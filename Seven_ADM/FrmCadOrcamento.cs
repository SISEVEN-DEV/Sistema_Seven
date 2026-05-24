using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using Seven_ADM;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadOrcamento : Form
    {
        public FrmCadOrcamento(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Cod_Orcamento, _Valor_Desconto_Item, _Valor_Acrescimo_Item, _Valor_Desconto, _Valor_Acrescimo, _CPF_CNPJ_Consumidor, _Data, _Hora, _Data_Validade, _Hora_Validade;

        private void FrmOrcamento_Load(object sender, EventArgs e)
        {
            try
            {
                bllOrcamento._FrmOrcamento_Ativo = true;
                //
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOrcamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOrcamento iniciado.");
                }
                //
                if (bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao) != null)
                {
                    rbtnProdutos.Checked = true;
                    cbbCliente.Items.Clear();
                    if (bllOrcamento.Sel_Cliente_Orc() == null)
                    {
                        cbbCliente.Enabled = false;
                        cbbCliente.Text = null;
                    }
                    else
                    {
                        cbbCliente.Enabled = true;
                        cbbCliente.Items.Add("");
                        foreach (DataRow dr in bllOrcamento.Sel_Cliente_Orc().Rows)
                        {
                            string cpfcnpj;
                            if (dr["cpf_cnpj"].ToString() == "")
                            {
                                cpfcnpj = "";
                            }
                            else
                            {
                                cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                            }
                            cbbCliente.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                        }
                    }
                    //                   
                    if (bllOrcamento.Sel_Cab_Orcamento_Todos(bllConexao._Codigo_Conexao) != null)
                    {
                        DataRow drorc = bllOrcamento.Sel_Cab_Orcamento_Todos(bllConexao._Codigo_Conexao).Rows[0];
                        //
                        if (drorc["cpf_cnpj_consumidor_orc"].ToString() != "")
                        {
                            cbbCliente.Text = drorc["id_consumidor_orc"].ToString() + "—" + drorc["nome_consumidor_orc"].ToString() + "—" + drorc["cpf_cnpj_consumidor_orc"].ToString();
                        }
                        else
                        {
                            cbbCliente.Text = drorc["id_consumidor_orc"].ToString() + "—" + drorc["nome_consumidor_orc"].ToString();
                        }
                        //
                        mtxtValidade.Text = drorc["data_validade"].ToString();
                        //
                        mtxtHorario.Text = drorc["hora_validade"].ToString();
                        //
                        rtxtObs.Text = drorc["observacao_orc"].ToString();
                    }
                    //
                    lblCodigo.Enabled = true;
                    mtxtHorario.Enabled = true;
                    lblCliente.Enabled = true;
                    cbbCliente.Enabled = true;
                    btnPesquisarCliente.Enabled = true;
                    lblValidade.Enabled = true;
                    mtxtValidade.Enabled = true;
                    btnSelecionarData1.Enabled = true;
                    lblObservacao.Enabled = true;
                    rtxtObs.Enabled = true;
                    lblQtdeCar.Enabled = true;
                    lblQtdeCar.Enabled = true;
                    rbtnServicos.Enabled = true;
                    grbBox3.Enabled = true;
                    mtxtHorario.Enabled = true;
                    txtpCodigo.Select();
                    btnNovo.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnCapturar.Enabled = true;
                    btnCancelar.Visible = true;
                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                    //
                    for (int i = 0; i < dtProd.Rows.Count; i++)
                    {
                        if (bllOrcamento.Sel_Cod_Produto_Existe_Orc(dtProd.Rows[i].Cells[1].Value.ToString()) == false)
                        {
                            MessageBox.Show("O Item: [ " + Convert.ToInt16(dtProd.Rows[i].Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")) + " - " + dtProd.Rows[i].Cells[1].Value.ToString() + " - " + dtProd.Rows[i].Cells[2].Value.ToString() + " ] foi excluído ou não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;

                            bllOrcamento.Excluir_Item(dtProd.Rows[i].Cells[0].Value.ToString());

                            bllOrcamento.Atualizar_Item_Dt_Prod(Convert.ToInt32(dtProd.Rows[i].Cells[0].Value), dtProd.Rows.Count);

                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                            if (dtProd.Rows.Count >= 1)
                            {
                                dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                dtProd.Select();
                            }
                            else
                            {
                                bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                                bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                                bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                                dtProd.DataSource = null;
                                Limpar();
                                lblCodigo.Enabled = false;
                                lblCliente.Enabled = false;
                                cbbCliente.Enabled = false;
                                btnPesquisarCliente.Enabled = false;
                                lblValidade.Enabled = false;
                                mtxtValidade.Enabled = false;
                                btnSelecionarData1.Enabled = false;
                                lblObservacao.Enabled = false;
                                rtxtObs.Enabled = false;
                                lblQtdeCar.Enabled = false;
                                lblQtdeCar.Enabled = false;
                                rbtnServicos.Enabled = false;
                                grbBox3.Enabled = false;
                                btnNovo.Enabled = true;
                                btnSalvar.Enabled = false;
                                btnCancelar.Visible = false;
                                btnNovo.Select();
                            }
                        }
                    }
                    //
                    rbtnCodigo.Checked = true;
                }
                else
                {
                    btnNovo.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOrcamento.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            cbbCliente.Text = null;
            mtxtValidade.Text = null;
            rtxtObs.Text = null;
            rbtnCodigo.Checked = true;
            txtpCodigo.Text = null;
            txtpBarra.Text = null;
            dtProd.DataSource = null;
            mtxtHorario.Text = null;
            lblValorTotal.Text = "0,00";
            lblValorTotalReal.Text = "0,00";
        }

        private void cbbCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCliente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCliente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCliente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisarCliente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisarProduto_MouseLeave(object sender, EventArgs e)
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

        private void pcibInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnIncuir.Select();
            }
        }

        private void cbbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtValidade.Select();
            }
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpBarra_Enter(object sender, EventArgs e)
        {
            txtpBarra.BackColor = Color.LightBlue;
        }

        private void txtpBarra_Leave(object sender, EventArgs e)
        {
            if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpBarra.Text = null;
            }
            txtpBarra.BackColor = Color.White;
        }

        private void txtpBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtpBarra.Text != "")
                {
                    try
                    {
                        if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO") == null)
                        {
                            MessageBox.Show("Código de barras do Produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            txtpBarra.Text = null;
                            txtpBarra.Select();
                        }
                        else
                        {
                            DataRow dr = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO").Rows[0];
                            //
                            if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                            {
                                bllOrcamento._Orc_PesqProduto_Tabela = dr["id_produto"].ToString() + "—" + dr["descricao"].ToString() + "—" + dr["UM"].ToString() + "—" + dr["preco"].ToString() + "—" + dr["acrescimo_porc"].ToString() + "—" + dr["desconto_porc"].ToString();
                                //                           
                                using (FrmAdicionarItem Orc = new FrmAdicionarItem(dtProd.Rows.Count + 1, 0, null, null, null))
                                {
                                    if (Orc.ShowDialog() == DialogResult.OK)
                                    {
                                        dtProd.Select();

                                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                        //
                                        txtpBarra.Text = null;
                                        //
                                        dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                        //
                                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                        //
                                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                        //
                                        if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                        {
                                            if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                            {
                                                MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.DialogResult = DialogResult.None;
                                            }
                                        }
                                        //
                                        txtpBarra.Select();
                                    }
                                }
                            }
                            else
                            {
                                using (FrmQuantidade Qtde = new FrmQuantidade(2, "1,00"))
                                {
                                    if (Qtde.ShowDialog() == DialogResult.OK)
                                    {
                                        bllOrcamento.Salvar_Itens_Orc_Operation((dtProd.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), bllOrcamento._Quantidade, dr["UM"].ToString(), dr["preco"].ToString(), dr["desconto_porc"].ToString(), dr["acrescimo_porc"].ToString(), bllConexao._Codigo_Conexao, 0);
                                        //
                                        dtProd.Select();
                                        //
                                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                        //
                                        txtpCodigo.Text = null;
                                        //
                                        dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                        //
                                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                        //
                                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                        //
                                        if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                        {
                                            if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                            {
                                                MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.DialogResult = DialogResult.None;
                                            }
                                        }
                                        //
                                        txtpBarra.Select();
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
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                        }
                        rbtnCodigo.Checked = true;
                    }
                }
                else
                {
                    btnIncuir.Select();
                }
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

        private void dtProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
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
            dtProd.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtProd.Columns[10].DefaultCellStyle.Format = "n2";
            dtProd.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtProd.Columns[11].DefaultCellStyle.Format = "n2";
        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (rbtnProdutos.Checked == true)
                {
                    if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                    {
                        using (FrmPesqProduto Prod = new FrmPesqProduto(7, null, _Usuario, _Cod_PDV_Computador, dtProd.Rows.Count, null))
                        {
                            if (Prod.ShowDialog() == DialogResult.OK)
                            {
                                using (FrmAdicionarItem Item = new FrmAdicionarItem(dtProd.Rows.Count, 0, null, null, null))
                                {
                                    if (Item.ShowDialog() == DialogResult.OK)
                                    {
                                        if (rbtnCodigo.Checked == true)
                                        {
                                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                            txtpCodigo.Text = null;

                                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }

                                            txtpCodigo.Select();
                                        }
                                        else
                                        {
                                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                            txtpBarra.Text = null;

                                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                            //
                                            txtpBarra.Select();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (FrmPesqProduto Prod = new FrmPesqProduto(8, null, _Usuario, _Cod_PDV_Computador, dtProd.Rows.Count + 1, null))
                        {
                            if (Prod.ShowDialog() == DialogResult.OK)
                            {
                                if (rbtnCodigo.Checked == true)
                                {
                                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                    txtpCodigo.Text = null;

                                    dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                    dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                    dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                                    if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                    {
                                        if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                        {
                                            MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.DialogResult = DialogResult.None;
                                        }
                                    }

                                    txtpCodigo.Select();
                                }
                                else
                                {
                                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                    txtpBarra.Text = null;

                                    dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                    dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                    dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                                    if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                    {
                                        if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                        {
                                            MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.DialogResult = DialogResult.None;
                                        }
                                    }
                                    //
                                    txtpBarra.Select();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                    {
                        using (FrmPesqServico Serv = new FrmPesqServico(3, _Usuario, _Cod_PDV_Computador, 0))
                        {
                            if (Serv.ShowDialog() == DialogResult.OK)
                            {
                                using (FrmAdicionarItem Item = new FrmAdicionarItem(dtProd.Rows.Count, 4, null, null, null))
                                {
                                    if (Item.ShowDialog() == DialogResult.OK)
                                    {
                                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                        txtpCodigo.Text = null;

                                        dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                        txtpCodigo.Select();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (FrmPesqServico Serv = new FrmPesqServico(1, _Usuario, _Cod_PDV_Computador, dtProd.Rows.Count + 1))
                        {
                            if (Serv.ShowDialog() == DialogResult.OK)
                            {
                                dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                txtpCodigo.Text = null;

                                dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                txtpCodigo.Select();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = false;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarProduto.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código e código de barras.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você inicia um novo orçamento, exclui um item do orçamento e cancela o orçamento atual.\n\n1 - Clicando no botão [ Novo ] você inicia um novo orçamento, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botao [ Excluir item ] você estará excluindo o item selecionado na tabela.\n\n3 - Se por algum um motivo você clicou no botão [ Novo ] e não deseja continuar nesta opção, clique no botão\n[ Cancelar ]\n\n4 - Clicando no botão [ Continuar ] você continua a para a finalização do orçamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmOrcamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            rbtnProdutos.Checked = true;
            lblCodigo.Enabled = true;
            lblCliente.Enabled = true;
            cbbCliente.Enabled = true;
            lblAsterisco.Enabled = true;
            btnPesquisarCliente.Enabled = true;
            lblValidade.Enabled = true;
            mtxtValidade.Enabled = true;
            btnSelecionarData1.Enabled = true;
            lblObservacao.Enabled = true;
            rtxtObs.Enabled = true;
            lblQtdeCar.Enabled = true;
            lblQtdeCar.Enabled = true;
            mtxtHorario.Enabled = true;
            rbtnServicos.Enabled = true;
            grbBox3.Enabled = true;
            txtpCodigo.Select();
            btnNovo.Enabled = false;
            btnCapturar.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Visible = true;
            rbtnCodigo.Checked = true;
            btnGerar.Visible = false;
            btnEnviarEmail.Visible = false;
            btnEnviarZap.Visible = false;
            //                
            try
            {
                cbbCliente.Items.Clear();
                if (bllOrcamento.Sel_Cliente_Orc() == null)
                {
                    cbbCliente.Enabled = false;
                    cbbCliente.Text = null;
                }
                else
                {
                    cbbCliente.Enabled = true;
                    cbbCliente.Items.Add("");
                    foreach (DataRow dr in bllOrcamento.Sel_Cliente_Orc().Rows)
                    {
                        string cpfcnpj;
                        if (dr["cpf_cnpj"].ToString() == "")
                        {
                            cpfcnpj = "";
                        }
                        else
                        {
                            cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                        }
                        cbbCliente.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                    }
                }
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
            }
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(589, 21);
            txtpCodigo.Visible = true;
            txtpBarra.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnBarra_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite o código de barras:";
            lblPesquisar.Location = new Point(437, 21);
            txtpCodigo.Visible = false;
            txtpBarra.Visible = true;
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                byte tabela;
                if (rbtnProdutos.Checked == true)
                {
                    tabela = 0;
                    if (rbtnCodigo.Checked == true)
                    {
                        if (txtpCodigo.Text != "")
                        {
                            if (bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "ATIVO") == null)
                            {
                                MessageBox.Show("Código de Produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                txtpCodigo.Text = null;
                                txtpCodigo.Select();
                            }
                            else
                            {
                                DataRow dr = bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "ATIVO").Rows[0];
                                //
                                if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                                {
                                    bllOrcamento._Orc_PesqProduto_Tabela = dr["id_produto"].ToString() + "—" + dr["descricao"].ToString() + "—" + dr["UM"].ToString() + "—" + dr["preco"].ToString() + "—" + dr["acrescimo_porc"].ToString() + "—" + dr["desconto_porc"].ToString();
                                    //
                                    using (FrmAdicionarItem Orc = new FrmAdicionarItem(dtProd.Rows.Count, 0, null, null, null))
                                    {
                                        if (Orc.ShowDialog() == DialogResult.OK)
                                        {
                                            dtProd.Select();

                                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                            //
                                            txtpCodigo.Text = null;
                                            //
                                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                            //
                                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                            //
                                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                            //
                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                            //
                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                            //
                                            txtpCodigo.Select();
                                        }
                                    }
                                }
                                else
                                {
                                    using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                                    {
                                        if (Qtde.ShowDialog() == DialogResult.OK)
                                        {
                                            bllOrcamento.Salvar_Itens_Orc_Operation((dtProd.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), bllOrcamento._Quantidade, dr["UM"].ToString(), dr["preco"].ToString(), dr["desconto_porc"].ToString(), dr["acrescimo_porc"].ToString(), bllConexao._Codigo_Conexao, tabela);
                                            //
                                            dtProd.Select();
                                            //
                                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                            //
                                            txtpCodigo.Text = null;
                                            //
                                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                            //
                                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                            //
                                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                            //
                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                            //
                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                            //
                                            txtpCodigo.Select();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (rbtnBarra.Checked == true)
                    {
                        if (txtpBarra.Text != "")
                        {
                            if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO") == null)
                            {
                                MessageBox.Show("Código de barras do Produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                txtpBarra.Text = null;
                                txtpBarra.Select();
                            }
                            else
                            {
                                DataRow dr = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO").Rows[0];
                                //
                                if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                                {
                                    bllOrcamento._Orc_PesqProduto_Tabela = dr["id_produto"].ToString() + "—" + dr["descricao"].ToString() + "—" + dr["UM"].ToString() + "—" + dr["preco"].ToString() + "—" + dr["acrescimo_porc"].ToString() + "—" + dr["desconto_porc"].ToString();
                                    //                           
                                    using (FrmAdicionarItem Orc = new FrmAdicionarItem(dtProd.Rows.Count + 1, 0, null, null, null))
                                    {
                                        if (Orc.ShowDialog() == DialogResult.OK)
                                        {
                                            dtProd.Select();

                                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                            //
                                            txtpBarra.Text = null;
                                            //
                                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                            //
                                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                            //
                                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                            //
                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                            //
                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                            //
                                            txtpBarra.Select();
                                        }
                                    }
                                }
                                else
                                {
                                    using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                                    {
                                        if (Qtde.ShowDialog() == DialogResult.OK)
                                        {
                                            bllOrcamento.Salvar_Itens_Orc_Operation((dtProd.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), bllOrcamento._Quantidade, dr["UM"].ToString(), dr["preco"].ToString(), dr["desconto_porc"].ToString(), dr["acrescimo_porc"].ToString(), bllConexao._Codigo_Conexao, tabela);
                                            //
                                            dtProd.Select();
                                            //
                                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                            //
                                            txtpCodigo.Text = null;
                                            //
                                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                            //
                                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                            //
                                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                            //
                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                            //
                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                            //
                                            txtpBarra.Select();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    tabela = 1;
                    if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                    {
                        if (txtpCodigo.Text != "")
                        {
                            if (bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "ATIVO") == null)
                            {
                                MessageBox.Show("Código de Serviço informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                txtpCodigo.Text = null;
                                txtpCodigo.Select();
                            }
                            else
                            {
                                DataRow dr = bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "ATIVO").Rows[0];
                                //
                                bllOrcamento._Orc_PesqProduto_Tabela = dr["id_servico"].ToString() + "—" + dr["descricao"].ToString() + "—" + dr["preco"].ToString() + "—" + dr["acrescimo_porc"].ToString() + "—" + dr["desconto_porc"].ToString();
                                //
                                using (FrmAdicionarItem Item = new FrmAdicionarItem(dtProd.Rows.Count, 4, null, null, null))
                                {
                                    if (Item.ShowDialog() == DialogResult.OK)
                                    {
                                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                        txtpCodigo.Text = null;

                                        dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];

                                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                        txtpCodigo.Select();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (txtpCodigo.Text != "")
                        {
                            if (bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "ATIVO") == null)
                            {
                                MessageBox.Show("Código de Serviço informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                txtpCodigo.Text = null;
                                txtpCodigo.Select();
                            }
                            else
                            {
                                DataRow dr = bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "ATIVO").Rows[0];
                                //
                                using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                                {
                                    if (Qtde.ShowDialog() == DialogResult.OK)
                                    {
                                        bllOrcamento.Salvar_Itens_Orc_Operation((dtProd.Rows.Count + 1).ToString(), dr["id_servico"].ToString(), dr["descricao"].ToString(), bllOrcamento._Quantidade, "UN", dr["preco"].ToString(), "0", "0", bllConexao._Codigo_Conexao, tabela);
                                        //
                                        dtProd.Select();
                                        //
                                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                        //
                                        txtpCodigo.Text = null;
                                        //
                                        dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                        //
                                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                        //
                                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                        //
                                        txtpCodigo.Select();
                                    }
                                }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                rbtnCodigo.Checked = true;
            }
        }

        private void FrmOrcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllOrcamento._FrmOrcamento_Ativo = false;
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOrcamento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOrcamento foi finalizado.");
                }
                //
                if (dtProd.DataSource != null)
                {
                    if (bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                    {
                        bllOrcamento.Alterar_Dados_Orcamento_PDV(cbbCliente.Text, mtxtValidade.Text, mtxtHorario.Text, rtxtObs.Text, bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                        //
                        bllOrcamento.Alterar_Dados_Orcamento_PDV(cbbCliente.Text, mtxtValidade.Text, mtxtHorario.Text, rtxtObs.Text, bllConexao._Codigo_Conexao);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmOrcamento.");
                }
            }
        }

        private void dtProd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtProd.Columns[0].HeaderText = "Item";
            dtProd.Columns[1].HeaderText = "Código";
            dtProd.Columns[2].HeaderText = "Descrição";
            dtProd.Columns[3].HeaderText = "Quantidade";
            dtProd.Columns[4].HeaderText = "UN";
            dtProd.Columns[5].HeaderText = "Valor Unitário (R$)";
            dtProd.Columns[6].HeaderText = "Valor do Item (R$)";
            dtProd.Columns[7].Visible = false;
            //dtProd.Columns[7].HeaderText = "Desconto - (%)";
            dtProd.Columns[8].HeaderText = "Valor Desconto - (R$)";
            dtProd.Columns[9].Visible = false;
            //dtProd.Columns[9].HeaderText = "Acréscimo + (%)";
            dtProd.Columns[10].HeaderText = "Valor Acréscimo + (R$)";
            dtProd.Columns[11].HeaderText = "Valor Total do Item (R$)";
            dtProd.Columns[12].HeaderText = "Tabela";

            dtProd.Columns[0].Width = 55;
            dtProd.Columns[1].Width = 78;
            dtProd.Columns[2].Width = 280;
            dtProd.Columns[3].Width = 90;
            dtProd.Columns[4].Width = 50;
            dtProd.Columns[5].Width = 125;
            dtProd.Columns[6].Width = 145;
            dtProd.Columns[7].Width = 145;
            dtProd.Columns[8].Width = 135;
            dtProd.Columns[9].Width = 135;
            dtProd.Columns[10].Width = 145;
            dtProd.Columns[11].Width = 150;
            dtProd.Columns[12].Width = 150;

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

            lblRegistros.Text = "Registros: " + dtProd.Rows.Count.ToString();

            decimal totalreal = 0;
            for (int i = 0; i < dtProd.Rows.Count; i++)
            {
                totalreal += Convert.ToDecimal(dtProd.Rows[i].Cells[11].Value);
            }
            lblValorTotalReal.Text = totalreal.ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal total = 0;
            for (int i = 0; i < dtProd.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dtProd.Rows[i].Cells[6].Value);
            }
            lblValorTotal.Text = total.ToString("n2", new CultureInfo("pt-BR"));
        }

        private void dtProd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtProd.Rows.Count.ToString();
            //
            decimal totalreal = 0;
            for (int i = 0; i < dtProd.Rows.Count; i++)
            {
                totalreal += Convert.ToDecimal(dtProd.Rows[i].Cells[11].Value);
            }
            lblValorTotalReal.Text = totalreal.ToString("n2", new CultureInfo("pt-BR"));
            //
            //
            decimal total = 0;
            for (int i = 0; i < dtProd.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dtProd.Rows[i].Cells[6].Value);
            }
            lblValorTotal.Text = total.ToString("n2", new CultureInfo("pt-BR"));
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                try
                {
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    bllOrcamento.Excluir_Item(SelectedRow.Cells[0].Value.ToString());

                    bllOrcamento.Atualizar_Item_Dt_Prod(dtProd.CurrentRow.Index + 1, dtProd.Rows.Count);

                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                    if (dtProd.Rows.Count >= 1)
                    {
                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                        dtProd.Select();
                    }
                    else
                    {
                        bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                        bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                        bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                        dtProd.DataSource = null;
                        Limpar();
                        lblCodigo.Enabled = false;
                        lblCliente.Enabled = false;
                        cbbCliente.Enabled = false;
                        btnPesquisarCliente.Enabled = false;
                        lblValidade.Enabled = false;
                        mtxtValidade.Enabled = false;
                        btnSelecionarData1.Enabled = false;
                        lblObservacao.Enabled = false;
                        rtxtObs.Enabled = false;
                        lblQtdeCar.Enabled = false;
                        lblQtdeCar.Enabled = false;
                        rbtnServicos.Enabled = false;
                        grbBox3.Enabled = false;
                        btnNovo.Enabled = true;
                        btnCapturar.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnCancelar.Visible = false;
                        btnNovo.Select();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirItem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirItem.");
                    }
                    this.DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void dtProd_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtProd.DataSource != null)
            {
                btnExcluirItem.Enabled = true;
                btnSalvar.Enabled = true;
            }
            else
            {
                btnExcluirItem.Enabled = false;
                btnSalvar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja cancelar o orçamento atual?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                try
                {
                    bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                    bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                    bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                    dtProd.DataSource = null;
                    Limpar();
                    lblCodigo.Enabled = false;
                    lblCliente.Enabled = false;
                    cbbCliente.Enabled = false;
                    lblAsterisco.Enabled = false;
                    btnPesquisarCliente.Enabled = false;
                    lblValidade.Enabled = false;
                    mtxtValidade.Enabled = false;
                    btnSelecionarData1.Enabled = false;
                    lblObservacao.Enabled = false;
                    rtxtObs.Enabled = false;
                    lblQtdeCar.Enabled = false;
                    lblQtdeCar.Enabled = false;
                    rbtnServicos.Enabled = false;
                    grbBox3.Enabled = false;
                    btnNovo.Enabled = true;
                    btnSalvar.Enabled = false;
                    btnCapturar.Enabled = false;
                    btnCancelar.Visible = false;
                    btnNovo.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCancelar.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCancelar.");
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void GerarPDF() 
        {
            if (bllOrcamento._Tipo_Impressao == "PDF A4")
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep, tel, cel;
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
                    tel = drPDF["telefone"].ToString();
                    cel = drPDF["celular"].ToString();
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
                    if (bllOrcamento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 230 + Margem_Esq, 7 + Margem_Topo, 140, 116);
                        imagem1.Dispose();
                        registros = 16;
                    }
                    else
                    {
                        registros = 18;
                    }
                    //
                    Margem_Topo = Margem_Topo + 45;
                    //
                    /*
                    if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        Margem_Topo = Margem_Topo + 5;
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 280 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        registros = 16;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 18;
                    }
                    */
                    //
                    textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 595, 13));
                    //
                    textFormatter1.DrawString(fantasia, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 98 + Margem_Topo, 595, 13));
                    //
                    textFormatter1.DrawString(cpf_cnpj + "  " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                    //
                    if (tel != "" & cel != "")
                    {
                        tel = tel + " - ";
                    }
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 124 + Margem_Topo, 595, 58);
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep + Environment.NewLine + tel + cel, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 124 + Margem_Topo, 595, 58));
                    //
                    Margem_Topo = Margem_Topo + 15;
                    //
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 160 + Margem_Topo, 595, 24));
                    textFormatter1.DrawString("ORÇAMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 169 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 175 + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString(" #       Código               Descrição                                                               Qtde.        UN.        Vl.Unit        Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 185 + Margem_Topo, 595, 13));
                    //
                    int Incrementar = 0;
                    for (int i = 0; i < dtProd.Rows.Count; i++)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[i];
                        if (PrimeiraPagina == true)
                        {
                            if (i == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "                      " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                DataRow drDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(drDescAcresc["valor_desconto"]) + Convert.ToDecimal(drDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(drDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(drDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(drDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 203 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(dtProd.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 203 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 216 + Margem_Topo, 100, 13));
                                //
                                if (_Valor_Desconto != "0" || _Valor_Desconto_Item != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 13));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(_Valor_Desconto) + Convert.ToDecimal(_Valor_Desconto_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (_Valor_Acrescimo != "0" || _Valor_Acrescimo_Item != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(_Valor_Acrescimo) + Convert.ToDecimal(_Valor_Acrescimo_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 8));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotalReal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 13));
                                //
                                if (_CPF_CNPJ_Consumidor != "")
                                {
                                    textFormatter1.DrawString(_CPF_CNPJ_Consumidor, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + _Cod_Orcamento + "  " + _Data + "  " + _Hora, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 13));
                                //
                                if (_Data_Validade != null & _Data_Validade != "")
                                {
                                    Incrementar = Incrementar + 13;
                                    textFormatter1.DrawString("Data e Hora de Validade: " + _Data_Validade.Remove(10) + "  " + _Hora_Validade, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 13));
                                }
                                //
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 28));
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 281 + Margem_Topo, 585, 11));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "                      " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                DataRow drDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(drDescAcresc["valor_desconto"]) + Convert.ToDecimal(drDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(drDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(drDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(drDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (i == registros - 5 & dtProd.Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 4 & dtProd.Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 3 & dtProd.Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 2 & dtProd.Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 1 & dtProd.Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            if (i == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "                      " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                DataRow drDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(drDescAcresc["valor_desconto"]) + Convert.ToDecimal(drDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(drDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(drDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(drDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 43 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(dtProd.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 43 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 56 + Margem_Topo, 100, 13));
                                //
                                if (_Valor_Desconto != "0" || _Valor_Desconto_Item != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 13));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(_Valor_Desconto) + Convert.ToDecimal(_Valor_Desconto_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (_Valor_Acrescimo != "0" || _Valor_Acrescimo_Item != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(_Valor_Acrescimo) + Convert.ToDecimal(_Valor_Acrescimo_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 8));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotalReal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 13));
                                //
                                //
                                if (_CPF_CNPJ_Consumidor != "")
                                {
                                    textFormatter1.DrawString(_CPF_CNPJ_Consumidor, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + _Cod_Orcamento + "   " + _Data + "   " + _Hora, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 13));
                                //
                                if (_Data_Validade != null & _Data_Validade != "")
                                {
                                    Incrementar = Incrementar + 13;
                                    textFormatter1.DrawString("Data e Hora de Validade: " + _Data_Validade.Remove(10) + "  " + _Hora_Validade, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 13));
                                }
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 28));
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 121 + Margem_Topo, 585, 11));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "                      " + SelectedRow.Cells[2].Value.ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                DataRow drDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(drDescAcresc["valor_desconto"]) + Convert.ToDecimal(drDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(drDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(drDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(drDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (i == registros - 5 & dtProd.Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 4 & dtProd.Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 3 & dtProd.Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 2 & dtProd.Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                            else if (i == registros - 1 & dtProd.Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
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
                    string mes;
                    if (DateTime.Now.Month < 10)
                    {
                        mes = "0" + DateTime.Now.Month;
                    }
                    else
                    {
                        mes = DateTime.Now.Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes + @"\" + _Cod_Orcamento + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes + @"\" + _Cod_Orcamento + ".pdf");
                    }                    
                 }
            }
            else
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep, tel, cel;
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
                    tel = drPDF["telefone"].ToString();
                    cel = drPDF["celular"].ToString();
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
                    var fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                    var fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                    var fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
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
                    if (bllOrcamento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 20 + Margem_Esq, 1 + Margem_Topo, 158, 69);
                        imagem1.Dispose();
                        Margem_Topo = Margem_Topo - 15;
                        registros = 32;
                    }
                    else
                    {
                        Margem_Topo = Margem_Topo - 69;
                        registros = 34;
                    }
                    //
                    Margem_Topo = Margem_Topo + 5;
                    /*
                    if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                       
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        
                    }
                    */
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 85 + Margem_Topo, 198, 16);
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 9;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 10));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 9;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 10));
                    }
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 102 + Margem_Topo, 198, 10));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 102 + Margem_Topo, 198, 10));
                    }    
                    //
                    if (tel != "" & cel != "")
                    {
                        tel = tel + " - ";
                    }
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep + Environment.NewLine + tel + cel, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 110 + Margem_Topo, 198, 43));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Margem_Topo = Margem_Topo + 4;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter1.DrawString("ORÇAMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Incrementar + Margem_Topo, 198, 24));
                    //
                    Incrementar = Incrementar + 3;
                    //
                    textFormatter2.DrawString(" # Código  Descrição  Qtde.  UN.  Vl.Unit  Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 160 + Margem_Topo, 198, 8));
                    //
                    Incrementar = Incrementar + 3;
                    //
                    for (int linha = 0; linha < dtProd.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[linha];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (linha == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                if (SelectedRow.Cells[2].Value.ToString().Length > 30)
                                {
                                    //graphics.DrawRectangle(pen, 20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20);
                                    if (!SelectedRow.Cells[2].Value.ToString().Substring(0, 30).Contains(" ") || !SelectedRow.Cells[2].Value.ToString().Substring(30).Contains(" "))
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString().Insert(30, Environment.NewLine), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                }
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
                                DataRow dtDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                //
                                Incrementar = Incrementar + 9;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dtDescAcresc["valor_desconto"]) + Convert.ToDecimal(dtDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dtDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(dtDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dtDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 3;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 168 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(dtProd.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 168 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 9;
                                //
                                if (_Valor_Desconto != "0" || _Valor_Desconto_Item != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(_Valor_Desconto) + Convert.ToDecimal(_Valor_Desconto_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                if (_Valor_Acrescimo != "0" || _Valor_Acrescimo_Item != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(_Valor_Acrescimo) + Convert.ToDecimal(_Valor_Acrescimo_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotalReal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                //
                                if (_CPF_CNPJ_Consumidor != "")
                                {
                                    textFormatter1.DrawString(_CPF_CNPJ_Consumidor, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 185 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 185 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + _Cod_Orcamento + "   " + _Data + "   " + _Hora, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 184 + Margem_Topo, 198, 8));
                                //
                                if (_Data_Validade != null & _Data_Validade != "")
                                {
                                    Incrementar = Incrementar + 9;
                                    textFormatter1.DrawString("Data e Hora de Validade: " + _Data_Validade.Remove(10) + "  " + _Hora_Validade, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 184 + Margem_Topo, 595, 13));
                                }
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 194 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 9;
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 198, 16));
                                //
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                if (SelectedRow.Cells[2].Value.ToString().Length > 30)
                                {
                                    //graphics.DrawRectangle(pen, 20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20);
                                    if (!SelectedRow.Cells[2].Value.ToString().Substring(0, 30).Contains(" ") || !SelectedRow.Cells[2].Value.ToString().Substring(30).Contains(" "))
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString().Insert(30, Environment.NewLine), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                }
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
                                DataRow dtDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                //
                                Incrementar = Incrementar + 9;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dtDescAcresc["valor_desconto"]) + Convert.ToDecimal(dtDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dtDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(dtDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dtDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 16;
                            }
                            //
                            if (linha == registros - 5 & dtProd.Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & dtProd.Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & dtProd.Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & dtProd.Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & dtProd.Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            if (linha == dtProd.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {

                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                if (SelectedRow.Cells[2].Value.ToString().Length > 30)
                                {
                                    //graphics.DrawRectangle(pen, 20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20);
                                    if (!SelectedRow.Cells[2].Value.ToString().Substring(0, 30).Contains(" ") || !SelectedRow.Cells[2].Value.ToString().Substring(30).Contains(" "))
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString().Insert(30, Environment.NewLine), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 180, 20));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 180, 20));
                                    }
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                }
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
                                DataRow dtDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                //
                                Incrementar = Incrementar + 9;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dtDescAcresc["valor_desconto"]) + Convert.ToDecimal(dtDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dtDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(dtDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dtDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 3;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(dtProd.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 9;
                                //
                                if (_Valor_Desconto != "0" || _Valor_Desconto_Item != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(_Valor_Desconto) + Convert.ToDecimal(_Valor_Desconto_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                if (_Valor_Acrescimo != "0" || _Valor_Acrescimo_Item != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(_Valor_Acrescimo) + Convert.ToDecimal(_Valor_Acrescimo_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(lblValorTotalReal.Text).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                //
                                if (_CPF_CNPJ_Consumidor != "")
                                {
                                    textFormatter1.DrawString(_CPF_CNPJ_Consumidor, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + _Cod_Orcamento + "   " + _Data + "   " + _Hora, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                //
                                if (_Data_Validade == null & _Data_Validade == "")
                                {
                                    Incrementar = Incrementar + 9;
                                    textFormatter1.DrawString("Data e Hora de Validade: " + _Data_Validade.Remove(10) + "  " + _Hora_Validade, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                }
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 36 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 9;
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 42 + Margem_Topo, 198, 16));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                if (SelectedRow.Cells[2].Value.ToString().Length > 30)
                                {
                                    //graphics.DrawRectangle(pen, 20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20);
                                    if (!SelectedRow.Cells[2].Value.ToString().Substring(0, 30).Contains(" ") || !SelectedRow.Cells[2].Value.ToString().Substring(30).Contains(" "))
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString().Insert(30, Environment.NewLine), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 180, 20));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 180, 20));
                                    }
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                }
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
                                DataRow dtDescAcresc = bllOrcamento.Sel_Desconto_Acrescimo_Orcamento(_Cod_Orcamento, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                //
                                Incrementar = Incrementar + 9;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dtDescAcresc["valor_desconto"]) + Convert.ToDecimal(dtDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dtDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(dtDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dtDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & dtProd.Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & dtProd.Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & dtProd.Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & dtProd.Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & dtProd.Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                    }
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
                    string mes;
                    if (DateTime.Now.Month < 10)
                    {
                        mes = "0" + DateTime.Now.Month;
                    }
                    else
                    {
                        mes = DateTime.Now.Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes + @"\" + _Cod_Orcamento + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes + @"\" + _Cod_Orcamento + ".pdf");
                    }
                }
            }
        }

        private void dtProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    try
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                        bllOrcamento.Excluir_Item(SelectedRow.Cells[0].Value.ToString());

                        bllOrcamento.Atualizar_Item_Dt_Prod(dtProd.CurrentRow.Index + 1, dtProd.Rows.Count);

                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                        if (dtProd.Rows.Count >= 1)
                        {
                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                            dtProd.Select();
                        }
                        else
                        {
                            bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                            bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                            bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                            dtProd.DataSource = null;
                            Limpar();
                            lblCodigo.Enabled = false;
                            lblCliente.Enabled = false;
                            cbbCliente.Enabled = false;
                            btnPesquisarCliente.Enabled = false;
                            lblValidade.Enabled = false;
                            mtxtValidade.Enabled = false;
                            btnSelecionarData1.Enabled = false;
                            lblObservacao.Enabled = false;
                            rtxtObs.Enabled = false;
                            lblQtdeCar.Enabled = false;
                            lblQtdeCar.Enabled = false;
                            rbtnServicos.Enabled = false;
                            grbBox3.Enabled = false;
                            btnNovo.Enabled = true;
                            btnSalvar.Enabled = false;
                            btnCancelar.Visible = false;
                            btnNovo.Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do datagridview dtProd.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do datagridview dtProd.");
                        }
                        this.DialogResult = DialogResult.Abort;
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCliente Clie = new FrmPesqCliente(15, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] items = bllOrcamento._Orc_PesqConsumidor_Tabela.Split('—');
                        //
                        cbbCliente.Items.Clear();
                        if (bllOrcamento.Sel_Cliente_Orc() == null)
                        {
                            cbbCliente.Enabled = false;
                            cbbCliente.Text = null;
                        }
                        else
                        {
                            cbbCliente.Enabled = true;
                            cbbCliente.Items.Add("");
                            foreach (DataRow dr in bllOrcamento.Sel_Cliente_Orc().Rows)
                            {
                                string cpfcnpj;
                                if (dr["cpf_cnpj"].ToString() == "")
                                {
                                    cpfcnpj = "";
                                }
                                else
                                {
                                    cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                }
                                cbbCliente.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                            }
                        }
                        //
                        if (items.Length > 2)
                        {
                            cbbCliente.Text = items[0] + "—" + items[1] + "—" + items[2];
                        }
                        else
                        {
                            cbbCliente.Text = items[0] + "—" + items[1];
                        }
                        //
                        bllOrcamento._Orc_PesqConsumidor_Tabela = null;
                        //
                        cbbCliente.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarCliente.");
                        }
                        bllOrcamento._Orc_PesqConsumidor_Tabela = null;
                        cbbCliente.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void mtxtValidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void mtxtValidade_Enter(object sender, EventArgs e)
        {
            mtxtValidade.BackColor = Color.LightBlue;
        }

        private void mtxtValidade_Leave(object sender, EventArgs e)
        {
            mtxtValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtValidade.Text == "")
            {
                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtValidade.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  mtxtValidade.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  mtxtValidade.");
                    }
                    mtxtValidade.Text = null;
                }
            }
            mtxtValidade.BackColor = Color.White;

        }

        private void btnSelecionarData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(6))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtValidade.Text = bllOrcamento._Data_DatePicker1;
                    bllOrcamento._Data_DatePicker1 = null;
                    mtxtValidade.Select();
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxtValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //
            if (cbbCliente.Text == "")
            {
                MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Cliente/Consumidor ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                cbbCliente.Select();
            }
            else if (dtProd.Rows.Count == 0)
            {
                MessageBox.Show("Existe uma tabela obrigatória que precisa ser preenchida:\n [ Produtos ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                cbbCliente.Select();
            }
            else if (mtxtHorario.Text != "" & mtxtValidade.Text == "")
            {
                MessageBox.Show("Existe um horário de válidade informado sem uma data de válidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                cbbCliente.Select();
            }
            else
            {
                pEnabled.Enabled = false;
                try
                {
                    using (FrmDescontoAcrescimoOrc DescAcresc = new FrmDescontoAcrescimoOrc(lblValorTotalReal.Text))
                    {
                        if (DescAcresc.ShowDialog() == DialogResult.OK)
                        {
                            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                DataRow dr;
                                //
                                this.DialogResult = DialogResult.None;
                                dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                //
                                for (int i = 0; i < dtProd.Rows.Count; i++)
                                {
                                    if (Convert.ToByte(dtProd.Rows[i].Cells[12].Value) == 0)
                                    {
                                        if (bllOrcamento.Sel_Cod_Produto_Existe_Orc(dtProd.Rows[i].Cells[1].Value.ToString()) == false)
                                        {
                                            MessageBox.Show("O Produto: [ " + Convert.ToInt16(dtProd.Rows[i].Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")) + " - " + dtProd.Rows[i].Cells[1].Value.ToString() + " - " + dtProd.Rows[i].Cells[2].Value.ToString() + " ] foi excluído ou não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;

                                            if (dtProd.Rows.Count > 1)
                                            {
                                                DialogResult = MessageBox.Show("Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (DialogResult == DialogResult.No)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    pEnabled.Enabled = true;
                                                    return;

                                                }
                                                else
                                                {
                                                    this.DialogResult = DialogResult.None;

                                                    bllOrcamento.Excluir_Item(dtProd.Rows[i].Cells[0].Value.ToString());

                                                    bllOrcamento.Atualizar_Item_Dt_Prod(Convert.ToInt32(dtProd.Rows[i].Cells[0].Value), dtProd.Rows.Count);

                                                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                                    dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                                    dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                                    dtProd.Select();
                                                }
                                            }
                                            else
                                            {
                                                pEnabled.Enabled = true;
                                                bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                                                bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                                                bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                                                dtProd.DataSource = null;
                                                Limpar();
                                                lblCodigo.Enabled = false;
                                                lblCliente.Enabled = false;
                                                cbbCliente.Enabled = false;
                                                lblAsterisco.Enabled = false;
                                                btnPesquisarCliente.Enabled = false;
                                                lblValidade.Enabled = false;
                                                mtxtValidade.Enabled = false;
                                                btnSelecionarData1.Enabled = false;
                                                lblObservacao.Enabled = false;
                                                rtxtObs.Enabled = false;
                                                lblQtdeCar.Enabled = false;
                                                lblQtdeCar.Enabled = false;
                                                rbtnServicos.Enabled = false;
                                                grbBox3.Enabled = false;
                                                btnNovo.Enabled = true;
                                                btnSalvar.Enabled = false;
                                                btnCapturar.Enabled = false;
                                                btnCancelar.Visible = false;
                                                btnNovo.Select();
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (bllOrcamento.Sel_Cod_Servico_Existe_Orc(dtProd.Rows[i].Cells[1].Value.ToString()) == false)
                                        {
                                            MessageBox.Show("O Serviço: [ " + Convert.ToInt16(dtProd.Rows[i].Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")) + " - " + dtProd.Rows[i].Cells[1].Value.ToString() + " - " + dtProd.Rows[i].Cells[2].Value.ToString() + " ] foi excluído ou não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;

                                            if (dtProd.Rows.Count > 1)
                                            {
                                                DialogResult = MessageBox.Show("Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (DialogResult == DialogResult.No)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    pEnabled.Enabled = true;
                                                    return;
                                                }
                                                else
                                                {
                                                    this.DialogResult = DialogResult.None;

                                                    bllOrcamento.Excluir_Item(dtProd.Rows[i].Cells[0].Value.ToString());

                                                    bllOrcamento.Atualizar_Item_Dt_Prod(Convert.ToInt32(dtProd.Rows[i].Cells[0].Value), dtProd.Rows.Count);

                                                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                                                    dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                                    dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                                    dtProd.Select();
                                                }
                                            }
                                            else
                                            {
                                                pEnabled.Enabled = true;
                                                bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                                                bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                                                bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                                                dtProd.DataSource = null;
                                                Limpar();
                                                lblCodigo.Enabled = false;
                                                lblCliente.Enabled = false;
                                                cbbCliente.Enabled = false;
                                                lblAsterisco.Enabled = false;
                                                btnPesquisarCliente.Enabled = false;
                                                lblValidade.Enabled = false;
                                                mtxtValidade.Enabled = false;
                                                btnSelecionarData1.Enabled = false;
                                                lblObservacao.Enabled = false;
                                                rtxtObs.Enabled = false;
                                                lblQtdeCar.Enabled = false;
                                                lblQtdeCar.Enabled = false;
                                                rbtnServicos.Enabled = false;
                                                grbBox3.Enabled = false;
                                                btnNovo.Enabled = true;
                                                btnSalvar.Enabled = false;
                                                btnCapturar.Enabled = false;
                                                btnCancelar.Visible = false;
                                                btnNovo.Select();
                                                return;
                                            }
                                        }
                                    }
                                }
                                //
                                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                decimal Desconto = 0;
                                for (int i = 0; i < dtProd.Rows.Count; i++)
                                {
                                    Desconto += Convert.ToDecimal(dtProd.Rows[i].Cells[8].Value);
                                }
                                string Valor_Desconto = Desconto.ToString("n2", new CultureInfo("pt-BR"));
                                //
                                decimal Acrescimo = 0;
                                for (int i = 0; i < dtProd.Rows.Count; i++)
                                {
                                    Acrescimo += Convert.ToDecimal(dtProd.Rows[i].Cells[10].Value);
                                }
                                string Valor_Acrescimo = Acrescimo.ToString("n2", new CultureInfo("pt-BR"));
                                //
                                lblValorTotalReal.Text = bllOrcamento._Valor_Real;
                                //
                                bllOrcamento.Salvar(cbbCliente.Text, _Usuario, mtxtValidade.Text, rtxtObs.Text.Trim(), lblValorTotal.Text, _Cod_PDV_Computador, bllOrcamento._Valor_Real, Valor_Desconto, Valor_Acrescimo, mtxtHorario.Text, bllOrcamento._Desconto_Porc, bllOrcamento._Acrescimo_Porc, bllOrcamento._Valor_Desconto, bllOrcamento._Valor_Acrescimo);
                                //
                                dr = bllOrcamento.Sel_Dados_Orcamento_A_Finalizar().Rows[0];
                                //
                                _Cod_Orcamento = dr["id_orcamento"].ToString();
                                _Valor_Acrescimo_Item = dr["valor_acrescimo_item"].ToString();
                                _Valor_Desconto_Item = dr["valor_desconto_item"].ToString();
                                _Valor_Acrescimo = dr["valor_acrescimo"].ToString();
                                _Valor_Desconto = dr["valor_desconto"].ToString();
                                _CPF_CNPJ_Consumidor = dr["cpf_cnpj_consumidor"].ToString();
                                _Data = dr["data"].ToString().Remove(10);
                                _Hora = dr["hora"].ToString();
                                _Data_Validade = dr["data_validade"].ToString();
                                _Hora_Validade = dr["hora_validade"].ToString();
                                //
                                for (int i = 0; i < dtProd.Rows.Count; i++)
                                {
                                    DataGridViewRow SelectedRow = dtProd.Rows[i];

                                    if (i == 0 & dtProd.Rows.Count == 1)
                                    {
                                        bllOrcamento.Salvar_Itens_Orc(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), _Cod_Orcamento, SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), bllOrcamento._Desconto_Porc, bllOrcamento._Valor_Desconto, false, true, bllOrcamento._Acrescimo_Porc, bllOrcamento._Valor_Acrescimo, Convert.ToByte(SelectedRow.Cells[12].Value));
                                    }
                                    else if (i == dtProd.Rows.Count - 1)
                                    {
                                        bllOrcamento.Salvar_Itens_Orc(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), _Cod_Orcamento, SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), bllOrcamento._Desconto_Porc, bllOrcamento._Valor_Desconto, true, false, bllOrcamento._Acrescimo_Porc, bllOrcamento._Valor_Acrescimo, Convert.ToByte(SelectedRow.Cells[12].Value));
                                    }
                                    else
                                    {
                                        bllOrcamento.Salvar_Itens_Orc(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), _Cod_Orcamento, SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), bllOrcamento._Desconto_Porc, bllOrcamento._Valor_Desconto, false, false, bllOrcamento._Acrescimo_Porc, bllOrcamento._Valor_Acrescimo, Convert.ToByte(SelectedRow.Cells[12].Value));
                                    }
                                }
                                //                    
                                dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                                lblCodigo.Enabled = false;
                                txtCodigo.Text = _Cod_Orcamento;
                                lblCliente.Enabled = false;
                                cbbCliente.Enabled = false;
                                lblAsterisco.Enabled = false;
                                btnPesquisarCliente.Enabled = false;
                                lblValidade.Enabled = false;
                                mtxtValidade.Enabled = false;
                                btnSelecionarData1.Enabled = false;
                                lblObservacao.Enabled = false;
                                rtxtObs.Enabled = false;
                                mtxtHorario.Enabled = false;
                                lblQtdeCar.Enabled = false;
                                rbtnServicos.Enabled = false;
                                grbBox3.Enabled = false;
                                btnNovo.Enabled = true;
                                btnExcluirItem.Enabled = false;
                                btnCapturar.Enabled = false;
                                btnCancelar.Visible = false;
                                btnSalvar.Enabled = false;
                                btnGerar.Visible = true;
                                btnEnviarEmail.Visible = true;
                                btnEnviarZap.Visible = true;
                                //
                                bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                                bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                                bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                                //
                                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                MessageBox.Show("Nº do Orçamento: " + _Cod_Orcamento, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                btnGerar_Click(sender, e);
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                dtProd.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            dtProd.Select();
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
                    _Cod_Orcamento = null;
                    _Valor_Acrescimo_Item = null;
                    _Valor_Desconto_Item = null;
                    _Valor_Acrescimo = null;
                    _Valor_Desconto = null;
                    _CPF_CNPJ_Consumidor = null;
                    _Data = null;
                    _Hora = null;
                    dtProd.DataSource = null;
                    bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                    bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                    bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                }
            }
            pEnabled.Enabled = true;
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtValidade_DoubleClick(object sender, EventArgs e)
        {
            mtxtValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtValidade.Text == "")
            {
                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtValidade.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void mtxtValidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtValidade.Text == "")
                {
                    mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtValidade.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total a Pagar (R$): " + lblValorTotal.Text.Replace("R$ ", ""), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalReal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalReal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (dtProd.DataSource != null)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        try
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                            bllOrcamento.Excluir_Item(SelectedRow.Cells[0].Value.ToString());

                            bllOrcamento.Atualizar_Item_Dt_Prod(dtProd.CurrentRow.Index + 1, dtProd.Rows.Count);

                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                            if (dtProd.Rows.Count >= 1)
                            {
                                dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                dtProd.Select();
                            }
                            else
                            {
                                bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                                bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                                bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                                dtProd.DataSource = null;
                                Limpar();
                                lblCodigo.Enabled = false;
                                lblCliente.Enabled = false;
                                cbbCliente.Enabled = false;
                                btnPesquisarCliente.Enabled = false;
                                lblValidade.Enabled = false;
                                mtxtValidade.Enabled = false;
                                btnSelecionarData1.Enabled = false;
                                lblObservacao.Enabled = false;
                                rtxtObs.Enabled = false;
                                lblQtdeCar.Enabled = false;
                                lblQtdeCar.Enabled = false;
                                rbtnServicos.Enabled = false;
                                grbBox3.Enabled = false;
                                btnNovo.Enabled = true;
                                btnSalvar.Enabled = false;
                                btnCancelar.Visible = false;
                                btnNovo.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do datagridview dtProd.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do datagridview dtProd.");
                            }
                            this.DialogResult = DialogResult.Abort;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
        }

        private void txtpBarra_KeyUp(object sender, KeyEventArgs e)
        {
            if (dtProd.DataSource != null)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        try
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                            bllOrcamento.Excluir_Item(SelectedRow.Cells[0].Value.ToString());

                            bllOrcamento.Atualizar_Item_Dt_Prod(dtProd.CurrentRow.Index + 1, dtProd.Rows.Count);

                            dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);

                            if (dtProd.Rows.Count >= 1)
                            {
                                dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;

                                dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;

                                dtProd.Select();
                            }
                            else
                            {
                                bllOrcamento.Excluir_Orc_Atual(bllConexao._Codigo_Conexao);
                                bllOrcamento.Excluir_Cab_Orcamento_Operation(bllConexao._Codigo_Conexao);
                                bllVenda.Excluir_Orcamento_Orc_PDV(bllConexao._Codigo_Conexao);
                                dtProd.DataSource = null;
                                Limpar();
                                lblCodigo.Enabled = false;
                                lblCliente.Enabled = false;
                                cbbCliente.Enabled = false;
                                btnPesquisarCliente.Enabled = false;
                                lblValidade.Enabled = false;
                                mtxtValidade.Enabled = false;
                                btnSelecionarData1.Enabled = false;
                                lblObservacao.Enabled = false;
                                rtxtObs.Enabled = false;
                                lblQtdeCar.Enabled = false;
                                lblQtdeCar.Enabled = false;
                                rbtnServicos.Enabled = false;
                                grbBox3.Enabled = false;
                                btnNovo.Enabled = true;
                                btnSalvar.Enabled = false;
                                btnCancelar.Visible = false;
                                btnNovo.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do datagridview dtProd.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do datagridview dtProd.");
                            }
                            this.DialogResult = DialogResult.Abort;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorario.Text = null;
                }
            }
            mtxtHorario.BackColor = Color.White;
        }

        private void dtProd_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCapturar_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btnCapturar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCapturar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void Capturar()
        {
            pEnabled.Enabled = false;
            try
            {
                if (bllUsuario.Sel_Capturar_Orcamento_Usuario(_Usuario) == true)
                {
                    using (FrmCapturarOrcamento Orc = new FrmCapturarOrcamento(1, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Orc.ShowDialog() == DialogResult.OK)
                        {
                            bllVenda.Alterar_Orcamento_Orc_PDV(bllVenda._Cod_Orcamento_Orc);
                            //
                            DataRow dr;
                            //
                            dr = bllOrcamento.Sel_Dados_Orcamento(bllVenda._Cod_Orcamento_Orc).Rows[0];
                            //
                            if (cbbCliente.Text != "")
                            {
                                if (dr["id_consumidor"].ToString() != "0")
                                {
                                    MessageBox.Show("Deseja substituir o Cliente/Consumidor do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        //
                                        if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                        {
                                            if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                            {
                                                cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                            }
                                            else
                                            {
                                                cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                {
                                    if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                    {
                                        cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                    }
                                    else
                                    {
                                        cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                    }
                                }
                            }
                            //
                            mtxtValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            if (mtxtValidade.Text != "")
                            {
                                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                if (dr["data_validade"].ToString() != "")
                                {
                                    MessageBox.Show("Deseja substituir a Data de Validade do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        //
                                        mtxtValidade.Text = dr["data_validade"].ToString().Remove(10);
                                        //
                                        mtxtHorario.Text = dr["hora_validade"].ToString();
                                    }
                                    else
                                    {
                                        mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                if (dr["data_validade"].ToString() != "")
                                {
                                    mtxtValidade.Text = dr["data_validade"].ToString().Remove(10);
                                }
                                //
                                mtxtHorario.Text = dr["hora_validade"].ToString();
                            }
                            //
                            if (rtxtObs.Text != "")
                            {
                                if (dr["observacao"].ToString() != "")
                                {
                                    MessageBox.Show("Deseja substituir a Observação do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        //
                                        rtxtObs.Text = dr["observacao"].ToString();
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                rtxtObs.Text = dr["observacao"].ToString();
                            }
                            //
                            if (bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento_Orc) != null)
                            {
                                for (int a = 0; a < bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento_Orc).Rows.Count; a++)
                                {
                                    dr = bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento_Orc).Rows[a];
                                    //
                                    string cod_prod = dr["id_produto"].ToString();
                                    //
                                    if (Convert.ToByte(dr["tabela"]) == 0)
                                    {
                                        if (bllProduto.Sel_Prod_Codigo(cod_prod, "") == null)
                                        {
                                            MessageBox.Show("Código de Produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            bllOrcamento.Salvar_Itens_Orc_Operation_Direto((dtProd.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), dr["UM"].ToString(), dr["valor_unitario"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), bllConexao._Codigo_Conexao);
                                        }
                                        //
                                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                    }
                                    else if (Convert.ToByte(dr["tabela"]) == 1)
                                    {
                                        if (bllServico.Sel_Servico_Codigo(cod_prod, "") == null)
                                        {
                                            MessageBox.Show("Código de Serviço informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            bllOrcamento.Salvar_Itens_Orc_Operation_Direto((dtProd.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), dr["UM"].ToString(), dr["valor_unitario"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), bllConexao._Codigo_Conexao);
                                        }
                                        //
                                        dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                    }
                                }
                            }
                            //
                            dtProd.Select();
                            //
                            txtpCodigo.Text = null;
                            //
                            dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                            //
                            dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                            //
                            dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                        }
                    }
                }
                else
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Capturar_Orcamento"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Capturar_Orcamento == 1)
                            {
                                using (FrmCapturarOrcamento Orc = new FrmCapturarOrcamento(1, _Usuario, _Cod_PDV_Computador))
                                {
                                    if (Orc.ShowDialog() == DialogResult.OK)
                                    {
                                        bllVenda.Alterar_Orcamento_Orc_PDV(bllVenda._Cod_Orcamento_Orc);
                                        //
                                        DataRow dr;
                                        //
                                        dr = bllOrcamento.Sel_Dados_Orcamento(bllVenda._Cod_Orcamento_Orc).Rows[0];
                                        //
                                        if (cbbCliente.Text != "")
                                        {
                                            if (dr["id_consumidor"].ToString() != "0")
                                            {
                                                MessageBox.Show("Deseja substituir o Cliente/Consumidor do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (DialogResult == DialogResult.Yes)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    //
                                                    if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                                    {
                                                        if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                                        {
                                                            cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                                        }
                                                        else
                                                        {
                                                            cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                            {
                                                if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                                {
                                                    cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                                }
                                                else
                                                {
                                                    cbbCliente.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                                }
                                            }
                                        }
                                        //
                                        mtxtValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                        if (mtxtValidade.Text != "")
                                        {
                                            mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                            //
                                            if (dr["data_validade"].ToString() != "")
                                            {
                                                MessageBox.Show("Deseja substituir a Data de Validade do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (DialogResult == DialogResult.Yes)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    //
                                                    mtxtValidade.Text = dr["data_validade"].ToString().Remove(10);
                                                    //
                                                    mtxtHorario.Text = dr["hora_validade"].ToString();
                                                }
                                                else
                                                {
                                                    mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (dr["data_validade"].ToString() != "")
                                            {
                                                mtxtValidade.Text = dr["data_validade"].ToString().Remove(10);
                                            }
                                            //
                                            mtxtHorario.Text = dr["hora_validade"].ToString();
                                        }
                                        //
                                        if (rtxtObs.Text != "")
                                        {
                                            if (dr["observacao"].ToString() != "")
                                            {
                                                MessageBox.Show("Deseja substituir a Observação do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (DialogResult == DialogResult.Yes)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    //
                                                    rtxtObs.Text = dr["observacao"].ToString();
                                                }
                                                else
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            rtxtObs.Text = dr["observacao"].ToString();
                                        }
                                        //
                                        if (bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento_Orc) != null)
                                        {
                                            for (int a = 0; a < bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento_Orc).Rows.Count; a++)
                                            {
                                                dr = bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento_Orc).Rows[a];
                                                //
                                                string cod_prod = dr["id_produto"].ToString();
                                                //
                                                if (Convert.ToByte(dr["tabela"]) == 0)
                                                {
                                                    if (bllProduto.Sel_Prod_Codigo(cod_prod, "") == null)
                                                    {
                                                        MessageBox.Show("Código de Produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        this.DialogResult = DialogResult.None;
                                                    }
                                                    else
                                                    {
                                                        bllOrcamento.Salvar_Itens_Orc_Operation_Direto((dtProd.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), dr["UM"].ToString(), dr["valor_unitario"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), bllConexao._Codigo_Conexao);
                                                    }
                                                    //
                                                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                                }
                                                else if (Convert.ToByte(dr["tabela"]) == 1)
                                                {
                                                    if (bllServico.Sel_Servico_Codigo(cod_prod, "") == null)
                                                    {
                                                        MessageBox.Show("Código de Serviço informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        this.DialogResult = DialogResult.None;
                                                    }
                                                    else
                                                    {
                                                        bllOrcamento.Salvar_Itens_Orc_Operation_Direto((dtProd.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["quantidade"].ToString(), dr["UM"].ToString(), dr["valor_unitario"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), bllConexao._Codigo_Conexao);
                                                    }
                                                    //
                                                    dtProd.DataSource = bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao);
                                                }
                                            }
                                        }
                                        //
                                        dtProd.Select();
                                        //
                                        txtpCodigo.Text = null;
                                        //
                                        dtProd.CurrentCell = dtProd.Rows[dtProd.Rows.Count - 1].Cells[0];
                                        //
                                        dtProd.Rows[dtProd.Rows.Count - 1].Selected = true;
                                        //
                                        dtProd.FirstDisplayedScrollingRowIndex = dtProd.Rows.Count - 1;
                                    }
                                }
                            }
                            else if (bllVenda._Capturar_Orcamento == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para capturar Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnOrcamento.");
                }
            }
            pEnabled.Enabled = true;
        }


        private void btnCapturar_Click(object sender, EventArgs e)
        {
            mtxtValidade.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (dtProd.DataSource != null || cbbCliente.Text != "" || rtxtObs.Text != "" || mtxtHorario.Text != "" || mtxtValidade.Text != "")
            {
                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                DialogResult = MessageBox.Show("Deseja capturar um novo orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    Capturar();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                mtxtValidade.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                Capturar();
            }

        }

        private void dtProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbtnProdutos_CheckedChanged(object sender, EventArgs e)
        {
            rbtnBarra.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rbtnBarra.Visible = false;
            rbtnCodigo.Checked = true;
        }

        private void dtProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 12 && e.Value.ToString() == "0")
            {
                e.Value = "PRODUTO";
            }
            else if (e.ColumnIndex == 12 && e.Value.ToString() == "1")
            {
                e.Value = "SERVICO";
            }
        }

        private void cbbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmInfImpressao Imp = new FrmInfImpressao(50))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        GerarPDF();
                        //
                        string mes;
                        if (DateTime.Now.Month < 10)
                        {
                            mes = "0" + DateTime.Now.Month;
                        }
                        else
                        {
                            mes = DateTime.Now.Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + DateTime.Now.Year + mes + @"\" + _Cod_Orcamento + ".pdf");
                    }
                }
                pEnabled.Enabled = true;
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerar.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnEnviarZap_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbCliente.Text == null || cbbCliente.Text == "")
                {
                    MessageBox.Show("Consumidor não foi informado neste Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    return;
                }
                //
                string[] items = cbbCliente.Text.Split('—');
                //
                DataRow dr = bllClieCons.Sel_Cliente_Codigo(items[0]).Rows[0];
                //
                string nome_consumidor = dr["nome"].ToString();
                //
                string cpfcnpj = dr["cpf_cnpj"].ToString();
                //
                if (cpfcnpj == null || cpfcnpj == "")
                {
                    cpfcnpj = "";
                }
                else
                {
                    cpfcnpj = dr["cpf_cnpj"].ToString();
                }
                //
                string celular;
                if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                {
                    MessageBox.Show("Este consumidor não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //
                    using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (Cel.ShowDialog() == DialogResult.OK)
                        {
                            celular = bllOrcamento._Celular_CadCelular_Tabela;
                        }
                        else
                        {
                            celular = null;
                            return;
                        }
                    }
                }
                else
                {
                    celular = dr["celular"].ToString();
                }
                //
                dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                //
                celular = celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                //
                string complemento = dr["complemento"].ToString();
                //
                if (complemento == null || complemento == "")
                {
                    complemento = "";
                }
                else
                {
                    complemento = dr["complemento"].ToString() + ", ";
                }
                //
                string mensagem = "*ORÇAMENTO*\n\n*" + dr["nome"].ToString() + "*\n" + dr["cpf_cnpj"].ToString() + "\n" + dr["ie_rg"].ToString() + "\n" + dr["endereco"].ToString() + ", " + dr["numero"].ToString() + "\n" + complemento + dr["bairro"].ToString() + "\n" + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + ", " + dr["cep"].ToString() + "\n\n*CLIENTE/CONSUMIDOR*\nNOME:\n" + nome_consumidor + "\nCPF / CNPJ:\n" + cpfcnpj + "\n\n*Itens:*\n";
                //
                for (int linha = 0; linha < bllOrcamento.Sel_Itens_Orcamento_Orc(txtCodigo.Text).Rows.Count; linha++)
                {
                    dr = bllOrcamento.Sel_Itens_Orcamento_Orc(txtCodigo.Text).Rows[linha];
                    //
                    mensagem = mensagem + "\n" + dr["id_item"].ToString() + " - " + dr["descricao"].ToString() + "\n             Qtde.: " + Convert.ToDecimal(dr["quantidade"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + "   -   " + dr["um"].ToString() + " X " + Convert.ToDecimal(dr["valor_unitario"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + "   -   " + Convert.ToDecimal(dr["valor_total"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + "\n                          Desc.: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")) + "  -  Acresc.: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")) + "  -  Vl. Total: " + Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                dr = bllOrcamento.Sel_Orcamento_Codigo(txtCodigo.Text).Rows[0];
                //
                mensagem = mensagem + "\n\nQtde. total de itens: " + Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(txtCodigo.Text).Rows.Count).ToString("D3", new CultureInfo("pt-BR")) + "\nValor Total R$: " + Convert.ToDecimal(dr["valor"]).ToString("n2", new CultureInfo("pt-BR"));
                //
                if (dr["valor_desconto_item"].ToString() != "0" || dr["valor_desconto"].ToString() != "0")
                {
                    mensagem = mensagem + "\nDescontos R$: -" + (Convert.ToDecimal(dr["valor_desconto_item"]) + Convert.ToDecimal(dr["valor_desconto"])).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                if (dr["valor_acrescimo_item"].ToString() != "0" || dr["valor_acrescimo"].ToString() != "0")
                {
                    mensagem = mensagem + "\nAcréscimos R$: " + (Convert.ToDecimal(dr["valor_acrescimo_item"]) + Convert.ToDecimal(dr["valor_acrescimo"])).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                mensagem = mensagem + "\nValor Total Real R$: *" + Convert.ToDecimal(dr["valor_real"]).ToString("n2", new CultureInfo("pt-BR")) + "*";
                //
                mensagem = mensagem + "\nOrçamento nº: *" + txtCodigo.Text + "*   " + dr["data"].ToString().Remove(10) + "   " + dr["hora"].ToString();
                //
                if (dr["data_validade"].ToString() != "")
                {
                    mensagem = mensagem + "\nData e Hora de Validade: " + dr["data_validade"].ToString().Remove(10) + "  " + dr["hora_validade"].ToString();
                }
                //
                mensagem = mensagem + "\n\n*Sistema SEVEN*";
                //
                Clipboard.SetText(mensagem);
                //
                string encodedMessage = HttpUtility.UrlEncode(mensagem);
                //
                string url = $"https://wa.me/55{celular}?text={encodedMessage}";
                //
                bllRegistroAtividades.Salvar("ENVIO DE MENSAGEM WHATSAPP DE ORCAMENTO.", "ORCAMENTO", dr["id_orcamento"].ToString(), _Usuario, _Cod_PDV_Computador);
                //
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarZAP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarZAP.");
                }
            }
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = bllOrcamento.Sel_Orcamento_Codigo(txtCodigo.Text).Rows[0];
                //
                string email;
                //
                if (dr["id_consumidor"].ToString() != "0")
                {
                    if (bllClieCons.Sel_Cliente_Codigo(dr["id_consumidor"].ToString()) == null)
                    {
                        MessageBox.Show("O Cliente/Consumidor não foi encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        email = null;
                    }
                    else
                    {
                        dr = bllClieCons.Sel_Cliente_Codigo(dr["id_consumidor"].ToString()).Rows[0];
                        //
                        if (dr["email"].ToString() == "" || dr["email"].ToString() == null)
                        {
                            MessageBox.Show("O Cliente/Consumidor não possui um e-mail cadastrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            email = null;
                        }
                        else
                        {
                            email = dr["email"].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O Orçamento selecionado não possui nenhum Cliente/Consumidor informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    email = null;
                }
                //
                dr = bllOrcamento.Sel_Orcamento_Codigo(txtCodigo.Text).Rows[0];
                //
                using (FrmInfImpressao Imp = new FrmInfImpressao(50))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        GerarPDF();
                    }
                    else
                    {
                        return;
                    }
                }
                //
                string mes;
                if (DateTime.Now.Month < 10)
                {
                    mes = "0" + DateTime.Now.Month;
                }
                else
                {
                    mes = DateTime.Now.Month.ToString();
                }
                //
                pEnabled.Enabled = false;
                using (FrmUtilEnviarEmail Email = new FrmUtilEnviarEmail(2, _Cod_PDV_Computador, _Usuario, @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(dr["data"]).Year + mes + @"\" + dr["id_orcamento"].ToString() + ".pdf;", "Atenciosamente, " + bllMinhaEmpresa.Sel_Nome_Empresa() + " - " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), "Referente ao orçamento de número " + dr["id_orcamento"].ToString(), email))
                {
                    if (Email.ShowDialog() == DialogResult.Abort)
                    {
                        dtProd.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarEmail.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarEmail.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }
       

        private void cbbCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbCliente.Text != "")
                {
                    string[] items = cbbCliente.Text.Split('—');
                    /*
                    if ((cbbCliente.Text.Split('—').Length - 1) == 1)
                    {
                        MessageBox.Show("Não é possível selecionar um consumidor sem CPF/CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbCliente.Text = null;
                    }
                    else 
                    */
                    if (bllClieCons.Sel_Situacao_Cliente_Bloqueado(items[0], "BLOQUEADO") == true)
                    {
                        MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbCliente.Text = null;
                    }
                    else
                    {
                        if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                        {
                            if (bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]) != "")
                            {
                                MessageBox.Show(bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]), "Informação de Observação do Consumidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbCliente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbCliente.");
                }
                cbbCliente.Text = null;
            }
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();
            }
        }

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/200";
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnCodigo.Checked == true)
                {
                    txtpCodigo.Select();
                }
                else
                {
                    txtpBarra.Select();
                }
            }
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                rtxtObs.Text = null;
            }
            rtxtObs.BackColor = Color.White;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text.Replace("R$ ", ""), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCliente.Select();
            }
        }
    }
}
