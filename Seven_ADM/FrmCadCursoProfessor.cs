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
    public partial class FrmCadCursoProfessor : Form
    {
        public FrmCadCursoProfessor()
        {
            InitializeComponent();
        }

        private bool _Comando_Atualizar;

        private void FrmCadProfInfo_Load(object sender, EventArgs e)
        {

        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtProfessor.Enabled = true;
            dtProfessor.Select();
        }

        private void FrmCadCursoProfessor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Abort;
            }
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

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProfessor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProfessor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProfessor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProfessor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtProfessor.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtProfessor.Enabled = false;
            grbBox1.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;            
            btnSalvar.Enabled = true;
            cbbProfessor.Select();
            cbbProfessor.Text = null;
            _Comando_Atualizar = false;

            cbbProfessor.Items.Clear();

            try
            {
                if (bllCurso.Sel_Professor_Curso() == null)
                {
                    cbbProfessor.Text = null;
                }
                else
                {
                    foreach (DataRow dr in bllCurso.Sel_Professor_Curso().Rows)
                    {
                        cbbProfessor.Items.Add((dr["id_funcionario"].ToString()) + "-" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbProfessor.DataSource = null;        
                ModoPesquisa();          
                _Comando_Atualizar = false;
            }
        }

        private void dtProfessor_MouseMove(object sender, MouseEventArgs e)
        {
            if (cbbProfessor.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtProfessor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtProfessor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtProfessor.Columns[0].HeaderText = "Código do Professor";
                dtProfessor.Columns[1].HeaderText = "Nome do Professor";

                DataGridViewRow SelectedRow = dtProfessor.Rows[dtProfessor.CurrentRow.Index];

                dtProfessor.Columns[0].Width = 100;
                dtProfessor.Columns[1].Width = 425;

                dtProfessor.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtProfessor.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtProfessor.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProfessor.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProfessor.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProfessor.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                dtProfessor.DefaultCellStyle.Font = new Font(cbbProfessor.Font, FontStyle.Bold);

                cbbProfessor.Text = SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString();         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                dtProfessor.DataSource = null;                
                ModoPesquisa();
                cbbProfessor.Text = null;                
                _Comando_Atualizar = false;
            }
        }       
    }
}
