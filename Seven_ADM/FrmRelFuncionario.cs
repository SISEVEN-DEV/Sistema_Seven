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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelFuncionario : Form
    {
        public FrmRelFuncionario()
        {
            InitializeComponent();
        }

        bool _Contem_Imagem = false;
        private byte _Trabalho;

        private void Limpar_OutrosFiltros()
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            cbbUF.Text = null;
            cbbCidade.Text = null;
            cbbCidade.Items.Clear();
            mtxtpCelular.Text = null;
            mtxtpTelefone.Text = null;
            txtpEmail.Text = null;
        }

        private void FrmRelFuncionario_Load(object sender, EventArgs e)
        {
            try
            {
                bllFuncionario._FrmRelFuncionario_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelFuncionario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelFuncionario iniciado.");
                }
                rbtnNome.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFuncionario.");
                }
            }
        }

        private void rbtnNome_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNome_MouseLeave(object sender, EventArgs e)
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

        private void rbtnRG_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnRG_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPalavra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCPF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPF_MouseLeave(object sender, EventArgs e)
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

        private void cbbUF_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCidade_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_DropDownClosed(object sender, EventArgs e)
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

        private void rbtnExportarTxt_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnExportarTxt_MouseLeave(object sender, EventArgs e)
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

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            lblDatas.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblAte.Enabled = true;
            lblEndereco.Enabled = true;
            lblUF.Enabled = true;
            lblCidade.Enabled = true;
            cbbUF.Enabled = true;
            cbbCidade.Enabled = true;
            lblTelefone.Enabled = true;
            mtxtpTelefone.Enabled = true;
            lblCelular.Enabled = true;
            mtxtpCelular.Enabled = true;
            lblEmail.Enabled = true;
            txtpEmail.Enabled = true;
            //         
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Location = new Point(355, 18);
            lblPesquisar.Text = "Digite o nome:";
            txtpNome.Visible = true;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            lblDatas.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            lblEndereco.Enabled = false;
            lblUF.Enabled = false;
            lblCidade.Enabled = false;
            cbbUF.Enabled = false;
            cbbCidade.Enabled = false;
            lblTelefone.Enabled = false;
            mtxtpTelefone.Enabled = false;
            lblCelular.Enabled = false;
            mtxtpCelular.Enabled = false;
            lblEmail.Enabled = false;
            txtpEmail.Enabled = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(580, 18);
            lblPesquisar.Text = "Digite o código:";
            txtpNome.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnRG_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            lblDatas.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            lblEndereco.Enabled = false;
            lblUF.Enabled = false;
            lblCidade.Enabled = false;
            cbbUF.Enabled = false;
            cbbCidade.Enabled = false;
            lblTelefone.Enabled = false;
            mtxtpTelefone.Enabled = false;
            lblCelular.Enabled = false;
            mtxtpCelular.Enabled = false;
            lblEmail.Enabled = false;
            txtpEmail.Enabled = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(511, 18);
            lblPesquisar.Text = "Digite o rg:";
            txtpNome.Visible = false;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnPalavra_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            lblDatas.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            lblEndereco.Enabled = false;
            lblUF.Enabled = false;
            lblCidade.Enabled = false;
            cbbUF.Enabled = false;
            cbbCidade.Enabled = false;
            lblTelefone.Enabled = false;
            mtxtpTelefone.Enabled = false;
            lblCelular.Enabled = false;
            mtxtpCelular.Enabled = false;
            lblEmail.Enabled = false;
            txtpEmail.Enabled = false;
            txtpPalavraChave.Visible = true;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(510, 18);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpNome.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            lblDatas.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            lblEndereco.Enabled = false;
            lblUF.Enabled = false;
            lblCidade.Enabled = false;
            cbbUF.Enabled = false;
            cbbCidade.Enabled = false;
            lblTelefone.Enabled = false;
            mtxtpTelefone.Enabled = false;
            lblCelular.Enabled = false;
            mtxtpCelular.Enabled = false;
            lblEmail.Enabled = false;
            txtpEmail.Enabled = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = true;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(554, 18);
            lblPesquisar.Text = "Digite o cpf:";
            txtpNome.Visible = false;
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            lblDatas.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblAte.Enabled = true;
            lblEndereco.Enabled = true;
            lblUF.Enabled = true;
            lblCidade.Enabled = true;
            cbbUF.Enabled = true;
            cbbCidade.Enabled = true;
            lblTelefone.Enabled = true;
            mtxtpTelefone.Enabled = true;
            lblCelular.Enabled = true;
            mtxtpCelular.Enabled = true;
            lblEmail.Enabled = true;
            txtpEmail.Enabled = true;
            txtpNome.Visible = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(601, 18);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            if (txtpNome.Text.Contains("'") || txtpNome.Text.Contains(";") || txtpNome.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpNome.Text = null;
                txtpNome.Select();
            }
            txtpNome.BackColor = Color.White;
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpRG_Enter(object sender, EventArgs e)
        {
            txtpRG.BackColor = Color.LightBlue;
        }

        private void txtpRG_Leave(object sender, EventArgs e)
        {
            if (txtpRG.Text.Contains("'") || txtpRG.Text.Contains(";") || txtpRG.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpRG.Text = null;
                txtpRG.Select();
            }
            txtpRG.BackColor = Color.White;
        }

        private void txtpRG_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mtxtpCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpCPF_Enter(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.LightBlue;
        }

        private void mtxtpCPF_Leave(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.White;
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

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUF.Select();
            }
        }

        private void cbbUF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCidade.Select();
            }
        }

        private void cbbCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpTelefone.Select();
            }
        }

        private void FrmRelFuncionario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Select();
            try
            {
                if (rbtnNome.Checked == true)
                {
                    if (txtpNome.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtpData.Select();
                            return;
                        }
                        else
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllFuncionario.Sel_Func_Data_UF_Cidade_Nome_Email_Telefone_Celular(txtpNome.Text, mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim()) == null)
                            {
                                dtFunc.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtFunc.DataSource = bllFuncionario.Sel_Func_Data_UF_Cidade_Nome_Email_Telefone_Celular(txtpNome.Text, mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim());
                                dtFunc.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_Codigo(txtpCodigo.Text) == null)
                        {
                            dtFunc.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFunc.DataSource = bllFuncionario.Sel_Funcionario_Codigo(txtpCodigo.Text);
                            dtFunc.Select();
                        }
                    }
                }
                else if (rbtnPalavra.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtFunc.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFunc.DataSource = bllFuncionario.Sel_Funcionario_Palavra_Chave(txtpPalavraChave.Text);
                            dtFunc.Select();
                        }
                    }
                }
                else if (rbtnCPF.Checked == true)
                {
                    mtxtpCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCPF.Text != "")
                    {
                        mtxtpCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFuncionario.Sel_Funcionario_CPF(mtxtpCPF.Text) == null)
                        {
                            dtFunc.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFunc.DataSource = bllFuncionario.Sel_Funcionario_CPF(mtxtpCPF.Text);
                            dtFunc.Select();
                        }
                    }
                }
                else if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_RG(txtpRG.Text) == null)
                        {
                            dtFunc.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFunc.DataSource = bllFuncionario.Sel_Funcionario_RG(txtpRG.Text);
                            dtFunc.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mtxtpData.Select();
                        return;
                    }
                    else
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFuncionario.Sel_Func_Data_UF_Cidade_Pessoa_Todos(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim()) == null)
                        {
                            dtFunc.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFunc.DataSource = bllFuncionario.Sel_Func_Data_UF_Cidade_Pessoa_Todos(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim());
                            dtFunc.Select();
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou funcionário.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou funcionário.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtFunc.DataSource = null;
                rbtnNome.Checked = true;
            }
        }

        private void dtFunc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtFunc.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtFunc.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtFunc.Rows[dtFunc.CurrentRow.Index];

                if (SelectedRow.Cells[18].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                    //
                    using (MemoryStream ms = new MemoryStream(imagemBytes))
                    {
                        Image imagem = Image.FromStream(ms);
                        pcibImagem.Image = imagem;
                        pcibImagem.SizeMode = PictureBoxSizeMode.StretchImage; // Ou CenterImage, como preferir
                    }
                    //
                    _Contem_Imagem = true;
                    lblLegendaImagem.Visible = false;
                }
                else
                {
                    lblLegendaImagem.Visible = true;
                    _Contem_Imagem = false;
                    lblLegendaImagem.Text = "Sem imagem para este registro.";
                    pcibImagem.Image = null;
                    pcibImagem.ImageLocation = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFunc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFunc.");
                }
                dtFunc.DataSource = null;
                rbtnNome.Checked = true;
            }
        }

        private Image AdjustImageOrientation(Image image)
        {
            if (image.PropertyIdList.Contains(0x0112)) // 0x0112 é o ID do campo EXIF de orientação
            {
                int orientation = image.GetPropertyItem(0x0112).Value[0];
                RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;

                switch (orientation)
                {
                    case 2:
                        rotateFlipType = RotateFlipType.RotateNoneFlipX;
                        break;
                    case 3:
                        rotateFlipType = RotateFlipType.Rotate180FlipNone;
                        break;
                    case 4:
                        rotateFlipType = RotateFlipType.Rotate180FlipX;
                        break;
                    case 5:
                        rotateFlipType = RotateFlipType.Rotate90FlipX;
                        break;
                    case 6:
                        rotateFlipType = RotateFlipType.Rotate90FlipNone;
                        break;
                    case 7:
                        rotateFlipType = RotateFlipType.Rotate270FlipX;
                        break;
                    case 8:
                        rotateFlipType = RotateFlipType.Rotate270FlipNone;
                        break;
                }

                if (rotateFlipType != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlipType);
                }
            }

            return image;
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida no ato da alteração de dados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtFunc.Rows[dtFunc.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtFunc.DataSource != null)
                    {
                        MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtFunc.Rows[dtFunc.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtFunc.DataSource != null)
                    {
                        MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lbllegendaImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lbllegendaImagem.");
                }
            }
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;

            if (dtFunc.DataSource != null)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pcibImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtFunc.DataSource != null)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void lblLegendaImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void dtFunc_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFunc.DataSource == null)
            {
                pcibImagem.Enabled = false;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = false;
                pcibAjudaFoto.Enabled = false;
                dtFunc.Enabled = false;
                _Contem_Imagem = false;
                grbBox2.Enabled = false;
            }
            else
            {
                pcibImagem.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                dtFunc.Enabled = true;
                grbBox2.Enabled = true;
            }
        }

        private void dtFunc_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtFunc.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtFunc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples resumido em PDF.\n\n2 - Relatório Completo em PDF: Clique para imprimir um relatório completo do(s) registro(s) em PDF.\n\n3 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n4 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmRelFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelFuncionario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelFuncionario foi finalizado.");
                }
                bllFuncionario._FrmRelFuncionario_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFuncionario.");
                }
            }
        }

        private void cbbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbUF.SelectedIndex == 0)
                {
                    cbbCidade.Items.Clear();
                }
                else if (cbbUF.SelectedIndex == 1)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 2)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 3)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 4)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 5)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 6)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 7)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 8)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 9)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 10)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 11)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 12)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 13)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 14)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 15)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 16)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 17)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 18)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 19)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 20)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 21)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 22)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 23)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 24)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 25)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 26)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 27)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                cbbCidade.Text = null;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome, código, rg, palavra-chave, cpf, todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtFunc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtFunc.Columns[0].HeaderText = "Código";
            dtFunc.Columns[1].HeaderText = "Nome";
            dtFunc.Columns[2].HeaderText = "Data de Nascimento";
            dtFunc.Columns[3].HeaderText = "CPF";
            dtFunc.Columns[4].HeaderText = "RG";
            dtFunc.Columns[5].HeaderText = "Sexo";
            dtFunc.Columns[6].HeaderText = "Telefone";
            dtFunc.Columns[7].HeaderText = "FAX";
            dtFunc.Columns[8].HeaderText = "Celular";
            dtFunc.Columns[9].HeaderText = "E-mail";
            dtFunc.Columns[10].HeaderText = "Endereço";
            dtFunc.Columns[11].HeaderText = "Número";
            dtFunc.Columns[12].HeaderText = "Complemento";
            dtFunc.Columns[13].HeaderText = "Bairro";
            dtFunc.Columns[14].HeaderText = "UF";
            dtFunc.Columns[15].HeaderText = "Cidade";
            dtFunc.Columns[16].HeaderText = "CEP";
            dtFunc.Columns[17].HeaderText = "Observações";
            dtFunc.Columns[18].Visible = false;
            dtFunc.Columns[19].HeaderText = "Palavra-Chave";
            dtFunc.Columns[20].HeaderText = "Data de Cadastro";
            //
            dtFunc.Columns[0].Width = 95;
            dtFunc.Columns[1].Width = 325;
            dtFunc.Columns[2].Width = 130;
            dtFunc.Columns[3].Width = 129;
            dtFunc.Columns[4].Width = 154;
            dtFunc.Columns[5].Width = 100;
            dtFunc.Columns[6].Width = 100;
            dtFunc.Columns[7].Width = 100;
            dtFunc.Columns[8].Width = 107;
            dtFunc.Columns[9].Width = 220;
            dtFunc.Columns[10].Width = 280;
            dtFunc.Columns[11].Width = 118;
            dtFunc.Columns[12].Width = 260;
            dtFunc.Columns[13].Width = 280;
            dtFunc.Columns[14].Width = 55;
            dtFunc.Columns[15].Width = 280;
            dtFunc.Columns[16].Width = 76;
            dtFunc.Columns[17].Width = 550;
            dtFunc.Columns[19].Width = 125;
            dtFunc.Columns[20].Width = 130;
            //
            dtFunc.DefaultCellStyle.Font = new Font(dtFunc.Font, FontStyle.Bold);
            //
            dtFunc.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFunc.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            lblRegistros.Text = "Registros: " + dtFunc.Rows.Count;
        }

        private void dtFunc_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
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
                    if (bllFuncionario._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Funcionários", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("NOME", fonte1, XBrushes.Black, new XRect(125 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF", fonte1, XBrushes.Black, new XRect(260 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("TELEFONE", fonte1, XBrushes.Black, new XRect(360 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CELULAR", fonte1, XBrushes.Black, new XRect(460 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("E-MAIL", fonte1, XBrushes.Black, new XRect(535 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtFunc.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtFunc.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtFunc.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtFunc.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + ", " + SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, 10));
                                //
                                textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + ", " + SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, 10));
                                //
                                textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;
                            }
                            //
                            if (linha == (pagina - 1) & dtFunc.Rows.Count > 16)
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
                                textFormatter1.DrawString("Relatório de Funcionários", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Funcionários", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtFunc.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + ", " + SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, 10));
                                //
                                textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                Incrementar = 36 + Incrementar;
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + ", " + SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, 10));
                                //
                                textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
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
                    for (int i = 0; i < dtFunc.Rows.Count; i = i + 2)
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
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllFuncionario._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Funcionários", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Página(s): 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(3 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    Margem_Topo = Convert.ToInt16(Margem_Topo - 15);
                    //
                    for (int x = 0; x < dtFunc.Rows.Count; x = x + 2)
                    {
                        DataGridViewRow SelectedRow = dtFunc.Rows[x];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (x == dtFunc.Rows.Count - 1 & PrimeiraPagina == true)
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo, 70, page.Height));
                                //Nome
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 180 + Margem_Topo, 509, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 198 + Margem_Topo, 509, 18);
                                textFormatter2.DrawString("Nome:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                                //CPF      
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo, 125, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo, 125, 18);
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Data Nascimento
                                graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 216 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 234 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                }
                                //RG
                                graphics.DrawRectangle(pen, XBrushes.White, 221 + Margem_Esq, 216 + Margem_Topo, 368, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 221 + Margem_Esq, 234 + Margem_Topo, 368, 18);
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(223 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(223 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Telefone
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo, 196, 18);
                                textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                                //FAX
                                graphics.DrawRectangle(pen, XBrushes.White, 201 + Margem_Esq, 252 + Margem_Topo, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 201 + Margem_Esq, 270 + Margem_Topo, 196, 18);
                                textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(203 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(203 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                                //Celular
                                graphics.DrawRectangle(pen, XBrushes.White, 397 + Margem_Esq, 252 + Margem_Topo, 192, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 397 + Margem_Esq, 270 + Margem_Topo, 192, 18);
                                textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(399 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(399 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                                //Endereco
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo, 465, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo, 465, 18);
                                textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                                //Numero
                                graphics.DrawRectangle(pen, XBrushes.White, 470 + Margem_Esq, 288 + Margem_Topo, 119, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 470 + Margem_Esq, 306 + Margem_Topo, 119, 18);
                                textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(472 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(472 + Margem_Esq, 308 + Margem_Topo, 114, page.Height));
                                //Complemento
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo, 285, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo, 285, 18);
                                textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                                //BairroDD
                                graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 324 + Margem_Topo, 299, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 342 + Margem_Topo, 299, 18);
                                textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                                //UF
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 360 + Margem_Topo, 25, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 378 + Margem_Topo, 25, 18);
                                textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                                //Cidade
                                graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 360 + Margem_Topo, 435, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 378 + Margem_Topo, 435, 18);
                                textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                                //CEP
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 360 + Margem_Topo, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 378 + Margem_Topo, 124, 18);
                                textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                                //E-mail
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 396 + Margem_Topo, 345, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 414 + Margem_Topo, 345, 18);
                                textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                                //Sexo
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 396 + Margem_Topo, 115, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 414 + Margem_Topo, 115, 18);
                                textFormatter2.DrawString("Sexo:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 396 + Margem_Topo, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 414 + Margem_Topo, 124, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 450 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                                StringBuilder sb = new StringBuilder();
                                sb.Append(SelectedRow.Cells[17].Value.ToString());
                                if (SelectedRow.Cells[17].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[17].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 452 + Margem_Topo, 584, 36));
                            }
                            else
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo, 70, page.Height));
                                //Nome
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 180 + Margem_Topo, 509, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 198 + Margem_Topo, 509, 18);
                                textFormatter2.DrawString("Nome:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                                //CPF      
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo, 125, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo, 125, 18);
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Data Nascimento
                                graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 216 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 234 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                }
                                //RG
                                graphics.DrawRectangle(pen, XBrushes.White, 221 + Margem_Esq, 216 + Margem_Topo, 368, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 221 + Margem_Esq, 234 + Margem_Topo, 368, 18);
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(223 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(223 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                                //Telefone
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo, 196, 18);
                                textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                                //FAX
                                graphics.DrawRectangle(pen, XBrushes.White, 201 + Margem_Esq, 252 + Margem_Topo, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 201 + Margem_Esq, 270 + Margem_Topo, 196, 18);
                                textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(203 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(203 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                                //Celular
                                graphics.DrawRectangle(pen, XBrushes.White, 397 + Margem_Esq, 252 + Margem_Topo, 192, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 397 + Margem_Esq, 270 + Margem_Topo, 192, 18);
                                textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(399 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(399 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                                //Endereco
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo, 465, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo, 465, 18);
                                textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                                //Numero
                                graphics.DrawRectangle(pen, XBrushes.White, 470 + Margem_Esq, 288 + Margem_Topo, 119, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 470 + Margem_Esq, 306 + Margem_Topo, 119, 18);
                                textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(472 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(472 + Margem_Esq, 308 + Margem_Topo, 114, page.Height));
                                //Complemento
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo, 285, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo, 285, 18);
                                textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                                //BairroDD
                                graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 324 + Margem_Topo, 299, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 342 + Margem_Topo, 299, 18);
                                textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                                //UF
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 360 + Margem_Topo, 25, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 378 + Margem_Topo, 25, 18);
                                textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                                //Cidade
                                graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 360 + Margem_Topo, 435, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 378 + Margem_Topo, 435, 18);
                                textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                                //CEP
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 360 + Margem_Topo, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 378 + Margem_Topo, 124, 18);
                                textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                                //E-mail
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 396 + Margem_Topo, 345, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 414 + Margem_Topo, 345, 18);
                                textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                                //Sexo
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 396 + Margem_Topo, 115, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 414 + Margem_Topo, 115, 18);
                                textFormatter2.DrawString("Sexo:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 396 + Margem_Topo, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 414 + Margem_Topo, 124, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 450 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                                StringBuilder sb = new StringBuilder();
                                sb.Append(SelectedRow.Cells[17].Value.ToString());
                                if (SelectedRow.Cells[17].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[17].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 452 + Margem_Topo, 584, 36));
                                textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, 488 + Margem_Topo, 5, 595));
                                //Grade2
                                SelectedRow = dtFunc.Rows[x + 1];
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 502 + Margem_Topo, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 520 + Margem_Topo, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 504 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 522 + Margem_Topo, 70, page.Height));
                                //Nome
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 502 + Margem_Topo, 509, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 520 + Margem_Topo, 509, 18);
                                textFormatter2.DrawString("Nome:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 504 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 522 + Margem_Topo, page.Width, page.Height));
                                //CPF      
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 538 + Margem_Topo, 125, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 556 + Margem_Topo, 125, 18);
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 558 + Margem_Topo, page.Width, page.Height));
                                //Data Nascimento
                                graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 538 + Margem_Topo, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 556 + Margem_Topo, 95, 18);
                                textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 558 + Margem_Topo, page.Width, page.Height));
                                }
                                //RG
                                graphics.DrawRectangle(pen, XBrushes.White, 221 + Margem_Esq, 538 + Margem_Topo, 368, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 221 + Margem_Esq, 556 + Margem_Topo, 368, 18);
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(223 + Margem_Esq, 540 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(223 + Margem_Esq, 558 + Margem_Topo, page.Width, page.Height));
                                //Telefone
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 574 + Margem_Topo, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 592 + Margem_Topo, 196, 18);
                                textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 594 + Margem_Topo, page.Width, page.Height));
                                //FAX
                                graphics.DrawRectangle(pen, XBrushes.White, 201 + Margem_Esq, 574 + Margem_Topo, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 201 + Margem_Esq, 592 + Margem_Topo, 196, 18);
                                textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(203 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(203 + Margem_Esq, 594 + Margem_Topo, page.Width, page.Height));
                                //Celular
                                graphics.DrawRectangle(pen, XBrushes.White, 397 + Margem_Esq, 574 + Margem_Topo, 192, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 397 + Margem_Esq, 592 + Margem_Topo, 192, 18);
                                textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(399 + Margem_Esq, 576 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(399 + Margem_Esq, 594 + Margem_Topo, page.Width, page.Height));
                                //Endereco
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 610 + Margem_Topo, 465, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 628 + Margem_Topo, 465, 18);
                                textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 612 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 630 + Margem_Topo, page.Width, page.Height));
                                //Numero
                                graphics.DrawRectangle(pen, XBrushes.White, 470 + Margem_Esq, 610 + Margem_Topo, 119, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 470 + Margem_Esq, 628 + Margem_Topo, 119, 18);
                                textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(472 + Margem_Esq, 612 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(472 + Margem_Esq, 630 + Margem_Topo, 114, page.Height));
                                //Complemento
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 646 + Margem_Topo, 285, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 664 + Margem_Topo, 285, 18);
                                textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 648 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 666 + Margem_Topo, page.Width, page.Height));
                                //BairroDD
                                graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 646 + Margem_Topo, 299, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 664 + Margem_Topo, 299, 18);
                                textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 648 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 666 + Margem_Topo, page.Width, page.Height));
                                //UF
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 682 + Margem_Topo, 25, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 700 + Margem_Topo, 25, 18);
                                textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 684 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 702 + Margem_Topo, page.Width, page.Height));
                                //Cidade
                                graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 682 + Margem_Topo, 435, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 700 + Margem_Topo, 435, 18);
                                textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 684 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 702 + Margem_Topo, page.Width, page.Height));
                                //CEP
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 682 + Margem_Topo, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 700 + Margem_Topo, 124, 18);
                                textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 684 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 702 + Margem_Topo, page.Width, page.Height));
                                //E-mail
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 718 + Margem_Topo, 345, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 736 + Margem_Topo, 345, 18);
                                textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 720 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 738 + Margem_Topo, page.Width, page.Height));
                                //Sexo
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 718 + Margem_Topo, 115, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 736 + Margem_Topo, 115, 18);
                                textFormatter2.DrawString("Sexo:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 720 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 738 + Margem_Topo, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 718 + Margem_Topo, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 736 + Margem_Topo, 124, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 720 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 738 + Margem_Topo, page.Width, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 754 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 772 + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 756 + Margem_Topo, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[17].Value.ToString());
                                if (SelectedRow.Cells[17].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[17].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 774 + Margem_Topo, 584, 36));

                                if (dtFunc.Rows.Count > 2)
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
                                    textFormatter1.DrawString("Relatório de Funcionários", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Página(s): " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(3 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                }
                            }
                        }
                        else
                        {
                            Margem_Topo = Convert.ToInt16(Margem_Topo - 104);

                            if (x == dtFunc.Rows.Count - 1 & PrimeiraPagina == false)
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo - 15, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo - 15, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo - 15, 70, page.Height));
                                //Nome
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 180 + Margem_Topo - 15, 509, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 198 + Margem_Topo - 15, 509, 18);
                                textFormatter2.DrawString("Nome:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 200 + Margem_Topo - 15, page.Width, page.Height));
                                //CPF      
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo - 15, 125, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo - 15, 125, 18);
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo - 15, page.Width, page.Height));
                                //Data Nascimento
                                graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 216 + Margem_Topo - 15, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 234 + Margem_Topo - 15, 95, 18);
                                textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 218 + Margem_Topo - 15, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 236 + Margem_Topo - 15, page.Width, page.Height));
                                }
                                //RG
                                graphics.DrawRectangle(pen, XBrushes.White, 221 + Margem_Esq, 216 + Margem_Topo - 15, 368, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 221 + Margem_Esq, 234 + Margem_Topo - 15, 368, 18);
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(223 + Margem_Esq, 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(223 + Margem_Esq, 236 + Margem_Topo - 15, page.Width, page.Height));
                                //Telefone
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo - 15, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo - 15, 196, 18);
                                textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo - 15, page.Width, page.Height));
                                //FAX
                                graphics.DrawRectangle(pen, XBrushes.White, 201 + Margem_Esq, 252 + Margem_Topo - 15, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 201 + Margem_Esq, 270 + Margem_Topo - 15, 196, 18);
                                textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(203 + Margem_Esq, 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(203 + Margem_Esq, 272 + Margem_Topo - 15, page.Width, page.Height));
                                //Celular
                                graphics.DrawRectangle(pen, XBrushes.White, 397 + Margem_Esq, 252 + Margem_Topo - 15, 192, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 397 + Margem_Esq, 270 + Margem_Topo - 15, 192, 18);
                                textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(399 + Margem_Esq, 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(399 + Margem_Esq, 272 + Margem_Topo - 15, page.Width, page.Height));
                                //Endereco
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo - 15, 465, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo - 15, 465, 18);
                                textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo - 15, page.Width, page.Height));
                                //Numero
                                graphics.DrawRectangle(pen, XBrushes.White, 470 + Margem_Esq, 288 + Margem_Topo - 15, 119, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 470 + Margem_Esq, 306 + Margem_Topo - 15, 119, 18);
                                textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(472 + Margem_Esq, 290 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(472 + Margem_Esq, 308 + Margem_Topo - 15, 114, page.Height));
                                //Complemento
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo - 15, 285, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo - 15, 285, 18);
                                textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo - 15, page.Width, page.Height));
                                //BairroDD
                                graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 324 + Margem_Topo - 15, 299, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 342 + Margem_Topo - 15, 299, 18);
                                textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 326 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 344 + Margem_Topo - 15, page.Width, page.Height));
                                //UF
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 360 + Margem_Topo - 15, 25, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 378 + Margem_Topo - 15, 25, 18);
                                textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 362 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 380 + Margem_Topo - 15, page.Width, page.Height));
                                //Cidade
                                graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 360 + Margem_Topo - 15, 435, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 378 + Margem_Topo - 15, 435, 18);
                                textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 362 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 380 + Margem_Topo - 15, page.Width, page.Height));
                                //CEP
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 360 + Margem_Topo - 15, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 378 + Margem_Topo - 15, 124, 18);
                                textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 362 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 380 + Margem_Topo - 15, page.Width, page.Height));
                                //E-mail
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 396 + Margem_Topo - 15, 345, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 414 + Margem_Topo - 15, 345, 18);
                                textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 398 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 416 + Margem_Topo - 15, page.Width, page.Height));
                                //Sexo
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 396 + Margem_Topo - 15, 115, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 414 + Margem_Topo - 15, 115, 18);
                                textFormatter2.DrawString("Sexo:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 398 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 416 + Margem_Topo - 15, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 396 + Margem_Topo - 15, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 414 + Margem_Topo - 15, 124, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 398 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 416 + Margem_Topo - 15, page.Width, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo - 15, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 450 + Margem_Topo - 15, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 434 + Margem_Topo - 15, page.Width, page.Height));
                                StringBuilder sb = new StringBuilder();
                                sb.Append(SelectedRow.Cells[17].Value.ToString());
                                if (SelectedRow.Cells[17].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[17].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 452 + Margem_Topo - 15, 584, 36));
                                //
                            }
                            else
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo - 15, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo - 15, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo - 15, 70, page.Height));
                                //Nome
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 180 + Margem_Topo - 15, 509, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 198 + Margem_Topo - 15, 509, 18);
                                textFormatter2.DrawString("Nome:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 200 + Margem_Topo - 15, page.Width, page.Height));
                                //CPF      
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo - 15, 125, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo - 15, 125, 18);
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo - 15, page.Width, page.Height));
                                //Data Nascimento
                                graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 216 + Margem_Topo - 15, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 234 + Margem_Topo - 15, 95, 18);
                                textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 218 + Margem_Topo - 15, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 236 + Margem_Topo - 15, page.Width, page.Height));
                                }
                                //RG
                                graphics.DrawRectangle(pen, XBrushes.White, 221 + Margem_Esq, 216 + Margem_Topo - 15, 368, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 221 + Margem_Esq, 234 + Margem_Topo - 15, 368, 18);
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(223 + Margem_Esq, 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(223 + Margem_Esq, 236 + Margem_Topo - 15, page.Width, page.Height));
                                //Telefone
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo - 15, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo - 15, 196, 18);
                                textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo - 15, page.Width, page.Height));
                                //FAX
                                graphics.DrawRectangle(pen, XBrushes.White, 201 + Margem_Esq, 252 + Margem_Topo - 15, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 201 + Margem_Esq, 270 + Margem_Topo - 15, 196, 18);
                                textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(203 + Margem_Esq, 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(203 + Margem_Esq, 272 + Margem_Topo - 15, page.Width, page.Height));
                                //Celular
                                graphics.DrawRectangle(pen, XBrushes.White, 397 + Margem_Esq, 252 + Margem_Topo - 15, 192, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 397 + Margem_Esq, 270 + Margem_Topo - 15, 192, 18);
                                textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(399 + Margem_Esq, 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(399 + Margem_Esq, 272 + Margem_Topo - 15, page.Width, page.Height));
                                //Endereco
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo - 15, 465, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo - 15, 465, 18);
                                textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo - 15, page.Width, page.Height));
                                //Numero
                                graphics.DrawRectangle(pen, XBrushes.White, 470 + Margem_Esq, 288 + Margem_Topo - 15, 119, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 470 + Margem_Esq, 306 + Margem_Topo - 15, 119, 18);
                                textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(472 + Margem_Esq, 290 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(472 + Margem_Esq, 308 + Margem_Topo - 15, 114, page.Height));
                                //Complemento
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo - 15, 285, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo - 15, 285, 18);
                                textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo - 15, page.Width, page.Height));
                                //BairroDD
                                graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 324 + Margem_Topo - 15, 299, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 342 + Margem_Topo - 15, 299, 18);
                                textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 326 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 344 + Margem_Topo - 15, page.Width, page.Height));
                                //UF
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 360 + Margem_Topo - 15, 25, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 378 + Margem_Topo - 15, 25, 18);
                                textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 362 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 380 + Margem_Topo - 15, page.Width, page.Height));
                                //Cidade
                                graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 360 + Margem_Topo - 15, 435, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 378 + Margem_Topo - 15, 435, 18);
                                textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 362 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 380 + Margem_Topo - 15, page.Width, page.Height));
                                //CEP
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 360 + Margem_Topo - 15, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 378 + Margem_Topo - 15, 124, 18);
                                textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 362 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 380 + Margem_Topo - 15, page.Width, page.Height));
                                //E-mail
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 396 + Margem_Topo - 15, 345, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 414 + Margem_Topo - 15, 345, 18);
                                textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 398 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 416 + Margem_Topo - 15, page.Width, page.Height));
                                //Sexo
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 396 + Margem_Topo - 15, 115, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 414 + Margem_Topo - 15, 115, 18);
                                textFormatter2.DrawString("Sexo:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 398 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 416 + Margem_Topo - 15, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 396 + Margem_Topo - 15, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 414 + Margem_Topo - 15, 124, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 398 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 416 + Margem_Topo - 15, page.Width, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo - 15, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 450 + Margem_Topo - 15, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 434 + Margem_Topo - 15, page.Width, page.Height));
                                StringBuilder sb = new StringBuilder();
                                sb.Append(SelectedRow.Cells[17].Value.ToString());
                                if (SelectedRow.Cells[17].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[17].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 452 + Margem_Topo - 15, 584, 36));
                                //
                                textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, 542 - 15 + Margem_Topo, 5, 595));
                                Margem_Topo = Convert.ToInt16(Margem_Topo + 104);
                                //Grade2
                                SelectedRow = dtFunc.Rows[x + 1];
                                //Código
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 502 + Margem_Topo - 15, 75, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 520 + Margem_Topo - 15, 75, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 504 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 522 + Margem_Topo - 15, 70, page.Height));
                                //Nome
                                graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 502 + Margem_Topo - 15, 509, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 520 + Margem_Topo - 15, 509, 18);
                                textFormatter2.DrawString("Nome:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 504 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 522 + Margem_Topo - 15, page.Width, page.Height));
                                //CPF      
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 538 + Margem_Topo - 15, 125, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 556 + Margem_Topo - 15, 125, 18);
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 540 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 558 + Margem_Topo - 15, page.Width, page.Height));
                                //Data Nascimento
                                graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 538 + Margem_Topo - 15, 95, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 556 + Margem_Topo - 15, 95, 18);
                                textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 540 + Margem_Topo - 15, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 558 + Margem_Topo - 15, page.Width, page.Height));
                                }
                                //RG
                                graphics.DrawRectangle(pen, XBrushes.White, 221 + Margem_Esq, 538 + Margem_Topo - 15, 368, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 221 + Margem_Esq, 556 + Margem_Topo - 15, 368, 18);
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(223 + Margem_Esq, 540 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(223 + Margem_Esq, 558 + Margem_Topo - 15, page.Width, page.Height));
                                //Telefone
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 574 + Margem_Topo - 15, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 592 + Margem_Topo - 15, 196, 18);
                                textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 576 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 594 + Margem_Topo - 15, page.Width, page.Height));
                                //FAX
                                graphics.DrawRectangle(pen, XBrushes.White, 201 + Margem_Esq, 574 + Margem_Topo - 15, 196, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 201 + Margem_Esq, 592 + Margem_Topo - 15, 196, 18);
                                textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(203 + Margem_Esq, 576 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(203 + Margem_Esq, 594 + Margem_Topo - 15, page.Width, page.Height));
                                //Celular
                                graphics.DrawRectangle(pen, XBrushes.White, 397 + Margem_Esq, 574 + Margem_Topo - 15, 192, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 397 + Margem_Esq, 592 + Margem_Topo - 15, 192, 18);
                                textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(399 + Margem_Esq, 576 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(399 + Margem_Esq, 594 + Margem_Topo - 15, page.Width, page.Height));
                                //Endereco
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 610 + Margem_Topo - 15, 465, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 628 + Margem_Topo - 15, 465, 18);
                                textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 612 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 630 + Margem_Topo - 15, page.Width, page.Height));
                                //Numero
                                graphics.DrawRectangle(pen, XBrushes.White, 470 + Margem_Esq, 610 + Margem_Topo - 15, 119, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 470 + Margem_Esq, 628 + Margem_Topo - 15, 119, 18);
                                textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(472 + Margem_Esq, 612 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(472 + Margem_Esq, 630 + Margem_Topo - 15, 114, page.Height));
                                //Complemento
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 646 + Margem_Topo - 15, 285, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 664 + Margem_Topo - 15, 285, 18);
                                textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 648 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 666 + Margem_Topo - 15, page.Width, page.Height));
                                //BairroDD
                                graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 646 + Margem_Topo - 15, 299, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 664 + Margem_Topo - 15, 299, 18);
                                textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 648 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 666 + Margem_Topo - 15, page.Width, page.Height));
                                //UF
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 682 + Margem_Topo - 15, 25, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 700 + Margem_Topo - 15, 25, 18);
                                textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 684 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 702 + Margem_Topo - 15, page.Width, page.Height));
                                //Cidade
                                graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 682 + Margem_Topo - 15, 435, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 700 + Margem_Topo - 15, 435, 18);
                                textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 684 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 702 + Margem_Topo - 15, page.Width, page.Height));
                                //CEP
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 682 + Margem_Topo - 15, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 700 + Margem_Topo - 15, 124, 18);
                                textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 684 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 702 + Margem_Topo - 15, page.Width, page.Height));
                                //E-mail
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 718 + Margem_Topo - 15, 345, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 736 + Margem_Topo - 15, 345, 18);
                                textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 720 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 738 + Margem_Topo - 15, page.Width, page.Height));
                                //Sexo
                                graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 718 + Margem_Topo - 15, 115, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 736 + Margem_Topo - 15, 115, 18);
                                textFormatter2.DrawString("Sexo:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 720 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 738 + Margem_Topo - 15, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 718 + Margem_Topo - 15, 124, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 736 + Margem_Topo - 15, 124, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 720 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[19].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 738 + Margem_Topo - 15, page.Width, page.Height));
                                //Observações
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 754 + Margem_Topo - 15, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 772 + Margem_Topo - 15, 584, 36);
                                textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 756 + Margem_Topo - 15, page.Width, page.Height));
                                sb.Clear();
                                sb.Append(SelectedRow.Cells[17].Value.ToString());
                                if (SelectedRow.Cells[17].Value.ToString().Length > 160)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(80, 80).Contains(" "))
                                    {
                                        sb.Insert(160, Environment.NewLine);
                                    }
                                }
                                //
                                if (SelectedRow.Cells[17].Value.ToString().Length > 80)
                                {
                                    if (!SelectedRow.Cells[17].Value.ToString().Substring(0, 80).Contains(" "))
                                    {
                                        sb.Insert(80, Environment.NewLine);
                                    }
                                }
                                textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 774 + Margem_Topo - 15, 584, 36));
                                //
                                if (dtFunc.Rows.Count > pagina)
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
                                    textFormatter1.DrawString("Relatório de Funcionários", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.pdf");
                    }
                }
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.txt"))
                {
                    writer.WriteLine("Relatório de Funcionários" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtFunc.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtFunc.Rows[linha];
                        string data_nascimento = SelectedRow.Cells[2].Value.ToString();
                        //
                        if (data_nascimento == "" || data_nascimento == null)
                        {
                            data_nascimento = "";
                        }
                        else
                        {
                            data_nascimento = data_nascimento.Remove(10);
                        }
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Nome: " + SelectedRow.Cells[1].Value.ToString() + " |Data de Nascimento: " + data_nascimento + " |CPF: " + SelectedRow.Cells[3].Value.ToString() + " |RG: " + SelectedRow.Cells[4].Value.ToString() + " |Sexo: " + SelectedRow.Cells[5].Value.ToString() + " |Telefone: " + SelectedRow.Cells[6].Value.ToString() + " |FAX: " + SelectedRow.Cells[7].Value.ToString() + " |Celular: " + SelectedRow.Cells[8].Value.ToString() + " |E-mail: " + SelectedRow.Cells[9].Value.ToString() + " |Endereço: " + SelectedRow.Cells[10].Value.ToString() + " |Número: " + SelectedRow.Cells[11].Value.ToString() + " |Complemento: " + SelectedRow.Cells[12].Value.ToString() + " |Bairro: " + SelectedRow.Cells[13].Value.ToString() + " |UF: " + SelectedRow.Cells[14].Value.ToString() + " |Cidade: " + SelectedRow.Cells[15].Value.ToString() + " |CEP: " + SelectedRow.Cells[16].Value.ToString() + " |Observações: " + SelectedRow.Cells[17].Value.ToString() + " |Palavra-Chave: " + SelectedRow.Cells[19].Value.ToString() + " |Data de Cadastro: " + SelectedRow.Cells[20].Value.ToString().Remove(10));
                    }
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.txt");
            }
            else if (_Trabalho == 3)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Nome;Data de Nascimento;CPF;RG;Sexo;Telefone;FAX;Celular;E-mail;Endereço;Número;Complemento;Bairro;UF;Cidade;CEP;Observações;Palavra-Chave;Data de Cadastro");
                    for (int linha = 0; linha < dtFunc.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtFunc.Rows[linha];
                        //
                        string data_nascimento = SelectedRow.Cells[2].Value.ToString();
                        //
                        if (data_nascimento == "" || data_nascimento == null)
                        {
                            data_nascimento = "";
                        }
                        else
                        {
                            data_nascimento = data_nascimento.Remove(10);
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), data_nascimento, SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[15].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), SelectedRow.Cells[17].Value.ToString(), SelectedRow.Cells[19].Value.ToString(), SelectedRow.Cells[20].Value.ToString().Remove(10)));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Funcionários");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.csv");
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dtFunc.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                btnSair.Enabled = true;
                rbtnNome.Checked = true;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtFunc.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtFunc.Select();
                //                
                try
                {
                    if (_Trabalho == 0 || _Trabalho == 1)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Funcionarios\Funcionarios.pdf");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dtFunc.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnNome.Checked = true;
                }
            }
        }

        private void btnTodasContas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTodasContas_MouseLeave(object sender, EventArgs e)
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

        private void txtpEmail_Enter(object sender, EventArgs e)
        {
            txtpEmail.BackColor = Color.LightBlue;
        }

        private void txtpEmail_Leave(object sender, EventArgs e)
        {
            if (txtpEmail.Text.Contains("'") || txtpEmail.Text.Contains(";") || txtpEmail.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpEmail.Text = null;
                txtpEmail.Select();
            }
            txtpEmail.BackColor = Color.White;
        }

        private void mtxtpTelefone_Enter(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtpTelefone_Leave(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.White;
        }

        private void mtxtpTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpCelular.Select();
            }
        }

        private void mtxtpCelular_Enter(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.LightBlue;
        }

        private void mtxtpCelular_Leave(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.White;
        }

        private void mtxtpCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpEmail.Select();
            }
        }

        private void txtpEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnTodasContas_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(34))
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
                    dtFunc.Enabled = false;
                    dtFunc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 3;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtFunc.Enabled = false;
            dtFunc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtFunc.Enabled = false;
            dtFunc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(35))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 1;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtFunc.Enabled = false;
                    dtFunc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void mtxtpData1_KeyDown(object sender, KeyEventArgs e)
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

        private void mtxtpData_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(16))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Select();
                    mtxtpData.Text = bllFuncionario._Data_DatePicker1;
                    mtxtpData1.Text = bllFuncionario._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }
    }
}
