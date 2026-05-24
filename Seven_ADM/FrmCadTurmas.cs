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
    public partial class FrmCadTurmas : Form
    {
        public FrmCadTurmas()
        {
            InitializeComponent();
        }

        private bool _Comando_Atualizar;

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadTurmas_Load(object sender, EventArgs e)
        {
            txtpNome.Select();
        }

        private void FrmCadTurmas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }
        }

        public void Limpar() 
        {
            txtCodigo.Text = null;
            cbbNomeCurso.Text = null;
            cbbLocal.Text = null;            
            txtQtdeAluno.Text = null;
            txtProfessor.Text = null;     
        }

        public void ModoPesquisa() 
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtTurma.Enabled = true;
            dtTurma.Select();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (cbbNomeCurso.Text == "" || cbbLocal.Text == "" ||  txtQtdeAluno.Text == "" || txtProfessor.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: < Nome da turma >, < Local >, < Dia da semana >, < Hora de inicio >, < Hora de saída >, < Qtd. de alunos > e < Professor/Instrutor >", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            //bllTurma.Alterar(txtCodigo.Text, cbbNomeCurso.Text.Trim(), cbbLocal.Text, cbbDiaSemana.Text, cbbHoraInicio.Text, cbbHoraSaida.Text, txtQtdeAluno.Text, txtProfessor.Text);

                            MessageBox.Show("Os dados foram alterados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dtTurma.DataSource = bllTurma.Sel_T_A_Atu(txtCodigo.Text);
                        }
                        else
                        {
                            //bllTurma.Salvar(

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dtTurma.DataSource = bllTurma.Sel_T_A_Sal();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                        Limpar();
                        _Comando_Atualizar = false;
                    }
                    finally
                    {
                        ModoPesquisa();
                        _Comando_Atualizar = false;
                    }
                }
            }
            else
            {
                cbbNomeCurso.Select();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtTurma.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtTurma.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;            
            Limpar();
            cbbNomeCurso.Select();            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnNomeTurma.Checked == true) 
                {
                    if (txtpNome.Text.Trim() != "") 
                    {
                        if (bllTurma.Sel_T_Nome_Tur(txtpNome.Text) == null)
                        {
                            dtTurma.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtTurma.DataSource = bllTurma.Sel_T_Nome_Tur(txtpNome.Text);
                            dtTurma.Select();
                        }
                    }         
                }
                else if (rbtnNomeProf.Checked == true)
                {
                    if (txtpNome.Text.Trim() != "")
                    {
                        if (bllTurma.Sel_T_Nome_Prof(txtpNome.Text) == null)
                        {
                            dtTurma.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtTurma.DataSource = bllTurma.Sel_T_Nome_Prof(txtpNome.Text);
                            dtTurma.Select();
                        }
                    }
                }
                else if (rbtnDia.Checked == true)
                {
                    if (cbbpDiaSemana.Text != "")
                    {
                        if (bllTurma.Sel_T_DiaSem(cbbpDiaSemana.Text) == null)
                        {
                            dtTurma.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtTurma.DataSource = bllTurma.Sel_T_DiaSem(cbbpDiaSemana.Text);
                            dtTurma.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllTurma.Sel_T_Cod(txtpCodigo.Text) == null)
                        {
                            dtTurma.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtTurma.DataSource = bllTurma.Sel_T_Cod(txtpCodigo.Text);
                            dtTurma.Select();
                        }
                    }

                }                
                else if (rbtnTodos.Checked == true)
                {
                    if (bllTurma.Sel_T_Todos() == null)
                    {
                        dtTurma.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtTurma.DataSource = bllTurma.Sel_T_Todos();
                        dtTurma.Select();
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
                txtpNome.Text = null;
                txtpCodigo.Text = null;
                cbbpDiaSemana.Text = null;
                rbtnNomeTurma.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = true;
                Limpar();
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
            }
            else
            {
                if (dtTurma.DataSource == null)
                {                    
                    Limpar();
                    btnExcluir.Enabled = false;
                    btnAlterar.Enabled = false;
                }
                else
                {
                    Limpar();
                    btnExcluir.Enabled = true;
                    btnAlterar.Enabled = true;
                }
            }
            ModoPesquisa();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtTurma.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            btnNovo.Enabled = false;
            btnCancelar.Visible = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            dtTurma.Enabled = false;
            cbbNomeCurso.Select();
            _Comando_Atualizar = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("ATENÇÃO! AS informações desta turma serão excluídas, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    bllTurma.Excluir(txtCodigo.Text);

                    if (rbtnNomeTurma.Checked == true)
                    {
                        if (txtpNome.Text.Trim() != "")
                        {
                            if (bllTurma.Sel_T_Nome_Tur(txtpNome.Text) == null)
                            {
                                dtTurma.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtTurma.DataSource = bllTurma.Sel_T_Nome_Tur(txtpNome.Text);
                                dtTurma.Select();
                            }
                        }
                    }
                    else if (rbtnNomeProf.Checked == true)
                    {
                        if (txtpNome.Text.Trim() != "")
                        {
                            if (bllTurma.Sel_T_Nome_Prof(txtpNome.Text) == null)
                            {
                                dtTurma.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtTurma.DataSource = bllTurma.Sel_T_Nome_Prof(txtpNome.Text);
                                dtTurma.Select();
                            }
                        }
                    }
                    else if (rbtnDia.Checked == true)
                    {
                        if (cbbpDiaSemana.Text != "")
                        {
                            if (bllTurma.Sel_T_DiaSem(cbbpDiaSemana.Text) == null)
                            {
                                dtTurma.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtTurma.DataSource = bllTurma.Sel_T_DiaSem(cbbpDiaSemana.Text);
                                dtTurma.Select();
                            }
                        }
                    }                   
                    else if (rbtnTodos.Checked == true)
                    {
                        if (bllTurma.Sel_T_Todos() == null)
                        {
                            dtTurma.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtTurma.DataSource = bllTurma.Sel_T_Todos();
                            dtTurma.Select();
                        }
                    }
                    else
                    {
                        dtTurma.DataSource = null;
                        Limpar();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    Limpar();
                    ModoPesquisa();
                }
            }
            else
            {
                if (dtTurma.DataSource != null) 
                {
                    dtTurma.Select();
                }
            }
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightSalmon;
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.White;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightSalmon;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.White;
        }

        private void txtNomeTurma_Enter(object sender, EventArgs e)
        {
            cbbNomeCurso.BackColor = Color.LightSalmon;
        }

        private void txtNomeTurma_Leave(object sender, EventArgs e)
        {
            cbbNomeCurso.BackColor = Color.White;
        }

        private void txtQtdeAluno_Enter(object sender, EventArgs e)
        {
            txtQtdeAluno.BackColor = Color.LightSalmon;
        }

        private void txtQtdeAluno_Leave(object sender, EventArgs e)
        {
            txtQtdeAluno.BackColor = Color.White;
        }

        private void txtProfessor_Enter(object sender, EventArgs e)
        {
            txtProfessor.BackColor = Color.LightSalmon;
        }

        private void txtProfessor_Leave(object sender, EventArgs e)
        {
            txtProfessor.BackColor = Color.White;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
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

        private void cbbLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbLocal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDiaSemana_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDiaSemana_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbHoraInicio_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbHoraInicio_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbHoraSaida_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbHoraSaida_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpDiaSemana_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpDiaSemana_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNomeTurma_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        
        private void rbtnNomeTurma_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNomeProf_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNomeProf_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDia_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDia_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnLocal_MouseLeave(object sender, EventArgs e)
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

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNomeTurma_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            cbbpDiaSemana.Visible = false;
            lblPesquisar.Location = new Point(352, 21);
            lblPesquisar.Text = "Digite o nome da turma:";
            txtpNome.Visible = true;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnNomeProf_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            cbbpDiaSemana.Visible = false;
            lblPesquisar.Location = new Point(330, 21);
            lblPesquisar.Text = "Digite o nome do professor:";
            txtpNome.Visible = true;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnDia_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            txtpNome.Visible = false;            
            lblPesquisar.Location = new Point(562, 21);
            lblPesquisar.Text = "Escolha um dia da semana:";
            cbbpDiaSemana.Visible = true;
            txtpNome.Text = null;
            cbbpDiaSemana.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpDiaSemana.Visible = false;
            txtpNome.Visible = false;
            lblPesquisar.Location = new Point(618, 21);
            lblPesquisar.Text = "Digite um código de turma:";
            txtpCodigo.Visible = true;            
            txtpNome.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbbpDiaSemana.Visible = false;
            txtpNome.Visible = false;
            lblPesquisar.Location = new Point(724, 21);
            lblPesquisar.Text = "Exibir todo o Cadastro:";
            txtpCodigo.Visible = false;
            txtpNome.Text = null;
            btnPesquisar.Select();
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpDiaSemana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void txtNomeTurma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                cbbLocal.Select();
            }
        }

        private void cbbLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                
            }
        }

        private void cbbDiaSemana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                
            }
        }

        private void cbbHoraInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
               
            }
        }

        private void cbbHoraSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtQtdeAluno.Select();            
            }
        }

        private void txtQtdeAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtProfessor.Select();
            }
        }

        private void txtProfessor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnSalvar.Select();
            }
        }

        private void cbbHoraInicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chbDom_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        






    }
}
