using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmFluxoCaixa : Form
    {
        public FrmFluxoCaixa(string usuario, string cod_pdv_computador, string data_abertura)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Data_Abertura = data_abertura;
        }

        byte _Trabalho;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Data_Abertura;

        private void FrmFluxoCaixa_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFluxoCaixa iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFluxoCaixa iniciado.");
                }
                //
                if (bllFluxoCaixa.Sel_Fluxo_Caixa_Usuario_PDV(_Data_Abertura, _Cod_PDV_Computador, _Usuario) != null)
                {
                    dtFluxo.DataSource = bllFluxoCaixa.Sel_Fluxo_Caixa_Usuario_PDV(_Data_Abertura, _Cod_PDV_Computador, _Usuario);
                }
                else
                {
                    dtFluxo.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmFluxoCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmFluxoCaixa.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmFluxoCaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtFluxo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtFluxo.Columns[0].HeaderText = "Código";
            dtFluxo.Columns[1].HeaderText = "Tipo";
            dtFluxo.Columns[2].HeaderText = "Descrição";
            dtFluxo.Columns[3].HeaderText = "Valor (R$)";
            dtFluxo.Columns[4].HeaderText = "Data";
            dtFluxo.Columns[5].HeaderText = "Horário";
            dtFluxo.Columns[6].HeaderText = "Cód. do Fato Gerador";
            dtFluxo.Columns[7].HeaderText = "Saldo (R$)";
            //
            dtFluxo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFluxo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtFluxo.Columns[0].Width = 95;
            dtFluxo.Columns[1].Width = 80;
            dtFluxo.Columns[2].Width = 333;
            dtFluxo.Columns[3].Width = 150;
            dtFluxo.Columns[4].Width = 85;
            dtFluxo.Columns[5].Width = 75;
            dtFluxo.Columns[6].Width = 150;
            dtFluxo.Columns[7].Width = 150;
            //
            decimal entradas = 0;
            decimal saidas = 0;
            for (int i = 0; i < dtFluxo.Rows.Count; i++)
            {
                if (dtFluxo.Rows[i].Cells[1].Value.ToString() == "ENTRADA")
                {
                    dtFluxo.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                    entradas += Convert.ToDecimal(dtFluxo.Rows[i].Cells[3].Value);
                }
                else if (dtFluxo.Rows[i].Cells[1].Value.ToString() == "SAÍDA")
                {
                    dtFluxo.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    saidas += Convert.ToDecimal(dtFluxo.Rows[i].Cells[3].Value);
                }
                //
                if (i == dtFluxo.Rows.Count - 1)
                {
                    lblValorSaldo.Text = Convert.ToDecimal(dtFluxo.Rows[i].Cells[7].Value).ToString("n2");
                }
            }
            //
            lblValorEntrada.Text = Convert.ToDecimal(entradas).ToString("n2", new CultureInfo("pt-BR"));
            lblValorSaida.Text = Convert.ToDecimal(saidas).ToString("n2", new CultureInfo("pt-BR"));
            lblRegistros.Text = "Registros: " + dtFluxo.Rows.Count;
            //
            dtFluxo.DefaultCellStyle.Font = new Font(dtFluxo.Font, FontStyle.Bold);
        }

        private void dtFluxo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtFluxo.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtFluxo.Columns[3].DefaultCellStyle.Format = "c";

            dtFluxo.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtFluxo.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtFluxo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "ENTRADA")
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
            else if (e.ColumnIndex == 1 && e.Value.ToString() == "SAÍDA")
            {
                e.CellStyle.ForeColor = Color.Red;
            }
            //
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 5 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(5);
            }
        }

        private void dtFluxo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtFluxo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtFluxo.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtFluxo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtFluxo_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFluxo.DataSource == null)
            {
                dtFluxo.Enabled = false;
            }
            else
            {
                dtFluxo.Enabled = true;
            }
        }

        private void FrmFluxoCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFluxoCaixa foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFluxoCaixa foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmFluxoCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmFluxoCaixa.");
                }
                this.DialogResult = DialogResult.Abort;
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

        private void lblValorEntrada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entradas (R$): " + Convert.ToDecimal(lblValorEntrada.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorSaida_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saídas (R$): " + Convert.ToDecimal(lblValorSaida.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saldo (R$): " + Convert.ToDecimal(lblValorSaldo.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorEntrada_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorEntrada_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorSaida_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorSaida_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorSaldo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorSaldo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
