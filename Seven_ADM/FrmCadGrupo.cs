using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadGrupo : Form
    {
        public FrmCadGrupo(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmCadGrupo_Load(object sender, EventArgs e)
        {
            try
            {
                bllGrupo._FrmCadGrupo_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadGrupo iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadGrupo iniciado.");
                }

                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadGrupo.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtPalavraChave.Text = null;
            txtDescricao.Text = null;
            cbbTabelaDestino.Text = null;
            cbbCorDestaque.Text = null;
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
            if (dtGrupo.DataSource != null)
            {
                dtGrupo.Enabled = true;
                dtGrupo.Select();
            }
        }

        private void FrmCadGrupo_KeyUp(object sender, KeyEventArgs e)
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

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTabelaDestino.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(254, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTabelaDestino.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(469, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTabelaDestino.Visible = false;
            txtpPalavraChave.Visible = true;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(388, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllGrupo.Sel_Grupo_Descricao(txtpDescricao.Text) == null)
                        {
                            dtGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtGrupo.DataSource = bllGrupo.Sel_Grupo_Descricao(txtpDescricao.Text);
                            dtGrupo.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllGrupo.Sel_Grupo_Codigo(txtpCodigo.Text) == null)
                        {
                            dtGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtGrupo.DataSource = bllGrupo.Sel_Grupo_Codigo(txtpCodigo.Text);
                            dtGrupo.Select();
                        }
                    }
                }
                else if (rbtnTabelaDestino.Checked == true)
                {
                    if (cbbpTabelaDestino.Text != "")
                    {
                        if (bllGrupo.Sel_Grupo_TabelaDestino(cbbpTabelaDestino.Text) == null)
                        {
                            dtGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtGrupo.DataSource = bllGrupo.Sel_Grupo_TabelaDestino(cbbpTabelaDestino.Text);
                            dtGrupo.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllGrupo.Sel_Grupo_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtGrupo.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtGrupo.DataSource = bllGrupo.Sel_Grupo_Palavra_Chave(txtpPalavraChave.Text);
                            dtGrupo.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllGrupo.Sel_Grupo_Todos() == null)
                    {
                        dtGrupo.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtGrupo.DataSource = bllGrupo.Sel_Grupo_Todos();
                        dtGrupo.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou grupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou grupo.");
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
                dtGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTabelaDestino.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(479, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            btnPesquisar.Select();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (txtDescricao.Text.Trim() == "" || cbbTabelaDestino.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Descrição ] e [ Tabela Destino do Grupo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllGrupo.Sel_Grupo_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtGrupo.DataSource = null;
                                rbtnDescricao.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                            }
                            else
                            {
                                bllGrupo.Alterar(txtCodigo.Text, txtDescricao.Text.Trim(), txtPalavraChave.Text.Trim(), cbbTabelaDestino.Text, cbbCorDestaque.Text);

                                bllGrupo.Alterar_Descricao_SubGrupo_Grupo(txtCodigo.Text, txtDescricao.Text.Trim());

                                bllGrupo.Alterar_Descricao_Grupo_Produto(txtCodigo.Text, txtDescricao.Text.Trim());

                                bllGrupo.Alterar_Descricao_Grupo_Conta_Receber(txtCodigo.Text, txtDescricao.Text.Trim());

                                bllGrupo.Alterar_Descricao_Grupo_Conta_Pagar(txtCodigo.Text, txtDescricao.Text.Trim());

                                dtGrupo.DataSource = bllGrupo.Sel_Grupo_A_Alt(txtCodigo.Text);

                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM GRUPO", "GRUPOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Grupo alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }

                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Grupo alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }

                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;

                                ModoPesquisa();

                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            bllGrupo.Salvar(txtDescricao.Text.Trim(), txtPalavraChave.Text.Trim(), cbbTabelaDestino.Text, cbbCorDestaque.Text);

                            dtGrupo.DataSource = bllGrupo.Sel_Grupo_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UM GRUPO", "GRUPOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            bllGrupo.Salvar_SubGrupoASalGrupo("GERAL", "", txtCodigo.Text + "-" + txtDescricao.Text.Trim());

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Grupo cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Grupo cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            ModoPesquisa();

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
                        dtGrupo.DataSource = null;
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtGrupo.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtGrupo.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            txtPalavraChave.Select();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
            Limpar();
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
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
                                if (bllGrupo.Sel_Grupo_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllGrupo.Sel_Grupo_Palavra_Chave_Ver(txtPalavraChave.Text) == true)
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

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTabelaDestino.Select();
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "")
            {
                try
                {
                    if (txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDescricao.Text = null;
                        txtDescricao.Select();
                    }
                    else
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllGrupo.Val_Grupo_Descricao_Alt(txtCodigo.Text, txtDescricao.Text, cbbTabelaDestino.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada para a tabela a que se destina este grupo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
                                }
                            }
                            else
                            {
                                if (bllGrupo.Val_Grupo_Descricao(txtDescricao.Text, cbbTabelaDestino.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada para a tabela a que se destina este grupo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    txtDescricao.Text = null;
                }
            }
            txtDescricao.BackColor = Color.White;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllGrupo.Sel_Grupo_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtGrupo.Select();
                }
                else
                {
                    dtGrupo.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = true;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    txtCodigo.Enabled = true;
                    lblCodigo.Enabled = true;
                    btnSalvar.Enabled = true;
                    grbBox1.Enabled = false;
                    dtGrupo.Enabled = false;
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
                dtGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
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

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
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

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
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

        private void dtGrupo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtGrupo.Rows[dtGrupo.CurrentRow.Index];

                dtGrupo.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtGrupo.DefaultCellStyle.SelectionForeColor = Color.Black;

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                cbbTabelaDestino.Text = SelectedRow.Cells[2].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[3].Value.ToString();
                cbbCorDestaque.Text = SelectedRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtGrupo.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void dtGrupo_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtGrupo.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtGrupo.Enabled = false;
                lblCxSituacao.BackColor = Color.White;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtGrupo.Enabled = true;
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
                if (dtGrupo.DataSource == null)
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

        private void dtGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtGrupo.DataSource == null)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, tabela, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou no botão: [ Novo ] ou no botão: [ Alterar ] e não deseja continuar nessas opções, clique no botão: [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtGrupo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtGrupo.Rows.Count;

            dtGrupo.Columns[0].HeaderText = "Código";
            dtGrupo.Columns[1].HeaderText = "Descrição";
            dtGrupo.Columns[2].HeaderText = "Tabela";
            dtGrupo.Columns[3].HeaderText = "Palavra-Chave";
            dtGrupo.Columns[4].Visible = false;
            dtGrupo.Columns[5].HeaderText = "Cor Destaque";

            dtGrupo.Columns[0].Width = 95;
            dtGrupo.Columns[1].Width = 350;
            dtGrupo.Columns[2].Width = 275;
            dtGrupo.Columns[3].Width = 125;
            dtGrupo.Columns[5].Width = 125;

            dtGrupo.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGrupo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtGrupo.DefaultCellStyle.Font = new Font(dtGrupo.Font, FontStyle.Bold);

            for (int i = 0; i < dtGrupo.Rows.Count; i++)
            {
                if (dtGrupo.Rows[i].Cells[5].Value.ToString() == "")
                {
                    dtGrupo.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else if (dtGrupo.Rows[i].Cells[5].Value.ToString() == "1")
                {
                    dtGrupo.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                }
                else if (dtGrupo.Rows[i].Cells[5].Value.ToString() == "2")
                {
                    dtGrupo.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                }
                else if (dtGrupo.Rows[i].Cells[5].Value.ToString() == "3")
                {
                    dtGrupo.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                }
                else if (dtGrupo.Rows[i].Cells[5].Value.ToString() == "4")
                {
                    dtGrupo.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                }
                else if (dtGrupo.Rows[i].Cells[5].Value.ToString() == "5")
                {
                    dtGrupo.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                }
                else if (dtGrupo.Rows[i].Cells[5].Value.ToString() == "6")
                {
                    dtGrupo.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void dtGrupo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllGrupo.Sel_Grupo_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtGrupo.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Grupo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllGrupo.Sel_Grup_SubGrupo_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Subgrupos, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (bllGrupo.Sel_Grup_Prod_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Produtos, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (bllGrupo.Sel_Grup_Conta_Pagar_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Contas a Pagar, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (bllGrupo.Sel_Grup_Conta_Receber_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Contas a Receber, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            bllGrupo.Excluir(txtCodigo.Text);

                            bllRegistroAtividades.Salvar("EXCLUIU UM GRUPO", "GRUPOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Grupo excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Grupo excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text != "")
                                {
                                    if (bllGrupo.Sel_Grupo_Descricao(txtpDescricao.Text) == null)
                                    {
                                        dtGrupo.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtGrupo.DataSource = bllGrupo.Sel_Grupo_Descricao(txtpDescricao.Text);
                                        dtGrupo.Select();
                                    }
                                }
                                else
                                {
                                    dtGrupo.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnTodos.Checked == true)
                            {
                                if (bllGrupo.Sel_Grupo_Todos() == null)
                                {
                                    dtGrupo.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtGrupo.DataSource = bllGrupo.Sel_Grupo_Todos();
                                    dtGrupo.Select();
                                }
                            }
                            else
                            {
                                dtGrupo.DataSource = null;
                                Limpar();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (dtGrupo.DataSource != null)
                        {
                            dtGrupo.Select();
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
                dtGrupo.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void FrmCadGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllGrupo._FrmCadGrupo_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadGrupo foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadGrupo foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadGrupo.");
                }
            }
        }

        private void cbbGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCorDestaque.Select();
            }
        }

        private void rbtnTabelaDestino_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTabelaDestino_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTabelaDestino_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTabelaDestino_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTabelaDestino_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTabelaDestino_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTabelaDestino_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTabelaDestino.Visible = true;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Escolha a tabela:";
            lblPesquisar.Location = new Point(322, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            cbbpTabelaDestino.Text = null;
            cbbpTabelaDestino.Select();
        }

        private void cbbpTabelaDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbTabelaDestino_Leave(object sender, EventArgs e)
        {
            if (cbbTabelaDestino.Text != "")
            {
                if (_Inserir_Atualizar == true)
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllGrupo.Val_Grupo_Descricao_Alt(txtCodigo.Text, txtDescricao.Text, cbbTabelaDestino.Text) == true)
                            {
                                MessageBox.Show("A Tabela informada já está cadastrada para a descrição informada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbbTabelaDestino.Text = null;
                                cbbTabelaDestino.Select();
                            }
                        }
                        else
                        {
                            if (bllGrupo.Val_Grupo_Descricao(txtDescricao.Text, cbbTabelaDestino.Text) == true)
                            {
                                MessageBox.Show("A Tabela informada já está cadastrada para a descrição informada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbbTabelaDestino.Text = null;
                                cbbTabelaDestino.Select();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do combo cbbTabelaDestino.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do combo cbbTabelaDestino.");
                        }
                        cbbpTabelaDestino.Text = null;
                    }
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPalavraChave.Select();
            }
        }

        private void cbbCorDestaque_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCorDestaque_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCorDestaque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCorDestaque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCorDestaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbCorDestaque.SelectedIndex == 0)
                {
                    lblCxSituacao.BackColor = Color.White;
                }
                else if (cbbCorDestaque.SelectedIndex == 1)
                {
                    lblCxSituacao.BackColor = Color.Khaki;
                }
                else if (cbbCorDestaque.SelectedIndex == 2)
                {
                    lblCxSituacao.BackColor = Color.Tan;
                }
                else if (cbbCorDestaque.SelectedIndex == 3)
                {
                    lblCxSituacao.BackColor = Color.Peru;
                }
                else if (cbbCorDestaque.SelectedIndex == 4)
                {
                    lblCxSituacao.BackColor = Color.Salmon;
                }
                else if (cbbCorDestaque.SelectedIndex == 5)
                {
                    lblCxSituacao.BackColor = Color.MediumOrchid;
                }
                else if (cbbCorDestaque.SelectedIndex == 6)
                {
                    lblCxSituacao.BackColor = Color.LightPink;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do combo cbbTabelaDestino.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do combo cbbTabelaDestino.");
                }
            }
        }

        private void lblCxSituacao_Click(object sender, EventArgs e)
        {

        }

        private void grbBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cbbCorDestaque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }
    }
}