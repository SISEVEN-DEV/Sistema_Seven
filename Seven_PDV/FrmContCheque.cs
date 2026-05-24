using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmContCheque : Form
    {
        public FrmContCheque(string consumidor, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Consumidor = consumidor;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Consumidor;

        private void FrmPesqFuncao_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContCheque iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContCheque iniciado.");
                }
                //
                if (bllControleCheque.Sel_Cliente_Controle_Cheque() == null)
                {
                    cbbCliente.Enabled = false;
                    cbbCliente.Text = null;
                }
                else
                {
                    cbbCliente.Enabled = true;
                    cbbCliente.Items.Add("");
                    foreach (DataRow dr in bllControleCheque.Sel_Cliente_Controle_Cheque().Rows)
                    {
                        cbbCliente.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString());
                    }
                }
                cbbCliente.Text = _Consumidor;
                //
                if (bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque() == null)
                {
                    cbbBanco.Enabled = false;
                    cbbBanco.Text = null;
                }
                else
                {
                    cbbBanco.Enabled = true;
                    cbbBanco.Items.Add("");
                    foreach (DataRow dr in bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque().Rows)
                    {
                        cbbBanco.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                txtBeneficiario.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                //
                cbbCliente.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelFuncionario.");
                }
                this.Close();
            }
        }

        private void Limpar()
        {
            cbbCliente.Text = null;
            cbbBanco.Text = null;
            txtNCheque.Text = null;
            txtBeneficiario.Text = null;
            txtAgencia.Text = null;
            txtConta.Text = null;
            txtValorCheque.Text = null;
            mtxtDataVencimento.Text = null;
            txtObs.Text = null;
        }

        private void txtNCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtConta.Select();
            }
        }

        private void mtxtpDataEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCliente.Select();
            }
        }

        private void cbbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbBanco.Select();
            }
        }

        private void cbbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNCheque.Select();
            }
        }

        private void txtValorCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorCheque.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtBeneficiario.Select();
            }
        }

        private void mtxtDataVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtObs.Select();
            }
        }

        private void mtxtDataCompensacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtObs.Select();
            }
        }

        private void txtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtNCheque_Enter(object sender, EventArgs e)
        {
            txtNCheque.BackColor = Color.LightBlue;
        }

        private void txtValorCheque_Enter(object sender, EventArgs e)
        {
            txtValorCheque.BackColor = Color.LightBlue;
        }

        private void mtxtDataVencimento_Enter(object sender, EventArgs e)
        {
            mtxtDataVencimento.BackColor = Color.LightBlue;
        }

        private void txtObs_Enter(object sender, EventArgs e)
        {
            txtObs.BackColor = Color.LightBlue;
        }

        private void txtNCheque_Leave(object sender, EventArgs e)
        {
            if (txtNCheque.Text.Contains("'") || txtNCheque.Text.Contains(";") || txtNCheque.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNCheque.Text = null;
                txtNCheque.Select();
            }
            txtNCheque.BackColor = Color.White;
        }

        private void txtValorCheque_Leave(object sender, EventArgs e)
        {
            if (txtValorCheque.Text != "")
            {
                if (txtValorCheque.Text.Contains("'") || txtValorCheque.Text.Contains(";") || txtValorCheque.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorCheque.Text = null;
                    txtValorCheque.Select();
                }
                else
                {
                    try
                    {
                        txtValorCheque.Text = Convert.ToDecimal(txtValorCheque.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorCheque.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorCheque.");
                        }
                        txtValorCheque.Text = null;
                    }
                }
            }
            txtValorCheque.BackColor = Color.White;
        }

        private void mtxtDataVencimento_Leave(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text != "")
            {
                try
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataVencimento.Text);
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

        private void txtObs_Leave(object sender, EventArgs e)
        {
            if (txtObs.Text.Contains("'") || txtObs.Text.Contains(";") || txtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtObs.Text = null;
                txtObs.Select();
            }
            txtObs.BackColor = Color.White;
        }

        private void txtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + txtObs.Text.Length + "/200";
        }

        private void btnSelecionarDataVencimento_Click(object sender, EventArgs e)
        {
            using (FrmDatePicker Data = new FrmDatePicker(3))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataVencimento.Text = bllControleCheque._Data_DatePicker1;
                }
            }
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

        private void btnProcurarCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCliente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbBanco_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbBanco_MouseHover(object sender, EventArgs e)
        {

        }

        private void cbbBanco_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbBanco_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbBanco_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarBanco_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarBanco_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarDataVencimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarDataVencimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarDataCompensacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarDataCompensacao_MouseLeave(object sender, EventArgs e)
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

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtBeneficiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataVencimento.Select();
            }
        }

        private void txtBeneficiario_Enter(object sender, EventArgs e)
        {
            txtBeneficiario.BackColor = Color.LightBlue;
        }

        private void txtBeneficiario_Leave(object sender, EventArgs e)
        {
            if (txtBeneficiario.Text.Contains("'") || txtBeneficiario.Text.Contains(";") || txtBeneficiario.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtBeneficiario.Text = null;
                txtBeneficiario.Select();
            }
            txtBeneficiario.BackColor = Color.White;
        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            using (FrmPesqConsumidor Clie = new FrmPesqConsumidor(3, null, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCliente.Items.Clear();
                        if (bllControleCheque.Sel_Cliente_Controle_Cheque() == null)
                        {
                            cbbCliente.Enabled = false;
                            cbbCliente.Text = null;
                        }
                        else
                        {
                            cbbCliente.Enabled = true;
                            cbbCliente.Items.Add("");
                            foreach (DataRow dr in bllControleCheque.Sel_Cliente_Controle_Cheque().Rows)
                            {
                                cbbCliente.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString());
                            }
                        }
                        //
                        cbbCliente.Text = bllControleCheque._Consumidor_PesqControleCheque;
                        bllControleCheque._Consumidor_PesqControleCheque = null;
                        cbbCliente.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        bllControleCheque._Consumidor_PesqControleCheque = null;
                        cbbCliente.Text = null;
                    }
                }
            }
        }

        private void btnProcurarBanco_Click(object sender, EventArgs e)
        {
            using (FrmPesqEntidadeBancaria Ent = new FrmPesqEntidadeBancaria(2))
            {
                if (Ent.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbBanco.Items.Clear();
                        if (bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque() == null)
                        {
                            cbbBanco.Enabled = false;
                            cbbBanco.Text = null;
                        }
                        else
                        {
                            cbbBanco.Enabled = true;
                            cbbBanco.Items.Add("");
                            foreach (DataRow dr in bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque().Rows)
                            {
                                cbbBanco.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbBanco.Text = bllControleCheque._Entidade_Bancaria_PesqControleCheque;
                        bllControleCheque._Entidade_Bancaria_PesqControleCheque = null;
                        cbbBanco.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarBanco.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarBanco.");
                        }
                        cbbBanco.Text = null;
                    }
                }
            }
        }

        private void cbbCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbCliente.Text != "")
                {
                    string[] items = cbbCliente.Text.Split('—');

                    if ((cbbCliente.Text.Split('—').Length - 1) == 1)
                    {
                        MessageBox.Show("Não é possível selecionar um consumidor sem CPF/CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                this.DialogResult = DialogResult.None;
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

        private void FrmCadContCheque_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmCadContCheque_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FrmCadContCheque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void mtxtDataVencimento_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "")
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataVencimento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataVencimento.Text == "")
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void txtAgencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorCheque.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtAgencia_Enter(object sender, EventArgs e)
        {
            txtAgencia.BackColor = Color.LightBlue;
        }

        private void txtConta_Enter(object sender, EventArgs e)
        {
            txtConta.BackColor = Color.LightBlue;
        }

        private void txtAgencia_Leave(object sender, EventArgs e)
        {
            if (txtAgencia.Text.Contains("'") || txtAgencia.Text.Contains(";") || txtAgencia.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtAgencia.Text = null;
                txtAgencia.Select();
            }
            txtAgencia.BackColor = Color.White;
        }

        private void txtConta_Leave(object sender, EventArgs e)
        {
            if (txtConta.Text.Contains("'") || txtConta.Text.Contains(";") || txtConta.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtConta.Text = null;
                txtConta.Select();
            }
            txtConta.BackColor = Color.White;
        }

        private void FrmCadContCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContCheque foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContCheque foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadContCheque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadContCheque.");
                }
            }
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere dados.\n\n1 - Você insere novos dados, ao finalizar clique no botão [ Salvar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                //
                if (cbbCliente.Text == "" || cbbBanco.Text == "" || txtNCheque.Text.Trim() == "" || txtAgencia.Text.Trim() == "" || txtConta.Text.Trim() == "" || txtValorCheque.Text == "" || txtBeneficiario.Text == "" || mtxtDataVencimento.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Cliente/Consumidor/Emitente ], [ Banco/Entidade Bancária ], [ Nº do Cheque ], [ Agência ], [ Conta ],\n[ Beneficiário ], [ Data de Vencimento ] e [ Valor do Cheque ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
                else
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    try
                    {
                        bllVenda._Dados_Cheque.Add(cbbCliente.Text + "—" + cbbBanco.Text + "—" + txtNCheque.Text.Trim() + "—" + txtBeneficiario.Text.Trim() + "—" + txtAgencia.Text.Trim() + "—" + txtConta.Text.Trim() + "—" + txtValorCheque.Text.Trim() + "—" + mtxtDataVencimento.Text + "—" + txtObs.Text.Trim());
                        //
                        bllVenda._Valor_Cheque = txtValorCheque.Text.Trim();
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        Limpar();
                    }
                }
            }
            else
            {
                cbbCliente.Select();
            }
        }

        private void txtConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAgencia.Select();
            }
        }

        private void lblBeneficiario_Click(object sender, EventArgs e)
        {

        }

        private void txtBeneficiario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
