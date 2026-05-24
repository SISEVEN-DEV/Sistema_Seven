using BLL;
using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmDatePicker : Form
    {
        public FrmDatePicker(byte _formulario)
        {
            InitializeComponent();
            _Formulario = _formulario;
        }

        private byte _Formulario;

        private void FrmDataPicker_Load(object sender, EventArgs e)
        {
            dtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            MessageBox.Show("Selecione a data no campo: [ Selecione a data ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (e.KeyChar == 13)
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
                bllContasReceber._Data_DatePicker1 = dtpData.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                bllOrcamento._Data_DatePicker1 = dtpData.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                bllControleCheque._Data_DatePicker1 = dtpData.Text;
                this.DialogResult = DialogResult.OK;

            }
            else if (_Formulario == 4)
            {
                bllDevolucao._Data_DatePicker1 = dtpData.Text;
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
