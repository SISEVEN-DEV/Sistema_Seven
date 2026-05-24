using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmLicencaExpirar : Form
    {


        public FrmLicencaExpirar(string dias, string data_expiracao)
        {
            InitializeComponent();
            _Dias = dias;
            _Data_Expiracao = data_expiracao;
        }

        private string _Dias;
        private string _Data_Expiracao;

        private void FrmTroco_Load(object sender, EventArgs e)
        {
            btnNao.Select();
            lblDias.Text = _Dias;
            lblDataExpiracao.Text = _Data_Expiracao;
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
