using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelUsuario : Form
    {
        public FrmRelUsuario(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Trabalho;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmRelUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                bllUsuario._FrmRelUsuario_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelUsuario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelUsuario iniciado.");
                }
                //
                rbtnNomeUsuario.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelUsuario.");
                }
                this.Close();
            }
        }

        private void rbtnNomeUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNomeUsuario_MouseLeave(object sender, EventArgs e)
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

        private void rbtnFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpFuncionario.Items.Clear();

                if (bllUsuario.Sel_Funcionario_Usuario() == null)
                {
                    cbbpFuncionario.Text = null;
                }
                else
                {
                    cbbpFuncionario.Items.Add("");
                    foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                    {
                        cbbpFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpFuncionario.");
                }
                cbbpFuncionario.Text = null;
            }
            //
            btnpProcurar.Visible = true;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = false;
            cbbpFuncionario.Visible = true;
            lblPesquisar.Text = "Escolha o funcionário:";
            lblPesquisar.Location = new Point(212, 21);
            cbbpFuncionario.Text = null;
            cbbpFuncionario.Select();
        }

        private void rbtnFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnFuncionario_MouseLeave(object sender, EventArgs e)
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

        private void cbbpFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpFuncionario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpFuncionario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
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

        private void btnImprimirRel_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimirRel_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnImprimirRel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnExportarTxt_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnExportarTxt_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExportarCsv_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExportarCsv_MouseLeave(object sender, EventArgs e)
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

        private void FrmRelUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelUsuario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelUsuario foi finalizado.");
                }
                bllUsuario._FrmRelUsuario_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelUsuario.");
                }
            }
        }

        private void FrmRelUsuario_KeyUp(object sender, KeyEventArgs e)
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

        private void rbtnNomeUsuario_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = true;
            cbbpFuncionario.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Digite o nome:";
            lblPesquisar.Location = new Point(418, 21);
            txtpNomeUsuario.Text = null;
            txtpNomeUsuario.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            txtpCodigo.Visible = true;
            txtpNomeUsuario.Visible = false;
            cbbpFuncionario.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(466, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = false;
            cbbpFuncionario.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(479, 21);
            btnPesquisar.Select();
        }

        private void txtpNomeUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpNomeUsuario_Enter(object sender, EventArgs e)
        {
            txtpNomeUsuario.BackColor = Color.LightBlue;
        }

        private void txtpNomeUsuario_Leave(object sender, EventArgs e)
        {
            if (txtpNomeUsuario.Text.Contains("'") || txtpNomeUsuario.Text.Contains(";") || txtpNomeUsuario.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpNomeUsuario.Text = null;
            }
            txtpNomeUsuario.BackColor = Color.White;
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
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void cbbpFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmPesqFuncionario Func = new FrmPesqFuncionario(1, _Usuario, _Cod_PDV_Computador))
            {
                if (Func.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpFuncionario.Items.Clear();

                        if (bllUsuario.Sel_Funcionario_Usuario() == null)
                        {
                            cbbpFuncionario.Text = null;
                        }
                        else
                        {
                            cbbpFuncionario.Items.Add("");
                            foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                            {
                                cbbpFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        //
                        cbbpFuncionario.Text = bllUsuario._User_PesqFuncionario_Tabela;
                        bllUsuario._User_PesqFuncionario_Tabela = null;
                        cbbpFuncionario.Select();
                    }
                    catch (Exception ex)
                    {
                        pPanel.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        bllUsuario._User_PesqFuncionario_Tabela = null;
                        cbbpFuncionario.Text = null;
                    }
                }
            }
            pPanel.Enabled = true;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome, código, funcionário, todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtGrupo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtUsuario.Columns[0].HeaderText = "Código";
            dtUsuario.Columns[1].HeaderText = "Nome";
            if (bllUsuario.Sel_Permitir_Vis_Senha_Usuario(_Usuario) == true)
            {
                dtUsuario.Columns[2].HeaderText = "Senha";
                dtUsuario.Columns[2].Width = 150;
            }
            else
            {
                dtUsuario.Columns[2].Visible = false;
            }
            dtUsuario.Columns[3].HeaderText = "Cod. do Funcionário";
            dtUsuario.Columns[4].HeaderText = "Nome do Funcionário";
            dtUsuario.Columns[5].HeaderText = "Data de Cadastro";

            dtUsuario.Columns[0].Width = 70;
            dtUsuario.Columns[1].Width = 298;
            dtUsuario.Columns[3].Width = 135;
            dtUsuario.Columns[4].Width = 550;
            dtUsuario.Columns[5].Width = 120;

            dtUsuario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtUsuario.DefaultCellStyle.Font = new Font(dtUsuario.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtUsuario.Rows.Count;
        }

        private void dtUsuario_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                dtUsuario.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void dtUsuario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtUsuario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtUsuario.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtUsuario.");
                }
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
            }
        }

        private void dtUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtUsuario.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtUsuario_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtUsuario.DataSource == null)
            {
                dtUsuario.Enabled = false;
                grbBox2.Enabled = false;
            }
            else
            {
                dtUsuario.Enabled = true;
                grbBox2.Enabled = true;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnNomeUsuario.Checked == true)
                {
                    if (txtpNomeUsuario.Text != "")
                    {
                        if (bllUsuario.Sel_Usuario_Nome_Usuario(txtpNomeUsuario.Text) == null)
                        {
                            dtUsuario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtUsuario.DataSource = bllUsuario.Sel_Usuario_Nome_Usuario(txtpNomeUsuario.Text);
                            dtUsuario.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllUsuario.Sel_Codigo_User(txtpCodigo.Text) == null)
                        {
                            dtUsuario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtUsuario.DataSource = bllUsuario.Sel_Codigo_User(txtpCodigo.Text);
                            dtUsuario.Select();
                        }
                    }
                }
                else if (rbtnFuncionario.Checked == true)
                {
                    if (cbbpFuncionario.Text != "")
                    {
                        if (bllUsuario.Sel_Funcionario_User(cbbpFuncionario.Text) == null)
                        {
                            dtUsuario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtUsuario.DataSource = bllUsuario.Sel_Funcionario_User(cbbpFuncionario.Text);
                            dtUsuario.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllUsuario.Sel_Usuario_Todos() == null)
                    {
                        dtUsuario.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtUsuario.DataSource = bllUsuario.Sel_Usuario_Todos();
                        dtUsuario.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou usuário.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou usuário.");
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
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
            }
        }

        private void btnImprimirRel_Click(object sender, EventArgs e)
        {
            using (FrmInfImpressao Imp = new FrmInfImpressao(37))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 0;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtUsuario.Enabled = false;
                    dtUsuario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    DataRow dr;
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllUsuario._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 100, 116);
                    }
                    //DATA
                    graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 5 + Margem_Topo, 95, 122);
                    textFormatter2.DrawString("Criado em:", fonte4, XBrushes.Black, new XRect(515 + Margem_Esq, 10 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToShortDateString(), fonte1, XBrushes.Black, new XRect(510 + Margem_Esq, 22 + Margem_Topo, page.Width, page.Height));
                    //HORÁRIO                    
                    textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(527 + Margem_Esq, 72 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToLongTimeString(), fonte1, XBrushes.Black, new XRect(516 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
                    //CABECALHO  DOCUMENTO
                    dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    if (!dr["nome"].ToString().Contains(" ") & dr["nome"].ToString().Length > 38)
                    {
                        textFormatter1.DrawString(dr["nome"].ToString().Insert(38, Environment.NewLine), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    else
                    {
                        textFormatter1.DrawString(dr["nome"].ToString(), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    //
                    textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + "CPF/CNPJ.: " + dr["cpf_cnpj"].ToString() + ", IE.: " + dr["ie_rg"].ToString() + Environment.NewLine + "End.: " + dr["endereco"].ToString() + Environment.NewLine + dr["complemento"].ToString() + ", " + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + "Tel.: " + dr["telefone"].ToString() + ", Cel.: " + dr["celular"].ToString() + Environment.NewLine + "E-mail.: " + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                    //
                    textFormatter1.DrawString("Relatório de Usuários", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("NOME", fonte1, XBrushes.Black, new XRect(90 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("FUNCIONÁRIO", fonte1, XBrushes.Black, new XRect(180 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtUsuario.Rows.Count; i++)
                    {
                        if (i == 16)
                        {
                            TotalPaginas = TotalPaginas + 1;
                        }
                        else if (i == registros)
                        {
                            registros = registros + 21;
                            TotalPaginas = TotalPaginas + 1;
                        }
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //                    
                    for (int linha = 0; linha < dtUsuario.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtUsuario.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtUsuario.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 212) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(90 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString() + "-" + SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(234 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                }
                                Incrementar = 36 + Incrementar;
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 212) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(90 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString() + "-" + SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(234 + Margem_Esq, (Incrementar + 212) + Margem_Topo, page.Width, page.Height));
                                }
                                Incrementar = 36 + Incrementar;
                            }
                            //
                            if (linha == (pagina - 1) & dtUsuario.Rows.Count > 16)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 22;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de Usuários", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                        }
                        else
                        {
                            if (linha == (pagina - 1))
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 21;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de Usuários", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtUsuario.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 34) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(90 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString() + "-" + SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(234 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                }
                                Incrementar = 36 + Incrementar;
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(20 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(54 + Margem_Esq, (Incrementar + 34) + Margem_Topo, 75, 18));
                                textFormatter2.DrawString("Nome:", fonte2, XBrushes.Black, new XRect(90 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(120 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[3].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString() + "-" + SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(234 + Margem_Esq, (Incrementar + 34) + Margem_Topo, page.Width, page.Height));
                                }
                                Incrementar = 36 + Incrementar;
                            }
                        }
                    }
                    //
                    PdfSecuritySettings security = doc.SecuritySettings;
                    //
                    security.PermitAccessibilityExtractContent = false;
                    security.PermitAnnotations = false;
                    security.PermitAssembleDocument = false;
                    security.PermitExtractContent = false;
                    security.PermitFormsFill = true;
                    security.PermitFullQualityPrint = false;
                    security.PermitModifyDocument = false;
                    security.PermitPrint = true;
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.txt"))
                {
                    writer.WriteLine("Relatório de Usuários" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtUsuario.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtUsuario.Rows[linha];
                        string data_cadastro = SelectedRow.Cells[5].Value.ToString();
                        //
                        if (data_cadastro == "" || data_cadastro == null)
                        {
                            data_cadastro = "";
                        }
                        else
                        {
                            data_cadastro = data_cadastro.Remove(10);
                        }
                        //
                        string cod_funcionario = SelectedRow.Cells[3].Value.ToString();
                        if (cod_funcionario == "0")
                        {
                            cod_funcionario = "";
                        }
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Nome: " + SelectedRow.Cells[1].Value.ToString() + " |Cód. do Funcionário: " + cod_funcionario + " |Nome do Funcionário: " + SelectedRow.Cells[4].Value.ToString() + " |Data de Cadastro: " + data_cadastro);
                    }
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.txt");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Nome;Cód. do Funcionário;Nome do Funcionário;Data de Cadastro");
                    for (int linha = 0; linha < dtUsuario.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtUsuario.Rows[linha];
                        //                        
                        string data_cadastro = SelectedRow.Cells[5].Value.ToString();
                        //
                        if (data_cadastro == "" || data_cadastro == null)
                        {
                            data_cadastro = "";
                        }
                        else
                        {
                            data_cadastro = data_cadastro.Remove(10);
                        }
                        //
                        string cod_funcionario = SelectedRow.Cells[3].Value.ToString();
                        //
                        if (cod_funcionario == "0")
                        {
                            cod_funcionario = "";
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), cod_funcionario, SelectedRow.Cells[4].Value.ToString(), data_cadastro));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Usuários");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.csv");
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                //
                pgbProgresso.Value = 0;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtUsuario.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
                picbInterrogacao3.Enabled = true;
                btnSair.Enabled = true;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtUsuario.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtUsuario.Select();

                try
                {
                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Usuarios\Usuarios.pdf");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    //
                    pgbProgresso.Value = 0;
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    dtUsuario.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao2.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnNomeUsuario.Checked = true;
                }
            }
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 1;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtUsuario.Enabled = false;
            dtUsuario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao2.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtUsuario.Enabled = false;
            dtUsuario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao2.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples resumido em PDF.\n\n2 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n3 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
