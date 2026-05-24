using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqUsuario : Form
    {
        public FrmPesqUsuario(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmPesqUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\7 Sistema\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\7 Sistema\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\7 Sistema\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\7 Sistema\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqUsuario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqUsuario iniciado.");
                }
                //
                rbtnNomeUsuario.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqUsuario.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome de usuário, código, funcionário e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
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

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
              
        private void FrmPesqUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
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
                    if (rbtnFuncionario.Text != "")
                    {
                        if (bllUsuario.Sel_Funcionario_User(cbbpFuncionario.Text) == null)
                        {
                            dtUsuario.DataSource = null;
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
                    }
                    else
                    {
                        dtUsuario.DataSource = bllUsuario.Sel_Usuario_Todos();
                        dtUsuario.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou usuário.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou usuário.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
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
                this.DialogResult = DialogResult.None;
                txtpNomeUsuario.Text = null;
                txtpNomeUsuario.Select();
            }
            txtpNomeUsuario.BackColor = Color.White;
        }

        private void txtpNomeUsuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtUsuario_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtUsuario.DataSource == null)
            {
                dtUsuario.Enabled = false;
                btnIncluir.Enabled = false;
            }
            else
            {
                dtUsuario.Enabled = true;
                btnIncluir.Enabled = true;
            }
        }

        private void dtUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void dtUsuario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtUsuario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtUsuario.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void rbtnNomeUsuario_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            cbbpFuncionario.Visible = false;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = true;
            lblPesquisar.Location = new Point(256, 21);
            lblPesquisar.Text = "Digite o nome do usuário:";
            txtpNomeUsuario.Text = null;
            txtpNomeUsuario.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            cbbpFuncionario.Visible = false;
            txtpCodigo.Visible = true;
            txtpNomeUsuario.Visible = false;
            lblPesquisar.Location = new Point(367, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = true;
            cbbpFuncionario.Visible = true;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = false;
            lblPesquisar.Location = new Point(113, 21);
            lblPesquisar.Text = "Escolha o funcionario:";
            cbbpFuncionario.Text = null;
            cbbpFuncionario.Select();
            //
            cbbpFuncionario.Items.Clear();
            if (bllOrcamento.Sel_Funcionario_Orc() == null)
            {
                cbbpFuncionario.Enabled = false;
                cbbpFuncionario.Text = null;
            }
            else
            {
                cbbpFuncionario.Enabled = true;
                cbbpFuncionario.Items.Add("");
                foreach (DataRow dr in bllOrcamento.Sel_Funcionario_Orc().Rows)
                {
                    cbbpFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                }
            }
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            cbbpFuncionario.Visible = false;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = false;
            lblPesquisar.Location = new Point(380, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void dtUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void dtUsuario_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtUsuario.Columns[0].HeaderText = "Código";
            dtUsuario.Columns[1].HeaderText = "Nome de Usuário";
            dtUsuario.Columns[2].Visible = false;
            dtUsuario.Columns[3].HeaderText = "Cód. do Funcionário";
            dtUsuario.Columns[4].HeaderText = "Nome do Funcionário";

            dtUsuario.Columns[0].Width = 70;
            dtUsuario.Columns[1].Width = 290;
            dtUsuario.Columns[3].Width = 135;
            dtUsuario.Columns[4].Width = 550;

            dtUsuario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtUsuario.DefaultCellStyle.Font = new Font(dtUsuario.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtUsuario.Rows.Count;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllOrcamento._Orc_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtUsuario_DoubleClick(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllOrcamento._Orc_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllOrcamento._Orc_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            using (FrmPesqFuncionario Pesq = new FrmPesqFuncionario(0))
            {
                if (Pesq.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpFuncionario.Items.Clear();
                        if (bllOrcamento.Sel_Funcionario_Orc() == null)
                        {
                            cbbpFuncionario.Text = null;
                            cbbpFuncionario.Enabled = false;
                        }
                        else
                        {
                            cbbpFuncionario.Enabled = true;
                            btnpProcurar.Enabled = true;
                            cbbpFuncionario.Items.Add("");
                            foreach (DataRow dr in bllOrcamento.Sel_Funcionario_Orc().Rows)
                            {
                                cbbpFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        string[] itens = bllOrcamento._Orc_PesqFuncionario_Tabela.Split('—');
                        cbbpFuncionario.Text = itens[0] + "—" + itens[1];
                        bllOrcamento._Orc_PesqFuncionario_Tabela = null;
                        btnPesquisar.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        cbbpFuncionario.Items.Clear();
                        cbbpFuncionario.Text = null;
                        bllOrcamento._Orc_PesqFuncionario_Tabela = null;
                    }
                }
            }
        }

        private void dtUsuario_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void cbbpFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }
    }
}
