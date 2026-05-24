using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Diagnostics;
using System.IO;

namespace SIE_7_Sistema
{
    public partial class FrmCadArquivo : Form
    {
        public FrmCadArquivo()
        {
            InitializeComponent();
        }

        private bool _Inserir_Atualizar;
        private bool _Comando_Atualizar;

        private void Limpar() 
        {
            txtPalavraChave.Text = null;
            txtDescricao.Text = null;
            cbbTipoTabela.Text = null;
            txtCaminho.Text = null;
            rtxtObs.Text = null;
        }

        public void ModoPesquisa()
        {//Faz o formulário ativar o modo pesquisa de dados
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtArquivo.Enabled = true;
            dtArquivo.Select();
        }

        private void FrmCadArquivos_Load(object sender, EventArgs e)
        {
            bllArquivo._FrmCadArquivo_Ativo = true;
            txtpDescricao.Select();
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
                txtPalavraChave.BackColor = Color.White;
            }
            else
            {
                try
                {
                    if (txtPalavraChave.Text != "")
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllArquivo.Sel_Arquivo_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true & _Inserir_Atualizar == true)
                            {
                                MessageBox.Show("A palavra-chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPalavraChave.Text = null;
                                txtPalavraChave.Select();
                            }
                        }
                        else
                        {
                            if (bllArquivo.Sel_Arquivo_Palavra_Chave_Val(txtPalavraChave.Text) == true & _Inserir_Atualizar == true)
                            {
                                MessageBox.Show("A palavra-chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPalavraChave.Text = null;
                                txtPalavraChave.Select();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPalavraChave.Text = null;
                }
                finally
                {
                    txtPalavraChave.BackColor = Color.White;
                }
            }
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtDescricao.Select();    
            }
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Text = null;
                txtDescricao.BackColor = Color.White;
            }
            else
            {
                try
                {
                    if (txtDescricao.Text != "")
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllArquivo.Sel_Arquivo_Descricao_Alt(txtCodigo.Text, txtDescricao.Text) == true & _Inserir_Atualizar == true)
                            {
                                MessageBox.Show("A descrição informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDescricao.Text = null;
                                txtDescricao.Select();
                            }
                        }
                        else
                        {
                            if (bllArquivo.Sel_Arquivo_Descricao_Val(txtDescricao.Text) == true & _Inserir_Atualizar == true)
                            {
                                MessageBox.Show("A descrição informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDescricao.Text = null;
                                txtDescricao.Select();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescricao.Text = null;
                }
                finally
                {
                    txtDescricao.BackColor = Color.White;
                }
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                cbbTipoTabela.Select();
            }
        }

        private void cbbTipoTabela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtCaminho.Select();
            }
        }

        private void cbbTipoTabela_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoTabela_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoTabela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoTabela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCaminho_Enter(object sender, EventArgs e)
        {
            txtCaminho.BackColor = Color.LightBlue;
        }

