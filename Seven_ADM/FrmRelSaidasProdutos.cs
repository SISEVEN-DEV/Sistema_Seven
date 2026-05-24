using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelSaidasProdutos : Form
    {
        public FrmRelSaidasProdutos(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = 0;
        }

        public FrmRelSaidasProdutos(string usuario, string cod_pdv_computador, string data, string data1, string horario, string horario1, string pdv_computador_reg)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = 1;
            _Data = data;
            _Data1 = data1;
            _Horario = horario;
            _Horario1 = horario1;
            _PDV_Computador_Reg = pdv_computador_reg;
        }

        private string _Usuario;
        private byte _Trabalho;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private string _Data;
        private string _Data1;
        private string _Horario;
        private string _Horario1;
        private string _PDV_Computador_Reg;

        private void FrmRelSaidasProdutos_Load(object sender, EventArgs e)
        {
            try
            {
                bllSaidasProdutos._FrmRelSaidasProdutos_Aberto = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaidasProdutos iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaidasProdutos iniciado.");
                }
                //
                cbbProduto.Items.Clear();
                if (bllSaidasProdutos.Sel_Produtos_Saidas_Prod() == null)
                {
                    cbbProduto.Enabled = false;
                    cbbProduto.Text = null;
                }
                else
                {
                    cbbProduto.Enabled = true;
                    cbbProduto.Items.Add("");
                    foreach (DataRow dr in bllSaidasProdutos.Sel_Produtos_Saidas_Prod().Rows)
                    {
                        cbbProduto.Items.Add(dr["id_produto"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                cbbServico.Items.Clear();
                if (bllSaidasProdutos.Sel_Servicos_Saidas_Prod() == null)
                {
                    cbbServico.Enabled = false;
                    cbbServico.Text = null;
                }
                else
                {
                    cbbServico.Enabled = true;
                    cbbServico.Items.Add("");
                    foreach (DataRow dr in bllSaidasProdutos.Sel_Servicos_Saidas_Prod().Rows)
                    {
                        cbbServico.Items.Add(dr["id_servico"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                cbbConsumidor.Items.Clear();
                if (bllSaidasProdutos.Sel_Consumidor_Saidas_Prod() == null)
                {
                    cbbConsumidor.Enabled = false;
                    cbbConsumidor.Text = null;
                }
                else
                {
                    cbbConsumidor.Enabled = true;
                    cbbConsumidor.Items.Add("");
                    foreach (DataRow dr in bllSaidasProdutos.Sel_Consumidor_Saidas_Prod().Rows)
                    {
                        cbbConsumidor.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString());
                    }
                }
                //
                cbbFornecedor.Items.Clear();
                if (bllSaidasProdutos.Sel_Fornecedor_Saidas_Prod() == null)
                {
                    cbbFornecedor.Enabled = false;
                    cbbFornecedor.Text = null;
                }
                else
                {
                    cbbFornecedor.Enabled = true;
                    cbbFornecedor.Items.Add("");
                    foreach (DataRow dr in bllSaidasProdutos.Sel_Fornecedor_Saidas_Prod().Rows)
                    {
                        cbbFornecedor.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString());
                    }
                }
                //
                cbbUsuario.Items.Clear();
                if (bllSaidasProdutos.Sel_Usuario_Saidas_Prod() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllSaidasProdutos.Sel_Usuario_Saidas_Prod().Rows)
                    {
                        cbbUsuario.Items.Add(dr["id_usuario"].ToString() + "—" + dr["nome_usuario"].ToString());
                    }
                }
                //
                cbbCodPDV.Items.Clear();
                if (bllSaidasProdutos.Sel_Cod_PDV_Saidas_Prod() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    cbbCodPDV.Enabled = true;
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllSaidasProdutos.Sel_Cod_PDV_Saidas_Prod().Rows)
                    {
                        cbbCodPDV.Items.Add(dr["id_cadastro_computadores"].ToString());
                    }
                }
                //
                cbbCFOP.Items.Clear();
                if (bllSaidasProdutos.Sel_Cfop_Dfe_Saida_Produtos() == null)
                {
                    cbbCFOP.Enabled = false;
                    cbbCFOP.Text = null;
                }
                else
                {
                    cbbCFOP.Enabled = true;
                    cbbCFOP.Items.Add("");
                    foreach (DataRow dr in bllSaidasProdutos.Sel_Cfop_Dfe_Saida_Produtos().Rows)
                    {
                        cbbCFOP.Items.Add(dr["cod_cfop"].ToString());
                    }
                }
                //
                if (_Formulario == 0)
                {
                    txtpCodigo.Select();
                }
                else if (_Formulario == 1)
                {
                    cbbCodPDV.Enabled = false;
                    lblDataVenda.ForeColor = Color.Blue;
                    mtxtpData.Enabled = false;
                    mtxtHorario.Enabled = false;
                    mtxtpData1.Enabled = false;
                    mtxtHorario1.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    cbbCodPDV.Enabled = false;
                    btnProcurarPDV.Enabled = false;
                    lblCodPDV.ForeColor = Color.Blue;
                    mtxtpData.Text = _Data;
                    mtxtpData1.Text = _Data1;
                    mtxtHorario.Text = _Horario;
                    mtxtHorario1.Text = _Horario1;
                    cbbCodPDV.Text = _PDV_Computador_Reg;
                    btnPesquisar.Select();
                    btnPesquisar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelSaidasProdutos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelSaidasProdutos.");
                }
                this.Close();
            }
        }

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
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

        private void cbbProduto_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_DropDownClosed(object sender, EventArgs e)
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

        private void cbbConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbConsumidor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbConsumidor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSubgrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubgrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSubgrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubgrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarSubgrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarSubgrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFornecedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void lblValorQuantidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorQuantidade_MouseLeave(object sender, EventArgs e)
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

        private void btnResumido_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnResumido_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExportarCsv_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExportarCsv_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnExportarTxt_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnExportarTxt_MouseLeave(object sender, EventArgs e)
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    mtxtpData1.Text = null;
                }
            }
            mtxtpData1.BackColor = Color.White;
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void cbbProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbServico.Select();
            }
        }

        private void cbbConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbFornecedor.Enabled == true)
                {
                    cbbFornecedor.Select();
                }
                else
                {
                    cbbUsuario.Select();
                }
                    
            }
        }

        private void cbbSubgrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFornecedor.Select();
            }
        }

        private void cbbFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUsuario.Select();
            }
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUM.Select();
            }
        }

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_Formulario == 0)
                {
                    if (mtxtpData.Enabled == true)
                    {
                        mtxtpData.Select();
                    }
                    else
                    {
                        cbbUM.Select();
                    }
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmRelSaidasProdutos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 0)
                {
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(6))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllSaidasProdutos._Data_DatePicker1;
                    mtxtpData1.Text = bllSaidasProdutos._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarProduto_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqProduto Prod = new FrmPesqProduto(0, null, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProduto.Items.Clear();
                        if (bllSaidasProdutos.Sel_Produtos_Saidas_Prod() == null)
                        {
                            cbbProduto.Text = null;
                            cbbProduto.Enabled = false;
                            lblProduto.Enabled = false;
                        }
                        else
                        {
                            cbbProduto.Enabled = true;
                            lblProduto.Enabled = true;
                            cbbProduto.Items.Add("");
                            foreach (DataRow dr in bllSaidasProdutos.Sel_Produtos_Saidas_Prod().Rows)
                            {
                                cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbProduto.Text = bllSaidasProdutos._Saidas_Prod_PesqProd_Tabela;
                        bllSaidasProdutos._Saidas_Prod_PesqProd_Tabela = null;
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
                        bllSaidasProdutos._Saidas_Prod_PesqProd_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarConsumidor_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCliente Clie = new FrmPesqCliente(1, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllSaidasProdutos.Sel_Consumidor_Saidas_Prod() == null)
                        {
                            cbbConsumidor.Text = null;
                            cbbConsumidor.Enabled = false;
                            lblConsumidor.Enabled = false;
                        }
                        else
                        {
                            cbbConsumidor.Enabled = true;
                            lblConsumidor.Enabled = true;
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllSaidasProdutos.Sel_Consumidor_Saidas_Prod().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbConsumidor.Text = bllSaidasProdutos._Saidas_Prod_PesqCliente_Tabela;
                        bllSaidasProdutos._Saidas_Prod_PesqCliente_Tabela = null;
                        cbbConsumidor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarConsumidor.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarConsumidor.");
                        }
                        cbbConsumidor.Text = null;
                        bllSaidasProdutos._Saidas_Prod_PesqCliente_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarFornecedor_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(1, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFornecedor.Items.Clear();
                        if (bllSaidasProdutos.Sel_Fornecedor_Saidas_Prod() == null)
                        {
                            cbbFornecedor.Text = null;
                            cbbFornecedor.Enabled = false;
                            lblFornecedor.Enabled = false;
                        }
                        else
                        {
                            cbbFornecedor.Enabled = true;
                            lblFornecedor.Enabled = true;
                            cbbFornecedor.Items.Add("");
                            foreach (DataRow dr in bllSaidasProdutos.Sel_Fornecedor_Saidas_Prod().Rows)
                            {
                                cbbFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbFornecedor.Text = bllSaidasProdutos._Saidas_Prod_PesqForn_Tabela;
                        bllSaidasProdutos._Saidas_Prod_PesqForn_Tabela = null;
                        cbbFornecedor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarFornecedor.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarFornecedor.");
                        }
                        cbbFornecedor.Text = null;
                        bllSaidasProdutos._Saidas_Prod_PesqForn_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

       

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(2, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllSaidasProdutos.Sel_Usuario_Saidas_Prod() == null)
                        {
                            cbbUsuario.Text = null;
                            cbbUsuario.Enabled = false;
                            lblUsuario.Enabled = false;
                        }
                        else
                        {
                            cbbUsuario.Enabled = true;
                            lblUsuario.Enabled = true;
                            cbbUsuario.Items.Add("");
                            foreach (DataRow dr in bllSaidasProdutos.Sel_Usuario_Saidas_Prod().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllSaidasProdutos._Saidas_Prod_PesqUsuarioTabela;
                        bllSaidasProdutos._Saidas_Prod_PesqUsuarioTabela = null;
                        cbbUsuario.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        cbbUsuario.Text = null;
                        bllSaidasProdutos._Saidas_Prod_PesqUsuarioTabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    MessageBox.Show("É necessário preencher ambos os campos de [ Data da Venda ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtpCodigo.Select();
                    return;
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    if (bllSaidasProdutos.Sel_Saidas_Produtos_Dados(mtxtpData.Text, mtxtpData1.Text, cbbProduto.Text, cbbConsumidor.Text, cbbFornecedor.Text, cbbModelo.Text, cbbUsuario.Text, cbbUM.Text, cbbCodPDV.Text, mtxtHorario.Text, mtxtHorario1.Text, txtpCodigo.Text, cbbFinalidade.Text, cbbCSOSN.Text, cbbCFOP.Text, cbbServico.Text, cbbTipoItem.Text) == null)
                    {
                        dtSaidas.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        if (cbbFornecedor.Text != "")
                        {
                            for (int i = 0; i < bllSaidasProdutos.Sel_Saidas_Produtos_Dados(mtxtpData.Text, mtxtpData1.Text, cbbProduto.Text, cbbConsumidor.Text, cbbFornecedor.Text, cbbModelo.Text, cbbUsuario.Text, cbbUM.Text, cbbCodPDV.Text, mtxtHorario.Text, mtxtHorario1.Text, txtpCodigo.Text, cbbFinalidade.Text, cbbCSOSN.Text, cbbCFOP.Text, cbbServico.Text, cbbTipoItem.Text).Rows.Count; i++)
                            {
                                DataRow dr = bllSaidasProdutos.Sel_Saidas_Produtos_Dados(mtxtpData.Text, mtxtpData1.Text, cbbProduto.Text, cbbConsumidor.Text, cbbFornecedor.Text, cbbModelo.Text, cbbUsuario.Text, cbbUM.Text, cbbCodPDV.Text, mtxtHorario.Text, mtxtHorario1.Text, txtpCodigo.Text, cbbFinalidade.Text, cbbCSOSN.Text, cbbCFOP.Text, cbbServico.Text, cbbTipoItem.Text).Rows[i];
                                //
                                if (dr["id_fornecedor"].ToString() != "")
                                {
                                    dtSaidas.DataSource = bllSaidasProdutos.Sel_Saidas_Produtos_Dados(mtxtpData.Text, mtxtpData1.Text, cbbProduto.Text, cbbConsumidor.Text, cbbFornecedor.Text, cbbModelo.Text, cbbUsuario.Text, cbbUM.Text, cbbCodPDV.Text, mtxtHorario.Text, mtxtHorario1.Text, txtpCodigo.Text, cbbFinalidade.Text, cbbCSOSN.Text, cbbCFOP.Text, cbbServico.Text, cbbTipoItem.Text);
                                    dtSaidas.Select();
                                    //
                                    for (int a = 0; a < dtSaidas.Rows.Count; a++)
                                    {
                                        if (cbbFornecedor.Text != "")
                                        {
                                            if (dtSaidas.Rows[a].Cells[14].Value.ToString() == "")
                                            {
                                                dtSaidas.Rows.RemoveAt(a);
                                                a--;
                                            }
                                        }
                                    }
                                    //
                                    if (dtSaidas.Rows.Count == 0)
                                    {
                                        dtSaidas.DataSource = null;
                                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        decimal quantidade = 0;
                                        for (int a = 0; a < dtSaidas.Rows.Count; a++)
                                        {
                                            quantidade += Convert.ToDecimal(dtSaidas.Rows[a].Cells[4].Value);
                                        }
                                        //
                                        decimal valortotal = 0;
                                        for (int a = 0; a < dtSaidas.Rows.Count; a++)
                                        {
                                            valortotal += Convert.ToDecimal(dtSaidas.Rows[a].Cells[9].Value);
                                        }
                                        //
                                        for (int a = 0; a < dtSaidas.Rows.Count; a++)
                                        {
                                            if (Convert.ToInt32(dtSaidas.Rows[a].Cells[21].Value.ToString()) > 1)
                                            {
                                                dtSaidas.Rows[a].Cells[14].Value = "0";
                                                dtSaidas.Rows[a].Cells[15].Value = "Este produto possui " + dtSaidas.Rows[a].Cells[21].Value.ToString() + " fornecedores.";
                                            }
                                        }
                                        //
                                        lblRegistros.Text = "Registros: " + dtSaidas.Rows.Count;
                                        lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                                        lblValorQuantidade.Text = Convert.ToDecimal(quantidade).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                    return;
                                }
                                else
                                {
                                    dtSaidas.DataSource = null;
                                    MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                        }
                        else
                        {
                            dtSaidas.DataSource = bllSaidasProdutos.Sel_Saidas_Produtos_Dados(mtxtpData.Text, mtxtpData1.Text, cbbProduto.Text, cbbConsumidor.Text, cbbFornecedor.Text, cbbModelo.Text, cbbUsuario.Text, cbbUM.Text, cbbCodPDV.Text, mtxtHorario.Text, mtxtHorario1.Text, txtpCodigo.Text, cbbFinalidade.Text, cbbCSOSN.Text, cbbCFOP.Text, cbbServico.Text, cbbTipoItem.Text);
                            dtSaidas.Select();
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
                dtSaidas.DataSource = null;
                if (_Formulario == 0)
                {
                    txtpCodigo.Select();
                }
                else
                {
                    cbbUsuario.Select();
                }

            }
        }

        private void dtSaidas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dtSaidas.DataSource];
                cm.EndCurrentEdit();
                cm.ResumeBinding();
                cm.SuspendBinding();
                //
                dtSaidas.Columns[0].HeaderText = "Cód. da Venda";
                dtSaidas.Columns[1].HeaderText = "Data da Saída";
                dtSaidas.Columns[2].HeaderText = "Horário da Saída";
                dtSaidas.Columns[3].HeaderText = "Cód. do Produto";
                dtSaidas.Columns[4].HeaderText = "Descrição do Produto";
                dtSaidas.Columns[5].HeaderText = "Quantidade";
                dtSaidas.Columns[6].HeaderText = "UN";
                dtSaidas.Columns[7].HeaderText = "Valor Unitário (R$)";
                dtSaidas.Columns[8].HeaderText = "Valor Desconto (R$)";
                dtSaidas.Columns[9].HeaderText = "Valor Acréscimo (R$)";
                dtSaidas.Columns[10].HeaderText = "Valor Total (R$)";
                dtSaidas.Columns[11].HeaderText = "Cód. do Fornecedor*";
                dtSaidas.Columns[12].HeaderText = "Nome do Fornecedor*";
                dtSaidas.Columns[13].HeaderText = "Cód. do Consumidor";
                dtSaidas.Columns[14].HeaderText = "Nome do Consumidor";
                dtSaidas.Columns[15].HeaderText = "Cód. do Usuário";
                dtSaidas.Columns[16].HeaderText = "Nome do Usuário";
                dtSaidas.Columns[17].HeaderText = "Tipo";
                dtSaidas.Columns[18].Visible = false;
                dtSaidas.Columns[19].HeaderText = "Cód. do PDV/Computador";
                dtSaidas.Columns[20].HeaderText = "Finalidade";
                dtSaidas.Columns[21].HeaderText = "Tipo/Tabela";
                //
                dtSaidas.Columns[0].Width = 110;
                dtSaidas.Columns[1].Width = 115;
                dtSaidas.Columns[2].Width = 135;
                dtSaidas.Columns[3].Width = 115;
                dtSaidas.Columns[4].Width = 325;
                dtSaidas.Columns[5].Width = 90;
                dtSaidas.Columns[6].Width = 56;
                dtSaidas.Columns[7].Width = 125;
                dtSaidas.Columns[8].Width = 135;
                dtSaidas.Columns[9].Width = 135;
                dtSaidas.Columns[10].Width = 115;
                dtSaidas.Columns[11].Width = 135;
                dtSaidas.Columns[12].Width = 325;
                dtSaidas.Columns[13].Width = 135;
                dtSaidas.Columns[14].Width = 325;
                dtSaidas.Columns[15].Width = 115;
                dtSaidas.Columns[16].Width = 150;
                dtSaidas.Columns[17].Width = 105;
                dtSaidas.Columns[19].Width = 175;
                dtSaidas.Columns[20].Width = 150;
                dtSaidas.Columns[21].Width = 150;
                //
                dtSaidas.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtSaidas.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //
                dtSaidas.DefaultCellStyle.Font = new Font(dtSaidas.Font, FontStyle.Bold);
                //            
                decimal quantidade = 0;
                for (int i = 0; i < dtSaidas.Rows.Count; i++)
                {
                    quantidade += Convert.ToDecimal(dtSaidas.Rows[i].Cells[5].Value);
                }
                //
                decimal valortotal = 0;
                for (int i = 0; i < dtSaidas.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtSaidas.Rows[i].Cells[10].Value);
                }
                //
                for (int i = 0; i < dtSaidas.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtSaidas.Rows[i].Cells[18].Value.ToString()) > 1)
                    {
                        dtSaidas.Rows[i].Cells[11].Value = "0";
                        dtSaidas.Rows[i].Cells[12].Value = "Este produto possui " + dtSaidas.Rows[i].Cells[18].Value.ToString() + " fornecedores.";
                    }
                }
                //
                lblRegistros.Text = "Registros: " + dtSaidas.Rows.Count;
                lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                lblValorQuantidade.Text = Convert.ToDecimal(quantidade).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtSaidas.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtSaidas.");
                }
                dtSaidas.DataSource = null;
                txtpCodigo.Select();
            }
        }

        private void dtSaidas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorQuantidade.Text = null;
            lblValorTotal.Text = null;
        }

        private void dtSaidas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtSaidas.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtSaidas.Columns[5].DefaultCellStyle.Format = "n2";
            dtSaidas.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtSaidas.Columns[7].DefaultCellStyle.Format = "n2";
            dtSaidas.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtSaidas.Columns[8].DefaultCellStyle.Format = "n2";
            dtSaidas.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtSaidas.Columns[9].DefaultCellStyle.Format = "n2";
            dtSaidas.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtSaidas.Columns[10].DefaultCellStyle.Format = "n2";

            dtSaidas.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtSaidas.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtSaidas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 11 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 13 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 15 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 0 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 17 && e.Value.ToString() == "55")
            {
                e.Value = "NFe";
            }
            else if (e.ColumnIndex == 17 && e.Value.ToString() == "65")
            {
                e.Value = "NFCe";
            }
            //
            if (e.ColumnIndex == 20 && e.Value.ToString() == "")
            {
                e.Value = "SAIDA";
            }
        }

        private void dtSaidas_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtSaidas.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtSaidas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtSaidas_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtSaidas.DataSource == null)
            {
                dtSaidas.Enabled = false;
                grbBox2.Enabled = false;
                lblValorTotal.Enabled = false;
                lblQuantidade.Enabled = false;
                lblTotal.Enabled = false;
                lblValorQuantidade.Enabled = false;
            }
            else
            {
                dtSaidas.Enabled = true;
                grbBox2.Enabled = true;
                lblValorTotal.Enabled = true;
                lblQuantidade.Enabled = true;
                lblTotal.Enabled = true;
                lblValorQuantidade.Enabled = true;
                //
                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();
                //
                if (bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }
                //
                for (int i = 0; i < dtSaidas.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtSaidas.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtSaidas.Rows[i].Cells[11].Value.ToString())
                        {
                            dtSaidas.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtSaidas.Rows[i].Cells[11].Value.ToString())
                        {
                            dtSaidas.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtSaidas.Rows[i].Cells[11].Value.ToString())
                        {
                            dtSaidas.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtSaidas.Rows[i].Cells[11].Value.ToString())
                        {
                            dtSaidas.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtSaidas.Rows[i].Cells[11].Value.ToString())
                        {
                            dtSaidas.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtSaidas.Rows[i].Cells[11].Value.ToString())
                        {
                            dtSaidas.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
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
                cbbCSOSN.Select();
            }
        }

        private void lblValorQuantidade_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quantidade dos itens: " + lblValorQuantidade.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor total dos itens: " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por múltiplos filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir o relatório em PDF.\n\n2 - Exp. dados para (.csv): Clique para gerar em arquivo excel o relatório.\n\n3 - Exp. dados para (.txt): Clique para gerar em arquivo texto o relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmRelSaidasProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllSaidasProdutos._FrmRelSaidasProdutos_Aberto = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaidasProdutos foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelSaidasProdutos foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelSaidasProdutos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelSaidasProdutos.");
                }
                bllSaidasProdutos._FrmRelSaidasProdutos_Aberto = false;
            }
        }

        private void btnResumido_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(13))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 0;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtSaidas.Enabled = false;
                    dtSaidas.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
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
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtSaidas.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                btnSair.Enabled = true;
                if (_Formulario == 0)
                {
                    txtpCodigo.Select();
                }
                else
                {
                    cbbUsuario.Select();
                }
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtSaidas.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                dtSaidas.Select();
                //
                try
                {
                    DataGridViewRow SelectedRow = dtSaidas.Rows[dtSaidas.CurrentRow.Index];

                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.pdf");
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
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    dtSaidas.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao.Enabled = true;
                    btnSair.Enabled = true;
                    if (_Formulario == 0)
                    {
                        txtpCodigo.Select();
                    }
                    else
                    {
                        cbbUsuario.Select();
                    }
                }
            }
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    DataRow dr;
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllSaidasProdutos._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 100, 116);
                    }
                    //DATA
                    graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 5 + Margem_Topo, 95, 122);
                    textFormatter2.DrawString("Criado em:", fonte4, XBrushes.Black, new XRect(515 + Margem_Esq, 10 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToShortDateString(), fonte1, XBrushes.Black, new XRect(510 + Margem_Esq, 22 + Margem_Topo, page.Width, page.Height));
                    //HORÁRIO                    
                    textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(527 + Margem_Esq, 72 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToLongTimeString(), fonte1, XBrushes.Black, new XRect(516 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
                    //CABECALHO  DOCUMENTO
                    dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    if (!dr["nome"].ToString().Contains(" ") & dr["nome"].ToString().Length > 38)
                    {
                        textFormatter1.DrawString(dr["nome"].ToString().Insert(38, Environment.NewLine), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    else
                    {
                        textFormatter1.DrawString(dr["nome"].ToString(), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    //
                    textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + "CPF/CNPJ.: " + dr["cpf_cnpj"].ToString() + ", IE.: " + dr["ie_rg"].ToString() + Environment.NewLine + "End.: " + dr["endereco"].ToString() + Environment.NewLine + dr["complemento"].ToString() + ", " + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + "Tel.: " + dr["telefone"].ToString() + ", Cel.: " + dr["celular"].ToString() + Environment.NewLine + "E-mail.: " + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                    //
                    textFormatter1.DrawString("Relatório de Saídas de Produtos", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓD. DA VENDA    DATA E HORA DA SAÍDA    PRODUTO   QTDE.   UN.   VL.UNIT   VL.TOTAL  TIPO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 15;
                    bool PrimeiraPagina = true;
                    //
                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtSaidas.Rows.Count; i++)
                    {
                        if (i == 16)
                        {
                            TotalPaginas = TotalPaginas + 1;
                        }
                        else if (i == registros)
                        {
                            registros = registros + 21;
                            TotalPaginas = TotalPaginas + 1;
                        }
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //   
                    for (int linha = 0; linha < dtSaidas.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtSaidas.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtSaidas.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Cód. da Venda:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(74 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data da Saída:", fonte2, XBrushes.Black, new XRect(108 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(173 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString() + "-" + SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Qtde.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(35 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("UN.:", fonte2, XBrushes.Black, new XRect(145 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(167 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Unit.:", fonte2, XBrushes.Black, new XRect(240 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(276 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Total.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(440 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[17].Value.ToString() == "55")
                                {
                                    textFormatter2.DrawString("NFe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                else if (SelectedRow.Cells[17].Value.ToString() == "65")
                                {
                                    textFormatter2.DrawString("NFCe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Quantidade dos itens: " + lblValorQuantidade.Text + "                                                                                                            Valor total dos itens: " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando    
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Cód. da Venda:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(74 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data da Saída:", fonte2, XBrushes.Black, new XRect(108 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(173 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString() + "-" + SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Qtde.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(35 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("UN.:", fonte2, XBrushes.Black, new XRect(145 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(167 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Unit.:", fonte2, XBrushes.Black, new XRect(240 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(276 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Total.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(440 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[17].Value.ToString() == "55")
                                {
                                    textFormatter2.DrawString("NFe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                else if (SelectedRow.Cells[17].Value.ToString() == "65")
                                {
                                    textFormatter2.DrawString("NFCe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 219) + Margem_Topo, 75, 18));
                                }
                                //
                                Incrementar = 36 + Incrementar;//incrementando                 
                            }
                            //
                            if (linha == (pagina - 1) & dtSaidas.Rows.Count > 16)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 22;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de Saídas de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                pagina = pagina + 21;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de Saídas de Produtos", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtSaidas.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Cód. da Venda:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(74 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data da Saída:", fonte2, XBrushes.Black, new XRect(108 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(173 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString() + "-" + SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Qtde.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(35 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("UN.:", fonte2, XBrushes.Black, new XRect(145 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(167 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Unit.:", fonte2, XBrushes.Black, new XRect(240 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(276 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Total.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(440 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[17].Value.ToString() == "55")
                                {
                                    textFormatter2.DrawString("NFe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                else if (SelectedRow.Cells[17].Value.ToString() == "65")
                                {
                                    textFormatter2.DrawString("NFCe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Quantidade dos itens: " + lblValorQuantidade.Text + "                                                                                                            Valor total dos itens: " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando       
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Cód. da Venda:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(74 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data da Saída:", fonte2, XBrushes.Black, new XRect(108 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(173 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produto:", fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString() + "-" + SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(305 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Qtde.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(35 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("UN.:", fonte2, XBrushes.Black, new XRect(145 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte4, XBrushes.Black, new XRect(167 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Unit.:", fonte2, XBrushes.Black, new XRect(240 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " -" + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " +" + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(276 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Vl Total.:", fonte2, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(440 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Tipo:", fonte2, XBrushes.Black, new XRect(500 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[17].Value.ToString() == "55")
                                {
                                    textFormatter2.DrawString("NFe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                else if (SelectedRow.Cells[17].Value.ToString() == "65")
                                {
                                    textFormatter2.DrawString("NFCe", fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                else
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(523 + Margem_Esq, (Incrementar + 41) + Margem_Topo, 75, 18));
                                }
                                //
                                Incrementar = 36 + Incrementar;
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.txt"))
                {
                    writer.WriteLine("Relatório de Saídas de Produtos" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtSaidas.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtSaidas.Rows[linha];
                        string cod_venda = SelectedRow.Cells[0].Value.ToString();
                        string data_venda = SelectedRow.Cells[1].Value.ToString();
                        string cod_fornecedor = SelectedRow.Cells[11].Value.ToString();
                        string cod_consumidor = SelectedRow.Cells[13].Value.ToString();
                        string tipo = SelectedRow.Cells[17].Value.ToString();
                        string finalidade = SelectedRow.Cells[20].Value.ToString();
                        //
                        if (cod_venda == "0")
                        {
                            cod_venda = "";
                        }
                        //
                        if (data_venda == "" || data_venda == null)
                        {
                            data_venda = "";
                        }
                        else
                        {
                            data_venda = data_venda.Remove(10);
                        }
                        //
                        if (cod_consumidor == "0")
                        {
                            cod_consumidor = "";
                        }
                        //
                        if (cod_fornecedor == "0")
                        {
                            cod_fornecedor = "";
                        }
                        //
                        if (tipo == "55")
                        {
                            tipo = "NFe";
                        }
                        else if (tipo == "65")
                        {
                            tipo = "NFCe";
                        }
                        //
                        if (finalidade == "" || finalidade == null)
                        {
                            finalidade = "SAIDA";
                        }
                        //
                        writer.WriteLine(@"|Cód. da Venda: " + cod_venda + " |Data da Saída: " + data_venda + " |Horário da Saída: " + SelectedRow.Cells[2].Value.ToString() + " |Cód. do Produto: " + SelectedRow.Cells[3].Value.ToString() + " |Descrição do Produto: " + SelectedRow.Cells[4].Value.ToString() + " |Quantidade: " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")) + " |UN.: " + SelectedRow.Cells[6].Value.ToString() + " |Valor Unitário (R$): " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Desconto (R$): " + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Acréscimo (R$): " + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Total (R$): " + Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Cód. do Fornecedor: " + cod_fornecedor + " |Nome do Fornecedor: " + SelectedRow.Cells[12].Value.ToString() + " |Cód. do Consumidor: " + cod_consumidor + " |Nome do Consumidor: " + SelectedRow.Cells[14].Value.ToString() + " |Cód. do Usuário: " + SelectedRow.Cells[15].Value.ToString() + " |Nome do Usuário: " + SelectedRow.Cells[16].Value.ToString() + " |Tipo: " + tipo + " |Cód. do PDV/Computador: " + SelectedRow.Cells[19].Value.ToString() + " |Finalidade: " + finalidade + " |Tipo/Tabela: " + SelectedRow.Cells[21].Value.ToString());
                    }
                    writer.WriteLine("Quantidade dos itens: " + lblValorQuantidade.Text + "    Valor total dos itens (R$): " + lblValorTotal.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.txt");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Cód. da Venda;Data da Saída;Horário da Saída;Cód. do Produto;Descrição do Produto;Quantidade;UN;Valor Unitário (R$);Valor do Desconto (R$);Valor do Acréscimo (R$);Valor Total (R$);Cód. do Fornecedor;Nome do Fornecedor;Cód. do Consumidor;Nome do Consumidor;Cód. do Usuário;Nome do Usuário;Tipo;Cód. do PDV/Computador;Finalidade;Tipo/Tabela");
                    for (int linha = 0; linha < dtSaidas.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtSaidas.Rows[linha];
                        string cod_venda = SelectedRow.Cells[0].Value.ToString();
                        string data_venda = SelectedRow.Cells[1].Value.ToString();
                        string cod_fornecedor = SelectedRow.Cells[11].Value.ToString();
                        string cod_consumidor = SelectedRow.Cells[13].Value.ToString();
                        string tipo = SelectedRow.Cells[17].Value.ToString();
                        string finalidade = SelectedRow.Cells[20].Value.ToString();
                        //
                        if (cod_venda == "0")
                        {
                            cod_venda = "";
                        }
                        //
                        if (data_venda == "" || data_venda == null)
                        {
                            data_venda = "";
                        }
                        else
                        {
                            data_venda = data_venda.Remove(10);
                        }
                        //
                        if (cod_consumidor == "0")
                        {
                            cod_consumidor = "";
                        }
                        //
                        if (cod_fornecedor == "0")
                        {
                            cod_fornecedor = "";
                        }
                        //
                        if (tipo == "55")
                        {
                            tipo = "NFe";
                        }
                        else if (tipo == "65")
                        {
                            tipo = "NFCe";
                        }
                        //
                        if (finalidade == "" || finalidade == null)
                        {
                            finalidade = "SAIDA";
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20}", cod_venda, data_venda, SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[6].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), cod_fornecedor, SelectedRow.Cells[12].Value.ToString(), cod_consumidor, SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[15].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), tipo, SelectedRow.Cells[19].Value.ToString(), finalidade, SelectedRow.Cells[21].Value.ToString()));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Saídas de Produtos");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                    Sw.WriteLine("Quantidade dos itens: " + lblValorQuantidade.Text);
                    Sw.WriteLine("Valor total dos itens (R$): " + lblValorTotal.Text);
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Saidas de Produtos\Saidas de Produtos.csv");
            }
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 1;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtSaidas.Enabled = false;
            dtSaidas.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao.Enabled = false;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtSaidas.Enabled = false;
            dtSaidas.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao.Enabled = false;
        }

        private void cbbCodPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCodPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCodPDV_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCodPDV_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarPDV_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqComputadorPDV Comp = new FrmPesqComputadorPDV(4))
            {
                if (Comp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCodPDV.Items.Clear();
                        if (bllSaidasProdutos.Sel_Cod_PDV_Saidas_Prod() != null)
                        {
                            cbbCodPDV.Items.Add("");
                            foreach (DataRow dr in bllSaidasProdutos.Sel_Cod_PDV_Saidas_Prod().Rows)
                            {
                                cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
                            }
                        }
                        cbbCodPDV.Text = bllSaidasProdutos._Saidas_Prod_PesqCompPDV_Tabela;
                        bllSaidasProdutos._Saidas_Prod_PesqCompPDV_Tabela = null;
                        cbbCodPDV.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPDV.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPDV.");
                        }
                        cbbCodPDV.Text = null;
                        bllSaidasProdutos._Saidas_Prod_PesqCompPDV_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
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

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text == "")
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario.Text = DateTime.Now.ToString("HH:mm") + ":00";
            }
            else
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
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

                    mtxtHorario.Text = DateTime.Now.ToString("HH:mm") + ":00";
                }
                else
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text == "")
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario1.Text = DateTime.Now.ToString("HH:mm") + ":00";
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

                    mtxtHorario1.Text = DateTime.Now.ToString("HH:mm") + ":00";
                }
                else
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCodPDV.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    mtxtHorario1.Text = null;
                }
            }
            mtxtHorario1.BackColor = Color.White;
        }

        private void cbbCodPDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFinalidade.Select();
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbTipoItem.Select();
            }
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.White;
        }

        private void cbbFinalidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFinalidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFinalidade_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFinalidade_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarCFOP_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCFOP Cfop = new FrmPesqCFOP(2, null, _Usuario, _Cod_PDV_Computador))
            {
                if (Cfop.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCFOP.Items.Clear();
                        if (bllSaidasProdutos.Sel_Cfop_Dfe_Saida_Produtos() == null)
                        {
                            cbbCFOP.Text = null;
                        }
                        else
                        {
                            cbbCFOP.Items.Add("");
                            foreach (DataRow dr in bllSaidasProdutos.Sel_Cfop_Dfe_Saida_Produtos().Rows)
                            {
                                cbbCFOP.Items.Add(dr["cod_cfop"].ToString());
                            }
                        }
                        //
                        string[] items = bllSaidasProdutos._Saidas_Prod_PesqCCFOP_Tabela.Split('—');
                        cbbCFOP.Text = items[0];
                        bllSaidasProdutos._Saidas_Prod_PesqCCFOP_Tabela = null;
                        cbbCFOP.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOperacao.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOperacao.");
                        }
                        cbbCFOP.Text = null;
                    }
                }
                pEnabled.Enabled = true;
            }
        }

        private void cbbCFOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void cbbCSOSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbConsumidor.Select();
            }
        }

        private void cbbFinalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbbCFOP.Select();
        }

        private void btnPesquisarServico_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqServico Serv = new FrmPesqServico(4, _Usuario, _Cod_PDV_Computador, 0))
            {
                if (Serv.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbServico.Items.Clear();
                        if (bllSaidasProdutos.Sel_Servicos_Saidas_Prod() == null)
                        {
                            cbbServico.Text = null;
                            cbbServico.Enabled = false;
                            lblServico.Enabled = false;
                        }
                        else
                        {
                            cbbServico.Enabled = true;
                            lblServico.Enabled = true;
                            cbbServico.Items.Add("");
                            foreach (DataRow dr in bllSaidasProdutos.Sel_Servicos_Saidas_Prod().Rows)
                            {
                                cbbServico.Items.Add(dr["id_servico"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }
                        cbbServico.Text = bllSaidasProdutos._Saidas_Prod_PesqServ_Tabela;
                        bllSaidasProdutos._Saidas_Prod_PesqServ_Tabela = null;
                        cbbServico.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarServico.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarServico.");
                        }
                        cbbServico.Text = null;
                        bllSaidasProdutos._Saidas_Prod_PesqServ_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbModelo.Select();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtpCodigo.Text = null;
            cbbModelo.Text = null;
            cbbProduto.Text = null;
            cbbConsumidor.Text = null;
            cbbUM.Text = null;
            cbbCSOSN.Text = null;
            cbbServico.Text = null;
            cbbFornecedor.Text = null;
            cbbUsuario.Text = null;
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            cbbCodPDV.Text = null;
            cbbFinalidade.Text = null;
            cbbCFOP.Text = null;
            cbbTipoItem.Text = null;
        }

        private void cbbTipoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbProduto.Select();
            }
        }
    }
}
