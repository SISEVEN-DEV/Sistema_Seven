using BLL;
using System.Data;
using System.Globalization;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Runtime.ConstrainedExecution;
using Seven_ADM;

namespace Seven_Sistema
{
    public partial class FrmPrecificarItems : Form
    {
        public FrmPrecificarItems(string usuario, string cod_pdv_computador, string cod_dfe, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Cod_dfe = cod_dfe;
            _Formulario = formulario; 
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Cod_dfe;
        private byte _Formulario;

        private void FrmAtualizarPrecoItem_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAtualizarPrecoItem iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAtualizarPrecoItem iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    if (bllPrecificacao.Sel_Items_DFe_Precificacao(_Cod_dfe) != null)
                    {
                        dtItens.DataSource = bllPrecificacao.Sel_Items_DFe_Precificacao(_Cod_dfe);
                        //
                        dtItens.Select();
                    }
                    else
                    {
                        dtItens.DataSource = null;
                        //
                        MessageBox.Show("O DFe não possui item(ens) informado(s) para precificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //
                        this.DialogResult = DialogResult.Abort;
                    }
                }
                else
                {
                    /*
                    if (bllPrecificacao.Sel_Items_DFe_Precificacao(_Cod_dfe) != null)
                    {
                        dtItens.DataSource = bllPrecificacao.Sel_Items_DFe_Precificacao(_Cod_dfe);
                        //
                        dtItens.Select();
                    }
                    else
                    {
                        dtItens.DataSource = null;
                        //
                        MessageBox.Show("O DFe não possui item(ens) informado(s) para precificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //
                        this.DialogResult = DialogResult.Abort;
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAtualizarPrecoItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAtualizarPrecoItem.");
                }
            }
        }

        private void txtMargem_Enter(object sender, EventArgs e)
        {
            txtMargem.BackColor = Color.LightBlue;
        }

        private void txtNovoPreco_Enter(object sender, EventArgs e)
        {
            txtNovoPreco.BackColor = Color.LightBlue;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPrecoAtual.Select();
            }
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCustoTotal.Select();
            }
        }

        private void txtUltCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargem.Select();
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCustoUnitario.Select();
            }
        }

        private void txtNovoCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCustoTotal.Select();
            }
        }

        private void txtNovoSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargem.Select();
            }
        }

        private void txtMargem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNovoPreco.Select();
            }
            if (txtMargem.Text.Contains("-") && e.KeyChar == (char)45)
            {
                e.Handled = true;
            }
            if (txtMargem.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44) && !(e.KeyChar == (char)45))
            {
                e.Handled = true;
            }
        }

        private void txtNovoPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (txtNovoPreco.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
        }

        private void FrmAtualizarPrecoItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAtualizarPrecoItem foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAtualizarPrecoItem foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmAtualizarPrecoItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmAtualizarPrecoItem.");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void dtItens_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtItens.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtItens_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNovoPreco_Leave(object sender, EventArgs e)
        {
            if (txtNovoPreco.Text != "")
            {
                if (txtNovoPreco.Text.Contains("'") || txtNovoPreco.Text.Contains(";") || txtNovoPreco.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtNovoPreco.Text = null;
                    txtNovoPreco.Select();
                }
                else
                {
                    try
                    {
                        txtNovoPreco.Text = Convert.ToDecimal(txtNovoPreco.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNovoPreco.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNovoPreco.");
                        }
                        txtNovoPreco.Text = null;
                    }
                }
            }
            txtNovoPreco.BackColor = Color.White;
        }

        private void txtMargem_Leave(object sender, EventArgs e)
        {
            if (txtMargem.Text != "")
            {
                if (txtMargem.Text.Contains("'") || txtMargem.Text.Contains(";") || txtMargem.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtMargem.Text = null;
                    txtMargem.Select();
                }
                else
                {
                    try
                    {
                        txtMargem.Text = Convert.ToDecimal(txtMargem.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtNovoPreco.Text = Convert.ToDecimal(bllDFe.Calculo_Valormargem_Precificacao(txtCustoUnitario.Text, txtMargem.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtMargem.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtMargem.");
                        }
                        txtMargem.Text = null;
                    }
                }
            }
            txtMargem.BackColor = Color.White;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void dtItens_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItens.DataSource == null)
            {
                dtItens.Enabled = false;
                lblCxSituacao.Visible = false;
                lblValorSituacao.Visible = false;
                btnLimpar.Enabled = false;
                grbBox1.Enabled = false;
                btnSalvar.Enabled = false;
            }
            else
            {
                dtItens.Enabled = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Visible = true;
                btnLimpar.Enabled = true;
                grbBox1.Enabled = true;
                btnSalvar.Enabled = true;
                //
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    if (_Formulario == 0)
                    {
                        if (dtItens.Rows[i].Cells[29].Value.ToString() == "")
                        {
                            dtItens.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            dtItens.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else
                    { 
                    
                    }
                }
            }
        }

        private void dtItens_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    dtItens.Columns[0].HeaderText = "Item";
                    dtItens.Columns[1].HeaderText = "Código";
                    dtItens.Columns[2].HeaderText = "Descrição";
                    dtItens.Columns[3].HeaderText = "UM.";
                    dtItens.Columns[4].HeaderText = "Quantidade";
                    dtItens.Columns[5].HeaderText = "QTD. da Emb.";
                    dtItens.Columns[6].HeaderText = "VL. Unit./Preço (R$)";
                    dtItens.Columns[7].HeaderText = "Total (R$)";
                    dtItens.Columns[8].HeaderText = "Valor do Desconto (R$)";
                    dtItens.Columns[9].HeaderText = "Valor do Acréscimo (R$)";
                    dtItens.Columns[10].HeaderText = "CST";
                    dtItens.Columns[11].HeaderText = "Alíquota ICMS (%)";
                    dtItens.Columns[12].HeaderText = "ICMS";
                    dtItens.Columns[13].HeaderText = "Base de Cálculo ICMS";
                    dtItens.Columns[14].HeaderText = "Total Real (R$)";
                    dtItens.Columns[15].HeaderText = "CSOSN";
                    dtItens.Columns[16].HeaderText = "CFOP";
                    dtItens.Columns[17].HeaderText = "NCM";
                    dtItens.Columns[18].HeaderText = "CEST";
                    dtItens.Columns[19].Visible = false;
                    dtItens.Columns[20].HeaderText = "Alíquota ST (%)";
                    dtItens.Columns[21].HeaderText = "Base de Cálculo ST";
                    dtItens.Columns[22].HeaderText = "MVA (%)";
                    dtItens.Columns[23].HeaderText = "Redução BC ST (%)";
                    dtItens.Columns[24].HeaderText = "ICMS ST";
                    dtItens.Columns[25].Visible = false;
                    dtItens.Columns[26].HeaderText = "Alíquota IPI";
                    dtItens.Columns[27].HeaderText = "IPI";
                    dtItens.Columns[28].HeaderText = "Margem (%)";
                    dtItens.Columns[29].HeaderText = "Novo Preço (R$)";
                    //
                    dtItens.Columns[0].Width = 55;
                    dtItens.Columns[1].Width = 85;
                    dtItens.Columns[2].Width = 255;
                    dtItens.Columns[3].Width = 46;
                    dtItens.Columns[4].Width = 95;
                    dtItens.Columns[5].Width = 100;
                    dtItens.Columns[6].Width = 135;
                    dtItens.Columns[7].Width = 150;
                    dtItens.Columns[8].Width = 150;
                    dtItens.Columns[9].Width = 150;
                    dtItens.Columns[10].Width = 85;
                    dtItens.Columns[11].Width = 150;
                    dtItens.Columns[12].Width = 150;
                    dtItens.Columns[13].Width = 150;
                    dtItens.Columns[14].Width = 150;
                    dtItens.Columns[15].Width = 85;
                    dtItens.Columns[16].Width = 85;
                    dtItens.Columns[17].Width = 120;
                    dtItens.Columns[18].Width = 120;
                    dtItens.Columns[20].Width = 150;
                    dtItens.Columns[21].Width = 150;
                    dtItens.Columns[22].Width = 150;
                    dtItens.Columns[23].Width = 150;
                    dtItens.Columns[24].Width = 150;
                    dtItens.Columns[25].Width = 175;
                    dtItens.Columns[26].Width = 150;
                    dtItens.Columns[27].Width = 150;
                    dtItens.Columns[28].Width = 150;
                    dtItens.Columns[29].Width = 150;

                    dtItens.DefaultCellStyle.Font = new Font(dtItens.Font, FontStyle.Bold);

                    dtItens.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dtItens.Columns[1].HeaderText = "Código";
                    dtItens.Columns[2].HeaderText = "Descrição";
                    dtItens.Columns[3].HeaderText = "UM.";
                    dtItens.Columns[4].HeaderText = "Preço (R$)";
                    dtItens.Columns[5].HeaderText = "Margem (%)";
                    dtItens.Columns[6].HeaderText = "Novo Preço (R$)";
                    //
                    dtItens.Columns[0].Width = 55;
                    dtItens.Columns[1].Width = 85;
                    dtItens.Columns[2].Width = 255;
                    dtItens.Columns[3].Width = 46;
                    dtItens.Columns[4].Width = 100;
                    dtItens.Columns[5].Width = 150;
                    dtItens.Columns[6].Width = 150;
                    //
                    dtItens.DefaultCellStyle.Font = new Font(dtItens.Font, FontStyle.Bold);
                    //
                    dtItens.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtItens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                //
                lblRegistros.Text = "Registros: " + dtItens.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtItens.");
                }
                dtItens.DataSource = null;
            }
        }

        private void dtItens_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtItens.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtItens.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                if (Convert.ToInt32(SelectedRow.Cells[1].Value) == 0)
                {
                    txtCodigo.Text = null;
                }
                else
                {
                    txtCodigo.Text = SelectedRow.Cells[1].Value.ToString();
                }
                //
                txtDescricao.Text = SelectedRow.Cells[2].Value.ToString();
                txtQuantidade.Text = Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR"));
                txtPreco.Text = Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtCustoTotal.Text = Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[27].Value) + Convert.ToDecimal(SelectedRow.Cells[24].Value) - Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtPrecoAtual.Text = Convert.ToDecimal(bllPrecificacao.Sel_Ult_Preco_Produto(SelectedRow.Cells[1].Value.ToString())).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtCustoUnitario.Text = Convert.ToDecimal((Convert.ToDecimal(SelectedRow.Cells[7].Value) + Convert.ToDecimal(SelectedRow.Cells[27].Value) + Convert.ToDecimal(SelectedRow.Cells[24].Value) - Convert.ToDecimal(SelectedRow.Cells[8].Value) + Convert.ToDecimal(SelectedRow.Cells[9].Value)) / Convert.ToDecimal(SelectedRow.Cells[4].Value)).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtUltCusto.Text = Convert.ToDecimal(bllPrecificacao.Sel_Ult_Dfe_Item_Produto(SelectedRow.Cells[1].Value.ToString(), _Cod_dfe)).ToString("n2", new CultureInfo("pt-BR"));
                //
                if (SelectedRow.Cells[28].Value != DBNull.Value)
                {
                    txtMargem.Text = Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtMargem.Text = null;
                }
                //
                if (SelectedRow.Cells[29].Value != DBNull.Value)
                {
                    txtNovoPreco.Text = Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtNovoPreco.Text = null;
                }
                //
                dtItens.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[0].DefaultCellStyle.Format = "D3";
                dtItens.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[4].DefaultCellStyle.Format = "n2";
                dtItens.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[5].DefaultCellStyle.Format = "n2";
                dtItens.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[6].DefaultCellStyle.Format = "n2";
                dtItens.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[7].DefaultCellStyle.Format = "n2";
                dtItens.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[8].DefaultCellStyle.Format = "n2";
                dtItens.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[9].DefaultCellStyle.Format = "n2";
                dtItens.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[11].DefaultCellStyle.Format = "n2";
                dtItens.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[12].DefaultCellStyle.Format = "n2";
                dtItens.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[13].DefaultCellStyle.Format = "n2";
                dtItens.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[14].DefaultCellStyle.Format = "n2";
                dtItens.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[20].DefaultCellStyle.Format = "n2";
                dtItens.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[21].DefaultCellStyle.Format = "n2";
                dtItens.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[22].DefaultCellStyle.Format = "n2";
                dtItens.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[23].DefaultCellStyle.Format = "n2";
                dtItens.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[24].DefaultCellStyle.Format = "n2";
                dtItens.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[26].DefaultCellStyle.Format = "n2";
                dtItens.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[27].DefaultCellStyle.Format = "n2";
                dtItens.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[28].DefaultCellStyle.Format = "n2";
                dtItens.Columns[29].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[29].DefaultCellStyle.Format = "n2";
                //
                if (SelectedRow.Cells[29].Value.ToString() == "")
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                }
                else
                { 
               
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "APURADO";
                    lblValorSituacao.ForeColor = Color.Green;
                    lblCxSituacao.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItens.");
                }
                dtItens.DataSource = null;
            }
        }

        private void FrmPrecificarItems_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPreco.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                if (txtNovoPreco.Text.Trim() == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\rCampo: [ Novo Preço ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNovoPreco.Select();
                }
                else
                {
                    try
                    {
                        DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                        //
                        if (SelectedRow.Cells[29].Value.ToString() != "")
                        {
                            int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                            
                            bllPrecificacao.Alterar(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), txtNovoPreco.Text, txtMargem.Text.Trim(), _Cod_dfe);

                            bllProduto.Adicionar_Saldo_Preco_Produto(SelectedRow.Cells[1].Value.ToString(), null, txtNovoPreco.Text);

                            dtItens.DataSource = bllPrecificacao.Sel_Items_DFe_Precificacao(_Cod_dfe);

                            bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA PRECIFICACAO", "PRECIFICACAO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Precificação alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Precificação alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            foreach (DataGridViewRow row in dtItens.Rows)
                            {
                                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                                {
                                    row.Selected = true;
                                    dtItens.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);

                            bllPrecificacao.Salvar(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), txtNovoPreco.Text, txtMargem.Text.Trim(), _Cod_dfe);
                            
                            bllProduto.Adicionar_Saldo_Preco_Produto(SelectedRow.Cells[1].Value.ToString(), null, txtNovoPreco.Text);

                            dtItens.DataSource = bllPrecificacao.Sel_Items_DFe_Precificacao(_Cod_dfe);

                            bllRegistroAtividades.Salvar("SALVOU UMA PRECIFICACAO", "PRECIFICACAO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Precificação cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Precificação cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            foreach (DataGridViewRow row in dtItens.Rows)
                            {
                                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                                {
                                    row.Selected = true;
                                    dtItens.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        dtItens.DataSource = null;
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                txtMargem.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnLimpar.Select();
            DialogResult = MessageBox.Show("Deseja limpar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                //
                try
                {
                    DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                    //
                    int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                    //
                    bllPrecificacao.Excluir(SelectedRow.Cells[0].Value.ToString(), _Cod_dfe);
                    //
                    dtItens.DataSource = bllPrecificacao.Sel_Items_DFe_Precificacao(_Cod_dfe);
                    //
                    bllRegistroAtividades.Salvar("EXCLUIU UMA PRECIFICACAO", "PRECIFICACAO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                    //
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Precificação excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Precificação excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                    }
                    //
                    foreach (DataGridViewRow row in dtItens.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtItens.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    dtItens.DataSource = null;
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void txtPrecoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUltCusto.Select();
            }
        }

        private void txtUltCusto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQuantidade.Select();
            }
        }

        private void dtItens_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }
    }
}
