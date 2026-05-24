using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelProdInv : Form
    {
        public FrmRelProdInv(string usuario, string cod_pdv_computador, string cod_inventario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Cod_Inventario = cod_inventario;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Cod_Inventario;
        private string _ComboboxProduto_Valor = null;

        private void FrmRelProdInv_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelProdInv iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelProdInv iniciado.");
                }
                //
                rbtnTodos.Checked = true;
                //
                if (bllInventario.Sel_Prod_Inv_Todos(_Cod_Inventario) != null)
                {
                    dtProd.DataSource = bllInventario.Sel_Prod_Inv_Todos(_Cod_Inventario);
                    //
                    dtProd.Select();
                }
                else
                {
                    cbbProduto.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelProdInv.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelProdInv.");
                }
            }
        }

        private void Limpar()
        {
            cbbProdutoServico.Text = null;
            cbbUM.Text = null;
            txtNCM.Text = null;
            txtInvSaldoAtual.Text = null;
            txtInvCustoMedioAtual.Text = null;
            txtInvTotalAtual.Text = null;
            txtQuantidade.Text = null;
            txtCustoMedio.Text = null;
            txtTotalMedio.Text = null;
            txtUltCusto.Text = null;
            txtUltSaldoAtual.Text = null;
            txtUltTotal.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            grbBox2.Enabled = false;
            btnSalvar.Enabled = false;
            if (dtProd.DataSource != null)
            {
                dtProd.Enabled = true;
                dtProd.Select();
            }
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtProd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtProd.Columns[0].HeaderText = "Código";
                dtProd.Columns[1].HeaderText = "Descrição";
                dtProd.Columns[2].HeaderText = "UM";
                dtProd.Columns[3].HeaderText = "NCM";
                dtProd.Columns[4].HeaderText = "Inv. Saldo Atual";
                dtProd.Columns[5].HeaderText = "Inv. Custo Médio Atual";
                dtProd.Columns[6].HeaderText = "Total Inv.";
                dtProd.Columns[7].HeaderText = "Qtde. Entradas";
                dtProd.Columns[8].HeaderText = "Custo Médio";
                dtProd.Columns[9].HeaderText = "Total Médio";
                dtProd.Columns[10].HeaderText = "Saldo";
                dtProd.Columns[11].HeaderText = "Último Custo";
                dtProd.Columns[12].HeaderText = "Total Atual";
                dtProd.Columns[13].Visible = false;

                dtProd.Columns[0].Width = 85;
                dtProd.Columns[1].Width = 320;
                dtProd.Columns[2].Width = 46;
                dtProd.Columns[3].Width = 175;
                dtProd.Columns[3].Width = 125;
                dtProd.Columns[4].Width = 125;
                dtProd.Columns[5].Width = 155;
                dtProd.Columns[6].Width = 125;
                dtProd.Columns[7].Width = 125;
                dtProd.Columns[8].Width = 125;
                dtProd.Columns[9].Width = 125;
                dtProd.Columns[10].Width = 125;
                dtProd.Columns[11].Width = 125;
                dtProd.Columns[12].Width = 125;

                dtProd.DefaultCellStyle.Font = new Font(dtProd.Font, FontStyle.Bold);

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
                dtProd.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRegistros.Text = "Registros: " + dtProd.Rows.Count;

                decimal valortotal = 0;
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtProd.Rows[i].Cells[6].Value);
                }
                lblTotalInv.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valortotalmedio = 0;
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    valortotalmedio += Convert.ToDecimal(dtProd.Rows[i].Cells[9].Value);
                }
                lblTotalMedio.Text = Convert.ToDecimal(valortotalmedio).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valortotalatual = 0;
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    valortotalatual += Convert.ToDecimal(dtProd.Rows[i].Cells[12].Value);
                }
                lblTotalAtual.Text = Convert.ToDecimal(valortotalatual).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento RowsAdded( do datagridview dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento RowsAdded( do datagridview dtProd.");
                }
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void dtProd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblTotalMedio.Text = null;
            lblTotalAtual.Text = null;
            lblTotalInv.Text = null;
        }

        private void dtProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                dtProd.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtProd.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                cbbProdutoServico.Items.Clear();
                if (SelectedRow.Cells[0].Value.ToString() != "0")
                {
                    cbbProdutoServico.Items.Add(SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString());
                    cbbProdutoServico.Text = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                }
                cbbUM.Text = SelectedRow.Cells[2].Value.ToString();
                txtNCM.Text = SelectedRow.Cells[3].Value.ToString();
                dtProd.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[4].DefaultCellStyle.Format = "n2";
                txtInvSaldoAtual.Text = Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[5].DefaultCellStyle.Format = "n2";
                txtInvCustoMedioAtual.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[6].DefaultCellStyle.Format = "n2";
                txtInvTotalAtual.Text = Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[7].DefaultCellStyle.Format = "n2";
                txtQuantidade.Text = Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[8].DefaultCellStyle.Format = "n2";
                txtCustoMedio.Text = Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[9].DefaultCellStyle.Format = "n2";
                txtTotalMedio.Text = Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[10].DefaultCellStyle.Format = "n2";
                txtUltSaldoAtual.Text = Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[11].DefaultCellStyle.Format = "n2";
                txtUltCusto.Text = Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[12].DefaultCellStyle.Format = "n2";
                txtUltTotal.Text = Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR"));
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
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
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

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtInvTotalAtual.Select();
            }
            if (txtInvCustoMedioAtual.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtSaldoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtInvCustoMedioAtual.Select();
            }
            if (txtInvSaldoAtual.Text.Contains("-") && e.KeyChar == (char)45)
            {
                e.Handled = true;
            }
            if (txtInvSaldoAtual.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44) && !(e.KeyChar == (char)45))
            {
                e.Handled = true;
            }
        }

        private void txtEstoqueTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQuantidade.Select();
            }
            if (txtInvTotalAtual.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalMedio.Select();
            }
            if (txtCustoMedio.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCustoMedio.Select();
            }
            if (txtQuantidade.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUltSaldoAtual.Select();
            }
            if (txtTotalMedio.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtCustoAtual_Leave(object sender, EventArgs e)
        {
            if (txtInvCustoMedioAtual.Text != "")
            {
                if (txtInvCustoMedioAtual.Text.Contains("'") || txtInvCustoMedioAtual.Text.Contains(";") || txtInvCustoMedioAtual.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtInvCustoMedioAtual.Text = null;
                    txtInvCustoMedioAtual.Select();
                }
                else
                {
                    try
                    {
                        txtInvCustoMedioAtual.Text = Convert.ToDecimal(txtInvCustoMedioAtual.Text).ToString("n5", new CultureInfo("pt-BR"));
                        //
                        txtInvTotalAtual.Text = Convert.ToDecimal(bllInventario.Calculo_Estoque_Atual(txtInvSaldoAtual.Text, txtInvCustoMedioAtual.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtInvCustoMedioAtual.Text = Convert.ToDecimal(txtInvCustoMedioAtual.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCustoAtual.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCustoAtual.");
                        }
                        txtInvCustoMedioAtual.Text = null;
                    }
                }
            }
            txtInvCustoMedioAtual.BackColor = Color.White;
        }

        private void txtSaldoAtual_Leave(object sender, EventArgs e)
        {
            if (txtInvSaldoAtual.Text != "")
            {
                if (txtInvSaldoAtual.Text.Contains("'") || txtInvSaldoAtual.Text.Contains(";") || txtInvSaldoAtual.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtInvSaldoAtual.Text = null;
                    txtInvSaldoAtual.Select();
                }
                else
                {
                    try
                    {
                        txtInvSaldoAtual.Text = Convert.ToDecimal(txtInvSaldoAtual.Text).ToString("n5", new CultureInfo("pt-BR"));
                        //                    
                        txtInvTotalAtual.Text = Convert.ToDecimal(bllInventario.Calculo_Estoque_Atual(txtInvSaldoAtual.Text, txtInvCustoMedioAtual.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtInvSaldoAtual.Text = Convert.ToDecimal(txtInvSaldoAtual.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSaldoAtual.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSaldoAtual.");
                        }
                        txtInvSaldoAtual.Text = null;
                    }
                }
            }
            txtInvSaldoAtual.BackColor = Color.White;
        }

        private void txtCustoAtual_Enter(object sender, EventArgs e)
        {
            txtInvCustoMedioAtual.BackColor = Color.LightBlue;
        }

        private void txtSaldoAtual_Enter(object sender, EventArgs e)
        {
            txtInvSaldoAtual.BackColor = Color.LightBlue;
        }

        private void cbbProduto_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProduto_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqProduto Prod = new FrmPesqProduto(5, null, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProduto.Items.Clear();
                        if (bllInventario.Sel_Produtos_Inv_Prod() == null)
                        {
                            cbbProduto.Text = null;
                            cbbProduto.Enabled = false;
                            lblPesquisa.Enabled = false;
                        }
                        else
                        {
                            cbbProduto.Enabled = true;
                            lblPesquisa.Enabled = true;
                            cbbProduto.Items.Add("");
                            foreach (DataRow dr in bllInventario.Sel_Produtos_Inv_Prod().Rows)
                            {
                                cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbProduto.Text = bllInventario._Inv_Prod_PesqProd_Tabela;
                        bllInventario._Inv_Prod_PesqProd_Tabela = null;
                        cbbProduto.Select();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        cbbProduto.Text = null;
                        bllInventario._Inv_Prod_PesqProd_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnProduto.Checked == true)
                {
                    if (cbbProduto.Text != "")
                    {
                        if (bllInventario.Sel_Prod_Inv_Cod(cbbProduto.Text, _Cod_Inventario) == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllInventario.Sel_Prod_Inv_Cod(cbbProduto.Text, _Cod_Inventario);
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnBarra.Checked == true)
                {
                    if (rbtnBarra.Text != "")
                    {
                        if (bllInventario.Sel_Prod_Inv_Cod_Barra(txtpBarra.Text, _Cod_Inventario) == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllInventario.Sel_Prod_Inv_Cod_Barra(txtpBarra.Text, _Cod_Inventario);
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllInventario.Sel_Prod_Inv_Todos(_Cod_Inventario) == null)
                    {
                        dtProd.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtProd.DataSource = bllInventario.Sel_Prod_Inv_Todos(_Cod_Inventario);
                        dtProd.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
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
            }
        }

        private void FrmRelProdInv_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelProdInv foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelProdInv foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelProdInv.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelProdInv.");
                }
            }
        }

        private void FrmRelProdInv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void dtProd_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                lblTotalAtual.Enabled = false;
                lblTotalMedio.Enabled = false;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtProd.Enabled = false;
                lblMedio.Enabled = false;
                lblAtual.Enabled = false;
                lblTotalInv.Enabled = false;
                lblInv.Enabled = false;
            }
            else
            {
                lblTotalAtual.Enabled = true;
                lblTotalMedio.Enabled = true;
                dtProd.Enabled = true;
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                lblMedio.Enabled = true;
                lblAtual.Enabled = true;
                lblTotalInv.Enabled = true;
                lblInv.Enabled = true;
            }
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão < Novo > você insere novos dados, ao finalizar clique no botão < Salvar >.\n\n2 - Clicando no botão < Alterar > você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão < Salvar >.\n\n3 - Clicando no botao < Excluir > você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões < Novo > ou < Alterar > e não deseja continuar nessas opções, clique no botão < Cancelar >.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por produto e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
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

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpBarra.Visible = false;
            cbbProduto.Visible = true;
            btnProcurarProduto.Visible = true;
            lblPesquisa.Text = "Produto:";
            lblPesquisa.Location = new Point(416, 16);
            cbbProduto.Text = null;
            cbbProduto.Select();
            //
            cbbProduto.Items.Clear();
            if (bllInventario.Sel_Produtos_Inv_Prod() == null)
            {
                cbbProduto.Text = null;
                cbbProduto.Enabled = false;
                lblPesquisa.Enabled = false;
            }
            else
            {
                cbbProduto.Enabled = true;
                lblPesquisa.Enabled = true;
                cbbProduto.Items.Add("");
                foreach (DataRow dr in bllInventario.Sel_Produtos_Inv_Prod().Rows)
                {
                    cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                }
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpBarra.Visible = false;
            cbbProduto.Visible = false;
            btnProcurarProduto.Visible = false;
            lblPesquisa.Text = "Exibir todo o cadastro:";
            lblPesquisa.Location = new Point(634, 16);
            cbbProduto.Select();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtProd.Enabled = false;
                grbBox1.Enabled = false;
                grbBox2.Enabled = true;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                Limpar();
                cbbProdutoServico.Enabled = true;
                cbbUM.Enabled = true;
                cbbProdutoServico.Select();
                _Inserir_Atualizar = true;
                _Comando_Atualizar = false;
                //
                cbbProdutoServico.Items.Clear();
                if (bllInventario.Sel_Produtos_Inv_Prod() == null)
                {
                    cbbProdutoServico.Text = null;
                }
                else
                {
                    cbbProdutoServico.Items.Add("");
                    foreach (DataRow dr in bllInventario.Sel_Produtos_Inv_Prod().Rows)
                    {
                        cbbProdutoServico.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                txtInvSaldoAtual.Text = "0,00";
                txtInvCustoMedioAtual.Text = "0,00";
                txtInvTotalAtual.Text = "0,00";
                txtQuantidade.Text = "0,00";
                txtCustoMedio.Text = "0,00";
                txtTotalMedio.Text = "0,00";
                txtUltCusto.Text = "0,00";
                txtUltSaldoAtual.Text = "0,00";
                txtUltTotal.Text = "0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                dtProd.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                //
                if (bllProduto.Sel_Produto_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false || bllInventario.Sel_Produto_Inv_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtProd.Select();
                }
                else
                {
                    dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtProd.Enabled = false;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = true;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    txtInvSaldoAtual.Select();
                    _ComboboxProduto_Valor = cbbProdutoServico.Text;
                    _Inserir_Atualizar = true;
                    _Comando_Atualizar = true;
                    //
                    cbbProdutoServico.Items.Clear();
                    if (bllInventario.Sel_Produtos_Inv_Prod() == null)
                    {
                        cbbProdutoServico.Text = null;
                    }
                    else
                    {
                        cbbProdutoServico.Items.Add("");
                        foreach (DataRow dr in bllInventario.Sel_Produtos_Inv_Prod().Rows)
                        {
                            cbbProdutoServico.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    //
                    if (SelectedRow.Cells[0].Value.ToString() != "0")
                    {
                        if (bllInventario.Sel_ComboboxProduto_Valor_A_Alterar(_ComboboxProduto_Valor) != null)
                        {
                            foreach (DataRow dr in bllInventario.Sel_ComboboxProduto_Valor_A_Alterar(_ComboboxProduto_Valor).Rows)
                            {
                                cbbProdutoServico.Text = dr["id_produto"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxProduto_Valor = null;
                        }
                    }
                    //
                    cbbProdutoServico.Enabled = false;
                    btnProcurarProdutoServico.Enabled = false;
                    cbbUM.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                dtProd.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                string codigo = SelectedRow.Cells[0].Value.ToString();
                string um = SelectedRow.Cells[2].Value.ToString();

                if (bllProduto.Sel_Produto_Ainda_Existe(codigo) == false || bllInventario.Sel_Produto_Inv_Ainda_Existe(codigo) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtProd.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Produto?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        bllInventario.Excluir_Item_Inventario(codigo, _Cod_Inventario, um);
                        //
                        bllRegistroAtividades.Salvar("EXCLUIU UM PRODUTO", "ITEM INVENTARIO", codigo, _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto excluído. Cod: " + codigo);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto excluído. Cod: " + codigo);
                        }
                        //
                        if (rbtnProduto.Checked == true)
                        {
                            if (cbbProduto.Text == "")
                            {
                                dtProd.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                if (bllInventario.Sel_Inventario_Codigo(cbbProduto.Text) == null)
                                {
                                    dtProd.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtProd.DataSource = bllInventario.Sel_Inventario_Codigo(cbbProduto.Text);
                                    dtProd.Select();
                                }
                            }
                        }
                        else
                        {
                            if (bllInventario.Sel_Prod_Inv_Todos(_Cod_Inventario) == null)
                            {
                                dtProd.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtProd.DataSource = bllInventario.Sel_Prod_Inv_Todos(_Cod_Inventario);
                                dtProd.Select();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
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
                dtProd.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtProd.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            ModoPesquisa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (cbbProdutoServico.Text == "" || cbbUM.Text == "" || txtInvSaldoAtual.Text.Trim() == "" || txtInvCustoMedioAtual.Text.Trim() == "" || txtInvTotalAtual.Text.Trim() == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Produto ], [ UM ] e\n[ Inventário ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbProduto.Select();
                    }
                    else
                    {
                        string[] items = cbbProdutoServico.Text.Split('—');
                        //
                        if (_Comando_Atualizar == true)
                        {
                            if (bllProduto.Sel_Produto_Ainda_Existe(items[0]) == false)
                            {
                                MessageBox.Show("Não é possível alterar/salvar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                dtProd.DataSource = null;
                                ModoPesquisa();
                                _Inserir_Atualizar = false;
                                _Comando_Atualizar = false;
                            }
                            else
                            {
                                DataRow dr = bllProduto.Sel_Prod_Codigo(items[0], "").Rows[0];
                                //
                                txtNCM.Text = dr["ncm"].ToString();
                                //
                                bllInventario.Alterar_Item_Inventario(cbbProdutoServico.Text, txtInvSaldoAtual.Text, txtInvCustoMedioAtual.Text, txtInvTotalAtual.Text, cbbUM.Text, txtNCM.Text.Trim(), _Cod_Inventario);
                                //
                                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                //
                                dtProd.DataSource = bllInventario.Sel_Item_Inventario_A_Alterar(items[0], _Cod_Inventario);
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM INVENTARIO", "INVENTARIO", items[0], _Usuario, _Cod_PDV_Computador);
                                //
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item Inventário alterado. Cod: " + items[0]);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item Inventário alterado. Cod: " + items[0]);
                                }
                                //
                                ModoPesquisa();
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        else
                        {
                            bllInventario.Salvar_Item_Inventario(cbbProdutoServico.Text, txtInvSaldoAtual.Text, txtInvCustoMedioAtual.Text, txtInvTotalAtual.Text, cbbUM.Text, txtNCM.Text.Trim(), _Cod_Inventario);
                            //
                            Informacoes_Estoque();
                            //
                            dtProd.DataSource = bllInventario.Sel_Item_Inventario_A_Salvar(_Cod_Inventario);
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM INVENTARIO", "INVENTARIO", items[0], _Usuario, _Cod_PDV_Computador);
                            //
                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item Inventário cadastrado. Cod: " + items[0]);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item Inventário cadastrado. Cod: " + items[0]);
                            }
                            //
                            ModoPesquisa();
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    cbbProdutoServico.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                dtProd.DataSource = null;
                rbtnProduto.Checked = true;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void Informacoes_Estoque()
        {
            string[] items = cbbProdutoServico.Text.Split('—');
            //
            DataRow dr = bllInventario.Sel_Inventario_Codigo(_Cod_Inventario).Rows[0];
            //
            //ENTRADAS DE DFE MANUAIS/IMPORTADAS
            //
            if (bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "TERCEIROS") != null)
            {
                for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "TERCEIROS").Rows.Count; i++)
                {
                    DataRow dr1 = bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "TERCEIROS").Rows[i];
                    //
                    if (bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()) != null)
                    {
                        for (int b = 0; b < bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()).Rows.Count; b++)
                        {
                            DataRow dr2 = bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()).Rows[b];
                            //
                            if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()) == true)
                            {
                                if (items[0] == dr2["id_produto"].ToString())
                                {
                                    if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()) != null)
                                    {
                                        decimal quantidade = 0;
                                        decimal total_medio = 0;
                                        //
                                        for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                                        {
                                            DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                            //
                                            total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                            //
                                            quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                        }
                                        //
                                        total_medio = total_medio + Convert.ToDecimal(dr2["valor_total"]);
                                        //
                                        quantidade = quantidade + Convert.ToDecimal(dr2["quantidade"]);
                                        //
                                        DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                        //
                                        if (dr["id_localizacao"].ToString() == "0")
                                        {
                                            bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                        }
                                        else
                                        {
                                            if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //
            //ENTRADAS DE DFE EMITIDAS
            //
            if (bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "PRÓPRIA") != null)
            {
                for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "PRÓPRIA").Rows.Count; i++)
                {
                    DataRow dr1 = bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "PRÓPRIA").Rows[i];
                    //
                    if ((dr1["situacao"].ToString() == "TRANSMITIDA" || dr1["situacao"].ToString() == "PENDENTE") & (dr1["finalidade"].ToString() == "ENTRADA" || dr1["finalidade"].ToString() == "RETORNO"))
                    {
                        if (bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()) != null)
                        {
                            for (int b = 0; b < bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()).Rows.Count; b++)
                            {
                                DataRow dr2 = bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()).Rows[b];
                                //
                                if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()) == true)
                                {
                                    if (items[0] == dr2["id_produto"].ToString())
                                    {
                                        if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()) != null)
                                        {
                                            decimal quantidade = 0;
                                            decimal total_medio = 0;
                                            //
                                            for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                                            {
                                                DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                                //
                                                total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                //
                                                quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                            }
                                            //
                                            total_medio = total_medio + Convert.ToDecimal(dr2["valor_total"]);
                                            //
                                            quantidade = quantidade + Convert.ToDecimal(dr2["quantidade"]);
                                            //
                                            DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //
            //ENTRADAS MANUAIS
            //
            if (bllEntradasProdutos.Sel_Fornecedores_Prod_Dados(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "", "", "MANUAL", "", "", "", "") != null)
            {
                for (int i = 0; i < bllEntradasProdutos.Sel_Fornecedores_Prod_Dados(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "", "", "MANUAL", "", "", "", "").Rows.Count; i++)
                {
                    DataRow dr1 = bllEntradasProdutos.Sel_Fornecedores_Prod_Dados(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "", "", "MANUAL", "", "", "", "").Rows[i];
                    //
                    DataRow dr2 = bllProduto.Sel_Prod_Codigo(dr1["id_prod"].ToString(), "").Rows[0];
                    //
                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()) == true)
                    {
                        if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()) != null)
                        {
                            decimal total_medio = 0;
                            decimal quantidade = 0;
                            //
                            for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                            {
                                DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                //
                                total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                //
                                quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                            }
                            //
                            quantidade = quantidade + Convert.ToDecimal(dr1["qtde"]);
                            //
                            DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                            //
                            if (items[0] == dr2["id_produto"].ToString())
                            {
                                if (dr["id_localizacao"].ToString() == "0")
                                {
                                    if (Convert.ToByte(dr["inv_contabil"]) == 0)
                                    {
                                        bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                    {
                                        if (Convert.ToByte(dr["inv_contabil"]) == 0)
                                        {
                                            bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0"); ;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //
            //SAIDAS DE DFE EMITIDAS
            //
            if (bllVenda.Sel_Venda_Data_Venda(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10)) != null)
            {
                for (int i = 0; i < bllVenda.Sel_Venda_Data_Venda(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10)).Rows.Count; i++)
                {
                    DataRow dr1 = bllVenda.Sel_Venda_Data_Venda(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10)).Rows[i];
                    //
                    if (dr1["tipo"].ToString() == "NFCe" || dr1["tipo"].ToString() == "NFe")
                    {
                        if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "-", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "TRANSMITIDA", dr1["id_venda"].ToString()) != null || bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "-", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "PENDENTE", dr1["id_venda"].ToString()) != null)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(dr1["id_venda"].ToString()) != null)
                            {
                                for (int b = 0; b < bllVenda.Sel_Itens_Venda_Venda(dr1["id_venda"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllVenda.Sel_Itens_Venda_Venda(dr1["id_venda"].ToString()).Rows[b];
                                    //
                                    DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()) == true)
                                    {
                                        if (items[0] == dr2["id_produto"].ToString())
                                        {

                                            decimal quantidade = 0;
                                            decimal total_medio = 0;
                                            //
                                            for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Cod_Inventario, dr2["um"].ToString()).Rows.Count; c++)
                                            {
                                                DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Cod_Inventario, dr2["um"].ToString()).Rows[c];
                                                //
                                                total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                //
                                                quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                            }
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //
            //SAIDAS DE PEDIDO
            //                
            if (bllVenda.Sel_Venda_Data_Venda(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10)) != null)
            {
                for (int i = 0; i < bllVenda.Sel_Venda_Data_Venda(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10)).Rows.Count; i++)
                {
                    DataRow dr1 = bllVenda.Sel_Venda_Data_Venda(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10)).Rows[i];
                    //
                    if (Convert.ToByte(dr["inv_contabil"]) == 0)
                    {
                        if (dr1["tipo"].ToString() == "DAV")
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(dr1["id_venda"].ToString()) != null)
                            {
                                for (int b = 0; b < bllVenda.Sel_Itens_Venda_Venda(dr1["id_venda"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllVenda.Sel_Itens_Venda_Venda(dr1["id_venda"].ToString()).Rows[b];
                                    //
                                    DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()) == true)
                                    {
                                        if (items[0] == dr2["id_produto"].ToString())
                                        {
                                            decimal quantidade = 0;
                                            decimal total_medio = 0;
                                            //
                                            for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Cod_Inventario, dr2["um"].ToString()).Rows.Count; c++)
                                            {
                                                DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Cod_Inventario, dr2["um"].ToString()).Rows[c];
                                                //
                                                total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                //
                                                quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                            }
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //
            //SAIDAS DFE EMITIDAS (SAIDA, DEVOLUCAO...)
            //
            if (bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "PRÓPRIA") != null)
            {
                for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "PRÓPRIA").Rows.Count; i++)
                {
                    DataRow dr1 = bllDFe.Sel_Dfe_Data_Cadastro(dr["data_inicial"].ToString().Remove(10), dr["data_final"].ToString().Remove(10), "PRÓPRIA").Rows[i];
                    //
                    if ((dr1["situacao"].ToString() == "TRANSMITIDA" || dr1["situacao"].ToString() == "PENDENTE") & (dr1["finalidade"].ToString() == "SAIDA" || dr1["finalidade"].ToString() == "DEVOLUCAO" || dr1["finalidade"].ToString() == "COMPLEMENTAR") & Convert.ToInt32(dr1["id_venda"]) == 0)
                    {
                        if (bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()) != null)
                        {
                            for (int b = 0; b < bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()).Rows.Count; b++)
                            {
                                DataRow dr2 = bllDFe.Sel_Items_DFe(dr1["id_dfe"].ToString()).Rows[b];
                                //
                                if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()) == true)
                                {
                                    if (items[0] == dr2["id_produto"].ToString())
                                    {
                                        if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()) != null)
                                        {
                                            decimal quantidade = 0;
                                            decimal total_medio = 0;
                                            //
                                            for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                                            {
                                                DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                                //
                                                total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                //
                                                quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                            }
                                            //
                                            DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), txtInvSaldoAtual.Text, quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cbbProdutoServico_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProdutoServico_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProdutoServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProdutoServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProdutoServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNCM.Select();
            }
        }

        private void cbbUM_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUM_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUM_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtInvSaldoAtual.Select();
            }
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProdutoServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarProdutoServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProdutoServico_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqProduto Prod = new FrmPesqProduto(5, null, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProdutoServico.Items.Clear();
                        if (bllInventario.Sel_Produtos_Inv_Prod() == null)
                        {
                            cbbProdutoServico.Text = null;
                            cbbProdutoServico.Enabled = false;
                        }
                        else
                        {
                            cbbProdutoServico.Enabled = true;
                            lblPesquisa.Enabled = true;
                            cbbProdutoServico.Items.Add("");
                            foreach (DataRow dr in bllInventario.Sel_Produtos_Inv_Prod().Rows)
                            {
                                cbbProdutoServico.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbProdutoServico.Text = bllInventario._Inv_Prod_PesqProd_Tabela;
                        bllInventario._Inv_Prod_PesqProd_Tabela = null;
                        cbbProdutoServico.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProdutoServico.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProdutoServico.");
                        }
                        cbbProdutoServico.Text = null;
                        bllInventario._Inv_Prod_PesqProd_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalReal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalReal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label10_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Atual: " + lblTotalAtual.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalReal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Médio: " + lblTotalMedio.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbProdutoServico_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbProdutoServico.Text != "")
                {
                    string[] items = cbbProdutoServico.Text.Split('—');
                    //
                    if (_Inserir_Atualizar == true)
                    {
                        DataRow dr = bllProduto.Sel_Prod_Codigo(items[0], "").Rows[0];
                        //
                        txtNCM.Text = dr["ncm"].ToString();
                        //
                        if (_Comando_Atualizar == true)
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                            //
                            if (bllInventario.Val_Inv_Prod_Alt(SelectedRow.Cells[0].Value.ToString(), cbbProdutoServico.Text, _Cod_Inventario, cbbUM.Text) == true)
                            {
                                MessageBox.Show("O Produto informado já está cadastrado no inventário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbProdutoServico.Text = null;
                                txtNCM.Text = null;
                                cbbProdutoServico.Select();
                            }
                        }
                        else
                        {
                            if (bllInventario.Val_Inv_Prod(cbbProdutoServico.Text, _Cod_Inventario, cbbUM.Text) == true)
                            {
                                MessageBox.Show("O Produto informado já está cadastrado no inventário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbProdutoServico.Text = null;
                                txtNCM.Text = null;
                                cbbProdutoServico.Select();
                            }
                        }
                    }
                    //

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto cbbProdutoServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto cbbProdutoServico.");
                }
                cbbProdutoServico.Text = null;
            }
        }

        private void chkbAlterarSaldoAtual_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbAlterarSaldoAtual_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbUM.Select();
            }
        }

        private void txtNCM_Enter(object sender, EventArgs e)
        {
            txtNCM.BackColor = Color.LightBlue;
        }

        private void txtNCM_Leave(object sender, EventArgs e)
        {
            if (txtNCM.Text.Contains("'") || txtNCM.Text.Contains(";") || txtNCM.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNCM.Text = null;
                txtNCM.Select();
            }
            txtNCM.BackColor = Color.White;
        }

        private void txtUltSaldoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUltCusto.Select();
            }
        }

        private void txtUltCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUltTotal.Select();
            }
        }

        private void txtUltTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void lblTotalInv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Inv.: " + lblTotalInv.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbUM_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbUM.Text != "")
                {
                    if (_Inserir_Atualizar == true)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                            //
                            if (bllInventario.Val_Inv_Prod_Alt(SelectedRow.Cells[0].Value.ToString(), cbbProdutoServico.Text, _Cod_Inventario, cbbUM.Text) == true)
                            {
                                MessageBox.Show("O Produto informado já está cadastrado no inventário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbUM.Text = null;
                                cbbUM.Select();
                            }
                        }
                        else
                        {
                            if (bllInventario.Val_Inv_Prod(cbbProdutoServico.Text, _Cod_Inventario, cbbUM.Text) == true)
                            {
                                MessageBox.Show("O Produto informado já está cadastrado no inventário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbUM.Text = null;
                                cbbUM.Select();
                            }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto cbbUM.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto cbbUM.");
                }
                cbbUM.Text = null;
            }
        }

        private void lblTotalInv_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalInv_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnBarra_CheckedChanged(object sender, EventArgs e)
        {
            txtpBarra.Visible = true;
            btnProcurarProduto.Visible = false;
            cbbProduto.Visible = false;
            lblPesquisa.Text = "Código de Barras:";
            lblPesquisa.Location = new Point(416, 16);
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void cbbProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpBarra_Leave(object sender, EventArgs e)
        {
            if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpBarra.Text = null;
                txtpBarra.Select();
            }
            txtpBarra.BackColor = Color.White;
        }

        private void txtpBarra_Enter(object sender, EventArgs e)
        {
            txtpBarra.BackColor = Color.LightBlue;
        }

        private void txtpBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnBarra.Checked == true)
                {
                    if (txtpBarra.Text == "")
                    {
                        btnPesquisar.Select();
                    }
                    else if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpBarra.Text = null;
                        txtpBarra.Select();
                    }
                    else
                    {
                        try
                        {
                            if (bllInventario.Sel_Prod_Inv_Cod_Barra(txtpBarra.Text, _Cod_Inventario) == null)
                            {
                                dtProd.DataSource = null;
                            }
                            else
                            {
                                dtProd.DataSource = bllInventario.Sel_Prod_Inv_Cod_Barra(txtpBarra.Text, _Cod_Inventario);
                                dtProd.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            txtpBarra.Text = null;
                            txtpBarra.Select();
                        }
                    }
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }
    }
}
