using BLL;
using Seven_ADM;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Seven_Sistema
{
    public partial class FrmCadDocFiscais : Form
    {
        public FrmCadDocFiscais(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private bool _Importado;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _ComboboxEmitente_Valor = null;
        private string _Caminho_NFeNFCe;
        //
        string _Emissao;
        private string _Id;
        private string _Natureza_Operacao;
        private string _Tipo;
        private string _Serie;
        private string _Numero_NF;
        private string _Data_Emissao;
        private string _Data_Saida;
        private string _Hora_Emissao;
        private string _Hora_Saida;
        private string _Chave;
        private string _Total_Produtos;
        private string _Frete;
        private string _Desconto;
        private string _Despesa;
        private string _IPÌ;
        private string _Seguro;
        private string _Valor_Total_NF;
        private string _Observacao;
        //
        private string _Nome;
        private string _CPFCNPJ;
        private string _Endereco;
        private string _Numero;
        private string _Complemento;
        private string _Bairro;
        private string _Cod_Municipio;
        private string _Cidade;
        private string _Uf;
        private string _Cep;
        private string _Fone;
        private string _Ie;
        //
        private int _Cod_Item;
        private string _Cod_Produto;
        private string _Codigo_Barra;
        private string _Descricao;
        private string _NCM;
        private string _CEST;
        private string _CFOP;
        private string _UM;
        private string _Preco;
        private string _CSOSN;
        private string _Desconto_Item;
        private string _Orig_CST;
        private string _CST;
        private string _Aliquota;
        private string _Valor_ICMS;
        private string _Aliquota_ST;
        private string _MVA;
        private string _Valor_ICMSST;
        private string _Quantidade;
        private string _Acrescimo_Item;
        private string _Base_Calculo_ICMS;
        private string _Base_Calculo_ICMS_ST;
        private string _Reducao_BC_ICMS_ST;
        private string _Aliquota_IPI;
        private string _Valor_IPI;
        private string _Valor_Frete;
        //
        private string _Tipo_Frete;
        private string _Codigo_ANTT;
        private string _Placa;
        private string _Uf_Transp;
        private string _Quantidade_Transp;
        private string _Especie;
        private string _Marca;
        private string _Numeracao;
        private string _Peso_Bruto;
        private string _Peso_Liquido;
        //
        private string _CPF_CNPJ_Empresa = null;

        private void FrmCadLancamentoNF_Load(object sender, EventArgs e)
        {
            try
            {
                bllDFe._FrmCadDocFiscais_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocFiscais iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocFiscais iniciado.");
                }
                //
                rbtnDataEmissao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadDocFiscais.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadDocFiscais.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            mtxtChave.Text = null;
            cbbModelo.Items.Clear();
            cbbModelo.Items.Add("");
            cbbModelo.Items.Add("MODELO 55 (NFe)");
            cbbModelo.Items.Add("MODELO 65 (NFCe)");
            cbbModelo.Text = "";
            _Emissao = null;
            cbbTipoEmitente.Items.Clear();
            cbbTipoEmitente.Items.Add("");
            cbbTipoEmitente.Items.Add("CLIENTES");
            cbbTipoEmitente.Items.Add("FORNECEDORES");
            cbbTipoEmitente.Text = "";
            cbbLocDestinatario.Text = null;
            txtNumero.Text = null;
            txtSerie.Text = null;
            mtxtDataEmissao.Text = null;
            mtxtDataSaida.Text = null;
            txtTotalProdutos.Text = null;
            txtValorDesconto.Text = null;
            txtValorFrete.Text = null;
            txtValorDespesa.Text = null;
            txtValorTotal.Text = null;
            rtxtObs.Text = null;
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            txtNaturezaOperacao.Text = null;
            btnProcurarNatOperacao.Enabled = true;
            btnSelecionarData.Enabled = true;
            btnSelecionarData2.Enabled = true;
            txtSeguro.Text = null;
            txtIPI.Text = null;
            //
            txtCodigo.ReadOnly = false;
            mtxtChave.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtSerie.ReadOnly = false;
            mtxtDataEmissao.ReadOnly = false;
            mtxtDataSaida.ReadOnly = false;
            txtTotalProdutos.ReadOnly = false;
            txtValorDesconto.ReadOnly = false;
            txtValorFrete.ReadOnly = false;
            txtValorDespesa.ReadOnly = false;
            txtValorTotal.ReadOnly = false;
            rtxtObs.ReadOnly = false;
            mtxtHorario.ReadOnly = false;
            mtxtHorario1.ReadOnly = false;
            txtNaturezaOperacao.ReadOnly = false;
            cbbTipoEmitente.Enabled = true;
            btnpProcurarDestinatario.Enabled = true;
            txtIPI.ReadOnly = false;
            txtSeguro.ReadOnly = false;
            //
            _Cod_Item = 0;
            _Cod_Produto = null;
            _Codigo_Barra = null;
            _Descricao = null;
            _NCM = null;
            _CEST = null;
            _CFOP = null;
            _UM = null;
            _Preco = null;
            _CSOSN = null;
            _Desconto_Item = null;
            _Orig_CST = null;
            _CST = null;
            _Aliquota = null;
            _Valor_ICMS = null;
            _Aliquota_ST = null;
            _MVA = null;
            _Valor_ICMSST = null;
            _Quantidade = null;
            _Acrescimo_Item = null;
            _Base_Calculo_ICMS = null;
            _Base_Calculo_ICMS_ST = null;
            _Reducao_BC_ICMS_ST = null;
            //
            _Id = null;
            _Natureza_Operacao = null;
            _Tipo = null;
            _Serie = null;
            _Numero_NF = null;
            _Data_Emissao = null;
            _Data_Saida = null;
            _Hora_Emissao = null;
            _Hora_Saida = null;
            _Chave = null;
            _Total_Produtos = null;
            _Frete = null;
            _Desconto = null;
            _Despesa = null;
            _Valor_Total_NF = null;
            _Seguro = null;
            _IPÌ = null;
            _Observacao = null;
            //
            _Cod_Item = 0;
            _Nome = null;
            _CPFCNPJ = null;
            _Endereco = null;
            _Numero = null;
            _Complemento = null;
            _Bairro = null;
            _Cod_Municipio = null;
            _Cidade = null;
            _Uf = null;
            _Cep = null;
            _Ie = null;
            _Fone = null;
            _Caminho_NFeNFCe = null;
            //
            lblRegistroImportado.Visible = false;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtDFE.DataSource != null)
            {
                dtDFE.Enabled = true;
                dtDFE.Select();
            }
        }


        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
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

        private void radioButton1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void radioButton1_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpEmitDest_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpEmitDest_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpEmitDest_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpEmitDest_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadastrarItens_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrarItens_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadastrarTransportadora_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrarTransportadora_MouseLeave(object sender, EventArgs e)
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

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImportarXML_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImportarXML_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadDocFiscais_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void rbtnDataEmissao_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = true;
            btnSelecionarData3.Visible = true;
            mtxtpData.Visible = true;
            mtxtpData1.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(414, 23);
            lblPesquisar.Text = "Digite as datas:";
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpData.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = false;
            btnSelecionarData3.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(561, 23);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnNumeroNF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNumeroNF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNumeroNF_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = false;
            btnSelecionarData3.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(520, 22);
            lblPesquisar.Text = "Digite o número da NF:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblAte.Visible = false;
            btnSelecionarData3.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(607, 23);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void FrmCadDocFiscais_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllDFe._FrmCadDocFiscais_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocFiscais foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocFiscais foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadDocFiscais.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadDocFiscais.");
                }
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por data de emissão, código, número da nf e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ]\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
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
                mtxtpData1.Select();
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    mtxtpData1.Text = null;
                }
            }
            mtxtpData1.BackColor = Color.White;
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

        private void btnSelecionarData3_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(22))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllDFe._Data_DatePicker1;
                    mtxtpData1.Text = bllDFe._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtDFE.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtDFE.Enabled = false;
                grbBox1.Enabled = false;
                grbBox2.Enabled = true;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                Limpar();
                mtxtChave.Select();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = true;
                btnCadastrarTransportadora.Enabled = false;
                btnCadastrarItens.Enabled = false;
                btnCadastrarValidade.Enabled = false;
                //
                cbbModelo.Text = "MODELO 55 (NFe)";
                cbbTipoEmitente.Text = "FORNECEDORES";
                cbbLocDestinatario.Items.Clear();
                if (bllDFe.Sel_Fornecedor_DFe() == null)
                {
                    cbbLocDestinatario.Text = null;
                }
                else
                {
                    cbbLocDestinatario.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                    {
                        string cpfcnpj;
                        if (dr["cpf_cnpj"].ToString() == "")
                        {
                            cpfcnpj = "";
                        }
                        else
                        {
                            cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                        }
                        cbbLocDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                    }
                }
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtDFE.DataSource = null;
                rbtnDataEmissao.Checked = true;
                Limpar();
                ModoPesquisa();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                if (bllDFe.Sel_Dfe_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtDFE.Select();
                }
                else
                {
                    dtDFE.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtDFE.Enabled = false;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = true;
                    btnNovo.Enabled = false;
                    btnImportarXML.Enabled = false;
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    mtxtChave.Select();
                    _Comando_Atualizar = true;
                    _Inserir_Atualizar = true;
                    btnCadastrarTransportadora.Enabled = false;
                    btnCadastrarItens.Enabled = false;
                    btnCadastrarValidade.Enabled = false;
                    _ComboboxEmitente_Valor = cbbLocDestinatario.Text;
                    //
                    if (Convert.ToByte(SelectedRow.Cells[21].Value) == 1 || SelectedRow.Cells[14].Value.ToString() == "PRÓPRIA")
                    {
                        _Importado = true;
                        btnProcurarNatOperacao.Enabled = false;
                        btnpProcurarDestinatario.Enabled = false;
                        btnSelecionarData.Enabled = false;
                        btnSelecionarData2.Enabled = false;
                        txtCodigo.ReadOnly = true;
                        mtxtChave.ReadOnly = true;
                        cbbModelo.Items.Clear();
                        if (SelectedRow.Cells[13].Value.ToString() == "55")
                        {
                            cbbModelo.Items.Add("MODELO 55 (NFe)");
                            cbbModelo.Text = "MODELO 55 (NFe)";
                        }
                        else if (SelectedRow.Cells[13].Value.ToString() == "65")
                        {
                            cbbModelo.Items.Add("MODELO 65 (NFCe)");
                            cbbModelo.Text = "MODELO 65 (NFCe)";
                        }
                        cbbTipoEmitente.Enabled = false;
                        cbbTipoEmitente.Text = SelectedRow.Cells[2].Value.ToString();
                        cbbLocDestinatario.Items.Clear();
                        cbbLocDestinatario.Items.Add(SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString());
                        cbbLocDestinatario.Text = SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString();
                        txtNumero.ReadOnly = true;
                        txtSerie.ReadOnly = true;
                        mtxtDataEmissao.ReadOnly = true;
                        mtxtDataSaida.ReadOnly = true;
                        txtTotalProdutos.ReadOnly = true;
                        txtValorDesconto.ReadOnly = true;
                        txtValorFrete.ReadOnly = true;
                        txtValorDespesa.ReadOnly = true;
                        txtValorTotal.ReadOnly = true;
                        rtxtObs.ReadOnly = true;
                        mtxtHorario.ReadOnly = true;
                        mtxtHorario1.ReadOnly = true;
                        txtNaturezaOperacao.ReadOnly = true;
                        txtSeguro.ReadOnly = true;
                        txtIPI.ReadOnly = true;
                    }
                    else
                    {
                        if (cbbTipoEmitente.SelectedIndex == 1)
                        {
                            if (cbbLocDestinatario.Text != "")
                            {
                                _ComboboxEmitente_Valor = cbbLocDestinatario.Text;
                                cbbLocDestinatario.Items.Clear();
                                if (bllDFe.Sel_Cliente_DFe() == null)
                                {
                                    cbbLocDestinatario.Text = null;
                                }
                                else
                                {
                                    cbbLocDestinatario.Items.Add("");
                                    foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                                    {
                                        string cpfcnpj;
                                        if (dr["cpf_cnpj"].ToString() == "")
                                        {
                                            cpfcnpj = "";
                                        }
                                        else
                                        {
                                            cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                        }
                                        cbbLocDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                    }
                                }

                                if (bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Clie(_ComboboxEmitente_Valor) != null)
                                {
                                    foreach (DataRow dr in bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Clie(_ComboboxEmitente_Valor).Rows)
                                    {
                                        cbbLocDestinatario.Text = dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    _ComboboxEmitente_Valor = null;
                                }
                                else
                                {
                                    _ComboboxEmitente_Valor = null;
                                    cbbLocDestinatario.Text = null;
                                }
                            }
                        }
                        else if (cbbTipoEmitente.SelectedIndex == 2)
                        {
                            if (cbbLocDestinatario.Text != "")
                            {
                                _ComboboxEmitente_Valor = cbbLocDestinatario.Text;
                                cbbLocDestinatario.Items.Clear();
                                if (bllDFe.Sel_Fornecedor_DFe() == null)
                                {
                                    cbbLocDestinatario.Text = null;
                                }
                                else
                                {
                                    cbbLocDestinatario.Items.Add("");
                                    foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                    {
                                        string cpfcnpj;
                                        if (dr["cpf_cnpj"].ToString() == "")
                                        {
                                            cpfcnpj = "";
                                        }
                                        else
                                        {
                                            cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                        }
                                        cbbLocDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                    }
                                }

                                if (bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Forn(_ComboboxEmitente_Valor) != null)
                                {
                                    foreach (DataRow dr in bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Forn(_ComboboxEmitente_Valor).Rows)
                                    {
                                        cbbLocDestinatario.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    _ComboboxEmitente_Valor = null;
                                }
                            }
                            else
                            {
                                _ComboboxEmitente_Valor = null;
                                cbbLocDestinatario.Text = null;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtDFE.DataSource = null;
                rbtnDataEmissao.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _Importado = false;
            //
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCadastrarTransportadora.Enabled = true;
                btnCadastrarItens.Enabled = true;
                btnCadastrarValidade.Enabled = true;
                btnImportarXML.Enabled = true;
                //
                Limpar();
            }
            else
            {
                if (dtDFE.DataSource == null)
                {
                    Limpar();
                    btnCadastrarTransportadora.Enabled = false;
                    btnCadastrarItens.Enabled = false;
                    btnCadastrarValidade.Enabled = false;
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnCadastrarTransportadora.Enabled = true;
                    btnCadastrarItens.Enabled = true;
                    btnCadastrarValidade.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            ModoPesquisa();
        }

        private void cbbEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitente_MouseLeave(object sender, EventArgs e)
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

        private void cbbTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_MouseLeave(object sender, EventArgs e)
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

        private void cbbDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurarDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }



        private void cbbEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbModelo.Select();
            }
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNumero.Select();
            }
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
            else
            {
                try
                {
                    if (txtNumero.Text != "")
                    {
                        if (_Inserir_Atualizar == true & _Importado == false)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie_Alt(txtCodigo.Text, txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                                {
                                    MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtNumero.Text = null;
                                    txtNumero.Select();
                                }
                            }
                            else
                            {
                                if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie(txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                                {
                                    MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtNumero.Text = null;
                                    txtNumero.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNumero.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNumero.");
                    }
                    txtNumero.Text = null;
                }
            }
            txtNumero.BackColor = Color.White;
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
                txtSerie.Select();
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                mtxtDataEmissao.Select();
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (txtSerie.Text.Contains("'") || txtSerie.Text.Contains(";") || txtSerie.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtSerie.Text = null;
                txtSerie.Select();
            }
            else
            {
                try
                {
                    if (txtSerie.Text != "")
                    {
                        if (_Inserir_Atualizar == true & _Importado == false)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie_Alt(txtCodigo.Text, txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                                {
                                    MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtSerie.Text = null;
                                    txtSerie.Select();
                                }
                            }
                            else
                            {
                                if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie(txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                                {
                                    MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtSerie.Text = null;
                                    txtSerie.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNumero.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNumero.");
                    }
                    txtNumero.Text = null;
                }
            }
            txtSerie.BackColor = Color.White;
        }

        private void txtSerie_Enter(object sender, EventArgs e)
        {
            txtSerie.BackColor = Color.LightBlue;
        }

        private void mtxtDataEmissao_DoubleClick(object sender, EventArgs e)
        {
            if (mtxtDataEmissao.ReadOnly == false)
            {
                mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataEmissao.Text == "")
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (mtxtDataEmissao.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataEmissao.Text == "")
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                }
            }
        }

        private void mtxtDataEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void mtxtDataEmissao_Enter(object sender, EventArgs e)
        {
            mtxtDataEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtDataEmissao_Leave(object sender, EventArgs e)
        {
            mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataEmissao.Text != "")
            {
                try
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataEmissao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataEmissao.");
                    }
                    mtxtDataEmissao.Text = null;
                }
            }
            mtxtDataEmissao.BackColor = Color.White;
        }


        private void mtxtDataSaida_Leave(object sender, EventArgs e)
        {
            mtxtDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataSaida.Text != "")
            {
                try
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataSaida.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataSaida.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataSaida.");
                    }
                    mtxtDataSaida.Text = null;
                }
            }
            mtxtDataSaida.BackColor = Color.White;
        }

        private void mtxtDataSaida_KeyUp(object sender, KeyEventArgs e)
        {
            if (mtxtDataSaida.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataSaida.Text == "")
                    {
                        mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtDataSaida.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                }
            }
        }

        private void mtxtDataSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void mtxtDataSaida_Enter(object sender, EventArgs e)
        {
            mtxtDataSaida.BackColor = Color.LightBlue;
        }

        private void cbbDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorFrete.Select();
            }
        }

        private void txtTotalProdutos_Enter(object sender, EventArgs e)
        {
            txtTotalProdutos.BackColor = Color.LightBlue;
        }

        private void txtTotalProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTotalProdutos.Text.Contains(",") && e.KeyChar == (char)44)
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

        private void txtTotalProdutos_Leave(object sender, EventArgs e)
        {
            if (txtTotalProdutos.Text != "")
            {
                if (txtTotalProdutos.Text.Contains("'") || txtTotalProdutos.Text.Contains(";") || txtTotalProdutos.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtTotalProdutos.Text = null;
                    txtTotalProdutos.Select();
                }
                else
                {
                    try
                    {
                        txtTotalProdutos.Text = Convert.ToDecimal(txtTotalProdutos.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtTotalProdutos.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtTotalProdutos.");
                        }
                        txtTotalProdutos.Text = null;
                    }
                }
            }
            txtTotalProdutos.BackColor = Color.White;
        }

        private void txtValorDesconto_Leave(object sender, EventArgs e)
        {
            if (txtValorDesconto.Text != "")
            {
                if (txtValorDesconto.Text.Contains("'") || txtValorDesconto.Text.Contains(";") || txtValorDesconto.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorDesconto.Text = null;
                    txtValorDesconto.Select();
                }
                else
                {
                    try
                    {
                        txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDesconto.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDesconto.");
                        }
                        txtValorDesconto.Text = null;
                    }
                }
            }
            txtValorDesconto.BackColor = Color.White;
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            txtValorDesconto.BackColor = Color.LightBlue;
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
                txtValorDespesa.Select();
            }
        }

        private void txtValorFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorFrete.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSeguro.Select();
            }
        }

        private void txtValorFrete_Leave(object sender, EventArgs e)
        {
            if (txtValorFrete.Text != "")
            {
                if (txtValorFrete.Text.Contains("'") || txtValorFrete.Text.Contains(";") || txtValorFrete.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorFrete.Text = null;
                    txtValorFrete.Select();
                }
                else
                {
                    try
                    {
                        txtValorFrete.Text = Convert.ToDecimal(txtValorFrete.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorFrete.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorFrete.");
                        }
                        txtValorFrete.Text = null;
                    }
                }
            }
            txtValorFrete.BackColor = Color.White;
        }

        private void txtValorFrete_Enter(object sender, EventArgs e)
        {
            txtValorFrete.BackColor = Color.LightBlue;
        }

        private void txtValorDespesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorDespesa.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtIPI.Select();
            }
        }

        private void txtValorDespesa_Enter(object sender, EventArgs e)
        {
            txtValorDespesa.BackColor = Color.LightBlue;
        }

        private void txtValorDespesa_Leave(object sender, EventArgs e)
        {
            if (txtValorDespesa.Text != "")
            {
                if (txtValorDespesa.Text.Contains("'") || txtValorDespesa.Text.Contains(";") || txtValorDespesa.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorDespesa.Text = null;
                    txtValorDespesa.Select();
                }
                else
                {
                    try
                    {
                        txtValorDespesa.Text = Convert.ToDecimal(txtValorDespesa.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDespesa.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDespesa.");
                        }
                        txtValorDespesa.Text = null;
                    }
                }
            }
            txtValorDespesa.BackColor = Color.White;
        }

        private void txtValorTotal_Leave(object sender, EventArgs e)
        {
            if (txtValorTotal.Text != "")
            {
                if (txtValorTotal.Text.Contains("'") || txtValorTotal.Text.Contains(";") || txtValorTotal.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorTotal.Text = null;
                    txtValorTotal.Select();
                }
                else
                {
                    try
                    {
                        txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorTotal.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorTotal.");
                        }
                        txtValorTotal.Text = null;
                    }
                }
            }
            txtValorTotal.BackColor = Color.White;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'"))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                rtxtObs.Text = null;
                rtxtObs.Select();
            }
            rtxtObs.BackColor = Color.White;
        }

        private void txtValorTotal_Enter(object sender, EventArgs e)
        {
            txtValorTotal.BackColor = Color.LightBlue;
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorTotal.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();
            }
        }

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/6000";
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(3))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataEmissao.Text = bllDFe._Data_DatePicker1;

                }
            }
            pEnabled.Enabled = true;
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
        {
            if (mtxtHorario.ReadOnly == false)
            {
                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario.Text == "")
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario_KeyUp(object sender, KeyEventArgs e)
        {
            if (mtxtHorario.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtHorario.Text == "")
                    {
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
                    }
                    else
                    {
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                }
            }
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

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataSaida.Select();
            }
        }

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            if (mtxtHorario1.ReadOnly == false)
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario1.Text == "")
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
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

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoEmitente.Select();
            }
        }

        private void mtxtHorario1_KeyUp(object sender, KeyEventArgs e)
        {
            if (mtxtHorario1.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtHorario1.Text == "")
                    {
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
                    }
                    else
                    {
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                }
            }
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(3))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataSaida.Text = bllDFe._Data_DatePicker1;
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtDFE_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtDFE.Columns[0].HeaderText = "Código";
            dtDFE.Columns[1].HeaderText = "Número da NF";
            dtDFE.Columns[2].HeaderText = "Tipo de Emitente";
            dtDFE.Columns[3].HeaderText = "Código do Emitente";
            dtDFE.Columns[4].HeaderText = "Nome do Emitente";
            dtDFE.Columns[5].HeaderText = "CPF/CNPJ do Emitente";
            dtDFE.Columns[6].HeaderText = "Total dos Produtos (R$)";
            dtDFE.Columns[7].HeaderText = "Valor Total da NF (R$)";
            dtDFE.Columns[8].HeaderText = "Série";
            dtDFE.Columns[9].HeaderText = "Data de Emissão";
            dtDFE.Columns[10].HeaderText = "Hora da Emissão";
            dtDFE.Columns[11].HeaderText = "Data de Sáida";
            dtDFE.Columns[12].HeaderText = "Hora de Saída";
            dtDFE.Columns[13].HeaderText = "Modelo";
            dtDFE.Columns[14].HeaderText = "Emissão";
            dtDFE.Columns[15].HeaderText = "Descontos (R$)";
            dtDFE.Columns[16].HeaderText = "Frete (R$)";
            dtDFE.Columns[17].HeaderText = "Despesas (R$)";
            dtDFE.Columns[18].HeaderText = "Chave";
            dtDFE.Columns[19].HeaderText = "Observacao";
            dtDFE.Columns[20].HeaderText = "Natureza da Operação/CFOP Predominante";
            dtDFE.Columns[21].Visible = false;
            dtDFE.Columns[22].Visible = false;
            dtDFE.Columns[23].HeaderText = "Seguro";
            dtDFE.Columns[24].HeaderText = "IPI";
            dtDFE.Columns[25].HeaderText = "Finalidade";
            dtDFE.Columns[26].HeaderText = "ICMS";
            dtDFE.Columns[27].HeaderText = "ICMS ST";
            dtDFE.Columns[28].HeaderText = "Base de Cálculo ICMS";
            dtDFE.Columns[29].HeaderText = "Base de Cálculo ICMS ST";
            dtDFE.Columns[30].HeaderText = "Total Aprox. dos Trib.";
            //
            dtDFE.Columns[0].Width = 85;
            dtDFE.Columns[1].Width = 105;
            dtDFE.Columns[2].Width = 150;
            dtDFE.Columns[3].Width = 150;
            dtDFE.Columns[4].Width = 275;
            dtDFE.Columns[5].Width = 205;
            dtDFE.Columns[6].Width = 150;
            dtDFE.Columns[7].Width = 150;
            dtDFE.Columns[8].Width = 150;
            dtDFE.Columns[9].Width = 85;
            dtDFE.Columns[9].Width = 150;
            dtDFE.Columns[10].Width = 150;
            dtDFE.Columns[11].Width = 150;
            dtDFE.Columns[12].Width = 150;
            dtDFE.Columns[13].Width = 100;
            dtDFE.Columns[14].Width = 100;
            dtDFE.Columns[15].Width = 150;
            dtDFE.Columns[16].Width = 150;
            dtDFE.Columns[17].Width = 150;
            dtDFE.Columns[18].Width = 425;
            dtDFE.Columns[19].Width = 500;
            dtDFE.Columns[20].Width = 350;
            dtDFE.Columns[23].Width = 150;
            dtDFE.Columns[24].Width = 150;
            dtDFE.Columns[25].Width = 200;
            dtDFE.Columns[26].Width = 150;
            dtDFE.Columns[27].Width = 150;
            dtDFE.Columns[28].Width = 150;
            dtDFE.Columns[29].Width = 175;
            dtDFE.Columns[30].Width = 150;
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
            dtDFE.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtDFE.DefaultCellStyle.Font = new Font(dtDFE.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtDFE.Rows.Count;
        }

        private void mtxtChave_Enter(object sender, EventArgs e)
        {
            mtxtChave.BackColor = Color.LightBlue;
        }

        private void mtxtChave_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtChave.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtChave.Text != "")
                {
                    mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    if (_Inserir_Atualizar == true)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllDFe.Sel_C_DFe_Chave_Alt(txtCodigo.Text, mtxtChave.Text) == true)
                            {
                                MessageBox.Show("O CPF informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                mtxtChave.Text = null;
                                mtxtChave.Select();
                            }
                        }
                        else
                        {
                            if (bllDFe.Sel_C_DFe_Chave(mtxtChave.Text) == true)
                            {
                                MessageBox.Show("A Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                mtxtChave.Text = null;
                                mtxtChave.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtChave.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtChave.");
                }
                mtxtChave.Text = null;
            }
            mtxtChave.BackColor = Color.White;
        }

        private void btnpProcurarDestinatario_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;
                if (cbbTipoEmitente.SelectedIndex == 1)
                {
                    using (FrmPesqCliente Clie = new FrmPesqCliente(9, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbLocDestinatario.Items.Clear();
                            if (bllDFe.Sel_Cliente_DFe() == null)
                            {
                                cbbLocDestinatario.Text = null;
                            }
                            else
                            {
                                cbbLocDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                                {
                                    string cpfcnpj;
                                    if (dr["cpf_cnpj"].ToString() == "")
                                    {
                                        cpfcnpj = "";
                                    }
                                    else
                                    {
                                        cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    cbbLocDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                }
                            }
                            cbbLocDestinatario.Text = bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela;
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                            cbbLocDestinatario.Select();
                        }
                    }
                }
                else if (cbbTipoEmitente.SelectedIndex == 2)
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(6, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbLocDestinatario.Items.Clear();
                            if (bllDFe.Sel_Fornecedor_DFe() == null)
                            {
                                cbbLocDestinatario.Text = null;
                            }
                            else
                            {
                                cbbLocDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                {
                                    string cpfcnpj;
                                    if (dr["cpf_cnpj"].ToString() == "")
                                    {
                                        cpfcnpj = "";
                                    }
                                    else
                                    {
                                        cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    cbbLocDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                }
                            }
                            cbbLocDestinatario.Text = bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela;
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                            cbbLocDestinatario.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbLocDestinatario.Text = null;
                bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Importado == false)
                {
                    if (cbbTipoEmitente.Text == "FORNECEDORES")
                    {
                        _ComboboxEmitente_Valor = cbbLocDestinatario.Text;
                        //
                        if (cbbLocDestinatario.Text != "")
                        {
                            cbbLocDestinatario.Items.Clear();
                            if (bllDFe.Sel_Fornecedor_DFe() == null)
                            {
                                cbbLocDestinatario.Text = null;
                            }
                            else
                            {
                                cbbLocDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                {
                                    string cpfcnpj;
                                    if (dr["cpf_cnpj"].ToString() == "")
                                    {
                                        cpfcnpj = "";
                                    }
                                    else
                                    {
                                        cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    cbbLocDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                }
                            }
                            //
                            if (bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Forn(_ComboboxEmitente_Valor) != null)
                            {
                                foreach (DataRow dr in bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Forn(_ComboboxEmitente_Valor).Rows)
                                {
                                    cbbLocDestinatario.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString();
                                    _ComboboxEmitente_Valor = null;
                                }
                            }
                            else
                            {
                                _ComboboxEmitente_Valor = null;
                                cbbLocDestinatario.Text = null;
                            }
                        }
                    }
                    else
                    {
                        _ComboboxEmitente_Valor = cbbLocDestinatario.Text;
                        //
                        if (cbbLocDestinatario.Text != "")
                        {
                            cbbLocDestinatario.Items.Clear();
                            if (bllDFe.Sel_Cliente_DFe() == null)
                            {
                                cbbLocDestinatario.Text = null;
                            }
                            else
                            {
                                cbbLocDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                                {
                                    string cpfcnpj;
                                    if (dr["cpf_cnpj"].ToString() == "")
                                    {
                                        cpfcnpj = "";
                                    }
                                    else
                                    {
                                        cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    cbbLocDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                }
                            }
                            //
                            if (bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Clie(_ComboboxEmitente_Valor) != null)
                            {
                                foreach (DataRow dr in bllDFe.Sel_ComboboxEmitente_Valor_A_Alterar_Clie(_ComboboxEmitente_Valor).Rows)
                                {
                                    cbbLocDestinatario.Text = dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString();
                                    _ComboboxEmitente_Valor = null;
                                }
                            }
                            else
                            {
                                _ComboboxEmitente_Valor = null;
                                cbbLocDestinatario.Text = null;
                            }
                        }
                    }
                }
                //
                mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                btnSalvar.Select();
                if (_Importado != true)
                {
                    DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    DialogResult = DialogResult.Yes;
                }
                //
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (cbbModelo.Text == "" || txtNumero.Text == "" || txtSerie.Text == "" || mtxtDataEmissao.Text == "" || mtxtHorario.Text == "" || cbbLocDestinatario.Text == "" || txtTotalProdutos.Text.Trim() == "" || txtValorTotal.Text.Trim() == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Modelo ], [ Número da NF ], [ Série ], [ Data de Emissão ]\n[ Horário de Emissão ], [ Emitente ], [ Total dos Produtos ]\ne [ Valor total da NF ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtChave.Select();
                    }
                    else if (txtTotalProdutos.Text.Trim() == "0,00" || txtTotalProdutos.Text.Trim() == "0")
                    {
                        MessageBox.Show("Valor informado no campo Total dos Produtos inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtChave.Select();
                    }
                    else if (txtValorTotal.Text.Trim() == "0,00" || txtValorTotal.Text.Trim() == "0")
                    {
                        MessageBox.Show("Valor informado no campo Valor Total da NF inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtChave.Select();
                    }
                    else
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (_Comando_Atualizar == true)
                        {
                            if (bllDFe.Sel_Dfe_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtDFE.DataSource = null;
                                rbtnDataEmissao.Checked = true;
                                ModoPesquisa();
                                _Inserir_Atualizar = false;
                                _Comando_Atualizar = false;
                                _Importado = false;
                            }
                            else
                            {
                                bllDFe.Alterar(txtCodigo.Text, mtxtChave.Text, _Emissao, cbbModelo.Text, txtNumero.Text.Trim(), txtSerie.Text.Trim(), mtxtDataEmissao.Text, mtxtHorario.Text, mtxtDataSaida.Text, mtxtHorario1.Text, cbbLocDestinatario.Text, rtxtObs.Text.Trim(), txtTotalProdutos.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorFrete.Text.Trim(), txtValorDespesa.Text.Trim(), txtValorTotal.Text.Trim(), txtNaturezaOperacao.Text.Trim(), cbbTipoEmitente.Text, txtSeguro.Text.Trim(), txtIPI.Text.Trim(), null, false, null, false);
                                //
                                dtDFE.DataSource = bllDFe.Sel_DFe_A_Alterar(txtCodigo.Text);
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM DFE", "DFE", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                //
                                btnImportarXML.Enabled = true;
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe alterado. Cod: " + txtCodigo.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe alterado. Cod: " + txtCodigo.Text);
                                }
                                //
                                ModoPesquisa();
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllContasPagar.Sel_Codigo_Tabela_Geradora_Conta_Pagar(txtCodigo.Text, "DFE") != null)
                                {
                                    DataRow dr = bllContasPagar.Sel_Codigo_Tabela_Geradora_Conta_Pagar(txtCodigo.Text, "DFE").Rows[0];
                                    //
                                    string codigo = dr["id_conta_pagar"].ToString();
                                    //
                                    DialogResult = MessageBox.Show("Deseja alterar também os dados da Conta a Pagar associada a este DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        using (FrmCadContasPagar Conta = new FrmCadContasPagar(1, _Usuario, _Cod_PDV_Computador, codigo))
                                        {
                                            if (Conta.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            string situacao = null;
                            if (_Importado == true)
                            {
                                LerArquivoEmitente(_Caminho_NFeNFCe);
                                //
                                if (_Emissao != "TERCEIROS")
                                {
                                    situacao = "PENDENTE";
                                }
                            }
                            //
                            bllDFe.Salvar(mtxtChave.Text, _Emissao, cbbModelo.Text, txtNumero.Text.Trim(), txtSerie.Text.Trim(), mtxtDataEmissao.Text, mtxtHorario.Text, mtxtDataSaida.Text, mtxtHorario1.Text, cbbLocDestinatario.Text, rtxtObs.Text.Trim(), txtTotalProdutos.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorFrete.Text.Trim(), txtValorDespesa.Text.Trim(), txtValorTotal.Text.Trim(), txtNaturezaOperacao.Text.Trim(), _Importado, _Cod_PDV_Computador, cbbTipoEmitente.Text, txtSeguro.Text.Trim(), txtIPI.Text.Trim(), false, null, false, null, situacao, null, null, null, false);
                            //
                            dtDFE.DataSource = bllDFe.Sel_DFe_A_Salvar();
                            //
                            if (_Importado == true)
                            {
                                LerArquivoItemsDFe(_Caminho_NFeNFCe);
                                LerArquivoTransportador(_Caminho_NFeNFCe);
                                bllXML.Salvar(txtCodigo.Text, File.ReadAllText(_Caminho_NFeNFCe, Encoding.UTF8), false);
                            }
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM DFE", "DFE", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + txtCodigo.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + txtCodigo.Text);
                            }
                            //
                            ModoPesquisa();
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            string modelo;
                            if (cbbModelo.Text == "MODELO 55 (NFe)")
                            {
                                modelo = "NFe";
                            }
                            else
                            {
                                modelo = "NFCe";
                            }
                            //
                            if (bllUsuario.Sel_Criar_Conta_Pagar_DFe_Usuario(_Usuario) == true)
                            {
                                DialogResult = MessageBox.Show("Deseja criar um registro de Conta a Pagar apartir deste documento DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    DialogResult = MessageBox.Show("Existe parcelamento no valor do DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        bllItem_Parcelamento_DFe.Excluir_Todos_Item_Parcelamento_DFe_Temp(bllConexao._Codigo_Conexao);
                                        //
                                        using (FrmQuantidade Quant = new FrmQuantidade(2, "1"))
                                        {
                                            if (Quant.ShowDialog() == DialogResult.OK)
                                            {
                                                bllItem_Parcelamento_DFe._Data_Vencimento_Multiplicada = mtxtDataEmissao.Text;
                                                //
                                                for (int i = 0; i < Convert.ToInt32(bllItem_Parcelamento_DFe._Quantidade); i++)
                                                {
                                                    bllItem_Parcelamento_DFe.Salvar((i + 1).ToString(), txtValorTotal.Text, bllConexao._Codigo_Conexao);
                                                }
                                                //
                                                bllItem_Parcelamento_DFe._Quantidade = null;
                                                bllItem_Parcelamento_DFe._Data_Vencimento_Multiplicada = null;
                                                //
                                                using (FrmCadDFeParcelamento Parc = new FrmCadDFeParcelamento(txtCodigo.Text, txtValorTotal.Text, _Usuario, _Cod_PDV_Computador))
                                                {
                                                    if (Parc.ShowDialog() == DialogResult.OK)
                                                    {
                                                        this.DialogResult = DialogResult.None;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bllContasPagar.Salvar(null, null, "1", "DFE " + cbbModelo.Text + " DE NÚMERO " + txtNumero.Text + " SÉRIE " + txtSerie.Text, null, mtxtDataEmissao.Text, mtxtDataEmissao.Text, modelo, cbbTipoEmitente.Text, cbbLocDestinatario.Text, txtValorTotal.Text, null, null, null, null, null, null, txtNumero.Text, null, "2—CONTAS A PAGAR NO GERAL", "2—GERAL", null, "DFE", txtCodigo.Text, null);
                                        //
                                        string codigo = bllContasPagar.Sel_Ultimo_Cod_Conta_Pagar();
                                        //
                                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.None;
                                        //
                                        if (bllUsuario.Sel_Criar_Lemb_Conta_Pagar_Usuario(_Usuario) == true)
                                        {
                                            DataRow dr = bllContasPagar.Sel_Conta_Codigo(codigo).Rows[0];
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
                                            DialogResult = MessageBox.Show("Deseja também criar um lembrete de Conta a Pagar apartir deste documento DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (DialogResult == DialogResult.Yes)
                                            {
                                                using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, data, null, "LEMBRETE DE CONTA A PAGAR", "LEMBRETE DE CONTA A PAGAR DE CÓDIGO " + codigo + "  NO VALOR DE " + Convert.ToDecimal(dr["valor_real"]).ToString("n2", new CultureInfo("pt-BR")) + " R$ DO " + dr["tipo_emitente"].ToString() + " " + dr["id_emitente"].ToString() + "-" + dr["nome_emitente"].ToString() + ".", null, false, _Usuario, _Cod_PDV_Computador, 2, "CONTAS A PAGAR", codigo))
                                                {
                                                    if (Lembrete.ShowDialog() == DialogResult.OK)
                                                    {
                                                        this.DialogResult = DialogResult.None;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //
                            if (_Importado == true)
                            {
                                DialogResult = MessageBox.Show("Deseja precificar agora os itens do DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    btnPrecificar_Click(sender, e);
                                }
                            }
                            //
                            _Importado = false;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    mtxtChave.Select();
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                _Importado = false;
                dtDFE.DataSource = null;
                rbtnDataEmissao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDataEmissao.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllDFe.Sel_Dfe_Data_Emissao(mtxtpData.Text, mtxtpData1.Text, "TERCEIROS") == null)
                        {
                            dtDFE.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtDFE.DataSource = bllDFe.Sel_Dfe_Data_Emissao(mtxtpData.Text, mtxtpData1.Text, "TERCEIROS");
                            dtDFE.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllDFe.Sel_Nfe_Cod(txtpCodigo.Text, "TERCEIROS") == null)
                        {
                            dtDFE.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtDFE.DataSource = bllDFe.Sel_Nfe_Cod(txtpCodigo.Text, "TERCEIROS");
                            dtDFE.Select();
                        }
                    }
                }
                else if (rbtnNumeroNF.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllDFe.Sel_Nfe_Numero(txtpCodigo.Text, "TERCEIROS") == null)
                        {
                            dtDFE.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtDFE.DataSource = bllDFe.Sel_Nfe_Numero(txtpCodigo.Text, "TERCEIROS");
                            dtDFE.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllDFe.Sel_Nfe_Todos("TERCEIROS") == null)
                    {
                        dtDFE.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtDFE.DataSource = bllDFe.Sel_Nfe_Todos("TERCEIROS");
                        dtDFE.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou dfe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou dfe.");
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
                mtxtDataEmissao.Select();
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void dtDFE_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtDFE.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtDFE.Enabled = false;
                btnCadastrarItens.Enabled = false;
                btnCadastrarTransportadora.Enabled = false;
                btnCadastrarValidade.Enabled = false;
                btnPrecificar.Enabled = false;
                btnAssociarItens.Enabled = false;
            }
            else
            {
                dtDFE.Enabled = true;
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnCadastrarItens.Enabled = true;
                btnCadastrarTransportadora.Enabled = true;
                btnCadastrarValidade.Enabled = true;
                btnPrecificar.Enabled = true;
                btnAssociarItens.Enabled = true;
            }
        }

        private void dtDFE_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtDFE.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtDFE.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                if (SelectedRow.Cells[1].Value.ToString() != "0")
                {
                    txtNumero.Text = SelectedRow.Cells[1].Value.ToString();
                }
                else
                {
                    txtNumero.Text = null;
                }
                cbbTipoEmitente.Text = SelectedRow.Cells[2].Value.ToString();
                cbbLocDestinatario.Items.Clear();
                cbbLocDestinatario.Items.Add(SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString());
                cbbLocDestinatario.Text = SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString();
                dtDFE.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[6].DefaultCellStyle.Format = "n2";
                txtTotalProdutos.Text = Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtDFE.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[7].DefaultCellStyle.Format = "n2";
                txtValorTotal.Text = Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR"));
                if (SelectedRow.Cells[8].Value.ToString() != "0")
                {
                    txtSerie.Text = SelectedRow.Cells[8].Value.ToString();
                }
                else
                {
                    txtSerie.Text = null;
                }
                mtxtDataEmissao.Text = SelectedRow.Cells[9].Value.ToString();
                mtxtHorario.Text = SelectedRow.Cells[10].Value.ToString();
                mtxtDataSaida.Text = SelectedRow.Cells[11].Value.ToString();
                mtxtHorario1.Text = SelectedRow.Cells[12].Value.ToString();
                //
                if (SelectedRow.Cells[13].Value.ToString() == "55")
                {
                    cbbModelo.Text = "MODELO 55 (NFe)";
                }
                else if (SelectedRow.Cells[13].Value.ToString() == "65")
                {
                    cbbModelo.Text = "MODELO 65 (NFCe)";
                }
                dtDFE.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[15].DefaultCellStyle.Format = "n2";
                txtValorDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtDFE.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[16].DefaultCellStyle.Format = "n2";
                txtValorFrete.Text = Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtDFE.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[17].DefaultCellStyle.Format = "n2";
                txtValorDespesa.Text = Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR"));
                mtxtChave.Text = SelectedRow.Cells[18].Value.ToString();
                rtxtObs.Text = SelectedRow.Cells[19].Value.ToString();
                txtNaturezaOperacao.Text = SelectedRow.Cells[20].Value.ToString();
                if (Convert.ToByte(SelectedRow.Cells[21].Value) == 1)
                {
                    lblRegistroImportado.Visible = true;
                }
                else
                {
                    lblRegistroImportado.Visible = false;
                }
                dtDFE.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[23].DefaultCellStyle.Format = "n2";
                txtSeguro.Text = Convert.ToDecimal(SelectedRow.Cells[23].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtDFE.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[24].DefaultCellStyle.Format = "n2";
                txtIPI.Text = Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR"));
                //
                if (SelectedRow.Cells[13].Value.ToString() == "PRÓPRIA")
                {
                    btnAlterar.Enabled = false;
                    btnCadastrarValidade.Enabled = false;
                }
                else
                {
                    btnCadastrarValidade.Enabled = true;
                    btnAlterar.Enabled = true;
                }
                dtDFE.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[26].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[27].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[28].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[29].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[29].DefaultCellStyle.Format = "n2";
                dtDFE.Columns[30].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtDFE.Columns[30].DefaultCellStyle.Format = "n2";
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
                rbtnDataEmissao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void mtxtDataSaida_DoubleClick(object sender, EventArgs e)
        {
            if (mtxtDataSaida.ReadOnly == false)
            {
                mtxtDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataSaida.Text == "")
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataSaida.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                if (bllDFe.Sel_Dfe_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDFE.Select();
                }
                else if (SelectedRow.Cells[14].Value.ToString() == "PRÓPRIA")
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo foi criado/emitido por esta empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDFE.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        string codigo = null;
                        if (bllContasPagar.Sel_Codigo_Tabela_Geradora_Conta_Pagar(txtCodigo.Text, "DFE") != null)
                        {
                            int a = bllContasPagar.Sel_Codigo_Tabela_Geradora_Conta_Pagar(txtCodigo.Text, "DFE").Rows.Count;

                            for (int i = 0; i < bllContasPagar.Sel_Codigo_Tabela_Geradora_Conta_Pagar(txtCodigo.Text, "DFE").Rows.Count; i++)
                            {
                                DataRow dr = bllContasPagar.Sel_Codigo_Tabela_Geradora_Conta_Pagar(txtCodigo.Text, "DFE").Rows[i];
                                //
                                codigo = codigo + dr["id_conta_pagar"].ToString() + "—";
                            }
                            //
                            string[] itens = codigo.Split('—');
                            //
                            for (int i = 0; i < itens.Length; i++)
                            {
                                if (itens[i] != "")
                                {
                                    DataRow dr = bllContasPagar.Sel_Conta_Codigo(itens[i]).Rows[0];
                                    //
                                    if (dr["situacao"].ToString() == "EFETUADO")
                                    {
                                        MessageBox.Show("O DFe está associado a uma Conta a Pagar [ Efetuada ], não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        bllContasPagar.Excluir(itens[i], _Cod_PDV_Computador);
                                        //
                                        bllRegistroAtividades.Salvar("EXCLUIU UMA CONTA A PAGAR", "CONTAS A PAGAR", itens[i], _Usuario, _Cod_PDV_Computador);
                                        //
                                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                        {
                                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar excluída. Cod: " + itens[i] + " | Descrição: " + dr["descricao"].ToString());
                                        }
                                        //
                                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                        {
                                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar excluída. Cod: " + itens[i] + " | Descrição: " + dr["descricao"].ToString());
                                        }
                                        //
                                        if (bllLembrete.Sel_Codigo_Tabela_Geradora(itens[i], "CONTAS A PAGAR") != null)
                                        {
                                            string cod_lembrete = bllLembrete.Sel_Codigo_Tabela_Geradora(itens[i], "CONTAS A PAGAR");

                                            dr = bllLembrete.Sel_Lembrete_Codigo(cod_lembrete).Rows[0];

                                            if (dr["situacao"].ToString() == "FINALIZADO")
                                            {
                                                MessageBox.Show("O DFe está associado a uma Lembrete [ Finalizado ], não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                this.DialogResult = DialogResult.None;
                                            }
                                            else
                                            {
                                                bllLembrete.Excluir_Usuario_Lembrete(cod_lembrete);
                                                //
                                                bllLembrete.Excluir(cod_lembrete);
                                                //
                                                bllRegistroAtividades.Salvar("EXCLUIU UM LEMBRETE", "LEMBRETE", cod_lembrete, _Usuario, _Cod_PDV_Computador);
                                                //
                                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                                {
                                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete excluído. Cod: " + cod_lembrete + " | Descrição: " + dr["descricao"].ToString());
                                                }
                                                //
                                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                                {
                                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete excluído. Cod: " + cod_lembrete + " | Descrição: " + dr["descricao"].ToString());
                                                }
                                                //
                                                if (bllLetreiro.Sel_Quantidade_Lembrete() == null)
                                                {
                                                    bllLetreiro.Excluir_Letreiro("LEMBRETE");
                                                }
                                                else if (Convert.ToInt32(bllLetreiro.Sel_Quantidade_Lembrete()) == 0)
                                                {
                                                    bllLetreiro.Excluir_Letreiro("LEMBRETE");
                                                }
                                                else if (Convert.ToInt32(bllLetreiro.Sel_Quantidade_Lembrete()) >= 1)
                                                {
                                                    bllLetreiro.Alterar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Lembrete() + " lembrete(es) em aberto que ainda não foi(ram) finalizado(os).", "LEMBRETE");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                        bllDFe.Excluir_Transportador(txtCodigo.Text);
                        //
                        if (bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()) != null)
                        {
                            for (int i = 0; i < bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                            {
                                DataRow dr = bllDFe.Sel_Items_DFe(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                                //
                                bllDFe.Atualizar_Saldo_Produto_Exclusao_Dfe(dr["id_produto"].ToString(), dr["quantidade"].ToString());
                            }
                        }
                        //
                        bllDFe.Excluir_Items_DFe(txtCodigo.Text);
                        //
                        bllDFe.Excluir_Referencia_DFe(txtCodigo.Text);
                        //
                        bllDFe.Excluir_Validade_DFe(txtCodigo.Text);
                        //
                        bllDFe.Excluir_Pagamento_DFe(txtCodigo.Text);
                        //
                        bllDFe.Excluir_Precificacao_DFe(txtCodigo.Text);
                        //
                        bllDFe.Excluir_Associar_Item_DFe(txtCodigo.Text);
                        //
                        bllDFe.Excluir(txtCodigo.Text, _Cod_PDV_Computador);
                        //
                        bllXML.Excluir(txtCodigo.Text);
                        //
                        bllRegistroAtividades.Salvar("EXCLUIU UM DFE", "DFE", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe excluído. Cod: " + txtCodigo.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe excluído. Cod: " + txtCodigo.Text);
                        }
                        //
                        if (rbtnDataEmissao.Checked == true)
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            //
                            if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                if (bllDFe.Sel_Dfe_Data_Emissao(mtxtpData.Text, mtxtpData1.Text, "TERCEIROS") == null)
                                {
                                    dtDFE.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtDFE.DataSource = bllDFe.Sel_Dfe_Data_Emissao(mtxtpData.Text, mtxtpData1.Text, "TERCEIROS");
                                    dtDFE.Select();
                                }
                            }
                            else
                            {
                                dtDFE.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnNumeroNF.Checked == true)
                        {
                            if (txtpCodigo.Text != "")
                            {
                                if (bllDFe.Sel_Nfe_Numero(txtpCodigo.Text, "TERCEIROS") == null)
                                {
                                    dtDFE.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtDFE.DataSource = bllDFe.Sel_Nfe_Numero(txtpCodigo.Text, "TERCEIROS");
                                    dtDFE.Select();
                                }
                            }
                            else
                            {
                                dtDFE.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnTodos.Checked == true)
                        {
                            if (bllDFe.Sel_Nfe_Todos("TERCEIROS") == null)
                            {
                                dtDFE.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtDFE.DataSource = bllDFe.Sel_Nfe_Todos("TERCEIROS");
                                dtDFE.Select();
                            }
                        }
                        else
                        {
                            dtDFE.DataSource = null;
                            Limpar();
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
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
                dtDFE.DataSource = null;
                rbtnDataEmissao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void dtDFE_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
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

        private void btnCadastrarItens_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                bool proprio;
                if (SelectedRow.Cells[14].Value.ToString() == "PRÓPRIA")
                {
                    proprio = true;
                }
                else
                {
                    proprio = false;
                }
                //
                using (FrmCadNFeNFCe NFe = new FrmCadNFeNFCe(_Usuario, _Cod_PDV_Computador, 0, txtTotalProdutos.Text, txtValorTotal.Text, SelectedRow.Cells[0].Value.ToString(), Convert.ToByte(SelectedRow.Cells[21].Value), proprio))
                {
                    if (NFe.ShowDialog() == DialogResult.OK)
                    {
                        dtDFE.Select();
                    }
                }
                //
                dtDFE_DataSourceChanged(sender, e);
                ModoPesquisa();
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarItens.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarNatOperacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarNatOperacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbNatOperacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbNatOperacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbNatOperacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbNatOperacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarNatOperacao_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCFOP Cfop = new FrmPesqCFOP(0, null, _Usuario, _Cod_PDV_Computador))
            {
                if (Cfop.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtNaturezaOperacao.Text = bllDFe._FornDFe_Cfop_PesqCfop_Tabela;
                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                        txtNaturezaOperacao.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
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
                        txtNaturezaOperacao.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtDFE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 8 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 20 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 5 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 9 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 11 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void btnImportarXML_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.Title = "Selecione um XML";
                    file.Filter = "Arquivo no formato:(*.xml)|*.xml|Todos os arquivos:(*.*)|*.*";
                    file.InitialDirectory = @"C:\";
                    //
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        VerArquivo_CPF_CNPJ(file.FileName);
                        //
                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != _CPF_CNPJ_Empresa)
                        {
                            MessageBox.Show("O CPF/CNPJ da empresa não existe neste XML.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            return;
                        }
                        //
                        LerArquivoCabecalho(file.FileName);
                        //
                        mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllDFe.Sel_C_DFe_Chave(mtxtChave.Text) == true)
                        {
                            MessageBox.Show("A Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                            //
                            cbbLocDestinatario.Items.Clear();
                            if (bllDFe.Sel_Fornecedor_DFe() == null)
                            {
                                cbbLocDestinatario.Text = null;
                            }
                            else
                            {
                                cbbLocDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                {
                                    cbbLocDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            txtCodigo.ReadOnly = true;
                            mtxtChave.ReadOnly = true;
                            txtNumero.ReadOnly = true;
                            txtSerie.ReadOnly = true;
                            mtxtDataEmissao.ReadOnly = true;
                            mtxtDataSaida.ReadOnly = true;
                            txtTotalProdutos.ReadOnly = true;
                            txtValorDesconto.ReadOnly = true;
                            txtValorFrete.ReadOnly = true;
                            txtValorDespesa.ReadOnly = true;
                            txtValorTotal.ReadOnly = true;
                            rtxtObs.ReadOnly = true;
                            mtxtHorario.ReadOnly = true;
                            mtxtHorario1.ReadOnly = true;
                            txtNaturezaOperacao.ReadOnly = true;
                            btnpProcurarDestinatario.Enabled = false;
                            btnProcurarNatOperacao.Enabled = false;
                            cbbTipoEmitente.Enabled = false;
                            btnSelecionarData.Enabled = false;
                            btnSelecionarData2.Enabled = false;
                            txtIPI.ReadOnly = true;
                            txtSeguro.ReadOnly = true;
                            _Caminho_NFeNFCe = file.FileName;
                            _Importado = true;
                            //
                            btnSalvar_Click(sender, e);
                        }

                    }
                    else
                    {
                        btnImportarXML.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImportarXML.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImportarXML.");
                }
                txtNaturezaOperacao.Text = null;
            }
        }

        private void LerArquivoEmitente(string caminho)
        {
            bool emitente = false;
            //
            using (XmlReader arqXML = XmlReader.Create(caminho))
            {
                while (arqXML.Read())
                {
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "emit")
                    {
                        emitente = true;
                    }
                    else if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "dest")
                    {
                        break;
                    }
                    else if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "transp")
                    {
                        break;
                    }
                    //
                    if (emitente == true)
                    {
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CNPJ")
                        {
                            _CPFCNPJ = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xNome")
                        {
                            _Nome = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xLgr")
                        {
                            _Endereco = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "nro")
                        {
                            _Numero = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xCpl")
                        {
                            _Complemento = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xBairro")
                        {
                            _Bairro = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "cMun")
                        {
                            _Cod_Municipio = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "UF")
                        {
                            _Uf = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CEP")
                        {
                            _Cep = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "fone")
                        {
                            _Fone = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "IE")
                        {
                            _Ie = arqXML.ReadElementContentAsString();
                        }
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.EndElement & arqXML.Name == "emit") // for closing tag
                    {
                        if (_CPFCNPJ.Length == 14)
                        {
                            string cpfcnpj_mascarado = _CPFCNPJ.Substring(0, 2) + "." + _CPFCNPJ.Substring(2, 3) + "." + _CPFCNPJ.Substring(5, 3) + "/" + _CPFCNPJ.Substring(8, 4) + "-" + _CPFCNPJ.Substring(12, 2);
                            //
                            if (_Emissao == "TERCEIROS")
                            {
                                if (bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado) == null)
                                {
                                    if (_Uf == "AC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AL")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AM")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "BA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "CE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "DF")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "ES")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "GO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MG")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MT")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PB")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PI")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RJ")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RN")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "TO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    bllFornecedor.Salvar(_Nome, cpfcnpj_mascarado, _Ie, _Fone, _Cep, _Endereco, _Cidade, _Uf, _Complemento, _Bairro, "", "", _Numero, "", "", "", "", "Pessoa Jurídica", "", "", null, _Cod_PDV_Computador, _Cod_Municipio);
                                    //
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Clear();
                                    if (bllDFe.Sel_Fornecedor_DFe() == null)
                                    {
                                        cbbLocDestinatario.Text = null;
                                    }
                                    else
                                    {
                                        cbbLocDestinatario.Items.Add("");
                                        foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                        {
                                            cbbLocDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString());
                                        }
                                    }
                                    //
                                    cbbLocDestinatario.Text = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString() + "—" + drForn["cpf_cnpj"].ToString();
                                }
                                else
                                {
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Add(drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString() + "—" + drForn["cpf_cnpj"].ToString());
                                    cbbLocDestinatario.Text = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString() + "—" + drForn["cpf_cnpj"].ToString();
                                }
                            }
                            else
                            {
                                if (bllClieCons.Sel_Clie_CPFCNPJ(cpfcnpj_mascarado) == null)
                                {
                                    if (_Uf == "AC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AL")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AM")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "BA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "CE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "DF")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "ES")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "GO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MG")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MT")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PB")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PI")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RJ")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RN")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "TO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    bllClieCons.Salvar(_Nome, null, null, null, cpfcnpj_mascarado, _Fone, null, null, _Endereco, _Numero, _Complemento, _Bairro, _Cidade, _Uf, _Cep, null, null, null, null, null, null, null, null, null, null, null, "Pessoa Jurídica", null, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, _Cod_PDV_Computador, "4—CLIENTES NO GERAL", "4—GERAL", _Cod_Municipio);
                                    //
                                    DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Clear();
                                    if (bllDFe.Sel_Cliente_DFe() == null)
                                    {
                                        cbbLocDestinatario.Text = null;
                                    }
                                    else
                                    {
                                        cbbLocDestinatario.Items.Add("");
                                        foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                                        {
                                            cbbLocDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString());
                                        }
                                    }
                                    //
                                    cbbLocDestinatario.Text = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                }
                                else
                                {
                                    DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Add(drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString());
                                    cbbLocDestinatario.Text = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                }
                            }
                        }
                        else
                        {
                            string cpfcnpj_mascarado = _CPFCNPJ.Substring(0, 3) + "." + _CPFCNPJ.Substring(3, 3) + "." + _CPFCNPJ.Substring(6, 3) + "-" + _CPFCNPJ.Substring(9, 2);
                            //
                            if (_Emissao == "TERCEIROS")
                            {
                                if (bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado) == null)
                                {
                                    if (_Uf == "AC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AL")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AM")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "BA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "CE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "DF")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "ES")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "GO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MG")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MT")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PB")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PI")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RJ")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RN")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "TO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    bllFornecedor.Salvar(_Nome, cpfcnpj_mascarado, _Ie, _Fone, _Cep, _Endereco, _Cidade, _Uf, _Complemento, _Bairro, "", "", _Numero, "", "", "", "", "Pessoa Física", "", "", null, _Cod_PDV_Computador, _Cod_Municipio);
                                    //
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Clear();
                                    if (bllDFe.Sel_Fornecedor_DFe() == null)
                                    {
                                        cbbLocDestinatario.Text = null;
                                    }
                                    else
                                    {
                                        cbbLocDestinatario.Items.Add("");
                                        foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                        {
                                            cbbLocDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString());
                                        }
                                    }
                                    //
                                    cbbLocDestinatario.Text = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString() + "—" + drForn["cpf_cnpj"].ToString();
                                }
                                else
                                {
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Add(drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString() + "—" + drForn["cpf_cnpj"].ToString());
                                    cbbLocDestinatario.Text = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString() + "—" + drForn["cpf_cnpj"].ToString();
                                }
                            }
                            else
                            {
                                if (bllClieCons.Sel_Clie_CPFCNPJ(cpfcnpj_mascarado) == null)
                                {
                                    if (_Uf == "AC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AL")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "AM")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "BA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "CE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "DF")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "ES")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "GO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MG")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "MT")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PA")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PB")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PI")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "PR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RJ")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RN")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                                        {
                                            int lineNumber = 0;
                                            string line;

                                            while ((line = Sr.ReadLine()) != null)
                                            {
                                                lineNumber++;

                                                if (line.Contains(_Cod_Municipio))
                                                {
                                                    string[] items = line.Split('—');
                                                    //
                                                    _Cidade = items[0];
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RR")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "RS")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SC")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SE")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "SP")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (_Uf == "TO")
                                    {
                                        using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                                        {
                                            while (!Sr.EndOfStream)
                                            {
                                                int lineNumber = 0;
                                                string line;

                                                while ((line = Sr.ReadLine()) != null)
                                                {
                                                    lineNumber++;

                                                    if (line.Contains(_Cod_Municipio))
                                                    {
                                                        string[] items = line.Split('—');
                                                        //
                                                        _Cidade = items[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //
                                    bllClieCons.Salvar(_Nome, null, null, _Ie, cpfcnpj_mascarado, _Fone, null, null, _Endereco, _Numero, _Complemento, _Bairro, _Cidade, _Uf, _Cep, null, null, null, null, null, null, null, null, null, null, null, "Pessoa Física", null, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, _Cod_PDV_Computador, "4—CLIENTES NO GERAL", "4—GERAL", _Cod_Municipio);
                                    //
                                    DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Clear();
                                    if (bllDFe.Sel_Cliente_DFe() == null)
                                    {
                                        cbbLocDestinatario.Text = null;
                                    }
                                    else
                                    {
                                        cbbLocDestinatario.Items.Add("");
                                        foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                                        {
                                            cbbLocDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + "—" + dr["cpf_cnpj"].ToString());
                                        }
                                    }
                                    //
                                    cbbLocDestinatario.Text = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                }
                                else
                                {
                                    DataRow drClie = bllClieCons.Sel_Clie_CPFCNPJ(cpfcnpj_mascarado).Rows[0];
                                    //
                                    cbbLocDestinatario.Items.Add(drClie["id_fornecedor"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString());
                                    cbbLocDestinatario.Text = drClie["id_fornecedor"].ToString() + "—" + drClie["nome"].ToString() + "—" + drClie["cpf_cnpj"].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LerArquivoTransportador(string caminho)
        {
            bool transp = false;
            bool placa = false;
            bool uf = false;
            bool codigo_antt = false;
            bool dados_transp = false;
            using (XmlReader arqXML = XmlReader.Create(caminho))
            {
                while (arqXML.Read())
                {
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "transp")
                    {
                        transp = true;
                    }
                    //
                    if (transp == true)
                    {
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "modFrete")
                        {
                            _Tipo_Frete = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CNPJ")
                        {
                            _CPFCNPJ = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xNome")
                        {
                            _Nome = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xLgr")
                        {
                            _Endereco = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xMun")
                        {
                            _Cidade = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "UF")
                        {
                            _Uf = arqXML.ReadElementContentAsString().ToUpper();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "IE")
                        {
                            _Ie = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "placa" & placa == false)
                        {
                            _Placa = arqXML.ReadElementContentAsString();
                            placa = true;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "UF" & uf == false)
                        {
                            _Uf_Transp = arqXML.ReadElementContentAsString();
                            uf = true;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "RNTC" & codigo_antt == false)
                        {
                            _Codigo_ANTT = arqXML.ReadElementContentAsString();
                            codigo_antt = true;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "qVol")
                        {
                            _Quantidade_Transp = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "esp")
                        {
                            _Especie = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "marca")
                        {
                            _Marca = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "nVol")
                        {
                            _Numeracao = arqXML.ReadElementContentAsString();
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "pesoL")
                        {
                            _Peso_Liquido = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "pesoB")
                        {
                            _Peso_Bruto = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.EndElement & arqXML.Name == "transporta")
                    {
                        dados_transp = true;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.EndElement & arqXML.Name == "transp") // for closing tag
                    {
                        if (dados_transp)
                            _Numero = "0";
                        //
                        _Bairro = "SEM DADOS DO BAIRRO";
                        //
                        _Cep = "0";
                        //
                        string tipo_transporte = null;
                        string tipo_frete = null;
                        //
                        if (_Tipo_Frete == "0")
                        {
                            tipo_transporte = "De Terceiros";
                            tipo_frete = "Frete por conta do Emitente";

                        }
                        else if (_Tipo_Frete == "1")
                        {
                            tipo_transporte = "Veículo Próprio";
                            tipo_frete = "";
                        }
                        else if (_Tipo_Frete == "2")
                        {
                            tipo_transporte = "De Terceiros";
                            tipo_frete = "Frete por conta do Emitente";
                        }
                        else if (_Tipo_Frete == "9")
                        {
                            tipo_transporte = "Sem Transporte";
                            tipo_frete = "";
                        }
                        //
                        if (_Tipo_Frete != "9" & _Tipo_Frete == "0")
                        {
                            string fornecedor;
                            if (_CPFCNPJ.Length == 14)
                            {
                                string cpfcnpj_mascarado = _CPFCNPJ.Substring(0, 2) + "." + _CPFCNPJ.Substring(2, 3) + "." + _CPFCNPJ.Substring(5, 3) + "/" + _CPFCNPJ.Substring(8, 4) + "-" + _CPFCNPJ.Substring(12, 2);
                                //
                                if (bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado) == null)
                                {
                                    bllFornecedor.Salvar(_Nome, cpfcnpj_mascarado, _Ie, "", _Cep, _Endereco, _Cidade, _Uf, _Complemento, _Bairro, "", "", _Numero, "", "", "", "", "Pessoa Jurídica", "", "", null, _Cod_PDV_Computador, _Cod_Municipio);
                                    //
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    fornecedor = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString();
                                }
                                else
                                {
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    fornecedor = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString();
                                }
                            }
                            else
                            {
                                string cpfcnpj_mascarado = _CPFCNPJ.Substring(0, 3) + "." + _CPFCNPJ.Substring(3, 3) + "." + _CPFCNPJ.Substring(6, 3) + "-" + _CPFCNPJ.Substring(9, 2);
                                //
                                if (bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado) == null)
                                {
                                    bllFornecedor.Salvar(_Nome, cpfcnpj_mascarado, _Ie, "", _Cep, _Endereco, _Cidade, _Uf, _Complemento, _Bairro, "", "", _Numero, "", "", "", "", "Pessoa Física", "", "", null, _Cod_PDV_Computador, _Cod_Municipio);
                                    //
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    fornecedor = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString();
                                }
                                else
                                {
                                    DataRow drForn = bllFornecedor.Sel_F_Cnpj(cpfcnpj_mascarado).Rows[0];
                                    //
                                    fornecedor = drForn["id_fornecedor"].ToString() + "—" + drForn["nome"].ToString();
                                }
                            }
                            //
                            if (dados_transp == false)
                            {
                                fornecedor = null;
                                _Uf = null;
                            }
                            //
                            bllTransportador.Salvar(tipo_transporte, tipo_frete, fornecedor, "", _Codigo_ANTT, _Placa, _Uf, _Especie, _Marca, _Quantidade_Transp, _Numeracao, _Peso_Bruto, _Peso_Liquido, txtCodigo.Text, _Frete);
                        }
                    }
                }
            }
        }

        private void LerArquivoItemsDFe(string caminho)
        {
            using (XmlReader arqXML = XmlReader.Create(caminho))
            {
                bool det = false;
                string tag = "";
                bool cst_icms = false;
                bool base_calculo = false;
                //
                while (arqXML.Read())
                {
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "det")
                    {
                        det = true;
                    }
                    else if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "total")
                    {
                        break;
                    }
                    //
                    if (det == true)
                    {
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "prod")
                        {
                            tag = "prod";
                        }
                        else if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "ICMS")
                        {
                            tag = "ICMS";
                        }
                        else if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "IPI")
                        {
                            tag = "IPI";
                        }
                        //
                        if (tag == "prod")
                        {
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "cProd")
                            {
                                _Cod_Produto = arqXML.ReadElementContentAsString().ToUpper();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xProd")
                            {
                                _Descricao = arqXML.ReadElementContentAsString().ToUpper();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "NCM")
                            {
                                _NCM = arqXML.ReadElementContentAsString();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CEST")
                            {
                                _CEST = arqXML.ReadElementContentAsString();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CFOP")
                            {
                                _CFOP = arqXML.ReadElementContentAsString();
                                //
                                if (bllCFOP.Sel_CFOP_Codigo(_CFOP) == null)
                                {
                                    if (_CFOP.Substring(0, 1) == "5" || _CFOP.Substring(0, 1) == "6" || _CFOP.Substring(0, 1) == "7")
                                    {
                                        bllCFOP.Salvar(txtNaturezaOperacao.Text, _CFOP, "SAIDA");
                                    }
                                    else if (_CFOP.Substring(0, 1) == "1" || _CFOP.Substring(0, 1) == "2" || _CFOP.Substring(0, 1) == "3")
                                    {
                                        bllCFOP.Salvar(txtNaturezaOperacao.Text, _CFOP, "ENTRADA");
                                    }
                                }
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "qCom")
                            {
                                _Quantidade = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vUnCom")
                            {
                                _Preco = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "cEANTrib")
                            {
                                _Codigo_Barra = arqXML.ReadElementContentAsString();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "uTrib")
                            {
                                _UM = arqXML.ReadElementContentAsString();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vFrete")
                            {
                                _Valor_Frete = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vDesc")
                            {
                                _Desconto_Item = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                                //_Desconto_Item = arqXML.ReadElementContentAsString();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vOutro_item")
                            {
                                _Acrescimo_Item = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                                //_Acrescimo_Item = arqXML.ReadElementContentAsString();
                            }
                        }
                        //
                        if (tag == "ICMS")
                        {
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "orig")
                            {
                                _Orig_CST = arqXML.ReadElementContentAsString();
                                if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CST" & cst_icms == false)
                                {
                                    _CST = arqXML.ReadElementContentAsString();
                                    cst_icms = true;
                                }
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CSOSN")
                            {
                                _CSOSN = arqXML.ReadElementContentAsString();
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vBC" & base_calculo == false)
                            {
                                _Base_Calculo_ICMS = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                                base_calculo = true;
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "pICMS")
                            {
                                _Aliquota = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vICMS")
                            {
                                _Valor_ICMS = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "pMVAST")
                            {
                                _MVA = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "pRedBCST")
                            {
                                _Reducao_BC_ICMS_ST = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vBCST")
                            {
                                _Base_Calculo_ICMS_ST = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "pICMSST")
                            {
                                _Aliquota_ST = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vICMSST")
                            {
                                _Valor_ICMSST = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                        }
                        //
                        if (tag == "IPI")
                        {
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "pIPI")
                            {
                                _Aliquota_IPI = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            //
                            if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vIPI")
                            {
                                _Valor_IPI = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            }
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.EndElement & arqXML.Name == "det") // for closing tag
                        {
                            if (_Codigo_Barra == "SEM GTIN" || _Codigo_Barra == "" || _Codigo_Barra == null)
                            {
                                _Codigo_Barra = null;
                            }
                            //
                            if (_Aliquota == "" || _Aliquota == null)
                            {
                                _Aliquota = "0,00";
                            }
                            //
                            bool alertar_estoque;
                            if (bllConfiguracaoSistema.Sel_Alertar_Estoque() == true)
                            {
                                alertar_estoque = true;
                            }
                            else
                            {
                                alertar_estoque = false;
                            }
                            //
                            bool dest_estoque_baixo;
                            if (bllConfiguracaoSistema.Sel_Alertar_Estoque() == true)
                            {
                                dest_estoque_baixo = true;
                            }
                            else
                            {
                                dest_estoque_baixo = false;
                            }
                            //
                            if (_Base_Calculo_ICMS == "" || _Base_Calculo_ICMS == null)
                            {
                                _Base_Calculo_ICMS = "0,00";
                            }
                            //
                            if (_Desconto_Item == "" || _Desconto_Item == null)
                            {
                                _Desconto_Item = "0,00";
                            }
                            //
                            if (_Acrescimo_Item == "" || _Acrescimo_Item == null)
                            {
                                _Acrescimo_Item = "0,00";
                            }
                            //
                            if (_Valor_ICMS == "" || _Valor_ICMS == null)
                            {
                                _Valor_ICMS = "0,00";
                            }
                            //
                            if (_Valor_ICMSST == "" || _Valor_ICMSST == null)
                            {
                                _Valor_ICMSST = "0,00";
                            }
                            //
                            if (_Aliquota_ST == "" || _Aliquota_ST == null)
                            {
                                _Aliquota_ST = "0,00";
                            }
                            //
                            if (_MVA == "" || _MVA == null)
                            {
                                _MVA = "0,00";
                            }
                            //
                            if (_Valor_ICMSST == "" || _Valor_ICMSST == null)
                            {
                                _Valor_ICMSST = "0,00";
                            }
                            //
                            if (_Base_Calculo_ICMS_ST == "" || _Base_Calculo_ICMS_ST == null)
                            {
                                _Base_Calculo_ICMS_ST = "0,00";
                            }
                            //
                            if (_Reducao_BC_ICMS_ST == "" || _Reducao_BC_ICMS_ST == null)
                            {
                                _Reducao_BC_ICMS_ST = "0,00";
                            }
                            //
                            if (_CST == "" || _CST == null)
                            {
                                _Orig_CST = null;
                            }
                            //
                            if (_CEST == "" || _CEST == null)
                            {
                                _CEST = null;
                            }
                            //
                            if (_Valor_Frete == "" || _Valor_Frete == null)
                            {
                                _Valor_Frete = "0,00";
                            }
                            //
                            if (_Codigo_Barra != null)
                            {
                                if (bllProduto.Sel_Prod_Barra(_Codigo_Barra, "") == null)
                                {
                                    bllProduto.Salvar("", _Descricao.Replace("*", ""), _UM, "", "1—PRODUTOS NO GERAL", "1—GERAL", _Codigo_Barra, _Preco, _Cod_Produto, "", "", null, "", "", _Quantidade, "0,00", "0,00", alertar_estoque, dest_estoque_baixo, _NCM, _CEST, "000", "20,50", "102", true, null, "000", "00001", "0", "0", "0", "ATIVO");
                                    //
                                    DataRow dr = bllProduto.Sel_Prod_A_Salvar().Rows[0];
                                    //
                                    bllDFe.Salvar_Items(_Cod_Item.ToString(), dr["id_produto"].ToString() + "—" + dr["descricao"].ToString(), _NCM, _CEST, _Orig_CST + _CST, _Aliquota, _CSOSN, _CFOP, _Quantidade, "1,00", bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Preco, _Desconto_Item, _Acrescimo_Item, bllDFe.Calculo_Valor_Item_Desc_Acresc(bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Desconto_Item, _Acrescimo_Item, _Valor_IPI, _Valor_Frete), bllDFe.Calculo_Valor_ICMS(_Base_Calculo_ICMS, _Aliquota), _Base_Calculo_ICMS, txtCodigo.Text, _Valor_ICMSST, _Aliquota_ST, _MVA, _Base_Calculo_ICMS_ST, _Reducao_BC_ICMS_ST, _UM, "0", _Aliquota_IPI, _Valor_IPI, _Reducao_BC_ICMS_ST, "000", "00001", "0", "0", "0", _Valor_Frete);
                                }
                                else
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Barra(_Codigo_Barra, "").Rows[0];
                                    //
                                    bllDFe.Salvar_Items(_Cod_Item.ToString(), dr["id_produto"].ToString() + "—" + dr["descricao"].ToString(), _NCM, _CEST, _Orig_CST + _CST, _Aliquota, _CSOSN, _CFOP, _Quantidade, "1,00", bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Preco, _Desconto_Item, _Acrescimo_Item, bllDFe.Calculo_Valor_Item_Desc_Acresc(bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Desconto_Item, _Acrescimo_Item, _Valor_IPI, _Valor_Frete), _Valor_ICMS, _Base_Calculo_ICMS, txtCodigo.Text, _Valor_ICMSST, _Aliquota_ST, _MVA, _Base_Calculo_ICMS_ST, _Reducao_BC_ICMS_ST, _UM, "0", _Aliquota_IPI, _Valor_IPI, _Reducao_BC_ICMS_ST, "000", "00001", "0", "0", "0", _Valor_Frete);
                                    //
                                    if (Convert.ToByte(dr["alertar_estoque"]) == 1)
                                    {
                                        alertar_estoque = true;
                                    }
                                    else
                                    {
                                        alertar_estoque = false;
                                    }
                                    //                                   
                                    if (Convert.ToByte(dr["dest_est_baixo"]) == 1)
                                    {
                                        dest_estoque_baixo = true;
                                    }
                                    else
                                    {
                                        dest_estoque_baixo = false;
                                    }
                                    //
                                    /*
                                    DialogResult = MessageBox.Show("O item:\n[ " + dr["id_produto"].ToString() + "-" + dr["descricao"].ToString() + " ]\n\njá está cadastrado, deseja atualizar o [ PREÇO ]?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        bllProduto.Adicionar_Saldo_Preco_Produto(dr["id_produto"].ToString(), _Quantidade, _Preco);
                                        //bllProduto.Alterar(dr["id_produto"].ToString(), dr["palavra_chave"].ToString(), dr["descricao"].ToString(), dr["um"].ToString(), dr["id_marca"].ToString() + "—" + dr["desc_marca"].ToString(), dr["id_grupo"].ToString() + "—" + dr["desc_grupo"].ToString(), dr["id_subgrupo"].ToString() + "—" + dr["desc_subgrupo"].ToString(), dr["cod_barra"].ToString(), _Preco, dr["referencia"].ToString(), dr["id_localizacao"].ToString() + "—" + dr["desc_localizacao"].ToString(), dr["observacao"].ToString(), dr["imagem_prod"].ToString(), dr["estoque_min"].ToString(), dr["estoque_max"].ToString(), _Quantidade, dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString(), alertar_estoque, dest_estoque_baixo, _Cod_PDV_Computador, dr["ncm"].ToString(), dr["cest"].ToString(), dr["cst"].ToString(), dr["aliq_icms"].ToString(), dr["csosn"].ToString());
                                    }
                                    else
                                    {
                                    */
                                        bllProduto.Adicionar_Saldo_Produto(dr["id_produto"].ToString(), _Quantidade);
                                    //}
                                }
                            }
                            else
                            {
                                if (bllProduto.Sel_Prod_Descricao(_Descricao, "") == null)
                                {
                                    bllProduto.Salvar("", _Descricao.Replace("*", ""), _UM, "", "1—PRODUTOS NO GERAL", "1—GERAL", _Codigo_Barra, _Preco, _Cod_Produto, "", "", null, "", "", _Quantidade, "0,00", "0,00", alertar_estoque, dest_estoque_baixo, _NCM, _CEST, "000", "20,50", "102", true, null, "000", "00001", "0", "0", "0", "ATIVO");
                                    //
                                    DataRow dr = bllProduto.Sel_Prod_A_Salvar().Rows[0];
                                    //
                                    bllDFe.Salvar_Items(_Cod_Item.ToString(), dr["id_produto"].ToString() + "—" + dr["descricao"].ToString(), _NCM, _CEST, _Orig_CST + _CST, _Aliquota, _CSOSN, _CFOP, _Quantidade, "1,00", bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Preco, _Desconto_Item, _Acrescimo_Item, bllDFe.Calculo_Valor_Item_Desc_Acresc(bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Desconto_Item, _Acrescimo_Item, _Valor_IPI, _Valor_Frete), bllDFe.Calculo_Valor_ICMS(_Base_Calculo_ICMS, _Aliquota), _Base_Calculo_ICMS, txtCodigo.Text, _Valor_ICMSST, _Aliquota_ST, _MVA, _Base_Calculo_ICMS_ST, _Reducao_BC_ICMS_ST, _UM, "0", _Aliquota_IPI, _Valor_IPI, _Reducao_BC_ICMS_ST, "000", "00001", "0", "0", "0", _Valor_Frete);
                                }
                                else
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Descricao(_Descricao, "").Rows[0];
                                    //
                                    bllDFe.Salvar_Items(_Cod_Item.ToString(), dr["id_produto"].ToString() + "—" + dr["descricao"].ToString(), _NCM, _CEST, _Orig_CST + _CST, _Aliquota, _CSOSN, _CFOP, _Quantidade, "1,00", bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Preco, _Desconto_Item, _Acrescimo_Item, bllDFe.Calculo_Valor_Item_Desc_Acresc(bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Desconto_Item, _Acrescimo_Item, _Valor_IPI, _Valor_Frete), _Valor_ICMS, _Base_Calculo_ICMS, txtCodigo.Text, _Valor_ICMSST, _Aliquota_ST, _MVA, _Base_Calculo_ICMS_ST, _Reducao_BC_ICMS_ST, _UM, "0", _Aliquota_IPI, _Valor_IPI, _Reducao_BC_ICMS_ST, "000", "00001", "0", "0", "0", _Valor_Frete);
                                    //
                                    if (Convert.ToByte(dr["alertar_estoque"]) == 1)
                                    {
                                        alertar_estoque = true;
                                    }
                                    else
                                    {
                                        alertar_estoque = false;
                                    }
                                    //                                   
                                    if (Convert.ToByte(dr["dest_est_baixo"]) == 1)
                                    {
                                        dest_estoque_baixo = true;
                                    }
                                    else
                                    {
                                        dest_estoque_baixo = false;
                                    }
                                    //
                                    bllProduto.Adicionar_Saldo_Produto(dr["id_produto"].ToString(), _Quantidade);
                                }
                                //MessageBox.Show("O Item:\n\n[ " + (_Cod_Item + 1) + "-" + _Descricao + " ]\n\nnão possui código de barras informado no xml.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //
                                //bllDFe.Salvar_Items(_Cod_Item.ToString(), "0—" + _Descricao, _NCM, _CEST, _Orig_CST + _CST, _Aliquota, _CSOSN, _CFOP, _Quantidade, "1,00", bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Preco, _Desconto_Item, _Acrescimo_Item, bllDFe.Calculo_Valor_Item_Desc_Acresc(bllDFe.Calculo_Valor_Item(_Preco, _Quantidade), _Desconto_Item, _Acrescimo_Item, _Valor_IPI, _Valor_Frete), bllDFe.Calculo_Valor_ICMS(_Base_Calculo_ICMS, _Aliquota), _Base_Calculo_ICMS, txtCodigo.Text, _Valor_ICMSST, _Aliquota_ST, _MVA, _Base_Calculo_ICMS_ST, _Reducao_BC_ICMS_ST, _UM, "0", _Aliquota_IPI, _Valor_IPI, _Reducao_BC_ICMS_ST, "000", "00001", "0", "0", "0", _Valor_Frete);
                            }
                            //
                            _Cod_Item = _Cod_Item + 1;
                            _Cod_Produto = null;
                            _Codigo_Barra = null;
                            _Descricao = null;
                            _NCM = null;
                            _CEST = null;
                            _CFOP = null;
                            _UM = null;
                            _Preco = null;
                            _CSOSN = null;
                            _Desconto_Item = null;
                            _Orig_CST = null;
                            _CST = null;
                            _Aliquota = null;
                            _Valor_ICMS = null;
                            _Quantidade = null;
                            _Acrescimo_Item = null;
                            _Base_Calculo_ICMS = null;
                            //
                            cst_icms = false;
                            base_calculo = false;
                        }
                    }
                }
                //
                DataRow drItem;
                decimal valoricms = 0;
                decimal valoricmsst = 0;
                decimal base_calculo_icms = 0;
                decimal base_calculo_icms_st = 0;
                decimal total_aprox_trib = 0;
                //
                for (int i = 0; i < dtDFE.Rows.Count; i++)
                {
                    for (int a = 0; a < bllDFe.Sel_Items_DFe(dtDFE.Rows[i].Cells[0].Value.ToString()).Rows.Count; a++)
                    {
                        drItem = bllDFe.Sel_Items_DFe(dtDFE.Rows[i].Cells[0].Value.ToString()).Rows[a];
                        //
                        valoricms += Convert.ToDecimal(drItem["valor_icms"]);
                        valoricmsst += Convert.ToDecimal(drItem["valor_icms_st"]);
                        base_calculo_icms += Convert.ToDecimal(drItem["valor_base_calculo"]);
                        base_calculo_icms_st += Convert.ToDecimal(drItem["valor_base_calculo_st"]);
                        total_aprox_trib += Convert.ToDecimal(drItem["total_aprox_trib"]);
                    }
                }
                //
                bllDFe.Salvar_icms_icms_st_base_total_trib(txtCodigo.Text, valoricms.ToString(), valoricmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
            }
        }

        private void LerArquivoCabecalho(string caminho)
        {
            using (XmlReader arqXML = XmlReader.Create(caminho))
            {
                bool nome_emitente = false;
                bool cpf_cnpj_emitente = false;
                bool id = false;
                string cpfcnpj_mascarado = null;
                bool total = false;
                //
                while (arqXML.Read())
                {
                    if (arqXML.GetAttribute("Id") != null & id == false)
                    {
                        _Id = arqXML.GetAttribute("Id").Replace("NFe", "");
                        _Chave = _Id;
                        mtxtChave.Text = _Chave;
                        id = true;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "natOp")
                    {
                        _Natureza_Operacao = arqXML.ReadElementContentAsString().ToUpper();
                        txtNaturezaOperacao.Text = _Natureza_Operacao;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "mod")
                    {
                        _Tipo = arqXML.ReadElementContentAsString();
                        if (_Tipo == "55")
                        {
                            cbbModelo.Items.Clear();
                            cbbModelo.Items.Add("MODELO 55 (NFe)");
                            cbbModelo.Text = "MODELO 55 (NFe)";
                        }
                        else if (_Tipo == "65")
                        {
                            cbbModelo.Items.Clear();
                            cbbModelo.Items.Add("MODELO 65 (NFCe)");
                            cbbModelo.Text = "MODELO 65 (NFCe)";
                        }
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "serie")
                    {
                        _Serie = arqXML.ReadElementContentAsInt().ToString();
                        txtSerie.Text = _Serie;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "nNF")
                    {
                        _Numero_NF = arqXML.ReadElementContentAsString();
                        txtNumero.Text = _Numero_NF;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "dhEmi")
                    {
                        string data = arqXML.ReadElementContentAsDateTime().ToString();
                        //
                        _Data_Emissao = data.Remove(10);
                        mtxtDataEmissao.Text = _Data_Emissao;
                        //
                        _Hora_Emissao = data.Remove(0, 11);
                        mtxtHorario.Text = _Hora_Emissao;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "dhSaiEnt")
                    {
                        string data = arqXML.ReadElementContentAsDateTime().ToString();
                        //
                        _Data_Saida = data.Remove(10);
                        mtxtDataSaida.Text = _Data_Saida;
                        //
                        _Hora_Saida = data.Remove(0, 11);
                        mtxtHorario1.Text = _Hora_Saida;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CNPJ" & cpf_cnpj_emitente == false)
                    {
                        _CPFCNPJ = arqXML.ReadElementContentAsString();
                        cpf_cnpj_emitente = true;
                        //
                        if (_CPFCNPJ.Length == 14)
                        {
                            cpfcnpj_mascarado = _CPFCNPJ.Substring(0, 2) + "." + _CPFCNPJ.Substring(2, 3) + "." + _CPFCNPJ.Substring(5, 3) + "/" + _CPFCNPJ.Substring(8, 4) + "-" + _CPFCNPJ.Substring(12, 2);
                            //
                            if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != cpfcnpj_mascarado)
                            {
                                _Emissao = "TERCEIROS";
                            }
                            else
                            {
                                _Emissao = "PRÓPRIA";
                            }
                        }
                        else
                        {
                            cpfcnpj_mascarado = _CPFCNPJ.Substring(0, 3) + "." + _CPFCNPJ.Substring(3, 3) + "." + _CPFCNPJ.Substring(6, 3) + "-" + _CPFCNPJ.Substring(9, 2);
                            //
                            if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != cpfcnpj_mascarado)
                            {
                                _Emissao = "TERCEIROS";
                            }
                            else
                            {
                                _Emissao = "PRÓPRIA";
                            }
                        }
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "xNome" & nome_emitente == false)
                    {
                        if (_Emissao == "TERCEIROS")
                        {
                            _Nome = arqXML.ReadElementContentAsString().ToUpper();
                            cbbTipoEmitente.Items.Clear();
                            cbbTipoEmitente.Items.Add("FORNECEDORES");
                            cbbTipoEmitente.Text = "FORNECEDORES";
                            cbbLocDestinatario.Items.Clear();
                            cbbLocDestinatario.Items.Add(_Nome + "—" + cpfcnpj_mascarado);
                            cbbLocDestinatario.Text = _Nome + "—" + cpfcnpj_mascarado;
                            nome_emitente = true;
                        }
                        else
                        {
                            _Nome = arqXML.ReadElementContentAsString().ToUpper();
                            cbbTipoEmitente.Items.Clear();
                            cbbTipoEmitente.Items.Add("CLIENTES");
                            cbbTipoEmitente.Text = "CLIENTES";
                            cbbLocDestinatario.Items.Clear();
                            cbbLocDestinatario.Items.Add(_Nome + "—" + cpfcnpj_mascarado);
                            cbbLocDestinatario.Text = _Nome + "—" + cpfcnpj_mascarado;
                            nome_emitente = true;
                        }
                    }
                    //
                   
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "total")
                    {
                        total = true;
                    }
                    //
                    if (total == true)
                    {
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vProd")
                        {
                            _Total_Produtos = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            txtTotalProdutos.Text = _Total_Produtos;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vFrete")
                        {
                            _Frete = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            txtValorFrete.Text = _Frete;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vSeg")
                        {
                            _Seguro = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            txtSeguro.Text = _Seguro;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vDesc")
                        {
                            _Desconto = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            txtValorDesconto.Text = _Desconto;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vIPI")
                        {
                            _IPÌ = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            txtIPI.Text = _IPÌ;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vOutro")
                        {
                            _Despesa = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            txtValorDespesa.Text = _Despesa;
                        }
                        //
                        if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "vNF")
                        {
                            _Valor_Total_NF = Convert.ToDecimal(arqXML.ReadElementContentAsString().Replace('.', ',')).ToString("n2", new CultureInfo("pt-BR"));
                            txtValorTotal.Text = _Valor_Total_NF;
                        }
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "cobr")
                    {
                        break;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "infCpl")
                    {
                        _Observacao = arqXML.ReadElementContentAsString();
                        rtxtObs.Text = _Observacao;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "chNFe")
                    {
                        _Chave = arqXML.ReadElementContentAsString();
                        mtxtChave.Text = _Chave;
                    }
                }
            }
        }

        private void VerArquivo_CPF_CNPJ(string caminho)
        {
            using (XmlReader arqXML = XmlReader.Create(caminho))
            {
                bool id = false;
                string cpfcnpj_mascarado = null;
                //
                while (arqXML.Read())
                {
                    if (arqXML.GetAttribute("Id") != null & id == false)
                    {
                        _Id = arqXML.GetAttribute("Id").Replace("NFe", "");
                        id = true;
                    }
                    //
                    if (arqXML.NodeType == XmlNodeType.Element & arqXML.Name == "CNPJ" || arqXML.Name == "CPF")
                    {
                        string cnpj = arqXML.ReadElementContentAsString();
                        //
                        if (cnpj.Length == 14)
                        {
                            cpfcnpj_mascarado = cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2);
                            //
                            if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() == cpfcnpj_mascarado)
                            {
                                _CPF_CNPJ_Empresa = cpfcnpj_mascarado;
                            }
                        }
                        else
                        {
                            cpfcnpj_mascarado = cnpj.Substring(0, 3) + "." + cnpj.Substring(3, 3) + "." + cnpj.Substring(6, 3) + "-" + cnpj.Substring(9, 2);
                            //
                            if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() == cpfcnpj_mascarado)
                            {
                                _CPF_CNPJ_Empresa = cpfcnpj_mascarado;
                            }
                        }
                    }
                }
            }
        }

        private void txtNaturezaOperacao_Enter(object sender, EventArgs e)
        {
            txtNaturezaOperacao.BackColor = Color.LightBlue;
        }

        private void txtNaturezaOperacao_Leave(object sender, EventArgs e)
        {
            if (txtNaturezaOperacao.Text.Contains(";") || txtNaturezaOperacao.Text.Contains("'") || txtNaturezaOperacao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNaturezaOperacao.Text = null;
                txtNaturezaOperacao.Select();
            }
            txtNaturezaOperacao.BackColor = Color.White;
        }

        private void txtNaturezaOperacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalProdutos.Select();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtChave.Select();
            }
        }

        private void cbbLocDestinatario_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbLocDestinatario.Text != "" & _Importado == false)
                {
                    string[] items = cbbLocDestinatario.Text.Split('—');
                    //
                    if ((cbbLocDestinatario.Text.Split('—').Length - 1) == 1)
                    {
                        MessageBox.Show("Não é possível selecionar um Emitente sem CPF/CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbLocDestinatario.Text = null;
                        return;
                    }
                    else
                    {
                        if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                        {
                            if (bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]) != "")
                            {
                                MessageBox.Show(bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]), "Informação de Observação do Consumidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    //
                    if (_Inserir_Atualizar == true & _Importado == false)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie_Alt(txtCodigo.Text, txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                            {
                                MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbLocDestinatario.Text = null;
                                cbbLocDestinatario.Select();
                            }
                        }
                        else
                        {
                            if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie(txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                            {
                                MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbLocDestinatario.Text = null;
                                cbbLocDestinatario.Select();
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
                cbbLocDestinatario.Text = null;
            }
        }

        private void btnCadastrarTransportadora_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                bool proprio;
                if (SelectedRow.Cells[14].Value.ToString() == "PRÓPRIA")
                {
                    proprio = true;
                }
                else
                {
                    proprio = false;
                }
                //
                using (FrmCadTransportadora Transp = new FrmCadTransportadora(0, SelectedRow.Cells[0].Value.ToString(), Convert.ToByte(SelectedRow.Cells[21].Value), proprio, _Usuario, _Cod_PDV_Computador))
                {
                    if (Transp.ShowDialog() == DialogResult.OK)
                    {
                        dtDFE.Select();
                    }
                }
                dtDFE_DataSourceChanged(sender, e);
                ModoPesquisa();
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarTransportadora.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarTransportadora.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnCadastrarValidade_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                using (FrmCadValidade Val = new FrmCadValidade(1, _Usuario, _Cod_PDV_Computador, null, SelectedRow.Cells[0].Value.ToString()))
                {
                    if (Val.ShowDialog() == DialogResult.OK)
                    {
                        dtDFE.Select();
                    }
                }
                //            
                dtDFE_DataSourceChanged(sender, e);
                ModoPesquisa();
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnCadastrarValidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrarValidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    cbbLocDestinatario.Items.Clear();
                    if (cbbTipoEmitente.SelectedIndex == 0)
                    {
                        cbbLocDestinatario.Text = null;
                        btnpProcurarDestinatario.Enabled = false;
                    }
                    else if (cbbTipoEmitente.SelectedIndex == 1)
                    {
                        if (bllDFe.Sel_Cliente_DFe() == null)
                        {
                            cbbLocDestinatario.Text = null;
                            btnpProcurarDestinatario.Enabled = false;
                        }
                        else
                        {
                            btnpProcurarDestinatario.Enabled = true;
                            cbbLocDestinatario.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                            {
                                string cpfcnpj;
                                if (dr["cpf_cnpj"].ToString() == "")
                                {
                                    cpfcnpj = "";
                                }
                                else
                                {
                                    cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                }
                                cbbLocDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                            }
                        }
                    }
                    else if (cbbTipoEmitente.SelectedIndex == 2)
                    {
                        if (bllDFe.Sel_Fornecedor_DFe() == null)
                        {
                            cbbLocDestinatario.Text = null;
                            btnpProcurarDestinatario.Enabled = false;
                        }
                        else
                        {
                            btnpProcurarDestinatario.Enabled = true;
                            cbbLocDestinatario.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                            {
                                string cpfcnpj;
                                if (dr["cpf_cnpj"].ToString() == "")
                                {
                                    cpfcnpj = "";
                                }
                                else
                                {
                                    cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                }
                                cbbLocDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoEmitente.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoEmitente.");
                    }
                    cbbLocDestinatario.Items.Clear();
                    cbbLocDestinatario.Text = null;
                    cbbTipoEmitente.Text = null;
                }
            }
        }

        private void cbbTipoEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbModelo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true & _Importado == false)
                {
                    if (_Comando_Atualizar == true)
                    {
                        if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie_Alt(txtCodigo.Text, txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                        {
                            MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            cbbLocDestinatario.Text = null;
                            cbbLocDestinatario.Select();
                        }
                    }
                    else
                    {
                        if (bllDFe.Sel_C_DFe_Codigo_Num_Emit_Serie(txtNumero.Text.Trim(), cbbLocDestinatario.Text, txtSerie.Text.Trim(), cbbModelo.Text) == true)
                        {
                            MessageBox.Show("Já existe um registro com os mesmos [ Número da NF ], [ Série ], [ Modelo ] e [ Emitente ] já cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            cbbLocDestinatario.Text = null;
                            cbbLocDestinatario.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNumero.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNumero.");
                }
                txtNumero.Text = null;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSeguro.Text.Contains(",") && e.KeyChar == (char)44)
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

        private void txtSeguro_Leave(object sender, EventArgs e)
        {
            if (txtSeguro.Text != "")
            {
                if (txtSeguro.Text.Contains("'") || txtSeguro.Text.Contains(";") || txtSeguro.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtSeguro.Text = null;
                    txtSeguro.Select();
                }
                else
                {
                    try
                    {
                        txtSeguro.Text = Convert.ToDecimal(txtSeguro.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSeguro.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtSeguro.");
                        }
                        txtSeguro.Text = null;
                    }
                }
            }
            txtSeguro.BackColor = Color.White;
        }

        private void txtSeguro_Enter(object sender, EventArgs e)
        {
            txtSeguro.BackColor = Color.LightBlue;
        }

        private void txtIPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtIPI.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValorTotal.Select();
            }
        }

        private void txtIPI_Enter(object sender, EventArgs e)
        {
            txtIPI.BackColor = Color.LightBlue;
        }

        private void txtIPI_Leave(object sender, EventArgs e)
        {
            if (txtIPI.Text != "")
            {
                if (txtSeguro.Text.Contains("'") || txtIPI.Text.Contains(";") || txtIPI.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtIPI.Text = null;
                    txtIPI.Select();
                }
                else
                {
                    try
                    {
                        txtIPI.Text = Convert.ToDecimal(txtIPI.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtIPI.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtIPI.");
                        }
                        txtIPI.Text = null;
                    }
                }
            }
            txtIPI.BackColor = Color.White;
        }

        private void cbbTipoEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbLocDestinatario.Select();
            }
        }

        private void mtxtChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbModelo.Select();
            }
        }

        private void btnCriarDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCriarDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPrecificar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPrecificar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPrecificar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                using (FrmPrecificarItems Val = new FrmPrecificarItems(_Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString(), 0))
                {
                    if (Val.ShowDialog() == DialogResult.OK)
                    {
                        dtDFE.Select();
                    }
                    else
                    {
                        dtDFE.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
            }
            pEnabled.Enabled = true;

        }

        private void btnAssociarItens_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                using (FrmAssociarItemDFe Assoc = new FrmAssociarItemDFe(_Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString()))
                {
                    if (Assoc.ShowDialog() == DialogResult.OK)
                    {
                        dtDFE.Select();
                    }
                    else
                    {
                        dtDFE.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
            }
            pEnabled.Enabled = true;
        }
    }
}