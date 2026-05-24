using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmAtualizacaoDisponivel : Form
    {
        public FrmAtualizacaoDisponivel()
        {
            InitializeComponent();
        }

        private void FrmTroco_Load(object sender, EventArgs e)
        {
            btnNao.Select();
        }

        private void FrmTroco_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
