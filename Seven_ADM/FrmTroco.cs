using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmTroco : Form
    {
        public FrmTroco(string valor_troco)
        {
            InitializeComponent();
            lblValorTroco.Text = valor_troco;
        }

        private void FrmTroco_Load(object sender, EventArgs e)
        {
            btnOK.Select();
        }

        private void FrmTroco_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
