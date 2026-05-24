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
    public partial class FrmUtilAgenda : Form
    {
        public FrmUtilAgenda(string usuario, string cod_pdv_computador, byte formulario, string codigo)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
            _Codigo = codigo;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private string _Codigo;
        bool _Nenhum_Registro = false;

        private void FrmContLembrete_Load(object sender, EventArgs e)
        {
            try
            {
                bllLembrete._FrmUtiAgenda_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilAgenda iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilAgenda iniciado.");
                }

                if (_Formulario == 1)
                {
                    rbtnCodigo.Checked = true;
                    //
                    txtpCodigo.Text = _Codigo;
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    btnAlterar_Click(sender, e);
                }
                else
                {
                    rbtnTodos.Checked = true;
                    //
                    cbbSituacao.Text = "PENDENTE";
                    //
                    btnPesquisar_Click(sender, e);
                }
                //
                _Nenhum_Registro = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilAgenda.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilAgenda.");
                }
            }
        }

        private void rbtnTituloAssunto_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            cbbSituacao.Enabled = true;
            cbbSituacao.Text = null;
            lblSituacao.Enabled = true;
            btnpProcurar.Visible = false;
            cbbUsuario.Visible = false;
            txtpTitulo.Visible = true;
            txtpCodigo.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            lblAte.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(344, 19);
            txtpTitulo.Text = null;
            txtpTitulo.Select();
            btnSelecionarData.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            cbbSituacao.Enabled = false;
            cbbSituacao.Text = null;
            lblSituacao.Enabled = false;
            btnpProcurar.Visible = false;
            cbbUsuario.Visible = false;
            txtpTitulo.Visible = false;
            txtpCodigo.Visible = true;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            lblAte.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(488, 19);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
            btnSelecionarData.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            cbbSituacao.Enabled = true;
            cbbSituacao.Text = null;
            lblSituacao.Enabled = true;
            btnpProcurar.Visible = false;
            cbbUsuario.Visible = false;
            txtpTitulo.Visible = false;
            txtpCodigo.Visible = false;
            mtxtpData.Visible = true;
            mtxtpData1.Visible = true;
            lblAte.Visible = true;
            lblPesquisar.Text = "Digite as datas:";
            lblPesquisar.Location = new Point(337, 19);
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpData.Select();
            btnSelecionarData.Visible = true;
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            cbbSituacao.Enabled = true;
            cbbSituacao.Text = null;
            lblSituacao.Enabled = true;
            btnpProcurar.Visible = false;
            cbbUsuario.Visible = false;
            txtpTitulo.Visible = false;
            txtpCodigo.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            lblAte.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(534, 19);
            btnPesquisar.Select();
            btnSelecionarData.Visible = false;
        }


        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
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

            if (mtxtpData.Text == "")
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtpData.BackColor = Color.White;
            }
            else
            {
                try
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData.Text);

                    mtxtpData.BackColor = Color.White;
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
                    mtxtpData1.Text = null;
                    dtLembretes.DataSource = null;
                    rbtnData.Checked = true;
                    mtxtpData.Select();
                }
            }
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void mtxtpData1_Leave(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text == "")
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtpData1.BackColor = Color.White;
            }
            else
            {
                try
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData1.Text);

                    mtxtpData1.BackColor = Color.White;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    mtxtpData.Text = null;
                    mtxtpData1.Text = null;
                    dtLembretes.DataSource = null;
                    rbtnData.Checked = true;
                    mtxtpData.Select();
                }
            }
        }

        private void txtpTitulo_Enter(object sender, EventArgs e)
        {
            txtpTitulo.BackColor = Color.LightBlue;
        }

        private void txtpTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void txtpTitulo_Leave(object sender, EventArgs e)
        {
            txtpTitulo.BackColor = Color.White;
        }



        private void FrmContLembrete_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmContLembrete_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilAgenda foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilAgenda foi finalizado.");
                }
                bllLembrete._FrmUtiAgenda_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmUtilAgenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmUtilAgenda.");
                }
            }
        }

        private void rbtnTituloAssunto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTituloAssunto_MouseLeave(object sender, EventArgs e)
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

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnData_MouseLeave(object sender, EventArgs e)
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

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            //
            if (e.KeyChar == 13)
            {
                if (rbtnTabela.Checked == true)
                {
                    cbbSituacao.Select();
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
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

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(0))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllLembrete._Data_DatePicker1;
                    mtxtpData1.Text = bllLembrete._Data_DatePicker2;
                    bllLembrete._Data_DatePicker1 = null;
                    bllLembrete._Data_DatePicker2 = null;
                    btnPesquisar.Select();
                }
            }
            this.Enabled = true;
        }

        private void mtxtpData_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text == "")
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtpData1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text == "")
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterregocao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterregocao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, null, null, null, null, null, false, _Usuario, _Cod_PDV_Computador, 0, null, null))
                {
                    if (Lembrete.ShowDialog() == DialogResult.OK)
                    {
                        dtLembretes.DataSource = bllLembrete.Sel_Lembrete_A_Sal();
                        dtLembretes.Select();
                        DataGridViewRow SelectedRow = dtLembretes.Rows[dtLembretes.CurrentRow.Index];
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar cadastrada. Cod: " + SelectedRow.Cells[0].Value.ToString() + " | Descrição: " + SelectedRow.Cells[1].Value.ToString());
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar cadastrada. Cod: " + SelectedRow.Cells[0].Value.ToString() + " | Descrição: " + SelectedRow.Cells[1].Value.ToString());
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                mtxtpData.Text = null;
                mtxtpData1.Text = null;
                dtLembretes.DataSource = null;
                rbtnData.Checked = true;
                mtxtpData.Select();
            }
            this.Enabled = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodos.Checked == true)
                {
                    if (bllLembrete.Sel_Lembrete_Todos(cbbSituacao.Text) == null)
                    {
                        dtLembretes.DataSource = null;
                        if (_Nenhum_Registro == true)
                        {
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Todos(cbbSituacao.Text);
                        dtLembretes.Select();
                    }
                }
                else if (rbtnUsuario.Checked == true)
                {
                    if (cbbUsuario.Text != "")
                    {
                        if (bllLembrete.Sel_Lembrete_Usuario(cbbUsuario.Text, cbbSituacao.Text) == null)
                        {
                            dtLembretes.DataSource = null;
                            if (_Nenhum_Registro == true)
                            {
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Usuario(cbbUsuario.Text, cbbSituacao.Text);
                            dtLembretes.Select();
                        }
                    }
                }
                else if (rbtnTabela.Checked == true)
                {
                    if (bllLembrete.Sel_Lembrete_Tabela_Geradora(txtpCodigo.Text, cbbSituacao.Text, cbbTabela.Text) == null)
                    {
                        dtLembretes.DataSource = null;
                        if (_Nenhum_Registro == true)
                        {
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Tabela_Geradora(txtpCodigo.Text, cbbSituacao.Text, cbbTabela.Text);
                        dtLembretes.Select();
                    }
                }
                else if (rbtnTituloAssunto.Checked == true)
                {
                    if (txtpTitulo.Text != "")
                    {
                        if (bllLembrete.Sel_Lembrete_Descricao(txtpTitulo.Text, cbbSituacao.Text) == null)
                        {
                            dtLembretes.DataSource = null;
                            if (_Nenhum_Registro == true)
                            {
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Descricao(txtpTitulo.Text, cbbSituacao.Text);
                            dtLembretes.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllLembrete.Sel_Lembrete_Codigo(txtpCodigo.Text) == null)
                        {
                            dtLembretes.DataSource = null;
                            if (_Nenhum_Registro == true)
                            {
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Codigo(txtpCodigo.Text);
                            dtLembretes.Select();
                        }
                    }
                    else
                    {
                        dtLembretes.DataSource = null;
                        if (_Nenhum_Registro == true)
                        {
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        this.DialogResult = DialogResult.None;
                    }
                }
                else if (rbtnData.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        if (bllLembrete.Sel_Lembrete_Data(mtxtpData.Text, mtxtpData1.Text, cbbSituacao.Text) == null)
                        {
                            dtLembretes.DataSource = null;
                            if (_Nenhum_Registro == true)
                            {
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Data(mtxtpData.Text, mtxtpData1.Text, cbbSituacao.Text);
                            dtLembretes.Select();
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou agenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou agenda.");
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
                dtLembretes.DataSource = null;
                rbtnData.Checked = true;
            }
        }

        private void dtLembretes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dtLembretes.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtLembretes.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtLembretes.Rows[e.RowIndex];

                if (SelectedRow.Cells[7].Value.ToString() == "ABERTO")
                {
                    lblValorSituacao.Text = "EM ABERTO";
                    lblValorSituacao.ForeColor = Color.Red;
                    pcibCor.BackColor = Color.Red;
                    btnFinalizar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnFinalizar.Enabled = true;
                }
                else if (SelectedRow.Cells[7].Value.ToString() == "PENDENTE")
                {
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    pcibCor.BackColor = Color.Red;
                    btnFinalizar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnFinalizar.Enabled = true;
                }
                else
                {

                    lblValorSituacao.ForeColor = Color.Green;
                    pcibCor.BackColor = Color.Green;
                    lblValorSituacao.Text = "FINALIZADO";
                    btnFinalizar.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnFinalizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do dtLembrete.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do dtLembrete.");
                }
                mtxtpData.Text = null;
                mtxtpData1.Text = null;
                dtLembretes.DataSource = null;
                rbtnData.Checked = true;
                mtxtpData.Select();
            }
        }

        private void dtLembretes_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtLembretes.DataSource == null)
            {
                dtLembretes.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnDuplicar.Enabled = false;
                lblValorSituacao.Visible = false;
                pcibCor.Visible = false;
                pcibCor.BackColor = Color.LightGray;
                lblSit.Visible = false;
            }
            else
            {
                dtLembretes.Enabled = true;
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnDuplicar.Enabled = true;
                lblValorSituacao.Visible = true;
                pcibCor.Visible = true;
                lblSit.Visible = true;
                //
                for (int i = 0; i < dtLembretes.Rows.Count; i++)
                {
                    if (dtLembretes.Rows[i].Cells[7].Value.ToString() == "ABERTO")
                    {
                        dtLembretes.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                    }
                    else if (dtLembretes.Rows[i].Cells[7].Value.ToString() == "PENDENTE")
                    {
                        dtLembretes.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                    }
                    else if (dtLembretes.Rows[i].Cells[7].Value.ToString() == "FINALIZADO")
                    {
                        dtLembretes.Rows[i].Cells[7].Style.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void dtLembretes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtLembretes.Columns[0].HeaderText = "Código";
            dtLembretes.Columns[1].HeaderText = "Descrição";
            dtLembretes.Columns[2].HeaderText = "Data";
            dtLembretes.Columns[3].HeaderText = "Horário";
            dtLembretes.Columns[4].HeaderText = "Observações";
            dtLembretes.Columns[5].HeaderText = "Som do Alarme";
            dtLembretes.Columns[6].HeaderText = "Usuário(s)";
            dtLembretes.Columns[7].HeaderText = "Situação";
            dtLembretes.Columns[8].HeaderText = "Tabela Geradora";
            dtLembretes.Columns[9].HeaderText = "Cód. Fato Gerador";


            dtLembretes.Columns[0].Width = 80;
            dtLembretes.Columns[1].Width = 300;
            dtLembretes.Columns[2].Width = 115;
            dtLembretes.Columns[3].Width = 115;
            dtLembretes.Columns[4].Width = 500;
            dtLembretes.Columns[5].Width = 125;
            dtLembretes.Columns[6].Width = 235;
            dtLembretes.Columns[7].Width = 150;
            dtLembretes.Columns[8].Width = 235;
            dtLembretes.Columns[9].Width = 175;

            dtLembretes.DefaultCellStyle.Font = new Font(dtLembretes.Font, FontStyle.Bold);

            dtLembretes.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLembretes.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistros.Text = "Registros: " + dtLembretes.Rows.Count;
        }

        private void dtLembretes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtLembretes_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtLembretes.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtLembretes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtLembretes.Rows[dtLembretes.CurrentRow.Index];
                //
                if (bllLembrete.Sel_Lembrete_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtLembretes.Select();
                }
                else
                {
                    if (bllLembrete.Sel_Ver_Lemb_Fechado(SelectedRow.Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("O alarme selecionado não pôde ser alterado pois o mesmo já foi finalizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtLembretes.DataSource = bllLembrete.Sel_Lembrete_A_Alt(SelectedRow.Cells[0].Value.ToString());
                        dtLembretes.Select();
                    }
                    else
                    {
                        using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), true, _Usuario, _Cod_PDV_Computador, 0, null, null))
                        {
                            if (Lembrete.ShowDialog() == DialogResult.OK)
                            {
                                dtLembretes.DataSource = bllLembrete.Sel_Lembrete_A_Alt(SelectedRow.Cells[0].Value.ToString());
                                dtLembretes.Select();
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
                mtxtpData.Text = null;
                mtxtpData1.Text = null;
                dtLembretes.DataSource = null;
                rbtnData.Checked = true;
                mtxtpData.Select();
            }
            this.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtLembretes.Rows[dtLembretes.CurrentRow.Index];
                //
                if (bllLembrete.Sel_Lembrete_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtLembretes.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Lembrete?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        bllLembrete.Excluir_Usuario_Lembrete(SelectedRow.Cells[0].Value.ToString());
                        //
                        bllLembrete.Excluir(SelectedRow.Cells[0].Value.ToString());
                        //
                        bllRegistroAtividades.Salvar("EXCLUIU UM LEMBRETE", "LEMBRETE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete excluído. Cod: " + SelectedRow.Cells[0].Value.ToString() + " | Descrição: " + SelectedRow.Cells[1].Value.ToString());
                        }
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete excluído. Cod: " + SelectedRow.Cells[0].Value.ToString() + " | Descrição: " + SelectedRow.Cells[1].Value.ToString());
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
                        //
                        if (rbtnTodos.Checked == true)
                        {
                            if (bllLembrete.Sel_Lembrete_Todos(cbbSituacao.Text) == null)
                            {
                                dtLembretes.DataSource = null;
                            }
                            else
                            {
                                dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Todos(cbbSituacao.Text);
                                dtLembretes.Select();
                            }
                        }
                        else if (rbtnUsuario.Checked == true)
                        {
                            if (cbbUsuario.Text != "")
                            {
                                if (bllLembrete.Sel_Lembrete_Usuario(cbbUsuario.Text, cbbSituacao.Text) == null)
                                {
                                    dtLembretes.DataSource = null;
                                }
                                else
                                {
                                    dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Usuario(cbbUsuario.Text, cbbSituacao.Text);
                                    dtLembretes.Select();
                                }
                            }
                        }
                        else if (rbtnTituloAssunto.Checked == true)
                        {
                            if (txtpTitulo.Text != "")
                            {
                                if (bllLembrete.Sel_Lembrete_Descricao(txtpTitulo.Text, cbbSituacao.Text) == null)
                                {
                                    dtLembretes.DataSource = null;
                                }
                                else
                                {
                                    dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Descricao(txtpTitulo.Text, cbbSituacao.Text);
                                    dtLembretes.Select();
                                }
                            }
                        }
                        else if (rbtnData.Checked == true)
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            //
                            if (mtxtpData.Text != "" & mtxtpData1.Text != "")
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                if (bllLembrete.Sel_Lembrete_Data(mtxtpData.Text, mtxtpData1.Text, cbbSituacao.Text) == null)
                                {
                                    dtLembretes.DataSource = null;
                                }
                                else
                                {
                                    dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Data(mtxtpData.Text, mtxtpData1.Text, "");
                                    dtLembretes.Select();
                                }
                            }
                        }
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        if (dtLembretes.DataSource != null)
                        {
                            dtLembretes.Select();
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
                mtxtpData.Text = null;
                mtxtpData1.Text = null;
                dtLembretes.DataSource = null;
                rbtnData.Checked = true;
                mtxtpData.Select();
            }
        }

        private void rbtnEmAberto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnEmAberto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnFechada_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnFechada_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnAmbas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnAmbas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFinalizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFinalizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtLembretes.Rows[dtLembretes.CurrentRow.Index];

                string codigo = SelectedRow.Cells[0].Value.ToString();

                if (bllLembrete.Sel_Ver_Lemb_Fechado(codigo) == true)
                {
                    MessageBox.Show("O alarme selecionado não pôde ser finalizado pois o mesmo já foi finalizado anteriormente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    dtLembretes.DataSource = bllLembrete.Sel_Lembrete_A_Alt(SelectedRow.Cells[0].Value.ToString());
                    dtLembretes.Select();
                }
                else
                {
                    using (FrmUtilLembrete Alarme = new FrmUtilLembrete(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), 0, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Alarme.ShowDialog() == DialogResult.OK)
                        {
                            dtLembretes.DataSource = bllLembrete.Sel_Lembrete_A_Alt(codigo);
                            dtLembretes.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }
                mtxtpData.Text = null;
                mtxtpData1.Text = null;
                dtLembretes.DataSource = null;
                rbtnData.Checked = true;
                mtxtpData.Select();
            }
            this.Enabled = true;
        }

        private void pcibInterregocao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por data, descrição, código, usuário, tabela e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Situação:\nEm Aberto significa que o lembrete selecionado ainda não foi finalizado.\nFinalizado significa que o lembrete foi finalizado pelo usuário.\n2 - Finalizar: Clique para finalizar um lembrete que está em aberto.\n3 - Novo: Inclui um novo lembrete.\n4 - Alterar: Altera um lembrete cadastrado.\n5 - Multiplicar: Adiciona várias ocorrências de um lembrete.\n6 - Excluir: Exclui um lembrete cadastrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void rbtnUsuário_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnUsuário_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnUsuário_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            cbbSituacao.Enabled = true;
            cbbSituacao.Text = null;
            lblSituacao.Enabled = true;
            btnpProcurar.Visible = true;
            cbbUsuario.Visible = true;
            txtpTitulo.Visible = false;
            txtpCodigo.Visible = false;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            lblAte.Visible = false;
            lblPesquisar.Text = "Escolha o usuário:";
            lblPesquisar.Location = new Point(401, 19);
            cbbUsuario.Text = null;
            cbbUsuario.Select();
            btnSelecionarData.Visible = false;
            //
            try
            {
                cbbUsuario.Items.Clear();
                if (bllLembrete.Sel_Usuario_Lembrete() == null)
                {
                    cbbUsuario.Text = null;
                    btnpProcurar.Enabled = false;
                }
                else
                {
                    btnpProcurar.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllLembrete.Sel_Usuario_Lembrete().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do botão cbbUsuario.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do botão cbbUsuario.");
                }
                cbbUsuario.Text = null;
            }
        }

        private void cbbUsuario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnFechada_CheckedChanged(object sender, EventArgs e)
        {
            dtLembretes.DataSource = null;
        }

        private void rbtnEmAberto_CheckedChanged(object sender, EventArgs e)
        {
            dtLembretes.DataSource = null;
        }

        private void rbtnAmbas_CheckedChanged(object sender, EventArgs e)
        {
            dtLembretes.DataSource = null;
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(10, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllVenda.Sel_Usuario_Vend() == null)
                        {
                            cbbUsuario.Text = null;
                            btnpProcurar.Enabled = false;
                        }
                        else
                        {
                            btnpProcurar.Enabled = true;
                            cbbUsuario.Items.Add("");
                            foreach (DataRow dr in bllVenda.Sel_Usuario_Vend().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllLembrete._Usuario_PesqLembrete;
                        bllLembrete._Usuario_PesqLembrete = null;
                        cbbUsuario.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        cbbUsuario.Text = null;
                        bllLembrete._Usuario_PesqLembrete = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void cbbSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtLembretes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(5);
            }
            //
            if (e.ColumnIndex == 9 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void btnDuplicar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDuplicar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtLembretes.Rows[dtLembretes.CurrentRow.Index];

                if (bllLembrete.Sel_Lembrete_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível multiplicar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtLembretes.Select();
                }
                else
                {

                    using (FrmCadContaAdicionarParcelas Multi = new FrmCadContaAdicionarParcelas(2))
                    {
                        if (Multi.ShowDialog() == DialogResult.OK)
                        {
                            bllLembrete._Data_Vencimento_Multiplicada = SelectedRow.Cells[2].Value.ToString();
                            //
                            bllLembrete.Multiplicar(SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), bllLembrete._Ocorrencia, SelectedRow.Cells[0].Value.ToString());
                            //
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM OU MAIS LEMBRETES", "LEMBRETE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete multiplicado. Cod: " + SelectedRow.Cells[0].Value.ToString());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete multiplicado. Cod: " + SelectedRow.Cells[0].Value.ToString());
                            }
                            //
                            dtLembretes.DataSource = bllLembrete.Sel_Lembrete_Usuario(SelectedRow.Cells[6].Value.ToString(), "ABERTO");
                            //
                            bllLembrete._Data_Vencimento_Multiplicada = null;
                            bllLembrete._Dias = null;
                            bllLembrete._Ocorrencia = null;
                            //
                            MessageBox.Show("O(s) dado(s) foram(foi) salvo(s) com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDuplicar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDuplicar.");
                }
                mtxtpData.Text = null;
                mtxtpData1.Text = null;
                dtLembretes.DataSource = null;
                rbtnData.Checked = true;
                mtxtpData.Select();
            }
            this.Enabled = true;
        }

        private void rbtnTabela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTabela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTabela_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = true;
            lblEscolha.Visible = true;
            cbbSituacao.Enabled = true;
            cbbSituacao.Text = null;
            lblSituacao.Enabled = true;
            btnpProcurar.Visible = false;
            cbbUsuario.Visible = false;
            txtpTitulo.Visible = false;
            txtpCodigo.Visible = true;
            mtxtpData.Visible = false;
            mtxtpData1.Visible = false;
            lblAte.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(488, 19);
            cbbTabela.Text = "CONTAS A PAGAR";
            txtpCodigo.Text = null;
            cbbTabela.Select();
            btnSelecionarData.Visible = false;
        }

        private void cbbTabela_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTabela_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTabela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTabela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTabela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpCodigo.Select();
            }
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void grbBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
