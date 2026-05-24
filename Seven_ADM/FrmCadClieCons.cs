using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using Seven_ADM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace Seven_Sistema
{
    public partial class FrmCadClieCons : Form
    {
        public FrmCadClieCons(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private bool _Inserir_Atualizar = false;
        private bool _Comando_Atualizar = false;
        private bool _Contem_Imagem = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private string _ComboboxGrupo_Valor = null;
        private string _ComboboxSubGrupo_Valor = null;
        private static List<string> _Codigo_Municipio = new List<string>();
        private bool _Visao_Geral_Clie_Cons = false;

        private void FrmCadAluno_Load(object sender, EventArgs e)
        {
            
            try
            {
                bllClieCons._FrmCadClieCons_Ativo = true;
                //
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadConsumidor iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadConsumidor iniciado.");
                }
                //
                rbtnNomeAluno.Checked = true;
                //
                if (_Formulario == 1)
                {
                    btnExcluir.Visible = false;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadConsumidor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadConsumidor.");
                }
            }
        }

        public void Ativar()
        {
            grbBox3.Enabled = true;
            btnIncluirDadosCEP.Enabled = true;
            txtCodigo.Enabled = false;
            lblCodigo.Enabled = false;
            lblAstGrupo.Enabled = true;
            txtDiferenca.Enabled = true;
            lblDiferenca.Enabled = true;
            grbBox4.Enabled = true;
            rbtnPfisica.Enabled = true;
            rbtnPjuridica.Enabled = true;
            lblPalavrachave.Enabled = true;
            lblNome.Enabled = true;
            lblDataNascimentoFantasia.Enabled = true;
            lblIE_RG.Enabled = true;
            lblCPF_CNPJ.Enabled = true;
            lblTelefone.Enabled = true;
            lblCelular.Enabled = true;
            lblEmail.Enabled = true;
            lblEndereco.Enabled = true;
            lblNumero.Enabled = true;
            lblComplemento.Enabled = true;
            lblBairro.Enabled = true;
            lblUF.Enabled = true;
            lblCidade.Enabled = true;
            lblCEP.Enabled = true;
            lblGenero.Enabled = true;
            lblObs.Enabled = true;
            txtNome.Enabled = true;
            mtxtDNascimento.Enabled = true;
            mtxtCPF.Enabled = true;
            txtIERG.Enabled = true;
            cbbGenero.Enabled = true;
            mtxtTelefone.Enabled = true;
            mtxtCelular.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            cbbUF.Enabled = true;
            cbbCidade.Enabled = true;
            mtxtCEP.Enabled = true;
            txtPalavraChave.Enabled = true;
            rtxtObs.Enabled = true;
            lblAsterisco1.Enabled = true;
            lblAsterisco2.Enabled = true;
            lblAsterisco3.Enabled = true;
            lblAsterisco4.Enabled = true;
            lblAsterisco5.Enabled = true;
            lblAsterisco6.Enabled = true;
            lblAsterisco7.Enabled = true;
            lblDataNascimentoFantasia.Enabled = true;
            txtFantasia.Enabled = true;
            mtxtCNPJ.Enabled = true;
            lblQtdeCar.Enabled = true;
            if (rbtnPfisica.Checked == true)
            {
                txtNomePai.Enabled = true;
                mtxtCPFPai.Enabled = true;
                mtxtCelularPai.Enabled = true;
                txtEmailPai.Enabled = true;
                txtNomeMae.Enabled = true;
                mtxtCPFMae.Enabled = true;
                mtxtCelularMae.Enabled = true;
                txtEmailMae.Enabled = true;
                lblNomePai.Enabled = true;
                lblCPFPai.Enabled = true;
                lblCelularPai.Enabled = true;
                lblEmailPai.Enabled = true;
                lblNomeMae.Enabled = true;
                lblCPFMae.Enabled = true;
                lblCelularMae.Enabled = true;
                lblEmailMae.Enabled = true;
                lblAvalista.Enabled = true;
                txtAvalista.Enabled = true;
                mtxtCPFAval.Enabled = true;
                lblCPFAval.Enabled = true;
                lblRGAval.Enabled = true;
                txtRGAval.Enabled = true;
                txtEmailAval.Enabled = true;
                lblEmailAval.Enabled = true;
                lblEnderecoAval.Enabled = true;
                txtEnderecoAval.Enabled = true;
                lblBairroAval.Enabled = true;
                txtBairroAval.Enabled = true;
                lblUFAval.Enabled = true;
                cbbUFAval.Enabled = true;
                lblCidadeAval.Enabled = true;
                cbbCidadeAval.Enabled = true;
                lblNumeroAval.Enabled = true;
                txtNumeroAval.Enabled = true;
                lblComplementoAval.Enabled = true;
                txtComplementoAval.Enabled = true;
                lblCEPAval.Enabled = true;
                mtxtCEPAval.Enabled = true;
                mtxtTelefoneAval.Enabled = true;
                lblTelefoneAval.Enabled = true;
                mtxtCelularAval.Enabled = true;
                lblCelularAval.Enabled = true;
            }
            else
            {
                txtNomePai.Enabled = false;
                mtxtCPFPai.Enabled = false;
                mtxtCelularPai.Enabled = false;
                txtEmailPai.Enabled = false;
                txtNomeMae.Enabled = false;
                mtxtCPFMae.Enabled = false;
                mtxtCelularMae.Enabled = false;
                txtEmailMae.Enabled = false;
                lblNomePai.Enabled = false;
                lblCPFPai.Enabled = false;
                lblCelularPai.Enabled = false;
                lblEmailPai.Enabled = false;
                lblNomeMae.Enabled = false;
                lblCPFMae.Enabled = false;
                lblCelularMae.Enabled = false;
                lblEmailMae.Enabled = false;
                lblAvalista.Enabled = false;
                txtAvalista.Enabled = false;
                mtxtCPFAval.Enabled = false;
                lblCPFAval.Enabled = false;
                lblRGAval.Enabled = false;
                txtRGAval.Enabled = false;
                txtEmailAval.Enabled = false;
                lblEmailAval.Enabled = false;
                lblEnderecoAval.Enabled = false;
                txtEnderecoAval.Enabled = false;
                lblBairroAval.Enabled = false;
                txtBairroAval.Enabled = false;
                lblUFAval.Enabled = false;
                cbbUFAval.Enabled = false;
                lblCidadeAval.Enabled = false;
                cbbCidadeAval.Enabled = false;
                lblNumeroAval.Enabled = false;
                txtNumeroAval.Enabled = false;
                lblComplementoAval.Enabled = false;
                txtComplementoAval.Enabled = false;
                lblCEPAval.Enabled = false;
                mtxtCEPAval.Enabled = false;
                mtxtTelefoneAval.Enabled = false;
                lblTelefoneAval.Enabled = false;
                mtxtCelularAval.Enabled = false;
                lblCelularAval.Enabled = false;
            }
            lblAsterisco8.Enabled = true;
            lblSituacao.Enabled = true;
            cbbSituacao.Enabled = true;
            txtCredito.Enabled = true;
            lblCredito.Enabled = true;
            lblSaldo.Enabled = true;
            txtSaldo.Enabled = true;
            txtSaldoCredLoja.Enabled = true;
            lblSaldoCreditoLoja.Enabled = true;
            picbInterrogacao3.Enabled = true;
            picbInterrogacao4.Enabled = true;

            
        }

        public void Limpar()
        {
            txtDiferenca.Text = null;
            cbbGrupo.Text = null;
            cbbSubGrupo.Text = null;
            txtCodigo.Text = null;
            txtNome.Text = null;
            mtxtDNascimento.Text = null;
            mtxtCPF.Text = null;
            txtIERG.Text = null;
            cbbGenero.Text = null;
            mtxtTelefone.Text = null;
            mtxtCelular.Text = null;
            txtEmail.Text = null;
            txtEndereco.Text = null;
            txtNumero.Text = null;
            txtComplemento.Text = null;
            txtBairro.Text = null;
            cbbUF.Text = null;
            cbbCidade.Text = null;
            mtxtCEP.Text = null;
            txtPalavraChave.Text = null;
            rtxtObs.Text = null;
            txtNomePai.Text = null;
            mtxtCPFPai.Text = null;
            mtxtCelularPai.Text = null;
            txtEmailPai.Text = null;
            txtNomeMae.Text = null;
            mtxtCPFMae.Text = null;
            mtxtCelularMae.Text = null;
            txtEmailMae.Text = null;
            mtxtCNPJ.Text = null;
            txtFantasia.Text = null;
            cbbSituacao.Text = null;
            txtCredito.Text = null;
            txtSaldo.Text = null;
            txtSaldoCredLoja.Text = null;
            txtAvalista.Text = null;
            mtxtCPFAval.Text = null;
            txtRGAval.Text = null;
            txtEmailAval.Text = null;
            txtEnderecoAval.Text = null;
            txtBairroAval.Text = null;
            cbbUFAval.Text = null;
            cbbCidadeAval.Text = null;
            txtNumeroAval.Text = null;
            txtComplementoAval.Text = null;
            mtxtCEPAval.Text = null;
            mtxtTelefoneAval.Text = null;
            mtxtCelularAval.Text = null;
            _Codigo_Municipio.Clear();
            mtxtDataUltCompra.Text = null;
            txtTempComprou.Text = null;
            mtxtHorarioultCompra.Text = null;
            txtQtdeCompras.Text = null;
            txtGastoCompras.Text = null;
            txtTicketMedio.Text = null;
            txtQtdeProduto.Text = null;
            txtQtdeServico.Text = null;
            txtIntervalo.Text = null;
            txtTotalEmAtraso.Text = null;
            mtxtDataCadastro.Text = null;
            mtxtDataUltAltSistema.Text = null;
            mtxtHorarioUltAltSistema.Text = null;
        }

        public void ModoPesquisa()
        {
            grbBox3.Enabled = false;
            btnIncluirDadosCEP.Enabled = false;
            txtCodigo.Enabled = false;
            lblCodigo.Enabled = false;
            lblAstGrupo.Enabled = false;
            lblAstSub.Enabled = false;
            txtDiferenca.Enabled = false;
            lblDiferenca.Enabled = false;
            grbBox4.Enabled = false;
            rbtnPfisica.Enabled = false;
            rbtnPjuridica.Enabled = false;
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtClie.DataSource != null)
            {
                dtClie.Enabled = true;
                dtClie.Select();
            }
            lblPalavrachave.Enabled = false;
            lblNome.Enabled = false;
            lblDataNascimentoFantasia.Enabled = false;
            lblIE_RG.Enabled = false;
            lblCPF_CNPJ.Enabled = false;
            lblTelefone.Enabled = false;
            lblCelular.Enabled = false;
            lblEmail.Enabled = false;
            lblEndereco.Enabled = false;
            lblNumero.Enabled = false;
            lblComplemento.Enabled = false;
            lblBairro.Enabled = false;
            lblUF.Enabled = false;
            lblCidade.Enabled = false;
            lblCEP.Enabled = false;
            lblGenero.Enabled = false;
            lblNomePai.Enabled = false;
            lblCPFPai.Enabled = false;
            lblCelularPai.Enabled = false;
            lblEmailPai.Enabled = false;
            lblNomeMae.Enabled = false;
            lblCPFMae.Enabled = false;
            lblCelularMae.Enabled = false;
            lblEmailMae.Enabled = false;
            lblObs.Enabled = false;
            txtNome.Enabled = false;
            mtxtDNascimento.Enabled = false;
            mtxtCPF.Enabled = false;
            txtIERG.Enabled = false;
            cbbGenero.Enabled = false;
            mtxtTelefone.Enabled = false;
            txtCodigo.Enabled = false;
            mtxtCelular.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            cbbUF.Enabled = false;
            cbbCidade.Enabled = false;
            mtxtCEP.Enabled = false;
            txtPalavraChave.Enabled = false;
            rtxtObs.Enabled = false;
            txtNomePai.Enabled = false;
            mtxtCPFPai.Enabled = false;
            mtxtCelularPai.Enabled = false;
            txtEmailPai.Enabled = false;
            txtNomeMae.Enabled = false;
            mtxtCPFMae.Enabled = false;
            mtxtCelularMae.Enabled = false;
            txtEmailMae.Enabled = false;
            lblAsterisco1.Enabled = false;
            lblAsterisco2.Enabled = false;
            lblAsterisco3.Enabled = false;
            lblAsterisco4.Enabled = false;
            lblAsterisco5.Enabled = false;
            lblAsterisco6.Enabled = false;
            lblAsterisco7.Enabled = false;
            txtFantasia.Enabled = false;
            mtxtCNPJ.Enabled = false;
            lblQtdeCar.Enabled = false;
            lblSituacao.Enabled = false;
            cbbSituacao.Enabled = false;
            txtCredito.Enabled = false;
            lblCredito.Enabled = false;
            lblSaldo.Enabled = false;
            txtSaldo.Enabled = false;
            txtSaldoCredLoja.Enabled = false;
            lblSaldoCreditoLoja.Enabled = false;
            lblAvalista.Enabled = false;
            txtAvalista.Enabled = false;
            mtxtCPFAval.Enabled = false;
            lblCPFAval.Enabled = false;
            lblRGAval.Enabled = false;
            txtRGAval.Enabled = false;
            txtEmailAval.Enabled = false;
            lblEmailAval.Enabled = false;
            lblEnderecoAval.Enabled = false;
            txtEnderecoAval.Enabled = false;
            lblBairroAval.Enabled = false;
            txtBairroAval.Enabled = false;
            lblUFAval.Enabled = false;
            cbbUFAval.Enabled = false;
            lblCidadeAval.Enabled = false;
            cbbCidadeAval.Enabled = false;
            lblNumeroAval.Enabled = false;
            txtNumeroAval.Enabled = false;
            lblComplementoAval.Enabled = false;
            txtComplementoAval.Enabled = false;
            lblCEPAval.Enabled = false;
            mtxtCEPAval.Enabled = false;
            mtxtTelefoneAval.Enabled = false;
            lblTelefoneAval.Enabled = false;
            mtxtCelularAval.Enabled = false;
            lblCelularAval.Enabled = false;
            lblAsterisco8.Enabled = false;
            picbInterrogacao3.Enabled = false;
            picbInterrogacao4.Enabled = false;

            
        }

        private void rbtnNomeAluno_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = true;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o nome/razão social:";
            lblPesquisar.Location = new Point(311, 21);
            txtpNome.MaxLength = 60;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(544, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o cpf:";
            lblPesquisar.Location = new Point(547, 21);
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
        }

        private void rbtnRG_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = true;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o rg:";
            lblPesquisar.Location = new Point(529, 21);
            txtpNome.MaxLength = 20;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnCPFResponsavel_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o cpf do pai/mãe:";
            lblPesquisar.Location = new Point(479, 21);
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            if (txtpNome.Text.Contains("'") || txtpNome.Text.Contains(";") || txtpNome.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpNome.Text = null;
                txtpNome.Select();
            }
            txtpNome.BackColor = Color.White;
        }

        private void mtxtpCPF_Enter(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.LightBlue;
        }

        private void mtxtpCPF_Leave(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.White;
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
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _ComboboxGrupo_Valor = cbbGrupo.Text;
                _ComboboxSubGrupo_Valor = cbbSubGrupo.Text;
                //
                if (cbbGrupo.Text != "")
                {
                    cbbGrupo.Items.Clear();
                    if (bllClieCons.Sel_Grupo_Clie() == null)
                    {
                        cbbGrupo.Text = null;
                    }
                    else
                    {
                        cbbGrupo.Items.Add("");
                        foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
                        {
                            cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    if (bllClieCons.Sel_ComboboxGrupo_Valor_A_Alterar_Clie(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllClieCons.Sel_ComboboxGrupo_Valor_A_Alterar_Clie(_ComboboxGrupo_Valor).Rows)
                        {
                            cbbGrupo.Text = dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString();
                        }
                        _ComboboxGrupo_Valor = null;
                    }
                    else
                    {
                        _ComboboxGrupo_Valor = null;
                        cbbGrupo.Text = null;
                    }
                }
                //
                if (cbbSubGrupo.Enabled != false & cbbGrupo.Text != "")
                {
                    cbbSubGrupo.Items.Clear();
                    if (bllClieCons.Sel_SubGrupo_Clie(cbbGrupo.Text) == null)
                    {
                        cbbSubGrupo.Text = null;
                    }
                    else
                    {
                        cbbSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllClieCons.Sel_SubGrupo_Clie(cbbGrupo.Text).Rows)
                        {
                            cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    cbbSubGrupo.Text = _ComboboxSubGrupo_Valor;

                    if (cbbSubGrupo.Text != "")
                    {
                        if (bllClieCons.Sel_ComboboxSubGrupo_Valor_A_Alterar_Clie(_ComboboxSubGrupo_Valor, cbbGrupo.Text) != null)
                        {
                            foreach (DataRow dr in bllClieCons.Sel_ComboboxSubGrupo_Valor_A_Alterar_Clie(_ComboboxSubGrupo_Valor, cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Text = dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxSubGrupo_Valor = null;

                        }
                        else
                        {
                            _ComboboxSubGrupo_Valor = null;
                            cbbSubGrupo.Text = null;
                        }
                    }
                }
                else
                {
                    cbbSubGrupo.Items.Clear();
                    cbbSubGrupo.Text = null;
                    _ComboboxSubGrupo_Valor = null;
                    _ComboboxGrupo_Valor = null;
                }
                //
               
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    mtxtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //(mtxtCPF.Text == "" & mtxtCNPJ.Text == "")
                    if (txtNome.Text.Trim() == "" || txtEndereco.Text.Trim() == "" || txtNumero.Text.Trim() == "" || txtBairro.Text.Trim() == "" || cbbUF.Text == "" || cbbCidade.Text == "" || mtxtCEP.Text == "" || cbbSituacao.Text == "" || cbbGrupo.Text == "" || cbbSubGrupo.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Nome/Razão Social ], [ Endereço ], [ Número ],\n[ Bairro ], [ UF ], [ Cidade ], [ CEP ], [ Situação ], [ Grupo ] e\n[ Sub-Grupo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        txtPalavraChave.Select();
                    }
                    else
                    {
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (_Comando_Atualizar == true)
                        {
                            DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                            //
                            if (txtCodigo.Text == "")
                            {
                                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                            }
                            //
                            if (bllClieCons.Sel_Cliente_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtClie.DataSource = null;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllClieCons._Url_Imagem = null;
                                rbtnNomeAluno.Checked = true;
                                ModoPesquisa();
                                pcibImagem.Image = null;
                                lblLegendaImagem.Visible = false;
                                _Inserir_Atualizar = false;
                                _Contem_Imagem = false;
                                _Comando_Atualizar = false;
                            }
                            else
                            {
                                if (rbtnPfisica.Checked == true)
                                {
                                    bllClieCons.Alterar(SelectedRow.Cells[0].Value.ToString(), txtNome.Text.Trim(), mtxtDNascimento.Text, txtPalavraChave.Text.Trim(), txtIERG.Text.Trim(), mtxtCPF.Text, mtxtTelefone.Text, mtxtCelular.Text, txtEmail.Text.Trim(), txtEndereco.Text.Trim(), txtNumero.Text.Trim(), txtComplemento.Text.Trim(), txtBairro.Text.Trim(), cbbCidade.Text, cbbUF.Text, mtxtCEP.Text, cbbGenero.Text, rtxtObs.Text.Trim(), txtNomePai.Text.Trim(), mtxtCPFPai.Text, mtxtCelularPai.Text, txtEmailPai.Text.Trim(), txtNomeMae.Text.Trim(), mtxtCPFMae.Text, mtxtCelularMae.Text, txtEmailMae.Text.Trim(), rbtnPfisica.Text, "", "", cbbSituacao.Text, txtCredito.Text.Trim(), txtAvalista.Text.Trim(), mtxtCPFAval.Text, txtRGAval.Text.Trim(), txtEmailAval.Text.Trim(), txtEnderecoAval.Text.Trim(), txtBairroAval.Text.Trim(), cbbUFAval.Text, cbbCidadeAval.Text, txtNumeroAval.Text.Trim(), txtComplementoAval.Text.Trim(), mtxtCEPAval.Text, mtxtTelefoneAval.Text, mtxtCelularAval.Text, _Cod_PDV_Computador, cbbGrupo.Text, cbbSubGrupo.Text, txtCodigo.Text.Trim(), SelectedRow.Cells[52].Value.ToString(), _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                                }
                                else
                                {
                                    bllClieCons.Alterar(SelectedRow.Cells[0].Value.ToString(), txtNome.Text.Trim(), "", txtPalavraChave.Text.Trim(), txtIERG.Text.Trim(), mtxtCNPJ.Text, mtxtTelefone.Text, mtxtCelular.Text, txtEmail.Text.Trim(), txtEndereco.Text.Trim(), txtNumero.Text.Trim(), txtComplemento.Text.Trim(), txtBairro.Text.Trim(), cbbCidade.Text, cbbUF.Text, mtxtCEP.Text, "", rtxtObs.Text.Trim(), "", "", "", "", "", "", "", "", rbtnPjuridica.Text, txtFantasia.Text.Trim(), "", cbbSituacao.Text, txtCredito.Text.Trim(), txtAvalista.Text.Trim(), mtxtCPFAval.Text, txtRGAval.Text.Trim(), txtEmailAval.Text.Trim(), txtEnderecoAval.Text.Trim(), txtBairroAval.Text.Trim(), cbbUFAval.Text, cbbCidadeAval.Text, txtNumeroAval.Text.Trim(), txtComplementoAval.Text.Trim(), mtxtCEPAval.Text, mtxtTelefoneAval.Text, mtxtCelularAval.Text, _Cod_PDV_Computador, cbbGrupo.Text, cbbSubGrupo.Text, txtCodigo.Text.Trim(), SelectedRow.Cells[52].Value.ToString(), _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                                }
                                //
                                if (_Contem_Imagem == true)
                                {
                                    if (bllClieCons._Url_Imagem != null)
                                    {
                                        bllClieCons.Alterar_Imagem_Cliente(txtCodigo.Text, bllClieCons._Url_Imagem);
                                    }
                                }
                                else
                                {
                                    bllClieCons.Alterar_Imagem_Cliente(txtCodigo.Text, bllClieCons._Url_Imagem);
                                }
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM CONSUMIDOR.", "CONSUMIDOR", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                bllClieCons.Alterar_Nome_Clie_Conta_Pagar(txtCodigo.Text, txtNome.Text.Trim());
                                bllClieCons.Alterar_Nome_Clie_Conta_Receber(txtCodigo.Text, txtNome.Text.Trim());
                                bllClieCons.Alterar_Nome_Clie_Devolucao(txtCodigo.Text, txtNome.Text.Trim());
                                bllClieCons.Alterar_Nome_Clie_Orcamento(txtCodigo.Text, txtNome.Text.Trim());
                                bllClieCons.Alterar_Nome_Clie_Vendas(txtCodigo.Text, txtNome.Text.Trim());
                                bllClieCons.Alterar_Nome_Clie_DFe(txtCodigo.Text, txtNome.Text.Trim());
                                string cpf_cnpj;
                                if (rbtnPfisica.Checked == true)
                                {
                                    cpf_cnpj = mtxtCPF.Text;
                                }
                                else
                                {
                                    cpf_cnpj = mtxtCNPJ.Text;
                                }
                                bllClieCons.Alterar_Nome_Clie_OS(txtCodigo.Text, txtNome.Text.Trim(), cpf_cnpj);
                                //
                                dtClie.DataSource = bllClieCons.Sel_Clie_A_Alt(txtCodigo.Text);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - consumidor alterado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - consumidor alterado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                                }
                                //
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllClieCons._Url_Imagem = null;
                                //
                                ModoPesquisa();
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                if (_Formulario == 1)
                                {
                                    bllClieCons._Cod_ClieCons_Cadastro = txtCodigo.Text;
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                                //
                                tabcCadastro.SelectedTab = tabpCadastro1;
                                //
                                Ativar_Visao_Geral();
                            }
                        }
                        else
                        {
                            if (rbtnPfisica.Checked == true)
                            {
                                bllClieCons.Salvar(txtNome.Text.Trim(), mtxtDNascimento.Text, txtPalavraChave.Text.Trim(), txtIERG.Text.Trim(), mtxtCPF.Text, mtxtTelefone.Text, mtxtCelular.Text, txtEmail.Text.Trim(), txtEndereco.Text.Trim(), txtNumero.Text.Trim(), txtComplemento.Text.Trim(), txtBairro.Text.Trim(), cbbCidade.Text, cbbUF.Text, mtxtCEP.Text, cbbGenero.Text, rtxtObs.Text.Trim(), txtNomePai.Text.Trim(), mtxtCPFPai.Text, mtxtCelularPai.Text, txtEmailPai.Text.Trim(), txtNomeMae.Text.Trim(), mtxtCPFMae.Text, mtxtCelularMae.Text, txtEmailMae.Text.Trim(), bllClieCons._Url_Imagem, rbtnPfisica.Text, "", "", cbbSituacao.Text, txtCredito.Text.Trim(), txtAvalista.Text.Trim(), mtxtCPFAval.Text, txtRGAval.Text.Trim(), txtEmailAval.Text.Trim(), txtEnderecoAval.Text.Trim(), txtBairroAval.Text.Trim(), cbbUFAval.Text, cbbCidadeAval.Text, txtNumeroAval.Text.Trim(), txtComplementoAval.Text.Trim(), mtxtCEPAval.Text, mtxtTelefoneAval.Text, mtxtCelularAval.Text, _Cod_PDV_Computador, cbbGrupo.Text, cbbSubGrupo.Text, _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                            }
                            else
                            {
                                bllClieCons.Salvar(txtNome.Text.Trim(), "", txtPalavraChave.Text.Trim(), txtIERG.Text.Trim(), mtxtCNPJ.Text, mtxtTelefone.Text, mtxtCelular.Text, txtEmail.Text.Trim(), txtEndereco.Text.Trim(), txtNumero.Text.Trim(), txtComplemento.Text.Trim(), txtBairro.Text.Trim(), cbbCidade.Text, cbbUF.Text, mtxtCEP.Text, "", rtxtObs.Text.Trim(), "", "", "", "", "", "", "", "", bllClieCons._Url_Imagem, rbtnPjuridica.Text, txtFantasia.Text.Trim(), "", cbbSituacao.Text, txtCredito.Text.Trim(), txtAvalista.Text.Trim(), mtxtCPFAval.Text, txtRGAval.Text.Trim(), txtEmailAval.Text.Trim(), txtEnderecoAval.Text.Trim(), txtBairroAval.Text.Trim(), cbbUFAval.Text, cbbCidadeAval.Text, txtNumeroAval.Text.Trim(), txtComplementoAval.Text.Trim(), mtxtCEPAval.Text, mtxtTelefoneAval.Text, mtxtCelularAval.Text, _Cod_PDV_Computador, cbbGrupo.Text, cbbSubGrupo.Text, _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                            }

                            dtClie.DataSource = bllClieCons.Sel_Cliente_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UM CONSUMIDOR.", "CONSUMIDOR", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            pcibImagem.Image = null;
                            pcibImagem.ImageLocation = null;
                            bllClieCons._Url_Imagem = null;

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Consumidor cadastrado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Consumidor cadastrado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }
                            //
                            ModoPesquisa();
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            if (_Formulario == 1)
                            {
                                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                                //
                                bllClieCons._Cod_ClieCons_Cadastro = SelectedRow.Cells[0].Value.ToString();
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            //
                            tabcCadastro.SelectedTab = tabpCadastro1;
                            //
                            Ativar_Visao_Geral();
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllClieCons._Url_Imagem = null;
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
                ModoPesquisa();
            }
        }

        private void Ativar_Visao_Geral() 
        {
            lblDataCadastro.Enabled = true;
            mtxtDataCadastro.Enabled = true;
            lblDataHorarioUltCompra.Enabled = true;
            mtxtDataUltCompra.Enabled = true;
            mtxtHorarioultCompra.Enabled = true;
            lblTempoCompra.Enabled = true;
            lblHa.Enabled = true;
            lblDias.Enabled = true;
            txtTempComprou.Enabled = true;
            lblQtdeCompra.Enabled = true;
            txtQtdeCompras.Enabled = true;
            lblTotalGasto.Enabled = true;
            txtGastoCompras.Enabled = true;
            lblTicketMedio.Enabled = true;
            txtTicketMedio.Enabled = true;
            lblQuantidadeProduto.Enabled = true;
            txtQtdeProduto.Enabled = true;
            lblQtdeServico.Enabled = true;
            txtQtdeServico.Enabled = true;
            lblIntervaloCompra.Enabled = true;
            txtIntervalo.Enabled = true;
            lblTotalAtrasado.Enabled = true;
            txtTotalEmAtraso.Enabled = true;
            btnGerarPDF.Enabled = true;
            picbInterrogacao5.Enabled = true;
            lblUltAlteracaoCadastro.Enabled = true;
            mtxtDataUltAltSistema.Enabled = true;
            mtxtHorarioUltAltSistema.Enabled = true;
        }

        private void Desativar_Visao_Geral()
        {
            lblDataCadastro.Enabled = false;
            mtxtDataCadastro.Enabled = false;
            lblDataHorarioUltCompra.Enabled = false;
            mtxtDataUltCompra.Enabled = false;
            mtxtHorarioultCompra.Enabled = false;
            lblTempoCompra.Enabled = false;
            lblHa.Enabled = false;
            lblDias.Enabled = false;
            txtTempComprou.Enabled = false;
            lblQtdeCompra.Enabled = false;
            txtQtdeCompras.Enabled = false;
            lblTotalGasto.Enabled = false;
            txtGastoCompras.Enabled = false;
            lblTicketMedio.Enabled = false;
            txtTicketMedio.Enabled = false;
            lblQuantidadeProduto.Enabled = false;
            txtQtdeProduto.Enabled = false;
            lblQtdeServico.Enabled = false;
            txtQtdeServico.Enabled = false;
            lblIntervaloCompra.Enabled = false;
            txtIntervalo.Enabled = false;
            lblTotalAtrasado.Enabled = false;
            txtTotalEmAtraso.Enabled = false;
            btnGerarPDF.Enabled = false;
            picbInterrogacao5.Enabled = false;
            lblUltAlteracaoCadastro.Enabled = false;
            mtxtDataUltAltSistema.Enabled = false;
            mtxtHorarioUltAltSistema.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtClie.DefaultCellStyle.SelectionBackColor = Color.White;
                lblLegendaImagem.Visible = true;
                pcibImagem.Image = null;
                pcibAjudaFoto.Enabled = true;
                pcibImagem.Enabled = true;
                lblLegendaImagem.Text = "Adicionar Imagem.";
                _Comando_Atualizar = false;
                _Inserir_Atualizar = true;
                dtClie.Enabled = false;
                grbBox1.Enabled = false;
                Ativar();
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                txtPalavraChave.Select();
                Limpar();
                rbtnPfisica.Checked = true;
                cbbUF.Text = "AC";
                cbbSituacao.Text = "ATIVO";
                txtSaldoCredLoja.Text = "0,00";
                txtSaldo.Text = "0,00";
                tabcCadastro.SelectedTab = tabpCadastro1;
                cbbUF.Text = "BA";
                cbbCidade.Text = bllMinhaEmpresa.Sel_Cidade_Empresa();
                mtxtCEP.Text = bllMinhaEmpresa.Sel_CEP_Empresa();
                //
                cbbGrupo.Items.Clear();
                if (bllClieCons.Sel_Grupo_Clie() == null)
                {
                    cbbGrupo.Text = null;
                }
                else
                {
                    cbbGrupo.Items.Add("");
                    foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
                    {
                        cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbGrupo.Text = "4—CLIENTES NO GERAL";
                cbbSubGrupo.Text = "4—GERAL";
                //
                Desativar_Visao_Geral();
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
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllClieCons.Sel_Cliente_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtClie.Select();
                }
                else
                {
                    if (_Contem_Imagem == false)
                    {
                        lblLegendaImagem.Text = "Adicionar Imagem.";
                        pcibImagem.Image = null;
                    }
                    dtClie.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtClie.Enabled = false;
                    grbBox1.Enabled = false;
                    btnNovo.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnCancelar.Visible = true;
                    btnSalvar.Enabled = true;
                    Ativar();
                    grbBox2.Enabled = true;
                    pcibAjudaFoto.Enabled = true;
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtPalavraChave.Select();
                    _Comando_Atualizar = true;
                    _Inserir_Atualizar = true;
                    _ComboboxGrupo_Valor = cbbGrupo.Text;
                    _ComboboxSubGrupo_Valor = cbbSubGrupo.Text;
                    //
                    if (cbbGrupo.Text != "")
                    {
                        cbbGrupo.Items.Clear();
                        if (bllClieCons.Sel_Grupo_Clie() == null)
                        {
                            cbbGrupo.Text = null;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                    }

                    if (bllClieCons.Sel_ComboboxGrupo_Valor_A_Alterar_Clie(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllClieCons.Sel_ComboboxGrupo_Valor_A_Alterar_Clie(_ComboboxGrupo_Valor).Rows)
                        {
                            cbbGrupo.Text = dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString();
                        }
                        _ComboboxGrupo_Valor = null;
                    }
                    else
                    {
                        _ComboboxGrupo_Valor = null;
                        cbbGrupo.Text = null;
                    }

                    if (cbbSubGrupo.Enabled != false & cbbGrupo.Text != "")
                    {
                        cbbSubGrupo.Items.Clear();
                        if (bllClieCons.Sel_SubGrupo_Clie(cbbGrupo.Text) == null)
                        {
                            cbbSubGrupo.Text = null;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllClieCons.Sel_SubGrupo_Clie(cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }

                        if (bllClieCons.Sel_ComboboxSubGrupo_Valor_A_Alterar_Clie(_ComboboxSubGrupo_Valor, cbbGrupo.Text) != null)
                        {
                            foreach (DataRow dr in bllClieCons.Sel_ComboboxSubGrupo_Valor_A_Alterar_Clie(_ComboboxSubGrupo_Valor, cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Text = dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxSubGrupo_Valor = null;
                        }
                        else
                        {
                            _ComboboxSubGrupo_Valor = null;
                            cbbSubGrupo.Text = null;
                        }
                    }
                    else
                    {
                        cbbSubGrupo.Items.Clear();
                        cbbSubGrupo.Text = null;
                        _ComboboxSubGrupo_Valor = null;
                        _ComboboxGrupo_Valor = null;
                    }
                }
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtClie.DataSource == null)
                {
                    Limpar();
                    pcibImagem.Enabled = false;
                    pcibImagem.Image = null;
                    lblLegendaImagem.Visible = false;
                    pcibAjudaFoto.Enabled = false;
                    _Contem_Imagem = false;
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            pcibImagem.Image = null;
            pcibImagem.ImageLocation = null;
            bllClieCons._Url_Imagem = null;
            ModoPesquisa();
            Ativar_Visao_Geral();
            tabcCadastro.SelectedTab = tabpCadastro1;
        }

        private void cbbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _Codigo_Municipio.Clear();
                if (cbbUF.SelectedIndex == 0)
                {
                    cbbCidade.Items.Clear();
                }
                else if (cbbUF.SelectedIndex == 1)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 2)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 3)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 4)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 5)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 6)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 7)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 8)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 9)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 10)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 11)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 12)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 13)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 14)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 15)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 16)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 17)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 18)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 19)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 20)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 21)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 22)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 23)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 24)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 25)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 26)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 27)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(ValidarData.RemoverAcentos(items[0]));
                            _Codigo_Municipio.Add(items[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                cbbCidade.Text = null;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadAluno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodos.Checked == true)
                {
                    if (bllClieCons.Sel_Clie_Todos() == null)
                    {
                        dtClie.DataSource = null;
                        this.DialogResult = DialogResult.None;
                        Limpar();
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dtClie.DataSource = bllClieCons.Sel_Clie_Todos();
                        dtClie.Select();
                    }
                }
                else if (rbtnNomeAluno.Checked == true)
                {
                    if (txtpNome.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_Nome(txtpNome.Text) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_Nome(txtpNome.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllClieCons.Sel_Cliente_Codigo(txtpCodigo.Text) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Cliente_Codigo(txtpCodigo.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnCPF.Checked == true)
                {
                    mtxtpCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCPF.Text != "")
                    {
                        mtxtpCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCPF.Text) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCPF.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnCNPJ.Checked == true)
                {
                    mtxtpCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCNPJ.Text != "")
                    {
                        mtxtpCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCNPJ.Text) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCNPJ.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_IERG(txtpRG.Text, 0) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_IERG(txtpRG.Text, 0);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnIE.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_IERG(txtpRG.Text, 1) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_IERG(txtpRG.Text, 1);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_Palavra_Chave(txtpPalavraChave.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnCPFResponsavel.Checked == true)
                {
                    mtxtpCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCPF.Text != "")
                    {
                        mtxtpCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllClieCons.Sel_Cliente_CPF_Resp(mtxtpCPF.Text) == null)
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Cliente_CPF_Resp(mtxtpCPF.Text);
                            dtClie.Select();
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou consumidor.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou consumidor.");
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
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
                ModoPesquisa();
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(590, 21);
            btnPesquisar.Select();
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

        private void dtAluno_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtClie.DataSource == null)
            {
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllClieCons._Url_Imagem = null;
                pcibImagem.Enabled = false;
                lblLegendaImagem.Visible = false;
                pcibAjudaFoto.Enabled = false;
                dtClie.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                _Contem_Imagem = false;
                //
                Desativar_Visao_Geral();
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                pcibImagem.Enabled = true;
                dtClie.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                //
                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();
                //
                if (bllGrupo.Sel_Grupo_Cor_Destaque("CLIENTES") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("CLIENTES").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("CLIENTES").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }
                //
                Ativar_Visao_Geral();
                //
                for (int i = 0; i < dtClie.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtClie.Rows[i].Cells[48].Value.ToString())
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtClie.Rows[i].Cells[48].Value.ToString())
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtClie.Rows[i].Cells[48].Value.ToString())
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtClie.Rows[i].Cells[48].Value.ToString())
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtClie.Rows[i].Cells[48].Value.ToString())
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtClie.Rows[i].Cells[48].Value.ToString())
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void dtAluno_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtClie.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtAluno_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNomeAluno_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNomeAluno_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnRG_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnRG_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCPFResponsavel_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPFResponsavel_MouseLeave(object sender, EventArgs e)
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

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void mtxtDNascimento_Enter(object sender, EventArgs e)
        {
            mtxtDNascimento.BackColor = Color.LightBlue;
        }

        private void mtxtDNascimento_Leave(object sender, EventArgs e)
        {
            mtxtDNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDNascimento.Text != "")
            {
                mtxtDNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                try
                {
                    ValidarData.Ver_Data(mtxtDNascimento.Text);
                    //
                    if (Convert.ToDateTime(mtxtDNascimento.Text).Year >= DateTime.Now.Year)
                    {
                        MessageBox.Show("Data de nascimento inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mtxtDNascimento.Text = null;
                        this.DialogResult = DialogResult.None;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDNascimento.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDNascimento.");
                    }
                    mtxtDNascimento.Text = null;
                }
            }
            mtxtDNascimento.BackColor = Color.White;
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

                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllClieCons.Sel_C_CPF_CNPJ_Alt(txtCodigo.Text, mtxtCPF.Text) == true)
                                {
                                    MessageBox.Show("O CPF informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtCPF.Text = null;
                                    mtxtCPF.Select();
                                }
                            }
                            else
                            {
                                if (bllClieCons.Sel_C_CPF_CNPJ(mtxtCPF.Text) == true)
                                {
                                    MessageBox.Show("O CPF informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtCPF.Text = null;
                                    mtxtCPF.Select();
                                }
                            }
                        }
                    }
                    else
                    {
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        MessageBox.Show("CPF inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCPF.Text = null;
                        mtxtCPF.Select();
                    }
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

        private void txtRG_Enter(object sender, EventArgs e)
        {
            txtIERG.BackColor = Color.LightBlue;
        }

        private void txtRG_Leave(object sender, EventArgs e)
        {
            if (txtIERG.Text.Contains("'") || txtIERG.Text.Contains(";") || txtIERG.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtIERG.Text = null;
                txtIERG.BackColor = Color.White;
                txtIERG.Select();
            }
            txtIERG.BackColor = Color.White;
        }

        private void mtxtTelefone_Enter(object sender, EventArgs e)
        {
            mtxtTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtTelefone_Leave(object sender, EventArgs e)
        {
            mtxtTelefone.BackColor = Color.White;
        }

        private void mtxtCelular_Enter(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.LightBlue;
        }

        private void mtxtCelular_Leave(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.LightBlue;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Contains("'") || txtEmail.Text.Contains(";") || txtEmail.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmail.Text = null;
                txtEmail.Select();
            }
            else if (!txtEmail.Text.Contains("@") && txtEmail.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtEmail.Text = null;
                txtEmail.Select();
            }
            txtEmail.BackColor = Color.White;
        }

        private void txtEndereco_Enter(object sender, EventArgs e)
        {
            txtEndereco.BackColor = Color.LightBlue;
        }

        private void txtEndereco_Leave(object sender, EventArgs e)
        {
            if (txtEndereco.Text.Contains("'") || txtEndereco.Text.Contains(";") || txtEndereco.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEndereco.Text = null;
                txtEndereco.Select();
            }
            txtEndereco.BackColor = Color.White;
        }

        private void txtNumero_Enter(object sender, EventArgs e)
        {
            txtNumero.BackColor = Color.LightBlue;
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text.Contains("'") || txtNumero.Text.Contains(";") || txtNumero.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNumero.Text = null;
                txtNumero.Select();
            }
            txtNumero.BackColor = Color.White;
        }

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            txtComplemento.BackColor = Color.LightBlue;
        }

        private void txtComplemento_Leave(object sender, EventArgs e)
        {
            if (txtComplemento.Text.Contains("'") || txtComplemento.Text.Contains(";") || txtComplemento.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtComplemento.Text = null;
                txtComplemento.Select();
            }
            txtComplemento.BackColor = Color.White;
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.LightBlue;
        }

        private void txtBairro_Leave(object sender, EventArgs e)
        {
            if (txtBairro.Text.Contains("'") || txtBairro.Text.Contains(";") || txtBairro.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtBairro.Text = null;
                txtBairro.Select();
            }
            txtBairro.BackColor = Color.White;
        }

        private void mtxtCEP_Enter(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.LightBlue;
        }

        private void mtxtCEP_Leave(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.White;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllClieCons.Sel_Cliente_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtClie.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Consumidor?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllClieCons.Sel_Cliente_Contas_Pagar_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Cliente/Consumidor selecionado está sendo utilizado por uma Conta a Pagar, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtClie.Select();
                        }
                        else if (bllClieCons.Sel_Cliente_Contas_Receber_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Cliente/Consumidor selecionado está sendo utilizado por uma Conta a Receber, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtClie.Select();
                        }
                        else if (bllClieCons.Sel_Cliente_Devolucao_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Cliente/Consumidor selecionado está sendo utilizado por uma Devolução, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtClie.Select();
                        }
                        else if (bllClieCons.Sel_Cliente_Orcamento_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Cliente/Consumidor selecionado está sendo utilizado por um Orçamento, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtClie.Select();
                        }
                        else if (bllClieCons.Sel_Cliente_Venda_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Cliente/Consumidor selecionado está sendo utilizado por uma Venda, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtClie.Select();
                        }
                        else if (bllClieCons.Sel_Cliente_OS_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Cliente/Consumidor selecionado está sendo utilizado por uma Ordem de Serviço, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtClie.Select();
                        }
                        else if (bllClieCons.Sel_Cliente_DFe_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Cliente/Consumidor selecionado está sendo utilizado por um DFe, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtClie.Select();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                            //
                            bllClieCons.Excluir(txtCodigo.Text);
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UM CONSUMIDOR.", "CONSUMIDOR", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            // 
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Consumidor excluído. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Consumidor excluído. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }
                            //
                            if (rbtnTodos.Checked == true)
                            {
                                if (bllClieCons.Sel_Clie_Todos() == null)
                                {
                                    dtClie.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtClie.DataSource = bllClieCons.Sel_Clie_Todos();
                                    dtClie.Select();
                                }
                            }
                            else if (rbtnNomeAluno.Checked == true)
                            {
                                if (txtpNome.Text != "")
                                {
                                    if (bllClieCons.Sel_Clie_Nome(txtpNome.Text) == null)
                                    {
                                        dtClie.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtClie.DataSource = bllClieCons.Sel_Clie_Nome(txtpNome.Text);
                                        dtClie.Select();
                                    }
                                }
                                else
                                {
                                    dtClie.DataSource = null;
                                    Limpar();
                                }
                            }
                            else
                            {
                                dtClie.DataSource = null;
                                Limpar();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        if (dtClie.DataSource != null)
                        {
                            dtClie.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllClieCons._Url_Imagem = null;
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
                ModoPesquisa();
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtComplemento.Select();
            }
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (rbtnPjuridica.Checked == true)
                {
                    txtFantasia.Select();
                }
                else
                {
                    mtxtDNascimento.Select();
                }
            }
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbtnPfisica.Checked == true)
            {
                if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
                {
                    e.Handled = true;
                }
            }
            //
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

        private void mtxtDNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGenero.Select();
            }
        }

        private void mtxtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG.Select();
            }
        }

        private void cbbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGrupo.Select();
            }
        }

        private void mtxtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelular.Select();
            }
        }

        private void mtxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabcCadastro3;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtTelefone.Select();
            }
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumero.Select();
            }
        }

        private void txtComplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtBairro.Select();
            }
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUF.Select();
            }
        }

        private void cbbUF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCidade.Select();
            }
        }

        private void cbbCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCEP.Select();
            }
        }

        private void mtxtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmail.Select();
            }
        }

        private void mtxtpCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbtnCodigo.Checked == true)
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por nome/razão social, código, cpf, cnpj, rg, inscrição estadual, cpf pai/mãe, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpRG_Enter(object sender, EventArgs e)
        {
            txtpRG.BackColor = Color.LightBlue;
        }

        private void txtpRG_Leave(object sender, EventArgs e)
        {
            if (txtpRG.Text.Contains("'") || txtpRG.Text.Contains(";") || txtpRG.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpRG.Text = null;
                txtpRG.Select();
            }
            //
            if (txtpRG.Text != "")
            {
                if (txtpRG.Text.Contains("."))
                {
                    txtpRG.Text = txtpRG.Text.Replace(".", "").Replace(",", "").Replace("-", "");
                }
            }
            //
            txtpRG.BackColor = Color.White;
        }

        private void txtpRG_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtAluno_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtClie.Columns[0].HeaderText = "Código";
                dtClie.Columns[1].HeaderText = "Nome/Razão Social";
                dtClie.Columns[2].HeaderText = "Nome Fantasia";
                dtClie.Columns[3].HeaderText = "Data de Nascimento";
                dtClie.Columns[4].HeaderText = "CPF/CNPJ";
                dtClie.Columns[5].HeaderText = "RG/IE";
                dtClie.Columns[6].HeaderText = "Gênero";
                dtClie.Columns[7].HeaderText = "Telefone";
                dtClie.Columns[8].Visible = false;
                dtClie.Columns[9].HeaderText = "Celular";
                dtClie.Columns[10].HeaderText = "E-mail";
                dtClie.Columns[11].HeaderText = "Endereço";
                dtClie.Columns[12].HeaderText = "Número";
                dtClie.Columns[13].HeaderText = "Complemento";
                dtClie.Columns[14].HeaderText = "Bairro";
                dtClie.Columns[15].HeaderText = "UF";
                dtClie.Columns[16].HeaderText = "Cidade";
                dtClie.Columns[17].HeaderText = "CEP";
                dtClie.Columns[18].HeaderText = "Situação";
                dtClie.Columns[19].HeaderText = "Crédito (R$)";
                dtClie.Columns[20].HeaderText = "Usado (R$)";
                dtClie.Columns[21].HeaderText = "Crédito da Loja (R$)";
                dtClie.Columns[22].HeaderText = "Nome do Avalista";
                dtClie.Columns[23].HeaderText = "CPF do Avalista";
                dtClie.Columns[24].HeaderText = "RG do Avalista";
                dtClie.Columns[25].HeaderText = "E-mail do Avalista";
                dtClie.Columns[26].HeaderText = "Endereço do Avalista";
                dtClie.Columns[27].HeaderText = "Bairro do Avalista";
                dtClie.Columns[28].HeaderText = "UF do Avalista";
                dtClie.Columns[29].HeaderText = "Cidade do Avalista";
                dtClie.Columns[30].HeaderText = "Número do Avalista";
                dtClie.Columns[31].HeaderText = "Complemento do Avalista";
                dtClie.Columns[32].HeaderText = "CEP do Avalista";
                dtClie.Columns[33].HeaderText = "Telefone do Avalista";
                dtClie.Columns[34].HeaderText = "Celular do Avalista";
                dtClie.Columns[35].HeaderText = "Nome do Pai";
                dtClie.Columns[36].HeaderText = "CPF do Pai";
                dtClie.Columns[37].HeaderText = "Celular do Pai";
                dtClie.Columns[38].HeaderText = "E-mail do Pai";
                dtClie.Columns[39].HeaderText = "Nome da Mãe";
                dtClie.Columns[40].HeaderText = "CPF da Mãe";
                dtClie.Columns[41].HeaderText = "Celular da Mãe";
                dtClie.Columns[42].HeaderText = "E-mail da Mãe";
                dtClie.Columns[43].HeaderText = "Observações";
                dtClie.Columns[44].Visible = false;
                dtClie.Columns[45].HeaderText = "Palavra-Chave";
                dtClie.Columns[46].HeaderText = "Data de Cadastro";
                dtClie.Columns[47].Visible = false;
                dtClie.Columns[48].HeaderText = "Cód. do Grupo";
                dtClie.Columns[49].HeaderText = "Descrição do Grupo";
                dtClie.Columns[50].HeaderText = "Cód. do Sub-Grupo";
                dtClie.Columns[51].HeaderText = "Descrição do Sub-Grupo";
                dtClie.Columns[52].Visible = false;

                dtClie.Columns[0].Width = 80;
                dtClie.Columns[1].Width = 325;
                dtClie.Columns[2].Width = 280;
                dtClie.Columns[3].Width = 135;
                dtClie.Columns[4].Width = 135;
                dtClie.Columns[5].Width = 175;
                dtClie.Columns[6].Width = 160;
                dtClie.Columns[7].Width = 125;
                dtClie.Columns[8].Width = 125;
                dtClie.Columns[9].Width = 125;
                dtClie.Columns[10].Width = 225;
                dtClie.Columns[11].Width = 325;
                dtClie.Columns[12].Width = 95;
                dtClie.Columns[13].Width = 255;
                dtClie.Columns[14].Width = 325;
                dtClie.Columns[15].Width = 55;
                dtClie.Columns[16].Width = 325;
                dtClie.Columns[17].Width = 76;
                dtClie.Columns[18].Width = 150;
                dtClie.Columns[19].Width = 155;
                dtClie.Columns[20].Width = 155;
                dtClie.Columns[21].Width = 200;
                dtClie.Columns[22].Width = 325;
                dtClie.Columns[23].Width = 135;
                dtClie.Columns[24].Width = 175;
                dtClie.Columns[25].Width = 225;
                dtClie.Columns[26].Width = 325;
                dtClie.Columns[27].Width = 325;
                dtClie.Columns[28].Width = 125;
                dtClie.Columns[29].Width = 325;
                dtClie.Columns[30].Width = 135;
                dtClie.Columns[31].Width = 255;
                dtClie.Columns[32].Width = 120;
                dtClie.Columns[33].Width = 135;
                dtClie.Columns[34].Width = 125;
                dtClie.Columns[35].Width = 325;
                dtClie.Columns[36].Width = 140;
                dtClie.Columns[37].Width = 155;
                dtClie.Columns[38].Width = 175;
                dtClie.Columns[39].Width = 235;
                dtClie.Columns[40].Width = 325;
                dtClie.Columns[41].Width = 155;
                dtClie.Columns[42].Width = 235;
                dtClie.Columns[43].Width = 500;
                dtClie.Columns[45].Width = 125;
                dtClie.Columns[46].Width = 130;
                dtClie.Columns[48].Width = 115;
                dtClie.Columns[49].Width = 325;
                dtClie.Columns[50].Width = 125;
                dtClie.Columns[51].Width = 325;

                dtClie.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[39].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[39].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[40].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[40].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[41].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[41].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[42].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[42].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[43].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[43].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[45].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[45].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[46].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[46].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[48].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[48].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[49].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[49].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[50].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[50].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[51].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtClie.Columns[51].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtClie.DefaultCellStyle.Font = new Font(dtClie.Font, FontStyle.Bold);
                lblRegistros.Text = "Registros: " + dtClie.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtClie.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtClie.");
                }
                dtClie.DataSource = null;
            }
        }

        private void dtAluno_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 0))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllClieCons._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllClieCons._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllClieCons._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllClieCons._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];

                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[44].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllClieCons._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllClieCons._Url_Imagem;
                                //
                                if (bllClieCons._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllClieCons._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllClieCons._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllClieCons._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllClieCons._Url_Imagem);
                                    bllClieCons._Mostrar_Imagem = false;
                                }
                            }
                        }
                    }
                    pEnabled.Enabled = true;
                }
                else
                {
                    if (_Contem_Imagem == true)
                    {
                        DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[44].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtClie.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro. Para adicionar uma imagem clique no botão [ Alterar ] após clique em\n[ Adicionar imagem ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblLegendaImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblLegendaImagem.");
                }
                //
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllClieCons._Url_Imagem = null;
                bllClieCons._Mostrar_Imagem = false;
                bllClieCons._Excluir_Imagem = false;
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 0))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllClieCons._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllClieCons._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllClieCons._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllClieCons._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];

                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[44].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllClieCons._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllClieCons._Url_Imagem;
                                //
                                if (bllClieCons._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllClieCons._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllClieCons._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllClieCons._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllClieCons._Url_Imagem);
                                    bllClieCons._Mostrar_Imagem = false;
                                }
                            }
                        }
                    }
                    pEnabled.Enabled = true;
                }
                else
                {
                    if (_Contem_Imagem == true)
                    {
                        DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[44].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtClie.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro. Para adicionar uma imagem clique no botão [ Alterar ] após clique em\n[ Adicionar imagem ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
                //
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllClieCons._Url_Imagem = null;
                bllClieCons._Mostrar_Imagem = false;
                bllClieCons._Excluir_Imagem = false;
            }
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtClie.DataSource != null || _Inserir_Atualizar == true)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pcibImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtClie.DataSource != null)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void lblLegendaImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNome.Select();
            }
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtPalavraChave.Text.Contains("'") || txtPalavraChave.Text.Contains(";") || txtPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtPalavraChave.Text = null;
                txtPalavraChave.BackColor = Color.White;
                txtPalavraChave.Select();
            }
            else
            {
                try
                {
                    if (_Inserir_Atualizar == true)
                    {
                        if (txtPalavraChave.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllClieCons.Sel_C_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllClieCons.Sel_C_Palavra_Chave(txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                    }
                    txtPalavraChave.Text = null;
                }
                finally
                {
                    txtPalavraChave.BackColor = Color.White;
                }
            }
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida.\n\n2 - Adicionar imagem: Clique em [ Adicionar Imagem ] para adicionar uma imagem ao registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = true;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(501, 21);
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadAluno_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadClieCons foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadClieCons foi finalizado.");
                }
                bllClieCons._Url_Imagem = null;
                bllClieCons._Nome_Arquivo = null;
                bllClieCons._FrmCadClieCons_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadClieCons.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadClieCons.");
                }
            }
        }

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtAluno_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtClie.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtClie.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNome.Text = SelectedRow.Cells[1].Value.ToString();
                txtFantasia.Text = SelectedRow.Cells[2].Value.ToString();
                mtxtDNascimento.Text = SelectedRow.Cells[3].Value.ToString();
                txtIERG.Text = SelectedRow.Cells[5].Value.ToString();
                cbbGenero.Text = SelectedRow.Cells[6].Value.ToString();
                mtxtTelefone.Text = SelectedRow.Cells[7].Value.ToString();
                mtxtCelular.Text = SelectedRow.Cells[9].Value.ToString();
                txtEmail.Text = SelectedRow.Cells[10].Value.ToString();
                txtEndereco.Text = SelectedRow.Cells[11].Value.ToString();
                txtNumero.Text = SelectedRow.Cells[12].Value.ToString();
                txtComplemento.Text = SelectedRow.Cells[13].Value.ToString();
                txtBairro.Text = SelectedRow.Cells[14].Value.ToString();
                cbbUF.Text = SelectedRow.Cells[15].Value.ToString();
                cbbCidade.Text = SelectedRow.Cells[16].Value.ToString();
                mtxtCEP.Text = SelectedRow.Cells[17].Value.ToString();
                cbbSituacao.Text = SelectedRow.Cells[18].Value.ToString();
                dtClie.Columns[19].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtClie.Columns[19].DefaultCellStyle.Format = "n2";
                txtCredito.Text = Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtClie.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtClie.Columns[20].DefaultCellStyle.Format = "n2";
                txtSaldo.Text = Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtClie.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtClie.Columns[21].DefaultCellStyle.Format = "n2";
                txtSaldoCredLoja.Text = Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR"));
                txtAvalista.Text = SelectedRow.Cells[22].Value.ToString();
                mtxtCPFAval.Text = SelectedRow.Cells[23].Value.ToString();
                txtRGAval.Text = SelectedRow.Cells[24].Value.ToString();
                txtEmailAval.Text = SelectedRow.Cells[25].Value.ToString();
                txtEnderecoAval.Text = SelectedRow.Cells[26].Value.ToString();
                txtBairroAval.Text = SelectedRow.Cells[27].Value.ToString();
                cbbUFAval.Text = SelectedRow.Cells[28].Value.ToString();
                cbbCidadeAval.Text = SelectedRow.Cells[29].Value.ToString();
                if (SelectedRow.Cells[30].Value.ToString() != "0")
                {
                    txtNumeroAval.Text = SelectedRow.Cells[30].Value.ToString();
                }
                txtComplementoAval.Text = SelectedRow.Cells[31].Value.ToString();
                mtxtCEPAval.Text = SelectedRow.Cells[32].Value.ToString();
                mtxtTelefoneAval.Text = SelectedRow.Cells[33].Value.ToString();
                mtxtCelularAval.Text = SelectedRow.Cells[34].Value.ToString();
                txtNomePai.Text = SelectedRow.Cells[35].Value.ToString();
                mtxtCPFPai.Text = SelectedRow.Cells[36].Value.ToString();
                mtxtCelularPai.Text = SelectedRow.Cells[37].Value.ToString();
                txtEmailPai.Text = SelectedRow.Cells[38].Value.ToString();
                txtNomeMae.Text = SelectedRow.Cells[39].Value.ToString();
                mtxtCPFMae.Text = SelectedRow.Cells[40].Value.ToString();
                mtxtCelularMae.Text = SelectedRow.Cells[41].Value.ToString();
                txtEmailMae.Text = SelectedRow.Cells[42].Value.ToString();
                rtxtObs.Text = SelectedRow.Cells[43].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[45].Value.ToString();
                txtDiferenca.Text = Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[19].Value) - Convert.ToDecimal(SelectedRow.Cells[20].Value)).ToString("n2", new CultureInfo("pt-BR"));
                if (SelectedRow.Cells[47].Value.ToString() == "0")
                {
                    rbtnPfisica.Checked = true;
                    mtxtCPF.Text = SelectedRow.Cells[4].Value.ToString();
                }
                else
                {
                    rbtnPjuridica.Checked = true;
                    mtxtCNPJ.Text = SelectedRow.Cells[4].Value.ToString();
                }
                cbbGrupo.Items.Clear();
                cbbGrupo.Items.Add(SelectedRow.Cells[48].Value.ToString() + "—" + SelectedRow.Cells[49].Value.ToString());
                cbbGrupo.Text = SelectedRow.Cells[48].Value.ToString() + "—" + SelectedRow.Cells[49].Value.ToString();
                cbbSubGrupo.Items.Clear();
                cbbSubGrupo.Items.Add(SelectedRow.Cells[50].Value.ToString() + "—" + SelectedRow.Cells[51].Value.ToString());
                cbbSubGrupo.Text = SelectedRow.Cells[50].Value.ToString() + "—" + SelectedRow.Cells[51].Value.ToString();
                //
                if (SelectedRow.Cells[44].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[44].Value;
                    //
                    using (MemoryStream ms = new MemoryStream(imagemBytes))
                    {
                        Image imagem = Image.FromStream(ms);
                        pcibImagem.Image = imagem;
                        pcibImagem.SizeMode = PictureBoxSizeMode.StretchImage; // Ou CenterImage, como preferir
                    }
                    //
                    _Contem_Imagem = true;
                    lblLegendaImagem.Visible = false;
                }
                else
                {
                    lblLegendaImagem.Visible = true;
                    _Contem_Imagem = false;
                    lblLegendaImagem.Text = "Sem imagem para este registro.";
                    pcibImagem.Image = null;
                    pcibImagem.ImageLocation = null;
                }
                //
                mtxtDataCadastro.Text = SelectedRow.Cells[46].Value.ToString();
                //
                if (_Visao_Geral_Clie_Cons == true)
                {
                    Executar_Visao_Geral();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtClie.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtClie.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
                ModoPesquisa();
            }
        }

        private Image AdjustImageOrientation(Image image)
        {
            if (image.PropertyIdList.Contains(0x0112)) // 0x0112 é o ID do campo EXIF de orientação
            {
                int orientation = image.GetPropertyItem(0x0112).Value[0];
                RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;

                switch (orientation)
                {
                    case 2:
                        rotateFlipType = RotateFlipType.RotateNoneFlipX;
                        break;
                    case 3:
                        rotateFlipType = RotateFlipType.Rotate180FlipNone;
                        break;
                    case 4:
                        rotateFlipType = RotateFlipType.Rotate180FlipX;
                        break;
                    case 5:
                        rotateFlipType = RotateFlipType.Rotate90FlipX;
                        break;
                    case 6:
                        rotateFlipType = RotateFlipType.Rotate90FlipNone;
                        break;
                    case 7:
                        rotateFlipType = RotateFlipType.Rotate270FlipX;
                        break;
                    case 8:
                        rotateFlipType = RotateFlipType.Rotate270FlipNone;
                        break;
                }
                //
                if (rotateFlipType != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlipType);
                }
            }

            return image;
        }

        private void cbbUF_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCidade_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSexo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSexo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNomePai_Enter(object sender, EventArgs e)
        {
            txtNomePai.BackColor = Color.LightBlue;
        }

        private void txtNomePai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
            {
                e.Handled = true;
            }
            //
            if (e.KeyChar == 13)
            {
                mtxtCPFPai.Select();
            }
        }

        private void txtNomePai_Leave(object sender, EventArgs e)
        {
            if (txtNomePai.Text.Contains("'") || txtNomePai.Text.Contains(";") || txtNomePai.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNomePai.Text = null;
                txtNomePai.Select();
            }
            txtNomePai.BackColor = Color.White;
        }

        private void mtxtCPFPai_Enter(object sender, EventArgs e)
        {
            mtxtCPFPai.BackColor = Color.LightBlue;
        }

        private void mtxtCPFPai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelularPai.Select();
            }
        }

        private void mtxtCPFPai_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCPFPai.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCPFPai.Text != "")
                {
                    if (ValidarCNPJECPF.ValidarCPF(mtxtCPFPai.Text))
                    {
                        mtxtCPFPai.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCPFPai.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        MessageBox.Show("CPF inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtCPFPai.Text = null;
                        mtxtCPFPai.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPFPai.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPFPai.");
                }
                mtxtCPFPai.Text = null;
            }
            mtxtCPFPai.BackColor = Color.White;
        }

        private void mtxtCelularPai_Enter(object sender, EventArgs e)
        {
            mtxtCelularPai.BackColor = Color.LightBlue;
        }

        private void mtxtCelularPai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmailPai.Select();
            }
        }

        private void txtEmailPai_Enter(object sender, EventArgs e)
        {
            txtEmailPai.BackColor = Color.LightBlue;
        }

        private void txtEmailPai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNomeMae.Select();
            }
        }

        private void txtEmailPai_Leave(object sender, EventArgs e)
        {
            if (txtEmailPai.Text.Contains("'") || txtEmailPai.Text.Contains(";") || txtEmailPai.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmailPai.Text = null;
                txtEmailPai.Select();
            }
            else if (!txtEmailPai.Text.Contains("@") && txtEmailPai.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtEmailPai.Text = null;
                txtEmailPai.Select();
            }
            txtEmailPai.BackColor = Color.White;
        }

        private void txtNomeMae_Enter(object sender, EventArgs e)
        {
            txtNomeMae.BackColor = Color.LightBlue;
        }

        private void txtNomeMae_Leave(object sender, EventArgs e)
        {
            if (txtNomeMae.Text.Contains("'") || txtNomeMae.Text.Contains(";") || txtNomeMae.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNomeMae.Text = null;
                txtNomeMae.Select();
            }
            txtNomeMae.BackColor = Color.White;
        }

        private void txtNomeMae_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
            {
                e.Handled = true;
            }
            //
            if (e.KeyChar == 13)
            {
                mtxtCPFMae.Select();
            }
        }

        private void mtxtCPFMae_Enter(object sender, EventArgs e)
        {
            mtxtCPFMae.BackColor = Color.LightBlue;
        }

        private void mtxtCPFMae_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelularMae.Select();
            }
        }

        private void mtxtCelularMae_Enter(object sender, EventArgs e)
        {
            mtxtCelularMae.BackColor = Color.LightBlue;
        }

        private void mtxtCelularMae_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmailMae.Select();
            }
        }

        private void txtEmailMae_Enter(object sender, EventArgs e)
        {
            txtEmailMae.BackColor = Color.LightBlue;
        }

        private void txtEmailMae_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();
            }
        }

        private void txtEmailMae_Leave(object sender, EventArgs e)
        {
            if (txtEmailMae.Text.Contains("'") || txtEmailMae.Text.Contains(";") || txtEmailMae.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmailMae.Text = null;
                txtEmailMae.Select();
            }
            else if (!txtEmailMae.Text.Contains("@") && txtEmailMae.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtEmailMae.Text = null;
                txtEmailMae.Select();
            }
            txtEmailMae.BackColor = Color.White;
        }

        private void mtxtCPFMae_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCPFMae.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCPFMae.Text != "")
                {
                    if (ValidarCNPJECPF.ValidarCPF(mtxtCPFMae.Text))
                    {
                        mtxtCPFMae.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCPFMae.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        MessageBox.Show("CPF inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtCPFMae.Text = null;
                        mtxtCPFMae.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPFMae.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPFMae.");
                }
                mtxtCPFMae.Text = null;
            }
            mtxtCPFMae.BackColor = Color.White;
        }

        private void mtxtCelularPai_Leave(object sender, EventArgs e)
        {
            mtxtCelularPai.BackColor = Color.White;
        }

        private void mtxtCelularMae_Leave(object sender, EventArgs e)
        {
            mtxtCelularMae.BackColor = Color.White;
        }

        private void tabcCadastro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tabcCadastro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void mtxtpTelefone_Enter(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtpTelefone_Leave(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.White;
        }

        private void mtxtpTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpCelular_Enter(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.LightBlue;
        }

        private void mtxtpCelular_Leave(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.White;
        }

        private void mtxtpCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbSexo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSexo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPjuridica_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPjuridica_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPjuridica_CheckedChanged_1(object sender, EventArgs e)
        {
            lblIE_RG.Text = "Inscrição Estadual:";
            lblCPF_CNPJ.Text = "CNPJ:";
            mtxtDNascimento.Visible = false;
            mtxtCNPJ.Text = null;
            mtxtCNPJ.Visible = true;
            mtxtCPF.Visible = false;
            txtFantasia.Visible = true;
            lblNome.Text = "Razão Social:";
            lblGenero.Visible = false;
            cbbGenero.Visible = false;
            lblDataNascimentoFantasia.Text = "Nome Fantasia:";
            lblAsterisco1.Location = new Point(241, 1);

            if (_Inserir_Atualizar == true)
            {
                if (_Comando_Atualizar == false)
                {
                    txtSaldo.Text = "0,00";
                    txtSaldoCredLoja.Text = "0,00";
                    cbbSituacao.Text = "ATIVO";
                }
                Ativar();
                txtFantasia.Text = null;
                mtxtCNPJ.Text = null;
                txtIERG.Text = null;
                if (_Comando_Atualizar == true)
                {
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                }
            }
        }

        private void rbtnPfisica_CheckedChanged(object sender, EventArgs e)
        {
            lblIE_RG.Text = "RG:";
            lblCPF_CNPJ.Text = "CPF:";
            mtxtCPF.Text = null;
            mtxtCNPJ.Visible = false;
            mtxtCPF.Visible = true;
            mtxtDNascimento.Visible = true;
            lblDataNascimentoFantasia.Text = "Data de Nascimento:";
            txtFantasia.Visible = false;
            lblNome.Text = "Nome:";
            lblGenero.Visible = true;
            cbbGenero.Visible = true;
            lblAsterisco1.Location = new Point(206, 1);

            if (_Inserir_Atualizar == true)
            {
                if (_Comando_Atualizar == false)
                {
                    txtSaldo.Text = "0,00";
                    txtSaldoCredLoja.Text = "0,00";
                    cbbSituacao.Text = "ATIVO";
                }
                cbbGenero.Text = null;
                mtxtDNascimento.Text = null;
                mtxtCPF.Text = null;
                txtIERG.Text = null;
                txtNomePai.Text = null;
                mtxtCPFPai.Text = null;
                mtxtCelularPai.Text = null;
                txtEmailPai.Text = null;
                txtNomeMae.Text = null;
                mtxtCPFMae.Text = null;
                mtxtCelularMae.Text = null;
                txtEmailMae.Text = null;
                mtxtCNPJ.Text = null;
                txtFantasia.Text = null;
                txtCredito.Text = null;
                txtAvalista.Text = null;
                mtxtCPFAval.Text = null;
                txtRGAval.Text = null;
                txtEmailAval.Text = null;
                txtEnderecoAval.Text = null;
                txtBairroAval.Text = null;
                cbbUFAval.Text = null;
                cbbCidadeAval.Text = null;
                txtNumeroAval.Text = null;
                txtComplementoAval.Text = null;
                mtxtCEPAval.Text = null;
                mtxtTelefoneAval.Text = null;
                mtxtCelularAval.Text = null;
                Ativar();
                if (_Comando_Atualizar == true)
                {
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                }
            }
        }

        private void rbtnPfisica_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPfisica_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtFantasia_Enter(object sender, EventArgs e)
        {
            txtFantasia.BackColor = Color.LightBlue;
        }

        private void txtFantasia_Leave(object sender, EventArgs e)
        {
            if (txtFantasia.Text.Contains("'") || txtFantasia.Text.Contains(";") || txtFantasia.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtFantasia.Text = null;
                txtFantasia.Select();
            }
            txtFantasia.BackColor = Color.White;
        }

        private void txtFantasia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGrupo.Select();
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

                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllClieCons.Sel_C_CPF_CNPJ_Alt(txtCodigo.Text, mtxtCNPJ.Text) == true)
                                {
                                    MessageBox.Show("O CNPJ informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtCNPJ.Text = null;
                                    mtxtCNPJ.Select();
                                }
                            }
                            else
                            {
                                if (bllClieCons.Sel_C_CPF_CNPJ(mtxtCNPJ.Text) == true)
                                {
                                    MessageBox.Show("O CNPJ informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    mtxtCNPJ.Text = null;
                                    mtxtCNPJ.Select();
                                }
                            }
                        }
                    }
                    else
                    {
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        MessageBox.Show("CNPJ inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCNPJ.Text = null;
                        mtxtCNPJ.Select();
                    }
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

        private void mtxtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG.Select();
            }
        }

        private void rbtnCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = true;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o cnpj:";
            lblPesquisar.Location = new Point(513, 21);
            mtxtpCNPJ.Text = null;
            mtxtpCNPJ.Select();
        }

        private void mtxtpCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.LightBlue;
        }

        private void mtxtpCNPJ_Leave(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.White;
        }

        private void mtxtpCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void rbtnCNPJ_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCNPJ_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnIE_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCelular.Visible = false;
            mtxtpTelefone.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = true;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite a inscrição estadual:";
            lblPesquisar.Location = new Point(437, 21);
            txtpNome.MaxLength = 20;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnIE_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnIE_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
            rtxtObs.SelectionStart = 0;
            rtxtObs.SelectionLength = rtxtObs.Text.Length;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                rtxtObs.Text = null;
                rtxtObs.Select();
            }
            rtxtObs.BackColor = Color.White;
        }

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/200";
        }

        private void rtxtObs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mtxtDataCadastro.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    tabcCadastro.SelectedTab = tabcCadastro4;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void tabcCadastro2_Enter(object sender, EventArgs e)
        {
            _Visao_Geral_Clie_Cons = false;
            if (_Inserir_Atualizar == true)
            {
                txtNomePai.Select();
            }
        }

        private void tabpCadastro1_Enter(object sender, EventArgs e)
        {
            _Visao_Geral_Clie_Cons = false;
            if (_Inserir_Atualizar == true)
            {
                txtPalavraChave.Select();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtPalavraChave.Select();
            }
        }

        private void cbbSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCredito.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSaldo.Select();
            }
        }

        private void txtCredito_Enter(object sender, EventArgs e)
        {
            txtCredito.BackColor = Color.LightBlue;
        }

        private void txtCredito_Leave(object sender, EventArgs e)
        {
            if (txtCredito.Text != "")
            {
                if (txtCredito.Text.Contains("'") || txtCredito.Text.Contains(";") || txtCredito.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtCredito.Text = null;
                    txtCredito.Select();
                }
                else
                {
                    try
                    {
                        txtCredito.Text = Convert.ToDecimal(txtCredito.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCredito.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCredito.");
                        }
                        txtCredito.Text = null;
                    }
                }
            }
            txtCredito.BackColor = Color.White;
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSaldo.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtDiferenca.Select();
            }
        }

        private void txtSaldoCredLoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSaldoCredLoja.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtCredito.Select();
            }
        }

        private void txtAvalista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
            {
                e.Handled = true;
            }
            //
            if (e.KeyChar == 13)
            {
                mtxtCPFAval.Select();
            }
        }

        private void txtAvalista_Enter(object sender, EventArgs e)
        {
            txtAvalista.BackColor = Color.LightBlue;
        }

        private void txtAvalista_Leave(object sender, EventArgs e)
        {
            if (txtAvalista.Text.Contains("'") || txtAvalista.Text.Contains(";") || txtAvalista.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtAvalista.Text = null;
                txtAvalista.Select();
            }
            txtAvalista.BackColor = Color.White;
        }

        private void mtxtCPFAval_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCPFAval.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCPFAval.Text != "")
                {
                    if (ValidarCNPJECPF.ValidarCPF(mtxtCPFAval.Text))
                    {
                        mtxtCPFAval.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCPFAval.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        MessageBox.Show("CPF inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCPFAval.Text = null;
                        mtxtCPFAval.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPFAval.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPFAval.");
                }
                mtxtCPFAval.Text = null;
            }
            mtxtCPFAval.BackColor = Color.White;
        }

        private void mtxtCPFAval_Enter(object sender, EventArgs e)
        {
            mtxtCPFAval.BackColor = Color.LightBlue;
        }

        private void mtxtCPFAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRGAval.Select();
            }
        }

        private void txtRGAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEmailAval.Select();
            }
        }

        private void txtRGAval_Enter(object sender, EventArgs e)
        {
            txtRGAval.BackColor = Color.LightBlue;
        }

        private void txtRGAval_Leave(object sender, EventArgs e)
        {
            if (txtRGAval.Text.Contains("'") || txtRGAval.Text.Contains(";") || txtRGAval.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtRGAval.Text = null;
                txtRGAval.Select();
            }
            txtRGAval.BackColor = Color.White;
        }

        private void txtEmailAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEnderecoAval.Select();
            }
        }

        private void txtEmailAval_Enter(object sender, EventArgs e)
        {
            txtEmailAval.BackColor = Color.LightBlue;
        }

        private void txtEmailAval_Leave(object sender, EventArgs e)
        {
            if (txtEmailAval.Text.Contains("'") || txtEmailAval.Text.Contains(";") || txtEmailAval.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmailAval.Text = null;
                txtEmailAval.Select();
            }
            txtEmailAval.BackColor = Color.White;
        }

        private void cbbUFAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCidadeAval.Select();
            }
        }

        private void cbbCidadeAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumeroAval.Select();
            }
        }

        private void txtBairroAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUFAval.Select();
            }
        }

        private void txtEnderecoAval_Enter(object sender, EventArgs e)
        {
            txtEnderecoAval.BackColor = Color.LightBlue;
        }

        private void txtEnderecoAval_Leave(object sender, EventArgs e)
        {
            if (txtEnderecoAval.Text.Contains("'") || txtEnderecoAval.Text.Contains(";") || txtEnderecoAval.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEnderecoAval.Text = null;
                txtEnderecoAval.Select();
            }
            txtEnderecoAval.BackColor = Color.White;
        }

        private void txtEnderecoAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtBairroAval.Select();
            }
        }

        private void txtBairroAval_Enter(object sender, EventArgs e)
        {
            txtBairroAval.BackColor = Color.LightBlue;
        }

        private void txtBairroAval_Leave(object sender, EventArgs e)
        {
            if (txtBairroAval.Text.Contains("'") || txtBairroAval.Text.Contains(";") || txtBairroAval.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtBairroAval.Text = null;
                txtBairroAval.Select();
            }
            txtBairroAval.BackColor = Color.White;
        }

        private void txtNumeroAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtComplementoAval.Select();
            }
        }

        private void txtNumeroAval_Enter(object sender, EventArgs e)
        {
            txtNumeroAval.BackColor = Color.LightBlue;
        }

        private void txtNumeroAval_Leave(object sender, EventArgs e)
        {
            if (txtNumeroAval.Text.Contains("'") || txtNumeroAval.Text.Contains(";") || txtNumeroAval.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNumeroAval.Text = null;
                txtNumeroAval.Select();
            }
            txtNumeroAval.BackColor = Color.White;
        }

        private void txtComplementoAval_Leave(object sender, EventArgs e)
        {
            if (txtComplementoAval.Text.Contains("'") || txtNumeroAval.Text.Contains(";") || txtComplementoAval.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtComplementoAval.Text = null;
                txtComplementoAval.Select();
            }
            txtComplementoAval.BackColor = Color.White;
        }

        private void txtComplementoAval_Enter(object sender, EventArgs e)
        {
            txtComplementoAval.BackColor = Color.LightBlue;
        }

        private void txtComplementoAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCEPAval.Select();
            }
        }

        private void mtxtCEPAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtTelefoneAval.Select();
            }
        }

        private void mtxtCEPAval_Enter(object sender, EventArgs e)
        {
            mtxtCEPAval.BackColor = Color.LightBlue;
        }

        private void mtxtCEPAval_Leave(object sender, EventArgs e)
        {
            mtxtCEPAval.BackColor = Color.White;
        }

        private void mtxtTelefoneAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelularAval.Select();
            }
        }

        private void mtxtTelefoneAval_Enter(object sender, EventArgs e)
        {
            mtxtTelefoneAval.BackColor = Color.LightBlue;
        }

        private void mtxtTelefoneAval_Leave(object sender, EventArgs e)
        {
            mtxtTelefoneAval.BackColor = Color.White;
        }

        private void mtxtCelularAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabcCadastro2;
            }
        }

        private void mtxtCelularAval_Enter(object sender, EventArgs e)
        {
            mtxtCelularAval.BackColor = Color.LightBlue;
        }

        private void mtxtCelularAval_Leave(object sender, EventArgs e)
        {
            mtxtCelularAval.BackColor = Color.White;
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSaldoCredLoja.Select();
            }
        }

        private void cbbUFAval_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbUFAval.SelectedIndex == 0)
                {
                    cbbCidadeAval.Items.Clear();
                }
                else if (cbbUFAval.SelectedIndex == 1)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 2)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 3)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 4)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 5)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 6)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 7)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 8)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 9)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 10)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 11)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 12)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 13)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 14)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 15)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 16)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 17)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 18)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 19)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 20)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 21)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 22)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 23)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 24)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 25)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 26)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUFAval.SelectedIndex == 27)
                {
                    cbbCidadeAval.Items.Clear();
                    cbbCidadeAval.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidadeAval.Items.Add(items[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                cbbCidadeAval.Text = null;
            }
        }

        private void cbbUFAval_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUFAval_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUFAval_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUFAval_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCidadeAval_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidadeAval_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtClie_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 30 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saldo: (Compras em Nota Promissória - Crédito)", "informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saldo Crédito da loja: Valores em cédito que o consumidor tem com a loja.", "informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtDiferenca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtAvalista.Enabled == false)
                {
                    tabcCadastro.SelectedTab = tabcCadastro2;
                }
                else
                {
                    txtAvalista.Select();
                }
            }
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

        private void btnProcurar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbSubGrupo.Enabled == true)
                {
                    cbbSubGrupo.Select();
                }
                else
                {
                    txtEndereco.Select();
                }
            }
        }

        private void cbbSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEndereco.Select();
            }
        }

        private void cbbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    if (cbbGrupo.Text != "")
                    {
                        string[] items = cbbGrupo.SelectedItem.ToString().Split('—');
                        cbbSubGrupo.Items.Clear();
                        if (bllClieCons.Sel_SubGrupo_Clie(items[0]) == null)
                        {
                            cbbSubGrupo.Text = null;
                            cbbSubGrupo.Enabled = false;
                            btnProcurar2.Enabled = false;
                            lblAstSub.Enabled = false;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllClieCons.Sel_SubGrupo_Clie(items[0]).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblAstSub.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        cbbSubGrupo.Items.Clear();
                        cbbSubGrupo.Text = null;
                        cbbSubGrupo.Enabled = false;
                        btnProcurar2.Enabled = false;
                        lblAstSub.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                    }
                    cbbGrupo.Text = null;
                    cbbSubGrupo.Text = null;
                }
            }
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(5))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbGrupo.Items.Clear();
                        if (bllClieCons.Sel_Grupo_Clie() == null)
                        {
                            cbbGrupo.Text = null;
                            cbbSubGrupo.Items.Clear();
                            cbbSubGrupo.Enabled = false;
                            cbbSubGrupo.Text = null;
                            btnProcurar2.Enabled = false;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                            }
                        }
                        //
                        cbbGrupo.Text = bllClieCons._Grupo_PesqGrupo_Tabela;
                        bllClieCons._Grupo_PesqGrupo_Tabela = null;
                        cbbGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        cbbGrupo.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurar2_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbGrupo.Text != "")
                {
                    string[] items = cbbGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 3))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbSubGrupo.Items.Clear();
                            if (bllClieCons.Sel_SubGrupo_Clie(items[0]) == null)
                            {
                                cbbSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllClieCons.Sel_SubGrupo_Clie(items[0]).Rows)
                                {
                                    cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbSubGrupo.Text = bllClieCons._SubGrupo_PesqSubGrupo_Tabela;
                            bllClieCons._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbSubGrupo.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                cbbSubGrupo.Text = null;
            }
            pEnabled.Enabled = true;
        }

        private void btnIncluirDadosCEP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluirDadosCEP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncluirDadosCEP_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbCidadeAval_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidadeAval_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtClie_DoubleClick(object sender, EventArgs e)
        {
            btnAlterar_Click(sender, e);
        }

        private void dtClie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
            }
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEndereco_DoubleClick(object sender, EventArgs e)
        {
            if (txtEndereco.Enabled == true)
            {
                if (txtEndereco.Text == "")
                {
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];

                    txtEndereco.Text = dr["endereco"].ToString();
                }
            }
        }

        private void txtEndereco_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) 
            {
                if (txtEndereco.Enabled == true)
                {
                    if (txtEndereco.Text == "")
                    {
                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];

                        txtEndereco.Text = dr["endereco"].ToString();
                    }
                }
            }
        }

        private void txtNumero_DoubleClick(object sender, EventArgs e)
        {
            if (txtNumero.Enabled == true)
            {
                if (txtNumero.Text == "")
                {
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];

                    txtNumero.Text = dr["numero"].ToString();
                }
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (txtNumero.Enabled == true)
                {
                    if (txtNumero.Text == "")
                    {
                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];

                        txtNumero.Text = dr["numero"].ToString();
                    }
                }
            }
        }

        private void txtBairro_DoubleClick(object sender, EventArgs e)
        {
            if (txtBairro.Enabled == true)
            {
                if (txtBairro.Text == "")
                {
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];

                    txtBairro.Text = dr["bairro"].ToString();
                }
            }
        }

        private void txtBairro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (txtBairro.Enabled == true)
                {
                    if (txtBairro.Text == "")
                    {
                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];

                        txtBairro.Text = dr["bairro"].ToString();
                    }
                }
            }
        }

        private void btnCadastrarCNPJ_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmCadCNPJ CNPJ = new FrmCadCNPJ(_Usuario, _Cod_PDV_Computador, 0))
                {
                    if (CNPJ.ShowDialog() == DialogResult.OK)
                    {
                        if (bllClieCons.Sel_Clie_CPFCNPJ(bllClieCons._CNPJ_PesqCNPJ_Tabela) != null)
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_CPFCNPJ(bllClieCons._CNPJ_PesqCNPJ_Tabela);
                            dtClie.Select();
                        }
                        else
                        {
                            dtClie.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        bllClieCons._CNPJ_PesqCNPJ_Tabela = null;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão  btnCadastrarCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão  btnCadastrarCNPJ.");
                }
                bllClieCons._CNPJ_PesqCNPJ_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void Executar_Visao_Geral() 
        {
            DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
            //
            DataRow dr;
            //
            if (bllClieCons.Sel_Clie_Data_Hora_Ult_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Data_Hora_Ult_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr["data"] != null & dr["data"] != DBNull.Value)
                {
                    mtxtDataUltCompra.Text = dr["data"].ToString().Remove(10);
                    //
                    txtTempComprou.Text = (Convert.ToDateTime(DateTime.Now.ToShortDateString()) - Convert.ToDateTime(mtxtDataUltCompra.Text)).TotalDays.ToString();
                }
                else
                {
                    mtxtDataUltCompra.Text = null;
                    //
                    txtTempComprou.Text = "0";
                }
                //
                if (dr["hora"] != null & dr["hora"] != DBNull.Value)
                {
                    mtxtHorarioultCompra.Text = dr["hora"].ToString();
                }
                else
                {
                    mtxtHorarioultCompra.Text = null;
                }

            }
            else
            {
                mtxtDataUltCompra.Text = null;
                //
                mtxtHorarioultCompra.Text = null;
                //
                txtTempComprou.Text = "0";
            }
            //
            if (bllClieCons.Sel_Clie_Total_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Total_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtQtdeCompras.Text = dr[0].ToString();
                }
                else
                {
                    txtQtdeCompras.Text = "0,00";
                }
            }
            else
            {
                txtQtdeCompras.Text = "0,00";
            }
            //
            if (bllClieCons.Sel_Clie_Valor_Total_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Valor_Total_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtGastoCompras.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtGastoCompras.Text = "0,00";
                }
            }
            else
            {
                txtGastoCompras.Text = "0,00";
            }
            //
            if (bllClieCons.Sel_Clie_Valor_Medio_Total_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Valor_Medio_Total_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtTicketMedio.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtTicketMedio.Text = "0,00";
                }
            }
            else
            {
                txtTicketMedio.Text = "0,00";
            }
            //
            if (bllClieCons.Sel_Clie_Qtde_Produto_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Qtde_Produto_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtQtdeProduto.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtQtdeProduto.Text = "0,00";
                }
            }
            else
            {
                txtQtdeProduto.Text = "0,00";
            }
            //
            if (bllClieCons.Sel_Clie_Qtde_Servico_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Qtde_Servico_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtQtdeServico.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtQtdeServico.Text = "0,00";
                }
            }
            else
            {
                txtQtdeServico.Text = "0,00";
            }
            //
            if (bllClieCons.Sel_Clie_Intervalo_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Intervalo_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtIntervalo.Text = dr[0].ToString();
                }
                else
                {
                    txtIntervalo.Text = "0";
                }
            }
            else
            {
                txtIntervalo.Text = "0";
            }
            //
            if (bllClieCons.Sel_Clie_Conta_Receber_Atrasada(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Conta_Receber_Atrasada(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtTotalEmAtraso.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtTotalEmAtraso.Text = "0,00";
                }
            }
            else
            {
                txtTotalEmAtraso.Text = "0,00";
            }
            //
            if (bllClieCons.Sel_Clie_Data_Hora_Ult_Alteracao(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllClieCons.Sel_Clie_Data_Hora_Ult_Alteracao(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr["data_ult_alteracao"] != null & dr["data_ult_alteracao"] != DBNull.Value)
                {
                    mtxtDataUltAltSistema.Text = dr["data_ult_alteracao"].ToString().Remove(10);
                    //
                    mtxtHorarioUltAltSistema.Text = dr["data_ult_alteracao"].ToString().Substring(11);
                }
                else
                {
                    mtxtDataUltAltSistema.Text = null;
                    //
                    mtxtHorarioUltAltSistema.Text = null;
                }
            }
            else
            {
                mtxtDataUltAltSistema.Text = null;
                //
                mtxtHorarioUltAltSistema.Text = null;
            }
        }

        private void tabcCadastro4_Enter(object sender, EventArgs e)
        {
            try
            {
                _Visao_Geral_Clie_Cons = true;
                //
                if (dtClie.DataSource != null & (_Inserir_Atualizar == true & _Comando_Atualizar == true))
                {
                    Executar_Visao_Geral();
                }
                else if (dtClie.DataSource != null & (_Inserir_Atualizar == false & _Comando_Atualizar == false))
                {
                    Executar_Visao_Geral();
                }
                //
                if (_Inserir_Atualizar == true)
                {
                    mtxtDataCadastro.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento enter do tabcCadastro4.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento enter do tabcCadastro4.");
                }
            }
        }

        private void tabcCadastro_Enter(object sender, EventArgs e)
        {
            _Visao_Geral_Clie_Cons = false;
        }

        private void mtxtDataCadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataUltCompra.Select();
            }
        }

        private void mtxtDataUltCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioultCompra.Select();
            }
        }

        private void mtxtHorarioultCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTempComprou.Select();
            }
        }

        private void txtTempComprou_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQtdeCompras.Select();
            }
        }

        private void txtGastoCompras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTicketMedio.Select();
            }
        }

        private void txtTicketMedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQtdeProduto.Select();
            }
        }

        private void txtQtdeProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQtdeServico.Select();
            }
        }

        private void txtQtdeServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIntervalo.Select();
            }
        }

        private void txtIntervalo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalEmAtraso.Select();
            }
        }

        private void txtTotalEmAtraso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataUltAltSistema.Select();
            }
        }

        private void txtQtdeCompras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGastoCompras.Select();
            }
        }

        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;
                using (FrmInfImpressao Imp = new FrmInfImpressao(52))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        if (bllClieCons._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                        {
                            using (var doc = new PdfDocument())
                            {
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
                                var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                var fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                var fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                                //
                                XPen pen1 = new XPen(XColors.AntiqueWhite);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                //
                                StringFormat Sf1 = new StringFormat();
                                Sf1.Alignment = StringAlignment.Near;
                                //
                                StringFormat Sf2 = new StringFormat();
                                Sf2.Alignment = StringAlignment.Far;
                                //
                                int Incrementar = 0;
                                //
                                textFormatter1.DrawString(bllMinhaEmpresa.Sel_Nome_Empresa(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 12));
                                Margem_Topo = Margem_Topo + 12;
                                textFormatter1.DrawString(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 12));
                                Margem_Topo = Margem_Topo + 12;
                                //
                                textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 1 + Incrementar + Margem_Topo, 198, 24));
                                textFormatter1.DrawString("VISÃO GERAL DO CLIENTE/CONSUMIDOR", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 24));
                                textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 12 + Incrementar + Margem_Topo, 198, 24));
                                //
                                Margem_Topo = Margem_Topo - 14;
                                //
                                textFormatter2.DrawString("Cliente/Consumidor: " + SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 36 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Data de Cadastro: " + mtxtDataCadastro.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 46 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Data e Horário da última Compra: " + mtxtDataUltCompra.Text + " " + mtxtHorarioultCompra.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                                //
                                Margem_Topo = Margem_Topo + 10;
                                textFormatter2.DrawString("Há quanto tempo comprou? Há " + txtTempComprou.Text + " dias.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Quantidade de Compras (Produtos/Serviços): " + txtQtdeCompras.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 66 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Total das Compras: " + txtGastoCompras.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 76 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Ticket Médio: " + txtTicketMedio.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 86 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Quantidade de Produtos Comprados: " + txtQtdeProduto.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Quantidade de Serviços Comprados: " + txtQtdeServico.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 106 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Intervalo entre Compras (Dias): " + txtIntervalo.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 116 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Total em Atraso: " + txtTotalEmAtraso.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 126 + Margem_Topo, 198, 7));
                                //
                                Margem_Topo = Margem_Topo + 10;
                                mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltAltSistema.Text == "")
                                {
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 126 + Margem_Topo, 198, 7));
                                }
                                else
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: " + mtxtDataUltAltSistema.Text + " " + mtxtHorarioUltAltSistema.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 126 + Margem_Topo, 198, 7));
                                }
                                //
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 146 + Margem_Topo, 198, 16));
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
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                                }
                            }
                        }
                        else if(bllClieCons._Tipo_Impressao == "PDF A4")
                        {
                            using (var doc = new PdfDocument())
                            {
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
                                var fonte4 = new XFont("Microsoft Sans Serif", 10);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                XPen pen1 = new XPen(XColors.AntiqueWhite);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                //
                                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                                //
                                StringFormat Sf1 = new StringFormat();
                                Sf1.Alignment = StringAlignment.Near;
                                //
                                StringFormat Sf2 = new StringFormat();
                                Sf2.Alignment = StringAlignment.Far;
                                //
                                int Incrementar = 0;
                                //
                                textFormatter1.DrawString(bllMinhaEmpresa.Sel_Nome_Empresa() + "    " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 10 + Margem_Topo, 595, 13));
                                //
                                Margem_Topo = Convert.ToInt16(Margem_Topo + 17);
                                //
                                textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 1 + Margem_Topo, 595, 24));
                                textFormatter1.DrawString("VISÃO GERAL DO CLIENTE/CONSUMIDOR", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 10 + Margem_Topo, 595, 13));
                                textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 16 + Margem_Topo, 595, 24));
                                //
                                Margem_Topo = Margem_Topo - 14;
                                //
                                textFormatter2.DrawString("Cliente/Consumidor: " + SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 47 + Margem_Topo, 595, 7));
                                //
                                Margem_Topo = Margem_Topo + 14;
                                textFormatter2.DrawString("Data de Cadastro: " + mtxtDataCadastro.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 47 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Data e Horário da última Compra: " + mtxtDataUltCompra.Text + " " + mtxtHorarioultCompra.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 61 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Há quanto tempo comprou? Há " + txtTempComprou.Text + " dias.", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 75 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Quantidade de Compras (Produtos/Serviços): " + txtQtdeCompras.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 89 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Total das Compras: " + txtGastoCompras.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 103 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Ticket Médio: " + txtTicketMedio.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 117 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Quantidade de Produtos Comprados: " + txtQtdeProduto.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 131 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Quantidade de Serviços Comprados: " + txtQtdeServico.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 145 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Intervalo entre Compras (Dias): " + txtIntervalo.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 159 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Total em Atraso: " + txtTotalEmAtraso.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 173 + Margem_Topo, 595, 7));
                                //
                                Margem_Topo = Margem_Topo + 14;
                                mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltAltSistema.Text == "")
                                {
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 173 + Margem_Topo, 595, 7));
                                }
                                else
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: " + mtxtDataUltAltSistema.Text + " " + mtxtHorarioUltAltSistema.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 173 + Margem_Topo, 595, 7));
                                }
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 216 + Margem_Topo, 585, 11));
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
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                                }
                            }
                        }
                    }
                }
                //
                AbrirPDF.Pdf(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarPDF.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarPDF.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Visão Geral: Exibe um relatório geral resumido sobre o cliente/consumidor.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void mtxtDataUltAltSistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioUltAltSistema.Select();
            }
        }

        private void mtxtHorarioUltAltSistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (btnSalvar.Enabled == false)
                {
                    dtClie.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
            }
        }
    }
}
