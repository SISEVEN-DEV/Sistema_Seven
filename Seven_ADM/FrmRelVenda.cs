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
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ACBrLib.NFe;

namespace Seven_Sistema
{
    public partial class FrmRelVenda : Form
    {
        public FrmRelVenda(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        public FrmRelVenda(string usuario, string cod_pdv_computador, string codigo)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Codigo = codigo;
        }

        public FrmRelVenda(string usuario, string cod_pdv_computador, string codigo, string data, string horario, string data1, string horario1, string pdv_computador_reg)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Codigo = codigo;
            _Data = data;
            _Data1 = data1;
            _Horario = horario;
            _Horario1 = horario1;
            _PDV_Computador_Reg = pdv_computador_reg;
            _Formulario = 1;
        }

        private string _Usuario;
        private byte _Trabalho;
        private string _Cod_PDV_Computador;
        private DataTable dtResumido;
        string _Codigo;
        //
        private string _Data;
        private string _Data1;
        private string _Horario;
        private string _Horario1;
        private string _PDV_Computador_Reg;
        private byte _Formulario;

        private void FrmRelVenda_Load(object sender, EventArgs e)
        {
            try
            {
                bllVenda._FrmRelVenda_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelVenda iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelVenda iniciado.");
                }
                //
                rbtnCodigo.Checked = true;
                //
                if (_Codigo != null)
                {
                    txtpCodigo.Text = _Codigo;
                    //
                    btnPesquisar_Click(sender, e);
                }
                //
                if (_Formulario == 1)
                {
                    rbtnTodos.Checked = true;
                    rbtnCodigo.Enabled = false;
                    rbtnTodos.Enabled = false;
                    lblDataVenda.ForeColor = Color.Blue;
                    mtxtpData.Enabled = false;
                    mtxtpData1.Enabled = false;
                    lblAte.Enabled = false;
                    mtxtHorario.Enabled = false;
                    mtxtHorario1.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    cbbCodPDV.Enabled = false;
                    lblCodPDV.ForeColor = Color.Blue;
                    btnProcurarPDV.Enabled = false;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelVenda.");
                }
            }
        }

        private void Limpar_OutrosFiltros()
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            cbbUsuario.Text = null;
            cbbTipo.Text = null;
            cbbCodPDV.Text = null;
            cbbConsumidor.Text = null;
            txtCodOrcamento.Text = null;
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

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_DropDownClosed(object sender, EventArgs e)
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

        private void cbbSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
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

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValor1.Select();
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

        private void rbtnExportarTxt_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnExportarTxt_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnInformarCPF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnInformarCPF_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
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

        private void btnConsultarPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(763, 19);
            txtpCodigo.Text = null;
            Limpar_OutrosFiltros();
            lblDataVenda.Enabled = false;
            mtxtpData.Enabled = false;
            lblAte.Enabled = false;
            mtxtpData1.Enabled = false;
            btnSelecionarData.Enabled = false;
            mtxtHorario.Enabled = false;
            mtxtHorario1.Enabled = false;
            lblUsuario.Enabled = false;
            cbbUsuario.Enabled = false;
            lblTipo.Enabled = false;
            cbbTipo.Enabled = false;
            lblCodPDV.Enabled = false;
            cbbCodPDV.Enabled = false;
            lblConsumidor.Enabled = false;
            cbbConsumidor.Enabled = false;
            btnProcurarCliente.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            btnProcurarPDV.Enabled = false;
            lblOrcamento.Enabled = false;
            txtCodOrcamento.Enabled = false;
            btnPesqOrcamento.Enabled = false;
            txtCodDevolucao.Enabled = false;
            lblCodDevolucao.Enabled = false;
            txtValor1.Enabled = false;
            txtValor2.Enabled = false;
            lblValor.Enabled = false;
            lblAte1.Enabled = false;
            lblFormaPagamento.Enabled = false;
            cbbFormaPagamento.Enabled = false;
            btnProcurarPagamento.Enabled = false;
            lblCodOS.Enabled = false;
            txtCodOS.Enabled = false;
            btnPesqOS.Enabled = false;
            btnPesqDevolucao.Enabled = false;
            btnLimpar.Enabled = false;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(811, 19);
            Limpar_OutrosFiltros();
            lblDataVenda.Enabled = true;
            mtxtpData.Enabled = true;
            lblAte.Enabled = true;
            mtxtpData1.Enabled = true;
            btnSelecionarData.Enabled = true;
            mtxtHorario.Enabled = true;
            mtxtHorario1.Enabled = true;
            lblUsuario.Enabled = true;
            cbbUsuario.Enabled = true;
            lblTipo.Enabled = true;
            cbbTipo.Enabled = true;
            lblCodPDV.Enabled = true;
            cbbCodPDV.Enabled = true;
            lblConsumidor.Enabled = true;
            cbbConsumidor.Enabled = true;
            btnProcurarCliente.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            btnProcurarPDV.Enabled = true;
            lblOrcamento.Enabled = true;
            txtCodOrcamento.Enabled = true;
            btnPesqOrcamento.Enabled = true;
            txtCodDevolucao.Enabled = true;
            lblCodDevolucao.Enabled = true;
            txtValor1.Enabled = true;
            txtValor2.Enabled = true;
            lblValor.Enabled = true;
            lblAte1.Enabled = true;
            lblFormaPagamento.Enabled = true;
            cbbFormaPagamento.Enabled = true;
            btnProcurarPagamento.Enabled = true;
            lblCodOS.Enabled = true;
            txtCodOS.Enabled = true;
            btnPesqOS.Enabled = true;
            btnPesqDevolucao.Enabled = true;
            btnLimpar.Enabled = true;
            btnPesquisar.Select();
            //
            try
            {
                cbbUsuario.Items.Clear();
                if (bllVenda.Sel_Usuario_Vend() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllVenda.Sel_Usuario_Vend().Rows)
                    {
                        cbbUsuario.Items.Add(dr["id_usuario"].ToString() + "—" + dr["nome_usuario"].ToString());
                    }
                }
                //
                cbbConsumidor.Items.Clear();
                if (bllVenda.Sel_Cliente_Vend() == null)
                {
                    cbbConsumidor.Enabled = false;
                    cbbConsumidor.Text = null;
                }
                else
                {
                    cbbConsumidor.Enabled = true;
                    cbbConsumidor.Items.Add("");
                    foreach (DataRow dr in bllVenda.Sel_Cliente_Vend().Rows)
                    {
                        cbbConsumidor.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString());
                    }
                }
                //
                cbbCodPDV.Items.Clear();
                if (bllVenda.Sel_Cod_PDV_Vend() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    cbbCodPDV.Enabled = true;
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllVenda.Sel_Cod_PDV_Vend().Rows)
                    {
                        cbbCodPDV.Items.Add(dr["id_cadastro_computadores"].ToString());
                    }
                }
                //
                cbbFormaPagamento.Items.Clear();
                if (bllVenda.Sel_Forma_Pagamento_Venda() == null)
                {
                    cbbFormaPagamento.Enabled = false;
                    cbbFormaPagamento.Text = null;
                }
                else
                {
                    cbbFormaPagamento.Enabled = true;
                    cbbFormaPagamento.Items.Add("");
                    foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_Venda().Rows)
                    {
                        cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 1)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                this.Close();
            }
        }

        private void FrmRelVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 1)
                {
                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    this.Close();
                }
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

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbbUsuario.Select();
        }

        private void cbbCodPDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbConsumidor.Select();
            }
        }

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbCodPDV.Enabled == false)
                {
                    cbbConsumidor.Select();
                }
                else
                {
                    cbbCodPDV.Select();
                }
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(3))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllVenda._Data_DatePicker1;
                    mtxtpData1.Text = bllVenda._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código e todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllVenda.Sel_Venda_Codigo(txtpCodigo.Text.Trim()) == null)
                        {
                            dtVenda.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtVenda.DataSource = bllVenda.Sel_Venda_Codigo(txtpCodigo.Text.Trim());
                            dtVenda.Select();
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

                        if (bllVenda.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbTipo.Text, cbbCodPDV.Text, cbbConsumidor.Text, txtCodOrcamento.Text, txtCodDevolucao.Text, txtValor1.Text, txtValor2.Text, cbbFormaPagamento.Text, txtCodOS.Text) == null)
                        {
                            dtVenda.DataSource = null;
                            dtResumido = null;
                            MessageBox.Show("Nenhum registro foi encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtVenda.DataSource = bllVenda.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbTipo.Text, cbbCodPDV.Text, cbbConsumidor.Text, txtCodOrcamento.Text, txtCodDevolucao.Text, txtValor1.Text, txtValor2.Text, cbbFormaPagamento.Text, txtCodOS.Text);
                            dtResumido = bllVenda.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos_Resumido(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbTipo.Text, cbbCodPDV.Text, cbbConsumidor.Text, txtCodOrcamento.Text, txtCodDevolucao.Text, txtValor1.Text, txtValor2.Text, cbbFormaPagamento.Text, txtCodOS.Text);
                            dtVenda.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
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
                dtVenda.DataSource = null;
                rbtnCodigo.Checked = true;
            }
        }

        private void dtVenda_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtVenda.DataSource == null)
            {
                dtVenda.Enabled = false;
                grbBox2.Enabled = false;
                lblValorTotal.Enabled = false;
                lblValorTotalReal.Enabled = false;
                lblTotal.Enabled = false;
                lblTotalReal.Enabled = false;
                lblCancelada.Enabled = false;
                lblValorDesconto.Enabled = false;
                lblValorAcrescimo.Enabled = false;
                lblDevolvida.Enabled = false;
                dtResumido = null;
            }
            else
            {
                dtVenda.Enabled = true;
                grbBox2.Enabled = true;
                lblValorTotal.Enabled = true;
                lblValorTotalReal.Enabled = true;
                lblTotal.Enabled = true;
                lblTotalReal.Enabled = true;
                lblCancelada.Enabled = true;
                lblValorDesconto.Enabled = true;
                lblValorAcrescimo.Enabled = true;
                lblDevolvida.Enabled = true;
                //
                if (rbtnTodos.Checked == true)
                {
                    btnRelResumido.Enabled = true;
                }
                else
                {
                    btnRelResumido.Enabled = false;
                }
            }
        }

        private void dtVenda_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtVenda.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtVenda_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtVenda.Columns[0].HeaderText = "Código";
                dtVenda.Columns[1].HeaderText = "Cód. do Consumidor";
                dtVenda.Columns[2].HeaderText = "Nome do Consumidor";
                dtVenda.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
                dtVenda.Columns[4].HeaderText = "Data";
                dtVenda.Columns[5].HeaderText = "Horário";
                dtVenda.Columns[6].HeaderText = "Valor (R$)";
                dtVenda.Columns[7].HeaderText = "Desconto -(%)";
                dtVenda.Columns[8].HeaderText = "Valor do Desconto -(R$)";
                dtVenda.Columns[9].HeaderText = "Acréscimo (%)";
                dtVenda.Columns[10].HeaderText = "Valor do Acréscimo (R$)";
                dtVenda.Columns[11].HeaderText = "Valor do Desconto Item (R$)";
                dtVenda.Columns[12].HeaderText = "Valor do Acréscimo Item (R$)";
                dtVenda.Columns[13].HeaderText = "A Pagar (R$)";
                dtVenda.Columns[14].HeaderText = "Valor Total Pago (R$)";
                dtVenda.Columns[15].HeaderText = "Troco (R$)";
                dtVenda.Columns[16].HeaderText = "Tipo";
                dtVenda.Columns[17].HeaderText = "Cód. do Usuário";
                dtVenda.Columns[18].HeaderText = "Nome do Usuário";
                dtVenda.Columns[19].HeaderText = "Cód. do PDV/Computador";
                dtVenda.Columns[20].HeaderText = "Observações";
                dtVenda.Columns[21].HeaderText = "Cód. do Orçamento";
                dtVenda.Columns[22].HeaderText = "Cód. da Devolução";
                dtVenda.Columns[23].HeaderText = "Cód. da O.S.";
                dtVenda.Columns[24].HeaderText = "Pagamento Parcial";

                dtVenda.DefaultCellStyle.Font = new Font(dtVenda.Font, FontStyle.Bold);

                dtVenda.Columns[0].Width = 95;
                dtVenda.Columns[1].Width = 130;
                dtVenda.Columns[2].Width = 355;
                dtVenda.Columns[3].Width = 185;
                dtVenda.Columns[4].Width = 85;
                dtVenda.Columns[5].Width = 85;
                dtVenda.Columns[6].Width = 115;
                dtVenda.Columns[7].Width = 115;
                dtVenda.Columns[8].Width = 150;
                dtVenda.Columns[9].Width = 115;
                dtVenda.Columns[10].Width = 150;
                dtVenda.Columns[11].Width = 170;
                dtVenda.Columns[12].Width = 170;
                dtVenda.Columns[13].Width = 115;
                dtVenda.Columns[14].Width = 150;
                dtVenda.Columns[15].Width = 115;
                dtVenda.Columns[16].Width = 105;
                dtVenda.Columns[17].Width = 115;
                dtVenda.Columns[18].Width = 150;
                dtVenda.Columns[19].Width = 170;
                dtVenda.Columns[20].Width = 500;
                dtVenda.Columns[21].Width = 125;
                dtVenda.Columns[22].Width = 125;
                dtVenda.Columns[23].Width = 125;
                dtVenda.Columns[24].Width = 125;
                //
                dtVenda.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtVenda.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                lblRegistros.Text = "Registros: " + dtVenda.Rows.Count;
                //
                decimal valortotal = 0;
                for (int i = 0; i < dtVenda.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtVenda.Rows[i].Cells[6].Value);
                }
                lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valortotalreal = 0;
                for (int i = 0; i < dtVenda.Rows.Count; i++)
                {
                    valortotalreal += Convert.ToDecimal(dtVenda.Rows[i].Cells[13].Value);
                }
                lblValorTotalReal.Text = Convert.ToDecimal(valortotalreal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valordesconto = 0;
                for (int i = 0; i < dtVenda.Rows.Count; i++)
                {
                    valordesconto += Convert.ToDecimal(dtVenda.Rows[i].Cells[8].Value) + Convert.ToDecimal(dtVenda.Rows[i].Cells[11].Value);
                }
                lblValorDesconto.Text = Convert.ToDecimal(valordesconto).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valoracrescimo = 0;
                for (int i = 0; i < dtVenda.Rows.Count; i++)
                {
                    valoracrescimo += Convert.ToDecimal(dtVenda.Rows[i].Cells[10].Value) + Convert.ToDecimal(dtVenda.Rows[i].Cells[12].Value);
                }
                lblValorAcrescimo.Text = Convert.ToDecimal(valoracrescimo).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtVenda.");
                }
                dtVenda.DataSource = null;
            }
        }

        private void dtVenda_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtVenda.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[6].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[7].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[8].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[9].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[10].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[11].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[12].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[13].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[14].DefaultCellStyle.Format = "n2";
            dtVenda.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtVenda.Columns[15].DefaultCellStyle.Format = "n2";

            dtVenda.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtVenda.DefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];

            if (SelectedRow.Cells[16].Value.ToString() == "DAV")
            {
                btnTransformarNFCe.Enabled = true;
            }
            else
            {
                btnTransformarNFCe.Enabled = false;
            }
            //
            if (SelectedRow.Cells[16].Value.ToString() == "SERVICO")
            {
                btnTransformarNFSe.Enabled = true;
            }
            else
            {
                btnTransformarNFSe.Enabled = false;
            }
            //
            if (SelectedRow.Cells[16].Value.ToString() == "SERVICO" || SelectedRow.Cells[16].Value.ToString() == "NFSe")
            {
                btnEnviarWhatsapp.Enabled = false;
                btnEnviarEmail.Enabled = false;
            }
            else
            {
                btnEnviarWhatsapp.Enabled = true;
                btnEnviarEmail.Enabled = true;
            }
        }

        private void dtVenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            if (e.ColumnIndex == 21 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 22 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 23 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 24 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 24 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
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

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalReal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Total (R$): " + lblValorTotalReal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnTodasContas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTodasContas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimir_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimir_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarPagamento_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];

                if (Convert.ToDecimal(SelectedRow.Cells[14].Value) <= 0)
                {
                    MessageBox.Show("Não existe(m) pagamento(s) para esta Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtVenda.Select();
                }
                else
                {
                    using (FrmConsultarPagamento Pag = new FrmConsultarPagamento(SelectedRow.Cells[0].Value.ToString(), 2))
                    {
                        if (Pag.ShowDialog() == DialogResult.Abort)
                        {
                            dtVenda.Select();
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

        private void btnConsultarItens_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 0))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtVenda.Select();
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

        private void btnGerarCupom_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerarCupom_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTodasContas_Click(object sender, EventArgs e)
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
                    dtVenda.Enabled = false;
                    dtVenda.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
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
                dtVenda.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
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
                dtVenda.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtVenda.Select();
                //
                try
                {
                    DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];

                    if (_Trabalho == 0 || _Trabalho == 3 || _Trabalho == 7)
                    {
                        AbrirPDF.Pdf(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.pdf");
                    }
                    else if (_Trabalho == 4)
                    {
                        string mes;
                        if (Convert.ToDateTime(SelectedRow.Cells[4].Value).Month < 10)
                        {
                            mes = "0" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Month;
                        }
                        else
                        {
                            mes = Convert.ToDateTime(SelectedRow.Cells[4].Value).Month.ToString();
                        }
                        //
                        AbrirPDF.Pdf(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 5 || _Trabalho == 8)
                    {
                        string mes;
                        if (Convert.ToDateTime(SelectedRow.Cells[4].Value).Month < 10)
                        {
                            mes = "0" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Month;
                        }
                        else
                        {
                            mes = Convert.ToDateTime(SelectedRow.Cells[4].Value).Month.ToString();
                        }
                        //
                        AbrirPDF.Pdf(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
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
                    dtVenda.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnCodigo.Checked = true;
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
                    textFormatter1.DrawString("Relatório de Vendas", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO  CONSUMIDOR  DATA  USUÁRIO  TIPO  VALOR  DESCONTO  ACRÉSCIMO  PAGAMENTO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtVenda.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtVenda.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtVenda.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtVenda.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 201) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[1].Value.ToString() == "0")
                                {
                                    textFormatter2.DrawString("Consumidor: Não identificado", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10) + " " + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString() + "-" + SelectedRow.Cells[18].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(244 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                if (SelectedRow.Cells[23].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. O.S.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(339 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[22].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Dev.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[22].Value.ToString(), fonte4, XBrushes.Black, new XRect(343 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[21].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Orç.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[21].Value.ToString(), fonte4, XBrushes.Black, new XRect(343 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Valor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(34 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Desconto:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[11].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(143 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimo:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[9].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[12].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(259 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(325 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(364 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Pagamento:", fonte2, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                string tipo = "";
                                for (int x = 0; x < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; x++) 
                                {
                                    dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[x];
                                    //
                                    if (x == 0)
                                    {
                                        tipo = " " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                    else
                                    {
                                        tipo = " " + tipo + ", " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                }
                                textFormatter2.DrawString("                     " + tipo, fonte4, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 213) + Margem_Topo, 195, 23));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Descontos (R$): " + lblValorDesconto.Text, fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Acréscimos (R$): " + lblValorAcrescimo.Text, fonte2, XBrushes.Black, new XRect(275 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total a Pagar (R$): " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 201) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[1].Value.ToString() == "0")
                                {
                                    textFormatter2.DrawString("Consumidor: Não identificado", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 201) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10) + " " + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString() + "-" + SelectedRow.Cells[18].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(244 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                if (SelectedRow.Cells[23].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. O.S.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(339 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[22].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Dev.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[22].Value.ToString(), fonte4, XBrushes.Black, new XRect(345 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[21].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Orç.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[21].Value.ToString(), fonte4, XBrushes.Black, new XRect(345 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Valor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(34 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Desconto:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[11].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(143 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimo:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[9].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[12].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(259 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(325 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(364 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Pagamento:", fonte2, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 213) + Margem_Topo, page.Width, page.Height));
                                //
                                string tipo = "";
                                for (int x = 0; x < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; x++)
                                {
                                    dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[x];
                                    //
                                    if (x == 0)
                                    {
                                        tipo = " " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                    else
                                    {
                                        tipo = " " + tipo + ", " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                }
                                textFormatter2.DrawString("                     " + tipo, fonte4, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 213) + Margem_Topo, 195, 23));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                                           
                            }
                            //
                            if (linha == (pagina - 1) & dtVenda.Rows.Count > 16)
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
                                textFormatter1.DrawString("Relatório de Vendas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Vendas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtVenda.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 23) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[1].Value.ToString() == "0")
                                {
                                    textFormatter2.DrawString("Consumidor: Não identificado", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10) + " " + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString() + "-" + SelectedRow.Cells[18].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(244 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                if (SelectedRow.Cells[23].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. O.S.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(339 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[22].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Dev.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[22].Value.ToString(), fonte4, XBrushes.Black, new XRect(345 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[21].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Orç.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[21].Value.ToString(), fonte4, XBrushes.Black, new XRect(345 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Valor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(34 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Desconto:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[11].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(143 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimo:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[9].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[12].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(259 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(325 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(364 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Pagamento:", fonte2, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                string tipo = "";
                                for (int x = 0; x < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; x++)
                                {
                                    dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[x];
                                    //
                                    if (x == 0)
                                    {
                                        tipo = " " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                    else
                                    {
                                        tipo = " " + tipo + ", " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                }
                                textFormatter2.DrawString("                     " + tipo, fonte4, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 35) + Margem_Topo, 195, 23));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Descontos (R$): " + lblValorDesconto.Text, fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Acréscimos (R$): " + lblValorAcrescimo.Text, fonte2, XBrushes.Black, new XRect(275 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total a Pagar (R$): " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 23) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[1].Value.ToString() == "0")
                                {
                                    textFormatter2.DrawString("Consumidor: Não identificado", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 23) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10) + " " + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Usuário:", fonte2, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString() + "-" + SelectedRow.Cells[18].Value.ToString(), fonte4, XBrushes.Black, new XRect(156 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(244 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                if (SelectedRow.Cells[23].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. O.S.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(339 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[22].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Dev.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[22].Value.ToString(), fonte4, XBrushes.Black, new XRect(345 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[21].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Cód. Orç.:", fonte2, XBrushes.Black, new XRect(295 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[21].Value.ToString(), fonte4, XBrushes.Black, new XRect(345 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Valor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(34 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Desconto:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[11].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(143 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimo:", fonte2, XBrushes.Black, new XRect(210 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[9].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[12].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(259 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar:", fonte2, XBrushes.Black, new XRect(325 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(364 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Pagamento:", fonte2, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                string tipo = "";
                                for (int x = 0; x < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; x++)
                                {
                                    dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[x];
                                    //
                                    if (x == 0)
                                    {
                                        tipo = " " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                    else
                                    {
                                        tipo = " " + tipo + ", " + dr["tipo"].ToString() + "-" + Convert.ToDecimal(dr["valor_pago"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                }
                                textFormatter2.DrawString("                     " + tipo, fonte4, XBrushes.Black, new XRect(395 + Margem_Esq, (Incrementar + 35) + Margem_Topo, 195, 23));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas");
                }
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.txt");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.txt"))
                {
                    writer.WriteLine("Relatório de Vendas" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtVenda.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtVenda.Rows[linha];
                        string data_venda = SelectedRow.Cells[4].Value.ToString();
                        string cod_consumidor = SelectedRow.Cells[1].Value.ToString();
                        //
                        if (data_venda == "" || data_venda == null)
                        {
                            data_venda = "";
                        }
                        else
                        {
                            data_venda = data_venda.Remove(10);
                        }
                        //
                        if (cod_consumidor == "0")
                        {
                            cod_consumidor = "";
                        }
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Cód. do Consumidor: " + cod_consumidor + " |Nome do Consumidor: " + SelectedRow.Cells[2].Value.ToString() + " |CPF/CNPJ do Consumidor: " + SelectedRow.Cells[3].Value.ToString() + " |Data: " + data_venda + " |Horário: " + SelectedRow.Cells[5].Value.ToString() + " |Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Desconto (%): " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Desconto (R$): " + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Acréscimo (%): " + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Acréscimo (R$): " + Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Desconto Item (R$): " + Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")) + " | Valor do Acréscimo Item (R$): " + Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")) + " | A Pagar (R$): " + Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Total Pago (R$): " + Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Tipo: " + SelectedRow.Cells[16].Value.ToString() + " |Cód. do Usuário: " + SelectedRow.Cells[17].Value.ToString() + " |Nome do Usuário: " + SelectedRow.Cells[18].Value.ToString() + " |Cód. do PDV/Computador: " + SelectedRow.Cells[19].Value.ToString() + " |Observações: " + SelectedRow.Cells[20].Value.ToString());
                    }
                    writer.WriteLine("Total (R$): " + lblValorTotal.Text);
                    writer.WriteLine("Canceladas (R$): " + lblValorDesconto.Text);
                    writer.WriteLine("Devolvidas (R$): " + lblValorAcrescimo.Text);
                    writer.WriteLine("Realizadas (R$): " + lblValorTotalReal.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.txt");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Cód. do Consumidor;Nome do Consumidor;CPF/CNPJ do Consumidor;Data;Horário;Valor (R$);Desconto (%);Valor do Desconto (R$);Acréscimo (%);Valor do Acréscimo (R$);Valor do Desconto Item (R$);Valor do Acréscimo Item (R$);A Pagar (R$);Valor Total Pago (R$);Troco (R$);Tipo;Cód. do Usuário;Nome do Usuário;Cód. do PDV/Computador;Observações");
                    for (int linha = 0; linha < dtVenda.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtVenda.Rows[linha];
                        string data_venda = SelectedRow.Cells[4].Value.ToString();
                        string cod_consumidor = SelectedRow.Cells[1].Value.ToString();
                        //
                        if (data_venda == "" || data_venda == null)
                        {
                            data_venda = "";
                        }
                        else
                        {
                            data_venda = data_venda.Remove(10);
                        }
                        //
                        if (cod_consumidor == "0")
                        {
                            cod_consumidor = "";
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20}", SelectedRow.Cells[0].Value.ToString(), cod_consumidor, SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), data_venda, SelectedRow.Cells[5].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[16].Value.ToString(), SelectedRow.Cells[17].Value.ToString(), SelectedRow.Cells[18].Value.ToString(), SelectedRow.Cells[19].Value.ToString(), SelectedRow.Cells[20].Value.ToString()));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Vendas");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                    Sw.WriteLine("Total (R$): " + lblValorTotal.Text);
                    Sw.WriteLine("Canceladas (R$): " + lblValorDesconto.Text);
                    Sw.WriteLine("Devolvidas (R$): " + lblValorAcrescimo.Text);
                    Sw.WriteLine("Realizadas (R$): " + lblValorTotalReal.Text);
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.csv");
            }
            else if (_Trabalho == 3)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    bool PrimeiraPagina = true;
                    int pagina = 2;
                    int ContadorPagina = 1;
                    int TotalPaginas = 1;
                    int registros = 4;
                    for (int i = 0; i < dtVenda.Rows.Count; i = i + 2)
                    {
                        if (i == 2)
                        {
                            TotalPaginas = TotalPaginas + 1;
                        }
                        else if (i == registros)
                        {
                            registros = registros + 2;
                            TotalPaginas = TotalPaginas + 1;
                        }
                    }
                    //
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    var fonte5 = new XFont("Microsoft Sans Serif", 11, XFontStyle.Bold);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    DataRow dr;
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
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
                    //
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
                    textFormatter1.DrawString("Relatório de Vendas", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 125 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Página(s): 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(3 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    StringBuilder sb = new StringBuilder();
                    Margem_Topo = Convert.ToInt16(Margem_Topo - 15);
                    //
                    for (int x = 0; x < dtVenda.Rows.Count; x = x + 2)
                    {
                        DataGridViewRow SelectedRow = dtVenda.Rows[x];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (x == dtVenda.Rows.Count - 1 & PrimeiraPagina == true)
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo, 70, page.Height));
                                //Cód Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 180 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 198 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter3.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 200 + Margem_Topo, 85, page.Height));
                                }
                                //Nome do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 170 + Margem_Esq, 180 + Margem_Topo, 419, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 170 + Margem_Esq, 198 + Margem_Topo, 419, 18);
                                textFormatter2.DrawString("Nome do Consumidor:", fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(172 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                                //CPF/CNPJ do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo, 120, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo, 120, 18);
                                textFormatter2.DrawString("CPF/CNPJ do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Data
                                graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 216 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 234 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 236 + Margem_Topo, 70, page.Height));
                                //Horário
                                graphics.DrawRectangle(pen, XBrushes.White, 200 + Margem_Esq, 216 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 200 + Margem_Esq, 234 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(202 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(202 + Margem_Esq, 236 + Margem_Topo, 70, page.Height));
                                //Cód. do Usuário
                                graphics.DrawRectangle(pen, XBrushes.White, 275 + Margem_Esq, 216 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 275 + Margem_Esq, 234 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Cód. do Usuário:", fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte1, XBrushes.Black, new XRect(277 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Nome do uusário
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 216 + Margem_Topo, 239, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 234 + Margem_Topo, 239, 18);
                                textFormatter2.DrawString("Nome do Usuário:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[18].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Valor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo, 70, page.Height));
                                //Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 252 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 270 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 272 + Margem_Topo, 65, page.Height));
                                //Valor Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 150 + Margem_Esq, 252 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 150 + Margem_Esq, 270 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(152 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(152 + Margem_Esq, 272 + Margem_Topo, 100, page.Height));
                                //Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 252 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 270 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Acréscimo (%):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 272 + Margem_Topo, 65, page.Height));
                                //Valor Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 325 + Margem_Esq, 252 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 325 + Margem_Esq, 270 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Acréscimo (R$):", fonte4, XBrushes.Black, new XRect(327 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(327 + Margem_Esq, 272 + Margem_Topo, 100, page.Height));
                                //Desconto Item
                                graphics.DrawRectangle(pen, XBrushes.White, 430 + Margem_Esq, 252 + Margem_Topo, 85, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 430 + Margem_Esq, 270 + Margem_Topo, 85, 18);
                                textFormatter2.DrawString("Desc. Item (R$):", fonte4, XBrushes.Black, new XRect(432 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(432 + Margem_Esq, 272 + Margem_Topo, 80, page.Height));
                                //Acréscimo item
                                graphics.DrawRectangle(pen, XBrushes.White, 515 + Margem_Esq, 252 + Margem_Topo, 74, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 515 + Margem_Esq, 270 + Margem_Topo, 74, 18);
                                textFormatter2.DrawString("Acrésc. Item (R$):", fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(517 + Margem_Esq, 272 + Margem_Topo, 69, page.Height));
                                //Valor Real
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo, 89, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo, 89, 18);
                                textFormatter2.DrawString("A Pagar (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, 84, page.Height));
                                //Valor Total Pago
                                graphics.DrawRectangle(pen, XBrushes.White, 94 + Margem_Esq, 288 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 94 + Margem_Esq, 306 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(96 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(96 + Margem_Esq, 308 + Margem_Topo, 100, page.Height));
                                //Troco
                                graphics.DrawRectangle(pen, XBrushes.White, 199 + Margem_Esq, 288 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 199 + Margem_Esq, 306 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(201 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(201 + Margem_Esq, 308 + Margem_Topo, 90, page.Height));
                                //Tipo
                                graphics.DrawRectangle(pen, XBrushes.White, 294 + Margem_Esq, 288 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 294 + Margem_Esq, 306 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Tipo:", fonte4, XBrushes.Black, new XRect(296 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(296 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                                //Cód. do PDV
                                graphics.DrawRectangle(pen, XBrushes.White, 384 + Margem_Esq, 288 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 384 + Margem_Esq, 306 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do PDV:", fonte4, XBrushes.Black, new XRect(386 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(386 + Margem_Esq, 308 + Margem_Topo, 85, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[20].Value.ToString());
                                if (SelectedRow.Cells[20].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[20].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[20].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[20].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, 584, 36));
                            }
                            else
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo, 70, page.Height));
                                //Cód Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 180 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 198 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter3.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 200 + Margem_Topo, 85, page.Height));
                                }
                                //Nome do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 170 + Margem_Esq, 180 + Margem_Topo, 419, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 170 + Margem_Esq, 198 + Margem_Topo, 419, 18);
                                textFormatter2.DrawString("Nome do Consumidor:", fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(172 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                                //CPF/CNPJ do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo, 120, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo, 120, 18);
                                textFormatter2.DrawString("CPF/CNPJ do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Data
                                graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 216 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 234 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 236 + Margem_Topo, 70, page.Height));
                                //Horário
                                graphics.DrawRectangle(pen, XBrushes.White, 200 + Margem_Esq, 216 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 200 + Margem_Esq, 234 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(202 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(202 + Margem_Esq, 236 + Margem_Topo, 70, page.Height));
                                //Cód. do Usuário
                                graphics.DrawRectangle(pen, XBrushes.White, 275 + Margem_Esq, 216 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 275 + Margem_Esq, 234 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Cód. do Usuário:", fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte1, XBrushes.Black, new XRect(277 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Nome do uusário
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 216 + Margem_Topo, 239, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 234 + Margem_Topo, 239, 18);
                                textFormatter2.DrawString("Nome do Usuário:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[18].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Valor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo, 70, page.Height));
                                //Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 252 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 270 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 272 + Margem_Topo, 65, page.Height));
                                //Valor Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 150 + Margem_Esq, 252 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 150 + Margem_Esq, 270 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(152 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(152 + Margem_Esq, 272 + Margem_Topo, 100, page.Height));
                                //Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 252 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 270 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Acréscimo (%):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 272 + Margem_Topo, 65, page.Height));
                                //Valor Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 325 + Margem_Esq, 252 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 325 + Margem_Esq, 270 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Acréscimo (R$):", fonte4, XBrushes.Black, new XRect(327 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(327 + Margem_Esq, 272 + Margem_Topo, 100, page.Height));
                                //Desconto Item
                                graphics.DrawRectangle(pen, XBrushes.White, 430 + Margem_Esq, 252 + Margem_Topo, 85, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 430 + Margem_Esq, 270 + Margem_Topo, 85, 18);
                                textFormatter2.DrawString("Desc. Item (R$):", fonte4, XBrushes.Black, new XRect(432 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(432 + Margem_Esq, 272 + Margem_Topo, 80, page.Height));
                                //Acréscimo item
                                graphics.DrawRectangle(pen, XBrushes.White, 515 + Margem_Esq, 252 + Margem_Topo, 74, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 515 + Margem_Esq, 270 + Margem_Topo, 74, 18);
                                textFormatter2.DrawString("Acrésc. Item (R$):", fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(517 + Margem_Esq, 272 + Margem_Topo, 69, page.Height));
                                //Valor Real
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo, 89, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo, 89, 18);
                                textFormatter2.DrawString("A Pagar (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, 84, page.Height));
                                //Valor Total Pago
                                graphics.DrawRectangle(pen, XBrushes.White, 94 + Margem_Esq, 288 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 94 + Margem_Esq, 306 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(96 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(96 + Margem_Esq, 308 + Margem_Topo, 100, page.Height));
                                //Troco
                                graphics.DrawRectangle(pen, XBrushes.White, 199 + Margem_Esq, 288 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 199 + Margem_Esq, 306 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(201 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(201 + Margem_Esq, 308 + Margem_Topo, 90, page.Height));
                                //Tipo
                                graphics.DrawRectangle(pen, XBrushes.White, 294 + Margem_Esq, 288 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 294 + Margem_Esq, 306 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Tipo:", fonte4, XBrushes.Black, new XRect(296 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(296 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                                //Cód. do PDV
                                graphics.DrawRectangle(pen, XBrushes.White, 384 + Margem_Esq, 288 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 384 + Margem_Esq, 306 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do PDV:", fonte4, XBrushes.Black, new XRect(386 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(386 + Margem_Esq, 308 + Margem_Topo, 85, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[20].Value.ToString());
                                if (SelectedRow.Cells[20].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[20].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[20].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[20].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, 584, 36));
                                //
                                textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, 435 + Margem_Topo, 5, 595));
                                //Grade2
                                SelectedRow = dtVenda.Rows[x + 1];
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 502 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 520 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 504 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 522 + Margem_Topo, 70, page.Height));
                                //Cód Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 502 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 520 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 504 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter3.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 522 + Margem_Topo, 85, page.Height));
                                }
                                //Nome do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 170 + Margem_Esq, 502 + Margem_Topo, 419, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 170 + Margem_Esq, 520 + Margem_Topo, 419, 18);
                                textFormatter2.DrawString("Nome do Consumidor:", fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, 504 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(172 + Margem_Esq, 522 + Margem_Topo, page.Width, page.Height));
                                //CPF/CNPJ do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 538 + Margem_Topo, 120, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 556 + Margem_Topo, 120, 18);
                                textFormatter2.DrawString("CPF/CNPJ do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 558 + Margem_Topo, page.Width, page.Height));
                                //Data
                                graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 538 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 556 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 558 + Margem_Topo, 70, page.Height));
                                //Horário
                                graphics.DrawRectangle(pen, XBrushes.White, 200 + Margem_Esq, 538 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 200 + Margem_Esq, 556 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(202 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(202 + Margem_Esq, 558 + Margem_Topo, 70, page.Height));
                                //Cód. do Usuário
                                graphics.DrawRectangle(pen, XBrushes.White, 275 + Margem_Esq, 538 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 275 + Margem_Esq, 556 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Cód. do Usuário:", fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(277 + Margem_Esq, 558 + Margem_Topo, 70, page.Height));
                                //Nome do uusário
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 538 + Margem_Topo, 239, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 556 + Margem_Topo, 239, 18);
                                textFormatter2.DrawString("Nome do Usuário:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 558 + Margem_Topo, page.Width, page.Height));
                                //Valor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 574 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 592 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 594 + Margem_Topo, 70, page.Height));
                                //Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 574 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 592 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 594 + Margem_Topo, 65, page.Height));
                                //Valor Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 150 + Margem_Esq, 574 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 150 + Margem_Esq, 592 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(197 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(197 + Margem_Esq, 594 + Margem_Topo, 100, page.Height));
                                //Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 574 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 592 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Acréscimo (%):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 594 + Margem_Topo, 65, page.Height));
                                //Valor Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 325 + Margem_Esq, 574 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 325 + Margem_Esq, 592 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Acréscimo (R$):", fonte4, XBrushes.Black, new XRect(327 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(327 + Margem_Esq, 594 + Margem_Topo, 100, page.Height));
                                //Desconto Item
                                graphics.DrawRectangle(pen, XBrushes.White, 430 + Margem_Esq, 574 + Margem_Topo, 85, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 430 + Margem_Esq, 592 + Margem_Topo, 85, 18);
                                textFormatter2.DrawString("Desc. Item (R$):", fonte4, XBrushes.Black, new XRect(432 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(432 + Margem_Esq, 594 + Margem_Topo, 80, page.Height));
                                //Acréscimo item
                                graphics.DrawRectangle(pen, XBrushes.White, 515 + Margem_Esq, 574 + Margem_Topo, 74, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 515 + Margem_Esq, 592 + Margem_Topo, 74, 18);
                                textFormatter2.DrawString("Acrésc. Item (R$):", fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(517 + Margem_Esq, 594 + Margem_Topo, 69, page.Height));
                                //Valor Real
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 610 + Margem_Topo, 89, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 628 + Margem_Topo, 89, 18);
                                textFormatter2.DrawString("A Pagar (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 612 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 630 + Margem_Topo, 84, page.Height));
                                //Valor Total Pago
                                graphics.DrawRectangle(pen, XBrushes.White, 94 + Margem_Esq, 610 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 94 + Margem_Esq, 628 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(96 + Margem_Esq, 612 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(96 + Margem_Esq, 630 + Margem_Topo, 100, page.Height));
                                //Troco
                                graphics.DrawRectangle(pen, XBrushes.White, 199 + Margem_Esq, 610 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 199 + Margem_Esq, 628 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(201 + Margem_Esq, 612 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(201 + Margem_Esq, 630 + Margem_Topo, 90, page.Height));
                                //Tipo
                                graphics.DrawRectangle(pen, XBrushes.White, 294 + Margem_Esq, 610 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 294 + Margem_Esq, 628 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Tipo:", fonte4, XBrushes.Black, new XRect(296 + Margem_Esq, 612 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(296 + Margem_Esq, 630 + Margem_Topo, page.Width, page.Height));
                                //Cód. do PDV
                                graphics.DrawRectangle(pen, XBrushes.White, 384 + Margem_Esq, 610 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 384 + Margem_Esq, 628 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do PDV:", fonte4, XBrushes.Black, new XRect(386 + Margem_Esq, 612 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(386 + Margem_Esq, 630 + Margem_Topo, 85, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 646 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 664 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 648 + Margem_Topo, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[18].Value.ToString());
                                if (SelectedRow.Cells[18].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[18].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, 584, 36));

                                if (dtVenda.Rows.Count > 2)
                                {
                                    pagina = pagina + 2;
                                    PrimeiraPagina = false;
                                    page = doc.AddPage();//Adicionar página
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    ContadorPagina = ContadorPagina + 1;
                                    Margem_Topo = Convert.ToInt16(Margem_Topo + 15);
                                    textFormatter1.DrawString("Relatório de Vendas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Página(s): " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(3 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                }
                            }
                        }
                        else
                        {
                            Margem_Topo = Convert.ToInt16(Margem_Topo - 104);

                            if (x == dtVenda.Rows.Count - 1 & PrimeiraPagina == false)
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 165 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 183 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 167 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 185 + Margem_Topo, 70, page.Height));
                                //Cód Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 165 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 183 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 167 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter3.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 185 + Margem_Topo, 85, page.Height));
                                }
                                //Nome do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 170 + Margem_Esq, 165 + Margem_Topo, 419, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 170 + Margem_Esq, 183 + Margem_Topo, 419, 18);
                                textFormatter2.DrawString("Nome do Consumidor:", fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, 167 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(172 + Margem_Esq, 185 + Margem_Topo, page.Width, page.Height));
                                //CPF/CNPJ do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 201 + Margem_Topo, 120, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 219 + Margem_Topo, 120, 18);
                                textFormatter2.DrawString("CPF/CNPJ do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 221 + Margem_Topo, page.Width, page.Height));
                                //Data
                                graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 201 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 219 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 221 + Margem_Topo, 70, page.Height));
                                //Horário
                                graphics.DrawRectangle(pen, XBrushes.White, 200 + Margem_Esq, 201 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 200 + Margem_Esq, 219 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(202 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(202 + Margem_Esq, 221 + Margem_Topo, 70, page.Height));
                                //Cód. do Usuário
                                graphics.DrawRectangle(pen, XBrushes.White, 275 + Margem_Esq, 201 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 275 + Margem_Esq, 219 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Cód. do Usuário:", fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(277 + Margem_Esq, 221 + Margem_Topo, 70, page.Height));
                                //Nome do uusário
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 201 + Margem_Topo, 239, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 219 + Margem_Topo, 239, 18);
                                textFormatter2.DrawString("Nome do Usuário:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 221 + Margem_Topo, page.Width, page.Height));
                                //Valor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 237 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 255 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 257 + Margem_Topo, 70, page.Height));
                                //Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 237 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 255 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 257 + Margem_Topo, 65, page.Height));
                                //Valor Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 150 + Margem_Esq, 237 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 150 + Margem_Esq, 255 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(197 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(197 + Margem_Esq, 257 + Margem_Topo, 100, page.Height));
                                //Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 237 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 255 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Acréscimo (%):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 257 + Margem_Topo, 65, page.Height));
                                //Valor Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 325 + Margem_Esq, 237 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 325 + Margem_Esq, 255 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Acréscimo (R$):", fonte4, XBrushes.Black, new XRect(327 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(327 + Margem_Esq, 257 + Margem_Topo, 100, page.Height));
                                //Desconto Item
                                graphics.DrawRectangle(pen, XBrushes.White, 430 + Margem_Esq, 237 + Margem_Topo, 85, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 430 + Margem_Esq, 255 + Margem_Topo, 85, 18);
                                textFormatter2.DrawString("Desc. Item (R$):", fonte4, XBrushes.Black, new XRect(432 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(432 + Margem_Esq, 257 + Margem_Topo, 80, page.Height));
                                //Acréscimo item
                                graphics.DrawRectangle(pen, XBrushes.White, 515 + Margem_Esq, 237 + Margem_Topo, 74, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 515 + Margem_Esq, 255 + Margem_Topo, 74, 18);
                                textFormatter2.DrawString("Acrésc. Item (R$):", fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(517 + Margem_Esq, 257 + Margem_Topo, 69, page.Height));
                                //Valor Real
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 273 + Margem_Topo, 89, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 291 + Margem_Topo, 89, 18);
                                textFormatter2.DrawString("A Pagar (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 293 + Margem_Topo, 84, page.Height));
                                //Valor Total Pago
                                graphics.DrawRectangle(pen, XBrushes.White, 94 + Margem_Esq, 273 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 94 + Margem_Esq, 291 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(96 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(96 + Margem_Esq, 293 + Margem_Topo, 100, page.Height));
                                //Troco
                                graphics.DrawRectangle(pen, XBrushes.White, 199 + Margem_Esq, 273 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 199 + Margem_Esq, 291 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(201 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(201 + Margem_Esq, 293 + Margem_Topo, 90, page.Height));
                                //Tipo
                                graphics.DrawRectangle(pen, XBrushes.White, 294 + Margem_Esq, 273 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 294 + Margem_Esq, 291 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Tipo:", fonte4, XBrushes.Black, new XRect(296 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(296 + Margem_Esq, 293 + Margem_Topo, page.Width, page.Height));
                                //Cód. do PDV
                                graphics.DrawRectangle(pen, XBrushes.White, 384 + Margem_Esq, 273 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 384 + Margem_Esq, 291 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do PDV:", fonte4, XBrushes.Black, new XRect(386 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(386 + Margem_Esq, 293 + Margem_Topo, 85, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 309 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 327 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 311 + Margem_Topo, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[18].Value.ToString());
                                if (SelectedRow.Cells[18].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[18].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 329 + Margem_Topo, 584, 36));
                            }
                            else
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 165 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 183 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 167 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 185 + Margem_Topo, 70, page.Height));
                                //Cód Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 165 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 183 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 167 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter3.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 185 + Margem_Topo, 85, page.Height));
                                }
                                //Nome do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 170 + Margem_Esq, 165 + Margem_Topo, 419, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 170 + Margem_Esq, 183 + Margem_Topo, 419, 18);
                                textFormatter2.DrawString("Nome do Consumidor:", fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, 167 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(172 + Margem_Esq, 185 + Margem_Topo, page.Width, page.Height));
                                //CPF/CNPJ do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 201 + Margem_Topo, 120, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 219 + Margem_Topo, 120, 18);
                                textFormatter2.DrawString("CPF/CNPJ do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 221 + Margem_Topo, page.Width, page.Height));
                                //Data
                                graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 201 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 219 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 221 + Margem_Topo, 70, page.Height));
                                //Horário
                                graphics.DrawRectangle(pen, XBrushes.White, 200 + Margem_Esq, 201 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 200 + Margem_Esq, 219 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(202 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(202 + Margem_Esq, 221 + Margem_Topo, 70, page.Height));
                                //Cód. do Usuário
                                graphics.DrawRectangle(pen, XBrushes.White, 275 + Margem_Esq, 201 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 275 + Margem_Esq, 219 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Cód. do Usuário:", fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(277 + Margem_Esq, 221 + Margem_Topo, 70, page.Height));
                                //Nome do uusário
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 201 + Margem_Topo, 239, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 219 + Margem_Topo, 239, 18);
                                textFormatter2.DrawString("Nome do Usuário:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 203 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 221 + Margem_Topo, page.Width, page.Height));
                                //Valor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 237 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 255 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 257 + Margem_Topo, 70, page.Height));
                                //Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 237 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 255 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 257 + Margem_Topo, 65, page.Height));
                                //Valor Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 150 + Margem_Esq, 237 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 150 + Margem_Esq, 255 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(197 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(197 + Margem_Esq, 257 + Margem_Topo, 100, page.Height));
                                //Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 237 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 255 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Acréscimo (%):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 257 + Margem_Topo, 65, page.Height));
                                //Valor Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 325 + Margem_Esq, 237 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 325 + Margem_Esq, 255 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Acréscimo (R$):", fonte4, XBrushes.Black, new XRect(327 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(327 + Margem_Esq, 257 + Margem_Topo, 100, page.Height));
                                //Desconto Item
                                graphics.DrawRectangle(pen, XBrushes.White, 430 + Margem_Esq, 237 + Margem_Topo, 85, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 430 + Margem_Esq, 255 + Margem_Topo, 85, 18);
                                textFormatter2.DrawString("Desc. Item (R$):", fonte4, XBrushes.Black, new XRect(432 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(432 + Margem_Esq, 257 + Margem_Topo, 80, page.Height));
                                //Acréscimo item
                                graphics.DrawRectangle(pen, XBrushes.White, 515 + Margem_Esq, 237 + Margem_Topo, 74, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 515 + Margem_Esq, 255 + Margem_Topo, 74, 18);
                                textFormatter2.DrawString("Acrésc. Item (R$):", fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 239 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(517 + Margem_Esq, 257 + Margem_Topo, 69, page.Height));
                                //Valor Real
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 273 + Margem_Topo, 89, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 291 + Margem_Topo, 89, 18);
                                textFormatter2.DrawString("A Pagar (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 293 + Margem_Topo, 84, page.Height));
                                //Valor Total Pago
                                graphics.DrawRectangle(pen, XBrushes.White, 94 + Margem_Esq, 273 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 94 + Margem_Esq, 291 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(96 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(96 + Margem_Esq, 293 + Margem_Topo, 100, page.Height));
                                //Troco
                                graphics.DrawRectangle(pen, XBrushes.White, 199 + Margem_Esq, 273 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 199 + Margem_Esq, 291 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(201 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(201 + Margem_Esq, 293 + Margem_Topo, 90, page.Height));
                                //Tipo
                                graphics.DrawRectangle(pen, XBrushes.White, 294 + Margem_Esq, 273 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 294 + Margem_Esq, 291 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Tipo:", fonte4, XBrushes.Black, new XRect(296 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(296 + Margem_Esq, 293 + Margem_Topo, page.Width, page.Height));
                                //Cód. do PDV
                                graphics.DrawRectangle(pen, XBrushes.White, 384 + Margem_Esq, 273 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 384 + Margem_Esq, 291 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do PDV:", fonte4, XBrushes.Black, new XRect(386 + Margem_Esq, 275 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(386 + Margem_Esq, 293 + Margem_Topo, 85, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 309 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 327 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 311 + Margem_Topo, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[18].Value.ToString());
                                if (SelectedRow.Cells[18].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[18].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 329 + Margem_Topo, 584, 36));
                                //
                                textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, 465 + Margem_Topo, 5, 595));
                                Margem_Topo = Convert.ToInt16(Margem_Topo + 104);
                                //Grade2
                                SelectedRow = dtVenda.Rows[x + 1];
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 487 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 505 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 489 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 507 + Margem_Topo, 70, page.Height));
                                //Cód Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 487 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 505 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 489 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter3.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 507 + Margem_Topo, 85, page.Height));
                                }
                                //Nome do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 170 + Margem_Esq, 487 + Margem_Topo, 419, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 170 + Margem_Esq, 505 + Margem_Topo, 419, 18);
                                textFormatter2.DrawString("Nome do Consumidor:", fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, 489 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(172 + Margem_Esq, 507 + Margem_Topo, page.Width, page.Height));
                                //CPF/CNPJ do Consumidor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 523 + Margem_Topo, 120, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 541 + Margem_Topo, 120, 18);
                                textFormatter2.DrawString("CPF/CNPJ do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 525 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 543 + Margem_Topo, page.Width, page.Height));
                                //Data
                                graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 523 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 541 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Data:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 525 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 543 + Margem_Topo, 70, page.Height));
                                //Horário
                                graphics.DrawRectangle(pen, XBrushes.White, 200 + Margem_Esq, 523 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 200 + Margem_Esq, 541 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(202 + Margem_Esq, 525 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(202 + Margem_Esq, 543 + Margem_Topo, 70, page.Height));
                                //Cód. do Usuário
                                graphics.DrawRectangle(pen, XBrushes.White, 275 + Margem_Esq, 523 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 275 + Margem_Esq, 541 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Cód. do Usuário:", fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, 525 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(277 + Margem_Esq, 543 + Margem_Topo, 70, page.Height));
                                //Nome do uusário
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 523 + Margem_Topo, 239, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 541 + Margem_Topo, 239, 18);
                                textFormatter2.DrawString("Nome do Usuário:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 525 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 543 + Margem_Topo, page.Width, page.Height));
                                //Valor
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 559 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 577 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 561 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 579 + Margem_Topo, 70, page.Height));
                                //Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 559 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 577 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 561 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 579 + Margem_Topo, 65, page.Height));
                                //Valor Desconto
                                graphics.DrawRectangle(pen, XBrushes.White, 150 + Margem_Esq, 559 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 150 + Margem_Esq, 577 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(197 + Margem_Esq, 561 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(197 + Margem_Esq, 579 + Margem_Topo, 100, page.Height));
                                //Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 559 + Margem_Topo, 70, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 577 + Margem_Topo, 70, 18);
                                textFormatter2.DrawString("Acréscimo (%):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 561 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 579 + Margem_Topo, 65, page.Height));
                                //Valor Acrescimo
                                graphics.DrawRectangle(pen, XBrushes.White, 325 + Margem_Esq, 559 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 325 + Margem_Esq, 577 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor do Acréscimo (R$):", fonte4, XBrushes.Black, new XRect(327 + Margem_Esq, 561 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(327 + Margem_Esq, 579 + Margem_Topo, 100, page.Height));
                                //Desconto Item
                                graphics.DrawRectangle(pen, XBrushes.White, 430 + Margem_Esq, 559 + Margem_Topo, 85, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 430 + Margem_Esq, 577 + Margem_Topo, 85, 18);
                                textFormatter2.DrawString("Desc. Item (R$):", fonte4, XBrushes.Black, new XRect(432 + Margem_Esq, 561 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(432 + Margem_Esq, 579 + Margem_Topo, 80, page.Height));
                                //Acréscimo item
                                graphics.DrawRectangle(pen, XBrushes.White, 515 + Margem_Esq, 559 + Margem_Topo, 74, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 515 + Margem_Esq, 577 + Margem_Topo, 74, 18);
                                textFormatter2.DrawString("Acrésc. Item (R$):", fonte4, XBrushes.Black, new XRect(517 + Margem_Esq, 561 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(517 + Margem_Esq, 579 + Margem_Topo, 69, page.Height));
                                //Valor Real
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 595 + Margem_Topo, 89, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 613 + Margem_Topo, 89, 18);
                                textFormatter2.DrawString("A Pagar (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 597 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 615 + Margem_Topo, 84, page.Height));
                                //Valor Total Pago
                                graphics.DrawRectangle(pen, XBrushes.White, 94 + Margem_Esq, 595 + Margem_Topo, 105, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 94 + Margem_Esq, 613 + Margem_Topo, 105, 18);
                                textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(96 + Margem_Esq, 597 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(96 + Margem_Esq, 615 + Margem_Topo, 100, page.Height));
                                //Troco
                                graphics.DrawRectangle(pen, XBrushes.White, 199 + Margem_Esq, 595 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 199 + Margem_Esq, 613 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(201 + Margem_Esq, 597 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(201 + Margem_Esq, 615 + Margem_Topo, 90, page.Height));
                                //Tipo
                                graphics.DrawRectangle(pen, XBrushes.White, 294 + Margem_Esq, 595 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 294 + Margem_Esq, 613 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Tipo:", fonte4, XBrushes.Black, new XRect(296 + Margem_Esq, 597 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(296 + Margem_Esq, 615 + Margem_Topo, page.Width, page.Height));
                                //Cód. do PDV
                                graphics.DrawRectangle(pen, XBrushes.White, 384 + Margem_Esq, 595 + Margem_Topo, 90, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 384 + Margem_Esq, 613 + Margem_Topo, 90, 18);
                                textFormatter2.DrawString("Cód. do PDV:", fonte4, XBrushes.Black, new XRect(386 + Margem_Esq, 597 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(386 + Margem_Esq, 615 + Margem_Topo, 85, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 631 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 649 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 633 + Margem_Topo, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[18].Value.ToString());
                                if (SelectedRow.Cells[18].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[18].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[18].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 651 + Margem_Topo, 584, 36));
                                //
                                if (dtVenda.Rows.Count > pagina)
                                {
                                    pagina = pagina + 2;
                                    PrimeiraPagina = false;
                                    page = doc.AddPage();//Adicionar página
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    ContadorPagina = ContadorPagina + 1;
                                    textFormatter1.DrawString("Relatório de Vendas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Página(s): " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                }
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.pdf");
                    }
                }
            }
            else if (_Trabalho == 4)
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                bllVenda.GerarDAV(0, SelectedRow.Cells[0].Value.ToString());
            }
            else if (_Trabalho == 5)
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                bllVenda.GerarDAV(1, SelectedRow.Cells[0].Value.ToString());
            }
            else if (_Trabalho == 7)
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
                    textFormatter1.DrawString("Relatório de Vendas", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("DATA  VALOR (R$)  DESCONTOS (R$)  ACRÉSCIMOS (R$)  A PAGAR (R$)  CÓDIGO MÍN/MÁX.", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtResumido.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtResumido.Rows.Count; linha++)
                    {
                        DataRow drResumido = dtResumido.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtResumido.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(drResumido["data"].ToString(), fonte4, XBrushes.Black, new XRect(33 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(drResumido["valor"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimos (R$):", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["acrescimo_venda"]) + Convert.ToDecimal(drResumido["acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(475 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Descontos (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["desconto_venda"]) + Convert.ToDecimal(drResumido["desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(78 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["valor_real"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(288 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Código Mín/Máx.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (drResumido["codigo_min"].ToString() == drResumido["codigo_max"].ToString())
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString() + " até " + drResumido["codigo_max"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Descontos (R$): " + lblValorDesconto.Text, fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Acréscimos (R$): " + lblValorAcrescimo.Text, fonte2, XBrushes.Black, new XRect(275 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total Real (R$): " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(drResumido["data"].ToString(), fonte4, XBrushes.Black, new XRect(33 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(drResumido["valor"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimos (R$):", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["acrescimo_venda"]) + Convert.ToDecimal(drResumido["acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(475 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Descontos (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["desconto_venda"]) + Convert.ToDecimal(drResumido["desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(78 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["valor_real"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(288 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Código Mín/Máx.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (drResumido["codigo_min"].ToString() == drResumido["codigo_max"].ToString())
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString() + " até " + drResumido["codigo_max"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                //
                                Incrementar = 36 + Incrementar;//incrementando  
                            }
                            //
                            if (linha == (pagina - 1) & dtResumido.Rows.Count > 16)
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
                                textFormatter1.DrawString("Relatório de Vendas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Vendas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtResumido.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(drResumido["data"].ToString(), fonte4, XBrushes.Black, new XRect(33 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(drResumido["valor"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimos (R$):", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["acrescimo_venda"]) + Convert.ToDecimal(drResumido["acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(475 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Descontos (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["desconto_venda"]) + Convert.ToDecimal(drResumido["desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(78 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["valor_real"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(288 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Código Mín/Máx.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (drResumido["codigo_min"].ToString() == drResumido["codigo_max"].ToString())
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString() + " até " + drResumido["codigo_max"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Descontos (R$): " + lblValorDesconto.Text, fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Acréscimos (R$): " + lblValorAcrescimo.Text, fonte2, XBrushes.Black, new XRect(275 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total Real (R$): " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(drResumido["data"].ToString(), fonte4, XBrushes.Black, new XRect(33 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(drResumido["valor"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(277 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Acréscimos (R$):", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["acrescimo_venda"]) + Convert.ToDecimal(drResumido["acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(475 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Descontos (R$):", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["desconto_venda"]) + Convert.ToDecimal(drResumido["desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(78 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("A Pagar (R$):", fonte2, XBrushes.Black, new XRect(228 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(Convert.ToDecimal(drResumido["valor_real"])).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(288 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Código Mín/Máx.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (drResumido["codigo_min"].ToString() == drResumido["codigo_max"].ToString())
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(drResumido["codigo_min"].ToString() + " até " + drResumido["codigo_max"].ToString(), fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Vendas\Vendas.pdf");
                    }
                }
            }
            else if (_Trabalho == 8)
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                bllVenda.GerarDAV(2, SelectedRow.Cells[0].Value.ToString());
            }
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples do(s) registro(s).\n\n2 - Relatório Completo: Clique para imprimir um relatório completo do(s) registro(s).\n\n3 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n4 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).\n\n5 - Consultar Pagamentos: Clique para visualizar o(s) pagamento(s) da Venda.\n\n6 - Consultar Itens: Clique para visualizar o(s) item(ns) da Venda.\n\n7 - Cupom da Venda: Clique para imprimir o cupom do registro selecionado.\n\n8 - Informar CPF/CNPJ: Clique para informar o CPF/CNPJ em um registro que não possua o consumidor identificado.\n\n9 - Excluir Venda: Clique para excluir a venda já realizada.\n\n10 - Exportar Vendas: Clique para exportar os cupons das vendas para uma pasta específica.\n\n11 - Remover CPF/CNPJ: Clique para remover o CPF/CNPJ em um registro que possua o consumidor identificado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmRelVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelVenda foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelVenda foi finalizado.");
                }
                bllVenda._FrmRelVenda_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelVenda.");
                }
            }
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 1;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtVenda.Enabled = false;
            dtVenda.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
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
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtVenda.Enabled = false;
            dtVenda.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }



        private void btnGerarCupom_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                if (SelectedRow.Cells[16].Value.ToString() == "DAV")
                {
                    using (FrmInfImpressao Imp = new FrmInfImpressao(28))
                    {
                        if (Imp.ShowDialog() == DialogResult.OK)
                        {
                            pgbProgresso.Visible = true;
                            lblProgresso.Visible = true;
                            if (bllVenda._Tipo_Impressao == "PDF A4")
                            {
                                _Trabalho = 4;
                            }
                            else if (bllVenda._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                            {
                                _Trabalho = 5;
                            }
                            else if (bllVenda._Tipo_Impressao == "PDF Impressora Térmica(58mm)")
                            {
                                _Trabalho = 8;
                            }
                            bckwIndeterminado.RunWorkerAsync();
                            pgbProgresso.MarqueeAnimationSpeed = 2;
                            this.Cursor = Cursors.WaitCursor;
                            dtVenda.Enabled = false;
                            dtVenda.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                            grbBox1.Enabled = false;
                            grbBox2.Enabled = false;
                            btnPesquisar.Enabled = false;
                            picbInterrogacao1.Enabled = false;
                            picbInterrogacao3.Enabled = false;
                        }
                    }
                }
                else if (SelectedRow.Cells[16].Value.ToString() == "SERVICO")
                {
                    using (FrmInfImpressao Imp = new FrmInfImpressao(28))
                    {
                        if (Imp.ShowDialog() == DialogResult.OK)
                        {
                            pgbProgresso.Visible = true;
                            lblProgresso.Visible = true;
                            if (bllVenda._Tipo_Impressao == "PDF A4")
                            {
                                _Trabalho = 4;
                            }
                            else if (bllVenda._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                            {
                                _Trabalho = 5;
                            }
                            else if (bllVenda._Tipo_Impressao == "PDF Impressora Térmica(58mm)")
                            {
                                _Trabalho = 8;
                            }
                            bckwIndeterminado.RunWorkerAsync();
                            pgbProgresso.MarqueeAnimationSpeed = 2;
                            this.Cursor = Cursors.WaitCursor;
                            dtVenda.Enabled = false;
                            dtVenda.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                            grbBox1.Enabled = false;
                            grbBox2.Enabled = false;
                            btnPesquisar.Enabled = false;
                            picbInterrogacao1.Enabled = false;
                            picbInterrogacao3.Enabled = false;
                        }
                    }
                }
                else
                {
                    DataRow dr = bllVenda.Sel_Dfe_Venda_Cod_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (SelectedRow.Cells[16].Value.ToString() == "NFCe")
                    {
                        bllDFe.GerarDANFE(dr["id_dfe"].ToString(), _Cod_PDV_Computador, false);
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("Deseja imprimir o DANFE no modelo A4?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.No)
                        {
                            this.DialogResult = DialogResult.None;
                            bllDFe.GerarDANFE(dr["id_dfe"].ToString(), _Cod_PDV_Computador, false);
                        }
                        else if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            bllDFe.GerarDANFE(dr["id_dfe"].ToString(), _Cod_PDV_Computador, true);
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            pEnabled.Enabled = true;
                            return;
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

        private void dtVenda_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorTotal.Text = null;
            lblValorTotalReal.Text = null;
            lblValorDesconto.Text = null;
            lblValorAcrescimo.Text = null;
        }

        private void btnCancelarVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelarVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExportarVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExportarVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                {
                    MessageBox.Show("Não é possível excluir este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtResumido.Select();
                }
                else if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0)
                {
                    MessageBox.Show("Não é possível excluir este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtVenda.Select();
                }
                else if (bllVenda.Sel_Venda_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtVenda.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        if (bllVenda.Sel_Venda_DFe_Ver(SelectedRow.Cells[0].Value.ToString()) == true)
                        {
                            MessageBox.Show("A Venda selecionada está sendo utilizada por um DFe, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtVenda.Select();
                        }
                        else if (bllVenda.Sel_Venda_Devolucao_Ver(SelectedRow.Cells[0].Value.ToString()) == true)
                        {
                            MessageBox.Show("A Venda selecionada está sendo utilizada por uma Devolução, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtVenda.Select();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (SelectedRow.Cells[16].Value.ToString() != "SERVICO")
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        bllVenda.Atualizar_Saldo_Produto_Excluir_Venda(dr["id_produto"].ToString(), dr["quantidade"].ToString());
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[0].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[1].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                    //
                                    /*
                                    if (SelectedRow.Cells[16].Value.ToString() == "SERVIÇO")
                                    {
                                        bllOS.Excluir_Pagamento_OS_Item(SelectedRow.Cells[23].Value.ToString(), dr["id_item_pagamento"].ToString());
                                    }
                                    */
                                }
                            }
                            //
                            if (SelectedRow.Cells[23].Value.ToString() != "")
                            {
                                if (bllOS.Sel_OS_Codigo(SelectedRow.Cells[23].Value.ToString()) != null)
                                {
                                    DataRow dr = bllOS.Sel_OS_Codigo(SelectedRow.Cells[23].Value.ToString()).Rows[0];
                                    //
                                    if (dr["situacao"].ToString() == "PENDENTE")
                                    {
                                        if (bllOS.Sel_Formas_Pagamento_OS(SelectedRow.Cells[23].Value.ToString()) == null)
                                        {
                                            bllOS.Alterar_Pagamento_Parcial_OS(SelectedRow.Cells[23].Value.ToString(), false);
                                        }
                                    }
                                    else
                                    {
                                        if (bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[23].Value.ToString()) != null)
                                        {
                                            for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[23].Value.ToString()).Rows.Count; i++)
                                            {
                                                DataRow dr1 = bllOS.Sel_Item_Servico_Todos(SelectedRow.Cells[23].Value.ToString()).Rows[i];
                                                //
                                                if (dr1["id_orcamento"].ToString() != "0")
                                                {
                                                    bllOrcamento.Alterar_Situacao_Orcamento(dr1["id_orcamento"].ToString(), "PENDENTE");
                                                }
                                            }
                                        }
                                        //
                                        if (bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[23].Value.ToString()) != null)
                                        {
                                            for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[23].Value.ToString()).Rows.Count; i++)
                                            {
                                                DataRow dr1 = bllOS.Sel_Item_OS_Produto_Todos(SelectedRow.Cells[23].Value.ToString()).Rows[i];
                                                //
                                                bllOS.Alterar_Estoque_Produto_OS(dr1["id_produto"].ToString(), dr1["quantidade"].ToString(), true);
                                                //
                                                if (dr1["id_orcamento"].ToString() != "0")
                                                {
                                                    bllOrcamento.Alterar_Situacao_Orcamento(dr1["id_orcamento"].ToString(), "PENDENTE");
                                                }
                                            }
                                        }
                                        //
                                        bllOS.Excluir_Items_OS_Produto(SelectedRow.Cells[23].Value.ToString());
                                        bllOS.Excluir_Items_OS_Servico(SelectedRow.Cells[23].Value.ToString());
                                        bllOS.Excluir_Items_OS_Funcionario(SelectedRow.Cells[23].Value.ToString());
                                        bllOS.Excluir_Pagamento_OS(SelectedRow.Cells[23].Value.ToString());
                                        //
                                        if (bllNFSe.Sel_NFSe_Menu_NFSe("_", "_", "_", "_", null, null, null, SelectedRow.Cells[23].Value.ToString()) != null)
                                        {
                                            for (int i = 0; bllNFSe.Sel_NFSe_Menu_NFSe("_", "_", "_", "_", null, null, null, SelectedRow.Cells[23].Value.ToString()).Rows.Count > i; i++)
                                            {
                                                DataRow dr1 = bllNFSe.Sel_NFSe_Menu_NFSe("_", "_", "_", "_", null, null, null, SelectedRow.Cells[23].Value.ToString()).Rows[i];
                                                //
                                                bllOS.Excluir_Item_NFSe_OS(dr["id_nfse"].ToString());
                                            }
                                            //
                                            bllOS.Excluir_NFSe_OS(SelectedRow.Cells[23].Value.ToString());
                                        }
                                        //
                                        bllOS.Excluir(SelectedRow.Cells[23].Value.ToString());
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[0].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[0].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //   
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    //
                                    if (dr["descricao"].ToString() == "ENTRADA DE VENDA EM NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE ENTRADA DE VENDA EM NOTA PROMISSORIA", dr["valor_real"].ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                    else
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA EM NOTA PROMISSORIA", dr["valor_real"].ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[0].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                            MessageBox.Show("Os dados foram excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            if (rbtnTodos.Checked == true)
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                                if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                                {
                                    dtResumido = null;
                                    dtVenda.DataSource = null;
                                }
                                else
                                {
                                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                    if (bllVenda.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbTipo.Text, cbbCodPDV.Text, cbbConsumidor.Text, txtCodOrcamento.Text, txtCodDevolucao.Text, txtValor1.Text, txtValor2.Text, cbbFormaPagamento.Text, txtCodOS.Text) == null)
                                    {
                                        dtVenda.DataSource = null;
                                        dtResumido = null;
                                    }
                                    else
                                    {
                                        dtVenda.DataSource = bllVenda.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbTipo.Text, cbbCodPDV.Text, cbbConsumidor.Text, txtCodOrcamento.Text, txtCodDevolucao.Text, txtValor1.Text, txtValor2.Text, cbbFormaPagamento.Text, txtCodOS.Text);
                                        dtResumido = bllVenda.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos_Resumido(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbTipo.Text, cbbCodPDV.Text, cbbConsumidor.Text, txtCodOrcamento.Text, txtCodDevolucao.Text, txtValor1.Text, txtValor2.Text, cbbFormaPagamento.Text, txtCodOS.Text);
                                        dtVenda.Select();
                                    }
                                }
                            }
                            else
                            {
                                dtResumido = null;
                                dtVenda.DataSource = null;
                            }
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        dtVenda.Select();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirVenda.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnExportarVenda_Click(object sender, EventArgs e)
        {

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

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCliente Clie = new FrmPesqCliente(0, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllVenda.Sel_Cliente_Vend() == null)
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
                            foreach (DataRow dr in bllVenda.Sel_Cliente_Vend().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbConsumidor.Text = bllVenda._Cliente_PesqCliente_Tabela;
                        bllVenda._Cliente_PesqCliente_Tabela = null;
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
                        bllVenda._Cliente_PesqCliente_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodOrcamento.Select();
            }
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(5, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllVenda.Sel_Usuario_Vend() == null)
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
                            foreach (DataRow dr in bllVenda.Sel_Usuario_Vend().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllVenda._Venda_PesqUsuarioTabela;
                        bllVenda._Venda_PesqUsuarioTabela = null;
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
                        bllVenda._Venda_PesqUsuarioTabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarPDV_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqComputadorPDV Comp = new FrmPesqComputadorPDV(1))
            {
                if (Comp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        cbbCodPDV.Items.Clear();
                        if (bllVenda.Sel_Cod_PDV_Vend() == null)
                        {
                            cbbCodPDV.Text = null;
                            cbbCodPDV.Enabled = false;
                            lblCodPDV.Enabled = false;
                        }
                        else
                        {
                            cbbCodPDV.Enabled = true;
                            lblCodPDV.Enabled = true;
                            cbbCodPDV.Items.Add("");
                            foreach (DataRow dr in bllVenda.Sel_Cod_PDV_Vend().Rows)
                            {
                                cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
                            }
                        }
                        cbbCodPDV.Text = bllVenda._Hist_PesqCompPDV_Tabela;
                        bllVenda._Hist_PesqCompPDV_Tabela = null;
                        cbbCodPDV.Select();
                    }
                    catch (Exception ex)
                    {
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
                        bllVenda._Hist_PesqCompPDV_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                        _Trabalho = 7;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtVenda.Enabled = false;
                    dtVenda.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnRelResumido_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelResumido_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorCancelada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Descontos (R$): " + lblValorDesconto.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDevolvida_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acréscimos (R$): " + lblValorAcrescimo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDevolvida_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDevolvida_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCodOrcamento_Leave(object sender, EventArgs e)
        {
            if (txtCodOrcamento.Text.Contains("'") || txtCodOrcamento.Text.Contains(";") || txtCodOrcamento.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodOrcamento.Text = null;
                txtCodOrcamento.Select();
            }
            txtCodOrcamento.BackColor = Color.White;
        }

        private void txtCodOrcamento_Enter(object sender, EventArgs e)
        {
            txtCodOrcamento.BackColor = Color.LightBlue;
        }

        private void txtCodOrcamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbFormaPagamento.Select();
            }
        }

        private void btnPesqOrcamento_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqOrcamento Orc = new FrmPesqOrcamento(1, _Usuario, _Cod_PDV_Computador))
            {
                if (Orc.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    try
                    {
                        txtCodOrcamento.Text = bllVenda._Cod_Orcamento;
                        bllVenda._Cod_Orcamento = null;
                        txtCodOrcamento.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesqOrcamento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesqOrcamento.");
                        }
                        txtCodOrcamento.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnPesqOrcamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesqOrcamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCodDevolucao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtCodOS.Select();
            }
        }

        private void txtCodDevolucao_Leave(object sender, EventArgs e)
        {
            if (txtCodDevolucao.Text.Contains("'") || txtCodDevolucao.Text.Contains(";") || txtCodDevolucao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodDevolucao.Text = null;
                txtCodDevolucao.Select();
            }
            txtCodDevolucao.BackColor = Color.White;
        }

        private void txtCodDevolucao_Enter(object sender, EventArgs e)
        {
            txtCodDevolucao.BackColor = Color.LightBlue;
        }

        private void CriarDFeNFCe()
        {
            DialogResult = MessageBox.Show("Você deseja prosseguir com a transformação deste DAV em NFC-e e enviá-lo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                //
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                {
                    DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                    //
                    DataRow drProduto = bllProduto.Sel_Prod_Codigo(drItemVenda["id_produto"].ToString(), "").Rows[0];
                    //
                    if (bllIBPT.Sel_IBPT_NCM(drProduto["ncm"].ToString(), drProduto["excecao_ncm"].ToString()) == null)
                    {
                        MessageBox.Show("O NCM do Produto [ " + drItemVenda["id_produto"].ToString() + " ] não foi encontrado na tabela IBPT.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                //
                string serie;
                serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFCe();
                //
                string cliente_consumidor;
                if (SelectedRow.Cells[1].Value.ToString() == "0")
                {
                    cliente_consumidor = null;
                }
                else
                {
                    cliente_consumidor = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString();
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
                bllDFe.Salvar(null, "PRÓPRIA", "65", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, cliente_consumidor, null, SelectedRow.Cells[6].Value.ToString(), (Convert.ToDecimal(SelectedRow.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[11].Value.ToString())).ToString(), null, (Convert.ToDecimal(SelectedRow.Cells[10].Value.ToString()) + Convert.ToDecimal(SelectedRow.Cells[12].Value.ToString())).ToString(), SelectedRow.Cells[13].Value.ToString(), "VENDA DE MERCADORIA", false, _Cod_PDV_Computador, "CLIENTES", "0", "0", true, "SAIDA", true, null, "PENDENTE", null, SelectedRow.Cells[0].Value.ToString(), null, false);
                //
                string _Ult_Codigo_DFe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                //
                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                {
                    DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[i];
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
                    bllDFe.Salvar_Items(item.ToString(), drItemVenda["id_produto"].ToString() + "—" + drItemVenda["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), cfop, drItemVenda["quantidade"].ToString(), "1", drItemVenda["valor_total"].ToString(), drItemVenda["valor_unitario"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString(), drItemVenda["valor_total_a_desc_acresc"].ToString(), valor_icms, valor_base_calculo, _Ult_Codigo_DFe, valor_icms_st, "0", "0", valor_base_calculo_st, "0", drItemVenda["um"].ToString(), total_aprox_trib, "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                }
                //
                DataRow drItemDfe;
                decimal icms = 0;
                decimal icmsst = 0;
                decimal base_calculo_icms = 0;
                decimal base_calculo_icms_st = 0;
                decimal total_apx_trib = 0;
                //
                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows.Count; i++)
                {
                    drItemDfe = bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows[i];
                    //
                    icms += Convert.ToDecimal(drItemDfe["valor_icms"]);
                    icmsst += Convert.ToDecimal(drItemDfe["valor_icms_st"]);
                    base_calculo_icms += Convert.ToDecimal(drItemDfe["valor_base_calculo"]);
                    base_calculo_icms_st += Convert.ToDecimal(drItemDfe["valor_base_calculo_st"]);
                    total_apx_trib += Convert.ToDecimal(drItemDfe["total_aprox_trib"]);
                }
                //
                bllDFe.Salvar_icms_icms_st_base_total_trib(_Ult_Codigo_DFe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_apx_trib.ToString());
                //
                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                {
                    DataRow drPagamento = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                    //
                    bllDFe.Salvar_Pagamento_DFe(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString() + "—" + drPagamento["tipo"].ToString(), drPagamento["valor_pago"].ToString(), _Ult_Codigo_DFe);
                }
                //
                pgbProgresso.Visible = true;
                lblProgresso.Visible = true;
                pgbProgresso.MarqueeAnimationSpeed = 2;
                this.Cursor = Cursors.WaitCursor;
                dtVenda.Enabled = false;
                dtVenda.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                grbBox1.Enabled = false;
                grbBox2.Enabled = false;
                btnPesquisar.Enabled = false;
                picbInterrogacao1.Enabled = false;
                picbInterrogacao3.Enabled = false;
                //
                bool contingencia = false;
                //
                if (bllConfiguracaoSistema.Sel_Contingencia_NFCe() == true)
                {
                    contingencia = true;
                }
                else
                {
                    contingencia = false;
                }
                //
                if (bllDFe.Transmitir_NFCe(_Ult_Codigo_DFe, _Cod_PDV_Computador, false) == contingencia)
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(_Ult_Codigo_DFe).Rows[0];
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
                    bllDFe.Transmitir_NFCe(_Ult_Codigo_DFe, _Cod_PDV_Computador, true);
                }
                //
                bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(null, null);
                //
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtVenda.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                string codigo = SelectedRow.Cells[0].Value.ToString();
                //
                if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "65", "", "", "", "", "", "", "", SelectedRow.Cells[0].Value.ToString()) != null)
                {
                    DataRow dr = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "65", "", "", "", "", "", "", "", SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["situacao"].ToString() == "PENDENTE")
                    {
                        using (FrmMenuNFeNFCe Menu = new FrmMenuNFeNFCe(_Usuario, _Cod_PDV_Computador, 1, dr["id_dfe"].ToString()))
                        {
                            if (Menu.ShowDialog() == DialogResult.Abort)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                    }
                    else if (dr["situacao"].ToString() == "TRANSMITIDA")
                    {
                        MessageBox.Show("O DAV selecionado já possui uma NFCe que já foi transmitida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        //
                        using (FrmMenuNFeNFCe Menu = new FrmMenuNFeNFCe(_Usuario, _Cod_PDV_Computador, 1, dr["id_dfe"].ToString()))
                        {
                            if (Menu.ShowDialog() == DialogResult.Abort)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                    }
                    else
                    {
                        CriarDFeNFCe();
                    }
                }
                else
                {
                    CriarDFeNFCe();
                }
                //
                if (bllVenda.Sel_Venda_Codigo(codigo) != null)
                {
                    dtVenda.DataSource = bllVenda.Sel_Venda_Codigo(codigo);
                }
                else
                {
                    dtVenda.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnTransformarNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnTransformarNFCe.");
                }
            }
        }

        private void btnTransformarNFCe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTransformarNFCe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFormaPagamento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFormaPagamento_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFormaPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFormaPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtValor1_Leave(object sender, EventArgs e)
        {
            if (txtValor1.Text != "")
            {
                if (txtValor1.Text.Contains("'") || txtValor1.Text.Contains(";") || txtValor1.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValor1.Text = null;
                    txtValor1.Select();
                }
                else
                {
                    try
                    {
                        txtValor1.Text = Convert.ToDecimal(txtValor1.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor1.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor1.");
                        }
                        txtValor1.Text = null;
                    }
                }
            }
            txtValor1.BackColor = Color.White;
        }

        private void txtValor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor1.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValor2.Select();
            }
        }

        private void txtValor1_Enter(object sender, EventArgs e)
        {
            txtValor1.BackColor = Color.LightBlue;
        }

        private void txtValor2_Leave(object sender, EventArgs e)
        {
            if (txtValor2.Text != "")
            {
                if (txtValor2.Text.Contains("'") || txtValor2.Text.Contains(";") || txtValor2.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValor2.Text = null;
                    txtValor2.Select();
                }
                else
                {
                    try
                    {
                        txtValor2.Text = Convert.ToDecimal(txtValor2.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor2.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor2.");
                        }
                        txtValor2.Text = null;
                    }
                }
            }
            txtValor2.BackColor = Color.White;
        }

        private void txtValor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor2.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbTipo.Select();
            }
        }

        private void txtValor2_Enter(object sender, EventArgs e)
        {
            txtValor2.BackColor = Color.LightBlue;
        }

        private void cbbFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodDevolucao.Select();
            }
        }

        private void btnProcurarPagamento_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(4, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFormaPagamento.Items.Clear();
                        if (bllVenda.Sel_Forma_Pagamento_Venda() == null)
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
                            foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_Venda().Rows)
                            {
                                cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                            }
                        }
                        cbbFormaPagamento.Text = bllVenda._Pagamento_PesqPagamento_Tabela;
                        bllVenda._Pagamento_PesqPagamento_Tabela = null;
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
                        bllVenda._Pagamento_PesqPagamento_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnTransformarNFSe_Click(object sender, EventArgs e)
        {

        }

        private void btnTransformarNFSe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTransformarNFSe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarWhatsapp_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void txtCodOS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCodOS_Enter(object sender, EventArgs e)
        {
            txtCodOS.BackColor = Color.LightBlue;
        }

        private void txtCodOS_Leave(object sender, EventArgs e)
        {
            if (txtCodOS.Text.Contains("'") || txtCodOS.Text.Contains(";") || txtCodOS.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodOS.Text = null;
                txtCodOS.Select();
            }
            txtCodOS.BackColor = Color.White;
        }

        private void btnPesqDevolucao_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqOS OS = new FrmPesqOS(1, _Usuario, _Cod_PDV_Computador))
            {
                if (OS.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    try
                    {
                        txtCodOS.Text = bllVenda._Cod_OS;
                        bllVenda._Cod_OS = null;
                        txtCodOS.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesqOS.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesqOS.");
                        }
                        txtCodOS.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        



        private async void btnEnviarWhatsapp_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja enviar esta Venda por whatsapp?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                    //
                    string celular;
                    //
                    DataRow dr;
                    if (SelectedRow.Cells[1].Value.ToString() != "0")
                    {
                        dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                        //
                        if (dr["celular"].ToString() == "" || dr["celular"].ToString() == null)
                        {
                            using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 2))
                            {
                                if (Cel.ShowDialog() == DialogResult.OK)
                                {
                                    celular = bllVenda._Celular_CadCelular_Tabela;
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
                        using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 2))
                        {
                            if (Cel.ShowDialog() == DialogResult.OK)
                            {
                                celular = bllVenda._Celular_CadCelular_Tabela;
                            }
                            else
                            {
                                celular = null;
                                return;
                            }
                        }
                    }
                    //
                    celular = celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                    //
                    if (SelectedRow.Cells[16].Value.ToString() == "NFCe" || SelectedRow.Cells[16].Value.ToString() == "NFe")
                    {
                        if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", SelectedRow.Cells[0].Value.ToString()) == null)
                        {
                            MessageBox.Show("Não foi possível localizar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            dr = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        }
                        //
                        if (!File.Exists(dr["caminho_dfe"].ToString()))
                        {
                            MessageBox.Show("Não foi possível localizar o arquivo do dfe [ " + dr["id_dfe"].ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            ACBrNFe ACBrNFe;
                            if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                            {
                                ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                            }
                            else
                            {
                                ACBrNFe = new ACBrNFe();
                            }
                            //
                            string modelo = null;
                            if (dr["modelo"].ToString() == "55")
                            {
                                modelo = "NFe";
                            }
                            else if (dr["modelo"].ToString() == "65")
                            {
                                modelo = "NFCe";
                            }
                            //
                            string destino_pdf = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\" + modelo + "_" + dr["numero_nf"].ToString() + ".pdf";
                            ACBrNFe.LimparLista();
                            ACBrNFe.CarregarXML(dr["caminho_dfe"].ToString());
                            var nomeArquivo = destino_pdf;
                            //
                            for (int i = 0; i < 2; i++)
                            {
                                using (FileStream aStream = File.Create(nomeArquivo))
                                {
                                    ACBrNFe.ImprimirPDF(aStream);
                                    byte[] buffer = new Byte[aStream.Length];
                                    await aStream.ReadAsync(buffer, 0, buffer.Length);
                                    await aStream.FlushAsync();
                                    aStream.Seek(0, SeekOrigin.End);
                                    await aStream.WriteAsync(buffer, 0, buffer.Length);
                                }
                            }
                            //
                            await bllVenda.UploadPdfAsync(destino_pdf, celular);
                            //
                            bllRegistroAtividades.Salvar("ENVIO DE VENDA POR WHATSAPP", "VENDA", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    else if (SelectedRow.Cells[16].Value.ToString() == "DAV")
                    {
                        string mes;
                        if (Convert.ToDateTime(SelectedRow.Cells[4].Value).Month < 10)
                        {
                            mes = "0" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Month;
                        }
                        else
                        {
                            mes = Convert.ToDateTime(SelectedRow.Cells[4].Value).Month.ToString();
                        }

                        if (!File.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf"))
                        {
                            MessageBox.Show("Não foi possível localizar o arquivo do DAV [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            string destino_pdf = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf";
                            //
                            await bllVenda.UploadPdfAsync(destino_pdf, celular);
                            //
                            bllRegistroAtividades.Salvar("ENVIO DE VENDA POR WHATSAPP", "VENDA", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarWhatsapp.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarWhatsapp.");
                }
            }
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja enviar esta Venda por e-mail?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    DialogResult = DialogResult.None;
                    //
                    DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                    //
                    string email = "";
                    //
                    if (SelectedRow.Cells[1].Value.ToString() != "0")
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
                        MessageBox.Show("A Venda selecionada não possui nenhum Cliente/Consumidor informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        email = null;
                    }
                    //
                    string arquivo = null;
                    //
                    if (SelectedRow.Cells[16].Value.ToString() == "NFCe" || SelectedRow.Cells[16].Value.ToString() == "NFe")
                    {
                        DataRow dr;
                        if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", SelectedRow.Cells[0].Value.ToString()) == null)
                        {
                            MessageBox.Show("Não foi possível localizar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            dr = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        }
                        //
                        if (!File.Exists(dr["caminho_dfe"].ToString()))
                        {
                            MessageBox.Show("Não foi possível localizar o arquivo do dfe [ " + dr["id_dfe"].ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            arquivo = dr["caminho_dfe"].ToString();
                        }
                    }
                    else if (SelectedRow.Cells[16].Value.ToString() == "DAV")
                    {
                        string mes;
                        if (Convert.ToDateTime(SelectedRow.Cells[4].Value).Month < 10)
                        {
                            mes = "0" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Month;
                        }
                        else
                        {
                            mes = Convert.ToDateTime(SelectedRow.Cells[4].Value).Month.ToString();
                        }

                        if (!File.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf"))
                        {
                            MessageBox.Show("Não foi possível localizar o arquivo do DAV [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            arquivo = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf";
                        }
                    }
                    //
                    pEnabled.Enabled = false;
                    using (FrmUtilEnviarEmail Mail = new FrmUtilEnviarEmail(4, _Cod_PDV_Computador, _Usuario, arquivo + ";", "Segue em anexo a Venda", "Venda", email))
                    {
                        if (Mail.ShowDialog() == DialogResult.OK)
                        {
                            dtVenda.Select();
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarEmail.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarEmail.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            txtValor1.Text = null;
            txtValor2.Text = null;
            cbbTipo.Text = null;
            cbbUsuario.Text = null;
            cbbCodPDV.Text = null;
            cbbConsumidor.Text = null;
            txtCodOrcamento.Text = null;
            cbbFormaPagamento.Text = null;
            txtCodDevolucao.Text = null;
            txtCodOS.Text = null;
        }
    }
}
