using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadPSPPIX : Form
    {
        public FrmCadPSPPIX(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmCadPSPPIX_Load(object sender, EventArgs e)
        {
            try
            {
                bllPSP._FrmCadPSPPIX_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadPSPPIX iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadPSPPIX iniciado.");
                }
                //
                rbtnPSP.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadPSPPIX.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadPSPPIX.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            cbbNomePSP.Text = null;
            txtChavePIX.Text = null;
            cbbTipoChave.Text = null;
            txtAcessToken.Text = null;
            cbbAmbiente.Text = null;
            txtTimeout.Text = null;
            txtNome.Text = null;
            cbbUF.Text = null;
            cbbCidade.Text = null;
            cbbCidade.Items.Clear();
            mtxtCEP.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            txtCodigo.Enabled = false;
            lblCodigo.Enabled = false;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtPSP.DataSource != null)
            {
                dtPSP.Enabled = true;
                dtPSP.Select();
            }
        }

        private void rbtnPSP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPSP_MouseLeave(object sender, EventArgs e)
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

        private void rbtnPIX_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPIX_MouseLeave(object sender, EventArgs e)
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

        private void btnGerarPIXCopiaCola_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerarPIXCopiaCola_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbNomePSP_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbNomePSP_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbNomePSP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbNomePSP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbAmbiente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbAmbiente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbAmbiente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbAmbiente_MouseLeave(object sender, EventArgs e)
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

        private void cbbCidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadPSPPIX_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllPSP._FrmCadPSPPIX_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadPSPPIX foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadPSPPIX foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadPSPPIX.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadPSPPIX.");
                }
            }
        }

        private void FrmCadPSPPIX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnPSP_CheckedChanged(object sender, EventArgs e)
        {
            cbbpPSP.Visible = true;
            lblPesquisar.Text = "Escolha o PSP:";
            lblPesquisar.Location = new Point(223, 21);
            txtpCodigo.Visible = false;
            cbbpTipoChave.Visible = false;
            cbbpPSP.Text = null;
            cbbpPSP.Select();
        }

        private void rbtnPIX_CheckedChanged(object sender, EventArgs e)
        {
            cbbpPSP.Visible = false;
            lblPesquisar.Text = "Escolha o tipo de chave pix:";
            lblPesquisar.Location = new Point(324, 21);
            txtpCodigo.Visible = false;
            cbbpTipoChave.Visible = true;
            cbbpTipoChave.Text = null;
            cbbpTipoChave.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpPSP.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(469, 21);
            txtpCodigo.Visible = true;
            cbbpTipoChave.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbbpPSP.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(480, 21);
            txtpCodigo.Visible = false;
            cbbpTipoChave.Visible = false;
            btnPesquisar.Select();
        }
        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void cbbpPSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por PSP, código, tipo de chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtPSP.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtPSP.Enabled = false;
                grbBox1.Enabled = false;
                grbBox2.Enabled = true;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                cbbNomePSP.Select();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = true;
                Limpar();
                txtTimeout.Text = "90000";
                //
                DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                //
                txtNome.Text = dr["nome"].ToString();
                //
                cbbUF.Text = dr["uf"].ToString();
                //
                cbbCidade.Text = dr["cidade"].ToString();
                //
                mtxtCEP.Text = dr["cep"].ToString();
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
                dtPSP.DataSource = null;
                rbtnPSP.Checked = true;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void txtChavePIX_Enter(object sender, EventArgs e)
        {
            txtChavePIX.BackColor = Color.LightBlue;
        }

        private void txtAcessToken_Enter(object sender, EventArgs e)
        {
            txtAcessToken.BackColor = Color.LightBlue;
        }

        private void txtTimeout_Enter(object sender, EventArgs e)
        {
            txtTimeout.BackColor = Color.LightBlue;
        }

        private void grbBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtAcessToken_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbAmbiente.Select();
            }
        }

        private void cbbAmbiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTimeout.Select();
            }
        }

        private void txtTimeout_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
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
                btnSalvar.Select();
            }
        }

        private void mtxtCEP_Enter(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.LightBlue;
        }

        private void cbbNomePSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtChavePIX.Select();
            }
        }

        private void txtChavePIX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoChave.Select();
            }
        }

        private void cbbTipoChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAcessToken.Select();
            }
        }

        private void cbbTipoChave_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoChave_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllPSP.Sel_PSP_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtPSP.Select();
                }
                else
                {
                    dtPSP.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = true;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    txtCodigo.Enabled = true;
                    lblCodigo.Enabled = true;
                    grbBox1.Enabled = false;
                    dtPSP.Enabled = false;
                    txtCodigo.Enabled = true;
                    cbbNomePSP.Select();
                    _Comando_Atualizar = true;
                    _Inserir_Atualizar = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtPSP.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnPIX.Checked = true;
            }
        }

        private void txtChavePIX_Leave(object sender, EventArgs e)
        {
            if (txtChavePIX.Text.Contains("'") || txtChavePIX.Text.Contains(";") || txtChavePIX.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChavePIX.Text = null;
                txtChavePIX.Select();
            }
            else
            {
                try
                {
                    if (txtChavePIX.Text != "")
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllPSP.Sel_Chave_Pix_Alt(txtCodigo.Text, txtChavePIX.Text) == true)
                                {
                                    MessageBox.Show("A Chave PIX informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtChavePIX.Text = null;
                                    txtChavePIX.Select();
                                }
                            }
                            else
                            {
                                if (bllPSP.Sel_Chave_Pix(txtChavePIX.Text) == true)
                                {
                                    MessageBox.Show("A Chave PIX informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtChavePIX.Text = null;
                                    txtChavePIX.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtChavePIX.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtChavePIX.");
                    }
                    txtChavePIX.Text = null;
                }
            }
            //
            txtChavePIX.BackColor = Color.White;
            //
            cbbTipoChave_SelectedIndexChanged(sender, e);
        }

        private void txtAcessToken_Leave(object sender, EventArgs e)
        {
            if (txtAcessToken.Text.Contains("'") || txtChavePIX.Text.Contains(";"))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAcessToken.Text = null;
                txtAcessToken.Select();
            }
            txtAcessToken.BackColor = Color.White;
        }

        private void txtTimeout_Leave(object sender, EventArgs e)
        {
            if (txtTimeout.Text.Contains("'") || txtTimeout.Text.Contains(";") || txtTimeout.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimeout.Text = null;
                txtTimeout.Select();
            }
            txtTimeout.BackColor = Color.White;
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

        private void mtxtCEP_Leave(object sender, EventArgs e)
        {
            mtxtCEP.BackColor = Color.White;
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
                if (dtPSP.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;

                }
            }
            _Inserir_Atualizar = false;
            ModoPesquisa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cbbTipoChave_SelectedIndexChanged(sender, e);
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (cbbNomePSP.Text.Trim() == "" || txtChavePIX.Text == "" || cbbTipoChave.Text == "" || cbbAmbiente.Text == "" || cbbAmbiente.Text == "" || txtNome.Text == "" || cbbUF.Text == "" || cbbCidade.Text == "" || mtxtCEP.Text == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\rCampo: [ Descrição ], [ Chave PIX ], [ Tipo de Chave ],\n[Ambiente ], [ Timeout ],\n[ Nome do Recebedor ], [ UF ], [ Cidade ]\ne [ CEP ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllPSP.Sel_PSP_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtPSP.DataSource = null;
                                rbtnCodigo.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                            }
                            else
                            {
                                bllPSP.Alterar(txtCodigo.Text, cbbNomePSP.Text, cbbTipoChave.Text, txtAcessToken.Text, cbbAmbiente.Text, txtTimeout.Text, txtNome.Text, cbbUF.Text, cbbCidade.Text, mtxtCEP.Text, txtChavePIX.Text);

                                dtPSP.DataSource = bllPSP.Sel_PSP_A_Alt(txtCodigo.Text);

                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM PSP/PIX", "PSP/PIX", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - PSP/PIX alteradp. Cod: " + txtCodigo.Text + " | Nome: " + cbbNomePSP.Text);
                                }

                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - PSP/PIX alteradp. Cod: " + txtCodigo.Text + " | Nome: " + cbbNomePSP.Text);
                                }
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                //
                                ModoPesquisa();
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            bllPSP.Salvar(cbbNomePSP.Text, cbbTipoChave.Text, txtAcessToken.Text, cbbAmbiente.Text, txtTimeout.Text, txtNome.Text, cbbUF.Text, cbbCidade.Text, mtxtCEP.Text, txtChavePIX.Text);

                            dtPSP.DataSource = bllPSP.Sel_PSP_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UM PSP/PIX", "PSP/PIX", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - PSP/PIX cadastrado. Cod: " + txtCodigo.Text + " | Nome: " + cbbNomePSP.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - PSP/PIX cadastrado. Cod: " + txtCodigo.Text + " | Nome: " + cbbNomePSP.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            ModoPesquisa();
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                        dtPSP.DataSource = null;
                        Limpar();
                        ModoPesquisa();
                        rbtnPSP.Checked = true;
                    }
                }
            }
            else
            {
                cbbNomePSP.Select();
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
                            cbbCidade.Items.Add(items[0]);
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

        private void dtPSP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtPSP.Columns[0].HeaderText = "Código";
            dtPSP.Columns[1].HeaderText = "Nome PSP";
            dtPSP.Columns[2].HeaderText = "Chave PIX";
            dtPSP.Columns[3].HeaderText = "Tipo de Chave";
            dtPSP.Columns[4].HeaderText = "Nome do Recebedor";
            dtPSP.Columns[5].HeaderText = "UF";
            dtPSP.Columns[6].HeaderText = "Cidade";
            dtPSP.Columns[7].HeaderText = "CEP";
            dtPSP.Columns[8].HeaderText = "Acess Token";
            dtPSP.Columns[9].HeaderText = "Timeout";
            dtPSP.Columns[10].HeaderText = "Ambiente";
            dtPSP.Columns[11].Visible = false;
            dtPSP.Columns[12].Visible = false;

            dtPSP.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPSP.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtPSP.DefaultCellStyle.Font = new Font(dtPSP.Font, FontStyle.Bold);

            dtPSP.Columns[0].Width = 95;
            dtPSP.Columns[1].Width = 185;
            dtPSP.Columns[2].Width = 280;
            dtPSP.Columns[3].Width = 150;
            dtPSP.Columns[4].Width = 280;
            dtPSP.Columns[5].Width = 55;
            dtPSP.Columns[6].Width = 280;
            dtPSP.Columns[7].Width = 76;
            dtPSP.Columns[8].Width = 250;
            dtPSP.Columns[9].Width = 100;
            dtPSP.Columns[10].Width = 150;

            lblRegistros.Text = "Registros: " + dtPSP.Rows.Count;
        }

        private void dtPSP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtPSP.Rows[dtPSP.CurrentRow.Index];

                dtPSP.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtPSP.DefaultCellStyle.SelectionForeColor = Color.Black;

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                cbbNomePSP.Text = SelectedRow.Cells[1].Value.ToString();
                txtChavePIX.Text = SelectedRow.Cells[2].Value.ToString();
                cbbTipoChave.Text = SelectedRow.Cells[3].Value.ToString();
                txtNome.Text = SelectedRow.Cells[4].Value.ToString();
                cbbUF.Text = SelectedRow.Cells[5].Value.ToString();
                cbbCidade.Text = SelectedRow.Cells[6].Value.ToString();
                mtxtCEP.Text = SelectedRow.Cells[7].Value.ToString();
                txtAcessToken.Text = SelectedRow.Cells[8].Value.ToString();
                txtTimeout.Text = SelectedRow.Cells[9].Value.ToString();
                cbbAmbiente.Text = SelectedRow.Cells[10].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtPSP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtPSP.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtPSP.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnPSP.Checked = true;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnPSP.Checked == true)
                {
                    if (cbbpPSP.Text != "")
                    {
                        if (bllPSP.Sel_PSP_Nome(cbbpPSP.Text) == null)
                        {
                            dtPSP.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtPSP.DataSource = bllPSP.Sel_PSP_Nome(cbbpPSP.Text);
                            dtPSP.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllPSP.Sel_PSP_Codigo(txtpCodigo.Text) == null)
                        {
                            dtPSP.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtPSP.DataSource = bllPSP.Sel_PSP_Codigo(txtpCodigo.Text);
                            dtPSP.Select();
                        }
                    }
                }
                else if (rbtnPIX.Checked == true)
                {
                    if (cbbpTipoChave.Text != "")
                    {
                        if (bllPSP.Sel_PSP_Tipo_Chave(cbbpTipoChave.Text) == null)
                        {
                            dtPSP.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtPSP.DataSource = bllPSP.Sel_PSP_Tipo_Chave(cbbpTipoChave.Text);
                            dtPSP.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllPSP.Sel_PSP_Todos() == null)
                    {
                        dtPSP.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtPSP.DataSource = bllPSP.Sel_PSP_Todos();
                        dtPSP.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou psp/pix.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou psp/pix.");
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtPSP.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnPSP.Checked = true;
            }
        }

        private void cbbpTipoChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void dtPSP_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPSP.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtPSP.Enabled = false;
                btnGerarPIXCopiaCola.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtPSP.Enabled = true;
                btnGerarPIXCopiaCola.Enabled = true;
            }
        }

        private void dtPSP_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtPSP.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtPSP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbNomePSP.Select();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllPSP.Sel_PSP_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtPSP.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este PSP/PIX?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        bllPSP.Excluir(txtCodigo.Text);

                        bllRegistroAtividades.Salvar("EXCLUIU UM PSP/PIX", "PSP/PIX", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - PSP/PIX excluído. Cod: " + txtCodigo.Text + " | Nome: " + cbbNomePSP.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - PSP/PIX excluído. Cod: " + txtCodigo.Text + " | Nome: " + cbbNomePSP.Text);
                        }
                        //
                        if (rbtnPSP.Checked == true)
                        {
                            if (cbbpPSP.Text != "")
                            {
                                if (bllPSP.Sel_PSP_Nome(cbbpPSP.Text) == null)
                                {
                                    dtPSP.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtPSP.DataSource = bllPSP.Sel_PSP_Nome(cbbpPSP.Text);
                                    dtPSP.Select();
                                }
                            }
                            else
                            {
                                dtPSP.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnPIX.Checked == true)
                        {
                            if (cbbpTipoChave.Text != "")
                            {
                                if (bllPSP.Sel_PSP_Tipo_Chave(cbbpTipoChave.Text) == null)
                                {
                                    dtPSP.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtPSP.DataSource = bllPSP.Sel_PSP_Tipo_Chave(cbbpTipoChave.Text);
                                    dtPSP.Select();
                                }
                            }
                            else
                            {
                                dtPSP.DataSource = null;
                                Limpar();
                            }
                        }
                        else if (rbtnTodos.Checked == true)
                        {
                            if (bllPSP.Sel_PSP_Todos() == null)
                            {
                                dtPSP.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtPSP.DataSource = bllPSP.Sel_PSP_Todos();
                                dtPSP.Select();
                            }
                        }
                        else
                        {
                            dtPSP.DataSource = null;
                            Limpar();
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dtPSP.DataSource != null)
                        {
                            dtPSP.Select();
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtPSP.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnPSP.Checked = true;
            }
        }

        private void cbbpPSP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpPSP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpPSP_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpPSP_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoChave_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoChave_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou no botão: [ Novo ] ou no botão: [ Alterar ] e não deseja continuar nessas opções, clique no botão: [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGerarPIXCopiaCola_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dtPSP.Rows[dtPSP.CurrentRow.Index];

            using (FrmGerarQRCodePIX PIX = new FrmGerarQRCodePIX(0, "1", "0", _Usuario, _Cod_PDV_Computador))
            {
                if (PIX.ShowDialog() == DialogResult.Abort)
                {

                }
            }
        }

        private void cbbTipoChave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                if (txtChavePIX.Text != "")
                {
                    if (cbbTipoChave.Text == "ALEATORIA")
                    {
                        if (txtChavePIX.Text.Length != 32 || !Regex.IsMatch(txtChavePIX.Text, @"^[A-Za-z0-9]+$"))
                        {
                            MessageBox.Show("Chave PIX inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtChavePIX.Text = "";
                        }
                    }
                    else if (cbbTipoChave.Text == "CPF")
                    {
                        txtChavePIX.Text = Regex.Replace(txtChavePIX.Text, "[^0-9]", "");
                        //
                        if (txtChavePIX.Text.Length != 11 || !Regex.IsMatch(txtChavePIX.Text, @"^\d{11}$"))
                        {
                            MessageBox.Show("Chave PIX inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtChavePIX.Text = "";
                        }
                    }
                    else if (cbbTipoChave.Text == "CNPJ")
                    {
                        txtChavePIX.Text = Regex.Replace(txtChavePIX.Text, "[^0-9]", "");
                        //
                        if (txtChavePIX.Text.Length != 14 || !Regex.IsMatch(txtChavePIX.Text, @"^\d{14}$"))
                        {
                            MessageBox.Show("Chave PIX inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtChavePIX.Text = "";
                        }
                    }
                    else if (cbbTipoChave.Text == "EMAIL")
                    {
                        if (!Regex.IsMatch(txtChavePIX.Text, @"^[^@]{3,}@\w+\.\w{2,}$"))
                        {
                            MessageBox.Show("Chave PIX inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtChavePIX.Text = "";
                        }
                    }
                    else if (cbbTipoChave.Text == "CELULAR")
                    {
                        txtChavePIX.Text = Regex.Replace(txtChavePIX.Text, "[^0-9]", "");
                        //
                        if (txtChavePIX.Text.Length != 10 & txtChavePIX.Text.Length != 11)
                        {
                            MessageBox.Show("Chave PIX inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtChavePIX.Text = "";
                        }
                    }
                }
            }
        }

        private void dtPSP_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }
    }
}
