using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadMarca : Form
    {
        public FrmCadMarca(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;

        private void FrmCadMarcaProduto_Load(object sender, EventArgs e)
        {
            try
            {
                bllMarca._FrmCadMarca_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadMarca iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadMarca iniciado.");
                }
                //
                rbtnDescricao.Checked = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadMarca.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtDescricao.Text = null;
            cbbOrigemPais.Text = null;
            cbbPais.Text = null;
            txtPalavraChave.Text = null;
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
            if (dtMarca.DataSource != null)
            {
                dtMarca.Enabled = true;
                dtMarca.Select();
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

        private void rbtnTabelaDestino_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTabelaDestino_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
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

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(274, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(469, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTabelaDestino_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = true;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Escolha a origem:";
            lblPesquisar.Location = new Point(320, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            cbbpOrigemPais.Text = null;
            cbbpOrigemPais.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = true;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(388, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(479, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            btnPesquisar.Select();
        }

        private void cbbpOrigemPais_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpOrigemPais_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpOrigemPais_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpOrigemPais_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
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

        private void cbbpOrigemPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
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

        private void dtGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtMarca.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtGrupo_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtMarca.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtMarca.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtMarca.Enabled = true;
            }
        }

        private void dtMarca_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtMarca.Columns[0].HeaderText = "Código";
            dtMarca.Columns[1].HeaderText = "Descrição";
            dtMarca.Columns[2].HeaderText = "Origem";
            dtMarca.Columns[3].HeaderText = "País";
            dtMarca.Columns[4].HeaderText = "Palavra-Chave";
            dtMarca.Columns[5].Visible = false;

            dtMarca.Columns[0].Width = 95;
            dtMarca.Columns[1].Width = 350;
            dtMarca.Columns[2].Width = 275;
            dtMarca.Columns[3].Width = 275;
            dtMarca.Columns[4].Width = 125;

            dtMarca.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtMarca.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtMarca.DefaultCellStyle.Font = new Font(dtMarca.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtMarca.Rows.Count;
        }

        private void dtMarca_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPalavraChave.Select();
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
                txtPalavraChave.Text = null;
                txtPalavraChave.Select();
            }
            else
            {
                if (_Inserir_Atualizar == true)
                {
                    try
                    {
                        if (txtPalavraChave.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllMarca.Sel_Marca_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllMarca.Sel_Marca_Palavra_Chave_Ver(txtPalavraChave.Text) == true)
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

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("=") || txtDescricao.Text.Contains("-"))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Text = null;
                txtDescricao.Select();
            }
            else
            {
                if (_Inserir_Atualizar == true)
                {
                    try
                    {
                        if (txtDescricao.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllMarca.Sel_Marca_Descricao_Alt(txtCodigo.Text, txtDescricao.Text.Trim(), cbbPais.Text) == true)
                                {
                                    MessageBox.Show("A descrição informada já está cadastrada para o país selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
                                }
                            }
                            else
                            {
                                if (bllMarca.Sel_Marca_Descricao_Ver(txtDescricao.Text.Trim(), cbbPais.Text) == true)
                                {
                                    MessageBox.Show("A descrição informada já está cadastrada para o país selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                        }
                        txtDescricao.Text = null;
                    }
                }
            }
            txtDescricao.BackColor = Color.White;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbOrigemPais.Select();
            }
        }

        private void cbbTabelaDestino_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTabelaDestino_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTabelaDestino_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTabelaDestino_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void comboBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadMarcaProduto_KeyUp(object sender, KeyEventArgs e)
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

        private void FrmCadMarcaProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllMarca._FrmCadMarca_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadMarca foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadMarca foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadMarca.");
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtMarca.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtMarca.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            Limpar();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            cbbOrigemPais.Text = "NACIONAL";
            txtPalavraChave.Select();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMarca.Sel_Marca_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtMarca.Select();
                }
                else
                {
                    dtMarca.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = true;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    grbBox1.Enabled = false;
                    dtMarca.Enabled = false;
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtPalavraChave.Select();
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
                dtMarca.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
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
                if (dtMarca.DataSource == null)
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

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou no botão: [ Novo ] ou no botão: [ Alterar ] e não deseja continuar nessas opções, clique no botão: [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, origem, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbbOrigemPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbPais.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    cbbPais.Select();
                }
            }
        }

        private void cbbPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (txtDescricao.Text.Trim() == "" || cbbPais.Text == "" || cbbOrigemPais.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Descrição ], [ Origem ] e [ País ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPalavraChave.Select();
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllMarca.Sel_Marca_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtMarca.DataSource = null;
                                rbtnDescricao.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                            }
                            else
                            {
                                bllMarca.Alterar(txtCodigo.Text, txtDescricao.Text.Trim(), txtPalavraChave.Text.Trim(), cbbOrigemPais.Text, cbbPais.Text);

                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA MARCA", "MARCAS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                bllMarca.Alterar_Descricao_Marca_Produto(txtCodigo.Text, txtDescricao.Text.Trim());

                                dtMarca.DataSource = bllMarca.Sel_Marca_A_Alt(txtCodigo.Text);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Marca alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }

                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Marca alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }

                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;

                                ModoPesquisa();

                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (_Formulario == 1)
                                {
                                    bllMarca._Cod_Marca_Cadastro = txtCodigo.Text;
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                        }
                        else
                        {
                            bllMarca.Salvar(txtDescricao.Text.Trim(), txtPalavraChave.Text.Trim(), cbbOrigemPais.Text, cbbPais.Text);

                            dtMarca.DataSource = bllMarca.Sel_Marca_A_Salvar();

                            bllRegistroAtividades.Salvar("SALVOU UMA MARCA", "MARCAS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Marca cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Marca cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            ModoPesquisa();

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (_Formulario == 1)
                            {
                                DataGridViewRow SelectedRow = dtMarca.Rows[dtMarca.CurrentRow.Index];
                                //
                                bllMarca._Cod_Marca_Cadastro = SelectedRow.Cells[0].Value.ToString();
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
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                        dtMarca.DataSource = null;
                        Limpar();
                        ModoPesquisa();
                        rbtnDescricao.Checked = true;
                    }
                }
            }
            else
            {
                txtPalavraChave.Select();
            }
        }

        private void dtMarca_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtMarca.Rows[dtMarca.CurrentRow.Index];

                dtMarca.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtMarca.DefaultCellStyle.SelectionForeColor = Color.Black;
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                cbbOrigemPais.Text = SelectedRow.Cells[2].Value.ToString();
                cbbPais.Text = SelectedRow.Cells[3].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtMarca.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtMarca.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Descricao(txtpDescricao.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Descricao(txtpDescricao.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Codigo(txtpCodigo.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Codigo(txtpCodigo.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnOrigem.Checked == true)
                {
                    if (rbtnOrigem.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Origem(cbbpOrigemPais.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Origem(cbbpOrigemPais.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Palavra_Chave(txtpPalavraChave.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllMarca.Sel_Marca_Todas() == null)
                    {
                        dtMarca.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtMarca.DataSource = bllMarca.Sel_Marca_Todas();
                        dtMarca.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou marca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou marca.");
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
                dtMarca.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void cbbOrigemPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbOrigemPais.SelectedIndex == 0)
                {
                    cbbPais.Items.Clear();
                }
                else if (cbbOrigemPais.SelectedIndex == 1)
                {
                    cbbPais.Enabled = false;
                    label1.Enabled = false;
                    cbbPais.Items.Add("BRASIL");
                    cbbPais.Text = "BRASIL";
                }
                else if (cbbOrigemPais.SelectedIndex == 2)
                {
                    cbbPais.Enabled = true;
                    label1.Enabled = true;
                    cbbPais.Text = null;
                    cbbPais.Items.Clear();
                    cbbPais.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\Paises\Paises.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            cbbPais.Items.Add(Sr.ReadLine());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbOrigemPais");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbOrigemPais");
                }
                cbbPais.Text = null;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMarca.Sel_Marca_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtMarca.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Marca?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllMarca.Sel_Marca_Produto_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Marca selecionada está sendo utilizada por um Produto, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtMarca.Select();
                        }
                        else
                        {
                            bllMarca.Excluir(txtCodigo.Text);

                            bllRegistroAtividades.Salvar("EXCLUIU UMA MARCA", "MARCAS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Marca excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Marca excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text != "")
                                {
                                    if (bllMarca.Sel_Marca_Descricao(txtpDescricao.Text) == null)
                                    {
                                        dtMarca.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtMarca.DataSource = bllMarca.Sel_Marca_Descricao(txtpDescricao.Text);
                                        dtMarca.Select();
                                    }
                                }
                                else
                                {
                                    dtMarca.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnOrigem.Checked == true)
                            {
                                if (rbtnOrigem.Text != "")
                                {
                                    if (bllMarca.Sel_Marca_Origem(cbbpOrigemPais.Text) == null)
                                    {
                                        dtMarca.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtMarca.DataSource = bllMarca.Sel_Marca_Origem(cbbpOrigemPais.Text);
                                        dtMarca.Select();
                                    }
                                }
                                else
                                {
                                    dtMarca.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnTodos.Checked == true)
                            {
                                if (bllMarca.Sel_Marca_Todas() == null)
                                {
                                    dtMarca.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtMarca.DataSource = bllMarca.Sel_Marca_Todas();
                                    dtMarca.Select();
                                }
                            }
                            else
                            {
                                dtMarca.DataSource = null;
                                Limpar();
                            }

                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (dtMarca.DataSource != null)
                        {
                            dtMarca.Select();
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
                dtMarca.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void cbbPais_Leave(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    if (cbbPais.Text != "")
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllMarca.Sel_Marca_Descricao_Alt(txtCodigo.Text, txtDescricao.Text.Trim(), cbbPais.Text) == true)
                            {
                                MessageBox.Show("O País selecionado já está cadastrado para a Descrição informada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbbPais.Text = null;
                                cbbPais.Select();
                            }
                        }
                        else
                        {
                            if (bllMarca.Sel_Marca_Descricao_Ver(txtDescricao.Text.Trim(), cbbPais.Text) == true)
                            {
                                MessageBox.Show("O País selecionado já está cadastrado para a Descrição informada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbbPais.Text = null;
                                cbbPais.Select();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    cbbPais.Text = null;
                }
            }
        }
    }
}













