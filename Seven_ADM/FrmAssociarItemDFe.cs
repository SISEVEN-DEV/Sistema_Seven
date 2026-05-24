using BLL;
using Seven_Sistema;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_ADM
{
    public partial class FrmAssociarItemDFe : Form
    {
        public FrmAssociarItemDFe(string usuario, string cod_pdv_computador, string cod_dfe)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Cod_dfe = cod_dfe;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Cod_dfe;

        private void FrmAssociarItemDFe_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAssociarItemDFe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAssociarItemDFe iniciado.");
                }
                //
                cbbProduto.Items.Clear();
                if (bllDFe.Sel_Produto_DFe("ATIVO") == null)
                {
                    cbbProduto.Text = null;
                }
                else
                {
                    cbbProduto.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Produto_DFe("ATIVO").Rows)
                    {
                        cbbProduto.Items.Add(dr["id_produto"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                if (bllDFe.Sel_Items_Associar_DFe(_Cod_dfe) != null)
                {
                    dtItens.DataSource = bllDFe.Sel_Items_Associar_DFe(_Cod_dfe);
                    //
                    dtItens.Select();
                }
                else
                {
                    dtItens.DataSource = null;
                    //
                    MessageBox.Show("O DFe não possui item(ens) sem código de barras para ser(em) associado(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //
                    this.DialogResult = DialogResult.Abort;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAssociarItemDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAssociarItemDFe.");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmAssociarItemDFe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtItens_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtItens.Columns[0].HeaderText = "Item";
                dtItens.Columns[1].HeaderText = "Descrição do Item";
                dtItens.Columns[2].HeaderText = "Cód. do Produto";
                dtItens.Columns[3].HeaderText = "Descrição do Produto";
                dtItens.Columns[4].HeaderText = "Quantidade";
                //
                dtItens.Columns[0].Width = 55;
                dtItens.Columns[1].Width = 225;
                dtItens.Columns[2].Width = 110;
                dtItens.Columns[3].Width = 225;
                dtItens.Columns[4].Width = 110;

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

        private void dtItens_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtItens.Rows.Count;
        }

        private void dtItens_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtItens.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtItens.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                //
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                if (SelectedRow.Cells[2].Value.ToString() == "" || SelectedRow.Cells[2].Value.ToString() == "0")
                {
                    cbbProduto.Text = null;
                }
                else
                {
                    cbbProduto.Text = SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString();
                }
                //
                dtItens.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[0].DefaultCellStyle.Format = "D3";
                //
                if (SelectedRow.Cells[2].Value.ToString() == "" || SelectedRow.Cells[2].Value.ToString() == "0")
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "NÃO ASSOCIADO";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                }
                else
                {

                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "ASSOCIADO";
                    lblValorSituacao.ForeColor = Color.Green;
                    lblCxSituacao.BackColor = Color.Green;
                }
                //
                txtQuantidade.Text = Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtItens.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[4].DefaultCellStyle.Format = "n2";
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

        private void dtItens_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItens.DataSource == null)
            {
                dtItens.Enabled = false;
                grbBox1.Enabled = false;
                btnSalvar.Enabled = false;
                lblCxSituacao.Visible = false;
                lblValorSituacao.Visible = false;
            }
            else
            {
                dtItens.Enabled = true;
                grbBox1.Enabled = true;
                btnSalvar.Enabled = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Visible = true;
            }
        }

        private void dtItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtQuantidade.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            try
            {
                DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                //
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (cbbProduto.Text == "")
                    {
                        if (SelectedRow.Cells[3].Value.ToString() != "")
                        {
                            int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);

                            bllDFe.Excluir_Associacao_Item(txtCodigo.Text, _Cod_dfe);

                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);

                            dtItens.DataSource = bllDFe.Sel_Items_Associar_DFe(_Cod_dfe);

                            bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA ASSOCIACAO DE ITEM", "ASSOCIACAO DE ITEM", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Associação de item alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Associação de item alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
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
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        if (SelectedRow.Cells[3].Value.ToString() == "" || SelectedRow.Cells[3].Value.ToString() == "0")
                        {
                            int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);

                            bllDFe.Salvar_Associacao_Item(txtCodigo.Text, cbbProduto.Text, _Cod_dfe);

                            string[] items = cbbProduto.Text.Split('—');

                            bllDFe.Alterar_Estoque_Produto_NFe(items[0], SelectedRow.Cells[4].Value.ToString(), true);

                            dtItens.DataSource = bllDFe.Sel_Items_Associar_DFe(_Cod_dfe);

                            bllRegistroAtividades.Salvar("SALVOU UMA ASSOCIACAO DE IEM", "ASSOCIACAO DE IEM", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Associação de item cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Associação de item cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
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
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);

                            bllDFe.Alterar_Associacao_Item(txtCodigo.Text, cbbProduto.Text, _Cod_dfe);

                            string[] items = cbbProduto.Text.Split('—');

                            if (SelectedRow.Cells[2].Value.ToString() != items[0])
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);

                                bllDFe.Alterar_Estoque_Produto_NFe(items[0], SelectedRow.Cells[4].Value.ToString(), true);
                            }

                            dtItens.DataSource = bllDFe.Sel_Items_Associar_DFe(_Cod_dfe);

                            bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA ASSOCIACAO DE ITEM", "ASSOCIACAO DE ITEM", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Associação de item alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Associação de item alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
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
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    cbbProduto.Select();
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
                dtItens.DataSource = null;
            }
        }

        private void btnpProcurarDestinatario_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqProduto Prod = new FrmPesqProduto(3, null, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProduto.Items.Clear();
                        if (bllDFe.Sel_Produto_DFe("ATIVO") == null)
                        {
                            cbbProduto.Text = null;
                        }
                        else
                        {
                            cbbProduto.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Produto_DFe("ATIVO").Rows)
                            {
                                cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbProduto.Text = bllDFe._FornDFe_Produto_PesqProduto_Tabela;
                        bllDFe._FornDFe_Produto_PesqProduto_Tabela = null;
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
                    }
                }
            }
            this.Enabled = true;
        }

        private void cbbProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clique para salvar a associação entre um produto sem código de barras, importado de um DFe a um produto já cadastrado no sistema.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmAssociarItemDFe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAssociarItemDFe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAssociarItemDFe foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmAssociarItemDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmAssociarItemDFe.");
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbProduto.Select();
            }
        }
    }
}
