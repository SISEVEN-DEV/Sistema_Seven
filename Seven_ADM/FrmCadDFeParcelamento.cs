using ACBrLib.Core.Boleto;
using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadDFeParcelamento : Form
    {
        public FrmCadDFeParcelamento(string codigo, string valor_nf, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Codigo = codigo;
            _Valor = valor_nf;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Codigo;
        private string _Valor;
        private decimal _Valor_Diferenca;
        private decimal _Valor_Total;
        private string _Usuario;
        private string _Cod_PDV_Computador;


        private void FrmContatoFeedBack_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDFeParcelamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDFeParcelamento iniciado.");
                }
                //
                lblTotalNF.Text = "Total da NF: " + Convert.ToDecimal(_Valor).ToString("n2", new CultureInfo("pt-BR")) + " R$";
                //
                if (bllItem_Parcelamento_DFe.Sel_Item_Parcelamento_DFe_Todos(bllConexao._Codigo_Conexao) == null)
                {
                    dtItens.DataSource = null;
                }
                else
                {
                    dtItens.DataSource = bllItem_Parcelamento_DFe.Sel_Item_Parcelamento_DFe_Todos(bllConexao._Codigo_Conexao);
                    //
                    dtItens.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadDFeParcelamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadDFeParcelamento.");
                }
            }
        }

        private void Limpar() 
        {
            mtxtDataVencimento.Text = null;
            txtValorDocumento.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = false;
            btnCancelar.Visible = false;
            btnFinalizar.Enabled = true;
            btnSalvar.Enabled = false;
            if (dtItens.DataSource != null)
            {
                dtItens.Enabled = true;
                dtItens.Select();
            }
        }

        private void FrmCadDFeParcelamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmCadDFeParcelamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllItem_Parcelamento_DFe.Excluir_Todos_Item_Parcelamento_DFe_Temp(bllConexao._Codigo_Conexao);
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDFeParcelamento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDFeParcelamento foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadDFeParcelamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadDFeParcelamento.");
                }
            }
        }

        private void dtItens_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtItens.Columns[0].HeaderText = "Parcela";
            dtItens.Columns[1].HeaderText = "Data de Vencimento";
            dtItens.Columns[2].HeaderText = "Valor (R$)";
            dtItens.Columns[3].Visible = false;

            //
            dtItens.Columns[0].Width = 115;
            dtItens.Columns[1].Width = 150;
            dtItens.Columns[2].Width = 184;

            //
            dtItens.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItens.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItens.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtItens.DefaultCellStyle.Font = new Font(dtItens.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtItens.Rows.Count;
            //
            _Valor_Total = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                _Valor_Total += Convert.ToDecimal(dtItens.Rows[i].Cells[2].Value);
            }
            lblTotalParcelamento.Text = "Total dos Parcelamentos: " + Convert.ToDecimal(_Valor_Total).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            //
            _Valor_Diferenca = 0;
            _Valor_Diferenca = _Valor_Total - Convert.ToDecimal(_Valor);
            if (_Valor_Total > Convert.ToDecimal(_Valor))
            {
                lblDiferenca.ForeColor = Color.Red;
                lblDiferenca.Text = "Diferença: " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            }
            else if (_Valor_Total < Convert.ToDecimal(_Valor))
            {
                lblDiferenca.ForeColor = Color.Red;
                lblDiferenca.Text = "Diferença: " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            }
            else
            {
                lblDiferenca.ForeColor = Color.Blue;
                lblDiferenca.Text = "Diferença: " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            }
        }

        private void dtItens_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItens.DataSource == null)
            {
                dtItens.Enabled = false;
                btnAlterar.Enabled = false;
            }
            else
            {
                dtItens.Enabled = true;
                btnAlterar.Enabled = true;
            }
        }

        private void dtItens_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtItens.Rows[e.RowIndex];
                mtxtDataVencimento.Text = SelectedRow.Cells[1].Value.ToString();
                dtItens.Columns[2].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[2].DefaultCellStyle.Format = "n2";
                txtValorDocumento.Text = Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtItens.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtItens.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtConta.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtConta.");
                }
                Limpar();
                ModoPesquisa();
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

        private void dtItens_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtItens.Rows.Count;
            //
            _Valor_Total = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                _Valor_Total += Convert.ToDecimal(dtItens.Rows[i].Cells[2].Value);
            }
            lblTotalParcelamento.Text = "Total dos Parcelamentos: " + Convert.ToDecimal(_Valor_Total).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            //
            _Valor_Diferenca = 0;
            _Valor_Diferenca = _Valor_Total - Convert.ToDecimal(_Valor);
            if (_Valor_Total > Convert.ToDecimal(_Valor))
            {
                lblDiferenca.ForeColor = Color.Red;
                lblDiferenca.Text = "Diferença: " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            }
            else if (_Valor_Total < Convert.ToDecimal(_Valor))
            {
                lblDiferenca.ForeColor = Color.Red;
                lblDiferenca.Text = "Diferença: " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            }
            else
            {
                lblDiferenca.ForeColor = Color.Blue;
                lblDiferenca.Text = "Diferença: " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$";
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                dtItens.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                btnCancelar.Visible = true;
                btnAlterar.Enabled = false;
                btnSalvar.Enabled = true;
                grbBox1.Enabled = true;
                btnFinalizar.Enabled = false;
                mtxtDataVencimento.Select();
                dtItens.Enabled = false;
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
                Limpar();
                ModoPesquisa();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtItens.DataSource == null)
            {
                Limpar();
            }
            else
            {
                Limpar();
                btnAlterar.Enabled = true;
            }
            ModoPesquisa();
        }

        private void mtxtDataVencimento_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "")
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "" & e.KeyCode == Keys.Insert)
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorDocumento.Select();
            }
        }

        private void mtxtDataVencimento_Leave(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "")
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataVencimento.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataVencimento.");
                    }
                    mtxtDataVencimento.Text = null;
                }
            }
            mtxtDataVencimento.BackColor = Color.White;
        }

        private void mtxtDataVencimento_Enter(object sender, EventArgs e)
        {
            mtxtDataVencimento.BackColor = Color.LightBlue;
        }

        private void btnPesquisarData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(3))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataVencimento.Text = bllDFe._Data_DatePicker1;
                }
            }
            this.Enabled = true;
        }

        private void dtItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void txtValorDocumento_Enter(object sender, EventArgs e)
        {
            txtValorDocumento.BackColor = Color.LightBlue;
        }

        private void txtValorDocumento_Leave(object sender, EventArgs e)
        {
            if (txtValorDocumento.Text != "")
            {
                if (txtValorDocumento.Text.Contains("'") || txtValorDocumento.Text.Contains(";") || txtValorDocumento.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorDocumento.Text = null;
                    txtValorDocumento.Select();
                }
                else
                {
                    try
                    {
                        txtValorDocumento.Text = Convert.ToDecimal(txtValorDocumento.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDocumento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDocumento.");
                        }
                        txtValorDocumento.Text = null;
                    }
                }
            }
            txtValorDocumento.BackColor = Color.White;
        }

        private void txtValorDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorDocumento.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera, multiplica e exclui registros.\n\n1 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n3 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n4 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.\n\n5 - Finalizar: Conclui o formulário e cria as contas a pagar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinalizar.Select();
                if (_Valor_Total > Convert.ToDecimal(_Valor))
                {
                    MessageBox.Show("Existe uma diferença a mais de " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$, diminua um ou mais valores e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else if (_Valor_Total < Convert.ToDecimal(_Valor))
                {
                    MessageBox.Show("Existe uma diferença a menos de " + Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR")) + " R$, aumente um ou mais os valores e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    DataRow dr = bllDFe.Sel_Nfe_Codigo(_Codigo).Rows[0];
                    //
                    string modelo = null;
                    string modelo1 = null;
                    if (dr["modelo"].ToString() == "55")
                    {
                        modelo = "MODELO 55(NFe)";
                        modelo1 = "NFe";

                    }
                    else if (dr["modelo"].ToString() == "65")
                    {
                        modelo = "MODELO 65(NFCe)";
                        modelo1 = "NFCe";
                    }
                    //
                    bool criarlembrete = false;
                    if (bllUsuario.Sel_Criar_Lemb_Conta_Pagar_Usuario(_Usuario) == true)
                    {
                        DialogResult = MessageBox.Show("Deseja também criar um lembrete de Conta a Pagar apartir deste documento DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            criarlembrete = true;
                        }
                    }
                    //
                    for (int i = 0; i < dtItens.Rows.Count; i++)
                    {
                        DataGridViewRow SelectedRow = dtItens.Rows[i];
                        //
                        bllContasPagar.Salvar(null, null, "1", "DFE " + modelo + " DE NÚMERO " + dr["numero_nf"].ToString() + " SÉRIE " + dr["serie"].ToString(), null, dr["data_emissao"].ToString().Remove(10), SelectedRow.Cells[1].Value.ToString().Remove(10), modelo1, dr["tipo_emitente_destinatario"].ToString(), dr["id_emitente_Destinatario"].ToString() + "—" + dr["nome_emitente_destinatario"].ToString(), SelectedRow.Cells[2].Value.ToString(), null, null, null, null, null, null, null, null, "2—CONTAS A PAGAR NO GERAL", "2—GERAL", null, "DFE", _Codigo, null);
                        //
                        string codigo = bllContasPagar.Sel_Ultimo_Cod_Conta_Pagar();
                        //
                        bllRegistroAtividades.Salvar("SALVOU UMA CONTA A PAGAR", "CONTAS A PAGAR", codigo, _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar cadastrada. Cod: " + codigo + " | Descrição: DFE " + modelo + " DE NÚMERO " + dr["numero_nf"].ToString() + " SÉRIE " + dr["serie"].ToString());
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar cadastrada. Cod: " + codigo + " | Descrição: DFE " + modelo + " DE NÚMERO " + dr["numero_nf"].ToString() + " SÉRIE " + dr["serie"].ToString());
                        }
                        //
                        if (criarlembrete == true)
                        {
                            MessageBox.Show("Lembrete da Parcela: " + SelectedRow.Cells[0].Value.ToString() + ".", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            dr = bllContasPagar.Sel_Conta_Codigo(codigo).Rows[0];
                            //
                            string data = null;
                            if (Convert.ToDateTime(dr["data_vencimento"].ToString()) < DateTime.Now)
                            {
                                data = DateTime.Now.ToShortDateString();
                            }
                            else
                            {
                                data = dr["data_vencimento"].ToString().Remove(10);
                            }
                            //
                            this.Enabled = false;
                            using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, data, null, "LEMBRETE DE CONTA A PAGAR", "LEMBRETE DE CONTA A PAGAR DE CÓDIGO " + codigo + ", PARCELA " + SelectedRow.Cells[0].Value.ToString() + " NO VALOR DE " + Convert.ToDecimal(dr["valor_real"]).ToString("n2", new CultureInfo("pt-BR")) + " R$ DO " + dr["tipo_emitente"].ToString() + " " + dr["id_emitente"].ToString() + "-" + dr["nome_emitente"].ToString() + ".", null, false, _Usuario, _Cod_PDV_Computador, 2, "CONTAS A PAGAR", codigo))
                            {
                                if (Lembrete.ShowDialog() == DialogResult.OK)
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            this.Enabled = true;
                        }
                        //
                        dr = bllDFe.Sel_Nfe_Codigo(_Codigo).Rows[0];
                    }
                    //
                    MessageBox.Show("Os dados das Parcelas foram salvos com sucesso no Contas a Pagar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }
            }

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
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataVencimento.Text == "" || txtValorDocumento.Text == "" || txtValorDocumento.Text == "0,00")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Data de Vencimento ] e [ Valor ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.Select();
                    }
                    else
                    {
                        DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];

                        int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                        //
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        bllItem_Parcelamento_DFe.Alterar(SelectedRow.Cells[0].Value.ToString(), txtValorDocumento.Text.Trim(), mtxtDataVencimento.Text, bllConexao._Codigo_Conexao);
                        //
                        dtItens.DataSource = bllItem_Parcelamento_DFe.Sel_Item_Parcelamento_DFe_Todos(bllConexao._Codigo_Conexao);
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
                        ModoPesquisa();
                        //
                        MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    mtxtDataVencimento.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                Limpar();
                ModoPesquisa();
            }
        }
    }
}
