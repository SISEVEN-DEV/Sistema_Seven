using BLL;
using Seven_ADM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmMinhaEmpresa : Form
    {
        public FrmMinhaEmpresa(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private bool _Contem_Imagem;
        private string _Cod_PDV_Computador;
        private bool _Ult_Num_NFe;
        private bool _Ult_Num_NFCe;
        private bool _Ult_Num_NFSe;

        private void FrmMinhaEmpresa_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMinhaEmpresa iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMinhaEmpresa iniciado.");
                }
                //
                cbbDentroTrib.Items.Clear();
                cbbForaTrib.Items.Clear();
                cbbDentroSubs.Items.Clear();
                cbbForaSubs.Items.Clear();
                if (bllMinhaEmpresa.Sel_Cfop_Minha_Empresa() == null)
                {
                    cbbDentroTrib.Text = null;
                    cbbForaTrib.Text = null;
                    cbbDentroSubs.Text = null;
                    cbbForaSubs.Text = null;
                }
                else
                {
                    foreach (DataRow dr in bllMinhaEmpresa.Sel_Cfop_Minha_Empresa().Rows)
                    {
                        cbbDentroTrib.Items.Add(dr["cod_cfop"].ToString());
                        cbbForaTrib.Items.Add(dr["cod_cfop"].ToString());
                        cbbDentroSubs.Items.Add(dr["cod_cfop"].ToString());
                        cbbForaSubs.Items.Add(dr["cod_cfop"].ToString());
                    }
                }
                //
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    cbbCRT.Text = "SIMPLES NACIONAL";
                    cbbDentroTrib.Text = "5102";
                    cbbForaTrib.Text = "6102";
                    cbbDentroSubs.Text = "5405";
                    cbbForaSubs.Text = "6405";
                    txtSerieNFe.Text = "1";
                    txtSerieNFCe.Text = "1";
                    rbtnPJuridica.Checked = true;
                    rbtnPJuridica1.Checked = true;
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    txtUltNNFCe.Text = (bllDFe.Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado("65", txtSerieNFCe.Text) - 1).ToString();
                    txtUltNNFe.Text = (bllDFe.Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado("55", txtSerieNFe.Text) - 1).ToString();
                    chkbBkpAut.Checked = true;
                    txtEmpresa.Select();
                }
                else
                {
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    if (Convert.ToByte(dr["pessoa"]) == 1)
                    {
                        rbtnPJuridica.Checked = true;
                        mtxtCNPJ.Text = dr["cpf_cnpj"].ToString();
                        txtFantasia.Text = dr["fantasia"].ToString();
                    }
                    else
                    {
                        rbtnPFisica.Checked = true;
                        mtxtCPF.Text = dr["cpf_cnpj"].ToString();
                        cbbSexo.Text = dr["genero"].ToString();
                    }
                    //
                    txtEmpresa.Text = dr["nome"].ToString();
                    txtIERG.Text = dr["ie_rg"].ToString();
                    mtxtTelefone.Text = dr["telefone"].ToString();
                    mtxtCelular.Text = dr["celular"].ToString();
                    txtEndereco.Text = dr["endereco"].ToString();
                    txtNumero.Text = dr["numero"].ToString();
                    txtComplemento.Text = dr["complemento"].ToString();
                    txtBairro.Text = dr["bairro"].ToString();
                    cbbUF.Text = dr["uf"].ToString();
                    cbbCidade.Text = dr["cidade"].ToString();
                    mtxtCEP.Text = dr["cep"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtlReferencia.Text = dr["referencia"].ToString();
                    txtLocalizacao.Text = dr["localizacao"].ToString();
                    //
                    if (dr["imagem_logo"] != DBNull.Value)
                    {
                        byte[] imagemBytes = (byte[])dr["imagem_logo"];
                        //
                        using (MemoryStream ms = new MemoryStream(imagemBytes))
                        {
                            Image imagem = Image.FromStream(ms);
                            pcibImagem.Image = imagem;
                            pcibImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        //
                        _Contem_Imagem = true;
                    }
                    else
                    {
                        _Contem_Imagem = false;
                        pcibImagem.Image = null;
                        pcibImagem.ImageLocation = null;
                    }
                    //
                    if (Convert.ToByte(dr["pessoa_contador"]) == 1)
                    {
                        rbtnPJuridica1.Checked = true;
                        mtxtCNPJ1.Text = dr["cpf_cnpj_contador"].ToString();
                        txtFantasia1.Text = dr["fantasia_contador"].ToString();
                    }
                    else
                    {
                        rbtnPFisica1.Checked = true;
                        mtxtCPF1.Text = dr["cpf_cnpj_contador"].ToString();
                        cbbSexo1.Text = dr["genero_contador"].ToString();
                    }
                    //
                    txtEmpresa1.Text = dr["nome_contador"].ToString();
                    txtIERG1.Text = dr["ie_rg_contador"].ToString();
                    mtxtTelefone1.Text = dr["telefone_contador"].ToString();
                    mtxtCelular1.Text = dr["celular_contador"].ToString();
                    txtEndereco1.Text = dr["endereco_contador"].ToString();
                    txtNumero1.Text = dr["numero_contador"].ToString();
                    txtComplemento1.Text = dr["complemento_contador"].ToString();
                    txtBairro1.Text = dr["bairro_contador"].ToString();
                    cbbUF1.Text = dr["uf_contador"].ToString();
                    cbbCidade1.Text = dr["cidade_contador"].ToString();
                    mtxtCEP1.Text = dr["cep_contador"].ToString();
                    txtEmail1.Text = dr["email_contador"].ToString();
                    txtReferencia1.Text = dr["referencia_contador"].ToString();
                    txtLocalizacao1.Text = dr["localizacao_contador"].ToString();
                    //
                    txtEmailEmpresa.Text = dr["email_empresa"].ToString();
                    txtSenhaEmailEmpresa.Text = dr["senha_email_empresa"].ToString();
                    cbbCRT.Text = dr["crt"].ToString();
                    //
                    cbbDentroTrib.Text = dr["cfop_trib_dentro"].ToString();
                    cbbForaTrib.Text = dr["cfop_trib_fora"].ToString();
                    cbbDentroSubs.Text = dr["cfop_subs_dentro"].ToString();
                    cbbForaSubs.Text = dr["cfop_subs_fora"].ToString();
                    //
                    txtSerieNFCe.Text = dr["serie_nfce"].ToString();
                    txtSerieNFe.Text = dr["serie_nfe"].ToString();
                    txtCodMunicipio.Text = dr["codigo_municipio"].ToString();
                    //
                    txtInscMun.Text = dr["inscricao_municipal"].ToString();
                    //
                    if (Convert.ToByte(dr["backup_automatico"]) == 1)
                    {
                        chkbBkpAut.Checked = true;
                    }
                    else
                    {
                        chkbBkpAut.Checked = false;
                    }
                    //
                    if (Convert.ToInt32(dr["ult_num_nfce"]) == 0)
                    {
                        txtUltNNFCe.Text = (bllDFe.Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado("65", txtSerieNFCe.Text) - 1).ToString();
                    }
                    else
                    {
                        txtUltNNFCe.Text = dr["ult_num_nfce"].ToString();
                    }
                    //
                    if (Convert.ToInt32(dr["ult_num_nfe"]) == 0)
                    {
                        txtUltNNFe.Text = (bllDFe.Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado("55", txtSerieNFe.Text) - 1).ToString();
                    }
                    else
                    {
                        txtUltNNFe.Text = dr["ult_num_nfe"].ToString();
                    }
                    //
                    if (Convert.ToInt32(dr["ult_num_nfse"]) == 0)
                    {

                    }
                    else
                    {

                    }
                    //
                    _Ult_Num_NFCe = false;
                    _Ult_Num_NFe = false;
                    //
                    btnAlterar.Enabled = true;
                    btnSalvar.Enabled = false;
                    //
                    txtEmpresa.Select();
                }
                //
                if (bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", null, "TRANSMITIDA", null, null) == null)
                {
                    btnEmitirNFe.Visible = true;
                }
                //
                MessageBox.Show("Atenção, preencha as informações da sua empresa conforme os dados registrados na SEFAZ. Em caso de dúvidas sobre algum campo ou informação, entre em contato com o nosso suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMinhaEmpresa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMinhaEmpresa.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            txtEmpresa.Text = null;
            mtxtCNPJ.Text = null;
            mtxtCPF.Text = null;
            txtIERG.Text = null;
            txtFantasia.Text = null;
            txtEndereco.Text = null;
            txtNumero.Text = null;
            txtComplemento.Text = null;
            txtBairro.Text = null;
            cbbUF.Text = null;
            cbbCidade.Text = null;
            mtxtCEP.Text = null;
            mtxtTelefone.Text = null;
            mtxtCelular.Text = null;
            txtEmail.Text = null;
            cbbSexo.Text = null;
            txtEmpresa1.Text = null;
            mtxtCNPJ1.Text = null;
            mtxtCPF1.Text = null;
            txtIERG1.Text = null;
            txtFantasia1.Text = null;
            txtEndereco1.Text = null;
            txtNumero1.Text = null;
            txtComplemento1.Text = null;
            txtBairro1.Text = null;
            cbbUF1.Text = null;
            cbbCidade1.Text = null;
            mtxtCEP1.Text = null;
            mtxtTelefone1.Text = null;
            mtxtCelular1.Text = null;
            txtEmail1.Text = null;
            cbbSexo1.Text = null;
        }

        private void txtEmpresa_Enter(object sender, EventArgs e)
        {
            txtEmpresa.BackColor = Color.LightBlue;
        }

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPFisica.Checked == true)
                {
                    mtxtCPF.Select();
                }
                else
                {
                    mtxtCNPJ.Select();
                }
            }
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            if (txtEmpresa.Text.Contains("'") || txtEmpresa.Text.Contains(";") || txtEmpresa.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmpresa.Text = null;
            }
            txtEmpresa.BackColor = Color.White;
        }

        private void mtxtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPFisica.Checked == true)
                {
                    cbbSexo.Select();
                }
                else
                {
                    txtFantasia.Select();
                }
            }
        }

        private void txtIERG_Enter(object sender, EventArgs e)
        {
            txtIERG.BackColor = Color.LightBlue;
        }

        private void txtIERG_Leave(object sender, EventArgs e)
        {
            if (txtIERG.Text.Contains("'") || txtIERG.Text.Contains(";") || txtIERG.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtIERG.Text = null;
            }
            txtIERG.BackColor = Color.White;
        }

        private void txtIERG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEndereco.Select();
            }
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
            }
            txtFantasia.BackColor = Color.White;
        }

        private void txtFantasia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtInscMun.Select();
            }
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
            }
            txtEndereco.BackColor = Color.White;
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumero.Select();
            }
        }

        private void txtNumero_Enter(object sender, EventArgs e)
        {
            txtNumero.BackColor = Color.LightBlue;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtBairro.Select();
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (txtNumero.Text.Contains("'") || txtNumero.Text.Contains(";") || txtNumero.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNumero.Text = null;
            }
            txtNumero.BackColor = Color.White;
        }

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            txtComplemento.BackColor = Color.LightBlue;
        }

        private void txtComplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtlReferencia.Select();
            }
        }

        private void txtComplemento_Leave(object sender, EventArgs e)
        {
            if (txtComplemento.Text.Contains("'") || txtComplemento.Text.Contains(";") || txtComplemento.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtComplemento.Text = null;
            }
            txtComplemento.BackColor = Color.White;
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.LightBlue;
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtComplemento.Select();
            }
        }

        private void txtBairro_Leave(object sender, EventArgs e)
        {
            if (txtBairro.Text.Contains("'") || txtBairro.Text.Contains(";") || txtBairro.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtBairro.Text = null;
            }
            txtBairro.BackColor = Color.White;
        }

        private void cbbCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodMunicipio.Select();
            }
        }

        private void cbbUF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCidade.Select();
            }
        }

        private void mtxtCEP_Enter(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.LightBlue;
        }

        private void mtxtCEP_Leave(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.White;
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

        private void mtxtCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtCNPJ.BackColor = Color.LightBlue;
        }

        private void mtxtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPFisica.Checked == true)
                {
                    cbbSexo.Select();
                }
                else
                {
                    txtFantasia.Select();
                }
            }
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

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            lblIE_RG.Text = "RG:";
            mtxtCPF.Visible = true;
            lblCPF.Text = "CPF:";
            mtxtCPF.Text = null;
            mtxtCNPJ.Visible = false;
            lblFantasia.Visible = false;
            txtFantasia.Visible = false;
            cbbSexo.Visible = true;
            lblSexo.Visible = true;
            txtFantasia.Text = null;
            label4.Location = new Point(310, 35);
            txtEmpresa.Select();
        }

        private void rbtnCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            lblIE_RG.Text = "Inscrição Estadual:";
            mtxtCPF.Visible = false;
            lblCPF.Text = "CNPJ:";
            mtxtCNPJ.Visible = true;
            mtxtCNPJ.Text = null;
            txtFantasia.Visible = true;
            lblFantasia.Visible = true;
            cbbSexo.Visible = false;
            lblSexo.Visible = false;
            cbbSexo.Text = null;
            label4.Location = new Point(317, 35);
            txtEmpresa.Select();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                try
                {
                    mtxtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (txtEmpresa.Text.Trim() == "" || (mtxtCPF.Text == "" & mtxtCNPJ.Text == "") || txtEndereco.Text.Trim() == "" || txtNumero.Text.Trim() == "" || txtBairro.Text.Trim() == "" || cbbUF.Text == "" || cbbCidade.Text == "" || mtxtCEP.Text == "" || cbbDentroSubs.Text == "" || cbbForaSubs.Text == "" || cbbDentroTrib.Text == "" || cbbForaTrib.Text == "" || txtSerieNFCe.Text == "0" || txtSerieNFCe.Text == "" || txtSerieNFe.Text == "0" || txtSerieNFe.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Empresa ], [ CPF/CNPJ ], [ Endereço ], [ Numero ], [ Bairro ], [ UF ], [ Cidade ], [ CEP ], [ CFOP Tributado/Isento ], [ CFOP Substituído ] e [ Série NFe/NFCe ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        bllMinhaEmpresa.Salvar(txtEmpresa.Text.Trim(), mtxtCPF.Text, txtIERG.Text.Trim(), txtFantasia.Text, txtEndereco.Text.Trim(), txtNumero.Text.Trim(), txtComplemento.Text.Trim(), txtBairro.Text.Trim(), cbbUF.Text, cbbCidade.Text, mtxtCEP.Text, mtxtTelefone.Text, mtxtCelular.Text, txtEmail.Text.Trim(), txtLocalizacao.Text.Trim(), txtlReferencia.Text.Trim(), bllMinhaEmpresa._Url_Imagem, cbbSexo.Text, grbBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text, _Cod_PDV_Computador, txtEmpresa1.Text.Trim(), mtxtCPF1.Text, txtIERG1.Text.Trim(), txtFantasia1.Text.Trim(), txtEndereco1.Text.Trim(), txtNumero1.Text.Trim(), txtComplemento1.Text.Trim(), txtBairro1.Text.Trim(), cbbUF1.Text, cbbCidade1.Text, mtxtCEP1.Text, mtxtTelefone1.Text, mtxtCelular1.Text, txtEmail1.Text.Trim(), txtLocalizacao1.Text.Trim(), txtReferencia1.Text.Trim(), cbbSexo1.Text, grbBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text, mtxtCNPJ.Text, mtxtCNPJ1.Text, txtEmailEmpresa.Text.Trim(), txtSenhaEmailEmpresa.Text.Trim(), cbbCRT.Text, cbbForaTrib.Text, cbbDentroTrib.Text, cbbDentroSubs.Text, cbbForaSubs.Text, txtSerieNFe.Text, txtSerieNFCe.Text, txtCodMunicipio.Text, txtInscMun.Text, chkbBkpAut.Checked, txtUltNNFCe.Text, txtUltNNFe.Text, txtUltNFSe.Text, _Ult_Num_NFe, _Ult_Num_NFCe, _Ult_Num_NFSe);
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.None;
                        bllRegistroAtividades.Salvar("SALVOU DADOS DA EMPRESA.", "MINHA EMPRESA", "1", _Usuario, _Cod_PDV_Computador);
                        //
                        btnAlterar.Enabled = true;
                        btnSalvar.Enabled = false;
                        //
                        bllMinhaEmpresa._Nome_Arquivo = null;
                        bllMinhaEmpresa._Url_Imagem = null;
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Minha Empresa salva. Cod: 1 | Nome/Razão Social: " + txtEmpresa.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Minha Empresa salva. Cod: 1 | Nome/Razão Social: " + txtEmpresa.Text);
                        }
                        //
                        this.DialogResult = DialogResult.Abort;
                    }
                }
                catch (Exception ex)
                {
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
                    bllMinhaEmpresa._Nome_Arquivo = null;
                    bllMinhaEmpresa._Url_Imagem = null;
                    Limpar();
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                txtEmpresa.Select();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            btnAlterar.Select();
            DialogResult = MessageBox.Show("Deseja alterar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                try
                {
                    mtxtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (txtEmpresa.Text.Trim() == "" || (mtxtCPF.Text == "" & mtxtCNPJ.Text == "") || txtEndereco.Text.Trim() == "" || txtNumero.Text.Trim() == "" || txtBairro.Text.Trim() == "" || cbbUF.Text == "" || cbbCidade.Text == "" || mtxtCEP.Text == "" || cbbDentroSubs.Text == "" || cbbForaSubs.Text == "" || cbbDentroTrib.Text == "" || cbbForaTrib.Text == "" || txtSerieNFCe.Text == "0" || txtSerieNFCe.Text == "" || txtSerieNFe.Text == "0" || txtSerieNFe.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Empresa ], [ CPF/CNPJ ], [ Endereço ], [ Numero ], [ Bairro ], [ UF ], [ Cidade ], [ CEP ], [ CFOP Tributado/Isento ], [ CFOP Substituído ] e [ Série NFe/NFCe ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        bllMinhaEmpresa.Alterar(txtEmpresa.Text.Trim(), mtxtCPF.Text, txtIERG.Text.Trim(), txtFantasia.Text, txtEndereco.Text.Trim(), txtNumero.Text.Trim(), txtComplemento.Text.Trim(), txtBairro.Text.Trim(), cbbUF.Text, cbbCidade.Text, mtxtCEP.Text, mtxtTelefone.Text, mtxtCelular.Text, txtEmail.Text.Trim(), txtLocalizacao.Text.Trim(), txtlReferencia.Text.Trim(), pcibImagem.ImageLocation, cbbSexo.Text, grbBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text, _Cod_PDV_Computador, txtEmpresa1.Text.Trim(), mtxtCPF1.Text, txtIERG1.Text.Trim(), txtFantasia1.Text.Trim(), txtEndereco1.Text.Trim(), txtNumero1.Text.Trim(), txtComplemento1.Text.Trim(), txtBairro1.Text.Trim(), cbbUF1.Text, cbbCidade1.Text, mtxtCEP1.Text, mtxtTelefone1.Text, mtxtCelular1.Text, txtEmail1.Text.Trim(), txtLocalizacao1.Text.Trim(), txtReferencia1.Text.Trim(), cbbSexo1.Text, grbBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text, mtxtCNPJ.Text, mtxtCNPJ1.Text, txtEmailEmpresa.Text.Trim(), txtSenhaEmailEmpresa.Text.Trim(), cbbCRT.Text, cbbForaTrib.Text, cbbDentroTrib.Text, cbbDentroSubs.Text, cbbForaSubs.Text, txtSerieNFe.Text, txtSerieNFCe.Text, txtCodMunicipio.Text, txtInscMun.Text, chkbBkpAut.Checked, txtUltNNFCe.Text, txtUltNNFe.Text, txtUltNFSe.Text, _Ult_Num_NFe, _Ult_Num_NFCe, _Ult_Num_NFSe);
                        //
                        if (_Contem_Imagem == true)
                        {
                            if (bllMinhaEmpresa._Url_Imagem != null)
                            {
                                bllMinhaEmpresa.Alterar_Imagem_Logo("1", bllMinhaEmpresa._Url_Imagem);
                            }
                        }
                        else
                        {
                            bllMinhaEmpresa.Alterar_Imagem_Logo("1", bllMinhaEmpresa._Url_Imagem);
                        }
                        //
                        MessageBox.Show("Os dados foram alterados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.None;
                        bllRegistroAtividades.Salvar("ALTEROU DADOS DA EMPRESA.", "MINHA EMPRESA", "1", _Usuario, _Cod_PDV_Computador);
                        //                      
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Minha Empresa alterada. Cod: 1 | Nome/Razão Social: " + txtEmpresa.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Minha Empresa alterada. Cod: 1 | Nome/Razão Social: " + txtEmpresa.Text);
                        }
                        //
                        this.DialogResult = DialogResult.Abort;
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
                    bllMinhaEmpresa._Nome_Arquivo = null;
                    bllMinhaEmpresa._Url_Imagem = null;
                    Limpar();
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                txtEmpresa.Select();
            }
        }

        private void FrmMinhaEmpresa_KeyUp(object sender, KeyEventArgs e)
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

        private void rbtnCPF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCNPJ_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCNPJ_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private static List<string> _Codigo_Municipio = new List<string>();

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

        private void btnDadosInfEmpresa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDadosInfEmpresa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImagemSistema_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 5))
                {
                    if (Imagem.ShowDialog() == DialogResult.OK)
                    {
                        if (bllMinhaEmpresa._Url_Imagem == null)
                        {
                            if (bllMinhaEmpresa._Excluir_Imagem == true)
                            {
                                pcibImagem.Enabled = false;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllMinhaEmpresa._Url_Imagem = null;
                                bllMinhaEmpresa._Excluir_Imagem = false;
                                _Contem_Imagem = false;
                            }
                            else if (bllMinhaEmpresa._Mostrar_Imagem == true)
                            {
                                DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                //
                                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Minha Empresa\Imagem\"))
                                {
                                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema\Minha Empresa\Imagem\");
                                }
                                byte[] imagemBytes = (byte[])dr["imagem_logo"];
                                string caminho = @"C:\Windows\Temp\Sistema SEVEN\Minha Empresa\Imagem\logo.jpg";
                                File.WriteAllBytes(caminho, imagemBytes);
                                Process.Start(caminho);
                                bllMinhaEmpresa._Mostrar_Imagem = false;
                            }
                           
                        }
                        else
                        {
                            pcibImagem.Enabled = true;
                            _Contem_Imagem = true;
                            pcibImagem.ImageLocation = bllMinhaEmpresa._Url_Imagem;
                            //
                            if (bllMinhaEmpresa._Excluir_Imagem == true)
                            {
                                pcibImagem.Enabled = false;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllMinhaEmpresa._Excluir_Imagem = false;
                                _Contem_Imagem = false;
                            }
                            else if (bllMinhaEmpresa._Mostrar_Imagem == true)
                            {
                                pcibImagem.Enabled = true;
                                Process.Start(bllMinhaEmpresa._Url_Imagem);
                                bllMinhaEmpresa._Mostrar_Imagem = false;
                            }
                        }
                    }
                }
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnImagemLogo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnImagemLogo.");
                }
            }
        }

        private void FrmMinhaEscola_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMinhaEmpresa foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMinhaEmpresa foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                bllMinhaEmpresa._Nome_Arquivo = null;
                bllMinhaEmpresa._Url_Imagem = null;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmMinhaEmpresa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmMinhaEmpresa.");
                }
            }
        }

        private void btnImagemSistema_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImagemSistema_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtTelefone_Enter(object sender, EventArgs e)
        {
            mtxtTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelular.Select();
            }
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

        private void mtxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmpresa1.Select();
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.LightBlue;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtTelefone.Select();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Contains("'") || txtEmail.Text.Contains(";") || txtEmail.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmail.Text = null;
            }
            else if (!txtEmail.Text.Contains("@") && txtEmail.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtEmail.Text = null;
            }
            txtEmail.BackColor = Color.White;
        }

        private void mtxtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmail.Select();
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informe os dados da empresa e do contador que serão cadastrados neste software mantendo fidelidade aos cadastros de pessoa física e/ou jurídca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    if (bllMinhaEmpresa._Url_Imagem == null)
                    {
                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                        //
                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Minha Empresa\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Minha Empresa\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])dr["imagem_logo"];
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Minha Empresa\Imagem\logo.jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        Process.Start(bllMinhaEmpresa._Url_Imagem);
                        bllMinhaEmpresa._Mostrar_Imagem = false;
                    }
                }
            }
            catch (Exception ex)
            {
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
            }
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibImagem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            if (pcibImagem.ImageLocation != null)
            {
                MessageBox.Show("1 - Adicionar imagem: Clique em [ Adicionar Logo Marca ] para adicionar uma imagem.\n\n2 - Caminho da imagem:\n" + pcibImagem.ImageLocation, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                MessageBox.Show("1 - Adicionar imagem: Clique em [ Adicionar Logo Marca ] para adicionar uma imagem.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
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

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG.Select();
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

        private void cbbSexo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSexo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblLocalizacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUF.Select();
            }
        }

        private void lblLocalizacao_Enter(object sender, EventArgs e)
        {
            txtLocalizacao.BackColor = Color.LightBlue;
        }

        private void txtLocalizacao_Leave(object sender, EventArgs e)
        {
            if (txtLocalizacao.Text.Contains("'") || txtLocalizacao.Text.Contains(";") || txtLocalizacao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtLocalizacao.Text = null;
            }
            txtLocalizacao.BackColor = Color.White;
        }

        private void lblReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtLocalizacao.Select();
            }
        }

        private void lblReferencia_Enter(object sender, EventArgs e)
        {
            txtlReferencia.BackColor = Color.LightBlue;
        }

        private void txtlReferencia_Leave(object sender, EventArgs e)
        {
            if (txtlReferencia.Text.Contains("'") || txtlReferencia.Text.Contains(";") || txtlReferencia.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtlReferencia.Text = null;
            }
            txtlReferencia.BackColor = Color.White;
        }

        private void txtEmpresa1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPFisica1.Checked == true)
                {
                    mtxtCPF1.Select();
                }
                else
                {
                    mtxtCNPJ1.Select();
                }
            }
        }

        private void txtEmpresa1_Enter(object sender, EventArgs e)
        {
            txtEmpresa1.BackColor = Color.LightBlue;
        }

        private void txtEmpresa1_Leave(object sender, EventArgs e)
        {
            if (txtEmpresa1.Text.Contains("'") || txtEmpresa1.Text.Contains(";") || txtEmpresa1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmpresa1.Text = null;
            }
            txtEmpresa1.BackColor = Color.White;
        }

        private void mtxtCPF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPFisica1.Checked == true)
                {
                    cbbSexo1.Select();
                }
                else
                {
                    txtFantasia1.Select();
                }
            }
        }

        private void mtxtCNPJ1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPFisica1.Checked == true)
                {
                    cbbSexo1.Select();
                }
                else
                {
                    txtFantasia1.Select();
                }
            }
        }

        private void cbbSexo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG1.Select();
            }
        }

        private void cbbSexo1_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSexo1_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSexo1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSexo1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtFantasia1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG1.Select();
            }
        }

        private void txtFantasia1_Enter(object sender, EventArgs e)
        {
            txtFantasia1.BackColor = Color.LightBlue;
        }

        private void txtFantasia1_Leave(object sender, EventArgs e)
        {
            if (txtFantasia1.Text.Contains("'") || txtFantasia1.Text.Contains(";") || txtFantasia1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtFantasia1.Text = null;
            }
            txtFantasia1.BackColor = Color.White;
        }

        private void txtIERG1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEndereco1.Select();
            }
        }

        private void txtIERG1_Enter(object sender, EventArgs e)
        {
            txtIERG1.BackColor = Color.LightBlue;
        }

        private void txtIERG1_Leave(object sender, EventArgs e)
        {
            if (txtIERG1.Text.Contains("'") || txtIERG1.Text.Contains(";") || txtIERG1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtIERG1.Text = null;
            }
            txtIERG1.BackColor = Color.White;
        }

        private void txtEndereco1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumero1.Select();
            }
        }

        private void txtEndereco1_Enter(object sender, EventArgs e)
        {
            txtEndereco1.BackColor = Color.LightBlue;
        }

        private void txtEndereco1_Leave(object sender, EventArgs e)
        {
            if (txtEndereco1.Text.Contains("'") || txtEndereco1.Text.Contains(";") || txtEndereco1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEndereco1.Text = null;
            }
            txtEndereco1.BackColor = Color.White;
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtBairro1.Select();
            }
        }

        private void txtNumero1_Enter(object sender, EventArgs e)
        {
            txtNumero1.BackColor = Color.LightBlue;
        }

        private void txtNumero1_Leave(object sender, EventArgs e)
        {
            if (txtNumero1.Text.Contains("'") || txtNumero1.Text.Contains(";") || txtNumero1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNumero1.Text = null;
            }
            txtNumero1.BackColor = Color.White;
        }

        private void txtBairro1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtComplemento1.Select();
            }
        }

        private void txtBairro1_Enter(object sender, EventArgs e)
        {
            txtBairro1.BackColor = Color.LightBlue;
        }

        private void txtBairro1_Leave(object sender, EventArgs e)
        {
            if (txtBairro1.Text.Contains("'") || txtBairro1.Text.Contains(";") || txtBairro1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtBairro1.Text = null;
            }
            txtBairro1.BackColor = Color.White;
        }

        private void txtComplemento1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtReferencia1.Select();
            }
        }

        private void txtComplemento1_Enter(object sender, EventArgs e)
        {
            txtComplemento1.BackColor = Color.LightBlue;
        }

        private void txtComplemento1_Leave(object sender, EventArgs e)
        {
            if (txtComplemento1.Text.Contains("'") || txtComplemento1.Text.Contains(";") || txtComplemento1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtComplemento1.Text = null;
            }
            txtComplemento1.BackColor = Color.White;
        }

        private void txtReferencia1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUF1.Select();
            }
        }

        private void txtReferencia1_Enter(object sender, EventArgs e)
        {
            txtReferencia1.BackColor = Color.LightBlue;
        }

        private void txtReferencia1_Leave(object sender, EventArgs e)
        {
            if (txtReferencia1.Text.Contains("'") || txtReferencia1.Text.Contains(";") || txtReferencia1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtReferencia1.Text = null;
            }
            txtReferencia1.BackColor = Color.White;
        }

        private void cbbUF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCidade1.Select();
            }
        }

        private void cbbUF1_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF1_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUF1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUF1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbUF1.SelectedIndex == 0)
                {
                    cbbCidade1.Items.Clear();
                }
                else if (cbbUF1.SelectedIndex == 1)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 2)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 3)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 4)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 5)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 6)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 7)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 8)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 9)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 10)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 11)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 12)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 13)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 14)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 15)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 16)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 17)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 18)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 19)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 20)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 21)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 22)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 23)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 24)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 25)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 26)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF1.SelectedIndex == 27)
                {
                    cbbCidade1.Items.Clear();
                    cbbCidade1.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade1.Items.Add(items[0]);
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
                cbbCidade1.Text = null;
            }
        }

        private void cbbCidade1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtLocalizacao1.Select();
            }
        }

        private void cbbCidade1_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade1_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCidade1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtLocalizacao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCEP1.Select();
            }
        }

        private void txtLocalizacao1_Enter(object sender, EventArgs e)
        {
            txtLocalizacao1.BackColor = Color.LightBlue;
        }

        private void txtLocalizacao1_Leave(object sender, EventArgs e)
        {
            if (txtLocalizacao1.Text.Contains("'") || txtLocalizacao1.Text.Contains(";") || txtLocalizacao1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtLocalizacao1.Text = null;
            }
            txtLocalizacao1.BackColor = Color.White;
        }

        private void mtxtCEP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmail1.Select();
            }
        }

        private void mtxtCEP1_Enter(object sender, EventArgs e)
        {
            mtxtCEP1.BackColor = Color.LightBlue;
        }

        private void mtxtCEP1_Leave(object sender, EventArgs e)
        {
            mtxtCEP1.BackColor = Color.White;
        }

        private void txtEmail1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtTelefone1.Select();
            }
        }

        private void txtEmail1_Enter(object sender, EventArgs e)
        {
            txtEmail1.BackColor = Color.LightBlue;
        }

        private void txtEmail1_Leave(object sender, EventArgs e)
        {
            if (txtEmail1.Text.Contains("'") || txtEmail1.Text.Contains(";") || txtEmail1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmail1.Text = null;
            }
            else if (!txtEmail1.Text.Contains("@") && txtEmail1.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtEmail1.Text = null;
            }
            txtEmail1.BackColor = Color.White;
        }

        private void mtxtTelefone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelular1.Select();
            }
        }

        private void mtxtTelefone1_Enter(object sender, EventArgs e)
        {
            mtxtTelefone1.BackColor = Color.LightBlue;
        }

        private void mtxtTelefone1_Leave(object sender, EventArgs e)
        {
            mtxtTelefone1.BackColor = Color.White;
        }

        private void mtxtCelular1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (btnSalvar.Enabled == true)
                {
                    btnSalvar.Select();
                }
                else
                {
                    btnAlterar.Select();
                }
            }
        }

        private void mtxtCelular1_Enter(object sender, EventArgs e)
        {
            mtxtCelular1.BackColor = Color.LightBlue;
        }

        private void mtxtCelular1_Leave(object sender, EventArgs e)
        {
            mtxtCelular1.BackColor = Color.White;
        }

        private void rbtnPFisica1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPFisica1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPJuridica1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPJuridica1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPFisica1_CheckedChanged(object sender, EventArgs e)
        {
            lblIE_RG1.Text = "RG:";
            mtxtCPF1.Visible = true;
            lblCPF1.Text = "CPF:";
            mtxtCPF1.Text = null;
            mtxtCNPJ1.Visible = false;
            lblFantasia1.Visible = false;
            txtFantasia1.Visible = false;
            cbbSexo1.Visible = true;
            lblSexo1.Visible = true;
            txtFantasia1.Text = null;
            txtEmpresa1.Select();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtCPF1_Enter(object sender, EventArgs e)
        {
            mtxtCPF1.BackColor = Color.LightBlue;
        }

        private void mtxtCPF1_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCPF1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCPF1.Text != "")
                {
                    if (ValidarCNPJECPF.ValidarCPF(mtxtCPF1.Text))
                    {
                        mtxtCPF1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCPF1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        MessageBox.Show("CPF inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCPF1.Text = null;
                        mtxtCPF1.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPF1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCPF1.");
                }
                mtxtCPF1.Text = null;
            }
            mtxtCPF1.BackColor = Color.White;
        }

        private void mtxtCNPJ1_Enter(object sender, EventArgs e)
        {
            mtxtCNPJ1.BackColor = Color.LightBlue;
        }

        private void rbtnPJuridica1_CheckedChanged(object sender, EventArgs e)
        {
            lblIE_RG1.Text = "Inscrição Estadual:";
            mtxtCPF1.Visible = false;
            lblCPF1.Text = "CNPJ:";
            mtxtCNPJ1.Visible = true;
            mtxtCNPJ1.Text = null;
            txtFantasia1.Visible = true;
            lblFantasia1.Visible = true;
            cbbSexo1.Visible = false;
            lblSexo1.Visible = false;
            cbbSexo1.Text = null;
            txtEmpresa1.Select();
        }

        private void mtxtCNPJ1_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCNPJ1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCNPJ1.Text != "")
                {
                    if (ValidarCNPJECPF.ValidaCNPJ(mtxtCNPJ1.Text))
                    {
                        mtxtCNPJ1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtCNPJ1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        MessageBox.Show("CNPJ inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCNPJ1.Text = null;
                        mtxtCNPJ1.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCNPJ1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCNPJ1.");
                }
                mtxtCNPJ1.Text = null;
            }
            mtxtCNPJ1.BackColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (txtSenhaEmailEmpresa.PasswordChar == '●')
            {
                txtSenhaEmailEmpresa.PasswordChar = '\0';
            }
            else
            {
                txtSenhaEmailEmpresa.PasswordChar = '●';
            }
            txtSenhaEmailEmpresa.Select();
        }

        private void txtEmailEmpresa_Enter(object sender, EventArgs e)
        {
            txtEmailEmpresa.BackColor = Color.LightBlue;
        }

        private void txtEmailEmpresa_Leave(object sender, EventArgs e)
        {
            if (txtEmailEmpresa.Text.Contains("'") || txtEmailEmpresa.Text.Contains(";") || txtEmailEmpresa.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEmailEmpresa.Text = null;
            }
            else if (!txtEmailEmpresa.Text.Contains("@") && txtEmailEmpresa.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtEmailEmpresa.Text = null;
            }
            txtEmailEmpresa.BackColor = Color.White;
        }

        private void txtEmailEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenhaEmailEmpresa.Select();
            }
        }

        private void txtSenhaEmailEmpresa_Enter(object sender, EventArgs e)
        {
            txtSenhaEmailEmpresa.BackColor = Color.LightBlue;
        }

        private void txtSenhaEmailEmpresa_Leave(object sender, EventArgs e)
        {
            txtSenhaEmailEmpresa.BackColor = Color.White;
        }

        private void btnVer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCRT_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCRT_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCRT_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCRT_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDentroTrib_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDentroTrib_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDentroTrib_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDentroTrib_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForaTrib_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForaTrib_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForaTrib_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForaTrib_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDentroSubs_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDentroSubs_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDentroSubs_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDentroSubs_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForaSubs_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForaSubs_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForaSubs_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForaSubs_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNFe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSerieNFCe.Select();
            }
        }

        private void txtNFCe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtUltNNFe.Select();
            }
        }

        private void txtNFe_Enter(object sender, EventArgs e)
        {
            txtSerieNFe.BackColor = Color.LightBlue;
        }

        private void txtNFe_Leave(object sender, EventArgs e)
        {
            if (txtSerieNFe.Text.Contains("'") || txtSerieNFe.Text.Contains(";") || txtSerieNFe.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtSerieNFe.Text = null;
            }
            txtSerieNFe.BackColor = Color.White;
        }

        private void txtNFCe_Leave(object sender, EventArgs e)
        {
            if (txtSerieNFCe.Text.Contains("'") || txtSerieNFCe.Text.Contains(";") || txtSerieNFCe.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtSerieNFCe.Text = null;
            }
            txtSerieNFCe.BackColor = Color.White;
        }

        private void txtNFCe_Enter(object sender, EventArgs e)
        {
            txtSerieNFCe.BackColor = Color.LightBlue;
        }

        private void txtCodMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCEP.Select();
            }
        }

        private void cbbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbCidade.Text == "")
                {
                    txtCodMunicipio.Text = null;
                }
                else
                {
                    txtCodMunicipio.Text = _Codigo_Municipio[cbbCidade.SelectedIndex - 1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbCidade");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbCidade");
                }
            }
        }

        private void btnEmitirNFe_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("ATENÇÃO!\n\nPara emitir documentos fiscais, entre em contato com o suporte do sistema para realizar as configurações necessárias.\n\nDeseja fazer isso agora?", "Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                Process.Start("https://wa.me/5575982868624?text=Ol%C3%A1");
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnEmitirNFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEmitirNFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtSenhaEmailEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCRT.Select();
            }
        }

        private void cbbCRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbDentroTrib.Select();
            }
        }

        private void cbbForaTrib_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbDentroSubs.Select();
            }
        }

        private void cbbDentroTrib_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbForaTrib.Select();
            }
        }

        private void cbbDentroSubs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbForaSubs.Select();
            }
        }

        private void cbbForaSubs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSerieNFe.Select();
            }
        }

        private void txtInscMun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG.Select();
            }
        }

        private void txtInscMun_Enter(object sender, EventArgs e)
        {
            txtInscMun.BackColor = Color.LightBlue;
        }

        private void txtInscMun_Leave(object sender, EventArgs e)
        {
            if (txtInscMun.Text.Contains("'") || txtInscMun.Text.Contains(";") || txtInscMun.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtInscMun.Text = null;
            }
            txtInscMun.BackColor = Color.White;
        }

        private void chkbBkpAut_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbBkpAut_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAtualizarUltNumeracao_Click(object sender, EventArgs e)
        {

        }

        private void txtUltNNFe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtUltNNFe.Select();
            }
        }

        private void txtUltNNFCe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtUltNFSe.Select();
            }
        }

        private void txtUltNNSe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEmpresa.Select();
            }
        }

        private void txtUltNNFe_Enter(object sender, EventArgs e)
        {
            txtUltNNFe.BackColor = Color.LightBlue;
        }

        private void txtUltNNFe_Leave(object sender, EventArgs e)
        {
            if (txtUltNNFe.Text.Contains("'") || txtUltNNFe.Text.Contains(";") || txtUltNNFe.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtUltNNFe.Text = null;
            }
            txtUltNNFe.BackColor = Color.White;
        }

        private void txtUltNNFCe_Leave(object sender, EventArgs e)
        {
            if (txtUltNNFCe.Text.Contains("'") || txtUltNNFCe.Text.Contains(";") || txtUltNNFCe.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtUltNNFCe.Text = null;
            }
            txtUltNNFCe.BackColor = Color.White;
        }

        private void txtUltNNFCe_Enter(object sender, EventArgs e)
        {
            txtUltNNFCe.BackColor = Color.LightBlue;
        }

        private void txtUltNNSe_Enter(object sender, EventArgs e)
        {
            txtUltNFSe.BackColor = Color.LightBlue;
        }

        private void txtUltNNSe_Leave(object sender, EventArgs e)
        {
            if (txtUltNFSe.Text.Contains("'") || txtUltNFSe.Text.Contains(";") || txtUltNFSe.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtUltNFSe.Text = null;
            }
            txtUltNFSe.BackColor = Color.White;
        }

        private void txtUltNFSe_TextChanged(object sender, EventArgs e)
        {
            _Ult_Num_NFSe = true;
        }

        private void txtUltNNFe_TextChanged(object sender, EventArgs e)
        {
            _Ult_Num_NFe = true;
        }

        private void txtUltNNFCe_TextChanged(object sender, EventArgs e)
        {
            _Ult_Num_NFCe = true;
        }

        private void btnCadastrarCNPJ_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmCadCNPJ CNPJ = new FrmCadCNPJ(_Usuario, _Cod_PDV_Computador, 2))
                {
                    if (CNPJ.ShowDialog() == DialogResult.OK)
                    {
                        string[] items = bllMinhaEmpresa._CNPJ_Dados.Split('—');
                        //
                            rbtnPJuridica1_CheckedChanged(sender, e);
                            //
                            txtEmpresa.Text = items[0];
                            //
                            mtxtCNPJ.Text = items[1];
                            //
                            txtIERG.Text = items[2];
                            //
                            mtxtCEP.Text = items[3];
                            //
                            txtEndereco.Text = items[4];
                            //
                            cbbCidade.Text = items[5];
                            //
                            cbbUF.Text = items[6];
                            //
                            txtComplemento.Text = items[7];
                            //
                            txtBairro.Text = items[8];
                            //
                            txtNumero.Text = items[9];
                            //
                            txtFantasia.Text = items[10];
                            //
                            txtCodMunicipio.Text = items[11];
                        
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão  btnCadastrarCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão  btnCadastrarCNPJ.");
                }
            }
            this.Enabled = true;
        }
    }
}
