using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using Seven_ADM;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmOS : Form
    {
        public FrmOS(string cod_pdv_computador, string usuario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmOS_Load(object sender, EventArgs e)
        {
            try
            {
                bllOS._FrmOS_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOS iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOS iniciado.");
                }
                //
                cbbpUsuario.Items.Clear();
                if (bllOS.Sel_Usuario_OS() == null)
                {
                    cbbpUsuario.Text = null;
                    cbbpUsuario.Enabled = false;
                    lblUsuario.Enabled = false;
                }
                else
                {
                    cbbpUsuario.Enabled = true;
                    lblUsuario.Enabled = true;
                    cbbpUsuario.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Usuario_OS().Rows)
                    {
                        cbbpUsuario.Items.Add(dr["id_usuario"].ToString() + "—" + dr["nome_usuario"].ToString());
                    }
                }
                //
                cbbFuncionario.Items.Clear();
                if (bllOS.Sel_Funcionario_OS() == null)
                {
                    cbbFuncionario.Enabled = false;
                    cbbFuncionario.Text = null;
                    lblFuncionario.Enabled = false;
                }
                else
                {
                    cbbFuncionario.Enabled = true;
                    cbbFuncionario.Items.Add("");
                    lblFuncionario.Enabled = true;
                    foreach (DataRow dr in bllOS.Sel_Funcionario_OS().Rows)
                    {
                        cbbFuncionario.Items.Add(dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString());
                    }
                }
                //
                cbbClieConsFunc.Items.Clear();
                if (bllOS.Sel_Cliente_OS() == null)
                {
                    cbbClieConsFunc.Enabled = false;
                    cbbClieConsFunc.Text = null;
                    lblClieCons.Enabled = false;
                }
                else
                {
                    cbbClieConsFunc.Enabled = true;
                    lblClieCons.Enabled = true;
                    cbbClieConsFunc.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Cliente_OS().Rows)
                    {
                        string cpfcnpj;
                        if (dr["cpf_cnpj"].ToString() == "")
                        {
                            cpfcnpj = "";
                        }
                        else
                        {
                            cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                        }
                        cbbClieConsFunc.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                    }
                }
                //
                cbbFormaPagamento.Items.Clear();
                if (bllOS.Sel_Forma_Pagamento_OS() == null)
                {
                    cbbFormaPagamento.Text = null;
                    cbbFormaPagamento.Enabled = false;
                    lblFormaPagamento.Enabled = false;
                }
                else
                {
                    cbbFormaPagamento.Enabled = true;
                    lblFormaPagamento.Enabled = true;
                    cbbFormaPagamento.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Forma_Pagamento_OS().Rows)
                    {
                        cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                    }
                }
                //
                mtxtpData.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOS.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOS.");
                }
            }
        }

        private void rbtnData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnClienteCons_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnClienteCons_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbClieConsFunc_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbClieConsFunc_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbClieConsFunc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbClieConsFunc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSituacao_MouseLeave(object sender, EventArgs e)
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

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
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

        private void btnGerar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFinalizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFinalizar_MouseLeave(object sender, EventArgs e)
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmOS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllOS._FrmOS_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOS foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOS foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmOS.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmOS.");
                }
            }
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

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
        }

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
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

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
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

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
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

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbClieConsFunc.Select();
            }
        }

        private void btnSelecionarData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbClieConsFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpUsuario.Select();
            }
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                mtxtDataBaixa.Select();
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

        private void cbbpSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFormaPagamento.Select();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmOSItem Os = new FrmOSItem(_Usuario, _Cod_PDV_Computador, false, null, 0))
                {
                    if (Os.ShowDialog() == DialogResult.OK)
                    {
                        dtOs.DataSource = bllOS.Sel_OS_Codigo(bllOS._Codigo);
                        //
                        bllOS._Codigo = null;
                        //
                        dtOs.Select();
                        // 
                        DialogResult = MessageBox.Show("Deseja gerar o documento O.S. agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            btnGerar_Click(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
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

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmPesqCliente Clie = new FrmPesqCliente(13, _Usuario, _Cod_PDV_Computador))
                {
                    if (Clie.ShowDialog() == DialogResult.OK)
                    {
                        cbbClieConsFunc.Items.Clear();
                        if (bllOS.Sel_Cliente_OS() == null)
                        {
                            cbbClieConsFunc.Text = null;
                            cbbClieConsFunc.Enabled = false;
                        }
                        else
                        {
                            cbbClieConsFunc.Enabled = true;
                            cbbClieConsFunc.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Cliente_OS().Rows)
                            {
                                string cpfcnpj;
                                if (dr["cpf_cnpj"].ToString() == "")
                                {
                                    cpfcnpj = "";
                                }
                                else
                                {
                                    cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                }
                                cbbClieConsFunc.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                            }
                        }
                        cbbClieConsFunc.Text = bllOS._Cliente_PesqCliente_Tabela;
                        bllOS._Cliente_PesqCliente_Tabela = null;
                        cbbClieConsFunc.Select();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbClieConsFunc.Text = null;
                bllOS._Cliente_PesqCliente_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(26))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllOS._Data_DatePicker1;
                    mtxtpData1.Text = bllOS._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtOs_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtOs.Columns[0].HeaderText = "Código";
            dtOs.Columns[1].HeaderText = "Cód. do Consumidor";
            dtOs.Columns[2].HeaderText = "Nome do Consumidor";
            dtOs.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
            dtOs.Columns[4].HeaderText = "Data";
            dtOs.Columns[5].HeaderText = "Horário";
            dtOs.Columns[6].Visible = false;
            dtOs.Columns[7].Visible = false;
            dtOs.Columns[8].Visible = false;
            dtOs.Columns[9].HeaderText = "Descrição do Item";
            dtOs.Columns[10].Visible = false;
            dtOs.Columns[11].Visible = false;
            dtOs.Columns[12].Visible = false;
            dtOs.Columns[13].Visible = false;
            dtOs.Columns[14].Visible = false;
            dtOs.Columns[15].HeaderText = "Valor Total (R$)";
            dtOs.Columns[16].HeaderText = "Observaçoes/Conclusão";
            dtOs.Columns[17].HeaderText = "Data de Conclusão";
            dtOs.Columns[18].HeaderText = "Horário de Conclusão";
            dtOs.Columns[19].HeaderText = "Situação";
            dtOs.Columns[20].Visible = false;
            dtOs.Columns[21].Visible = false;
            dtOs.Columns[22].Visible = false;
            dtOs.Columns[23].Visible = false;
            dtOs.Columns[24].Visible = false;
            dtOs.Columns[25].Visible = false;
            dtOs.Columns[26].Visible = false;
            dtOs.Columns[27].Visible = false;
            dtOs.Columns[28].Visible = false;
            dtOs.Columns[29].HeaderText = "A Pagar (R$)";
            dtOs.Columns[30].HeaderText = "Valor Pago (R$)";
            dtOs.Columns[31].HeaderText = "Troco (R$)";
            dtOs.Columns[32].Visible = false;
            dtOs.Columns[33].Visible = false;
            dtOs.Columns[34].Visible = false;
            dtOs.Columns[35].HeaderText = "Cód. do Usuário";
            dtOs.Columns[36].HeaderText = "Nome do Usuário";
            dtOs.Columns[37].Visible = false;
            dtOs.Columns[38].Visible = false;
            //
            dtOs.Columns[15].DisplayIndex = 20;
            dtOs.Columns[16].DisplayIndex = 37;
            dtOs.Columns[19].DisplayIndex = 32;
            dtOs.Columns[17].DisplayIndex = 33;
            dtOs.Columns[18].DisplayIndex = 34;

            /*
            dtOs.Columns[0].HeaderText = "Código";
            dtOs.Columns[1].HeaderText = "Cód. do Consumidor";
            dtOs.Columns[2].HeaderText = "Nome do Consumidor";
            dtOs.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
            dtOs.Columns[4].HeaderText = "Data";
            dtOs.Columns[5].HeaderText = "Horário";
            dtOs.Columns[6].Visible = "Data de Conclusão Prevista";
            dtOs.Columns[7].HeaderText = "Horário de Conclusão Prevista";
            dtOs.Columns[8].HeaderText = "Descrição";
            dtOs.Columns[9].HeaderText = "Descrição do Item/Equipamento";
            dtOs.Columns[10].HeaderText = "Marca";
            dtOs.Columns[11].HeaderText = "Modelo";
            dtOs.Columns[12].HeaderText = "Nº de Série";
            dtOs.Columns[13].HeaderText = "Total dos Serviços (R$)";
            dtOs.Columns[14].HeaderText = "Total dos Produtos (R$)";
            dtOs.Columns[15].HeaderText = "Valor Total (R$)";
            dtOs.Columns[16].HeaderText = "Observação.";
            dtOs.Columns[17].HeaderText = "Data de Conclusão";
            dtOs.Columns[18].HeaderText = "Horário de Conclusão";
            dtOs.Columns[19].HeaderText = "Situação";
            dtOs.Columns[20].Visible = false;
            dtOs.Columns[21].HeaderText = "Valor do Desconto (R$)";
            dtOs.Columns[22].HeaderText = "Desconto (%)";
            dtOs.Columns[23].HeaderText = "Valor do Acréscimo (R$)";
            dtOs.Columns[24].HeaderText = "Acréscimo (%)";
            dtOs.Columns[25].HeaderText = "Valor do Desconto Prod. (R$)";
            dtOs.Columns[26].HeaderText = "Desconto Prod. (%)";
            dtOs.Columns[27].HeaderText = "Valor do Acréscimo Prod. (R$)";
            dtOs.Columns[28].HeaderText = "Acréscimo Prod. (%)";
            dtOs.Columns[29].HeaderText = "Valor Real (R$)";
            dtOs.Columns[30].HeaderText = "Valor Pago (R$)";
            dtOs.Columns[31].HeaderText = "Troco (R$)";
            dtOs.Columns[32].HeaderText = "Cód. do Usuário Baixa";
            dtOs.Columns[33].HeaderText = "Nome do Usuário Baixa";
            dtOs.Columns[34].HeaderText = "Cód. do PDV/Computador Baixa";
            dtOs.Columns[35].HeaderText = "Cód. do Usuário";
            dtOs.Columns[36].HeaderText = "Nome do Usuário";
            dtOs.Columns[37].HeaderText = "Valor do Acéscimo do Item (R$)";
            dtOs.Columns[38].HeaderText = "Valor do Desconto do Item (R$)";
             */
            //
            dtOs.DefaultCellStyle.Font = new System.Drawing.Font(dtOs.Font, FontStyle.Bold);
            //
            dtOs.Columns[0].Width = 85;
            dtOs.Columns[1].Width = 125;
            dtOs.Columns[2].Width = 250;
            dtOs.Columns[3].Width = 155;
            dtOs.Columns[4].Width = 90;
            dtOs.Columns[5].Width = 75;
            dtOs.Columns[6].Width = 175;
            dtOs.Columns[7].Width = 175;
            dtOs.Columns[8].Width = 500;
            dtOs.Columns[9].Width = 320;
            dtOs.Columns[10].Width = 320;
            dtOs.Columns[11].Width = 320;
            dtOs.Columns[12].Width = 320;
            dtOs.Columns[13].Width = 150;
            dtOs.Columns[14].Width = 150;
            dtOs.Columns[15].Width = 150;
            dtOs.Columns[16].Width = 500;
            dtOs.Columns[17].Width = 150;
            dtOs.Columns[18].Width = 150;
            dtOs.Columns[19].Width = 175;
            dtOs.Columns[21].Width = 150;
            dtOs.Columns[22].Width = 150;
            dtOs.Columns[23].Width = 150;
            dtOs.Columns[24].Width = 175;
            dtOs.Columns[25].Width = 175;
            dtOs.Columns[26].Width = 175;
            dtOs.Columns[27].Width = 175;
            dtOs.Columns[28].Width = 175;
            dtOs.Columns[29].Width = 115;
            dtOs.Columns[30].Width = 115;
            dtOs.Columns[31].Width = 115;
            dtOs.Columns[32].Width = 150;
            dtOs.Columns[33].Width = 150;
            dtOs.Columns[34].Width = 200;
            dtOs.Columns[35].Width = 120;
            dtOs.Columns[36].Width = 150;
            dtOs.Columns[37].Width = 195;
            dtOs.Columns[38].Width = 195;
            //
            dtOs.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOs.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            lblRegistros.Text = "Registros: " + dtOs.Rows.Count;
            //
            decimal valortotalservico = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[13].Value.ToString() == "")
                {
                    valortotalservico += 0;
                }
                else
                {
                    valortotalservico += Convert.ToDecimal(dtOs.Rows[i].Cells[13].Value);
                }
            }
            lblValorTotalServicos.Text = Convert.ToDecimal(valortotalservico).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotalproduto = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[14].Value.ToString() == "")
                {
                    valortotalproduto += 0;
                }
                else
                {
                    valortotalproduto += Convert.ToDecimal(dtOs.Rows[i].Cells[14].Value);
                }
            }
            lblValorTotalProdutos.Text = Convert.ToDecimal(valortotalproduto).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal total = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[14].Value.ToString() == "")
                {
                    total += 0;
                }
                else
                {
                    total += Convert.ToDecimal(dtOs.Rows[i].Cells[15].Value);
                }
            }
            lblTotal.Text = Convert.ToDecimal(total).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotal = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[29].Value.ToString() == "")
                {
                    valortotal += 0;
                }
                else
                {
                    valortotal += Convert.ToDecimal(dtOs.Rows[i].Cells[29].Value);
                }
            }
            lblValorTotalOS.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valorpago = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[19].Value.ToString() == "CONCLUÍDO")
                {
                    valorpago += Convert.ToDecimal(dtOs.Rows[i].Cells[29].Value);
                }
                else if (dtOs.Rows[i].Cells[19].Value.ToString() == "PENDENTE")
                {
                    if (dtOs.Rows[i].Cells[30].Value.ToString() != "")
                    {
                        valorpago += Convert.ToDecimal(dtOs.Rows[i].Cells[30].Value);
                    }
                    else
                    {
                        valorpago += 0;
                    }
                }
            }
            //
            lblValorRecebido.Text = Convert.ToDecimal(valorpago).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtpData.Select();
                }
                else if ((mtxtDataBaixa.Text == "" & mtxtDataBaixa1.Text != "") || (mtxtDataBaixa.Text != "" & mtxtDataBaixa1.Text == ""))
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    MessageBox.Show("É necessário preencher ambos os campos de [ Data Baixa ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtDataBaixa.Select();
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    if (bllOS.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(cbbpSituacao.Text, cbbpUsuario.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClieConsFunc.Text, cbbFuncionario.Text, mtxtDataBaixa.Text, mtxtDataBaixa1.Text, mtxtHorarioBaixa.Text, mtxtHorarioBaixa1.Text, cbbFormaPagamento.Text, "", "", "") == null)
                    {
                        dtOs.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtOs.DataSource = bllOS.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(cbbpSituacao.Text, cbbpUsuario.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClieConsFunc.Text, cbbFuncionario.Text, mtxtDataBaixa.Text, mtxtDataBaixa1.Text, mtxtHorarioBaixa.Text, mtxtHorarioBaixa1.Text, cbbFormaPagamento.Text, "", "", "");
                        dtOs.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou ordem de serviço.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou ordem de serviço.");
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
                dtOs.DataSource = null;
            }
        }

        private void dtOs_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtOs.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                btnGerar.Enabled = false;
                btnFinalizar.Enabled = false;
                dtOs.Enabled = false;
                lblValorTotalServicos.Enabled = false;
                lblValorTotalProdutos.Enabled = false;
                lblValorTotalOS.Enabled = false;
                lblTotalServicos.Enabled = false;
                lblTotalProduto.Enabled = false;
                lblValorTotal.Enabled = false;
                lblRegistros.Enabled = false;
                btnEnviarZap.Enabled = false;
                btnEnviarEmail.Enabled = false;
                lblValorSituacao.Visible = false;
                pcibCross.Visible = false;
                pcibTick.Visible = false;
                btnReciboRegistro.Enabled = false;
                lblValorRecebido.Enabled = false;
                lblValorPago.Enabled = false;
                btnReciboRegistro.Enabled = false;
                lblTot.Enabled = false;
                lblTotal.Enabled = false;
                btnRelatorioPDF.Enabled = false;
                btnConsultarFuncionario.Enabled = false;
                btnConsultarPagamento.Enabled = false;
                btnConsultarServicos.Enabled = false;
                btnConsultarProduto.Enabled = false;
                lblValorTotalServicos.Text = null;
                lblValorTotalProdutos.Text = null;
                lblTotal.Text = null;
                lblValorTotalOS.Text = null;
                lblValorRecebido.Text = null;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnGerar.Enabled = true;
                dtOs.Enabled = true;
                lblValorTotalServicos.Enabled = true;
                lblValorTotalProdutos.Enabled = true;
                lblValorTotalOS.Enabled = true;
                lblTotalServicos.Enabled = true;
                lblTotalProduto.Enabled = true;
                lblValorTotal.Enabled = true;
                lblRegistros.Enabled = true;
                btnEnviarZap.Enabled = true;
                btnEnviarEmail.Enabled = true;
                lblValorSituacao.Visible = true;
                pcibTick.Visible = false;
                pcibCross.Visible = false;
                lblValorRecebido.Enabled = true;
                lblValorPago.Enabled = true;
                lblTot.Enabled = true;
                lblTotal.Enabled = true;
                btnRelatorioPDF.Enabled = true;
                btnConsultarFuncionario.Enabled = true;
                btnConsultarPagamento.Enabled = true;
                btnConsultarServicos.Enabled = true;
                btnConsultarProduto.Enabled = true;
                chkbDestOsPend_CheckedChanged(sender, e);
            }
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtOs_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            //
            decimal valortotalservico = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[13].Value.ToString() == "")
                {
                    valortotalservico += 0;
                }
                else
                {
                    valortotalservico += Convert.ToDecimal(dtOs.Rows[i].Cells[13].Value);
                }
            }
            lblValorTotalServicos.Text = Convert.ToDecimal(valortotalservico).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotalproduto = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[14].Value.ToString() == "")
                {
                    valortotalproduto += 0;
                }
                else
                {
                    valortotalproduto += Convert.ToDecimal(dtOs.Rows[i].Cells[14].Value);
                }
            }
            lblValorTotalProdutos.Text = Convert.ToDecimal(valortotalproduto).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal total = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[14].Value.ToString() == "")
                {
                    total += 0;
                }
                else
                {
                    total += Convert.ToDecimal(dtOs.Rows[i].Cells[15].Value);
                }
            }
            lblTotal.Text = Convert.ToDecimal(total).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotal = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[29].Value.ToString() == "")
                {
                    valortotal += 0;
                }
                else
                {
                    valortotal += Convert.ToDecimal(dtOs.Rows[i].Cells[29].Value);
                }
            }
            lblValorTotalOS.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valorpago = 0;
            for (int i = 0; i < dtOs.Rows.Count; i++)
            {
                if (dtOs.Rows[i].Cells[19].Value.ToString() == "CONCLUÍDO")
                {
                    valorpago += Convert.ToDecimal(dtOs.Rows[i].Cells[29].Value);
                }
                else if (dtOs.Rows[i].Cells[19].Value.ToString() == "PENDENTE")
                {
                    if (dtOs.Rows[i].Cells[30].Value.ToString() != "")
                    {
                        valorpago += Convert.ToDecimal(dtOs.Rows[i].Cells[30].Value);
                    }
                    else
                    {
                        valorpago += 0;
                    }
                }
            }
            //
            lblValorRecebido.Text = Convert.ToDecimal(valorpago).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void dtOs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtOs.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[13].DefaultCellStyle.Format = "n2";
            dtOs.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[14].DefaultCellStyle.Format = "n2";
            dtOs.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[15].DefaultCellStyle.Format = "n2";
            dtOs.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[21].DefaultCellStyle.Format = "n2";
            dtOs.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[22].DefaultCellStyle.Format = "n2";
            dtOs.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[23].DefaultCellStyle.Format = "n2";
            dtOs.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[24].DefaultCellStyle.Format = "n2";
            dtOs.Columns[25].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[25].DefaultCellStyle.Format = "n2";
            dtOs.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[26].DefaultCellStyle.Format = "n2";
            dtOs.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[27].DefaultCellStyle.Format = "n2";
            dtOs.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[28].DefaultCellStyle.Format = "n2";
            dtOs.Columns[29].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[29].DefaultCellStyle.Format = "n2";
            dtOs.Columns[30].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[30].DefaultCellStyle.Format = "n2";
            dtOs.Columns[31].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[31].DefaultCellStyle.Format = "n2";
            dtOs.Columns[37].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[37].DefaultCellStyle.Format = "n2";
            dtOs.Columns[38].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOs.Columns[38].DefaultCellStyle.Format = "n2";

            dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtOs.DefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
            //
            if (SelectedRow.Cells[19].Value.ToString() == "PENDENTE")
            {
                lblValorSituacao.Text = "PENDENTE";
                lblValorSituacao.ForeColor = Color.Red;
                pcibCross.Visible = true;
                pcibTick.Visible = false;
                btnFinalizar.Enabled = true;
                btnAlterar.Enabled = true;
                //
                if (SelectedRow.Cells[30].Value.ToString() != "")
                {
                    btnReciboRegistro.Enabled = true;
                    //
                    if (Convert.ToDecimal(SelectedRow.Cells[30].Value) < Convert.ToDecimal(SelectedRow.Cells[29].Value))
                    {
                        lblPagamentoParcial.Visible = true;
                    }
                    else
                    {
                        lblPagamentoParcial.Visible = false;
                    }
                }
                else
                {
                    btnReciboRegistro.Enabled = false;
                    lblPagamentoParcial.Visible = false;
                }
            }
            else
            {
                lblValorSituacao.Text = "CONCLUÍDO";
                lblPagamentoParcial.Visible = false;
                lblValorSituacao.ForeColor = Color.Green;
                pcibCross.Visible = false;
                pcibTick.Visible = true;
                btnFinalizar.Enabled = false;
                btnAlterar.Enabled = false;
                btnReciboRegistro.Enabled = true;
            }
        }

        private void lblValorTotalServicos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalServicos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalProdutos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalProdutos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalOS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalOS_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalServicos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Serviços (R$): " + lblValorTotalServicos.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalProdutos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produtos (R$): " + lblValorTotalProdutos.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalOS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A Pagar (R$): " + lblValorTotalOS.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtOs_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtOs.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtOs_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtOs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 6 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 17 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 13 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
            //
            if (e.ColumnIndex == 14 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
            //
            if (e.ColumnIndex == 15 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
            //
            if (e.ColumnIndex == 32 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 34 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 30 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por data, descrição, código, cliente/consumidor, funcionário e todos os dados cadastrados e/ou situação.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                //
                string codigo = SelectedRow.Cells[0].Value.ToString();
                //
                using (FrmOSItem Os = new FrmOSItem(_Usuario, _Cod_PDV_Computador, true, SelectedRow.Cells[0].Value.ToString(), 0))
                {
                    if (Os.ShowDialog() == DialogResult.OK)
                    {
                        dtOs.DataSource = bllOS.Sel_OS_Codigo(codigo);
                        //
                        dtOs.Select();
                    }
                    else
                    {
                        dtOs.DataSource = bllOS.Sel_OS_Codigo(codigo);
                        //
                        dtOs.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
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
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                //
                if (bllOS.Sel_OS_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtOs.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Ordem de Serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllUsuario.Sel_Perm_Exc_OS(_Usuario) == true)
                        {
                            if (bllOS.Sel_Venda_OS_Ver(SelectedRow.Cells[0].Value.ToString()) == true)
                            {
                                MessageBox.Show("A Ordem de Serviço selecionada está sendo utilizada por uma Venda, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                dtOs.Select();
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        if (dr["id_orcamento"].ToString() != "0")
                                        {
                                            bllOrcamento.Alterar_Situacao_Orcamento(dr["id_orcamento"].ToString(), "PENDENTE");
                                        }
                                    }
                                }
                                //
                                if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        bllOS.Alterar_Estoque_Produto_OS(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                        //
                                        if (dr["id_orcamento"].ToString() != "0")
                                        {
                                            bllOrcamento.Alterar_Situacao_Orcamento(dr["id_orcamento"].ToString(), "PENDENTE");
                                        }
                                    }
                                }
                                //
                                bllOS.Excluir_Items_OS_Produto(SelectedRow.Cells[0].Value.ToString());
                                bllOS.Excluir_Items_OS_Servico(SelectedRow.Cells[0].Value.ToString());
                                bllOS.Excluir_Items_OS_Funcionario(SelectedRow.Cells[0].Value.ToString());
                                bllOS.Excluir_Pagamento_OS(SelectedRow.Cells[0].Value.ToString());
                                //
                                if (bllNFSe.Sel_NFSe_Menu_NFSe("_", "_", "_", "_", null, null, null, SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; bllNFSe.Sel_NFSe_Menu_NFSe("_", "_", "_", "_", null, null, null, SelectedRow.Cells[0].Value.ToString()).Rows.Count > i; i++)
                                    {
                                        DataRow dr = bllNFSe.Sel_NFSe_Menu_NFSe("_", "_", "_", "_", null, null, null, SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        bllOS.Excluir_Item_NFSe_OS(dr["id_nfse"].ToString());
                                    }
                                    //
                                    bllOS.Excluir_NFSe_OS(SelectedRow.Cells[0].Value.ToString());
                                }
                                //
                                bllOS.Excluir(SelectedRow.Cells[0].Value.ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUIU UMA ORDEM DE SERVICO", "ORDEM DE SERVICO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Ordem de serviço excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Ordem de serviço excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                                }
                                //
                                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                                mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                                if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                                {
                                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtpData.Select();
                                }
                                else if ((mtxtDataBaixa.Text == "" & mtxtDataBaixa1.Text != "") || (mtxtDataBaixa.Text != "" & mtxtDataBaixa1.Text == ""))
                                {
                                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    MessageBox.Show("É necessário preencher ambos os campos de [ Data Baixa ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtDataBaixa.Select();
                                }
                                else
                                {
                                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    //
                                    if (bllOS.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(cbbpSituacao.Text, cbbpUsuario.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClieConsFunc.Text, cbbFuncionario.Text, mtxtDataBaixa.Text, mtxtDataBaixa1.Text, mtxtHorarioBaixa.Text, mtxtHorarioBaixa1.Text, cbbFormaPagamento.Text, "", "", "") == null)
                                    {
                                        dtOs.DataSource = null;
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        dtOs.DataSource = bllOS.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(cbbpSituacao.Text, cbbpUsuario.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClieConsFunc.Text, cbbFuncionario.Text, mtxtDataBaixa.Text, mtxtDataBaixa1.Text, mtxtHorarioBaixa.Text, mtxtHorarioBaixa1.Text, cbbFormaPagamento.Text, "", "", "");
                                        dtOs.Select();
                                    }
                                }
                                //
                                MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para excluir Ordens de Serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        dtOs.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
            }
        }

        private void Gerar2ViaPDF()
        {
            if (bllOS._Tipo_Impressao == "PDF A4")
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 14, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9);
                    var fonte3 = new XFont("Microsoft Sans Serif", 11, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //                   
                    //Linhas do datagrid
                    int Incrementar = 0;
                    //                    
                    int AumentoImagem = 0;
                    if (bllOS._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 140, 80);
                        imagem1.Dispose();
                        AumentoImagem = 30;
                    }
                    else
                    {
                        AumentoImagem = 0;
                    }
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    textFormatter1.DrawString(dr["nome"].ToString(), fonte3, XBrushes.Black, new XRect(AumentoImagem + 7 + Margem_Esq, 7 + Margem_Topo, 575, 28));
                    //
                    textFormatter1.DrawString(dr["fantasia"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 7 + Margem_Esq, 20 + Margem_Topo, 575, 10));
                    //
                    string cpf_cnpj;
                    string ie_rg;
                    if (Convert.ToByte(dr["pessoa"]) == 0)
                    {
                        cpf_cnpj = "CPF:";
                        ie_rg = "RG:";
                    }
                    else
                    {
                        cpf_cnpj = "CNPJ:";
                        ie_rg = "IE:";
                    }
                    //
                    //graphics.DrawRectangle(pen, XBrushes.White, AumentoImagem + 45 + Margem_Esq, 40 + Margem_Topo, 500, 33);
                    textFormatter1.DrawString(cpf_cnpj + " " + dr["cpf_cnpj"].ToString() + ", " + ie_rg + " " + dr["ie_rg"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 45 + Margem_Esq, 30 + Margem_Topo, 500, 11));
                    //
                    textFormatter1.DrawString(dr["endereco"].ToString() + ", " + dr["numero"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 45 + Margem_Esq, 40 + Margem_Topo, 500, 33));
                    //
                    textFormatter1.DrawString("RECIBO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 77 + Margem_Topo, 575, 15));
                    //
                    Margem_Topo = Margem_Topo + 15;
                    //
                    DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                    //
                    textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                    //
                    textFormatter3.DrawString("Valor Total a Pagar(R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                    //
                    textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 83 + Margem_Topo, 575, 10));
                    //
                    DataRow drConsumidor = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                    textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[2].Value.ToString() + "  -  CPF/CNPJ: " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 94 + Margem_Topo, 570, 10));
                    //
                    string quantia = SelectedRow.Cells[30].Value.ToString();
                    //
                    Margem_Topo = Margem_Topo + 10;
                    //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 120 + Margem_Topo, 570, 22);
                    textFormatter2.DrawString("Recebi(emos) de " + SelectedRow.Cells[2].Value.ToString() + ", a quantia de " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), referente ao pagamento da Ordem de Serviço nº " + SelectedRow.Cells[0].Value.ToString() + ", " + SelectedRow.Cells[9].Value.ToString() + ".", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 105 + Margem_Topo, 570, 22));
                    //
                    textFormatter2.DrawString("Pagamento                                         -                                                 Valor Pago (R$)               -               Data               -               Hora", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 127 + Margem_Topo, 575, 10));
                    //
                    textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 128 + Margem_Topo, 570, 10));
                    //
                    for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        dr = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                        //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 154 + Margem_Topo, 260, 10);
                        textFormatter2.DrawString(dr["tipo"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 138 + Margem_Topo, 260, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 265 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 380 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(dr["data_pagamento"].ToString().Remove(10), fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(475 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        Incrementar = Incrementar + 8;
                    }
                    //
                    textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 132 + Margem_Topo, 570, 10));
                    //
                    textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[29].Value) - (Convert.ToDecimal(SelectedRow.Cells[30].Value) - Convert.ToDecimal(SelectedRow.Cells[31].Value))).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                    //
                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595    ", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, Incrementar + 153 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                    //
                    textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 160 + Margem_Topo, 5, 595));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep, tel, cel;
                    byte pessoa;
                    //
                    nome = dr["nome"].ToString();
                    fantasia = dr["fantasia"].ToString();
                    cpf_cnpj = dr["cpf_cnpj"].ToString();
                    ie_rg = dr["ie_rg"].ToString();
                    endereco = dr["endereco"].ToString();
                    numero = dr["numero"].ToString();
                    bairro = dr["bairro"].ToString();
                    cidade = dr["cidade"].ToString();
                    uf = dr["uf"].ToString();
                    cep = dr["cep"].ToString();
                    pessoa = Convert.ToByte(dr["pessoa"]);
                    tel = dr["telefone"].ToString();
                    cel = dr["celular"].ToString();
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
                    var fonte3 = new XFont("Courrier New", 12, XFontStyle.Regular);
                      var fonte4 = new XFont("Courrier Regular", 6, XFontStyle.Italic);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_80_Pdv(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_80_Pdv(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    //
                    if (bllOS._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 20 + Margem_Esq, 1 + Margem_Topo, 158, 69);
                        imagem1.Dispose();
                        Margem_Topo = Margem_Topo - 15;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                    }
                    //        
                    Margem_Topo = Margem_Topo + 5;
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 2 + Margem_Topo, 203, 16);     
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
                    if (tel != "" & cel != "")
                    {
                        tel = tel + " - ";
                    }
                    //
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep + Environment.NewLine + tel + cel, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 110 + Margem_Topo, 198, 43));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Incrementar = Incrementar + 8;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 198, 24));
                    //Margem_Topo = Margem_Topo - 4;
                    textFormatter1.DrawString("RECIBO", fonte3, XBrushes.Black, new XRect(5 + Margem_Esq, 149 + Margem_Topo + Incrementar, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Margem_Topo + Incrementar, 198, 24));
                    //
                    DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                    //
                    textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 183 + Margem_Topo + Incrementar, 198, 8));
                    //
                    textFormatter3.DrawString("Valor Total a Pagar (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 171 + Margem_Topo + Incrementar, 198, 12));
                    //
                    textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 191 + Margem_Topo + Incrementar, 198, 8));
                    //
                    Margem_Topo = Margem_Topo - 17;
                    //
                    DataRow drConsumidor = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 217 + Margem_Topo + Incrementar, 198, 24);
                    if (SelectedRow.Cells[2].Value.ToString().Length > 20)
                    {
                        if (!SelectedRow.Cells[2].Value.ToString().Substring(0, 20).Contains(" ") || (!SelectedRow.Cells[2].Value.ToString().Substring(20).Contains(" ") & SelectedRow.Cells[2].Value.ToString().Substring(20).Length > 10))
                        {
                            textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString().Insert(20, Environment.NewLine) + Environment.NewLine + "CPF/CNPJ: " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo + Incrementar, 198, 24));
                        }
                        else
                        {
                            textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString() + Environment.NewLine + "CPF/CNPJ: " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo + Incrementar, 198, 24));
                        }
                        Margem_Topo = Margem_Topo + 16;
                    }
                    else
                    {
                        textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString() + Environment.NewLine + "CPF/CNPJ: " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo + Incrementar, 198, 24));
                        Margem_Topo = Margem_Topo + 12;
                    }
                    //                    
                    string quantia = SelectedRow.Cells[30].Value.ToString();
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 225 + Margem_Topo + Incrementar, 198, 64);
                    textFormatter2.DrawString("Recebi(emos) de " + SelectedRow.Cells[2].Value.ToString() + ", a quantia de " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), referente ao pagamento da Ordem de Serviço nº " + SelectedRow.Cells[0].Value.ToString() + ", " + SelectedRow.Cells[9].Value.ToString() + ".", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo + Incrementar, 198, 64));
                    //
                    textFormatter2.DrawString(" Pagamento - Valor Pago (R$) - Data e Hora", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 291 + Margem_Topo + Incrementar, 198, 8));
                    //
                    textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 296 + Margem_Topo, 198, 16));
                    //
                    Margem_Topo = Margem_Topo + 2;
                    //
                    for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        dr = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                        textFormatter2.DrawString(dr["tipo"].ToString() + "  -  " + Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")) + " - " + dr["data_pagamento"].ToString().Remove(10) + " " + dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 305 + Margem_Topo, 198, 8));
                        //
                        Incrementar = Incrementar + 9;
                    }
                    //
                    textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 300 + Margem_Topo, 198, 16));
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 310 + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[29].Value) - (Convert.ToDecimal(SelectedRow.Cells[30].Value) - Convert.ToDecimal(SelectedRow.Cells[31].Value))).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 320 + Margem_Topo, 198, 8));
                    //
                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 333 + Margem_Topo, 198, 10));

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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
        }


        private void GerarRelatorio() 
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
                if (bllOS._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                {
                    XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                    graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 140, 116);
                    imagem1.Dispose();
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
                textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + dr["cpf_cnpj"].ToString() + Environment.NewLine + dr["ie_rg"].ToString() + Environment.NewLine + dr["endereco"].ToString() + "," + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + dr["telefone"].ToString() + " " + dr["celular"].ToString() + Environment.NewLine + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                //
                textFormatter1.DrawString("Relatório de Ordem de Serviço", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                //
                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                textFormatter2.DrawString("CÓDIGO  CONSUMIDOR   DATA    A PAGAR   VALOR PAGO   TROCO   SITUAÇÃO   OBSERVAÇÃO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                //                  
                //Linhas do datagrid
                int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                int ContadorPagina = 1;
                int pagina = 16;
                bool PrimeiraPagina = true;

                int TotalPaginas = 1;//Numero de páginas do documento.
                int registros = 37;
                for (int i = 0; i < dtOs.Rows.Count; i++)
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
                for (int linha = 0; linha < dtOs.Rows.Count; linha++)
                {
                    DataGridViewRow SelectedRow = dtOs.Rows[linha];
                    if (linha < 16 & PrimeiraPagina == true)
                    {
                        if (linha == dtOs.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                        { 
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 200) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 75, 18));
                            //
                            textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 200) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 200) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Horário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(135 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(249 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Valor Pago:", fonte2, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[30].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("0,00", fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            textFormatter2.DrawString("Troco:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(429 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(478 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte4, XBrushes.Black, new XRect(520 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Observação: " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 216) + Margem_Topo, 575, 21));
                            //
                            //
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Total (R$): " + lblTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString("A Pagar (R$): " + lblValorTotalOS.Text, fonte2, XBrushes.Black, new XRect(240 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString("Pago (R$): " + lblValorRecebido.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                            //
                            Incrementar = 36 + Incrementar;//incrementando                               
                        }
                        else
                        {
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 200) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 75, 18));
                            //
                            textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 200) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 200) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Horário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(135 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(249 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Valor Pago:", fonte2, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[30].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("0,00", fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            textFormatter2.DrawString("Troco:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(429 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(478 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte4, XBrushes.Black, new XRect(520 + Margem_Esq, (Incrementar + 209) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Observação: " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 216) + Margem_Topo, 575, 21));
                            //
                            Incrementar = 36 + Incrementar;//incrementando                                           
                        }
                        //
                        if (linha == (pagina - 1) & dtOs.Rows.Count > 16)
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
                            textFormatter1.DrawString("Relatório de Ordem de Serviço", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                            textFormatter1.DrawString("Relatório de Ordem de Serviço", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                            textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                            textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                        }
                        //
                        if (linha == dtOs.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                        {
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 22) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 75, 18));
                            //
                            textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 22) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 22) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Horário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(135 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(249 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Valor Pago:", fonte2, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[30].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("0,00", fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            textFormatter2.DrawString("Troco:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(429 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(478 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte4, XBrushes.Black, new XRect(520 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Observação: " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 38) + Margem_Topo, 575, 21));
                            //
                            //
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Total (R$): " + lblTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString("A Pagar (R$): " + lblValorTotalOS.Text, fonte2, XBrushes.Black, new XRect(240 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString("Pago (R$): " + lblValorRecebido.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                            //
                            Incrementar = 36 + Incrementar;//incrementando                               
                        }
                        else
                        {
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 22) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 75, 18));
                            //
                            textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 22) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 22) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Horário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(135 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(249 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Valor Pago:", fonte2, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[30].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("0,00", fonte4, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            textFormatter2.DrawString("Troco:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(429 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(478 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte4, XBrushes.Black, new XRect(520 + Margem_Esq, (Incrementar + 31) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Observação: " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 38) + Margem_Topo, 575, 21));
                            //
                            Incrementar = 36 + Incrementar;//incrementando       
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
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS");
                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                }
                else
                {
                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                }
            }
        }

        private void GerarPDF()
        {
            if (bllOS._Tipo_Impressao == "PDF A4")
            {
                this.Cursor = Cursors.WaitCursor;
                dtOs.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                //
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Microsoft Sans Serif", 18, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    var fonte5 = new XFont("Microsoft Sans Serif", 8);
                    var fonte6 = new XFont("Microsoft Sans Serif", 7, XFontStyle.Bold);
                    XPen pen2 = new XPen(XColors.White);
                    XPen pen = new XPen(XColors.Black);
                    int Incrementar = 0;
                    DataRow dr;
                    DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    bool novapaginaservico = false;
                    bool novapaginaproduto = false;
                    bool novapaginafuncionario = false;
                    int TotalPaginas = 1;
                    //
                    if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            if (i == 11)
                            {
                                novapaginaservico = true;
                            }
                        }
                    }
                    //
                    if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            if (i == 11)
                            {
                                novapaginaproduto = true;
                            }
                        }
                    }
                    //
                    if (bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            if (i == 5)
                            {
                                novapaginafuncionario = true;
                            }
                        }
                    }
                    //
                    if (novapaginaservico == true || novapaginaproduto == true || novapaginafuncionario == true)
                    {
                        TotalPaginas = 2;
                    }
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllOS._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 140, 116);
                        imagem1.Dispose();
                    }
                    dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //graphics.DrawRectangle(pen, 150 + Margem_Esq, 7 + Margem_Topo, 335, 28);
                    if (!dr["nome"].ToString().Contains(" ") & dr["nome"].ToString().Length > 38)
                    {
                        textFormatter1.DrawString(dr["nome"].ToString().Insert(38, Environment.NewLine), fonte1, XBrushes.Black, new XRect(150 + Margem_Esq, 7 + Margem_Topo, 335, 28));
                    }
                    else
                    {
                        textFormatter1.DrawString(dr["nome"].ToString(), fonte1, XBrushes.Black, new XRect(150 + Margem_Esq, 7 + Margem_Topo, 335, 28));
                    }
                    //
                    string cpf_cnpj;
                    string ie_rg;
                    if (Convert.ToByte(dr["pessoa"]) == 0)
                    {
                        cpf_cnpj = "CPF:";
                        ie_rg = "RG:";
                    }
                    else
                    {
                        cpf_cnpj = "CNPJ:";
                        ie_rg = "IE:";
                    }
                    //
                    textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + cpf_cnpj + " " + dr["cpf_cnpj"].ToString() + Environment.NewLine + ie_rg + " " + dr["ie_rg"].ToString() + Environment.NewLine + dr["endereco"].ToString() + ","  + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + dr["telefone"].ToString() + " " + dr["celular"].ToString() + Environment.NewLine + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                    //
                    //DATA
                    graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 5 + Margem_Topo, 95, 122);
                    textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(531 + Margem_Esq, 10 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(510 + Margem_Esq, 22 + Margem_Topo, page.Width, page.Height));
                    //HORÁRIO                    
                    textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(527 + Margem_Esq, 38 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(516 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    //Nº OS
                    textFormatter2.DrawString("Ordem de Serviço:", fonte4, XBrushes.Black, new XRect(505 + Margem_Esq, 78 + Margem_Topo, page.Width, page.Height));
                    graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 90 + Margem_Topo, 95, 37);
                    textFormatter1.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte3, XBrushes.Black, new XRect(494 + Margem_Esq, 98 + Margem_Topo, 95, 37));
                    //
                    //DADOS CLIENTE
                    string endereco = "";
                    string bairro = "";
                    string cep = "";
                    string municipio = "";
                    string uf = "";
                    string telefone = "";
                    string celular = "";
                    string email = "";
                    //
                    if (SelectedRow.Cells[1].Value.ToString() != "0")
                    {
                        dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                        //
                        endereco = dr["endereco"].ToString();
                        //
                        bairro = dr["bairro"].ToString();
                        //
                        cep = dr["cep"].ToString();
                        //
                        municipio = dr["cidade"].ToString();
                        //
                        uf = dr["uf"].ToString();
                        //
                        telefone = dr["telefone"].ToString();
                        //
                        if (telefone == null || telefone == "")
                        {
                            celular = dr["celular"].ToString();
                        }
                        else
                        {
                            celular = " / " + dr["celular"].ToString();
                        }
                        //
                        if ((telefone == null || telefone == "") || (celular == null || celular == ""))
                        {
                            email = dr["email"].ToString();
                        }
                        else
                        {
                            email = " / " + dr["email"].ToString();
                        }
                    }
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 130 + Margem_Topo, 584, 15);
                    textFormatter1.DrawString("DADOS DO CLIENTE/CONSUMIDOR", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 132 + Margem_Topo, page.Width, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 145 + Margem_Topo, 400, 25);
                    textFormatter2.DrawString("NOME", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 147 + Margem_Topo, 400, 15));
                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 158 + Margem_Topo, 400, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 405 + Margem_Esq, 145 + Margem_Topo, 184, 25);
                    textFormatter2.DrawString("CPF/CNPJ", fonte2, XBrushes.Black, new XRect(407 + Margem_Esq, 147 + Margem_Topo, 184, 25));
                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, 158 + Margem_Topo, 184, 25));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 170 + Margem_Topo, 275, 25);
                    textFormatter2.DrawString("ENDEREÇO", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 172 + Margem_Topo, 275, 15));
                    textFormatter2.DrawString(endereco, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 183 + Margem_Topo, 275, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 280 + Margem_Esq, 170 + Margem_Topo, 220, 25);
                    textFormatter2.DrawString("BAIRRO", fonte2, XBrushes.Black, new XRect(282 + Margem_Esq, 172 + Margem_Topo, 220, 15));
                    textFormatter2.DrawString(bairro, fonte4, XBrushes.Black, new XRect(282 + Margem_Esq, 183 + Margem_Topo, 220, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 500 + Margem_Esq, 170 + Margem_Topo, 89, 25);
                    textFormatter2.DrawString("CEP", fonte2, XBrushes.Black, new XRect(502 + Margem_Esq, 172 + Margem_Topo, 89, 15));
                    textFormatter2.DrawString(cep, fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, 183 + Margem_Topo, 89, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 195 + Margem_Topo, 175, 25);
                    textFormatter2.DrawString("MUNICÍPIO", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 197 + Margem_Topo, 175, 15));
                    textFormatter2.DrawString(municipio, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 208 + Margem_Topo, 175, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 180 + Margem_Esq, 195 + Margem_Topo, 100, 25);
                    textFormatter2.DrawString("UF", fonte2, XBrushes.Black, new XRect(182 + Margem_Esq, 197 + Margem_Topo, 100, 15));
                    textFormatter2.DrawString(uf, fonte4, XBrushes.Black, new XRect(182 + Margem_Esq, 208 + Margem_Topo, 100, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 280 + Margem_Esq, 195 + Margem_Topo, 309, 25);
                    textFormatter2.DrawString("CONTATO", fonte2, XBrushes.Black, new XRect(282 + Margem_Esq, 197 + Margem_Topo, 309, 15));
                    textFormatter2.DrawString(telefone + celular + email, fonte4, XBrushes.Black, new XRect(282 + Margem_Esq, 208 + Margem_Topo, 309, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 223 + Margem_Topo, 584, 15);
                    textFormatter1.DrawString("DADOS DO ITEM/EQUIPAMENTO", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 225 + Margem_Topo, page.Width, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 238 + Margem_Topo, 325, 25);
                    textFormatter2.DrawString("DESCRIÇÃO DO ITEM", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 240 + Margem_Topo, 309, 15));
                    textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 251 + Margem_Topo, 309, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 300 + Margem_Esq, 238 + Margem_Topo, 289, 25);
                    textFormatter2.DrawString("MARCA", fonte2, XBrushes.Black, new XRect(302 + Margem_Esq, 240 + Margem_Topo, 309, 15));
                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(302 + Margem_Esq, 251 + Margem_Topo, 309, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 263 + Margem_Topo, 325, 25);
                    textFormatter2.DrawString("MODELO", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 265 + Margem_Topo, 309, 15));
                    textFormatter2.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 276 + Margem_Topo, 309, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 300 + Margem_Esq, 263 + Margem_Topo, 289, 25);
                    textFormatter2.DrawString("Nº DE SÉRIE", fonte2, XBrushes.Black, new XRect(302 + Margem_Esq, 265 + Margem_Topo, 309, 15));
                    textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte4, XBrushes.Black, new XRect(302 + Margem_Esq, 276 + Margem_Topo, 309, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 291 + Margem_Topo, 485, 15);
                    textFormatter1.DrawString("DESCRIÇÃO COMPLETA DO SERVIÇO", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 293 + Margem_Topo, 485, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 306 + Margem_Topo, 485, 45);
                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, 485, 50));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 354 + Margem_Topo, 485, 15);
                    textFormatter1.DrawString("OBSERVAÇÕES / CONCLUSÃO", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 355 + Margem_Topo, 485, 15));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 369 + Margem_Topo, 485, 45);
                    textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 371 + Margem_Topo, 485, 50));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 291 + Margem_Topo, 95, 122);
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 494 + Margem_Esq, 291 + Margem_Topo, 95, 24);
                    textFormatter1.DrawString("CONCLUSÃO\nPREVISTA", fonte2, XBrushes.Black, new XRect(494 + Margem_Esq, 293 + Margem_Topo, 95, 30));
                    //
                    //DATA CONCLUSÃO PREV
                    textFormatter2.DrawString("Data / Horário:", fonte4, XBrushes.Black, new XRect(510 + Margem_Esq, 316 + Margem_Topo, page.Width, page.Height));
                    if (SelectedRow.Cells[6].Value.ToString() != "")
                    {
                        textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString().Remove(10) + Environment.NewLine + "  " + SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 327 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 494 + Margem_Esq, 348 + Margem_Topo, 95, 15);
                    textFormatter1.DrawString("SITUAÇÃO", fonte2, XBrushes.Black, new XRect(494 + Margem_Esq, 350 + Margem_Topo, 95, 15));
                    //
                    if (SelectedRow.Cells[19].Value.ToString() != "PENDENTE")
                    {
                        textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(505 + Margem_Esq, 367 + Margem_Topo, page.Width, page.Height));
                        //
                        //DATA CONCLUSAO
                        textFormatter2.DrawString("Data / Horário:", fonte4, XBrushes.Black, new XRect(510 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                        if (SelectedRow.Cells[18].Value.ToString() != "")
                        {
                            textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString().Remove(10) + Environment.NewLine + "  " + SelectedRow.Cells[18].Value.ToString(), fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 390 + Margem_Topo, page.Width, page.Height));
                        }
                        else
                        {
                            textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 390 + Margem_Topo, page.Width, page.Height));
                        }
                    }
                    else
                    {
                        textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(505 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 417 + Margem_Topo, 584, 15);
                    textFormatter1.DrawString("SERVIÇO(S)", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 419 + Margem_Topo, page.Width, 15));
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo, 584, 120);
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 432 + Margem_Topo, 584, 15);
                    textFormatter2.DrawString("Cód.", fonte2, XBrushes.Black, new XRect(10 + Margem_Esq, 434 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Descrição", fonte2, XBrushes.Black, new XRect(75 + Margem_Esq, 434 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Qtd.", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, 434 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Vl. Unit. (R$)", fonte2, XBrushes.Black, new XRect(425 + Margem_Esq, 434 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Vl. Total (R$)", fonte2, XBrushes.Black, new XRect(520 + Margem_Esq, 434 + Margem_Topo, page.Width, 15));
                    //
                    if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            //
                            textFormatter2.DrawString(dr["id_servico"].ToString(), fonte5, XBrushes.Black, new XRect(10 + Margem_Esq, (Incrementar + 449) + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString(dr["descricao"].ToString(), fonte5, XBrushes.Black, new XRect(75 + Margem_Esq, (Incrementar + 449) + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 449) + Margem_Topo, page.Width, 15));
                            //
                            if (dr["valor_desconto"].ToString() != "0" || dr["valor_acrescimo"].ToString() != "0")
                            {
                                textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(dr["valor_acrescimo"]).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(dr["valor_desconto"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 449) + Margem_Topo, 130, 15));
                            }
                            else
                            {
                                textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 449) + Margem_Topo, 130, 15));
                            }
                            //
                            textFormatter2.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(535 + Margem_Esq, (Incrementar + 449) + Margem_Topo, page.Width, 15));
                            //
                            Incrementar = 9 + Incrementar;
                            //
                            if (i == 10)
                            {
                                break;
                            }
                        }
                    }
                    //
                    Incrementar = 0;
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 555 + Margem_Topo, 584, 15);
                    textFormatter1.DrawString("PRODUTO(S) ADICIONADO(S)", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 557 + Margem_Topo, page.Width, 15));
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 570 + Margem_Topo, 584, 120);
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 570 + Margem_Topo, 584, 15);
                    textFormatter2.DrawString("Cód.", fonte2, XBrushes.Black, new XRect(10 + Margem_Esq, 572 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Descrição", fonte2, XBrushes.Black, new XRect(80 + Margem_Esq, 572 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Qtd.", fonte2, XBrushes.Black, new XRect(360 + Margem_Esq, 572 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Un.", fonte2, XBrushes.Black, new XRect(405 + Margem_Esq, 572 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Vl. Unit. (R$)", fonte2, XBrushes.Black, new XRect(430 + Margem_Esq, 572 + Margem_Topo, page.Width, 15));
                    textFormatter2.DrawString("Vl. Total (R$)", fonte2, XBrushes.Black, new XRect(520 + Margem_Esq, 572 + Margem_Topo, page.Width, 15));
                    //
                    if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            //
                            textFormatter2.DrawString(dr["id_produto"].ToString(), fonte5, XBrushes.Black, new XRect(10 + Margem_Esq, (Incrementar + 587) + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString(dr["descricao"].ToString(), fonte5, XBrushes.Black, new XRect(80 + Margem_Esq, (Incrementar + 587) + Margem_Topo, page.Width, 15));
                            graphics.DrawRectangle(pen2, XBrushes.White, 360 + Margem_Esq, (Incrementar + 587) + Margem_Topo, 220, 10);
                            textFormatter2.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 587) + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString(dr["um"].ToString(), fonte5, XBrushes.Black, new XRect(405 + Margem_Esq, (Incrementar + 587) + Margem_Topo, page.Width, 15));
                            //
                            if (dr["valor_desconto"].ToString() != "0" || dr["valor_acrescimo"].ToString() != "0")
                            {
                                textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(dr["valor_acrescimo"]).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(dr["valor_desconto"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 587) + Margem_Topo, 130, 15));
                            }
                            else
                            {
                                textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 587) + Margem_Topo, 130, 15));
                            }
                            //textFormatter2.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(430 + Margem_Esq, (Incrementar + 587) + Margem_Topo, page.Width, 15));
                            //
                            textFormatter2.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(520 + Margem_Esq, (Incrementar + 587) + Margem_Topo, page.Width, 15));
                            //
                            Incrementar = 9 + Incrementar;
                            //
                            if (i == 10)
                            {
                                break;
                            }
                        }
                    }
                    //
                    Incrementar = 0;
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 693 + Margem_Topo, 584, 15);
                    textFormatter1.DrawString("FUNCIONÁRIO(S)", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 695 + Margem_Topo, page.Width, 15));
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 708 + Margem_Topo, 584, 48);
                    //
                    if (bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            //
                            textFormatter2.DrawString(dr["id_funcionario"].ToString() + " - " + dr["nome_funcionario"].ToString(), fonte5, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 710) + Margem_Topo, page.Width, 15));
                            //
                            Incrementar = 9 + Incrementar;
                            //
                            if (i == 4)
                            {
                                break;
                            }
                        }
                    }
                    //
                    Incrementar = 0;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 759 + Margem_Topo, 584, 27);
                    string valorservico;
                    if (SelectedRow.Cells[13].Value.ToString() == "")
                    {
                        valorservico = "0";
                    }
                    else
                    {
                        valorservico = SelectedRow.Cells[13].Value.ToString();
                    }
                    textFormatter2.DrawString("SERVIÇOS (R$): " + Convert.ToDecimal(valorservico).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                    string valorproduto;
                    if (SelectedRow.Cells[14].Value.ToString() == "")
                    {
                        valorproduto = "0";
                    }
                    else
                    {
                        valorproduto = SelectedRow.Cells[14].Value.ToString();
                    }
                    //
                    textFormatter2.DrawString("PRODUTOS (R$): " + Convert.ToDecimal(valorproduto).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(165 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                    //
                    textFormatter2.DrawString("TOTAL (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(310 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                    //
                    textFormatter2.DrawString("ACRÉSCIMO (R$): " + (Convert.ToDecimal(SelectedRow.Cells[23].Value) + Convert.ToDecimal(SelectedRow.Cells[38].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                    //
                    textFormatter2.DrawString("DESCONTO (R$): " + (Convert.ToDecimal(SelectedRow.Cells[21].Value) + Convert.ToDecimal(SelectedRow.Cells[37].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                    //
                    textFormatter2.DrawString("A PAGAR (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                    //
                    if (SelectedRow.Cells[30].Value.ToString() == "")
                    {
                        textFormatter2.DrawString("PAGO (R$): 0,00", fonte2, XBrushes.Black, new XRect(455 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                    }
                    else
                    {
                        if (SelectedRow.Cells[19].Value.ToString() == "PENDENTE")
                        {
                            textFormatter2.DrawString("TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        }
                        else
                        {
                            textFormatter2.DrawString("TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        }
                    }
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 789 + Margem_Topo, 165, 30);
                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10) + " " + SelectedRow.Cells[5].Value.ToString(), fonte5, XBrushes.Black, new XRect(45 + Margem_Esq, 791 + Margem_Topo, page.Width, 15));
                    graphics.DrawRectangle(pen, XBrushes.White, 165 + Margem_Esq, 789 + Margem_Topo, 424, 30);
                    textFormatter2.DrawString("CLIENTE/CONSUMIDOR", fonte5, XBrushes.Black, new XRect(210 + Margem_Esq, 791 + Margem_Topo, page.Width, 15));
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 811 + Margem_Topo, 165, 8);
                    textFormatter2.DrawString("DATA", fonte6, XBrushes.Black, new XRect(75 + Margem_Esq, 811 + Margem_Topo, page.Width, 15));
                    graphics.DrawRectangle(pen, XBrushes.White, 165 + Margem_Esq, 811 + Margem_Topo, 424, 8);
                    textFormatter2.DrawString("CLIENTE/CONSUMIDOR", fonte6, XBrushes.Black, new XRect(335 + Margem_Esq, 811 + Margem_Topo, page.Width, 15));
                    //
                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595    ", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: " + 1 + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    if (novapaginaservico == true || novapaginaproduto == true || novapaginafuncionario == true)
                    {
                        page = doc.AddPage();
                        page.Width = 595;
                        page.Height = 842;
                        graphics = XGraphics.FromPdfPage(page);
                        textFormatter1 = new XTextFormatter(graphics);
                        textFormatter2 = new XTextFormatter(graphics);
                        textFormatter3 = new XTextFormatter(graphics);
                        fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                        fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                        fonte3 = new XFont("Microsoft Sans Serif", 18, XFontStyle.Bold);
                        fonte4 = new XFont("Microsoft Sans Serif", 9);
                        fonte5 = new XFont("Microsoft Sans Serif", 8);
                        fonte6 = new XFont("Microsoft Sans Serif", 7, XFontStyle.Bold);
                        pen2 = new XPen(XColors.White);
                        pen = new XPen(XColors.Black);
                        //
                        textFormatter1.Alignment = XParagraphAlignment.Center;
                        textFormatter3.Alignment = XParagraphAlignment.Right;
                        int novamargemproduto = 0;
                        int novamargemfuncionario = 0;
                        int tamanhograde;
                        //
                        graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                        //
                        if (bllProduto._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                        {
                            XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                            graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 100, 116);
                        }
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
                        //DATA
                        graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 5 + Margem_Topo, 95, 122);
                        textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(525 + Margem_Esq, 10 + Margem_Topo, page.Width, page.Height));
                        textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(510 + Margem_Esq, 22 + Margem_Topo, page.Width, page.Height));
                        //HORÁRIO                    
                        textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(527 + Margem_Esq, 38 + Margem_Topo, page.Width, page.Height));
                        textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(516 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                        //Nº OS
                        textFormatter2.DrawString("Ordem de Serviço:", fonte4, XBrushes.Black, new XRect(505 + Margem_Esq, 78 + Margem_Topo, page.Width, page.Height));
                        graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 90 + Margem_Topo, 95, 37);
                        textFormatter1.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte3, XBrushes.Black, new XRect(494 + Margem_Esq, 98 + Margem_Topo, 95, 37));
                        //
                        if (novapaginaservico == true)
                        {
                            tamanhograde = 240 - 12;
                            if (novapaginafuncionario == false & novapaginaproduto == false)
                            {
                                tamanhograde = 628 - 12;
                            }
                            if (novapaginafuncionario == true & novapaginaproduto == false)
                            {
                                tamanhograde = 496 - 12;
                            }
                            //
                            graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 130 + Margem_Topo, 584, 15);
                            textFormatter1.DrawString("SERVIÇO(S)", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 132 + Margem_Topo, page.Width, 15));
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 145 + Margem_Topo, 584, tamanhograde);
                            //
                            graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 145 + Margem_Topo, 584, 15);
                            textFormatter2.DrawString("Cód.", fonte2, XBrushes.Black, new XRect(10 + Margem_Esq, 147 + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Descrição", fonte2, XBrushes.Black, new XRect(75 + Margem_Esq, 147 + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Qtd.", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, 147 + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Vl. Unit. (R$)", fonte2, XBrushes.Black, new XRect(425 + Margem_Esq, 147 + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Vl. Total (R$)", fonte2, XBrushes.Black, new XRect(520 + Margem_Esq, 147 + Margem_Topo, page.Width, 15));
                            //
                            if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 11; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    textFormatter2.DrawString(dr["id_servico"].ToString(), fonte5, XBrushes.Black, new XRect(10 + Margem_Esq, (Incrementar + 162) + Margem_Topo, page.Width, 15));
                                    textFormatter2.DrawString(dr["descricao"].ToString(), fonte5, XBrushes.Black, new XRect(80 + Margem_Esq, (Incrementar + 162) + Margem_Topo, page.Width, 15));
                                    textFormatter2.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 162) + Margem_Topo, page.Width, 15));
                                    //
                                    if (dr["valor_desconto"].ToString() != "0" || dr["valor_acrescimo"].ToString() != "0")
                                    {
                                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(dr["valor_acrescimo"]).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(dr["valor_desconto"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 449) + Margem_Topo, 130, 15));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 449) + Margem_Topo, 130, 15));
                                    }
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(535 + Margem_Esq, (Incrementar + 162) + Margem_Topo, page.Width, 15));
                                    //
                                    Incrementar = 9 + Incrementar;
                                }
                            }
                            //
                            Incrementar = 0;
                        }
                        //
                        if (novapaginaproduto == true)
                        {
                            tamanhograde = 240;
                            if (novapaginaservico == false & novapaginafuncionario == false)
                            {
                                novamargemproduto = novamargemproduto - 256;
                                tamanhograde = 622 - 12;
                            }
                            else if (novapaginaservico == true & novapaginafuncionario == false)
                            {
                                tamanhograde = 366 - 12;
                            }
                            else if (novapaginaservico == false & novapaginafuncionario == true)
                            {
                                novamargemproduto = novamargemproduto - 258;
                                tamanhograde = 496 - 12;
                            }
                            //
                            graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 388 + novamargemproduto + Margem_Topo, 584, 15);
                            textFormatter1.DrawString("PRODUTO(S) ADICIONADO(S)", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 390 + novamargemproduto + Margem_Topo, page.Width, 15));
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 401 + novamargemproduto + Margem_Topo, 584, tamanhograde);
                            //
                            graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 401 + novamargemproduto + Margem_Topo, 584, 15);
                            textFormatter2.DrawString("Cód.", fonte2, XBrushes.Black, new XRect(10 + Margem_Esq, 403 + novamargemproduto + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Descrição", fonte2, XBrushes.Black, new XRect(80 + Margem_Esq, 403 + novamargemproduto + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Qtd.", fonte2, XBrushes.Black, new XRect(360 + Margem_Esq, 403 + novamargemproduto + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Un.", fonte2, XBrushes.Black, new XRect(405 + Margem_Esq, 403 + novamargemproduto + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Vl. Unit. (R$).", fonte2, XBrushes.Black, new XRect(440 + Margem_Esq, 403 + novamargemproduto + Margem_Topo, page.Width, 15));
                            textFormatter2.DrawString("Vl. Total (R$).", fonte2, XBrushes.Black, new XRect(520 + Margem_Esq, 403 + novamargemproduto + Margem_Topo, page.Width, 15));
                            //
                            if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 11; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    textFormatter2.DrawString(dr["id_produto"].ToString(), fonte5, XBrushes.Black, new XRect(10 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, page.Width, 15));
                                    textFormatter2.DrawString(dr["descricao"].ToString(), fonte5, XBrushes.Black, new XRect(80 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, page.Width, 15));
                                    graphics.DrawRectangle(pen2, XBrushes.White, 360 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, 220, 10);
                                    textFormatter2.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, page.Width, 15));
                                    textFormatter2.DrawString(dr["um"].ToString(), fonte5, XBrushes.Black, new XRect(405 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, page.Width, 15));
                                    //
                                    if (dr["valor_desconto"].ToString() != "0" || dr["valor_acrescimo"].ToString() != "0")
                                    {
                                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(dr["valor_acrescimo"]).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(dr["valor_desconto"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, 130, 15));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(390 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, 130, 15));
                                    }
                                    //
                                    //textFormatter2.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(440 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, page.Width, 15));
                                    textFormatter2.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte5, XBrushes.Black, new XRect(520 + Margem_Esq, (Incrementar + 418) + novamargemproduto + Margem_Topo, page.Width, 15));
                                    //
                                    Incrementar = 9 + Incrementar;
                                }
                            }
                            //
                            Incrementar = 0;
                        }
                        //
                        if (novapaginafuncionario == true)
                        {
                            tamanhograde = 108;
                            if (novapaginaservico == false & novapaginaproduto == false)
                            {
                                novamargemfuncionario = novamargemfuncionario - 513;
                                tamanhograde = 622 - 12;
                            }
                            //
                            graphics.DrawRectangle(pen, XBrushes.LightGray, 5 + Margem_Esq, 644 + novamargemfuncionario + Margem_Topo, 584, 15);
                            textFormatter1.DrawString("FUNCIONÁRIO(S)", fonte2, XBrushes.Black, new XRect(5 + Margem_Esq, 646 + novamargemfuncionario + Margem_Topo, page.Width, 15));
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 659 + novamargemfuncionario + Margem_Topo, 584, tamanhograde);
                            //
                            if (bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 5; i < bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    textFormatter2.DrawString(dr["id_funcionario"].ToString() + " - " + dr["nome_funcionario"].ToString(), fonte5, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 661) + novamargemfuncionario + Margem_Topo, page.Width, 15));
                                    //
                                    Incrementar = 9 + Incrementar;
                                }
                            }
                            //
                            Incrementar = 0;
                        }
                        //



                        graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 759 + Margem_Topo, 584, 27);
                        if (SelectedRow.Cells[13].Value.ToString() == "")
                        {
                            valorservico = "0";
                        }
                        else
                        {
                            valorservico = SelectedRow.Cells[13].Value.ToString();
                        }
                        textFormatter2.DrawString("SERVIÇOS (R$): " + Convert.ToDecimal(valorservico).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                        if (SelectedRow.Cells[14].Value.ToString() == "")
                        {
                            valorproduto = "0";
                        }
                        else
                        {
                            valorproduto = SelectedRow.Cells[14].Value.ToString();
                        }
                        //
                        textFormatter2.DrawString("PRODUTOS (R$): " + Convert.ToDecimal(valorproduto).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(165 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                        //
                        textFormatter2.DrawString("TOTAL (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(310 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                        //
                        textFormatter2.DrawString("ACRÉSCIMO (R$): " + (Convert.ToDecimal(SelectedRow.Cells[23].Value) + Convert.ToDecimal(SelectedRow.Cells[38].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 761 + Margem_Topo, page.Width, 15));
                        //
                        textFormatter2.DrawString("DESCONTO (R$): " + (Convert.ToDecimal(SelectedRow.Cells[21].Value) + Convert.ToDecimal(SelectedRow.Cells[37].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        //
                        textFormatter2.DrawString("A PAGAR (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        //
                        if (SelectedRow.Cells[30].Value.ToString() == "")
                        {
                            textFormatter2.DrawString("PAGO (R$): 0,00", fonte2, XBrushes.Black, new XRect(455 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        }
                        else
                        {
                            if (SelectedRow.Cells[19].Value.ToString() == "PENDENTE")
                            {
                                textFormatter2.DrawString("TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                            }
                            else
                            {
                                textFormatter2.DrawString("TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                            }
                        }



                        /*
                        graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 771 + Margem_Topo, 584, 15);
                        //
                        textFormatter2.DrawString("SERVIÇOS (R$): " + Convert.ToDecimal(valorservico).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        if (SelectedRow.Cells[14].Value.ToString() == "")
                        {
                            valorproduto = "0";
                        }
                        else
                        {
                            valorproduto = SelectedRow.Cells[14].Value.ToString();
                        }
                        textFormatter2.DrawString("PRODUTOS (R$): " + Convert.ToDecimal(valorproduto).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(165 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        //
                        textFormatter2.DrawString("TOTAL (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(310 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        //
                        if (SelectedRow.Cells[30].Value.ToString() == "")
                        {
                            textFormatter2.DrawString("PAGO (R$): 0,00", fonte2, XBrushes.Black, new XRect(455 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                        }
                        else
                        {
                            if (SelectedRow.Cells[19].Value.ToString() == "PENDENTE")
                            {
                                textFormatter2.DrawString("TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                            }
                            else
                            {
                                textFormatter2.DrawString("TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(435 + Margem_Esq, 773 + Margem_Topo, page.Width, 15));
                            }
                        }
                        */
                        //
                        graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 789 + Margem_Topo, 165, 30);
                        textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10) + " " + SelectedRow.Cells[5].Value.ToString(), fonte5, XBrushes.Black, new XRect(45 + Margem_Esq, 791 + Margem_Topo, page.Width, 15));
                        graphics.DrawRectangle(pen, XBrushes.White, 165 + Margem_Esq, 789 + Margem_Topo, 424, 30);
                        textFormatter2.DrawString("CLIENTE/CONSUMIDOR", fonte5, XBrushes.Black, new XRect(210 + Margem_Esq, 791 + Margem_Topo, page.Width, 15));
                        graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 811 + Margem_Topo, 165, 8);
                        textFormatter2.DrawString("DATA", fonte6, XBrushes.Black, new XRect(75 + Margem_Esq, 811 + Margem_Topo, page.Width, 15));
                        graphics.DrawRectangle(pen, XBrushes.White, 165 + Margem_Esq, 811 + Margem_Topo, 424, 8);
                        textFormatter2.DrawString("CLIENTE/CONSUMIDOR", fonte6, XBrushes.Black, new XRect(335 + Margem_Esq, 811 + Margem_Topo, page.Width, 15));
                        //
                        textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595    ", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                        textFormatter1.DrawString("Páginas: " + 2 + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                    }
                }
            }
            else
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep, tel, cel;
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
                    tel = drPDF["telefone"].ToString();
                    cel = drPDF["celular"].ToString();
                    //
                    var page = doc.AddPage();
                    //
                    DataRow dr;
                    DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                    //
                    page.Width = 203;
                    page.Height = 850;
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
                    var fonte4 = new XFont("Courrier Regular", 6, XFontStyle.Italic);
                    var fonte5 = new XFont("Courrier Regular", 10, XFontStyle.Bold);
                    var fonte6 = new XFont("Courrier Regular", 16, XFontStyle.Bold);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.White);
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
                    //
                    if (bllOS._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 20 + Margem_Esq, 1 + Margem_Topo, 158, 69);
                        imagem1.Dispose();
                        Margem_Topo = Margem_Topo - 15;
                    }
                    else
                    {
                        Margem_Topo = Margem_Topo - 69;
                    }
                    //
                    Margem_Topo = Margem_Topo + 5;
                    //
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
                    string cpfcnpj = null;
                    string ierg = null;
                    if (pessoa == 1)
                    {
                        cpfcnpj = "CNPJ: ";
                        ierg = "IE.: ";
                    }
                    else
                    {
                        cpfcnpj = "CPF: ";
                        ierg = "RG.: ";
                    }
                    //
                    if (tel != "" & cel != "")
                    {
                        tel = tel + " - ";
                    }
                    textFormatter1.DrawString(cpfcnpj + cpf_cnpj + "   " + ierg + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 102 + Margem_Topo, 198, 10));
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 110 + Margem_Topo, 198, 43);
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep + Environment.NewLine + tel + cel, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 110 + Margem_Topo, 198, 43));
                    //
                    Margem_Topo = Margem_Topo + 18;
                    textFormatter1.DrawString("Ordem de Serviço", fonte5, XBrushes.Black, new XRect(5 + Margem_Esq, 133 + Incrementar + Margem_Topo, 198, 24));
                    //
                    graphics.DrawRectangle(pen, 2 + Margem_Esq, 146 + Incrementar + Margem_Topo, 198, 24);
                    //
                    textFormatter1.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte6, XBrushes.Black, new XRect(5 + Margem_Esq, 148 + Incrementar + Margem_Topo, 198, 24));
                    //
                    Margem_Topo = Margem_Topo - 4;
                    //
                    //
                    textFormatter2.DrawString("      Data:", fonte5, XBrushes.Black, new XRect(5 + Margem_Esq, 174 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter3.DrawString("Horário:       ", fonte5, XBrushes.Black, new XRect(5 + Margem_Esq, 174 + Incrementar + Margem_Topo, 198, 24));
                    //
                    graphics.DrawRectangle(pen, 2 + Margem_Esq, 186 + Incrementar + Margem_Topo, 63, 14);
                    //
                    graphics.DrawRectangle(pen, 136 + Margem_Esq, 186 + Incrementar + Margem_Topo, 63, 14);
                    //
                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte5, XBrushes.Black, new XRect(7 + Margem_Esq, 188 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte5, XBrushes.Black, new XRect(148 + Margem_Esq, 188 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 198 + Incrementar + Margem_Topo, 198, 10));
                    //
                    //DADOS CLIENTE
                    string municipio = "";
                    string telefone = "";
                    string celular = "";
                    string email = "";
                    //
                    if (SelectedRow.Cells[1].Value.ToString() != "0")
                    {
                        dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                        //
                        endereco = dr["endereco"].ToString();
                        //
                        bairro = dr["bairro"].ToString();
                        //
                        cep = dr["cep"].ToString();
                        //
                        municipio = dr["cidade"].ToString();
                        //
                        uf = dr["uf"].ToString();
                        //
                        telefone = dr["telefone"].ToString();
                        //
                        if (telefone == null || telefone == "")
                        {
                            celular = dr["celular"].ToString();
                        }
                        else
                        {
                            celular = " / " + dr["celular"].ToString();
                        }
                        //
                        if ((telefone == null || telefone == "") || (celular == null || celular == ""))
                        {
                            email = dr["email"].ToString();
                        }
                        else
                        {
                            email = " / " + dr["email"].ToString();
                        }
                    }
                    //
                    textFormatter1.DrawString("DADOS DO CLIENTE/CONSUMIDOR", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 208 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    if (SelectedRow.Cells[2].Value.ToString().Length > 30)
                    {
                        if (!SelectedRow.Cells[2].Value.ToString().Substring(0, 30).Contains(" ") || !SelectedRow.Cells[2].Value.ToString().Substring(30).Contains(" "))
                        {
                            textFormatter2.DrawString("NOME: " + SelectedRow.Cells[2].Value.ToString().Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter2.DrawString("NOME: " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 11;
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME: " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 8));
                    }
                    //
                    textFormatter2.DrawString("CPF/CNPJ: " + SelectedRow.Cells[3].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 224 + Margem_Topo, 198, 8));
                    //
                    if (endereco.Length > 30)
                    {
                        if (!endereco.Substring(0, 30).Contains(" ") || !endereco.Substring(30).Contains(" "))
                        {
                            textFormatter2.DrawString("ENDEREÇO: " + endereco.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 232 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter2.DrawString("ENDEREÇO: " + endereco, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 232 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 11;
                    }
                    else
                    {
                        textFormatter2.DrawString("ENDEREÇO: " + endereco, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 232 + Margem_Topo, 198, 8));
                    }
                    //
                    if (bairro.Length > 30)
                    {
                        if (!bairro.Substring(0, 30).Contains(" ") || !bairro.Substring(30).Contains(" "))
                        {
                            textFormatter2.DrawString("BAIRRO: " + bairro.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 240 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter2.DrawString("BAIRRO: " + bairro, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 240 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 11;
                    }
                    else
                    {
                        textFormatter2.DrawString("BAIRRO: " + bairro, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 240 + Margem_Topo, 198, 8));
                    }
                    //
                    textFormatter2.DrawString("UF: " + uf + "              CEP: " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 248 + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString("MUNICÍPIO: " + municipio, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 256 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo - 8;
                    //
                    textFormatter2.DrawString("CONTATO: " + telefone + celular + email, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 272 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter1.DrawString("DADOS DO ITEM/EQUIPAMENTO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 290 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    if (SelectedRow.Cells[9].Value.ToString().Length > 30)
                    {
                        if (!SelectedRow.Cells[9].Value.ToString().Substring(0, 30).Contains(" ") || !SelectedRow.Cells[9].Value.ToString().Substring(30).Contains(" "))
                        {
                            textFormatter2.DrawString("DESC.: " + SelectedRow.Cells[9].Value.ToString().Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 298 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter2.DrawString("DESC.: " + SelectedRow.Cells[9].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 298 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 11;
                    }
                    else
                    {
                        textFormatter2.DrawString("DESC.: " + SelectedRow.Cells[9].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 298 + Margem_Topo, 198, 8));
                    }
                    //
                    textFormatter2.DrawString("MARCA: " + SelectedRow.Cells[10].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 306 + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString("MODELO: " + SelectedRow.Cells[11].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 314 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    textFormatter2.DrawString("Nº DE SÉRIE: " + SelectedRow.Cells[12].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 322 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 332 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter1.DrawString("DESCRIÇÃO COMPLETA DO SERVIÇO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 342 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    if (SelectedRow.Cells[8].Value.ToString() == "")
                    {
                        Margem_Topo = Margem_Topo - 45;
                    }
                    else
                    {
                        textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 350 + Margem_Topo, 198, 48));
                    }
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 398 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter1.DrawString("OBSERVAÇÕES / CONCLUSÃO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 408 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    if (SelectedRow.Cells[16].Value.ToString() == "")
                    {
                        Margem_Topo = Margem_Topo - 45;
                    }
                    else
                    {
                        textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 416 + Margem_Topo, 198, 48));
                    }
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    //
                    if (SelectedRow.Cells[6].Value.ToString() != "")
                    {
                        textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 464 + Incrementar + Margem_Topo, 198, 10));
                        //
                        textFormatter1.DrawString("CONCLUSÃO PREVISTA", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 474 + Margem_Topo, 198, 8));
                        //
                        Margem_Topo = Margem_Topo + 1;
                        //
                        textFormatter1.DrawString(SelectedRow.Cells[6].Value.ToString().Remove(10) + "  " + SelectedRow.Cells[7].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 482 + Margem_Topo, 198, 10));
                    }
                    else
                    {
                        Margem_Topo = Margem_Topo - 22;
                    }
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 492 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter1.DrawString("SITUAÇÃO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 502 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    string data_conclusao = "";
                    if (SelectedRow.Cells[17].Value.ToString() != "")
                    {
                        data_conclusao = "    " + SelectedRow.Cells[17].Value.ToString().Remove(10) + "  " + SelectedRow.Cells[18].Value.ToString();
                    }
                    //
                    textFormatter1.DrawString(SelectedRow.Cells[19].Value.ToString() + data_conclusao, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 510 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 520 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter1.DrawString("SERVIÇO(S)", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 530 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    textFormatter2.DrawString("Cód. Descrição  Qtd.  Vl. Unit. (R$)  Vl Total (R$)", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 538 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Margem_Topo = Margem_Topo + 2;
                    //
                    if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            //
                            textFormatter2.DrawString(dr["id_servico"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 546 + Incrementar + Margem_Topo, 198, 10));
                            //
                            if (dr["descricao"].ToString().Length > 30)
                            {
                                if (!dr["descricao"].ToString().Substring(0, 30).Contains(" ") || !dr["descricao"].ToString().Substring(30).Contains(" "))
                                {
                                    textFormatter2.DrawString(dr["id_servico"].ToString() + "    " + dr["descricao"].ToString().Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 546 + Incrementar + Margem_Topo, 198, 21));
                                }
                                else
                                {
                                    textFormatter2.DrawString(dr["id_servico"].ToString() + "    " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 546 + Incrementar + Margem_Topo, 198, 21));
                                }
                                Incrementar = Incrementar + 11;
                            }
                            else
                            {
                                textFormatter2.DrawString(dr["id_servico"].ToString() + "    " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 546 + Incrementar + Margem_Topo, 198, 10));
                            }
                            //graphics.DrawRectangle(pen1, XBrushes.White, 125 + Margem_Esq, 546 + Incrementar + Margem_Topo, 208, 10);
                            textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")) + "   x   " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + "          " + Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 556 + Incrementar + Margem_Topo, 198, 10));
                            //
                            if (dr["valor_desconto"].ToString() != "0" || dr["valor_acrescimo"].ToString() != "0")
                            {
                                Incrementar = Incrementar + 11;
                                //
                                textFormatter1.DrawString("-" + Convert.ToDecimal(dr["valor_desconto"]).ToString("n2", new CultureInfo("pt-BR")) + "       +" + Convert.ToDecimal(dr["valor_acrescimo"]).ToString("n2", new CultureInfo("pt-BR")) + "       " + Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 556 + Incrementar + Margem_Topo, 198, 10));
                            }
                            //
                            Incrementar = 19 + Incrementar;
                        }
                    }
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 548 + Incrementar + Margem_Topo, 198, 10));
                        //
                        textFormatter1.DrawString("PRODUTO(S) ADICIONADO(S)", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 558 + Margem_Topo, 198, 8));
                        //
                        Margem_Topo = Margem_Topo + 1;
                        //
                        textFormatter2.DrawString("Cód. Descrição  Qtd.  Vl. Unit. (R$)  Vl Total (R$)", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 566 + Incrementar + Margem_Topo, 198, 10));
                        //
                        Margem_Topo = Margem_Topo + 2;
                        //
                        for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            //
                            if (dr["descricao"].ToString().Length > 30)
                            {
                                if (!dr["descricao"].ToString().Substring(0, 30).Contains(" ") || !dr["descricao"].ToString().Substring(30).Contains(" "))
                                {
                                    textFormatter2.DrawString(dr["id_produto"].ToString() + "    " + dr["descricao"].ToString().Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, (Incrementar + 574) + Margem_Topo, 198, 21));
                                }
                                else
                                {
                                    textFormatter2.DrawString(dr["id_produto"].ToString() + "    " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, (Incrementar + 574) + Margem_Topo, 198, 21));
                                }
                                Incrementar = Incrementar + 11;
                            }
                            else
                            {
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "    " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, (Incrementar + 574) + Margem_Topo, 198, 10));
                            }
                            //
                            //graphics.DrawRectangle(pen1, XBrushes.White, 80 + Margem_Esq, (Incrementar + 574) + Margem_Topo, 198, 10);
                            textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")) + " " + dr["um"].ToString() + "      " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + "      " + Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, (Incrementar + 584) + Margem_Topo, 198, 10));
                            //textFormatter2.DrawString(dr["um"].ToString(), fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 574) + Margem_Topo, 198, 10));
                            //textFormatter2.DrawString(Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 574) + Margem_Topo, 198, 10));
                            //textFormatter2.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(165 + Margem_Esq, (Incrementar + 574) + Margem_Topo, 198, 10));
                            Incrementar = 19 + Incrementar;
                        }
                    }
                    else
                    {
                        Margem_Topo = Margem_Topo - 20;
                    }
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    if (bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 576 + Incrementar + Margem_Topo, 198, 10));
                        //
                        textFormatter1.DrawString("FUNCIONÁRIO(S)", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 586 + Margem_Topo, 198, 8));
                        //
                        Margem_Topo = Margem_Topo + 1;

                        textFormatter2.DrawString("Cód.       Nome", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 594 + Incrementar + Margem_Topo, 198, 10));
                        //
                        Margem_Topo = Margem_Topo + 2;
                        //
                        for (int i = 0; i < bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            //
                            textFormatter2.DrawString(dr["id_funcionario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, (Incrementar + 602) + Margem_Topo, 198, 10));
                            textFormatter2.DrawString(dr["nome_funcionario"].ToString(), fonte2, XBrushes.Black, new XRect(30 + Margem_Esq, (Incrementar + 602) + Margem_Topo, 198, 10));
                            //
                            Incrementar = 10 + Incrementar;
                        }
                    }
                    else
                    {
                        Margem_Topo = Margem_Topo - 22;
                    }
                    //
                    Margem_Topo = Margem_Topo - 6;
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 604 + Incrementar + Margem_Topo, 198, 10));
                    //
                    string valorservico;
                    if (SelectedRow.Cells[13].Value.ToString() == "")
                    {
                        valorservico = "0";
                    }
                    else
                    {
                        valorservico = SelectedRow.Cells[13].Value.ToString();
                    }
                    string valorproduto;
                    if (SelectedRow.Cells[14].Value.ToString() == "")
                    {
                        valorproduto = "0";
                    }
                    else
                    {
                        valorproduto = SelectedRow.Cells[14].Value.ToString();
                    }
                    //
                    Margem_Topo = Margem_Topo + 1;
                    //
                    textFormatter2.DrawString("SERVIÇOS(R$): " + Convert.ToDecimal(valorservico).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 614 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Margem_Topo = Margem_Topo + 3;
                    //
                    if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) == null)
                    {
                        Margem_Topo = Margem_Topo - 8;
                    }
                    else
                    {
                        textFormatter2.DrawString("PRODUTOS (R$): " + Convert.ToDecimal(valorproduto).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 622 + Incrementar + Margem_Topo, 198, 10));
                        //
                        Margem_Topo = Margem_Topo + 2;
                    }
                    //
                    textFormatter2.DrawString("TOTAL (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 630 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Incrementar = Incrementar + 11;
                    //
                    textFormatter2.DrawString("ACRÉSCIMO (R$): " + (Convert.ToDecimal(SelectedRow.Cells[23].Value) + Convert.ToDecimal(SelectedRow.Cells[38].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 630 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Incrementar = Incrementar + 11;
                    //
                    textFormatter2.DrawString("DESCONTO (R$): " + (Convert.ToDecimal(SelectedRow.Cells[21].Value) + Convert.ToDecimal(SelectedRow.Cells[37].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 630 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Incrementar = Incrementar + 11;
                    //
                    textFormatter2.DrawString("A PAGAR (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 630 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Incrementar = Incrementar + 11;
                    //
                    if (SelectedRow.Cells[30].Value.ToString() == "")
                    {
                        textFormatter2.DrawString("VALOR TOTAL PAGO (R$): 0,00", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 630 + Incrementar + Margem_Topo, 198, 10));
                    }
                    else
                    {
                        if (SelectedRow.Cells[19].Value.ToString() == "PENDENTE")
                        {
                            textFormatter2.DrawString("VALOR TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 630 + Incrementar + Margem_Topo, 198, 10));
                        }
                        else
                        {
                            textFormatter2.DrawString("VALOR TOTAL PAGO (R$): " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 630 + Incrementar + Margem_Topo, 198, 10));
                        }
                    }
                    //
                    Margem_Topo = Margem_Topo - 4;
                    //
                    textFormatter2.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 640 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10) + " " + SelectedRow.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 650 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter1.DrawString("_________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 662 + Incrementar + Margem_Topo, 198, 10));
                    //
                    Margem_Topo = Margem_Topo + 2;
                    //
                    if (SelectedRow.Cells[2].Value.ToString().Length > 30)
                    {
                        if (!SelectedRow.Cells[2].Value.ToString().Substring(0, 30).Contains(" ") || !SelectedRow.Cells[2].Value.ToString().Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(SelectedRow.Cells[2].Value.ToString().Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 670 + Incrementar + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter1.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 670 + Incrementar + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 11;
                    }
                    else
                    {
                        textFormatter1.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 670 + Incrementar + Margem_Topo, 198, 10));
                    }
                    //
                    textFormatter1.DrawString("___________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 682 + Incrementar + Margem_Topo, 198, 10));
                    //
                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 695 + Margem_Topo, 198, 10));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                    }
                }
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmInfImpressao Imp = new FrmInfImpressao(45))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        GerarPDF();
                        //
                        AbrirPDF.Pdf(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                    }
                }

                pEnabled.Enabled = true;
            }
            catch (Exception ex)
            {
                dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerar.");
                }
            }
            pEnabled.Enabled = true;
            dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                {
                    MessageBox.Show("Não é possível finalizar este registro porque o caixa está fechado.\n\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtOs.Select();
                }
                else
                {
                    DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                    //
                    string codigo = SelectedRow.Cells[0].Value.ToString();
                    //
                    using (FrmOSBaixa Os = new FrmOSBaixa(_Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString()))
                    {
                        if (Os.ShowDialog() == DialogResult.OK)
                        {
                            dtOs.DataSource = bllOS.Sel_OS_Codigo(codigo);
                            //
                            SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                            //
                            DataRow dr;
                            //
                            string totalreal = null;
                            //
                            string totalpago = null;
                            //
                            string totaltroco = null;
                            //
                            string desc_item = SelectedRow.Cells[37].Value.ToString();
                            //
                            string acresc_item = SelectedRow.Cells[38].Value.ToString();
                            //
                            string total = null;
                            //
                            string total_parcial = "0";
                            //
                            string valor_pago = SelectedRow.Cells[30].Value.ToString();
                            //
                            if (valor_pago == "")
                            {
                                valor_pago = "0";
                            }
                            //
                            bool parcial;
                            if (Convert.ToDecimal(SelectedRow.Cells[29].Value) > Convert.ToDecimal(valor_pago))
                            {
                                for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    if (bllOS.Sel_Pagamento_Parcial_OS(SelectedRow.Cells[0].Value.ToString()) == false)
                                    {
                                        totalpago = (Convert.ToDecimal(totalpago) + Convert.ToDecimal(dr["valor_pago"].ToString())).ToString();
                                    }
                                    else
                                    {
                                        if (Convert.ToByte(dr["pagamento_parcial"]) == 2)
                                        {
                                            totalpago = (Convert.ToDecimal(totalpago) + Convert.ToDecimal(dr["valor_pago"].ToString())).ToString();
                                        }
                                        else
                                        {
                                            total_parcial = (Convert.ToDecimal(total_parcial) + Convert.ToDecimal(dr["valor_pago"].ToString())).ToString();
                                        }
                                    }
                                }
                                //
                                totalreal = (Convert.ToDecimal(SelectedRow.Cells[30].Value) - Convert.ToDecimal(total_parcial)).ToString();
                                //
                                totaltroco = (Convert.ToDecimal(totalpago) - Convert.ToDecimal(totalreal)).ToString();
                                //
                                total = (Convert.ToDecimal(SelectedRow.Cells[30].Value) - Convert.ToDecimal(total_parcial)).ToString();
                                //
                                bllOS.Alterar_Pagamento_Parcial_OS(SelectedRow.Cells[0].Value.ToString(), true);
                                //
                                parcial = true;
                            }
                            else
                            {
                                for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    if (Convert.ToByte(dr["pagamento_parcial"]) == 0)
                                    {
                                        totalpago = (Convert.ToDecimal(totalpago) + Convert.ToDecimal(dr["valor_pago"].ToString())).ToString();
                                    }
                                    else
                                    {
                                        total_parcial = (Convert.ToDecimal(total_parcial) + Convert.ToDecimal(dr["valor_pago"].ToString())).ToString();
                                    }
                                }
                                //
                                totalreal = (Convert.ToDecimal(SelectedRow.Cells[29].Value) - Convert.ToDecimal(total_parcial)).ToString();
                                //
                                totaltroco = (Convert.ToDecimal(totalpago) - Convert.ToDecimal(totalreal)).ToString();
                                //
                                total = (Convert.ToDecimal(SelectedRow.Cells[15].Value) - Convert.ToDecimal(total_parcial)).ToString();
                                //
                                parcial = false;
                            }
                            //
                            string cliente_consumidor = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString();
                            //  
                            bllVenda.Salvar_Venda(cliente_consumidor, SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[24].Value.ToString(), SelectedRow.Cells[23].Value.ToString(), "SERVICO", total, totalreal, null, _Usuario, _Cod_PDV_Computador, totaltroco, totalpago, acresc_item, desc_item, null, null, SelectedRow.Cells[0].Value.ToString(), parcial);
                            //
                            dr = bllVenda.Sel_Dados_Venda_A_Finalizar().Rows[0];
                            //
                            string cod_venda = dr["id_venda"].ToString();
                            string data = dr["data"].ToString().Remove(10);
                            string hora = dr["hora"].ToString();
                            string valor_desconto_venda = dr["valor_desconto"].ToString();
                            string valor_desconto_item = dr["valor_desconto_item"].ToString();
                            string valor_acrescimo_venda = dr["valor_acrescimo"].ToString();
                            string valor_acrescimo_item = dr["valor_acrescimo_item"].ToString();
                            string valor = dr["valor"].ToString();
                            string valor_real = dr["valor_real"].ToString();
                            string troco = dr["troco"].ToString();
                            string cod_consumidor = dr["id_consumidor"].ToString();
                            string nome_consumidor = dr["nome_consumidor"].ToString();
                            string cpf_cnpj_consumidor = dr["cpf_cnpj_consumidor"].ToString();
                            string cod_usuario = dr["id_usuario"].ToString();
                            string nome_usuario = dr["nome_usuario"].ToString();
                            string desconto_porc = dr["desconto_porc"].ToString();
                            string acrescimo_porc = dr["acrescimo_porc"].ToString();
                            string ult_codigo_dfe = null;
                            //
                            for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                            {
                                dr = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                //
                                if (i == bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {
                                    bllVenda.Salvar_Itens_Venda(dr["id_item"].ToString(), dr["id_servico"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), "UN", dr["valor_unitario"].ToString(), cod_venda, valor_desconto_venda, valor_acrescimo_venda, valor, true, bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count.ToString(), dr["valor_acrescimo"].ToString(), dr["valor_desconto"].ToString(), dr["valor_total"].ToString(), false, desconto_porc, acrescimo_porc, "SERVICO");
                                }
                                else if (i == 0)
                                {
                                    bllVenda.Salvar_Itens_Venda(dr["id_item"].ToString(), dr["id_servico"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), "UN", dr["valor_unitario"].ToString(), cod_venda, valor_desconto_venda, valor_acrescimo_venda, valor, true, bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count.ToString(), dr["valor_acrescimo"].ToString(), dr["valor_desconto"].ToString(), dr["valor_total"].ToString(), true, desconto_porc, acrescimo_porc, "SERVICO");
                                }
                                else
                                {
                                    bllVenda.Salvar_Itens_Venda(dr["id_item"].ToString(), dr["id_servico"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), "UN", dr["valor_unitario"].ToString(), cod_venda, valor_desconto_venda, valor_acrescimo_venda, valor, false, bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count.ToString(), dr["valor_acrescimo"].ToString(), dr["valor_desconto"].ToString(), dr["valor_total"].ToString(), false, desconto_porc, acrescimo_porc, "SERVICO");
                                }
                            }
                            //
                            if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                int qtde_servico = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count;
                                //                    
                                for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    qtde_servico = qtde_servico + 1;
                                    //
                                    dr = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    if (i == bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                    {
                                        bllVenda.Salvar_Itens_Venda(qtde_servico.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), dr["um"].ToString(), dr["valor_unitario"].ToString(), cod_venda, valor_desconto_venda, valor_acrescimo_venda, valor, true, bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count.ToString(), dr["valor_acrescimo"].ToString(), dr["valor_desconto"].ToString(), dr["valor_total"].ToString(), false, desconto_porc, acrescimo_porc, "PRODUTO");
                                    }
                                    else if (i == 0)
                                    {
                                        bllVenda.Salvar_Itens_Venda(qtde_servico.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), dr["um"].ToString(), dr["valor_unitario"].ToString(), cod_venda, valor_desconto_venda, valor_acrescimo_venda, valor, true, bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count.ToString(), dr["valor_acrescimo"].ToString(), dr["valor_desconto"].ToString(), dr["valor_total"].ToString(), true, desconto_porc, acrescimo_porc, "PRODUTO");
                                    }
                                    else
                                    {
                                        bllVenda.Salvar_Itens_Venda(qtde_servico.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), dr["um"].ToString(), dr["valor_unitario"].ToString(), cod_venda, valor_desconto_venda, valor_acrescimo_venda, valor, false, bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count.ToString(), dr["valor_acrescimo"].ToString(), dr["valor_desconto"].ToString(), dr["valor_total"].ToString(), false, desconto_porc, acrescimo_porc, "PRODUTO");
                                    }
                                }
                            }
                            //
                            for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                            {
                                dr = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                //
                                if (Convert.ToDecimal(SelectedRow.Cells[29].Value) > Convert.ToDecimal(valor_pago))
                                {
                                    if (total_parcial == "0")
                                    {
                                        if (dr["pagamento_parcial"].ToString() == "1")
                                        {
                                            bllVenda.Salvar_Forma_Pagamento(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString(), dr["tipo"].ToString(), dr["valor_pago"].ToString(), cod_venda, data, hora, _Cod_PDV_Computador, _Usuario);
                                            //
                                            if (dr["tipo"].ToString() == "CREDITO LOJA")
                                            {
                                                bllVenda.Baixa_Credito_Loja_Cliente(cod_consumidor, dr["valor_pago"].ToString());
                                            }
                                            else
                                            {
                                                bllFluxoCaixa.Salvar(data, hora, "ENTRADA", "VENDA DE SERVICOS", valor_real, cod_venda, _Usuario, _Cod_PDV_Computador);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dr["pagamento_parcial"].ToString() == "2")
                                        {
                                            bllVenda.Salvar_Forma_Pagamento(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString(), dr["tipo"].ToString(), dr["valor_pago"].ToString(), cod_venda, data, hora, _Cod_PDV_Computador, _Usuario);
                                            //                                       
                                            if (dr["tipo"].ToString() == "CREDITO LOJA")
                                            {
                                                bllVenda.Baixa_Credito_Loja_Cliente(cod_consumidor, dr["valor_pago"].ToString());
                                            }
                                            else
                                            {
                                                bllFluxoCaixa.Salvar(data, hora, "ENTRADA", "VENDA DE SERVICOS", valor_real, cod_venda, _Usuario, _Cod_PDV_Computador);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (dr["pagamento_parcial"].ToString() == "0")
                                    {
                                        bllVenda.Salvar_Forma_Pagamento(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString(), dr["tipo"].ToString(), dr["valor_pago"].ToString(), cod_venda, data, hora, _Cod_PDV_Computador, _Usuario);
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllVenda.Baixa_Credito_Loja_Cliente(cod_consumidor, dr["valor_pago"].ToString());
                                        }
                                        else
                                        {
                                            bllFluxoCaixa.Salvar(data, hora, "ENTRADA", "VENDA DE SERVICOS", valor_real, cod_venda, _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                            }
                            //
                            bllOS.Alterar_Forma_Pagamento_Parcial(SelectedRow.Cells[0].Value.ToString());
                            //
                            if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    DataRow drServico = bllServico.Sel_Servico_Codigo(dr["id_servico"].ToString(), "").Rows[0];
                                    //
                                    if (Convert.ToInt32(drServico["id_item_servico"]) != 0)
                                    {
                                        bllNFSe.Salvar(SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString(), dr["valor_unitario"].ToString(), "UNICA", SelectedRow.Cells[0].Value.ToString());
                                        //
                                        string cod_nfse = bllNFSe.Sel_Ultima_NFSe().ToString();
                                        //
                                        bllNFSe.Salvar_Item_NFSE(dr["id_item"].ToString(), dr["id_servico"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), drServico["id_item_servico"].ToString(), drServico["aliquota"].ToString(), cod_nfse);
                                        //
                                        bllNFSe.CriarNFSe(cod_nfse, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            btnGerar_Click(sender, e);
                            //
                            btnReciboRegistro_Click(sender, e);
                            //
                            if (Convert.ToDecimal(SelectedRow.Cells[14].Value) != 0 & Convert.ToDecimal(SelectedRow.Cells[30].Value) >= Convert.ToDecimal(SelectedRow.Cells[29].Value))
                            {
                                using (FrmTipoDFe DFe = new FrmTipoDFe(SelectedRow.Cells[1].Value.ToString()))
                                {
                                    if (DFe.ShowDialog() == DialogResult.OK)
                                    {
                                        if (bllOS._Tipo_Venda == "NFCe")
                                        {
                                            bllVenda.Alterar_Tipo_Venda_PDV(cod_venda, "SERVICO/NFCe");
                                            //
                                            pEnabled.Enabled = true;
                                            dtOs.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                                            //
                                            lblProgresso.Visible = true;
                                            lblProgresso.Text = "Transmitindo, por favor, aguarde...";
                                            //
                                            for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                            {
                                                DataRow dr1 = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                                //
                                                string cod_produto = dr1["id_produto"].ToString();
                                                string desc_produto = dr1["descricao"].ToString();
                                                //
                                                dr1 = bllProduto.Sel_Prod_Codigo(cod_produto, "").Rows[0];
                                                //
                                                if (dr1["ncm"].ToString() == "" || dr1["ncm"].ToString() == null)
                                                {
                                                    MessageBox.Show("Não foi possível gerar a NFC-e (modelo 65).\n\nÉ necessário ter um NCM válido cadastrado para o produto:\n[ " + cod_produto + "-" + desc_produto + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    return;
                                                }
                                            }
                                            //
                                            string serie;
                                            serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFCe();
                                            //
                                            if (cliente_consumidor != null)
                                            {
                                                string[] items = cliente_consumidor.Split('—');
                                                //
                                                if (items[0] == "0")
                                                {
                                                    bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(items[1], items[2]);
                                                }
                                            }
                                            //
                                            decimal valor_total_nf = 0;
                                            decimal valor_desconto_nf = 0;
                                            decimal valor_desconto_item_nf = 0;
                                            decimal valor_acrescimo_nf = 0;
                                            decimal valor_acrescimo_item_nf = 0;
                                            decimal valor_total_a_desc_acresc_nf = 0;
                                            for (int i = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i < bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count; i++)
                                            {
                                                DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows[i];
                                                //
                                                valor_total_nf = valor_total_nf + Convert.ToDecimal(drItemVenda["valor_total"]);
                                                valor_desconto_nf = valor_desconto_nf + Convert.ToDecimal(drItemVenda["valor_desconto"]);
                                                valor_acrescimo_nf = valor_acrescimo_nf + Convert.ToDecimal(drItemVenda["valor_acrescimo"]);
                                                valor_desconto_item_nf = valor_desconto_item_nf + Convert.ToDecimal(drItemVenda["valor_desconto_item"]);
                                                valor_acrescimo_item_nf = valor_acrescimo_item_nf + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"]);
                                                valor_total_a_desc_acresc_nf = valor_total_a_desc_acresc_nf + Convert.ToDecimal(drItemVenda["valor_total_a_desc_acresc"]);
                                            }
                                            //
                                            bllDFe.Salvar(null, "PRÓPRIA", "65", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, cliente_consumidor, null, valor_total_nf.ToString(), (valor_desconto_nf + valor_desconto_item_nf).ToString(), null, (valor_acrescimo_nf + valor_acrescimo_item_nf).ToString(), valor_total_a_desc_acresc_nf.ToString(), "VENDA DE MERCADORIA", false, _Cod_PDV_Computador, "CLIENTES", "0", "0", true, "SAIDA", true, null, "PENDENTE", null, cod_venda, null, false);
                                            //
                                            ult_codigo_dfe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                            //
                                            int qtde_produto = 0;
                                            for (int i = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i < bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count; i++)
                                            {
                                                DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows[i];
                                                //
                                                DataRow drProduto = bllProduto.Sel_Prod_Codigo(drItemVenda["id_produto"].ToString(), "").Rows[0];
                                                //
                                                string valor_base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drItemVenda["valor_unitario"].ToString(), drItemVenda["quantidade"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString());
                                                //
                                                string valor_base_calculo_st = "0";
                                                //
                                                string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                                //
                                                string valor_icms_st = "0";
                                                //
                                                string total_aprox_trib = bllDFe.Calculo_Valor_Aprox_Trib(drItemVenda["valor_total"].ToString(), drItemVenda["id_produto"].ToString());
                                                //
                                                string cfop = null;
                                                if (bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL" || bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL - MEI")
                                                {
                                                    if (drProduto["csosn"].ToString() == "101")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "102")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "103")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "201")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "202")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "203")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "300")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "400")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "500")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "900")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                }
                                                //
                                                bllDFe.Salvar_Items(qtde_produto.ToString(), drItemVenda["id_produto"].ToString() + "—" + drItemVenda["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), cfop, drItemVenda["quantidade"].ToString(), "1", drItemVenda["valor_total"].ToString(), drItemVenda["valor_unitario"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString(), drItemVenda["valor_total_a_desc_acresc"].ToString(), valor_icms, valor_base_calculo, ult_codigo_dfe, valor_icms_st, "0", "0", valor_base_calculo_st, "0", drItemVenda["um"].ToString(), total_aprox_trib, "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                                //
                                                qtde_produto = qtde_produto + 1;
                                            }
                                            //
                                            DataRow drItemDfe;
                                            decimal icms = 0;
                                            decimal icmsst = 0;
                                            decimal base_calculo_icms = 0;
                                            decimal base_calculo_icms_st = 0;
                                            decimal total_apx_trib = 0;
                                            //
                                            for (int i = 0; i < bllDFe.Sel_Items_DFe(ult_codigo_dfe).Rows.Count; i++)
                                            {
                                                drItemDfe = bllDFe.Sel_Items_DFe(ult_codigo_dfe).Rows[i];
                                                //
                                                icms += Convert.ToDecimal(drItemDfe["valor_icms"]);
                                                icmsst += Convert.ToDecimal(drItemDfe["valor_icms_st"]);
                                                base_calculo_icms += Convert.ToDecimal(drItemDfe["valor_base_calculo"]);
                                                base_calculo_icms_st += Convert.ToDecimal(drItemDfe["valor_base_calculo_st"]);
                                                total_apx_trib += Convert.ToDecimal(drItemDfe["total_aprox_trib"]);
                                            }
                                            //
                                            bllDFe.Salvar_icms_icms_st_base_total_trib(ult_codigo_dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_apx_trib.ToString());
                                            //
                                            if (bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count == 1)
                                            {
                                                DataRow drPagamento = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                                //
                                                bllDFe.Salvar_Pagamento_DFe("1", drPagamento["id_pagamento"].ToString() + "—" + drPagamento["tipo"].ToString(), valor_total_a_desc_acresc_nf.ToString(), ult_codigo_dfe);
                                            }
                                            else
                                            {
                                                decimal pagamento_dividido = 0;
                                                decimal valor_pagamento_dividido = Math.Round(valor_total_a_desc_acresc_nf / Convert.ToDecimal(bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count), 2);
                                                //
                                                for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                                {
                                                    DataRow drPagamento = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                                    //
                                                    pagamento_dividido += valor_pagamento_dividido;
                                                    //
                                                    if (i == bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                                    {
                                                        if (pagamento_dividido < valor_total_a_desc_acresc_nf || pagamento_dividido > valor_total_a_desc_acresc_nf)
                                                        {
                                                            pagamento_dividido = valor_total_a_desc_acresc_nf - pagamento_dividido;
                                                            //
                                                            valor_pagamento_dividido += pagamento_dividido;
                                                        }
                                                        //
                                                        bllDFe.Salvar_Pagamento_DFe((i + 1).ToString(), drPagamento["id_pagamento"].ToString() + "—" + drPagamento["tipo"].ToString(), valor_pagamento_dividido.ToString(), ult_codigo_dfe);
                                                    }
                                                    else
                                                    {
                                                        bllDFe.Salvar_Pagamento_DFe((i + 1).ToString(), drPagamento["id_pagamento"].ToString() + "—" + drPagamento["tipo"].ToString(), valor_pagamento_dividido.ToString(), ult_codigo_dfe);
                                                    }
                                                }
                                            }
                                            //
                                            bool contingencia = false;
                                            //
                                            if (bllConfiguracaoSistema.Sel_Contingencia_NFCe() == true)
                                            {
                                                bllDFe.Transmitir_NFCe(ult_codigo_dfe, _Cod_PDV_Computador, true);
                                            }
                                            else
                                            {
                                                if (bllDFe.Transmitir_NFCe(ult_codigo_dfe, _Cod_PDV_Computador, false) == contingencia)
                                                {
                                                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(ult_codigo_dfe).Rows[0];
                                                    //
                                                    string[] items = drDFe["caminho_dfe"].ToString().Split('\\');
                                                    //
                                                    if (File.Exists(drDFe["caminho_dfe"].ToString()))
                                                    {
                                                        string diretorio = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\Cont-NFCe\" + items[5] + @"\" + items[6];
                                                        if (!Directory.Exists(diretorio))
                                                        {
                                                            Directory.CreateDirectory(diretorio);
                                                        }
                                                        //
                                                        File.Move(drDFe["caminho_dfe"].ToString(), diretorio + @"\" + items[7]);
                                                    }
                                                    //
                                                    bllDFe.Transmitir_NFCe(ult_codigo_dfe, _Cod_PDV_Computador, true);
                                                }
                                            }
                                            //
                                            bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(null, null);
                                            lblProgresso.Visible = false;
                                        }
                                        else if (bllOS._Tipo_Venda == "NFe")
                                        {
                                            bllVenda.Alterar_Tipo_Venda_PDV(cod_venda, "SERVICO/NFe");
                                            //
                                            string serie;
                                            serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                            //
                                            for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                            {
                                                DataRow dr1 = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                                //
                                                string cod_produto = dr1["id_produto"].ToString();
                                                string desc_produto = dr1["descricao"].ToString();
                                                //
                                                dr1 = bllProduto.Sel_Prod_Codigo(cod_produto, "").Rows[0];
                                                //
                                                if (dr1["ncm"].ToString() == "" || dr1["ncm"].ToString() == null)
                                                {
                                                    MessageBox.Show("Não foi possível gerar a NF-e (modelo 55).\n\nÉ necessário ter um NCM válido cadastrado para o produto:\n[ " + cod_produto + "-" + desc_produto + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    return;
                                                }
                                            }
                                            //
                                            if (cliente_consumidor != null)
                                            {
                                                string[] items = cliente_consumidor.Split('—');
                                                //
                                                if (items[0] == "0")
                                                {
                                                    bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(items[1], items[2]);
                                                }
                                            }
                                            //
                                            decimal valor_total_nf = 0;
                                            decimal valor_desconto_nf = 0;
                                            decimal valor_desconto_item_nf = 0;
                                            decimal valor_acrescimo_nf = 0;
                                            decimal valor_acrescimo_item_nf = 0;
                                            decimal valor_total_a_desc_acresc_nf = 0;
                                            for (int i = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i < bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count; i++)
                                            {
                                                DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows[i];
                                                //
                                                valor_total_nf = valor_total_nf + Convert.ToDecimal(drItemVenda["valor_total"]);
                                                valor_desconto_nf = valor_desconto_nf + Convert.ToDecimal(drItemVenda["valor_desconto"]);
                                                valor_acrescimo_nf = valor_acrescimo_nf + Convert.ToDecimal(drItemVenda["valor_acrescimo"]);
                                                valor_desconto_item_nf = valor_desconto_item_nf + Convert.ToDecimal(drItemVenda["valor_desconto_item"]);
                                                valor_acrescimo_item_nf = valor_acrescimo_item_nf + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"]);
                                                valor_total_a_desc_acresc_nf = valor_total_a_desc_acresc_nf + Convert.ToDecimal(drItemVenda["valor_total_a_desc_acresc"]);
                                            }
                                            //
                                            bllDFe.Salvar(null, "PRÓPRIA", "55", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, cliente_consumidor, null, valor_total_nf.ToString(), (valor_desconto_nf + valor_desconto_item_nf).ToString(), null, (valor_acrescimo_nf + valor_acrescimo_item_nf).ToString(), valor_total_a_desc_acresc_nf.ToString(), "VENDA DE MERCADORIA", false, _Cod_PDV_Computador, "CLIENTES", "0", "0", true, "SAIDA", true, null, "PENDENTE", null, cod_venda, null, true);
                                            //
                                            ult_codigo_dfe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                            //
                                            int qtde_produto = 0;
                                            for (int i = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i < bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count; i++)
                                            {
                                                DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows[i];
                                                //
                                                DataRow drProduto = bllProduto.Sel_Prod_Codigo(drItemVenda["id_produto"].ToString(), "").Rows[0];
                                                //
                                                int item = Convert.ToInt32(drItemVenda["id_item"]) - 1;
                                                //
                                                string valor_base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drItemVenda["valor_unitario"].ToString(), drItemVenda["quantidade"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString());
                                                //
                                                string valor_base_calculo_st = "0";
                                                //
                                                string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                                //
                                                string valor_icms_st = "0";
                                                //
                                                string total_aprox_trib = bllDFe.Calculo_Valor_Aprox_Trib(drItemVenda["valor_total"].ToString(), drItemVenda["id_produto"].ToString());
                                                //
                                                string cfop = null;
                                                if (bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL" || bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL - MEI")
                                                {
                                                    if (drProduto["csosn"].ToString() == "101")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "102")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "103")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "201")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "202")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "203")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "300")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "400")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "500")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                                    }
                                                    else if (drProduto["csosn"].ToString() == "900")
                                                    {
                                                        cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                                    }
                                                }
                                                //
                                                bllDFe.Salvar_Items(qtde_produto.ToString(), drItemVenda["id_produto"].ToString() + "—" + drItemVenda["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), cfop, drItemVenda["quantidade"].ToString(), "1", drItemVenda["valor_total"].ToString(), drItemVenda["valor_unitario"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString(), drItemVenda["valor_total_a_desc_acresc"].ToString(), valor_icms, valor_base_calculo, ult_codigo_dfe, valor_icms_st, "0", "0", valor_base_calculo_st, "0", drItemVenda["um"].ToString(), total_aprox_trib, "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                                //
                                                qtde_produto = qtde_produto + 1;
                                            }
                                            //
                                            DataRow drItemDfe;
                                            decimal icms = 0;
                                            decimal icmsst = 0;
                                            decimal base_calculo_icms = 0;
                                            decimal base_calculo_icms_st = 0;
                                            decimal total_apx_trib = 0;
                                            //
                                            for (int i = 0; i < bllDFe.Sel_Items_DFe(ult_codigo_dfe).Rows.Count; i++)
                                            {
                                                drItemDfe = bllDFe.Sel_Items_DFe(ult_codigo_dfe).Rows[i];
                                                //
                                                icms += Convert.ToDecimal(drItemDfe["valor_icms"]);
                                                icmsst += Convert.ToDecimal(drItemDfe["valor_icms_st"]);
                                                base_calculo_icms += Convert.ToDecimal(drItemDfe["valor_base_calculo"]);
                                                base_calculo_icms_st += Convert.ToDecimal(drItemDfe["valor_base_calculo_st"]);
                                                total_apx_trib += Convert.ToDecimal(drItemDfe["total_aprox_trib"]);
                                            }
                                            //
                                            bllDFe.Salvar_icms_icms_st_base_total_trib(ult_codigo_dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_apx_trib.ToString());
                                            //
                                            if (bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count == 1)
                                            {
                                                DataRow drPagamento = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                                //
                                                bllDFe.Salvar_Pagamento_DFe(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString() + "—" + drPagamento["tipo"].ToString(), valor_total_a_desc_acresc_nf.ToString(), ult_codigo_dfe);
                                            }
                                            else
                                            {
                                                decimal pagamento_dividido = 0;
                                                decimal valor_pagamento_dividido = Math.Round(valor_total_a_desc_acresc_nf / Convert.ToDecimal(bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count), 2);
                                                //
                                                for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                                {
                                                    DataRow drPagamento = bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                                    //
                                                    pagamento_dividido += valor_pagamento_dividido;
                                                    //
                                                    if (i == bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                                    {
                                                        if (pagamento_dividido < valor_total_a_desc_acresc_nf)
                                                        {
                                                            pagamento_dividido = valor_total_a_desc_acresc_nf - pagamento_dividido;
                                                            //
                                                            valor_pagamento_dividido += pagamento_dividido;
                                                        }
                                                        //
                                                        bllDFe.Salvar_Pagamento_DFe(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString() + "—" + drPagamento["tipo"].ToString(), valor_pagamento_dividido.ToString(), ult_codigo_dfe);
                                                    }
                                                    else
                                                    {
                                                        bllDFe.Salvar_Pagamento_DFe(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString() + "—" + drPagamento["tipo"].ToString(), valor_pagamento_dividido.ToString(), ult_codigo_dfe);
                                                    }
                                                }
                                            }
                                            //
                                            using (FrmCadNFeNFCe NFe = new FrmCadNFeNFCe(_Usuario, _Cod_PDV_Computador, 2, null, null, ult_codigo_dfe, 0, false))
                                            {
                                                if (NFe.ShowDialog() == DialogResult.Abort)
                                                {
                                                    MessageBox.Show("O documento fiscal [ Cód: " + ult_codigo_dfe + " ] referente a venda atual se encontra pendente, é necessário verificar o motivo e transmitir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                        dtOs.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                pEnabled.Enabled = true;
                dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }
            }
            pEnabled.Enabled = true;
            dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        }

        private void dtOs_DoubleClick(object sender, EventArgs e)
        {
            if (dtOs.Rows[dtOs.CurrentRow.Index].Cells[19].Value.ToString() == "PENDENTE")
            {
                DataGridViewCellEventArgs a = new DataGridViewCellEventArgs(0,0);
                //
                btnAlterar_Click(sender, e);
                //
                dtOs_CellEnter(sender, a);
            }
            else
            {
                DialogResult = MessageBox.Show("Deseja gerar o pdf do registro?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    btnGerar_Click(sender, e);
                }
                else if (DialogResult == DialogResult.No)
                {
                    pEnabled.Enabled = false;
                    try
                    {
                        DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                        //
                        string codigo = SelectedRow.Cells[0].Value.ToString();
                        //
                        using (FrmOSItem Os = new FrmOSItem(_Usuario, _Cod_PDV_Computador, true, SelectedRow.Cells[0].Value.ToString(), 1))
                        {
                            if (Os.ShowDialog() == DialogResult.OK)
                            {
                                dtOs.DataSource = bllOS.Sel_OS_Codigo(codigo);
                                //
                                dtOs.Select();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
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
            }
        }

        private void btnEmail_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEmail_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarZap_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviarZap_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarZap_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                //
                DataRow dr;
                //DADOS CLIENTE
                string endereco = "";
                string bairro = "";
                string cep = "";
                string municipio = "";
                string uf = "";
                string telefone = "";
                string celular = "";
                string email = "";
                //
                if (bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()) != null)
                {
                    dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                    //
                    if (SelectedRow.Cells[1].Value.ToString() != "0")
                    {
                        dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                        //
                        endereco = dr["endereco"].ToString();
                        //
                        bairro = dr["bairro"].ToString();
                        //
                        cep = dr["cep"].ToString();
                        //
                        municipio = dr["cidade"].ToString();
                        //
                        uf = dr["uf"].ToString();
                        //
                        telefone = dr["telefone"].ToString();
                        //
                        if (telefone == null || telefone == "")
                        {
                            celular = dr["celular"].ToString();
                        }
                        else
                        {
                            celular = " / " + dr["celular"].ToString();
                        }
                        //
                        if ((telefone == null || telefone == "") & (celular == null || celular == ""))
                        {
                            email = dr["email"].ToString();
                        }
                        else
                        {
                            email = " / " + dr["email"].ToString();
                        }
                    }
                    //
                    if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                    {
                        MessageBox.Show("Este Cliente/Consumidor não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //
                        using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 0))
                        {
                            if (Cel.ShowDialog() == DialogResult.OK)
                            {
                                celular = bllOS._Celular_CadCelular_Tabela;
                            }
                            else
                            {
                                celular = null;
                                return;
                            }
                        }
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("A Ordem de Serviço selecionada não possui nenhum Cliente/Consumidor informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    celular = null;
                    return;
                }
                //
                celular = celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                //
                string data_horario_conc_prev = "";
                if (SelectedRow.Cells[6].Value.ToString() != "")
                {
                    data_horario_conc_prev = "*CONCLUSÃO PREVISTA*\n```" + SelectedRow.Cells[6].Value.ToString().Remove(10) + "     " + SelectedRow.Cells[7].Value.ToString() + "```\n";
                }
                //
                string data_horario_conclusao = "";
                if (SelectedRow.Cells[17].Value.ToString() != "")
                {
                    data_horario_conclusao = SelectedRow.Cells[17].Value.ToString().Remove(10) + Environment.NewLine + "     " + SelectedRow.Cells[18].Value.ToString();
                }
                //
                string servicos = "";
                if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                {
                    servicos = "#    Cód.    Descrição    Valor (R$)\n";
                    //
                    for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        dr = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                        //
                        servicos = servicos + "```" + (i + 1) + ".  " + dr["id_servico"].ToString() + "  " + dr["descricao"].ToString() + "  " + Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")) + " x " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + " " + Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")) + "```\n";
                    }
                }
                //
                string produtos = "";
                if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                {
                    produtos = "# Cód. Descrição Qtd. Un. Vl. Unit (R$) Vl. Total (R$)\n";
                    //
                    for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        dr = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                        //
                        produtos = produtos + "```" + (i + 1) + ".  " + dr["id_produto"].ToString().ToString() + "  " + dr["descricao"].ToString() + "  " + Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")) + "  " + dr["um"].ToString() + "  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")) + "  " + Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")) + "```\n";
                    }
                }
                //
                string funcionario = "";
                if (bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                {
                    funcionario = "#    Cód.    Nome\n";
                    //
                    for (int i = 0; i < bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        dr = bllOS.Sel_Item_OS_Funcionario_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                        //
                        funcionario = funcionario + "```" + (i + 1) + ".  " + dr["id_funcionario"].ToString() + "  " + dr["nome_funcionario"].ToString() + "```\n";
                    }
                }
                //
                string valorservico;
                if (SelectedRow.Cells[13].Value.ToString() == "")
                {
                    valorservico = "0";
                }
                else
                {
                    valorservico = SelectedRow.Cells[13].Value.ToString();
                }
                string valorproduto;
                if (SelectedRow.Cells[14].Value.ToString() == "")
                {
                    valorproduto = "0";
                }
                else
                {
                    valorproduto = SelectedRow.Cells[14].Value.ToString();
                }
                //
                string dados_servico = "";
                if (SelectedRow.Cells[8].Value.ToString() != "")
                {
                    dados_servico = "```" + SelectedRow.Cells[8].Value.ToString() + "```";
                }
                //
                string observacoes = "";
                if (SelectedRow.Cells[16].Value.ToString() != "")
                {
                    observacoes = "```" + SelectedRow.Cells[16].Value.ToString() + "```";
                }
                //
                DialogResult = MessageBox.Show("Você será direcionado para o whatsapp, deseja continuar?", "Ajuda", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    string mensagem = "*ORDEM DE SERVIÇO Nº: " + SelectedRow.Cells[0].Value.ToString() + "*\n\nData\n" + SelectedRow.Cells[4].Value.ToString().Remove(10) + "\n\nHorário\n" + SelectedRow.Cells[5].Value.ToString() + "\n\n*DADOS CLIENTE/CONSUMIDOR*\n```NOME:\n" + SelectedRow.Cells[2].Value.ToString() + "\nCPF/CNPJ:\n" + SelectedRow.Cells[3].Value.ToString() + "```\n\n*DADOS DO ITEM/EQUIPAMENTO*\n```DESCRIÇÃO DO ITEM:\n" + SelectedRow.Cells[9].Value.ToString() + "\nMARCA:\n" + SelectedRow.Cells[10].Value.ToString() + "\nMODELO:\n" + SelectedRow.Cells[11].Value.ToString() + "\nNº DE SÉRIE:\n" + SelectedRow.Cells[12].Value.ToString() + "```\n*DESCRIÇÃO COMPLETA DO SERVIÇO*\n" + dados_servico + "\n*OBSERVAÇÕES/CONCLUSÃO*\n" + observacoes + "\n" + data_horario_conc_prev + "\n*SITUAÇÃO*\n```" + SelectedRow.Cells[19].Value.ToString() + "\n" + data_horario_conclusao + "```\n*SERVIÇO(S)*\n" + servicos + "\n*PRODUTO(S) ADICIONADO(S)*\n" + produtos + "\n*FUNCIONÁRIO(S)*\n" + funcionario + "\nTOTAL DOS SERVIÇOS (R$): *" + Convert.ToDecimal(valorservico).ToString("n2", new CultureInfo("pt-BR")) + "*\nTOTAL DOS PRODUTOS (R$): *" + Convert.ToDecimal(valorproduto).ToString("n2", new CultureInfo("pt-BR")) + "*\nVALOR TOTAL (R$): *" + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "*\n\n_Sistema SEVEN - Tel/Zap: (75) 98271-6595_";
                    //
                    Clipboard.SetText(mensagem);
                    //
                    string encodedMessage = HttpUtility.UrlEncode(mensagem);
                    //
                    string url = $"https://wa.me/55{celular}?text={encodedMessage}";
                    //
                    bllRegistroAtividades.Salvar("ENVIO DE MENSAGEM WHATSAPP DE ORDEM DE SERVICO.", "ORDEM DE SERVICO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                    //
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarZAP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarZAP.");
                }
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                //
                string email = "";
                //
                if(SelectedRow.Cells[1].Value.ToString() != "0")
                {
                    if (bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()) == null)
                    {
                        MessageBox.Show("O Cliente/Consumidor não foi encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        email = null;
                    }
                    else
                    {
                        DataRow dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                        //
                        if (dr["email"].ToString() == null || dr["email"].ToString() == "")
                        {
                            MessageBox.Show("Este cliente não possui e-mail cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("A Ordem de Serviço selecionada não possui nenhum Cliente/Consumidor informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    email = null;
                }
                //
                using (FrmInfImpressao Imp = new FrmInfImpressao(45))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        GerarPDF();
                    }
                    else
                    {
                        return;
                    }
                }
                //
                pEnabled.Enabled = false;
                using (FrmUtilEnviarEmail Mail = new FrmUtilEnviarEmail(3, _Cod_PDV_Computador, _Usuario, @"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf;", "Segue em anexo Ordem de Serviço Nº " + SelectedRow.Cells[0].Value.ToString() + ", " + bllMinhaEmpresa.Sel_Nome_Empresa() + ", " + bllMinhaEmpresa.Sel_Empresa_Fantasia() + ", " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), "Ordem de Serviço Nº " + SelectedRow.Cells[0].Value.ToString(), email))
                {
                    if (Mail.ShowDialog() == DialogResult.OK)
                    {
                        dtOs.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCriarLembrete.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCriarLembrete.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbpSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSituacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar O.S. ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Gerar PDF: Clique para gerar o documento da O.S.\n\n6 - Enviar E-Mail: Clique para enviar um email para o cliente/consumidor da O.S.\n\n7 - Enviar ZAP: Clique para enviar uma mensagem de Whatsapp através do whatsapp web.\n\n8 - Finalizar: Clique para finalizar a O.S. selecionada.\n\n9 - Segunda Via do Recibo: Clique para gerar em PDF o recibo de pagamento da O.S..", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;

        }

        private void chkbDestOsPend_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbDestOsPend_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbDestOsPend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbDestOsPend.Checked == true)
            {
                if (dtOs.DataSource != null)
                {
                    for (int i = 0; i < dtOs.Rows.Count; i++)
                    {
                        if (dtOs.Rows[i].Cells[19].Value.ToString() == "PENDENTE")
                        {
                            dtOs.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else 
                        {
                            dtOs.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
            else
            {
                if (dtOs.DataSource != null)
                {
                    for (int i = 0; i < dtOs.Rows.Count; i++)
                    {
                        dtOs.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dtOs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
            }
          
        }

        private void lblValorRecebido_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pago (R$): " + lblValorRecebido.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnReciboRegistro_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmInfImpressao Imp = new FrmInfImpressao(45))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];
                        //
                        Gerar2ViaPDF();
                        //
                        AbrirPDF.Pdf(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
                pEnabled.Enabled = true;
            }
            catch (Exception ex)
            {
                dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnReciboRegistro.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnReciboRegistro.");
                }
            }
            pEnabled.Enabled = true;
            dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(11, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpUsuario.Items.Clear();
                        if (bllOS.Sel_Usuario_OS() == null)
                        {
                            cbbpUsuario.Text = null;
                            cbbpUsuario.Enabled = false;
                            lblUsuario.Enabled = false;
                        }
                        else
                        {
                            cbbpUsuario.Enabled = true;
                            lblUsuario.Enabled = true;
                            cbbpUsuario.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Usuario_OS().Rows)
                            {
                                cbbpUsuario.Items.Add(dr["id_usuario"].ToString() + "—" + dr["nome_usuario"].ToString());
                            }
                        }
                        cbbpUsuario.Text = bllOS._Usuario_PesqUsuario_Tabela;
                        bllOS._Usuario_PesqUsuario_Tabela = null;
                        cbbpUsuario.Select();
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
                        cbbpUsuario.Text = null;
                        bllOS._Usuario_PesqUsuario_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbpUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpCodigo.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtOs.Columns[0].DisplayIndex = 2;
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void mtxtDataBaixa_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa.Text == "")
            {
                mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataBaixa.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataBaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioBaixa.Select();
            }
        }

        private void mtxtDataBaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataBaixa.Text == "")
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataBaixa.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataBaixa_Enter(object sender, EventArgs e)
        {
            mtxtDataBaixa.BackColor = Color.LightBlue;
        }

        private void mtxtDataBaixa_Leave(object sender, EventArgs e)
        {
            mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa.Text != "")
            {
                try
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataBaixa.Text);

                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataBaixa1.Text != "")
                    {
                        mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataBaixa.Text) > Convert.ToDateTime(mtxtDataBaixa1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataBaixa.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa.");
                    }
                    mtxtDataBaixa.Text = null;
                }
            }
            mtxtDataBaixa.BackColor = Color.White;
        }

        private void mtxtHorarioBaixa_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa.Text == "")
            {
                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioBaixa.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioBaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataBaixa1.Select();
            }
        }

        private void mtxtHorarioBaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioBaixa.Text == "")
                {
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioBaixa.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioBaixa_Enter(object sender, EventArgs e)
        {
            mtxtHorarioBaixa.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioBaixa_Leave(object sender, EventArgs e)
        {
            mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa.Text != "")
            {
                if (mtxtHorarioBaixa.Text.Length == 4)
                {
                    mtxtHorarioBaixa.Text = mtxtHorarioBaixa.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioBaixa.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa.");
                    }
                    mtxtHorarioBaixa.Text = null;
                }
            }
            mtxtHorarioBaixa.BackColor = Color.White;
        }

        private void mtxtDataBaixa1_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa1.Text == "")
            {
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataBaixa1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataBaixa1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioBaixa1.Select();
            }
        }

        private void mtxtDataBaixa1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataBaixa1.Text == "")
                {
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataBaixa1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataBaixa1_Enter(object sender, EventArgs e)
        {
            mtxtDataBaixa1.BackColor = Color.LightBlue;
        }

        private void mtxtDataBaixa1_Leave(object sender, EventArgs e)
        {
            mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa1.Text != "")
            {
                try
                {
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataBaixa1.Text);

                    mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataBaixa.Text != "")
                    {
                        mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataBaixa1.Text) < Convert.ToDateTime(mtxtDataBaixa.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataBaixa1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa1.");
                    }
                    mtxtDataBaixa1.Text = null;
                }
            }
            mtxtDataBaixa1.BackColor = Color.White;
        }

        private void mtxtHorarioBaixa1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa1.Text == "")
            {
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioBaixa1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioBaixa1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFuncionario.Select();
            }
        }

        private void mtxtHorarioBaixa1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioBaixa1.Text == "")
                {
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioBaixa1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioBaixa1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioBaixa1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioBaixa1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa1.Text != "")
            {
                if (mtxtHorarioBaixa1.Text.Length == 4)
                {
                    mtxtHorarioBaixa1.Text = mtxtHorarioBaixa1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioBaixa1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa1.");
                    }
                    mtxtHorarioBaixa1.Text = null;
                }
            }
            mtxtHorarioBaixa1.BackColor = Color.White;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(26))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataBaixa.Text = bllOS._Data_DatePicker1;
                    mtxtDataBaixa1.Text = bllOS._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarFuncionario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmPesqFuncionario Func = new FrmPesqFuncionario(8, _Usuario, _Cod_PDV_Computador))
                {
                    if (Func.ShowDialog() == DialogResult.OK)
                    {
                        cbbFuncionario.Items.Clear();
                        if (bllOS.Sel_Funcionario_OS() == null)
                        {
                            cbbFuncionario.Text = null;
                            cbbFuncionario.Enabled = false;
                        }
                        else
                        {
                            cbbFuncionario.Enabled = true;
                            cbbFuncionario.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Funcionario_OS().Rows)
                            {
                                cbbFuncionario.Items.Add(dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString());
                            }
                        }
                        cbbFuncionario.Text = bllOS._Func_PesqFuncionario_Tabela;
                        bllOS._Func_PesqFuncionario_Tabela = null;
                        cbbFuncionario.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbFuncionario.Text = null;
                bllOS._Func_PesqFuncionario_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void cbbFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpSituacao.Select();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtHorario.Text = null;
            mtxtHorario.Text = null;
            cbbClieConsFunc.Text = null;
            cbbpUsuario.Text = null;
            txtpCodigo.Text = null;
            mtxtDataBaixa.Text = null;
            mtxtDataBaixa1.Text = null;
            cbbFuncionario.Text = null;
            cbbpSituacao.Text = null;
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            mtxtHorarioBaixa.Text = null;
            mtxtHorarioBaixa1.Text = null;
            cbbFormaPagamento.Text = null;
        }

        private void btnRelatorioPDF_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmInfImpressao Imp = new FrmInfImpressao(51))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        GerarRelatorio();
                        //
                        AbrirPDF.Pdf(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS\OS.pdf");
                    }
                }

                pEnabled.Enabled = true;
            }
            catch (Exception ex)
            {
                dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerar.");
                }
            }
            pEnabled.Enabled = true;
            dtOs.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        }

        private void btnProcurarForma_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(3, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFormaPagamento.Items.Clear();
                        if (bllOS.Sel_Forma_Pagamento_OS() == null)
                        {
                            cbbFormaPagamento.Text = null;
                            cbbFormaPagamento.Enabled = false;
                            lblFormaPagamento.Enabled = false;
                        }
                        else
                        {
                            cbbFormaPagamento.Enabled = true;
                            lblFormaPagamento.Enabled = true;
                            cbbFormaPagamento.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Forma_Pagamento_OS().Rows)
                            {
                                cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                            }
                        }
                        cbbFormaPagamento.Text = bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela;
                        bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela = null;
                        cbbFormaPagamento.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = false;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPagamento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPagamento.");
                        }
                        cbbFormaPagamento.Text = null;
                        bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void dtOs_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            chkbDestOsPend_CheckedChanged(sender, e);
        }

        private void dtOs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impede o som e a ação padrão
                e.Handled = true;
                //
                dtOs_DoubleClick(sender, e);
            }
        }

        private void btnConsultarServicos_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 7))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtOs.Select();
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

        private void btnConsultarProduto_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 9))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtOs.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarProduto.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnConsultarFuncionario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 8))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtOs.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarFuncionario.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnConsultarPagamento_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtOs.Rows[dtOs.CurrentRow.Index];

                if (SelectedRow.Cells[30].Value.ToString() == "")
                {
                    MessageBox.Show("Não existe(m) pagamento(s) para esta Ordem de Serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtOs.Select();
                }
                else
                {
                    using (FrmConsultarPagamento Pag = new FrmConsultarPagamento(SelectedRow.Cells[0].Value.ToString(), 6))
                    {
                        if (Pag.ShowDialog() == DialogResult.Abort)
                        {
                            dtOs.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultaPagamento.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void txtpCodigo_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}

