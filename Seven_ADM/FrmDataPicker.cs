using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using System.Globalization;

namespace SIE_7_Sistema
{
    public partial class FrmDataPicker : Form
    { 
        public FrmDataPicker(byte _formulario)
        {
            InitializeComponent();
            _Formulario = _formulario;
        }

        private byte _Formulario;

        private void FrmDataPicker_Load(object sender, EventArgs e)
        {
            dtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (_Formulario == 0)
            {
                lblLabel1.Text = "Desconto Até:";
            }
            else
            {
                lblLabel1.Text = "Data de Pagamento:";
            }
            dtpData.Select();
        }

        private void FrmDataPicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            string campo;

            if (_Formulario == 0)
            {
                MessageBox.Show("Selecione a data no campo: < Desconto Até >.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Formulario == 1)
            {
                MessageBox.Show("Selecione a data no campo: < Data de Pagamento >.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtpData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void dtpData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                bllContasPagar._Data_DatePicker1 = dtpData.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                bllContasPagar._Data_DatePicker1 = dtpData.Text;
                this.DialogResult = DialogResult.OK;
            }            
        }

        private void dtpData_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
