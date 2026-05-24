using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Globalization;

namespace SIE_7_Sistema
{
    public partial class FrmCadCurso : Form
    {
        public FrmCadCurso()
        {
            InitializeComponent();
        }

        private void FrmMatriculaTurmaAluno_Load(object sender, EventArgs e)
        {
            bllCurso._FrmCadCurso_Ativo = true;
            txtpDescricao.Select();
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Ou_Atualizar = false;

        private void Limpar() 
        {
            txtCodigo.Text = null;
            txtPalavraChave.Text = null;
            txtDescricao.Text = null;
            txtSigla.Text = null;
            rtxtObs.Text = null;        
        }

        private void ModoPesquisa() 
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtCurso.Enabled = true;
            dtCurso.Select();
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(182, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpDescricao.Select();        
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {           
            txtpPalavraChave.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(397, 21);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();      
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            lblPesquisar.Location = new Point(483, 21);
            lblPesquisar.Text = "Digite o código:";            
            txtpCodigo.Text = null;
            txtpCodigo.Select();
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
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

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpPalavraChave.Text = null;
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
            if (txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpCodigo.Text = null;
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtDescricao.Select();
            }
        }

        private void txtPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtPalavraChave.Text != "")
            {
                try
                {
                    if (txtPalavraChave.Text.Contains(";") || txtPalavraChave.Text.Contains("'") || txtPalavraChave.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPalavraChave.Text = null;
                    }
                    else
                    {
                        if (_Comando_Atualizar == true & _Inserir_Ou_Atualizar == true)
                        {
                            if (bllCurso.Val_Curso_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                            {
                                MessageBox.Show("Palavra-chave já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPalavraChave.Text = null;
                            }
                        }
                        else
                        {
                            if (bllCurso.Val_Curso_Palavra_Chave(txtPalavraChave.Text) == true & _Inserir_Ou_Atualizar == true)
                            {
                                MessageBox.Show("Palavra-chave já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPalavraChave.Text = null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPalavraChave.Text = null;
                }
            }
            txtPalavraChave.BackColor = Color.White;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                rtxtObs.Select();
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
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllCurso.Val_Curso_Descricao_Alt(txtCodigo.Text, txtDescricao.Text) == true & _Inserir_Ou_Atualizar == true)
                            {
                                MessageBox.Show("Descrição já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDescricao.Text = null;
                            }
                        }
                        else
                        {
                            if (bllCurso.Val_Curso_Descricao(txtDescricao.Text) == true & _Inserir_Ou_Atualizar == true)
                            {
                                MessageBox.Show("Descrição já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDescricao.Text = null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescricao.Text = null;
                }
            }
            txtDescricao.BackColor = Color.White;
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.White;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtSigla_Enter(object sender, EventArgs e)
        {
            txtSigla.BackColor = Color.LightBlue;
        }

        private void txtSigla_Leave(object sender, EventArgs e)
        {
            if (txtSigla.Text != "")
            {
                try
                {
                    if (txtSigla.Text.Contains(";") || txtSigla.Text.Contains("'") || txtSigla.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSigla.Text = null;
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllCurso.Val_Curso_Sigla_Alt(txtCodigo.Text, txtSigla.Text) == true & _Inserir_Ou_Atualizar == true)
                            {
                                MessageBox.Show("Sigla já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtSigla.Text = null;
                            }
                        }
                        else
                        {
                            if (bllCurso.Val_Curso_Sigla(txtSigla.Text) == true & _Inserir_Ou_Atualizar == true)
                            {
                                MessageBox.Show("Sigla já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtSigla.Text = null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSigla.Text = null;
                }
            }
            txtSigla.BackColor = Color.White;
        }

        private void txtSigla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                rtxtObs.Select();
            }
        }

        private void FrmCadCurso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
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
                        if (bllCurso.Sel_Descricao_Curso(txtpDescricao.Text) == null)
                        {
                            dtCurso.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtCurso.DataSource = bllCurso.Sel_Descricao_Curso(txtpDescricao.Text);
                            dtCurso.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllCurso.Sel_Codigo_Curso(txtpCodigo.Text) == null)
                        {
                            dtCurso.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtCurso.DataSource = bllCurso.Sel_Codigo_Curso(txtpCodigo.Text);
                            dtCurso.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllCurso.Sel_Palavra_Chave_Curso(txtpPalavraChave.Text) == null)
                        {
                            dtCurso.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtCurso.DataSource = bllCurso.Sel_Palavra_Chave_Curso(txtpPalavraChave.Text);
                            dtCurso.Select();
                        }
                    }
                }
                else if (rbtnSigla.Checked == true) 
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllCurso.Sel_Sigla_Curso(txtpPalavraChave.Text) == null)
                        {
                            dtCurso.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtCurso.DataSource = bllCurso.Sel_Sigla_Curso(txtpPalavraChave.Text);
                            dtCurso.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllCurso.Sel_Todos_Curso() == null)
                    {
                        dtCurso.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtCurso.DataSource = bllCurso.Sel_Todos_Curso();
                        dtCurso.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtCurso.DataSource = null;
                txtpDescricao.Select();
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void rbtnSigla_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(452, 21);
            lblPesquisar.Text = "Digite a sigla:";
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();      
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(496, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            txtpDescricao.Visible = false;           
            btnPesquisar.Select();
        }

        private void rbtnSigla_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnSigla_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
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

        private void btnExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtCurso.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtCurso.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnAdicionarDisciplina.Enabled = false;
            btnAdicionarProfessor.Enabled = false;
            btnSalvar.Enabled = true;
            txtPalavraChave.Select();
            _Inserir_Ou_Atualizar = true;
            Limpar();            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtCurso.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox2.Enabled = true;
            btnNovo.Enabled = false;
            btnCancelar.Visible = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            grbBox1.Enabled = false;
            btnAdicionarDisciplina.Enabled = true;
            btnAdicionarProfessor.Enabled = true;
            dtCurso.Enabled = false;
            txtPalavraChave.Select();
            _Inserir_Ou_Atualizar = true;
            _Comando_Atualizar = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Todos os dados desta disciplina serão excluídos, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    bllCurso.Excluir(txtCodigo.Text);

                    if (rbtnDescricao.Checked == true)
                    {
                        if (txtpDescricao.Text != "")
                        {
                            if (bllCurso.Sel_Descricao_Curso(txtpDescricao.Text) == null)
                            {
                                dtCurso.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtCurso.DataSource = bllCurso.Sel_Descricao_Curso(txtpDescricao.Text);
                                dtCurso.Select();
                            }
                        }
                        else
                        {
                            dtCurso.DataSource = null;
                            Limpar();
                        }
                    }
                    else if (rbtnTodos.Checked == true)
                    {
                        if (bllCurso.Sel_Todos_Curso() == null)
                        {
                            dtCurso.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtCurso.DataSource = bllCurso.Sel_Todos_Curso();
                            dtCurso.Select();
                        }
                    }
                    else
                    {
                        dtCurso.DataSource = null;
                        Limpar();
                    }
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpDescricao.Text = null;
                    dtCurso.DataSource = null;
                    txtpDescricao.Select();
                    rbtnDescricao.Checked = true;
                    ModoPesquisa();
                    Limpar();
                    _Comando_Atualizar = false;
                }
            }
            else
            {
                if (dtCurso.DataSource != null)
                {
                    dtCurso.Select();
                }
            }
        }

        private void dtCurso_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtCurso.Columns[0].HeaderText = "Código";
                dtCurso.Columns[1].HeaderText = "Descrição";
                dtCurso.Columns[2].HeaderText = "Sigla";
                dtCurso.Columns[3].HeaderText = "Valor do Curso (R$)";
                dtCurso.Columns[4].HeaderText = "Observações";
                dtCurso.Columns[5].HeaderText = "Palavra-chave";

                DataGridViewRow SelectedRow = dtCurso.Rows[dtCurso.CurrentRow.Index];

                dtCurso.Columns[0].Width = 55;
                dtCurso.Columns[1].Width = 350;
                dtCurso.Columns[2].Width = 125;
                dtCurso.Columns[3].Width = 162;
                dtCurso.Columns[4].Width = 500;
                dtCurso.Columns[5].Width = 95;

                dtCurso.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtCurso.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtCurso.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCurso.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtCurso.DefaultCellStyle.Font = new Font(dtCurso.Font, FontStyle.Bold);

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                txtSigla.Text = SelectedRow.Cells[2].Value.ToString();
                dtCurso.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtCurso.Columns[3].DefaultCellStyle.Format = "c";
                txtValorCurso.Text = Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR"));
                rtxtObs.Text = SelectedRow.Cells[4].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[5].Value.ToString();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtCurso.DataSource = null;
                txtpDescricao.Select();
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();                
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
                if (dtCurso.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnAdicionarDisciplina.Enabled = true;
                    btnAdicionarProfessor.Enabled = true;
                }
            }
            _Inserir_Ou_Atualizar = false;
            ModoPesquisa();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\r1 - Clicando no botão < Novo > você insere novos dados, ao finalizar clique no botão < Salvar >.\r2 - Clicando no botão < Alterar > você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão < Salvar >.\r3 - Clicando no botao < Excluir > você estará excluindo os dados selecionados na tabela.\r4 - Se por algum um motivo você clicou no botão: < Novo > ou no botão: < Alterar > e não deseja continuar nessas opções, clique no botão: < Cancelar >.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pcibInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por descrição, código, palavra-chave, sigla e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (txtDescricao.Text.Trim() == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\rCampo: < Descrição >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPalavraChave.Select();
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            bllCurso.Alterar(txtCodigo.Text, txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), txtValorCurso.Text.Trim(), txtSigla.Text.Trim(), rtxtObs.Text);

                            MessageBox.Show("Os dados foram alterados com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _Comando_Atualizar = false;
                            _Inserir_Ou_Atualizar = false;

                            dtCurso.DataSource = bllCurso.Sel_Cur_A_Alt(txtCodigo.Text);

                            ModoPesquisa();
                        }
                        else
                        {
                            bllCurso.Salvar(txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), txtValorCurso.Text.Trim(), rtxtObs.Text, txtSigla.Text.Trim());

                            MessageBox.Show("Os dados foram salvos com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _Comando_Atualizar = false;
                            _Inserir_Ou_Atualizar = false;

                            dtCurso.DataSource = bllCurso.Sel_Cur_A_Sal();

                            ModoPesquisa();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpDescricao.Text = null;
                        dtCurso.DataSource = null;
                        txtpDescricao.Select();
                        rbtnDescricao.Checked = true;
                        ModoPesquisa();
                        Limpar();
                        _Comando_Atualizar = false;
                    }
                }
            }
        }

