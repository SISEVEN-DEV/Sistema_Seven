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
    public partial class FrmPagamentoDFe : Form
    {
        public FrmPagamentoDFe(string valor_real_documento, string cod_pdv_computador, string usuario, string cod_dfe)
        {
            InitializeComponent();
            _Valor_Real_Documento = valor_real_documento;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Usuario = usuario;
            _Cod_DFe = cod_dfe;
        }

        private string _Cod_PDV_Computador;
        private string _Valor_Real_Documento;
        private string _Cod_DFe;
        private string _Usuario;

        private void FrmPagDFe_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPagamentoDFe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPagamentoDFe iniciado.");
                }
                //
                lblValorDiferencaTroco.Text = "-" + _Valor_Real_Documento;
                //
                cbbFormaPagamento.Items.Clear();
                //
                if (bllDFe.Sel_Forma_Pagamento_DFe() == null)
                {
                    cbbFormaPagamento.Text = null;
                }
                else
                {
                    cbbFormaPagamento.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Forma_Pagamento_DFe().Rows)
                    {
                        cbbFormaPagamento.Items.Add((dr["id_pagamento"].ToString()) + "—" + (dr["tipo"].ToString()));
                    }
                }
                //
                cbbFormaPagamento.Select();
                //
                chkbConsumidor.Checked = bllDFe._Consumidor_Final;
                //
                if (bllDFe._Tipo_Operacao == "OPERACAO PRESENCIAL")
                {
                    rbtnPresencial.Checked = true;
                }
                else if (bllDFe._Tipo_Operacao == "OPERACAO PELA INTERNET")
                {
                    rbtnInternet.Checked = true;
                }
                else if (bllDFe._Tipo_Operacao == "OPERACAO NAO PRESENCIAL")
                {
                    rbtnNaoPresencial.Checked = true;
                }
                //
                if (_Cod_DFe == null)
                {
                    if (bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao) != null)
                    {
                        dtFormaPagamento.DataSource = bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        dtFormaPagamento.DataSource = null;
                    }
                }
                else
                {
                    if (bllDFe.Sel_Item_DFe_Pgto_Todas(_Cod_DFe) != null)
                    {
                        dtFormaPagamento.DataSource = bllDFe.Sel_Item_DFe_Pgto_Todas(_Cod_DFe);
                    }
                    else
                    {
                        dtFormaPagamento.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPagamentoDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPagamentoDFe.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void chkbConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPresencial_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPresencial_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnInternet_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnInternet_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNaoPresencial_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNaoPresencial_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalPago_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalPago_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDiferencaTroco_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDiferencaTroco_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirReg_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirReg_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvarPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvarPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarForma_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarForma_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFormaPagamento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFormaPagamento_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFormaPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFormaPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmPagamentoDFe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Cod_DFe == null)
                {
                    bllDFe._Consumidor_Final = chkbConsumidor.Checked;
                    //
                    if (rbtnPresencial.Checked == true)
                    {
                        bllDFe._Tipo_Operacao = rbtnPresencial.Text.ToUpper();
                    }
                    else if (rbtnInternet.Checked == true)
                    {
                        bllDFe._Tipo_Operacao = rbtnInternet.Text.ToUpper();
                    }
                    else if (rbtnNaoPresencial.Checked == true)
                    {
                        bllDFe._Tipo_Operacao = rbtnNaoPresencial.Text.ToUpper();
                    }
                }
                else
                {
                    bllDFe._Consumidor_Final = chkbConsumidor.Checked;
                    //
                    if (rbtnPresencial.Checked == true)
                    {
                        bllDFe._Tipo_Operacao = rbtnPresencial.Text.ToUpper();
                    }
                    else if (rbtnInternet.Checked == true)
                    {
                        bllDFe._Tipo_Operacao = rbtnInternet.Text.ToUpper();
                    }
                    else if (rbtnNaoPresencial.Checked == true)
                    {
                        bllDFe._Tipo_Operacao = rbtnNaoPresencial.Text.ToUpper();
                    }
                    //
                    bllDFe.Alterar_Dados_Cons_Presenca_DFe(_Cod_DFe, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao);
                }
                //
                DialogResult = DialogResult.OK;

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPagamentoDFe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPagamentoDFe foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPagamentoDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPagamentoDFe.");
                }
            }
        }

        private void pcibInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao_MouseLeave(object sender, EventArgs e)
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

        private void FrmPagamentoDFe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnProcurarForma_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(2, _Usuario, _Cod_PDV_Computador))
                {
                    if (Pag.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        cbbFormaPagamento.Items.Clear();
                        if (bllDFe.Sel_Forma_Pagamento_DFe() == null)
                        {
                            cbbFormaPagamento.Enabled = false;
                            cbbFormaPagamento.Text = null;
                        }
                        else
                        {
                            cbbFormaPagamento.Enabled = true;
                            cbbFormaPagamento.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Forma_Pagamento_DFe().Rows)
                            {
                                cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                            }
                        }
                        //
                        cbbFormaPagamento.Text = bllDFe._Forma_Pagamento_PesqFormaPagamento_Tabela;
                        bllDFe._Forma_Pagamento_PesqFormaPagamento_Tabela = null;
                        cbbFormaPagamento.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForma.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForma.");
                }
                cbbFormaPagamento.Text = null;
            }
        }

        private void cbbFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorPagamento.Select();
            }
        }

        private void txtValorPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorPagamento.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (btnSalvarPagamento.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    btnSalvarPagamento.Select();
                }
            }
        }

        private void txtValorPagamento_Leave(object sender, EventArgs e)
        {
            if (txtValorPagamento.Text != "")
            {
                if (txtValorPagamento.Text.Contains("'") || txtValorPagamento.Text.Contains(";") || txtValorPagamento.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorPagamento.Text = null;
                    txtValorPagamento.Select();
                }
                else
                {
                    try
                    {
                        txtValorPagamento.Text = Convert.ToDecimal(txtValorPagamento.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorPagamento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorPagamento.");
                        }
                        txtValorPagamento.Text = null;
                    }
                }
            }
            txtValorPagamento.BackColor = Color.White;
        }

        private void txtValorPagamento_Enter(object sender, EventArgs e)
        {
            txtValorPagamento.BackColor = Color.LightBlue;
        }

        private void lblValorTotalPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Pago (R$): " + lblValorTotalPago.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDiferencaTroco_Click(object sender, EventArgs e)
        {
            if (lblDiferencaTroco.Text == "Diferença (R$):")
            {
                MessageBox.Show("Diferença (R$): " + lblValorDiferencaTroco.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                MessageBox.Show("Troco (R$): " + lblValorDiferencaTroco.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
        }

        private void dtFormaPagamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtFormaPagamento.Columns[0].HeaderText = "Item";
            dtFormaPagamento.Columns[1].HeaderText = "Cód. Forma de Pagamento";
            dtFormaPagamento.Columns[2].HeaderText = "Tipo";
            dtFormaPagamento.Columns[3].HeaderText = "Valor Pago (R$)";
            if (_Cod_DFe != null)
            {
                dtFormaPagamento.Columns[4].Visible = false;
            }

            dtFormaPagamento.DefaultCellStyle.Font = new Font(dtFormaPagamento.Font, FontStyle.Bold);

            dtFormaPagamento.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtFormaPagamento.Columns[0].Width = 56;
            dtFormaPagamento.Columns[1].Width = 164;
            dtFormaPagamento.Columns[2].Width = 295;
            dtFormaPagamento.Columns[3].Width = 110;
            //
            decimal valortotal = 0;
            for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
            {
                valortotal += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
            }
            lblValorTotalPago.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordiferenca = 0;
            valordiferenca = valortotal - Convert.ToDecimal(_Valor_Real_Documento);
            if (valortotal > Convert.ToDecimal(_Valor_Real_Documento))
            {
                lblDiferencaTroco.Location = new Point(280, 183);
                lblDiferencaTroco.ForeColor = Color.Blue;
                lblDiferencaTroco.Text = "Troco (R$):";
                lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
            }
            else
            {
                lblDiferencaTroco.Location = new Point(245, 183);
                lblDiferencaTroco.ForeColor = Color.Red;
                lblDiferencaTroco.Text = "Diferença (R$):";
                lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
            }
        }

        private void btnSalvarPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvarPagamento.Select();
                this.DialogResult = DialogResult.None;
                if (cbbFormaPagamento.Text == "" || txtValorPagamento.Text.Trim() == "" || txtValorPagamento.Text.Trim() == "0" || txtValorPagamento.Text.Trim() == "0,00")
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Forma de pagamento ] e [ Valor Pago ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    cbbFormaPagamento.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja salvar os dados da Forma de Pagamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {

                        if (_Cod_DFe == null)
                        {
                            bllDFe.Salvar_Forma_Pagamento_DFe_Temp((dtFormaPagamento.Rows.Count + 1).ToString(), cbbFormaPagamento.Text, txtValorPagamento.Text.Trim(), bllConexao._Codigo_Conexao);
                            //
                            dtFormaPagamento.DataSource = bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao);
                        }
                        else
                        {
                            bllDFe.Salvar_Pagamento_DFe((dtFormaPagamento.Rows.Count + 1).ToString(), cbbFormaPagamento.Text, txtValorPagamento.Text.Trim(), _Cod_DFe);
                            //
                            dtFormaPagamento.DataSource = bllDFe.Sel_Item_DFe_Pgto_Todas(_Cod_DFe);
                        }
                        //
                        dtFormaPagamento.CurrentCell = dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Cells[0];
                        //
                        dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Selected = true;
                        //
                        dtFormaPagamento.FirstDisplayedScrollingRowIndex = dtFormaPagamento.Rows.Count - 1;
                        //
                        cbbFormaPagamento.Text = null;
                        txtValorPagamento.Text = null;
                        //
                        MessageBox.Show("Os dados da Forma de Pagamento foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        cbbFormaPagamento.Select();

                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        cbbFormaPagamento.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarPagamento.");
                }
                //
                dtFormaPagamento.DataSource = null;
            }
        }

        private void dtFormaPagamento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtFormaPagamento.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtFormaPagamento.Columns[3].DefaultCellStyle.Format = "n2";

            dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtFormaPagamento.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtFormaPagamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFormaPagamento.DataSource == null)
            {
                dtFormaPagamento.Enabled = false;
                btnExcluirReg.Enabled = false;
            }
            else
            {
                dtFormaPagamento.Enabled = true;
                btnExcluirReg.Enabled = true;
            }
        }

        private void dtFormaPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtFormaPagamento.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtFormaPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtFormaPagamento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblValorTotalPago.Text = "0,00";
            lblValorDiferencaTroco.Text = "-" + _Valor_Real_Documento;
            lblDiferencaTroco.Location = new Point(245, 183);
            lblDiferencaTroco.ForeColor = Color.Red;
            lblDiferencaTroco.Text = "Diferença (R$):";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            this.DialogResult = DialogResult.OK;

        }

        private void btnExcluirReg_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                try
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (_Cod_DFe == null)
                    {
                        bllDFe.Excluir_Item_Pgto_DFe_Temp(SelectedRow.Cells[0].Value.ToString());

                        bllDFe.Atualizar_Item_Dt_Pgto_DFe_Temp(dtFormaPagamento.CurrentRow.Index + 1, dtFormaPagamento.Rows.Count, bllConexao._Codigo_Conexao);

                        dtFormaPagamento.DataSource = bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        bllDFe.Excluir_Item_Pgto_DFe(SelectedRow.Cells[4].Value.ToString());

                        bllDFe.Atualizar_Item_Dt_Pgto_DFe(dtFormaPagamento.CurrentRow.Index + 1, dtFormaPagamento.Rows.Count);

                        dtFormaPagamento.DataSource = bllDFe.Sel_Item_DFe_Pgto_Todas(_Cod_DFe);

                    }
                    //
                    if (dtFormaPagamento.Rows.Count >= 1)
                    {
                        dtFormaPagamento.CurrentCell = dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Cells[0];
                        //
                        dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Selected = true;
                        //
                        dtFormaPagamento.FirstDisplayedScrollingRowIndex = dtFormaPagamento.Rows.Count - 1;
                    }
                    //
                    MessageBox.Show("Item excluído com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    dtFormaPagamento.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirReg.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirReg.");
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Pagamento: É onde vai ser informado o pagamento realizado pelo consumidor.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtValorPagamento_DoubleClick(object sender, EventArgs e)
        {
            if (txtValorPagamento.Text == "")
            {
                if (dtFormaPagamento.DataSource != null)
                {
                    if (lblValorDiferencaTroco.Text.Contains("-"))
                    {
                        txtValorPagamento.Text = lblValorDiferencaTroco.Text.Replace("-", "");
                    }
                }
                else
                {
                    txtValorPagamento.Text = lblValorDiferencaTroco.Text.Replace("-", "");
                }
            }
        }

        private void txtValorPagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (txtValorPagamento.Text == "")
                {
                    if (dtFormaPagamento.DataSource != null)
                    {
                        if (lblValorDiferencaTroco.Text.Contains("-"))
                        {
                            txtValorPagamento.Text = lblValorDiferencaTroco.Text.Replace("-", "");
                        }
                    }
                    else
                    {
                        txtValorPagamento.Text = lblValorDiferencaTroco.Text.Replace("-", "");
                    }
                }
            }
        }
    }
}
