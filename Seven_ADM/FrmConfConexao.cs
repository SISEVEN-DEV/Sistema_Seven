using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL;
using System.Net;

namespace Seven_Sistema
{
    public partial class FrmConfConexao : Form
    {
        public FrmConfConexao()
        {
            InitializeComponent();
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Alterar = false;
        int _UltimaLinha_Sel;

        public void Limpar()
        {
            txtCodigo.Text = null;
            cbbTipoConexao.Text = null;
            txtCaminhoBanco.Text = null;
            txtNomeServIP.Text = null;
            txtDescFant.Text = null;
            txtSenha.Text = null;
            txtNomeDestePC.Text = null;
        }

        public void ModoPesquisa()
        {
            txtSenha.PasswordChar = '●';
            grbBox1.Enabled = false;
            btnNovoMini.Enabled = true;
            btnCancelarMini.Visible = false;
            btnSalvarMini.Enabled = false;
            dtConect.Enabled = true;
            dtConect.Select();
        }

        private void FrmAddEmpresaBanco_Load(object sender, EventArgs e)
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

                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexão iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexão iniciado.");
                }

                if (bllConexao.Sel_Todos_Conexao() == null)
                {
                    btnNovoMini.Select();
                }
                else
                {
                    dtConect.DataSource = bllConexao.Sel_Todos_Conexao();
                    dtConect.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConexão.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConexão.");
                }
                this.Close();
            }
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvarMini_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvarMini_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelarMini_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelarMini_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirMini_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirMini_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterarMini_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterarMini_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnNovoMini_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovoMini_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoConexao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoConexao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoConexao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoConexao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEscolherLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEscolherLocal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmConexao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnNovoMini_Click(object sender, EventArgs e)
        {            
            dtConect.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtConect.Enabled = false;
            grbBox1.Enabled = true;
            btnExcluirMini.Enabled = false;
            btnAlterarMini.Enabled = false;
            btnCancelarMini.Visible = true;
            btnNovoMini.Enabled = false;
            btnSalvarMini.Enabled = true;    
            Limpar();
            _Comando_Atualizar = false;
            _Inserir_Alterar = true;
            cbbTipoConexao.Text = "LOCAL";
            cbbTipoConexao.Select();
        }

        private void btnAlterarMini_Click(object sender, EventArgs e)
        {            
            dtConect.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtConect.Enabled = false;
            grbBox1.Enabled = true;
            btnNovoMini.Enabled = false;
            btnAlterarMini.Enabled = false;
            btnExcluirMini.Enabled = false;
            btnCancelarMini.Visible = true;
            btnSalvarMini.Enabled = true;
            if (cbbTipoConexao.SelectedIndex == 0)
            {                
                lblAsterisco3.Enabled = false;
                lblNomeServIP.Enabled = false;
                txtNomeServIP.Enabled = false;
            }
            else
            {
                lblAsterisco3.Enabled = true;
                lblNomeServIP.Enabled = true;
                txtNomeServIP.Enabled = true;
             }
            _Inserir_Alterar = true;            
            cbbTipoConexao.Select();
            _Comando_Atualizar = true;           
        }