        private void dtCurso_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtCurso.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                btnAdicionarDisciplina.Enabled = false;
                btnAdicionarProfessor.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnAdicionarDisciplina.Enabled = true;
                btnAdicionarProfessor.Enabled = true;
            }
        }

        private void dtCurso_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtCurso.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtCurso_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllCurso._FrmCadCurso_Ativo = false;
        }

        private void btnAdicionarDisciplina_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAdicionarDisciplina_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAdicionarProfessor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAdicionarProfessor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAdicionarDisciplina_Click(object sender, EventArgs e)
        {
            using (FrmCadCursoDisciplina Disci = new FrmCadCursoDisciplina()) 
            {
                if (Disci.ShowDialog() == DialogResult.OK) 
                {
                    btnAdicionarDisciplina.Select();
                }
            }
        }

        private void btnAdicionarProfessor_Click(object sender, EventArgs e)
        {
            using (FrmCadCursoProfessor Prof = new FrmCadCursoProfessor()) 
            {
                if (Prof.ShowDialog() == DialogResult.OK) 
                {
                    btnAdicionarProfessor.Select();
                }
            }
        }

        private void txtValorCurso_Enter(object sender, EventArgs e)
        {
            txtValorCurso.BackColor = Color.LightBlue;
        }

        private void txtValorCurso_Leave(object sender, EventArgs e)
        {
            txtValorCurso.BackColor = Color.White;
        }

        private void txtValorCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorCurso.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();
            }
        }       
    }
}
