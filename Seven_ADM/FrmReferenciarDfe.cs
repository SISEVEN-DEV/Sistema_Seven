using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmReferenciarDfe : Form
    {
        public FrmReferenciarDfe(string cod_dfe)
        {
            InitializeComponent();
            _Cod_DFe = cod_dfe;
        }

        private string _Cod_DFe;
        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;

        private void FrmReferenciarDfe_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmReferenciarDfe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmReferenciarDfe iniciado.");
                }
                //
                if (_Cod_DFe == null)
                {
                    if (bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao) != null)
                    {
                        dtRef.DataSource = bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao);
                        dtRef.Select();
                    }
                    else
                    {
                        btnNovo.Select();
                    }
                }
                else
                {
                    if (bllDFe.Sel_Referencia_DFe(_Cod_DFe) != null)
                    {
                        dtRef.DataSource = bllDFe.Sel_Referencia_DFe(_Cod_DFe);
                        dtRef.Select();
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
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmReferenciarDfe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmReferenciarDfe.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            mtxtChave.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            lblCodigo.Enabled = false;
            btnSalvar.Enabled = false;
            if (dtRef.DataSource != null)
            {
                dtRef.Enabled = true;
                dtRef.Select();
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

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirItem_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtChave.Select();
            }
        }

        private void mtxtChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void mtxtChave_Enter(object sender, EventArgs e)
        {
            mtxtChave.BackColor = Color.LightBlue;
        }

        private void mtxtChave_Leave(object sender, EventArgs e)
        {
            mtxtChave.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtChave.Text != "")
            {
                if (mtxtChave.Text.Length < 44)
                {
                    mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    MessageBox.Show("A Chave informada é inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtChave.Text = null;
                    mtxtChave.Select();
                    return;
                }
                //
                mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                try
                {
                    if (_Inserir_Atualizar == true)
                    {
                        if (_Cod_DFe == null)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllDFe.Val_Referencia_Chave_Alt_Temp(txtCodigo.Text, mtxtChave.Text) == true)
                                {
                                    MessageBox.Show("A Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtChave.Text = null;
                                    mtxtChave.Select();
                                }
                            }
                            else
                            {

                                if (bllDFe.Val_Referencia_Chave_Temp(mtxtChave.Text) == true)
                                {
                                    MessageBox.Show("A Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtChave.Text = null;
                                    mtxtChave.Select();
                                }
                            }
                        }
                        else
                        {
                            if (_Comando_Atualizar == true)
                            {
                                DataGridViewRow SelectedRow = dtRef.Rows[dtRef.CurrentRow.Index];

                                if (bllDFe.Val_Referencia_Chave_Alt(SelectedRow.Cells[2].Value.ToString(), mtxtChave.Text, _Cod_DFe) == true)
                                {
                                    MessageBox.Show("A Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtChave.Text = null;
                                    mtxtChave.Select();
                                }
                            }
                            else
                            {
                                if (bllDFe.Val_Referencia_Chave(mtxtChave.Text, _Cod_DFe) == true)
                                {
                                    MessageBox.Show("A Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtChave.Text = null;
                                    mtxtChave.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    mtxtChave.Text = null;
                }
            }
            mtxtChave.BackColor = Color.White;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            dtRef.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtRef.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            mtxtChave.Select();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
            Limpar();
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtRef.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox2.Enabled = true;
            btnNovo.Enabled = false;
            btnCancelar.Visible = true;
            lblCodigo.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            dtRef.Enabled = false;
            txtCodigo.Enabled = true;
            mtxtChave.Select();
            _Comando_Atualizar = true;
            _Inserir_Atualizar = true;
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
                if (dtRef.DataSource == null)
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
            _Inserir_Atualizar = false;
            ModoPesquisa();
        }

        private void FrmReferenciarDfe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    mtxtChave.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtChave.Text.Trim() == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\rCampo: [ Chave ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        //
                        mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (_Comando_Atualizar == true)
                        {
                            DataGridViewRow SelectedRow = dtRef.Rows[dtRef.CurrentRow.Index];

                            if (_Cod_DFe == null)
                            {
                                bllDFe.Alterar_Referencia_Temp(SelectedRow.Cells[2].Value.ToString(), mtxtChave.Text, bllConexao._Codigo_Conexao);

                                dtRef.DataSource = bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao);
                            }
                            else
                            {
                                bllDFe.Alterar_Referencia(SelectedRow.Cells[2].Value.ToString(), mtxtChave.Text);

                                dtRef.DataSource = bllDFe.Sel_Referencia_DFe(_Cod_DFe);
                            }
                            //
                            dtRef.CurrentCell = dtRef.Rows[dtRef.Rows.Count - 1].Cells[0];
                            //
                            dtRef.Rows[dtRef.Rows.Count - 1].Selected = true;
                            //
                            dtRef.FirstDisplayedScrollingRowIndex = dtRef.Rows.Count - 1;

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            ModoPesquisa();

                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            if (_Cod_DFe == null)
                            {
                                bllDFe.Salvar_Referencia_Temp(dtRef.Rows.Count.ToString(), mtxtChave.Text, bllConexao._Codigo_Conexao);

                                dtRef.DataSource = bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao);
                            }
                            else
                            {
                                bllDFe.Salvar_Referencia(dtRef.Rows.Count.ToString(), mtxtChave.Text, _Cod_DFe);
                                //
                                dtRef.DataSource = bllDFe.Sel_Referencia_DFe(_Cod_DFe);
                            }
                            //
                            dtRef.CurrentCell = dtRef.Rows[dtRef.Rows.Count - 1].Cells[0];
                            //
                            dtRef.Rows[dtRef.Rows.Count - 1].Selected = true;
                            //
                            dtRef.FirstDisplayedScrollingRowIndex = dtRef.Rows.Count - 1;

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            ModoPesquisa();

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    mtxtChave.Select();
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtRef.DataSource = null;
                Limpar();
                ModoPesquisa();
            }
        }

        private void dtRef_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtRef.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtRef.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtRef.Enabled = true;
            }
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou no botão: [ Novo ] ou no botão: [ Alterar ] e não deseja continuar nessas opções, clique no botão: [ Cancelar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmReferenciarDfe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmReferenciarDfe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmReferenciarDfe foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmReferenciarDfe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmReferenciarDfe.");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja excluir esta Referencia?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    DataGridViewRow SelectedRow = dtRef.Rows[dtRef.CurrentRow.Index];

                    if (_Cod_DFe == null)
                    {
                        bllDFe.Excluir_Referencia_Temp(txtCodigo.Text);
                        //
                        bllDFe.Atualizar_Item_Dt_Referencia_DFe_Temp(dtRef.CurrentRow.Index + 1, dtRef.Rows.Count, bllConexao._Codigo_Conexao);
                        //
                        Limpar();
                        //
                        dtRef.DataSource = bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        bllDFe.Excluir_Referencia(SelectedRow.Cells[2].Value.ToString());
                        //
                        bllDFe.Atualizar_Item_Dt_Referencia_DFe(dtRef.CurrentRow.Index + 1, dtRef.Rows.Count, _Cod_DFe);
                        //
                        Limpar();
                        //
                        dtRef.DataSource = bllDFe.Sel_Referencia_DFe(_Cod_DFe);
                    }
                    //
                    if (dtRef.Rows.Count >= 1)
                    {
                        dtRef.CurrentCell = dtRef.Rows[dtRef.Rows.Count - 1].Cells[0];
                        //
                        dtRef.Rows[dtRef.Rows.Count - 1].Selected = true;
                        //
                        dtRef.FirstDisplayedScrollingRowIndex = dtRef.Rows.Count - 1;
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtRef.DataSource = null;
                Limpar();
                ModoPesquisa();
            }
        }

        private void dtRef_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtRef.Rows.Count;

            dtRef.Columns[0].HeaderText = "Código";
            dtRef.Columns[1].HeaderText = "Chave";
            if (_Cod_DFe != null)
            {
                dtRef.Columns[2].Visible = false;
            }
            dtRef.Columns[0].Width = 80;
            dtRef.Columns[1].Width = 395;

            dtRef.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtRef.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtRef.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtRef.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtRef.DefaultCellStyle.Font = new Font(dtRef.Font, FontStyle.Bold);
        }

        private void dtRef_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtRef_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtRef.Rows[dtRef.CurrentRow.Index];

                dtRef.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtRef.DefaultCellStyle.SelectionForeColor = Color.Black;

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                mtxtChave.Text = SelectedRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtRef.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtRef.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtRef.DataSource = null;
                Limpar();
                ModoPesquisa();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtRef_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtRef.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtRef_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurarDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarDFe_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqDFe NFe = new FrmPesqDFe(2))
            {
                if (NFe.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    try
                    {
                        mtxtChave.Text = bllDFe._Chave_DFe;
                        bllDFe._Chave_DFe = null;
                        txtCodigo.Select();
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
                        txtCodigo.Text = null;
                    }
                }
            }
            this.Enabled = true;
        }
    }
}
