using BLL;
using Seven_ADM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadFornecedor : Form
    {
        public FrmCadFornecedor(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private bool _Contem_Imagem;
        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private static List<string> _Codigo_Municipio = new List<string>();
        private byte _Formulario;

        private void FrmCadFornecedor_Load(object sender, EventArgs e)
        {
            try
            {
                bllFornecedor._FrmCadFornecedor_Ativo = true;
                //
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFornecedor iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFornecedor iniciado.");
                }
                //
                rbtnNome.Checked = true;
                //
                if (_Formulario == 1)
                {
                    btnExcluir.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFornecedor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFornecedor.");
                }
                this.Close();
            }
        }

        public void Ativar()
        {
            lblQtdeCar.Enabled = true;
            rbtnPfisica.Enabled = true;
            rbtnPjuridica.Enabled = true;
            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            txtNome.Enabled = true;
            txtPalavraChave.Enabled = true;
            mtxtCPF.Enabled = true;
            mtxtCNPJ.Enabled = true;
            txtFantasia.Enabled = true;
            mtxtDNascimento.Enabled = true;
            txtIERG.Enabled = true;
            mtxtTelefone.Enabled = true;
            mtxtFAX.Enabled = true;
            mtxtCelular.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            cbbUF.Enabled = true;
            cbbCidade.Enabled = true;
            mtxtCEP.Enabled = true;
            txtEmail.Enabled = true;
            cbbSexo.Enabled = true;
            rtxtObs.Enabled = true;
            lblPalavraChave.Enabled = true;
            lblNome.Enabled = true;
            lblCPF_CNPJ.Enabled = true;
            lblFantasia.Enabled = true;
            lblDataNascimento.Enabled = true;
            lblIE_RG.Enabled = true;
            lblTelefone.Enabled = true;
            lblFAX.Enabled = true;
            lblCelular.Enabled = true;
            lblEndereco.Enabled = true;
            lblNumero.Enabled = true;
            lblComplemento.Enabled = true;
            lblBairro.Enabled = true;
            lblUF.Enabled = true;
            lblCidade.Enabled = true;
            lblCEP.Enabled = true;
            lblEmail.Enabled = true;
            lblSexo.Enabled = true;
            lblObs.Enabled = true;
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtPalavraChave.Text = null;
            txtNome.Text = null;
            txtFantasia.Text = null;
            mtxtDNascimento.Text = null;
            mtxtCPF.Text = null;
            mtxtCNPJ.Text = null;
            txtIERG.Text = null;
            cbbSexo.Text = null;
            txtEndereco.Text = null;
            txtNumero.Text = null;
            txtComplemento.Text = null;
            txtBairro.Text = null;
            cbbUF.Text = null;
            cbbCidade.Text = null;
            mtxtCEP.Text = null;
            mtxtTelefone.Text = null;
            mtxtCelular.Text = null;
            mtxtFAX.Text = null;
            txtEmail.Text = null;
            rtxtObs.Text = null;
        }

        private void ModoPesquisa()
        {
            rbtnPfisica.Enabled = false;
            rbtnPjuridica.Enabled = false;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            label8.Enabled = false;
            lblQtdeCar.Enabled = false;
            txtCodigo.Enabled = false;
            lblCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtPalavraChave.Enabled = false;
            mtxtCPF.Enabled = false;
            mtxtCNPJ.Enabled = false;
            txtFantasia.Enabled = false;
            mtxtDNascimento.Enabled = false;
            txtIERG.Enabled = false;
            mtxtTelefone.Enabled = false;
            mtxtFAX.Enabled = false;
            mtxtCelular.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            cbbUF.Enabled = false;
            cbbCidade.Enabled = false;
            mtxtCEP.Enabled = false;
            txtEmail.Enabled = false;
            cbbSexo.Enabled = false;
            rtxtObs.Enabled = false;
            lblCodigo.Enabled = false;
            lblPalavraChave.Enabled = false;
            lblNome.Enabled = false;
            lblCPF_CNPJ.Enabled = false;
            lblFantasia.Enabled = false;
            lblDataNascimento.Enabled = false;
            lblIE_RG.Enabled = false;
            lblTelefone.Enabled = false;
            lblFAX.Enabled = false;
            lblCelular.Enabled = false;
            lblEndereco.Enabled = false;
            lblNumero.Enabled = false;
            lblComplemento.Enabled = false;
            lblBairro.Enabled = false;
            lblUF.Enabled = false;
            lblCidade.Enabled = false;
            lblCEP.Enabled = false;
            lblEmail.Enabled = false;
            lblSexo.Enabled = false;
            lblObs.Enabled = false;
            //
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtForn.DataSource != null)
            {
                dtForn.Enabled = true;
                dtForn.Select();
            }
        }

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Location = new Point(309, 19);
            lblPesquisar.Text = "Digite o nome/razão social:";
            txtpNome.Visible = true;
            txtpNome.MaxLength = 60;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnPalavra_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpPalavraChave.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(527, 19);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpNome.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            mtxtpCPF.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(570, 19);
            txtpCodigo.Visible = true;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(537, 19);
            lblPesquisar.Text = "Digite o cnpj:";
            mtxtpCNPJ.Visible = true;
            mtxtpCNPJ.Text = null;
            mtxtpCNPJ.Select();
        }

        private void rbtnRG_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(528, 19);
            lblPesquisar.Text = "Digite o rg:";
            txtpRG.Visible = true;
            txtpRG.TextAlign = HorizontalAlignment.Right;
            txtpRG.MaxLength = 20;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o cpf:";
            lblPesquisar.Location = new Point(571, 19);
            mtxtpCPF.Visible = true;
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            mtxtpCPF.Visible = false;
            lblPesquisar.Location = new Point(619, 19);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void rbtnPjuridica_CheckedChanged(object sender, EventArgs e)
        {
            lblIE_RG.Text = "Inscrição Estadual:";
            lblCPF_CNPJ.Text = "CNPJ:";
            lblDataNascimento.Visible = false;
            mtxtDNascimento.Visible = false;
            mtxtCNPJ.Visible = true;
            mtxtCPF.Visible = false;
            lblFantasia.Visible = true;
            txtFantasia.Visible = true;
            lblNome.Text = "Razão Social:";
            lblSexo.Visible = false;
            cbbSexo.Visible = false;
            label1.Location = new Point(243, 0);

            if (_Inserir_Atualizar == true)
            {
                txtFantasia.Text = null;
                mtxtCNPJ.Text = null;
                txtIERG.Text = null;
                txtPalavraChave.Select();
            }
        }

        private void rbtnPfisica_CheckedChanged(object sender, EventArgs e)
        {
            lblIE_RG.Text = "RG:";
            lblCPF_CNPJ.Text = "CPF:";
            lblDataNascimento.Visible = true;
            mtxtDNascimento.Visible = true;
            mtxtCNPJ.Visible = false;
            mtxtCPF.Visible = true;
            lblFantasia.Visible = false;
            txtFantasia.Visible = false;
            lblNome.Text = "Nome:";
            lblSexo.Visible = true;
            cbbSexo.Visible = true;
            label1.Location = new Point(207, 0);

            if (_Inserir_Atualizar == true)
            {
                mtxtDNascimento.Text = null;
                mtxtCPF.Text = null;
                txtIERG.Text = null;
                txtPalavraChave.Select();
            }
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
                txtpNome.Text = null;
                txtpNome.Select();
            }
            txtpNome.BackColor = Color.White;
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
                txtpRG.Text = null;
                txtpRG.Select();
            }
            txtpRG.BackColor = Color.White;
        }

        private void mtxtpCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.LightBlue;
        }

        private void mtxtpCNPJ_Leave(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.White;
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
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
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
                txtNome.Text = null;
                txtNome.Select();
            }
            txtNome.BackColor = Color.White;
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
                txtFantasia.Text = null;
                txtFantasia.Select();
            }
            txtFantasia.BackColor = Color.White;
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
                                if (bllFornecedor.Sel_F_CNPJCPF_Alt(txtCodigo.Text, mtxtCPF.Text) == true)
                                {
                                    MessageBox.Show("O CPF informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    mtxtCPF.Text = null;
                                    mtxtCPF.Select();
                                }
                            }
                            else
                            {
                                if (bllFornecedor.Sel_F_CNPJCPF(mtxtCPF.Text) == true)
                                {
                                    MessageBox.Show("O CPF informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    mtxtCPF.Text = null;
                                    mtxtCPF.Select();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mtxtCPF.Text = null;
                        mtxtCPF.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caxia de texto mtxtCPF.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caxia de texto mtxtCPF.");
                }
                mtxtCPF.Text = null;
            }
            mtxtCPF.BackColor = Color.White;
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
                    if (_Inserir_Atualizar == true)
                    {
                        if (ValidarCNPJECPF.ValidaCNPJ(mtxtCNPJ.Text))
                        {
                            mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (_Comando_Atualizar == true)
                            {
                                if (bllFornecedor.Sel_F_CNPJCPF_Alt(txtCodigo.Text, mtxtCNPJ.Text) == true)
                                {
                                    MessageBox.Show("O CNPJ informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    mtxtCNPJ.Text = null;
                                    mtxtCNPJ.Select();
                                }
                            }
                            else
                            {
                                if (bllFornecedor.Sel_F_CNPJCPF(mtxtCNPJ.Text) == true)
                                {
                                    MessageBox.Show("O CNPJ informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    mtxtCNPJ.Text = null;
                                    mtxtCNPJ.Select();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("CNPJ inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtCNPJ.Text = null;
                            mtxtCNPJ.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caxia de texto mtxtCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caxia de texto mtxtCNPJ.");
                }
                mtxtCNPJ.Text = null;
            }
            mtxtCNPJ.BackColor = Color.White;
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
                txtIERG.Text = null;
                txtIERG.Select();
            }
            else
            {
                try
                {
                    if (_Inserir_Atualizar == true)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (rbtnPfisica.Checked == true)
                            {
                                if (bllFornecedor.Sel_F_RG_alt(txtCodigo.Text, txtIERG.Text) == true)
                                {
                                    MessageBox.Show("O RG informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtIERG.Text = null;
                                    txtIERG.Select();
                                }
                            }
                            else
                            {
                                if (bllFornecedor.Sel_F_IE_alt(txtCodigo.Text, txtIERG.Text) == true)
                                {
                                    MessageBox.Show("A Inscrição Estadual informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtIERG.Text = null;
                                    txtIERG.Select();
                                }
                            }
                        }
                        else
                        {
                            if (rbtnPfisica.Checked == true)
                            {
                                if (bllFornecedor.Sel_F_Rg(txtIERG.Text) == true)
                                {
                                    MessageBox.Show("O RG informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtIERG.Text = null;
                                    txtIERG.Select();
                                }
                            }
                            else
                            {
                                if (bllFornecedor.Sel_F_Ie(txtIERG.Text) == true)
                                {
                                    MessageBox.Show("A Inscrição Estadual informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtIERG.Text = null;
                                    txtIERG.Select();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caxia de texto txtIERG.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caxia de texto txtIERG.");
                    }
                    txtIERG.Text = null;
                }
            }
            txtIERG.BackColor = Color.White;
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
                txtNumero.Text = null;
                txtNumero.Select();
            }
            txtNumero.BackColor = Color.White;
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

        private void mtxtTelefone_Enter(object sender, EventArgs e)
        {
            mtxtTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtTelefone_Leave(object sender, EventArgs e)
        {
            mtxtTelefone.BackColor = Color.White;
        }

        private void mtxtFAX_Enter(object sender, EventArgs e)
        {
            mtxtFAX.BackColor = Color.LightBlue;
        }

        private void mtxtFAX_Leave(object sender, EventArgs e)
        {
            mtxtFAX.BackColor = Color.White;
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
                txtEmail.Text = null;
                txtEmail.Select();
            }
            else if (!txtEmail.Text.Contains("@") && txtEmail.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Text = null;
                txtEmail.Select();
            }
            txtEmail.BackColor = Color.White;
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
                if (rbtnPfisica.Checked == true)
                {
                    mtxtCPF.Select();
                }
                else
                {
                    mtxtCNPJ.Select();
                }
            }
        }

        private void txtFantasia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG.Select();
            }
        }

        private void mtxtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtFantasia.Select();
            }
        }

        private void mtxtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDNascimento.Select();
            }
        }

        private void txtIERG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                mtxtTelefone.Select();
            }
        }

        private void cbbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabPage2;
            }
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumero.Select();
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

        private void mtxtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtFAX.Select();
            }
        }

        private void mtxtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmail.Select();
            }
        }

        private void mtxtFAX_KeyPress(object sender, KeyPressEventArgs e)
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
                txtEndereco.Select();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnPfisica.Checked == true)
                {
                    cbbSexo.Select();
                }
                else
                {
                    tabcCadastro.SelectedTab = tabPage2;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtForn.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtForn.Enabled = false;
                grbBox1.Enabled = false;
                Ativar();
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                Limpar();
                pcibAjudaFoto.Enabled = true;
                pcibImagem.Image = null;
                rbtnPjuridica.Checked = true;
                lblLegendaImagem.Text = "Adicionar imagem.";
                txtPalavraChave.Select();
                lblLegendaImagem.Visible = true;
                _Inserir_Atualizar = true;
                _Comando_Atualizar = false;
                cbbUF.Text = "AC";
                cbbUF.Text = "BA";
                cbbCidade.Text = bllMinhaEmpresa.Sel_Cidade_Empresa();
                mtxtCEP.Text = bllMinhaEmpresa.Sel_CEP_Empresa();
                tabcCadastro.SelectedTab = tabPage1;
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
                dtForn.DataSource = null;
                rbtnNome.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllFornecedor.Sel_Fornecedor_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtForn.Select();
                }
                else
                {
                    if (_Contem_Imagem == false)
                    {
                        lblLegendaImagem.Text = "Adicionar imagem.";
                        pcibImagem.Image = null;
                    }
                    dtForn.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtForn.Enabled = false;
                    grbBox1.Enabled = false;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    Ativar();
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    pcibAjudaFoto.Enabled = true;
                    txtPalavraChave.Select();
                    _Comando_Atualizar = true;
                    _Inserir_Atualizar = true;
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
                dtForn.DataSource = null;
                rbtnNome.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtComplemento_Leave(object sender, EventArgs e)
        {
            if (txtComplemento.Text.Contains("'") || txtComplemento.Text.Contains(";") || txtComplemento.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtComplemento.Text = null;
                txtComplemento.Select();
            }
            txtComplemento.BackColor = Color.White;
        }

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            txtComplemento.BackColor = Color.LightBlue;
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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
                            cbbCidade.Items.Add(items[0]);
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                mtxtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (txtNome.Text == "" || txtEndereco.Text == "" || txtNumero.Text == "" || cbbCidade.Text == "" || txtBairro.Text == "" || mtxtCEP.Text == "" || cbbUF.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Nome/Razão Social ], [ Endereço ], [ Número ], [ Bairro ], [ UF ], [ Cidade ] e [ CEP ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    txtPalavraChave.Select();
                }
                else
                {
                    try
                    {
                        btnSalvar.Select();
                        mtxtCEP.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (_Comando_Atualizar == true)
                        {
                            if (bllFornecedor.Sel_Fornecedor_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtForn.DataSource = null;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllFornecedor._Url_Imagem = null;
                                rbtnNome.Checked = true;
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
                                    bllFornecedor.Alterar(txtCodigo.Text, txtNome.Text.Trim(), mtxtCPF.Text, txtIERG.Text.Trim(), mtxtTelefone.Text, mtxtCEP.Text, txtEndereco.Text.Trim(), cbbCidade.Text, cbbUF.Text, txtComplemento.Text.Trim(), txtBairro.Text.Trim(), txtEmail.Text.Trim(), mtxtCelular.Text, txtNumero.Text.Trim(), mtxtFAX.Text, "", mtxtDNascimento.Text, rtxtObs.Text, rbtnPfisica.Text, cbbSexo.Text, txtPalavraChave.Text.Trim(), _Cod_PDV_Computador, _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                                }
                                else
                                {
                                    bllFornecedor.Alterar(txtCodigo.Text, txtNome.Text.Trim(), mtxtCNPJ.Text, txtIERG.Text.Trim(), mtxtTelefone.Text, mtxtCEP.Text, txtEndereco.Text.Trim(), cbbCidade.Text, cbbUF.Text, txtComplemento.Text.Trim(), txtBairro.Text.Trim(), txtEmail.Text.Trim(), mtxtCelular.Text, txtNumero.Text.Trim(), mtxtFAX.Text, txtFantasia.Text.Trim(), "", rtxtObs.Text.Trim(), rbtnPjuridica.Text, "", txtPalavraChave.Text.Trim(), _Cod_PDV_Computador, _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                                }
                                //
                                if (_Contem_Imagem == true)
                                {
                                    if (bllFornecedor._Url_Imagem != null)
                                    {
                                        bllFornecedor.Alterar_Imagem_Forn(txtCodigo.Text, bllFornecedor._Url_Imagem);
                                    }
                                }
                                else
                                {
                                    bllFornecedor.Alterar_Imagem_Forn(txtCodigo.Text, bllFornecedor._Url_Imagem);
                                }
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM FORNECEDOR", "FORNECEDORES", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                bllFornecedor.Alterar_Forn_Conta_Pagar(txtCodigo.Text, txtNome.Text.Trim());
                                bllFornecedor.Alterar_Forn_Conta_Receber(txtCodigo.Text, txtNome.Text.Trim());
                                bllFornecedor.Alterar_Forn_DFe(txtCodigo.Text, txtNome.Text.Trim());
                                bllFornecedor.Alterar_Forn_Transportador(txtCodigo.Text, txtNome.Text.Trim());

                                dtForn.DataSource = bllFornecedor.Sel_F_A_Alt(txtCodigo.Text);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Fornecedor alterado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                                }

                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Fornecedor alterado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                                }
                                //
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllFornecedor._Url_Imagem = null;
                                //
                                ModoPesquisa();
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                if (_Formulario == 1)
                                {
                                    bllFornecedor._Cod_Forn_Cadastro = txtCodigo.Text;
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                        }
                        else
                        {
                            if (rbtnPfisica.Checked == true)
                            {
                                bllFornecedor.Salvar(txtNome.Text.Trim(), mtxtCPF.Text, txtIERG.Text.Trim(), mtxtTelefone.Text, mtxtCEP.Text, txtEndereco.Text.Trim(), cbbCidade.Text, cbbUF.Text, txtComplemento.Text.Trim(), txtBairro.Text.Trim(), txtEmail.Text.Trim(), mtxtCelular.Text, txtNumero.Text.Trim(), mtxtFAX.Text, "", mtxtDNascimento.Text, rtxtObs.Text, rbtnPfisica.Text, cbbSexo.Text, txtPalavraChave.Text.Trim(), bllFornecedor._Url_Imagem, _Cod_PDV_Computador, _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                            }
                            else
                            {
                                bllFornecedor.Salvar(txtNome.Text.Trim(), mtxtCNPJ.Text, txtIERG.Text.Trim(), mtxtTelefone.Text, mtxtCEP.Text, txtEndereco.Text.Trim(), cbbCidade.Text, cbbUF.Text, txtComplemento.Text.Trim(), txtBairro.Text.Trim(), txtEmail.Text.Trim(), mtxtCelular.Text, txtNumero.Text.Trim(), mtxtFAX.Text, txtFantasia.Text.Trim(), "", rtxtObs.Text.Trim(), rbtnPjuridica.Text, "", txtPalavraChave.Text.Trim(), bllFornecedor._Url_Imagem, _Cod_PDV_Computador, _Codigo_Municipio[cbbCidade.SelectedIndex - 1]);
                            }

                            dtForn.DataSource = bllFornecedor.Sel_F_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UM FORNECEDOR", "FORNECEDORES", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            pcibImagem.Image = null;
                            pcibImagem.ImageLocation = null;
                            bllFornecedor._Url_Imagem = null;

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Fornecedor cadastrado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }

                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Fornecedor cadastrado. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }

                            ModoPesquisa();

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (_Formulario == 1)
                            {
                                DataGridViewRow SelectedRow = dtForn.Rows[dtForn.CurrentRow.Index];
                                bllFornecedor._Cod_Forn_Cadastro = SelectedRow.Cells[0].Value.ToString();
                                //
                                this.DialogResult = DialogResult.OK;
                            }

                        }
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
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                        pcibImagem.Image = null;
                        pcibImagem.ImageLocation = null;
                        bllFornecedor._Url_Imagem = null;
                        dtForn.DataSource = null;
                        rbtnNome.Checked = true;
                        ModoPesquisa();
                    }
                }
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

        private void rbtnCNPJ_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCNPJ_MouseLeave(object sender, EventArgs e)
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

        private void rbtnCPF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPF_MouseLeave(object sender, EventArgs e)
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

        private void cbbSexo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Select();
            try
            {
                if (rbtnNome.Checked == true)
                {
                    if (txtpNome.Text != "")
                    {
                        if (bllFornecedor.Sel_F_Nome(txtpNome.Text) == null)
                        {
                            dtForn.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_Nome(txtpNome.Text);
                            dtForn.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllFornecedor.Sel_F_Cod(txtpCodigo.Text) == null)
                        {
                            dtForn.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_Cod(txtpCodigo.Text);
                            dtForn.Select();
                        }
                    }
                }
                else if (rbtnPalavra.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllFornecedor.Sel_F_Palavra_chave(txtpPalavraChave.Text) == null)
                        {
                            dtForn.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_Palavra_chave(txtpPalavraChave.Text);
                            dtForn.Select();
                        }
                    }
                }
                else if (rbtnCNPJ.Checked == true)
                {
                    mtxtpCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCNPJ.Text != "")
                    {
                        mtxtpCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFornecedor.Sel_F_Cnpj(mtxtpCNPJ.Text) == null)
                        {
                            dtForn.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_Cnpj(mtxtpCNPJ.Text);
                            dtForn.Select();
                        }
                    }
                }
                else if (rbtnCPF.Checked == true)
                {
                    mtxtpCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCPF.Text != "")
                    {
                        mtxtpCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFornecedor.Sel_F_Cpf(mtxtpCPF.Text) == null)
                        {
                            dtForn.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_Cpf(mtxtpCPF.Text);
                            dtForn.Select();
                        }
                    }
                }
                if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllFornecedor.Sel_F_IERG(txtpRG.Text, 0) == null)
                        {
                            dtForn.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_IERG(txtpRG.Text, 0);
                            dtForn.Select();
                        }
                    }
                }
                if (rbtnIE.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllFornecedor.Sel_F_IERG(txtpRG.Text, 1) == null)
                        {
                            dtForn.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_IERG(txtpRG.Text, 1);
                            dtForn.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllFornecedor.Sel_F_Todos() == null)
                    {
                        dtForn.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtForn.DataSource = bllFornecedor.Sel_F_Todos();
                        dtForn.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou fornecedor.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou fornecedor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dtForn.DataSource = null;
                rbtnNome.Checked = true;
                ModoPesquisa();
            }
        }

        private void txtpRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbtnRG.Checked == true || rbtnIE.Checked == true)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllFornecedor.Sel_Fornecedor_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtForn.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Fornecedor?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllFornecedor.Sel_Forn_Conta_Pagar_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Fornecedor selecionado está sendo utilizado por uma Conta a Pagar, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtForn.Select();
                        }
                        else if (bllFornecedor.Sel_Forn_Conta_Receber_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Fornecedor selecionado está sendo utilizado por uma Conta a Receber, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtForn.Select();
                        }
                        else if (bllFornecedor.Sel_Forn_DFe_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Fornecedor selecionado está sendo utilizado por um DFe, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtForn.Select();
                        }
                        else if (bllFornecedor.Sel_Forn_Transportador_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Fornecedor selecionado está sendo utilizado por um Transportador, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtForn.Select();
                        }
                        else
                        {
                            bllFornecedor.Excluir(txtCodigo.Text);
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UM FORNECEDOR", "FORNECEDORES", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //                     
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Fornecedor excluído. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Fornecedor excluído. Cod: " + txtCodigo.Text + " | Nome/Razão Social: " + txtNome.Text);
                            }
                            //
                            if (rbtnNome.Checked == true)
                            {
                                if (txtpNome.Text != "")
                                {
                                    if (bllFornecedor.Sel_F_Nome(txtpNome.Text) == null)
                                    {
                                        dtForn.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtForn.DataSource = bllFornecedor.Sel_F_Nome(txtpNome.Text);
                                        dtForn.Select();
                                    }
                                }
                                else
                                {
                                    dtForn.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnTodos.Checked == true)
                            {
                                if (bllFornecedor.Sel_F_Todos() == null)
                                {
                                    dtForn.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtForn.DataSource = bllFornecedor.Sel_F_Todos();
                                    dtForn.Select();
                                }
                            }
                            else
                            {
                                dtForn.DataSource = null;
                                Limpar();
                            }
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (dtForn.DataSource != null)
                        {
                            dtForn.Select();
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
                bllFornecedor._Url_Imagem = null;
                dtForn.DataSource = null;
                rbtnNome.Checked = true;
                ModoPesquisa();
            }
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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
                if (dtForn.DataSource == null)
                {
                    Limpar();
                    pcibImagem.Enabled = false;
                    pcibImagem.Image = null;
                    lblLegendaImagem.Visible = false;
                    _Contem_Imagem = false;
                    pcibAjudaFoto.Enabled = false;
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
            bllFornecedor._Url_Imagem = null;
            ModoPesquisa();
        }

        private void dtForn_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtForn.DataSource == null)
            {
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllFornecedor._Url_Imagem = null;
                pcibImagem.Enabled = false;
                lblLegendaImagem.Visible = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                pcibAjudaFoto.Enabled = false;
                dtForn.Enabled = false;
                _Contem_Imagem = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                pcibImagem.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                dtForn.Enabled = true;
            }
        }

        private void dtForn_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtForn.DataSource != null)
            {
                this.Cursor = Cursors.IBeam;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dtForn_MouseLeave(object sender, EventArgs e)
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

        private void rbtnPfisica_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPfisica_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome/razão social, código, cpf, cnpj, rg, inscrição estadual, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtForn_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtForn.Columns[0].HeaderText = "Código";
            dtForn.Columns[1].HeaderText = "Nome/Razão Social";
            dtForn.Columns[2].HeaderText = "Nome Fantasia";
            dtForn.Columns[3].HeaderText = "Data de Nascimento";
            dtForn.Columns[4].HeaderText = "CPF/CNPJ";
            dtForn.Columns[5].HeaderText = "RG/IE";
            dtForn.Columns[6].HeaderText = "Gênero";
            dtForn.Columns[7].HeaderText = "Telefone";
            dtForn.Columns[8].HeaderText = "FAX";
            dtForn.Columns[9].HeaderText = "Celular";
            dtForn.Columns[10].HeaderText = "E-mail";
            dtForn.Columns[11].HeaderText = "Endereço";
            dtForn.Columns[12].HeaderText = "Número";
            dtForn.Columns[13].HeaderText = "Complemento";
            dtForn.Columns[14].HeaderText = "Bairro";
            dtForn.Columns[15].HeaderText = "UF";
            dtForn.Columns[16].HeaderText = "Cidade";
            dtForn.Columns[17].HeaderText = "CEP";
            dtForn.Columns[18].HeaderText = "Observações";
            dtForn.Columns[19].Visible = false;
            dtForn.Columns[20].HeaderText = "Palavra-Chave";
            dtForn.Columns[21].Visible = false;
            dtForn.Columns[22].Visible = false;
            dtForn.Columns[23].Visible = false;
            //
            dtForn.Columns[0].Width = 95;
            dtForn.Columns[1].Width = 325;
            dtForn.Columns[2].Width = 280;
            dtForn.Columns[3].Width = 130;
            dtForn.Columns[4].Width = 129;
            dtForn.Columns[5].Width = 154;
            dtForn.Columns[6].Width = 100;
            dtForn.Columns[7].Width = 100;
            dtForn.Columns[8].Width = 100;
            dtForn.Columns[9].Width = 107;
            dtForn.Columns[10].Width = 220;
            dtForn.Columns[11].Width = 280;
            dtForn.Columns[12].Width = 118;
            dtForn.Columns[13].Width = 260;
            dtForn.Columns[14].Width = 280;
            dtForn.Columns[15].Width = 55;
            dtForn.Columns[16].Width = 280;
            dtForn.Columns[17].Width = 76;
            dtForn.Columns[18].Width = 500;
            dtForn.Columns[20].Width = 125;
            //
            dtForn.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtForn.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtForn.DefaultCellStyle.Font = new Font(dtForn.Font, FontStyle.Bold);
            //
            lblRegistros.Text = "Registros: " + dtForn.Rows.Count;
        }

        private void dtForn_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void rbtnPalavra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtPalavraChave.Text != "")
            {
                if (txtPalavraChave.Text.Contains("'") || txtPalavraChave.Text.Contains(";") || txtPalavraChave.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPalavraChave.Text = null;
                    txtPalavraChave.Select();
                }
                else
                {
                    try
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllFornecedor.Sel_Forn_Palavra_chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllFornecedor.Sel_Forn_Palavra_chave(txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
            txtPalavraChave.BackColor = Color.White;
        }

        private void mtxtDNascimento_Leave(object sender, EventArgs e)
        {
            mtxtDNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDNascimento.Text != "__/__/____" & mtxtDNascimento.Text != "  /  /" & mtxtDNascimento.Text != "")
            {
                try
                {
                    mtxtDNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    ValidarData.Ver_Data(mtxtDNascimento.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDNascimento.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDNascimento.");
                    }
                    mtxtDNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtDNascimento.Text = null;
                }
            }
            mtxtDNascimento.BackColor = Color.White;
        }

        private void mtxtDNascimento_Enter(object sender, EventArgs e)
        {
            mtxtDNascimento.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNome.Select();
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 1))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllFornecedor._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllFornecedor._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllFornecedor._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllFornecedor._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtForn.Rows[dtForn.CurrentRow.Index];

                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllFornecedor._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllFornecedor._Url_Imagem;
                                //
                                if (bllFornecedor._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllFornecedor._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllFornecedor._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllFornecedor._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllFornecedor._Url_Imagem);
                                    bllFornecedor._Mostrar_Imagem = false;
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
                        DataGridViewRow SelectedRow = dtForn.Rows[dtForn.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtForn.DataSource != null)
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
                bllFornecedor._Url_Imagem = null;
                bllFornecedor._Mostrar_Imagem = false;
                bllFornecedor._Excluir_Imagem = false;
            }
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtForn.DataSource != null || _Inserir_Atualizar == true)
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
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            lblLegendaImagem.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 1))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllFornecedor._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllFornecedor._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllFornecedor._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllFornecedor._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtForn.Rows[dtForn.CurrentRow.Index];

                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllFornecedor._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllFornecedor._Url_Imagem;
                                //
                                if (bllFornecedor._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllFornecedor._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllFornecedor._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllFornecedor._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllFornecedor._Url_Imagem);
                                    bllFornecedor._Mostrar_Imagem = false;
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
                        DataGridViewRow SelectedRow = dtForn.Rows[dtForn.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtForn.DataSource != null)
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
                bllFornecedor._Url_Imagem = null;
                bllFornecedor._Mostrar_Imagem = false;
                bllFornecedor._Excluir_Imagem = false;
            }
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtForn.DataSource != null || _Inserir_Atualizar == true)
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

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida.\n\n2 - Adicionar imagem: Clique em [ Adicionar imagem ] para adicionar uma imagem ao registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmCadFornecedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllFornecedor._FrmCadFornecedor_Ativo = false;
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFornecedor foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFornecedor foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFornecedor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFornecedor.");
                }
            }
        }

        private void FrmCadFornecedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cbbSexo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSexo_DropDownClosed(object sender, EventArgs e)
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

        private void cbbUF_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_DropDownClosed(object sender, EventArgs e)
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
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtForn_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtForn.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtForn.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                DataGridViewRow SelectedRow = dtForn.Rows[dtForn.CurrentRow.Index];
                //
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNome.Text = SelectedRow.Cells[1].Value.ToString();
                txtFantasia.Text = SelectedRow.Cells[2].Value.ToString();
                mtxtDNascimento.Text = SelectedRow.Cells[3].Value.ToString();
                txtIERG.Text = SelectedRow.Cells[5].Value.ToString();
                cbbSexo.Text = SelectedRow.Cells[6].Value.ToString();
                mtxtTelefone.Text = SelectedRow.Cells[7].Value.ToString();
                mtxtFAX.Text = SelectedRow.Cells[8].Value.ToString();
                mtxtCelular.Text = SelectedRow.Cells[9].Value.ToString();
                txtEmail.Text = SelectedRow.Cells[10].Value.ToString();
                txtEndereco.Text = SelectedRow.Cells[11].Value.ToString();
                txtNumero.Text = SelectedRow.Cells[12].Value.ToString();
                txtComplemento.Text = SelectedRow.Cells[13].Value.ToString();
                txtBairro.Text = SelectedRow.Cells[14].Value.ToString();
                cbbUF.Text = SelectedRow.Cells[15].Value.ToString();
                cbbCidade.Text = SelectedRow.Cells[16].Value.ToString();
                mtxtCEP.Text = SelectedRow.Cells[17].Value.ToString();
                rtxtObs.Text = SelectedRow.Cells[18].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[20].Value.ToString();
                //
                if (SelectedRow.Cells[19].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
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
                if (SelectedRow.Cells[22].Value.ToString() == "0")
                {
                    rbtnPfisica.Checked = true;
                    mtxtCPF.Text = SelectedRow.Cells[4].Value.ToString();
                }
                else
                {
                    rbtnPjuridica.Checked = true;
                    mtxtCNPJ.Text = SelectedRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtForn.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtForn.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;


                dtForn.DataSource = null;
                rbtnNome.Checked = true;
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

                if (rotateFlipType != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlipType);
                }
            }

            return image;
        }

        private void cbbSexo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtDNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtIERG.Select();
            }
        }

        private void rbtnIE_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnIE_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnIE_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(436, 19);
            lblPesquisar.Text = "Digite a inscrição estadual:";
            txtpRG.Visible = true;
            txtpRG.TextAlign = HorizontalAlignment.Right;
            txtpRG.MaxLength = 20;
            txtpRG.Text = null;
            txtpRG.Select();
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
                btnSalvar.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPalavraChave.Select();
            }
        }

        private void tabcCadastro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tabcCadastro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                txtPalavraChave.Select();
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                txtEmail.Select();
            }
        }

        private void btnCadastrarCNPJ_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmCadCNPJ CNPJ = new FrmCadCNPJ(_Usuario, _Cod_PDV_Computador, 1))
                {
                    if (CNPJ.ShowDialog() == DialogResult.OK)
                    {
                        if (bllFornecedor.Sel_F_Cnpj(bllFornecedor._CNPJ_PesqCNPJ_Tabela) != null)
                        {
                            dtForn.DataSource = bllFornecedor.Sel_F_Cnpj(bllFornecedor._CNPJ_PesqCNPJ_Tabela);
                            dtForn.Select();
                        }
                        else
                        {
                            dtForn.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        bllFornecedor._CNPJ_PesqCNPJ_Tabela = null;
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
                bllFornecedor._CNPJ_PesqCNPJ_Tabela = null;
            }
            pEnabled.Enabled = true;
        }
    }
}
