using ACBrLib.NFe;
using BLL;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Seven_Sistema
{
    public partial class FrmMenuNFeNFCe : Form
    {
        public FrmMenuNFeNFCe(string usuario, string cod_pdv_computador, byte formulario, string cod_dfe)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Cod_DFe = cod_dfe;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Cod_DFe;
        bool _Concluiu = false;
        bool _Nenhum_Registro = false;
        bool _Transmitir_Direto = true;
        private bool isMethodRunning = false;

        private void FrmConfEnviarEmail_Load(object sender, EventArgs e)
        {
            try
            {
                bllDFe._FrmMenuNFeNFCe_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFeNFCe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFeNFCe iniciado.");
                }
                //
                if (_Formulario == 1 || _Formulario == 2 || _Formulario == 3 || _Formulario == 4)
                {
                    this.ControlBox = false;
                    //
                    grbBox1.Enabled = false;
                    //
                    btnPesquisar_Click(sender, e);
                }
                else
                {
                    cbbSituacao.Text = "PENDENTE";
                    btnPesquisar_Click(sender, e);
                }
                //
                _Nenhum_Registro = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFeNFCe.");
                }
            }
        }

        private void dtDFE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 20 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 21 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 7 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 9 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void dtDFE_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtDFE.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtDFE.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtDFE.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[4].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[5].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[12].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[13].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[14].DefaultCellStyle.Format = "n2";
                //
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                mtxtChave.Text = SelectedRow.Cells[15].Value.ToString();
                //
                if (SelectedRow.Cells[18].Value.ToString() == "CANCELADA")
                {
                    lblValorSituacao.Visible = true;
                    pcibDelete.Visible = true;
                    pcibCross.Visible = false;
                    pcibTick.Visible = false;
                    lblValorSituacao.Text = "CANCELADA";
                    lblValorSituacao.ForeColor = Color.Red;
                    btnConsultarDFe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                else if (SelectedRow.Cells[18].Value.ToString() == "DENEGADA")
                {
                    lblValorSituacao.Visible = true;
                    pcibDelete.Visible = true;
                    pcibCross.Visible = false;
                    pcibTick.Visible = false;
                    lblValorSituacao.Text = "CANCELADA";
                    lblValorSituacao.ForeColor = Color.Red;                  
                    btnConsultarDFe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                else if (SelectedRow.Cells[18].Value.ToString() == "INUTILIZADA")
                {
                    lblValorSituacao.Visible = true;
                    pcibDelete.Visible = true;
                    pcibCross.Visible = false;
                    pcibTick.Visible = false;
                    lblValorSituacao.Text = "INUTILIZADA";
                    lblValorSituacao.ForeColor = Color.Red;
                    btnConsultarDFe.Enabled = false;
                    btnTransmitir.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                else if (SelectedRow.Cells[18].Value.ToString() == "TRANSMITIDA")
                {
                    lblValorSituacao.Visible = true;
                    pcibDelete.Visible = false;
                    pcibCross.Visible = false;
                    pcibTick.Visible = true;
                    lblValorSituacao.Text = "TRANSMITIDA";
                    lblValorSituacao.ForeColor = Color.Green;
                    btnConsultarDFe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnInutilizar.Enabled = false;
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        btnCartaCorrecao.Enabled = true;
                    }
                    else
                    {
                        btnCartaCorrecao.Enabled = false;
                    }
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                else if (SelectedRow.Cells[18].Value.ToString() == "PENDENTE")
                {
                    lblValorSituacao.Visible = true;
                    pcibDelete.Visible = false;
                    pcibCross.Visible = true;
                    pcibTick.Visible = false;
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    if (SelectedRow.Cells[15].Value.ToString() == "")
                    {
                        btnConsultarDFe.Enabled = false;
                        btnTransmitir.Enabled = true;
                        lblChave.Enabled = false;
                        mtxtChave.Enabled = false;
                        btnCopiarChave.Enabled = false;
                    }
                    else
                    {
                        btnConsultarDFe.Enabled = true;
                        btnTransmitir.Enabled = false;
                        lblChave.Enabled = true;
                        mtxtChave.Enabled = true;
                        btnCopiarChave.Enabled = true;
                    }
                    btnCancelar.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                }
                else
                {
                    lblValorSituacao.Visible = true;
                    pcibDelete.Visible = false;
                    pcibCross.Visible = true;
                    pcibTick.Visible = false;
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    if (SelectedRow.Cells[15].Value.ToString() == "")
                    {
                        btnConsultarDFe.Enabled = false;
                        btnTransmitir.Enabled = true;
                        lblChave.Enabled = false;
                        mtxtChave.Enabled = false;
                        btnCopiarChave.Enabled = false;
                    }
                    else
                    {
                        btnConsultarDFe.Enabled = true;
                        btnTransmitir.Enabled = false;
                        lblChave.Enabled = true;
                        mtxtChave.Enabled = true;
                        btnAbrirArquivo.Enabled = true;
                        btnCopiarChave.Enabled = true;
                    }
                    btnCancelar.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                }
                //
                if (isMethodRunning == false)
                {
                    rtbRespostas.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtDFE.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtDFE.");
                }
                dtDFE.DataSource = null;
            }
        }

        private void dtDFE_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtDFE.Columns[0].HeaderText = "Código";
            dtDFE.Columns[1].HeaderText = "Número da NF";
            dtDFE.Columns[2].HeaderText = "Código do Dest.";
            dtDFE.Columns[3].HeaderText = "Nome do Destinatário";
            dtDFE.Columns[4].HeaderText = "Total dos Produtos";
            dtDFE.Columns[5].HeaderText = "Valor Total da NF";
            dtDFE.Columns[6].HeaderText = "Série";
            dtDFE.Columns[7].HeaderText = "Data de Emissão";
            dtDFE.Columns[8].HeaderText = "Hora da Emissão";
            dtDFE.Columns[9].HeaderText = "Data de Sáida";
            dtDFE.Columns[10].HeaderText = "Hora de Saída";
            dtDFE.Columns[11].HeaderText = "Modelo";
            dtDFE.Columns[12].HeaderText = "Descontos";
            dtDFE.Columns[13].HeaderText = "Frete";
            dtDFE.Columns[14].HeaderText = "Despesas";
            dtDFE.Columns[15].HeaderText = "Chave";
            dtDFE.Columns[16].HeaderText = "Natureza da Operação/CFOP Predominante";
            dtDFE.Columns[17].Visible = false;
            dtDFE.Columns[18].HeaderText = "Situação";
            dtDFE.Columns[19].HeaderText = "Cód. Status";
            dtDFE.Columns[20].HeaderText = "Cód. da Venda";
            dtDFE.Columns[21].HeaderText = "Cód. da Devolução";
            dtDFE.Columns[22].HeaderText = "Data de Cadastro/Criação";
            //
            dtDFE.Columns[0].Width = 100;
            dtDFE.Columns[1].Width = 105;
            dtDFE.Columns[2].Width = 115;
            dtDFE.Columns[3].Width = 287;
            dtDFE.Columns[4].Width = 150;
            dtDFE.Columns[5].Width = 150;
            dtDFE.Columns[6].Width = 85;
            dtDFE.Columns[7].Width = 150;
            dtDFE.Columns[8].Width = 150;
            dtDFE.Columns[9].Width = 150;
            dtDFE.Columns[10].Width = 150;
            dtDFE.Columns[11].Width = 100;
            dtDFE.Columns[12].Width = 150;
            dtDFE.Columns[13].Width = 150;
            dtDFE.Columns[14].Width = 150;
            dtDFE.Columns[15].Width = 425;
            dtDFE.Columns[16].Width = 375;
            dtDFE.Columns[18].Width = 150;
            dtDFE.Columns[19].Width = 100;
            dtDFE.Columns[20].Width = 125;
            dtDFE.Columns[21].Width = 150;
            dtDFE.Columns[22].Width = 225;
            //
            dtDFE.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtDFE.DefaultCellStyle.Font = new Font(dtDFE.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtDFE.Rows.Count;

            decimal valortotalreal = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valortotalreal += Convert.ToDecimal(dtDFE.Rows[i].Cells[5].Value);
            }
            lblValorTotal.Text = Convert.ToDecimal(valortotalreal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotal = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valortotal += Convert.ToDecimal(dtDFE.Rows[i].Cells[4].Value);
            }
            lblValorTotalReal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));           
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if ((mtxtpDataEmissao.Text == "" & mtxtpDataEmissao1.Text != "") || (mtxtpDataEmissao.Text != "" & mtxtpDataEmissao1.Text == ""))
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtpDataEmissao.Select();
                    return;
                }
                else
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    if (bllDFe.Sel_Dfe_Menu_NFe_NFCe(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, cbbModelo.Text, cbbSituacao.Text, txtNumeroNF.Text, _Cod_DFe) == null)
                    {
                        dtDFE.DataSource = null;
                        if (_Nenhum_Registro == true)
                        {
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtDFE.DataSource = bllDFe.Sel_Dfe_Menu_NFe_NFCe(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, cbbModelo.Text, cbbSituacao.Text, txtNumeroNF.Text, _Cod_DFe);
                        dtDFE.Select();
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
                dtDFE.DataSource = null;
                cbbModelo.Select();
            }
        }

        private void dtDFE_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorTotalReal.Text = null;
            lblValorTotal.Text = null;
        }

        private void FrmMenuNFeNFCe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bllLetreiro.Sel_Tipo_Letreiro_Existe("DFE") == true)
                {
                    if (bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "") != null)
                    {
                        if (_Formulario == 0)
                        {
                            DialogResult = MessageBox.Show("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).\n\nDeseja verificar agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                                e.Cancel = true;
                                //
                                cbbSituacao.Text = "PENDENTE";
                                dtDFE.DataSource = bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "");
                                dtDFE.Select();
                                //
                                return;
                            }
                        }
                        bllLetreiro.Alterar_Letreiro("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).", "DFE");
                    }
                    else
                    {
                        bllLetreiro.Excluir_Letreiro("DFE");
                    }
                }
                else
                {
                    if (bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "") != null)
                    {
                        if (_Formulario == 0)
                        {
                            DialogResult = MessageBox.Show("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).\n\nDeseja verificar agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                                e.Cancel = true;
                                //
                                cbbSituacao.Text = "PENDENTE";
                                dtDFE.DataSource = bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "");
                                dtDFE.Select();
                                //
                                return;
                            }
                        }
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).", "1", "DFE");
                    }
                    else
                    {
                        bllLetreiro.Excluir_Letreiro("DFE");
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFeNFCe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFeNFCe foi finalizado.");
                }
                //
                bllDFe._FrmMenuNFeNFCe_Ativo = false;
                //
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFeNFCe.");
                }
            }
        }

        private void cbbModelo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbModelo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbModelo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbModelo_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
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

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTransmitir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTransmitir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnStatusSefaz_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnStatusSefaz_MouseLeave(object sender, EventArgs e)
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

        private void btnInutilizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnInutilizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtDFE_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtDFE.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtDFE_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNumeroNF_Enter(object sender, EventArgs e)
        {
            txtNumeroNF.BackColor = Color.LightBlue;
        }

        private void txtNumeroNF_Leave(object sender, EventArgs e)
        {
            if (txtNumeroNF.Text.Contains("'") || txtNumeroNF.Text.Contains(";") || txtNumeroNF.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNumeroNF.Text = null;
                txtNumeroNF.Select();
            }
            txtNumeroNF.BackColor = Color.White;
        }

        private void txtNumeroNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                mtxtpDataEmissao.Select();
            }
        }

        private void cbbModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumeroNF.Select();
            }
        }

        private void mtxtpDataEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text == "")
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao.Text == "")
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao.Select();
            }
        }

        private void mtxtpDataEmissao_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text != "")
            {
                try
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao.Text);

                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao1.Text != "")
                    {
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao.Text) > Convert.ToDateTime(mtxtpDataEmissao1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    mtxtpDataEmissao.Text = null;
                }
            }
            mtxtpDataEmissao.BackColor = Color.White;
        }

        private void mtxtpDataEmissao_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text == "")
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao.Text == "")
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataEmissao1.Select();
            }
        }

        private void mtxtHorarioEmissao_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text != "")
            {
                if (mtxtHorarioEmissao.Text.Length == 4)
                {
                    mtxtHorarioEmissao.Text = mtxtHorarioEmissao.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    mtxtHorarioEmissao.Text = null;
                }
            }
            mtxtHorarioEmissao.BackColor = Color.White;
        }

        private void mtxtHorarioEmissao_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text == "")
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao1.Select();
            }
        }

        private void mtxtpDataEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao1.Text == "")
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text != "")
            {
                try
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao1.Text);

                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao.Text != "")
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao1.Text) < Convert.ToDateTime(mtxtpDataEmissao.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    mtxtpDataEmissao1.Text = null;
                }
            }
            mtxtpDataEmissao1.BackColor = Color.White;
        }

        private void mtxtpDataEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text == "")
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void mtxtHorarioEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao1.Text == "")
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text != "")
            {
                if (mtxtHorarioEmissao1.Text.Length == 4)
                {
                    mtxtHorarioEmissao1.Text = mtxtHorarioEmissao1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    mtxtHorarioEmissao1.Text = null;
                }
            }
            mtxtHorarioEmissao1.BackColor = Color.White;
        }

        private void FrmMenuNFeNFCe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 1 || _Formulario == 2 || _Formulario == 3 || _Formulario == 4)
                {
                    if (_Concluiu == true)
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
                    this.Close();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 1 || _Formulario == 2 || _Formulario == 3 || _Formulario == 4)
            {
                if (_Concluiu == true)
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
                this.Close();
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(22))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataEmissao.Text = bllDFe._Data_DatePicker1;
                    mtxtpDataEmissao1.Text = bllDFe._Data_DatePicker2;
                }
            }
            this.Enabled = true;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtDFE_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtDFE.DataSource == null)
            {
                lblValorTotal.Enabled = false;
                lblValorTotalReal.Enabled = false;
                lblTotal.Enabled = false;
                lblTotalReal.Enabled = false;
                btnTransmitir.Enabled = false;
                btnImprimir.Enabled = false;
                btnCancelar.Enabled = false;
                btnInutilizar.Enabled = false;
                btnConsultarDFe.Enabled = false;
                lblValorSituacao.Visible = false;
                pcibDelete.Visible = false;
                pcibCross.Visible = false;
                pcibTick.Visible = false;
                mtxtChave.Enabled = false;
                btnCopiarChave.Enabled = false;
                lblChave.Enabled = false;
                btnAbrirArquivo.Enabled = false;
                mtxtChave.Text = null;
                dtDFE.Enabled = false;
            }
            else
            {
                lblValorTotal.Enabled = true;
                lblValorTotalReal.Enabled = true;
                lblTotal.Enabled = true;
                lblTotalReal.Enabled = true;
                btnImprimir.Enabled = true;
                lblValorSituacao.Visible = true;
                btnCopiarChave.Enabled = true;
                btnAbrirArquivo.Enabled = true;
                dtDFE.Enabled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                //
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (SelectedRow.Cells[11].Value.ToString() == "65")
                {
                    bllDFe.GerarDANFE(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, false);
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja imprimir o DANFE no modelo A4?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.None;
                        bllDFe.GerarDANFE(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, false);
                    }
                    else if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        bllDFe.GerarDANFE(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, true);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
                //
                isMethodRunning = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnImprimir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnImprimir.");
                }
            }
        }

        private void btnStatusSefaz_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                ACBrNFe ACBrNFe;
                if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                {
                    ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                }
                else
                {
                    ACBrNFe = new ACBrNFe();
                }
                //
                var ret = ACBrNFe.StatusServico();
                //
                rtbRespostas.Text = ret.Resposta;
                //
                MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
                //
                ACBrNFe.Dispose();
                ACBrNFe = null;
                isMethodRunning = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnStatusSefaz.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnStatusSefaz.");
                }
            }
        }

        private void btnConsultarDFe_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                DataRow drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                bllRegistroAtividades.Salvar("CONSULTOU O DFE " + SelectedRow.Cells[0].Value.ToString() + ".", "DFE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                //
                ACBrNFe ACBrNFe;
                if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                {
                    ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                }
                else
                {
                    ACBrNFe = new ACBrNFe();
                }
                //
                int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                //
                mtxtChave.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                //
                string chave = mtxtChave.Text;
                //
                mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                ACBrNFe.LimparLista();
                //
                string caminho_chave;
                if (File.Exists(SelectedRow.Cells[17].Value.ToString()) == true)
                {
                    caminho_chave = SelectedRow.Cells[17].Value.ToString();
                }
                else
                {
                    if (_Formulario == 0)
                    {
                        MessageBox.Show("Arquivo XML não foi encontrado, o DFe será consultado pelo número da chave.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    //
                    caminho_chave = mtxtChave.Text.Replace("-", "").Replace(".", "").Replace("/", "");
                }
                //
                var ret = ACBrNFe.Consultar(caminho_chave);
                //
                rtbRespostas.Text = ret.Resposta;
                //
                if (ret.CStat == 100)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "TRANSMITIDA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "TRANSMITIDA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1 & (_Formulario == 1 || _Formulario == 3) & executar == true)
                        {
                            decimal valor_pago = 0;
                            if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    valor_pago += Convert.ToDecimal(drPagamento["valor_pago"]);
                                }
                            }
                            //
                            string pago = null;
                            string troco = null;
                            //
                            pago = valor_pago.ToString();
                            troco = Convert.ToDecimal(valor_pago - Convert.ToDecimal(drDFe["valor_total_nf"])).ToString();
                            //
                            bllVenda.Salvar_Venda(drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"], "0", drDFe["descontos"].ToString(), "0", drDFe["despesas"].ToString(), "NFe", drDFe["total_produtos"].ToString(), drDFe["valor_total_nf"].ToString(), null, _Usuario, _Cod_PDV_Computador, troco, pago, "0", "0", null, null, null, false);
                            //
                            string _Ult_Cod_Venda = bllVenda.Sel_Ultima_Venda();
                            //
                            if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    bllVenda.Salvar_Forma_Pagamento(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString(), drPagamento["tipo"].ToString(), drPagamento["valor_pago"].ToString(), _Ult_Cod_Venda, drDFe["data_emissao"].ToString().Remove(10), drDFe["hora_emissao"].ToString(), _Cod_PDV_Computador, _Usuario);
                                }
                            }
                            //
                            if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    bllVenda.Salvar_Itens_Venda(drItems["id_item"].ToString(), drItems["id_produto"].ToString(), drItems["descricao"].ToString(), drItems["quantidade"].ToString(), "", drItems["valor_unitario"].ToString(), _Ult_Cod_Venda, drItems["valor_desconto"].ToString(), drItems["valor_acrescimo"].ToString(), "0", false, "0", "0", "0", drItems["total"].ToString(), false, "0", "0", "PRODUTO");
                                }
                            }
                            //
                            bllFluxoCaixa.Salvar(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "VENDA DE PRODUTOS", pago, _Ult_Cod_Venda, _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                        }
                    }
                    //
                    drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (bllXML.Sel_Dados_XML(drDFe["id_dfe"].ToString()) == null)
                    {
                        if (File.Exists(drDFe["caminho_dfe"].ToString()) == true)
                        {
                            bllXML.Salvar(drDFe["id_dfe"].ToString(), File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                        }
                        else
                        {
                            MessageBox.Show("O XML não foi encontrado para inclusão no banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnCartaCorrecao.Enabled = true;
                    //
                    _Concluiu = true;
                    //
                    if (_Formulario == 2 || _Formulario == 3)
                    {
                        btnImprimir_Click(sender, e);
                    }
                }
                else if (ret.CStat == 101)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    //
                    if (drDFe["situacao"].ToString() != "CANCELADA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "CANCELADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(drDFe["id_venda"].ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (drDFe["situacao"].ToString() != "CANCELADA")
                        {
                            executar = true;
                        }
                        //
                        if (executar == true)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 102)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "INUTILIZADA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(drDFe["id_venda"].ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (drDFe["situacao"].ToString() != "INUTILIZADA")
                        {
                            executar = true;
                        }
                        //
                        if (executar == true)
                        {

                            if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "  PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 110)
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 150)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "TRANSMITIDA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "TRANSMITIDA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1 & (_Formulario == 1 || _Formulario == 3) & executar == true)
                        {
                            decimal valor_pago = 0;
                            if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    valor_pago += Convert.ToDecimal(drPagamento["valor_pago"]);
                                }
                            }
                            //
                            string pago = null;
                            string troco = null;
                            //
                            pago = valor_pago.ToString();
                            troco = Convert.ToDecimal(valor_pago - Convert.ToDecimal(drDFe["valor_total_nf"])).ToString();
                            //
                            bllVenda.Salvar_Venda(drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"], "0", drDFe["descontos"].ToString(), "0", drDFe["despesas"].ToString(), "NFe", drDFe["total_produtos"].ToString(), drDFe["valor_total_nf"].ToString(), null, _Usuario, _Cod_PDV_Computador, troco, pago, "0", "0", null, null, null, false);
                            //
                            string _Ult_Cod_Venda = bllVenda.Sel_Ultima_Venda();
                            //
                            if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    bllVenda.Salvar_Forma_Pagamento(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString(), drPagamento["tipo"].ToString(), drPagamento["valor_pago"].ToString(), _Ult_Cod_Venda, drDFe["data_emissao"].ToString().Remove(10), drDFe["hora_emissao"].ToString(), _Cod_PDV_Computador, _Usuario);
                                }
                            }
                            //
                            if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                    //
                                    bllVenda.Salvar_Itens_Venda(drItems["id_item"].ToString(), drItems["id_produto"].ToString(), drItems["descricao"].ToString(), drItems["quantidade"].ToString(), "", drItems["valor_unitario"].ToString(), _Ult_Cod_Venda, drItems["valor_desconto"].ToString(), drItems["valor_acrescimo"].ToString(), "0", false, "0", "0", "0", drItems["total"].ToString(), false, "0", "0", "PRODUTO");
                                }
                            }
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                        }
                    }
                    //
                    drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (bllXML.Sel_Dados_XML(drDFe["id_dfe"].ToString()) == null)
                    {
                        if (File.Exists(drDFe["caminho_dfe"].ToString()) == true)
                        {
                            bllXML.Salvar(drDFe["id_dfe"].ToString(), File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                        }
                        else
                        {
                            MessageBox.Show("O XML não foi encontrado para inclusão no banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnCartaCorrecao.Enabled = true;
                    //
                    _Concluiu = true;
                    //
                    if (_Formulario == 2 || _Formulario == 3)
                    {
                        btnImprimir_Click(sender, e);
                    }
                }
                else if (ret.CStat == 151)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "CANCELADA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "CANCELADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(drDFe["id_venda"].ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (drDFe["situacao"].ToString() != "CANCELADA")
                        {
                            executar = true;
                        }
                        //
                        if (executar == true)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 155)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "CANCELADA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "CANCELADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(drDFe["id_venda"].ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (drDFe["situacao"].ToString() != "CANCELADA")
                        {
                            executar = true;
                        }
                        //
                        if (executar == true)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 204)
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = false;
                }
                else if (ret.CStat == 206)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "INUTILIZADA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(drDFe["id_venda"].ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (drDFe["situacao"].ToString() != "INUTILIZADA")
                        {
                            executar = true;
                        }
                        //
                        if (executar == true)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 217)
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = true;
                    btnInutilizar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = false;
                }
                else if (ret.CStat == 218)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "CANCELADA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "CANCELADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(drDFe["id_venda"].ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (drDFe["situacao"].ToString() != "CANCELADA")
                        {
                            executar = true;
                        }
                        //
                        if (executar == true)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 256)
                {
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    bool executar = false;
                    if (drDFe["situacao"].ToString() != "INUTILIZADA")
                    {
                        executar = true;
                    }
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(drDFe["id_venda"].ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                        {
                            if (drDFe["finalidade"].ToString() == "SAIDA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "RETORNO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "ENTRADA")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                            {
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                        bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (drDFe["situacao"].ToString() != "INUTILIZADA")
                        {
                            executar = true;
                        }
                        //
                        if (executar == true)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                }
                            }
                            //
                            bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    if (dr["tipo"].ToString() == "CREDITO LOJA")
                                    {
                                        bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                    }
                                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                    {
                                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                            //
                            if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                //
                                for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                {
                                    DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                    //
                                    bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                }
                            }
                            //
                            if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                            {
                                bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                            }
                            //
                            bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 301)
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 302)
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else if (ret.CStat == 539)
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = false;
                }
                else if (ret.CStat == 303)
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = false;
                    btnInutilizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = true;
                }
                else
                {
                    MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    //
                    bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.NProt);
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    dtDFE.Select();
                    btnTransmitir.Enabled = true;
                    btnInutilizar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnCartaCorrecao.Enabled = false;
                    //
                    _Concluiu = false;
                }
                //
                ACBrNFe.Dispose();
                ACBrNFe = null;
                //
                isMethodRunning = false;
                //
                if ((_Formulario == 2 || _Formulario == 3) & _Concluiu == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnConsultarDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnConsultarDFe.");
                }
                btnInutilizar.Enabled = true;
            }
        }

        private void cbbSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (btnTransmitir.Enabled == false)
                {
                    btnSair.Select();
                }
                else
                {
                    btnTransmitir.Select();
                }
            }
        }

        private void rtbRespostas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtChave.Select();
            }
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
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

        private void lblValorTotalReal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Produtos (R$): " + lblValorTotalReal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total das NF (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por modelo, número da nf, data e horário de emissão e situação.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Transmitir: Clique para transmitir o DFe selecionado.\n\n2 - Imprimir DANFE: Clique para imprimir o DFe selecionado.\n\n3 - Consultar DFe: Clique para consultar a situação do DFe na Sefaz.\n\n4 - Inutilizar: Clique para inutilizar a númeração do DFe na Sefaz.\n\n5 - Cancelar: Clique para cancelar o DFe na Sefaz.\n\n6 - Consultar Status: Clique para consultar se o serviço da Sefaz está disponível.\n\n7 - Carta de Correção: Clique para realizar uma carta de correção do DFe selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnTransmitir_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                //
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0)
                {
                    MessageBox.Show("Não é possível transmitir este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDFE.Select();
                }
                else if (bllDFe.Sel_Dfe_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível transmitir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    bllRegistroAtividades.Salvar("INICIOU A TRANSMISSAO DO DFE " + SelectedRow.Cells[0].Value.ToString() + ".", "DFE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                    //
                    int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                    //
                    ACBrNFe ACBrNFe;
                    if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                    {
                        ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                    }
                    else
                    {
                        ACBrNFe = new ACBrNFe();
                    }
                    //
                    bool sincrono;
                    if (SelectedRow.Cells[11].Value.ToString() == "55")
                    {
                        ACBrNFe.Config.ModeloDF = ACBrLib.Core.NFe.ModeloNFe.moNFe;
                        //
                        bllDFe.CriarDFeNFe(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador);
                        //
                        ACBrNFe.CarregarINI(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfe" + drDFe["numero_nf"].ToString() + ".ini");
                        //
                        sincrono = true;
                        //
                        var ret = ACBrNFe.Enviar(1, sincrono: sincrono);
                        //
                        rtbRespostas.Text = ret.Resposta;
                        //
                        if (ret.Envio.CStat == 100)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "TRANSMITIDA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            if (Convert.ToByte(drDFe["origem_venda"]) == 1 & (_Formulario == 1 || _Formulario == 3))
                            {
                                decimal valor_pago = 0;
                                if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        valor_pago += Convert.ToDecimal(drPagamento["valor_pago"]);
                                    }
                                }
                                //
                                string pago = null;
                                string troco = null;
                                //
                                pago = valor_pago.ToString();
                                troco = Convert.ToDecimal(valor_pago - Convert.ToDecimal(drDFe["valor_total_nf"])).ToString();
                                //
                                bllVenda.Salvar_Venda(drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"], "0", drDFe["descontos"].ToString(), "0", drDFe["despesas"].ToString(), "NFe", drDFe["total_produtos"].ToString(), drDFe["valor_total_nf"].ToString(), null, _Usuario, _Cod_PDV_Computador, troco, pago, "0", "0", null, null, null, false);
                                //
                                string _Ult_Cod_Venda = bllVenda.Sel_Ultima_Venda();
                                //
                                bllDFe.Vincular_Venda_DFe(_Ult_Cod_Venda, SelectedRow.Cells[0].Value.ToString());
                                //
                                if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        bllVenda.Salvar_Forma_Pagamento(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString(), drPagamento["tipo"].ToString(), drPagamento["valor_pago"].ToString(), _Ult_Cod_Venda, drDFe["data_emissao"].ToString().Remove(10), drDFe["hora_emissao"].ToString(), _Cod_PDV_Computador, _Usuario);
                                    }
                                }
                                //
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        bllVenda.Salvar_Itens_Venda(drItems["id_item"].ToString(), drItems["id_produto"].ToString(), drItems["descricao"].ToString(), drItems["quantidade"].ToString(), "", drItems["valor_unitario"].ToString(), _Ult_Cod_Venda, drItems["valor_desconto"].ToString(), drItems["valor_acrescimo"].ToString(), "0", false, "0", "0", "0", drItems["valor_total"].ToString(), false, "0", "0", "PRODUTO");
                                    }
                                }
                                //
                                bllFluxoCaixa.Salvar(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "VENDA DE PRODUTOS", (Convert.ToDecimal(pago) - Convert.ToDecimal(troco)).ToString(), _Ult_Cod_Venda, _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            if (bllXML.Sel_Dados_XML(drDFe["id_dfe"].ToString()) == null)
                            {
                                if (File.Exists(drDFe["caminho_dfe"].ToString()) == true)
                                {
                                    bllXML.Salvar(drDFe["id_dfe"].ToString(), File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                                }
                                else
                                {
                                    MessageBox.Show("O XML não foi encontrado para inclusão no banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                            //
                            if (_Formulario != 0)
                            {
                                cbbModelo.Text = "MODELO 55 (NFe)";
                                txtNumeroNF.Text = drDFe["numero_nf"].ToString();
                                mtxtpDataEmissao.Text = null;
                                mtxtpDataEmissao1.Text = null;
                                mtxtHorarioEmissao.Text = null;
                                mtxtHorarioEmissao1.Text = null;
                                cbbSituacao.Text = null;
                                //
                                btnPesquisar_Click(sender, e);
                                //
                                btnImprimir_Click(sender, e);
                            }
                        }
                        else if (ret.Envio.CStat == 110)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                        }
                        else if (ret.Envio.CStat == 150)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "TRANSMITIDA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            if (Convert.ToByte(drDFe["origem_venda"]) == 1 & (_Formulario == 1 || _Formulario == 3))
                            {
                                decimal valor_pago = 0;
                                if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        valor_pago += Convert.ToDecimal(drPagamento["valor_pago"]);
                                    }
                                }
                                //
                                string pago = null;
                                string troco = null;
                                //
                                pago = valor_pago.ToString();
                                troco = Convert.ToDecimal(valor_pago - Convert.ToDecimal(drDFe["valor_total_nf"])).ToString();
                                //
                                bllVenda.Salvar_Venda(drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"], "0", drDFe["descontos"].ToString(), "0", drDFe["despesas"].ToString(), "NFe", drDFe["total_produtos"].ToString(), drDFe["valor_total_nf"].ToString(), null, _Usuario, _Cod_PDV_Computador, troco, pago, "0", "0", null, null, null, false);
                                //
                                string _Ult_Cod_Venda = bllVenda.Sel_Ultima_Venda();
                                //
                                bllDFe.Vincular_Venda_DFe(_Ult_Cod_Venda, SelectedRow.Cells[0].Value.ToString());
                                //
                                if (bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        bllVenda.Salvar_Forma_Pagamento(drPagamento["id_item_pagamento"].ToString(), drPagamento["id_pagamento"].ToString(), drPagamento["tipo"].ToString(), drPagamento["valor_pago"].ToString(), _Ult_Cod_Venda, drDFe["data_emissao"].ToString().Remove(10), drDFe["hora_emissao"].ToString(), _Cod_PDV_Computador, _Usuario);
                                    }
                                }
                                //
                                if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                        //
                                        bllVenda.Salvar_Itens_Venda(drItems["id_item"].ToString(), drItems["id_produto"].ToString(), drItems["descricao"].ToString(), drItems["quantidade"].ToString(), "", drItems["valor_unitario"].ToString(), _Ult_Cod_Venda, drItems["valor_desconto"].ToString(), drItems["valor_acrescimo"].ToString(), "0", false, "0", "0", "0", drItems["total"].ToString(), false, "0", "0", "PRODUTO");
                                    }
                                }
                                //
                                bllFluxoCaixa.Salvar(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "VENDA DE PRODUTOS", pago, _Ult_Cod_Venda, _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            if (bllXML.Sel_Dados_XML(drDFe["id_dfe"].ToString()) == null)
                            {
                                if (File.Exists(drDFe["caminho_dfe"].ToString()) == true)
                                {
                                    bllXML.Salvar(drDFe["id_dfe"].ToString(), File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                                }
                                else
                                {
                                    MessageBox.Show("O XML não foi encontrado para inclusão no banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                            //
                            if (_Formulario != 0)
                            {
                                cbbModelo.Text = "MODELO 55 (NFe)";
                                txtNumeroNF.Text = drDFe["numero_nf"].ToString();
                                mtxtpDataEmissao.Text = null;
                                mtxtpDataEmissao1.Text = null;
                                mtxtHorarioEmissao.Text = null;
                                mtxtHorarioEmissao1.Text = null;
                                cbbSituacao.Text = null;
                                //
                                btnPesquisar_Click(sender, e);
                                //
                                btnImprimir_Click(sender, e);
                            }
                        }
                        else if (ret.Envio.CStat == 204)
                        {
                            MessageBox.Show(ret.Envio.NProt, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = false;
                        }
                        else if (ret.Envio.CStat == 206)
                        {
                            MessageBox.Show(ret.Envio.NProt, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                        }
                        else if (ret.Envio.CStat == 218)
                        {
                            MessageBox.Show(ret.Envio.NProt, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "CANCELADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                        }
                        else if (ret.Envio.CStat == 256)
                        {
                            MessageBox.Show(ret.Envio.NProt, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                        }
                        else if (ret.Envio.CStat == 301)
                        {
                            MessageBox.Show(ret.Envio.NProt, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                        }
                        else if (ret.Envio.CStat == 302)
                        {
                            MessageBox.Show(ret.Envio.NProt, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = true;
                        }
                        else if (ret.Envio.CStat == 539)
                        {
                            MessageBox.Show(ret.Envio.NProt, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = false;
                        }
                        else
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            _Concluiu = false;
                        }
                    }
                    else
                    {
                        ACBrNFe.Config.ModeloDF = ACBrLib.Core.NFe.ModeloNFe.moNFCe;
                        //
                        bllDFe.CriarDFeNFCe(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, true);
                        //
                        ACBrNFe.CarregarINI(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfce" + drDFe["numero_nf"].ToString() + ".ini");
                        //
                        sincrono = true;
                        //
                        var ret = ACBrNFe.Enviar(1, sincrono: sincrono);
                        //
                        rtbRespostas.Text = ret.Resposta;
                        //
                        if (ret.Envio.CStat == 100)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "TRANSMITIDA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            bllXML.Salvar(SelectedRow.Cells[0].Value.ToString(), File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            if (_Formulario != 0)
                            {
                                btnImprimir_Click(sender, e);
                            }
                        }
                        else if (ret.Envio.CStat == 110)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else if (ret.Envio.CStat == 150)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "TRANSMITIDA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            bllXML.Salvar(SelectedRow.Cells[0].Value.ToString(), File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                            //
                            btnPesquisar_Click(sender, e);
                            //
                            if (_Formulario != 0)
                            {
                                btnImprimir_Click(sender, e);
                            }
                        }
                        else if (ret.Envio.CStat == 204)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else if (ret.Envio.CStat == 206)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else if (ret.Envio.CStat == 218)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "CANCELADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else if (ret.Envio.CStat == 256)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else if (ret.Envio.CStat == 301)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else if (ret.Envio.CStat == 302)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else if (ret.Envio.CStat == 539)
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show(ret.Envio.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            //
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", SelectedRow.Cells[0].Value.ToString(), ret.Envio.NProt);
                            //
                            btnPesquisar_Click(sender, e);
                        }
                    }
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                    //
                    isMethodRunning = false;
                    //
                    if ((_Formulario == 2 || _Formulario == 3 || _Formulario == 4) & _Concluiu == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnTransmitir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnTransmitir.");
                }
            }
        }

        private void btnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(mtxtChave.Text.Replace("-", "").Replace(".", "").Replace("/", ""));
        }

        private void btnCopiarChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCopiarChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnInutilizar_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0)
                {
                    MessageBox.Show("Não é possível inutilizar este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDFE.Select();
                }
                else if (bllDFe.Sel_Dfe_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível transmitir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    bllRegistroAtividades.Salvar("INICIOU A INUTILIZACAO DO DFE " + SelectedRow.Cells[0].Value.ToString() + ".", "DFE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);

                    int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                    //
                    ACBrNFe ACBrNFe;
                    if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                    {
                        ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                    }
                    else
                    {
                        ACBrNFe = new ACBrNFe();
                    }
                    //
                    var ano = DateTime.Now.Year;
                    //
                    var modelo = 0;
                    if (Convert.ToByte(drDFe["modelo"]) == 55)
                    {
                        modelo = 55;
                    }
                    else
                    {
                        modelo = 65;
                    }
                    //
                    var serie = Convert.ToInt32(drDFe["serie"].ToString());
                    //
                    var numeroInicial = Convert.ToInt32(drDFe["numero_nf"]);
                    var numeroFinal = Convert.ToInt32(drDFe["numero_nf"]);
                    //
                    var eCNPJ = bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "");
                    //
                    var aJustificativa = "";
                    using (FrmCancInutCorrec Inut = new FrmCancInutCorrec(2))
                    {
                        if (Inut.ShowDialog() == DialogResult.OK)
                        {
                            aJustificativa = bllDFe._JustificativaInutCancelCorr;
                        }
                        else
                        {
                            MessageBox.Show("É necessário informar uma justificativa para Inutilizar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    //
                    var ret = ACBrNFe.Inutilizar(eCNPJ, aJustificativa, ano, modelo, serie, numeroInicial, numeroFinal);
                    rtbRespostas.Text = ret.Resposta;
                    //
                    if (ret.XMotivo == "Inutilização de número homologado" || ret.CStat == 102)
                    {
                        MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        //
                        bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), null);
                        //
                        if (SelectedRow.Cells[11].Value.ToString() == "55")
                        {
                            drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(drDFe["id_venda"].ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                            {
                                if (drDFe["finalidade"].ToString() == "SAIDA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "RETORNO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "ENTRADA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (executar == true)
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                        }
                        //
                        btnPesquisar_Click(sender, e);
                        //
                        _Concluiu = true;
                    }
                    else if (ret.CStat == 135)
                    {
                        MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        //
                        bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), null);
                        //
                        if (SelectedRow.Cells[11].Value.ToString() == "55")
                        {
                            drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(drDFe["id_venda"].ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                            {
                                if (drDFe["finalidade"].ToString() == "SAIDA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "RETORNO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "ENTRADA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (executar == true)
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                        }
                        //
                        btnPesquisar_Click(sender, e);
                        //
                        _Concluiu = true;
                    }
                    else if (ret.XMotivo == "Rejeição: NF-e já está inutilizada na Base de dados da SEFAZ" || ret.CStat == 206)
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        //
                        bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), null);
                        //
                        if (SelectedRow.Cells[11].Value.ToString() == "55")
                        {
                            drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(drDFe["id_venda"].ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                            {
                                if (drDFe["finalidade"].ToString() == "SAIDA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "RETORNO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "ENTRADA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (executar == true)
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                        }
                        //
                        btnPesquisar_Click(sender, e);
                        //
                        _Concluiu = true;
                    }
                    else if (ret.XMotivo == "Rejeição: Uma NF-e da faixa já está inutilizada na Base de dados da SEFAZ" || ret.CStat == 256)
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        //
                        bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), null);
                        //
                        if (SelectedRow.Cells[11].Value.ToString() == "55")
                        {
                            drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(drDFe["id_venda"].ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                            {
                                if (drDFe["finalidade"].ToString() == "SAIDA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "RETORNO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "ENTRADA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (executar == true)
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                        }
                        //
                        btnPesquisar_Click(sender, e);
                        //
                        _Concluiu = true;
                    }
                    else if (ret.XMotivo == "Ja existe pedido de Inutilizacao com a mesma faixa de inutilizacao" || ret.CStat == 563)
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        //
                        bllDFe.Alterar_Situacao_DFe(ret.CStat.ToString(), "INUTILIZADA", SelectedRow.Cells[0].Value.ToString(), null);
                        //
                        if (SelectedRow.Cells[11].Value.ToString() == "55")
                        {
                            drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (Convert.ToByte(drDFe["origem_venda"]) == 1)
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(drDFe["id_emitente_destinatario"].ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), drDFe["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(drDFe["id_venda"].ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(drDFe["id_venda"].ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(drDFe["id_venda"].ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(drDFe["id_venda"].ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(drDFe["id_venda"].ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(drDFe["id_venda"].ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA ATRAVES DO DFE", "MENU NFE/NFCE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            if (drDFe["id_venda"].ToString() == "0" & drDFe["id_devolucao"].ToString() == "0" & executar == true)
                            {
                                if (drDFe["finalidade"].ToString() == "SAIDA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "RETORNO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "ENTRADA")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), false);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                                else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
                                {
                                    if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        {
                                            DataRow drItems = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];

                                            bllDFe.Alterar_Estoque_Produto_NFe(drItems["id_produto"].ToString(), drItems["quantidade"].ToString(), true);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool executar = false;
                            if (drDFe["situacao"].ToString() != "INUTILIZADA")
                            {
                                executar = true;
                            }
                            //
                            if (executar == true)
                            {
                                if (bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllDFe.Alterar_Estoque_Produto_NFe(dr["id_produto"].ToString(), dr["quantidade"].ToString(), true);
                                    }
                                }
                                //
                                bllVenda.Excluir_Item_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    for (int i = 0; i < bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllVenda.Sel_Formas_Pagamento_Venda(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        if (dr["tipo"].ToString() == "CREDITO LOJA")
                                        {
                                            bllDevolucao.Adicionar_Credito_Loja_Cliente(SelectedRow.Cells[2].Value.ToString(), dr["valor_pago"].ToString());
                                        }
                                        else if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "SAIDA", "EXCLUSAO DE VENDA", SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                }
                                //
                                bllVenda.Excluir_Pagamento_Venda_Venda(SelectedRow.Cells[20].Value.ToString());
                                //
                                if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllContasReceber.Alterar_Situacao_Conta_Receber_Venda(SelectedRow.Cells[20].Value.ToString(), "CANCELADA");
                                    //
                                    for (int i = 0; i < bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows.Count; i++)
                                    {
                                        DataRow dr = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(SelectedRow.Cells[20].Value.ToString()).Rows[i];
                                        //
                                        bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                                    }
                                }
                                //
                                if (bllControleCheque.Sel_Controle_Cheque_Venda(SelectedRow.Cells[20].Value.ToString()) != null)
                                {
                                    bllControleCheque.Alterar_Situacao_Controle_Cheque(SelectedRow.Cells[20].Value.ToString(), "CANCELADO");
                                }
                                //
                                bllVenda.Excluir(SelectedRow.Cells[20].Value.ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUSAO DE VENDA", "VENDAS", SelectedRow.Cells[20].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            }
                        }
                        //
                        btnPesquisar_Click(sender, e);
                        //
                        _Concluiu = true;
                    }
                    else
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        //
                        btnPesquisar_Click(sender, e);
                        //
                        _Concluiu = false;
                    }
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0]; // Mover o foco para a célula da linha
                            break;
                        }
                    }
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                    //
                    isMethodRunning = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnInutilizar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnInutilizar.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0)
                {
                    MessageBox.Show("Não é possível cancelar este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDFE.Select();
                }
                else if (bllDFe.Sel_Dfe_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível transmitir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    bllRegistroAtividades.Salvar("INICIOU O CANCELAMENTO DO DFE " + SelectedRow.Cells[0].Value.ToString() + ".", "DFE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                    //
                    int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                    //
                    ACBrNFe ACBrNFe;
                    if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                    {
                        ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                    }
                    else
                    {
                        ACBrNFe = new ACBrNFe();
                    }
                    //
                    var idLote = 1;
                    //
                    var eChave = drDFe["chave_dfe"].ToString();
                    //
                    var eCNPJ = bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "");
                    //
                    var aJustificativa = "";
                    using (FrmCancInutCorrec Inut = new FrmCancInutCorrec(2))
                    {
                        if (Inut.ShowDialog() == DialogResult.OK)
                        {
                            aJustificativa = bllDFe._JustificativaInutCancelCorr;
                        }
                        else
                        {
                            MessageBox.Show("É necessário informar uma justificativa para cancelar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    //
                    var ret = ACBrNFe.Cancelar(eChave, aJustificativa, eCNPJ, idLote);
                    rtbRespostas.Text = ret.Resposta;
                    //                
                    if (ret.CStat == 101)
                    {
                        MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (ret.CStat == 135)
                    {
                        MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (ret.CStat == 136)
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (ret.CStat == 151)
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (ret.CStat == 155)
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (ret.CStat == 218)
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        MessageBox.Show(ret.XMotivo, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    //
                    foreach (DataGridViewRow row in dtDFE.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtDFE.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    btnConsultarDFe_Click(sender, e);
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                    //
                    isMethodRunning = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnCancelar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnCancelar.");
                }
            }
        }

        private void btnCartaCorrecao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCartaCorrecao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCartaCorrecao_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (bllDFe.Sel_Dfe_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível transmitir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    bllRegistroAtividades.Salvar("INICIOU UMA CARTA DE CORRECAO DO DFE " + SelectedRow.Cells[0].Value.ToString() + ".", "DFE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                    //
                    DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    ACBrNFe ACBrNFe;
                    if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                    {
                        ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                    }
                    else
                    {
                        ACBrNFe = new ACBrNFe();
                    }
                    //
                    string idLote = "1";
                    //
                    string xCorrecao;
                    using (FrmCancInutCorrec Inut = new FrmCancInutCorrec(3))
                    {
                        if (Inut.ShowDialog() == DialogResult.OK)
                        {
                            xCorrecao = bllDFe._JustificativaInutCancelCorr;
                        }
                        else
                        {
                            return;
                        }
                    }
                    //
                    string cUF = null;
                    if (drMinhaEmpresa["UF"].ToString() == "AC")
                    {
                        cUF = "12";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "AL")
                    {
                        cUF = "27";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "AP")
                    {
                        cUF = "16";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "AM")
                    {
                        cUF = "13";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "BA")
                    {
                        cUF = "29";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "CE")
                    {
                        cUF = "23";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "DF")
                    {
                        cUF = "53";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "ES")
                    {
                        cUF = "32";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "GO")
                    {
                        cUF = "52";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "MA")
                    {
                        cUF = "21";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "MT")
                    {
                        cUF = "51";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "MS")
                    {
                        cUF = "50";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "MG")
                    {
                        cUF = "31";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "PA")
                    {
                        cUF = "15";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "PB")
                    {
                        cUF = "25";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "PR")
                    {
                        cUF = "41";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "PE")
                    {
                        cUF = "26";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "PI")
                    {
                        cUF = "22";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "RJ")
                    {
                        cUF = "33";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "RN")
                    {
                        cUF = "24";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "RS")
                    {
                        cUF = "43";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "RO")
                    {
                        cUF = "11";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "RR")
                    {
                        cUF = "14";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "SC")
                    {
                        cUF = "42";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "SP")
                    {
                        cUF = "35";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "SE")
                    {
                        cUF = "28";
                    }
                    else if (drMinhaEmpresa["UF"].ToString() == "TO")
                    {
                        cUF = "17";
                    }
                    //
                    string CNPJ = drMinhaEmpresa["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
                    //
                    string chNFe = drDFe["chave_dfe"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
                    //
                    string dhEvento = DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");
                    //
                    string nSeqEvento = bllDFe.Sel_Dfe_N_Seq_CCe(SelectedRow.Cells[0].Value.ToString()).ToString();
                    //
                    string criarini = @"[EVENTO]
idLote=" + idLote + @"

[EVENTO001]
cOrgao=" + cUF + @"
CNPJ=" + CNPJ + @"
chNFe=" + chNFe + @"
dhEvento=" + dhEvento + @"
tpEvento=110110
nSeqEvento=" + nSeqEvento + @"
versaoEvento =1.00
xCorrecao=" + xCorrecao
        ;
                    //
                    bllDFe.Alterar_N_Seq_CCe(nSeqEvento, SelectedRow.Cells[0].Value.ToString());
                    //
                    File.WriteAllText(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\cce.ini", criarini, Encoding.UTF8);
                    //
                    ACBrNFe.CarregarEventoINI(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\cce.ini");
                    //
                    var ret = ACBrNFe.EnviarEvento(Convert.ToInt32(idLote));
                    rtbRespostas.Text = ret.Resposta;
                    //
                    MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
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
                    var arquivoXmlEvento = ACBrNFe.Config.PathNFe + @"\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\NFe\" + DateTime.Now.Year + mes + @"\Evento\CCe\110110" + drDFe["chave_dfe"].ToString().Replace(".", "").Replace("-", "").Replace("/", "") + Convert.ToInt32(nSeqEvento).ToString("D2", new CultureInfo("pt-BR")) + "-procEventoNFe.xml";
                    //
                    string x = Convert.ToInt32(nSeqEvento).ToString("D2", new CultureInfo("pt-BR"));
                    var arquivoXml = drDFe["caminho_dfe"].ToString();
                    //
                    ACBrNFe.ImprimirEvento(arquivoXml, arquivoXmlEvento);
                    //
                    ACBrNFe.LimparListaEventos();
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                    //
                    isMethodRunning = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnCancelar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnCancelar.");
                }
            }
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                string[] items = SelectedRow.Cells[17].Value.ToString().Split('\\');
                //
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.Title = "Selecione um XML";
                    file.Filter = "NFCe/XML :(" + items[7] + ")|" + items[7];
                    //
                    string diretorioinicial = SelectedRow.Cells[17].Value.ToString().Replace(items[7], "");
                    //
                    file.InitialDirectory = diretorioinicial;
                    //
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        Process.Start(file.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnAbrirArquivo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnAbrirArquivo.");
                }
            }
        }

        private void btnAbrirArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAbrirArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Antes de executar qualquer ação no DFe é importante antes de tudo, clicar em [ Consultar DFe ] para verificar o retorno da sefaz.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;

        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtDFE_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_Formulario == 2 & _Transmitir_Direto == true)
            {
             
            }
        }

        private void dtDFE_EnabledChanged(object sender, EventArgs e)
        {
            if (_Transmitir_Direto == true & _Formulario == 2)
            {
                btnTransmitir.Enabled = true;
                //
                btnTransmitir_Click(sender, e);
                //
                _Transmitir_Direto = false;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            cbbModelo.Text = null;
            txtNumeroNF.Text = null;
            mtxtpDataEmissao.Text = null;
            mtxtHorarioEmissao.Text = null;
            mtxtpDataEmissao1.Text = null;
            mtxtHorarioEmissao1.Text = null;
            cbbSituacao.Text = null;
        }
    }
}
