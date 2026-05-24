using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqCliente : Form
    {
        public FrmPesqCliente(byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private bool _Contem_Imagem;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqCliente_Load(object sender, EventArgs e)
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCliente iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCliente iniciado.");
                }
                rbtnNomeAluno.Checked = true;
                //
                if (bllUsuario.Sel_Permitir_Cadastrar_PDV_Usuario(_Usuario) == true)
                {
                    btnCadastrar.Visible = true;
                }
                else
                {
                    btnCadastrar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqCliente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqCliente.");
                }
                this.DialogResult = DialogResult.Abort;
            }
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

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
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

        private void rbtnRG_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnRG_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnIE_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnIE_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void mtxtpCPF_Enter(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void mtxtpCelular_Enter(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.LightBlue;
        }

        private void txtpRG_Enter(object sender, EventArgs e)
        {
            txtpRG.BackColor = Color.LightBlue;
        }

        private void mtxtpCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.LightBlue;
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
            lblPesquisar.Location = new Point(269, 21);
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
            lblPesquisar.Text = "Digite o cpf do responsável:";
            lblPesquisar.Location = new Point(457, 21);
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
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

        private void mtxtpCelular_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mtxtpTelefone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mtxtpCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
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

        private void mtxtpCPF_Leave(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.White;
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

        private void mtxtpCelular_Leave(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.White;
        }

        private void mtxtpCNPJ_Leave(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.White;
        }

        private void mtxtpTelefone_Enter(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtpTelefone_Leave(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.White;
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
            txtpRG.BackColor = Color.White;
        }

        private void FrmPesqCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmPesqCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCliente foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCliente foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelVenda.");
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodos.Checked == true)
                {
                    if (bllClieCons.Sel_Clie_Todos_Ativo() == null)
                    {
                        dtClie.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtClie.DataSource = bllClieCons.Sel_Clie_Todos_Ativo();
                        dtClie.Select();
                    }
                }
                else if (rbtnNomeAluno.Checked == true)
                {
                    if (txtpNome.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_Nome_Ativo(txtpNome.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_Nome_Ativo(txtpNome.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllClieCons.Sel_Cliente_Codigo_Ativo(txtpCodigo.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Cliente_Codigo_Ativo(txtpCodigo.Text);
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

                        if (bllClieCons.Sel_Clie_CPFCNPJ_Ativo(mtxtpCPF.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_CPFCNPJ_Ativo(mtxtpCPF.Text);
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

                        if (bllClieCons.Sel_Clie_CPFCNPJ_Ativo(mtxtpCNPJ.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_CPFCNPJ_Ativo(mtxtpCNPJ.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_IERG_Ativo(txtpRG.Text, 0) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_IERG_Ativo(txtpRG.Text, 0);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnIE.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_IERG_Ativo(txtpRG.Text, 1) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_IERG_Ativo(txtpRG.Text, 1);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_Palavra_Chave_Ativo(txtpPalavraChave.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_Palavra_Chave_Ativo(txtpPalavraChave.Text);
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

                        if (bllClieCons.Sel_Cliente_CPF_Resp_Ativo(mtxtpCPF.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Cliente_CPF_Resp_Ativo(mtxtpCPF.Text);
                            dtClie.Select();
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou cliente.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou cliente.");
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
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
            }
        }

        private void dtClie_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtClie.DataSource == null)
            {
                pcibImagem.Image = null;
                pcibImagem.Enabled = false;
                lblLegendaImagem.Visible = false;
                pcibAjudaFoto.Enabled = false;
                dtClie.Enabled = false;
                btnIncluir.Enabled = false;
                _Contem_Imagem = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                pcibImagem.Enabled = true;
                dtClie.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                //
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

        private void dtClie_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                if (_Formulario == 0)
                {
                    bllVenda._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllSaidasProdutos._Saidas_Prod_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllVenda._Cliente_PesqCliente_Tabela = SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[30].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 3)
                {
                    bllDevolucao._Devolucao_Prod_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    bllContasPagar._Emitente_PesqContaPagar_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 6)
                {
                    bllContasReceber._Consumidor_PesqContaReceber = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 7)
                {
                    bllControleCheque._Consumidor_PesqControleCheque = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 8)
                {
                    if (SelectedRow.Cells[10].Value.ToString() == "")
                    {
                        MessageBox.Show("O Consumidor selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[10].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 9)
                {
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 10)
                {
                    bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 11)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllSMS._Destinatario_SMS = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 12)
                {
                    bllEntradasProdutos._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 13)
                {
                    /*
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                    */
                    if (SelectedRow.Cells[4].Value.ToString() != "")
                    {
                        bllOS._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                    }
                    else
                    {
                        bllOS._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    }
                    this.DialogResult = DialogResult.OK;
                    //}
                }
                else if (_Formulario == 14)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllPSP._Celular = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 15)
                {
                    /*
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("Não é possível incluir um consumidor sem CPF/CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else 
                    */
                    if (SelectedRow.Cells[18].Value.ToString() == "BLOQUEADO")
                    {
                        MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        btnIncluir.Select();
                        //
                        if (SelectedRow.Cells[4].Value.ToString() != "")
                        { 
                            bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();

                        }
                        else
                        {
                            bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();

                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 16)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento doubleclick do dtClie.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento doubleclick do dtClie.");
                }
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                if (_Formulario == 0)
                {
                    bllVenda._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllSaidasProdutos._Saidas_Prod_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllVenda._Cliente_PesqCliente_Tabela = SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[30].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 3)
                {
                    bllDevolucao._Devolucao_Prod_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    bllContasPagar._Emitente_PesqContaPagar_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 6)
                {
                    bllContasReceber._Consumidor_PesqContaReceber = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 7)
                {
                    bllControleCheque._Consumidor_PesqControleCheque = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 8)
                {
                    if (SelectedRow.Cells[10].Value.ToString() == "")
                    {
                        MessageBox.Show("O Consumidor selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[10].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 9)
                {
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 10)
                {
                    bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 11)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllSMS._Destinatario_SMS = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 12)
                {
                    bllEntradasProdutos._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 13)
                {
                    /*
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                    */
                    if (SelectedRow.Cells[4].Value.ToString() != "")
                    {
                        bllOS._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                    }
                    else
                    {
                        bllOS._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    }
                    this.DialogResult = DialogResult.OK;
                    //}
                }
                else if (_Formulario == 14)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllPSP._Celular = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 15)
                {
                    /*
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("Não é possível incluir um consumidor sem CPF/CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else 
                    */
                    if (SelectedRow.Cells[18].Value.ToString() == "BLOQUEADO")
                    {
                        MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        btnIncluir.Select();
                        //
                        if (SelectedRow.Cells[4].Value.ToString() != "")
                        {
                            bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                        }
                        else
                        {
                            bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 16)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtClie.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtClie.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtClie.");
                }
            }
        }

        private void dtClie_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtClie.Columns[0].HeaderText = "Código";
            dtClie.Columns[1].HeaderText = "Nome/Razão Social";
            dtClie.Columns[2].HeaderText = "Nome Fantasia";
            dtClie.Columns[3].HeaderText = "Data de Nascimento";
            dtClie.Columns[4].HeaderText = "CPF/CNPJ";
            dtClie.Columns[5].HeaderText = "RG/IE";
            dtClie.Columns[6].HeaderText = "Gênero";
            dtClie.Columns[7].HeaderText = "Telefone";
            dtClie.Columns[8].HeaderText = "FAX";
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
            dtClie.Columns[19].HeaderText = "Crédito";
            dtClie.Columns[20].HeaderText = "Saldo";
            dtClie.Columns[21].HeaderText = "Saldo Crédito da Loja";
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
            dtClie.Columns[50].HeaderText = "Cód. do Sub-grupo";
            dtClie.Columns[51].HeaderText = "Descrição do Sub-grupo";
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

        private void dtClie_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtClie.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtClie.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                dtClie.Columns[19].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtClie.Columns[19].DefaultCellStyle.Format = "n2";
                dtClie.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtClie.Columns[20].DefaultCellStyle.Format = "n2";
                dtClie.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtClie.Columns[21].DefaultCellStyle.Format = "n2";
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
                dtClie.DataSource = null;
                rbtnNomeAluno.Checked = true;
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

        private void dtClie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];
                    if (_Formulario == 0)
                    {
                        bllVenda._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        bllSaidasProdutos._Saidas_Prod_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 2)
                    {
                        if (SelectedRow.Cells[4].Value.ToString() == "")
                        {
                            MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtClie.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllVenda._Cliente_PesqCliente_Tabela = SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[30].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        bllDevolucao._Devolucao_Prod_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 4)
                    {
                        bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 5)
                    {
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 6)
                    {
                        bllContasReceber._Consumidor_PesqContaReceber = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 7)
                    {
                        bllControleCheque._Consumidor_PesqControleCheque = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 8)
                    {
                        if (SelectedRow.Cells[10].Value.ToString() == "")
                        {
                            MessageBox.Show("O Consumidor selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtClie.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[10].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 9)
                    {
                        if (SelectedRow.Cells[4].Value.ToString() == "")
                        {
                            MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtClie.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 10)
                    {
                        bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 11)
                    {
                        if (SelectedRow.Cells[9].Value.ToString() == "")
                        {
                            MessageBox.Show("O Consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtClie.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllSMS._Destinatario_SMS = SelectedRow.Cells[9].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 12)
                    {
                        bllEntradasProdutos._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 13)
                    {
                        /*
                        if (SelectedRow.Cells[4].Value.ToString() == "")
                        {
                            MessageBox.Show("O consumidor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtClie.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                        */
                        if (SelectedRow.Cells[4].Value.ToString() != "")
                        {
                            bllOS._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                        }
                        else
                        {
                            bllOS._Cliente_PesqCliente_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        }
                        this.DialogResult = DialogResult.OK;
                        //}
                    }
                    else if (_Formulario == 14)
                    {
                        if (SelectedRow.Cells[9].Value.ToString() == "")
                        {
                            MessageBox.Show("O consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtClie.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllPSP._Celular = SelectedRow.Cells[9].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 15)
                    {
                        /*
                        if (SelectedRow.Cells[4].Value.ToString() == "")
                        {
                            MessageBox.Show("Não é possível incluir um consumidor sem CPF/CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else 
                        */
                        if (SelectedRow.Cells[18].Value.ToString() == "BLOQUEADO")
                        {
                            MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            btnIncluir.Select();
                            //
                            if (SelectedRow.Cells[4].Value.ToString() != "")
                            {
                                bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                            }
                            else
                            {
                                bllOrcamento._Orc_PesqConsumidor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 16)
                    {
                        if (SelectedRow.Cells[9].Value.ToString() == "")
                        {
                            MessageBox.Show("O Consumidor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtClie.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[9].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtClie.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtClie.");
                    }
                }
            }
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lbllegendaImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lbllegendaImagem.");
                }
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
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
        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
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

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida no ato da alteração de dados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtClie_MouseMove(object sender, MouseEventArgs e)
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

        private void dtClie_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por nome/razão social, código, cpf, cnpj, rg, inscrição estadual, cpf(Pai ou Mãe), palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtClie_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtClie_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 30 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void grbBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Cadastrar_Cliente_Consumidor(_Usuario) == true)
                {
                    using (FrmCadClieCons Clie = new FrmCadClieCons(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllClieCons.Sel_Cliente_Codigo_Ativo(bllClieCons._Cod_ClieCons_Cadastro) == null)
                            {
                                dtClie.DataSource = null;
                            }
                            else
                            {
                                dtClie.DataSource = bllClieCons.Sel_Cliente_Codigo_Ativo(bllClieCons._Cod_ClieCons_Cadastro);
                                dtClie.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        bllClieCons._Cod_ClieCons_Cadastro = null;
                    }
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Funcionários.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
            }
            this.Enabled = true;
        }

        private void btnCadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
