using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmConsultarItem : Form
    {
        public FrmConsultarItem(string codigo, byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Codigo = codigo;
        }

        string _Codigo;
        byte _Formulario;

        private void FrmConsultarItemVenda_Load(object sender, EventArgs e)
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

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConsultarItemVenda iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConsultarItemVenda iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    if (bllVenda.Sel_Itens_Venda_Venda(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem item(s) para esta Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllVenda.Sel_Itens_Venda_Venda(_Codigo);
                        dtitem.Select();
                    }
                }
                else if (_Formulario == 1)
                {
                    lblItem.Text = "Item(ns) Devolvido(s)";
                    if (bllDevolucao.Sel_Itens_Devolucao(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem itens para esta Devolução/Troca.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllDevolucao.Sel_Itens_Devolucao(_Codigo);
                        dtitem.Select();
                    }
                }
                else if (_Formulario == 2)
                {
                    lblItem.Text = "Novo(s) Item(ns) Incluído(s)";
                    if (bllDevolucao.Sel_Itens_Prod_Devolucao(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem novo(s) item(ns) incluído(s) para esta Devolução/Troca.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllDevolucao.Sel_Itens_Prod_Devolucao(_Codigo);
                        dtitem.Select();
                    }
                }
                else if (_Formulario == 3)
                {
                    if (bllOrcamento.Sel_Itens_Orcamento_Orc(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem item(ns) para este Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllOrcamento.Sel_Itens_Orcamento_Orc(_Codigo);
                        dtitem.Select();
                    }
                }
                else if (_Formulario == 4)
                {
                    if (bllDFe.Sel_Items_DFe(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem item(ns) para este DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllDFe.Sel_Items_DFe(_Codigo);
                        dtitem.Select();
                    }
                }
                else if (_Formulario == 5)
                {
                    this.Text = "Consultar Transportadora";
                    lblItem.Text = "Transportador(a)";
                    if (bllTransportador.Sel_Dados_Transportador(_Codigo) == null)
                    {
                        MessageBox.Show("Não existe Transportadora para este DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllTransportador.Sel_Dados_Transportador(_Codigo);
                        dtitem.Select();
                    }
                    ttpConsultarPagamento.SetToolTip(btnVoltar, "Sair de Consultar Transportadora");
                }
                else if (_Formulario == 6)
                {
                    this.Text = "Consultar Referências";
                    lblItem.Text = "DFe Referenciados";
                    if (bllDFe.Sel_Referencia_DFe(_Codigo) == null)
                    {
                        MessageBox.Show("Não existe Referência para este DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllDFe.Sel_Referencia_DFe(_Codigo);
                        dtitem.Select();
                    }
                    ttpConsultarPagamento.SetToolTip(btnVoltar, "Sair de Consultar Referência");
                }
                else if (_Formulario == 7)
                {
                    if (bllOS.Sel_Item_Servico_Todos(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem Serviços(s) para esta Ordem de Serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllOS.Sel_Item_Servico_Todos(_Codigo);
                        dtitem.Select();
                    }
                    //
                    this.Text = "Consultar Serviços";
                    lblItem.Text = "Serviço(s)";
                }
                else if (_Formulario == 8)
                {
                    if (bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem Funcionário(s) para esta Ordem de Serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo);
                        dtitem.Select();
                    }
                    //
                    this.Text = "Consultar Funcionários";
                    lblItem.Text = "Funcionário(s)";
                }
                else if (_Formulario == 9)
                {
                    if (bllOS.Sel_Item_OS_Produto_Todos(_Codigo) == null)
                    {
                        MessageBox.Show("Não existem Produto(s) para esta Ordem de Serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        dtitem.DataSource = bllOS.Sel_Item_OS_Produto_Todos(_Codigo);
                        dtitem.Select();
                    }
                    //
                    this.Text = "Consultar Produtos";
                    lblItem.Text = "Produto(s)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConsultarItemVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConsultarItemVenda.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtitem_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";
                    dtitem.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[3].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[5].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[6].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[7].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[8].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[9].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[10].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[11].DefaultCellStyle.Format = "n2";

                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (_Formulario == 1)
                {
                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";
                    dtitem.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[3].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[5].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[6].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[7].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[8].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[9].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[10].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[11].DefaultCellStyle.Format = "n2";

                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (_Formulario == 2)
                {
                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";
                    dtitem.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[3].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[5].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[6].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[7].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[8].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[9].DefaultCellStyle.Format = "n2";

                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (_Formulario == 3)
                {
                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";
                    dtitem.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[3].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[5].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[6].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[7].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[8].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[9].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[10].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[11].DefaultCellStyle.Format = "n2";

                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (_Formulario == 4)
                {
                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;

                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";
                    dtitem.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[4].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[5].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[6].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[7].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[8].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[9].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[11].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[12].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[13].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[14].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[20].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[21].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[22].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[23].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[24].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[25].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[25].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[26].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[27].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[28].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[31].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[31].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[32].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[32].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[33].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[33].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[34].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[34].DefaultCellStyle.Format = "n2";
                }
                else if (_Formulario == 5)
                {
                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;

                    dtitem.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[13].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[14].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[15].DefaultCellStyle.Format = "n2";
                }
                else if (_Formulario == 6)
                {
                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else  if (_Formulario == 7)
                {
                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";
                    dtitem.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[3].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[4].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[5].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[8].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[9].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[10].DefaultCellStyle.Format = "n2";

                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (_Formulario == 8)
                {
                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";

                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (_Formulario == 9)
                {
                    dtitem.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[0].DefaultCellStyle.Format = "D3";
                    dtitem.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[3].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[5].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[6].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[7].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[8].DefaultCellStyle.Format = "n2";
                    dtitem.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtitem.Columns[9].DefaultCellStyle.Format = "n2";

                    dtitem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dtitem.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtitem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtitem.");
                }
            }
        }

        private void dtitem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_Formulario == 0)
            {
                dtitem.Columns[0].HeaderText = "Item";
                dtitem.Columns[1].HeaderText = "Cód. do Produto";
                dtitem.Columns[2].HeaderText = "Descrição";
                dtitem.Columns[3].HeaderText = "Quantidade";
                dtitem.Columns[4].HeaderText = "UN";
                dtitem.Columns[5].HeaderText = "Valor Unitário (R$)";
                dtitem.Columns[6].HeaderText = "Valor do Item (R$)";
                dtitem.Columns[7].HeaderText = "Valor do Desconto (R$)";
                dtitem.Columns[8].HeaderText = "Valor do Acréscimo (R$)";
                dtitem.Columns[9].HeaderText = "Valor do Desconto Item (R$)";
                dtitem.Columns[10].HeaderText = "Valor do Acréscimo Item (R$)";
                dtitem.Columns[11].HeaderText = "Valor Total do Item (R$)";
                dtitem.Columns[12].HeaderText = "Tipo/Tabela";

                dtitem.Columns[0].Width = 56;
                dtitem.Columns[1].Width = 125;
                dtitem.Columns[2].Width = 357;
                dtitem.Columns[3].Width = 125;
                dtitem.Columns[4].Width = 56;
                dtitem.Columns[5].Width = 125;
                dtitem.Columns[6].Width = 125;
                dtitem.Columns[7].Width = 145;
                dtitem.Columns[8].Width = 145;
                dtitem.Columns[9].Width = 185;
                dtitem.Columns[10].Width = 185;
                dtitem.Columns[11].Width = 150;
                dtitem.Columns[12].Width = 150;

                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 1)
            {
                dtitem.Columns[0].HeaderText = " Item";
                dtitem.Columns[1].HeaderText = "  Código";
                dtitem.Columns[2].HeaderText = "Descrição";
                dtitem.Columns[3].HeaderText = "  Qtd.";
                dtitem.Columns[4].HeaderText = " UN.";
                dtitem.Columns[5].HeaderText = "Vl. Unit (R$)";
                dtitem.Columns[6].HeaderText = "Vl. Item (R$)";
                dtitem.Columns[7].HeaderText = "Vl. do Desc. - (R$)";
                dtitem.Columns[8].HeaderText = "Vl. do Acrésc. + (R$)";
                dtitem.Columns[9].HeaderText = "Vl. do Desc. Item - (R$)";
                dtitem.Columns[10].HeaderText = "Vl. do Acrésc. Item + (R$)";
                dtitem.Columns[11].HeaderText = "Valor Total Após Desc. e Acresc. (R$)";
                //
                dtitem.Columns[0].Width = 56;
                dtitem.Columns[1].Width = 78;
                dtitem.Columns[2].Width = 358;
                dtitem.Columns[3].Width = 70;
                dtitem.Columns[4].Width = 56;
                dtitem.Columns[5].Width = 95;
                dtitem.Columns[6].Width = 95;
                dtitem.Columns[7].Width = 125;
                dtitem.Columns[8].Width = 135;
                dtitem.Columns[9].Width = 145;
                dtitem.Columns[10].Width = 155;
                dtitem.Columns[11].Width = 220;
                //
                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 2)
            {
                dtitem.Columns[0].HeaderText = " Item";
                dtitem.Columns[1].HeaderText = "  Código";
                dtitem.Columns[2].HeaderText = "Descrição";
                dtitem.Columns[3].HeaderText = "  Qtd.";
                dtitem.Columns[4].HeaderText = " UN.";
                dtitem.Columns[5].HeaderText = "Vl. Unit (R$)";
                dtitem.Columns[6].HeaderText = "Vl. Item (R$)";
                dtitem.Columns[7].HeaderText = "Vl. do Desc. Item - (R$)";
                dtitem.Columns[8].HeaderText = "Vl. do Acrésc. Item + (R$)";
                dtitem.Columns[9].HeaderText = "Valor Total Após Desc. e Acresc. (R$)";
                //
                dtitem.Columns[0].Width = 56;
                dtitem.Columns[1].Width = 78;
                dtitem.Columns[2].Width = 358;
                dtitem.Columns[3].Width = 70;
                dtitem.Columns[4].Width = 56;
                dtitem.Columns[5].Width = 95;
                dtitem.Columns[6].Width = 95;
                dtitem.Columns[7].Width = 145;
                dtitem.Columns[8].Width = 155;
                dtitem.Columns[9].Width = 210;
                //
                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 3)
            {
                dtitem.Columns[0].HeaderText = "Item";
                dtitem.Columns[1].HeaderText = "Cód. do Produto";
                dtitem.Columns[2].HeaderText = "Descrição";
                dtitem.Columns[3].HeaderText = "Quantidade";
                dtitem.Columns[4].HeaderText = "UN";
                dtitem.Columns[5].HeaderText = "Valor Unitário (R$)";
                dtitem.Columns[6].HeaderText = "Valor do Item (R$)";
                dtitem.Columns[7].HeaderText = "Valor do Desconto (R$)";
                dtitem.Columns[8].HeaderText = "Valor do Acréscimo (R$)";
                dtitem.Columns[9].HeaderText = "Valor do Desconto Item (R$)";
                dtitem.Columns[10].HeaderText = "Valor do Acréscimo Item (R$)";
                dtitem.Columns[11].HeaderText = "Valor Total do Item (R$)";
                dtitem.Columns[12].HeaderText = "Tabela";
                dtitem.Columns[13].Visible = false;

                dtitem.Columns[0].Width = 56;
                dtitem.Columns[1].Width = 125;
                dtitem.Columns[2].Width = 357;
                dtitem.Columns[3].Width = 125;
                dtitem.Columns[4].Width = 56;
                dtitem.Columns[5].Width = 125;
                dtitem.Columns[6].Width = 125;
                dtitem.Columns[7].Width = 145;
                dtitem.Columns[8].Width = 145;
                dtitem.Columns[9].Width = 185;
                dtitem.Columns[10].Width = 185;
                dtitem.Columns[11].Width = 150;
                dtitem.Columns[12].Width = 150;

                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 4)
            {
                dtitem.Columns[0].HeaderText = "Item";
                dtitem.Columns[1].HeaderText = "Cód. do Produto";
                dtitem.Columns[2].HeaderText = "Descrição";
                dtitem.Columns[3].HeaderText = "UM.";
                dtitem.Columns[4].HeaderText = "Quantidade";
                dtitem.Columns[5].HeaderText = "Quant. da Emb.";
                dtitem.Columns[6].HeaderText = "Valor Unitário (R$)";
                dtitem.Columns[7].HeaderText = "Valor do Item (R$)";
                dtitem.Columns[8].HeaderText = "Valor do Desconto (R$)";
                dtitem.Columns[9].HeaderText = "Valor do Acréscimo (R$)";
                dtitem.Columns[10].HeaderText = "CST";
                dtitem.Columns[11].HeaderText = "Alíquota ICMS (%)";
                dtitem.Columns[12].HeaderText = "Valor do ICMS (R$)";
                dtitem.Columns[13].HeaderText = "Valor da Base de Cálculo (R$)";
                dtitem.Columns[14].HeaderText = "Valor Total (R$)";
                dtitem.Columns[15].HeaderText = "CSOSN";
                dtitem.Columns[16].HeaderText = "CFOP";
                dtitem.Columns[17].HeaderText = "NCM";
                dtitem.Columns[18].HeaderText = "CEST";
                dtitem.Columns[19].Visible = false;
                dtitem.Columns[20].HeaderText = "Alíquota ST (%)";
                dtitem.Columns[21].HeaderText = "Base de Cálculo ST";
                dtitem.Columns[22].HeaderText = "MVA (%)";
                dtitem.Columns[23].HeaderText = "Redução BC ST (%)";
                dtitem.Columns[24].HeaderText = "ICMS ST";
                if (_Formulario == 0)
                {
                    dtitem.Columns[25].Visible = false;
                }
                else
                {
                    dtitem.Columns[25].HeaderText = "Total Aprox. dos Trib.";
                }
                dtitem.Columns[26].HeaderText = "Alíquota IPI (%)";
                dtitem.Columns[27].HeaderText = "IPI";
                dtitem.Columns[28].HeaderText = "Redução BC ST (%)";
                dtitem.Columns[29].HeaderText = "CST IBS/CBS";
                dtitem.Columns[30].HeaderText = "Cód. Sit. Trib. (cClassTrib)";
                dtitem.Columns[31].HeaderText = "Alíq. IBS Mun. (%)";
                dtitem.Columns[32].HeaderText = "Alíq. IBS Est. (%)";
                dtitem.Columns[33].HeaderText = "Alíq. CBS (%)";
                dtitem.Columns[34].HeaderText = "Valor Frete (R$)";

                dtitem.Columns[0].Width = 55;
                dtitem.Columns[1].Width = 120;
                dtitem.Columns[2].Width = 255;
                dtitem.Columns[3].Width = 46;
                dtitem.Columns[4].Width = 95;
                dtitem.Columns[5].Width = 150;
                dtitem.Columns[6].Width = 135;
                dtitem.Columns[7].Width = 150;
                dtitem.Columns[8].Width = 150;
                dtitem.Columns[9].Width = 150;
                dtitem.Columns[10].Width = 85;
                dtitem.Columns[11].Width = 150;
                dtitem.Columns[12].Width = 150;
                dtitem.Columns[13].Width = 200;
                dtitem.Columns[14].Width = 150;
                dtitem.Columns[15].Width = 85;
                dtitem.Columns[16].Width = 85;
                dtitem.Columns[17].Width = 120;
                dtitem.Columns[18].Width = 120;
                dtitem.Columns[20].Width = 150;
                dtitem.Columns[21].Width = 150;
                dtitem.Columns[22].Width = 150;
                dtitem.Columns[23].Width = 150;
                dtitem.Columns[24].Width = 150;
                dtitem.Columns[25].Width = 170;
                dtitem.Columns[26].Width = 150;
                dtitem.Columns[27].Width = 150;
                dtitem.Columns[28].Width = 150;
                dtitem.Columns[29].Width = 125;
                dtitem.Columns[30].Width = 175;
                dtitem.Columns[31].Width = 125;
                dtitem.Columns[32].Width = 125;
                dtitem.Columns[33].Width = 110;
                dtitem.Columns[34].Width = 150;

                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 5)
            {
                dtitem.Columns[0].Visible = false;
                dtitem.Columns[1].HeaderText = "Tipo de Transporte";
                dtitem.Columns[2].HeaderText = "Tipo de Frete";
                dtitem.Columns[3].HeaderText = "Cód. do Transportador";
                dtitem.Columns[4].HeaderText = "Nome do Transportador";
                dtitem.Columns[5].HeaderText = "Veículo";
                dtitem.Columns[6].HeaderText = "Código Antt";
                dtitem.Columns[7].HeaderText = "Placa";
                dtitem.Columns[8].HeaderText = "UF";
                dtitem.Columns[9].HeaderText = "Espécie";
                dtitem.Columns[10].HeaderText = "Marca";
                dtitem.Columns[11].HeaderText = "Quantidade";
                dtitem.Columns[12].HeaderText = "Númeração";
                dtitem.Columns[13].HeaderText = "Peso Bruto";
                dtitem.Columns[14].HeaderText = "Peso Liquido";
                dtitem.Columns[15].HeaderText = "Valor Frete";


                dtitem.Columns[1].Width = 200;
                dtitem.Columns[2].Width = 200;
                dtitem.Columns[3].Width = 150;
                dtitem.Columns[4].Width = 325;
                dtitem.Columns[5].Width = 150;
                dtitem.Columns[6].Width = 150;
                dtitem.Columns[7].Width = 150;
                dtitem.Columns[8].Width = 55;
                dtitem.Columns[9].Width = 150;
                dtitem.Columns[10].Width = 200;
                dtitem.Columns[11].Width = 150;
                dtitem.Columns[12].Width = 150;
                dtitem.Columns[13].Width = 150;
                dtitem.Columns[14].Width = 150;
                dtitem.Columns[15].Width = 150;

                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 6)
            {
                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;

                dtitem.Columns[0].HeaderText = "Código";
                dtitem.Columns[1].HeaderText = "Item";
                dtitem.Columns[2].HeaderText = "Chave";

                dtitem.Columns[0].Width = 100;
                dtitem.Columns[1].Width = 80;
                dtitem.Columns[2].Width = 601;

                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);
            }
            else if (_Formulario == 7)
            {
                dtitem.Columns[0].HeaderText = "Item";
                dtitem.Columns[1].HeaderText = "Cód. do Produto";
                dtitem.Columns[2].HeaderText = "Descrição";
                dtitem.Columns[3].HeaderText = "Quantidade";
                dtitem.Columns[4].HeaderText = "Valor Unitário (R$)";
                dtitem.Columns[5].HeaderText = "Valor do Item (R$)";
                dtitem.Columns[6].Visible = false;
                dtitem.Columns[7].Visible = false;
                dtitem.Columns[8].HeaderText = "Valor do Desconto Item (R$)";
                dtitem.Columns[9].HeaderText = "Valor do Acréscimo Item (R$)";
                dtitem.Columns[10].HeaderText = "Valor Total do Item (R$)";
                dtitem.Columns[11].Visible = false;

                dtitem.Columns[0].Width = 56;
                dtitem.Columns[1].Width = 125;
                dtitem.Columns[2].Width = 357;
                dtitem.Columns[3].Width = 125;
                dtitem.Columns[4].Width = 125;
                dtitem.Columns[5].Width = 125;
                dtitem.Columns[8].Width = 185;
                dtitem.Columns[9].Width = 185;
                dtitem.Columns[10].Width = 185;

                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 8)
            {
                dtitem.Columns[0].HeaderText = "Item";
                dtitem.Columns[1].HeaderText = "Cód. do Funcionário";
                dtitem.Columns[2].HeaderText = "Nome do Funcionário";

                dtitem.Columns[0].Width = 56;
                dtitem.Columns[1].Width = 125;
                dtitem.Columns[2].Width = 600;
                dtitem.Columns[3].Visible = false;

                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }
            else if (_Formulario == 9)
            {
                dtitem.Columns[0].HeaderText = " Item";
                dtitem.Columns[1].HeaderText = "  Código";
                dtitem.Columns[2].HeaderText = "Descrição";
                dtitem.Columns[3].HeaderText = "  Qtd.";
                dtitem.Columns[4].HeaderText = " UN.";
                dtitem.Columns[5].HeaderText = "Vl. Unit (R$)";
                dtitem.Columns[6].HeaderText = "Vl. Item (R$)";
                dtitem.Columns[7].HeaderText = "Vl. do Desc. Item - (R$)";
                dtitem.Columns[8].HeaderText = "Vl. do Acrésc. Item + (R$)";
                dtitem.Columns[9].HeaderText = "Valor Total Após Desc. e Acresc. (R$)";
                dtitem.Columns[10].Visible = false;
                dtitem.Columns[11].Visible = false;
                //
                dtitem.Columns[0].Width = 56;
                dtitem.Columns[1].Width = 78;
                dtitem.Columns[2].Width = 358;
                dtitem.Columns[3].Width = 70;
                dtitem.Columns[4].Width = 56;
                dtitem.Columns[5].Width = 95;
                dtitem.Columns[6].Width = 95;
                dtitem.Columns[7].Width = 145;
                dtitem.Columns[8].Width = 155;
                dtitem.Columns[9].Width = 220;
                //
                dtitem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtitem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtitem.DefaultCellStyle.Font = new Font(dtitem.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtitem.Rows.Count;
            }

        }

        private void dtitem_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtitem.DataSource != null)
            {
                dtitem.Enabled = true;
            }
            else
            {
                dtitem.Enabled = false;
            }
        }

        private void FrmConsultarItemVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtitem_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtitem.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtitem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtitem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
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

        private void FrmConsultarItemVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConsultarItemVenda foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConsultarItemVenda foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmConsultarItemVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmConsultarItemVenda.");
                }
            }
        }

        private void dtitem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_Formulario == 4)
            {
                if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
                {
                    e.Value = "";
                }
            }
            else if (_Formulario == 3)
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
        }
    }
}
