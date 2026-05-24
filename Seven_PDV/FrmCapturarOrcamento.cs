using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCapturarOrcamento : Form
    {
        public FrmCapturarOrcamento(byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmCapturarOrcamento_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarOrcamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarOrcamento iniciado.");
                }
                //
                txtCodigo.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCapturarOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCapturarOrcamento.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Contains("'") || txtCodigo.Text.Contains(";") || txtCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodigo.Text = null;
            }
            txtCodigo.BackColor = Color.White;
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            txtCodigo.BackColor = Color.LightBlue;
        }

        private void FrmCapturarOrcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarOrcamento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarOrcamento foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCapturarOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCapturarOrcamento.");
                }
            }
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informe o código do orçamento e clique em salvar para capturar o Orçamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmCapturarOrcamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n< Código do Orçamento >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtCodigo.Select();
                }
                else
                {
                    if (bllOrcamento.Sel_Cod_Orcamento_Existe_PDV(txtCodigo.Text.Trim()) == null)
                    {
                        MessageBox.Show("Orçamento não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (bllOrcamento.Sel_Data_Validade_Orc_PDV(txtCodigo.Text.Trim()) == false)
                    {
                        DialogResult = MessageBox.Show("O orçamento de código: [ " + txtCodigo.Text + " ] está expirado. Deseja continuar", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            MessageBox.Show("Orçamento encontrado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bllVenda._Cod_Orcamento = txtCodigo.Text;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            txtCodigo.Select();
                        }
                    }
                    else
                    {
                        if (_Formulario == 0)
                        {
                            DataRow dr = bllOrcamento.Sel_Cod_Orcamento_Existe_PDV(txtCodigo.Text.Trim()).Rows[0];
                            //
                            if (dr["situacao"].ToString() == "PENDENTE")
                            {
                                MessageBox.Show("Orçamento encontrado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllVenda._Cod_Orcamento = txtCodigo.Text;
                                this.DialogResult = DialogResult.OK;
                            }
                            else if (dr["situacao"].ToString() == "REALIZADO")
                            {
                                DialogResult = MessageBox.Show("Este Orçamento já foi realizado. Deseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    MessageBox.Show("Orçamento encontrado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bllVenda._Cod_Orcamento = txtCodigo.Text;
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    txtCodigo.Select();
                                }
                            }
                        }
                        else
                        {
                            DataRow dr = bllOrcamento.Sel_Cod_Orcamento_Existe_PDV(txtCodigo.Text.Trim()).Rows[0];
                            //
                            if (dr["situacao"].ToString() == "PENDENTE")
                            {
                                MessageBox.Show("Orçamento encontrado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllVenda._Cod_Orcamento = txtCodigo.Text;
                                this.DialogResult = DialogResult.OK;
                            }
                            else if (dr["situacao"].ToString() == "REALIZADO")
                            {
                                DialogResult = MessageBox.Show("Este Orçamento já foi realizado. Deseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    MessageBox.Show("Orçamento encontrado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bllVenda._Cod_Orcamento = txtCodigo.Text;
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    txtCodigo.Select();
                                }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                bllVenda._Cod_Orcamento = null;
                txtCodigo.Text = null;
                txtCodigo.Select();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqOrcamento Orc = new FrmPesqOrcamento(1, _Usuario, _Cod_PDV_Computador))
            {
                if (Orc.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    try
                    {
                        txtCodigo.Text = bllVenda._Cod_Orcamento;
                        bllVenda._Cod_Orcamento = null;
                        txtCodigo.Select();
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
                        txtCodigo.Text = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
    }
}