        private void txtCaminho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnProcurar.Select();
            }
        }

        private void txtCaminho_Leave(object sender, EventArgs e)
        {
            txtCaminho.BackColor = Color.White;
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnSalvar.Select();
            }
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.White;
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

        private void cbbpTipoTabela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void rbtnNomeAluno_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNomeAluno_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void btnAbrirArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAbrirArquivo_MouseLeave(object sender, EventArgs e)
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

        private void btnProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadArquivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllArquivo._FrmCadArquivo_Ativo = false;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNomeAluno_CheckedChanged(object sender, EventArgs e)
        {            
            txtpDescricao.Visible = true;
            cbbpTipoTabela.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location =new Point(249, 21);
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {            
            txtpDescricao.Visible = false;
            cbbpTipoTabela.Visible = false;
            txtpCodigo.Visible = true;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(539, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {            
            txtpDescricao.Visible = false;
            cbbpTipoTabela.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = true;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(460, 21);
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {            
            txtpDescricao.Visible = false;
            cbbpTipoTabela.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(549, 21);            
            btnPesquisar.Select();
        }

        private void rbtnTabela_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTipoTabela.Visible = true;
            txtpDescricao.Visible = false;            
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Escolha a tabela:";
            lblPesquisar.Location = new Point(332, 21);
            cbbpTipoTabela.Text = null;
            cbbpTipoTabela.Select();
        }

        private void cbbpTipoTabela_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoTabela_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoTabela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoTabela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTabela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTabela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtArquivo.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;           
            _Inserir_Atualizar = true;
            dtArquivo.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            txtPalavraChave.Select();
            Limpar();    
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {          
            _Inserir_Atualizar = true;
            dtArquivo.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            dtArquivo.Enabled = false;
            grbBox2.Enabled = true;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnSalvar.Enabled = true;
            txtPalavraChave.Select();
            _Comando_Atualizar = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (txtDescricao.Text.Trim() == "" || txtCaminho.Text == "" || cbbTipoTabela.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: < Descrição >, < Caminho do Arquivo > e < Tabela >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPalavraChave.Select();
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            bllArquivo.Alterar(txtCodigo.Text, txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), cbbTipoTabela.Text, txtCaminho.Text, rtxtObs.Text); 

                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            dtArquivo.DataSource = bllArquivo.Sel_Arquivo_A_Alt(txtCodigo.Text);
                            
                            ModoPesquisa();                          
                        }
                        else
                        {
                            bllArquivo.Salvar(txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), cbbTipoTabela.Text, txtCaminho.Text, rtxtObs.Text);

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            dtArquivo.DataSource = bllArquivo.Sel_Arquivo_A_Sal();

                            ModoPesquisa();                         
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpDescricao.Text = null;
                        dtArquivo.DataSource = null;                        
                        rbtnNomeAluno.Checked = true;
                        txtpDescricao.Select();
                        ModoPesquisa();
                        Limpar();                        
                        _Comando_Atualizar = false;                       
                        _Inserir_Atualizar = false;
                    }
                }
            }
            else
            {
                txtPalavraChave.Select();
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Title = "Selecione um arquivo";
                file.InitialDirectory = @"C:\";
                if (bllArquivo.Sel_Varios_Tipos_Arquivo_Dir() != true) 
                {
                    file.Filter = "Arquivos no formato:(*.bmp;*.jpg;*.gif;*.png;*.pdf;*.xps;*.txt;*.doc;*.xls;*.xlt;*xltm)|*.bmp;*.jpg;*.gif*.png*.pdf*.xps*.txt*.doc*.xls*.xlt*xltm";
                }

                if (file.ShowDialog() == DialogResult.OK)
                {
                    txtCaminho.Text = file.FileName;
                }
            }
        }

        private void txtCaminho_TextChanged(object sender, EventArgs e)
        {           
            if (txtCaminho.Text == "")
            {
                btnExcluirArquivo.Enabled = false;
                btnAbrirArquivo.Enabled = false;
            }
            else
            {
                btnExcluirArquivo.Enabled = true;
                btnAbrirArquivo.Enabled = true;
            }
        }

        private void btnExcluirArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadArquivo_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnExcluirArquivo_Click(object sender, EventArgs e)
        {
            this.DialogResult = MessageBox.Show("Deseja apagar o caminho do arquivo informado?", "Pergunta",  MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.Yes) 
            {
                txtCaminho.Text = null;
            }           
        }

        private void dtArquivo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtArquivo.Columns[0].HeaderText = "Código";
                dtArquivo.Columns[1].HeaderText = "Descrição";
                dtArquivo.Columns[2].HeaderText = "Tabela";
                dtArquivo.Columns[3].HeaderText = "Caminho do arquivo";
                dtArquivo.Columns[4].HeaderText = "Observação";
                dtArquivo.Columns[5].HeaderText = "Palavra-chave";

                dtArquivo.Columns[0].Width = 80;
                dtArquivo.Columns[1].Width = 325;
                dtArquivo.Columns[2].Width = 150;
                dtArquivo.Columns[3].Width = 500;
                dtArquivo.Columns[4].Width = 500;
                dtArquivo.Columns[5].Width = 95;

                dtArquivo.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtArquivo.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtArquivo.DefaultCellStyle.Font = new Font(dtArquivo.Font, FontStyle.Bold);

                dtArquivo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtArquivo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow SelectedRow = dtArquivo.Rows[dtArquivo.CurrentRow.Index];
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                cbbTipoTabela.Text = SelectedRow.Cells[2].Value.ToString();
                txtCaminho.Text = SelectedRow.Cells[3].Value.ToString();
                rtxtObs.Text = SelectedRow.Cells[4].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtArquivo.DataSource = null;              
                rbtnNomeAluno.Checked = true;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();               
                _Comando_Atualizar = false;                
                _Inserir_Atualizar = false;
            }          
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtCaminho.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                btnPesquisar.Select();
                if (rbtnTodos.Checked == true)
                {
                    if (bllArquivo.Sel_Arquivo_Todos() == null)
                    {
                        dtArquivo.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Todos();
                        dtArquivo.Select();
                    }
                }
                else if (rbtnNomeAluno.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllArquivo.Sel_Arquivo_Descricao(txtpDescricao.Text) == null)
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Descricao(txtpDescricao.Text);
                            dtArquivo.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllArquivo.Sel_Arquivo_Codigo(txtpCodigo.Text) == null)
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Codigo(txtpCodigo.Text);
                            dtArquivo.Select();
                        }
                    }
                }              
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllArquivo.Sel_Arquivo_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Palavra_Chave(txtpPalavraChave.Text);
                            dtArquivo.Select();
                        }
                    }
                }
                else if (rbtnTabela.Checked == true)
                {                  
                    if (cbbpTipoTabela.Text != "")
                    {
                        if (bllArquivo.Sel_Arquivo_Tabela(cbbpTipoTabela.Text) == null)
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Tabela(cbbpTipoTabela.Text);
                            dtArquivo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtArquivo.DataSource = null;              
                rbtnNomeAluno.Checked = true;
                txtpDescricao.Select();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                Limpar();                           
            }       
        }

        private void dtArquivo_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtArquivo.DataSource == null)
            {           
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;               
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;               
            }
        }

        private void dtArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtArquivo.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtArquivo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtArquivo.Rows.Count;
        }

        private void dtArquivo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por descricao, código, palavra-chave, tabela e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\r1 - Clicando no botão < Novo > você insere novos dados, ao finalizar clique no botão < Salvar >.\r2 - Clicando no botão < Alterar > você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão < Salvar >.\r3 - Clicando no botao < Excluir > você estará excluindo os dados selecionados na tabela.\r4 - Se por algum um motivo você clicou no botão: < Novo > ou no botão: < Alterar > e não deseja continuar nessas opções, clique no botão: < Cancelar >.\n5 - Abrir Arquivo: Abre o arquivo especificado na caixa de texto caminho do arquivo", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja excluir este arquivo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    bllArquivo.Excluir(txtCodigo.Text);

                    if (bllArquivo.Sel_Excluir_Arquivo_Dir() == true)
                    {
                        DialogResult = MessageBox.Show("Deseja também excluir este mesmo arquivo do seu computador?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes) 
                        {
                            File.Delete(txtCaminho.Text);
                        }
                    }
                    
                    if (rbtnNomeAluno.Checked == true)
                    {
                        if (txtpDescricao.Text != "")
                        {
                            if (bllArquivo.Sel_Arquivo_Descricao(txtpDescricao.Text) == null)
                            {
                                dtArquivo.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Descricao(txtpDescricao.Text);
                                dtArquivo.Select();
                            }
                        }
                        else
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                    }
                    else if (rbtnTabela.Checked == true)
                    {
                        if (cbbpTipoTabela.Text != "")
                        {
                            if (bllArquivo.Sel_Arquivo_Tabela(cbbpTipoTabela.Text) == null)
                            {
                                dtArquivo.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Tabela(cbbpTipoTabela.Text);
                                dtArquivo.Select();
                            }
                        }
                        else
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                    }
                    else if (rbtnPalavraChave.Checked == true)
                    {
                        if (txtpPalavraChave.Text != "")
                        {
                            if (bllArquivo.Sel_Arquivo_Palavra_Chave(txtpPalavraChave.Text) == null)
                            {
                                dtArquivo.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Palavra_Chave(txtpPalavraChave.Text);
                                dtArquivo.Select();
                            }
                        }
                        else
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                    }
                    else if (rbtnTodos.Checked == true)
                    {
                        if (bllArquivo.Sel_Arquivo_Todos() == null)
                        {
                            dtArquivo.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_Arquivo_Todos();
                            dtArquivo.Select();
                        }
                    }
                    else
                    {
                        dtArquivo.DataSource = null;
                        Limpar();
                    }

                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtArquivo.DataSource = null;
                }
            }
            else
            {
                if (dtArquivo.DataSource != null)
                {
                    dtArquivo.Select();
                }
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
                if (dtArquivo.DataSource == null)
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

        private void dtArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }       
    }
}
