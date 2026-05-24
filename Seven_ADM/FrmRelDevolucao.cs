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
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelDevolucao : Form
    {
        public FrmRelDevolucao(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        public FrmRelDevolucao(string usuario, string cod_pdv_computador, string data, string horario, string data1, string horario1, string pdv_computador_reg)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = 1;
            _Data = data;
            _Data1 = data1;
            _Horario = horario;
            _Horario1 = horario1;
            _PDV_Computador_Reg = pdv_computador_reg;
        }

        byte _Trabalho;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Data;
        private string _Data1;
        private string _Horario;
        private string _Horario1;
        private string _PDV_Computador_Reg;
        private byte _Formulario;

        private void FrmRelDevolucao_Load(object sender, EventArgs e)
        {
            try
            {
                bllDevolucao._FrmRelDevolucao_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDevolucao iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDevolucao iniciado.");
                }
                //
                rbtnCodigo.Checked = true;
                //
                if (_Formulario == 1)
                {
                    rbtnTodos.Checked = true;
                    rbtnCodigo.Checked = false;
                    rbtnCodVenda.Checked = false;
                    lblDatas.ForeColor = Color.Blue;
                    mtxtpData.Enabled = false;
                    mtxtpData1.Enabled = false;
                    mtxtHorario.Enabled = false;
                    mtxtHorario1.Enabled = false;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelDevolucao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelDevolucao.");
                }
            }
        }

        private void Limpar_OutrosFiltros()
        {
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            cbbUsuario.Text = null;
            cbbCodPDV.Text = null;
            cbbConsumidor.Text = null;
            cbbTipoDevolucao.Text = null;
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

        private void btnProcurar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar1_MouseLeave(object sender, EventArgs e)
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

        private void cbbConsumidor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbConsumidor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDevolucao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDevolucao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDevolucao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDevolucao_MouseLeave(object sender, EventArgs e)
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

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
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

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
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

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnProcurarVenda.Visible = false;
            Limpar_OutrosFiltros();
            btnProcurar1.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblDatas.Enabled = false;
            mtxtHorario.Enabled = false;
            mtxtHorario1.Enabled = false;
            btnSelecionarData.Enabled = false;
            lblAte.Enabled = false;
            lblUsuario.Enabled = false;
            cbbUsuario.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            lblCodPDV.Enabled = false;
            cbbCodPDV.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            btnProcurarConsumidor.Enabled = false;
            cbbConsumidor.Enabled = false;
            lblConsumidor.Enabled = false;
            lblTipo.Enabled = false;
            cbbTipoDevolucao.Enabled = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Location = new Point(735, 18);
            lblPesquisar.Location = new Point(632, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnProcurarVenda.Visible = false;
            Limpar_OutrosFiltros();
            btnProcurar1.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblDatas.Enabled = true;
            mtxtHorario.Enabled = true;
            mtxtHorario1.Enabled = true;
            btnSelecionarData.Enabled = true;
            lblAte.Enabled = true;
            lblUsuario.Enabled = true;
            cbbUsuario.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            lblCodPDV.Enabled = true;
            cbbCodPDV.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            btnProcurarConsumidor.Enabled = true;
            cbbConsumidor.Enabled = true;
            lblConsumidor.Enabled = true;
            lblTipo.Enabled = true;
            cbbTipoDevolucao.Enabled = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(680, 21);
            btnPesquisar.Select();
            //
            try
            {
                cbbConsumidor.Items.Clear();
                if (bllDevolucao.Sel_Cliente_Dev() == null)
                {
                    cbbConsumidor.Enabled = false;
                    cbbConsumidor.Text = null;
                }
                else
                {
                    cbbConsumidor.Enabled = true;
                    cbbConsumidor.Items.Add("");
                    foreach (DataRow dr in bllDevolucao.Sel_Cliente_Dev().Rows)
                    {
                        cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //  
                cbbUsuario.Items.Clear();
                if (bllDevolucao.Sel_Usuario_Dev() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllDevolucao.Sel_Usuario_Dev().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
                //
                cbbCodPDV.Items.Clear();
                if (bllDevolucao.Sel_Cod_PDV_Dev() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    cbbCodPDV.Enabled = true;
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllDevolucao.Sel_Cod_PDV_Dev().Rows)
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllDevolucao.Sel_Codigo_Dev(txtpCodigo.Text.Trim()) == null)
                        {
                            dtDevolucao.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtDevolucao.DataSource = bllDevolucao.Sel_Codigo_Dev(txtpCodigo.Text.Trim());
                            dtDevolucao.Select();
                        }
                    }
                }
                if (rbtnCodVenda.Checked == true)
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

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data da Devolução ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                        if (bllDevolucao.Sel_Devolucao_Cod_Venda(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text, cbbConsumidor.Text, cbbTipoDevolucao.Text, txtpCodigo.Text) == null)
                        {
                            dtDevolucao.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtDevolucao.DataSource = bllDevolucao.Sel_Devolucao_Cod_Venda(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text, cbbConsumidor.Text, cbbTipoDevolucao.Text, txtpCodigo.Text);
                            dtDevolucao.Select();
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

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data da Devolução ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                        if (bllDevolucao.Sel_Devolucao_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text, cbbConsumidor.Text, cbbTipoDevolucao.Text) == null)
                        {
                            dtDevolucao.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtDevolucao.DataSource = bllDevolucao.Sel_Devolucao_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text, cbbConsumidor.Text, cbbTipoDevolucao.Text);
                            dtDevolucao.Select();
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
                dtDevolucao.DataSource = null;
                rbtnCodigo.Checked = true;
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
                cbbUsuario.Select();
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

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
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
                cbbConsumidor.Select();
            }
        }

        private void cbbConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoDevolucao.Select();
            }
        }

        private void cbbTipoDevolucao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            using (FrmDatePicker2 Data = new FrmDatePicker2(11))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllDevolucao._Data_DatePicker1;
                    mtxtpData1.Text = bllDevolucao._Data_DatePicker2;
                }
            }
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            using (FrmPesqUsuario User = new FrmPesqUsuario(7, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllDevolucao.Sel_Usuario_Dev() == null)
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
                            foreach (DataRow dr in bllDevolucao.Sel_Usuario_Dev().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllDevolucao._Devolucao_PesqUsuarioTabela;
                        bllDevolucao._Devolucao_PesqUsuarioTabela = null;
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
                        bllDevolucao._Devolucao_PesqUsuarioTabela = null;
                    }
                }
            }
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            using (FrmPesqComputadorPDV Comp = new FrmPesqComputadorPDV(6))
            {
                if (Comp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCodPDV.Items.Clear();
                        if (bllDevolucao.Sel_Cod_PDV_Dev() != null)
                        {
                            cbbCodPDV.Items.Add("");
                            foreach (DataRow dr in bllDevolucao.Sel_Cod_PDV_Dev().Rows)
                            {
                                cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
                            }
                        }
                        cbbCodPDV.Text = bllDevolucao._Devolucao_PesqCompPDV_Tabela;
                        bllDevolucao._Devolucao_PesqCompPDV_Tabela = null;
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
                        bllDevolucao._Devolucao_PesqCompPDV_Tabela = null;
                    }
                }
            }
        }

        private void btnProcurarConsumidor_Click(object sender, EventArgs e)
        {
            using (FrmPesqCliente Clie = new FrmPesqCliente(3, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllDevolucao.Sel_Cliente_Dev() == null)
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
                            foreach (DataRow dr in bllDevolucao.Sel_Cliente_Dev().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbConsumidor.Text = bllDevolucao._Devolucao_Prod_PesqCliente_Tabela;
                        bllDevolucao._Devolucao_Prod_PesqCliente_Tabela = null;
                        cbbConsumidor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarConsumidor.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarConsumidor.");
                        }
                        cbbConsumidor.Text = null;
                        bllSaidasProdutos._Saidas_Prod_PesqCliente_Tabela = null;
                    }
                }
            }
        }

        private void FrmRelDevolucao_KeyUp(object sender, KeyEventArgs e)
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

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código, todos e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtDevolucao_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtDevolucao.Columns[0].HeaderText = "Código";
                dtDevolucao.Columns[1].HeaderText = "Cód. do Consumidor";
                dtDevolucao.Columns[2].HeaderText = "Nome do Consumidor";
                dtDevolucao.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
                dtDevolucao.Columns[4].HeaderText = "Data";
                dtDevolucao.Columns[5].HeaderText = "Horário";
                dtDevolucao.Columns[6].HeaderText = "Valor (R$)";
                dtDevolucao.Columns[7].HeaderText = "Valor Novo(s) Item(ns) (R$)";
                dtDevolucao.Columns[8].HeaderText = "Valor Devolvido (R$)";
                dtDevolucao.Columns[9].HeaderText = "Cód. do Usuário";
                dtDevolucao.Columns[10].HeaderText = "Nome do Usuário";
                dtDevolucao.Columns[11].HeaderText = "Cód. do PDV/Computador";
                dtDevolucao.Columns[12].HeaderText = "Cód. da Venda";
                dtDevolucao.Columns[13].HeaderText = "Tipo de Devolução";

                dtDevolucao.Columns[0].Width = 95;
                dtDevolucao.Columns[1].Width = 130;
                dtDevolucao.Columns[2].Width = 350;
                dtDevolucao.Columns[3].Width = 185;
                dtDevolucao.Columns[4].Width = 85;
                dtDevolucao.Columns[5].Width = 85;
                dtDevolucao.Columns[6].Width = 115;
                dtDevolucao.Columns[7].Width = 160;
                dtDevolucao.Columns[8].Width = 135;
                dtDevolucao.Columns[9].Width = 115;
                dtDevolucao.Columns[10].Width = 150;
                dtDevolucao.Columns[11].Width = 160;
                dtDevolucao.Columns[12].Width = 130;
                dtDevolucao.Columns[13].Width = 550;

                dtDevolucao.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDevolucao.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                dtDevolucao.DefaultCellStyle.Font = new Font(dtDevolucao.Font, FontStyle.Bold);
                //
                decimal valor_total = 0;
                for (int i = 0; i < dtDevolucao.Rows.Count; i++)
                {
                    valor_total += Convert.ToDecimal(dtDevolucao.Rows[i].Cells[6].Value);
                }
                //
                lblValorTotal.Text = Convert.ToDecimal(valor_total).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valor_devolvido = 0;
                for (int i = 0; i < dtDevolucao.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dtDevolucao.Rows[i].Cells[8].Value) > 0)
                    {
                        valor_devolvido += Convert.ToDecimal(dtDevolucao.Rows[i].Cells[8].Value);
                    }
                }
                //
                lblValorTotalDev.Text = Convert.ToDecimal(valor_devolvido).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valor_novos_itens = 0;
                for (int i = 0; i < dtDevolucao.Rows.Count; i++)
                {
                    valor_novos_itens += Convert.ToDecimal(dtDevolucao.Rows[i].Cells[7].Value);
                }
                //
                lblValorTotNovItem.Text = Convert.ToDecimal(valor_novos_itens).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblRegistros.Text = "Registros: " + dtDevolucao.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtDevolucao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtDevolucao.");
                }
                dtDevolucao.DataSource = null;
            }
        }

        private void dtDevolucao_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtDevolucao.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDevolucao.Columns[6].DefaultCellStyle.Format = "n2";
            dtDevolucao.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDevolucao.Columns[7].DefaultCellStyle.Format = "n2";
            dtDevolucao.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDevolucao.Columns[8].DefaultCellStyle.Format = "n2";

            dtDevolucao.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtDevolucao.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtDevolucao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        }

        private void dtDevolucao_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtDevolucao.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtDevolucao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtDevolucao_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtDevolucao.DataSource == null)
            {
                dtDevolucao.Enabled = false;
                grbBox2.Enabled = false;
                lblValor.Enabled = false;
                lblValorTotal.Enabled = false;
                lblTotalDev.Enabled = false;
                lblValorTotalDev.Enabled = false;
                lblValorTotNovItem.Enabled = false;
                lblNovosItens.Enabled = false;
            }
            else
            {
                dtDevolucao.Enabled = true;
                grbBox2.Enabled = true;
                lblValorTotal.Enabled = true;
                lblValor.Enabled = true;
                lblTotalDev.Enabled = true;
                lblValorTotalDev.Enabled = true;
                lblValorTotNovItem.Enabled = true;
                lblNovosItens.Enabled = true;
            }
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnRelatorioPDF_Click(object sender, EventArgs e)
        {
            using (FrmInfImpressao Imp = new FrmInfImpressao(40))
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
                    dtDevolucao.Enabled = false;
                    dtDevolucao.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = false;
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
                    if (bllDevolucao._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Devolução/Troca", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO      DATA    HORÁRIO           CONSUMIDOR                          TIPO          VALOR (R$)", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtDevolucao.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtDevolucao.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtDevolucao.Rows[linha];

                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtDevolucao.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Tipo de devolução:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(89 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Valor Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
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
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Tipo de devolução:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(89 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                 
                            }
                            //
                            if (linha == (pagina - 1) & dtDevolucao.Rows.Count > 16)
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
                                textFormatter1.DrawString("Relatório de Devolução/Troca", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Devolução/Troca", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtDevolucao.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Tipo de devolução:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(89 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Valor Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
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
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Tipo de devolução:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(89 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(470 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Cód. do Consumidor;Nome do Consumidor;CPF/CNPJ do Consumidor;Data;Horário;Valor (R$); Valor Novo(s) Item(ns) (R$);Valor Devolvido (R$);Cód. do Usuário;Nome do Usuário;Cód. do PDV/Computador;Cód. da Venda;Tipo da Devolução;Situação;Justificativa");
                    for (int linha = 0; linha < dtDevolucao.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtDevolucao.Rows[linha];
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString().Remove(10), SelectedRow.Cells[5].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[15].Value.ToString()));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Devolução/Troca");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                    Sw.WriteLine("Total (R$): " + lblValorTotal.Text);
                    Sw.WriteLine("Novos Itens (R$): " + lblValorTotNovItem.Text);
                    Sw.WriteLine("Devolvido (R$): " + lblValorTotalDev.Text);
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.csv");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.txt");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.txt"))
                {
                    writer.WriteLine("Relatório de Devolução/Troca" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtDevolucao.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtDevolucao.Rows[linha];
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
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Cód. do Consumidor: " + cod_consumidor + " |Nome do Consumidor: " + SelectedRow.Cells[2].Value.ToString() + " |CPF/CNPJ do Consumidor: " + SelectedRow.Cells[3].Value.ToString() + " |Data: " + SelectedRow.Cells[4].Value.ToString().Remove(10) + " |Horário: " + SelectedRow.Cells[5].Value.ToString() + " |Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Novo(s) Item(ns) (R$): " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Devolvido (R$): " + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " | Cód. do Usuário: " + SelectedRow.Cells[9].Value.ToString() + " |Nome do Usuário: " + SelectedRow.Cells[10].Value.ToString() + " |Cód. do PDV/Computador: " + SelectedRow.Cells[11].Value.ToString() + " |Cód. da Venda: " + SelectedRow.Cells[12].Value.ToString() + " |Tipo da Devolução: " + SelectedRow.Cells[13].Value.ToString() + " |Situação: " + SelectedRow.Cells[14].Value.ToString() + " |Justificativa: " + SelectedRow.Cells[15].Value.ToString());
                    }
                    writer.WriteLine("Total (R$): " + lblValorTotal.Text);
                    writer.WriteLine("Novos Itens (R$): " + lblValorTotNovItem.Text);
                    writer.WriteLine("Devolvido (R$): " + lblValorTotalDev.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.txt");
            }
            else if (_Trabalho == 3)
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
                    int Incrementar = 0;
                    bool PrimeiraPagina = true;
                    int registros;
                    //
                    if (bllDevolucao._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        registros = 30;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 32;
                    }
                    //
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
                        Incrementar = Incrementar + 8;
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
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 8));
                    }
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                    }
                    //
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 109 + Margem_Topo, 198, 24));     //
                    Incrementar = Incrementar - 15;
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, Incrementar + 144 + Margem_Topo, 198, 24));
                    textFormatter1.DrawString("COMPROVANTE DE DEVOLUÇÃO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString(" #   Código  Descrição   Qtde. Devolvida   UN.   Vl.Unit   Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 160 + Margem_Topo, 198, 8));
                    //
                    Incrementar = Incrementar + 1;
                    //
                    DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];
                    //

                    for (int linha = 0; linha < bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count; linha++)
                    {
                        DataRow dr = bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows[linha];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (linha == bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
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
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                DataRow drDados = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[12].Value.ToString()).Rows[0];
                                //
                                textFormatter1.DrawString("NNF nº: " + SelectedRow.Cells[12].Value.ToString() + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["hora"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 8;
                                //
                                textFormatter1.DrawString("Devolução nº: " + SelectedRow.Cells[0].Value.ToString() + "   " + SelectedRow.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRow.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRow.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                Incrementar = Incrementar - 8;
                                //
                                textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 16;
                                //
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
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
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
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
                            }
                            //
                            if (linha == registros - 5 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 4 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 3 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 2 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 1 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            if (linha == bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
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
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                DataRow drDados = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[12].Value.ToString()).Rows[0];
                                //
                                textFormatter1.DrawString("NNF nº: " + SelectedRow.Cells[12].Value.ToString() + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["hora"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 8;
                                //
                                textFormatter1.DrawString("Devolução nº: " + SelectedRow.Cells[0].Value.ToString() + "   " + SelectedRow.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRow.Cells[5].Value.ToString().ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRow.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                Incrementar = Incrementar - 8;
                                //
                                textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 16;
                                //
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));

                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 4 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 3 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 2 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                            else if (linha == registros - 1 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
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
                    if (bllDevolucao._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        Margem_Topo = Margem_Topo + 5;
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 280 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        registros = 14;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 16;
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
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 160 + Margem_Topo, 595, 24));
                    textFormatter1.DrawString("COMPROVANTE DE DEVOLUÇÃO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 169 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 175 + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString(" #       Código               Descrição                                                               Qtde.        UN.        Vl.Unit        Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 185 + Margem_Topo, 595, 13));
                    //
                    DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];
                    int Incrementar = 0;
                    for (int linha = 0; linha < bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count; linha++)
                    {
                        DataRow dr = bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows[linha];

                        if (PrimeiraPagina == true)
                        {
                            if (linha == bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 203 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 203 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 216 + Margem_Topo, 100, 13));
                                //
                                DataRow drDados = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[12].Value.ToString()).Rows[0];
                                //
                                textFormatter1.DrawString("NNF nº: " + SelectedRow.Cells[12].Value.ToString() + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["hora"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 595, 13));
                                //
                                textFormatter1.DrawString("Devolução nº: " + SelectedRow.Cells[0].Value.ToString() + "   " + SelectedRow.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRow.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 13));
                                //
                                if (SelectedRow.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 30));
                                //
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 281 + Margem_Topo, 585, 11));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (linha == registros - 5 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 4 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 3 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 2 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 1 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            if (linha == bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 43 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 43 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 56 + Margem_Topo, 100, 13));
                                //
                                DataRow drDados = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[12].Value.ToString()).Rows[0];
                                //
                                textFormatter1.DrawString("NNF nº: " + SelectedRow.Cells[12].Value.ToString() + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["hora"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 595, 13));
                                //
                                textFormatter1.DrawString("Devolução nº: " + SelectedRow.Cells[0].Value.ToString() + "   " + SelectedRow.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRow.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 13));
                                //
                                if (SelectedRow.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 30));
                                //
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 121 + Margem_Topo, 585, 11));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (linha == registros - 5 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 4 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 3 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 2 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                            else if (linha == registros - 1 & bllDevolucao.Sel_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
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
                dtDevolucao.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                btnSair.Enabled = true;
                rbtnCodigo.Checked = true;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtDevolucao.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                dtDevolucao.Select();
                //
                try
                {
                    DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];

                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Devolucao Troca\DevolucaoTroca.pdf");
                    }
                    else if (_Trabalho == 3)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 4)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
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
                    dtDevolucao.Enabled = true;
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

        private void FrmRelDevolucao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllDevolucao._FrmRelDevolucao_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDevolucao foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDevolucao foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelDevolucao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelDevolucao.");
                }
            }
        }

        private void lblValorSaldo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorSaldo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 1;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtDevolucao.Enabled = false;
            dtDevolucao.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
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
            dtDevolucao.Enabled = false;
            dtDevolucao.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao.Enabled = false;
        }

        private void btnConsultarItens_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarItens_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarItens_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 1))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtDevolucao.Select();
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
        }

        private void btnGerarCupom_Click(object sender, EventArgs e)
        {
            using (FrmInfImpressao Imp = new FrmInfImpressao(40))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllDevolucao._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 4;
                    }
                    else
                    {
                        _Trabalho = 3;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtDevolucao.Enabled = false;
                    dtDevolucao.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao.Enabled = false;
                }
            }
        }

        private void dtDevolucao_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblValorTotal.Text = null;
            lblValorTotalDev.Text = null;
            lblValorTotNovItem.Text = null;
            lblRegistros.Text = "Registros: 0";
        }

        private void btnConsultarItensInc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarItensInc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarItensInc_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 2))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtDevolucao.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItensInc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItensInc.");
                }
            }
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

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCodPDV.Select();
            }
        }

        private void btnCancelarDevolucao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelarDevolucao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelarDevolucao_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarValoresDev_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarValoresDev_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarValoresDev_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];

                if (SelectedRow.Cells[11].Value.ToString() == "DEVOLUCAO EM PRODUTOS")
                {
                    MessageBox.Show("Não existe(m) pagamento(s) para esta Devolução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDevolucao.Select();
                }
                else
                {
                    using (FrmConsultarPagamento Pag = new FrmConsultarPagamento(SelectedRow.Cells[0].Value.ToString(), 3))
                    {
                        if (Pag.ShowDialog() == DialogResult.Abort)
                        {
                            dtDevolucao.Select();
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
                DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0)
                {
                    MessageBox.Show("Não é possível excluir este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDevolucao.Select();
                }
                else if (bllDevolucao.Sel_Devolucao_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDevolucao.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Devolução?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllDevolucao.Sel_DFe_Devolucao_Ver(SelectedRow.Cells[0].Value.ToString()) == true)
                        {
                            MessageBox.Show("A Devolução selecionada está sendo utilizada por um DFe, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtDevolucao.Select();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            bllDevolucao.Excluir_Devolucao_Item_Dev_Prod(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllDevolucao.Excluir_Devolucao_Item_Devolucao(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllDevolucao.Excluir_Devolucao_Pagamento(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllDevolucao.Excluir(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "ENTRADA", "EXCLUSAO DE DEVOLUCAO DE PRODUTOS", SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UMA DEVOLUCAO", "DEVOLUCAO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Devolução excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Devolução excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
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

                                    if (bllDevolucao.Sel_Devolucao_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text, cbbConsumidor.Text, cbbTipoDevolucao.Text) == null)
                                    {
                                        dtDevolucao.DataSource = null;
                                    }
                                    else
                                    {
                                        dtDevolucao.DataSource = bllDevolucao.Sel_Devolucao_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbUsuario.Text, cbbCodPDV.Text, cbbConsumidor.Text, cbbTipoDevolucao.Text);
                                        dtDevolucao.Select();
                                    }
                                }
                            }
                            else
                            {
                                dtDevolucao.DataSource = null;
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
            }
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Total (R$): " + Convert.ToDecimal(lblValorTotal.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir o relatório em PDF.\n\n2 - Exp. dados para (.csv): Clique para gerar em arquivo excel o relatório.\n\n3 - Exp. dados para (.txt): Clique para gerar em arquivo texto o relatório.\n\n4 - Consultar Pagamentos: Clique para visualizar o(s) pagamento(s) devolvido(s) da Devolução.\n\n5 - Consultar Itens Devolvidos: Clique para visualizar o(s) item(ns) devolvido(s).\n\n6 - Consultar novos Itens Incluídos: Clique para visualizar o(s) novo(s) item(ns) incluído(s) na devolução.\n\n7 - Cupom da Devolução/Troca: Clique para imprimir o cupom do registro selecionado.\n\n8 - Cancelar Devolução: Clique para cancelar a devolução já realizada.\n\n9 - Excluir Devolução: Clique para excluir a devolução pendente já realizada.\n\n10 - Venda da Devolução: Clique para visualizar a venda que gerou a devolução selecionada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalDev_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalDev_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalDev_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Total Devolvido (R$): " + Convert.ToDecimal(lblValorTotalDev.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotNovItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Novos Itens (R$): " + Convert.ToDecimal(lblValorTotNovItem.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotNovItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotNovItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVendaOrcamento_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDevolucao.Rows[dtDevolucao.CurrentRow.Index];

                using (FrmRelVenda Venda = new FrmRelVenda(_Usuario, _Cod_PDV_Computador, SelectedRow.Cells[12].Value.ToString()))
                {
                    if (Venda.ShowDialog() == DialogResult.OK)
                    {
                        dtDevolucao.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnVendaOrcamento");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnVendaOrcamento.");
                }
            }
        }

        private void btnVendaOrcamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVendaOrcamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtHorario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void grbBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rbtnCodVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodVenda_CheckedChanged(object sender, EventArgs e)
        {
            btnProcurarVenda.Visible = true;
            Limpar_OutrosFiltros();
            btnProcurar1.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblDatas.Enabled = true;
            mtxtHorario.Enabled = true;
            mtxtHorario1.Enabled = true;
            btnSelecionarData.Enabled = true;
            lblAte.Enabled = true;
            lblUsuario.Enabled = true;
            cbbUsuario.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            lblCodPDV.Enabled = true;
            cbbCodPDV.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            btnProcurarConsumidor.Enabled = true;
            cbbConsumidor.Enabled = true;
            lblConsumidor.Enabled = true;
            lblTipo.Enabled = true;
            cbbTipoDevolucao.Enabled = true;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código da venda:";
            lblPesquisar.Location = new Point(543, 21);
            txtpCodigo.Location = new Point(703, 18);
            txtpCodigo.Select();
            //
            try
            {
                cbbConsumidor.Items.Clear();
                if (bllDevolucao.Sel_Cliente_Dev() == null)
                {
                    cbbConsumidor.Enabled = false;
                    cbbConsumidor.Text = null;
                }
                else
                {
                    cbbConsumidor.Enabled = true;
                    cbbConsumidor.Items.Add("");
                    foreach (DataRow dr in bllDevolucao.Sel_Cliente_Dev().Rows)
                    {
                        cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //  
                cbbUsuario.Items.Clear();
                if (bllDevolucao.Sel_Usuario_Dev() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllDevolucao.Sel_Usuario_Dev().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
                //
                cbbCodPDV.Items.Clear();
                if (bllDevolucao.Sel_Cod_PDV_Dev() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    cbbCodPDV.Enabled = true;
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllDevolucao.Sel_Cod_PDV_Dev().Rows)
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

        private void btnProcurarVenda_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            //
            using (FrmPesqVenda Clie = new FrmPesqVenda(2, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    try
                    {
                        txtpCodigo.Text = bllDevolucao._Devolucao_PesqVendaTabela;
                        bllDevolucao._Devolucao_PesqVendaTabela = null;
                        txtpCodigo.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarVenda.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarVenda.");
                        }
                        txtpCodigo.Text = null;
                    }
                }
            }
            //
            pEnabled.Enabled = true;
        }
    }
}
