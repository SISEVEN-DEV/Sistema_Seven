using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmSangriaSuprimento : Form
    {
        public FrmSangriaSuprimento(string usuario, string cod_pdv_computador, byte formulario, string valor_total_caixa)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
            _Valor_Total_Caixa = valor_total_caixa;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Valor_Total_Caixa;

        private void FrmSangriaSuprimento_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSangriaSuprimento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSangriaSuprimento iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    if (bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(_Cod_PDV_Computador) != null)
                    {
                        DataRow dr = bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(_Cod_PDV_Computador).Rows[0];
                        //
                        string _Data_Abertura = dr["data_abertura"].ToString().Remove(10);
                        string _Hora_Abertura = dr["hora_abertura"].ToString();

                        if (bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(_Data_Abertura, _Hora_Abertura) == null)
                        {
                            dtSangSup.DataSource = null;
                            btnNovo.Select();
                        }
                        else
                        {
                            dtSangSup.DataSource = bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(_Data_Abertura, _Hora_Abertura);
                            //
                            dtSangSup.Select();

                            dtSangSup.CurrentCell = dtSangSup.Rows[dtSangSup.Rows.Count - 1].Cells[0];

                            dtSangSup.Rows[dtSangSup.Rows.Count - 1].Selected = true;

                            dtSangSup.FirstDisplayedScrollingRowIndex = dtSangSup.Rows.Count - 1;
                        }
                    }
                    else
                    {
                        if (bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(DateTime.Now.ToShortDateString(), "00:00:00") == null)
                        {
                            dtSangSup.DataSource = null;
                            btnNovo.Select();
                        }
                        else
                        {
                            dtSangSup.DataSource = bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(DateTime.Now.ToShortDateString(), "00:00:00");
                            //
                            dtSangSup.Select();

                            dtSangSup.CurrentCell = dtSangSup.Rows[dtSangSup.Rows.Count - 1].Cells[0];

                            dtSangSup.Rows[dtSangSup.Rows.Count - 1].Selected = true;

                            dtSangSup.FirstDisplayedScrollingRowIndex = dtSangSup.Rows.Count - 1;
                        }
                    }
                }
                else if (_Formulario == 1)
                {
                    btnNovo_Click(sender, e);
                    //
                    txtValor.Text = _Valor_Total_Caixa;
                    //
                    lblDescricao.Enabled = false;
                    txtDescricao.Enabled = false;
                    txtDescricao.Text = "FECHAMENTO DE CAIXA";
                    //
                    label2.Enabled = false;
                    cbbTipo.Enabled = false;
                    lblTipo.Enabled = false;
                    cbbTipo.Text = "SANGRIA";
                    btnSair.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmSangriaSuprimento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmSangriaSuprimento.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtValor.Text = null;
            txtDescricao.Text = null;
            cbbTipo.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtSangSup.Enabled = true;
            dtSangSup.Select();
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];

                if (bllSangriaSuprimento.Sel_SangSup_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtSangSup.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Sangria/Suprimento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        bllSangriaSuprimento.Excluir(txtCodigo.Text);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sangria/Surpimento excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sangria/Surpimento excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                        }
                        //

                        //
                        if (cbbTipo.Text == "SANGRIA")
                        {
                            bllFluxoCaixa.Salvar(DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.'), DateTime.Now.ToString("HH:mm"), "ENTRADA", "RETORNO DE SANGRIA DE CAIXA", txtValor.Text, txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            bllRegistroAtividades.Salvar("EXCLUIU UMA SANGRIA", "SANGRIA /SUPRIMENTO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);

                        }
                        else if (cbbTipo.Text == "SUPRIMENTO")
                        {
                            bllFluxoCaixa.Salvar(DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.'), DateTime.Now.ToString("HH:mm"), "SAIDA", "RETORNO DE SUPRIMENTO DE CAIXA", txtValor.Text, txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            bllRegistroAtividades.Salvar("EXCLUIU UM SUPRIMENTO", "SANGRIA/SUPRIMENTO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);

                        }
                        //
                        DataRow dr = bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(_Cod_PDV_Computador).Rows[0];
                        //
                        string _Data_Abertura = dr["data_abertura"].ToString().Remove(10);
                        string _Hora_Abertura = dr["hora_abertura"].ToString();
                        //
                        if (bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(_Data_Abertura, _Hora_Abertura) == null)
                        {
                            dtSangSup.DataSource = null;
                            btnNovo.Select();
                        }
                        else
                        {
                            dtSangSup.DataSource = bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(_Data_Abertura, _Hora_Abertura);
                            //
                            dtSangSup.CurrentCell = dtSangSup.Rows[dtSangSup.Rows.Count - 1].Cells[0];

                            dtSangSup.Rows[dtSangSup.Rows.Count - 1].Selected = true;

                            dtSangSup.FirstDisplayedScrollingRowIndex = dtSangSup.Rows.Count - 1;
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
                dtSangSup.DataSource = null;
                ModoPesquisa();
                Limpar();
            }
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

        private void dtVenda_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtSangSup.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtValor.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (txtDescricao.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    txtDescricao.Select();
                }
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipo.Select();
            }
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                if (txtValor.Text.Contains("'") || txtValor.Text.Contains(";") || txtValor.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor.Text = null;
                    txtValor.Select();
                }
                else
                {
                    try
                    {
                        txtValor.Text = Convert.ToDecimal(txtValor.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (Convert.ToDecimal(txtValor.Text) > Convert.ToDecimal(_Valor_Total_Caixa) & _Formulario == 1)
                        {
                            MessageBox.Show("O valor da sangria não pode ser maior que o valor que você possui em caixa, que é de " + _Valor_Total_Caixa + " R$.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            txtValor.Text = _Valor_Total_Caixa;
                            txtValor.Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor.");
                        }
                        txtValor.Text = null;
                    }
                }
            }
            txtValor.BackColor = Color.White;
        }

        private void FrmSangriaSuprimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSangriaSuprimento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSangriaSuprimento foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmSangriaSuprimento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmSangriaSuprimento.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnGerarPDF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerarPDF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void dtSangSup_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtSangSup.DataSource == null)
            {
                btnExcluir.Enabled = false;
                dtSangSup.Enabled = false;
                btnGerarPDF.Enabled = false;
                btnGerarPDF.Enabled = false;
            }
            else
            {
                dtSangSup.Enabled = true;
                btnExcluir.Enabled = true;
                btnGerarPDF.Enabled = true;
                btnGerarPDF.Enabled = true;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtSangSup.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtSangSup.Enabled = false;
            grbBox1.Enabled = true;
            btnExcluir.Enabled = false;
            if (_Formulario == 0)
            {
                btnCancelar.Visible = true;
            }
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnGerarPDF.Enabled = false;
            Limpar();
            txtValor.Select();
            cbbTipo.Text = "SANGRIA";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtSangSup.DataSource == null)
            {
                Limpar();
            }
            else
            {
                Limpar();
                btnExcluir.Enabled = true;
            }
            ModoPesquisa();
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
                    if (txtValor.Text.Trim() == "" || cbbTipo.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Valor ] e [ Tipo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtValor.Select();
                    }
                    else
                    {
                        bllSangriaSuprimento.Salvar(txtDescricao.Text.Trim(), txtValor.Text.Trim(), _Usuario, cbbTipo.Text, _Cod_PDV_Computador);
                        //
                        DataRow dr = bllSangriaSuprimento.Sel_Ultima_Sangria_Suprimento().Rows[0];
                        //
                        string data, hora, valor, codigo, tipo;
                        //
                        data = dr["data"].ToString().Remove(10);
                        hora = dr["hora"].ToString().Remove(5);
                        valor = dr["valor"].ToString();
                        codigo = dr["id_sang_sup"].ToString();
                        tipo = dr["tipo"].ToString();
                        //
                        if (tipo == "SANGRIA")
                        {
                            bllFluxoCaixa.Salvar(data, hora, "SAIDA", "SANGRIA DE CAIXA", valor, codigo, _Usuario, _Cod_PDV_Computador);
                        }
                        else if (tipo == "SUPRIMENTO")
                        {
                            bllFluxoCaixa.Salvar(data, hora, "ENTRADA", "SUPRIMENTO DE CAIXA", valor, codigo, _Usuario, _Cod_PDV_Computador);
                        }
                        //
                        if (bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(_Cod_PDV_Computador) != null)
                        {
                            DataRow dr1 = bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(_Cod_PDV_Computador).Rows[0];
                            //
                            string _Data_Abertura = dr1["data_abertura"].ToString().Remove(10);
                            string _Hora_Abertura = dr1["hora_abertura"].ToString();
                            //
                            dtSangSup.DataSource = bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(_Data_Abertura, _Hora_Abertura);
                            //
                            dtSangSup.CurrentCell = dtSangSup.Rows[dtSangSup.Rows.Count - 1].Cells[0];
                            //
                            dtSangSup.Rows[dtSangSup.Rows.Count - 1].Selected = true;
                            //
                            dtSangSup.FirstDisplayedScrollingRowIndex = dtSangSup.Rows.Count - 1;
                        }
                        else
                        {
                            if (bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(DateTime.Now.ToShortDateString(), "00:00:00") == null)
                            {
                                dtSangSup.DataSource = null;
                                btnNovo.Select();
                            }
                            else
                            {
                                dtSangSup.DataSource = bllSangriaSuprimento.Sel_Sangria_Suprimento_Data_PDV(DateTime.Now.ToShortDateString(), "00:00:00");
                                //
                                dtSangSup.Select();

                                dtSangSup.CurrentCell = dtSangSup.Rows[dtSangSup.Rows.Count - 1].Cells[0];

                                dtSangSup.Rows[dtSangSup.Rows.Count - 1].Selected = true;

                                dtSangSup.FirstDisplayedScrollingRowIndex = dtSangSup.Rows.Count - 1;
                            }
                        }
                        //
                        DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];
                        //
                        bllRegistroAtividades.Salvar("SALVOU UMA SANGRIA/SUPRIMENTO.", "SANGRIA SUPRIMENTO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sangria/Suprimento cadastrada. Cod: " + SelectedRow.Cells[0].ToString() + " | Descrição: " + txtDescricao.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sangria/Suprimento cadastrada. Cod: " + SelectedRow.Cells[0].ToString() + " | Descrição: " + txtDescricao.Text);
                        }
                        //
                        ModoPesquisa();
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        //
                        using (FrmInfImpressao Imp = new FrmInfImpressao(3))
                        {
                            if (Imp.ShowDialog() == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.None;
                                dtSangSup.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                                this.Enabled = false;
                                if (bllSangriaSuprimento._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                                {
                                    Process.Start(bllSangriaSuprimento.GerarCupom(0, SelectedRow.Cells[0].Value.ToString()));
                                }
                                else if (bllSangriaSuprimento._Tipo_Impressao == "PDF A4")
                                {
                                    Process.Start(bllSangriaSuprimento.GerarCupom(1, SelectedRow.Cells[0].Value.ToString()));
                                }
                                this.Enabled = true;
                                dtSangSup.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.Abort;
                            }
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    txtValor.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                dtSangSup.DataSource = null;
                ModoPesquisa();
                Limpar();
            }
        }


        private void FrmSangriaSuprimento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else if (_Formulario == 1)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescricao.Text = null;
                txtDescricao.Select();
            }
            txtDescricao.BackColor = Color.White;
        }

        private void dtSangSup_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtSangSup.Columns[0].HeaderText = "Código";
            dtSangSup.Columns[1].HeaderText = "Descrição";
            dtSangSup.Columns[2].HeaderText = "Valor (R$)";
            dtSangSup.Columns[3].HeaderText = "Tipo";
            dtSangSup.Columns[4].HeaderText = "Data";
            dtSangSup.Columns[5].HeaderText = "Horário";
            dtSangSup.Columns[6].Visible = false;
            dtSangSup.Columns[7].Visible = false;
            dtSangSup.Columns[8].Visible = false;

            dtSangSup.Columns[0].Width = 85;
            dtSangSup.Columns[1].Width = 320;
            dtSangSup.Columns[2].Width = 155;
            dtSangSup.Columns[3].Width = 175;
            dtSangSup.Columns[4].Width = 115;
            dtSangSup.Columns[5].Width = 115;

            dtSangSup.DefaultCellStyle.Font = new Font(dtSangSup.Font, FontStyle.Bold);

            dtSangSup.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtSangSup.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistros.Text = "Registros: " + dtSangSup.Rows.Count;
        }

        private void dtSangSup_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtSangSup.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtSangSup.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                txtValor.Text = SelectedRow.Cells[2].Value.ToString();
                txtValor.Text = Convert.ToDecimal(txtValor.Text).ToString("n2", new CultureInfo("pt-BR"));
                dtSangSup.Columns[2].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtSangSup.Columns[2].DefaultCellStyle.Format = "n2";
                cbbTipo.Text = SelectedRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtSangSup.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtSangSup.");
                }
                dtSangSup.DataSource = null;
                ModoPesquisa();
                Limpar();
            }
        }

        private void dtSangSup_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtSangSup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n3 - Se por algum um motivo você clicou no botão [ Novo ] e não deseja continuar nessa opção, clique no botão\n[ Cancelar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValor.Select();
            }
        }

        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            using (FrmInfImpressao Imp = new FrmInfImpressao(3))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.DialogResult = DialogResult.None;
                        DataGridViewRow SelectedRow = dtSangSup.Rows[dtSangSup.CurrentRow.Index];
                        dtSangSup.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                        this.Enabled = false;
                        if (bllSangriaSuprimento._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                        {
                            Process.Start(bllSangriaSuprimento.GerarCupom(0, SelectedRow.Cells[0].Value.ToString()));
                        }
                        else if (bllSangriaSuprimento._Tipo_Impressao == "PDF A4")
                        {
                            Process.Start(bllSangriaSuprimento.GerarCupom(1, SelectedRow.Cells[0].Value.ToString()));
                        }
                        this.Enabled = true;
                        dtSangSup.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnGerarPDF.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnGerarPDF.");
                        }
                    }
                }
            }
        }
    }
}
