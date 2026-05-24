using BLL;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadFuncionario : Form
    {
        public FrmCadFuncionario(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;

        private void FrmCadProfessor_Load(object sender, EventArgs e)
        {
            try
            {
                bllFuncionario._FrmCadFuncionario_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncionario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncionario iniciado.");
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncionario.");
                }
            }
        }

        private bool _Contem_Imagem = false;
        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;

        public void Ativar()
        {
            txtPalavraChave.Enabled = true;
            lblPalavraChave.Enabled = true;
            lblNome.Enabled = true;
            txtNome.Enabled = true;
            lblAsterisco1.Enabled = true;
            mtxtDNascimento.Enabled = true;
            lblDataNascimento.Enabled = true;
            mtxtCPF.Enabled = true;
            lblCPF.Enabled = true;
            lblRG.Enabled = true;
            txtRG.Enabled = true;
            lblEndereco.Enabled = true;
            txtEndereco.Enabled = true;
            lblAsterisco5.Enabled = true;
            lblNumero.Enabled = true;
            txtNumero.Enabled = true;
            lblAsterisco3.Enabled = true;
            txtComplemento.Enabled = true;
            lblComplemento.Enabled = true;
            lblBairro.Enabled = true;
            txtBairro.Enabled = true;
            lblAsterisco4.Enabled = true;
            lblAsterisco6.Enabled = true;
            lblUF.Enabled = true;
            cbbUF.Enabled = true;
            lblCidade.Enabled = true;
            cbbCidade.Enabled = true;
            lblAsterisco7.Enabled = true;
            lblCEP.Enabled = true;
            mtxtCEP.Enabled = true;
            lblAsterisco8.Enabled = true;
            mtxtTelefone.Enabled = true;
            lblTelefone.Enabled = true;
            mtxtCelular.Enabled = true;
            lblCelular.Enabled = true;
            mtxtFAX.Enabled = true;
            lblFAX.Enabled = true;
            txtEmail.Enabled = true;
            lblEmail.Enabled = true;
            lblSexo.Enabled = true;
            cbbSexo.Enabled = true;
            lblObs.Enabled = true;
            rtxtObs.Enabled = true;
            lblQtdeCar.Enabled = true;
        }


        private void Limpar()
        {
            txtCodigo.Text = null;
            txtRG.Text = null;
            txtPalavraChave.Text = null;
            txtNome.Text = null;
            mtxtDNascimento.Text = null;
            mtxtCPF.Text = null;
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
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            txtPalavraChave.Enabled = false;
            lblPalavraChave.Enabled = false;
            lblNome.Enabled = false;
            txtNome.Enabled = false;
            lblAsterisco1.Enabled = false;
            mtxtDNascimento.Enabled = false;
            lblDataNascimento.Enabled = false;
            mtxtCPF.Enabled = false;
            lblCPF.Enabled = false;
            lblRG.Enabled = false;
            txtRG.Enabled = false;
            lblEndereco.Enabled = false;
            txtEndereco.Enabled = false;
            lblAsterisco5.Enabled = false;
            lblNumero.Enabled = false;
            txtNumero.Enabled = false;
            lblAsterisco3.Enabled = false;
            txtComplemento.Enabled = false;
            lblComplemento.Enabled = false;
            lblBairro.Enabled = false;
            txtBairro.Enabled = false;
            lblAsterisco4.Enabled = false;
            lblAsterisco6.Enabled = false;
            lblUF.Enabled = false;
            cbbUF.Enabled = false;
            lblCidade.Enabled = false;
            cbbCidade.Enabled = false;
            lblAsterisco7.Enabled = false;
            lblCEP.Enabled = false;
            mtxtCEP.Enabled = false;
            lblAsterisco8.Enabled = false;
            mtxtTelefone.Enabled = false;
            lblTelefone.Enabled = false;
            mtxtCelular.Enabled = false;
            lblCelular.Enabled = false;
            mtxtFAX.Enabled = false;
            lblFAX.Enabled = false;
            txtEmail.Enabled = false;
            lblEmail.Enabled = false;
            lblSexo.Enabled = false;
            cbbSexo.Enabled = false;
            lblObs.Enabled = false;
            rtxtObs.Enabled = false;
            lblQtdeCar.Enabled = false;
            //
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtFuncionario.DataSource != null)
            {
                dtFuncionario.Enabled = true;
                dtFuncionario.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                mtxtCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (txtNome.Text.Trim() == "" || txtEndereco.Text.Trim() == "" || txtNumero.Text.Trim() == "" || cbbCidade.Text == "" || txtBairro.Text.Trim() == "" || mtxtCEP.Text == "" || cbbUF.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Nome ], [ Endereço ], [ Número ], [ Bairro ], [ UF ],\n[ Cidade ] e [ CEP ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            if (bllFuncionario.Sel_Funcionario_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtFuncionario.DataSource = null;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllFuncionario._Url_Imagem = null;
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
                                bllFuncionario.Alterar(txtCodigo.Text, txtNome.Text.Trim(), mtxtCPF.Text, txtRG.Text.Trim(), mtxtTelefone.Text, mtxtCEP.Text, txtEndereco.Text.Trim(), cbbCidade.Text, cbbUF.Text, txtComplemento.Text.Trim(), txtBairro.Text.Trim(), txtEmail.Text.Trim(), mtxtCelular.Text, txtNumero.Text.Trim(), mtxtFAX.Text, mtxtDNascimento.Text, rtxtObs.Text.Trim(), cbbSexo.Text, txtPalavraChave.Text.Trim());
                                //
                                if (_Contem_Imagem == true)
                                {
                                    if (bllFuncionario._Url_Imagem != null)
                                    {
                                        bllFuncionario.Alterar_Imagem_Funcionario(txtCodigo.Text, bllFuncionario._Url_Imagem);
                                    }
                                }
                                else
                                {
                                    bllFuncionario.Alterar_Imagem_Funcionario(txtCodigo.Text, bllFuncionario._Url_Imagem);
                                }
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM FUNCIONARIO", "FUNCIONARIOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                bllFuncionario.Alterar_Func_Conta_Pagar(txtCodigo.Text, txtNome.Text.Trim());
                                bllFuncionario.Alterar_Func_Usuario(txtCodigo.Text, txtNome.Text.Trim());
                                bllFuncionario.Alterar_Func_Conta_Receber(txtCodigo.Text, txtNome.Text.Trim());

                                dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_A_Alterar(txtCodigo.Text);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Funcionário alterado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Funcionário alterado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome.Text);
                                }

                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllFuncionario._Url_Imagem = null;

                                ModoPesquisa();

                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                if (_Formulario == 1)
                                {
                                    bllFuncionario._Cod_Funcionario_Cadastro = txtCodigo.Text;
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                        }
                        else
                        {
                            bllFuncionario.Salvar(txtNome.Text.Trim(), mtxtCPF.Text, txtRG.Text.Trim(), mtxtTelefone.Text, mtxtCEP.Text, txtEndereco.Text.Trim(), cbbCidade.Text, cbbUF.Text, txtComplemento.Text.Trim(), txtBairro.Text.Trim(), txtEmail.Text.Trim(), mtxtCelular.Text, txtNumero.Text.Trim(), mtxtFAX.Text, mtxtDNascimento.Text, rtxtObs.Text.Trim(), cbbSexo.Text, txtPalavraChave.Text.Trim(), bllFuncionario._Url_Imagem, _Cod_PDV_Computador);

                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_A_Salvar();

                            bllRegistroAtividades.Salvar("SALVOU UM FUNCIONARIO", "FUNCIONARIOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            pcibImagem.Image = null;
                            pcibImagem.ImageLocation = null;
                            bllFuncionario._Url_Imagem = null;

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Funcionário cadastrado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome.Text);
                            }

                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Funcionário cadastrado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome.Text);
                            }

                            ModoPesquisa();

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            if (_Formulario == 1)
                            {
                                bllFuncionario._Cod_Funcionario_Cadastro = txtCodigo.Text;
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
                        bllFuncionario._Url_Imagem = null;
                        dtFuncionario.DataSource = null;
                        rbtnNome.Checked = true;
                        ModoPesquisa();
                    }
                }
            }
        }

        private void cbbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllFuncionario.Sel_Funcionario_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtFuncionario.Select();
                }
                else
                {
                    if (_Contem_Imagem == false)
                    {
                        lblLegendaImagem.Text = "Adicionar imagem.";
                        pcibImagem.Image = null;
                    }
                    dtFuncionario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtFuncionario.Enabled = false;
                    grbBox1.Enabled = false;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    lblCodigo.Enabled = true;
                    Ativar();
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
                dtFuncionario.DataSource = null;
                rbtnNome.Checked = true;
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
                if (dtFuncionario.DataSource == null)
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
            bllFuncionario._Url_Imagem = null;
            ModoPesquisa();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadProfessor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllFuncionario.Sel_Funcionario_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtFuncionario.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Funcionário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        bllFuncionario.Excluir(txtCodigo.Text);
                        //
                        bllRegistroAtividades.Salvar("EXCLUIU UM FUNCIONARIO.", "FUNCIONARIOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Funcionário excluído. Cod: " + txtCodigo.Text + " | Nome: " + txtNome.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Funcionário excluído. Cod: " + txtCodigo.Text + " | Nome: " + txtNome.Text);
                        }
                        //
                        if (rbtnNome.Checked == true)
                        {
                            if (txtpNome.Text != "")
                            {
                                if (bllFuncionario.Sel_Funcionario_Nome(txtpNome.Text) == null)
                                {
                                    dtFuncionario.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Nome(txtpNome.Text);
                                    dtFuncionario.Select();
                                }
                            }
                            else
                            {
                                dtFuncionario.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnTodos.Checked == true)
                        {
                            if (bllFuncionario.Sel_Funcionario_Todos() == null)
                            {
                                dtFuncionario.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Todos();
                                dtFuncionario.Select();
                            }
                        }
                        else
                        {
                            dtFuncionario.DataSource = null;
                            Limpar();
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dtFuncionario.DataSource != null)
                        {
                            dtFuncionario.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                bllFuncionario._Url_Imagem = null;
                dtFuncionario.DataSource = null;
                rbtnNome.Checked = true;
                ModoPesquisa();
            }
        }

        private void dtProfessorInstrutor_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFuncionario.DataSource == null)
            {
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllFuncionario._Url_Imagem = null;
                pcibImagem.Enabled = false;
                lblLegendaImagem.Visible = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                pcibAjudaFoto.Enabled = false;
                dtFuncionario.Enabled = false;
                _Contem_Imagem = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                pcibImagem.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                dtFuncionario.Enabled = true;
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

        private void rbtnPalavra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavra_MouseLeave(object sender, EventArgs e)
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

        private void dtProfessorInstrutor_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtFuncionario.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtProfessorInstrutor_MouseLeave(object sender, EventArgs e)
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
                        if (bllFuncionario.Sel_Funcionario_Nome(txtpNome.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Nome(txtpNome.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_Codigo(txtpCodigo.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Codigo(txtpCodigo.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnPalavra.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Palavra_Chave(txtpPalavraChave.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnCPF.Checked == true)
                {
                    mtxtpCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCPF.Text != "")
                    {
                        mtxtpCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFuncionario.Sel_Funcionario_CPF(mtxtpCPF.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_CPF(mtxtpCPF.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_RG(txtpRG.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_RG(txtpRG.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllFuncionario.Sel_Funcionario_Todos() == null)
                    {
                        dtFuncionario.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Todos();
                        dtFuncionario.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou funcionário.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou funcionário.");
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
                dtFuncionario.DataSource = null;
                rbtnNome.Checked = true;
                ModoPesquisa();
            }
        }

        private void rbtnPalavra_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = true;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(506, 20);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpNome.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(577, 20);
            lblPesquisar.Text = "Digite o código:";
            txtpNome.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Location = new Point(347, 20);
            lblPesquisar.Text = "Digite o nome:";
            txtpNome.Visible = true;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpNome.Visible = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(598, 20);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void rbtnRG_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(508, 20);
            lblPesquisar.Text = "Digite o rg:";
            txtpNome.Visible = false;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = true;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(540, 20);
            lblPesquisar.Text = "Digite o cpf:";
            txtpNome.Visible = false;
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
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
                            if (bllFuncionario.Sel_Func_Palavra_chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                            {
                                MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtPalavraChave.Text = null;
                                txtPalavraChave.Select();
                            }
                        }
                        else
                        {
                            if (bllFuncionario.Sel_Func_Palavra_Chave(txtPalavraChave.Text) == true)
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
            txtPalavraChave.BackColor = Color.White;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNome.Select();
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
                txtNome.Text = null;
                txtNome.Select();
            }
            txtNome.BackColor = Color.White;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
            {
                e.Handled = true;
            }
            //
            if (e.KeyChar == 13)
            {
                mtxtDNascimento.Select();
            }
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

        private void mtxtDNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCPF.Select();
            }
        }

        private void mtxtCPF_Enter(object sender, EventArgs e)
        {
            mtxtCPF.BackColor = Color.LightBlue;
        }

        private void mtxtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRG.Select();
            }
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
                                if (bllFuncionario.Sel_Func_CNPJCPF_Alt(txtCodigo.Text, mtxtCPF.Text) == true)
                                {
                                    MessageBox.Show("O CPF informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    mtxtCPF.Text = null;
                                    mtxtCPF.Select();
                                }
                            }
                            else
                            {
                                if (bllFuncionario.Sel_Func_CNPJCPF(mtxtCPF.Text) == true)
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
            txtRG.BackColor = Color.LightBlue;
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabPage2;
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
                txtComplemento.Select();
            }
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

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            txtComplemento.BackColor = Color.LightBlue;
        }

        private void txtComplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtBairro.Select();
            }
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

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.LightBlue;
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUF.Select();
            }
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

        private void mtxtCEP_Enter(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.LightBlue;
        }

        private void mtxtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtTelefone.Select();
            }
        }

        private void mtxtCEP_Leave(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.White;
        }

        private void mtxtTelefone_Enter(object sender, EventArgs e)
        {
            mtxtTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtFAX.Select();
            }
        }

        private void mtxtTelefone_Leave(object sender, EventArgs e)
        {
            mtxtTelefone.BackColor = Color.White;
        }

        private void mtxtFAX_Enter(object sender, EventArgs e)
        {
            mtxtFAX.BackColor = Color.LightBlue;
        }

        private void mtxtFAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelular.Select();
            }
        }

        private void mtxtFAX_Leave(object sender, EventArgs e)
        {
            mtxtFAX.BackColor = Color.White;
        }

        private void mtxtCelular_Enter(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.LightBlue;
        }

        private void mtxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmail.Select();
            }
        }

        private void mtxtCelular_Leave(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.LightBlue;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSexo.Select();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Contains("'") || txtEmail.Text.Contains(";") || txtEmail.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Text = null;
                txtEmail.Select();
            }
            else if (!txtEmail.Text.Contains("@") & txtEmail.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Text = null;
                txtEmail.Select();
            }
            txtEmail.BackColor = Color.White;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
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

        private void txtpRG_Enter(object sender, EventArgs e)
        {
            txtpRG.BackColor = Color.LightBlue;
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

        private void mtxtpCPF_Enter(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.LightBlue;
        }

        private void mtxtpCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpCPF_Leave(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.White;
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
            {
                e.Handled = true;
            }
            //
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtFuncionario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtFuncionario.Enabled = false;
                grbBox1.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                Ativar();
                Limpar();
                cbbUF.Text = "AC";
                pcibAjudaFoto.Enabled = true;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = true;
                lblLegendaImagem.Text = "Adicionar imagem.";
                txtPalavraChave.Select();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = true;
                cbbUF.Text = "BA";
                cbbCidade.Text = bllMinhaEmpresa.Sel_Cidade_Empresa();
                mtxtCEP.Text = bllMinhaEmpresa.Sel_CEP_Empresa();
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
                dtFuncionario.DataSource = null;
                rbtnNome.Checked = true;
                ModoPesquisa();
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 3))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllFuncionario._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllFuncionario._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllFuncionario._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllFuncionario._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllFuncionario._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllFuncionario._Url_Imagem;
                                //
                                if (bllFuncionario._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllFuncionario._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllFuncionario._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllFuncionario._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllFuncionario._Url_Imagem);
                                    bllFuncionario._Mostrar_Imagem = false;
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
                        DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtFuncionario.DataSource != null)
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
                bllFuncionario._Url_Imagem = null;
                bllFuncionario._Mostrar_Imagem = false;
                bllFuncionario._Excluir_Imagem = false;
            }
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 3))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllFuncionario._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllFuncionario._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllFuncionario._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllFuncionario._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllFuncionario._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllFuncionario._Url_Imagem;
                                //
                                if (bllFuncionario._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllFuncionario._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllFuncionario._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllFuncionario._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllFuncionario._Url_Imagem);
                                    bllFuncionario._Mostrar_Imagem = false;
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
                        DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtFuncionario.DataSource != null)
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
                bllFuncionario._Url_Imagem = null;
                bllFuncionario._Mostrar_Imagem = false;
                bllFuncionario._Excluir_Imagem = false;
            }
        }

        private void txtRG_Leave(object sender, EventArgs e)
        {
            if (txtRG.Text.Contains("'") || txtRG.Text.Contains(";") || txtRG.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRG.Text = null;
                txtRG.Select();
            }
            else
            {
                try
                {
                    if (_Inserir_Atualizar == true)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllFuncionario.Sel_Func_RG_Alt(txtCodigo.Text, txtRG.Text) == true)
                            {
                                MessageBox.Show("O RG informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtRG.Text = null;
                                txtRG.Select();
                            }
                        }
                        else
                        {
                            if (bllFuncionario.Sel_Func_RG(txtRG.Text) == true)
                            {
                                MessageBox.Show("O RG informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtRG.Text = null;
                                txtRG.Select();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtRG.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtRG.");
                    }
                    txtRG.Text = null;
                }
            }
            txtRG.BackColor = Color.White;
        }

        private void txtEndereco_Enter(object sender, EventArgs e)
        {
            txtEndereco.BackColor = Color.LightBlue;
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumero.Select();
            }
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
                txtPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtFuncionario.DataSource != null || _Inserir_Atualizar == true)
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

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtFuncionario.DataSource != null || _Inserir_Atualizar == true)
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

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome, código, rg, palavra-chave, cpf e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void cbbUF_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida.\n\n2 - Adicionar imagem: Clique em [ Adicionar imagem ] para adicionar uma imagem ao registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadProfessor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncionario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncionario foi finalizado.");
                }
                bllFuncionario._FrmCadFuncionario_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncionario.");
                }
            }
        }

        private void dtProfessorInstrutor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                dtFuncionario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtFuncionario.DefaultCellStyle.SelectionForeColor = Color.Black;

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNome.Text = SelectedRow.Cells[1].Value.ToString();
                mtxtDNascimento.Text = SelectedRow.Cells[2].Value.ToString();
                mtxtCPF.Text = SelectedRow.Cells[3].Value.ToString();
                txtRG.Text = SelectedRow.Cells[4].Value.ToString();
                cbbSexo.Text = SelectedRow.Cells[5].Value.ToString();
                mtxtTelefone.Text = SelectedRow.Cells[6].Value.ToString();
                mtxtFAX.Text = SelectedRow.Cells[7].Value.ToString();
                mtxtCelular.Text = SelectedRow.Cells[8].Value.ToString();
                txtEmail.Text = SelectedRow.Cells[9].Value.ToString();
                txtEndereco.Text = SelectedRow.Cells[10].Value.ToString();
                txtNumero.Text = SelectedRow.Cells[11].Value.ToString();
                txtComplemento.Text = SelectedRow.Cells[12].Value.ToString();
                txtBairro.Text = SelectedRow.Cells[13].Value.ToString();
                cbbUF.Text = SelectedRow.Cells[14].Value.ToString();
                cbbCidade.Text = SelectedRow.Cells[15].Value.ToString();
                mtxtCEP.Text = SelectedRow.Cells[16].Value.ToString();
                rtxtObs.Text = SelectedRow.Cells[17].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[19].Value.ToString();

                if (SelectedRow.Cells[18].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFunc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFunc.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtFuncionario.DataSource = null;
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

        private void dtProfessorInstrutor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtFuncionario.Columns[0].HeaderText = "Código";
                dtFuncionario.Columns[1].HeaderText = "Nome";
                dtFuncionario.Columns[2].HeaderText = "Data de Nascimento";
                dtFuncionario.Columns[3].HeaderText = "CPF";
                dtFuncionario.Columns[4].HeaderText = "RG";
                dtFuncionario.Columns[5].HeaderText = "Sexo";
                dtFuncionario.Columns[6].HeaderText = "Telefone";
                dtFuncionario.Columns[7].HeaderText = "FAX";
                dtFuncionario.Columns[8].HeaderText = "Celular";
                dtFuncionario.Columns[9].HeaderText = "E-mail";
                dtFuncionario.Columns[10].HeaderText = "Endereço";
                dtFuncionario.Columns[11].HeaderText = "Número";
                dtFuncionario.Columns[12].HeaderText = "Complemento";
                dtFuncionario.Columns[13].HeaderText = "Bairro";
                dtFuncionario.Columns[14].HeaderText = "UF";
                dtFuncionario.Columns[15].HeaderText = "Cidade";
                dtFuncionario.Columns[16].HeaderText = "CEP";
                dtFuncionario.Columns[17].HeaderText = "Observações";
                dtFuncionario.Columns[18].Visible = false;
                dtFuncionario.Columns[19].HeaderText = "Palavra-Chave";
                dtFuncionario.Columns[20].Visible = false;

                dtFuncionario.Columns[0].Width = 95;
                dtFuncionario.Columns[1].Width = 325;
                dtFuncionario.Columns[2].Width = 130;
                dtFuncionario.Columns[3].Width = 129;
                dtFuncionario.Columns[4].Width = 154;
                dtFuncionario.Columns[5].Width = 100;
                dtFuncionario.Columns[6].Width = 100;
                dtFuncionario.Columns[7].Width = 100;
                dtFuncionario.Columns[8].Width = 107;
                dtFuncionario.Columns[9].Width = 220;
                dtFuncionario.Columns[10].Width = 280;
                dtFuncionario.Columns[11].Width = 118;
                dtFuncionario.Columns[12].Width = 260;
                dtFuncionario.Columns[13].Width = 280;
                dtFuncionario.Columns[14].Width = 55;
                dtFuncionario.Columns[15].Width = 280;
                dtFuncionario.Columns[16].Width = 76;
                dtFuncionario.Columns[17].Width = 550;
                dtFuncionario.Columns[19].Width = 125;

                dtFuncionario.DefaultCellStyle.Font = new Font(dtFuncionario.Font, FontStyle.Bold);

                dtFuncionario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRegistros.Text = "Registros: " + dtFuncionario.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtFuncionario.");
                }
                dtFuncionario.DataSource = null;
            }
        }

        private void dtProfessorInstrutor_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
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

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/200";
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}