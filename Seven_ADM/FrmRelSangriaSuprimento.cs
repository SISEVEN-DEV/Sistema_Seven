using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelSangriaSuprimento : Form
    {
        public FrmRelSangriaSuprimento(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Cod_PDV_Computador = cod_pdv_computador;
            _Usuario = usuario;
            _Formulario = 0;
        }

        public FrmRelSangriaSuprimento(string usuario, string cod_pdv_computador, string data, string data1, string horario, string horario1, string pdv_computador_reg)
        {
            InitializeComponent();
            _Cod_PDV_Computador = cod_pdv_computador;
            _Usuario = usuario;
            _Data = data;
            _Data1 = data1;
            _Horario = horario;
            _Horario1 = horario1;
            _PDV_Computador_Reg = pdv_computador_reg;
            _Formulario = 1;
        }

        private byte _Trabalho;
        private string _Cod_PDV_Computador;
        private string _Usuario;
        private string _Data;
        private string _Data1;
        private string _Horario;
        private string _Horario1;
        private string _PDV_Computador_Reg;
        private byte _Formulario;

        private void Limpar_OutrosFiltros()
        {
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            cbbUsuario.Text = null;
            cbbCodPDV.Text = null;
        }

        private void FrmMovContsaPagar_Load(object sender, EventArgs e)
        {
            try
            {
                bllSangriaSuprimento._FrmRelSangriaSuprimento_Aberto = true;
                //
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSangriaSuprimento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSangriaSuprimento iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    rbtnDescricao.Checked = true;
                }
                else
                {
                    rbtnTodos.Checked = true;
                    rbtnDescricao.Enabled = false;
                    rbtnCodigo.Enabled = false;
                    rbtnTodos.Enabled = false;
                    lblDatas.ForeColor = Color.Blue;
                    mtxtpData.Enabled = false;
                    mtxtpData1.Enabled = false;
                    mtxtHorario.Enabled = false;
                    mtxtHorario1.Enabled = false;
                    lblAte.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    cbbCodPDV.Enabled = false;
                    lblCodPDV.ForeColor = Color.Blue;
                    btnProcurar1.Enabled = false;
                    mtxtpData.Text = _Data;
                    mtxtpData1.Text = _Data1;
                    mtxtHorario.Text = _Horario;
                    mtxtHorario1.Text = _Horario1;
                    cbbCodPDV.Text = _PDV_Computador_Reg;
                    btnPesquisar.Select();
                    btnPesquisar_Click(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFluxoCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFluxoCaixa.");
                }
            }
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

        private void btnCupomSangSup_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCupomSangSup_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioPDF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioPDF_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar1_MouseLeave(object sender, EventArgs e)
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

        private void btnProcurarUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarUsuario_MouseLeave(object sender, EventArgs e)
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

        private void cbbUsuario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_DropDownClosed(object sender, EventArgs e)
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad.");
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad1.");
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

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
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

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                this.Close();
            }
            else if (_Formulario == 1)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblDatas.Enabled = true;
                mtxtpData.Enabled = true;
                mtxtpData1.Enabled = true;
                lblAte.Enabled = true;
                btnSelecionarData.Enabled = true;
                txtpCodigo.Visible = false;
                txtpDescricao.Visible = true;
                lblPesquisar.Text = "Digite a Descrição";
                lblPesquisar.Location = new Point(362, 21);
                txtpDescricao.Text = null;
                txtpDescricao.Select();
                mtxtHorario.Enabled = true;
                mtxtHorario1.Enabled = true;
                lblUsuario.Enabled = true;
                cbbUsuario.Enabled = true;
                btnProcurarUsuario.Enabled = true;
                cbbCodPDV.Enabled = true;
                btnProcurar1.Enabled = true;
                lblCodPDV.Enabled = true;
                Limpar_OutrosFiltros();
                //
                cbbUsuario.Items.Clear();
                if (bllSangriaSuprimento.Sel_Usuario_Sangria_Suprimento() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllSangriaSuprimento.Sel_Usuario_Sangria_Suprimento().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
                //
                cbbCodPDV.Items.Clear();
                if (bllSangriaSuprimento.Sel_Cod_PDV_Sangria_Suprimento() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    cbbCodPDV.Enabled = true;
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllSangriaSuprimento.Sel_Cod_PDV_Sangria_Suprimento().Rows)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnDescricao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnDescricao.");
                }
                cbbUsuario.Items.Clear();
                cbbUsuario.Text = null;
                cbbCodPDV.Items.Clear();
                cbbCodPDV.Text = null;
            }
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblDatas.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            btnSelecionarData.Enabled = false;
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(519, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
            mtxtHorario.Enabled = false;
            mtxtHorario1.Enabled = false;
            lblUsuario.Enabled = false;
            cbbUsuario.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            cbbCodPDV.Enabled = false;
            btnProcurar1.Enabled = false;
            lblCodPDV.Enabled = false;
            Limpar_OutrosFiltros();
        }

        private void rbtnData_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblDatas.Enabled = true;
                mtxtpData.Enabled = true;
                mtxtpData1.Enabled = true;
                lblAte.Enabled = true;
                btnSelecionarData.Enabled = true;
                txtpCodigo.Visible = false;
                txtpDescricao.Visible = false;
                lblPesquisar.Text = "Exibir todo o cadastro:";
                lblPesquisar.Location = new Point(567, 21);
                mtxtpData.Text = null;
                mtxtpData1.Text = null;
                mtxtpData.Select();
                mtxtHorario.Enabled = true;
                mtxtHorario1.Enabled = true;
                lblUsuario.Enabled = true;
                cbbUsuario.Enabled = true;
                btnProcurarUsuario.Enabled = true;
                cbbCodPDV.Enabled = true;
                btnProcurar1.Enabled = true;
                lblCodPDV.Enabled = true;
                Limpar_OutrosFiltros();
                //
                cbbUsuario.Items.Clear();
                if (bllSangriaSuprimento.Sel_Usuario_Sangria_Suprimento() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllSangriaSuprimento.Sel_Usuario_Sangria_Suprimento().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
                //
                cbbCodPDV.Items.Clear();
                if (bllSangriaSuprimento.Sel_Cod_PDV_Sangria_Suprimento() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    cbbCodPDV.Enabled = true;
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllSangriaSuprimento.Sel_Cod_PDV_Sangria_Suprimento().Rows)
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
                cbbUsuario.Items.Clear();
                cbbUsuario.Text = null;
                cbbCodPDV.Items.Clear();
                cbbCodPDV.Text = null;
            }
        }

        private void FrmRelSangriaSuprimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSangriaSupirmento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSangriaSupirmento foi finalizado.");
                }
                bllSangriaSuprimento._FrmRelSangriaSuprimento_Aberto = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelSangriaSupirmento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelSangriaSupirmento.");
                }
            }
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text == "")
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario.Text = DateTime.Now.ToString("HH:mm") + ":00";
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

                    mtxtHorario.Text = DateTime.Now.ToString("HH:mm") + ":00";
                }
                else
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
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

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text == "")
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario1.Text = DateTime.Now.ToString("HH:mm") + ":00";
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

                    mtxtHorario1.Text = DateTime.Now.ToString("HH:mm") + ":00";
                }
                else
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUsuario.Select();
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

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbCodPDV.Enabled == false)
                {
                    btnPesquisar.Select();
                }
                else
                {
                    cbbCodPDV.Select();
                }
            }
        }

        private void cbbCodPDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void FrmRelSangriaSuprimento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 0)
                {
                    this.Close();
                }
                else if (_Formulario == 1)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void lblValorSuprimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorSuprimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorSangria_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorSangria_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorSuprimento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suprimentos (R$): " + Convert.ToDecimal(lblValorSuprimento.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorSangria_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sangrias (R$): " + Convert.ToDecimal(lblValorSangria.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtSangSup_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtSangSup.DataSource == null)
            {
                dtSangSup.Enabled = false;
                grbBox2.Enabled = false;
                lblSuprimento.Enabled = false;
                lblValorSuprimento.Enabled = false;
                lblSangria.Enabled = false;
                lblValorSangria.Enabled = false;
            }
            else
            {
                dtSangSup.Enabled = true;
                grbBox2.Enabled = true;
                lblSuprimento.Enabled = true;
                lblValorSuprimento.Enabled = true;
                lblSangria.Enabled = true;
                lblValorSangria.Enabled = true;
                //
                decimal suprimento = 0;
                decimal sangria = 0;
                for (int i = 0; i < dtSangSup.Rows.Count; i++)
                {
                    if (dtSangSup.Rows[i].Cells[3].Value.ToString() == "SUPRIMENTO")
                    {
                        dtSangSup.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                        suprimento += Convert.ToDecimal(dtSangSup.Rows[i].Cells[2].Value);
                    }
                    //
                    if (dtSangSup.Rows[i].Cells[3].Value.ToString() == "SANGRIA")
                    {
                        dtSangSup.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                        sangria += Convert.ToDecimal(dtSangSup.Rows[i].Cells[2].Value);
                    }
                }
                lblValorSuprimento.Text = Convert.ToDecimal(suprimento).ToString("n2", new CultureInfo("pt-BR"));
                lblValorSangria.Text = Convert.ToDecimal(sangria).ToString("n2", new CultureInfo("pt-BR"));
            }
        }

        private void dtSangSup_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtSangSup.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtSangSup_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtSangSup_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtSangSup.Columns[0].HeaderText = "Código";
                dtSangSup.Columns[1].HeaderText = "Descrição";
                dtSangSup.Columns[2].HeaderText = "Valor (R$)";
                dtSangSup.Columns[3].HeaderText = "Tipo";
                dtSangSup.Columns[4].HeaderText = "Data";
                dtSangSup.Columns[5].HeaderText = "Horário";
                dtSangSup.Columns[6].HeaderText = "Cód. do Usuário";
                dtSangSup.Columns[7].HeaderText = "Nome do Usuário";
                dtSangSup.Columns[8].HeaderText = "Cód. do PDV/Computador";

                dtSangSup.Columns[0].Width = 85;
                dtSangSup.Columns[1].Width = 320;
                dtSangSup.Columns[2].Width = 155;
                dtSangSup.Columns[3].Width = 127;
                dtSangSup.Columns[4].Width = 115;
                dtSangSup.Columns[5].Width = 115;
                dtSangSup.Columns[6].Width = 115;
                dtSangSup.Columns[7].Width = 115;
                dtSangSup.Columns[8].Width = 175;

                dtSangSup.DefaultCellStyle.Font = new Font(dtSangSup.Font, FontStyle.Bold);

                dtSangSup.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSangSup.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRegistros.Text = "Registros: " + dtSangSup.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtSangSup.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtSangSup.");
                }
                dtSangSup.DataSource = null;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodos.Checked == true)
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

                        if (bllSangriaSuprimento.Sel_Data_Sang_Sup(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text) == null)
                        {
                            dtSangSup.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtSangSup.DataSource = bllSangriaSuprimento.Sel_Data_Sang_Sup(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text);
                            dtSangSup.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllSangriaSuprimento.Sel_Codigo_Sang_Sup(txtpCodigo.Text.Trim()) == null)
                        {
                            dtSangSup.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtSangSup.DataSource = bllSangriaSuprimento.Sel_Codigo_Sang_Sup(txtpCodigo.Text);
                            dtSangSup.Select();
                        }
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text.Trim() != "")
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

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData.Select();
                            return;
                        }
                        else if (mtxtpData.Text == "" & mtxtpData1.Text == "" & mtxtHorario.Text != "" & mtxtHorario1.Text != "")
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Horário ] e [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtHorario.Select();
                            return;
                        }
                        else if ((mtxtHorario.Text != "" & mtxtHorario.Text != "") & (mtxtpData.Text == "" || mtxtpData1.Text == ""))
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] e [ Horário ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                            if (bllSangriaSuprimento.Sel_Descricao_Sang_Sup(txtpDescricao.Text, mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text) == null)
                            {
                                dtSangSup.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtSangSup.DataSource = bllSangriaSuprimento.Sel_Descricao_Sang_Sup(txtpDescricao.Text, mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text);
                                dtSangSup.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtSangSup.DataSource = null;
                if (_Formulario == 0)
                {
                    rbtnCodigo.Checked = true;
                }
                else
                {
                    cbbUsuario.Select();
                }
            }
        }

        private void dtSangSup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void dtSangSup_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtSangSup.Columns[2].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtSangSup.Columns[2].DefaultCellStyle.Format = "n2";

            dtSangSup.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtSangSup.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnRelatorioPDF_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(16))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 0;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtSangSup.Enabled = false;
                    dtSangSup.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código e todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples do(s) registro(s).\n\n2 - Cupom da Sangria/Suprimento: Clique para imprimir o cupom do registro selecionado.\n\n3 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n4 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).\n\n5 - Excluir: Clique para o registro selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
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
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllSangriaSuprimento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + "CPF/CNPJ.: " + dr["cpf_cnpj"].ToString() + ", IE/RG.: " + dr["ie_rg"].ToString() + Environment.NewLine + "End.: " + dr["endereco"].ToString() + Environment.NewLine + dr["complemento"].ToString() + ", " + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + "Tel.: " + dr["telefone"].ToString() + ", Cel.: " + dr["celular"].ToString() + Environment.NewLine + "E-mail.: " + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                    //
                    textFormatter1.DrawString("Relatório de Sangria e Suprimento", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("DESCRIÇÃO", fonte1, XBrushes.Black, new XRect(65 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("VALOR (R$)", fonte1, XBrushes.Black, new XRect(155 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("TIPO", fonte1, XBrushes.Black, new XRect(235 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("DATA", fonte1, XBrushes.Black, new XRect(275 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("HORÁRIO", fonte1, XBrushes.Black, new XRect(320 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("USUÁRIO", fonte1, XBrushes.Black, new XRect(390 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("PDV/COMPUTADOR", fonte1, XBrushes.Black, new XRect(455 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 15;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 35;
                    for (int i = 0; i < dtSangSup.Rows.Count; i++)
                    {
                        if (i == 15)
                        {
                            TotalPaginas = TotalPaginas + 1;
                        }
                        else if (i == registros)
                        {
                            registros = registros + 20;
                            TotalPaginas = TotalPaginas + 1;
                        }
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //               
                    for (int linha = 0; linha < dtSangSup.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtSangSup.Rows[linha];
                        //
                        if (linha < 30 & PrimeiraPagina == true)
                        {
                            if (linha == dtSangSup.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(151 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(56 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //                                
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(114 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() == "SUPRIMENTO")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Blue, new XRect(138 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Red, new XRect(138 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(230 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(255 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(391 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Cód. PDV/Comp.:", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(546 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Suprimentos (R$): " + lblValorSuprimento.Text, fonte2, XBrushes.Blue, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Sangria (R$): " + lblValorSangria.Text, fonte2, XBrushes.Red, new XRect(380 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(151 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(56 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //                                
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(114 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() == "SUPRIMENTO")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Blue, new XRect(138 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Red, new XRect(138 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(230 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(255 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(391 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Cód. PDV/Comp.:", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(546 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;
                            }
                            //
                            if (linha == (pagina - 1) & dtSangSup.Rows.Count > 15)
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
                                textFormatter1.DrawString("Relatório de Sangria e Suprimento", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                pagina = pagina + 20;
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
                                textFormatter1.DrawString("Relatório de Sangria e Suprimento", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtSangSup.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(151 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(56 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //                                
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(114 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() == "SUPRIMENTO")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Blue, new XRect(138 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Red, new XRect(138 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(230 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(255 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(391 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Cód. PDV/Comp.:", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(546 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Suprimentos (R$): " + lblValorSuprimento.Text, fonte2, XBrushes.Blue, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Sangria (R$): " + lblValorSangria.Text, fonte2, XBrushes.Red, new XRect(380 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(151 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(56 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //                                
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(114 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() == "SUPRIMENTO")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Blue, new XRect(138 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Red, new XRect(138 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(230 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(255 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(355 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(391 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Cód. PDV/Comp.:", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(546 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
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
                    int AumentoDeLinhaFixo = 0;
                    //
                    if (bllSangriaSuprimento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 85 + Margem_Topo, 198, 16);
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        AumentoDeLinhaFixo = AumentoDeLinhaFixo + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 8));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 93 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 93 + Margem_Topo, 198, 16));
                        }
                        AumentoDeLinhaFixo = AumentoDeLinhaFixo + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 93 + Margem_Topo, 198, 8));
                    }
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 101 + Margem_Topo, 198, 8));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 101 + Margem_Topo, 198, 8));
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 109 + Margem_Topo, 198, 40);
                    textFormatter1.DrawString(endereco + ", " + numero + ", " + bairro + ", " + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 109 + Margem_Topo, 198, 40));
                    //
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + AumentoDeLinhaFixo + Margem_Topo, 198, 24));
                    textFormatter1.DrawString("SANGRIA/SUPRIMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + AumentoDeLinhaFixo + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + AumentoDeLinhaFixo + Margem_Topo, 198, 24));
                    //
                    DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];
                    //
                    textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 160 + Margem_Topo, 198, 7));
                    //  
                    textFormatter2.DrawString("Tipo: " + SelectedRow.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 168 + Margem_Topo, 198, 7));
                    //     
                    if (SelectedRow.Cells[1].Value.ToString().Length > 40)
                    {
                        textFormatter2.DrawString("Descrição: " + SelectedRow.Cells[1].Value.ToString().Insert(40, Environment.NewLine), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 176 + Margem_Topo, 198, 14));
                        AumentoDeLinhaFixo = AumentoDeLinhaFixo + 8;
                    }
                    else
                    {
                        textFormatter2.DrawString("Descrição: " + SelectedRow.Cells[1].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 176 + Margem_Topo, 198, 7));
                    }
                    //
                    textFormatter2.DrawString("Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 184 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Data: " + SelectedRow.Cells[4].Value.ToString().Remove(10), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 192 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Horário: " + SelectedRow.Cells[5].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 200 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Usuário(a): " + SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 208 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Nº do PDV: " + SelectedRow.Cells[8].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 216 + Margem_Topo, 198, 7));
                    //
                    textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 232 + Margem_Topo, 198, 16));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 2)
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
                    //
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 12);
                    var fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
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
                    if (bllSangriaSuprimento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 280 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
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
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 124 + Margem_Topo, 595, 45));
                    //
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 160 + Margem_Topo, 595, 24));
                    textFormatter1.DrawString("SANGRIA/SUPRIMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 169 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 175 + Margem_Topo, 595, 24));
                    //
                    //
                    int Incrementar = 0;
                    DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];
                    //
                    textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 185 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Tipo: " + SelectedRow.Cells[3].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 199 + Margem_Topo, 595, 13));
                    //  
                    textFormatter2.DrawString("Descrição: " + SelectedRow.Cells[1].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 213 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 227 + Margem_Topo, 595, 13)); Incrementar = Incrementar + 26;
                    //
                    textFormatter2.DrawString("Data: " + SelectedRow.Cells[4].Value.ToString().Remove(10), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 241 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Horário: " + SelectedRow.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 255 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Usuário(a): " + SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 269 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Nº do PDV: " + SelectedRow.Cells[8].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 283 + Margem_Topo, 595, 13));
                    //
                    textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 309 + Margem_Topo, 585, 11));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 3)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.txt"))
                {
                    writer.WriteLine("Relatório de Sangrias e Suprimentos" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtSangSup.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtSangSup.Rows[linha];
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Descrição: " + SelectedRow.Cells[1].Value.ToString() + " |Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Tipo: " + SelectedRow.Cells[3].Value.ToString() + " |Data: " + SelectedRow.Cells[4].Value.ToString().Remove(10) + " |Horário: " + SelectedRow.Cells[5].Value.ToString() + " |Cód. do Usuário: " + SelectedRow.Cells[6].Value.ToString() + " |Nome do Usuário: " + SelectedRow.Cells[7].Value.ToString() + " |Cód. do PDV/Computador: " + SelectedRow.Cells[8].Value.ToString());
                    }
                    writer.WriteLine("Suprimentos (R$): " + lblValorSuprimento.Text + "    Sangrias (R$): " + lblValorSangria.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.txt");
            }
            else if (_Trabalho == 4)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Descrição;Valor (R$);Tipo;Data;Horário;Cód. do Usuário;Nome do Usuário;Cód. do PDV/Computador;");
                    for (int linha = 0; linha < dtSangSup.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtSangSup.Rows[linha];
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString().Remove(10), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString()));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Sangrias e Suprimentos");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                    Sw.WriteLine("Suprimentos (R$): " + lblValorSuprimento.Text);
                    Sw.WriteLine("Sangrias (R$): " + lblValorSangria.Text);
                } //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.csv");
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
                dtSangSup.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                btnSair.Enabled = true;
                if (_Formulario == 0)
                {
                    rbtnCodigo.Checked = true;
                }
                else
                {
                    cbbUsuario.Select();
                }
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtSangSup.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtSangSup.Select();
                //
                DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];
                //
                try
                {
                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\SangriaSuprimento.pdf");
                    }
                    else if (_Trabalho == 1)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 2)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
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
                    dtSangSup.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                    if (_Formulario == 0)
                    {
                        rbtnCodigo.Checked = true;
                    }
                    else
                    {
                        cbbUsuario.Select();
                    }
                }
            }
        }

        private void btnCupomSangSup_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(17))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllSangriaSuprimento._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                    {
                        _Trabalho = 1;
                    }
                    else if (bllSangriaSuprimento._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 2;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtSangSup.Enabled = false;
                    dtSangSup.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 3;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtSangSup.Enabled = false;
            dtSangSup.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 4;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtSangSup.Enabled = false;
            dtSangSup.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(10))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllSangriaSuprimento._Data_DatePicker1;
                    mtxtpData1.Text = bllSangriaSuprimento._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(6, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllSangriaSuprimento.Sel_Usuario_Sangria_Suprimento() == null)
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
                            foreach (DataRow dr in bllSangriaSuprimento.Sel_Usuario_Sangria_Suprimento().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllSangriaSuprimento._SangriaSuprimento_PesqUsuarioTabela;
                        bllSangriaSuprimento._SangriaSuprimento_PesqUsuarioTabela = null;
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
                        bllSangriaSuprimento._SangriaSuprimento_PesqUsuarioTabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqComputadorPDV Comp = new FrmPesqComputadorPDV(5))
            {
                if (Comp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCodPDV.Items.Clear();
                        if (bllSangriaSuprimento.Sel_Cod_PDV_Sangria_Suprimento() != null)
                        {
                            cbbCodPDV.Items.Add("");
                            foreach (DataRow dr in bllSangriaSuprimento.Sel_Cod_PDV_Sangria_Suprimento().Rows)
                            {
                                cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
                            }
                        }
                        cbbCodPDV.Text = bllSangriaSuprimento._SangriaSuprimento_PesqCompPDV_Tabela;
                        bllSangriaSuprimento._SangriaSuprimento_PesqCompPDV_Tabela = null;
                        cbbCodPDV.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão  btnProcurar1.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão  btnProcurar1.");
                        }
                        cbbCodPDV.Text = null;
                        bllSangriaSuprimento._SangriaSuprimento_PesqCompPDV_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0)
                {
                    MessageBox.Show("Não é possível excluir este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtSangSup.Select();
                }
                else if (bllSangriaSuprimento.Sel_SangriaSuprimento_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtSangSup.Select();
                }
                else if (bllUsuario.Sel_Excluir_Sang_Sup_Usuario(_Usuario) == false)
                {
                    MessageBox.Show("O Usuário atual não possui permissão para excluir Sangrias/Suprimentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtSangSup.Select();
                }
                else
                {
                    string mensagem;

                    if (SelectedRow.Cells[3].Value.ToString() == "SUPRIMENTO")
                    {
                        mensagem = "Deseja excluir este Suprimento?";
                    }
                    else
                    {
                        mensagem = "Deseja excluir esta Sangria?";
                    }

                    DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        if (SelectedRow.Cells[3].Value.ToString() == "SUPRIMENTO")
                        {
                            mensagem = "EXCLUIU UM SUPRIMENTO";
                            bllFluxoCaixa.Salvar(DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.'), DateTime.Now.ToString("HH:mm:ss"), "SAIDA", "RETORNO DE SUPRIMENTO DE CAIXA", SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        else
                        {
                            mensagem = "EXCLUIU UMA SANGRIA";
                            bllFluxoCaixa.Salvar(DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.'), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "RETORNO DE SANGRIA DE CAIXA", SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        bllRegistroAtividades.Salvar(mensagem, "SANGRIA/SUPRIMENTO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //                     
                        bllSangriaSuprimento.Excluir(SelectedRow.Cells[0].Value.ToString());
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sangria/Suprimento excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sangria/Suprimento excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }
                        //
                        if (rbtnTodos.Checked == true)
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

                                if (bllSangriaSuprimento.Sel_Data_Sang_Sup(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text) == null)
                                {
                                    dtSangSup.DataSource = null;
                                }
                                else
                                {
                                    dtSangSup.DataSource = bllSangriaSuprimento.Sel_Data_Sang_Sup(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text);
                                    dtSangSup.Select();
                                }
                            }
                        }
                        else if (rbtnDescricao.Checked == true)
                        {
                            if (txtpDescricao.Text.Trim() != "")
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

                                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtpData.Select();
                                    return;
                                }
                                else if (mtxtpData.Text == "" & mtxtpData1.Text == "" & mtxtHorario.Text != "" & mtxtHorario1.Text != "")
                                {
                                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                    MessageBox.Show("É necessário preencher ambos os campos de [ Horário ] e [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtHorario.Select();
                                    return;
                                }
                                else if ((mtxtHorario.Text != "" & mtxtHorario.Text != "") & (mtxtpData.Text == "" || mtxtpData1.Text == ""))
                                {
                                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] e [ Horário ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                                    if (bllSangriaSuprimento.Sel_Descricao_Sang_Sup(txtpDescricao.Text, mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text) == null)
                                    {
                                        dtSangSup.DataSource = null;
                                    }
                                    else
                                    {
                                        dtSangSup.DataSource = bllSangriaSuprimento.Sel_Descricao_Sang_Sup(txtpDescricao.Text, mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text);
                                        dtSangSup.Select();
                                    }
                                }
                            }
                            else
                            {
                                dtSangSup.DataSource = null;
                            }
                        }
                        else
                        {
                            dtSangSup.DataSource = null;
                        }
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        if (dtSangSup.DataSource != null)
                        {
                            dtSangSup.Select();
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                dtSangSup.DataSource = null;
                rbtnDescricao.Checked = true;
                Limpar_OutrosFiltros();
            }
        }

        private void dtSangSup_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblValorSuprimento.Text = null;
            lblValorSangria.Text = null;
            lblRegistros.Text = "Registros: 0";
        }
    }
}
