using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmLayoutPDV : Form
    {
        public FrmLayoutPDV(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;
        private bool _Comando_Atualizar = false;

        private void FrmLayoutPDV_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                //
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLayoutPDV iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLayoutPDV iniciado.");
                }
                //
                if (bllLayoutPDV.Sel_Layout_PDV_Todos(bllConexao._Codigo_Conexao) != null)
                {
                    DataRow dr = bllLayoutPDV.Sel_Layout_PDV_Todos(bllConexao._Codigo_Conexao).Rows[0];
                    //
                    if (Convert.ToByte(dr["layout_tipo"]) == 0)
                    {
                        rbtnClassico.Checked = true;
                    }
                    else
                    {
                        rbtnBigPicture.Checked = true;
                    }
                    //
                    _Comando_Atualizar = true;
                }
                else
                {
                    _Comando_Atualizar = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLayoutPDV.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLayoutPDV.");
                }
            }
        }

        private void pPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            pPanel1.BackColor = Color.Black;
        }

        private void pPanel1_MouseLeave(object sender, EventArgs e)
        {
            if (rbtnClassico.Checked == true)
            {
                pPanel1.BackColor = Color.CornflowerBlue;
                pPanel2.BackColor = Color.LightGray;
            }
            else
            {
                pPanel1.BackColor = Color.LightGray;
            }
        }

        private void pPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            pPanel2.BackColor = Color.Black;
        }

        private void pPanel2_MouseLeave(object sender, EventArgs e)
        {
            if (rbtnBigPicture.Checked == true)
            {
                pPanel2.BackColor = Color.CornflowerBlue;
                pPanel1.BackColor = Color.LightGray;
            }
            else
            {
                pPanel2.BackColor = Color.LightGray;
            }
        }

        private void rbtnClassico_MouseMove(object sender, MouseEventArgs e)
        {
            pPanel1.BackColor = Color.Black;
        }

        private void rbtnClassico_MouseLeave(object sender, EventArgs e)
        {
            if (rbtnClassico.Checked == true)
            {
                pPanel1.BackColor = Color.CornflowerBlue;
                pPanel2.BackColor = Color.LightGray;
            }
            else
            {
                pPanel1.BackColor = Color.LightGray;
            }
        }

        private void rbtnBigPicture_MouseMove(object sender, MouseEventArgs e)
        {
            pPanel2.BackColor = Color.Black;
        }

        private void rbtnBigPicture_MouseLeave(object sender, EventArgs e)
        {
            if (rbtnBigPicture.Checked == true)
            {
                pPanel2.BackColor = Color.CornflowerBlue;
                pPanel1.BackColor = Color.LightGray;
            }
            else
            {
                pPanel2.BackColor = Color.LightGray;
            }
        }

        private void FrmLayoutPDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLayoutPDV foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLayoutPDV foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLayoutPDV.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLayoutPDV.");
                }
            }

        }

        private void pcibImagem1_MouseMove(object sender, MouseEventArgs e)
        {
            pPanel1.BackColor = Color.Black;
        }

        private void pcibImagem1_MouseLeave(object sender, EventArgs e)
        {
            if (rbtnClassico.Checked == true)
            {
                pPanel1.BackColor = Color.CornflowerBlue;
                pPanel2.BackColor = Color.LightGray;
            }
            else
            {
                pPanel1.BackColor = Color.LightGray;
            }
        }

        private void pcibImagem2_MouseMove(object sender, MouseEventArgs e)
        {
            pPanel2.BackColor = Color.Black;
        }

        private void pcibImagem2_MouseLeave(object sender, EventArgs e)
        {
            if (rbtnBigPicture.Checked == true)
            {
                pPanel2.BackColor = Color.CornflowerBlue;
                pPanel1.BackColor = Color.LightGray;
            }
            else
            {
                pPanel2.BackColor = Color.LightGray;
            }           
        }

        private void pcibImagem1_Click(object sender, EventArgs e)
        {
            rbtnClassico.Checked = true;
        }

        private void pcibImagem2_Click(object sender, EventArgs e)
        {
            rbtnBigPicture.Checked = true;
        }

        private void pcibImagem1_DoubleClick(object sender, EventArgs e)
        {
            btnContinuar_Click(sender, e);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            btnContinuar.Select();
            try
            {
                byte layout_tipo;
                if (_Comando_Atualizar == true)
                {
                    if (rbtnClassico.Checked == true)
                    {
                        layout_tipo = 0;
                    }
                    else
                    {
                        layout_tipo = 1;
                    }
                    //
                    bllLayoutPDV.Alterar(layout_tipo, bllConexao._Codigo_Conexao);
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (rbtnClassico.Checked == true)
                    {
                        layout_tipo = 0;
                    }
                    else
                    {
                        layout_tipo = 1;
                    }
                    //
                    bllLayoutPDV.Salvar(layout_tipo, bllConexao._Codigo_Conexao);
                    //
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
            }
        }

        private void FrmLayoutPDV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void rbtnClassico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnClassico.Checked == true)
            {
                pPanel1.BackColor = Color.CornflowerBlue;
                pPanel2.BackColor = Color.LightGray;
            }
        }

        private void rbtnClassico_Click(object sender, EventArgs e)
        {
            pPanel1.BackColor = Color.CornflowerBlue;
        }

        private void rbtnBigPicture_Click(object sender, EventArgs e)
        {
            pPanel2.BackColor = Color.CornflowerBlue;
        }

        private void rbtnBigPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBigPicture.Checked == true)
            {
                pPanel2.BackColor = Color.CornflowerBlue;
                pPanel1.BackColor = Color.LightGray;
            }
        }

        private void pcibImagem2_DoubleClick(object sender, EventArgs e)
        {
            btnContinuar_Click(sender, e);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                Application.Exit();
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
