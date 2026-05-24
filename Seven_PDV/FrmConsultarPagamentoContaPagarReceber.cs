using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmConsultarPagamentoContaPagarReceber : Form
    {
        public FrmConsultarPagamentoContaPagarReceber(string codigo, byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Codigo = codigo;
        }

        string _Codigo;
        byte _Formulario;

        private void FrmOpeConsultarPagamentoContaReceber_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOpeConsultarPagamentoContaReceber iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOpeConsultarPagamentoContaReceber iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    if (bllContasReceber.Sel_Formas_Pagamento_Conta_Receber(_Codigo) == null)
                    {
                        MessageBox.Show("Ainda não existe(m) pagamento(s) para esta Conta a Receber.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtPagamento.DataSource = bllContasReceber.Sel_Formas_Pagamento_Conta_Receber(_Codigo);
                        dtPagamento.Select();
                    }
                }
                else if (_Formulario == 1)
                {
                    if (bllContasPagar.Sel_Formas_Pagamento_Conta_Pagar(_Codigo) == null)
                    {
                        MessageBox.Show("Ainda não existe(m) pagamento(s) para esta Conta a Pagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtPagamento.DataSource = bllContasPagar.Sel_Formas_Pagamento_Conta_Pagar(_Codigo);
                        dtPagamento.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOpeConsultarPagamentoContaReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOpeConsultarPagamentoContaReceber.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtPagamento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtPagamento.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPagamento.Columns[3].DefaultCellStyle.Format = "n2";

            dtPagamento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtPagamento.DefaultCellStyle.SelectionForeColor = Color.Black;

        }

        private void dtFormaPagamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtPagamento.Columns[0].HeaderText = "Item";
            dtPagamento.Columns[1].HeaderText = "Cód. do Pagamento";
            dtPagamento.Columns[2].HeaderText = "Tipo";
            dtPagamento.Columns[3].HeaderText = "Valor Pago (R$)";
            dtPagamento.Columns[4].HeaderText = "Data de Pagamento";
            dtPagamento.Columns[5].HeaderText = "Hora do Pagamento";
            dtPagamento.Columns[6].HeaderText = "Pagamento Parcial";

            dtPagamento.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPagamento.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtPagamento.Columns[0].Width = 55;
            dtPagamento.Columns[1].Width = 135;
            dtPagamento.Columns[2].Width = 319;
            dtPagamento.Columns[3].Width = 135;
            dtPagamento.Columns[4].Width = 135;
            dtPagamento.Columns[5].Width = 135;
            dtPagamento.Columns[6].Width = 125;

            dtPagamento.DefaultCellStyle.Font = new Font(dtPagamento.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtPagamento.Rows.Count;
        }

        private void dtPagamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 6 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
            //
            if (e.ColumnIndex == 5 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(5);
            }
            //
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void dtPagamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPagamento.DataSource != null)
            {
                dtPagamento.Enabled = true;
            }
            else
            {
                dtPagamento.Enabled = false;
            }
        }

        private void FrmOpeConsultarPagamentoContaReceber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtPagamento.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtPagamento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmOpeConsultarPagamentoContaReceber_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOpeConsultarPagamentoContaReceber foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOpeConsultarPagamentoContaReceber foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmOpeConsultarPagamentoContaReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmOpeConsultarPagamentoContaReceber.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
