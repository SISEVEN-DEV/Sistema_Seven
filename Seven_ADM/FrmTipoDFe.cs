using BLL;
using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmTipoDFe : Form
    {
        public FrmTipoDFe(string destinatario)
        {
            InitializeComponent();
            //
            if (destinatario == null || destinatario == "0")
            {
                btnNFe.Enabled = false;
            }
        }

        private void btnNFe_Click(object sender, EventArgs e)
        {
            bllOS._Tipo_Venda = "NFe";
            this.DialogResult = DialogResult.OK;
        }

        private void FrmTipoDFe_Load(object sender, EventArgs e)
        {
            btnNFe.Select();
        }

        private void FrmTipoDFe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bllOS._Tipo_Venda = "DAV";
            this.DialogResult = DialogResult.OK;
        }

        private void btnNFCe_Click(object sender, EventArgs e)
        {
            bllOS._Tipo_Venda = "NFCe";
            this.DialogResult = DialogResult.OK;
        }
    }
}
