using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace SIE_7_Sistema
{
    public partial class FrmCadDisciplina : Form
    {
        public FrmCadDisciplina()
        {
            InitializeComponent();
        }
        
        bool _Comando_Atualizar = false;
        bool _Inserir_Atualizar = false;
        
        private void Limpar() 
        {
            txtCodigo.Text = null;
            txtPalavraChave.Text = null;
            cbbTipoDisciplina.Text = null;
            mtxtCargaHoraria.Text = null;
            txtDescricao.Text = null;
            rtxtObs.Text = null;        
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtDisciplina.Enabled = true;
            dtDisciplina.Select();
        } 

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por descrição, código, palavra-chave, tipo de disciplina e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmCadDisciplina_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
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
                        if (_Comando_Atualizar == true)
                        {
                            if (bllDisciplina.Val_Disci_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true & _Inserir_Atualizar == true)
                            {
                                MessageBox.Show("Palavra-chave já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPalavraChave.Text = null;
                            }
                        }
                        else
                        {
                            if (bllDisciplina.Val_Disci_Palavra_Chave(txtPalavraChave.Text) == true & _Inserir_Atualizar == true)
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
                            if (bllDisciplina.Val_Disci_Descricao_Alt(txtCodigo.Text, txtDescricao.Text) == true & _Inserir_Atualizar == true)
                            {
                                MessageBox.Show("Descrição já está cadastrada, verifique.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDescricao.Text = null;
                            }
                        }
                        else
                        {
                            if (bllDisciplina.Val_Disci_Descricao(txtDescricao.Text) == true & _Inserir_Atualizar == true)
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

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtDescricao.Select();
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                mtxtCargaHoraria.Select();
            }
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtObs.Text = null;
            }
            rtxtObs.BackColor = Color.White;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnSalvar.Select();   
            }
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

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpCodigo.Text = null;
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbtnCodigo.Checked == true)
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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

        private void btnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
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

        private void FrmCadDisciplina_Load(object sender, EventArgs e)
        {
            bllDisciplina._FrmCadDisciplina_Ativo = true;
            txtpDescricao.Select();
        }

        private void pcibInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\r1 - Clicando no botão < Novo > você insere novos dados, ao finalizar clique no botão < Salvar >.\r2 - Clicando no botão < Alterar > você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão < Salvar >.\r3 - Clicando no botao < Excluir > você estará excluindo os dados selecionados na tabela.\r4 - Se por algum um motivo você clicou no botão: < Novo > ou no botão: < Alterar > e não deseja continuar nessas opções, clique no botão: < Cancelar >.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtDisciplina.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;           
            dtDisciplina.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            txtPalavraChave.Select();
            _Inserir_Atualizar = true;
            Limpar();            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtDisciplina.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;            
            grbBox2.Enabled = true;
            btnNovo.Enabled = false;
            btnCancelar.Visible = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            grbBox1.Enabled = false;
            dtDisciplina.Enabled = false;
            txtPalavraChave.Select();
            _Inserir_Atualizar = true;
            _Comando_Atualizar = true;
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
                if (dtDisciplina.DataSource == null)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtDisciplina_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtDisciplina.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtDisciplina_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                mtxtCargaHoraria.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (txtDescricao.Text == "" || cbbTipoDisciplina.Text == "" || mtxtCargaHoraria.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: < Descrição >, < Carga Horária > e < Tipo de Disciplina >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPalavraChave.Select();
                    mtxtCargaHoraria.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
                else
                {
                    try
                    {
                        mtxtCargaHoraria.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (_Comando_Atualizar == true)
                        {
                            bllDisciplina.Alterar(txtCodigo.Text, txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), mtxtCargaHoraria.Text.Trim(), cbbTipoDisciplina.Text, rtxtObs.Text); 

                            MessageBox.Show("Os dados foram alterados com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            dtDisciplina.DataSource = bllDisciplina.Sel_Disciplina_A_Alterar(txtCodigo.Text);

                            ModoPesquisa();                                                 
                        }
                        else
                        {
                            bllDisciplina.Salvar(txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), mtxtCargaHoraria.Text.Trim(), cbbTipoDisciplina.Text, rtxtObs.Text); 

                            MessageBox.Show("Os dados foram salvos com Sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            dtDisciplina.DataSource = bllDisciplina.Sel_Disciplina_A_Salvar();
                                                        
                            ModoPesquisa();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpDescricao.Text = null;
                        dtDisciplina.DataSource = null;
                        txtpDescricao.Select();
                        rbtnDescricao.Checked = true;
                        ModoPesquisa();
                        Limpar();
                        _Comando_Atualizar = false;                     
                    }
                }
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
                        if (bllDisciplina.Sel_Disci_Descricao(txtpDescricao.Text) == null)
                        {
                            dtDisciplina.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Descricao(txtpDescricao.Text);
                            dtDisciplina.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllDisciplina.Sel_Disci_Codigo(txtpCodigo.Text) == null)
                        {
                            dtDisciplina.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Codigo(txtpCodigo.Text);
                            dtDisciplina.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllDisciplina.Sel_Disci_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtDisciplina.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Palavra_Chave(txtpPalavraChave.Text);
                            dtDisciplina.Select();
                        }
                    }
                }
                else if (rbtnTipoDisciplina.Checked == true)
                {
                    if (bllDisciplina.Sel_Disci_Tipo_Disciplina(cbbpTipoDisciplina.Text) == null)
                    {
                        dtDisciplina.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Tipo_Disciplina(cbbpTipoDisciplina.Text);
                        dtDisciplina.Select();
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllDisciplina.Sel_Disci_Todos() == null)
                    {
                        dtDisciplina.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Todos();
                        dtDisciplina.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtDisciplina.DataSource = null;
                txtpDescricao.Select();
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;               
            }       
        }

        private void dtDisciplina_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtDisciplina.Columns[0].HeaderText = "Código";
                dtDisciplina.Columns[1].HeaderText = "Descrição";
                dtDisciplina.Columns[2].HeaderText = "Carga Horária(HH)";
                dtDisciplina.Columns[3].HeaderText = "Tipo de Disciplina";
                dtDisciplina.Columns[4].HeaderText = "Observações";
                dtDisciplina.Columns[5].HeaderText = "Palavra-chave";

                DataGridViewRow SelectedRow = dtDisciplina.Rows[dtDisciplina.CurrentRow.Index];

                dtDisciplina.Columns[0].Width = 55;
                dtDisciplina.Columns[1].Width = 350;
                dtDisciplina.Columns[2].Width = 125;
                dtDisciplina.Columns[3].Width = 190;
                dtDisciplina.Columns[4].Width = 500;
                dtDisciplina.Columns[5].Width = 95;

                dtDisciplina.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtDisciplina.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtDisciplina.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDisciplina.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtDisciplina.DefaultCellStyle.Font = new Font(dtDisciplina.Font, FontStyle.Bold);

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                mtxtCargaHoraria.Text = SelectedRow.Cells[2].Value.ToString();
                cbbTipoDisciplina.Text = SelectedRow.Cells[3].Value.ToString();
                rtxtObs.Text = SelectedRow.Cells[4].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[5].Value.ToString();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtDisciplina.DataSource = null;
                txtpDescricao.Select();
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;               
            }
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;            
            txtpCodigo.Visible = false;            
            lblPesquisar.Location = new Point(299, 21);
            lblPesquisar.Text = "Digite a descrição:";
            cbbpTipoDisciplina.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = true;            
            lblPesquisar.Location = new Point(565, 21);
            lblPesquisar.Text = "Digite o código:";
            cbbpTipoDisciplina.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = true;
            txtpCodigo.Visible = false;            
            lblPesquisar.Location = new Point(475, 21);
            lblPesquisar.Text = "Digite a palavra-chave:";
            cbbpTipoDisciplina.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {            
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;            
            lblPesquisar.Location = new Point(574, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            cbbpTipoDisciplina.Visible = false;
            txtpDescricao.Visible = false;            
            btnPesquisar.Select();
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpPalavraChave.Text = null;
            }  
            txtpPalavraChave.BackColor = Color.White;
        }

        private void dtDisciplina_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtDisciplina.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;          
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;               
            }
        }

        private void dtDisciplina_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtDisciplina_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtDisciplina.Rows.Count;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {            
            DialogResult = MessageBox.Show("Todos os dados desta disciplina serão excluídos, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    bllDisciplina.Excluir(txtCodigo.Text);
                    
                    if (rbtnTodos.Checked == true)
                    {
                        if (bllDisciplina.Sel_Disci_Todos() == null)
                        {
                            dtDisciplina.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Todos();
                            dtDisciplina.Select();
                        }
                    }
                    else if (rbtnDescricao.Checked == true)
                    {
                        if (txtpDescricao.Text != "")
                        {
                            if (bllDisciplina.Sel_Disci_Descricao(txtpDescricao.Text) == null)
                            {
                                dtDisciplina.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Descricao(txtpDescricao.Text);
                                dtDisciplina.Select();
                            }
                        }
                        else
                        {
                            dtDisciplina.DataSource = null;
                            Limpar();
                        }
                    }
                    else if (rbtnTipoDisciplina.Checked == true)
                    {
                        if (cbbTipoDisciplina.Text != "")
                        {
                            if (bllDisciplina.Sel_Disci_Tipo_Disciplina(cbbTipoDisciplina.Text) == null)
                            {
                                dtDisciplina.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtDisciplina.DataSource = bllDisciplina.Sel_Disci_Tipo_Disciplina(cbbTipoDisciplina.Text);
                                dtDisciplina.Select();
                            }
                        }
                        else 
                        {
                            dtDisciplina.DataSource = null;
                            Limpar();
                        }
                    }
                    else
                    {
                        dtDisciplina.DataSource = null;
                        Limpar();
                    }
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpDescricao.Text = null;
                    dtDisciplina.DataSource = null;
                    txtpDescricao.Select();
                    rbtnDescricao.Checked = true;
                    ModoPesquisa();
                    Limpar();
                    _Comando_Atualizar = false;                 
                }
            }
            else
            {
                if (dtDisciplina.DataSource != null)
                {
                    dtDisciplina.Select();
                }
            }
        }
            
        private void txtCargaHoraria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbTipoDisciplina.Select();
            }
        }

        private void FrmCadDisciplina_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllDisciplina._FrmCadDisciplina_Ativo = false;
        }
        
        private void mtxtHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                rtxtObs.Select();
            }
        }

        

        

        private void rbtnBaseComum_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnBaseComum_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnParteDiversificada_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnParteDiversificada_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDisciplina_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDisciplina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                rtxtObs.Select();
            }
        }

        private void cbbpTipoDisciplina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void cbbTipoDisciplina_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDisciplina_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoDisciplina_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoDisciplina_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoDisciplina_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoDisciplina_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTipoDisciplina_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(352, 21);
            lblPesquisar.Text = "Escolha o tipo de disciplina:";
            cbbpTipoDisciplina.Visible = true;
            txtpDescricao.Visible = false;
            cbbpTipoDisciplina.Text = null;
            cbbpTipoDisciplina.Select();
        }

        private void rbtnTipoDisciplina_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTipoDisciplina_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDisciplina_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtCargaHoraria_Enter(object sender, EventArgs e)
        {
            mtxtCargaHoraria.BackColor = Color.LightBlue;
        }

        private void mtxtCargaHoraria_Leave(object sender, EventArgs e)
        {
            mtxtCargaHoraria.BackColor = Color.White;
        }

        private void mtxtCargaHoraria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                cbbTipoDisciplina.Select();
            }
        }      
    }
}
