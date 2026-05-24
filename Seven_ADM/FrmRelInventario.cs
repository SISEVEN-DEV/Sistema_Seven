using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelInventario : Form
    {
        public FrmRelInventario(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Trabalho;
        private string _Codigo;

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            try
            {
                bllInventario._FrmInventario_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInventario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInventario iniciado.");
                }
                //
                if (bllInventario.Sel_Inventario_Todos() == null)
                {
                    btnNovo.Select();
                }
                else
                {
                    dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                    //
                    dtInv.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInventario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInventario.");
                }
            }
        }

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
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

        private void btnExcluirItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioTodos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;
                //
                if (bllInventario.Sel_Ultima_Data_Inventario_Adicionado() != null)
                {
                    MessageBox.Show("Data do último inventário informado: " + bllInventario.Sel_Ultima_Data_Inventario_Adicionado().Remove(10), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //
                using (FrmDataInventario Inv = new FrmDataInventario())
                {
                    if (Inv.ShowDialog() == DialogResult.OK)
                    {
                        pgbProgresso.Visible = true;
                        lblProgresso.Visible = true;
                        lblItem.Enabled = false;
                        dtInv.Enabled = false;
                        lblRegistros.Enabled = false;
                        btnRelatorioTodos.Enabled = false;
                        btnRelatorioPositivo.Enabled = false;
                        btnRelatorioZerado.Enabled = false;
                        btnRelatorioNegativo.Enabled = false;
                        grbBox2.Enabled = false;
                        _Trabalho = 0;
                        bckwIndeterminado.RunWorkerAsync();
                        pgbProgresso.MarqueeAnimationSpeed = 2;
                        this.Cursor = Cursors.WaitCursor;
                        dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    }
                }
                //
                pEnabled.Enabled = true;
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnIncluir.");
                }
            }
        }

        private void FrmInventario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllInventario._FrmInventario_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInventario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInventario foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmInventario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmInventario.");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtInv_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtInv.DataSource == null)
            {
                btnRelatorioTodos.Enabled = false;
                btnAjustarInventario.Enabled = false;
                btnRelatorioTodos.Enabled = false;
                btnRelatorioPositivo.Enabled = false;
                btnRelatorioNegativo.Enabled = false;
                btnRelatorioZerado.Enabled = false;
                lblValorSituacao.Visible = false;
                lblCxSituacao.Visible = false;
                btnExcluir.Enabled = false;
                btnItens.Enabled = false;
                btnFinalizar.Enabled = false;
            }
            else
            {
                dtInv.Enabled = true;
                btnRelatorioTodos.Enabled = true;
                btnAjustarInventario.Enabled = true;
                btnRelatorioTodos.Enabled = true;
                btnRelatorioPositivo.Enabled = true;
                btnRelatorioNegativo.Enabled = true;
                btnRelatorioZerado.Enabled = true;
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
            }
        }

        private void dtInv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtInv.Columns[0].HeaderText = "Còdigo";
            dtInv.Columns[1].HeaderText = "Descrição";
            dtInv.Columns[2].HeaderText = "Data Inicial";
            dtInv.Columns[3].HeaderText = "Data Final";
            dtInv.Columns[4].HeaderText = "Valor";
            dtInv.Columns[5].HeaderText = "Data de Cadastro";
            dtInv.Columns[6].HeaderText = "Cód. da Localização";
            dtInv.Columns[7].HeaderText = "Desc. da Localização";
            dtInv.Columns[8].HeaderText = "Inventário Contábil";
            dtInv.Columns[9].HeaderText = "Situação";

            dtInv.Columns[0].Width = 85;
            dtInv.Columns[1].Width = 342;
            dtInv.Columns[2].Width = 100;
            dtInv.Columns[3].Width = 104;
            dtInv.Columns[4].Width = 125;
            dtInv.Columns[5].Width = 125;
            dtInv.Columns[6].Width = 135;
            dtInv.Columns[7].Width = 275;
            dtInv.Columns[8].Width = 135;
            dtInv.Columns[9].Width = 135;

            dtInv.DefaultCellStyle.Font = new Font(dtInv.Font, FontStyle.Bold);

            dtInv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtInv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistros.Text = "Registros: " + dtInv.Rows.Count;
        }

        private void dtInv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                //
                if (SelectedRow.Cells[9].Value.ToString() == "ABERTO")
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "ABERTO";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                    btnItens.Enabled = true;
                    btnFinalizar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnSincronizar.Enabled = false;
                    btnAjustarInventario.Enabled = true;
                }
                else
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "FINALIZADO";
                    lblValorSituacao.ForeColor = Color.Green;
                    lblCxSituacao.BackColor = Color.Green;
                    btnItens.Enabled = false;
                    btnFinalizar.Enabled = false;
                    btnExcluir.Enabled = true;
                    btnSincronizar.Enabled = true;
                    btnAjustarInventario.Enabled = false;
                }
                //
                dtInv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtInv.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                dtInv.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtInv.Columns[4].DefaultCellStyle.Format = "n2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtInv.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtInv.");
                }
            }
        }

        private void dtInv_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtInv.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtInv_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtInv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 4 && e.Value.ToString() == "")
            {
                e.Value = "0,00";
            }
            //
            if (e.ColumnIndex == 6 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 8 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 8 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
        }

        private void dtInv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo Inventário ] você cria um novo inventário.\n\n2 - Clicando no botão [ Alterar Itens do Inventário ] você altera os itens do inventário de produtos selecionado.\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Clicando no botão [ Atualizar Todo Estoque ] todo o estoque do sistema será atualizado através dos parâmetros específicados.\n\n5 - Clicando no botão [ Zerar Todo Estoque ] todo o estoque do sistema será zerado.\n\n6 - Clicando no botão [ Ajustar Inventário ] todo o inventário será ajustado através dos parâmetros especificados.\n\n7 - Clicando no botão [ Sincronizar Estoque Atual ] todo o estoque será sincronizado com o inventário selecionado.\n\n8 - Clicando no botão [ Finalizar Inventário ] você estará alterando a situação do inventário de [ Pendente ] para [ Finalizado ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                //
                if (bllInventario.Sel_Inventario_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtInv.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Inventário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllUsuario.Sel_Perm_Exc_Inv(_Usuario) == true)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            bllInventario.Excluir_Items_Inventario(SelectedRow.Cells[0].Value.ToString());
                            bllInventario.Excluir(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UM INVENTARIO", "INVENTARIO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Inventário excluído. Cod: " + SelectedRow.Cells[0].Value.ToString());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Inventário excluído. Cod: " + SelectedRow.Cells[0].Value.ToString());
                            }
                            //
                            if (bllInventario.Sel_Inventario_Todos() == null)
                            {
                                dtInv.DataSource = null;
                            }
                            else
                            {
                                dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                                dtInv.Select();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para Excluir Inventário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        dtInv.Select();
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
            }
        }

        private void bckwIndeterminado_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                _Codigo = bllInventario.Sel_Ultimo_Cod_Inventario_Adicionado();
                //
                DataRow dr = bllInventario.Sel_Inventario_Codigo(_Codigo).Rows[0];
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
                                    if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()) != null)
                                    {
                                        decimal inv_saldo_atual = 0;
                                        decimal quantidade = 0;
                                        decimal total_medio = 0;
                                        //
                                        for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                                        {
                                            DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                            //
                                            inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr3["inv_saldo_atual"]);
                                            //
                                            total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                            //
                                            quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                        }
                                        //
                                        inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr2["quantidade"]);
                                        //
                                        total_medio = total_medio + Convert.ToDecimal(dr2["valor_total"]);
                                        //
                                        quantidade = quantidade + Convert.ToDecimal(dr2["quantidade"]);
                                        //
                                        DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                        //
                                        if (dr["id_localizacao"].ToString() == "0")
                                        {
                                            bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), inv_saldo_atual.ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                        }
                                        else
                                        {
                                            if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), inv_saldo_atual.ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                        //
                                        if (dr["id_localizacao"].ToString() == "0")
                                        {
                                            bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), dr2["quantidade"].ToString(), dr2["quantidade"].ToString(), dr2["total"].ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                        }
                                        else
                                        {
                                            if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                            {
                                                bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), dr2["quantidade"].ToString(), dr2["quantidade"].ToString(), dr2["total"].ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
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
                                        if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()) != null)
                                        {
                                            decimal inv_saldo_atual = 0;
                                            decimal quantidade = 0;
                                            decimal total_medio = 0;
                                            //
                                            for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                                            {
                                                DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                                //
                                                inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr3["inv_saldo_atual"]);
                                                //
                                                total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                //
                                                quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                            }
                                            //
                                            inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr2["quantidade"]);
                                            //
                                            total_medio = total_medio + Convert.ToDecimal(dr2["valor_total"]);
                                            //
                                            quantidade = quantidade + Convert.ToDecimal(dr2["quantidade"]);
                                            //
                                            DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), inv_saldo_atual.ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), inv_saldo_atual.ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                                }
                                            }
                                        }
                                        else
                                        {
                                            DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), dr2["quantidade"].ToString(), dr2["quantidade"].ToString(), dr2["valor_total"].ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), dr2["quantidade"].ToString(), dr2["quantidade"].ToString(), dr2["valor_total"].ToString(), dr4["est_saldo_atual"].ToString(), dr2["total"].ToString(), dr2["valor_desconto"].ToString(), dr2["valor_acrescimo"].ToString(), dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), dr2["valor_icms"].ToString(), dr2["valor_icms_st"].ToString(), dr2["valor_ipi"].ToString());
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
                                decimal inv_saldo_atual = 0;
                                decimal quantidade = 0;
                                decimal total_medio = 0;
                                decimal ult_custo = 0;
                                //
                                for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                                {
                                    DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                    //
                                    inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr3["inv_saldo_atual"]);
                                    //
                                    total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                    //
                                    quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                    //
                                    ult_custo = ult_custo + Convert.ToDecimal(dr3["ult_custo"]);
                                }
                                //
                                inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr1["qtde"]);
                                //
                                quantidade = quantidade + Convert.ToDecimal(dr1["qtde"]);
                                //
                                DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                //
                                if (dr["id_localizacao"].ToString() == "0")
                                {
                                    if (Convert.ToByte(dr["inv_contabil"]) == 0)
                                    {
                                        bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), inv_saldo_atual.ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                    {
                                        if (Convert.ToByte(dr["inv_contabil"]) == 0)
                                        {
                                            bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), inv_saldo_atual.ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                        }
                                    }
                                }
                                //
                            }
                            else
                            {
                                DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                //
                                if (dr["id_localizacao"].ToString() == "0")
                                {
                                    if (Convert.ToByte(dr["inv_contabil"]) == 0)
                                    {
                                        bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), dr1["qtde"].ToString(), dr1["qtde"].ToString(), "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                    {
                                        if (Convert.ToByte(dr["inv_contabil"]) == 0)
                                        {
                                            bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), dr1["qtde"].ToString(), dr1["qtde"].ToString(), "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
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
                                            if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Codigo, dr2["um"].ToString()) == null)
                                            {
                                                if (dr["id_localizacao"].ToString() == "0")
                                                {
                                                    bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), "-" + dr2["quantidade"].ToString(), "0", "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                    {
                                                        bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), "-" + dr2["quantidade"].ToString(), "0", "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                decimal inv_saldo_atual = 0;
                                                decimal quantidade = 0;
                                                decimal total_medio = 0;
                                                decimal ult_custo = 0;
                                                //
                                                for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Codigo, dr2["um"].ToString()).Rows.Count; c++)
                                                {
                                                    DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Codigo, dr2["um"].ToString()).Rows[c];
                                                    //
                                                    inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr3["inv_saldo_atual"]);
                                                    //
                                                    total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                    //
                                                    quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                                    //
                                                    ult_custo = ult_custo + Convert.ToDecimal(dr3["ult_custo"]);
                                                }
                                                //
                                                if (dr["id_localizacao"].ToString() == "0")
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), (inv_saldo_atual - Convert.ToDecimal(dr2["quantidade"])).ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                    {
                                                        bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), (inv_saldo_atual - Convert.ToDecimal(dr2["quantidade"])).ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
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
                                            if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Codigo, dr2["um"].ToString()) == null)
                                            {
                                                if (dr["id_localizacao"].ToString() == "0")
                                                {
                                                    bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), "-" + dr2["quantidade"].ToString(), "0", "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                    {
                                                        bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), "-" + dr2["quantidade"].ToString(), "0", "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                decimal inv_saldo_atual = 0;
                                                decimal quantidade = 0;
                                                decimal total_medio = 0;
                                                decimal ult_custo = 0;
                                                //
                                                for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Codigo, dr2["um"].ToString()).Rows.Count; c++)
                                                {
                                                    DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), _Codigo, dr2["um"].ToString()).Rows[c];
                                                    //
                                                    inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr3["inv_saldo_atual"]);
                                                    //
                                                    total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                    //
                                                    quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                                    //
                                                    ult_custo = ult_custo + Convert.ToDecimal(dr3["ult_custo"]);
                                                }
                                                //
                                                if (dr["id_localizacao"].ToString() == "0")
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), (inv_saldo_atual - Convert.ToDecimal(dr2["quantidade"])).ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                    {
                                                        bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), (inv_saldo_atual - Convert.ToDecimal(dr2["quantidade"])).ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
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
                                        if (bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()) != null)
                                        {
                                            decimal inv_saldo_atual = 0;
                                            decimal quantidade = 0;
                                            decimal total_medio = 0;
                                            decimal ult_custo = 0;
                                            //
                                            for (int c = 0; c < bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows.Count; c++)
                                            {
                                                DataRow dr3 = bllInventario.Sel_Inventario_Item_Existe(dr2["id_produto"].ToString(), dr["id_inventario"].ToString(), dr2["um"].ToString()).Rows[c];
                                                //
                                                inv_saldo_atual = inv_saldo_atual + Convert.ToDecimal(dr3["inv_saldo_atual"]);
                                                //
                                                total_medio = total_medio + Convert.ToDecimal(dr3["total_medio"]);
                                                //
                                                quantidade = quantidade + Convert.ToDecimal(dr3["quantidade"]);
                                                //
                                                ult_custo = ult_custo + Convert.ToDecimal(dr3["ult_custo"]);
                                            }
                                            //
                                            DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), (inv_saldo_atual - Convert.ToDecimal(dr2["quantidade"])).ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Alterar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr4["descricao"].ToString(), (inv_saldo_atual - Convert.ToDecimal(dr2["quantidade"])).ToString(), quantidade.ToString(), total_medio.ToString(), dr4["est_saldo_atual"].ToString(), ult_custo.ToString(), "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            DataRow dr4 = bllProduto.Sel_Prod_Codigo(dr2["id_produto"].ToString(), "").Rows[0];
                                            //
                                            if (dr["id_localizacao"].ToString() == "0")
                                            {
                                                bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), "-" + dr2["quantidade"].ToString(), "0", "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
                                            }
                                            else
                                            {
                                                if (Convert.ToInt16(dr4["id_localizacao"]) == Convert.ToInt16(dr["id_localizacao"].ToString()))
                                                {
                                                    bllInventario.Salvar_Item_Novo_Inventario(dr2["id_produto"].ToString() + "—" + dr2["descricao"].ToString(), "-" + dr2["quantidade"].ToString(), "0", "0", dr4["est_saldo_atual"].ToString(), "0", "0", "0", dr2["um"].ToString(), dr4["ncm"].ToString(), dr["id_inventario"].ToString(), "0", "0", "0");
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
                bllRegistroAtividades.Salvar("CRIOU UM NOVO INVENTARIO DE PRODUTOS.", "INVENTARIO", _Codigo, _Usuario, _Cod_PDV_Computador);
            }
            else if (_Trabalho == 1)
            {
                if (bllProduto.Sel_Prod_Todos("") != null)
                {
                    for (int i = 0; i < bllProduto.Sel_Prod_Todos("").Rows.Count; i++)
                    {
                        DataRow dr = bllProduto.Sel_Prod_Todos("").Rows[i];
                        //
                        bllInventario.Alterar_Saldo_Produto_Inv(dr["id_produto"].ToString(), "0");
                    }
                }
                //
                //ENTRADAS DE DFE MANUAIS/IMPORTADAS
                //
                if (bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "TERCEIROS") != null)
                {
                    for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "TERCEIROS").Rows.Count; i++)
                    {
                        DataRow dr = bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "TERCEIROS").Rows[i];
                        //
                        if (bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()) != null)
                        {
                            for (int b = 0; b < bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows.Count; b++)
                            {
                                DataRow dr2 = bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows[b];
                                //
                                if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                {
                                    string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();
                                    //
                                    bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                }
                            }
                        }
                    }
                }
                //
                //ENTRADAS DE DFE EMITIDAS
                //
                if (bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "PRÓPRIA") != null)
                {
                    for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "PRÓPRIA").Rows.Count; i++)
                    {
                        DataRow dr = bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "PRÓPRIA").Rows[i];
                        //
                        if ((dr["situacao"].ToString() == "TRANSMITIDA" || dr["situacao"].ToString() == "PENDENTE") & (dr["finalidade"].ToString() == "ENTRADA" || dr["finalidade"].ToString() == "RETORNO"))
                        {
                            if (bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()) != null)
                            {
                                for (int b = 0; b < bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows[b];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                    {
                                        string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                        bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                    }
                                }
                            }
                        }
                    }
                }
                //
                //ENTRADAS MANUAIS
                //
                if (bllProduto.Sel_Prod_Todos("") != null)
                {
                    for (int i = 0; i < bllProduto.Sel_Prod_Todos("").Rows.Count; i++)
                    {
                        DataRow dr = bllProduto.Sel_Prod_Todos("").Rows[i];
                        //
                        if (bllEntradasProdutos.Sel_Entrada_Prod_Todos(dr["id_produto"].ToString()) != null)
                        {
                            for (int b = 0; b < bllEntradasProdutos.Sel_Entrada_Prod_Todos(dr["id_produto"].ToString()).Rows.Count; b++)
                            {
                                DataRow dr2 = bllEntradasProdutos.Sel_Entrada_Prod_Todos(dr["id_produto"].ToString()).Rows[b];
                                //
                                string data = dr2["data_entrada"].ToString().Remove(10);
                                //
                                if (Convert.ToDateTime(data) >= Convert.ToDateTime(bllInventario._Data_DatePicker1) & Convert.ToDateTime(dr2["data_entrada"]) <= Convert.ToDateTime(bllInventario._Data_DatePicker2))
                                {
                                    string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                    bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                }
                            }
                        }
                    }
                }
                //
                //SAIDAS DE DFE EMITIDAS
                //
                if (bllVenda.Sel_Venda_Data_Venda(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2) != null)
                {
                    for (int i = 0; i < bllVenda.Sel_Venda_Data_Venda(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2).Rows.Count; i++)
                    {
                        DataRow dr = bllVenda.Sel_Venda_Data_Venda(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2).Rows[i];
                        //
                        if (dr["tipo"].ToString() == "NFCe" || dr["tipo"].ToString() == "NFe")
                        {
                            if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "-", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "TRANSMITIDA", dr["id_venda"].ToString()) != null || bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "-", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "PENDENTE", dr["id_venda"].ToString()) != null)
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()) != null)
                                {
                                    for (int b = 0; b < bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows.Count; b++)
                                    {
                                        DataRow dr2 = bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows[b];
                                        //
                                        if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                        {
                                            string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) - Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                            bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //
                //SAIDAS PEDIDO
                //
                if (bllVenda.Sel_Venda_Data_Venda(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2) != null)
                {
                    for (int i = 0; i < bllVenda.Sel_Venda_Data_Venda(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2).Rows.Count; i++)
                    {
                        DataRow dr = bllVenda.Sel_Venda_Data_Venda(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2).Rows[i];
                        //
                        if (dr["tipo"].ToString() == "DAV")
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()) != null)
                            {
                                for (int b = 0; b < bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows[b];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                    {
                                        string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) - Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                        bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                    }
                                }
                            }
                        }
                    }
                }
                //
                //SAIDAS DFE EMITIDAS (SAIDA, DEVOLUCAO...)
                //
                if (bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "PRÓPRIA") != null)
                {
                    for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "PRÓPRIA").Rows.Count; i++)
                    {
                        DataRow dr = bllDFe.Sel_Dfe_Data_Cadastro(bllInventario._Data_DatePicker1, bllInventario._Data_DatePicker2, "PRÓPRIA").Rows[i];
                        //
                        if ((dr["situacao"].ToString() == "TRANSMITIDA" || dr["situacao"].ToString() == "PENDENTE") & (dr["finalidade"].ToString() == "SAIDA" || dr["finalidade"].ToString() == "DEVOLUCAO" || dr["finalidade"].ToString() == "COMPLEMENTAR") & Convert.ToInt32(dr["id_venda"]) == 0)
                        {
                            if (bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()) != null)
                            {
                                for (int b = 0; b < bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows[b];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                    {
                                        string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                        bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                    }
                                }
                            }
                        }
                    }
                }
                //
                bllRegistroAtividades.Salvar("ATUALIZOU O ESTOQUE DE " + bllInventario._Data_DatePicker1 + " ATÉ " + bllInventario._Data_DatePicker2 + ".", "INVENTARIO", "0", _Usuario, _Cod_PDV_Computador);
                //
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Trabalho == 2)
            {
                if (bllProduto.Sel_Prod_Todos("") != null)
                {
                    for (int i = 0; i < bllProduto.Sel_Prod_Todos("").Rows.Count; i++)
                    {
                        DataRow dr = bllProduto.Sel_Prod_Todos("").Rows[i];
                        //
                        bllInventario.Alterar_Saldo_Produto_Inv(dr["id_produto"].ToString(), "0");
                    }
                }
                //
                //ENTRADAS DE DFE MANUAIS/IMPORTADAS
                //
                if (bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "TERCEIROS") != null)
                {
                    for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "TERCEIROS").Rows.Count; i++)
                    {
                        DataRow dr = bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "TERCEIROS").Rows[i];
                        //
                        if (bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()) != null)
                        {
                            for (int b = 0; b < bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows.Count; b++)
                            {
                                DataRow dr2 = bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows[b];
                                //
                                if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                {
                                    string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();
                                    //
                                    bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                }
                            }
                        }
                    }
                }
                //
                //ENTRADAS DE DFE EMITIDAS
                //
                if (bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "PRÓPRIA") != null)
                {
                    for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "PRÓPRIA").Rows.Count; i++)
                    {
                        DataRow dr = bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "PRÓPRIA").Rows[i];
                        //
                        if ((dr["situacao"].ToString() == "TRANSMITIDA" || dr["situacao"].ToString() == "PENDENTE") & (dr["finalidade"].ToString() == "ENTRADA" || dr["finalidade"].ToString() == "RETORNO"))
                        {
                            if (bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()) != null)
                            {
                                for (int b = 0; b < bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows[b];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                    {
                                        string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                        bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                    }
                                }
                            }
                        }
                    }
                }
                //
                //ENTRADAS MANUAIS
                //
                if (bllProduto.Sel_Prod_Todos("") != null)
                {
                    for (int i = 0; i < bllProduto.Sel_Prod_Todos("").Rows.Count; i++)
                    {
                        DataRow dr = bllProduto.Sel_Prod_Todos("").Rows[i];
                        //
                        if (bllEntradasProdutos.Sel_Entrada_Prod_Todos(dr["id_produto"].ToString()) != null)
                        {
                            for (int b = 0; b < bllEntradasProdutos.Sel_Entrada_Prod_Todos(dr["id_produto"].ToString()).Rows.Count; b++)
                            {
                                DataRow dr2 = bllEntradasProdutos.Sel_Entrada_Prod_Todos(dr["id_produto"].ToString()).Rows[b];
                                //
                                string data = dr2["data_entrada"].ToString().Remove(10);
                                //
                                if (Convert.ToDateTime(data) >= Convert.ToDateTime("01/07/2024") & Convert.ToDateTime(dr2["data_entrada"]) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                                {
                                    string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                    bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                }
                            }
                        }
                    }
                }
                //
                //SAIDAS DE DFE EMITIDAS
                //
                if (bllVenda.Sel_Venda_Data_Venda("01/07/2024", DateTime.Now.ToShortDateString()) != null)
                {
                    for (int i = 0; i < bllVenda.Sel_Venda_Data_Venda("01/07/2024", DateTime.Now.ToShortDateString()).Rows.Count; i++)
                    {
                        DataRow dr = bllVenda.Sel_Venda_Data_Venda("01/07/2024", DateTime.Now.ToShortDateString()).Rows[i];
                        //
                        if (dr["tipo"].ToString() == "NFCe" || dr["tipo"].ToString() == "NFe")
                        {
                            if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "-", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "TRANSMITIDA", dr["id_venda"].ToString()) != null || bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "-", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "PENDENTE", dr["id_venda"].ToString()) != null)
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()) != null)
                                {
                                    for (int b = 0; b < bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows.Count; b++)
                                    {
                                        DataRow dr2 = bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows[b];
                                        //
                                        if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                        {
                                            string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) - Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                            bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //
                //SAIDAS PEDIDO
                //
                if (bllVenda.Sel_Venda_Data_Venda("01/07/2024", DateTime.Now.ToShortDateString()) != null)
                {
                    for (int i = 0; i < bllVenda.Sel_Venda_Data_Venda("01/07/2024", DateTime.Now.ToShortDateString()).Rows.Count; i++)
                    {
                        DataRow dr = bllVenda.Sel_Venda_Data_Venda("01/07/2024", DateTime.Now.ToShortDateString()).Rows[i];
                        //
                        if (dr["tipo"].ToString() == "DAV")
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()) != null)
                            {
                                for (int b = 0; b < bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllVenda.Sel_Itens_Venda_Venda(dr["id_venda"].ToString()).Rows[b];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                    {
                                        string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) - Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                        bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                    }
                                }
                            }
                        }
                    }
                }
                //
                //SAIDAS DFE EMITIDAS (SAIDA, DEVOLUCAO...)
                //
                if (bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "PRÓPRIA") != null)
                {
                    for (int i = 0; i < bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "PRÓPRIA").Rows.Count; i++)
                    {
                        DataRow dr = bllDFe.Sel_Dfe_Data_Cadastro("01/07/2024", DateTime.Now.ToShortDateString(), "PRÓPRIA").Rows[i];
                        //
                        if ((dr["situacao"].ToString() == "TRANSMITIDA" || dr["situacao"].ToString() == "PENDENTE") & (dr["finalidade"].ToString() == "SAIDA" || dr["finalidade"].ToString() == "DEVOLUCAO" || dr["finalidade"].ToString() == "COMPLEMENTAR") & Convert.ToInt32(dr["id_venda"]) == 0)
                        {
                            if (bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()) != null)
                            {
                                for (int b = 0; b < bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows.Count; b++)
                                {
                                    DataRow dr2 = bllDFe.Sel_Items_DFe(dr["id_dfe"].ToString()).Rows[b];
                                    //
                                    if (bllProduto.Sel_Produto_Ainda_Existe(dr2["id_produto"].ToString()))
                                    {
                                        string saldo = (Convert.ToDecimal(bllProduto.Sel_Saldo_Atual_Produto(dr2["id_produto"].ToString())) + Convert.ToDecimal(dr2["quantidade"].ToString())).ToString();

                                        bllInventario.Alterar_Saldo_Produto_Inv(dr2["id_produto"].ToString(), saldo);
                                    }
                                }
                            }
                        }
                    }
                }
                //
                bllRegistroAtividades.Salvar("ATUALIZOU TODO O ESTOQUE.", "INVENTARIO", "0", _Usuario, _Cod_PDV_Computador);
                //
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Trabalho == 4)
            {
                DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                //
                if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                {
                    for (int b = 0; b < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; b++)
                    {
                        DataRow dr = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[b];
                        //
                        string cod_produto = dr["id_produto"].ToString();
                        //
                        if (bllInventario._Grupo != null & bllInventario._SubGrupo == null)
                        {
                            DataRow dr1 = bllProduto.Sel_Prod_Codigo(cod_produto, "").Rows[0];
                            //
                            if (dr1["id_grupo"].ToString() == bllInventario._Grupo)
                            {
                                if (bllInventario._Tipo == true)
                                {
                                    decimal multiplicador = Convert.ToDecimal(bllInventario._Multiplicador);
                                    //
                                    decimal quantidade = Convert.ToDecimal(dr["inv_saldo_atual"]) + multiplicador;
                                    //
                                    decimal valor_unitario = Convert.ToDecimal(dr["inv_custo_medio_atual"]);
                                    //                                
                                    decimal resultado = quantidade * valor_unitario;
                                    //
                                    bllInventario.Alterar_Saldo_Atual_Ajuste_Inv(SelectedRow.Cells[0].Value.ToString(), cod_produto, quantidade.ToString(), Math.Round(resultado, 2).ToString());
                                }
                                else
                                {
                                    decimal multiplicador = Convert.ToDecimal(bllInventario._Multiplicador);
                                    //
                                    decimal quantidade = Convert.ToDecimal(dr["inv_saldo_atual"]);
                                    //
                                    decimal valor_unitario = Convert.ToDecimal(dr["inv_custo_medio_atual"]) + multiplicador;
                                    //                                
                                    decimal resultado = quantidade * valor_unitario;
                                    //
                                    bllInventario.Alterar_Custo_Medio_Atual_Ajuste_Inv(SelectedRow.Cells[0].Value.ToString(), cod_produto, valor_unitario.ToString(), Math.Round(resultado, 2).ToString());

                                }
                            }
                        }
                        else if (bllInventario._Grupo != null & bllInventario._SubGrupo != null)
                        {
                            DataRow dr1 = bllProduto.Sel_Prod_Codigo(cod_produto, "").Rows[0];
                            //
                            if (dr1["id_grupo"].ToString() == bllInventario._Grupo)
                            {
                                if (dr1["id_subgrupo"].ToString() == bllInventario._SubGrupo)
                                {
                                    if (bllInventario._Tipo == true)
                                    {
                                        decimal multiplicador = Convert.ToDecimal(bllInventario._Multiplicador);
                                        //
                                        decimal quantidade = Convert.ToDecimal(dr["inv_saldo_atual"]) + multiplicador;
                                        //
                                        decimal valor_unitario = Convert.ToDecimal(dr["inv_custo_medio_atual"]);
                                        //
                                        decimal resultado = quantidade * valor_unitario;
                                        //
                                        bllInventario.Alterar_Saldo_Atual_Ajuste_Inv(SelectedRow.Cells[0].Value.ToString(), cod_produto, quantidade.ToString(), Math.Round(resultado, 2).ToString());
                                    }
                                }
                                else
                                {
                                    decimal multiplicador = Convert.ToDecimal(bllInventario._Multiplicador);
                                    //
                                    decimal quantidade = Convert.ToDecimal(dr["inv_saldo_atual"]);
                                    //
                                    decimal valor_unitario = Convert.ToDecimal(dr["inv_custo_medio_atual"]) + multiplicador;
                                    //                                
                                    decimal resultado = quantidade * valor_unitario;
                                    //
                                    bllInventario.Alterar_Custo_Medio_Atual_Ajuste_Inv(SelectedRow.Cells[0].Value.ToString(), cod_produto, valor_unitario.ToString(), Math.Round(resultado, 2).ToString());
                                }
                            }
                        }
                        else
                        {
                            if (bllInventario._Tipo == true)
                            {
                                decimal multiplicador = Convert.ToDecimal(bllInventario._Multiplicador);
                                //
                                decimal quantidade = Convert.ToDecimal(dr["inv_saldo_atual"]) + multiplicador;
                                //
                                decimal valor_unitario = Convert.ToDecimal(dr["inv_custo_medio_atual"]);
                                //
                                decimal resultado = quantidade * valor_unitario;
                                //
                                bllInventario.Alterar_Saldo_Atual_Ajuste_Inv(SelectedRow.Cells[0].Value.ToString(), cod_produto, quantidade.ToString(), Math.Round(resultado, 2).ToString());
                            }
                            else
                            {
                                decimal multiplicador = Convert.ToDecimal(bllInventario._Multiplicador);
                                //
                                decimal quantidade = Convert.ToDecimal(dr["inv_saldo_atual"]);
                                //
                                decimal valor_unitario = Convert.ToDecimal(dr["inv_custo_medio_atual"]) + multiplicador;
                                //                                
                                decimal resultado = quantidade * valor_unitario;
                                //
                                bllInventario.Alterar_Custo_Medio_Atual_Ajuste_Inv(SelectedRow.Cells[0].Value.ToString(), cod_produto, valor_unitario.ToString(), Math.Round(resultado, 2).ToString());

                            }
                        }
                    }
                }
                //
                bllRegistroAtividades.Salvar("AJUSTOU O INVENTARIO.", "INVENTARIO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                //
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Trabalho == 5)
            {
                if (bllProduto.Sel_Prod_Todos("") != null)
                {
                    bllInventario.Zerar_Estoque_Produto_Inv();
                }
                //
                bllRegistroAtividades.Salvar("ZEROU O ESTOQUE ATUAL.", "INVENTARIO", "0", _Usuario, _Cod_PDV_Computador);
                //
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Trabalho == 6)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 8);
                    var fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    var fonte6 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    XPen pen2 = new XPen(XColors.White);
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ABERTURA", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    int TotalPaginas = 1;
                    int registros = 96;
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            if (i == 48)
                            {
                                TotalPaginas = TotalPaginas + 1;
                            }
                            else if (i == registros)
                            {
                                registros = registros + 48;
                                TotalPaginas = TotalPaginas + 1;
                            }
                        }
                    }
                    else
                    {
                        registros = 0;
                        TotalPaginas = 1;
                    }
                    //
                    textFormatter1.DrawString("CONTÉM ESTE LIVRO " + TotalPaginas + " FOLHA(S) NÚMERADA(S) ELETRÔNICAMENTE DO Nº 1 AO Nº " + TotalPaginas + " E SERVIRÁ PARA O LANÇAMENTO DAS OPERAÇÕES PRÓPRIAS DO ESTABELECIMENTO ABAIXO IDENTIFICADO NO PERÍODO DE " + SelectedRow.Cells[2].Value.ToString().Remove(10) + " A " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    int Incrementar = 0;
                    int ContadorPagina = 1;
                    int pagina = 48;
                    bool PrimeiraPagina = true;
                    //
                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Inventário Nº:" + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString("Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, 580, page.Height));
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //
                    decimal valor = 0;
                    //
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int linha = 0; linha < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; linha++)
                        {
                            DataRow dr1 = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[linha];
                            //
                            valor += Convert.ToDecimal(dr1["inv_total_atual"]);
                            //
                            if (linha < 48 & PrimeiraPagina == true)
                            {
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                //
                                if (linha == (pagina - 1) & bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count > 48)
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 49;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                            }
                            else
                            {
                                if (linha == (pagina - 1))
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 48;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Relatório de Contagem de Inventário", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    //
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["valor_unitario"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["valor_unitario"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString(Convert.ToDecimal(dr1["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                            }
                        }
                    }
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    fonte6 = new XFont("Microsoft Sans Serif", 9);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ENCERRAMENTO", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NESTA DATA PROCEDEMOS AO ENCERRAMENTO DO PRESENTE LIVRO DE NÚMERO " + SelectedRow.Cells[0].Value.ToString() + " COM " + TotalPaginas + " FOLHA(S) NÚMERADAS ELETRÔNICAMENTE, RELATIVA A SITUAÇÃO DE " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                }
            }
            else if (_Trabalho == 7)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 8);
                    var fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    var fonte6 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    XPen pen2 = new XPen(XColors.White);
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ABERTURA", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    int TotalPaginas = 1;
                    int registros = 96;
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            DataRow dr1 = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                            if (Convert.ToDecimal(dr1["inv_saldo_atual"]) > 0)
                            {
                                if (i == 48)
                                {
                                    TotalPaginas = TotalPaginas + 1;
                                }
                                else if (i == registros)
                                {
                                    registros = registros + 48;
                                    TotalPaginas = TotalPaginas + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        registros = 0;
                        TotalPaginas = 1;
                    }
                    //
                    textFormatter1.DrawString("CONTÉM ESTE LIVRO " + TotalPaginas + " FOLHA(S) NÚMERADA(S) ELETRÔNICAMENTE DO Nº 1 AO Nº " + TotalPaginas + " E SERVIRÁ PARA O LANÇAMENTO DAS OPERAÇÕES PRÓPRIAS DO ESTABELECIMENTO ABAIXO IDENTIFICADO NO PERÍODO DE " + SelectedRow.Cells[2].Value.ToString().Remove(10) + " A " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    int Incrementar = 0;
                    int ContadorPagina = 1;
                    int pagina = 48;
                    bool PrimeiraPagina = true;
                    //
                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Inventário Nº:" + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString("Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, 580, page.Height));
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //
                    decimal valor = 0;
                    //
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int linha = 0; linha < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; linha++)
                        {
                            DataRow dr1 = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[linha];
                            //
                            if (Convert.ToDecimal(dr1["inv_total_atual"]) > 0)
                            {
                                valor += Convert.ToDecimal(dr1["inv_total_atual"]);
                            }
                            else
                            {
                                continue;
                            }
                            //
                            if (linha < 48 & PrimeiraPagina == true)
                            {
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) > 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) > 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                //
                                if (linha == (pagina - 1) & bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count > 48)
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 49;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                            }
                            else
                            {
                                if (linha == (pagina - 1))
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 48;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Relatório de Contagem de Inventário", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    //
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) > 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) > 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                            }
                        }
                    }
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    fonte6 = new XFont("Microsoft Sans Serif", 9);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ENCERRAMENTO", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NESTA DATA PROCEDEMOS AO ENCERRAMENTO DO PRESENTE LIVRO DE NÚMERO " + SelectedRow.Cells[0].Value.ToString() + " COM " + TotalPaginas + " FOLHA(S) NÚMERADAS ELETRÔNICAMENTE, RELATIVA A SITUAÇÃO DE " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                }
            }
            else if (_Trabalho == 8)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 8);
                    var fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    var fonte6 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    XPen pen2 = new XPen(XColors.White);
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ABERTURA", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    int TotalPaginas = 1;
                    int registros = 96;
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            DataRow dr1 = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                            if (Convert.ToDecimal(dr1["inv_total_atual"]) == 0)
                            {
                                if (i == 48)
                                {
                                    TotalPaginas = TotalPaginas + 1;
                                }
                                else if (i == registros)
                                {
                                    registros = registros + 48;
                                    TotalPaginas = TotalPaginas + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        registros = 0;
                        TotalPaginas = 1;
                    }
                    //
                    textFormatter1.DrawString("CONTÉM ESTE LIVRO " + TotalPaginas + " FOLHA(S) NÚMERADA(S) ELETRÔNICAMENTE DO Nº 1 AO Nº " + TotalPaginas + " E SERVIRÁ PARA O LANÇAMENTO DAS OPERAÇÕES PRÓPRIAS DO ESTABELECIMENTO ABAIXO IDENTIFICADO NO PERÍODO DE " + SelectedRow.Cells[2].Value.ToString().Remove(10) + " A " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    int Incrementar = 0;
                    int ContadorPagina = 1;
                    int pagina = 48;
                    bool PrimeiraPagina = true;
                    //
                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Inventário Nº:" + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString("Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, 580, page.Height));
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int linha = 0; linha < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; linha++)
                        {
                            DataRow dr1 = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[linha];
                            //
                            if (Convert.ToDecimal(dr1["inv_total_atual"]) != 0)
                            {
                                continue;
                            }
                            //
                            if (linha < 48 & PrimeiraPagina == true)
                            {
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) == 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) == 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Total do Saldo: 0,00    Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                //
                                if (linha == (pagina - 1) & bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count > 48)
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 49;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                            }
                            else
                            {
                                if (linha == (pagina - 1))
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 48;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Relatório de Contagem de Inventário", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    //
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) == 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Total do Saldo: 0,00    Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) == 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Total do Saldo: 0,00    Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                            }
                        }
                    }
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    fonte6 = new XFont("Microsoft Sans Serif", 9);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ENCERRAMENTO", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NESTA DATA PROCEDEMOS AO ENCERRAMENTO DO PRESENTE LIVRO DE NÚMERO " + SelectedRow.Cells[0].Value.ToString() + " COM " + TotalPaginas + " FOLHA(S) NÚMERADAS ELETRÔNICAMENTE, RELATIVA A SITUAÇÃO DE " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                }
            }
            else if (_Trabalho == 9)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 8);
                    var fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    var fonte6 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    XPen pen2 = new XPen(XColors.White);
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ABERTURA", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    int TotalPaginas = 1;
                    int registros = 96;
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int i = 0; i < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {

                            DataRow dr1 = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                            if (Convert.ToDecimal(dr1["inv_total_atual"]) < 0)
                            {
                                if (i == 48)
                                {
                                    TotalPaginas = TotalPaginas + 1;
                                }
                                else if (i == registros)
                                {
                                    registros = registros + 48;
                                    TotalPaginas = TotalPaginas + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        registros = 0;
                        TotalPaginas = 1;
                    }
                    //
                    textFormatter1.DrawString("CONTÉM ESTE LIVRO " + TotalPaginas + " FOLHA(S) NÚMERADA(S) ELETRÔNICAMENTE DO Nº 1 AO Nº " + TotalPaginas + " E SERVIRÁ PARA O LANÇAMENTO DAS OPERAÇÕES PRÓPRIAS DO ESTABELECIMENTO ABAIXO IDENTIFICADO NO PERÍODO DE " + SelectedRow.Cells[2].Value.ToString().Remove(10) + " A " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    int Incrementar = 0;
                    int ContadorPagina = 1;
                    int pagina = 48;
                    bool PrimeiraPagina = true;
                    //
                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Inventário Nº:" + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString("Valor Total: 0,00", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, 580, page.Height));
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //
                    decimal valor = 0;
                    //
                    if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                    {
                        for (int linha = 0; linha < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; linha++)
                        {
                            DataRow dr1 = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[linha];
                            //
                            if (Convert.ToDecimal(dr1["inv_total_atual"]) < 0)
                            {
                                valor += Convert.ToDecimal(dr1["inv_total_atual"]);
                            }
                            else
                            {
                                continue;
                            }
                            //
                            if (linha < 48 & PrimeiraPagina == true)
                            {
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) < 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) < 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                //
                                if (linha == (pagina - 1) & bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count > 48)
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 49;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Inventário de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                            }
                            else
                            {
                                if (linha == (pagina - 1))
                                {
                                    PrimeiraPagina = false;
                                    Incrementar = 0;
                                    ContadorPagina = ContadorPagina + 1;
                                    pagina = pagina + 48;
                                    page = doc.AddPage();
                                    page.Width = 595;
                                    page.Height = 842;
                                    graphics = XGraphics.FromPdfPage(page);
                                    textFormatter1 = new XTextFormatter(graphics);
                                    textFormatter2 = new XTextFormatter(graphics);
                                    textFormatter3 = new XTextFormatter(graphics);
                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                                    pen1 = new XPen(XColors.LightBlue);
                                    pen = new XPen(XColors.Black);
                                    pen2 = new XPen(XColors.White);
                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                    //
                                    textFormatter1.DrawString("Relatório de Contagem de Inventário", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString(dr["nome"].ToString() + " - " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 20 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Inventário Nº: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 29 + Margem_Topo, page.Width, page.Height));
                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 40 + Margem_Topo, 584, 26);
                                    //
                                    textFormatter2.DrawString("PRODUTO        UM        NCM/SH", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 46 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter2.DrawString("Saldo", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Custo", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString("Total", fonte2, XBrushes.Black, new XRect(545 + Margem_Esq, 50 + Margem_Topo, page.Width, page.Height));
                                    //
                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                if (linha == bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count - 1)
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) < 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                                else
                                {

                                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 66) + Margem_Topo, 584, 15);
                                    //                               
                                    textFormatter2.DrawString(dr1["id_produto"].ToString() + "-" + dr1["descricao"].ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    graphics.DrawRectangle(pen2, XBrushes.White, 225 + Margem_Esq, (Incrementar + 68) + Margem_Topo, 362, 12);
                                    textFormatter2.DrawString(dr1["um"].ToString() + "    " + dr1["ncm"].ToString(), fonte4, XBrushes.Black, new XRect(360 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    //
                                    if (Convert.ToDecimal(dr1["inv_total_atual"]) < 0)
                                    {
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_saldo_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_custo_medio_atual"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                        //
                                        textFormatter2.DrawString(Convert.ToDecimal(dr1["inv_total_atual"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(545 + Margem_Esq, (Incrementar + 69) + Margem_Topo, page.Width, page.Height));
                                    }
                                    //
                                    textFormatter3.DrawString("Valor Total: " + Convert.ToDecimal(valor).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 84) + Margem_Topo, 580, page.Height));
                                    //
                                    Incrementar = 15 + Incrementar;
                                }
                            }
                        }
                    }
                    //
                    page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    graphics = XGraphics.FromPdfPage(page);
                    textFormatter1 = new XTextFormatter(graphics);
                    textFormatter2 = new XTextFormatter(graphics);
                    textFormatter3 = new XTextFormatter(graphics);
                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    fonte4 = new XFont("Microsoft Sans Serif", 8);
                    fonte5 = new XFont("Microsoft Sans Serif", 24, XFontStyle.Bold);
                    fonte6 = new XFont("Microsoft Sans Serif", 9);
                    pen1 = new XPen(XColors.LightBlue);
                    pen = new XPen(XColors.Black);
                    pen2 = new XPen(XColors.White);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    textFormatter2 = new XTextFormatter(graphics);
                    //
                    textFormatter1.DrawString("REGISTRO DE INVENTÁRIO", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("MODELO P7", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 65 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Número de Ordem: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("TERMO DE ENCERRAMENTO", fonte5, XBrushes.Black, new XRect(2 + Margem_Esq, 250 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NESTA DATA PROCEDEMOS AO ENCERRAMENTO DO PRESENTE LIVRO DE NÚMERO " + SelectedRow.Cells[0].Value.ToString() + " COM " + TotalPaginas + " FOLHA(S) NÚMERADAS ELETRÔNICAMENTE, RELATIVA A SITUAÇÃO DE " + SelectedRow.Cells[3].Value.ToString().Remove(10) + ".", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 280 + Margem_Topo, 580, page.Height));
                    //
                    textFormatter2.DrawString("NOME:             " + dr["nome"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 350 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("ENDEREÇO:   " + dr["endereco"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["complemento"].ToString() + ", " + dr["numero"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("MUNICÍPIO:    " + dr["cidade"].ToString() + "-" + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("CPF/CNPJ:      " + dr["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(24 + Margem_Esq, 386 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter3.DrawString(dr["cidade"].ToString().ToUpper() + ", " + DateTime.Now.ToLongDateString(), fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 495 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contribuinte ou Representante Legal)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 535 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("NOME:             _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 560 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("ENDEREÇO:   _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 572 + Margem_Topo, 540, page.Height));
                    textFormatter1.DrawString("MUNICÍPIO:    _______________________________________________________________", fonte6, XBrushes.Black, new XRect(12 + Margem_Esq, 584 + Margem_Topo, 540, page.Height));
                    //
                    textFormatter1.DrawString("_______________________________________________________________" + Environment.NewLine + "(Assinatura do Contador)", fonte6, XBrushes.Black, new XRect(2 + Margem_Esq, 735 + Margem_Topo, page.Width, page.Height));
                    //
                    if (dr["nome_contador"].ToString() == "" || dr["nome_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("NOME:           _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("NOME:        " + dr["nome_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 760 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    if (dr["cpf_cnpj_contador"].ToString() == "" || dr["cpf_cnpj_contador"].ToString() == null)
                    {
                        textFormatter2.DrawString("CPF:            _______________________________________________________________", fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    else
                    {
                        textFormatter2.DrawString("CPF:            " + dr["cpf_cnpj_contador"].ToString(), fonte6, XBrushes.Black, new XRect(24 + Margem_Esq, 772 + Margem_Topo, page.Width, page.Height));
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                }
            }
            else if (_Trabalho == 10)
            {
                DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                //
                if (bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()) != null)
                {
                    for (int b = 0; b < bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows.Count; b++)
                    {
                        DataRow dr = bllInventario.Sel_Prod_Inv_Todos(SelectedRow.Cells[0].Value.ToString()).Rows[b];
                        //
                        bllInventario.Sincronizar_Estoque_Produto_Inv(dr["id_produto"].ToString(), dr["inv_saldo_atual"].ToString());
                    }
                }
                //
                bllRegistroAtividades.Salvar("SINCRONIZOU O ESTOQUE ATUAL.", "INVENTARIO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                //
                pgbProgresso.Value = 0;
                this.Cursor = Cursors.Default;
                dtInv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                lblItem.Enabled = true;
                dtInv.Enabled = true;
                lblRegistros.Enabled = true;
                btnRelatorioTodos.Enabled = true;
                btnRelatorioPositivo.Enabled = true;
                btnRelatorioZerado.Enabled = true;
                btnRelatorioNegativo.Enabled = true;
                grbBox2.Enabled = true;
                _Codigo = null;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                dtInv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                lblItem.Enabled = true;
                dtInv.Enabled = true;
                lblRegistros.Enabled = true;
                btnRelatorioTodos.Enabled = true;
                btnRelatorioPositivo.Enabled = true;
                btnRelatorioZerado.Enabled = true;
                btnRelatorioNegativo.Enabled = true;
                grbBox2.Enabled = true;
                dtInv.Select();
                //
                try
                {
                    if (_Trabalho == 0)
                    {
                        dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                        _Codigo = null;
                        //
                        dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                        //
                        dtInv.CurrentCell = dtInv.Rows[dtInv.Rows.Count - 1].Cells[0];
                        //
                        dtInv.Rows[dtInv.Rows.Count - 1].Selected = true;
                        //
                        dtInv.FirstDisplayedScrollingRowIndex = dtInv.Rows.Count - 1;
                        //
                        pEnabled.Enabled = true;
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_Trabalho == 1 || _Trabalho == 2)
                    {
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_Trabalho == 3)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.pdf");
                    }
                    else if (_Trabalho == 4)
                    {
                        bllInventario._Tipo = false;
                        bllInventario._Grupo = null;
                        bllInventario._SubGrupo = null;
                    }
                    else if (_Trabalho == 6 || _Trabalho == 7 || _Trabalho == 8 || _Trabalho == 9)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Inventario\Inventario.pdf");
                    }
                    else if (_Trabalho == 10)
                    {
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    //
                    pgbProgresso.Value = 0;
                    this.Cursor = Cursors.Default;
                    dtInv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    lblItem.Enabled = true;
                    dtInv.Enabled = true;
                    lblRegistros.Enabled = true;
                    btnRelatorioTodos.Enabled = true;
                    btnRelatorioPositivo.Enabled = true;
                    btnRelatorioZerado.Enabled = true;
                    btnRelatorioNegativo.Enabled = true;
                    grbBox2.Enabled = true;
                    _Codigo = null;
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                pEnabled.Enabled = false;
                //
                int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                //
                using (FrmRelProdInv Inv = new FrmRelProdInv(_Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString()))
                {
                    if (Inv.ShowDialog() == DialogResult.Abort)
                    {
                        dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                    }
                }
                //
                foreach (DataGridViewRow row in dtInv.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                    {
                        row.Selected = true;
                        dtInv.CurrentCell = row.Cells[0];
                        break;
                    }
                }
                pEnabled.Enabled = true;
                //
                btnItens.Select();
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnItens.");
                }
            }
        }

        private void btnAtualizarEstoque_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja recontar todo o estoque e atualizar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (bllUsuario.Sel_Atualizar_Zerar_Estoque(_Usuario) == true)
                {
                    DialogResult = MessageBox.Show("Deseja recontar e atualizar através de uma data específica?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        pEnabled.Enabled = false;
                        using (FrmDataAtualizarEst Est = new FrmDataAtualizarEst())
                        {
                            if (Est.ShowDialog() == DialogResult.OK)
                            {
                                pgbProgresso.Visible = true;
                                lblProgresso.Visible = true;
                                _Trabalho = 1;
                                bckwIndeterminado.RunWorkerAsync();
                                pgbProgresso.MarqueeAnimationSpeed = 2;
                                this.Cursor = Cursors.WaitCursor;
                                dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;

                            }
                        }
                        pEnabled.Enabled = true;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        DialogResult = MessageBox.Show("O Estoque será recontado e atualizado desde o início.\n\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            pgbProgresso.Visible = true;
                            lblProgresso.Visible = true;
                            _Trabalho = 2;
                            bckwIndeterminado.RunWorkerAsync();
                            pgbProgresso.MarqueeAnimationSpeed = 2;
                            this.Cursor = Cursors.WaitCursor;
                            dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;

                        }
                    }
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para Atualizar Estoque.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnAtualizarEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAtualizarEstoque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dtInv.Select();
                //
                DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                //
                pEnabled.Enabled = false;
                //
                int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                //
                using (FrmInvAjustarInventario Inv = new FrmInvAjustarInventario(_Usuario, _Cod_PDV_Computador))
                {
                    if (Inv.ShowDialog() == DialogResult.OK)
                    {
                        pgbProgresso.Visible = true;
                        lblProgresso.Visible = true;
                        _Trabalho = 4;
                        bckwIndeterminado.RunWorkerAsync();
                        pgbProgresso.MarqueeAnimationSpeed = 2;
                        this.Cursor = Cursors.WaitCursor;
                        dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    }
                }
                //
                pEnabled.Enabled = true;
                //
                dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                //
                foreach (DataGridViewRow row in dtInv.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                    {
                        row.Selected = true;
                        dtInv.CurrentCell = row.Cells[0];
                        break;
                    }
                }
                //
                btnAjustarInventario.Select();
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAjustarInventario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAjustarInventario.");
                }
            }
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioPositivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioPositivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioZerado_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioZerado_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioNegativo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioNegativo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja zerar todo o estoque?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (bllUsuario.Sel_Atualizar_Zerar_Estoque(_Usuario) == true)
                    {
                        pgbProgresso.Visible = true;
                        lblProgresso.Visible = true;
                        _Trabalho = 5;
                        bckwIndeterminado.RunWorkerAsync();
                        pgbProgresso.MarqueeAnimationSpeed = 2;
                        this.Cursor = Cursors.WaitCursor;
                        dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Zerar Estoque.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnZerarEstoque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnZerarEstoque.");
                }
            }
        }

        private void btnZerarEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnZerarEstoque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioTodos_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(24))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 6;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnRelatorioPositivo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(24))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 7;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnRelatorioZerado_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(24))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 8;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnRelatorioNegativo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(24))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 9;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSincronizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;

        }

        private void btnSincronizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja sincronizar o estoque atual com o estoque informado no inventário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 10;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtInv.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSincronizar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSincronizar.");
                }
            }
        }

        private void btnFinalizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFinalizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {

                //
                DialogResult = MessageBox.Show("Deseja finalizar o Inventário selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    DataGridViewRow SelectedRow = dtInv.Rows[dtInv.CurrentRow.Index];
                    //
                    int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                    //
                    if (bllInventario.Sel_Situacao_Inventario(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        MessageBox.Show("O Inventário já foi finalizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //
                        dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                    }
                    else
                    {
                        bllInventario.Alterar(SelectedRow.Cells[0].Value.ToString());
                        //
                        MessageBox.Show("O Inventário foi finalizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        dtInv.DataSource = bllInventario.Sel_Inventario_Todos();
                    }
                    //
                    foreach (DataGridViewRow row in dtInv.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtInv.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    dtInv.Select();
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnZerarEstoque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnZerarEstoque.");
                }
            }
        }
    }
}
