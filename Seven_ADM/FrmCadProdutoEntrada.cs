using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadProdutoEntrada : Form
    {
        public FrmCadProdutoEntrada(string codigo, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Codigo = codigo;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        public string _Codigo;
        public string _Usuario;
        private string _ComboboxFornecedor_Valor = null;
        private string _Cod_PDV_Computador;

        private void Limpar()
        {
            mtxtDataCompra.Text = null;
            cbbFornecedor.Text = null;
            txtQuantidade.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtEstoque.Enabled = true;
            dtEstoque.Select();
        }

        private void FrmCadProdutoEstoque_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProdutoEntrada iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProdutoEntrada iniciado.");
                }
                //
                if (_Codigo != "")
                {
                    dtEstoque.DataSource = bllEntradasProdutos.Sel_Entrada_Prod_Todos(_Codigo);
                    dtEstoque.Select();
                }
                //
                if (bllEntradasProdutos._Data_Entrada != null & bllEntradasProdutos._Quantidade != null)
                {
                    btnNovo_Click(sender, e);
                    mtxtDataCompra.Text = bllEntradasProdutos._Data_Entrada;
                    cbbFornecedor.Text = bllEntradasProdutos._Fornecedor;
                    txtQuantidade.Text = bllEntradasProdutos._Quantidade;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadProdutoEntrada.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadProdutoEntrada.");
                }
            }
        }

        private void mtxtDataCompra_Enter(object sender, EventArgs e)
        {
            mtxtDataCompra.BackColor = Color.LightBlue;
        }

        private void mtxtDataCompra_Leave(object sender, EventArgs e)
        {
            mtxtDataCompra.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataCompra.Text == "")
            {
                mtxtDataCompra.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtDataCompra.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataCompra.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataCompra.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataCompra.");
                    }
                    mtxtDataCompra.Text = null;
                    mtxtDataCompra.Select();
                }
            }
            mtxtDataCompra.BackColor = Color.White;
        }

        private void mtxtDataCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFornecedor.Select();
            }
        }

        private void cbbFornecedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQuantidade.Select();
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

        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            txtQuantidade.BackColor = Color.LightBlue;
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Contains("'") || txtQuantidade.Text.Contains(";") || txtQuantidade.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtQuantidade.Text = null;
                txtQuantidade.Select();
            }
            else
            {
                try
                {
                    if (txtQuantidade.Text != "")
                    {
                        txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    txtQuantidade.BackColor = Color.White;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidade.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidade.");
                    }
                    txtQuantidade.Text = null;
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQuantidade.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void pcibInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
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

        private void FrmCadProdutoEstoque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void cbbFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtEstoque.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtEstoque.Enabled = false;
            grbBox1.Enabled = true;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            txtQuantidade.Select();
            Limpar();
            mtxtDataCompra.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //
            try
            {
                cbbFornecedor.Items.Clear();
                if (bllProduto.Sel_Fornecedor_Prod() == null)
                {
                    cbbFornecedor.Text = null;
                }
                else
                {
                    cbbFornecedor.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Fornecedor_Prod().Rows)
                    {
                        cbbFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                dtEstoque.DataSource = null;
                ModoPesquisa();
                Limpar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            ModoPesquisa();
            bllEntradasProdutos._Data_Entrada = null;
            bllEntradasProdutos._Fornecedor = null;
            bllEntradasProdutos._Quantidade = null;
        }

        private void dtEstoque_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtEstoque.Columns[0].HeaderText = "Código";
            dtEstoque.Columns[1].HeaderText = "Data de Entrada";
            dtEstoque.Columns[2].HeaderText = "Cód. do Fornecedor";
            dtEstoque.Columns[3].HeaderText = "Nome do Fornecedor";
            dtEstoque.Columns[4].HeaderText = "Quantidade";
            dtEstoque.Columns[5].Visible = false;
            dtEstoque.Columns[6].Visible = false;
            dtEstoque.Columns[7].Visible = false;

            dtEstoque.Columns[0].Width = 95;
            dtEstoque.Columns[1].Width = 145;
            dtEstoque.Columns[2].Width = 125;
            dtEstoque.Columns[3].Width = 325;
            dtEstoque.Columns[4].Width = 100;

            dtEstoque.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtEstoque.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtEstoque.DefaultCellStyle.Font = new Font(dtEstoque.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtEstoque.Rows.Count;
        }

        private void dtEstoque_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(0, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFornecedor.Items.Clear();

                        if (bllProduto.Sel_Fornecedor_Prod() == null)
                        {
                            cbbFornecedor.Text = null;
                        }
                        else
                        {
                            cbbFornecedor.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Fornecedor_Prod().Rows)
                            {
                                cbbFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                            }
                        }

                        cbbFornecedor.Text = bllProduto._Fornecedor_PesqFornecedor_Tabela;
                        bllProduto._Fornecedor_PesqFornecedor_Tabela = null;
                        cbbFornecedor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        cbbFornecedor.Text = null;
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbFornecedor.Text != "")
                {
                    _ComboboxFornecedor_Valor = cbbFornecedor.Text;
                    cbbFornecedor.Items.Clear();
                    if (bllProduto.Sel_Fornecedor_Prod() == null)
                    {
                        cbbFornecedor.Text = null;
                    }
                    else
                    {
                        cbbFornecedor.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_Fornecedor_Prod().Rows)
                        {
                            cbbFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                        }
                    }
                    //
                    if (bllEntradasProdutos.Sel_ComboboxFornecedor_Valor_A_Alterar(_ComboboxFornecedor_Valor) != null)
                    {
                        foreach (DataRow dr in bllEntradasProdutos.Sel_ComboboxFornecedor_Valor_A_Alterar(_ComboboxFornecedor_Valor).Rows)
                        {
                            cbbFornecedor.Text = dr["id_fornecedor"].ToString() + "-" + dr["nome"].ToString();
                        }
                        _ComboboxFornecedor_Valor = null;
                    }
                    else
                    {
                        _ComboboxFornecedor_Valor = null;
                        cbbFornecedor.Text = null;
                    }
                }
                //
                mtxtDataCompra.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                //
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (txtQuantidade.Text == "" || mtxtDataCompra.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Data de Entrada ] e [ Quantidade ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataCompra.Select();
                    }
                    else
                    {
                        if (_Codigo != "")
                        {
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(_Codigo) == true)
                            {
                                if (bllProduto.Ver_Estoque_Max_Prod(_Codigo, txtQuantidade.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque máximo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                        }
                        //
                        mtxtDataCompra.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        bllEntradasProdutos._Data_Entrada = mtxtDataCompra.Text;
                        bllEntradasProdutos._Fornecedor = cbbFornecedor.Text;
                        bllEntradasProdutos._Quantidade = txtQuantidade.Text;
                        //
                        MessageBox.Show("Os dados foram informados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.Abort;
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    mtxtDataCompra.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                dtEstoque.DataSource = null;
                ModoPesquisa();
                Limpar();
            }
        }

        private void dtEstoque_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtEstoque.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtEstoque.Columns[4].DefaultCellStyle.Format = "n2";

            dtEstoque.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtEstoque.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void mtxtDataCompra_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataCompra.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataCompra.Text == "")
            {
                mtxtDataCompra.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataCompra.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataCompra.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataCompra.Text == "")
                {
                    mtxtDataCompra.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataCompra.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        }

        private void dtEstoque_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtEstoque.DataSource != null)
            {
                btnExcluir.Enabled = true;
                dtEstoque.Enabled = true;
            }
            else
            {
                btnExcluir.Enabled = false;
                dtEstoque.Enabled = false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja excluir esta Entrada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    DataGridViewRow SelectedRow = dtEstoque.Rows[dtEstoque.CurrentRow.Index];
                    //
                    bllEntradasProdutos.Sel_Prod_Reduzir_Saldo_Atual_Cad_Prod(_Codigo, SelectedRow.Cells[4].Value.ToString());
                    //
                    bllEntradasProdutos.Excluir(SelectedRow.Cells[0].Value.ToString());
                    //
                    bllRegistroAtividades.Salvar("EXCLUIU DADOS DE UMA ENTRADA.", "ENTRADA DE PRODUTOS", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                    //
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Entrada excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Entrada excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                    }
                    //
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    if (dtEstoque.DataSource != null)
                    {
                        dtEstoque.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                dtEstoque.DataSource = null;
                ModoPesquisa();
                Limpar();
            }
        }

        private void dtEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtEstoque.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtEstoque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadProdutoEntrada_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProdutoEntrada foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProdutoEntrada foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProdutoEntrada.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProdutoEntrada.");
                }
            }
        }

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n3 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\nPara salvar as entradas, é necessário confirmar as entradas clicando em [ Salvar ] no cadastro de Produtos. Caso seja realizada uma exclusão de ma entrada, os dados serão escluídos sem a confirmação do botão [ Salvar ] no cadastro de produtos.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtEstoque_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }
    }
}
