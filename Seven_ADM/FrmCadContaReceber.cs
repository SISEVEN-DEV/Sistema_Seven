using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BLL;

namespace SIE_7_Sistema
{
    public partial class FrmCadContaReceber : Form
    {
        public FrmCadContaReceber()
        {
            InitializeComponent();
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar;
        private string _ComboboxEmitente_Valor;

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtPalavraChave.Text = null;
            txtParcela.Text = null;
            txtDescricao.Text = null;
            cbbTipoDocumento.Text = null;
            mtxtDataEmissao.Text = null;
            mtxtDataVencimento.Text = null;
            rtxtObs.Text = null;
            cbbTipoDestinatario.Text = null;
            cbbDestinatario.Text = null;
            txtValorDocumento.Text = null;
            mtxtDataDesconto.Text = null;
            txtDesconto.Text = null;
            txtValorDesconto.Text = null;
            txtMulta.Text = null;
            txtValorMulta.Text = null;
            txtMora.Text = null;
            chkbVencDiaUtil.Checked = false;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtContaReceber.Enabled = true;
            dtContaReceber.Select();
        }       

        private void FrmCadContaReceber_Load(object sender, EventArgs e)
        {
            bllContasReceber._FrmCadContaReceber_Ativo = true;
            txtpDescricao.Select();
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            btnSelecionarData.Visible = false;
            cbbpTipoDestinatario.Visible = false;
            btnpProcurar.Visible = false;
            cbbpDestinatario.Visible = false;
            txtpPalavraChave.Visible = false;
            lblAte.Visible = false;
            txtpDescricao.Visible = true;
            mtxtpData1.Visible = false;
            mtxtpData2.Visible = false;
            lblPesquisar.Location = new Point(203, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpCodigo.Visible = false;
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnSelecionarData.Visible = false;
            cbbpTipoDestinatario.Visible = false;
            btnpProcurar.Visible = false;
            cbbpDestinatario.Visible = false;
            txtpPalavraChave.Visible = false;
            lblAte.Visible = false;
            txtpDescricao.Visible = false;
            mtxtpData1.Visible = false;
            mtxtpData2.Visible = false;
            lblPesquisar.Location = new Point(465, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Visible = true;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnCodAluno_CheckedChanged(object sender, EventArgs e)
        {
            btnSelecionarData.Visible = false;
            cbbpTipoDestinatario.Visible = true;
            btnpProcurar.Visible = true;
            cbbpDestinatario.Visible = true;
            txtpPalavraChave.Visible = false;
            lblAte.Visible = false;
            txtpDescricao.Visible = false;
            mtxtpData1.Visible = false;
            mtxtpData2.Visible = false;
            lblPesquisar.Location = new Point(80, 21);
            lblPesquisar.Text = "Localizar destinatário em:";
            txtpCodigo.Visible = false;
            cbbpTipoDestinatario.Text = null;
            cbbpDestinatario.Text = null;
            cbbpTipoDestinatario.Select();
        }

        private void rbtnDataEmissao_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTipoDestinatario.Visible = false;
            btnpProcurar.Visible = false;
            cbbpDestinatario.Visible = false;
            btnSelecionarData.Visible = true;
            txtpPalavraChave.Visible = false;
            lblAte.Visible = true;
            txtpDescricao.Visible = false;
            mtxtpData1.Visible = true;
            mtxtpData2.Visible = true;
            lblPesquisar.Location = new Point(350, 21);
            lblPesquisar.Text = "Digite as datas:";
            txtpCodigo.Visible = false;
            mtxtpData1.Text = null;
            mtxtpData2.Text = null;
            mtxtpData1.Select();
        }

        private void rbtnDataVencimento_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTipoDestinatario.Visible = false;
            btnpProcurar.Visible = false;
            cbbpDestinatario.Visible = false;
            btnSelecionarData.Visible = true;
            txtpPalavraChave.Visible = false;
            lblAte.Visible = true;
            txtpDescricao.Visible = false;
            mtxtpData1.Visible = true;
            mtxtpData2.Visible = true;
            lblPesquisar.Location = new Point(350, 21);
            lblPesquisar.Text = "Digite as datas:";
            txtpCodigo.Visible = false;
            mtxtpData1.Text = null;
            mtxtpData2.Text = null;
            mtxtpData1.Select();
        }

        private void rbtnTodas_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTipoDestinatario.Visible = false;
            btnpProcurar.Visible = false;
            cbbpDestinatario.Visible = false;
            btnSelecionarData.Visible = false;
            txtpPalavraChave.Visible = false;
            lblAte.Visible = false;
            txtpDescricao.Visible = false;
            mtxtpData1.Visible = false;
            mtxtpData2.Visible = false;
            lblPesquisar.Location = new Point(515, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            txtpCodigo.Visible = false;
            btnPesquisar.Select();
        }

        private void txtParcela_Enter(object sender, EventArgs e)
        {
            txtParcela.BackColor = Color.LightBlue;
        }

        private void txtParcela_Leave(object sender, EventArgs e)
        {
            if (txtParcela.Text.Contains("'") || txtParcela.Text.Contains(";") || txtParcela.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParcela.Text = null;
            }
            txtParcela.BackColor = Color.White;
        }
        
        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Text = null;
            }
            txtDescricao.BackColor = Color.White;
        }
        
