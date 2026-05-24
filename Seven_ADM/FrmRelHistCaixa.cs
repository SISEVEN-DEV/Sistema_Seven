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
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelHistCaixa : Form
    {
        public FrmRelHistCaixa(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = 0;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        public FrmRelHistCaixa(string data, string data1, string horario, string horario1, string pdv_computador_reg, string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Data = data;
            _Data1 = data1;
            _Horario = horario;
            _Horario1 = horario1;
            if (formulario == 1)
            {
                if (pdv_computador_reg.Contains("/"))
                {
                    string[] items = pdv_computador_reg.Split('/');
                    _PDV_Computador_Reg = items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", "");
                }
                else
                {
                    _PDV_Computador_Reg = pdv_computador_reg;
                }
            }
            else if (formulario == 2)
            {
                string[] items = pdv_computador_reg.Split('/');
                _PDV_Computador_Reg = items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""); ;
            }
            _Formulario = formulario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        byte _Formulario;
        private string _Usuario;
        private byte _Trabalho;
        string _Data;
        string _Data1;
        string _Horario;
        string _Horario1;
        string _PDV_Computador_Reg;
        //
        string _Data2;
        string _Data3;
        string _Horario2;
        string _Horario3;
        private string _Usuario1;
        string _PDV_Computador_Reg1;
        string _Cod_PDV_Computador;

        private void FrmRelHistCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                bllHistCaixa._FrmRelHistCaixa_Aberto = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelHistoricoCaixa iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelHistoricoCaixa iniciado.");
                }
                //                
                cbbCodPDV.Items.Clear();
                if (bllHistCaixa.Sel_Comp_PDV_HistCaixa() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    if (_Formulario == 0)
                    {
                        cbbCodPDV.Enabled = true;
                    }
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllHistCaixa.Sel_Comp_PDV_HistCaixa().Rows)
                    {
                        cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
                    }
                }
                //
                cbbUsuario.Items.Clear();
                if (bllHistCaixa.Sel_Usuario_HistCaixa() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllHistCaixa.Sel_Usuario_HistCaixa().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
                //
                if (_Formulario == 0)
                {
                    mtxtpData.Select();
                }
                else if (_Formulario == 1)
                {
                    mtxtpData.Text = _Data;
                    mtxtpData.Enabled = false;
                    lblAte.Enabled = false;
                    lblData.ForeColor = Color.Blue;
                    btnSelecionarData.Enabled = false;
                    label2.Enabled = false;
                    mtxtpData1.Text = _Data1;
                    mtxtpData1.Enabled = false;
                    mtxtHorario.Text = _Horario;
                    mtxtHorario.Enabled = false;
                    mtxtHorario1.Text = _Horario1;
                    mtxtHorario1.Enabled = false;
                    cbbCodPDV.Text = _PDV_Computador_Reg;
                    lblCodPDV.ForeColor = Color.Blue;
                    cbbCodPDV.Enabled = false;
                    btnProcurar1.Enabled = false;
                    btnPesquisar.Select();
                    btnPesquisar_Click(sender, e);
                }
                else if (_Formulario == 2)
                {
                    cbbUsuario.Enabled = false;
                    lblUsuario.Enabled = false;
                    btnProcurarUsuario.Enabled = false;
                    cbbUsuario.Text = _Usuario.Replace("Usuário(a): ", "");
                    cbbCodPDV.Text = _PDV_Computador_Reg;
                    lblCodPDV.Enabled = false;
                    cbbCodPDV.Enabled = false;
                    btnProcurar1.Enabled = false;
                    mtxtpData.Text = _Data;
                    mtxtHorario.Text = _Horario;
                    mtxtpData1.Text = _Data1;
                    mtxtHorario1.Text = _Horario1;
                    mtxtpData.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelHistoricoCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelHistoricoCaixa.");
                }
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

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(5))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllHistCaixa._Data_DatePicker1;
                    mtxtpData1.Text = bllHistCaixa._Data_DatePicker2;
                    mtxtpData1.Select();
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

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
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

                mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
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

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_Formulario == 2)
                {
                    btnPesquisar.Select();
                }
                else
                {
                    cbbUsuario.Select();
                }
            }
        }

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbCodPDV.Enabled == true)
                {
                    cbbCodPDV.Select();
                }
                else
                {
                    btnPesquisar.Select();
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

        private void FrmRelHistCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllHistCaixa._FrmRelHistCaixa_Aberto = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelHistoricoCaixa foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelHistoricoCaixa foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelHistoricoCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelHistoricoCaixa.");
                }
            }
        }

        private void FrmRelHistCaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 0)
                {
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTotalVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblDescontoVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblDescontoVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblAcrescimoVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblAcrescimoVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalRealVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalRealVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblSuprimentos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblSuprimentos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalRealContasReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalRealContasReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblSangria_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalRealContaPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalRealContaPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQtdeVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQtdeVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQtdeSup_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQtdeSup_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQtdeSangria_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQtdeSangria_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblDinheiro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblDinheiro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalTroco_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalTroco_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblPIX_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblPIX_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCartaoCredito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCartaoCredito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCartaoDebito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCartaoDebito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCreditoLoja_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCreditoLoja_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCheque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCheque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalEntrada_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalEntrada_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalSaida_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalSaida_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalSaldo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalSaldo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnResumido_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnResumido_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total das Vendas (R$): " + lblTotalVenda.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblDescontoVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Descontos das Vendas (R$): " + lblDescontoVenda.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblAcrescimoVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acréscimos das Vendas (R$): " + lblAcrescimoVenda.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalRealVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Real das Vendas (R$): " + lblTotalVendasVista.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblSuprimentos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suprimentos (R$): " + lblSuprimentos.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalRealContasReceber_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Real das Contas a Receber (R$): " + lblTotalRealContasReceber.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblSangria_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sangrias (R$): " + lblSangria.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalRealContaPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Real das Contas a Pagar (R$): " + lblTotalRealContaPagar.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQtdeVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Qtde. de Vendas: " + lblQtdeVenda.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQtdeSup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Qtde. de Suprimentos: " + lblQtdeSup.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQtdeSangria_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Qtde. de Sangrias: " + lblQtdeSangria.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblDinheiro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dinheiro (R$): " + lblDinheiro.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalTroco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Troco (R$): " + lblTotalTroco.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblPIX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PIX (R$): " + lblPIX.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblCartaoCredito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cartão de Crédito (R$): " + lblCartaoCredito.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblCartaoDebito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cartão de Débito (R$): " + lblCartaoDebito.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblCreditoLoja_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Crédito da Loja (R$): " + lblCreditoLoja.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblCheque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total de Vendas Cheque (R$): " + lblCheque.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalEntrada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total de Entradas + (R$): " + lblTotalEntrada.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalSaida_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total de Saídas - (R$): " + lblTotalSaida.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entradas - Saídas (R$): " + lblTotalSaldo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblSangria_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(1, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllHistCaixa.Sel_Usuario_HistCaixa() != null)
                        {
                            cbbUsuario.Items.Add("");
                            foreach (DataRow dr in bllHistCaixa.Sel_Usuario_HistCaixa().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllHistCaixa._Hist_PesqUsuario_Tabela;
                        bllHistCaixa._Hist_PesqUsuario_Tabela = null;
                        cbbUsuario.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
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
                        bllHistCaixa._Hist_PesqUsuario_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqComputadorPDV Comp = new FrmPesqComputadorPDV(0))
            {
                if (Comp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCodPDV.Items.Clear();
                        if (bllHistCaixa.Sel_Comp_PDV_HistCaixa() != null)
                        {
                            cbbCodPDV.Items.Add("");
                            foreach (DataRow dr in bllHistCaixa.Sel_Comp_PDV_HistCaixa().Rows)
                            {
                                cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
                            }
                        }
                        cbbCodPDV.Text = bllHistCaixa._Hist_PesqCompPDV_Tabela;
                        bllHistCaixa._Hist_PesqCompPDV_Tabela = null;
                        cbbCodPDV.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar1.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar1.");
                        }
                        cbbCodPDV.Text = null;
                        bllHistCaixa._Hist_PesqCompPDV_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                //
                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                //
                if (mtxtpData.Text == "" & mtxtpData1.Text == "")
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    MessageBox.Show("É necessário preencher os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtpData.Select();
                    return;
                }
                else if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
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
                    return;
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    DataRow dr = bllHistCaixa.Sel_Caixa_Dados_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text).Rows[0];
                    //
                    grbBox1.Enabled = true;
                    lblEntrada.Enabled = true;
                    lblSaida.Enabled = true;
                    lblSaldo.Enabled = true;
                    lblTotalEntrada.Enabled = true;
                    lblTotalSaida.Enabled = true;
                    lblTotalSaldo.Enabled = true;
                    btnResumido.Enabled = true;
                    rbtnExportarTxt.Enabled = true;
                    //
                    lblTotalVendaNotaPromissoria.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Vendas_Nota_Pomissoria(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblCreditoLoja.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Credito_Loja_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblCheque.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Cheque_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblTotalVenda.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Vendas(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR")).Replace("-", "");
                    //
                    lblTotalRealVendas.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Real_Vendas(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR")).Replace("-", "");
                    //
                    lblDescontoVenda.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Descontos_Vendas(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblAcrescimoVenda.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Acrescimos_Vendas(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblTotalVendasVista.Text = Convert.ToDecimal(Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Real_Vendas_A_Vista(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)) - Convert.ToDecimal(lblTotalVendaNotaPromissoria.Text) - Convert.ToDecimal(lblCheque.Text) - Convert.ToDecimal(lblCreditoLoja.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblQtdeVenda.Text = bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Vendas_Qtde(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text);
                    //
                    lblTotalRealContasReceber.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Conta_Receber_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblTotalRealContaPagar.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Conta_Pagar_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblSuprimentos.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Sup_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblQtdeSup.Text = bllHistCaixa.Sel_Caixa_Dados_Sup_Hist_Qtdeg(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text);
                    //
                    lblSangria.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Sang_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblQtdeSangria.Text = bllHistCaixa.Sel_Caixa_Dados_Sang_Hist_Qtdeg(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text);
                    //
                    lblDinheiro.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Dinheiro_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblTotalTroco.Text = Convert.ToDecimal(bllHistCaixa.Sel_Abert_Caixa_Dados_Troco(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblCartaoCredito.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblCartaoDebito.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblPIX.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Pix_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblValeAlimRef.Text = Convert.ToDecimal(Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Alimentacao_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)) + Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Refeicao_Hist(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text))).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblQtdeDevolucoes.Text = bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Devolucao_Qtde(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text);
                    //
                    lblTotalDevolucoes.Text = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Hist_Total_Devolucao(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbCodPDV.Text, cbbUsuario.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblTotalEntrada.Text = Convert.ToDecimal((Convert.ToDecimal(lblDinheiro.Text) - Convert.ToDecimal(lblTotalTroco.Text)) + Convert.ToDecimal(lblPIX.Text) + Convert.ToDecimal(lblValeAlimRef.Text) + Convert.ToDecimal(lblCartaoCredito.Text) + Convert.ToDecimal(lblCartaoDebito.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblTotalSaida.Text = Convert.ToDecimal(Convert.ToDecimal(lblTotalRealContaPagar.Text) + Convert.ToDecimal(lblSangria.Text) + Convert.ToDecimal(lblTotalDevolucoes.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblTotalSaldo.Text = Convert.ToDecimal(Convert.ToDecimal(lblTotalEntrada.Text) - Convert.ToDecimal(lblTotalSaida.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    grbBox1.Enabled = true;
                    grbBox5.Enabled = true;
                    lblEntrada.Enabled = true;
                    lblTotalEntrada.Enabled = true;
                    lblSaida.Enabled = true;
                    lblTotalSaida.Enabled = true;
                    lblSaldo.Enabled = true;
                    lblTotalSaldo.Enabled = true;
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
                lblTotalVenda.Text = null;
                lblDescontoVenda.Text = null;
                lblAcrescimoVenda.Text = null;
                lblQtdeVenda.Text = null;
                lblTotalRealContasReceber.Text = null;
                lblTotalRealContaPagar.Text = null;
                lblSuprimentos.Text = null;
                lblQtdeSup.Text = null;
                lblSangria.Text = null;
                lblQtdeSangria.Text = null;
                lblDinheiro.Text = null;
                lblTotalTroco.Text = null;
                lblCartaoCredito.Text = null;
                lblCartaoDebito.Text = null;
                lblPIX.Text = null;
                lblCreditoLoja.Text = null;
                lblCheque.Text = null;
                lblTotalEntrada.Text = null;
                lblTotalSaida.Text = null;
                lblTotalSaldo.Text = null;
                if (_Formulario == 0)
                {
                    mtxtpData.Select();
                }
                else
                {
                    cbbUsuario.Select();
                }
            }
        }

        private void btnResumido_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(12))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Data2 = mtxtpData.Text;
                    _Data3 = mtxtpData1.Text;
                    //
                    mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    if (mtxtHorario.Text != "")
                    {
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        _Horario2 = mtxtHorario.Text;
                    }
                    else
                    {
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        _Horario2 = "";
                    }
                    //
                    mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    if (mtxtHorario1.Text != "")
                    {
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        _Horario3 = mtxtHorario.Text;
                    }
                    else
                    {
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        _Horario3 = "";
                    }
                    //
                    _Usuario1 = cbbUsuario.Text;
                    _PDV_Computador_Reg1 = cbbCodPDV.Text;
                    //
                    if (bllHistCaixa._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                    {
                        _Trabalho = 0;
                    }
                    else if (bllHistCaixa._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 1;
                    }
                    else
                    {
                        _Trabalho = 3;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    lblEntrada.Enabled = false;
                    lblSaida.Enabled = false;
                    lblSaldo.Enabled = false;
                    lblTotalEntrada.Enabled = false;
                    lblTotalSaida.Enabled = false;
                    lblTotalSaldo.Enabled = false;
                    btnResumido.Enabled = false;
                    rbtnExportarTxt.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
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
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    //
                    textFormatter1.DrawString(bllMinhaEmpresa.Sel_Nome_Empresa(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 12));
                    Margem_Topo = Margem_Topo + 12;
                    textFormatter1.DrawString(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 12));
                    Margem_Topo = Margem_Topo + 12;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 1 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter1.DrawString("HISTÓRICO DE CAIXA", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 12 + Incrementar + Margem_Topo, 198, 24));
                    //
                    Margem_Topo = Margem_Topo - 14;
                    //
                    string hora1;
                    if (_Horario2 != "")
                    {
                        hora1 = "A partir de " + mtxtpData.Text + " " + mtxtHorario.Text;
                    }
                    else
                    {
                        hora1 = "A partir de " + mtxtpData.Text;
                    }
                    //
                    string hora2;
                    if (_Horario3 != "")
                    {
                        hora2 = " Até " + mtxtpData1.Text + " " + mtxtHorario1.Text;
                    }
                    else
                    {
                        hora2 = " Até " + mtxtpData1.Text;
                    }
                    //
                    textFormatter2.DrawString("Datas: " + hora1 + hora2, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 36 + Margem_Topo, 198, 7));
                    //
                    if (_PDV_Computador_Reg1 == "")
                    {
                        textFormatter2.DrawString("Nº do PDV/Caixa: Não informado.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 46 + Margem_Topo, 198, 7));
                    }
                    else
                    {
                        textFormatter2.DrawString("Nº do PDV/Caixa: " + _PDV_Computador_Reg1, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 46 + Margem_Topo, 198, 7));
                    }
                    //
                    if (_Usuario1 == "")
                    {
                        textFormatter2.DrawString("Usuário: Não informado.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                    }
                    else
                    {
                        textFormatter2.DrawString("Usuário: " + _Usuario1, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                    }
                    //
                    Margem_Topo = Margem_Topo - 25;
                    //
                    textFormatter1.DrawString("Entradas", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 96 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 101 + Incrementar + Margem_Topo, 198, 24));
                    //
                    Margem_Topo = Margem_Topo + 20;
                    //
                    textFormatter2.DrawString("Total das Vendas (R$): " + Convert.ToDecimal(lblTotalVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Descontos das Vendas (R$): " + Convert.ToDecimal(lblDescontoVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Acréscimo das Vendas (R$): " + Convert.ToDecimal(lblAcrescimoVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Total das Real Vendas (R$): " + Convert.ToDecimal(lblTotalRealVendas.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 20;
                    //
                    textFormatter1.DrawString("Entradas a Prazo e Operações Neutras (*)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 96 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 101 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString("Total das Vendas Cheque (R$): " + Convert.ToDecimal(lblCheque.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 115 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    //
                    textFormatter2.DrawString("Total das Vendas Nota Promissória (R$): " + Convert.ToDecimal(lblTotalVendaNotaPromissoria.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 115 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Crédito da Loja (R$): " + Convert.ToDecimal(lblCreditoLoja.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 115 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 20;
                    //
                    textFormatter1.DrawString("Entradas à vista (+)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 115 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 121 + Incrementar + Margem_Topo, 198, 24));
                    //
                    Margem_Topo = Margem_Topo - 10;
                    //
                    textFormatter2.DrawString("Total das Vendas à Vista (R$): " + Convert.ToDecimal(lblTotalVendasVista.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 145 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Suprimentos (R$): " + Convert.ToDecimal(lblSuprimentos.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 155 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Contas a Receber (R$): " + Convert.ToDecimal(lblTotalRealContasReceber.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 165 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo - 10;
                    //
                    textFormatter1.DrawString("Saídas (-)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 195 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 201 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString("Sangrias (R$): " + Convert.ToDecimal(lblSangria.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 215 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Contas a Pagar (R$): " + Convert.ToDecimal(lblTotalRealContaPagar.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 225 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Devoluções (R$): " + Convert.ToDecimal(lblTotalDevolucoes.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 225 + Margem_Topo, 198, 7));
                    //
                    //
                    textFormatter1.DrawString("Outras Informações", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 245 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 251 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString("Qtde. de Vendas: " + lblQtdeVenda.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 265 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Qtde. de Suprimentos: " + lblQtdeSup.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 275 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Qtde. de Sangrias: " + lblQtdeSangria.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 285 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Qtde. de Devoluções: " + lblQtdeDevolucoes.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 285 + Margem_Topo, 198, 7));
                    //
                    textFormatter1.DrawString("Pagamentos", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 305 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 311 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString("Dinheiro (R$): " + Convert.ToDecimal(lblDinheiro.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 325 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(lblTotalTroco.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 335 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    //
                    textFormatter2.DrawString("Cartão de Crédito (R$): " + Convert.ToDecimal(lblCartaoCredito.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 335 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Cartão de Débito (R$): " + Convert.ToDecimal(lblCartaoDebito.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 345 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("PIX (R$): " + Convert.ToDecimal(lblPIX.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 355 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Vale Alimentação/Refeição (R$): " + Convert.ToDecimal(lblValeAlimRef.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 355 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo - 20;
                    //
                    textFormatter1.DrawString("Caixa", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 396 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 401 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString("Total de Entradas + (R$): " + Convert.ToDecimal(lblTotalEntrada.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 415 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Total de Saídas - (R$): " + Convert.ToDecimal(lblTotalSaida.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 425 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Total Entradas - Saídas (R$): " + Convert.ToDecimal(lblTotalSaldo.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 435 + Margem_Topo, 198, 7));
                    //
                    textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 451 + Margem_Topo, 198, 16));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                using (var doc = new PdfDocument())
                {
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
                    var fonte4 = new XFont("Microsoft Sans Serif", 10);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    //
                    textFormatter1.DrawString(bllMinhaEmpresa.Sel_Nome_Empresa() + "    " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 10 + Margem_Topo, 595, 13));
                    //
                    Margem_Topo = Convert.ToInt16(Margem_Topo + 17);
                    //
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 1 + Margem_Topo, 595, 24));
                    textFormatter1.DrawString("HISTÓRICO DO CAIXA", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 10 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 16 + Margem_Topo, 595, 24));
                    //
                    Margem_Topo = Margem_Topo - 14;
                    //
                    string hora1;
                    if (_Horario2 != "")
                    {
                        hora1 = "A partir de " + mtxtpData.Text + " " + mtxtHorario.Text;
                    }
                    else
                    {
                        hora1 = "A partir de " + mtxtpData.Text;
                    }
                    //
                    string hora2;
                    if (_Horario3 != "")
                    {
                        hora2 = " Até " + mtxtpData1.Text + " " + mtxtHorario1.Text;
                    }
                    else
                    {
                        hora2 = " Até " + mtxtpData1.Text;
                    }
                    //
                    textFormatter2.DrawString("Datas: " + hora1 + hora2, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 47 + Margem_Topo, 595, 7));
                    //
                    if (_PDV_Computador_Reg1 == "")
                    {
                        textFormatter2.DrawString("Nº do PDV/Caixa: Não informado.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 61 + Margem_Topo, 595, 7));
                    }
                    else
                    {
                        textFormatter2.DrawString("Nº do PDV/Caixa: " + _PDV_Computador_Reg1, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 61 + Margem_Topo, 595, 7));
                    }
                    //
                    if (_Usuario1 == "")
                    {
                        textFormatter2.DrawString("Usuário: Não informado.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 75 + Margem_Topo, 595, 7));
                    }
                    else
                    {
                        textFormatter2.DrawString("Usuário: " + _Usuario1, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 75 + Margem_Topo, 595, 7));
                    }
                    //
                    Margem_Topo = Convert.ToInt16(Margem_Topo - 38);
                    //
                    textFormatter1.DrawString("Entradas", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 138 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Margem_Topo, 595, 24));
                    //
                    Margem_Topo = Margem_Topo + 24;
                    //
                    textFormatter2.DrawString("Total das Vendas (R$): " + Convert.ToDecimal(lblTotalVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 138 + Margem_Topo, 595, 7));
                    Margem_Topo = Margem_Topo + 14;
                    //
                    textFormatter2.DrawString("Descontos das Vendas (R$): " + Convert.ToDecimal(lblDescontoVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 138 + Margem_Topo, 595, 7));
                    Margem_Topo = Margem_Topo + 14;
                    //
                    textFormatter2.DrawString("Acréscimo das Vendas (R$): " + Convert.ToDecimal(lblAcrescimoVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 138 + Margem_Topo, 595, 7));
                    Margem_Topo = Margem_Topo + 14;
                    //
                    textFormatter2.DrawString("Total Real das Vendas (R$): " + Convert.ToDecimal(lblTotalRealVendas.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 138 + Margem_Topo, 595, 7));
                    Margem_Topo = Margem_Topo + 35;
                    //
                    textFormatter1.DrawString("Entradas a Prazo e Operações Neutras (*)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 138 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString("Total das Vendas Cheque (R$): " + Convert.ToDecimal(lblCheque.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 161 + Margem_Topo, 595, 7));
                    Margem_Topo = Margem_Topo + 14;
                    //
                    textFormatter2.DrawString("Total das Vendas Nota Promissória (R$): " + Convert.ToDecimal(lblTotalVendaNotaPromissoria.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 161 + Margem_Topo, 595, 7));
                    Margem_Topo = Margem_Topo + 14;
                    //
                    textFormatter2.DrawString("Crédito da Loja (R$): " + Convert.ToDecimal(lblCreditoLoja.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 161 + Margem_Topo, 595, 7));
                    Margem_Topo = Margem_Topo + 35;
                    //
                    textFormatter1.DrawString("Entradas à vista (+)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 161 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 167 + Margem_Topo, 595, 24));
                    //
                    Margem_Topo = Margem_Topo - 20;
                    textFormatter2.DrawString("Total das Vendas à Vista (R$): " + Convert.ToDecimal(lblTotalVendasVista.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 203 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Suprimentos (R$): " + Convert.ToDecimal(lblSuprimentos.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 217 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Contas a Receber (R$): " + Convert.ToDecimal(lblTotalRealContasReceber.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 231 + Margem_Topo, 595, 7));
                    //
                    textFormatter1.DrawString("Saídas (+)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 266 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 272 + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString("Sangrias (R$): " + Convert.ToDecimal(lblSangria.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 289 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Contas a Pagar (R$): " + Convert.ToDecimal(lblTotalRealContaPagar.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 303 + Margem_Topo, 595, 7));
                    //
                    Margem_Topo = Margem_Topo + 14;
                    textFormatter2.DrawString("Devoluções (R$): " + Convert.ToDecimal(lblTotalDevolucoes.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 303 + Margem_Topo, 595, 7));
                    //
                    textFormatter1.DrawString("Outras Informações", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 338 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 344 + Margem_Topo, 595, 24));
                    //                    
                    textFormatter2.DrawString("Qtde. de Vendas: " + lblQtdeVenda.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 361 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Qtde. de Suprimentos: " + lblQtdeSup.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 375 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Qtde. de Sangrias: " + lblQtdeSangria.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 389 + Margem_Topo, 595, 7));
                    //
                    Margem_Topo = Margem_Topo + 14;
                    textFormatter2.DrawString("Qtde. de Devoluções: " + lblQtdeDevolucoes.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 389 + Margem_Topo, 595, 7));
                    //
                    textFormatter1.DrawString("Pagamentos", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 424 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 430 + Incrementar + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString("Dinheiro (R$): " + Convert.ToDecimal(lblDinheiro.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 447 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(lblTotalTroco.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 461 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Cartão de Crédito (R$): " + Convert.ToDecimal(lblCartaoCredito.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 475 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Cartão de Débito (R$): " + Convert.ToDecimal(lblCartaoDebito.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 489 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("PIX (R$): " + Convert.ToDecimal(lblPIX.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 503 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Vale Alimentação/Refeição (R$): " + Convert.ToDecimal(lblValeAlimRef.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 517 + Margem_Topo, 595, 7));
                    //
                    Margem_Topo = Margem_Topo - 14;
                    //
                    textFormatter1.DrawString("Caixa", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 566 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 572 + Incrementar + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString("Total de Entradas + (R$): " + Convert.ToDecimal(lblTotalEntrada.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 589 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Total de Saídas - (R$): " + Convert.ToDecimal(lblTotalSaida.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 603 + Margem_Topo, 595, 7));
                    //
                    textFormatter2.DrawString("Total Entradas - Saídas (R$): " + Convert.ToDecimal(lblTotalSaldo.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 617 + Margem_Topo, 595, 7));
                    //
                    textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 660 + Margem_Topo, 585, 11));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                }
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa");
                }
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.txt");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.txt"))
                {
                    writer.WriteLine(bllMinhaEmpresa.Sel_Nome_Empresa() + "    " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ());
                    writer.WriteLine("");
                    writer.WriteLine("Histórico de Caixa");
                    writer.WriteLine("");
                    //
                    string hora1;
                    if (_Horario2 != "")
                    {
                        hora1 = "A partir de " + mtxtpData.Text + " " + mtxtHorario.Text;
                    }
                    else
                    {
                        hora1 = "A partir de " + mtxtpData.Text;
                    }
                    //
                    string hora2;
                    if (_Horario3 != "")
                    {
                        hora2 = " Até " + mtxtpData1.Text + " " + mtxtHorario1.Text;
                    }
                    else
                    {
                        hora2 = " Até " + mtxtpData1.Text;
                    }
                    //
                    writer.WriteLine("Datas: " + hora1 + hora2);
                    //
                    if (_PDV_Computador_Reg1 == "")
                    {
                        writer.WriteLine("Nº do PDV/Caixa: Não informado.");
                    }
                    else
                    {
                        writer.WriteLine("Nº do PDV/Caixa: " + _PDV_Computador_Reg1);
                    }
                    //
                    if (_Usuario1 == "")
                    {
                        writer.WriteLine("Usuário: Não informado.");
                    }
                    else
                    {
                        writer.WriteLine("Usuário: " + _Usuario1);
                    }
                    //
                    writer.WriteLine("================================================================");
                    writer.WriteLine("Entradas");
                    writer.WriteLine("");
                    writer.WriteLine("Total das Vendas (R$): " + Convert.ToDecimal(lblTotalVenda.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Desconto das Vendas (R$): " + Convert.ToDecimal(lblDescontoVenda.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Acréscimo das Vendas (R$): " + Convert.ToDecimal(lblAcrescimoVenda.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Total Real das Vendas (R$): " + Convert.ToDecimal(lblTotalRealVendas.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("================================================================");
                    writer.WriteLine("Entradas a Prazo e Operações Neutras (*)");
                    writer.WriteLine("");
                    writer.WriteLine("Total das Vendas Cheque (R$): " + Convert.ToDecimal(lblCheque.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Total das Vendas Nota Promissória (R$): " + Convert.ToDecimal(lblTotalVendaNotaPromissoria.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Crédito da Loja (R$): " + Convert.ToDecimal(lblCreditoLoja.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("================================================================");
                    writer.WriteLine("Entradas à vista (+)");
                    writer.WriteLine("");
                    writer.WriteLine("Total das Vendas à Vista (R$): " + Convert.ToDecimal(lblTotalVendasVista.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Suprimentos (R$): " + Convert.ToDecimal(lblSuprimentos.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Contas a Receber (R$): " + Convert.ToDecimal(lblTotalRealContasReceber.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("================================================================");
                    writer.WriteLine("Saídas (-)");
                    writer.WriteLine("");
                    writer.WriteLine("Sangrias (R$): " + Convert.ToDecimal(lblSangria.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Contas a Pagar (R$): " + Convert.ToDecimal(lblTotalRealContaPagar.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Devoluções (R$): " + Convert.ToDecimal(lblTotalDevolucoes.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("================================================================"); ;
                    writer.WriteLine("Outras Informações");
                    writer.WriteLine("");
                    writer.WriteLine("Qtde. de Vendas: " + lblQtdeVenda.Text);
                    writer.WriteLine("Qtde. de Suprimentos: " + lblQtdeSup.Text);
                    writer.WriteLine("Qtde. de Sangrias: " + lblQtdeSangria.Text);
                    writer.WriteLine("Qtde. de Devolulões: " + lblQtdeDevolucoes.Text);
                    writer.WriteLine("================================================================");
                    writer.WriteLine("Pagamentos");
                    writer.WriteLine("");
                    writer.WriteLine("Dinheiro (R$): " + Convert.ToDecimal(lblDinheiro.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Troco (R$): " + Convert.ToDecimal(lblTotalTroco.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Cartão de Crédito (R$): " + Convert.ToDecimal(lblCartaoCredito.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Cartão de Débito (R$): " + Convert.ToDecimal(lblCartaoDebito.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("PIX (R$): " + Convert.ToDecimal(lblPIX.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Vale Alimentação/Refeição (R$): " + Convert.ToDecimal(lblValeAlimRef.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("================================================================");
                    writer.WriteLine("Caixa");
                    writer.WriteLine("");
                    writer.WriteLine("Total de Entradas + (R$): " + Convert.ToDecimal(lblTotalEntrada.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Total de Saídas - (R$): " + Convert.ToDecimal(lblTotalSaida.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("Total Entradas - Saídas (R$): " + Convert.ToDecimal(lblTotalSaldo.Text).ToString("n2", new CultureInfo("pt-BR")));
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("Sistema SEVEN");
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.txt");
            }
            else if (_Trabalho == 3)
            {
                using (var doc = new PdfDocument())
                {
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
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    //
                    textFormatter1.DrawString(bllMinhaEmpresa.Sel_Nome_Empresa(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 128, 24));
                    Margem_Topo = Margem_Topo + 16;
                    textFormatter1.DrawString(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 128, 12));
                    Margem_Topo = Margem_Topo + 12;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 1 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter1.DrawString("HISTÓRICO DE CAIXA", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 12 + Incrementar + Margem_Topo, 128, 24));
                    //
                    Margem_Topo = Margem_Topo - 14;
                    //
                    string hora1;
                    if (_Horario2 != "")
                    {
                        hora1 = "A partir de " + mtxtpData.Text + " " + mtxtHorario.Text;
                    }
                    else
                    {
                        hora1 = "A partir de " + mtxtpData.Text;
                    }
                    //
                    string hora2;
                    if (_Horario3 != "")
                    {
                        hora2 = " Até " + mtxtpData1.Text + " " + mtxtHorario1.Text;
                    }
                    else
                    {
                        hora2 = " Até " + mtxtpData1.Text;
                    }
                    //
                    textFormatter2.DrawString("Datas: " + hora1 + hora2, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 36 + Margem_Topo, 198, 7));
                    //
                    if (_PDV_Computador_Reg1 == "")
                    {
                        textFormatter2.DrawString("Nº do PDV/Caixa: Não informado.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 46 + Margem_Topo, 198, 7));
                    }
                    else
                    {
                        textFormatter2.DrawString("Nº do PDV/Caixa: " + _PDV_Computador_Reg1, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 46 + Margem_Topo, 198, 7));
                    }
                    //
                    if (_Usuario1 == "")
                    {
                        textFormatter2.DrawString("Usuário: Não informado.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                    }
                    else
                    {
                        textFormatter2.DrawString("Usuário: " + _Usuario1, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                    }
                    //
                    Margem_Topo = Margem_Topo - 25;
                    //
                    textFormatter1.DrawString("Entradas", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 96 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 101 + Incrementar + Margem_Topo, 128, 24));
                    //
                    Margem_Topo = Margem_Topo + 20;
                    //
                    textFormatter2.DrawString("Total das Vendas (R$): " + Convert.ToDecimal(lblTotalVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Descontos das Vendas (R$): " + Convert.ToDecimal(lblDescontoVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Acréscimo das Vendas (R$): " + Convert.ToDecimal(lblAcrescimoVenda.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Total das Real Vendas (R$): " + Convert.ToDecimal(lblTotalRealVendas.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 20;
                    //
                    textFormatter1.DrawString("Entradas a Prazo e Oper. Neutras (*)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 96 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 101 + Incrementar + Margem_Topo, 128, 24));
                    //
                    textFormatter2.DrawString("Total das Vendas Cheque (R$): " + Convert.ToDecimal(lblCheque.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 115 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    //
                    textFormatter2.DrawString("Total das Vendas Nota Promissória (R$): " + Convert.ToDecimal(lblTotalVendaNotaPromissoria.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 115 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Crédito da Loja (R$): " + Convert.ToDecimal(lblCreditoLoja.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 115 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 20;
                    //
                    textFormatter1.DrawString("Entradas à vista (+)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 115 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 121 + Incrementar + Margem_Topo, 128, 24));
                    //
                    Margem_Topo = Margem_Topo - 10;
                    //
                    textFormatter2.DrawString("Total das Vendas à Vista (R$): " + Convert.ToDecimal(lblTotalVendasVista.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 145 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Suprimentos (R$): " + Convert.ToDecimal(lblSuprimentos.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 155 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Contas a Receber (R$): " + Convert.ToDecimal(lblTotalRealContasReceber.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 165 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo - 10;
                    //
                    textFormatter1.DrawString("Saídas (-)", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 195 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 201 + Incrementar + Margem_Topo, 128, 24));
                    //
                    textFormatter2.DrawString("Sangrias (R$): " + Convert.ToDecimal(lblSangria.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 215 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Contas a Pagar (R$): " + Convert.ToDecimal(lblTotalRealContaPagar.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 225 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Devoluções (R$): " + Convert.ToDecimal(lblTotalDevolucoes.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 225 + Margem_Topo, 198, 7));
                    //
                    //
                    textFormatter1.DrawString("Outras Informações", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 245 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 251 + Incrementar + Margem_Topo, 128, 24));
                    //
                    textFormatter2.DrawString("Qtde. de Vendas: " + lblQtdeVenda.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 265 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Qtde. de Suprimentos: " + lblQtdeSup.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 275 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Qtde. de Sangrias: " + lblQtdeSangria.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 285 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Qtde. de Devoluções: " + lblQtdeDevolucoes.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 285 + Margem_Topo, 198, 7));
                    //
                    textFormatter1.DrawString("Pagamentos", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 305 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 311 + Incrementar + Margem_Topo, 128, 24));
                    //
                    textFormatter2.DrawString("Dinheiro (R$): " + Convert.ToDecimal(lblDinheiro.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 325 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(lblTotalTroco.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 335 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    //
                    textFormatter2.DrawString("Cartão de Crédito (R$): " + Convert.ToDecimal(lblCartaoCredito.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 335 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Cartão de Débito (R$): " + Convert.ToDecimal(lblCartaoDebito.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 345 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("PIX (R$): " + Convert.ToDecimal(lblPIX.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 355 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo + 10;
                    textFormatter2.DrawString("Vale Alimentação/Refeição (R$): " + Convert.ToDecimal(lblValeAlimRef.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 355 + Margem_Topo, 198, 7));
                    //
                    Margem_Topo = Margem_Topo - 20;
                    //
                    textFormatter1.DrawString("Caixa", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 396 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 401 + Incrementar + Margem_Topo, 128, 24));
                    //
                    textFormatter2.DrawString("Total de Entradas + (R$): " + Convert.ToDecimal(lblTotalEntrada.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 415 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Total de Saídas - (R$): " + Convert.ToDecimal(lblTotalSaida.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 425 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Total Entradas - Saídas (R$): " + Convert.ToDecimal(lblTotalSaldo.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 435 + Margem_Topo, 198, 7));
                    //
                    textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 451 + Margem_Topo, 198, 16));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                }
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
                //
                grbBox1.Enabled = true;
                lblEntrada.Enabled = true;
                lblSaida.Enabled = true;
                lblSaldo.Enabled = true;
                lblTotalEntrada.Enabled = true;
                lblTotalSaida.Enabled = true;
                lblTotalSaldo.Enabled = true;
                btnResumido.Enabled = true;
                rbtnExportarTxt.Enabled = true;
                if (_Formulario == 0)
                {
                    mtxtpData.Select();
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
                picbInterrogacao.Enabled = true;
                grbBox1.Enabled = true;
                lblEntrada.Enabled = true;
                lblSaida.Enabled = true;
                lblSaldo.Enabled = true;
                lblTotalEntrada.Enabled = true;
                lblTotalSaida.Enabled = true;
                lblTotalSaldo.Enabled = true;
                btnResumido.Enabled = true;
                rbtnExportarTxt.Enabled = true;
                //
                try
                {
                    if (_Trabalho == 0 || _Trabalho == 3)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                    else if (_Trabalho == 1)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Historico do Caixa\HistoricoCaixa.pdf");
                    }
                    //
                    bllRegistroAtividades.Salvar("GEROU UM RLEATÓRIO", "HISTÓRICO DE CAIXA", "0", _Usuario, _Cod_PDV_Computador);
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
                    grbBox1.Enabled = true;
                    lblEntrada.Enabled = true;
                    lblSaida.Enabled = true;
                    lblSaldo.Enabled = true;
                    lblTotalEntrada.Enabled = true;
                    lblTotalSaida.Enabled = true;
                    lblTotalSaldo.Enabled = true;
                    btnResumido.Enabled = true;
                    rbtnExportarTxt.Enabled = true;
                    picbInterrogacao.Enabled = true;
                    //
                    if (_Formulario == 0)
                    {
                        mtxtpData.Select();
                    }
                    else
                    {
                        cbbUsuario.Select();
                    }
                }
            }
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            //
            _Data2 = mtxtpData.Text;
            _Data3 = mtxtpData1.Text;
            //
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (mtxtHorario.Text != "")
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                _Horario2 = mtxtHorario.Text;
            }
            else
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                _Horario2 = "";
            }
            //
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (mtxtHorario1.Text != "")
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                _Horario3 = mtxtHorario.Text;
            }
            else
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                _Horario3 = "";
            }
            //
            _Usuario1 = cbbUsuario.Text;
            _PDV_Computador_Reg1 = cbbCodPDV.Text;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            lblEntrada.Enabled = false;
            lblSaida.Enabled = false;
            lblSaldo.Enabled = false;
            lblTotalEntrada.Enabled = false;
            lblTotalSaida.Enabled = false;
            lblTotalSaldo.Enabled = false;
            btnResumido.Enabled = false;
            rbtnExportarTxt.Enabled = false;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir as informações em PDF.\n\n2 - Exp. dados para (.txt): Clique para gerar em arquivo texto o relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por múltiplos filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalDevolucoes_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalDevolucoes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalCancelamentos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalCancelamentos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalDevolucoes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total das Devoluções (R$): " + lblTotalDevolucoes.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQtdeDevolucoes_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQtdeDevolucoes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQtdeDevolucoes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Qtde. de Devoluções: " + lblQtdeDevolucoes.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalVendaNotaPromissoria_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalVendaNotaPromissoria_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalVendaNotaPromissoria_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total de Vendas Nota Promissória (R$): " + lblTotalVenda.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalRealVendas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalRealVendas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalRealVendas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Real das Vendas (R$): " + lblTotalRealVendas.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValeAlimRef_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValeAlimRef_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValeAlimRef_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vale Alimentação/Refeição (R$): " + lblValeAlimRef.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label20_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
