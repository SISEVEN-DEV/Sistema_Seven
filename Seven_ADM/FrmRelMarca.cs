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
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelMarca : Form
    {
        public FrmRelMarca()
        {
            InitializeComponent();
        }

        private byte _Trabalho;

        private void FrmRelMarca_Load(object sender, EventArgs e)
        {
            try
            {
                bllMarca._FrmRelMarca_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelMarca iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelMarca iniciado.");
                }
                //               
                using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\Paises\Paises.txt", System.Text.Encoding.UTF8))
                {
                    cbbpPais.Items.Add("");
                    cbbpPais.Items.Add("BRASIL");
                    while (!Sr.EndOfStream)
                    {
                        cbbpPais.Items.Add(Sr.ReadLine());
                    }
                }
                //
                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelMarca.");
                }
                this.Close();
            }
        }

        private void Limpar_OutrosFiltros()
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
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

        private void rbtnOrigem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(259, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(469, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = true;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(388, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnOrigem_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpOrigemPais.Visible = true;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Escolha a origem:";
            lblPesquisar.Location = new Point(320, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            cbbpOrigemPais.Text = null;
            cbbpOrigemPais.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(479, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            btnPesquisar.Select();
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
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
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpOrigemPais_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbbpOrigemPais_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpOrigemPais_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpOrigemPais_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpOrigemPais_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
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

        private void btnImprimirRel_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimirRel_MouseLeave(object sender, EventArgs e)
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

        private void FrmRelMarca_KeyUp(object sender, KeyEventArgs e)
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

        private void FrmRelMarca_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelMarca foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelMarca foi finalizado.");
                }
                bllMarca._FrmRelMarca_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelMarca.");
                }
            }
        }

        private void rbtnOrigem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
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
            if (e.KeyCode == Keys.Enter)
            {
                cbbpPais.Select();
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
            if (e.KeyCode == Keys.Enter)
            {
                mtxtpData1.Select();
            }
        }

        private void cbbpPais_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpPais_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpPais_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpPais_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, origem, palavra-chave, todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples resumido em PDF.\n\n2 - Relatório Completo em PDF: Clique para imprimir um relatório completo do(s) registro(s) em PDF.\n\n3 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n4 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtMarca_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtMarca.Columns[0].HeaderText = "Código";
            dtMarca.Columns[1].HeaderText = "Descrição";
            dtMarca.Columns[2].HeaderText = "Origem";
            dtMarca.Columns[3].HeaderText = "País";
            dtMarca.Columns[4].HeaderText = "Palavra-Chave";
            dtMarca.Columns[5].HeaderText = "Data de Cadastro";
            //
            dtMarca.Columns[0].Width = 95;
            dtMarca.Columns[1].Width = 350;
            dtMarca.Columns[2].Width = 275;
            dtMarca.Columns[3].Width = 275;
            dtMarca.Columns[4].Width = 125;
            dtMarca.Columns[5].Width = 130;
            //
            dtMarca.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtMarca.DefaultCellStyle.Font = new Font(dtMarca.Font, FontStyle.Bold);
            //
            lblRegistros.Text = "Registros: " + dtMarca.Rows.Count;
        }

        private void dtMarca_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtMarca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtMarca_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtMarca.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtMarca_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtMarca.DataSource == null)
            {
                grbBox2.Enabled = false;
                dtMarca.Enabled = false;
            }
            else
            {
                grbBox2.Enabled = true;
                dtMarca.Enabled = true;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
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

                            if (bllMarca.Sel_Marca_Data_Pais_Descricao(mtxtpData.Text, mtxtpData1.Text, txtpDescricao.Text.Trim(), cbbpPais.Text) == null)
                            {
                                dtMarca.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtMarca.DataSource = bllMarca.Sel_Marca_Data_Pais_Descricao(mtxtpData.Text, mtxtpData1.Text, txtpDescricao.Text.Trim(), cbbpPais.Text);
                                dtMarca.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Codigo(txtpCodigo.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Codigo(txtpCodigo.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnOrigem.Checked == true)
                {
                    if (cbbpOrigemPais.Text != "")
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

                            if (bllMarca.Sel_Marca_Data_Pais_Origem(mtxtpData.Text, mtxtpData1.Text, cbbpOrigemPais.Text, cbbpPais.Text) == null)
                            {
                                dtMarca.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtMarca.DataSource = bllMarca.Sel_Marca_Data_Pais_Origem(mtxtpData.Text, mtxtpData1.Text, cbbpOrigemPais.Text, cbbpPais.Text);
                                dtMarca.Select();
                            }
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Palavra_Chave(txtpPalavraChave.Text);
                            dtMarca.Select();
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

                        if (bllMarca.Sel_Marca_Data_Pais_Todos(mtxtpData.Text, mtxtpData1.Text, cbbpPais.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Data_Pais_Todos(mtxtpData.Text, mtxtpData1.Text, cbbpPais.Text);
                            dtMarca.Select();
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou marca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou marca.");
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
                dtMarca.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtMarca_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtMarca.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtMarca.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtMarca.");
                }
                dtMarca.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void btnImprimirRel_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(38))
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
                    dtMarca.Enabled = false;
                    dtMarca.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
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
                dtMarca.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
                picbInterrogacao3.Enabled = true;
                btnSair.Enabled = true;
                rbtnDescricao.Checked = true;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtMarca.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtMarca.Select();
                //
                try
                {
                    if (_Trabalho == 0 || _Trabalho == 1)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.pdf");
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
                    dtMarca.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao2.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnDescricao.Checked = true;
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
                    if (bllMarca._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Marcas", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("DESCRIÇÃO", fonte1, XBrushes.Black, new XRect(125 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtMarca.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtMarca.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtMarca.Rows[linha];
                        if (linha < 15 & PrimeiraPagina == true)
                        {
                            if (linha == dtMarca.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 212) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                Incrementar = 36 + Incrementar;
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 212) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                Incrementar = 36 + Incrementar;
                            }
                            //
                            if (linha == (pagina - 1) & dtMarca.Rows.Count > 15)
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
                                textFormatter1.DrawString("Relatório de Marcas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Marcas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtMarca.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 34) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                Incrementar = 36 + Incrementar;
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 34) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(172 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.pdf");
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
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
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
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllMarca._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Marcas", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    //Linhas do datagrid
                    int Incrementar = 0;
                    int ContadorPagina = 1;
                    int pagina = 4;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 9;
                    for (int i = 0; i < dtMarca.Rows.Count; i++)
                    {
                        if (i == 4)
                        {
                            TotalPaginas = TotalPaginas + 1;
                        }
                        else if (i == registros)
                        {
                            registros = registros + 5;
                            TotalPaginas = TotalPaginas + 1;
                        }
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //                    
                    for (int linha = 0; linha < dtMarca.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtMarca.Rows[linha];
                        if (linha < 4 & PrimeiraPagina == true)
                        {
                            if (linha == dtMarca.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 180 + Margem_Topo - 15, 45, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 198 + Margem_Topo - 15, 45, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 200 + Margem_Topo - 15, 40, page.Height));
                                //Descrição
                                graphics.DrawRectangle(pen, XBrushes.White, 50 + Margem_Esq, Incrementar + 180 + Margem_Topo - 15, 539, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 50 + Margem_Esq, Incrementar + 198 + Margem_Topo - 15, 539, 18);
                                textFormatter2.DrawString("Descrição:", fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 200 + Margem_Topo - 15, page.Width, page.Height));
                                //Tabela Destino
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 216 + Margem_Topo - 15, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 234 + Margem_Topo - 15, 584, 18);
                                textFormatter2.DrawString("Origem:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 236 + Margem_Topo - 15, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 216 + Margem_Topo - 15, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 234 + Margem_Topo - 15, 130, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 236 + Margem_Topo - 15, 40, page.Height));
                                //País
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 252 + Margem_Topo - 15, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 270 + Margem_Topo - 15, 584, 18);
                                textFormatter2.DrawString("País:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 272 + Margem_Topo - 15, page.Width, page.Height));
                                //Data Cadastro
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 252 + Margem_Topo - 15, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 270 + Margem_Topo - 15, 130, 18);
                                textFormatter2.DrawString("Data de Cadastro:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 272 + Margem_Topo - 15, 40, page.Height));
                                //
                            }
                            else
                            {
                                //Código
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 180 + Margem_Topo - 15, 45, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 198 + Margem_Topo - 15, 45, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 200 + Margem_Topo - 15, 40, page.Height));
                                //Descrição
                                graphics.DrawRectangle(pen, XBrushes.White, 50 + Margem_Esq, Incrementar + 180 + Margem_Topo - 15, 539, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 50 + Margem_Esq, Incrementar + 198 + Margem_Topo - 15, 539, 18);
                                textFormatter2.DrawString("Descrição:", fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 182 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 200 + Margem_Topo - 15, page.Width, page.Height));
                                //Tabela Destino
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 216 + Margem_Topo - 15, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 234 + Margem_Topo - 15, 584, 18);
                                textFormatter2.DrawString("Origem:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 236 + Margem_Topo - 15, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 216 + Margem_Topo - 15, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 234 + Margem_Topo - 15, 130, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 218 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 236 + Margem_Topo - 15, 40, page.Height));
                                //País
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 252 + Margem_Topo - 15, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 270 + Margem_Topo - 15, 584, 18);
                                textFormatter2.DrawString("País:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 272 + Margem_Topo - 15, page.Width, page.Height));
                                //Data Cadastro
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 252 + Margem_Topo - 15, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 270 + Margem_Topo - 15, 130, 18);
                                textFormatter2.DrawString("Data de Cadastro:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 254 + Margem_Topo - 15, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 272 + Margem_Topo - 15, 40, page.Height));
                                //
                                if (linha != 3)
                                {
                                    textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 307 - 15 + Margem_Topo, 5, 595));
                                }
                                //
                                Incrementar = 158 + Incrementar;//incrementando         
                            }
                            //
                            if (linha == (pagina - 1) & dtMarca.Rows.Count > 4)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 6;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                textFormatter1.DrawString("Relatório de Marcas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                pagina = pagina + 5;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                textFormatter1.DrawString("Relatório de Marcas", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtMarca.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                //Codigo
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 22 + Margem_Topo, 45, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 40 + Margem_Topo, 45, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 24 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 42 + Margem_Topo, 40, page.Height));
                                //Descrição
                                graphics.DrawRectangle(pen, XBrushes.White, 50 + Margem_Esq, Incrementar + 22 + Margem_Topo, 539, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 50 + Margem_Esq, Incrementar + 40 + Margem_Topo, 539, 18);
                                textFormatter2.DrawString("Descrição:", fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 24 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 42 + Margem_Topo, page.Width, page.Height));
                                //Tabela Destino
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 58 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 76 + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Origem:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 60 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 78 + Margem_Topo, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 58 + Margem_Topo, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 76 + Margem_Topo, 130, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 60 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 78 + Margem_Topo, 40, page.Height));
                                //País
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 94 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 112 + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("País:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 96 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 114 + Margem_Topo, page.Width, page.Height));
                                //Data Cadastro
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 94 + Margem_Topo, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 112 + Margem_Topo, 130, 18);
                                textFormatter2.DrawString("Data de Cadastro:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 96 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 114 + Margem_Topo, 40, page.Height));
                            }
                            else
                            {
                                //Codigo
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 22 + Margem_Topo, 45, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 40 + Margem_Topo, 45, 18);
                                textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 24 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 42 + Margem_Topo, 40, page.Height));
                                //Descrição
                                graphics.DrawRectangle(pen, XBrushes.White, 50 + Margem_Esq, Incrementar + 22 + Margem_Topo, 539, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 50 + Margem_Esq, Incrementar + 40 + Margem_Topo, 539, 18);
                                textFormatter2.DrawString("Descrição:", fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 24 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(52 + Margem_Esq, Incrementar + 42 + Margem_Topo, page.Width, page.Height));
                                //Tabela Destino
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 58 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 76 + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Origem:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 60 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 78 + Margem_Topo, page.Width, page.Height));
                                //Palavra-Chave
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 58 + Margem_Topo, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 76 + Margem_Topo, 130, 18);
                                textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 60 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 78 + Margem_Topo, 40, page.Height));
                                //País
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 94 + Margem_Topo, 584, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, Incrementar + 112 + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("País:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 96 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 114 + Margem_Topo, page.Width, page.Height));
                                //Data Cadastro
                                graphics.DrawRectangle(pen, XBrushes.White, 459 + Margem_Esq, Incrementar + 94 + Margem_Topo, 130, 18);
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 459 + Margem_Esq, Incrementar + 112 + Margem_Topo, 130, 18);
                                textFormatter2.DrawString("Data de Cadastro:", fonte4, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 96 + Margem_Topo, page.Width, page.Height));
                                textFormatter3.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(461 + Margem_Esq, Incrementar + 114 + Margem_Topo, 40, page.Height));
                                //
                                if (linha != (pagina - 2))
                                {
                                    textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 144 + Margem_Topo, 5, 595));
                                }
                                Incrementar = 148 + Incrementar;//incrementando       
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.pdf");
                    }
                }
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.txt"))
                {
                    writer.WriteLine("Relatório de Marcas" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToShortTimeString());
                    for (int linha = 0; linha < dtMarca.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtMarca.Rows[linha];
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Descrição: " + SelectedRow.Cells[1].Value.ToString() + " |Origem: " + SelectedRow.Cells[2].Value.ToString() + " |País: " + SelectedRow.Cells[3].Value.ToString() + " |Palavra-Chave: " + SelectedRow.Cells[4].Value.ToString() + " |Data de Cadastro: " + SelectedRow.Cells[5].Value.ToString().Remove(10));
                    }
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.txt");
            }
            else if (_Trabalho == 3)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Descrição;Origem;País;Palavra-Chave;Data de Cadastro");
                    for (int linha = 0; linha < dtMarca.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtMarca.Rows[linha];
                        //                        
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString().Remove(10)));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Marcas");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToShortTimeString());
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Marcas\Marcas.csv");
            }
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
            dtMarca.Enabled = false;
            dtMarca.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao2.Enabled = false;
            picbInterrogacao3.Enabled = false;
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
            dtMarca.Enabled = false;
            dtMarca.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao2.Enabled = false;
            picbInterrogacao3.Enabled = false;
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
            using (FrmDatePicker2 Data = new FrmDatePicker2(20))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllMarca._Data_DatePicker1;
                    mtxtpData1.Text = bllMarca._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(39))
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
                    dtMarca.Enabled = false;
                    dtMarca.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                    picbInterrogacao2.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }
    }
}
