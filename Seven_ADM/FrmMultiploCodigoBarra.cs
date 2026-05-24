using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmMultiploCodigoBarra : Form
    {
        public FrmMultiploCodigoBarra(string cod_produto, string cod_barra_atual)
        {
            InitializeComponent();
            _Cod_Produto = cod_produto;
            _Cod_Barra_Atual = cod_barra_atual;
        }

        private bool _Inserir_Atualizar;
        private string _Cod_Produto;
        private string _Cod_Barra_Atual;

        private void FrmCadComputadores_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMultiploCodigoBarra iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMultiploCodigoBarra iniciado.");
                }
                //
                if (_Cod_Produto != "")
                {
                    if (bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos(_Cod_Produto) != null)
                    {
                        dtBarra.Enabled = true;
                        //
                        dtBarra.DataSource = bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos(_Cod_Produto);
                        //
                        dtBarra.Select();
                    }
                    else
                    {
                        btnNovo.Select();
                    }
                }
                else
                {
                    if (bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos_Temp() != null)
                    {
                        dtBarra.Enabled = true;
                        //
                        dtBarra.DataSource = bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos_Temp();
                        //
                        dtBarra.Select();
                    }
                    else
                    {
                        btnNovo.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMultiploCodigoBarra.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMultiploCodigoBarra.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtBarra.Text = null;
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmMultiploCodigoBarra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmMultiploCodigoBarra_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMultiploCodigoBarra foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMultiploCodigoBarra foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmMultiploCodigoBarra.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmMultiploCodigoBarra.");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n3 - Se por algum um motivo você clicou no botão [ Novo ] e não deseja continuar nessa opção, clique no\nbotão [ Cancelar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtBarra_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBarra.Text != "")
                {
                    if (txtBarra.Text.Contains(";") || txtBarra.Text.Contains("'") || txtBarra.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtBarra.Text = null;
                        txtBarra.Select();
                    }
                    else
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Cod_Produto != "")
                            {
                                if (bllMultiploCodigoBarra.Val_Mult_Barra(txtBarra.Text) == true)
                                {
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                                else if (txtBarra.Text == _Cod_Barra_Atual)
                                {
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                            }
                            else
                            {
                                if (bllMultiploCodigoBarra.Val_Mult_Barra_Temp(txtBarra.Text) == true)
                                {
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                                else if (bllMultiploCodigoBarra.Val_Mult_Barra(txtBarra.Text) == true)
                                {
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                                else if (txtBarra.Text == _Cod_Barra_Atual)
                                {
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                            }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtBarra.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtBarra.");
                }
                txtBarra.Text = null;
            }
            txtBarra.BackColor = Color.White;
        }

        private void txtBarra_Enter(object sender, EventArgs e)
        {
            txtBarra.BackColor = Color.LightBlue;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                _Inserir_Atualizar = true;
                dtBarra.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtBarra.Enabled = false;
                grbBox1.Enabled = true;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                Limpar();
                txtBarra.Select();
                //
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
                dtBarra.DataSource = null;
                grbBox1.Enabled = false;
                Limpar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtBarra.DataSource == null)
            {
                Limpar();
                dtBarra.Enabled = false;
            }
            else
            {
                Limpar();
                btnExcluir.Enabled = true;
                dtBarra.Enabled = true;
                dtBarra.Select();
            }
            _Inserir_Atualizar = false;
            grbBox1.Enabled = false;
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (txtBarra.Text.Trim() == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Código de Barras ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtBarra.Select();
                    }
                    else
                    {
                        if (_Cod_Produto == "")
                        {
                            bllMultiploCodigoBarra.Salvar_Temp((dtBarra.Rows.Count + 1).ToString(), txtBarra.Text.Trim());
                            //
                            dtBarra.Enabled = true;
                            //
                            dtBarra.DataSource = bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos_Temp();
                            //
                            dtBarra.CurrentCell = dtBarra.Rows[dtBarra.Rows.Count - 1].Cells[0];
                            //
                            dtBarra.Rows[dtBarra.Rows.Count - 1].Selected = true;
                            //
                            dtBarra.FirstDisplayedScrollingRowIndex = dtBarra.Rows.Count - 1;
                            //
                            dtBarra.Select();
                        }
                        else
                        {
                            bllMultiploCodigoBarra.Salvar((dtBarra.Rows.Count + 1).ToString(), txtBarra.Text.Trim(), _Cod_Produto);
                            //
                            dtBarra.Enabled = true;
                            //
                            dtBarra.DataSource = bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos(_Cod_Produto);
                            //
                            dtBarra.CurrentCell = dtBarra.Rows[dtBarra.Rows.Count - 1].Cells[1];
                            //
                            dtBarra.Rows[dtBarra.Rows.Count - 1].Selected = true;
                            //
                            dtBarra.FirstDisplayedScrollingRowIndex = dtBarra.Rows.Count - 1;
                            //
                            dtBarra.Select();
                        }
                        //
                        grbBox1.Enabled = false;
                        btnNovo.Enabled = true;
                        btnSalvar.Enabled = false;
                        btnCancelar.Visible = false;
                        _Inserir_Atualizar = false;
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    txtBarra.Select();
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                _Inserir_Atualizar = false;
                dtBarra.DataSource = null;
                grbBox1.Enabled = false;
                btnNovo.Enabled = true;
                btnCancelar.Visible = false;
                btnSalvar.Enabled = false;
                Limpar();
            }
        }

        private void dtBarra_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_Cod_Produto == "")
            {
                dtBarra.Columns[0].HeaderText = "Item";
                dtBarra.Columns[1].HeaderText = "Código de Barras";
                //
                dtBarra.Columns[0].Width = 85;
                dtBarra.Columns[1].Width = 330;
                //
                dtBarra.DefaultCellStyle.Font = new Font(dtBarra.Font, FontStyle.Bold);

                dtBarra.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtBarra.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtBarra.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtBarra.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                dtBarra.Columns[0].Visible = false;
                dtBarra.Columns[1].HeaderText = "Item";
                dtBarra.Columns[2].HeaderText = "Código de Barras";
                dtBarra.Columns[3].Visible = false;
                //
                dtBarra.Columns[1].Width = 85;
                dtBarra.Columns[2].Width = 330;
                //
                dtBarra.DefaultCellStyle.Font = new Font(dtBarra.Font, FontStyle.Bold);

                dtBarra.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtBarra.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtBarra.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtBarra.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //
            lblRegistros.Text = "Registros: " + dtBarra.Rows.Count;
        }

        private void dtBarra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_Cod_Produto == "")
                {
                    DataGridViewRow SelectedRow = dtBarra.Rows[dtBarra.CurrentRow.Index];

                    dtBarra.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtBarra.DefaultCellStyle.SelectionForeColor = Color.Black;
                    //
                    txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                    txtBarra.Text = SelectedRow.Cells[1].Value.ToString();
                }
                else
                {
                    DataGridViewRow SelectedRow = dtBarra.Rows[dtBarra.CurrentRow.Index];

                    dtBarra.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtBarra.DefaultCellStyle.SelectionForeColor = Color.Black;
                    //
                    txtCodigo.Text = SelectedRow.Cells[1].Value.ToString();
                    txtBarra.Text = SelectedRow.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtBarra.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtBarra.");
                }
                dtBarra.DataSource = null;
                grbBox1.Enabled = false;
                btnNovo.Enabled = true;
                btnCancelar.Visible = false;
                btnSalvar.Enabled = false;
                Limpar();
            }
        }

        private void dtBarra_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtBarra.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Cod_Produto != "")
                {
                    DataGridViewRow SelectedRow = dtBarra.Rows[dtBarra.CurrentRow.Index];
                    //
                    if (bllMultiploCodigoBarra.Sel_Codigo_Barras_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                    {
                        MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtBarra.Select();
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("Deseja excluir este Código de Barras?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            bllMultiploCodigoBarra.Excluir(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllMultiploCodigoBarra.Atualizar_Item_Dt_Barra(dtBarra.CurrentRow.Index + 1, dtBarra.Rows.Count);
                            //
                            if (bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos(_Cod_Produto) != null)
                            {
                                dtBarra.DataSource = bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos(_Cod_Produto);
                                //
                                dtBarra.CurrentCell = dtBarra.Rows[dtBarra.Rows.Count - 1].Cells[1];
                                //
                                dtBarra.Rows[dtBarra.Rows.Count - 1].Selected = true;
                                //
                                dtBarra.FirstDisplayedScrollingRowIndex = dtBarra.Rows.Count - 1;
                                //
                                dtBarra.Select();
                            }
                            else
                            {
                                dtBarra.DataSource = null;
                                Limpar();
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
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Código de Barras?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        bllMultiploCodigoBarra.Excluir_Temp(txtCodigo.Text);
                        //
                        bllMultiploCodigoBarra.Atualizar_Item_Dt_Barra_Temp(dtBarra.CurrentRow.Index + 1, dtBarra.Rows.Count);
                        //
                        if (bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos_Temp() != null)
                        {
                            dtBarra.DataSource = bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos_Temp();
                            //
                            dtBarra.CurrentCell = dtBarra.Rows[dtBarra.Rows.Count - 1].Cells[0];
                            //
                            dtBarra.Rows[dtBarra.Rows.Count - 1].Selected = true;
                            //
                            dtBarra.FirstDisplayedScrollingRowIndex = dtBarra.Rows.Count - 1;
                            //
                            dtBarra.Select();
                        }
                        else
                        {
                            dtBarra.DataSource = null;
                            Limpar();
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
                dtBarra.DataSource = null;
                grbBox1.Enabled = false;
                btnNovo.Enabled = true;
                btnCancelar.Visible = false;
                btnSalvar.Enabled = false;
                Limpar();
            }
        }

        private void dtBarra_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtBarra.DataSource == null)
            {
                btnExcluir.Enabled = false;
                dtBarra.Enabled = false;
            }
            else
            {
                dtBarra.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void dtBarra_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }
    }
}
