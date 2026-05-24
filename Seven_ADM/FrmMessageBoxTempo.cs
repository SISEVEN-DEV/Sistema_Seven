using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmMessageBoxTempo : Form
    {
        public FrmMessageBoxTempo()
        {
            InitializeComponent();
        }

        int Minutos = 5;
        bool Concluiu = false;

        private void FrmMessageBoxTempo_Load(object sender, EventArgs e)
        {
            TemporizadorOk.Start();
            btnOK.Select();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.Select();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK.Select();
            }
        }

        private void TemporizadorOk_Tick(object sender, EventArgs e)
        {
            if (Minutos == 0)
            {
                TemporizadorOk.Stop();
                btnOK.Text = "OK";
                Concluiu = true;
            }
            else
            {
                Minutos--;
                btnOK.Text = "OK (" + Minutos + ")";
            }
        }

        private void FrmMessageBoxTempo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Concluiu == true)
            {
                e.Cancel = false;
            }
            else
            {
                this.Close();
                e.Cancel = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Concluiu == true)
            {
                this.Close();
            }
        }

        private void FrmMessageBoxTempo_KeyUp(object sender, KeyEventArgs e)
        {
            if (Concluiu == true)
            {
                this.Close();
            }
        }
    }
}