        private void mtxtDataEmissao_Enter(object sender, EventArgs e)
        {
            mtxtDataEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtDataEmissao_Leave(object sender, EventArgs e)
        {
            mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataEmissao.Text == "")
            {
                mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataVencimento.Text == "")
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        ValidarData.Ver_Data(mtxtDataEmissao.Text);
                    }
                    else
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataEmissao.Text) > Convert.ToDateTime(mtxtDataVencimento.Text))
                        {
                            MessageBox.Show("Data de emissão é maior que a data de vencimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtDataEmissao.Text = null;
                        }
                        else
                        {
                            ValidarData.Ver_Data(mtxtDataEmissao.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtDataEmissao.Text = null;
                }
            }
            mtxtDataEmissao.BackColor = Color.White;
        }

        private void mtxtDataVencimento_Enter(object sender, EventArgs e)
        {
            mtxtDataVencimento.BackColor = Color.LightBlue;
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

                    mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataEmissao.Text == "")
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        ValidarData.Ver_Data(mtxtDataVencimento.Text);
                    }
                    else
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataVencimento.Text) < Convert.ToDateTime(mtxtDataEmissao.Text))
                        {
                            MessageBox.Show("Data de vencimento é maior que a data de emissão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtDataVencimento.Text = null;
                        }
                        else
                        {
                            ValidarData.Ver_Data(mtxtDataVencimento.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtDataVencimento.Text = null;
                }
            }
            mtxtDataVencimento.BackColor = Color.White;
        }
        
        private void mtxtDataDesconto_Enter(object sender, EventArgs e)
        {
            mtxtDataDesconto.BackColor = Color.LightBlue;
        }

        private void mtxtDataDesconto_Leave(object sender, EventArgs e)
        {
            mtxtDataDesconto.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataDesconto.Text == "")
            {
                mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataVencimento.Text == "")
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        ValidarData.Ver_Data(mtxtDataDesconto.Text);
                    }
                    else
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataVencimento.Text) < Convert.ToDateTime(mtxtDataDesconto.Text))
                        {
                            MessageBox.Show("Data de desconto é maior que a data de vencimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtDataDesconto.Text = null;
                        }
                        else
                        {
                            ValidarData.Ver_Data(mtxtDataDesconto.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtDataDesconto.Text = null;
                }
            }
            mtxtDataDesconto.BackColor = Color.White;
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            txtValorDesconto.BackColor = Color.LightBlue;
        }

        private void txtValorDesconto_Leave(object sender, EventArgs e)
        {
            /*
            if (txtValorDesconto.Text != "")
            {
                if (txtValorDesconto.Text.Contains("'") || txtValorDesconto.Text.Contains(";") || txtValorDesconto.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValorDesconto.Text = null;
                }
                else
                {
                    try
                    {
                        txtValorDesconto.Text = decimal.Parse(txtValorDesconto.Text, new CultureInfo("pt-BR")).ToString("n2");

                        if (txtValorDocumento.Text != "")
                        {
                            txtDesconto.Text = bllContasPagar.Calculo_ValorDesconto(txtValorDocumento.Text, txtValorDesconto.Text);

                            txtDesconto.Text = decimal.Parse(txtDesconto.Text, new CultureInfo("pt-BR")).ToString("n2");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValorDesconto.Text = null;
                    }
                }
            }
            txtValorDesconto.BackColor = Color.White;
            */
        }

        private void txtMulta_Enter(object sender, EventArgs e)
        {
            txtMulta.BackColor = Color.LightBlue;
        }

        private void txtMulta_Leave(object sender, EventArgs e)
        {
            if (txtMulta.Text.Contains("'") || txtMulta.Text.Contains(";") || txtMulta.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMulta.Text = null;
            }
            else
            {
                if (txtMulta.Text != "")
                {
                    if (Convert.ToDecimal(txtMulta.Text) > 100)
                    {
                        MessageBox.Show("Valor inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMulta.Text = null;
                        txtValorMulta.Text = null;
                    }
                    else
                    {
                        try
                        {
                            txtMulta.Text = decimal.Parse(txtMulta.Text, new CultureInfo("pt-BR")).ToString("n2");

                            if (txtValorDocumento.Text != "")
                            {
                                txtValorMulta.Text = bllContasPagar.Calculo_Multa(txtValorDocumento.Text, txtMulta.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMulta.Text = null;
                        }
                    }
                }
            }
            txtMulta.BackColor = Color.White;
        }       

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtObs.Text = null;
            }
            rtxtObs.BackColor = Color.White;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtContaReceber.Enabled = false;
            grbBox1.Enabled = false;
            btnCriarLembrete.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;           
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            Limpar();        
            txtParcela.Enabled = false;
            txtParcela.Text = "1";
            txtPalavraChave.Select();
            _Inserir_Atualizar = true;            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];

                if (bllContasReceber.Sel_Alterar_Conta_Receber_Fechada() == false & bllContasReceber.Sel_Situacao_Conta(SelectedRow.Cells[0].Value.ToString()) == true)
                {
                    MessageBox.Show("Não é possível alterar uma conta com a situação fechada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnAlterar.Select();
                }
                else
                {

                    dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = true;
                    dtContaReceber.Enabled = false;
                    dtContaReceber.Select();
                    txtDescricao.Select();
                    btnCriarLembrete.Enabled = false;
                    _Inserir_Atualizar = true;
                    _Comando_Atualizar = true;

                    if (cbbTipoDestinatario.SelectedIndex == 0)
                    {
                        if (cbbDestinatario.Text != "")
                        {
                            _ComboboxEmitente_Valor = cbbDestinatario.Text;
                            cbbDestinatario.Items.Clear();
                            if (bllContasReceber.Sel_Aluno_Cont_Receber() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Aluno_Cont_Receber().Rows)
                                {
                                    cbbDestinatario.Items.Add((dr["id_aluno"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }

                            if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Aluno_ContaReceber(_ComboboxEmitente_Valor) != null)
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Aluno_ContaReceber(_ComboboxEmitente_Valor).Rows)
                                {
                                    cbbDestinatario.Text = dr["id_aluno"].ToString() + "-" + dr["nome"].ToString();
                                }
                                _ComboboxEmitente_Valor = null;
                            }
                            else
                            {
                                _ComboboxEmitente_Valor = null;
                                cbbDestinatario.Text = null;
                            }
                        }
                    }
                    else if (cbbTipoDestinatario.SelectedIndex == 1)
                    {
                        if (cbbDestinatario.Text != "")
                        {
                            _ComboboxEmitente_Valor = cbbDestinatario.Text;
                            cbbDestinatario.Items.Clear();
                            if (bllContasReceber.Sel_Forn_Cont_Receber() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Forn_Cont_Receber().Rows)
                                {
                                    cbbDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }

                            if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxEmitente_Valor) != null)
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxEmitente_Valor).Rows)
                                {
                                    cbbDestinatario.Text = dr["id_fornecedor"].ToString() + "-" + dr["nome"].ToString();
                                }
                                _ComboboxEmitente_Valor = null;
                            }
                        }
                        else
                        {
                            _ComboboxEmitente_Valor = null;
                            cbbDestinatario.Text = null;
                        }
                    }
                    else if (cbbTipoDestinatario.SelectedIndex == 2)
                    {
                        if (cbbDestinatario.Text != "")
                        {
                            _ComboboxEmitente_Valor = cbbDestinatario.Text;
                            cbbDestinatario.Items.Clear();
                            if (bllContasReceber.Sel_Func_Cont_Receber() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Func_Cont_Receber().Rows)
                                {
                                    cbbDestinatario.Items.Add((dr["id_funcionario"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }

                            if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxEmitente_Valor) != null)
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxEmitente_Valor).Rows)
                                {
                                    cbbDestinatario.Text = dr["id_funcionario"].ToString() + "-" + dr["nome"].ToString();
                                }
                                _ComboboxEmitente_Valor = null;
                            }
                        }
                        else
                        {
                            _ComboboxEmitente_Valor = null;
                            cbbDestinatario.Text = null;
                        }
                    }                
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                Limpar();
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCriarLembrete.Enabled = true;
            }
            else
            {
                if (dtContaReceber.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnCriarLembrete.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            ModoPesquisa();           
        }

        private void txtCodFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
            
            }
        }

        private void txtValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorDesconto.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtMulta.Select();
            }
        }

        private void txtMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMulta.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValorMulta.Select();
            }
        }

      

        private void mtxtDataEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataEmissao.Text == "")
            {
                mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
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

        private void mtxtDataDesconto_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataDesconto.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataDesconto.Text == "")
            {
                mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataDesconto.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }       
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
            }
            txtpDescricao.BackColor = Color.White;
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_Leave(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.White;
        }

        private void mtxtpData2_Enter(object sender, EventArgs e)
        {
            mtxtpData2.BackColor = Color.LightBlue;
        }

        private void mtxtpData2_Leave(object sender, EventArgs e)
        {
            mtxtpData2.BackColor = Color.White;
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
                txtpCodigo.Text = null;
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbTipoDestinatario.SelectedIndex == 0)
                {
                    if (cbbDestinatario.Text != "")
                    {
                        _ComboboxEmitente_Valor = cbbDestinatario.Text;
                        cbbDestinatario.Items.Clear();
                        if (bllContasReceber.Sel_Aluno_Cont_Receber() == null)
                        {
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_Aluno_Cont_Receber().Rows)
                            {
                                cbbDestinatario.Items.Add((dr["id_aluno"].ToString()) + "-" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Aluno_ContaReceber(_ComboboxEmitente_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Aluno_ContaReceber(_ComboboxEmitente_Valor).Rows)
                            {
                                cbbDestinatario.Text = dr["id_aluno"].ToString() + "-" + dr["nome"].ToString();
                            }
                            _ComboboxEmitente_Valor = null;
                        }
                        else
                        {
                            _ComboboxEmitente_Valor = null;
                            cbbDestinatario.Text = null;
                        }
                    }
                }
                else if (cbbTipoDestinatario.SelectedIndex == 1)
                {
                    if (cbbDestinatario.Text != "")
                    {
                        _ComboboxEmitente_Valor = cbbDestinatario.Text;
                        cbbDestinatario.Items.Clear();
                        if (bllContasReceber.Sel_Forn_Cont_Receber() == null)
                        {
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_Forn_Cont_Receber().Rows)
                            {
                                cbbDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxEmitente_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxEmitente_Valor).Rows)
                            {
                                cbbDestinatario.Text = dr["id_fornecedor"].ToString() + "-" + dr["nome"].ToString();
                            }
                            _ComboboxEmitente_Valor = null;
                        }
                    }
                    else
                    {
                        _ComboboxEmitente_Valor = null;
                        cbbDestinatario.Text = null;
                    }
                }
                else if (cbbTipoDestinatario.SelectedIndex == 2)
                {
                    if (cbbDestinatario.Text != "")
                    {
                        _ComboboxEmitente_Valor = cbbDestinatario.Text;
                        cbbDestinatario.Items.Clear();
                        if (bllContasReceber.Sel_Func_Cont_Receber() == null)
                        {
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_Func_Cont_Receber().Rows)
                            {
                                cbbDestinatario.Items.Add((dr["id_funcionario"].ToString()) + "-" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxEmitente_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxEmitente_Valor).Rows)
                            {
                                cbbDestinatario.Text = dr["id_funcionario"].ToString() + "-" + dr["nome"].ToString();
                            }
                            _ComboboxEmitente_Valor = null;
                        }
                    }
                    else
                    {
                        _ComboboxEmitente_Valor = null;
                        cbbDestinatario.Text = null;
                    }
                }
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtDataDesconto.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (txtParcela.Text == "" || txtDescricao.Text == "" || mtxtDataEmissao.Text == "" || mtxtDataVencimento.Text == "" || cbbTipoDocumento.Text == "" || cbbTipoDestinatario.Text == "" || cbbDestinatario.Text == "" || txtValorDocumento.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: < Parcela >, < Descrição >, < Emissão >, < Vencimento >, < Tipo de Documento >, < Emitente > e < Valor do Documento >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        txtPalavraChave.Select();
                    }
                    else
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;


                        if (_Comando_Atualizar == true)
                        {
                            bllContasReceber.Alterar(txtCodigo.Text, txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), txtParcela.Text.Trim(), cbbTipoDocumento.Text, mtxtDataEmissao.Text, mtxtDataVencimento.Text, rtxtObs.Text.Trim(), cbbTipoDestinatario.Text, cbbDestinatario.Text, txtValorDocumento.Text.Trim(), mtxtDataDesconto.Text, txtDesconto.Text.Trim(), txtValorDesconto.Text.Trim(), txtMulta.Text.Trim(), txtValorMulta.Text.Trim(), txtMora.Text.Trim(), chkbVencDiaUtil.Checked);

                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_A_Alt(txtCodigo.Text);

                            ModoPesquisa();

                            if (bllContasReceber.Sel_Mostrar_Opc_Doc_Fis_A_Alterar_Conta_Receber() == true)
                            {
                                DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];

                                DialogResult = MessageBox.Show("Deseja salvar o documento físico no sistema ou digitalizar o mesmo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    using (FrmDetalhesConta Det = new FrmDetalhesConta(SelectedRow.Cells[0].Value.ToString(), 1))
                                    {
                                        if (Det.ShowDialog() == DialogResult.Abort)
                                        {
                                            dtContaReceber.Select();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bllContasReceber.Salvar(txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), txtParcela.Text.Trim(), cbbTipoDocumento.Text, mtxtDataEmissao.Text, mtxtDataVencimento.Text, rtxtObs.Text.Trim(), cbbTipoDestinatario.Text, cbbDestinatario.Text, txtValorDocumento.Text.Trim(), mtxtDataDesconto.Text, txtDesconto.Text.Trim(), txtValorDesconto.Text.Trim(), txtMulta.Text.Trim(), txtValorMulta.Text.Trim(), txtMora.Text.Trim(), chkbVencDiaUtil.Checked);

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_A_Sal();

                            ModoPesquisa();

                            if (bllContasReceber.Sel_Mostrar_Opc_Doc_Fis_A_Salvar_Conta_Receber() == true)
                            {
                                DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];

                                DialogResult = MessageBox.Show("Deseja salvar o documento físico no sistema ou digitalizar o mesmo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    using (FrmDetalhesConta Det = new FrmDetalhesConta(SelectedRow.Cells[0].Value.ToString(), 1))
                                    {
                                        if (Det.ShowDialog() == DialogResult.Abort)
                                        {
                                            dtContaReceber.Select();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    txtPalavraChave.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void rbtnNome_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNome_MouseLeave(object sender, EventArgs e)
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

        private void rbtnCodAluno_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodAluno_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDataCadastro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDataCadastro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDataEmissao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDataEmissao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDataVencimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDataVencimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodas_MouseLeave(object sender, EventArgs e)
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

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
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

        private void btnExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnDuplicar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDuplicar_MouseLeave(object sender, EventArgs e)
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

        private void rbtnCodAluno_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodas.Checked == true)
                {
                    if (bllContasReceber.Sel_Conta_Receber_Todas() == null)
                    {
                        dtContaReceber.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Todas();
                        dtContaReceber.Select();
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text);
                            dtContaReceber.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Codigo_Receber(txtpCodigo.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Codigo_Receber(txtpCodigo.Text);
                            dtContaReceber.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Palavra_Chave_Receber(txtpPalavraChave.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Palavra_Chave_Receber(txtpPalavraChave.Text);
                            dtContaReceber.Select();
                        }
                    }
                }
                else if (rbtnDestinatario.Checked == true)
                {
                    if (cbbpDestinatario.Text != "" & cbbpTipoDestinatario.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Destinatario_Receber(cbbpDestinatario.Text, cbbpTipoDestinatario.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Destinatario_Receber(cbbpDestinatario.Text, cbbpTipoDestinatario.Text);
                            dtContaReceber.Select();
                        }
                    }
                }
                else if (rbtnDataEmissao.Checked == true)
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData2.Text != "" && mtxtpData1.Text != "")
                    {
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData2.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllContasReceber.Sel_Conta_Receber_Data_Emissao(mtxtpData1.Text, mtxtpData2.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Data_Emissao(mtxtpData1.Text, mtxtpData2.Text);
                            dtContaReceber.Select();
                        }
                    }
                }
                else if (rbtnDataVencimento.Checked == true)
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData2.Text != "" && mtxtpData1.Text != "")
                    {
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData2.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllContasReceber.Sel_Conta_Receber_Data_Vencimento(mtxtpData1.Text, mtxtpData2.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Data_Vencimento(mtxtpData1.Text, mtxtpData2.Text);
                            dtContaReceber.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                _ComboboxEmitente_Valor = null;  
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadContaReceber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }
        }

        private void dtContaReceber_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtContaReceber.Columns[0].HeaderText = "Código";
                dtContaReceber.Columns[1].HeaderText = "Descrição";
                dtContaReceber.Columns[2].HeaderText = "Ocorrência/Parcela";
                dtContaReceber.Columns[3].HeaderText = "Data de Emissão";
                dtContaReceber.Columns[4].HeaderText = "Data de Vencimento";
                dtContaReceber.Columns[5].HeaderText = "Tipo do Documento";
                dtContaReceber.Columns[6].Visible = false;
                dtContaReceber.Columns[7].HeaderText = "Cód. do Destinatário";
                dtContaReceber.Columns[8].HeaderText = "Nome do Destinatário";
                dtContaReceber.Columns[9].HeaderText = "Valor do Documento (R$)";
                dtContaReceber.Columns[10].Visible = false;
                dtContaReceber.Columns[11].HeaderText = "Data do Desconto";
                dtContaReceber.Columns[12].HeaderText = "Desconto (%)";
                dtContaReceber.Columns[13].HeaderText = "Valor do Desconto (R$)";
                dtContaReceber.Columns[14].HeaderText = "Multa (%)";
                dtContaReceber.Columns[15].HeaderText = "Valor da Multa (R$)";
                dtContaReceber.Columns[16].HeaderText = "Mora (%)";
                dtContaReceber.Columns[17].HeaderText = "Valor da Mora (R$)";
                dtContaReceber.Columns[18].Visible = false;
                dtContaReceber.Columns[19].Visible = false;
                dtContaReceber.Columns[20].HeaderText = "Observações";
                dtContaReceber.Columns[21].HeaderText = "Palavra-Chave";
                dtContaReceber.Columns[22].Visible = false;
                dtContaReceber.Columns[23].Visible = false;

                dtContaReceber.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtContaReceber.Columns[0].Width = 95;
                dtContaReceber.Columns[1].Width = 325;
                dtContaReceber.Columns[2].Width = 146;
                dtContaReceber.Columns[3].Width = 150;
                dtContaReceber.Columns[4].Width = 150;
                dtContaReceber.Columns[5].Width = 200;
                dtContaReceber.Columns[7].Width = 135;
                dtContaReceber.Columns[8].Width = 325;
                dtContaReceber.Columns[9].Width = 162;
                dtContaReceber.Columns[11].Width = 150;
                dtContaReceber.Columns[12].Width = 150;
                dtContaReceber.Columns[13].Width = 150;
                dtContaReceber.Columns[14].Width = 150;
                dtContaReceber.Columns[15].Width = 150;
                dtContaReceber.Columns[16].Width = 150;
                dtContaReceber.Columns[17].Width = 150;
                dtContaReceber.Columns[20].Width = 500;
                dtContaReceber.Columns[21].Width = 150;

                dtContaReceber.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtContaReceber.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtContaReceber.DefaultCellStyle.Font = new Font(dtContaReceber.Font, FontStyle.Bold);

                DataGridViewRow SelectedRow = dtContaReceber.Rows[e.RowIndex];
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                txtParcela.Text = SelectedRow.Cells[2].Value.ToString();
                mtxtDataEmissao.Text = SelectedRow.Cells[3].Value.ToString();
                mtxtDataVencimento.Text = SelectedRow.Cells[4].Value.ToString();
                cbbTipoDocumento.Text = SelectedRow.Cells[5].Value.ToString();
                if (SelectedRow.Cells[6].Value.ToString() == "0")
                {
                    cbbTipoDestinatario.Text = "ALUNO(A)";
                }
                else if (SelectedRow.Cells[6].Value.ToString() == "1")
                {
                    cbbTipoDestinatario.Text = "FORNECEDOR(A)";
                }
                else if (SelectedRow.Cells[6].Value.ToString() == "2")
                {
                    cbbTipoDestinatario.Text = "FUNCIONARIO(A)";
                }
                cbbDestinatario.Items.Clear();
                cbbDestinatario.Items.Add(SelectedRow.Cells[7].Value.ToString() + "-" + SelectedRow.Cells[8].Value.ToString());
                cbbDestinatario.Text = SelectedRow.Cells[7].Value.ToString() + "-" + SelectedRow.Cells[8].Value.ToString();
                dtContaReceber.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[9].DefaultCellStyle.Format = "c";
                txtValorDocumento.Text = Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR"));
                mtxtDataDesconto.Text = SelectedRow.Cells[11].Value.ToString();
                dtContaReceber.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[12].DefaultCellStyle.Format = "n2";
                txtDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtContaReceber.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[13].DefaultCellStyle.Format = "c";
                txtValorDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[13].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtContaReceber.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[14].DefaultCellStyle.Format = "n2";
                txtMulta.Text = Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtContaReceber.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[15].DefaultCellStyle.Format = "c";
                txtValorMulta.Text = Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtContaReceber.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[16].DefaultCellStyle.Format = "n2";
                txtMora.Text = Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtContaReceber.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[17].DefaultCellStyle.Format = "c";
                rtxtObs.Text = SelectedRow.Cells[20].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[21].Value.ToString();
                if (SelectedRow.Cells[22].Value.ToString() == "1")
                {
                    chkbVencDiaUtil.Checked = true;
                }
                else
                {
                    chkbVencDiaUtil.Checked = false;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                _ComboboxEmitente_Valor = null;
            }
        }               

        private void dtContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtContaReceber.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else 
            {
                this.Cursor = Cursors.IBeam;            
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];

            try
            {
                if (bllContasReceber.Sel_Excluir_Conta_Receber_Fechada() == false & bllContasReceber.Sel_Situacao_Conta(SelectedRow.Cells[0].Value.ToString()) == true)
                {
                    MessageBox.Show("Não é possível excluir uma conta fechada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnExcluir.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja realmente excluir esta conta?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {

                        bllContasReceber.Excluir(txtCodigo.Text);

                        if (rbtnTodas.Checked == true)
                        {
                            if (bllContasReceber.Sel_Conta_Receber_Todas() == null)
                            {
                                dtContaReceber.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Todas();
                                dtContaReceber.Select();
                            }
                        }
                        else if (rbtnDescricao.Checked == true)
                        {
                            if (txtpDescricao.Text != "")
                            {
                                if (bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text) == null)
                                {
                                    dtContaReceber.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text);
                                    dtContaReceber.Select();
                                }
                            }
                            else
                            {
                                dtContaReceber.DataSource = null;
                                Limpar();
                            }
                        }                        
                        else if (rbtnDataEmissao.Checked == true)
                        {
                            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpData2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                            if (mtxtpData1.Text != "" && mtxtpData2.Text != "")
                            {
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData2.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                if (bllContasReceber.Sel_Conta_Receber_Data_Emissao(mtxtpData1.Text, mtxtpData2.Text) == null)
                                {
                                    dtContaReceber.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Data_Emissao(mtxtpData1.Text, mtxtpData2.Text);
                                    dtContaReceber.Select();
                                }
                            }
                            else
                            {
                                dtContaReceber.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnDataVencimento.Checked == true)
                        {
                            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpData2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                            if (mtxtpData1.Text != "" && mtxtpData2.Text != "")
                            {
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData2.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                if (bllContasReceber.Sel_Conta_Receber_Data_Vencimento(mtxtpData1.Text, mtxtpData2.Text) == null)
                                {
                                    dtContaReceber.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Data_Vencimento(mtxtpData1.Text, mtxtpData2.Text);
                                    dtContaReceber.Select();
                                }
                            }
                            else
                            {
                                dtContaReceber.DataSource = null;
                                Limpar();
                            }
                        }                   
                        else if (rbtnDestinatario.Checked == true)
                        {
                            if (rbtnDestinatario.Text != "")
                            {
                                if (bllContasReceber.Sel_Conta_Destinatario_Receber(cbbpDestinatario.Text, cbbpTipoDestinatario.Text) == null)
                                {
                                    dtContaReceber.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Destinatario_Receber(cbbpDestinatario.Text, cbbpTipoDestinatario.Text);
                                    dtContaReceber.Select();
                                }
                            }
                        }
                        else
                        {
                            dtContaReceber.DataSource = null;
                            Limpar();
                        }
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        if (dtContaReceber.DataSource != null)
                        {
                            dtContaReceber.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void dtContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtContaReceber_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtContaReceber.DataSource == null)
            {
                btnAlterar.Enabled = false;
                btnCriarLembrete.Enabled = false;
                btnExcluir.Enabled = false;
            }
            else
            {
                btnAlterar.Enabled = true;
                btnCriarLembrete.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }        

        private void mtxtpData1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text == "")
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtpData2_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData2.Text == "")
            {
                mtxtpData2.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData2.Select();
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
                btnPesquisar.Select();
            }
        }

        private void mtxtpData2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoDocumento.Select();
            }
        }

        private void mtxtDataEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataVencimento.Select();
            }
        }

        private void cbbTipoCobranca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataEmissao.Select();

            }
        }

        private void mtxtDataVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();  
            }
        }

        private void mtxtDataDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDesconto.Select();
            }
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoDestinatario.Select();    
            }
        }        

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por descrição, código, destinatário, data de emissão, data de vencimento, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\r1 - Clicando no botão < Novo > você insere novos dados, ao finalizar clique no botão < Salvar >.\r2 - Clicando no botão < Alterar > você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão < Salvar >.\r3 - Clicando no botao < Excluir > você estará excluindo os dados selecionados na tabela.\r4 - Se por algum um motivo você clicou no botão: < Novo > ou no botão: < Alterar > e não deseja continuar nessas opções, clique no botão: < Cancelar >.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mtxtDataDesconto.Text);
        }

        private void txtParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13) 
            {
                txtDescricao.Select();
            }
        }

        private void pcibInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Desconto: O valor informado neste campo só será descontado até o dia do vencimento.\n2 - Multa: O valor informado neste campo só será acrescentado(Em apenas uma instância) se a conta passar da data de vencimento.\n\nLembrando que esses campos trabalham com a porcentagem (%).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pcibInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
      
        private void dtContaReceber_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtContaReceber.Rows.Count;
        }

        private void dtContaReceber_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
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

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTipoDestinatario.Visible = false;
            btnpProcurar.Visible = false;
            cbbpDestinatario.Visible = false;
            btnSelecionarData.Visible = false;
            txtpPalavraChave.Visible = true;
            lblAte.Visible = false;
            txtpDescricao.Visible = false;
            mtxtpData1.Visible = false;
            mtxtpData2.Visible = false;
            lblPesquisar.Location = new Point(426, 21);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpCodigo.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpPalavraChave.Text = null;
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            using (FrmPesqClieFornFunc Pesq = new FrmPesqClieFornFunc(cbbpTipoDestinatario.Text, 1))
            {
                if (Pesq.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpDestinatario.Items.Clear();

                        if (cbbpTipoDestinatario.SelectedIndex == 0)
                        {
                            if (bllContasReceber.Sel_Aluno_Cont_Receber() == null)
                            {
                                cbbpDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Aluno_Cont_Receber().Rows)
                                {
                                    cbbpDestinatario.Items.Add((dr["id_aluno"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        else if (cbbpTipoDestinatario.SelectedIndex == 1)
                        {
                            if (bllContasReceber.Sel_Forn_Cont_Receber() == null)
                            {
                                cbbpDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Forn_Cont_Receber().Rows)
                                {
                                    cbbpDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        else if (cbbpTipoDestinatario.SelectedIndex == 2)
                        {
                            if (bllContasReceber.Sel_Func_Cont_Receber() == null)
                            {
                                cbbpDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Func_Cont_Receber().Rows)
                                {
                                    cbbpDestinatario.Items.Add((dr["id_funcionario"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        if (bllContasReceber._Emitente_PesqContaReceber_Tabela == "Alunos(a)")
                        {
                            cbbpTipoDestinatario.Text = "ALUNO(A)";
                        }
                        else if (bllContasReceber._Emitente_PesqContaReceber_Tabela == "Fornecedores(a)")
                        {
                            cbbpTipoDestinatario.Text = "FORNECEDOR(A)";
                        }
                        else if (bllContasReceber._Emitente_PesqContaReceber_Tabela == "Funcionarios(a)")
                        {
                            cbbpTipoDestinatario.Text = "FUNCIONARIO(A)";
                        }
                        cbbpDestinatario.Text = bllContasReceber._Emitente_PesqContaReceber;
                        bllContasReceber._Emitente_PesqContaReceber = null;
                        bllContasReceber._Emitente_PesqContaReceber_Tabela = null;
                        btnPesquisar.Select();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpDescricao.Text = null;
                        dtContaReceber.DataSource = null;
                        rbtnDescricao.Checked = true;
                        txtpDescricao.Select();
                        ModoPesquisa();
                        Limpar();
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                        _ComboboxEmitente_Valor = null;
                    }
                }
                else
                {
                    bllContasReceber._Emitente_PesqContaReceber = null;
                    bllContasReceber._Emitente_PesqContaReceber_Tabela = null;
                    btnPesquisar.Select();
                }
            }
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_Leave(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.White;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtDescricao.Select();
            }
        }

        private void cbbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                mtxtDataEmissao.Select();
            }
        }

        private void cbbTipoDestinatarioo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                cbbDestinatario.Select();
            }
        }

        private void cbbDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtValorDocumento.Select();
            }
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
                mtxtDataDesconto.Select();
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
                if (txtValorMulta.Text.Contains("'") || txtValorMulta.Text.Contains(";") || txtValorMulta.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValorMulta.Text = null;
                }
                else
                {
                    try
                    {
                        txtValorDocumento.Text = decimal.Parse(txtValorDocumento.Text, new CultureInfo("pt-BR")).ToString("n2");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValorDocumento.Text = null;
                    }
                }
            }
            txtValorDocumento.BackColor = Color.White;        
        }

        private void mtxtDataDesconto_Enter_1(object sender, EventArgs e)
        {
            mtxtDataDesconto.BackColor = Color.LightBlue;
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            txtDesconto.BackColor = Color.LightBlue;
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            if (txtDesconto.Text.Contains("'") || txtDesconto.Text.Contains(";") || txtDesconto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDesconto.Text = null;
            }
            else
            {
                if (txtDesconto.Text != "")
                {
                    if (Convert.ToDecimal(txtDesconto.Text) > 100)
                    {
                        MessageBox.Show("Valor inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDesconto.Text = null;
                        txtValorDesconto.Text = null;
                    }
                    else
                    {
                        try
                        {
                            txtDesconto.Text = decimal.Parse(txtDesconto.Text, new CultureInfo("pt-BR")).ToString("n2");

                            if (txtValorDocumento.Text != "")
                            {
                                txtValorDesconto.Text = bllContasPagar.Calculo_Desconto(txtValorDocumento.Text, txtDesconto.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDesconto.Text = null;
                        }
                    }
                }
            }
            txtDesconto.BackColor = Color.White;
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDesconto.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValorDesconto.Select();
            }
        }

        private void txtValorMulta_Enter(object sender, EventArgs e)
        {
            txtValorMulta.BackColor = Color.LightBlue;
        }

        private void txtValorMulta_Leave(object sender, EventArgs e)
        {
            if (txtValorMulta.Text != "")
            {
                if (txtValorMulta.Text.Contains("'") || txtValorMulta.Text.Contains(";") || txtValorMulta.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValorMulta.Text = null;
                }
                else
                {
                    try
                    {
                        txtValorMulta.Text = decimal.Parse(txtValorMulta.Text, new CultureInfo("pt-BR")).ToString("n2");

                        if (txtValorDocumento.Text != "")
                        {
                            txtMulta.Text = bllContasPagar.Calculo_Multa(txtValorDocumento.Text, txtValorMulta.Text);

                            txtMulta.Text = decimal.Parse(txtMulta.Text, new CultureInfo("pt-BR")).ToString("n2");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValorMulta.Text = null;
                    }
                }
            }
            txtValorMulta.BackColor = Color.White;
        }

        private void txtValorMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorMulta.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtMora.Select();
            }
        }

        private void txtMora_Enter(object sender, EventArgs e)
        {
            txtMora.BackColor = Color.LightBlue;
        }

        private void txtMora_Leave(object sender, EventArgs e)
        {
            if (txtMora.Text.Contains("'") || txtMora.Text.Contains(";") || txtMora.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMora.Text = null;
            }
            else
            {
                if (txtMora.Text != "")
                {
                    if (Convert.ToDecimal(txtMora.Text) > 100)
                    {
                        MessageBox.Show("Valor inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMora.Text = null;
                    }
                    else
                    {
                        try
                        {
                            txtMora.Text = decimal.Parse(txtMora.Text, new CultureInfo("pt-BR")).ToString("n2");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMora.Text = null;
                        }
                    }
                }
            }
            txtMora.BackColor = Color.White;
        }

        private void txtMora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMora.Text.Contains(",") && e.KeyChar == (char)44)
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

        private void cbbTipoDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDocumento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDocumento_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDestinatarioo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDestinatarioo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDestinatarioo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDestinatarioo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDestinatario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoDestinatario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpDestinatario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbVencDiaUtil_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbVencDiaUtil_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    if (cbbTipoDestinatario.SelectedIndex == 0)
                    {
                        cbbDestinatario.Items.Clear();
                        if (bllContasReceber.Sel_Aluno_Cont_Receber() == null)
                        {
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_Aluno_Cont_Receber().Rows)
                            {
                                cbbDestinatario.Items.Add((dr["id_aluno"].ToString()) + "-" + (dr["nome"].ToString()));
                            }
                        }
                    }
                    else if (cbbTipoDestinatario.SelectedIndex == 1)
                    {
                        cbbDestinatario.Items.Clear();
                        if (bllContasReceber.Sel_Forn_Cont_Receber() == null)
                        {
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_Forn_Cont_Receber().Rows)
                            {
                                cbbDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                            }
                        }
                    }
                    else if (cbbTipoDestinatario.SelectedIndex == 2)
                    {
                        cbbDestinatario.Items.Clear();
                        if (bllContasReceber.Sel_Func_Cont_Receber() == null)
                        {
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_Func_Cont_Receber().Rows)
                            {
                                cbbDestinatario.Items.Add((dr["id_funcionario"].ToString()) + "-" + (dr["nome"].ToString()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbDestinatario.Text = null;
                }
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            using (FrmPesqClieFornFunc Pesq = new FrmPesqClieFornFunc(cbbTipoDestinatario.Text, 1))
            {
                if (Pesq.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbDestinatario.Items.Clear();

                        if (cbbTipoDestinatario.SelectedIndex == 0)
                        {
                            if (bllContasReceber.Sel_Aluno_Cont_Receber() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Aluno_Cont_Receber().Rows)
                                {
                                    cbbDestinatario.Items.Add((dr["id_aluno"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        else if (cbbTipoDestinatario.SelectedIndex == 1)
                        {
                            if (bllContasReceber.Sel_Forn_Cont_Receber() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Forn_Cont_Receber().Rows)
                                {
                                    cbbDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        else if (cbbTipoDestinatario.SelectedIndex == 2)
                        {
                            if (bllContasReceber.Sel_Func_Cont_Receber() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_Func_Cont_Receber().Rows)
                                {
                                    cbbDestinatario.Items.Add((dr["id_funcionario"].ToString()) + "-" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        if (bllContasReceber._Emitente_PesqContaReceber_Tabela == "Alunos(a)")
                        {
                            cbbTipoDestinatario.Text = "ALUNO(A)";
                        }
                        else if (bllContasReceber._Emitente_PesqContaReceber_Tabela == "Fornecedores(a)")
                        {
                            cbbTipoDestinatario.Text = "FORNECEDOR(A)";
                        }
                        else if (bllContasReceber._Emitente_PesqContaReceber_Tabela == "Funcionarios(a)")
                        {
                            cbbTipoDestinatario.Text = "FUNCIONARIO(A)";
                        }
                        cbbDestinatario.Text = bllContasReceber._Emitente_PesqContaReceber;
                        bllContasReceber._Emitente_PesqContaReceber = null;
                        bllContasReceber._Emitente_PesqContaReceber_Tabela = null;
                        btnPesquisar.Select();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpDescricao.Text = null;
                        dtContaReceber.DataSource = null;
                        rbtnDescricao.Checked = true;
                        txtpDescricao.Select();
                        ModoPesquisa();
                        Limpar();
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                        _ComboboxEmitente_Valor = null;
                    }
                }
                else
                {
                    bllContasReceber._Emitente_PesqContaReceber = null;
                    bllContasReceber._Emitente_PesqContaReceber_Tabela = null;
                }
            }
        }

        private void cbbpTipoDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpDestinatario.Items.Clear();

                if (cbbpTipoDestinatario.SelectedIndex == 0)
                {
                    if (bllContasReceber.Sel_Aluno_Cont_Receber() == null)
                    {
                        cbbpDestinatario.Text = null;
                    }
                    else
                    {
                        foreach (DataRow dr in bllContasReceber.Sel_Aluno_Cont_Receber().Rows)
                        {
                            cbbpDestinatario.Items.Add((dr["id_aluno"].ToString()) + "-" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoDestinatario.SelectedIndex == 1)
                {
                    if (bllContasReceber.Sel_Forn_Cont_Receber() == null)
                    {
                        cbbpDestinatario.Text = null;
                    }
                    else
                    {
                        foreach (DataRow dr in bllContasReceber.Sel_Forn_Cont_Receber().Rows)
                        {
                            cbbpDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "-" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoDestinatario.SelectedIndex == 2)
                {
                    if (bllContasReceber.Sel_Func_Cont_Receber() == null)
                    {
                        cbbpDestinatario.Text = null;
                    }
                    else
                    {
                        foreach (DataRow dr in bllContasReceber.Sel_Func_Cont_Receber().Rows)
                        {
                            cbbpDestinatario.Items.Add((dr["id_funcionario"].ToString()) + "-" + (dr["nome"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void txtValorDocumento_TextChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                txtDesconto.Text = "";
                txtValorDesconto.Text = "";
                txtMulta.Text = "";
                txtValorMulta.Text = "";
            }
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            using (FrmDatePicker2 Data = new FrmDatePicker2(2))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataEmissao.Text = bllContasReceber._Data_DatePicker1;
                    mtxtDataVencimento.Text = bllContasReceber._Data_DatePicker2;
                    bllContasReceber._Data_DatePicker1 = null;
                    bllContasReceber._Data_DatePicker2 = null;
                    mtxtDataVencimento.Select();
                }
            }
        }

        private void btnSelecionarData3_Click(object sender, EventArgs e)
        {
            using (FrmDataPicker Data = new FrmDataPicker(1))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataDesconto.Text = bllContasReceber._Data_DatePicker1;
                    bllContasReceber._Data_DatePicker1 = null;
                    mtxtDataDesconto.Select();
                }
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            using (FrmDatePicker2 Data = new FrmDatePicker2(2))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData1.Text = bllContasReceber._Data_DatePicker1;
                    mtxtpData2.Text = bllContasReceber._Data_DatePicker2;
                    bllContasReceber._Data_DatePicker1 = null;
                    bllContasReceber._Data_DatePicker2 = null;
                    btnPesquisar.Select();
                }
            }
        }

        private void btnCriarLembrete_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCriarLembrete_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCriarLembrete_Click(object sender, EventArgs e)
        {
            using (FrmUtilCadLembrete Lemb = new FrmUtilCadLembrete(txtPalavraChave.Text, mtxtDataVencimento.Text, txtDescricao.Text, rtxtObs.Text))
            {
                if (Lemb.ShowDialog() == DialogResult.OK)
                {
                    dtContaReceber.Select();
                }
            }
        }

        private void FrmCadContaReceber_FormClosing(object sender, FormClosingEventArgs e)
        {
            bllContasReceber._FrmCadContaReceber_Ativo = false;
        }   
    }
}
