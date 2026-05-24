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
using System.IO;
using System.Web;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelAniversario : Form
    {
        public FrmRelAniversario(string cod_pdv_computador, string usuario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmRelAniversario_Load(object sender, EventArgs e)
        {
            try
            {
                bllAniversariante._FrmRelAniversario_Ativo = true;
                //
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelAniversario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelAniversario iniciado.");
                }
                //
                rbtnAniversariante.Checked = true;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelAniversario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelAniversario.");
                }
            }
        }

        private void FrmRelAniversario_KeyUp(object sender, KeyEventArgs e)
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

        private void btnCriarLembrete_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCriarLembrete_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarEmail_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviarEmail_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarSMS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviarSMS_MouseLeave(object sender, EventArgs e)
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

        private void pcibInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtAniv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtAniversario.Rows.Count;
        }

        private void dtAniv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtAniv_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtAniversario.DataSource == null)
            {
                btnCriarLembrete.Enabled = false;
                btnEnviarEmail.Enabled = false;
                btnEnviarSMS.Enabled = false;
            }
            else
            {
                btnCriarLembrete.Enabled = true;
                btnEnviarEmail.Enabled = true;
                btnEnviarSMS.Enabled = true;
            }
        }

        private void dtAniv_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtAniversario.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }


        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnAniversariante_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnAniversariante_MouseLeave(object sender, EventArgs e)
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

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbEmitenteDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitenteDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbEmitenteDestinatario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitenteDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarEmitDest_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarEmitDest_MouseLeave(object sender, EventArgs e)
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

        private void rbtnAniversariante_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpData.Visible = false;
            btnSelecionarData1.Visible = false;
            btnProcurarAniversariante.Visible = true;
            mtxtpData1.Visible = false;
            lblAte1.Visible = false;
            cbbAniversariante.Visible = true;
            cbbTipoAniversariante.Visible = true;
            lblPesquisar.Text = "Localizar aniversariante em:";
            lblPesquisar.Location = new Point(219, 21);
            cbbTipoAniversariante.Text = null;
            cbbAniversariante.Text = null;
            cbbTipoAniversariante.SelectedIndex = 1;
            cbbTipoAniversariante.Select();
        }

        private void rbtnData_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpData.Visible = true;
            btnSelecionarData1.Visible = true;
            btnProcurarAniversariante.Visible = false;
            mtxtpData1.Visible = true;
            lblAte1.Visible = true;
            cbbAniversariante.Visible = false;
            cbbTipoAniversariante.Visible = false;
            lblPesquisar.Text = "Digite as datas:";
            lblPesquisar.Location = new Point(426, 21);
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpData.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpData.Visible = false;
            btnSelecionarData1.Visible = false;
            btnProcurarAniversariante.Visible = false;
            mtxtpData1.Visible = false;
            lblAte1.Visible = false;
            cbbAniversariante.Visible = false;
            cbbTipoAniversariante.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(619, 21);
            btnPesquisar.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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

        private void FrmRelAniversario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelAniversario foi finalizado.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelAniversario foi finalizado.");
                }
                bllAniversariante._FrmRelAniversario_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelAniversario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelAniversario.");
                }
            }
        }

        private void btnProcurarEmitDest_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            //
            try
            {
                if (cbbTipoAniversariante.SelectedIndex == 1)
                {
                    using (FrmPesqCliente Clie = new FrmPesqCliente(10, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbAniversariante.Items.Clear();
                            if (bllAniversariante.Sel_Cliente_Aniv() == null)
                            {
                                cbbAniversariante.Text = null;
                            }
                            else
                            {
                                cbbAniversariante.Items.Add("");
                                foreach (DataRow dr in bllAniversariante.Sel_Cliente_Aniv().Rows)
                                {
                                    cbbAniversariante.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            cbbAniversariante.Text = bllAniversariante._Aniver_PesqFornClieFunc_Tabela;
                            bllAniversariante._Aniver_PesqFornClieFunc_Tabela = null;
                            cbbAniversariante.Select();
                        }
                    }
                }
                else if (cbbTipoAniversariante.SelectedIndex == 2)
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(7, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbAniversariante.Items.Clear();
                            if (bllAniversariante.Sel_Fornecedor_Aniv() == null)
                            {
                                cbbAniversariante.Text = null;
                            }
                            else
                            {
                                cbbAniversariante.Items.Add("");
                                foreach (DataRow dr in bllAniversariante.Sel_Fornecedor_Aniv().Rows)
                                {
                                    cbbAniversariante.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            cbbAniversariante.Text = bllAniversariante._Aniver_PesqFornClieFunc_Tabela;
                            bllAniversariante._Aniver_PesqFornClieFunc_Tabela = null;
                            cbbAniversariante.Select();
                        }
                    }
                }
                else if (cbbTipoAniversariante.SelectedIndex == 3)
                {
                    using (FrmPesqFuncionario Forn = new FrmPesqFuncionario(6, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbAniversariante.Items.Clear();
                            if (bllAniversariante.Sel_Funcionario_Aniv() == null)
                            {
                                cbbAniversariante.Text = null;
                            }
                            else
                            {
                                cbbAniversariante.Items.Add("");
                                foreach (DataRow dr in bllAniversariante.Sel_Funcionario_Aniv().Rows)
                                {
                                    cbbAniversariante.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            cbbAniversariante.Text = bllAniversariante._Aniver_PesqFornClieFunc_Tabela;
                            bllAniversariante._Aniver_PesqFornClieFunc_Tabela = null;
                            cbbAniversariante.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarEmitDest.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarEmitDest.");
                }
                cbbAniversariante.Text = null;
                bllAniversariante._Aniver_PesqFornClieFunc_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {

            pEnabled.Enabled = false;
            //
            using (FrmDatePicker2 Data = new FrmDatePicker2(24))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllAniversariante._Data_DatePicker1;
                    mtxtpData1.Text = bllAniversariante._Data_DatePicker2;
                }
            }
            //
            pEnabled.Enabled = true;
        }

        private void cbbTipoAniversariante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbAniversariante.Items.Clear();
                if (cbbTipoAniversariante.SelectedIndex == 0)
                {
                    cbbAniversariante.Text = null;
                    btnProcurarAniversariante.Enabled = false;
                }
                else if (cbbTipoAniversariante.SelectedIndex == 1)
                {
                    if (bllAniversariante.Sel_Cliente_Aniv() == null)
                    {
                        cbbAniversariante.Text = null;
                        btnProcurarAniversariante.Enabled = false;
                    }
                    else
                    {
                        btnProcurarAniversariante.Enabled = true;
                        cbbAniversariante.Items.Add("");
                        foreach (DataRow dr in bllAniversariante.Sel_Cliente_Aniv().Rows)
                        {
                            cbbAniversariante.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbTipoAniversariante.SelectedIndex == 2)
                {
                    if (bllAniversariante.Sel_Fornecedor_Aniv() == null)
                    {
                        cbbAniversariante.Text = null;
                        btnProcurarAniversariante.Enabled = false;
                    }
                    else
                    {
                        btnProcurarAniversariante.Enabled = true;
                        cbbAniversariante.Items.Add("");
                        foreach (DataRow dr in bllAniversariante.Sel_Fornecedor_Aniv().Rows)
                        {
                            cbbAniversariante.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbTipoAniversariante.SelectedIndex == 3)
                {
                    if (bllAniversariante.Sel_Funcionario_Aniv() == null)
                    {
                        cbbAniversariante.Text = null;
                        btnProcurarAniversariante.Enabled = false;
                    }
                    else
                    {
                        btnProcurarAniversariante.Enabled = true;
                        cbbAniversariante.Items.Add("");
                        foreach (DataRow dr in bllAniversariante.Sel_Funcionario_Aniv().Rows)
                        {
                            cbbAniversariante.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoAniversariante.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoAniversariante.");
                }
                cbbAniversariante.Items.Clear();
                cbbAniversariante.Text = null;
                cbbTipoAniversariante.Text = null;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnAniversariante.Checked == true)
                {
                    if (cbbTipoAniversariante.Text != "" & cbbAniversariante.Text != "")
                    {
                        if (bllAniversariante.Sel_Aniversariante_Aniv(cbbAniversariante.Text, cbbTipoAniversariante.Text) == null)
                        {
                            dtAniversario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtAniversario.DataSource = bllAniversariante.Sel_Aniversariante_Aniv(cbbAniversariante.Text, cbbTipoAniversariante.Text);
                            dtAniversario.Select();
                        }
                    }
                    else if (cbbAniversariante.Text == "" & cbbTipoAniversariante.Text != "")
                    {
                        if (bllAniversariante.Sel_Aniversariante_Tipo_Aniv(cbbTipoAniversariante.Text) == null)
                        {
                            dtAniversario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtAniversario.DataSource = bllAniversariante.Sel_Aniversariante_Tipo_Aniv(cbbTipoAniversariante.Text);
                            dtAniversario.Select();
                        }
                    }
                }
                else if (rbtnData.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllAniversariante.Sel_Aniversario_Data(mtxtpData.Text, mtxtpData1.Text) == null)
                        {
                            dtAniversario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtAniversario.DataSource = bllAniversariante.Sel_Aniversario_Data(mtxtpData.Text, mtxtpData1.Text);
                            dtAniversario.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllAniversariante.Sel_Aniversario_Todos() == null)
                    {
                        dtAniversario.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtAniversario.DataSource = bllAniversariante.Sel_Aniversario_Todos();
                        dtAniversario.Select();
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
                dtAniversario.DataSource = null;
                rbtnAniversariante.Checked = true;
            }
        }

        private void dtAniversario_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtAniversario.Columns[0].HeaderText = "Código";
            dtAniversario.Columns[1].HeaderText = "Nome do Aniversáriante";
            dtAniversario.Columns[2].HeaderText = "CPF/CNPJ";
            dtAniversario.Columns[3].HeaderText = "Data de Aniversário";
            dtAniversario.Columns[4].HeaderText = "Tipo de Aniversariante";
            dtAniversario.Columns[5].HeaderText = "Celular";
            dtAniversario.Columns[6].HeaderText = "E-mail";
            //
            dtAniversario.Columns[0].Width = 85;
            dtAniversario.Columns[1].Width = 325;
            dtAniversario.Columns[2].Width = 175;
            dtAniversario.Columns[3].Width = 135;
            dtAniversario.Columns[4].Width = 155;
            dtAniversario.Columns[5].Width = 125;
            dtAniversario.Columns[6].Width = 225;
            //
            dtAniversario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAniversario.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtAniversario.DefaultCellStyle.Font = new Font(dtAniversario.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtAniversario.Rows.Count;
        }

        private void dtAniversario_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtAniversario.DataSource == null)
            {
                dtAniversario.Enabled = false;
                grbBox2.Enabled = false;
            }
            else
            {
                dtAniversario.Enabled = true;
                grbBox2.Enabled = true;
            }
        }

        private void dtAniversario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtAniversario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtAniversario.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnCriarLembrete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtAniversario.Rows[dtAniversario.CurrentRow.Index];

                string cpf_cnpj = null;
                if (SelectedRow.Cells[2].Value.ToString() != "")
                {
                    cpf_cnpj = "  E CPF / CNPJ: " + SelectedRow.Cells[2].Value.ToString();
                }
                //
                pEnabled.Enabled = false;
                using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, SelectedRow.Cells[3].Value.ToString(), null, "LEMBRETE DE ANIVERSARIANTE", "LEMBRETE DE ANIVERSARIO DO " + SelectedRow.Cells[4].Value.ToString().Trim() + "  DE CÓDIGO: " + SelectedRow.Cells[0].Value.ToString() + ",  NOME: " + SelectedRow.Cells[1].Value.ToString() + cpf_cnpj, null, false, _Usuario, _Cod_PDV_Computador, 1, null, null))
                {
                    if (Lembrete.ShowDialog() == DialogResult.OK)
                    {
                        dtAniversario.Select();
                    }
                }
                pEnabled.Enabled = true;
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

        private void dtAniversario_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtAniversario.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtAniversario_MouseLeave(object sender, EventArgs e)
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

        private void dtAniversario_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Criar lembrete: Clique para criar um aviso no sistema para o aniversariante selecionado.\n\n2 - Enviar E-mail: Clique para enviar um email para o aniversariante selecionado.\n\n3 - Enviar SMS: Clique para enviar um SMS para o aniversariante selecionado.\n\n4 - Enviar ZAP: Clique para um whatsapp para o aniversariante selecionado.\n\n5 - Relatório em PDF: Clique para imprimir um relatório simples do(s) registro(s).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por aniversariante, data e todos os dados cadastados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtAniversario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Trim();
            }
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtAniversario.Rows[dtAniversario.CurrentRow.Index];
                //
                string email;
                if (SelectedRow.Cells[4].Value.ToString().Trim() == "FORNECEDOR")
                {
                    DataRow dr = bllFornecedor.Sel_F_Cod(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["email"].ToString() == null || dr["email"].ToString() == "")
                    {
                        MessageBox.Show("Este fornecedor não possui e-mail cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        email = null;
                    }
                    else
                    {
                        email = dr["email"].ToString();
                    }
                }
                else if (SelectedRow.Cells[4].Value.ToString().Trim() == "CLIENTE")
                {
                    DataRow dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["email"].ToString() == null || dr["email"].ToString() == "")
                    {
                        MessageBox.Show("Este cliente não possui e-mail cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        email = null;
                    }
                    else
                    {
                        email = dr["email"].ToString();
                    }
                }
                else
                {
                    DataRow dr = bllFuncionario.Sel_Funcionario_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["email"].ToString() == null || dr["email"].ToString() == "")
                    {
                        MessageBox.Show("Este funcionario não possui e-mail cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        email = null;
                    }
                    else
                    {
                        email = dr["email"].ToString();
                    }
                }
                //
                pEnabled.Enabled = false;
                using (FrmUtilEnviarEmail Mail = new FrmUtilEnviarEmail(3, _Cod_PDV_Computador, _Usuario, "", "Feliz aniversário! Muitas felicidade sempre! " + bllMinhaEmpresa.Sel_Nome_Empresa() + " " + bllMinhaEmpresa.Sel_Empresa_Fantasia() + " " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), "Parabéns, " + SelectedRow.Cells[1].Value.ToString(), email))
                {
                    if (Mail.ShowDialog() == DialogResult.OK)
                    {
                        dtAniversario.Select();
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

        private void btnEnviarZAP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviarZAP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarZAP_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtAniversario.Rows[dtAniversario.CurrentRow.Index];
                //
                string celular;
                if (SelectedRow.Cells[4].Value.ToString().Trim() == "FORNECEDOR")
                {
                    DataRow dr = bllFornecedor.Sel_F_Cod(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                    {
                        MessageBox.Show("Este fornecedor não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        celular = null;
                        return;
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                else if (SelectedRow.Cells[4].Value.ToString().Trim() == "CLIENTE")
                {
                    DataRow dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                    {
                        MessageBox.Show("Este cliente não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        celular = null;
                        return;
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                else
                {
                    DataRow dr = bllFuncionario.Sel_Funcionario_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                    {
                        MessageBox.Show("Este funcionario não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        celular = null;
                        return;
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                //
                celular = celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                //
                DialogResult = MessageBox.Show("Você será direcionado para o whatsapp, deseja continuar?", "Ajuda", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    string mensagem = "*Parabéns " + SelectedRow.Cells[1].Value.ToString() + "!!!*\n\nParabéns! Você merece tudo de melhor nessa vida! Que tenha um ano iluminado e muitas felicidades!\n\n" + bllMinhaEmpresa.Sel_Nome_Empresa() + "\n" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() + "\n\n*Sistema SEVEN*";
                    //
                    string encodedMessage = HttpUtility.UrlEncode(mensagem);
                    //
                    string url = $"https://wa.me/55{celular}?text={encodedMessage}";
                    //
                    bllRegistroAtividades.Salvar("ENVIO DE MENSAGEM WHATSAPP DE ANIVERSARIANTE.", "ANIVERSARIO", "0", _Usuario, _Cod_PDV_Computador);
                    //
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                //
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

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
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
                if (bllAniversariante._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                textFormatter1.DrawString("Relatório de Aniversariante", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                //
                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                textFormatter2.DrawString("CÓDIGO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                textFormatter2.DrawString("ANIVERSARIANTE", fonte1, XBrushes.Black, new XRect(80 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                textFormatter2.DrawString("DATA", fonte1, XBrushes.Black, new XRect(295 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                textFormatter2.DrawString("TIPO ", fonte1, XBrushes.Black, new XRect(420 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                //                  
                //Linhas do datagrid
                int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                int ContadorPagina = 1;
                int pagina = 16;
                bool PrimeiraPagina = true;

                int TotalPaginas = 1;//Numero de páginas do documento.
                int registros = 37;
                for (int i = 0; i < dtAniversario.Rows.Count; i++)
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
                for (int linha = 0; linha < dtAniversario.Rows.Count; linha++)
                {
                    DataGridViewRow SelectedRow = dtAniversario.Rows[linha];
                    if (linha < 16 & PrimeiraPagina == true)
                    {
                        if (linha == dtAniversario.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                        {
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                            //
                            string cpf_cnpj = null;
                            if (SelectedRow.Cells[2].Value.ToString() != "")
                            {
                                cpf_cnpj = "-" + SelectedRow.Cells[2].Value.ToString();
                            }
                            textFormatter2.DrawString("Aniversariante:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(166 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(348 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(372 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            //
                            Incrementar = 36 + Incrementar;//incrementando                               
                        }
                        else
                        {
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                            //
                            string cpf_cnpj = null;
                            if (SelectedRow.Cells[2].Value.ToString() != "")
                            {
                                cpf_cnpj = "-" + SelectedRow.Cells[2].Value.ToString();
                            }
                            textFormatter2.DrawString("Aniversariante:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(166 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(348 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(372 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                            //
                            Incrementar = 36 + Incrementar;//incrementando                               
                        }
                        //
                        if (linha == (pagina - 1) & dtAniversario.Rows.Count > 16)
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
                            textFormatter1.DrawString("Relatório de Aniversariante", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                            textFormatter1.DrawString("Relatório de Aniversariante", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                            textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                            textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                        }
                        //
                        if (linha == dtAniversario.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                        {
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                            //
                            string cpf_cnpj = null;
                            if (SelectedRow.Cells[2].Value.ToString() != "")
                            {
                                cpf_cnpj = "-" + SelectedRow.Cells[2].Value.ToString();
                            }
                            textFormatter2.DrawString("Aniversariante:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(166 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(348 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(372 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                            //
                            Incrementar = 36 + Incrementar;//incrementando                               
                        }
                        else
                        {
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                            //
                            string cpf_cnpj = null;
                            if (SelectedRow.Cells[2].Value.ToString() != "")
                            {
                                cpf_cnpj = "-" + SelectedRow.Cells[2].Value.ToString();
                            }
                            textFormatter2.DrawString("Aniversariante:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(166 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                            //
                            textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(348 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(372 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
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
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Aniversariante"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Aniversariante");
                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Aniversariante\Aniversariante.pdf");
                }
                else
                {
                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Aniversariante\Aniversariante.pdf");
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
                dtAniversario.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                pcibInterrogacao2.Enabled = true;
                pcibInterrogacao.Enabled = true;
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
                dtAniversario.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                pcibInterrogacao.Enabled = true;
                pcibInterrogacao2.Enabled = true;
                dtAniversario.Select();
                //
                try
                {
                    Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Aniversariante\Aniversariante.pdf");
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
                    dtAniversario.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    pcibInterrogacao2.Enabled = true;
                    pcibInterrogacao.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnAniversariante.Checked = true;
                }
            }
        }

        private void btnRelatorioPDF_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            //
            using (FrmInfImpressao Imp = new FrmInfImpressao(43))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtAniversario.Enabled = false;
                    dtAniversario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    pcibInterrogacao.Enabled = false;
                    pcibInterrogacao2.Enabled = false;
                }
            }
            //
            pEnabled.Enabled = true;
        }

        private void btnEnviarSMS_Click(object sender, EventArgs e)
        {
            try
            {

                //
                DataGridViewRow SelectedRow = dtAniversario.Rows[dtAniversario.CurrentRow.Index];
                //
                string celular;
                if (SelectedRow.Cells[4].Value.ToString().Trim() == "FORNECEDOR")
                {
                    DataRow dr = bllFornecedor.Sel_F_Cod(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                    {
                        MessageBox.Show("Este fornecedor não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        celular = null;
                        return;
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                else if (SelectedRow.Cells[4].Value.ToString().Trim() == "CLIENTE")
                {
                    DataRow dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                    {
                        MessageBox.Show("Este cliente não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        celular = null;
                        return;
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                else
                {
                    DataRow dr = bllFuncionario.Sel_Funcionario_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                    {
                        MessageBox.Show("Este funcionario não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        celular = null;
                        return;
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                //
                pEnabled.Enabled = false;
                using (FrmUtilEnviarSMS Sms = new FrmUtilEnviarSMS(1, _Cod_PDV_Computador, _Usuario, "Feliz aniversário! Muitas felicidade sempre! " + bllMinhaEmpresa.Sel_Nome_Empresa() + " " + bllMinhaEmpresa.Sel_Empresa_Fantasia() + " " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), celular))
                {
                    if (Sms.ShowDialog() == DialogResult.OK)
                    {
                        dtAniversario.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
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
            pEnabled.Enabled = true;
        }
    }
}
