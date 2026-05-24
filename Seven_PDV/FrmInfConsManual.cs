using BLL;
using Seven_ADM;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmInfConsManual : Form
    {
        public FrmInfConsManual(string tabela, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Tabela = tabela;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Tabela;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmHistOrcamentoItens_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfConsManual iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfConsManual iniciado.");
                }
                //
                rbtnPfisica.Checked = true;
                txtNome.Text = "CONSUMIDOR FINAL";
                mtxtCPF.Select();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInfConsManual.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInfConsManual.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmHistOrcamentoItens_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
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

        private void rbtnPfisica_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPfisica_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPjuridica_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPjuridica_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPjuridica.Checked == true)
                {
                    mtxtCNPJ.Select();
                }
                else
                {
                    mtxtCPF.Select();
                }
            }
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.LightBlue;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Text.Contains("'") || txtNome.Text.Contains(";") || txtNome.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNome.Text = null;
                txtNome.Select();
            }
            txtNome.BackColor = Color.White;
        }

        private void mtxtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIncluir.Select();
            }
        }

        private void mtxtCPF_Enter(object sender, EventArgs e)
        {
            mtxtCPF.BackColor = Color.LightBlue;
        }

        private void mtxtCPF_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCPF.Text != "")
                {
                    if (ValidarCNPJECPF.ValidarCPF(mtxtCPF.Text))
                    {
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCPF.Text = null;
                        mtxtCPF.Select();
                    }
                }
                else
                {
                    mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPF.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPF.");
                }
                mtxtCPF.Text = null;
            }
            mtxtCPF.BackColor = Color.White;
        }

        private void mtxtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIncluir.Select();
            }
        }

        private void mtxtCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtCNPJ.BackColor = Color.LightBlue;
        }

        private void mtxtCNPJ_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCNPJ.Text != "")
                {
                    if (ValidarCNPJECPF.ValidaCNPJ(mtxtCNPJ.Text))
                    {
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;                        
                    }
                    else
                    {
                        MessageBox.Show("CNPJ inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCNPJ.Text = null;
                        mtxtCNPJ.Select();
                    }
                }
                else
                {
                    mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCNPJ.");
                }
                mtxtCNPJ.Text = null;
            }
            mtxtCNPJ.BackColor = Color.White;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void rbtnPfisica_CheckedChanged(object sender, EventArgs e)
        {
            lblCPF_CNPJ.Text = "CPF:";
            mtxtCPF.Text = null;
            mtxtCNPJ.Visible = false;
            mtxtCPF.Visible = true;
            lblNome.Text = "Nome:";
            lblAsterisco1.Location = new Point(309, 36);
            lblAsterisco2.Location = new Point(39, 36);
            mtxtCPF.Text = null;
            txtNome.Enabled = true;
            lblNome.Enabled = true;
            lblAsterisco2.Enabled = true;
            lblCNPJMensagem.Visible = false;
            mtxtCPF.Select();
        }

        private void rbtnPjuridica_CheckedChanged(object sender, EventArgs e)
        {
            lblCPF_CNPJ.Text = "CNPJ:";
            mtxtCNPJ.Text = null;
            mtxtCNPJ.Visible = true;
            mtxtCPF.Visible = false;
            lblNome.Text = "Razão Social:";
            lblAsterisco1.Location = new Point(316, 36);
            lblAsterisco2.Location = new Point(74, 36);
            mtxtCNPJ.Text = null;
            txtNome.Enabled = false;
            lblNome.Enabled = false;
            txtNome.Text = "CONSUMIDOR FINAL";
            lblAsterisco2.Enabled = false;
            lblCNPJMensagem.Visible = true;
            mtxtCNPJ.Select();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    mtxtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (txtNome.Text == "")
                    {
                        txtNome.Text = "CONSUMIDOR FINAL";
                    }
                    //
                    if (txtNome.Text == "" || (mtxtCPF.Text == "" & mtxtCNPJ.Text == ""))
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Nome ] e [ CPF/CNPJ ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNome.Select();
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (rbtnPfisica.Checked == true)
                        {
                            if (bllClieCons.Sel_C_CPF_CNPJ(mtxtCPF.Text) == true)
                            {
                                MessageBox.Show("O CPF informado já está cadastrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(mtxtCPF.Text).Rows[0];
                                //
                                if (drClie["situacao"].ToString() == "BLOQUEADO")
                                {
                                    MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else if (drClie["situacao"].ToString() == "INATIVO")
                                {
                                    MessageBox.Show("O Consumidor está com a situação cadastral [ Inativo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    bllVenda._PDV_PesqCliente_Tabela = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                    //
                                    bllVenda.Alterar_Consumidor_PDV(drClie["id_cliente"].ToString(), drClie["nome"].ToString(), drClie["cpf_cnpj"].ToString(), _Tabela, bllConexao._Codigo_Conexao);
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            else
                            {
                                DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];

                                bllClieCons.Salvar(txtNome.Text.Trim(), null, null, null, mtxtCPF.Text, null, null, null, dr["endereco"].ToString(), dr["numero"].ToString(), null, dr["bairro"].ToString(), dr["cidade"].ToString(), dr["uf"].ToString(), dr["cep"].ToString(), null, null, null, null, null, null, null, null, null, null, null, "Pessoa Física", null, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, _Cod_PDV_Computador, "4—CLIENTES NO GERAL", "4—GERAL", dr["codigo_municipio"].ToString());

                                DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(mtxtCPF.Text).Rows[0];
                                //
                                bllVenda._PDV_PesqCliente_Tabela = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                //
                                bllVenda.Alterar_Consumidor_PDV(drClie["id_cliente"].ToString(), drClie["nome"].ToString(), drClie["cpf_cnpj"].ToString(), _Tabela, bllConexao._Codigo_Conexao);
                                //
                                this.DialogResult = DialogResult.OK;
                                /*
                                string cpf;
                                if (mtxtCPF.Text == "   .   .   -" || mtxtCPF.Text == "___.___.___-__")
                                {
                                    cpf = "";
                                }
                                else
                                {
                                    cpf = "—" + mtxtCPF.Text;
                                }
                                //
                                bllVenda._PDV_PesqCliente_Tabela = "0—" + txtNome.Text.Trim() + cpf;
                                //
                                bllVenda.Alterar_Consumidor_PDV("0", txtNome.Text.Trim(), mtxtCPF.Text, _Tabela, bllConexao._Codigo_Conexao);
                                */
                            }
                        }
                        else
                        {
                            if (bllClieCons.Sel_C_CPF_CNPJ(mtxtCNPJ.Text) == true)
                            {
                                MessageBox.Show("O CNPJ informado já está cadastrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(mtxtCNPJ.Text).Rows[0];
                                //
                                if (drClie["situacao"].ToString() == "BLOQUEADO")
                                {
                                    MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else if (drClie["situacao"].ToString() == "INATIVO")
                                {
                                    MessageBox.Show("O Consumidor está com a situação cadastral [ Inativo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    bllVenda._PDV_PesqCliente_Tabela = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                    //
                                    bllVenda.Alterar_Consumidor_PDV(drClie["id_cliente"].ToString(), drClie["nome"].ToString(), drClie["cpf_cnpj"].ToString(), _Tabela, bllConexao._Codigo_Conexao);
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            else
                            {
                                mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                //
                                string cnpj = mtxtCNPJ.Text;
                                //
                                mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                //ValidarCNPJECPF.BuscarCNPJ(mtxtCNPJ.Text, cnpj, _Cod_PDV_Computador, 0, _Usuario);
                                //
                                //DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(mtxtCNPJ.Text).Rows[0];
                                //
                                /*
                                if (drClie["ie_rg"].ToString() == "")
                                {
                                    DialogResult = MessageBox.Show("ATENÇÃO!\nVerifique com o [ CONSUMIDOR ] se este [ CNPJ ] possui Inscrição Estadual (IE).\n\nClique em [ Sim ] para confirmar e informar a IE ou em [ Não ] caso não possua.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        using (FrmCadIE IE = new FrmCadIE(drClie["id_cliente"].ToString()))
                                        {
                                            if (IE.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                        }
                                    }
                                }
                                */
                                //
                                //bllVenda._PDV_PesqCliente_Tabela = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                //
                                //bllVenda.Alterar_Consumidor_PDV(drClie["id_cliente"].ToString(), drClie["nome"].ToString(), drClie["cpf_cnpj"].ToString(), _Tabela, bllConexao._Codigo_Conexao);
                                //
                                //this.DialogResult = DialogResult.OK;
                                /*
                                string cnpj;
                                if (mtxtCNPJ.Text == "  .   .   /    -" || mtxtCNPJ.Text == "__.___.___/____-__")
                                {
                                    cnpj = "";
                                }
                                else
                                {
                                    cnpj = "—" + mtxtCNPJ.Text;
                                }
                                //
                                bllVenda._PDV_PesqCliente_Tabela = "0—" + txtNome.Text.Trim() + cnpj;
                                //
                                bllVenda.Alterar_Consumidor_PDV("0", txtNome.Text.Trim(), mtxtCNPJ.Text, _Tabela, bllConexao._Codigo_Conexao);
                                */
                            }
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
            }
        }

        private void FrmInfConsManual_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfConsManual foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfConsManual foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmInfConsManual.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmInfConsManual.");
                }
            }
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Pessoa Física: Informe o [ CPF ] do cliente e o [ Nome ], por padrão o campo [ Nome ] já vem preenchido.\n\n2 - Pessoa Jurídica: Informe o [ CNPJ ] que será consultado online e preenchido, caso a inscrição estadual não seja localizada confirme com o cliente se o [ CNPJ ] possui inscrição.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;

        }
    }
}
