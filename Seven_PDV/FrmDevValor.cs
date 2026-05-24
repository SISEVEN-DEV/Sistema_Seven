using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmDevValor : Form
    {
        public FrmDevValor(string valor, string tipo)
        {
            InitializeComponent();
            lblTipoDev.Text = tipo;
            lblValor.Text = valor;
        }

        private void FrmDevValor_Load(object sender, EventArgs e)
        {
            btnOK.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmDevValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
