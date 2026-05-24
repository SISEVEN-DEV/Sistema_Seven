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
    public partial class FrmPesqServico : Form
    {
        public FrmPesqServico(byte formulario, string usuario, string cod_pdv_computador, int item)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Item = item.ToString();
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Item;

        private void FrmpesqServico_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqServico iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqServico iniciado.");
                }
                rbtnDescricao.Checked = true;
                //
                if (bllUsuario.Sel_Permitir_Cadastrar_PDV_Usuario(_Usuario) == true)
                {
                    btnCadastrar.Visible = true;
                }
                else
                {
                    btnCadastrar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmpesqServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmpesqServico.");
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
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

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
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

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            lblSubGrupo1.Visible = false;
            cbbpGrupo.Visible = false;
            cbbpSubGrupo.Visible = false;
            btnpProcurarSub1.Visible = false;
            cbbpItemServico.Visible = false;
            btnpProcurarServico.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(314, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblSubGrupo1.Visible = false;
            cbbpGrupo.Visible = false;
            cbbpSubGrupo.Visible = false;
            btnpProcurarSub1.Visible = false;
            cbbpItemServico.Visible = false;
            btnpProcurarServico.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(486, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblSubGrupo1.Visible = false;
            cbbpGrupo.Visible = false;
            cbbpSubGrupo.Visible = false;
            btnpProcurarSub1.Visible = false;
            cbbpItemServico.Visible = false;
            btnpProcurarServico.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(538, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            btnPesquisar.Select();
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, item de serviço, grupo, subgrupo e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmpesqServico_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmpesqServico foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmpesqServico foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqServico.");
                }
            }
        }

        private void FrmPesqServico_KeyUp(object sender, KeyEventArgs e)
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
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllServico.Sel_Servico_Descricao(txtpDescricao.Text, "ATIVO") == null)
                        {
                            dtServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtServico.DataSource = bllServico.Sel_Servico_Descricao(txtpDescricao.Text, "ATIVO");
                            dtServico.Select();
                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    if (cbbpGrupo.Text != "")
                    {
                        if (cbbpGrupo.Text != "" && cbbpSubGrupo.Text == "")
                        {
                            if (bllServico.Sel_Serv_Grupo(cbbpGrupo.Text, "ATIVO") == null)
                            {
                                dtServico.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtServico.DataSource = bllServico.Sel_Serv_Grupo(cbbpGrupo.Text, "ATIVO");
                                dtServico.Select();
                            }
                        }
                        else
                        {
                            if (bllServico.Sel_Serv_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "ATIVO") == null)
                            {
                                dtServico.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtServico.DataSource = bllServico.Sel_Serv_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "ATIVO");
                                dtServico.Select();
                            }
                        }
                    }
                }
                else if (rbtnItemServico.Checked == true)
                {
                    if (cbbpItemServico.Text != "")
                    {
                        if (bllServico.Sel_Servico_Item_Servico(cbbpItemServico.Text, "ATIVO") == null)
                        {
                            dtServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtServico.DataSource = bllServico.Sel_Servico_Item_Servico(cbbpItemServico.Text, "ATIVO");
                            dtServico.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "ATIVO") == null)
                        {
                            dtServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtServico.DataSource = bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "ATIVO");
                            dtServico.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllServico.Sel_Servico_Todos("ATIVO") == null)
                    {
                        dtServico.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtServico.DataSource = bllServico.Sel_Servico_Todos("ATIVO");
                        dtServico.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou servico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou servico.");
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
                dtServico.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtServico_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtServico.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtServico.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtServico.Enabled = true;
            }
        }

        private void dtServico_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtServico.Columns[0].HeaderText = "Código";
            dtServico.Columns[1].HeaderText = "Descrição";
            dtServico.Columns[2].HeaderText = "Preço (R$)";
            dtServico.Columns[3].HeaderText = "Cód. Item de Serviço";
            dtServico.Columns[4].HeaderText = "Descrição de Serviço";
            dtServico.Columns[5].HeaderText = "Alíquota (%)";
            dtServico.Columns[6].HeaderText = "Comissão (%)";
            dtServico.Columns[7].HeaderText = "Acréscimo (%)";
            dtServico.Columns[8].HeaderText = "Desconto (%)";
            dtServico.Columns[9].HeaderText = "Cód. do Grupo";
            dtServico.Columns[10].HeaderText = "Descrição do Grupo";
            dtServico.Columns[11].HeaderText = "Cód. do Subgrupo";
            dtServico.Columns[12].HeaderText = "Descrição do Subgrupo";
            dtServico.Columns[13].HeaderText = "Situação";
            dtServico.Columns[14].Visible = false;


            dtServico.Columns[0].Width = 95;
            dtServico.Columns[1].Width = 390;
            dtServico.Columns[2].Width = 113;
            dtServico.Columns[3].Width = 165;
            dtServico.Columns[4].Width = 500;
            dtServico.Columns[5].Width = 113;
            dtServico.Columns[6].Width = 113;
            dtServico.Columns[7].Width = 113;
            dtServico.Columns[8].Width = 113;
            dtServico.Columns[9].Width = 150;
            dtServico.Columns[10].Width = 250;
            dtServico.Columns[11].Width = 150;
            dtServico.Columns[12].Width = 250;
            dtServico.Columns[13].Width = 110;

            dtServico.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtServico.DefaultCellStyle.Font = new Font(dtServico.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtServico.Rows.Count;
        }

        private void dtServico_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtServico.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtServico.DefaultCellStyle.SelectionForeColor = Color.Black;
            //
            dtServico.Columns[2].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[2].DefaultCellStyle.Format = "n2";
            dtServico.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[5].DefaultCellStyle.Format = "n2";
            dtServico.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[6].DefaultCellStyle.Format = "n2";
            dtServico.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[7].DefaultCellStyle.Format = "n2";
            dtServico.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[8].DefaultCellStyle.Format = "n2";
        }

        private void dtServico_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtServico_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtServico.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    //
                    using (FrmQuantidade Qtde = new FrmQuantidade(0, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    //
                    using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            bllOrcamento.Salvar_Itens_Orc_Operation(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), bllOrcamento._Quantidade, "UN", SelectedRow.Cells[2].Value.ToString(), "0", "0", bllConexao._Codigo_Conexao, 1);
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    //
                    bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    btnIncluir.Select();
                    //
                    bllOrcamento._Orc_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    btnIncluir.Select();
                    //
                    bllSaidasProdutos._Saidas_Prod_PesqServ_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    btnIncluir.Select();
                    //
                    bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
            }
        }

        private void dtServico_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    //
                    using (FrmQuantidade Qtde = new FrmQuantidade(0, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    //
                    using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            bllOrcamento.Salvar_Itens_Orc_Operation(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), bllOrcamento._Quantidade, "UN", SelectedRow.Cells[2].Value.ToString(), "0", "0", bllConexao._Codigo_Conexao, 1);
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    //
                    bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    btnIncluir.Select();
                    //
                    bllOrcamento._Orc_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    btnIncluir.Select();
                    //
                    bllSaidasProdutos._Saidas_Prod_PesqServ_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    btnIncluir.Select();
                    //
                    bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
            }
        }

        private void dtServico_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
                    //
                    if (_Formulario == 0)
                    {
                        btnIncluir.Select();
                        //
                        using (FrmQuantidade Qtde = new FrmQuantidade(0, "1,00"))
                        {
                            if (Qtde.ShowDialog() == DialogResult.OK)
                            {
                                bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        btnIncluir.Select();
                        //
                        using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                        {
                            if (Qtde.ShowDialog() == DialogResult.OK)
                            {
                                bllOrcamento.Salvar_Itens_Orc_Operation(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), bllOrcamento._Quantidade, "UN", SelectedRow.Cells[2].Value.ToString(), "0", "0", bllConexao._Codigo_Conexao, 1);
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        btnIncluir.Select();
                        //
                        bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                        //
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 3)
                    {
                        btnIncluir.Select();
                        //
                        bllOrcamento._Orc_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString() + "—" + SelectedRow.Cells[8].Value.ToString();
                        //
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 4)
                    {
                        btnIncluir.Select();
                        //
                        bllSaidasProdutos._Saidas_Prod_PesqServ_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        //
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 5)
                    {
                        btnIncluir.Select();
                        //
                        bllOS._Servico_PesqServico_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        //
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
            }
        }

        private void btnCadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Cadastrar_Servico(_Usuario) == true)
                {
                    using (FrmCadServico Prod = new FrmCadServico(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (Prod.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllServico.Sel_Servico_Codigo(bllServico._Cod_Servico_Cadastro, "ATIVO") == null)
                            {
                                dtServico.DataSource = null;
                            }
                            else
                            {
                                dtServico.DataSource = bllServico.Sel_Servico_Codigo(bllServico._Cod_Servico_Cadastro, "ATIVO");
                                dtServico.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        bllServico._Cod_Servico_Cadastro = null;
                    }
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Serviços.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
            }
            this.Enabled = true;
        }

        private void dtServico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void rbtnItemServico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblSubGrupo1.Visible = false;
                ttpServico.SetToolTip(btnpProcurarServico, "Clique para pesquisar um Item de Serviço.");
                cbbpGrupo.Visible = false;
                cbbpSubGrupo.Visible = false;
                btnpProcurarSub1.Visible = false;
                btnpProcurarServico.Visible = true;
                lblPesquisar.Text = "Escolha o item de serviço:";
                lblPesquisar.Location = new Point(271, 21);
                txtpCodigo.Visible = false;
                txtpDescricao.Visible = false;
                txtpDescricao.Text = null;
                cbbpItemServico.Visible = true;
                cbbpItemServico.Select();
                cbbpItemServico.Items.Clear();
                //
                if (bllServico.Sel_Item_Servico_Serv() == null)
                {
                    cbbpItemServico.Text = null;
                }
                else
                {
                    cbbpItemServico.Items.Add("");
                    foreach (DataRow dr in bllServico.Sel_Item_Servico_Serv().Rows)
                    {
                        cbbpItemServico.Items.Add(dr["ncm"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
            }
        }

        private void btnpProcurarServico_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (rbtnItemServico.Checked == true)
                {
                    using (FrmPesqItemServico ItemServico = new FrmPesqItemServico(null))
                    {
                        if (ItemServico.ShowDialog() == DialogResult.OK)
                        {
                            cbbpItemServico.Items.Clear();
                            if (bllServico.Sel_Item_Servico_Serv() == null)
                            {
                                cbbpItemServico.Text = null;
                            }
                            else
                            {
                                cbbpItemServico.Items.Add("");
                                foreach (DataRow dr in bllServico.Sel_Item_Servico_Serv().Rows)
                                {
                                    cbbpItemServico.Items.Add(dr["ncm"].ToString() + "—" + dr["descricao"].ToString());
                                }
                            }
                            //
                            cbbpItemServico.Text = bllServico._ItemServico_PesqItemServico_Tabela;
                            bllServico._ItemServico_PesqItemServico_Tabela = null;
                            cbbpItemServico.Select();

                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    using (FrmPesqGrupo Grupo = new FrmPesqGrupo(6))
                    {
                        if (Grupo.ShowDialog() == DialogResult.OK)
                        {
                            cbbpGrupo.Items.Clear();
                            if (bllServico.Sel_Grupo_Serv() == null)
                            {
                                cbbpGrupo.Text = null;
                                cbbpSubGrupo.Enabled = false;
                                cbbpSubGrupo.Text = null;
                                btnpProcurarSub1.Enabled = false;
                                lblSubGrupo1.Enabled = false;
                            }
                            else
                            {
                                cbbpGrupo.Items.Add("");
                                foreach (DataRow dr in bllServico.Sel_Grupo_Serv().Rows)
                                {
                                    cbbpGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                                    cbbpSubGrupo.Enabled = true;
                                    btnpProcurarSub1.Enabled = true;
                                    lblSubGrupo1.Enabled = true;
                                }
                            }
                            cbbpGrupo.Text = bllServico._Grupo_PesqGrupo_Tabela;
                            bllServico._Grupo_PesqGrupo_Tabela = null;
                            cbbpGrupo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurarServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurarServico.");
                }
                cbbpItemServico.Text = null;
            }
            this.Enabled = true;
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void rbtnGrupo_CheckedChanged(object sender, EventArgs e)
        {
            lblSubGrupo1.Visible = true;
            ttpServico.SetToolTip(btnpProcurarServico, "Clique para pesquisar um Grupo.");
            cbbpGrupo.Visible = true;
            cbbpSubGrupo.Visible = true;
            btnpProcurarSub1.Visible = true;
            btnpProcurarServico.Visible = true;
            lblPesquisar.Text = "Escolha o grupo:";
            lblPesquisar.Location = new Point(289, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpDescricao.Text = null;
            cbbpItemServico.Visible = false;
            cbbpGrupo.Select();
            cbbpGrupo.Items.Clear();
            //
            try
            {
                cbbpGrupo.Items.Clear();
                cbbpSubGrupo.Items.Clear();
                if (bllServico.Sel_Grupo_Serv() == null)
                {
                    cbbpGrupo.Text = null;
                }
                else
                {
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllServico.Sel_Grupo_Serv().Rows)
                    {
                        cbbpGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
            }
        }

        private void cbbpGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.SelectedItem.ToString().Split('—');
                    cbbpSubGrupo.Items.Clear();
                    if (bllServico.Sel_SubGrupo_Serv(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnpProcurarSub1.Enabled = false;
                        lblSubGrupo1.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllServico.Sel_SubGrupo_Serv(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                            cbbpSubGrupo.Enabled = true;
                            btnpProcurarSub1.Enabled = true;
                            lblSubGrupo1.Enabled = true;
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnpProcurarSub1.Enabled = false;
                    lblSubGrupo1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void btnpProcurarSub1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 4))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();
                            if (bllServico.Sel_SubGrupo_Serv(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllServico.Sel_SubGrupo_Serv(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                            }
                            cbbpSubGrupo.Text = bllServico._SubGrupo_PesqSubGrupo_Tabela;
                            bllServico._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbpSubGrupo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                cbbpSubGrupo.Text = null;
            }
            this.Enabled = true;
        }

        private void grbBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
