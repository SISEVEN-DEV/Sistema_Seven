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
    public partial class FrmRelEntradasProdutos : Form
    {
        public FrmRelEntradasProdutos(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Trabalho;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmRelFornecedoresProd_Load(object sender, EventArgs e)
        {
            try
            {
                bllEntradasProdutos._FrmRelEntradasProdutos_Aberto = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelEntradasProdutos iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelEntradasProdutos iniciado.");
                }
                //
                cbbProduto.Items.Clear();
                if (bllEntradasProdutos.Sel_Produtos_FornProd() == null)
                {
                    cbbProduto.Enabled = false;
                    cbbProduto.Text = null;
                }
                else
                {
                    cbbProduto.Enabled = true;
                    cbbProduto.Items.Add("");
                    foreach (DataRow dr in bllEntradasProdutos.Sel_Produtos_FornProd().Rows)
                    {
                        cbbProduto.Items.Add(dr["id_produto"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                cbbFornecedor.Items.Clear();
                if (bllEntradasProdutos.Sel_Fornecedor_FornProd() == null)
                {
                    cbbFornecedor.Enabled = false;
                    cbbFornecedor.Text = null;
                }
                else
                {
                    cbbFornecedor.Enabled = true;
                    cbbFornecedor.Items.Add("");
                    foreach (DataRow dr in bllEntradasProdutos.Sel_Fornecedor_FornProd().Rows)
                    {
                        cbbFornecedor.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString());
                    }
                }
                //
                cbbClienteCons.Items.Clear();
                if (bllEntradasProdutos.Sel_Cliente_Ent() == null)
                {
                    cbbClienteCons.Enabled = false;
                    cbbClienteCons.Text = null;
                }
                else
                {
                    cbbClienteCons.Enabled = true;
                    cbbClienteCons.Items.Add("");
                    foreach (DataRow dr in bllEntradasProdutos.Sel_Cliente_Ent().Rows)
                    {
                        cbbClienteCons.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //
                cbbProduto.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelEntradasProdutos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelEntradasProdutos.");
                }
            }
        }

        private void cbbProduto_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarProduto_MouseLeave(object sender, EventArgs e)
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

        private void cbbFornecedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarFornecedor_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
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

        private void lblValorQuantidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorQuantidade_MouseLeave(object sender, EventArgs e)
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
                            mtxtpData.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(7))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllEntradasProdutos._Data_DatePicker1;
                    mtxtpData1.Text = bllEntradasProdutos._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarProduto_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqProduto Prod = new FrmPesqProduto(1, null, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProduto.Items.Clear();
                        if (bllEntradasProdutos.Sel_Produtos_FornProd() == null)
                        {
                            cbbProduto.Text = null;
                            cbbProduto.Enabled = false;
                            lblProduto.Enabled = false;
                        }
                        else
                        {
                            cbbProduto.Enabled = true;
                            lblProduto.Enabled = true;
                            cbbProduto.Items.Add("");
                            foreach (DataRow dr in bllEntradasProdutos.Sel_Produtos_FornProd().Rows)
                            {
                                cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbProduto.Text = bllEntradasProdutos._FornProd_Prod_PesqProd_Tabela;
                        bllEntradasProdutos._FornProd_Prod_PesqProd_Tabela = null;
                        cbbProduto.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        cbbProduto.Text = null;
                        bllEntradasProdutos._FornProd_Prod_PesqProd_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarFornecedor_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(2, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFornecedor.Items.Clear();
                        if (bllEntradasProdutos.Sel_Fornecedor_FornProd() == null)
                        {
                            cbbFornecedor.Text = null;
                            cbbFornecedor.Enabled = false;
                            lblFornecedor.Enabled = false;
                        }
                        else
                        {
                            cbbFornecedor.Enabled = true;
                            lblFornecedor.Enabled = true;
                            cbbFornecedor.Items.Add("");
                            foreach (DataRow dr in bllEntradasProdutos.Sel_Fornecedor_FornProd().Rows)
                            {
                                cbbFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbFornecedor.Text = bllEntradasProdutos._FornProd_Prod_PesqForn_Tabela;
                        bllEntradasProdutos._FornProd_Prod_PesqForn_Tabela = null;
                        cbbFornecedor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarFornecedor.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarFornecedor.");
                        }
                        cbbFornecedor.Text = null;
                        bllEntradasProdutos._FornProd_Prod_PesqForn_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void FrmRelFornecedoresProd_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllEntradasProdutos._FrmRelEntradasProdutos_Aberto = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelEntradasProdutos foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelEntradasProdutos foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelEntradasProdutos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelEntradasProdutos.");
                }
                bllEntradasProdutos._FrmRelEntradasProdutos_Aberto = false;
            }
        }

        private void FrmRelFornecedoresProd_KeyUp(object sender, KeyEventArgs e)
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

        private void cbbProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFornecedor.Select();
            }
        }

        private void cbbFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbClienteCons.Select();
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por todos os/(ou outros) filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblValorQuantidade_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quantidade dos itens: " + lblValorQuantidade.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
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

                    MessageBox.Show("É necessário preencher ambos os campos de [ Data da Entrada ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mtxtpData.Select();
                    return;
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    if (bllEntradasProdutos.Sel_Fornecedores_Prod_Dados(mtxtpData.Text, mtxtpData1.Text, cbbProduto.Text, cbbFornecedor.Text, cbbTipo.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClienteCons.Text, txtCodDFe.Text.Trim()) == null)
                    {
                        dtFornProd.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtFornProd.DataSource = bllEntradasProdutos.Sel_Fornecedores_Prod_Dados(mtxtpData.Text, mtxtpData1.Text, cbbProduto.Text, cbbFornecedor.Text, cbbTipo.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClienteCons.Text, txtCodDFe.Text.Trim());
                    }
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
                dtFornProd.DataSource = null;
                mtxtpData.Select();
            }
        }

        private void dtFornProd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtFornProd.Columns[0].HeaderText = "Cód. do Produto";
                dtFornProd.Columns[1].HeaderText = "Descrição do Produto";
                dtFornProd.Columns[2].HeaderText = "Cód. do Fornecedor";
                dtFornProd.Columns[3].HeaderText = "Nome do Fornecedor";
                dtFornProd.Columns[4].HeaderText = "Data da Entrada";
                dtFornProd.Columns[5].HeaderText = "Quantidade";
                dtFornProd.Columns[6].HeaderText = "Tipo de Entrada";
                dtFornProd.Columns[7].HeaderText = "Cód. da Entrada";
                dtFornProd.Columns[8].HeaderText = "UM";

                dtFornProd.Columns[0].Width = 110;
                dtFornProd.Columns[1].Width = 325;
                dtFornProd.Columns[2].Width = 135;
                dtFornProd.Columns[3].Width = 325;
                dtFornProd.Columns[4].Width = 175;
                dtFornProd.Columns[5].Width = 110;
                dtFornProd.Columns[6].Width = 200;
                dtFornProd.Columns[7].Width = 150;
                dtFornProd.Columns[8].Width = 46;

                dtFornProd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFornProd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                dtFornProd.DefaultCellStyle.Font = new Font(dtFornProd.Font, FontStyle.Bold);
                //
                decimal quantidade = 0;
                for (int i = 0; i < dtFornProd.Rows.Count; i++)
                {
                    quantidade += Convert.ToDecimal(dtFornProd.Rows[i].Cells[5].Value);
                }
                lblValorQuantidade.Text = Convert.ToDecimal(quantidade).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblRegistros.Text = "Registros: " + dtFornProd.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento RowsAdded do dtFornProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento RowsAdded do dtFornProd.");
                }
                dtFornProd.DataSource = null;
                mtxtpData.Select();
            }
        }

        private void dtFornProd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorQuantidade.Text = null;
        }

        private void dtFornProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtFornProd.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtFornProd.Columns[5].DefaultCellStyle.Format = "n2";

            dtFornProd.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtFornProd.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtFornProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value.ToString() == "0")
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
                if (e.Value.ToString().Trim() != "DFE")
                {
                    e.Value = "MANUAL";
                }
                else
                {
                    e.Value = "DFe";
                }
            }
        }

        private void dtFornProd_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtFornProd.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtFornProd_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtFornProd_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFornProd.DataSource == null)
            {
                dtFornProd.Enabled = false;
                grbBox2.Enabled = false;
                lblQuantidade.Enabled = false;
                lblValorQuantidade.Enabled = false;
            }
            else
            {
                dtFornProd.Enabled = true;
                grbBox2.Enabled = true;
                lblQuantidade.Enabled = true;
                lblValorQuantidade.Enabled = true;
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
                dtFornProd.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                btnSair.Enabled = true;
                mtxtpData.Select();
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtFornProd.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                dtFornProd.Select();
                //
                try
                {
                    DataGridViewRow SelectedRow = dtFornProd.Rows[dtFornProd.CurrentRow.Index];

                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.pdf");
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
                    dtFornProd.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao.Enabled = true;
                    btnSair.Enabled = true;
                    mtxtpData.Select();
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
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllEntradasProdutos._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter2.DrawString(DateTime.Now.ToLongTimeString(), fonte1, XBrushes.Black, new XRect(526 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
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
                    textFormatter1.DrawString("Relatório de Entradas de Produtos", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("PRODUTO       FORNECEDOR       DATA DA ENTRADA       QUANTIDADE       TIPO DE ENTRADA", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtFornProd.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtFornProd.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtFornProd.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtFornProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(47 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString() + "-" + SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(60 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data da Entrada:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(425 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Quantidade:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(405 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo de Entrada:", fonte2, XBrushes.Black, new XRect(450 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[6].Value.ToString().Trim() != "DFE")
                                {
                                    textFormatter2.DrawString("MANUAL", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("DFe", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(47 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString() + "-" + SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(60 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data da Entrada:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(425 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Quantidade:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(405 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo de Entrada:", fonte2, XBrushes.Black, new XRect(450 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[6].Value.ToString().Trim() != "DFE")
                                {
                                    textFormatter2.DrawString("MANUAL", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("DFe", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                Incrementar = 36 + Incrementar;//incrementando                 
                            }
                            //
                            if (linha == (pagina - 1) & dtFornProd.Rows.Count > 15)
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
                                textFormatter1.DrawString("Relatório de Entradas de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Entradas de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtFornProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(47 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString() + "-" + SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(60 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data da Entrada:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(425 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Quantidade:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(405 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo de Entrada:", fonte2, XBrushes.Black, new XRect(450 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[6].Value.ToString().Trim() != "DFE")
                                {
                                    textFormatter2.DrawString("MANUAL", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("DFe", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Quantidade dos itens: " + lblValorQuantidade.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando       
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(47 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString() + "-" + SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(60 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data da Entrada:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(425 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Quantidade:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(405 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo de Entrada:", fonte2, XBrushes.Black, new XRect(450 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[6].Value.ToString().Trim() != "DFE")
                                {
                                    textFormatter2.DrawString("MANUAL", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("DFe", fonte4, XBrushes.Black, new XRect(522 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.txt");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.txt"))
                {
                    writer.WriteLine("Relatório de Entradas de Produtos" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtFornProd.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtFornProd.Rows[linha];
                        string cod_fornecedor = SelectedRow.Cells[2].Value.ToString();
                        string tipo_entrada_tabela = SelectedRow.Cells[6].Value.ToString();
                        //                      
                        if (cod_fornecedor == "0")
                        {
                            cod_fornecedor = "";
                        }
                        //
                        if (tipo_entrada_tabela.Trim() != "DFE")
                        {
                            tipo_entrada_tabela = "MANUAL";
                        }
                        else
                        {
                            tipo_entrada_tabela = "DFe";
                        }
                        //
                        writer.WriteLine(@"|Cód. do Produto: " + SelectedRow.Cells[0].Value.ToString() + " |Descrição do Produto: " + SelectedRow.Cells[1].Value.ToString() + " |Cód. do Fornecedor: " + cod_fornecedor + " |Descrição do Fornecedor: " + SelectedRow.Cells[3].Value.ToString() + " |Data de Entrada: " + SelectedRow.Cells[4].Value.ToString().Remove(10) + " |Quantidade: " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Tipo de Entrada: " + tipo_entrada_tabela + " | Cód. da Entrada: " + SelectedRow.Cells[7].Value.ToString());
                    }
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.txt");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Cód. do Produto;Descrição do Produto;Cód. do Fornecedor;Nome do Fornecedor;Data da Entrada;Quantidade;Tipo de Entrada;Cód. da Entrada");
                    for (int linha = 0; linha < dtFornProd.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtFornProd.Rows[linha];
                        string cod_fornecedor = SelectedRow.Cells[2].Value.ToString();
                        string tipo_entrada_tabela = SelectedRow.Cells[6].Value.ToString();
                        //                      
                        if (cod_fornecedor == "0")
                        {
                            cod_fornecedor = "";
                        }
                        //
                        if (tipo_entrada_tabela.Trim() != "DFE")
                        {
                            tipo_entrada_tabela = "MANUAL";
                        }
                        else
                        {
                            tipo_entrada_tabela = "DFe";
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), cod_fornecedor, SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), tipo_entrada_tabela, SelectedRow.Cells[7].Value.ToString()));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Entradas de Produtos");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                    Sw.WriteLine("Quantidade dos itens: " + lblValorQuantidade.Text);
                } 
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Entradas de Produtos\Entradas de Produtos.csv");
            }
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtFornProd.Enabled = false;
            dtFornProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
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
            _Trabalho = 1;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtFornProd.Enabled = false;
            dtFornProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao.Enabled = false;
        }

        private void btnResumido_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(14))
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
                    dtFornProd.Enabled = false;
                    dtFornProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir o relatório em PDF.\n\n2 - Exp. dados para (.csv): Clique para gerar em arquivo excel o relatório.\n\n3 - Exp. dados para (.txt): Clique para gerar em arquivo texto o relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_DropDownClosed(object sender, EventArgs e)
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

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbProduto.Select();
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

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
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

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodDFe.Select();
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

        private void btnClienteCons_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnClienteCons_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbClienteCons_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbClienteCons_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbClienteCons_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbClienteCons_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnClienteCons_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCliente Clie = new FrmPesqCliente(12, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbClienteCons.Items.Clear();
                        if (bllEntradasProdutos.Sel_Cliente_Ent() == null)
                        {
                            cbbClienteCons.Text = null;
                            cbbClienteCons.Enabled = false;
                            lblCliente.Enabled = false;
                        }
                        else
                        {
                            cbbClienteCons.Enabled = true;
                            lblCliente.Enabled = true;
                            cbbClienteCons.Items.Add("");
                            foreach (DataRow dr in bllEntradasProdutos.Sel_Cliente_Ent().Rows)
                            {
                                cbbClienteCons.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString());
                            }
                        }
                        cbbClienteCons.Text = bllEntradasProdutos._Cliente_PesqCliente_Tabela;
                        bllEntradasProdutos._Cliente_PesqCliente_Tabela = null;
                        cbbClienteCons.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnClienteCons.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnClienteCons.");
                        }
                        cbbClienteCons.Text = null;
                        bllEntradasProdutos._Cliente_PesqCliente_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnPesqDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesqDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCodDFe_Enter(object sender, EventArgs e)
        {
            txtCodDFe.BackColor = Color.LightBlue;
        }

        private void txtCodDFe_Leave(object sender, EventArgs e)
        {
            if (txtCodDFe.Text.Contains("'") || txtCodDFe.Text.Contains(";") || txtCodDFe.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodDFe.Text = null;
                txtCodDFe.Select();
            }
            txtCodDFe.BackColor = Color.White;
        }

        private void txtCodDFe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbTipo.Select();
            }
        }

        private void cbbClienteCons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnPesqDFe_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqDFe DFe = new FrmPesqDFe(1))
            {
                if (DFe.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    try
                    {
                        txtCodDFe.Text = bllEntradasProdutos._Cod_DFe;
                        bllEntradasProdutos._Cod_DFe = null;
                        txtCodDFe.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesqDFe.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesqDFe.");
                        }
                        txtCodDFe.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }
    }
}