        private void btnCancelarMini_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterarMini.Enabled = true;
                btnExcluirMini.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtConect.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterarMini.Enabled = true;
                    btnExcluirMini.Enabled = true;
                }
            }
            _Inserir_Alterar = false;
            ModoPesquisa();
        }

        private void btnSalvarMini_Click(object sender, EventArgs e)
        {
            try
            {               
                btnSalvarMini.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (txtNomeDestePC.Text.Trim() == "" || cbbTipoConexao.Text == "" || txtNomeServIP.Text.Trim() == "" || txtCaminhoBanco.Text.Trim().Trim() == "" || txtDescFant.Text.Trim().Trim() == "" || txtSenha.Text.Trim().Trim() == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: < Tipo de Conexão >, < Nome do Computador >, < Caminho para o banco de dados >, < Descrição/Fantasia > e < Senha de Autorização >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoConexao.Select();
                    }                    
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            _UltimaLinha_Sel = dtConect.Rows[dtConect.CurrentRow.Index].Index;

                            //bllConexao.Alterar(txtCodigo.Text, txtCaminhoBanco.Text.Trim(), cbbTipoConexao.Text, txtNomeServIP.Text.Trim(), txtDescFant.Text.Trim(), txtSenha.Text.Trim(), txtNomeDestePC.Text.Trim(), );

                            dtConect.DataSource = bllConexao.Sel_Todos_Conexao();

                            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão alterada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão alterada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            _Inserir_Alterar = false;
                            //
                            ModoPesquisa();
                            //
                            dtConect.CurrentCell = dtConect.Rows[_UltimaLinha_Sel].Cells[0];
                            //
                            dtConect.Rows[_UltimaLinha_Sel].Selected = true;
                            //
                            dtConect.FirstDisplayedScrollingRowIndex = _UltimaLinha_Sel;
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            //bllConexao.Salvar(txtCaminhoBanco.Text.Trim(), cbbTipoConexao.Text, txtNomeServIP.Text.Trim(), txtDescFant.Text.Trim(), txtSenha.Text.Trim(), txtNomeDestePC.Text.Trim(), txtOrdem.Text);

                            dtConect.DataSource = bllConexao.Sel_Todos_Conexao();

                            _Comando_Atualizar = false;
                            
                            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão cadastrada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão cadastrada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            //
                            _Inserir_Alterar = false;
                            //
                            ModoPesquisa();
                            //
                            dtConect.CurrentCell = dtConect.Rows[dtConect.Rows.Count - 1].Cells[0];
                            //
                            dtConect.Rows[dtConect.Rows.Count - 1].Selected = true;
                            //
                            dtConect.FirstDisplayedScrollingRowIndex = dtConect.Rows.Count - 1;
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    cbbTipoConexao.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarMini.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarMini.");
                }
                cbbTipoConexao.Text = null;
                dtConect.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }
        
        private void cbbTipoConexao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtNomeServIP.Enabled == false)
                {
                    txtCaminhoBanco.Select();
                }
                else
                {
                    txtNomeServIP.Select();
                }               
            }
        }

        private void txtCaminhoBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescFant.Select();
            }
        }

        private void txtNomeComputadorIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCaminhoBanco.Select();
            }
        }

        private void txtCaminhoBanco_Enter(object sender, EventArgs e)
        {
            txtCaminhoBanco.BackColor = Color.LightBlue;
        }

        private void txtCaminhoBanco_Leave(object sender, EventArgs e)
        {
            if (txtCaminhoBanco.Text.Contains(";") || txtCaminhoBanco.Text.Contains("'") || txtCaminhoBanco.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCaminhoBanco.Text = null;
                txtCaminhoBanco.Select();
            }
            else if (txtCaminhoBanco.Text != "")
            {
                if (!txtCaminhoBanco.Text.Contains(".FDB") & !txtCaminhoBanco.Text.Contains(".Fdb") & !txtCaminhoBanco.Text.Contains(".fdb") & !txtCaminhoBanco.Text.Contains(".fDb") & !txtCaminhoBanco.Text.Contains(".fdD"))
                {
                    MessageBox.Show("É necessário selecionar um banco de dados no formato (.FDB).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCaminhoBanco.Text = null;
                    txtCaminhoBanco.Select();
                    this.DialogResult = DialogResult.None;
                }
                else if (txtCaminhoBanco.Text.Length > 3)
                {
                    if(cbbTipoConexao.Text == "LOCAL" & txtCaminhoBanco.Text.Substring(0, 3) != @"C:\" & txtCaminhoBanco.Text.Substring(0, 3) != @"D:\" & txtCaminhoBanco.Text.Substring(0, 3) != @"E:\" & txtCaminhoBanco.Text.Substring(0, 3) != @"c:\" & txtCaminhoBanco.Text.Substring(0, 3) != @"d:\" & txtCaminhoBanco.Text.Substring(0, 3) != @"e:\")
                    {
                        MessageBox.Show("É necessário selecionar um banco de dados local.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCaminhoBanco.Text = null;
                        txtCaminhoBanco.Select();
                        this.DialogResult = DialogResult.None;
                    }
                }
            }           
            txtCaminhoBanco.BackColor = Color.White;
        }

        private void txtNomeComputadorIP_Enter(object sender, EventArgs e)
        {
            txtNomeServIP.BackColor = Color.LightBlue;
        }

        private void txtNomeComputadorIP_Leave(object sender, EventArgs e)
        {
            if (txtNomeServIP.Text.Contains(";") || txtNomeServIP.Text.Contains("'") || txtNomeServIP.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNomeServIP.Text = null;
                txtNomeServIP.Select();
            }
            txtNomeServIP.BackColor = Color.White;
        }

        private void txtDescFant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.Select();
            }
        }

        private void dtConect_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtConect.Rows.Count;
        }

        private void dtConect_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtConect_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtConect.Columns[0].HeaderText = "Código";
                dtConect.Columns[1].HeaderText = "Nome do Computador";
                dtConect.Columns[2].HeaderText = "Caminho para o Banco de Dados";
                dtConect.Columns[3].HeaderText = "Senha de Autorização";
                dtConect.Columns[4].HeaderText = "Tipo de Conexão";  
                dtConect.Columns[5].HeaderText = "Descrição/Fantasia da Empresa";
                             

                DataGridViewRow SelectedRow = dtConect.Rows[dtConect.CurrentRow.Index];

                dtConect.Columns[0].Width = 85;
                dtConect.Columns[1].Width = 320;
                dtConect.Columns[2].Width = 400;
                dtConect.Columns[3].Width = 135;
                dtConect.Columns[4].Width = 150;
                dtConect.Columns[5].Width = 320;
                

                dtConect.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtConect.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtConect.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConect.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtConect.DefaultCellStyle.Font = new Font(dtConect.Font, FontStyle.Bold);

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNomeServIP.Text = SelectedRow.Cells[1].Value.ToString();
                txtCaminhoBanco.Text = SelectedRow.Cells[2].Value.ToString();
                txtSenha.Text = SelectedRow.Cells[3].Value.ToString();
                cbbTipoConexao.Text = SelectedRow.Cells[4].Value.ToString();
                txtDescFant.Text = SelectedRow.Cells[5].Value.ToString();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtConect.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtConect.");
                }                
                dtConect.DataSource = null;
                dtConect.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void dtConect_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtConect.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtConect_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoConexao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Alterar == true)
            {
                if (cbbTipoConexao.SelectedIndex == 0)
                {
                    txtNomeDestePC.Text = Dns.GetHostName();
                    txtNomeServIP.Text = Dns.GetHostName();
                    txtNomeServIP.ReadOnly = true;
                    lblNomeServIP.ForeColor = Color.Blue;
                }
                else
                {
                    txtNomeDestePC.Text = Dns.GetHostName();
                    txtNomeServIP.Text = null;
                    txtNomeServIP.ReadOnly = false;
                    lblNomeServIP.ForeColor = Color.Black;
                }
            }
        }

        private void txtDescFant_Enter(object sender, EventArgs e)
        {
            txtDescFant.BackColor = Color.LightBlue;
        }

        private void txtDescFant_Leave(object sender, EventArgs e)
        {
            if (txtDescFant.Text.Contains(";") || txtDescFant.Text.Contains("'") || txtDescFant.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescFant.Text = null;
                txtDescFant.Select();
            }
            txtDescFant.BackColor = Color.White;
        }

        private void FrmConexao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexao foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexao foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConexao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConexao.");
                }
                this.DialogResult = DialogResult.Abort;
            }           
        }

        private void btnExcluirMini_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja excluir esta conexão?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    bllConexao.Excluir(txtCodigo.Text);

                    bllConexao.Atualizar_Item_Dt_Conexao(dtConect.CurrentRow.Index + 1, dtConect.Rows.Count);

                    using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão excluída. Cod: " + txtCodigo.Text + " | Tipo: " + cbbTipoConexao.Text);
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão excluída. Cod: " + txtCodigo.Text + " | Tipo: " + cbbTipoConexao.Text);
                    }

                    if (bllConexao.Sel_Todos_Conexao() == null)
                    {
                        dtConect.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtConect.DataSource = bllConexao.Sel_Todos_Conexao();
                        dtConect.Select();
                    }
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
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
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirMini.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirMini.");
                }                
                dtConect.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void dtConect_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtConect.DataSource == null)
            {
                dtConect.Enabled = false;
                btnExcluirMini.Enabled = false;
                btnAlterarMini.Enabled = false;
            }
            else
            {
                dtConect.Enabled = true;
                btnExcluirMini.Enabled = true;
                btnAlterarMini.Enabled = true;
            }
        }
        
        private void btnEscolherLocal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Title = "Selecione um banco de dados";
                file.Filter = "Banco de dados no formato:(*.FDB)|*.FDB";
                file.InitialDirectory = @"C:\";
                
                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (file.FileName.Length > 60)
                    {
                        MessageBox.Show("O caminho escolhido é muito longo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        txtCaminhoBanco.Text = file.FileName;
                    }
                }
            }
        }

        private void dtConect_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                dtConect.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (txtSenha.PasswordChar == '●')
            {
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '●';
            }
        }

        private void btnVer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue;
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvarMini.Select();
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text.Contains(";") || txtSenha.Text.Contains("'") || txtSenha.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtSenha.Text = null;
                txtSenha.Select();
            }
            txtSenha.BackColor = Color.White;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Tipo de Conexão: Conexão local significa que o banco de dados que esta aplicação irá se conectar se encontra neste computador, conexão remota significa que o banco de dados que está aplicação irá se conectar está em um outro computador.\n\n2 - Nome do Computador: É o nome do computador que possui o banco de dados a qual esta aplicação irá se conectar.\n\n3 - Nome deste Computador: Nome atual do computador.\n\n4 - Caminho para o Banco de Dados: Nesta caixa de texto é onde será informado o diretório para o banco de dados.\n\n5 - Descrição/Razão Social/Fantasia: Este campo identificará o banco de dados.\n\n6 - Senha de Autorização: É a senha que permite que este computador conecte ao servidor(local ou remoto) solicitado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNomeDestePC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescFant.Select();
            }
        }
    }
}
