using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqVenda : Form
    {
        public FrmPesqVenda(byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqVenda_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                //
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqVenda iniciado.");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqVenda iniciado.");
                }
                //
                rbtnDataVenda.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqVenda.");
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void rbtnDataVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDataVenda_MouseLeave(object sender, EventArgs e)
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

        private void btnConsultarItens_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarItens_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    bllDFe._Cod_Orcamento = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if(_Formulario == 1)
                {
                    btnIncluir.Select();
                    bllComissao._Cod_Venda = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    bllDevolucao._Devolucao_PesqVendaTabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do click btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do click btnIncluir.");
                }
            }
        }

        private void rbtnDataVenda_CheckedChanged(object sender, EventArgs e)
        {
            btnProcurarCliente.Visible = false;
            lblAte.Visible = true;
            btnSelecionarData.Visible = true;
            mtxtpData.Visible = true;
            mtxtpData1.Visible = true;
            cbbConsumidor.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(405, 19);
            lblPesquisar.Text = "Digite as datas:";
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpData.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnProcurarCliente.Visible = false;
            lblAte.Visible = false;
            btnSelecionarData.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            cbbConsumidor.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(552, 19);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnConsumidor_CheckedChanged(object sender, EventArgs e)
        {
            btnProcurarCliente.Visible = true;
            lblAte.Visible = false;
            btnSelecionarData.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            cbbConsumidor.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(285, 19);
            lblPesquisar.Text = "Escolha o consumidor:";
            cbbConsumidor.Text = null;
            cbbConsumidor.Select();
            //
            cbbConsumidor.Items.Clear();
            if (bllVenda.Sel_Cliente_Vend() == null)
            {
                cbbConsumidor.Text = null;
                btnProcurarCliente.Enabled = false;
            }
            else
            {
                btnProcurarCliente.Enabled = true;
                cbbConsumidor.Items.Add("");
                foreach (DataRow dr in bllVenda.Sel_Cliente_Vend().Rows)
                {
                    cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                }
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnProcurarCliente.Visible = false;
            lblAte.Visible = false;
            btnSelecionarData.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            cbbConsumidor.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(598, 19);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDataVenda.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllVenda.Sel_Venda_Data_Venda(mtxtpData.Text, mtxtpData1.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllVenda.Sel_Venda_Data_Venda(mtxtpData.Text, mtxtpData1.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllVenda.Sel_Venda_Codigo(txtpCodigo.Text.Trim()) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllVenda.Sel_Venda_Codigo(txtpCodigo.Text.Trim());
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnConsumidor.Checked == true)
                {
                    if (cbbConsumidor.Text != "")
                    {
                        if (bllVenda.Sel_Venda_Consumidor(cbbConsumidor.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllVenda.Sel_Venda_Consumidor(cbbConsumidor.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllVenda.Sel_Venda_Todos() == null)
                    {
                        dtPesquisa.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtPesquisa.DataSource = bllVenda.Sel_Venda_Todos();
                        dtPesquisa.Select();
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
                dtPesquisa.DataSource = null;
                rbtnCodigo.Checked = true;
            }
        }

        private void btnConsultarItens_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            btnIncluir.Enabled = false;
            btnVoltar.Enabled = false;
            btnProcurarCliente.Enabled = false;
            btnSelecionarData.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 0))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtPesquisa.Select();
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
            btnPesquisar.Enabled = true;
            btnIncluir.Enabled = false;
            btnIncluir.Enabled = true;
            btnVoltar.Enabled = true;
            btnProcurarCliente.Enabled = true;
            btnSelecionarData.Enabled = true;
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
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

        private void cbbConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            btnIncluir.Enabled = false;
            btnVoltar.Enabled = false;
            btnProcurarCliente.Enabled = false;
            btnConsultarItens.Enabled = false;
            try
            {
                using (FrmPesqCliente Clie = new FrmPesqCliente(4, _Usuario, _Cod_PDV_Computador))
                {
                    if (Clie.ShowDialog() == DialogResult.OK)
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllVenda.Sel_Cliente_Vend() == null)
                        {
                            cbbConsumidor.Text = null;
                        }
                        else
                        {
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
                }
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
                cbbConsumidor.Text = null;
                bllVenda._Cliente_PesqCliente_Tabela = null;
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
            btnProcurarCliente.Enabled = true;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            btnIncluir.Enabled = false;
            btnVoltar.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnConsultarItens.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(3))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllVenda._Data_DatePicker1;
                    mtxtpData1.Text = bllVenda._Data_DatePicker2;
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

        private void dtPesquisa_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dtPesquisa_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    bllDFe._Cod_Orcamento = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    bllComissao._Cod_Venda = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    bllDevolucao._Devolucao_PesqVendaTabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtPesquisa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtPesquisa.");
                }
            }
        }

        private void dtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    //
                    if (_Formulario == 0)
                    {
                        btnIncluir.Select();
                        bllDFe._Cod_Orcamento = SelectedRow.Cells[0].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        btnIncluir.Select();
                        bllComissao._Cod_Venda = SelectedRow.Cells[0].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 2)
                    {
                        btnIncluir.Select();
                        bllDevolucao._Devolucao_PesqVendaTabela = SelectedRow.Cells[0].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do KeyDown dtPesquisa.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do KeyDown dtPesquisa.");
                    }
                }
            }
        }

        private void FrmPesqVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtPesquisa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtPesquisa.Columns[0].HeaderText = "Código";
                dtPesquisa.Columns[1].HeaderText = "Cód. do Consumidor";
                dtPesquisa.Columns[2].HeaderText = "Nome do Consumidor";
                dtPesquisa.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
                dtPesquisa.Columns[4].HeaderText = "Data";
                dtPesquisa.Columns[5].HeaderText = "Horário";
                dtPesquisa.Columns[6].HeaderText = "Valor (R$)";
                dtPesquisa.Columns[7].HeaderText = "Desconto -(%)";
                dtPesquisa.Columns[8].HeaderText = "Valor do Desconto -(R$)";
                dtPesquisa.Columns[9].HeaderText = "Acréscimo (%)";
                dtPesquisa.Columns[10].HeaderText = "Valor do Acréscimo (R$)";
                dtPesquisa.Columns[11].HeaderText = "Valor do Desconto Item (R$)";
                dtPesquisa.Columns[12].HeaderText = "Valor do Acréscimo Item (R$)";
                dtPesquisa.Columns[13].HeaderText = "Valor Real (R$)";
                dtPesquisa.Columns[14].HeaderText = "Valor Total Pago (R$)";
                dtPesquisa.Columns[15].HeaderText = "Troco (R$)";
                dtPesquisa.Columns[16].HeaderText = "Tipo";
                dtPesquisa.Columns[17].HeaderText = "Cód. do Usuário";
                dtPesquisa.Columns[18].HeaderText = "Nome do Usuário";
                dtPesquisa.Columns[19].HeaderText = "Cód. do PDV/Computador";
                dtPesquisa.Columns[20].HeaderText = "Observações";
                dtPesquisa.Columns[21].HeaderText = "Cód. do Orçamento";
                dtPesquisa.Columns[22].HeaderText = "Cód. da Devolução";
                dtPesquisa.Columns[23].HeaderText = "Cód. da O.S.";

                dtPesquisa.DefaultCellStyle.Font = new Font(dtPesquisa.Font, FontStyle.Bold);

                dtPesquisa.Columns[0].Width = 95;
                dtPesquisa.Columns[1].Width = 130;
                dtPesquisa.Columns[2].Width = 355;
                dtPesquisa.Columns[3].Width = 185;
                dtPesquisa.Columns[4].Width = 85;
                dtPesquisa.Columns[5].Width = 85;
                dtPesquisa.Columns[6].Width = 115;
                dtPesquisa.Columns[7].Width = 115;
                dtPesquisa.Columns[8].Width = 150;
                dtPesquisa.Columns[9].Width = 115;
                dtPesquisa.Columns[10].Width = 150;
                dtPesquisa.Columns[11].Width = 170;
                dtPesquisa.Columns[12].Width = 170;
                dtPesquisa.Columns[13].Width = 115;
                dtPesquisa.Columns[14].Width = 150;
                dtPesquisa.Columns[15].Width = 115;
                dtPesquisa.Columns[16].Width = 105;
                dtPesquisa.Columns[17].Width = 115;
                dtPesquisa.Columns[18].Width = 150;
                dtPesquisa.Columns[19].Width = 170;
                dtPesquisa.Columns[20].Width = 500;
                dtPesquisa.Columns[21].Width = 125;
                dtPesquisa.Columns[22].Width = 125;
                dtPesquisa.Columns[23].Width = 125;
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
                dtPesquisa.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPesquisa.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPesquisa.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPesquisa.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPesquisa.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPesquisa.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                lblRegistros.Text = "Registros: " + dtPesquisa.Rows.Count;
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
                dtPesquisa.DataSource = null;
            }
        }

        private void dtPesquisa_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtPesquisa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtPesquisa.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[6].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[7].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[8].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[9].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[10].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[11].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[12].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[13].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[14].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[15].DefaultCellStyle.Format = "n2";

            dtPesquisa.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtPesquisa.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtPesquisa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por data da Venda, código, consumidor e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmPesqVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqVenda foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqVenda foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqVenda.");
                }
            }
        }

        private void mtxtpData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
