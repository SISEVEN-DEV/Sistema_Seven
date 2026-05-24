using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadValidade : Form
    {
        public FrmCadValidade(byte formulario, string usuario, string cod_pdv_computador, string produto, string cod_dfe)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Produto = produto;
            _Cod_DFe = cod_dfe;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Produto;
        private string _Cod_DFe;

        private bool _Comando_Atualizar = false;

        private void FrmCadValidade_Load(object sender, EventArgs e)
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
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadValidade iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadValidade iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    cbbProduto.Items.Clear();
                    cbbProduto.Items.Add(_Produto);
                    cbbProduto.Text = _Produto;
                    cbbProduto.Enabled = false;
                    btnProcurarProduto.Enabled = false;
                }
                else if (_Formulario == 1)
                {
                    cbbProduto.Items.Clear();
                    cbbProduto.Enabled = true;
                    btnProcurarProduto.Enabled = true;
                    //
                    if (bllValidade.Sel_Items_DFe_Validade(_Cod_DFe) == null)
                    {
                        MessageBox.Show("O DFe selecionado não possui nenhum Produto associado a nenhum item cadastrado no sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        foreach (DataRow dr in bllValidade.Sel_Items_DFe_Validade(_Cod_DFe).Rows)
                        {
                            cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                        //
                        cbbProduto.SelectedIndex = 0;
                        //
                        _Produto = cbbProduto.Text;
                    }
                }
                else
                {
                    cbbProduto.Items.Clear();
                    cbbProduto.Items.Add(_Produto);
                    cbbProduto.Text = _Produto;
                    cbbProduto.Enabled = false;
                    btnProcurarProduto.Enabled = false;
                    rbtnTodos.Checked = true;
                    //
                    if (bllValidade.Sel_Validade_Todos(_Produto) == null)
                    {
                        dtValidade.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtValidade.DataSource = bllValidade.Sel_Validade_Todos(_Produto);
                        dtValidade.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadValidade.");
                }
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtNLote.Text = null;
            mtxtDataValidade.Text = null;
            mtxtDataFabricacao.Text = null;
            mtxtHorario1.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            txtCodigo.Enabled = false;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtValidade.Enabled = true;
            dtValidade.Select();
        }

        private void rbtnDataEmissao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDataEmissao_MouseLeave(object sender, EventArgs e)
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

        private void rbtnNumeroNF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNumeroNF_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData3_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
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

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
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
                mtxtpData1.Select();
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

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por data de validade, código, nº do lote e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;

        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ]\n\n5 - Asterisco Escuro (*): Significa que esse campo pode possuir um ou mais valores.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmCadValidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
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

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(23))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllValidade._Data_DatePicker1;
                    mtxtpData1.Text = bllValidade._Data_DatePicker2;
                }
            }
            this.Enabled = true;
        }

        private void txtNLote_Leave(object sender, EventArgs e)
        {
            if (txtNLote.Text.Contains(";") || txtNLote.Text.Contains("'") || txtNLote.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNLote.Text = null;
                txtNLote.Select();
            }
            txtNLote.BackColor = Color.White;
        }

        private void txtNLote_Enter(object sender, EventArgs e)
        {
            txtNLote.BackColor = Color.LightBlue;
        }

        private void txtNLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataFabricacao.Select();
            }
        }

        private void mtxtDataValidade_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataValidade.Text == "")
            {
                mtxtDataValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataValidade.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataValidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataValidade.Text == "")
                {
                    mtxtDataValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataValidade.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataValidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void mtxtDataValidade_Enter(object sender, EventArgs e)
        {
            mtxtDataValidade.BackColor = Color.LightBlue;
        }

        private void mtxtDataValidade_Leave(object sender, EventArgs e)
        {
            mtxtDataValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataValidade.Text != "")
            {
                try
                {
                    mtxtDataValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataValidade.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataValidade.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataValidade.");
                    }
                    mtxtDataValidade.Text = null;
                }
            }
            mtxtDataValidade.BackColor = Color.White;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(4))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataValidade.Text = bllValidade._Data_DatePicker1;

                }
            }
            this.Enabled = true;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDataValidade_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = true;
            btnSelecionarData1.Visible = true;
            mtxtpData.Visible = true;
            mtxtpData1.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(242, 22);
            lblPesquisar.Text = "Digite as datas:";
            txtpLote.Visible = false;
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpData.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = false;
            btnSelecionarData1.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(389, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpLote.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnNumeroNF_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = false;
            btnSelecionarData1.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(180, 21);
            lblPesquisar.Text = "Digite o nº do lote:";
            txtpLote.Visible = true;
            txtpLote.Text = null;
            txtpLote.Select();

        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = false;
            btnSelecionarData1.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(435, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            txtpLote.Visible = false;
            btnPesquisar.Select();
        }

        private void txtpLote_Enter(object sender, EventArgs e)
        {
            txtpLote.BackColor = Color.LightBlue;
        }

        private void txtpLote_Leave(object sender, EventArgs e)
        {
            if (txtpLote.Text.Contains(";") || txtpLote.Text.Contains("'") || txtpLote.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpLote.Text = null;
                txtpLote.Select();
            }
            txtpLote.BackColor = Color.White;
        }

        private void txtpLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtValidade.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtValidade.Enabled = false;
                grbBox1.Enabled = false;
                grbBox2.Enabled = true;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                grbBox3.Enabled = false;
                Limpar();
                txtNLote.Select();
                _Comando_Atualizar = false;
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
                Limpar();
                _Comando_Atualizar = false;
                dtValidade.DataSource = null;
                rbtnDataValidade.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllValidade.Sel_Validade_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtValidade.Select();
                }
                else
                {
                    dtValidade.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtValidade.Enabled = false;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = true;
                    btnNovo.Enabled = false;
                    txtCodigo.Enabled = true;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    txtNLote.Select();
                    _Comando_Atualizar = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                Limpar();
                _Comando_Atualizar = false;
                dtValidade.DataSource = null;
                rbtnDataValidade.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtValidade.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;

                }
            }
            grbBox3.Enabled = true;
            ModoPesquisa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                mtxtDataValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataValidade.Text.Trim() == "")
                {
                    mtxtDataValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\rCampo: [ Data de Validade ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    mtxtDataValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllValidade.Sel_Validade_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                dtValidade.DataSource = null;
                                rbtnDataValidade.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                            }
                            else
                            {
                                bllValidade.Alterar(txtCodigo.Text, txtNLote.Text.Trim(), mtxtDataValidade.Text, _Produto, _Cod_DFe, mtxtDataFabricacao.Text, mtxtHorario1.Text);

                                dtValidade.DataSource = bllValidade.Sel_Validade_A_Alterar(txtCodigo.Text);

                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA VALIDADE", "VALIDADE", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Validade alterada. Cod: " + txtCodigo.Text + " | Nº do Lote: " + txtNLote.Text);
                                }

                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Validade alterada. Cod: " + txtCodigo.Text + " | Nº do Lote: " + txtNLote.Text);
                                }


                                _Comando_Atualizar = false;

                                ModoPesquisa();

                                grbBox3.Enabled = true;

                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "VALIDADE") != null)
                                {
                                    string codigo = bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "VALIDADE");

                                    DialogResult = MessageBox.Show("Deseja alterar também os dados do lembrete associado a esta Validade?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.Enabled = false;
                                        using (FrmUtilAgenda Agenda = new FrmUtilAgenda(_Usuario, _Cod_PDV_Computador, 1, codigo))
                                        {
                                            if (Agenda.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                        }
                                        this.Enabled = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bllValidade.Salvar(txtNLote.Text.Trim(), mtxtDataValidade.Text, _Produto, _Cod_DFe, mtxtDataFabricacao.Text, mtxtHorario1.Text);

                            dtValidade.DataSource = bllValidade.Sel_Validade_A_Salvar();

                            bllRegistroAtividades.Salvar("SALVOU UMA VALIDADE", "VALIDADE", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Validade cadastrada. Cod: " + txtCodigo.Text + " | Nº do Lote: " + txtNLote.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Validade cadastrada. Cod: " + txtCodigo.Text + " | Nº do Lote: " + txtNLote.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            //
                            ModoPesquisa();
                            //
                            grbBox3.Enabled = true;
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllUsuario.Sel_Criar_Lemb_Validade_Usuario(_Usuario) == true)
                            {
                                DialogResult = MessageBox.Show("Deseja criar um lembrete para esta Validade?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    DataGridViewRow SelectedRow = dtValidade.Rows[dtValidade.CurrentRow.Index];
                                    //
                                    this.Enabled = false;
                                    using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, SelectedRow.Cells[4].Value.ToString().Remove(10), null, "LEMBRETE DE VALIDADE DE PRODUTO", "LEMBRETE DE VALIDADE DE PRODUTO DE CÓDIGO " + SelectedRow.Cells[0].Value.ToString().Trim() + "  NA DATA  DE " + SelectedRow.Cells[4].Value.ToString().Remove(10), null, false, _Usuario, _Cod_PDV_Computador, 2, "VALIDADE", SelectedRow.Cells[0].Value.ToString()))
                                    {
                                        if (Lembrete.ShowDialog() == DialogResult.OK)
                                        {
                                            this.DialogResult = DialogResult.None;
                                        }
                                    }
                                    this.Enabled = true;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
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
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        _Comando_Atualizar = false;
                        dtValidade.DataSource = null;
                        Limpar();
                        ModoPesquisa();
                        grbBox3.Enabled = true;
                        rbtnDataValidade.Checked = true;
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                txtNLote.Select();
            }
        }

        private void dtValidade_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtValidade.Columns[0].HeaderText = "Código";
            dtValidade.Columns[1].HeaderText = "Nº do Lote";
            dtValidade.Columns[2].HeaderText = "Data de Fabricação";
            dtValidade.Columns[3].HeaderText = "Horário de Fabricação";
            dtValidade.Columns[4].HeaderText = "Data de Validade";
            dtValidade.Columns[5].Visible = false;
            dtValidade.Columns[6].Visible = false;
            //
            dtValidade.Columns[0].Width = 85;
            dtValidade.Columns[1].Width = 337;
            dtValidade.Columns[2].Width = 150;
            dtValidade.Columns[3].Width = 150;
            dtValidade.Columns[4].Width = 150;
            //
            dtValidade.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtValidade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtValidade.DefaultCellStyle.Font = new Font(dtValidade.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtValidade.Rows.Count;
        }

        private void dtValidade_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtValidade.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtValidade.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtValidade.Rows[dtValidade.CurrentRow.Index];
                //
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNLote.Text = SelectedRow.Cells[1].Value.ToString();
                if (SelectedRow.Cells[2].Value.ToString() != "")
                {
                    mtxtDataFabricacao.Text = SelectedRow.Cells[2].Value.ToString().Remove(10);
                }
                mtxtHorario1.Text = SelectedRow.Cells[3].Value.ToString();
                mtxtDataValidade.Text = SelectedRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtValidade.");
                }
                rbtnDataValidade.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void dtValidade_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtValidade.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtValidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtValidade_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtValidade.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtValidade.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtValidade.Enabled = true;
            }
        }

        private void dtValidade_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDataValidade.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllValidade.Sel_Validade_Data_Validade(mtxtpData.Text, mtxtpData1.Text, _Produto) == null)
                        {
                            dtValidade.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtValidade.DataSource = bllValidade.Sel_Validade_Data_Validade(mtxtpData.Text, mtxtpData1.Text, _Produto);
                            dtValidade.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllValidade.Sel_Validade_Codigo(txtpCodigo.Text, _Produto) == null)
                        {
                            dtValidade.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtValidade.DataSource = bllValidade.Sel_Validade_Codigo(txtpCodigo.Text, _Produto);
                            dtValidade.Select();
                        }
                    }
                }
                else if (rbtnNLote.Checked == true)
                {
                    if (txtpLote.Text != "")
                    {
                        if (bllValidade.Sel_Validade_N_Lote(txtpLote.Text, _Produto) == null)
                        {
                            dtValidade.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtValidade.DataSource = bllValidade.Sel_Validade_N_Lote(txtpLote.Text, _Produto);
                            dtValidade.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllValidade.Sel_Validade_Todos(_Produto) == null)
                    {
                        dtValidade.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtValidade.DataSource = bllValidade.Sel_Validade_Todos(_Produto);
                        dtValidade.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou validade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou validade.");
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
                dtValidade.DataSource = null;
                rbtnDataValidade.Checked = true;
                mtxtDataValidade.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void FrmCadValidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadValidade foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadValidade foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadValidade.");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllValidade.Sel_Validade_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtValidade.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Validade?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        /*
                        if (bllProduto.Sel_Produto_Venda_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Produto selecionado está sendo utilizado por uma Venda, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtProd.Select();
                        }
                        else
                        {
                        */
                        //bllProduto.Excluir_Mult_Barra_Prod(txtCodigo.Text);
                        //
                        bllValidade.Excluir(txtCodigo.Text);

                        bllRegistroAtividades.Salvar("EXCLUIU UMA VALIDADE", "VALIDADE", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Validade excluída. Cod: " + txtCodigo.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Validade excluída. Cod: " + txtCodigo.Text);
                        }

                        if (rbtnDataValidade.Checked == true)
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            //
                            if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                if (bllValidade.Sel_Validade_Data_Validade(mtxtpData.Text, mtxtpData1.Text, _Produto) == null)
                                {
                                    dtValidade.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtValidade.DataSource = bllValidade.Sel_Validade_Data_Validade(mtxtpData.Text, mtxtpData1.Text, _Produto);
                                    dtValidade.Select();
                                }
                            }
                            else
                            {
                                dtValidade.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnNLote.Checked == true)
                        {
                            if (txtpLote.Text != "")
                            {
                                if (bllValidade.Sel_Validade_N_Lote(txtpLote.Text.Trim(), _Produto) == null)
                                {
                                    dtValidade.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtValidade.DataSource = bllValidade.Sel_Validade_N_Lote(txtpLote.Text.Trim(), _Produto);
                                    dtValidade.Select();
                                }
                            }
                            else
                            {
                                dtValidade.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnTodos.Checked == true)
                        {
                            if (bllValidade.Sel_Validade_Todos(_Produto) == null)
                            {
                                dtValidade.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtValidade.DataSource = bllValidade.Sel_Validade_Todos(_Produto);
                                dtValidade.Select();
                            }
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                dtValidade.DataSource = null;
                rbtnDataValidade.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void cbbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();
            dtValidade.DataSource = null;
            _Produto = cbbProduto.Text;
        }

        private void btnProcurarProduto_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqProduto Prod = new FrmPesqProduto(4, _Cod_DFe, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProduto.Items.Clear();
                        if (bllValidade.Sel_Items_DFe_Validade(_Cod_DFe) == null)
                        {
                            cbbProduto.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllValidade.Sel_Items_DFe_Validade(_Cod_DFe).Rows)
                            {
                                cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbProduto.Text = bllValidade._Validade_Prod_PesqProd_Tabela;
                        bllValidade._Validade_Prod_PesqProd_Tabela = null;
                        cbbProduto.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        cbbProduto.Text = null;
                    }
                }
                this.Enabled = true;
            }
        }

        private void mtxtDataFabricacao_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataFabricacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataFabricacao.Text == "")
            {
                mtxtDataFabricacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataFabricacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataFabricacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataFabricacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void mtxtDataFabricacao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataFabricacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataFabricacao.Text == "")
                {
                    mtxtDataFabricacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataFabricacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataFabricacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataFabricacao_Enter(object sender, EventArgs e)
        {
            mtxtDataFabricacao.BackColor = Color.LightBlue;
        }

        private void mtxtDataFabricacao_Leave(object sender, EventArgs e)
        {
            mtxtDataFabricacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataFabricacao.Text != "")
            {
                try
                {
                    mtxtDataFabricacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataFabricacao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataFabricacao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataFabricacao.");
                    }
                    mtxtDataFabricacao.Text = null;
                }
            }
            mtxtDataFabricacao.BackColor = Color.White;
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(4))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataFabricacao.Text = bllValidade._Data_DatePicker1;
                }
            }
            this.Enabled = true;
        }

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            if (mtxtHorario1.ReadOnly == false)
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
                mtxtDataValidade.Select();
            }
        }

        private void mtxtHorario1_KeyUp(object sender, KeyEventArgs e)
        {
            if (mtxtHorario1.ReadOnly == false)
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

        private void dtValidade_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }
    }
}
