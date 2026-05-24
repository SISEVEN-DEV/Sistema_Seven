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

namespace SIE_7_Sistema
{
    public partial class FrmPesqArquivo : Form
    {
        public FrmPesqArquivo(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNomeAluno_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = true;
            cbbpTipoTabela.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(249, 21);
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

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
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

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void cbbpTipoTabela_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAbrirArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAbrirArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dtArquivo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtArquivo.Rows.Count;      
        }

        private void dtArquivo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void FrmPesqArquivo_Load(object sender, EventArgs e)
        {
            txtpDescricao.Select();
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtArquivo.Rows[dtArquivo.CurrentRow.Index];
                Process.Start(SelectedRow.Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtArquivo_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtArquivo.DataSource == null)
            {
                btnAbrirArquivo.Enabled = false;
            }
            else
            {
                btnAbrirArquivo.Enabled = true;
            }
        }

        private void dtArquivo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtArquivo.Columns[0].HeaderText = "Código";
                dtArquivo.Columns[1].HeaderText = "Caminho do arquivo";
                dtArquivo.Columns[2].HeaderText = "Descrição";                
                dtArquivo.Columns[3].HeaderText = "Observação";
                dtArquivo.Columns[4].HeaderText = "Palavra-chave";

                dtArquivo.Columns[0].Width = 80;
                dtArquivo.Columns[1].Width = 500;
                dtArquivo.Columns[2].Width = 325;           
                dtArquivo.Columns[3].Width = 500;
                dtArquivo.Columns[4].Width = 95;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtArquivo.DataSource = null;
                rbtnNomeAluno.Checked = true;
                txtpDescricao.Select();                
            }          
        }

        private void FrmPesqArquivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                btnPesquisar.Select();
                if (rbtnTodos.Checked == true)
                {
                    if (bllArquivo.Sel_PesqArquivo_Todos(_Formulario) == null)
                    {
                        dtArquivo.DataSource = null;                        
                    }
                    else
                    {
                        dtArquivo.DataSource = bllArquivo.Sel_PesqArquivo_Todos(_Formulario);
                        dtArquivo.Select();
                    }
                }
                else if (rbtnNomeAluno.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllArquivo.Sel_PesqArquivo_Descricao(txtpDescricao.Text, _Formulario) == null)
                        {
                            dtArquivo.DataSource = null;                            
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_PesqArquivo_Descricao(txtpDescricao.Text, _Formulario);
                            dtArquivo.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllArquivo.Sel_PesqArquivo_Codigo(txtpCodigo.Text, _Formulario) == null)
                        {
                            dtArquivo.DataSource = null;                         
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_PesqArquivo_Codigo(txtpCodigo.Text, _Formulario);
                            dtArquivo.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllArquivo.Sel_PesqArquivo_Palavra_Chave(txtpPalavraChave.Text, _Formulario) == null)
                        {
                            dtArquivo.DataSource = null;                            
                        }
                        else
                        {
                            dtArquivo.DataSource = bllArquivo.Sel_PesqArquivo_Palavra_Chave(txtpPalavraChave.Text, _Formulario);
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

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clique no botão abrir o arquivo selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por descricao, código, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dtArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }         
    }
}
