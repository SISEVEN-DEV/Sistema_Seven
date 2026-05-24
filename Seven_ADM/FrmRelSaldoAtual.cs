using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelSaldoAtual : Form
    {
        public FrmRelSaldoAtual(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private bool _Contem_Imagem = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Trabalho;

        private void FrmConfCadComp_Load(object sender, EventArgs e)
        {
            try
            {
                bllProduto._FrmRelSaldoAtualEstoque_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaldoAtual iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaldoAtual iniciado.");
                }
                //
                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelSaldoAtual.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelSaldoAtual.");
                }
            }
        }

        private void Limpar_OutrosFiltros()
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            cbbUM.Text = null;
            txtPreco1.Text = null;
            txtPreco2.Text = null;
            cbbpLocalizacao.Text = null;
            cbbMarca.Text = null;
            txtSaldoAtual.Text = null;
            txtSaldoAtual1.Text = null;
            cbbpFornecedor.Text = null;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnBarra_MouseLeave(object sender, EventArgs e)
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

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnGrupo_MouseLeave(object sender, EventArgs e)
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

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbpSubGrupo.Enabled == true)
                {
                    cbbpSubGrupo.Select();
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarSub1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurarSub1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_MouseLeave(object sender, EventArgs e)
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

        private void cbbUM_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUM_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUM_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtPreco1_Enter(object sender, EventArgs e)
        {
            txtPreco1.BackColor = Color.LightBlue;
        }

        private void txtPreco2_Enter(object sender, EventArgs e)
        {
            txtPreco2.BackColor = Color.LightBlue;
        }

        private void cbbpLocalizacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpLocalizacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpLocalizacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpLocalizacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarLocalizacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarLocalizacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbMarca_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbMarca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbMarca_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbMarca_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarMarca_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarMarca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarForn_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarForn_MouseLeave(object sender, EventArgs e)
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

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorPrecoTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorPrecoTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorEstoqueTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorEstoqueTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioResumido_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioResumido_MouseLeave(object sender, EventArgs e)
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
                btnPesquisar.Select();
            }
        }

        private void txtpBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnBarra.Checked == true)
                {
                    if (txtpBarra.Text == "")
                    {
                        btnPesquisar.Select();
                    }
                    else if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpBarra.Text = null;
                        txtpBarra.Select();
                    }
                    else
                    {
                        try
                        {
                            if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "") == null)
                            {
                                dtProd.DataSource = null;
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "");
                                dtProd.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            txtpBarra.Text = null;
                            txtpBarra.Select();
                        }
                    }
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
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

        private void txtpBarra_Enter(object sender, EventArgs e)
        {
            txtpBarra.BackColor = Color.LightBlue;
        }

        private void txtpBarra_Leave(object sender, EventArgs e)
        {
            if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpBarra.Text = null;
                txtpBarra.Select();
            }
            txtpBarra.BackColor = Color.White;
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

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUM.Select();
            }
        }

        private void cbbUM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPreco1.Select();
            }
        }

        private void txtPreco1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPreco1.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtPreco2.Select();
            }
        }

        private void txtPreco2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPreco2.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbpLocalizacao.Select();
            }
        }

        private void cbbpLocalizacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbMarca.Select();
            }
        }

        private void cbbMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSaldoAtual.Select();
            }
        }

        private void txtSaldoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSaldoAtual.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (txtSaldoAtual.Text.Contains("-") && e.KeyChar == (char)45)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44) && !(e.KeyChar == (char)45))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSaldoAtual1.Select();
            }
        }

        private void txtSaldoAtual1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSaldoAtual1.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (txtSaldoAtual1.Text.Contains("-") && e.KeyChar == (char)45)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44) && !(e.KeyChar == (char)45))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbpFornecedor.Select();
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

        private void txtPreco1_Leave(object sender, EventArgs e)
        {
            if (txtPreco1.Text != "")
            {
                if (txtPreco1.Text.Contains("'") || txtPreco1.Text.Contains(";") || txtPreco1.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPreco1.Text = null;
                    txtPreco1.Select();
                }
                else
                {
                    try
                    {
                        txtPreco1.Text = Convert.ToDecimal(txtPreco1.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPreco1.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPreco1.");
                        }
                        txtPreco1.Text = null;
                    }
                }
            }
            txtPreco1.BackColor = Color.White;
        }

        private void txtPreco2_Leave(object sender, EventArgs e)
        {
            if (txtPreco2.Text != "")
            {
                if (txtPreco2.Text.Contains("'") || txtPreco2.Text.Contains(";") || txtPreco2.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPreco2.Text = null;
                    txtPreco2.Select();
                }
                else
                {
                    try
                    {
                        txtPreco2.Text = Convert.ToDecimal(txtPreco2.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPreco2.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPreco2.");
                        }
                        txtPreco2.Text = null;
                    }
                }
            }
            txtPreco2.BackColor = Color.White;
        }

        private void txtSaldoAtual_Leave(object sender, EventArgs e)
        {
            if (txtSaldoAtual.Text != "")
            {
                if (txtSaldoAtual.Text.Contains("'") || txtSaldoAtual.Text.Contains(";") || txtSaldoAtual.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSaldoAtual.Text = null;
                    txtSaldoAtual.Select();
                }
                else
                {
                    try
                    {
                        txtSaldoAtual.Text = Convert.ToDecimal(txtSaldoAtual.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSaldoAtual.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSaldoAtual.");
                        }
                        txtSaldoAtual.Text = null;
                    }
                }
            }
            txtSaldoAtual.BackColor = Color.White;

        }

        private void txtSaldoAtual_Enter(object sender, EventArgs e)
        {
            txtSaldoAtual.BackColor = Color.LightBlue;
        }

        private void txtSaldoAtual1_Leave(object sender, EventArgs e)
        {
            if (txtSaldoAtual1.Text != "")
            {
                if (txtSaldoAtual1.Text.Contains("'") || txtSaldoAtual1.Text.Contains(";") || txtSaldoAtual1.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSaldoAtual1.Text = null;
                    txtSaldoAtual1.Select();
                }
                else
                {
                    try
                    {
                        txtSaldoAtual1.Text = Convert.ToDecimal(txtSaldoAtual1.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSaldoAtual1.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSaldoAtual1.");
                        }
                        txtSaldoAtual1.Text = null;
                    }
                }
            }
            txtSaldoAtual1.BackColor = Color.White;
        }

        private void txtSaldoAtual1_Enter(object sender, EventArgs e)
        {
            txtSaldoAtual1.BackColor = Color.LightBlue;
        }

        private void FrmRelSaldoAtual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmRelSaldoAtual_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaldoAtual foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaldoAtual foi finalizado.");
                }
                bllProduto._FrmRelSaldoAtualEstoque_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelSaldoAtual.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelSaldoAtual.");
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

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            lblDataCadastro.Enabled = true;
            lblUN.Enabled = true;
            lblPreco.Enabled = true;
            lblLocalizacao.Enabled = true;
            lblMarca.Enabled = true;
            lblSaldo.Enabled = true;
            lblFornecedor.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblAte.Enabled = true;
            btnSelecionarData.Enabled = true;
            cbbUM.Enabled = true;
            txtPreco1.Enabled = true;
            txtPreco2.Enabled = true;
            lblAte1.Enabled = true;
            cbbpLocalizacao.Enabled = true;
            btnProcurarLocalizacao.Enabled = true;
            cbbMarca.Enabled = true;
            btnProcurarMarca.Enabled = true;
            txtSaldoAtual.Enabled = true;
            txtSaldoAtual1.Enabled = true;
            lblAte2.Enabled = true;
            cbbpFornecedor.Enabled = true;
            btnProcurarForn.Enabled = true;
            Limpar_OutrosFiltros();
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = true;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(340, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Text = null;
            txtpDescricao.Select();
            //
            try
            {
                cbbMarca.Items.Clear();
                if (bllProduto.Sel_Marca_Prod() == null)
                {
                    cbbMarca.Text = null;
                }
                else
                {
                    cbbMarca.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                    {
                        cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbpLocalizacao.Items.Clear();
                if (bllProduto.Sel_Localizacao_Prod() == null)
                {
                    cbbpLocalizacao.Text = null;
                }
                else
                {
                    cbbpLocalizacao.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                    {
                        cbbpLocalizacao.Items.Add((dr["id_localizacao"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbpFornecedor.Items.Clear();
                if (bllProduto.Sel_Fornecedor_Prod() == null)
                {
                    cbbpFornecedor.Text = null;
                }
                else
                {
                    cbbpFornecedor.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Fornecedor_Prod().Rows)
                    {
                        cbbpFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do rbtDescricao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do rbtDescricao.");
                }
                cbbpLocalizacao.Text = null;
                cbbMarca.Text = null;
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblDataCadastro.Enabled = true;
            lblUN.Enabled = true;
            lblPreco.Enabled = true;
            lblLocalizacao.Enabled = true;
            lblMarca.Enabled = true;
            lblSaldo.Enabled = true;
            lblFornecedor.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblAte.Enabled = true;
            btnSelecionarData.Enabled = true;
            cbbUM.Enabled = true;
            txtPreco1.Enabled = true;
            txtPreco2.Enabled = true;
            lblAte1.Enabled = true;
            cbbpLocalizacao.Enabled = true;
            btnProcurarLocalizacao.Enabled = true;
            cbbMarca.Enabled = true;
            btnProcurarMarca.Enabled = true;
            txtSaldoAtual.Enabled = true;
            txtSaldoAtual1.Enabled = true;
            lblAte2.Enabled = true;
            cbbpFornecedor.Enabled = true;
            btnProcurarForn.Enabled = true;
            Limpar_OutrosFiltros();
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(619, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
            mtxtpData.Text = "01/01/2020";
            mtxtpData1.Text = DateTime.Now.ToShortDateString();
            //
            try
            {
                cbbMarca.Items.Clear();
                if (bllProduto.Sel_Marca_Prod() == null)
                {
                    cbbMarca.Text = null;
                }
                else
                {
                    cbbMarca.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                    {
                        cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbpLocalizacao.Items.Clear();
                if (bllProduto.Sel_Localizacao_Prod() == null)
                {
                    cbbpLocalizacao.Text = null;
                }
                else
                {
                    cbbpLocalizacao.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                    {
                        cbbpLocalizacao.Items.Add((dr["id_localizacao"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbpFornecedor.Items.Clear();
                if (bllProduto.Sel_Fornecedor_Prod() == null)
                {
                    cbbpFornecedor.Text = null;
                }
                else
                {
                    cbbpFornecedor.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Fornecedor_Prod().Rows)
                    {
                        cbbpFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do rbtDescricao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do rbtDescricao.");
                }
                cbbpLocalizacao.Text = null;
                cbbMarca.Text = null;
            }
        }

        private void rbtnBarra_CheckedChanged(object sender, EventArgs e)
        {
            lblDataCadastro.Enabled = false;
            lblUN.Enabled = false;
            lblPreco.Enabled = false;
            lblLocalizacao.Enabled = false;
            lblMarca.Enabled = false;
            lblSaldo.Enabled = false;
            lblFornecedor.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            btnSelecionarData.Enabled = false;
            cbbUM.Enabled = false;
            txtPreco1.Enabled = false;
            txtPreco2.Enabled = false;
            lblAte1.Enabled = false;
            cbbpLocalizacao.Enabled = false;
            btnProcurarLocalizacao.Enabled = false;
            cbbMarca.Enabled = false;
            btnProcurarMarca.Enabled = false;
            txtSaldoAtual.Enabled = false;
            txtSaldoAtual1.Enabled = false;
            lblAte2.Enabled = false;
            cbbpFornecedor.Enabled = false;
            btnProcurarForn.Enabled = false;
            Limpar_OutrosFiltros();
            txtpBarra.MaxLength = 60;
            txtpBarra.CharacterCasing = CharacterCasing.Normal;
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = true;
            lblPesquisar.Location = new Point(415, 21);
            lblPesquisar.Text = "Digite o código de barras:";
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblDataCadastro.Enabled = false;
            lblUN.Enabled = false;
            lblPreco.Enabled = false;
            lblLocalizacao.Enabled = false;
            lblMarca.Enabled = false;
            lblSaldo.Enabled = false;
            lblFornecedor.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            btnSelecionarData.Enabled = false;
            cbbUM.Enabled = false;
            txtPreco1.Enabled = false;
            txtPreco2.Enabled = false;
            lblAte1.Enabled = false;
            cbbpLocalizacao.Enabled = false;
            btnProcurarLocalizacao.Enabled = false;
            cbbMarca.Enabled = false;
            btnProcurarMarca.Enabled = false;
            txtSaldoAtual.Enabled = false;
            txtSaldoAtual1.Enabled = false;
            lblAte2.Enabled = false;
            cbbpFornecedor.Enabled = false;
            btnProcurarForn.Enabled = false;
            Limpar_OutrosFiltros();
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = true;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(567, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            lblDataCadastro.Enabled = false;
            lblUN.Enabled = false;
            lblPreco.Enabled = false;
            lblLocalizacao.Enabled = false;
            lblMarca.Enabled = false;
            lblSaldo.Enabled = false;
            lblFornecedor.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            btnSelecionarData.Enabled = false;
            cbbUM.Enabled = false;
            txtPreco1.Enabled = false;
            txtPreco2.Enabled = false;
            lblAte1.Enabled = false;
            cbbpLocalizacao.Enabled = false;
            btnProcurarLocalizacao.Enabled = false;
            cbbMarca.Enabled = false;
            btnProcurarMarca.Enabled = false;
            txtSaldoAtual.Enabled = false;
            txtSaldoAtual1.Enabled = false;
            lblAte2.Enabled = false;
            cbbpFornecedor.Enabled = false;
            btnProcurarForn.Enabled = false;
            Limpar_OutrosFiltros();
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = true;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(524, 21);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnGrupo_CheckedChanged(object sender, EventArgs e)
        {
            lblDataCadastro.Enabled = true;
            lblUN.Enabled = true;
            lblPreco.Enabled = true;
            lblLocalizacao.Enabled = true;
            lblMarca.Enabled = true;
            lblSaldo.Enabled = true;
            lblFornecedor.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblAte.Enabled = true;
            btnSelecionarData.Enabled = true;
            cbbUM.Enabled = true;
            txtPreco1.Enabled = true;
            txtPreco2.Enabled = true;
            lblAte1.Enabled = true;
            cbbpLocalizacao.Enabled = true;
            btnProcurarLocalizacao.Enabled = true;
            cbbMarca.Enabled = true;
            btnProcurarMarca.Enabled = true;
            txtSaldoAtual.Enabled = true;
            txtSaldoAtual1.Enabled = true;
            lblAte2.Enabled = true;
            cbbpFornecedor.Enabled = true;
            btnProcurarForn.Enabled = true;
            Limpar_OutrosFiltros();
            cbbpSubGrupo.Text = null;
            btnpProcurar.Visible = true;
            btnpProcurarSub1.Visible = true;
            cbbpSubGrupo.Visible = true;
            cbbpSubGrupo.Enabled = false;
            btnpProcurarSub1.Enabled = false;
            lblSubGrupo1.Visible = true;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(366, 21);
            lblPesquisar.Text = "Escolha o grupo:";
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Text = null;
            cbbpGrupo.Select();
            //
            try
            {
                cbbpGrupo.Items.Clear();
                if (bllProduto.Sel_Grupo_Prod() == null)
                {
                    cbbpGrupo.Text = null;
                }
                else
                {
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbMarca.Items.Clear();
                if (bllProduto.Sel_Marca_Prod() == null)
                {
                    cbbMarca.Text = null;
                }
                else
                {
                    cbbMarca.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                    {
                        cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbpLocalizacao.Items.Clear();
                if (bllProduto.Sel_Localizacao_Prod() == null)
                {
                    cbbpLocalizacao.Text = null;
                }
                else
                {
                    cbbpLocalizacao.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                    {
                        cbbpLocalizacao.Items.Add((dr["id_localizacao"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbpFornecedor.Items.Clear();
                if (bllProduto.Sel_Fornecedor_Prod() == null)
                {
                    cbbpFornecedor.Text = null;
                }
                else
                {
                    cbbpFornecedor.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Fornecedor_Prod().Rows)
                    {
                        cbbpFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do rbtnGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do rbtnGrupo.");
                }
                cbbMarca.Text = null;
                cbbpLocalizacao.Text = null;
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, código de barras, grupo e sub-grupo, palavra-chave, todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProcurarMarca_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmPesqMarca Marca = new FrmPesqMarca(0, _Usuario, _Cod_PDV_Computador))
            {
                if (Marca.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbMarca.Items.Clear();
                        if (bllProduto.Sel_Marca_Prod() == null)
                        {
                            cbbMarca.Text = null;
                        }
                        else
                        {
                            cbbMarca.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                            {
                                cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbMarca.Text = bllProduto._Marca_PesqMarca_Tabela;
                        bllProduto._Marca_PesqMarca_Tabela = null;
                        cbbMarca.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar3.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar3.");
                        }
                        cbbMarca.Text = null;
                    }
                }
            }
            pPanel.Enabled = true;
        }

        private void btnProcurarLocalizacao_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmPesqLocalizacao Localizacao = new FrmPesqLocalizacao(0))
            {
                if (Localizacao.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpLocalizacao.Items.Clear();
                        if (bllProduto.Sel_Localizacao_Prod() == null)
                        {
                            cbbpLocalizacao.Text = null;
                        }
                        else
                        {
                            cbbpLocalizacao.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                            {
                                cbbpLocalizacao.Items.Add((dr["id_localizacao"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbpLocalizacao.Text = bllProduto._Localizacao_PesqLocalizacao_Tabela;
                        bllProduto._Localizacao_PesqLocalizacao_Tabela = null;
                        cbbpLocalizacao.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar4.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar4.");
                        }
                        cbbpLocalizacao.Text = null;
                    }
                }
            }
            pPanel.Enabled = true;
        }

        private void btnProcurarForn_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(0, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpFornecedor.Items.Clear();
                        if (bllProduto.Sel_Fornecedor_Prod() == null)
                        {
                            cbbpFornecedor.Text = null;
                        }
                        else
                        {
                            cbbpFornecedor.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Fornecedor_Prod().Rows)
                            {
                                cbbpFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        //
                        cbbpFornecedor.Text = bllProduto._Fornecedor_PesqFornecedor_Tabela;
                        bllProduto._Fornecedor_PesqFornecedor_Tabela = null;
                        cbbpFornecedor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForn.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForn.");
                        }
                        cbbpFornecedor.Text = null;
                    }
                }
            }
            pPanel.Enabled = true;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(4))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllProduto._Data_DatePicker1;
                    mtxtpData1.Text = bllProduto._Data_DatePicker2;
                }
            }
            pPanel.Enabled = true;
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(0))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllProduto.Sel_Grupo_Prod() == null)
                        {
                            cbbpGrupo.Text = null;
                            cbbpSubGrupo.Enabled = false;
                            cbbpSubGrupo.Text = null;
                            btnpProcurarSub1.Enabled = false;
                            lblSubGrupo1.Enabled = false;
                        }
                        else
                        {
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                            {
                                cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbpSubGrupo.Enabled = true;
                                btnpProcurarSub1.Enabled = true;
                                lblSubGrupo1.Enabled = true;
                            }
                        }

                        cbbpGrupo.Text = bllProduto._Grupo_PesqGrupo_Tabela;
                        bllProduto._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        cbbpGrupo.Text = null;
                    }
                }
            }
            pPanel.Enabled = true;
        }

        private void btnpProcurarSub1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    pPanel.Enabled = false;
                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 0))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();

                            if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbpSubGrupo.Text = bllProduto._SubGrupo_PesqSubGrupo_Tabela;
                            bllProduto._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbpSubGrupo.Select();
                        }
                    }
                    pPanel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                cbbpSubGrupo.Text = null;
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
                            this.DialogResult = DialogResult.None;
                            mtxtpData.Select();
                            return;
                        }

                        if (txtPreco1.Text != "" & txtPreco2.Text != "")
                        {
                            if (Convert.ToDecimal(txtPreco1.Text) > Convert.ToDecimal(txtPreco2.Text))
                            {
                                MessageBox.Show("É necessário preencher o primeiro campo de preço com o valor mínimo e o segundo campo com o valor máximo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPreco1.Select();
                                return;
                            }
                        }
                        //
                        if (txtSaldoAtual.Text != "" & txtSaldoAtual1.Text != "")
                        {
                            if (Convert.ToDecimal(txtSaldoAtual.Text) > Convert.ToDecimal(txtSaldoAtual1.Text))
                            {
                                MessageBox.Show("É necessário preencher o primeiro campo de saldo atual com o valor mínimo e o segundo campo com o valor máximo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPreco1.Select();
                                return;
                            }
                        }
                        //
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, txtpDescricao.Text) == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            if (cbbpFornecedor.Text != "")
                            {
                                for (int i = 0; i < bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, txtpDescricao.Text).Rows.Count; i++)
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, txtpDescricao.Text).Rows[i];
                                    //
                                    if (dr["id_fornecedor"].ToString() != "")
                                    {
                                        dtProd.DataSource = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, txtpDescricao.Text);
                                        dtProd.Select();
                                        //
                                        for (int a = 0; a < dtProd.Rows.Count; a++)
                                        {
                                            if (cbbpFornecedor.Text != "")
                                            {
                                                if (dtProd.Rows[a].Cells[30].Value.ToString() == "")
                                                {
                                                    dtProd.Rows.RemoveAt(a);
                                                    a--;
                                                }
                                            }
                                        }
                                        //
                                        if (dtProd.Rows.Count == 0)
                                        {
                                            dtProd.DataSource = null;
                                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            decimal valorsaldo = 0;
                                            for (int x = 0; x < dtProd.Rows.Count; x++)
                                            {
                                                valorsaldo += Convert.ToDecimal(dtProd.Rows[x].Cells[17].Value);
                                            }
                                            //
                                            decimal valorpreco = 0;
                                            for (int z = 0; z < dtProd.Rows.Count; z++)
                                            {
                                                valorpreco += Convert.ToDecimal(dtProd.Rows[z].Cells[3].Value);
                                            }
                                            //
                                            lblRegistros.Text = "Registros: " + dtProd.Rows.Count;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        dtProd.DataSource = null;
                                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, txtpDescricao.Text);
                                dtProd.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnBarra.Checked == true)
                {
                    if (txtpBarra.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    if (cbbpGrupo.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData.Select();
                            return;
                        }

                        if (txtPreco1.Text != "" & txtPreco2.Text != "")
                        {
                            if (Convert.ToDecimal(txtPreco1.Text) > Convert.ToDecimal(txtPreco2.Text))
                            {
                                MessageBox.Show("É necessário preencher o primeiro campo de preço com o valor mínimo e o segundo campo com o valor máximo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPreco1.Select();
                                return;
                            }
                        }
                        //
                        if (txtSaldoAtual.Text != "" & txtSaldoAtual1.Text != "")
                        {
                            if (Convert.ToDecimal(txtSaldoAtual.Text) > Convert.ToDecimal(txtSaldoAtual1.Text))
                            {
                                MessageBox.Show("É necessário preencher o primeiro campo de saldo atual com o valor mínimo e o segundo campo com o valor máximo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPreco1.Select();
                                return;
                            }
                        }
                        //
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, cbbpGrupo.Text, cbbpSubGrupo.Text) == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            if (cbbpFornecedor.Text != "")
                            {
                                for (int i = 0; i < bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, cbbpGrupo.Text, cbbpSubGrupo.Text).Rows.Count; i++)
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, cbbpGrupo.Text, cbbpSubGrupo.Text).Rows[i];
                                    //
                                    if (dr["id_fornecedor"].ToString() != "")
                                    {
                                        dtProd.DataSource = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, cbbpGrupo.Text, cbbpSubGrupo.Text);
                                        dtProd.Select();
                                        //
                                        for (int a = 0; a < dtProd.Rows.Count; a++)
                                        {
                                            if (cbbpFornecedor.Text != "")
                                            {
                                                if (dtProd.Rows[a].Cells[30].Value.ToString() == "")
                                                {
                                                    dtProd.Rows.RemoveAt(a);
                                                    a--;
                                                }
                                            }
                                        }
                                        //
                                        if (dtProd.Rows.Count == 0)
                                        {
                                            dtProd.DataSource = null;
                                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            decimal valorsaldo = 0;
                                            for (int x = 0; x < dtProd.Rows.Count; x++)
                                            {
                                                valorsaldo += Convert.ToDecimal(dtProd.Rows[x].Cells[17].Value);
                                            }
                                            //
                                            decimal valorpreco = 0;
                                            for (int z = 0; z < dtProd.Rows.Count; z++)
                                            {
                                                valorpreco += Convert.ToDecimal(dtProd.Rows[z].Cells[3].Value);
                                            }
                                            //                                         
                                            lblRegistros.Text = "Registros: " + dtProd.Rows.Count;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        dtProd.DataSource = null;
                                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text, cbbpGrupo.Text, cbbpSubGrupo.Text);
                                dtProd.Select();
                            }
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
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                        return;
                    }
                    else
                    {
                        if (txtPreco1.Text != "" & txtPreco2.Text != "")
                        {
                            if (Convert.ToDecimal(txtPreco1.Text) > Convert.ToDecimal(txtPreco2.Text))
                            {
                                MessageBox.Show("É necessário preencher o primeiro campo de preço com o valor mínimo e o segundo campo com o valor máximo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPreco1.Select();
                                return;
                            }
                        }
                        //
                        if (txtSaldoAtual.Text != "" & txtSaldoAtual1.Text != "")
                        {
                            if (Convert.ToDecimal(txtSaldoAtual.Text) > Convert.ToDecimal(txtSaldoAtual1.Text))
                            {
                                MessageBox.Show("É necessário preencher o primeiro campo de saldo atual com o valor mínimo e o segundo campo com o valor máximo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPreco1.Select();
                                return;
                            }
                        }
                        //
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text) == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            if (cbbpFornecedor.Text != "")
                            {
                                for (int i = 0; i < bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text).Rows.Count; i++)
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text).Rows[i];
                                    //
                                    if (dr["id_fornecedor"].ToString() != "")
                                    {
                                        dtProd.DataSource = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text);
                                        dtProd.Select();
                                        //
                                        for (int a = 0; a < dtProd.Rows.Count; a++)
                                        {
                                            if (cbbpFornecedor.Text != "")
                                            {
                                                if (dtProd.Rows[a].Cells[30].Value.ToString() == "")
                                                {
                                                    dtProd.Rows.RemoveAt(a);
                                                    a--;
                                                }
                                            }
                                        }
                                        //
                                        if (dtProd.Rows.Count == 0)
                                        {
                                            dtProd.DataSource = null;
                                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            decimal valorsaldo = 0;
                                            for (int x = 0; x < dtProd.Rows.Count; x++)
                                            {
                                                valorsaldo += Convert.ToDecimal(dtProd.Rows[x].Cells[17].Value);
                                            }
                                            //
                                            decimal valorpreco = 0;
                                            for (int z = 0; z < dtProd.Rows.Count; z++)
                                            {
                                                valorpreco += Convert.ToDecimal(dtProd.Rows[z].Cells[3].Value);
                                            }
                                            //                                          
                                            lblRegistros.Text = "Registros: " + dtProd.Rows.Count;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        dtProd.DataSource = null;
                                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(mtxtpData.Text, mtxtpData1.Text, txtPreco1.Text.Trim(), txtPreco2.Text.Trim(), cbbpLocalizacao.Text, cbbUM.Text, txtSaldoAtual.Text.Trim(), txtSaldoAtual1.Text.Trim(), cbbMarca.Text, cbbpFornecedor.Text);
                                dtProd.Select();
                            }
                        }
                    }
                }
                //
                for (int a = 0; a < dtProd.Rows.Count; a++)
                {
                    if (Convert.ToInt32(dtProd.Rows[a].Cells[32].Value.ToString()) > 1)
                    {
                        dtProd.Rows[a].Cells[30].Value = "0";
                        dtProd.Rows[a].Cells[31].Value = "Este produto possui " + dtProd.Rows[a].Cells[32].Value.ToString() + " fornecedores.";
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
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
                dtProd.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtProd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtProd.Columns[0].HeaderText = "Código";
                dtProd.Columns[1].HeaderText = "Descrição";
                dtProd.Columns[2].HeaderText = "UM";
                dtProd.Columns[3].HeaderText = "Preço (R$)";
                dtProd.Columns[4].HeaderText = "Cód. da Marca";
                dtProd.Columns[5].HeaderText = "Descrição da Marca";
                dtProd.Columns[6].HeaderText = "Cód. do Grupo";
                dtProd.Columns[7].HeaderText = "Descrição do Grupo";
                dtProd.Columns[8].HeaderText = "Cód. do Sub-grupo";
                dtProd.Columns[9].HeaderText = "Descrição do Sub-grupo";
                dtProd.Columns[10].HeaderText = "Código de Barras*";
                dtProd.Columns[11].HeaderText = "Referência";
                dtProd.Columns[12].HeaderText = "Cód. da Localização";
                dtProd.Columns[13].HeaderText = "Descrição da Localização";
                dtProd.Columns[14].Visible = false;
                dtProd.Columns[15].Visible = false;
                dtProd.Columns[16].Visible = false;
                dtProd.Columns[17].HeaderText = "Saldo Atual";
                dtProd.Columns[18].HeaderText = "Observações";
                dtProd.Columns[19].Visible = false;
                dtProd.Columns[20].Visible = false;
                dtProd.Columns[21].Visible = false;
                dtProd.Columns[22].Visible = false;
                dtProd.Columns[23].Visible = false;
                dtProd.Columns[24].Visible = false;
                dtProd.Columns[25].HeaderText = "NCM";
                dtProd.Columns[26].HeaderText = "CST";
                dtProd.Columns[27].HeaderText = "Alíquota (%)";
                dtProd.Columns[28].HeaderText = "CSOSN";
                dtProd.Columns[29].HeaderText = "CEST";
                //
                if (rbtnCodigo.Checked == true || rbtnPalavraChave.Checked == true || rbtnBarra.Checked == true)
                {
                    dtProd.Columns[30].Visible = false;
                    dtProd.Columns[31].Visible = false;
                    dtProd.Columns[32].Visible = false;
                    dtProd.Columns[33].HeaderText = "Ex.";
                    dtProd.Columns[34].HeaderText = "CST IBS/CBS";
                    dtProd.Columns[35].HeaderText = "Cód. Sit. Trib. (cClassTrib)";
                    dtProd.Columns[36].HeaderText = "Alíq. IBS Mun. (%)";
                    dtProd.Columns[37].HeaderText = "Alíq. IBS Est. (%)";
                    dtProd.Columns[38].HeaderText = "Alíq. CBS (%)";
                    //
                    dtProd.Columns[33].Width = 46;
                    dtProd.Columns[34].Width = 125;
                    dtProd.Columns[35].Width = 175;
                    dtProd.Columns[36].Width = 125;
                    dtProd.Columns[37].Width = 125;
                    dtProd.Columns[38].Width = 110;
                    //
                    dtProd.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dtProd.Columns[30].HeaderText = "Ex.";
                    dtProd.Columns[31].HeaderText = "CST IBS/CBS";
                    dtProd.Columns[32].HeaderText = "Cód. Sit. Trib. (cClassTrib)";
                    dtProd.Columns[33].HeaderText = "Alíq. IBS Mun. (%)";
                    dtProd.Columns[34].HeaderText = "Alíq. IBS Est. (%)";
                    dtProd.Columns[35].HeaderText = "Alíq. CBS (%)";
                    //
                    dtProd.Columns[30].Width = 46;
                    dtProd.Columns[31].Width = 125;
                    dtProd.Columns[32].Width = 175;
                    dtProd.Columns[33].Width = 125;
                    dtProd.Columns[34].Width = 125;
                    dtProd.Columns[35].Width = 110;
                    //
                    dtProd.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dtProd.Columns[0].Width = 85;
                dtProd.Columns[1].Width = 320;
                dtProd.Columns[2].Width = 46;
                dtProd.Columns[3].Width = 155;
                dtProd.Columns[4].Width = 115;
                dtProd.Columns[5].Width = 250;
                dtProd.Columns[6].Width = 115;
                dtProd.Columns[7].Width = 325;
                dtProd.Columns[8].Width = 125;
                dtProd.Columns[9].Width = 325;
                dtProd.Columns[10].Width = 325;
                dtProd.Columns[11].Width = 85;
                dtProd.Columns[12].Width = 135;
                dtProd.Columns[13].Width = 325;
                dtProd.Columns[15].Width = 125;
                dtProd.Columns[16].Width = 125;
                dtProd.Columns[17].Width = 95;
                dtProd.Columns[18].Width = 500;
                dtProd.Columns[19].Width = 95;
                dtProd.Columns[21].Width = 150;
                dtProd.Columns[22].Width = 150;
                dtProd.Columns[25].Width = 110;
                dtProd.Columns[26].Width = 90;
                dtProd.Columns[27].Width = 110;
                dtProd.Columns[28].Width = 90;
                dtProd.Columns[29].Width = 110;

                dtProd.DefaultCellStyle.Font = new Font(dtProd.Font, FontStyle.Bold);

                dtProd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRegistros.Text = "Registros: " + dtProd.Rows.Count;

                decimal valorsaldo = 0;
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dtProd.Rows[i].Cells[17].Value) > 0)
                    {
                        valorsaldo += Convert.ToDecimal(dtProd.Rows[i].Cells[17].Value);
                    }
                }
                lblValorEstoqueTotal.Text = Convert.ToDecimal(valorsaldo).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valorpreco = 0;
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    valorpreco += Convert.ToDecimal(dtProd.Rows[i].Cells[3].Value);
                }
                lblValorPrecoTotal.Text = Convert.ToDecimal(valorpreco).ToString("n2", new CultureInfo("pt-BR"));
                //
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    if (bllProduto.Sel_Dest_Est_Negativo_Prod(dtProd.Rows[i].Cells[0].Value.ToString()) == true)
                    {
                        dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (bllProduto.Sel_Alert_Est_Max_Min_Prod(dtProd.Rows[i].Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(dtProd.Rows[i].Cells[0].Value.ToString(), "1"))
                        {
                            dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                dtProd.DataSource = null;
            }
        }

        private void dtProd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorPrecoTotal.Text = null;
            lblValorEstoqueTotal.Text = null;
        }

        private void dtProd_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtProd_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtProd_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                pcibImagem.Image = null;
                _Contem_Imagem = false;
                lblLegendaImagem.Visible = false;
                pcibAjudaFoto.Enabled = false;
                dtProd.Enabled = true;
                grbBox2.Enabled = false;
                pcibImagem.Enabled = false;
                lblPrecoTotal.Enabled = false;
                lblValorPrecoTotal.Enabled = false;
                lblEstTotal.Enabled = false;
                lblValorEstoqueTotal.Enabled = false;
            }
            else
            {
                pcibImagem.Enabled = true;
                _Contem_Imagem = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                dtProd.Enabled = true;
                grbBox2.Enabled = true;
                lblPrecoTotal.Enabled = true;
                lblValorPrecoTotal.Enabled = true;
                lblEstTotal.Enabled = true;
                lblValorEstoqueTotal.Enabled = true;
            }
        }

        private void dtProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                dtProd.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtProd.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtProd.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[3].DefaultCellStyle.Format = "n2";
                dtProd.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[15].DefaultCellStyle.Format = "n2";
                dtProd.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[16].DefaultCellStyle.Format = "n2";
                dtProd.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[17].DefaultCellStyle.Format = "n2";
                dtProd.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[21].DefaultCellStyle.Format = "n2";
                dtProd.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[22].DefaultCellStyle.Format = "n2";
                dtProd.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[27].DefaultCellStyle.Format = "n2";
                //
                if (rbtnCodigo.Checked == true || rbtnPalavraChave.Checked == true || rbtnBarra.Checked == true)
                {
                    dtProd.Columns[36].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[36].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[37].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[37].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[38].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[38].DefaultCellStyle.Format = "n2";
                }
                else
                {
                    dtProd.Columns[33].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[33].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[34].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[34].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[35].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[35].DefaultCellStyle.Format = "n2";
                }
                //
                if (SelectedRow.Cells[14].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                rbtnDescricao.Checked = true;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = false;
                _Contem_Imagem = false;
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

        private void lblValorPrecoTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Preço Total (R$): " + lblValorPrecoTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblValorEstoqueTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Estoque Total: " + lblValorEstoqueTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 12 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 30 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);

            if (dtProd.DataSource != null)
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
            if (dtProd.DataSource != null)
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

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtProd.DataSource != null)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblLegendaImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblLegendaImagem.");
                }
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtProd.DataSource != null)
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

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbbpGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.SelectedItem.ToString().Split('—');
                    cbbpSubGrupo.Items.Clear();
                    if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnpProcurarSub1.Enabled = false;
                        lblSubGrupo1.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            cbbpSubGrupo.Enabled = true;
                            btnpProcurarSub1.Enabled = true;
                            lblSubGrupo1.Enabled = true;
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnpProcurarSub1.Enabled = false;
                    lblSubGrupo1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
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
                dtProd.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
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
                rbtnDescricao.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                dtProd.Enabled = true;
                dtProd.Select();
                //
                try
                {
                    if (_Trabalho == 0)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saldo Atual\SaldoAtual.pdf");
                    }
                    else if (_Trabalho == 1)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contabil Atual\ContabilAtual.pdf");
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
                    dtProd.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnDescricao.Checked = true;
                }
            }
        }

        private void bckwIndeterminado_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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
                    if (bllProduto._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Saldo Atual de Estoque", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO   DESCRIÇÃO                  UM    PREÇO (R$)    SALDO ATUAL    LOCALIZAÇÃO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 15;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 35;
                    for (int i = 0; i < dtProd.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtProd.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[linha];
                        if (linha < 15 & PrimeiraPagina == true)
                        {
                            if (linha == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Saldo Atual:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Localização:", fonte2, XBrushes.Black, new XRect(330 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[12].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString() + "-" + SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(382 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Preço Total (R$): " + lblValorPrecoTotal.Text + "                                                                                                              Estoque Total: " + lblValorEstoqueTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Saldo Atual:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Localização:", fonte2, XBrushes.Black, new XRect(330 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[12].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString() + "-" + SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(382 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                Incrementar = 36 + Incrementar;//incrementando                 
                            }
                            //
                            if (linha == (pagina - 1) & dtProd.Rows.Count > 15)
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
                                textFormatter1.DrawString("Relatório de Saldo Atual de Estoque", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Saldo Atual de Estoque", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Saldo Atual:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Localização:", fonte2, XBrushes.Black, new XRect(330 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[12].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString() + "-" + SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(382 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Preço Total (R$): " + lblValorPrecoTotal.Text + "                                                                                                              Estoque Total: " + lblValorEstoqueTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando       
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Saldo Atual:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Localização:", fonte2, XBrushes.Black, new XRect(330 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[12].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString() + "-" + SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(382 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saldo Atual"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saldo Atual");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saldo Atual\SaldoAtual.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saldo Atual\SaldoAtual.pdf");
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
                    if (bllProduto._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Saldo Atual de Estoque", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO   DESCRIÇÃO                  UM    PREÇO (R$)    NCM/CEST    CST/CSOSN    ALÍQUOTA", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 15;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 35;
                    for (int i = 0; i < dtProd.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtProd.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[linha];

                        if (linha < 15 & PrimeiraPagina == true)
                        {
                            if (linha == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("NCM/CEST:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                string cest = null;
                                if (SelectedRow.Cells[29].Value.ToString() != "")
                                {
                                    cest = " - " + SelectedRow.Cells[29].Value.ToString();
                                }
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString() + cest, fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("CST/CSOSN:", fonte2, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[26].Value.ToString() + "-" + SelectedRow.Cells[28].Value.ToString(), fonte4, XBrushes.Black, new XRect(422 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Alíquota:", fonte2, XBrushes.Black, new XRect(480 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("NCM/CEST:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                string cest = null;
                                if (SelectedRow.Cells[29].Value.ToString() != "")
                                {
                                    cest = " - " + SelectedRow.Cells[29].Value.ToString();
                                }
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString() + cest, fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("CST/CSOSN:", fonte2, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[26].Value.ToString() + "-" + SelectedRow.Cells[28].Value.ToString(), fonte4, XBrushes.Black, new XRect(422 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Alíquota:", fonte2, XBrushes.Black, new XRect(480 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                 
                            }
                            //
                            if (linha == (pagina - 1) & dtProd.Rows.Count > 15)
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
                                textFormatter1.DrawString("Relatório de Saldo Atual de Estoque", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Saldo Atual de Estoque", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("NCM/CEST:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                string cest = null;
                                if (SelectedRow.Cells[29].Value.ToString() != "")
                                {
                                    cest = " - " + SelectedRow.Cells[29].Value.ToString();
                                }
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString() + cest, fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("CST/CSOSN:", fonte2, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[26].Value.ToString() + "-" + SelectedRow.Cells[28].Value.ToString(), fonte4, XBrushes.Black, new XRect(422 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Alíquota:", fonte2, XBrushes.Black, new XRect(480 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando       
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Descrição:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(146 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Unid. de Medida:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(79 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Preço (R$):", fonte2, XBrushes.Black, new XRect(110 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(162 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("NCM/CEST:", fonte2, XBrushes.Black, new XRect(220 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                string cest = null;
                                if (SelectedRow.Cells[29].Value.ToString() != "")
                                {
                                    cest = " - " + SelectedRow.Cells[29].Value.ToString();
                                }
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString() + cest, fonte4, XBrushes.Black, new XRect(273 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("CST/CSOSN:", fonte2, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[26].Value.ToString() + "-" + SelectedRow.Cells[28].Value.ToString(), fonte4, XBrushes.Black, new XRect(422 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Alíquota:", fonte2, XBrushes.Black, new XRect(480 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contabil Atual"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contabil Atual");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contabil Atual\ContabilAtual.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contabil Atual\ContabilAtual.pdf");
                    }
                }
            }
        }

        private void btnRelatorioResumido_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(22))
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
                    dtProd.Enabled = false;
                    dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir o relatório em PDF.\n\n2 - Exp. dados para (.csv): Clique para gerar em arquivo excel o relatório.\n\n3 - Exp. dados para (.txt): Clique para gerar em arquivo texto o relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPositivos_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(22))
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
                    dtProd.Enabled = false;
                    dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void btnNegativos_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(22))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 2;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtProd.Enabled = false;
                    dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void btnZerado_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(22))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 3;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtProd.Enabled = false;
                    dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void btnPositivos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPositivos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
