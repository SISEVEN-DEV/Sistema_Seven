using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmDevolucao : Form
    {
        public FrmDevolucao(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmDevolucao_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDevolucao iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDevolucao iniciado.");
                }
                //
                rbtnData.Checked = true;
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmDevolucao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmDevolucao.");
                }
            }
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
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

        private void btnExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpData.Visible = false;
            mtxtHorario.Visible = false;
            mtxtpData1.Visible = false;
            mtxtHorario1.Visible = false;
            lblAte1.Visible = false;
            btnSelecionarData1.Visible = false;
            txtpCodigo.Visible = true;
            cbbpConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Location = new Point(571, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnConsumidor_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpData.Visible = false;
            mtxtHorario.Visible = false;
            mtxtpData1.Visible = false;
            mtxtHorario1.Visible = false;
            btnSelecionarData1.Visible = false;
            lblAte1.Visible = false;
            txtpCodigo.Visible = false;
            cbbpConsumidor.Visible = true;
            btnpProcurar.Visible = true;
            lblPesquisar.Location = new Point(338, 21);
            lblPesquisar.Text = "Escolha o consumidor:";
            cbbpConsumidor.Text = null;
            cbbpConsumidor.Select();
            //
            try
            {
                cbbpConsumidor.Items.Clear();
                if (bllDevolucao.Sel_Cliente_Dev() == null)
                {
                    cbbpConsumidor.Enabled = false;
                    cbbpConsumidor.Text = null;
                }
                else
                {
                    cbbpConsumidor.Enabled = true;
                    cbbpConsumidor.Items.Add("");
                    foreach (DataRow dr in bllDevolucao.Sel_Cliente_Dev().Rows)
                    {
                        cbbpConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnConsumidor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnConsumidor.");
                }
                cbbpConsumidor.Items.Clear();
                cbbpConsumidor.Text = null;
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpData.Visible = false;
            mtxtHorario.Visible = false;
            mtxtpData1.Visible = false;
            mtxtHorario1.Visible = false;
            btnSelecionarData1.Visible = false;
            lblAte1.Visible = false;
            txtpCodigo.Visible = false;
            cbbpConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Location = new Point(619, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void cbbpConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void FrmDevolucao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllDevolucao.Sel_Codigo_Vendas_Dev(txtpCodigo.Text, bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss")) == null)
                        {
                            dtVenda.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtVenda.DataSource = bllDevolucao.Sel_Codigo_Vendas_Dev(txtpCodigo.Text, bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss"));
                            //
                            dtVenda.CurrentCell = dtVenda.Rows[dtVenda.Rows.Count - 1].Cells[0];

                            dtVenda.Rows[dtVenda.Rows.Count - 1].Selected = true;

                            dtVenda.FirstDisplayedScrollingRowIndex = dtVenda.Rows.Count - 1;
                            //
                            dtVenda.Select();
                        }
                    }
                }
                else if (rbtnConsumidor.Checked == true)
                {
                    if (cbbpConsumidor.Text != "")
                    {
                        if (bllDevolucao.Sel_Consumidor_Vendas_Dev(cbbpConsumidor.Text, bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss")) == null)
                        {
                            dtVenda.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtVenda.DataSource = bllDevolucao.Sel_Consumidor_Vendas_Dev(cbbpConsumidor.Text, bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss"));
                            //
                            dtVenda.CurrentCell = dtVenda.Rows[dtVenda.Rows.Count - 1].Cells[0];

                            dtVenda.Rows[dtVenda.Rows.Count - 1].Selected = true;

                            dtVenda.FirstDisplayedScrollingRowIndex = dtVenda.Rows.Count - 1;
                            //
                            dtVenda.Select();
                        }
                    }
                }
                else if (rbtnData.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData.Text == "" & mtxtpData1.Text == "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                        return;
                    }
                    else if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                        return;
                    }
                    else
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;


                        if (bllDevolucao.Sel_Data_Vendas_Dev(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss")) == null)
                        {
                            dtVenda.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtVenda.DataSource = bllDevolucao.Sel_Data_Vendas_Dev(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss"));
                            //
                            dtVenda.CurrentCell = dtVenda.Rows[dtVenda.Rows.Count - 1].Cells[0];

                            dtVenda.Rows[dtVenda.Rows.Count - 1].Selected = true;

                            dtVenda.FirstDisplayedScrollingRowIndex = dtVenda.Rows.Count - 1;
                            //
                            dtVenda.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllDevolucao.Sel_Todas_Vendas_Dev(bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss")) == null)
                    {
                        dtVenda.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtVenda.DataSource = bllDevolucao.Sel_Todas_Vendas_Dev(bllAbert_Fech_Caixa.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador), DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss"));
                        //
                        dtVenda.CurrentCell = dtVenda.Rows[dtVenda.Rows.Count - 1].Cells[0];

                        dtVenda.Rows[dtVenda.Rows.Count - 1].Selected = true;

                        dtVenda.FirstDisplayedScrollingRowIndex = dtVenda.Rows.Count - 1;
                        //
                        dtVenda.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtProd.DataSource = null;
                dtItensVenda.DataSource = null;
                dtVenda.DataSource = null;
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                rbtnCodigo.Checked = true;
            }
        }

        private void dtVenda_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtVenda.DataSource == null)
            {
                dtVenda.Enabled = false;
                lblCodigoVenda.Visible = false;
                dtItensVenda.DataSource = null;
                dtProd.DataSource = null;
                btnIncluir.Enabled = false;
                lblValorTotalVenda.Text = "0,00";
                lblValorTotalProdutos.Text = "0,00";
                lblValorTotal.Text = "0,00";
                btnContinuar.Enabled = false;
                grbBox2.Enabled = false;
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
            }
            else
            {
                dtVenda.Enabled = true;
                lblCodigoVenda.Visible = true;
                lblValorTotal.ForeColor = Color.Black;
                grbBox2.Enabled = true;
            }
        }

        private void dtVenda_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtVenda.Columns[0].HeaderText = "Código";
            dtVenda.Columns[1].HeaderText = "Cód. do Consumidor";
            dtVenda.Columns[2].HeaderText = "Nome/Razão Social do Consumidor";
            dtVenda.Columns[3].HeaderText = "CPF/CNPJ";
            dtVenda.Columns[4].HeaderText = "Data";
            dtVenda.Columns[5].HeaderText = "Hora";
            dtVenda.Columns[6].HeaderText = "Valor do Desconto - (R$)";
            dtVenda.Columns[7].HeaderText = "Valor do Acréscimo (R$)";
            dtVenda.Columns[8].HeaderText = "Valor do Desconto do Item - (R$)";
            dtVenda.Columns[9].HeaderText = "Valor do Acréscimo do Item (R$)";
            dtVenda.Columns[10].HeaderText = "Valor (R$)";
            dtVenda.Columns[11].HeaderText = "Valor Total (R$)";
            dtVenda.Columns[12].HeaderText = "Tipo do Documento";
            dtVenda.Columns[13].HeaderText = "Número da NF";

            dtVenda.Columns[0].Width = 85;
            dtVenda.Columns[1].Width = 150;
            dtVenda.Columns[2].Width = 325;
            dtVenda.Columns[3].Width = 135;
            dtVenda.Columns[4].Width = 125;
            dtVenda.Columns[5].Width = 125;
            dtVenda.Columns[6].Width = 150;
            dtVenda.Columns[7].Width = 150;
            dtVenda.Columns[8].Width = 190;
            dtVenda.Columns[9].Width = 190;
            dtVenda.Columns[10].Width = 125;
            dtVenda.Columns[11].Width = 125;
            dtVenda.Columns[12].Width = 140;
            dtVenda.Columns[13].Width = 125;

            dtVenda.DefaultCellStyle.Font = new Font(dtProd.Font, FontStyle.Bold);

            dtVenda.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtVenda.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistrosVenda.Text = "Registros: " + dtVenda.Rows.Count;
        }

        private void dtVenda_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtVenda.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtVenda.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtVenda.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtVenda.Columns[6].DefaultCellStyle.Format = "n2";
                dtVenda.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtVenda.Columns[7].DefaultCellStyle.Format = "n2";
                dtVenda.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtVenda.Columns[8].DefaultCellStyle.Format = "n2";
                dtVenda.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtVenda.Columns[9].DefaultCellStyle.Format = "n2";
                dtVenda.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtVenda.Columns[10].DefaultCellStyle.Format = "n2";
                dtVenda.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtVenda.Columns[11].DefaultCellStyle.Format = "n2";
                //
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                lblValorTotalProdutos.Text = Convert.ToDecimal(SelectedRow.Cells[10].Value.ToString()).ToString("n2", new CultureInfo("pt-BR"));
                lblValorTotalVenda.Text = Convert.ToDecimal(SelectedRow.Cells[11].Value.ToString()).ToString("n2", new CultureInfo("pt-BR"));
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Salvar_Todos_Itens_Venda_Dev_Codigo(SelectedRow.Cells[0].Value.ToString(), bllConexao._Codigo_Conexao);
                dtItensVenda.DataSource = bllDevolucao.Sel_Todas_Itens_Venda_Dev();
                dtProd.DataSource = null;
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                lblCodigoVenda.Text = SelectedRow.Cells[0].Value.ToString();
                btnContinuar.Enabled = true;
                btnIncluir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtVenda.");
                }
                dtVenda.DataSource = null;
                dtProd.DataSource = null;
                dtItensVenda.DataSource = null;
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                rbtnCodigo.Checked = true;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }

        private void dtVenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void dtVenda_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtVenda.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmDevolucao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDevolucao foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDevolucao foi finalizado.");
                }
                //
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmDevolucao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmDevolucao.");
                }
            }
        }

        private void dtItensVenda_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtItensVenda.Columns[0].HeaderText = " Item";
                dtItensVenda.Columns[1].HeaderText = "  Código";
                dtItensVenda.Columns[2].HeaderText = "Descrição";
                dtItensVenda.Columns[3].HeaderText = "  Qtd.";
                dtItensVenda.Columns[4].HeaderText = " UN.";
                dtItensVenda.Columns[5].HeaderText = "Vl. Unit (R$)";
                dtItensVenda.Columns[6].HeaderText = "Vl. Item (R$)";
                dtItensVenda.Columns[7].HeaderText = "Vl. do Desc. - (R$)";
                dtItensVenda.Columns[8].HeaderText = "Vl. do Acrésc. + (R$)";
                dtItensVenda.Columns[9].HeaderText = "Vl. do Desc. Item - (R$)";
                dtItensVenda.Columns[10].HeaderText = "Vl. do Acrésc. Item + (R$)";
                dtItensVenda.Columns[11].HeaderText = "Valor Total Após Desc. e Acresc. (R$)";
                //
                dtItensVenda.Columns[0].Width = 56;
                dtItensVenda.Columns[1].Width = 78;
                dtItensVenda.Columns[2].Width = 358;
                dtItensVenda.Columns[3].Width = 70;
                dtItensVenda.Columns[4].Width = 56;
                dtItensVenda.Columns[5].Width = 95;
                dtItensVenda.Columns[6].Width = 95;
                dtItensVenda.Columns[7].Width = 125;
                dtItensVenda.Columns[8].Width = 135;
                dtItensVenda.Columns[9].Width = 145;
                dtItensVenda.Columns[10].Width = 155;
                dtItensVenda.Columns[11].Width = 220;
                //
                dtItensVenda.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItensVenda.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                dtItensVenda.DefaultCellStyle.Font = new Font(dtItensVenda.Font, FontStyle.Bold);

                lblRegistrosItem.Text = "Registros: " + dtItensVenda.Rows.Count;

                decimal valortotalitens = 0;
                for (int i = 0; i < dtItensVenda.Rows.Count; i++)
                {
                    valortotalitens += Convert.ToDecimal(dtItensVenda.Rows[i].Cells[11].Value);
                }
                lblValorCredito.Text = Convert.ToDecimal(valortotalitens).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblValorTotal.Text = Convert.ToDecimal(Convert.ToDecimal(lblValorCredito.Text) - Convert.ToDecimal(lblValorNovosItens.Text)).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtItensVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtItensVenda.");
                }
                dtItensVenda.DataSource = null;
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
            }
        }

        private void dtItensVenda_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtItensVenda.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtItensVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtItensVenda_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItensVenda.DataSource == null)
            {
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                dtItensVenda.Enabled = false;
                btnZerar.Enabled = false;
                btnAltQuantidade.Enabled = false;
                btnContinuar.Enabled = false;
                lblValorCredito.Text = "0,00";
                lblValorTotal.Text = Convert.ToDecimal(Convert.ToDecimal(lblValorCredito.Text) - Convert.ToDecimal(lblValorNovosItens.Text)).ToString("n2", new CultureInfo("pt-BR"));
            }
            else
            {
                btnAltQuantidade.Enabled = true;
                dtItensVenda.Enabled = true;
                btnZerar.Enabled = true;
                btnContinuar.Enabled = true;
            }
        }

        private void dtItensVenda_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.Cursor = Cursors.Hand;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;

                if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                {
                    using (FrmPesqProduto Prod = new FrmPesqProduto(1, 0, _Usuario, _Cod_PDV_Computador, null, null, null))
                    {
                        if (Prod.ShowDialog() == DialogResult.OK)
                        {
                            using (FrmAdicionarItem Item = new FrmAdicionarItem(dtProd.Rows.Count, 1, null, null))
                            {
                                if (Item.ShowDialog() == DialogResult.OK)
                                {
                                    dtProd.DataSource = bllDevolucao.Sel_Todos_Itens_Dev_Prod_Temp();

                                    dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                    dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                    dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                    //
                                    if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                    {
                                        if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                        {
                                            MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    //
                                    dtProd.Select();
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (FrmPesqProduto Prod = new FrmPesqProduto(4, dtProd.Rows.Count + 1, _Usuario, _Cod_PDV_Computador, null, null, null))
                    {
                        if (Prod.ShowDialog() == DialogResult.OK)
                        {
                            dtProd.DataSource = bllDevolucao.Sel_Todos_Itens_Dev_Prod_Temp();

                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                            //
                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                            {
                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                {
                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            //
                            dtProd.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
            pEnabled.Enabled = true;
        }

        private void dtProd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtProd.Columns[0].HeaderText = " Item";
                dtProd.Columns[1].HeaderText = "  Código";
                dtProd.Columns[2].HeaderText = "Descrição";
                dtProd.Columns[3].HeaderText = "  Qtd.";
                dtProd.Columns[4].HeaderText = " UN.";
                dtProd.Columns[5].HeaderText = "Vl. Unit (R$)";
                dtProd.Columns[6].HeaderText = "Vl. Item (R$)";
                dtProd.Columns[7].HeaderText = "Vl. do Desc. Item - (R$)";
                dtProd.Columns[8].HeaderText = "Vl. do Acrésc. Item + (R$)";
                dtProd.Columns[9].HeaderText = "Valor Total Após Desc. e Acresc. (R$)";
                //
                dtProd.Columns[0].Width = 56;
                dtProd.Columns[1].Width = 78;
                dtProd.Columns[2].Width = 358;
                dtProd.Columns[3].Width = 70;
                dtProd.Columns[4].Width = 56;
                dtProd.Columns[5].Width = 95;
                dtProd.Columns[6].Width = 95;
                dtProd.Columns[7].Width = 145;
                dtProd.Columns[8].Width = 155;
                dtProd.Columns[9].Width = 210;
                //
                dtProd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                dtProd.DefaultCellStyle.Font = new Font(dtProd.Font, FontStyle.Bold);
                //
                lblRegistrosProd.Text = "Registros: " + dtProd.Rows.Count;
                //
                decimal valortotalitens = 0;
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    valortotalitens += Convert.ToDecimal(dtProd.Rows[i].Cells[9].Value);
                }
                lblValorNovosItens.Text = Convert.ToDecimal(valortotalitens).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblValorTotal.Text = Convert.ToDecimal(Convert.ToDecimal(lblValorCredito.Text) - Convert.ToDecimal(lblValorNovosItens.Text)).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do datagridview dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do datagridview dtProd.");
                }
                dtProd.DataSource = null;
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
            }
        }

        private void dtVenda_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistrosVenda.Text = "Registros: 0";
        }

        private void dtItensVenda_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistrosItem.Text = "Registros: 0";
            lblValorTotal.Text = Convert.ToDecimal(Convert.ToDecimal(lblValorCredito.Text) - Convert.ToDecimal(lblValorNovosItens.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void dtProd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistrosProd.Text = "Registros: 0";
            //
            lblValorTotal.Text = Convert.ToDecimal(Convert.ToDecimal(lblValorCredito.Text) - Convert.ToDecimal(lblValorNovosItens.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void dtProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                dtProd.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtProd.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtProd.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[0].DefaultCellStyle.Format = "D3";
                dtProd.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[3].DefaultCellStyle.Format = "n2";
                dtProd.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[5].DefaultCellStyle.Format = "n2";
                dtProd.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[6].DefaultCellStyle.Format = "n2";
                dtProd.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[7].DefaultCellStyle.Format = "n2";
                dtProd.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[8].DefaultCellStyle.Format = "n2";
                dtProd.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[9].DefaultCellStyle.Format = "n2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                dtProd.DataSource = null;
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
            }
        }

        private void dtItensVenda_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtItensVenda.Rows[dtItensVenda.CurrentRow.Index];

                dtItensVenda.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtItensVenda.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtItensVenda.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[0].DefaultCellStyle.Format = "D3";
                dtItensVenda.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[3].DefaultCellStyle.Format = "n2";
                dtItensVenda.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[5].DefaultCellStyle.Format = "n2";
                dtItensVenda.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[6].DefaultCellStyle.Format = "n2";
                dtItensVenda.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[7].DefaultCellStyle.Format = "n2";
                dtItensVenda.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[8].DefaultCellStyle.Format = "n2";
                dtItensVenda.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[9].DefaultCellStyle.Format = "n2";
                dtItensVenda.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[10].DefaultCellStyle.Format = "n2";
                dtItensVenda.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItensVenda.Columns[11].DefaultCellStyle.Format = "n2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItensVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItensVenda.");
                }
                dtItensVenda.DataSource = null;
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;

                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    bllDevolucao.Excluir_Item_Dev_Prod(SelectedRow.Cells[0].Value.ToString());

                    bllDevolucao.Atualizar_Item_Dev_Prod(dtProd.CurrentRow.Index + 1, dtProd.Rows.Count);

                    dtProd.DataSource = bllDevolucao.Sel_Todos_Itens_Dev_Prod_Temp();

                    if (dtProd.Rows.Count > 1)
                    {
                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                    }
                    btnIncluir.Select();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
            }
        }

        private void dtProd_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                dtProd.Enabled = false;
                btnExcluir.Enabled = false;
                lblValorNovosItens.Text = "0,00";
                lblValorTotal.Text = Convert.ToDecimal(Convert.ToDecimal(lblValorCredito.Text) - Convert.ToDecimal(lblValorNovosItens.Text)).ToString("n2", new CultureInfo("pt-BR"));
            }
            else
            {
                dtProd.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void dtProd_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtProd_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtItensVenda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtItensVenda.Rows[dtItensVenda.CurrentRow.Index];

                using (FrmQuantidade Qtde = new FrmQuantidade(1, Convert.ToDecimal(SelectedRow.Cells[3].Value.ToString()).ToString("n2", new CultureInfo("pt-BR"))))
                {
                    if (Qtde.ShowDialog() == DialogResult.OK)
                    {
                        if (Convert.ToDecimal(bllDevolucao._Quantidade) > bllDevolucao.Sel_Quantidade_Item_Venda_Dev(lblCodigoVenda.Text))
                        {
                            MessageBox.Show("A quantidade do item a ser devolvida não pode ser maior que a quantidade do item na venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtItensVenda.Select();
                        }
                        else
                        {

                            bllDevolucao.Alterar_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), bllDevolucao._Quantidade, SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[9].Value.ToString());
                            dtItensVenda.DataSource = bllDevolucao.Sel_Todas_Itens_Venda_Dev();
                            dtItensVenda.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSelecionar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSelecionar.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                dtItensVenda.DataSource = null;
            }
        }

        private void btnZerar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnZerar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                lblValorTotalProdutos.Text = Convert.ToDecimal(SelectedRow.Cells[9].Value.ToString()).ToString("n2", new CultureInfo("pt-BR"));
                lblValorTotalVenda.Text = Convert.ToDecimal(SelectedRow.Cells[10].Value.ToString()).ToString("n2", new CultureInfo("pt-BR"));
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Salvar_Todos_Itens_Venda_Dev_Codigo(SelectedRow.Cells[0].Value.ToString(), bllConexao._Codigo_Conexao);
                dtItensVenda.DataSource = bllDevolucao.Sel_Todas_Itens_Venda_Dev();
                dtProd.DataSource = null;
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                lblCodigoVenda.Text = SelectedRow.Cells[0].Value.ToString();
                btnContinuar.Enabled = true;
                btnIncluir.Enabled = true;
                dtItensVenda.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSelecionar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSelecionar.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }

        private void btnZerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtItensVenda.Rows.Count == 1)
                {
                    MessageBox.Show("Não é possível aplicar a quantidade 0 em um único item.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtItensVenda.Select();
                }
                else
                {
                    for (int a = 0; a < dtItensVenda.Rows.Count; a++)
                    {
                        DataGridViewRow SelectedRow = dtItensVenda.Rows[a];
                        //
                        bllDevolucao.Alterar_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), "0,00", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[9].Value.ToString());
                    }
                    dtItensVenda.DataSource = bllDevolucao.Sel_Todas_Itens_Venda_Dev();
                    dtItensVenda.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSelecionar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSelecionar.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }

        private void btnAltQuantidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAltQuantidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAltQuantidade_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;

                DataGridViewRow SelectedRow = dtItensVenda.Rows[dtItensVenda.CurrentRow.Index];

                using (FrmQuantidade Qtde = new FrmQuantidade(1, Convert.ToDecimal(SelectedRow.Cells[3].Value.ToString()).ToString("n2", new CultureInfo("pt-BR"))))
                {
                    if (Qtde.ShowDialog() == DialogResult.OK)
                    {
                        if (Convert.ToDecimal(bllDevolucao._Quantidade) > bllDevolucao.Sel_Quantidade_Item_Venda_Dev(lblCodigoVenda.Text))
                        {
                            MessageBox.Show("A quantidade do item a ser devolvida não pode ser maior que a quantidade do item na venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            bllDevolucao._Quantidade = null;
                            dtItensVenda.Select();
                        }
                        else if (dtItensVenda.Rows.Count == 1 & Convert.ToDecimal(bllDevolucao._Quantidade) <= 0)
                        {
                            MessageBox.Show("Não é possível aplicar a quantidade 0 em um único item.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            bllDevolucao._Quantidade = null;
                            dtItensVenda.Select();
                        }
                        else
                        {

                            bllDevolucao.Alterar_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), bllDevolucao._Quantidade, SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[9].Value.ToString());
                            dtItensVenda.DataSource = bllDevolucao.Sel_Todas_Itens_Venda_Dev();
                            bllDevolucao._Quantidade = null;
                            dtItensVenda.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAltQuantidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAltQuantidade.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
            pEnabled.Enabled = true;
        }

        private void lblValorTotalProdutos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalProdutos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorCredito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorCredito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorNovosItens_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorNovosItens_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total da Venda (R$): " + lblValorTotalVenda.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalProdutos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Produtos (R$): " + lblValorTotalProdutos.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorCredito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Crédito (R$): " + lblValorCredito.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorNovosItens_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Novos Itens (R$): " + lblValorNovosItens.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Diferença (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                //
                DataRow drTipoPgto = bllVenda.Sel_Dados_Pagamento_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (drTipoPgto["tipo"].ToString() == "NOTA PROMISSORIA")
                {
                    MessageBox.Show("Não é possível utilizar a Devolução/Troca para uma Venda em [ Nota Promissória ]. É necessário emitir um DFe de entrada dos itens de uma Venda em Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else if (drTipoPgto["tipo"].ToString() == "CREDITO LOJA")
                {
                    MessageBox.Show("Não é possível utilizar a Devolução/Troca para uma Venda em\n[ Crédito Loja ]. É necessário emitir um DFe de entrada dos itens de uma Venda em Crédito da Loja.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    DataRow dr;
                    //
                    pEnabled.Enabled = false;
                    if (lblValorCredito.Text == "0,00")
                    {
                        MessageBox.Show("É necessário informar pelo um item para iniciar a devolução/troca.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", null, null, null, null, null, null, null, null, SelectedRow.Cells[0].Value.ToString()) != null)
                        {
                            dr = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", null, null, null, null, null, null, null, null, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            if (dr["situacao"].ToString() != "TRANSMITIDA")
                            {
                                string status = null;
                                //
                                if (dr["situacao"].ToString() == "PENDENTE")
                                {
                                    status = "Pendente";
                                }
                                else if (dr["situacao"].ToString() == "CANCELADA")
                                {
                                    status = "Cancelada";
                                }
                                else if (dr["situacao"].ToString() == "INUTILIZADA")
                                {
                                    status = "Inutilizada";
                                }
                                //
                                MessageBox.Show("A venda [ " + SelectedRow.Cells[0].Value.ToString() + " ] correspondente à Nota Fiscal de nº [ " + dr["id_dfe"].ToString() + " ] está com status [ " + status + " ].\nÉ necessário transmitir a nota ou inutilizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                pEnabled.Enabled = true;
                                return;
                            }
                        }
                        //
                        if (Convert.ToDecimal(lblValorNovosItens.Text) < Convert.ToDecimal(lblValorCredito.Text))
                        {
                            if (bllDevolucao.Sel_Existe_Devolucao(lblCodigoVenda.Text) == true)
                            {
                                DialogResult = MessageBox.Show("Já existe uma devolução para a venda selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pEnabled.Enabled = true;
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                            //
                            string consumidor;
                            //
                            if (SelectedRow.Cells[1].Value.ToString() == "0")
                            {
                                DialogResult = MessageBox.Show("Deseja identificar o consumidor?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    this.DialogResult = DialogResult.None;
                                    using (FrmPesqConsumidor Clie = new FrmPesqConsumidor(1, null, _Usuario, _Cod_PDV_Computador))
                                    {
                                        if (Clie.ShowDialog() == DialogResult.OK)
                                        {
                                            this.DialogResult = DialogResult.None;
                                            consumidor = bllDevolucao._Consumidor_PesqDev;
                                            bllDevolucao._Consumidor_PesqDev = null;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.None;
                                            consumidor = null;
                                            bllDevolucao._Consumidor_PesqDev = null;
                                        }
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    consumidor = null;
                                }
                            }
                            else
                            {
                                consumidor = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString();
                            }
                            //
                            using (FrmDevTipo Dev = new FrmDevTipo(lblValorTotal.Text, consumidor))
                            {
                                if (Dev.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllDevolucao._Tipo_Dev_Forma == 1)
                                    {
                                        using (FrmDevValor Val = new FrmDevValor(lblValorTotal.Text, "Será devolvido em dinheiro:"))
                                        {
                                            if (Val.ShowDialog() == DialogResult.OK)
                                            {
                                                bllDevolucao.Salvar_Devolucao(consumidor, lblValorCredito.Text, _Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString(), dtProd.Rows.Count, 1, lblValorNovosItens.Text, lblValorTotal.Text);
                                                //
                                                bllVenda._Cod_Devolucao = bllDevolucao.Sel_Ultima_Devolucao();
                                                //
                                                bllVenda._Valor_Desconto_Devolucao = null;
                                                //
                                                bllRegistroAtividades.Salvar("DEVOLVEU DINHEIRO E/OU PRODUTO", "DEVOLUCAO", bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                                                //
                                                dr = bllDevolucao.Sel_Dados_Devolucao_A_Finalizar(bllVenda._Cod_Devolucao).Rows[0];
                                                //
                                                bllDevolucao.Salvar_Pagamento_Devolucao("1", "1", "DINHEIRO", lblValorTotal.Text, bllVenda._Cod_Devolucao, dr["data"].ToString().Remove(10), dr["horario"].ToString(), _Usuario, _Cod_PDV_Computador);
                                                //
                                                bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "DEVOLUCAO DE PRODUTOS", lblValorCredito.Text, bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                                                //
                                                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.DialogResult = DialogResult.None;
                                                //
                                                for (int i = 0; i < dtItensVenda.Rows.Count; i++)
                                                {
                                                    SelectedRow = dtItensVenda.Rows[i];

                                                    bllDevolucao.Salvar_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString());
                                                    bllDevolucao.Alterar_Estoque_Produto_Devolucao(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString());
                                                }
                                                //
                                                for (int i = 0; i < dtProd.Rows.Count; i++)
                                                {
                                                    SelectedRow = dtProd.Rows[i];

                                                    bllDevolucao.Salvar_Novos_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString());
                                                }
                                                //
                                                bool retorno;
                                                if (dtProd.Rows.Count > 0)
                                                {
                                                    for (int a = 0; a < dtProd.Rows.Count; a++)
                                                    {
                                                        SelectedRow = dtProd.Rows[a];
                                                        //
                                                        if (bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "") == null)
                                                        {
                                                            MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                            this.DialogResult = DialogResult.None;
                                                        }
                                                        else
                                                        {
                                                            dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];
                                                            //
                                                            bllVenda.Salvar_Items_PDV_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), bllConexao._Codigo_Conexao, "PRODUTO");
                                                        }
                                                        //
                                                        if (a + 1 == dtProd.Rows.Count)
                                                        {
                                                            bllVenda._Descricao_Produto = SelectedRow.Cells[2].Value.ToString();
                                                        }
                                                        //                                                
                                                        bllVenda._PDV_PesqCliente_Tabela = consumidor;
                                                    }
                                                    retorno = true;
                                                }
                                                else
                                                {
                                                    retorno = false;
                                                }
                                                //
                                                SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                                //
                                                if (SelectedRow.Cells[12].Value.ToString() == "NFCe" || SelectedRow.Cells[12].Value.ToString() == "NFe")
                                                {
                                                    string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                                    //
                                                    DataRow drClieCons;
                                                    if (bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()) == null)
                                                    {
                                                        DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                                        //
                                                        string pessoa = null;
                                                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Length == 18)
                                                        {
                                                            pessoa = "1";
                                                        }
                                                        else
                                                        {
                                                            pessoa = "0";
                                                        }
                                                        //
                                                        bllClieCons.Salvar(drMinhaEmpresa["nome"].ToString(), null, null, drMinhaEmpresa["ie_rg"].ToString(), drMinhaEmpresa["cpf_cnpj"].ToString(), null, null, null, drMinhaEmpresa["endereco"].ToString(), drMinhaEmpresa["numero"].ToString(), null, drMinhaEmpresa["bairro"].ToString(), drMinhaEmpresa["cidade"].ToString(), drMinhaEmpresa["uf"].ToString(), drMinhaEmpresa["cep"].ToString(), null, null, null, null, null, null, null, null, null, null, null, pessoa, null, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, _Cod_PDV_Computador, "4—CLIENTES NO GERAL", "4—GERAL", drMinhaEmpresa["codigo_municipio"].ToString());
                                                        //
                                                        drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                                    }
                                                    else
                                                    {
                                                        drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                                    }
                                                    //
                                                    DataRow drCFOP;
                                                    if (bllCFOP.Sel_CFOP_Codigo("1202") == null)
                                                    {
                                                        bllCFOP.Salvar("DEVOLUCAO DE VENDA DE MERQ. ADQ. OU REC. DE TERCEIROS", "1202", "ENTRADA");
                                                        //
                                                        drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                                    }
                                                    else
                                                    {
                                                        drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                                    }
                                                    //
                                                    bllDFe.Salvar(null, "PRÓPRIA", "55", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, drClieCons["id_cliente"].ToString() + "—" + drClieCons["nome"].ToString() + "—" + drClieCons["cpf_cnpj"].ToString(), null, (Convert.ToDecimal(lblValorCredito.Text) + (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)) - (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value))).ToString(), (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)).ToString(), "0", (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString(), lblValorCredito.Text, "1202—" + drCFOP["descricao"].ToString(), false, _Cod_PDV_Computador, "CLIENTES", "0", "0", true, "RETORNO", false, "OPERACAO PRESENCIAL", "PENDENTE", null, null, bllVenda._Cod_Devolucao, false);
                                                    string cod_dfe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                                    //
                                                    if (bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao) != null)
                                                    {
                                                        for (int i = 0; i < bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows.Count; i++)
                                                        {
                                                            DataRow drDevolucao = bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows[i];
                                                            //
                                                            DataRow drProduto = bllProduto.Sel_Prod_Codigo(drDevolucao["id_produto"].ToString(), "").Rows[0];
                                                            //
                                                            string valor_desconto = (Convert.ToDecimal(drDevolucao["valor_desconto"]) + Convert.ToDecimal(drDevolucao["valor_desconto_item"])).ToString();
                                                            //
                                                            string valor_acrescimo = (Convert.ToDecimal(drDevolucao["valor_acrescimo"]) + Convert.ToDecimal(drDevolucao["valor_acrescimo_item"])).ToString();
                                                            //
                                                            string valor_total_real = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                                            //
                                                            string valor_base_calculo = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                                            //
                                                            string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                                            //
                                                            bllDFe.Salvar_Items(i.ToString(), drDevolucao["id_produto"].ToString() + "—" + drDevolucao["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), "1202", drDevolucao["quantidade"].ToString(), "1", drDevolucao["valor_total"].ToString(), drDevolucao["valor_unitario"].ToString(), valor_desconto, valor_acrescimo, valor_total_real, valor_icms, valor_base_calculo, cod_dfe, "0", "0", "0", "0", "0", drDevolucao["um"].ToString(), "0", "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                                        }
                                                    }
                                                    //
                                                    decimal icms = 0;
                                                    decimal icmsst = 0;
                                                    decimal base_calculo_icms = 0;
                                                    decimal base_calculo_icms_st = 0;
                                                    decimal total_aprox_trib = 0;
                                                    //
                                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(cod_dfe).Rows.Count; i++)
                                                    {
                                                        dr = bllDFe.Sel_Items_DFe(cod_dfe).Rows[i];
                                                        //
                                                        icms += Convert.ToDecimal(dr["valor_icms"]);
                                                        icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                                        base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                                        base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                                        total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                                    }
                                                    //
                                                    bllDFe.Salvar_icms_icms_st_base_total_trib(cod_dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                                                    //
                                                    MessageBox.Show("O próximo procedimento será a emissão da Nota Fiscal eletrônica [ NFe Modelo 55 ] de retorno dos produtos.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                    //
                                                    using (FrmCadNFeNFCe Dfe = new FrmCadNFeNFCe(_Usuario, _Cod_PDV_Computador, 4, null, null, cod_dfe, 0, false))
                                                    {
                                                        if (Dfe.ShowDialog() == DialogResult.Abort)
                                                        {
                                                            bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                                            bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                                            if (retorno == true)
                                                            {
                                                                this.DialogResult = DialogResult.OK;
                                                            }
                                                            else
                                                            {
                                                                this.DialogResult = DialogResult.Abort;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                                            bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                                            if (retorno == true)
                                                            {
                                                                this.DialogResult = DialogResult.OK;
                                                            }
                                                            else
                                                            {
                                                                this.DialogResult = DialogResult.Abort;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                                    bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                                    if (retorno == true)
                                                    {
                                                        this.DialogResult = DialogResult.OK;
                                                    }
                                                    else
                                                    {
                                                        this.DialogResult = DialogResult.Abort;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (bllDevolucao._Tipo_Dev_Forma == 2)
                                    {
                                        using (FrmDevValor Val = new FrmDevValor(lblValorTotal.Text, "Será devolvido em crédito:"))
                                        {
                                            if (Val.ShowDialog() == DialogResult.OK)
                                            {
                                                bllDevolucao.Salvar_Devolucao(consumidor, lblValorCredito.Text, _Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString(), dtProd.Rows.Count, 2, lblValorNovosItens.Text, lblValorTotal.Text);
                                                //
                                                bllVenda._Cod_Devolucao = bllDevolucao.Sel_Ultima_Devolucao();
                                                //
                                                bllVenda._Valor_Desconto_Devolucao = null;
                                                //
                                                bllRegistroAtividades.Salvar("DEVOLVEU CREDITO E/OU PRODUTO", "DEVOLUCAO", bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                                                //
                                                dr = bllDevolucao.Sel_Dados_Devolucao_A_Finalizar(bllVenda._Cod_Devolucao).Rows[0];
                                                //
                                                bllDevolucao.Salvar_Pagamento_Devolucao("1", "5", "CREDITO LOJA", lblValorTotal.Text, bllVenda._Cod_Devolucao, dr["data"].ToString().Remove(10), dr["horario"].ToString(), _Usuario, _Cod_PDV_Computador);
                                                //
                                                //bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAÍDA", "DEVOLUÇÃO DE PRODUTOS", lblValorCredito.Text, bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                                                //
                                                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //
                                                for (int i = 0; i < dtItensVenda.Rows.Count; i++)
                                                {
                                                    SelectedRow = dtItensVenda.Rows[i];

                                                    bllDevolucao.Salvar_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString());
                                                    bllDevolucao.Alterar_Estoque_Produto_Devolucao(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString());
                                                }
                                                //
                                                for (int i = 0; i < dtProd.Rows.Count; i++)
                                                {
                                                    SelectedRow = dtProd.Rows[i];

                                                    bllDevolucao.Salvar_Novos_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString());
                                                }
                                                //
                                                bllDevolucao.Adicionar_Credito_Loja_Cliente(consumidor, lblValorTotal.Text);
                                                //
                                                this.DialogResult = DialogResult.None;
                                                //
                                                bool retorno = false;
                                                if (dtProd.Rows.Count > 0)
                                                {
                                                    for (int a = 0; a < dtProd.Rows.Count; a++)
                                                    {
                                                        SelectedRow = dtProd.Rows[a];
                                                        //
                                                        if (bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "") == null)
                                                        {
                                                            MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                            this.DialogResult = DialogResult.None;
                                                        }
                                                        else
                                                        {
                                                            dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];
                                                            //
                                                            bllVenda.Salvar_Items_PDV_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), bllConexao._Codigo_Conexao, "PRODUTO");
                                                        }
                                                        //
                                                        if (a + 1 == dtProd.Rows.Count)
                                                        {
                                                            bllVenda._Descricao_Produto = SelectedRow.Cells[2].Value.ToString();
                                                        }
                                                        //
                                                        bllVenda._PDV_PesqCliente_Tabela = consumidor;
                                                    }
                                                    retorno = true;
                                                }
                                                else
                                                {
                                                    retorno = false;
                                                }
                                                //
                                                SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                                //
                                                if (SelectedRow.Cells[12].Value.ToString() == "NFCe" || SelectedRow.Cells[12].Value.ToString() == "NFe")
                                                {
                                                    string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                                    //
                                                    DataRow drClieCons;
                                                    if (bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()) == null)
                                                    {
                                                        DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                                        //
                                                        string pessoa = null;
                                                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Length == 18)
                                                        {
                                                            pessoa = "1";
                                                        }
                                                        else
                                                        {
                                                            pessoa = "0";
                                                        }
                                                        //
                                                        bllClieCons.Salvar(drMinhaEmpresa["nome"].ToString(), null, null, drMinhaEmpresa["ie_rg"].ToString(), drMinhaEmpresa["cpf_cnpj"].ToString(), null, null, null, drMinhaEmpresa["endereco"].ToString(), drMinhaEmpresa["numero"].ToString(), null, drMinhaEmpresa["bairro"].ToString(), drMinhaEmpresa["cidade"].ToString(), drMinhaEmpresa["uf"].ToString(), drMinhaEmpresa["cep"].ToString(), null, null, null, null, null, null, null, null, null, null, null, pessoa, null, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, _Cod_PDV_Computador, "4—CLIENTES NO GERAL", "4—GERAL", drMinhaEmpresa["codigo_municipio"].ToString());
                                                        //
                                                        drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                                    }
                                                    else
                                                    {
                                                        drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                                    }
                                                    //
                                                    DataRow drCFOP;
                                                    if (bllCFOP.Sel_CFOP_Codigo("1202") == null)
                                                    {
                                                        bllCFOP.Salvar("DEVOLUCAO DE VENDA DE MERQ. ADQ. OU REC. DE TERCEIROS", "1202", "ENTRADA");
                                                        //
                                                        drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                                    }
                                                    else
                                                    {
                                                        drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                                    }
                                                    //
                                                    bllDFe.Salvar(null, "PRÓPRIA", "55", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, drClieCons["id_cliente"].ToString() + "—" + drClieCons["nome"].ToString() + "—" + drClieCons["cpf_cnpj"].ToString(), null, (Convert.ToDecimal(lblValorCredito.Text) + (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)) - (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value))).ToString(), (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)).ToString(), "0", (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString(), lblValorCredito.Text, "1202—" + drCFOP["descricao"].ToString(), false, _Cod_PDV_Computador, "CLIENTES", "0", "0", true, "RETORNO", false, "OPERACAO PRESENCIAL", "PENDENTE", null, null, bllVenda._Cod_Devolucao, false);
                                                    string cod_dfe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                                    //
                                                    if (bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao) != null)
                                                    {
                                                        for (int i = 0; i < bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows.Count; i++)
                                                        {
                                                            DataRow drDevolucao = bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows[i];
                                                            //
                                                            DataRow drProduto = bllProduto.Sel_Prod_Codigo(drDevolucao["id_produto"].ToString(), "").Rows[0];
                                                            //
                                                            string valor_desconto = (Convert.ToDecimal(drDevolucao["valor_desconto"]) + Convert.ToDecimal(drDevolucao["valor_desconto_item"])).ToString();
                                                            //
                                                            string valor_acrescimo = (Convert.ToDecimal(drDevolucao["valor_acrescimo"]) + Convert.ToDecimal(drDevolucao["valor_acrescimo_item"])).ToString();
                                                            //
                                                            string valor_total_real = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                                            //
                                                            string valor_base_calculo = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                                            //
                                                            string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                                            //
                                                            bllDFe.Salvar_Items(i.ToString(), drDevolucao["id_produto"].ToString() + "—" + drDevolucao["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), "1202", drDevolucao["quantidade"].ToString(), "1", drDevolucao["valor_total"].ToString(), drDevolucao["valor_unitario"].ToString(), valor_desconto, valor_acrescimo, valor_total_real, valor_icms, valor_base_calculo, cod_dfe, "0", "0", "0", "0", "0", drDevolucao["um"].ToString(), "0", "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                                        }
                                                    }
                                                    //
                                                    decimal icms = 0;
                                                    decimal icmsst = 0;
                                                    decimal base_calculo_icms = 0;
                                                    decimal base_calculo_icms_st = 0;
                                                    decimal total_aprox_trib = 0;
                                                    //
                                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(cod_dfe).Rows.Count; i++)
                                                    {
                                                        dr = bllDFe.Sel_Items_DFe(cod_dfe).Rows[i];
                                                        //
                                                        icms += Convert.ToDecimal(dr["valor_icms"]);
                                                        icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                                        base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                                        base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                                        total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                                    }
                                                    //
                                                    bllDFe.Salvar_icms_icms_st_base_total_trib(cod_dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                                                    //
                                                    MessageBox.Show("O próximo procedimento será a emissão da Nota Fiscal eletrônica [ NFe Modelo 55 ] de retorno dos produtos.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                    //
                                                    using (FrmCadNFeNFCe Dfe = new FrmCadNFeNFCe(_Usuario, _Cod_PDV_Computador, 4, null, null, cod_dfe, 0, false))
                                                    {
                                                        if (Dfe.ShowDialog() == DialogResult.Abort)
                                                        {
                                                            bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                                            bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                                            if (retorno == true)
                                                            {
                                                                this.DialogResult = DialogResult.OK;
                                                            }
                                                            else
                                                            {
                                                                this.DialogResult = DialogResult.Abort;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                                            bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                                            if (retorno == true)
                                                            {
                                                                this.DialogResult = DialogResult.OK;
                                                            }
                                                            else
                                                            {
                                                                this.DialogResult = DialogResult.Abort;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                                    bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                                    if (retorno == true)
                                                    {
                                                        this.DialogResult = DialogResult.OK;
                                                    }
                                                    else
                                                    {
                                                        this.DialogResult = DialogResult.Abort;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    pEnabled.Enabled = true;
                                    this.DialogResult = DialogResult.None;
                                    return;
                                }
                            }
                        }
                        else if (Convert.ToDecimal(lblValorNovosItens.Text) == Convert.ToDecimal(lblValorCredito.Text))
                        {
                            if (bllDevolucao.Sel_Existe_Devolucao(lblCodigoVenda.Text) == true)
                            {
                                DialogResult = MessageBox.Show("Já existe uma devolução para a venda selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pEnabled.Enabled = true;
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                            //
                            SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                            //
                            string consumidor;
                            //
                            if (SelectedRow.Cells[1].Value.ToString() == "0")
                            {
                                DialogResult = MessageBox.Show("Deseja identificar o consumidor?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    this.DialogResult = DialogResult.None;
                                    using (FrmPesqConsumidor Clie = new FrmPesqConsumidor(1, null, _Usuario, _Cod_PDV_Computador))
                                    {
                                        if (Clie.ShowDialog() == DialogResult.OK)
                                        {
                                            this.DialogResult = DialogResult.None;
                                            consumidor = bllDevolucao._Consumidor_PesqDev;
                                            bllDevolucao._Consumidor_PesqDev = null;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.None;
                                            consumidor = null;
                                            bllDevolucao._Consumidor_PesqDev = null;
                                        }
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    consumidor = null;
                                }
                            }
                            else
                            {
                                consumidor = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString();
                            }
                            //                  
                            bllDevolucao.Salvar_Devolucao(consumidor, lblValorCredito.Text, _Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString(), dtProd.Rows.Count, 0, lblValorNovosItens.Text, lblValorTotal.Text);
                            //     
                            bllVenda._Cod_Devolucao = bllDevolucao.Sel_Ultima_Devolucao();
                            //               
                            bllVenda._Valor_Desconto_Devolucao = null;
                            //
                            bllRegistroAtividades.Salvar("DEVOLVEU PRODUTO", "DEVOLUCAO", bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                            //
                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "DEVOLUCAO DE PRODUTOS", lblValorCredito.Text, bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                            //
                            for (int i = 0; i < dtItensVenda.Rows.Count; i++)
                            {
                                SelectedRow = dtItensVenda.Rows[i];

                                bllDevolucao.Salvar_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString());
                                bllDevolucao.Alterar_Estoque_Produto_Devolucao(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString());
                            }
                            //
                            for (int i = 0; i < dtProd.Rows.Count; i++)
                            {
                                SelectedRow = dtProd.Rows[i];

                                bllDevolucao.Salvar_Novos_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString());
                            }
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            bool retorno = false;
                            if (dtProd.Rows.Count > 0)
                            {
                                for (int a = 0; a < dtProd.Rows.Count; a++)
                                {
                                    SelectedRow = dtProd.Rows[a];
                                    //
                                    if (bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "") == null)
                                    {
                                        MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];
                                        //
                                        bllVenda.Salvar_Items_PDV_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), bllConexao._Codigo_Conexao, "PRODUTO");
                                    }
                                    //
                                    if (a + 1 == dtProd.Rows.Count)
                                    {
                                        bllVenda._Descricao_Produto = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    bllVenda._PDV_PesqCliente_Tabela = consumidor;
                                }
                                //
                                retorno = true;
                            }
                            else
                            {
                                retorno = false;
                            }
                            //
                            SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                            //
                            if (SelectedRow.Cells[12].Value.ToString() == "NFCe" || SelectedRow.Cells[12].Value.ToString() == "NFe")
                            {
                                string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                //
                                DataRow drClieCons;
                                if (bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()) == null)
                                {
                                    DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                    //
                                    string pessoa = null;
                                    if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Length == 18)
                                    {
                                        pessoa = "1";
                                    }
                                    else
                                    {
                                        pessoa = "0";
                                    }
                                    //
                                    bllClieCons.Salvar(drMinhaEmpresa["nome"].ToString(), null, null, drMinhaEmpresa["ie_rg"].ToString(), drMinhaEmpresa["cpf_cnpj"].ToString(), null, null, null, drMinhaEmpresa["endereco"].ToString(), drMinhaEmpresa["numero"].ToString(), null, drMinhaEmpresa["bairro"].ToString(), drMinhaEmpresa["cidade"].ToString(), drMinhaEmpresa["uf"].ToString(), drMinhaEmpresa["cep"].ToString(), null, null, null, null, null, null, null, null, null, null, null, pessoa, null, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, _Cod_PDV_Computador, "4—CLIENTES NO GERAL", "4—GERAL", drMinhaEmpresa["codigo_municipio"].ToString());
                                    //
                                    drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                }
                                else
                                {
                                    drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                }
                                //
                                DataRow drCFOP;
                                if (bllCFOP.Sel_CFOP_Codigo("1202") == null)
                                {
                                    bllCFOP.Salvar("DEVOLUCAO DE VENDA DE MERQ. ADQ. OU REC. DE TERCEIROS", "1202", "ENTRADA");
                                    //
                                    drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                }
                                else
                                {
                                    drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                }
                                //
                                bllDFe.Salvar(null, "PRÓPRIA", "55", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, drClieCons["id_cliente"].ToString() + "—" + drClieCons["nome"].ToString() + "—" + drClieCons["cpf_cnpj"].ToString(), null, (Convert.ToDecimal(lblValorCredito.Text) + (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)) - (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value))).ToString(), (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)).ToString(), "0", (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString(), lblValorCredito.Text, "1202—" + drCFOP["descricao"].ToString(), false, _Cod_PDV_Computador, "CLIENTES", "0", "0", true, "RETORNO", false, "OPERACAO PRESENCIAL", "PENDENTE", null, null, bllVenda._Cod_Devolucao, false);
                                string cod_dfe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                //
                                if (bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao) != null)
                                {
                                    for (int i = 0; i < bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows.Count; i++)
                                    {
                                        DataRow drDevolucao = bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows[i];
                                        //
                                        DataRow drProduto = bllProduto.Sel_Prod_Codigo(drDevolucao["id_produto"].ToString(), "").Rows[0];
                                        //
                                        string valor_desconto = (Convert.ToDecimal(drDevolucao["valor_desconto"]) + Convert.ToDecimal(drDevolucao["valor_desconto_item"])).ToString();
                                        //
                                        string valor_acrescimo = (Convert.ToDecimal(drDevolucao["valor_acrescimo"]) + Convert.ToDecimal(drDevolucao["valor_acrescimo_item"])).ToString();
                                        //
                                        string valor_total_real = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                        //
                                        string valor_base_calculo = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                        //
                                        string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                        //
                                        bllDFe.Salvar_Items(i.ToString(), drDevolucao["id_produto"].ToString() + "—" + drDevolucao["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), "1202", drDevolucao["quantidade"].ToString(), "1", drDevolucao["valor_total"].ToString(), drDevolucao["valor_unitario"].ToString(), valor_desconto, valor_acrescimo, valor_total_real, valor_icms, valor_base_calculo, cod_dfe, "0", "0", "0", "0", "0", drDevolucao["um"].ToString(), "0", "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                    }
                                }
                                //
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_aprox_trib = 0;
                                //
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(cod_dfe).Rows.Count; i++)
                                {
                                    dr = bllDFe.Sel_Items_DFe(cod_dfe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(dr["valor_icms"]);
                                    icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                    total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(cod_dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                                //
                                MessageBox.Show("O próximo procedimento será a emissão da Nota Fiscal eletrônica [ NFe Modelo 55 ] de retorno dos produtos.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                using (FrmCadNFeNFCe Dfe = new FrmCadNFeNFCe(_Usuario, _Cod_PDV_Computador, 4, null, null, cod_dfe, 0, false))
                                {
                                    if (Dfe.ShowDialog() == DialogResult.Abort)
                                    {
                                        bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                        bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                        if (retorno == true)
                                        {
                                            this.DialogResult = DialogResult.OK;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.Abort;
                                        }
                                    }
                                    else
                                    {
                                        bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                        bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                        if (retorno == true)
                                        {
                                            this.DialogResult = DialogResult.OK;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.Abort;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                if (retorno == true)
                                {
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.Abort;
                                }
                            }
                        }
                        else if (Convert.ToDecimal(lblValorNovosItens.Text) > Convert.ToDecimal(lblValorCredito.Text))
                        {
                            if (bllDevolucao.Sel_Existe_Devolucao(lblCodigoVenda.Text) == true)
                            {
                                DialogResult = MessageBox.Show("Já existe uma devolução para a venda selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pEnabled.Enabled = true;
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                            //
                            DialogResult = MessageBox.Show("O valor total dos [ Produtos (Novos Itens) ] é maior que o valor de [ Itens da Nota Não Fiscal (Crédito) ]\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                //
                                string consumidor;
                                //
                                if (SelectedRow.Cells[1].Value.ToString() == "0")
                                {
                                    DialogResult = MessageBox.Show("Deseja identificar o consumidor?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        using (FrmPesqConsumidor Clie = new FrmPesqConsumidor(1, null, _Usuario, _Cod_PDV_Computador))
                                        {
                                            if (Clie.ShowDialog() == DialogResult.OK)
                                            {
                                                this.DialogResult = DialogResult.None;
                                                consumidor = bllDevolucao._Consumidor_PesqDev;
                                                bllDevolucao._Consumidor_PesqDev = null;
                                            }
                                            else
                                            {
                                                this.DialogResult = DialogResult.None;
                                                consumidor = null;
                                                bllDevolucao._Consumidor_PesqDev = null;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                        consumidor = null;
                                    }
                                }
                                else
                                {
                                    consumidor = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString();
                                }
                                //
                                bllDevolucao.Salvar_Devolucao(consumidor, lblValorCredito.Text, _Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString(), dtProd.Rows.Count, 0, lblValorNovosItens.Text, "0");
                                //     
                                bllVenda._Cod_Devolucao = bllDevolucao.Sel_Ultima_Devolucao();
                                //               
                                bllRegistroAtividades.Salvar("DEVOLVEU PRODUTO", "DEVOLUCAO", bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                                //
                                bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "DEVOLUCAO DE PRODUTOS", lblValorCredito.Text, bllVenda._Cod_Devolucao, _Usuario, _Cod_PDV_Computador);
                                //
                                bllVenda._Valor_Desconto_Devolucao = lblValorTotal.Text.Replace("-", "");
                                //
                                for (int i = 0; i < dtItensVenda.Rows.Count; i++)
                                {
                                    SelectedRow = dtItensVenda.Rows[i];

                                    bllDevolucao.Salvar_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString());
                                    bllDevolucao.Alterar_Estoque_Produto_Devolucao(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString());
                                }
                                //
                                for (int i = 0; i < dtProd.Rows.Count; i++)
                                {
                                    SelectedRow = dtProd.Rows[i];

                                    bllDevolucao.Salvar_Novos_Itens_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllVenda._Cod_Devolucao, SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString());
                                }
                                //
                                this.DialogResult = DialogResult.None;
                                //
                                for (int a = 0; a < dtProd.Rows.Count; a++)
                                {
                                    SelectedRow = dtProd.Rows[a];
                                    //
                                    if (bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "") == null)
                                    {
                                        MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];
                                        //
                                        bllVenda.Salvar_Items_PDV_Devolucao(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), bllConexao._Codigo_Conexao, "PRODUTO");
                                    }
                                    //
                                    if (a + 1 == dtProd.Rows.Count)
                                    {
                                        bllVenda._Descricao_Produto = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    bllVenda._PDV_PesqCliente_Tabela = consumidor;
                                }
                                //
                                SelectedRow = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                //
                                if (SelectedRow.Cells[12].Value.ToString() == "NFCe" || SelectedRow.Cells[12].Value.ToString() == "NFe")
                                {
                                    string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                    //
                                    DataRow drClieCons;
                                    if (bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()) == null)
                                    {
                                        DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        string pessoa = null;
                                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Length == 18)
                                        {
                                            pessoa = "1";
                                        }
                                        else
                                        {
                                            pessoa = "0";
                                        }
                                        //
                                        bllClieCons.Salvar(drMinhaEmpresa["nome"].ToString(), null, null, drMinhaEmpresa["ie_rg"].ToString(), drMinhaEmpresa["cpf_cnpj"].ToString(), null, null, null, drMinhaEmpresa["endereco"].ToString(), drMinhaEmpresa["numero"].ToString(), null, drMinhaEmpresa["bairro"].ToString(), drMinhaEmpresa["cidade"].ToString(), drMinhaEmpresa["uf"].ToString(), drMinhaEmpresa["cep"].ToString(), null, null, null, null, null, null, null, null, null, null, null, pessoa, null, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, _Cod_PDV_Computador, "4—CLIENTES NO GERAL", "4—GERAL", drMinhaEmpresa["codigo_municipio"].ToString());
                                        //
                                        drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                    }
                                    else
                                    {
                                        drClieCons = bllClieCons.Sel_Clie_CPFCNPJ(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ()).Rows[0];
                                    }
                                    //
                                    DataRow drCFOP;
                                    if (bllCFOP.Sel_CFOP_Codigo("1202") == null)
                                    {
                                        bllCFOP.Salvar("DEVOLUCAO DE VENDA DE MERQ. ADQ. OU REC. DE TERCEIROS", "1202", "ENTRADA");
                                        //
                                        drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                    }
                                    else
                                    {
                                        drCFOP = bllCFOP.Sel_CFOP_Codigo("1202").Rows[0];
                                    }
                                    //
                                    bllDFe.Salvar(null, "PRÓPRIA", "55", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, drClieCons["id_cliente"].ToString() + "—" + drClieCons["nome"].ToString() + "—" + drClieCons["cpf_cnpj"].ToString(), null, (Convert.ToDecimal(lblValorCredito.Text) + (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)) - (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value))).ToString(), (Convert.ToDecimal(SelectedRow.Cells[6].Value) + Convert.ToDecimal(SelectedRow.Cells[8].Value)).ToString(), "0", (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString(), lblValorCredito.Text, "1202—" + drCFOP["descricao"].ToString(), false, _Cod_PDV_Computador, "CLIENTES", "0", "0", true, "RETORNO", false, "OPERACAO PRESENCIAL", "PENDENTE", null, null, bllVenda._Cod_Devolucao, false);
                                    string cod_dfe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                    //
                                    if (bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao) != null)
                                    {
                                        for (int i = 0; i < bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows.Count; i++)
                                        {
                                            DataRow drDevolucao = bllDevolucao.Sel_Itens_Devolucao(bllVenda._Cod_Devolucao).Rows[i];
                                            //
                                            DataRow drProduto = bllProduto.Sel_Prod_Codigo(drDevolucao["id_produto"].ToString(), "").Rows[0];
                                            //
                                            string valor_desconto = (Convert.ToDecimal(drDevolucao["valor_desconto"]) + Convert.ToDecimal(drDevolucao["valor_desconto_item"])).ToString();
                                            //
                                            string valor_acrescimo = (Convert.ToDecimal(drDevolucao["valor_acrescimo"]) + Convert.ToDecimal(drDevolucao["valor_acrescimo_item"])).ToString();
                                            //
                                            string valor_total_real = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                            //
                                            string valor_base_calculo = drDevolucao["valor_total_a_desc_acresc"].ToString();
                                            //
                                            string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                            //
                                            bllDFe.Salvar_Items(i.ToString(), drDevolucao["id_produto"].ToString() + "—" + drDevolucao["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), "1202", drDevolucao["quantidade"].ToString(), "1", drDevolucao["valor_total"].ToString(), drDevolucao["valor_unitario"].ToString(), valor_desconto, valor_acrescimo, valor_total_real, valor_icms, valor_base_calculo, cod_dfe, "0", "0", "0", "0", "0", drDevolucao["um"].ToString(), "0", "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                        }
                                    }
                                    //
                                    decimal icms = 0;
                                    decimal icmsst = 0;
                                    decimal base_calculo_icms = 0;
                                    decimal base_calculo_icms_st = 0;
                                    decimal total_aprox_trib = 0;
                                    //
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(cod_dfe).Rows.Count; i++)
                                    {
                                        dr = bllDFe.Sel_Items_DFe(cod_dfe).Rows[i];
                                        //
                                        icms += Convert.ToDecimal(dr["valor_icms"]);
                                        icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                        base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                        base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                        total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                    }
                                    //
                                    bllDFe.Salvar_icms_icms_st_base_total_trib(cod_dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                                    //
                                    MessageBox.Show("O próximo procedimento será a emissão da Nota Fiscal eletrônica [ NFe Modelo 55 ] de retorno dos produtos.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.None;
                                    //
                                    using (FrmCadNFeNFCe Dfe = new FrmCadNFeNFCe(_Usuario, _Cod_PDV_Computador, 4, null, null, cod_dfe, 0, false))
                                    {
                                        if (Dfe.ShowDialog() == DialogResult.Abort)
                                        {
                                            bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                            bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                            this.DialogResult = DialogResult.OK;
                                        }
                                        else
                                        {
                                            bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                            bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                            this.DialogResult = DialogResult.OK;
                                        }
                                    }
                                }
                                else
                                {
                                    bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                                    bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            else
                            {
                                pEnabled.Enabled = true;
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        DataRow drDados = bllDevolucao.Sel_Dados_Devolucao_A_Finalizar(bllVenda._Cod_Devolucao).Rows[0];
                        //
                        for (int i = 0; i < dtItensVenda.Rows.Count; i++)
                        {
                            if (Convert.ToDecimal(dtItensVenda.Rows[i].Cells[3].Value) == 0)
                            {
                                dtItensVenda.Rows.RemoveAt(i);
                            }
                        }
                        //
                        if (bllConfiguracaoSistema.Sel_Tipo_Imp_Devolucao(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)")
                        {
                            prtDocumento.Print();
                        }
                        else if (bllConfiguracaoSistema.Sel_Tipo_Imp_Devolucao(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)(Mostrar na Tela)")
                        {
                            using (var doc = new PdfDocument())
                            {
                                DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                //
                                string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                                byte pessoa;
                                //
                                nome = drPDF["nome"].ToString();
                                fantasia = drPDF["fantasia"].ToString();
                                cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                                ie_rg = drPDF["ie_rg"].ToString();
                                endereco = drPDF["endereco"].ToString();
                                numero = drPDF["numero"].ToString();
                                bairro = drPDF["bairro"].ToString();
                                cidade = drPDF["cidade"].ToString();
                                uf = drPDF["uf"].ToString();
                                cep = drPDF["cep"].ToString();
                                pessoa = Convert.ToByte(drPDF["pessoa"]);
                                //
                                var page = doc.AddPage();
                                //
                                page.Width = 203;
                                page.Height = 842;
                                //
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                var textFormatter2 = new XTextFormatter(graphics);
                                var textFormatter3 = new XTextFormatter(graphics);
                                var textFormatter4 = new XTextFormatter(graphics);
                                //
                                var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                var fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                var fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                XPen pen1 = new XPen(XColors.AntiqueWhite);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                                //
                                StringFormat Sf1 = new StringFormat();
                                Sf1.Alignment = StringAlignment.Near;
                                //
                                StringFormat Sf2 = new StringFormat();
                                Sf2.Alignment = StringAlignment.Far;
                                //
                                int Incrementar = 0;
                                bool PrimeiraPagina = true;
                                int registros;
                                //
                                if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                                {
                                    XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                                    graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                                    imagem1.Dispose();
                                    registros = 30;
                                }
                                else
                                {
                                    Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                                    registros = 32;
                                }
                                //
                                if (nome.Length > 30)
                                {
                                    if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                                    {
                                        textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                                    }
                                    Incrementar = Incrementar + 8;
                                }
                                else
                                {
                                    textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 8));
                                }
                                //
                                if (fantasia.Length > 30)
                                {
                                    if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                                    {
                                        textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                                    }
                                    Incrementar = Incrementar + 8;
                                }
                                else
                                {
                                    textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 8));
                                }
                                //
                                if (pessoa == 1)
                                {
                                    textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                                }
                                else
                                {
                                    textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                                }
                                //
                                textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 109 + Margem_Topo, 198, 24));     //
                                Incrementar = Incrementar - 15;                                                                                                                                                                                                                   //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                                textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, Incrementar + 144 + Margem_Topo, 198, 24));
                                textFormatter1.DrawString("COMPROVANTE DE DEVOLUÇÃO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + Incrementar + Margem_Topo, 198, 24));
                                textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Incrementar + Margem_Topo, 198, 24));
                                //
                                textFormatter2.DrawString(" #   Código  Descrição   Qtde. Devolvida   UN.   Vl.Unit   Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 160 + Margem_Topo, 198, 8));
                                //
                                Incrementar = Incrementar + 1;
                                //
                                for (int linha = 0; linha < dtItensVenda.Rows.Count; linha++)
                                {
                                    SelectedRow = dtItensVenda.Rows[linha];
                                    //
                                    if (PrimeiraPagina == true)
                                    {
                                        if (linha == dtItensVenda.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                            //
                                            Incrementar = Incrementar + 7;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                            //
                                            Incrementar = Incrementar + 14;
                                            //
                                            textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                            //
                                            textFormatter3.DrawString(Convert.ToInt16(dtItensVenda.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                            //
                                            textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                            //
                                            textFormatter3.DrawString(Convert.ToDecimal(drDados["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                            //
                                            DataGridViewRow SelectedRows = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                            //
                                            textFormatter1.DrawString("NNF nº: " + SelectedRows.Cells[0].Value.ToString() + "   " + SelectedRows.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRows.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                            Incrementar = Incrementar + 8;
                                            //
                                            textFormatter1.DrawString("Devolução nº: " + bllVenda._Cod_Devolucao + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["horario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                            //
                                            if (drDados["cpf_cnpj_consumidor"].ToString() != "")
                                            {
                                                textFormatter1.DrawString(drDados["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                                Incrementar = Incrementar + 7;
                                            }
                                            else
                                            {
                                                textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                                Incrementar = Incrementar + 7;
                                            }
                                            //
                                            Incrementar = Incrementar - 8;
                                            //
                                            textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
                                            //
                                            Incrementar = Incrementar + 16;
                                            //
                                            textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
                                        }
                                        else
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                            //
                                            Incrementar = Incrementar + 7;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                            //
                                            Incrementar = Incrementar + 14;
                                        }
                                        //
                                        if (linha == registros - 5 & dtItensVenda.Rows.Count == registros - 3)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 4 & dtItensVenda.Rows.Count == registros - 2)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 3 & dtItensVenda.Rows.Count == registros - 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 2 & dtItensVenda.Rows.Count == registros)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 1 & dtItensVenda.Rows.Count >= registros + 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                    }
                                    else
                                    {
                                        if (linha == dtItensVenda.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                            //
                                            Incrementar = Incrementar + 7;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                            //
                                            Incrementar = Incrementar + 14;
                                            //
                                            textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                            //
                                            textFormatter3.DrawString(Convert.ToInt16(dtItensVenda.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                            //
                                            textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                            //
                                            textFormatter3.DrawString(Convert.ToDecimal(drDados["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                            //
                                            DataGridViewRow SelectedRows = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                            //
                                            textFormatter1.DrawString("NNF nº: " + SelectedRows.Cells[0].Value.ToString() + "   " + SelectedRows.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRows.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                            Incrementar = Incrementar + 8;
                                            //
                                            textFormatter1.DrawString("Devolução nº: " + bllVenda._Cod_Devolucao + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["horario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                            //
                                            if (drDados["cpf_cnpj_consumidor"].ToString() != "")
                                            {
                                                textFormatter1.DrawString(drDados["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                                Incrementar = Incrementar + 7;
                                            }
                                            else
                                            {
                                                textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                                Incrementar = Incrementar + 7;
                                            }
                                            //
                                            Incrementar = Incrementar - 8;
                                            //
                                            textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                                            //
                                            Incrementar = Incrementar + 16;
                                            //
                                            textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                                        }
                                        else
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                            //
                                            Incrementar = Incrementar + 7;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));

                                            Incrementar = Incrementar + 14;
                                        }
                                        //
                                        if (linha == registros - 5 & dtItensVenda.Rows.Count == registros - 3)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 4 & dtItensVenda.Rows.Count == registros - 2)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 3 & dtItensVenda.Rows.Count == registros - 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 2 & dtItensVenda.Rows.Count == registros)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (linha == registros - 1 & dtItensVenda.Rows.Count >= registros + 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 203;
                                            page.Height = 842;
                                            registros = registros + 37;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                            fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                            fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                            fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                    }
                                }
                                PdfSecuritySettings security = doc.SecuritySettings;
                                //
                                security.PermitAccessibilityExtractContent = false;
                                security.PermitAnnotations = false;
                                security.PermitAssembleDocument = false;
                                security.PermitExtractContent = false;
                                security.PermitFormsFill = true;
                                security.PermitFullQualityPrint = false;
                                security.PermitModifyDocument = false;
                                security.PermitPrint = true;
                                //
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao");
                                    doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + bllVenda._Cod_Devolucao + ".pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + bllVenda._Cod_Devolucao + ".pdf");
                                }
                                //
                                Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + bllVenda._Cod_Devolucao + ".pdf");
                            }
                        }
                        else if (bllConfiguracaoSistema.Sel_Tipo_Imp_Devolucao(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)")
                        {
                            using (var doc = new PdfDocument())
                            {
                                DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                //
                                string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                                byte pessoa;
                                //
                                nome = drPDF["nome"].ToString();
                                fantasia = drPDF["fantasia"].ToString();
                                cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                                ie_rg = drPDF["ie_rg"].ToString();
                                endereco = drPDF["endereco"].ToString();
                                numero = drPDF["numero"].ToString();
                                bairro = drPDF["bairro"].ToString();
                                cidade = drPDF["cidade"].ToString();
                                uf = drPDF["uf"].ToString();
                                cep = drPDF["cep"].ToString();
                                pessoa = Convert.ToByte(drPDF["pessoa"]);
                                //
                                var page = doc.AddPage();
                                //
                                page.Width = 595;
                                page.Height = 842;
                                //
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                var textFormatter2 = new XTextFormatter(graphics);
                                var textFormatter3 = new XTextFormatter(graphics);
                                var textFormatter4 = new XTextFormatter(graphics);
                                //
                                var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                var fonte2 = new XFont("Microsoft Sans Serif", 12);
                                var fonte3 = new XFont("Microsoft Sans Serif", 11);
                                var fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                bool PrimeiraPagina = true;
                                int registros;
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                XPen pen1 = new XPen(XColors.AntiqueWhite);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                                //
                                StringFormat Sf1 = new StringFormat();
                                Sf1.Alignment = StringAlignment.Near;
                                //
                                StringFormat Sf2 = new StringFormat();
                                Sf2.Alignment = StringAlignment.Far;
                                //
                                if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                                {
                                    Margem_Topo = Margem_Topo + 5;
                                    XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                                    graphics.DrawImage(imagem1, 280 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                                    imagem1.Dispose();
                                    registros = 14;
                                }
                                else
                                {
                                    Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                                    registros = 16;
                                }
                                //
                                textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 595, 13));
                                //
                                textFormatter1.DrawString(fantasia, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 98 + Margem_Topo, 595, 13));
                                //
                                if (pessoa == 1)
                                {
                                    textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                                }
                                else
                                {
                                    textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                                }
                                //
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, 124 + Margem_Topo, 595, 45);
                                textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 124 + Margem_Topo, 595, 45));
                                //
                                //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                                textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 160 + Margem_Topo, 595, 24));
                                textFormatter1.DrawString("COMPROVANTE DE DEVOLUÇÃO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 169 + Margem_Topo, 595, 13));
                                textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 175 + Margem_Topo, 595, 24));
                                //
                                textFormatter2.DrawString(" #       Código               Descrição                                                               Qtde.        UN.        Vl.Unit        Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 185 + Margem_Topo, 595, 13));
                                //
                                int Incrementar = 0;
                                for (int i = 0; i < dtItensVenda.Rows.Count; i++)
                                {
                                    SelectedRow = dtItensVenda.Rows[i];
                                    if (PrimeiraPagina == true)
                                    {
                                        if (i == dtItensVenda.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 13;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 26;
                                            //
                                            textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 203 + Margem_Topo, 198, 13));
                                            //
                                            textFormatter3.DrawString(Convert.ToInt16(dtItensVenda.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 203 + Margem_Topo, 100, 13));
                                            //
                                            textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 13));
                                            //
                                            textFormatter3.DrawString(Convert.ToDecimal(drDados["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 216 + Margem_Topo, 100, 13));
                                            //
                                            DataGridViewRow SelectedRows = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                            //
                                            textFormatter1.DrawString("NNF nº: " + SelectedRows.Cells[0].Value.ToString() + "   " + SelectedRows.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRows.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 595, 13));
                                            //
                                            textFormatter1.DrawString("Devolução nº: " + bllVenda._Cod_Devolucao + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["horario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 13));
                                            //
                                            if (drDados["cpf_cnpj_consumidor"].ToString() != "")
                                            {
                                                textFormatter1.DrawString(drDados["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 12));
                                                Incrementar = Incrementar + 12;
                                            }
                                            else
                                            {
                                                textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 12));
                                                Incrementar = Incrementar + 12;
                                            }
                                            //
                                            textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 30));
                                            //
                                            textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 281 + Margem_Topo, 585, 11));
                                        }
                                        else
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 13;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 26;
                                        }
                                        //
                                        if (i == registros - 5 & dtItensVenda.Rows.Count == registros - 3)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 4 & dtItensVenda.Rows.Count == registros - 2)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 3 & dtItensVenda.Rows.Count == registros - 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 2 & dtItensVenda.Rows.Count == registros)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 1 & dtItensVenda.Rows.Count >= registros + 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                    }
                                    else
                                    {
                                        if (i == dtItensVenda.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 13;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 26;
                                            //
                                            textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 43 + Margem_Topo, 198, 13));
                                            //
                                            textFormatter3.DrawString(Convert.ToInt16(dtItensVenda.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 43 + Margem_Topo, 100, 13));
                                            //
                                            textFormatter2.DrawString("Valor Total Devolvido R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 13));
                                            //
                                            textFormatter3.DrawString(Convert.ToDecimal(drDados["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 56 + Margem_Topo, 100, 13));
                                            //
                                            DataGridViewRow SelectedRows = dtVenda.Rows[dtVenda.CurrentRow.Index];
                                            //
                                            textFormatter1.DrawString("NNF nº: " + SelectedRows.Cells[0].Value.ToString() + "   " + SelectedRows.Cells[4].Value.ToString().Remove(10) + "   " + SelectedRows.Cells[5].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 595, 13));
                                            //
                                            textFormatter1.DrawString("Devolução nº: " + bllVenda._Cod_Devolucao + "   " + drDados["data"].ToString().Remove(10) + "   " + drDados["horario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 13));
                                            //
                                            if (drDados["cpf_cnpj_consumidor"].ToString() != "")
                                            {
                                                textFormatter1.DrawString(drDados["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 12));
                                                Incrementar = Incrementar + 12;
                                            }
                                            else
                                            {
                                                textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 12));
                                                Incrementar = Incrementar + 12;
                                            }
                                            //
                                            textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 30));
                                            //
                                            textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 121 + Margem_Topo, 585, 11));
                                        }
                                        else
                                        {
                                            textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                            //  
                                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                            //         
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                            textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                            //
                                            //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 13;
                                            //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                            //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                            textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                            //
                                            Incrementar = Incrementar + 26;
                                        }
                                        //
                                        if (i == registros - 5 & dtItensVenda.Rows.Count == registros - 3)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 4 & dtItensVenda.Rows.Count == registros - 2)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 3 & dtItensVenda.Rows.Count == registros - 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 2 & dtItensVenda.Rows.Count == registros)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                        else if (i == registros - 1 & dtItensVenda.Rows.Count >= registros + 1)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            registros = registros + 19;
                                            Margem_Topo = 0;
                                            //
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            textFormatter3 = new XTextFormatter(graphics);
                                            textFormatter4 = new XTextFormatter(graphics);
                                            //
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 12);
                                            fonte3 = new XFont("Microsoft Sans Serif", 11);
                                            fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                            //
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            textFormatter2.Alignment = XParagraphAlignment.Left;
                                            textFormatter3.Alignment = XParagraphAlignment.Right;
                                        }
                                    }
                                }

                                PdfSecuritySettings security = doc.SecuritySettings;
                                //
                                security.PermitAccessibilityExtractContent = false;
                                security.PermitAnnotations = false;
                                security.PermitAssembleDocument = false;
                                security.PermitExtractContent = false;
                                security.PermitFormsFill = true;
                                security.PermitFullQualityPrint = false;
                                security.PermitModifyDocument = false;
                                security.PermitPrint = true;
                                //
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao");
                                    doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + bllVenda._Cod_Devolucao + ".pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + bllVenda._Cod_Devolucao + ".pdf");
                                }
                                //
                                Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Devolucao\" + bllVenda._Cod_Devolucao + ".pdf");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnContinuar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnContinuar.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                dtItensVenda.DataSource = null;
                dtProd.DataSource = null;
                dtVenda.DataSource = null;
                bllVenda._Valor_Desconto_Devolucao = null;
                bllVenda._PDV_PesqCliente_Tabela = null;
                bllVenda._Cod_Devolucao = null;
                bllDevolucao.Excluir_Devolucao_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao.Excluir_Dev_Prod_Atual(bllConexao._Codigo_Conexao);
                bllDevolucao._Consumidor_PesqDev = null;
                rbtnCodigo.Checked = true;
            }
            pEnabled.Enabled = true;
        }

        private void btnContinuar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnContinuar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotal_TextChanged(object sender, EventArgs e)
        {
            if (lblValorTotal.Text.Contains("-"))
            {
                lblValorTotal.ForeColor = Color.Red;
            }
            else
            {
                lblValorTotal.ForeColor = Color.Blue;
            }
        }

        private void cbbpConsumidor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpConsumidor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqConsumidor Pesq = new FrmPesqConsumidor(1, null, _Usuario, _Cod_PDV_Computador))
            {
                if (Pesq.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpConsumidor.Items.Clear();
                        if (bllDevolucao.Sel_Cliente_Dev() == null)
                        {
                            cbbpConsumidor.Text = null;
                            cbbpConsumidor.Enabled = false;
                        }
                        else
                        {
                            cbbpConsumidor.Enabled = true;
                            btnpProcurar.Enabled = true;
                            cbbpConsumidor.Items.Add("");
                            foreach (DataRow dr in bllDevolucao.Sel_Cliente_Dev().Rows)
                            {
                                cbbpConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        string[] itens = bllDevolucao._Consumidor_PesqDev.Split('—');
                        cbbpConsumidor.Text = itens[0] + "—" + itens[1];
                        bllDevolucao._Consumidor_PesqDev = null;
                        btnPesquisar.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        cbbpConsumidor.Items.Clear();
                        cbbpConsumidor.Text = null;
                        bllDevolucao._Consumidor_PesqDev = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtProd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;

                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                        bllDevolucao.Excluir_Item_Dev_Prod(SelectedRow.Cells[0].Value.ToString());

                        bllDevolucao.Atualizar_Item_Dev_Prod(dtProd.CurrentRow.Index + 1, dtProd.Rows.Count);

                        dtProd.DataSource = bllDevolucao.Sel_Todos_Itens_Dev_Prod_Temp();

                        if (dtProd.Rows.Count > 1)
                        {
                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                        }
                        btnIncluir.Select();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                    }
                }
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código, consumidor, data e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Itens da Venda (Crédito): Nesta tabela serão exibidas as informações dos itens da venda selecionada na tabela acima. " + Environment.NewLine + "Para iniciar uma devolução/troca de produtos altere a quantidade do item específico clicando no botão [ Alterar ]." + Environment.NewLine + Environment.NewLine + "Ex: Se a quantidade do item que o cliente comprou foi 10 e o cliente vai devolver apenas 1 você vai alterar a quantidade que antes era 10 e vai informar apenas 1.Desta forma será devolvido apenas 1 quantidade do item selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Produtos (Novos Itens): Nesta tabela serão exibidas as informações dos produtos que serão incluidos para devolução/troca de itens especificados na tabela [ Itens da Venda (Crédito) ]. " + Environment.NewLine + "Clicando no botão [ Incluir ] você vai incluir os produtos que vão fazer parte da devolução/troca." + Environment.NewLine + Environment.NewLine + "Ex: Se na tabela [ Itens da Nota não Fiscal (Crédito) ] você informou que será devolvido apenas 1 unidade de um item que possui o valor unitário de 10, 00 R$ (Dez Reais) você na tabela [ Produtos(Novos Itens) ] vai informar os itens que farão parte desta troca, podendo informar um ou mais itens com valor menor ou igual ao do item selecionado para troca na tabela [ Itens da Nota não Fiscal (Crédito) ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void rbtnData_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpData.Visible = true;
            mtxtHorario.Visible = true;
            mtxtpData1.Visible = true;
            mtxtHorario1.Visible = true;
            btnSelecionarData1.Visible = true;
            lblAte1.Visible = true;
            txtpCodigo.Visible = false;
            cbbpConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Location = new Point(321, 21);
            lblPesquisar.Text = "Digite a data:";
            mtxtpData.Text = null;
            mtxtHorario.Text = null;
            mtxtpData1.Text = null;
            mtxtHorario1.Text = null;
            btnSelecionarData1.Text = null;
            mtxtpData.Select();
        }

        private void mtxtpData_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text == "")
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpData.Text == "")
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void mtxtpData_Leave(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text != "")
            {
                try
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData.Text);

                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData1.Text != "")
                    {
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData.Text) > Convert.ToDateTime(mtxtpData1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida.");
                    }
                    mtxtpData.Text = null;
                }
            }
            mtxtpData.BackColor = Color.White;
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text == "")
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario.Text == "")
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario_Leave(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text != "")
            {
                if (mtxtHorario.Text.Length == 4)
                {
                    mtxtHorario.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida.");
                    }
                    mtxtHorario.Text = null;
                }
            }
            mtxtHorario.BackColor = Color.White;
        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtpData1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text == "")
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpData1.Text == "")
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpData1_Leave(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text != "")
            {
                try
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData1.Text);

                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData1.Text) < Convert.ToDateTime(mtxtpData.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida1.");
                    }
                    mtxtpData1.Text = null;
                }
            }
            mtxtpData1.BackColor = Color.White;
        }

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text == "")
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario1.Text == "")
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario1_Leave(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text != "")
            {
                if (mtxtHorario1.Text.Length == 4)
                {
                    mtxtHorario1.Text = mtxtHorario1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida1.");
                    }
                    mtxtHorario1.Text = null;
                }
            }
            mtxtHorario1.BackColor = Color.White;
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue; 
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(0))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllDevolucao._Data_DatePicker1;
                    mtxtpData1.Text = bllDevolucao._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }
    }
}
