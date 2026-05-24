using BLL;
using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmDatePicker2 : Form
    {
        public FrmDatePicker2(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmDatePicker2_Load(object sender, EventArgs e)
        {
            dtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtpData.Select();
        }

        private void FrmDatePicker2_KeyUp(object sender, KeyEventArgs e)
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

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                bllDevolucao._Data_DatePicker1 = dtpData.Text;
                bllDevolucao._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                bllContasReceber._Data_DatePicker1 = dtpData.Text;
                bllContasReceber._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                bllHistCaixa._Data_DatePicker1 = dtpData.Text;
                bllHistCaixa._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                bllContasPagar._Data_DatePicker1 = dtpData.Text;
                bllContasPagar._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtpData1.Select();
            }
        }

        private void dtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void dtpData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void dtpData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtpData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void dtpData1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecione as datas nos campos acima.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
