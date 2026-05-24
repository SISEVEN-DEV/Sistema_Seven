using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqDFe : Form
    {
        public FrmPesqDFe(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmPesqDFe_Load(object sender, EventArgs e)
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqDFe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqDFe iniciado.");
                }
                //
                rbtnDataEmissao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqDFe.");
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void rbtnDataCriacao_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = true;
            btnSelecionarData.Visible = true;
            mtxtpData.Visible = true;
            mtxtChave.Visible = false;
            mtxtpData1.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(405, 19);
            lblPesquisar.Text = "Digite as datas:";
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpData.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblAte.Visible = false;
            btnSelecionarData.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(552, 19);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblAte.Visible = false;
            btnSelecionarData.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(598, 19);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void FrmPesqDFe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqDFe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqDFe foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqDFe.");
                }
            }
        }

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
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

        private void btnConsultarItens_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarItens_MouseLeave(object sender, EventArgs e)
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

        private void btnProcurarCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCliente_MouseLeave(object sender, EventArgs e)
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

        private void rbtnDataCriacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDataCriacao_MouseLeave(object sender, EventArgs e)
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

        private void rbtnConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnConsumidor_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
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
                btnPesquisar.Select();
            }
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

        private void cbbConsumidor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rbtnNumeroNF_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblAte.Visible = false;
            btnSelecionarData.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(511, 19);
            lblPesquisar.Text = "Digite o número da NF:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void FrmPesqDFe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtPesquisa_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtPesquisa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtPesquisa_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                dtPesquisa.Enabled = false;
                btnIncluir.Enabled = false;
                btnConsultarItens.Enabled = false;
            }
            else
            {
                dtPesquisa.Enabled = true;
                btnIncluir.Enabled = true;
                btnConsultarItens.Enabled = true;
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            btnIncluir.Enabled = false;
            btnVoltar.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnConsultarItens.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(12))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllOrcamento._Data_DatePicker1;
                    mtxtpData1.Text = bllOrcamento._Data_DatePicker2;
                }
            }
            btnPesquisar.Enabled = true;
            if (dtPesquisa.DataSource == null)
            {
                btnIncluir.Enabled = false;
                btnConsultarItens.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                btnConsultarItens.Enabled = true;
            }
            btnVoltar.Enabled = true;
            btnSelecionarData.Enabled = true;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por data de emissão, código, número da nf, chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDataEmissao.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllDFe.Sel_Dfe_Data_Emissao(mtxtpData.Text, mtxtpData1.Text, "") == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllDFe.Sel_Dfe_Data_Emissao(mtxtpData.Text, mtxtpData1.Text, "");
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllDFe.Sel_Nfe_Cod(txtpCodigo.Text, "") == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllDFe.Sel_Nfe_Cod(txtpCodigo.Text, "");
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnNumeroNF.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllDFe.Sel_Nfe_Numero(txtpCodigo.Text, "") == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllDFe.Sel_Nfe_Numero(txtpCodigo.Text, "");
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnChave.Checked == true)
                {
                    mtxtChave.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtChave.Text != "")
                    {
                        mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllDFe.Sel_Nfe_Chave(mtxtChave.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllDFe.Sel_Nfe_Chave(mtxtChave.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllDFe.Sel_Nfe_Todos("") == null)
                    {
                        dtPesquisa.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtPesquisa.DataSource = bllDFe.Sel_Nfe_Todos("");
                        dtPesquisa.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou dfe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou dfe.");
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
                dtPesquisa.DataSource = null;
                rbtnDataEmissao.Checked = true;
            }
        }

        private void dtPesquisa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtPesquisa.Columns[0].HeaderText = "Código";
            dtPesquisa.Columns[1].HeaderText = "Número da NF";
            dtPesquisa.Columns[2].HeaderText = "Tipo do Emit./Dest.";
            dtPesquisa.Columns[3].HeaderText = "Código do Emit./Dest.";
            dtPesquisa.Columns[4].HeaderText = "Nome do Emit./Dest.";
            dtPesquisa.Columns[5].HeaderText = "CPF/CNPJ do Emit./Dest.";
            dtPesquisa.Columns[6].HeaderText = "Total dos Produtos (R$)";
            dtPesquisa.Columns[7].HeaderText = "Valor Total da NF (R$)";
            dtPesquisa.Columns[8].HeaderText = "Série";
            dtPesquisa.Columns[9].HeaderText = "Data de Emissão";
            dtPesquisa.Columns[10].HeaderText = "Hora da Emissão";
            dtPesquisa.Columns[11].HeaderText = "Data de Sáida";
            dtPesquisa.Columns[12].HeaderText = "Hora de Saída";
            dtPesquisa.Columns[13].HeaderText = "Modelo";
            dtPesquisa.Columns[14].HeaderText = "Emissão";
            dtPesquisa.Columns[15].HeaderText = "Descontos (R$)";
            dtPesquisa.Columns[16].HeaderText = "Frete (R$)";
            dtPesquisa.Columns[17].HeaderText = "Despesas (R$)";
            dtPesquisa.Columns[18].HeaderText = "Chave";
            dtPesquisa.Columns[19].HeaderText = "Observacao";
            dtPesquisa.Columns[20].HeaderText = "Natureza da Operação/CFOP Predominante";
            dtPesquisa.Columns[21].Visible = false;
            dtPesquisa.Columns[22].Visible = false;
            dtPesquisa.Columns[23].HeaderText = "Seguro";
            dtPesquisa.Columns[24].HeaderText = "IPI";
            dtPesquisa.Columns[25].HeaderText = "Finalidade";
            dtPesquisa.Columns[26].HeaderText = "ICMS";
            dtPesquisa.Columns[27].HeaderText = "ICMS ST";
            dtPesquisa.Columns[28].HeaderText = "Base de Cálculo ICMS";
            dtPesquisa.Columns[29].HeaderText = "Base de Cálculo ICMS ST";
            dtPesquisa.Columns[30].HeaderText = "Total Aprox. dos Trib.";
            //
            dtPesquisa.Columns[0].Width = 85;
            dtPesquisa.Columns[1].Width = 105;
            dtPesquisa.Columns[2].Width = 150;
            dtPesquisa.Columns[3].Width = 150;
            dtPesquisa.Columns[4].Width = 275;
            dtPesquisa.Columns[5].Width = 205;
            dtPesquisa.Columns[6].Width = 150;
            dtPesquisa.Columns[7].Width = 150;
            dtPesquisa.Columns[8].Width = 150;
            dtPesquisa.Columns[9].Width = 85;
            dtPesquisa.Columns[9].Width = 150;
            dtPesquisa.Columns[10].Width = 150;
            dtPesquisa.Columns[11].Width = 150;
            dtPesquisa.Columns[12].Width = 150;
            dtPesquisa.Columns[13].Width = 100;
            dtPesquisa.Columns[14].Width = 100;
            dtPesquisa.Columns[15].Width = 150;
            dtPesquisa.Columns[16].Width = 150;
            dtPesquisa.Columns[17].Width = 150;
            dtPesquisa.Columns[18].Width = 425;
            dtPesquisa.Columns[19].Width = 500;
            dtPesquisa.Columns[20].Width = 350;
            dtPesquisa.Columns[23].Width = 150;
            dtPesquisa.Columns[24].Width = 150;
            dtPesquisa.Columns[25].Width = 200;
            dtPesquisa.Columns[26].Width = 150;
            dtPesquisa.Columns[27].Width = 150;
            dtPesquisa.Columns[28].Width = 150;
            dtPesquisa.Columns[29].Width = 175;
            dtPesquisa.Columns[30].Width = 150;
            //
            dtPesquisa.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtPesquisa.DefaultCellStyle.Font = new Font(dtPesquisa.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtPesquisa.Rows.Count;
        }

        private void dtPesquisa_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtPesquisa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtPesquisa.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtPesquisa.DefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
            //
            dtPesquisa.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[6].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[7].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[15].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[16].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[17].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[23].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[24].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[26].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[27].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[28].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[29].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[29].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[30].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[30].DefaultCellStyle.Format = "n2";
        }

        private void dtPesquisa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 8 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 20 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 5 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 9 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 11 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllDFe._Cod_DFe = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllEntradasProdutos._Cod_DFe = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllDFe._Chave_DFe = SelectedRow.Cells[18].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtPesquisa_DoubleClick(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllDFe._Cod_DFe = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllEntradasProdutos._Cod_DFe = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllDFe._Chave_DFe = SelectedRow.Cells[18].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllDFe._Cod_DFe = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllEntradasProdutos._Cod_DFe = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllDFe._Chave_DFe = SelectedRow.Cells[18].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        private void rbtnChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnChave_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = true;
            lblAte.Visible = false;
            btnSelecionarData.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(249, 19);
            lblPesquisar.Text = "Digite a chave:";
            mtxtChave.Text = null;
            mtxtChave.Select();
        }

        private void mtxtChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtChave_Enter(object sender, EventArgs e)
        {
            mtxtChave.BackColor = Color.LightBlue;
        }

        private void mtxtChave_Leave(object sender, EventArgs e)
        {
            mtxtChave.BackColor = Color.White;
        }

        private void btnConsultarItens_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 4))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtPesquisa.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
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
            this.Enabled = true;
        }
    }
}
