using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace _7_Sistema_Instalador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte _Estagio = 0;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Estagio != 0)
            {
                DialogResult = MessageBox.Show("Deseja cancelar a instalação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAvancar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAvancar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            string startPath = @"C:\7 Sistema\Relatorios";
            string zipPath = @"C:\Rel.zip";

            



            if (_Estagio == 0)
            {
                _Estagio = 1;
                lblInformacoescomp1.Visible = false;
                btnVoltar.Enabled = true;
                lblCabecalho1.Text = "Contrato e Licença";
                lblPeqCabecalho1.Visible = true;
                rtxtContLic.Visible = true;
                rbtnAceito.Visible = true;
                rbtnNaoAceito.Visible = true;
                rbtnNaoAceito.Checked = true;
            }
            else if (_Estagio == 1)
            {
                _Estagio = 2;
                lblInformacoescomp1.Visible = false;
                btnVoltar.Enabled = true;
                lblCabecalho1.Text = "Selecione para instalar os componentes necessários para o funcionamento do software";
                lblPeqCabecalho1.Text = "Componentes:";
                lblPeqCabecalho1.Visible = true;
                rtxtContLic.Visible = false;
                rbtnAceito.Visible = false;
                rbtnNaoAceito.Visible = false;
                chkbAdobePDF.Visible = true;
                chkbFirebird.Visible = true;
                chkbIbexpert.Visible = true;



            }








            //MessageBox.Show(Environment.Is64BitOperatingSystem.ToString());
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (_Estagio == 1)
            {
                _Estagio = 0;
                lblInformacoescomp1.Visible = true;
                btnVoltar.Enabled = false;
                lblCabecalho1.Text = "Bem-vindo ao assistente de instalação do software 7 Sistema";
                lblPeqCabecalho1.Visible = false;
                rtxtContLic.Visible = false;
                rbtnAceito.Visible = false;
                rbtnNaoAceito.Visible = false;
            }
            else if (_Estagio == 2)
            {
                _Estagio = 1;
                lblInformacoescomp1.Visible = false;
                btnVoltar.Enabled = true;
                lblCabecalho1.Text = "Contrato e Licença";
                lblPeqCabecalho1.Text = "Leia atentamente o contrato de licença:";
                lblPeqCabecalho1.Visible = true;
                rtxtContLic.Visible = true;
                rbtnAceito.Visible = true;
                rbtnNaoAceito.Visible = true;
                chkbAdobePDF.Visible = false;
                chkbFirebird.Visible = false;
                chkbIbexpert.Visible = false;
            }
        }

        private void chkbFirebird_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbFirebird_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbIbexpert_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbIbexpert_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbAdobePDF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbAdobePDF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnAceito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnAceito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNaoAceito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNaoAceito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Estagio != 0)
                {
                    DialogResult = MessageBox.Show("Deseja cancelar a instalação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void rbtnAceito_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAceito.Checked == true)
            {
                btnAvancar.Enabled = true;
            }
        }

        private void rbtnNaoAceito_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNaoAceito.Checked == true)
            {
                btnAvancar.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
