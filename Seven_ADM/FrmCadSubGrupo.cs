using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadSubGrupo : Form
    {
        public FrmCadSubGrupo(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario.Remove(0, 12);
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmCadSubGrupo_Load(object sender, EventArgs e)
        {
            try
            {
                bllSubGrupo._FrmCadSubgrupo_Ativo = true;

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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadSubGrupo iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadSubGrupo iniciado.");
                }

                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadSubGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadSubGrupo.");
                }
            }
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _ComboboxGrupo_Valor = null;

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtDescricao.Text = null;
            txtPalavraChave.Text = null;
            cbbGrupo.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtSubGrupo.DataSource != null)
            {
                dtSubGrupo.Enabled = true;
                dtSubGrupo.Select();
            }
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

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
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

        private void FrmCadSubGrupo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGrupo.Select();
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "")
            {
                try
                {
                    if (txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDescricao.Text = null;
                        txtDescricao.Select();
                    }
                    else
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllSubGrupo.Val_SubGrupo_Descricao_Alt(txtCodigo.Text, txtDescricao.Text, cbbGrupo.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada em um subgrupo para este grupo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
                                }
                            }
                            else
                            {
                                if (bllSubGrupo.Val_SubGrupo_Descricao(txtDescricao.Text, cbbGrupo.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada em um subgrupo para este grupo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    txtDescricao.Text = null;
                }
            }
            txtDescricao.BackColor = Color.White;
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(201, 21);
            txtpCodigo.Visible = false;
            cbbpGrupo.Visible = false;
            btnpGrupo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpPalavraChave.Visible = false;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(419, 21);
            txtpCodigo.Visible = true;
            cbbpGrupo.Visible = false;
            btnpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(429, 21);
            txtpCodigo.Visible = false;
            cbbpGrupo.Visible = false;
            btnpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            btnPesquisar.Select();
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
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

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
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
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void dtGrupo_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtSubGrupo.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtSubGrupo.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                dtSubGrupo.Enabled = true;
            }
        }

        private void dtSubGrupo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtSubGrupo.Rows.Count;
        }

        private void dtSubGrupo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtSubGrupo.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtSubGrupo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtSubGrupo.Columns[0].HeaderText = "Código";
                dtSubGrupo.Columns[1].HeaderText = "Descrição";
                dtSubGrupo.Columns[2].HeaderText = "Cód. do Grupo";
                dtSubGrupo.Columns[3].HeaderText = "Descrição do Grupo";
                dtSubGrupo.Columns[4].HeaderText = "Palavra-Chave";
                dtSubGrupo.Columns[5].Visible = false;

                DataGridViewRow SelectedRow = dtSubGrupo.Rows[dtSubGrupo.CurrentRow.Index];

                dtSubGrupo.Columns[0].Width = 95;
                dtSubGrupo.Columns[1].Width = 515;
                dtSubGrupo.Columns[2].Width = 105;
                dtSubGrupo.Columns[3].Width = 315;
                dtSubGrupo.Columns[4].Width = 125;

                dtSubGrupo.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtSubGrupo.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtSubGrupo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSubGrupo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtSubGrupo.DefaultCellStyle.Font = new Font(dtSubGrupo.Font, FontStyle.Bold);

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                cbbGrupo.Items.Clear();
                cbbGrupo.Items.Add(SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString());
                cbbGrupo.Text = SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtSubGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtSubGrupo.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtSubGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtSubGrupo.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtSubGrupo.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            txtPalavraChave.Select();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
            Limpar();

            try
            {
                cbbGrupo.Items.Clear();
                if (bllSubGrupo.Sel_Grupo_SubGrupo() == null)
                {
                    cbbGrupo.Text = null;
                }
                else
                {
                    cbbGrupo.Items.Add("");
                    foreach (DataRow dr in bllSubGrupo.Sel_Grupo_SubGrupo().Rows)
                    {
                        cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtSubGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllSubGrupo.Sel_Subgrupo_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtSubGrupo.Select();
                }
                else
                {
                    dtSubGrupo.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = true;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    grbBox1.Enabled = false;
                    dtSubGrupo.Enabled = false;
                    dtSubGrupo.Select();
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtPalavraChave.Select();
                    _Comando_Atualizar = true;
                    _Inserir_Atualizar = true;

                    _ComboboxGrupo_Valor = cbbGrupo.Text;

                    if (cbbGrupo.Text != "")
                    {
                        cbbGrupo.Items.Clear();
                        if (bllSubGrupo.Sel_Grupo_SubGrupo() == null)
                        {
                            cbbGrupo.Text = null;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllSubGrupo.Sel_Grupo_SubGrupo().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                    }

                    if (bllSubGrupo.Sel_ComboboxGrupo_Valor_A_Alterar_SubGrupo(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllSubGrupo.Sel_ComboboxGrupo_Valor_A_Alterar_SubGrupo(_ComboboxGrupo_Valor).Rows)
                        {
                            cbbGrupo.Text = dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString();
                        }
                        _ComboboxGrupo_Valor = null;
                    }
                    else
                    {
                        _ComboboxGrupo_Valor = null;
                        cbbGrupo.Text = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtSubGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
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
                if (dtSubGrupo.DataSource == null)
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _ComboboxGrupo_Valor = cbbGrupo.Text;

                if (cbbGrupo.Text != "")
                {
                    cbbGrupo.Items.Clear();
                    if (bllSubGrupo.Sel_Grupo_SubGrupo() == null)
                    {
                        cbbGrupo.Text = null;
                    }
                    else
                    {
                        cbbGrupo.Items.Add("");
                        foreach (DataRow dr in bllSubGrupo.Sel_Grupo_SubGrupo().Rows)
                        {
                            cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }

                    if (bllSubGrupo.Sel_ComboboxGrupo_Valor_A_Alterar_SubGrupo(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllSubGrupo.Sel_ComboboxGrupo_Valor_A_Alterar_SubGrupo(_ComboboxGrupo_Valor).Rows)
                        {
                            cbbGrupo.Text = dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString();
                        }
                        _ComboboxGrupo_Valor = null;
                    }
                    else
                    {
                        _ComboboxGrupo_Valor = null;
                        cbbGrupo.Text = null;
                    }
                }
                //
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (txtDescricao.Text.Trim() == "" || cbbGrupo.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Descrição ] e [ Grupo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllSubGrupo.Sel_Subgrupo_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                dtSubGrupo.DataSource = null;
                                Limpar();
                                ModoPesquisa();
                                rbtnDescricao.Checked = true;
                            }
                            else
                            {
                                bllSubGrupo.Alterar(txtCodigo.Text, txtDescricao.Text.Trim(), cbbGrupo.Text, txtPalavraChave.Text.Trim());

                                bllSubGrupo.Alterar_Descricao_Subgrupo_Conta_Receber(txtCodigo.Text, txtDescricao.Text.Trim());

                                bllSubGrupo.Alterar_Descricao_Subgrupo_Contas_Pagar(txtCodigo.Text, txtDescricao.Text.Trim());

                                bllSubGrupo.Alterar_Descricao_Subgrupo_Produto(txtCodigo.Text, txtDescricao.Text.Trim());

                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM SUBGRUPO", "SUBGRUPOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_A_Alt(txtCodigo.Text);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - SubGrupo alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - SubGrupo alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                //
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                //                            
                                ModoPesquisa();
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            bllSubGrupo.Salvar(txtDescricao.Text.Trim(), txtPalavraChave.Text.Trim(), cbbGrupo.Text);
                            //
                            dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_A_Sal();
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM SUBGRUPO.", "SUBGRUPOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - SubGrupo cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - SubGrupo cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            //
                            ModoPesquisa();
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    txtDescricao.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dtSubGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
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
                        if (bllSubGrupo.Sel_SubGrupo_Descricao(txtpDescricao.Text) == null)
                        {
                            dtSubGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_Descricao(txtpDescricao.Text);
                            dtSubGrupo.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllSubGrupo.Sel_SubGrupo_Codigo(txtpCodigo.Text) == null)
                        {
                            dtSubGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_Codigo(txtpCodigo.Text);
                            dtSubGrupo.Select();
                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    if (cbbpGrupo.Text != "")
                    {
                        if (bllSubGrupo.Sel_SubGrupo_Grupo(cbbpGrupo.Text) == null)
                        {
                            dtSubGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_Grupo(cbbpGrupo.Text);
                            dtSubGrupo.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllSubGrupo.Sel_SubGrupo_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtSubGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_Palavra_Chave(txtpPalavraChave.Text);
                            dtSubGrupo.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllSubGrupo.Sel_SubGrupo_Todos() == null)
                    {
                        dtSubGrupo.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_Todos();
                        dtSubGrupo.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou sub-grupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou sub-grupo.");
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtSubGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por descrição, código, grupo, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você alterar os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou no botão: [ Novo ] ou no botão: [ Alterar ] e não deseja continuar nessas opções, clique no botão: [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllSubGrupo.Sel_Subgrupo_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtSubGrupo.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Subgrupo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllSubGrupo.Sel_SubGrupo_Prod_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Produtos, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (bllSubGrupo.Sel_SubGrupo_Conta_Pagar_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Contas a Pagar, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (bllSubGrupo.Sel_SubGrupo_Conta_Receber_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Contas a Receber, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            bllSubGrupo.Excluir(txtCodigo.Text);

                            bllRegistroAtividades.Salvar("EXCLUIU UM SUBGRUPO", "SUBGRUPOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Subgrupo excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Subgrupo excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text != "")
                                {
                                    if (bllSubGrupo.Sel_SubGrupo_Descricao(txtDescricao.Text) == null)
                                    {
                                        dtSubGrupo.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_Descricao(txtpDescricao.Text);
                                        dtSubGrupo.Select();
                                    }
                                }
                                else
                                {
                                    dtSubGrupo.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnTodos.Checked == true)
                            {
                                if (bllSubGrupo.Sel_SubGrupo_Todos() == null)
                                {
                                    dtSubGrupo.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtSubGrupo.DataSource = bllSubGrupo.Sel_SubGrupo_Todos();
                                    dtSubGrupo.Select();
                                }
                            }
                            else
                            {
                                dtSubGrupo.DataSource = null;
                                Limpar();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        if (dtSubGrupo.DataSource != null)
                        {
                            dtSubGrupo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dtSubGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtPalavraChave.Text.Contains("'") || txtPalavraChave.Text.Contains(";") || txtPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPalavraChave.Text = null;
                txtPalavraChave.Select();
            }
            else
            {
                if (_Inserir_Atualizar == true)
                {
                    try
                    {
                        if (txtPalavraChave.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllSubGrupo.Sel_SubGrupo_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllSubGrupo.Sel_SubGrupo_Palavra_Chave_Ver(txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                        }
                        txtPalavraChave.Text = null;
                    }
                }
            }
            txtPalavraChave.BackColor = Color.White;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(338, 21);
            txtpCodigo.Visible = false;
            cbbpGrupo.Visible = false;
            btnpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Visible = true;
            txtpPalavraChave.Select();
        }

        private void FrmCadSubGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadSubGrupo foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadSubGrupo foi finalizado.");
                }
                bllSubGrupo._FrmCadSubgrupo_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadSubGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadSubGrupo.");
                }
            }
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(1))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbGrupo.Items.Clear();
                        if (bllSubGrupo.Sel_Grupo_SubGrupo() == null)
                        {
                            cbbGrupo.Text = null;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllSubGrupo.Sel_Grupo_SubGrupo().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbGrupo.Text = bllSubGrupo._Grupo_PesqGrupo_Tabela;
                        bllSubGrupo._Grupo_PesqGrupo_Tabela = null;
                        cbbGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        bllSubGrupo._Grupo_PesqGrupo_Tabela = null;
                        cbbGrupo.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void rbtnGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnGrupo_MouseLeave(object sender, EventArgs e)
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

        private void rbtnGrupo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpGrupo.Items.Clear();
                if (bllSubGrupo.Sel_Grupo_SubGrupo() == null)
                {
                    cbbpGrupo.Text = null;
                }
                else
                {
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllSubGrupo.Sel_Grupo_SubGrupo().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
            }
            //
            lblPesquisar.Text = "Escolha o grupo:";
            lblPesquisar.Location = new Point(212, 21);
            txtpCodigo.Visible = false;
            cbbpGrupo.Visible = true;
            btnpGrupo.Visible = true;
            txtpDescricao.Visible = false;
            cbbpGrupo.Text = null;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Select();
        }

        private void btnpGrupo_Click(object sender, EventArgs e)
        {
            grbBox1.Enabled = false;
            dtSubGrupo.Enabled = false;
            lblRegistros.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSair.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(1))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllSubGrupo.Sel_Grupo_SubGrupo() == null)
                        {
                            cbbpGrupo.Text = null;
                        }
                        else
                        {
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllSubGrupo.Sel_Grupo_SubGrupo().Rows)
                            {
                                cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbpGrupo.Text = bllSubGrupo._Grupo_PesqGrupo_Tabela;
                        bllSubGrupo._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        cbbGrupo.Text = null;
                        bllSubGrupo._Grupo_PesqGrupo_Tabela = null;
                    }
                }
            }
            grbBox1.Enabled = true;
            if (dtSubGrupo.DataSource != null)
            {
                dtSubGrupo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                dtSubGrupo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            lblRegistros.Enabled = true;
            btnNovo.Enabled = true;
            btnSair.Enabled = true;
        }

        private void btnpGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbGrupo_Leave(object sender, EventArgs e)
        {
            if (cbbGrupo.Text != "")
            {
                try
                {
                    if (_Inserir_Atualizar == true)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllSubGrupo.Val_SubGrupo_Descricao_Alt(txtCodigo.Text, txtDescricao.Text, cbbGrupo.Text) == true)
                            {
                                MessageBox.Show("O Grupo informado já possui cadastrado um subgrupo com esta descrição.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbbGrupo.Text = null;
                                cbbGrupo.Select();
                            }
                        }
                        else
                        {
                            if (bllSubGrupo.Val_SubGrupo_Descricao(txtDescricao.Text, cbbGrupo.Text) == true)
                            {
                                MessageBox.Show("O Grupo informado já possui cadastrado um subgrupo com esta descrição.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbbGrupo.Text = null;
                                cbbGrupo.Select();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do combo caixa cbbGrupo.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do combo caixa cbbGrupo.");
                    }
                    cbbGrupo.Text = null;
                }
            }
            txtDescricao.BackColor = Color.White;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPalavraChave.Select();
            }
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
