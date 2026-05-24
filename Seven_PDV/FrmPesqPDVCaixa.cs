using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Seven_Sistema
{
    public partial class FrmPesqPDVCaixa : Form
    {
        public FrmPesqPDVCaixa()
        {
            InitializeComponent();
        }

        private void FrmPesqPDVCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\7 Sistema\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\7 Sistema\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\7 Sistema\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\7 Sistema\Log de Acoes");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqPDVCaixa iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqPDVCaixa iniciado.");
                }
                //
               
                //
                dtPesquisa.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqPDVCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqPDVCaixa.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtPesquisa_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                dtPesquisa.Enabled = false;
                btnIncluir.Enabled = false;
            }
            else
            {
                dtPesquisa.Enabled = true;
                btnIncluir.Enabled = true;
            }
        }

        private void dtPesquisa_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtPesquisa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtPesquisa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtPesquisa.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtPesquisa.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtPesquisa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtPesquisa.Columns[0].HeaderText = "Código";
            dtPesquisa.Columns[1].HeaderText = "Nome do Computador";

            dtPesquisa.Columns[0].Width = 95;
            dtPesquisa.Columns[1].Width = 512;

            dtPesquisa.DefaultCellStyle.Font = new Font(dtPesquisa.Font, FontStyle.Bold);

            dtPesquisa.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistros.Text = "Registros: " + dtPesquisa.Rows.Count;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtPesquisa_DoubleClick(object sender, EventArgs e)
        {
            if (dtPesquisa.DataSource != null)
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dtPesquisa.DataSource != null)
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void FrmPesqPDVCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqPDVCaixa foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqPDVCaixa foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqPDVCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqPDVCaixa.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
            this.DialogResult = DialogResult.OK;
        }

        private void FrmPesqPDVCaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
