using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadTransportadora : Form
    {
        public FrmCadTransportadora(byte formulario, string cod_dfe, byte importado, bool proprio, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Cod_DFe = cod_dfe;
            //
            if (importado == 0)
            {
                _Importado = false;
            }
            else
            {
                _Importado = true;
            }
            //
            if (proprio == true)
            {
                _Importado = true;
            }
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;

        }

        private bool _Comando_Atualizar;
        private string _Cod_DFe;
        private bool _Importado;
        private byte _Formulario;
        private string _Cod_PDV_Computador;
        private string _Usuario;

        private void FrmCadTransportadora_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadTransportadora iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadTransportadora iniciado.");
                }
                //
                cbbFornecedor.Items.Clear();
                if (bllDFe.Sel_Fornecedor_DFe() == null)
                {
                    cbbFornecedor.Text = null;
                }
                else
                {
                    cbbFornecedor.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                    {
                        cbbFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //
                if (_Formulario == 0)
                {
                    if (bllTransportador.Sel_Dados_Transportador(_Cod_DFe) != null)
                    {
                        DataRow dr = bllTransportador.Sel_Dados_Transportador(_Cod_DFe).Rows[0];
                        //
                        if (dr["tipo_transporte"].ToString() == "PROPRIO")
                        {
                            rbtnProprio.Checked = true;
                            rbtnProprio.Select();
                        }
                        else if (dr["tipo_transporte"].ToString() == "TERCEIROS")
                        {
                            rbtnTerceiros.Checked = true;
                            rbtnTerceiros.Select();
                        }
                        else if (dr["tipo_transporte"].ToString() == "SEM TRANSPORTE")
                        {
                            rbtnSemTransporte.Checked = true;
                            rbtnSemTransporte.Select();
                        }
                        //
                        if (dr["tipo_frete"].ToString() == "DESTINATARIO")
                        {
                            rbtnFreteDestinatario.Checked = true;
                        }
                        else if (dr["tipo_frete"].ToString() == "EMITENTE")
                        {
                            rbtnFreteEmitente.Checked = true;
                        }
                        //
                        cbbFornecedor.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome_fornecedor"].ToString();
                        txtVeiculo.Text = dr["veiculo"].ToString();
                        txtCodigoANTT.Text = dr["codigo_antt"].ToString();
                        txtPlacaVeiculo.Text = dr["placa"].ToString();
                        cbbUF.Text = dr["uf"].ToString();
                        txtEspecie.Text = dr["especie"].ToString();
                        txtMarca.Text = dr["marca"].ToString();
                        txtQuantidadeEmbalagem.Text = dr["quantidade"].ToString();
                        txtNumeracao.Text = dr["numeracao"].ToString();
                        txtPesoBruto.Text = Convert.ToDecimal(dr["peso_bruto"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                        txtPesoLiquido.Text = Convert.ToDecimal(dr["peso_liquido"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                        txtValorFrete.Text = Convert.ToDecimal(dr["valor_frete"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                        //                    
                        _Comando_Atualizar = true;
                    }
                    else
                    {
                        _Comando_Atualizar = false;
                        rbtnProprio.Select();
                    }
                    //
                    if (_Importado == true)
                    {
                        grbBox5.Enabled = false;
                        grbBox6.Enabled = false;
                        txtVeiculo.ReadOnly = true;
                        txtCodigoANTT.ReadOnly = true;
                        txtPlacaVeiculo.ReadOnly = true;
                        txtEspecie.ReadOnly = true;
                        txtMarca.ReadOnly = true;
                        txtQuantidadeEmbalagem.ReadOnly = true;
                        txtNumeracao.ReadOnly = true;
                        txtPesoBruto.ReadOnly = true;
                        txtPesoLiquido.ReadOnly = true;
                        string uf = cbbUF.Text;
                        cbbUF.Items.Clear();
                        cbbUF.Items.Add(uf);
                        cbbUF.Text = uf;
                        //
                        string fornecedor = cbbFornecedor.Text;
                        cbbFornecedor.Items.Clear();
                        cbbFornecedor.Items.Add(fornecedor);
                        cbbFornecedor.Text = fornecedor;
                        btnProcurarFornecedor.Enabled = false;
                        btnSalvar.Enabled = false;
                    }
                }
                else
                {
                    if (bllTransportador.Sel_Dados_Transportador_Temp(bllConexao._Codigo_Conexao) != null)
                    {
                        DataRow dr = bllTransportador.Sel_Dados_Transportador_Temp(bllConexao._Codigo_Conexao).Rows[0];
                        //
                        if (dr["tipo_transporte"].ToString() == "PROPRIO")
                        {
                            rbtnProprio.Checked = true;
                            rbtnProprio.Select();
                        }
                        else if (dr["tipo_transporte"].ToString() == "TERCEIROS")
                        {
                            rbtnTerceiros.Checked = true;
                            rbtnTerceiros.Select();
                        }
                        else if (dr["tipo_transporte"].ToString() == "SEM TRANSPORTE")
                        {
                            rbtnSemTransporte.Checked = true;
                            rbtnSemTransporte.Select();
                        }
                        //
                        if (dr["tipo_frete"].ToString() == "DESTINATARIO")
                        {
                            rbtnFreteDestinatario.Checked = true;
                        }
                        else if (dr["tipo_frete"].ToString() == "EMITENTE")
                        {
                            rbtnFreteEmitente.Checked = true;
                        }
                        //
                        cbbFornecedor.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome_fornecedor"].ToString();
                        txtVeiculo.Text = dr["veiculo"].ToString();
                        txtCodigoANTT.Text = dr["codigo_antt"].ToString();
                        txtPlacaVeiculo.Text = dr["placa"].ToString();
                        cbbUF.Text = dr["uf"].ToString();
                        txtEspecie.Text = dr["especie"].ToString();
                        txtMarca.Text = dr["marca"].ToString();
                        txtQuantidadeEmbalagem.Text = dr["quantidade"].ToString();
                        txtNumeracao.Text = dr["numeracao"].ToString();
                        txtPesoBruto.Text = Convert.ToDecimal(dr["peso_bruto"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                        txtPesoLiquido.Text = Convert.ToDecimal(dr["peso_liquido"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                        txtValorFrete.Text = Convert.ToDecimal(dr["valor_frete"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                        //                    
                        _Comando_Atualizar = true;

                    }
                    else
                    {
                        _Comando_Atualizar = false;
                        rbtnProprio.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadTransportadora.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadTransportadora.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            cbbFornecedor.Text = null;
            txtVeiculo.Text = null;
            txtCodigoANTT.Text = null;
            txtPlacaVeiculo.Text = null;
            cbbUF.Text = null;
            txtEspecie.Text = null;
            txtMarca.Text = null;
            txtQuantidadeEmbalagem.Text = "0";
            txtNumeracao.Text = null;
            txtPesoBruto.Text = "0,00";
            txtPesoLiquido.Text = "0,00";
            txtValorFrete.Text = "0,00";
        }

        private void rbtnProprio_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnProprio_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTerceiros_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTerceiros_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnFreteEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnFreteEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnFreteDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnFreteDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnProprio_CheckedChanged(object sender, EventArgs e)
        {
            grbBox6.Enabled = true;
            grbBox2.Enabled = false;
            grbBox3.Enabled = true;
            grbBox4.Enabled = true;
            cbbFornecedor.Text = null;
            rbtnFreteDestinatario.Checked = false;
            rbtnFreteEmitente.Checked = false;
        }

        private void rbtnSemTransporte_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnSemTransporte_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFornecedor_DrawItem(object sender, DrawItemEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFornecedor_MouseLeave(object sender, EventArgs e)
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

        private void cbbUF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProduto_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(6, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFornecedor.Items.Clear();
                        if (bllDFe.Sel_Fornecedor_DFe() == null)
                        {
                            cbbFornecedor.Text = null;
                            cbbFornecedor.Enabled = false;
                            label1.Enabled = false;
                        }
                        else
                        {
                            cbbFornecedor.Enabled = true;
                            label1.Enabled = true;
                            cbbFornecedor.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                            {
                                cbbFornecedor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbFornecedor.Text = bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela;
                        bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                        cbbFornecedor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarFornecedor.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarFornecedor.");
                        }
                        cbbFornecedor.Text = null;
                        bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void cbbFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtVeiculo.Select();
            }
        }

        private void txtVeiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodigoANTT.Select();
            }
        }

        private void txtVeiculo_Enter(object sender, EventArgs e)
        {
            txtVeiculo.BackColor = Color.LightBlue;
        }

        private void txtVeiculo_Leave(object sender, EventArgs e)
        {
            if (txtVeiculo.Text.Contains(";") || txtVeiculo.Text.Contains("'") || txtVeiculo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtVeiculo.Text = null;
                txtVeiculo.Select();
            }
            txtVeiculo.BackColor = Color.White;
        }

        private void txtCodigoANTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtPlacaVeiculo.Select();
            }
        }

        private void txtCodigoANTT_Enter(object sender, EventArgs e)
        {
            txtCodigoANTT.BackColor = Color.LightBlue;
        }

        private void txtCodigoANTT_Leave(object sender, EventArgs e)
        {
            if (txtCodigoANTT.Text.Contains(";") || txtCodigoANTT.Text.Contains("'") || txtCodigoANTT.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodigoANTT.Text = null;
                txtCodigoANTT.Select();
            }
            txtCodigoANTT.BackColor = Color.White;
        }

        private void txtPlacaVeiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUF.Select();
            }
        }

        private void txtPlacaVeiculo_Enter(object sender, EventArgs e)
        {
            txtPlacaVeiculo.BackColor = Color.LightBlue;
        }

        private void txtPlacaVeiculo_Leave(object sender, EventArgs e)
        {
            if (txtPlacaVeiculo.Text.Contains(";") || txtPlacaVeiculo.Text.Contains("'") || txtPlacaVeiculo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtPlacaVeiculo.Text = null;
                txtPlacaVeiculo.Select();
            }
            txtPlacaVeiculo.BackColor = Color.White;
        }

        private void cbbUF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorFrete.Select();
            }
        }

        private void txtEspecie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMarca.Select();
            }
        }

        private void txtEspecie_Enter(object sender, EventArgs e)
        {
            txtEspecie.BackColor = Color.LightBlue;
        }

        private void txtEspecie_Leave(object sender, EventArgs e)
        {
            if (txtEspecie.Text.Contains(";") || txtEspecie.Text.Contains("'") || txtEspecie.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEspecie.Text = null;
                txtEspecie.Select();
            }
            txtEspecie.BackColor = Color.White;
        }

        private void txtQuantidadeEmbalagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQuantidadeEmbalagem.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtNumeracao.Select();
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtPesoBruto.Select();
            }
        }

        private void txtNumeracao_Enter(object sender, EventArgs e)
        {
            txtNumeracao.BackColor = Color.LightBlue;
        }

        private void txtNumeracao_Leave(object sender, EventArgs e)
        {
            if (txtNumeracao.Text.Contains(";") || txtNumeracao.Text.Contains("'") || txtNumeracao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNumeracao.Text = null;
                txtNumeracao.Select();
            }
            txtNumeracao.BackColor = Color.White;
        }

        private void txtPesoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPesoBruto.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtPesoLiquido.Select();
            }
        }

        private void txtPesoBruto_Enter(object sender, EventArgs e)
        {
            txtPesoBruto.BackColor = Color.LightBlue;
        }

        private void txtPesoBruto_Leave(object sender, EventArgs e)
        {
            if (txtPesoBruto.Text != "")
            {
                if (txtPesoBruto.Text.Contains("'") || txtPesoBruto.Text.Contains(";") || txtPesoBruto.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtPesoBruto.Text = null;
                    txtPesoBruto.Select();
                }
                else
                {
                    try
                    {
                        txtPesoBruto.Text = Convert.ToDecimal(txtPesoBruto.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPesoBruto.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPesoBruto.");
                        }
                        txtPesoBruto.Text = null;
                    }
                }
            }
            txtPesoBruto.BackColor = Color.White;
        }

        private void txtPesoLiquido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPesoLiquido.Text.Contains(",") && e.KeyChar == (char)44)
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

        private void txtPesoLiquido_Enter(object sender, EventArgs e)
        {
            txtPesoLiquido.BackColor = Color.LightBlue;
        }

        private void txtPesoLiquido_Leave(object sender, EventArgs e)
        {
            if (txtPesoLiquido.Text != "")
            {
                if (txtPesoLiquido.Text.Contains("'") || txtPesoLiquido.Text.Contains(";") || txtPesoLiquido.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtPesoLiquido.Text = null;
                    txtPesoLiquido.Select();
                }
                else
                {
                    try
                    {
                        txtPesoLiquido.Text = Convert.ToDecimal(txtPesoLiquido.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPesoLiquido.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPesoLiquido.");
                        }
                        txtPesoLiquido.Text = null;
                    }
                }
            }
            txtPesoLiquido.BackColor = Color.White;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQuantidadeEmbalagem.Select();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtMarca.Text.Contains(";") || txtMarca.Text.Contains("'") || txtMarca.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtMarca.Text = null;
                txtMarca.Select();
            }
            txtMarca.BackColor = Color.White;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            txtMarca.BackColor = Color.LightBlue;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void rbtnTerceiros_CheckedChanged(object sender, EventArgs e)
        {
            grbBox6.Enabled = true;
            grbBox2.Enabled = true;
            grbBox3.Enabled = true;
            grbBox4.Enabled = true;
            rbtnFreteDestinatario.Checked = false;
            rbtnFreteEmitente.Checked = true;
        }

        private void rbtnSemTransporte_CheckedChanged(object sender, EventArgs e)
        {
            grbBox6.Enabled = false;
            grbBox2.Enabled = false;
            grbBox3.Enabled = false;
            grbBox4.Enabled = false;
            rbtnFreteDestinatario.Checked = false;
            rbtnFreteEmitente.Checked = false;
            Limpar();
        }

        private void FrmCadTransportadora_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
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
                    //
                    string dados_transporte = null;
                    string dados_frete = null;
                    //
                    foreach (RadioButton r in grbBox5.Controls)
                    {
                        if (r.Checked)
                            dados_transporte = r.Text;
                    }
                    //
                    foreach (RadioButton r in grbBox6.Controls)
                    {
                        if (r.Checked)
                            dados_frete = r.Text;
                    }

                    if (_Formulario == 0)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            bllTransportador.Alterar(_Cod_DFe, dados_transporte, dados_frete, cbbFornecedor.Text, txtVeiculo.Text.Trim(), txtCodigoANTT.Text.Trim(), txtPlacaVeiculo.Text.Trim(), cbbUF.Text, txtEspecie.Text, txtMarca.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtNumeracao.Text.Trim(), txtPesoBruto.Text.Trim(), txtPesoLiquido.Text.Trim(), txtValorFrete.Text);
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bllTransportador.Salvar(dados_transporte, dados_frete, cbbFornecedor.Text, txtVeiculo.Text.Trim(), txtCodigoANTT.Text.Trim(), txtPlacaVeiculo.Text.Trim(), cbbUF.Text, txtEspecie.Text, txtMarca.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtNumeracao.Text.Trim(), txtPesoBruto.Text.Trim(), txtPesoLiquido.Text.Trim(), _Cod_DFe, txtValorFrete.Text);
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            bllTransportador.Alterar_Temp(bllConexao._Codigo_Conexao, dados_transporte, dados_frete, cbbFornecedor.Text, txtVeiculo.Text.Trim(), txtCodigoANTT.Text.Trim(), txtPlacaVeiculo.Text.Trim(), cbbUF.Text, txtEspecie.Text, txtMarca.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtNumeracao.Text.Trim(), txtPesoBruto.Text.Trim(), txtPesoLiquido.Text.Trim(), txtValorFrete.Text);
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bllTransportador.Salvar_Temp(dados_transporte, dados_frete, cbbFornecedor.Text, txtVeiculo.Text.Trim(), txtCodigoANTT.Text.Trim(), txtPlacaVeiculo.Text.Trim(), cbbUF.Text, txtEspecie.Text, txtMarca.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtNumeracao.Text.Trim(), txtPesoBruto.Text.Trim(), txtPesoLiquido.Text.Trim(), bllConexao._Codigo_Conexao, txtValorFrete.Text);
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    this.DialogResult = DialogResult.OK;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                Limpar();
                rbtnProprio.Enabled = false;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere os dados.\n\n1 - Ao finalizar o preenchimento dos campos clique no botão [ Salvar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtQuantidadeEmbalagem_Enter(object sender, EventArgs e)
        {
            txtQuantidadeEmbalagem.BackColor = Color.LightBlue;
        }

        private void txtQuantidadeEmbalagem_Leave(object sender, EventArgs e)
        {
            if (txtQuantidadeEmbalagem.Text.Contains(";") || txtQuantidadeEmbalagem.Text.Contains("'") || txtQuantidadeEmbalagem.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtQuantidadeEmbalagem.Text = null;
                txtQuantidadeEmbalagem.Select();
            }
            txtQuantidadeEmbalagem.BackColor = Color.White;
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
                txtEspecie.Select();
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
    }
}
