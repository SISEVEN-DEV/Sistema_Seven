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
    public partial class FrmCadCursoDisciplina : Form
    {
        public FrmCadCursoDisciplina()
        {
            InitializeComponent();
        }

        private void FrmCadCursoDisciplina_Load(object sender, EventArgs e)
        {
            try
            {
                clbDisciplinas.Items.Clear();

                if (bllCurso.Sel_Curso_Disci() == null)
                {
                    lblNaoExistemDisciplina.Visible = true;
                    clbDisciplinas.Visible = false;
                }
                else
                {
                    lblNaoExistemDisciplina.Visible = false;
                    clbDisciplinas.Visible = true;

                    foreach (DataRow dr in bllCurso.Sel_Curso_Disci().Rows)
                    {
                        clbDisciplinas.Items.Add((dr["id_disciplina"].ToString()) + "-" + (dr["descricao"].ToString()));
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        private void btnOK_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
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

        private void clbDisciplinas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void clbDisciplinas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void FrmCadCursoDisciplina_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        

        

        
    }
}
