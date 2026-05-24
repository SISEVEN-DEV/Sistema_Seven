using BLL;
using System;
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
    public partial class FrmOSItem : Form
    {
        public FrmOSItem(string usuario, string cod_pdv_computador, bool comando_atualizar, string codigo, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Comando_Atualizar = comando_atualizar;
            _Codigo = codigo;
            _Formulario = formulario;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private bool _Comando_Atualizar;
        private string _Codigo;
        private bool _Contem_Imagem;
        private bool _Contem_Imagem_Prod;
        private bool _Contem_Imagem_Func;
        private byte _Formulario;
        private decimal _Servico;
        private decimal _Produto;
        private decimal _Desconto;
        private decimal _Desconto_Prod;
        private decimal _Acrescimo;
        private decimal _Acrescimo_Prod;

        private void FrmItemOS_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSItem iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSItem iniciado.");
                }
                //
                cbbClieConsFunc.Items.Clear();
                if (bllOS.Sel_Cliente_OS() == null)
                {
                    cbbClieConsFunc.Enabled = false;
                    cbbClieConsFunc.Text = null;
                }
                else
                {
                    cbbClieConsFunc.Enabled = true;
                    cbbClieConsFunc.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Cliente_OS().Rows)
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
                        //
                        cbbClieConsFunc.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                    }
                }
                //
                lblValorTotalServicos.Text = "0,00";
                lblValorTotalProdutos.Text = "0,00";
                lblTotalOS.Text = "0,00";
                lblValorDesconto.Text = "0,00";
                lblValorAcrescimo.Text = "0,00";
                lblValorTotalOS.Text = "0,00";
                //
                if (_Comando_Atualizar == false)
                {
                    bllOS.Excluir_Item_Servico_Todos_Temp(bllConexao._Codigo_Conexao);
                    bllOS.Excluir_Item_OS_Produto_Todos_Temp(bllConexao._Codigo_Conexao);
                    bllOS.Excluir_Item_OS_Funcionario_Todos_Temp(bllConexao._Codigo_Conexao);
                    //
                    mtxtData.Text = DateTime.Now.ToShortDateString();
                    mtxtHorario.Text = DateTime.Now.ToLongTimeString();
                    //
                    pcibInterreogacao1.Visible = false;
                    //txtDescItemEquip.Text = "SERVIÇO GERAL";
                }
                else
                {
                    pcibInterreogacao1.Visible = true;
                    //
                    DataRow dr = bllOS.Sel_OS_Codigo(_Codigo).Rows[0];
                    //
                    if (dr["cpf_cnpj_consumidor"].ToString() == "")
                    {
                        cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                    }
                    else
                    {
                        cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                    }
                    //
                    mtxtData.Text = dr["data"].ToString().Remove(10);
                    //
                    mtxtHorario.Text = dr["horario"].ToString();
                    //
                    if (dr["data_conc_prev"].ToString() != "")
                    {
                        mtxtDataConclusao.Text = dr["data_conc_prev"].ToString();
                    }
                    //
                    mtxtHorarioConclusao.Text = dr["horario_conc_prev"].ToString();
                    //
                    txtDescricao.Text = dr["descricao"].ToString();
                    //
                    txtDescItemEquip.Text = dr["descricao_item"].ToString();
                    //
                    txtMarca.Text = dr["marca"].ToString();
                    //
                    txtModelo.Text = dr["modelo"].ToString();
                    //
                    txtNSerie.Text = dr["n_serie"].ToString();
                    //
                    txtObservacao.Text = dr["observacao"].ToString();
                    //
                    if (dr["imagem_os"] != DBNull.Value)
                    {
                        byte[] imagemBytes = (byte[])dr["imagem_os"];
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
                    if (bllOS.Sel_Item_Servico_Todos(_Codigo) != null)
                    {
                        dtServico.DataSource = bllOS.Sel_Item_Servico_Todos(_Codigo);
                    }
                    //
                    if (bllOS.Sel_Item_OS_Produto_Todos(_Codigo) != null)
                    {
                        dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Todos(_Codigo);
                    }
                    //
                    if (bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo) != null)
                    {
                        dtFuncionario.DataSource = bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo);
                    }
                    //
                    if (_Formulario == 1)
                    {
                        mtxtData.ReadOnly = true;
                        mtxtHorario.ReadOnly = true;
                        btnSelecionarData1.Enabled = false;
                        mtxtDataConclusao.ReadOnly = true;
                        mtxtHorarioConclusao.ReadOnly = true;
                        btnSelecionarData2.Enabled = false;
                        txtDescItemEquip.ReadOnly = true;
                        txtMarca.ReadOnly = true;
                        btnProcurarMarca.Enabled = false;
                        txtModelo.ReadOnly = true;
                        txtNSerie.ReadOnly = true;
                        txtDescricao.ReadOnly = true;
                        btnNovoServico.Enabled = false;
                        btnExcluirServico.Enabled = false;
                        btnNovoProduto.Enabled = false;
                        btnExcluirProduto.Enabled = false;
                        btnNovoFuncionario.Enabled = false;
                        btnExcluirFuncionario.Enabled = false;
                        txtObservacao.ReadOnly = true;
                        btnSalvar.Visible = false;
                        cbbClieConsFunc.Items.Clear();
                        if (dr["id_consumidor"].ToString() != "0")
                        {
                            cbbClieConsFunc.Items.Add(dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString());
                            cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                        }
                        btnProcurar.Enabled = false;
                        pcibInterreogacao.Visible = false;
                    }
                }
                //
                cbbClieConsFunc.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOSItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOSItem.");
                }
            }
        }

        private void Limpar() 
        {
            cbbClieConsFunc.Text = null;
            mtxtDataConclusao.Text = null;
            mtxtHorarioConclusao.Text = null;
            txtMarca.Text = null;
            txtModelo.Text = null;
            txtNSerie.Text = null;
            txtDescricao.Text = null;
            txtObservacao.Text = null;
            dtFuncionario.DataSource = null;
            dtProduto.DataSource = null;
            dtServico.DataSource = null;
        }

        private void cbbClieConsFunc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbClieConsFunc_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData1_MouseLeave(object sender, EventArgs e)
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

        private void cbbClieConsFunc_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbClieConsFunc_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtpData_DoubleClick(object sender, EventArgs e)
        {
            mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtData.Text == "")
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtData.Text == "")
                {
                    mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpData_Leave(object sender, EventArgs e)
        {
            mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtData.Text != "")
            {
                try
                {
                    mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtData.Text);

                    mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataConclusao.Text != "")
                    {
                        mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtData.Text) > Convert.ToDateTime(mtxtDataConclusao.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtData.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtData.");
                    }
                    mtxtData.Text = null;
                }
            }
            mtxtData.BackColor = Color.White;
        }

        private void mtxtData_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                mtxtData.BackColor = Color.LightBlue;
            }
        }

        private void mtxtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void mtxtDataConclusao_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataConclusao.Text == "")
            {
                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataConclusao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataConclusao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataConclusao.Text == "")
                {
                    mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataConclusao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataConclusao_Leave(object sender, EventArgs e)
        {
            mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataConclusao.Text != "")
            {
                try
                {
                    mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataConclusao.Text);

                    mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtData.Text != "")
                    {
                        mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataConclusao.Text) < Convert.ToDateTime(mtxtData.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataConclusao.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataConclusao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataConclusao.");
                    }
                    mtxtDataConclusao.Text = null;
                }
            }
            mtxtDataConclusao.BackColor = Color.White;
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
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

        private void mtxtHorario_KeyUp(object sender, KeyEventArgs e)
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
            if (_Formulario != 1)
            {
                mtxtHorario.BackColor = Color.LightBlue;
            }
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataConclusao.Select();
            }
        }

        private void mtxtHorarioConclusao_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioConclusao.Text == "")
            {
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioConclusao.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioConclusao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioConclusao.Text == "")
                {
                    mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioConclusao.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioConclusao_Leave(object sender, EventArgs e)
        {
            mtxtHorarioConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioConclusao.Text != "")
            {
                if (mtxtHorarioConclusao.Text.Length == 4)
                {
                    mtxtHorarioConclusao.Text = mtxtHorarioConclusao.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioConclusao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioConclusao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioConclusao.");
                    }
                    mtxtHorarioConclusao.Text = null;
                }
            }
            mtxtHorarioConclusao.BackColor = Color.White;
        }

        private void mtxtHorarioConclusao_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                mtxtHorarioConclusao.BackColor = Color.LightBlue;
            }
        }

        private void mtxtHorarioConclusao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescItemEquip.Select();
            }
        }

        private void cbbClieConsFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtData.Select();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }


        private void btnProcurar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmPesqCliente Clie = new FrmPesqCliente(13, _Usuario, _Cod_PDV_Computador))
                {
                    if (Clie.ShowDialog() == DialogResult.OK)
                    {
                        cbbClieConsFunc.Items.Clear();
                        if (bllOS.Sel_Cliente_OS() == null)
                        {
                            cbbClieConsFunc.Text = null;
                            cbbClieConsFunc.Enabled = false;
                        }
                        else
                        {
                            cbbClieConsFunc.Enabled = true;
                            cbbClieConsFunc.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Cliente_OS().Rows)
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
                                cbbClieConsFunc.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                            }
                        }
                        cbbClieConsFunc.Text = bllOS._Cliente_PesqCliente_Tabela;
                        bllOS._Cliente_PesqCliente_Tabela = null;
                        cbbClieConsFunc.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbClieConsFunc.Text = null;
                bllOS._Cliente_PesqCliente_Tabela = null;
            }
            this.Enabled = true;
        }

        private void mtxtDataConclusao_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                mtxtDataConclusao.BackColor = Color.LightBlue;
            }
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(5))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtData.Text = bllOS._Data_DatePicker1;
                }
            }
            this.Enabled = true;
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(5))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataConclusao.Text = bllOS._Data_DatePicker1;
                }
            }
            this.Enabled = true;
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarFunc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarMarca_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarMarca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFuncionario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFuncionario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtDataConclusao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioConclusao.Select();
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtObservacao.Select();
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtModelo.Select();
            }
        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNSerie.Select();
            }
        }

        private void txtNSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void txtObservacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void btnProcurarMarca_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmPesqMarca Marca = new FrmPesqMarca(1, _Usuario, _Cod_PDV_Computador))
                {
                    if (Marca.ShowDialog() == DialogResult.OK)
                    {
                        txtMarca.Text = bllOS._Marca_PesqMarca_Tabela;
                        bllOS._Marca_PesqMarca_Tabela = null;
                        txtMarca.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbClieConsFunc.Text = null;
                bllOS._Marca_PesqMarca_Tabela = null;
            }
            this.Enabled = true;
        }

        private void txtDescItemEquip_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                txtDescItemEquip.BackColor = Color.LightBlue;
            }
        }

        private void txtMarca_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                txtMarca.BackColor = Color.LightBlue;
            }
        }

        private void txtModelo_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                txtModelo.BackColor = Color.LightBlue;
            }
        }

        private void txtNSerie_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                txtNSerie.BackColor = Color.LightBlue;
            }
        }

        private void txtObservacao_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                txtObservacao.BackColor = Color.LightBlue;
            }
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                txtDescricao.BackColor = Color.LightBlue;
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescricao.Text = null;
                txtDescricao.Select();
            }
            txtDescricao.BackColor = Color.White;
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + txtDescricao.Text.Length + "/250";
        }

        private void txtDescItemEquip_Leave(object sender, EventArgs e)
        {
            if (txtDescItemEquip.Text.Contains("'") || txtDescItemEquip.Text.Contains(";") || txtDescItemEquip.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescItemEquip.Text = null;
                txtDescItemEquip.Select();
            }
            txtDescItemEquip.BackColor = Color.White;
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {
            if (txtMarca.Text.Contains("'") || txtMarca.Text.Contains(";") || txtMarca.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtMarca.Text = null;
                txtMarca.Select();
            }
            txtMarca.BackColor = Color.White;
        }

        private void txtModelo_Leave(object sender, EventArgs e)
        {
            if (txtModelo.Text.Contains("'") || txtModelo.Text.Contains(";") || txtModelo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtModelo.Text = null;
                txtModelo.Select();
            }
            txtModelo.BackColor = Color.White;
        }

        private void txtNSerie_Leave(object sender, EventArgs e)
        {
            if (txtNSerie.Text.Contains("'") || txtNSerie.Text.Contains(";") || txtNSerie.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNSerie.Text = null;
                txtNSerie.Select();
            }
            txtNSerie.BackColor = Color.White;
        }

        private void txtObservacao_Leave(object sender, EventArgs e)
        {
            if (txtObservacao.Text.Contains("'") || txtObservacao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtObservacao.Text = null;
                txtObservacao.Select();
            }
            txtObservacao.BackColor = Color.White;
        }

        private void txtConclusao_Leave(object sender, EventArgs e)
        {

        }

        private void FrmItemOS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtDescItemEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMarca.Select();
            }
        }

        private void txtObservacao_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCarObs.Text = "Max. de Caracteres: " + txtObservacao.Text.Length + "/250";
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Formulario != 1)
            {
                lblLegendaImagem.ForeColor = Color.Red;
                lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
                this.Cursor = Cursors.Hand;
            }
        }

        private void lblLegendaImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void pcibImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Formulario != 1)
            {
                lblLegendaImagem.ForeColor = Color.Red;
                lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
                this.Cursor = Cursors.Hand;
            }
        }

        private void btnNovoProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovoProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovoFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovoFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovoServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovoServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tabcCadastro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tabcCadastro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovoServico_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                {
                    using (FrmPesqServico Serv = new FrmPesqServico(2, _Usuario, _Cod_PDV_Computador, 0))
                    {
                        if (Serv.ShowDialog() == DialogResult.OK)
                        {
                            using (FrmAdicionarItem Item = new FrmAdicionarItem(dtServico.Rows.Count, 3, null, null, _Codigo))
                            {
                                if (Item.ShowDialog() == DialogResult.OK)
                                {
                                    if (_Comando_Atualizar == false)
                                    {
                                        dtServico.DataSource = bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao);
                                    }
                                    else
                                    {
                                        dtServico.DataSource = bllOS.Sel_Item_Servico_Todos(_Codigo);
                                    }
                                    //
                                    bllOS._Servico_PesqServico_Tabela = null;
                                    //
                                    dtServico.CurrentCell = dtServico.Rows[dtServico.Rows.Count - 1].Cells[0];
                                    //
                                    dtServico.Rows[dtServico.Rows.Count - 1].Selected = true;
                                    //
                                    dtServico.FirstDisplayedScrollingRowIndex = dtServico.Rows.Count - 1;
                                    //
                                    dtServico.Select();
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (FrmPesqServico Serv = new FrmPesqServico(0, _Usuario, _Cod_PDV_Computador, 0))
                    {
                        if (Serv.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            string[] items = bllOS._Servico_PesqServico_Tabela.Split('—');
                            //
                            if (_Comando_Atualizar == false)
                            {
                                bllOS.Salvar_Items_Servico_Temp((dtServico.Rows.Count + 1).ToString(), items[0], items[1], items[2], bllConexao._Codigo_Conexao, bllOS._Quantidade, items[3], items[5], items[4], "0");
                                //
                                dtServico.DataSource = bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao);
                            }
                            else
                            {
                                bllOS.Salvar_Items_Servico((dtServico.Rows.Count + 1).ToString(), items[0], items[1], items[2], _Codigo, bllOS._Quantidade, items[3], items[5], items[4], "0");
                                //
                                dtServico.DataSource = bllOS.Sel_Item_Servico_Todos(_Codigo);
                                //
                                bllOS.Alterar_OS_Valores(_Codigo, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblValorTotalOS.Text);
                            }
                            //
                            bllOS._Servico_PesqServico_Tabela = null;
                            //
                            dtServico.CurrentCell = dtServico.Rows[dtServico.Rows.Count - 1].Cells[0];
                            //
                            dtServico.Rows[dtServico.Rows.Count - 1].Selected = true;
                            //
                            dtServico.FirstDisplayedScrollingRowIndex = dtServico.Rows.Count - 1;
                            //
                            dtServico.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovoServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovoServico.");
                }
                bllOS._Servico_PesqServico_Tabela = null;
            }
            this.Enabled = true;
        }

        private void btnNovoFuncionario_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmPesqFuncionario Func = new FrmPesqFuncionario(9, _Usuario, _Cod_PDV_Computador))
                {
                    if (Func.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        string[] items = bllOS._Func_PesqFuncionario_Tabela.Split('—');
                        //
                        if (_Comando_Atualizar == false)
                        {
                            bllOS.Salvar_Items_OS_Funcionario_Temp((dtFuncionario.Rows.Count + 1).ToString(), items[0], items[1], bllConexao._Codigo_Conexao, items[2]);
                            //
                            dtFuncionario.DataSource = bllOS.Sel_Item_OS_Funcionario_Temp_Todos(bllConexao._Codigo_Conexao);
                        }
                        else
                        {
                            bllOS.Salvar_Items_OS_Funcionario((dtFuncionario.Rows.Count + 1).ToString(), items[0], items[1], _Codigo);
                            //
                            dtFuncionario.DataSource = bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo);
                        }
                        //
                        bllOS._Func_PesqFuncionario_Tabela = null;
                        //
                        dtFuncionario.CurrentCell = dtFuncionario.Rows[dtFuncionario.Rows.Count - 1].Cells[0];
                        //
                        dtFuncionario.Rows[dtFuncionario.Rows.Count - 1].Selected = true;
                        //
                        dtFuncionario.FirstDisplayedScrollingRowIndex = dtFuncionario.Rows.Count - 1;
                        //
                        dtFuncionario.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovoServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovoServico.");
                }
                bllOS._Servico_PesqServico_Tabela = null;
            }
            this.Enabled = true;
        }

        private void dtServico_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtServico.Columns[0].HeaderText = "Item";
                dtServico.Columns[1].HeaderText = "Cód. do Serviço";
                dtServico.Columns[2].HeaderText = "Descrição do Serviço";
                dtServico.Columns[3].HeaderText = "Quantidade";
                dtServico.Columns[4].HeaderText = "Vl. Unit. (R$)";
                dtServico.Columns[5].HeaderText = "Valor Total (R$)";
                //
                if (_Comando_Atualizar != false)
                {
                    dtServico.Columns[6].Visible = false;
                    dtServico.Columns[7].Visible = false;
                    dtServico.Columns[8].HeaderText = "Vl. do Desc. - (R$)";
                    dtServico.Columns[9].HeaderText = "Vl. do Acrésc. + (R$)";
                    dtServico.Columns[10].HeaderText = "Vl. Total (R$)";
                    dtServico.Columns[11].HeaderText = "Cód. do Orçamento";
                    dtServico.Columns[8].Width = 150;
                    dtServico.Columns[9].Width = 150;
                    dtServico.Columns[10].Width = 150;
                    dtServico.Columns[11].Width = 150;
                    dtServico.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dtServico.Columns[6].Visible = false;
                    dtServico.Columns[7].HeaderText = "Vl. do Desc. - (R$)";
                    dtServico.Columns[8].HeaderText = "Vl. do Acrésc. + (R$)";
                    dtServico.Columns[9].HeaderText = "Vl. Total (R$)";
                    dtServico.Columns[10].HeaderText = "Cód. do Orçamento";
                    dtServico.Columns[7].Width = 150;
                    dtServico.Columns[8].Width = 150;
                    dtServico.Columns[9].Width = 150;
                    dtServico.Columns[10].Width = 150;
                    dtServico.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtServico.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                //
                dtServico.Columns[0].Width = 55;
                dtServico.Columns[1].Width = 115;
                dtServico.Columns[2].Width = 277;
                dtServico.Columns[3].Width = 100;
                dtServico.Columns[4].Width = 100;
                dtServico.Columns[5].Width = 105;
                //
                dtServico.DefaultCellStyle.Font = new Font(dtServico.Font, FontStyle.Bold);
                //
                dtServico.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtServico.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                decimal total_servicos = 0;
                for (int i = 0; i < dtServico.Rows.Count; i++)
                {
                    total_servicos += Convert.ToDecimal(dtServico.Rows[i].Cells[5].Value);
                }
                lblValorTotalServicos.Text = total_servicos.ToString("n2", new CultureInfo("pt-BR"));
                //
                _Desconto = 0;
                for (int i = 0; i < dtServico.Rows.Count; i++)
                {
                    if (_Comando_Atualizar != false)
                    {
                        _Desconto += Convert.ToDecimal(dtServico.Rows[i].Cells[8].Value);
                    }
                    else
                    {
                        _Desconto += Convert.ToDecimal(dtServico.Rows[i].Cells[7].Value);
                    }
                }
                lblValorDesconto.Text = (_Desconto + _Desconto_Prod).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Acrescimo = 0;
                for (int i = 0; i < dtServico.Rows.Count; i++)
                {
                    if (_Comando_Atualizar != false)
                    {
                        _Acrescimo += Convert.ToDecimal(dtServico.Rows[i].Cells[9].Value);
                    }
                    else
                    {
                        _Acrescimo += Convert.ToDecimal(dtServico.Rows[i].Cells[8].Value);
                    }
                }
                lblValorAcrescimo.Text = (_Acrescimo + _Acrescimo_Prod).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Servico = 0;
                for (int i = 0; i < dtServico.Rows.Count; i++)
                {
                    _Servico += Convert.ToDecimal(dtServico.Rows[i].Cells[5].Value);
                }
                lblTotalOS.Text = (_Servico + _Produto).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valortotal = 0;
                valortotal = Convert.ToDecimal(lblTotalOS.Text) + Convert.ToDecimal(lblValorAcrescimo.Text) - Convert.ToDecimal(lblValorDesconto.Text);
                //
                lblValorTotalOS.Text = valortotal.ToString("n2", new CultureInfo("pt-BR"));
                //
                lblRegistrosServico.Text = "Registros: " + dtServico.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtServico.");
                }
                dtServico.DataSource = null;
            }
        }

        private void dtServico_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_Formulario != 1)
            {
                dtServico.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            }
            else
            {
                dtServico.DefaultCellStyle.SelectionBackColor = Color.White;
            }

            dtServico.DefaultCellStyle.SelectionForeColor = Color.Black;

            dtServico.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[0].DefaultCellStyle.Format = "D3";
            dtServico.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[3].DefaultCellStyle.Format = "n2";
            dtServico.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[4].DefaultCellStyle.Format = "n2";
            dtServico.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtServico.Columns[5].DefaultCellStyle.Format = "n2";

            if (_Comando_Atualizar != false)
            {
                dtServico.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[8].DefaultCellStyle.Format = "n2";
                dtServico.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[9].DefaultCellStyle.Format = "n2";
                dtServico.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[10].DefaultCellStyle.Format = "n2";
            }
            else
            {
                dtServico.Columns[6].Visible = false;
                dtServico.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[7].DefaultCellStyle.Format = "n2";
                dtServico.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[8].DefaultCellStyle.Format = "n2";
                dtServico.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[9].DefaultCellStyle.Format = "n2";
            }
        }

        private void dtServico_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            decimal total_servicos = 0;
            for (int i = 0; i < dtServico.Rows.Count; i++)
            {
                total_servicos += Convert.ToDecimal(dtServico.Rows[i].Cells[5].Value);
            }
            lblValorTotalServicos.Text = total_servicos.ToString("n2", new CultureInfo("pt-BR"));
            //
            _Desconto = 0;
            for (int i = 0; i < dtServico.Rows.Count; i++)
            {
                if (_Comando_Atualizar != false)
                {
                    _Desconto += Convert.ToDecimal(dtServico.Rows[i].Cells[8].Value);
                }
                else
                {
                    _Desconto += Convert.ToDecimal(dtServico.Rows[i].Cells[7].Value);
                }
            }
            lblValorDesconto.Text = (_Desconto + _Desconto_Prod).ToString("n2", new CultureInfo("pt-BR"));
            //
            _Acrescimo = 0;
            for (int i = 0; i < dtServico.Rows.Count; i++)
            {
                if (_Comando_Atualizar != false)
                {
                    _Acrescimo += Convert.ToDecimal(dtServico.Rows[i].Cells[9].Value);
                }
                else
                {
                    _Acrescimo += Convert.ToDecimal(dtServico.Rows[i].Cells[8].Value);
                }
            }
            lblValorAcrescimo.Text = (_Acrescimo + _Acrescimo_Prod).ToString("n2", new CultureInfo("pt-BR"));
            //
            _Servico = 0;
            for (int i = 0; i < dtServico.Rows.Count; i++)
            {
                _Servico += Convert.ToDecimal(dtServico.Rows[i].Cells[5].Value);
            }
            lblTotalOS.Text = (_Servico + _Produto).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotal = 0;
            valortotal = Convert.ToDecimal(lblTotalOS.Text) + Convert.ToDecimal(lblValorAcrescimo.Text) - Convert.ToDecimal(lblValorDesconto.Text);
            //
            lblValorTotalOS.Text = valortotal.ToString("n2", new CultureInfo("pt-BR"));
            //
            lblRegistrosServico.Text = "Registros: " + dtServico.Rows.Count;
        }

        private void dtServico_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtServico.DataSource == null)
            {
                btnExcluirServico.Enabled = false;
                dtServico.Enabled = false;
            }
            else
            {
                btnExcluirServico.Enabled = true;
                dtServico.Enabled = true;
            }
        }

        private void dtServico_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtServico.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmItemOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Comando_Atualizar == false)
                {
                    bllOS.Excluir_Item_Servico_Todos_Temp(bllConexao._Codigo_Conexao);
                    bllOS.Excluir_Item_OS_Produto_Todos_Temp(bllConexao._Codigo_Conexao);
                    bllOS.Excluir_Item_OS_Funcionario_Todos_Temp(bllConexao._Codigo_Conexao);
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSItem foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSItem foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmOSItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmOSItem.");
                }
            }
        }

        private void btnExcluirServico_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
                //
                string mensagem = "Deseja excluir este Serviço?";
                //
                DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (_Comando_Atualizar == false)
                    {
                        bllOS.Excluir_Item_Servico_Temp(SelectedRow.Cells[0].Value.ToString(), bllConexao._Codigo_Conexao);
                        //
                        bllOS.Atualizar_Item_Dt_Item_Servico_Temp(dtServico.CurrentRow.Index + 1, dtServico.Rows.Count, bllConexao._Codigo_Conexao);
                        //
                        dtServico.DataSource = bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao);
                        //
                        if (dtServico.Rows.Count >= 1)
                        {
                            dtServico.Rows[dtServico.Rows.Count - 1].Selected = true;

                            dtServico.FirstDisplayedScrollingRowIndex = dtServico.Rows.Count - 1;

                            dtServico.Select();
                        }
                        else
                        {
                            dtServico.DataSource = null;
                            btnNovoServico.Select();
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        if (SelectedRow.Cells[11].Value.ToString() != "0")
                        {
                            bool orcamento_existe = false;
                            for (int i = 0; i < dtServico.Rows.Count; i++)
                            {
                                if (i != dtServico.CurrentRow.Index)
                                {
                                    if (dtServico.Rows[i].Cells[11].Value.ToString() == "" || dtServico.Rows[i].Cells[11].Value.ToString() != SelectedRow.Cells[11].Value.ToString())
                                    {
                                        orcamento_existe = false;
                                    }
                                    else
                                    {
                                        orcamento_existe = true;
                                        break;
                                    }
                                }
                            }
                            //
                            if (orcamento_existe == false)
                            {
                                for (int i = 0; i < dtProduto.Rows.Count; i++)
                                {
                                    if (dtProduto.Rows[i].Cells[11].Value.ToString() == "" || dtProduto.Rows[i].Cells[11].Value.ToString() != SelectedRow.Cells[11].Value.ToString())
                                    {
                                        orcamento_existe = false;
                                    }
                                    else
                                    {
                                        orcamento_existe = true;
                                        break;
                                    }
                                }
                            }
                            //
                            if (orcamento_existe == false)
                            {
                                bllOrcamento.Alterar_Situacao_Orcamento(SelectedRow.Cells[11].Value.ToString(), "PENDENTE");
                            }
                        }
                        //
                        if (bllOS.Sel_Item_Servico_Todos(_Codigo).Rows.Count == 1)
                        {
                            MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Cliente/Consumidor ], [ Data de Criação ], [ Descrição do Item/Equipamento ] e\n[ Tabela de Serviços ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllOS.Excluir_Item_Servico(SelectedRow.Cells[0].Value.ToString(), _Codigo);
                            //
                            bllOS.Atualizar_Item_Dt_Item_Servico(dtServico.CurrentRow.Index + 1, dtServico.Rows.Count, _Codigo);
                            //
                            dtServico.DataSource = bllOS.Sel_Item_Servico_Todos(_Codigo);
                            //
                            bllOS.Alterar_OS_Valores(_Codigo, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblValorTotalOS.Text);
                            //
                            if (dtServico.Rows.Count >= 1)
                            {
                                dtServico.Rows[dtServico.Rows.Count - 1].Selected = true;

                                dtServico.FirstDisplayedScrollingRowIndex = dtServico.Rows.Count - 1;

                                dtServico.Select();
                            }
                            else
                            {
                                dtServico.DataSource = null;
                                btnNovoServico.Select();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    dtServico.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirServico.");
                }
                dtServico.DataSource = null;
                btnNovoServico.Select();
            }
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(_Usuario) == true)
                {
                    using (FrmPesqProduto Serv = new FrmPesqProduto(11, null, _Usuario, _Cod_PDV_Computador, 0, null))
                    {
                        if (Serv.ShowDialog() == DialogResult.OK)
                        {
                            using (FrmAdicionarItem Item = new FrmAdicionarItem(dtProduto.Rows.Count, 5, null, null, _Codigo))
                            {
                                if (Item.ShowDialog() == DialogResult.OK)
                                {
                                    if (_Comando_Atualizar == false)
                                    {
                                        dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao);
                                    }
                                    else
                                    {
                                        dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Todos(_Codigo);
                                        //
                                        bllOS.Alterar_OS_Valores(_Codigo, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblValorTotalOS.Text);
                                    }
                                    //
                                    dtProduto.CurrentCell = dtProduto.Rows[dtProduto.Rows.Count - 1].Cells[0];
                                    //
                                    dtProduto.Rows[dtProduto.Rows.Count - 1].Selected = true;
                                    //
                                    dtProduto.FirstDisplayedScrollingRowIndex = dtProduto.Rows.Count - 1;
                                    //
                                    dtProduto.Select();
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (FrmPesqProduto Serv = new FrmPesqProduto(6, null, _Usuario, _Cod_PDV_Computador, 0, null))
                    {
                        if (Serv.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            string[] items = bllOS._Produto_PesqProduto_Tabela.Split('—');
                            //
                            if (_Comando_Atualizar == false)
                            {
                                bllOS.Salvar_Items_OS_Produto_Temp((dtProduto.Rows.Count + 1).ToString(), items[0], items[1], items[3], items[2], bllOS._Quantidade, items[4], items[5], bllConexao._Codigo_Conexao, "0");
                                //
                                dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao);
                            }
                            else
                            {
                                bllOS.Salvar_Items_OS_Produto((dtProduto.Rows.Count + 1).ToString(), items[0], items[1], items[3], items[2], bllOS._Quantidade, items[4], items[5], _Codigo, "0");
                                //
                                bllOS.Alterar_Estoque_Produto_OS(items[0], bllOS._Quantidade, false);
                                //
                                dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Todos(_Codigo);
                                //
                                bllOS.Alterar_OS_Valores(_Codigo, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblValorTotalOS.Text);
                            }
                            //
                            bllOS._Produto_PesqProduto_Tabela = null;
                            bllOS._Quantidade = null;
                            //
                            dtProduto.CurrentCell = dtProduto.Rows[dtProduto.Rows.Count - 1].Cells[0];
                            //
                            dtProduto.Rows[dtProduto.Rows.Count - 1].Selected = true;
                            //
                            dtProduto.FirstDisplayedScrollingRowIndex = dtProduto.Rows.Count - 1;
                            //
                            dtProduto.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovoProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovoProduto.");
                }
                cbbClieConsFunc.Text = null;
                bllOS._Produto_PesqProduto_Tabela = null;
                bllOS._Quantidade = null;
            }
            this.Enabled = true;
        }

        private void dtIProduto_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtProduto.DataSource == null)
            {
                btnExcluirProduto.Enabled = false;
                dtProduto.Enabled = false;
                pcibImagemProduto.Image = null;
                pcibImagemProduto.Enabled = false;
            }
            else
            {
                dtProduto.Enabled = true;
                pcibImagemProduto.Enabled = true;
                btnExcluirProduto.Enabled = true;
            }
        }

        private void dtProduto_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtProduto.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtProduto_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtProduto.Columns[0].HeaderText = "Item";
                dtProduto.Columns[1].HeaderText = "Cód. do Produto";
                dtProduto.Columns[2].HeaderText = "Descrição do Produto";
                dtProduto.Columns[3].HeaderText = " Qtd.";
                dtProduto.Columns[4].HeaderText = "UN.";
                dtProduto.Columns[5].HeaderText = "Vl. Unit. (R$)";
                dtProduto.Columns[6].HeaderText = "Vl. Item (R$)";
                dtProduto.Columns[7].HeaderText = "Vl. do Desc. - (R$)";
                dtProduto.Columns[8].HeaderText = "Vl. do Acrésc. + (R$)";
                dtProduto.Columns[9].HeaderText = "Vl. Total (R$)";
                
                if (_Comando_Atualizar != false)
                {
                    dtProduto.Columns[10].Visible = false;
                    dtProduto.Columns[11].HeaderText = "Cód. do Orçamento";
                    dtProduto.Columns[11].Width = 150;
                    dtProduto.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProduto.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dtProduto.Columns[10].HeaderText = "Cód. do Orçamento";
                    dtProduto.Columns[10].Width = 150;
                    dtProduto.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProduto.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                //
                dtProduto.Columns[0].Width = 56;
                dtProduto.Columns[1].Width = 115;
                dtProduto.Columns[2].Width = 275;
                dtProduto.Columns[3].Width = 70;
                dtProduto.Columns[4].Width = 56;
                dtProduto.Columns[5].Width = 130;
                dtProduto.Columns[6].Width = 130;
                dtProduto.Columns[7].Width = 130;
                dtProduto.Columns[8].Width = 130;
                dtProduto.Columns[9].Width = 130;
                dtProduto.Columns[10].Width = 150;
                //
                dtProduto.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProduto.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                dtProduto.DefaultCellStyle.Font = new Font(dtProduto.Font, FontStyle.Bold);
                //
                decimal totalprodutos = 0;
                for (int i = 0; i < dtProduto.Rows.Count; i++)
                {
                    totalprodutos += Convert.ToDecimal(dtProduto.Rows[i].Cells[6].Value);
                }
                //
                lblValorTotalProdutos.Text = totalprodutos.ToString("n2", new CultureInfo("pt-BR"));
                //
                _Desconto_Prod = 0;
                for (int i = 0; i < dtProduto.Rows.Count; i++)
                {
                    _Desconto_Prod += Convert.ToDecimal(dtProduto.Rows[i].Cells[7].Value);
                }
                lblValorDesconto.Text = (_Desconto + _Desconto_Prod).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Acrescimo_Prod = 0;
                for (int i = 0; i < dtProduto.Rows.Count; i++)
                {
                    _Acrescimo_Prod += Convert.ToDecimal(dtProduto.Rows[i].Cells[8].Value);
                }
                lblValorAcrescimo.Text = (_Acrescimo + _Acrescimo_Prod).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Produto = 0;
                for (int i = 0; i < dtProduto.Rows.Count; i++)
                {
                    _Produto += Convert.ToDecimal(dtProduto.Rows[i].Cells[6].Value);
                }
                lblTotalOS.Text = (_Servico + _Produto).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valortotal = 0;
                valortotal = Convert.ToDecimal(lblTotalOS.Text) + Convert.ToDecimal(lblValorAcrescimo.Text) - Convert.ToDecimal(lblValorDesconto.Text);
                //
                lblValorTotalOS.Text = valortotal.ToString("n2", new CultureInfo("pt-BR"));
                //
                lblRegistrosProduto.Text = "Registros: " + dtProduto.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtServico.");
                }
                dtProduto.DataSource = null;
            }
        }

        private void dtProduto_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            decimal totalprodutos = 0;
            for (int i = 0; i < dtProduto.Rows.Count; i++)
            {
                totalprodutos += Convert.ToDecimal(dtProduto.Rows[i].Cells[6].Value);
            }
            //
            lblValorTotalProdutos.Text = totalprodutos.ToString("n2", new CultureInfo("pt-BR"));
            //
            _Desconto_Prod = 0;
            for (int i = 0; i < dtProduto.Rows.Count; i++)
            {
                _Desconto_Prod += Convert.ToDecimal(dtProduto.Rows[i].Cells[8].Value);
            }
            lblValorDesconto.Text = (_Desconto + _Desconto_Prod).ToString("n2", new CultureInfo("pt-BR"));
            //
            _Acrescimo_Prod = 0;
            for (int i = 0; i < dtProduto.Rows.Count; i++)
            {
                _Acrescimo_Prod += Convert.ToDecimal(dtProduto.Rows[i].Cells[9].Value);
            }
            lblValorAcrescimo.Text = (_Acrescimo + _Acrescimo_Prod).ToString("n2", new CultureInfo("pt-BR"));
            //
            _Produto = 0;
            for (int i = 0; i < dtProduto.Rows.Count; i++)
            {
                _Produto += Convert.ToDecimal(dtProduto.Rows[i].Cells[6].Value);
            }
            lblTotalOS.Text = (_Servico + _Produto).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotal = 0;
            valortotal = Convert.ToDecimal(lblTotalOS.Text) + Convert.ToDecimal(lblValorAcrescimo.Text) - Convert.ToDecimal(lblValorDesconto.Text);
            //
            lblValorTotalOS.Text = valortotal.ToString("n2", new CultureInfo("pt-BR"));
            //
            lblRegistrosProduto.Text = "Registros: " + dtProduto.Rows.Count;
        }

        private void dtProduto_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProduto.Rows[dtProduto.CurrentRow.Index];
                //
                dtProduto.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProduto.Columns[0].DefaultCellStyle.Format = "D3";
                dtProduto.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProduto.Columns[3].DefaultCellStyle.Format = "n2";
                dtProduto.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProduto.Columns[5].DefaultCellStyle.Format = "n2";
                dtProduto.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProduto.Columns[6].DefaultCellStyle.Format = "n2";
                dtProduto.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProduto.Columns[7].DefaultCellStyle.Format = "n2";
                dtProduto.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProduto.Columns[8].DefaultCellStyle.Format = "n2";
                dtProduto.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProduto.Columns[9].DefaultCellStyle.Format = "n2";
                //
                if (_Formulario != 1)
                {
                    dtProduto.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                }
                else
                {
                    dtProduto.DefaultCellStyle.SelectionBackColor = Color.White;
                }
                //
                dtProduto.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                DataRow dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];
                //
                if (dr["imagem_prod"] != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])dr["imagem_prod"];
                    //
                    using (MemoryStream ms = new MemoryStream(imagemBytes))
                    {
                        Image imagem = Image.FromStream(ms);
                        pcibImagemProduto.Image = imagem;
                        pcibImagemProduto.SizeMode = PictureBoxSizeMode.StretchImage; // Ou CenterImage, como preferir
                    }
                    //
                    _Contem_Imagem_Prod = true;
                    lblLegendaImagemProduto.Visible = false;
                }
                else
                {
                    lblLegendaImagemProduto.Visible = true;
                    _Contem_Imagem_Prod = false;
                    lblLegendaImagemProduto.Text = "Sem imagem para este registro.";
                    pcibImagemProduto.Image = null;
                    pcibImagemProduto.ImageLocation = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProduto.");
                }
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

        private void btnExcluirProduto_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProduto.Rows[dtProduto.CurrentRow.Index];
                //
                string mensagem = "Deseja excluir este Produto?";
                //
                DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (_Comando_Atualizar == false)
                    {
                        bllOS.Excluir_Item_OS_Produto_Temp(SelectedRow.Cells[0].Value.ToString(), bllConexao._Codigo_Conexao);
                        //
                        bllOS.Atualizar_Item_Dt_Item_OS_Produto_Temp(dtProduto.CurrentRow.Index + 1, dtProduto.Rows.Count, bllConexao._Codigo_Conexao);
                        //
                        dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        if (SelectedRow.Cells[11].Value.ToString() != "0")
                        {
                            bool orcamento_existe = false;
                            for (int i = 0; i < dtProduto.Rows.Count; i++)
                            {
                                if (i != dtProduto.CurrentRow.Index)
                                {
                                    if (dtProduto.Rows[i].Cells[11].Value.ToString() == "" || dtProduto.Rows[i].Cells[11].Value.ToString() != SelectedRow.Cells[11].Value.ToString())
                                    {
                                        orcamento_existe = false;
                                    }
                                    else
                                    {
                                        orcamento_existe = true;
                                        break;
                                    }
                                }
                            }
                            //
                            if (orcamento_existe == false)
                            {
                                for (int i = 0; i < dtServico.Rows.Count; i++)
                                {
                                    if (dtServico.Rows[i].Cells[11].Value.ToString() == "" || dtServico.Rows[i].Cells[11].Value.ToString() != SelectedRow.Cells[11].Value.ToString())
                                    {
                                        orcamento_existe = false;
                                    }
                                    else
                                    {
                                        orcamento_existe = true;
                                        break;
                                    }
                                }
                            }
                            //
                            if (orcamento_existe == false)
                            {
                                bllOrcamento.Alterar_Situacao_Orcamento(SelectedRow.Cells[11].Value.ToString(), "PENDENTE");
                            }
                        }
                        //
                        bllOS.Excluir_Item_OS_Produto(SelectedRow.Cells[0].Value.ToString(), _Codigo);
                        //
                        bllOS.Alterar_Estoque_Produto_OS(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), true);
                        //
                        bllOS.Atualizar_Item_Dt_Item_OS_Produto(dtProduto.CurrentRow.Index + 1, dtProduto.Rows.Count, _Codigo);
                        //
                        dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Todos(_Codigo);
                        //
                        bllOS.Alterar_OS_Valores(_Codigo, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblValorTotalOS.Text);
                    }
                    //
                    if (dtProduto.Rows.Count >= 1)
                    {
                        dtProduto.Rows[dtProduto.Rows.Count - 1].Selected = true;

                        dtProduto.FirstDisplayedScrollingRowIndex = dtProduto.Rows.Count - 1;

                        dtProduto.Select();
                    }
                    else
                    {
                        dtProduto.DataSource = null;
                        btnNovoServico.Select();
                    }
                    //
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    dtProduto.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirProduto.");
                }
                dtProduto.DataSource = null;
                btnNovoProduto.Select();
            }
        }

        private void lblValorTotalProdutos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalProdutos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalServicos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Serviços (R$): " + lblValorTotalServicos.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalProdutos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Produtos (R$): " + lblValorTotalProdutos.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalOS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor A Pagar (R$): " + lblValorTotalOS.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pcibImagemProduto_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Formulario != 1)
            {
                lblLegendaImagemProduto.ForeColor = Color.Red;
                lblLegendaImagemProduto.Font = new Font(lblLegendaImagemProduto.Font.Name, lblLegendaImagemProduto.Font.SizeInPoints, FontStyle.Underline);
                if (dtProduto.DataSource != null)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void pcibImagemProduto_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagemProduto.ForeColor = Color.Black;
            lblLegendaImagemProduto.Font = new Font(lblLegendaImagemProduto.Font.Name, lblLegendaImagemProduto.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblLegendaImagemProduto_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Formulario != 1)
            {
                lblLegendaImagemProduto.ForeColor = Color.Red;
                lblLegendaImagemProduto.Font = new Font(lblLegendaImagemProduto.Font.Name, lblLegendaImagemProduto.Font.SizeInPoints, FontStyle.Underline);
                if (dtProduto.DataSource != null)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void lblLegendaImagemProduto_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagemProduto.ForeColor = Color.Black;
            lblLegendaImagemProduto.Font = new Font(lblLegendaImagemProduto.Font.Name, lblLegendaImagemProduto.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];
                //
                DialogResult = MessageBox.Show("Deseja excluir este Funcionário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (_Comando_Atualizar == false)
                    {
                        bllOS.Excluir_Item_OS_Funcionario_Temp(SelectedRow.Cells[0].Value.ToString(), bllConexao._Codigo_Conexao);
                        //
                        bllOS.Atualizar_Item_Dt_Item_OS_Funcionario_Temp(dtFuncionario.CurrentRow.Index + 1, dtFuncionario.Rows.Count, bllConexao._Codigo_Conexao);
                        //
                        dtFuncionario.DataSource = bllOS.Sel_Item_OS_Funcionario_Temp_Todos(bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        bllOS.Excluir_Item_OS_Funcionario(SelectedRow.Cells[0].Value.ToString(), _Codigo);
                        //
                        bllOS.Atualizar_Item_Dt_Item_OS_Funcionario(dtFuncionario.CurrentRow.Index + 1, dtFuncionario.Rows.Count, _Codigo);
                        //
                        dtFuncionario.DataSource = bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo);
                    }
                    //
                    if (dtFuncionario.Rows.Count >= 1)
                    {
                        dtFuncionario.Rows[dtFuncionario.Rows.Count - 1].Selected = true;

                        dtFuncionario.FirstDisplayedScrollingRowIndex = dtFuncionario.Rows.Count - 1;

                        dtFuncionario.Select();
                    }
                    else
                    {
                        dtFuncionario.DataSource = null;
                        btnNovoServico.Select();
                    }
                    //
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    dtFuncionario.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirFuncionario.");
                }
                dtFuncionario.DataSource = null;
                btnNovoFuncionario.Select();
            }
        }

        private void dtFuncionario_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtFuncionario.Columns[0].HeaderText = "Item";
                dtFuncionario.Columns[1].HeaderText = "Cód. do Funcionário";
                dtFuncionario.Columns[2].HeaderText = "Nome do Funcionário";
                if (_Comando_Atualizar != false)
                {
                    dtFuncionario.Columns[3].Visible = false;
                }
                //
                dtFuncionario.Columns[0].Width = 56;
                dtFuncionario.Columns[1].Width = 135;
                dtFuncionario.Columns[2].Width = 399;
                //
                dtFuncionario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFuncionario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                dtFuncionario.DefaultCellStyle.Font = new Font(dtProduto.Font, FontStyle.Bold);
                //
                lblRegistrosFuncionario.Text = "Registros: " + dtFuncionario.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtServico.");
                }
                dtFuncionario.DataSource = null;
            }
        }

        private void dtFuncionario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];
                //
                if (_Formulario != 1)
                {
                    dtFuncionario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                }
                else
                {
                    dtFuncionario.DefaultCellStyle.SelectionBackColor = Color.White;
                }
                //
                dtFuncionario.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                DataRow dr = bllFuncionario.Sel_Funcionario_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                //
                if (dr["imagem_func"] != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])dr["imagem_func"];
                    //
                    using (MemoryStream ms = new MemoryStream(imagemBytes))
                    {
                        Image imagem = Image.FromStream(ms);
                        pcibImagemFuncionario.Image = imagem;
                        pcibImagemFuncionario.SizeMode = PictureBoxSizeMode.StretchImage; // Ou CenterImage, como preferir
                    }
                    //
                    _Contem_Imagem_Func = true;
                    lblLegendaImagemFuncionario.Visible = false;
                }
                else
                {
                    lblLegendaImagemFuncionario.Visible = true;
                    _Contem_Imagem_Func = false;
                    lblLegendaImagemFuncionario.Text = "Sem imagem para este registro.";
                    pcibImagemFuncionario.Image = null;
                    pcibImagemFuncionario.ImageLocation = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFuncionario.");
                }
            }
        }

        private void dtFuncionario_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistrosFuncionario.Text = "Registros: " + dtFuncionario.Rows.Count;
        }

        private void dtFuncionario_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFuncionario.DataSource == null)
            {
                btnExcluirFuncionario.Enabled = false;
                dtFuncionario.Enabled = false;
                pcibImagemFuncionario.Image = null;
                pcibImagemFuncionario.Enabled = false;
            }
            else
            {
                pcibImagemFuncionario.Enabled = true;
                btnExcluirFuncionario.Enabled = true;
                dtFuncionario.Enabled = true;
            }
        }

        private void dtFuncionario_MouseMove(object sender, MouseEventArgs e)
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

        private void dtFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblLegendaImagemFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Formulario != 1)
            {
                lblLegendaImagemFuncionario.ForeColor = Color.Red;
                lblLegendaImagemFuncionario.Font = new Font(lblLegendaImagemFuncionario.Font.Name, lblLegendaImagemFuncionario.Font.SizeInPoints, FontStyle.Underline);
                if (dtFuncionario.DataSource != null)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void pcibImagemFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Formulario != 1)
            {
                lblLegendaImagemFuncionario.ForeColor = Color.Red;
                lblLegendaImagemFuncionario.Font = new Font(lblLegendaImagemFuncionario.Font.Name, lblLegendaImagemFuncionario.Font.SizeInPoints, FontStyle.Underline);
                if (dtFuncionario.DataSource != null)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void lblLegendaImagemFuncionario_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagemFuncionario.ForeColor = Color.Black;
            lblLegendaImagemFuncionario.Font = new Font(lblLegendaImagemFuncionario.Font.Name, lblLegendaImagemFuncionario.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void pcibImagemFuncionario_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagemFuncionario.ForeColor = Color.Black;
            lblLegendaImagemFuncionario.Font = new Font(lblLegendaImagemFuncionario.Font.Name, lblLegendaImagemFuncionario.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalServicos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalServicos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalOS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalOS_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            try
            {
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (cbbClieConsFunc.Text == "" || mtxtData.Text.Trim() == "" || mtxtHorario.Text.Trim() == "" || txtDescItemEquip.Text.Trim() == "" || dtServico.Rows.Count == 0)
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Cliente/Consumidor ], [ Data e Horário de Criação ],\n[ Descrição do Item ] e [ Tabela de Serviços ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        cbbClieConsFunc.Select();
                    }
                    else if (Convert.ToDecimal(lblValorTotalOS.Text) == 0)
                    {
                        MessageBox.Show("Os serviços e/ou produtos informados não podem ter valor zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbClieConsFunc.Select();
                    }
                    else
                    {
                        btnSalvar.Select();
                        mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (_Comando_Atualizar == true)
                        {
                            if (bllOS.Sel_OS_Ainda_Existe(_Codigo) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllOS._Nome_Arquivo = null;
                                bllOS._Url_Imagem = null;
                                pcibImagem.Image = null;
                                lblLegendaImagem.Visible = false;
                                _Comando_Atualizar = false;
                            }
                            else
                            {
                                bllOS.Alterar(_Codigo, cbbClieConsFunc.Text, mtxtData.Text, mtxtHorario.Text, mtxtDataConclusao.Text, mtxtHorarioConclusao.Text, txtDescricao.Text, txtDescItemEquip.Text, txtMarca.Text, txtModelo.Text, txtNSerie.Text, txtObservacao.Text, _Cod_PDV_Computador, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblTotalOS.Text, lblValorDesconto.Text, lblValorAcrescimo.Text);
                                //
                                if (_Contem_Imagem == true)
                                {
                                    if (bllOS._Url_Imagem != null)
                                    {
                                        bllOS.Alterar_Imagem_Os(_Codigo, bllOS._Url_Imagem);
                                    }
                                }
                                else
                                {
                                    bllOS.Alterar_Imagem_Os(_Codigo, bllOS._Url_Imagem);
                                }
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA ORDEM DE SERVICO", "ORDEM DE SERVICO", _Codigo, _Usuario, _Cod_PDV_Computador);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Ordem de Serviço Alterar. Cod: " + _Codigo);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Ordem de Serviço Alterar. Cod: " + _Codigo);
                                }
                                //
                                bllOS._Nome_Arquivo = null;
                                bllOS._Url_Imagem = null;
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        else
                        {
                            bllOS.Salvar(cbbClieConsFunc.Text, mtxtData.Text, mtxtHorario.Text, mtxtDataConclusao.Text, mtxtHorarioConclusao.Text, txtDescricao.Text, txtDescItemEquip.Text, txtMarca.Text, txtModelo.Text, txtNSerie.Text, txtObservacao.Text, bllOS._Url_Imagem, _Cod_PDV_Computador, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblTotalOS.Text, _Usuario, lblValorDesconto.Text, lblValorAcrescimo.Text);
                            //
                            string codigo = bllOS.Sel_Ultimo_Cod_OS_Adicionado();
                            //
                            bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA ORDEM DE SERVICO", "ORDEM DE SERVICO", codigo, _Usuario, _Cod_PDV_Computador);
                            //
                            DataRow dr;
                            if (bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao) != null)
                            {
                                for (int i = 0; i < bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao).Rows[i];
                                    //
                                    bllOS.Salvar_Items_Servico_Con(dr["id_item"].ToString(), dr["id_servico"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), codigo, dr["quantidade"].ToString(), dr["comissao_porc"].ToString(), dr["valor_desconto"].ToString(), dr["valor_acrescimo"].ToString(), dr["valor_total_a_desc_acresc"].ToString(), dr["id_orcamento"].ToString());
                                    //
                                    if (dr["id_orcamento"].ToString() != "0")
                                    {
                                        bllOrcamento.Alterar_Situacao_Orcamento(dr["id_orcamento"].ToString(), "REALIZADO");
                                    }
                                }
                            }
                            //
                            if (bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao) != null)
                            {
                                for (int i = 0; i < bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao).Rows[i];
                                    //
                                    bllOS.Salvar_Items_OS_Produto_Con(dr["id_item"].ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), dr["um"].ToString(), dr["quantidade"].ToString(), dr["valor_acrescimo"].ToString(), dr["valor_desconto"].ToString(), codigo, dr["valor_total_a_desc_acresc"].ToString(), dr["id_orcamento"].ToString());
                                    //
                                    bllOS.Alterar_Estoque_Produto_OS(dr["id_produto"].ToString(), dr["quantidade"].ToString(), false);
                                    //
                                    if (dr["id_orcamento"].ToString() != "0")
                                    {
                                        bllOrcamento.Alterar_Situacao_Orcamento(dr["id_orcamento"].ToString(), "REALIZADO");
                                    }
                                }
                            }
                            //
                            if (bllOS.Sel_Item_OS_Funcionario_Temp_Todos(bllConexao._Codigo_Conexao) != null)
                            {
                                for (int i = 0; i < bllOS.Sel_Item_OS_Funcionario_Temp_Todos(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                {
                                    dr = bllOS.Sel_Item_OS_Funcionario_Temp_Todos(bllConexao._Codigo_Conexao).Rows[i];
                                    //
                                    bllOS.Salvar_Items_OS_Funcionario(dr["id_item"].ToString(), dr["id_funcionario"].ToString(), dr["nome_funcionario"].ToString(), codigo);
                                }
                            }
                            //
                            bllOS._Codigo = codigo;
                            //
                            bllOS._Nome_Arquivo = null;
                            bllOS._Url_Imagem = null;
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Ordem de Serviço cadastrada. Cod: " + codigo);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Ordem de Serviço cadastrada. Cod: " + codigo);
                            }
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            this.DialogResult = DialogResult.OK;
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllOS._Nome_Arquivo = null;
                bllOS._Url_Imagem = null;
            }
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                this.Enabled = false;
                try
                {
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 6))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllOS._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllOS._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllOS._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllOS._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataRow dr = bllOS.Sel_OS_Codigo(_Codigo).Rows[0];
                                            //
                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])dr["imagem_os"];
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + _Codigo + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllOS._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllOS._Url_Imagem;
                                //
                                if (bllOS._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllOS._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllOS._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllOS._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllOS._Url_Imagem);
                                    bllOS._Mostrar_Imagem = false;
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    //
                    pcibImagem.Image = null;
                    pcibImagem.ImageLocation = null;
                    bllOS._Url_Imagem = null;
                    bllOS._Mostrar_Imagem = false;
                    bllOS._Excluir_Imagem = false;
                }
                this.Enabled = true;
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                this.Enabled = false;
                try
                {
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 6))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllOS._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllOS._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllOS._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllOS._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataRow dr = bllOS.Sel_OS_Codigo(_Codigo).Rows[0];
                                            //
                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])dr["imagem_os"];
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + _Codigo + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllOS._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllOS._Url_Imagem;
                                //
                                if (bllOS._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllOS._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllOS._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllOS._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllOS._Url_Imagem);
                                    bllOS._Mostrar_Imagem = false;
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    //
                    pcibImagem.Image = null;
                    pcibImagem.ImageLocation = null;
                    bllOS._Url_Imagem = null;
                    bllOS._Mostrar_Imagem = false;
                    bllOS._Excluir_Imagem = false;
                }
                this.Enabled = true;
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

        private void txtConclusao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Clicando no botão [ Salvar O.S. ] você estará salvando a ordem de serviço.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void pcibInterreogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterreogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterreogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Os dados inseridos em serviços, produtos e funcionários serão salvos instantaneamente ao clicar no botão novo, independentemente de você confirmar alterações na O.S.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void tabpCadastro_Enter(object sender, EventArgs e)
        {
            btnNovoServico.Select();
        }

        private void tabpCadastro1_Enter(object sender, EventArgs e)
        {
            this.Enabled = true;
            //dtIProduto_DataSourceChanged(sender, e);
        }

        private void tabpCadastro2_Enter(object sender, EventArgs e)
        {
            btnNovoFuncionario.Select();
        }

        private void dtServico_KeyUp(object sender, KeyEventArgs e)
        {
            if (_Formulario != 1)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btnExcluirServico_Click(sender, e);
                }
            }
        }

        private void dtProduto_KeyUp(object sender, KeyEventArgs e)
        {
            if (_Formulario != 1)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btnExcluirProduto_Click(sender, e);
                }
            }
        }

        private void dtFuncionario_KeyUp(object sender, KeyEventArgs e)
        {
            if (_Formulario != 1)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btnExcluirFuncionario_Click(sender, e);
                }
            }
        }

        private void cbbClieConsFunc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbClieConsFunc.Text != "")
                {
                    string[] items = cbbClieConsFunc.Text.Split('—');

                    /*
                    if ((cbbClieConsFunc.Text.Split('—').Length - 1) == 1)
                    {
                        MessageBox.Show("Não é possível selecionar um consumidor sem [ CPF/CNPJ ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbClieConsFunc.Text = null;
                    }
                    else*/
                    if (bllClieCons.Sel_Situacao_Cliente_Bloqueado(items[0], "BLOQUEADO") == true)
                    {
                        MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbClieConsFunc.Text = null;
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbClieConsFunc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbClieConsFunc.");
                }
                cbbClieConsFunc.Text = null;
            }
        }

        private void pcibImagemFuncionario_Click(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                try
                {
                    if (_Contem_Imagem_Func == true)
                    {
                        DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                        DataRow dr = bllFuncionario.Sel_Funcionario_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])dr["imagem_func"];
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtFuncionario.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                }
            }
        }

        private void lblLegendaImagemFuncionario_Click(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                try
                {
                    if (_Contem_Imagem_Func == true)
                    {
                        DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                        DataRow dr = bllFuncionario.Sel_Funcionario_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])dr["imagem_func"];
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtFuncionario.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                }
            }
        }

        private void pcibImagemProduto_Click(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                try
                {
                    if (_Contem_Imagem_Prod == true)
                    {
                        DataGridViewRow SelectedRow = dtProduto.Rows[dtProduto.CurrentRow.Index];

                        DataRow dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])dr["imagem_prod"];
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtProduto.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                }
            }
        }

        private void lblLegendaImagemProduto_Click(object sender, EventArgs e)
        {
            if (_Formulario != 1)
            {
                try
                {
                    if (_Contem_Imagem_Prod == true)
                    {
                        DataGridViewRow SelectedRow = dtProduto.Rows[dtProduto.CurrentRow.Index];

                        DataRow dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])dr["imagem_prod"];
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtProduto.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                }
            }
        }

        private void txtDescItemEquip_DoubleClick(object sender, EventArgs e)
        {
            if (txtDescItemEquip.Text == "")
            {
                txtDescItemEquip.Text = "SERVIÇO GERAL";
            }
        }

        private void txtDescItemEquip_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (txtDescItemEquip.Text == "")
                {
                    txtDescItemEquip.Text = "SERVIÇO GERAL";
                }
            }
        }

        private void lblTotalOS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Total (R$): " + lblTotalOS.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDesconto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Desconto (R$): " + lblValorDesconto.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorAcrescimo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Acréscimo (R$): " + lblValorAcrescimo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxtHorarioConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (dtFuncionario.DataSource != null || dtServico.DataSource != null || dtProduto.DataSource != null || cbbClieConsFunc.Text != "" || txtDescItemEquip.Text != "" || txtMarca.Text != "" || txtModelo.Text != "" || txtNSerie.Text != "" || txtDescricao.Text != "" || txtObservacao.Text != "")
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                DialogResult = MessageBox.Show("Deseja capturar um novo Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    Capturar();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                Capturar();
            }
        }

        private void Capturar()
        {
            this.Enabled = false;
            try
            {
                if (bllUsuario.Sel_Capturar_Orcamento_Usuario(_Usuario) == true)
                {
                    using (FrmCapturarOrcamento Orc = new FrmCapturarOrcamento(2, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Orc.ShowDialog() == DialogResult.OK)
                        {
                            DataRow dr;
                            //
                            dr = bllOrcamento.Sel_Dados_Orcamento(bllOS._Cod_Orcamento_Cadastro).Rows[0];
                            //
                            if (cbbClieConsFunc.Text != "")
                            {
                                if (dr["id_consumidor"].ToString() != "0")
                                {
                                    MessageBox.Show("Deseja substituir o Cliente/Consumidor do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        //
                                        if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                        {
                                            if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                            {
                                                cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                            }
                                            else
                                            {
                                                cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                {
                                    if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                    {
                                        cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                    }
                                    else
                                    {
                                        cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                    }
                                }
                            }
                            //
                            if (txtObservacao.Text != "")
                            {
                                if (dr["observacao"].ToString() != "")
                                {
                                    MessageBox.Show("Deseja substituir a Observação do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        //
                                        txtObservacao.Text = dr["observacao"].ToString();
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            else
                            {
                                txtObservacao.Text = dr["observacao"].ToString();
                            }
                            //
                            if (bllOrcamento.Sel_Itens_Orcamento_Orc(bllOS._Cod_Orcamento_Cadastro) != null)
                            {
                                int item_produto = dtProduto.Rows.Count;
                                int item_servico = dtServico.Rows.Count;
                                //
                                for (int a = 0; a < bllOrcamento.Sel_Itens_Orcamento_Orc(bllOS._Cod_Orcamento_Cadastro).Rows.Count; a++)
                                {
                                    dr = bllOrcamento.Sel_Itens_Orcamento_Orc(bllOS._Cod_Orcamento_Cadastro).Rows[a];
                                    //
                                    string cod_prod = dr["id_produto"].ToString();
                                    //
                                    if (Convert.ToByte(dr["tabela"]) == 0)
                                    {
                                        if (bllProduto.Sel_Prod_Codigo(cod_prod, "") == null)
                                        {
                                            MessageBox.Show("Código de Produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            item_produto = item_produto + 1;
                                            //
                                            if (_Comando_Atualizar == false)
                                            {
                                                bllOS.Salvar_Items_OS_Produto_Valor_Desc_Acresc_Temp(item_produto.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), dr["um"].ToString(), dr["quantidade"].ToString(), dr["valor_acrescimo_item"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_total_a_desc_acresc"].ToString(), bllConexao._Codigo_Conexao, bllOS._Cod_Orcamento_Cadastro);
                                            }
                                            else
                                            {
                                                bllOS.Salvar_Items_OS_Produto_Valor_Desc_Acresc(item_produto.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), dr["um"].ToString(), dr["quantidade"].ToString(), dr["valor_acrescimo_item"].ToString(), dr["valor_desconto_item"].ToString(), _Codigo, bllOS._Cod_Orcamento_Cadastro, dr["valor_total_a_desc_acresc"].ToString());
                                                //
                                                bllOS.Alterar_Estoque_Produto_OS(dr["id_produto"].ToString(), dr["quantidade"].ToString(), false);
                                            }
                                        }
                                    }
                                    else if (Convert.ToByte(dr["tabela"]) == 1)
                                    {
                                        if (bllServico.Sel_Servico_Codigo(cod_prod, "") == null)
                                        {
                                            MessageBox.Show("Código de Serviço informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            item_servico = item_servico + 1;
                                            //
                                            DataRow dr1 = bllServico.Sel_Servico_Codigo(dr["id_produto"].ToString(), "").Rows[0];
                                            //
                                            if (_Comando_Atualizar == false)
                                            {
                                                bllOS.Salvar_Items_Servico_Valor_Desc_Acresc_Temp(item_servico.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), bllConexao._Codigo_Conexao, dr["quantidade"].ToString(), dr1["comissao"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), dr["valor_total_a_desc_acresc"].ToString(), bllOS._Cod_Orcamento_Cadastro);
                                            }
                                            else
                                            {
                                                bllOS.Salvar_Items_Servico_Valor_Desc_Acresc(item_servico.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), _Codigo, dr["quantidade"].ToString(), dr1["comissao"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), bllOS._Cod_Orcamento_Cadastro, dr["valor_total_a_desc_acresc"].ToString());
                                            }
                                        }
                                    }
                                }
                                //
                                if (_Comando_Atualizar == false)
                                {
                                    if (bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao) == null)
                                    {
                                        bllOS.Excluir_Item_OS_Produto_Todos_Temp(bllConexao._Codigo_Conexao);
                                        MessageBox.Show("O Orçamento informado não possui Serviços informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                        this.Enabled = true;
                                        Limpar();
                                        return;
                                    }
                                    else
                                    {
                                        if (bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao) != null)
                                        {
                                            tabcCadastro.SelectedTab = tabpCadastro1;
                                            //
                                            dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao);
                                            //
                                            dtProduto.Select();
                                            //
                                            dtProduto.CurrentCell = dtProduto.Rows[dtProduto.Rows.Count - 1].Cells[0];
                                            //
                                            dtProduto.Rows[dtProduto.Rows.Count - 1].Selected = true;
                                            //
                                            dtProduto.FirstDisplayedScrollingRowIndex = dtProduto.Rows.Count - 1;
                                        }
                                        else
                                        {
                                            dtProduto.DataSource = null;
                                        }
                                        //
                                        dtServico.DataSource = bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao);
                                    }
                                }
                                else
                                {
                                    if (bllOS.Sel_Item_Servico_Todos(_Codigo) == null)
                                    {
                                        MessageBox.Show("O Orçamento informado não possui Serviços informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                        this.Enabled = true;
                                        Limpar();
                                        return;
                                    }
                                    else
                                    {
                                        if (bllOS.Sel_Item_OS_Produto_Todos(_Codigo) != null)
                                        {
                                            tabcCadastro.SelectedTab = tabpCadastro1;
                                            //
                                            dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Todos(_Codigo);
                                            //
                                            dtProduto.Select();
                                            //
                                            dtProduto.CurrentCell = dtProduto.Rows[dtProduto.Rows.Count - 1].Cells[0];
                                            //
                                            dtProduto.Rows[dtProduto.Rows.Count - 1].Selected = true;
                                            //
                                            dtProduto.FirstDisplayedScrollingRowIndex = dtProduto.Rows.Count - 1;
                                        }
                                        else
                                        {
                                            dtProduto.DataSource = null;
                                        }
                                        //
                                        dtServico.DataSource = bllOS.Sel_Item_Servico_Todos(_Codigo);
                                        //
                                        bllOS.Alterar_OS_Valores(_Codigo, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblValorTotalOS.Text);
                                    }
                                    //
                                    bllOrcamento.Alterar_Situacao_Orcamento(bllOS._Cod_Orcamento_Cadastro, "REALIZADO");
                                }
                            }
                            //
                            tabcCadastro.SelectedTab = tabpCadastro;
                            //
                            dtServico.Select();
                            //
                            dtServico.CurrentCell = dtServico.Rows[dtServico.Rows.Count - 1].Cells[0];
                            //
                            dtServico.Rows[dtServico.Rows.Count - 1].Selected = true;
                            //
                            dtServico.FirstDisplayedScrollingRowIndex = dtServico.Rows.Count - 1;
                        }
                    }
                }
                else
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Capturar_Orcamento"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Capturar_Orcamento == 1)
                            {
                                using (FrmCapturarOrcamento Orc = new FrmCapturarOrcamento(2, _Usuario, _Cod_PDV_Computador))
                                {
                                    if (Orc.ShowDialog() == DialogResult.OK)
                                    {
                                        DataRow dr;
                                        //
                                        dr = bllOrcamento.Sel_Dados_Orcamento(bllOS._Cod_Orcamento_Cadastro).Rows[0];
                                        //
                                        if (cbbClieConsFunc.Text != "")
                                        {
                                            if (dr["id_consumidor"].ToString() != "0")
                                            {
                                                MessageBox.Show("Deseja substituir o Cliente/Consumidor do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (DialogResult == DialogResult.Yes)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    //
                                                    if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                                    {
                                                        if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                                        {
                                                            cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                                        }
                                                        else
                                                        {
                                                            cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                            {
                                                if (dr["cpf_cnpj_consumidor"].ToString() == "")
                                                {
                                                    cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString();
                                                }
                                                else
                                                {
                                                    cbbClieConsFunc.Text = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                                }
                                            }
                                        }
                                        //
                                        if (txtObservacao.Text != "")
                                        {
                                            if (dr["observacao"].ToString() != "")
                                            {
                                                MessageBox.Show("Deseja substituir a Observação do Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (DialogResult == DialogResult.Yes)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    //
                                                    txtObservacao.Text = dr["observacao"].ToString();
                                                }
                                                else
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            txtObservacao.Text = dr["observacao"].ToString();
                                        }
                                        //
                                        if (bllOrcamento.Sel_Itens_Orcamento_Orc(bllOS._Cod_Orcamento_Cadastro) != null)
                                        {
                                            int item_produto = dtProduto.Rows.Count;
                                            int item_servico = dtServico.Rows.Count;

                                            for (int a = 0; a < bllOrcamento.Sel_Itens_Orcamento_Orc(bllOS._Cod_Orcamento_Cadastro).Rows.Count; a++)
                                            {
                                                dr = bllOrcamento.Sel_Itens_Orcamento_Orc(bllOS._Cod_Orcamento_Cadastro).Rows[a];
                                                //
                                                string cod_prod = dr["id_produto"].ToString();
                                                //
                                                if (Convert.ToByte(dr["tabela"]) == 0)
                                                {
                                                    if (bllProduto.Sel_Prod_Codigo(cod_prod, "") == null)
                                                    {
                                                        MessageBox.Show("Código de Produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        this.DialogResult = DialogResult.None;
                                                    }
                                                    else
                                                    {
                                                        item_produto = item_produto + 1;
                                                        //
                                                        if (_Comando_Atualizar == false)
                                                        {
                                                            bllOS.Salvar_Items_OS_Produto_Valor_Desc_Acresc_Temp(item_produto.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), dr["um"].ToString(), dr["quantidade"].ToString(), dr["valor_acrescimo_item"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_total_a_desc_acresc"].ToString(), bllConexao._Codigo_Conexao, bllOS._Cod_Orcamento_Cadastro);
                                                        }
                                                        else
                                                        {
                                                            bllOS.Salvar_Items_OS_Produto_Valor_Desc_Acresc(item_produto.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), dr["um"].ToString(), dr["quantidade"].ToString(), dr["valor_acrescimo_item"].ToString(), dr["valor_desconto_item"].ToString(), _Codigo, bllOS._Cod_Orcamento_Cadastro, dr["valor_total_a_desc_acresc"].ToString());
                                                            //
                                                            bllOS.Alterar_Estoque_Produto_OS(dr["id_produto"].ToString(), dr["quantidade"].ToString(), false);
                                                        }
                                                    }
                                                }
                                                else if (Convert.ToByte(dr["tabela"]) == 1)
                                                {
                                                    if (bllServico.Sel_Servico_Codigo(cod_prod, "") == null)
                                                    {
                                                        MessageBox.Show("Código de Serviço informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        this.DialogResult = DialogResult.None;
                                                    }
                                                    else
                                                    {
                                                        item_servico = item_servico + 1;
                                                        //
                                                        DataRow dr1 = bllServico.Sel_Servico_Codigo(dr["id_produto"].ToString(), "").Rows[0];
                                                        //
                                                        if (_Comando_Atualizar == false)
                                                        {
                                                            bllOS.Salvar_Items_Servico_Valor_Desc_Acresc_Temp(item_servico.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), bllConexao._Codigo_Conexao, dr["quantidade"].ToString(), dr1["comissao"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), dr["valor_total_a_desc_acresc"].ToString(), bllOS._Cod_Orcamento_Cadastro);
                                                        }
                                                        else
                                                        {
                                                            bllOS.Salvar_Items_Servico_Valor_Desc_Acresc(item_servico.ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), _Codigo, dr["quantidade"].ToString(), dr1["comissao"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_acrescimo_item"].ToString(), bllOS._Cod_Orcamento_Cadastro, dr["valor_total_a_desc_acresc"].ToString());
                                                        }
                                                    }
                                                }
                                            }
                                            //
                                            if (_Comando_Atualizar == false)
                                            {
                                                if (bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao) == null)
                                                {
                                                    bllOS.Excluir_Item_OS_Produto_Todos_Temp(bllConexao._Codigo_Conexao);
                                                    MessageBox.Show("O Orçamento informado não possui Serviços informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    this.DialogResult = DialogResult.None;
                                                    this.Enabled = true;
                                                    Limpar();
                                                    return;
                                                }
                                                else
                                                {
                                                    if (bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao) != null)
                                                    {
                                                        tabcCadastro.SelectedTab = tabpCadastro1;
                                                        //
                                                        dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Temp_Todos(bllConexao._Codigo_Conexao);
                                                        //
                                                        dtProduto.Select();
                                                        //
                                                        dtProduto.CurrentCell = dtProduto.Rows[dtProduto.Rows.Count - 1].Cells[0];
                                                        //
                                                        dtProduto.Rows[dtProduto.Rows.Count - 1].Selected = true;
                                                        //
                                                        dtProduto.FirstDisplayedScrollingRowIndex = dtProduto.Rows.Count - 1;
                                                    }
                                                    else
                                                    {
                                                        dtProduto.DataSource = null;
                                                    }
                                                    //
                                                    dtServico.DataSource = bllOS.Sel_Item_Servico_Temp_Todos(bllConexao._Codigo_Conexao);
                                                }
                                            }
                                            else
                                            {
                                                if (bllOS.Sel_Item_Servico_Todos(_Codigo) == null)
                                                {
                                                    MessageBox.Show("O Orçamento informado não possui Serviços informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    this.DialogResult = DialogResult.None;
                                                    this.Enabled = true;
                                                    Limpar();
                                                    return;
                                                }
                                                else
                                                {
                                                    if (bllOS.Sel_Item_OS_Produto_Todos(_Codigo) != null)
                                                    {
                                                        tabcCadastro.SelectedTab = tabpCadastro1;
                                                        //
                                                        dtProduto.DataSource = bllOS.Sel_Item_OS_Produto_Todos(_Codigo);
                                                        //
                                                        dtProduto.Select();
                                                        //
                                                        dtProduto.CurrentCell = dtProduto.Rows[dtProduto.Rows.Count - 1].Cells[0];
                                                        //
                                                        dtProduto.Rows[dtProduto.Rows.Count - 1].Selected = true;
                                                        //
                                                        dtProduto.FirstDisplayedScrollingRowIndex = dtProduto.Rows.Count - 1;
                                                    }
                                                    else
                                                    {
                                                        dtProduto.DataSource = null;
                                                    }
                                                    //
                                                    dtServico.DataSource = bllOS.Sel_Item_Servico_Todos(_Codigo);
                                                    //
                                                    bllOS.Alterar_OS_Valores(_Codigo, lblValorTotalOS.Text, lblValorTotalServicos.Text, lblValorTotalProdutos.Text, lblValorTotalOS.Text);
                                                }
                                                //
                                                bllOrcamento.Alterar_Situacao_Orcamento(bllOS._Cod_Orcamento_Cadastro, "REALIZADO");
                                            }
                                        }
                                        //
                                        tabcCadastro.SelectedTab = tabpCadastro;
                                        //
                                        dtServico.Select();
                                        //
                                        dtServico.CurrentCell = dtServico.Rows[dtServico.Rows.Count - 1].Cells[0];
                                        //
                                        dtServico.Rows[dtServico.Rows.Count - 1].Selected = true;
                                        //
                                        dtServico.FirstDisplayedScrollingRowIndex = dtServico.Rows.Count - 1;
                                    }
                                }
                            }
                            else if (bllVenda._Capturar_Orcamento == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para capturar Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnOrcamento.");
                }
            }
            this.Enabled = true;
        }

        private void dtServico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_Comando_Atualizar == false)
            {
                if (e.ColumnIndex == 10 && e.Value.ToString() == "0")
                {
                    e.Value = "";
                }
            }
            else
            {
                if (e.ColumnIndex == 11 && e.Value.ToString() == "0")
                {
                    e.Value = "";
                }
            }
        }

        private void dtProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_Comando_Atualizar != false)
            {
                if (e.ColumnIndex == 11 && e.Value.ToString() == "0")
                {
                    e.Value = "";
                }
            }
            else
            {
                if (e.ColumnIndex == 10 && e.Value.ToString() == "0")
                {
                    e.Value = "";
                }
            }
        }
    }
}
