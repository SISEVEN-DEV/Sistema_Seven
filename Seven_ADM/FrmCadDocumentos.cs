using BLL;
using Seven_ADM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadDocumentos : Form
    {
        public FrmCadDocumentos(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            //
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            //
            if (formulario == 0)
            {
                lblClieConsFornFunc.Visible = false;
                cbbClieConsFuncForn.Visible = false;
                btnProcurarClieFornFunc.Visible = false;
                lblAsterisco2.Visible = false;
                lblVisualizacao.Visible = false;
                btnAdicionar.Visible = false;
                btnRemover.Visible = false;
                dtDestinatario.Visible = false;
            }
            else
            {
                lblClieConsFornFunc.Visible = true;
                cbbClieConsFuncForn.Visible = true;
                btnProcurarClieFornFunc.Visible = true;
                lblAsterisco2.Visible = true;
                lblVisualizacao.Visible = true;
                btnAdicionar.Visible = true;
                btnRemover.Visible = true;
                dtDestinatario.Visible = true;
            }
        }

        private byte _Formulario;
        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _ComboboxGrupo_Valor = null;
        private string _ComboboxSubGrupo_Valor = null;
        private bool _Checkbox_Ativo = false;
        private bool _Mudou_Arquivo = false;

        private void FrmCadDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                bllDocumentos._FrmCadDocumentos_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocumentos iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocumentos iniciado.");
                }
                //
                cbbpGrupo.Items.Clear();
                if (bllDocumentos.Sel_Grupo_Doc() == null)
                {
                    cbbpGrupo.Text = null;
                }
                else
                {
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllDocumentos.Sel_Grupo_Doc().Rows)
                    {
                        cbbpGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadDocumentos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadDocumentos.");
                }
            }
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtDocumento.DataSource != null)
            {
                dtDocumento.Enabled = true;
                dtDocumento.Select();
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtDescricao.Text = null;
            mtxtData.Text = null;
            mtxtHorario.Text = null;
            cbbSituacao.Text = null;
            cbbGrupo.Text = null;
            cbbSubGrupo.Text = null;
            rtxtObs.Text = null;
            dtDestinatario.DataSource = null;
            pcibCross.Visible = false;
            pcibTick.Visible = false;
            lblArquivo.Visible = false;
            bllDocumentos._Nome_Arquivo = null;
        }




        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                //try
                //{
                mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                //
                if (_Formulario == 0)
                {
                    if (cbbSituacao.Text == "" || cbbGrupo.Text.Trim() == "" || cbbSubGrupo.Text == "" || mtxtData.Text == "" || mtxtHorario.Text == "" || bllDocumentos._Nome_Arquivo == null)
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Situação ], [ Grupo ], [ Data e Horário de Competência ], [ Sub-Grupo ] e [ Arquivo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtDescricao.Select();
                        return;
                    }
                }
                else
                {
                    if (cbbSituacao.Text == "" || cbbGrupo.Text.Trim() == "" || cbbSubGrupo.Text == "" || dtDestinatario.Rows.Count == 0)
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Situação ], [ Grupo ] e\n[ Sub-Grupo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtDescricao.Select();
                        return;
                    }
                }
                //
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                if (_Comando_Atualizar == true)
                {
                    DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];

                    if (bllDocumentos.Sel_Documento_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                    {
                        MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtDocumento.DataSource = null;
                        ModoPesquisa();
                        Limpar();
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                    }
                    else
                    {
                        bllDocumentos.Alterar(txtCodigo.Text, txtDescricao.Text.Trim(), mtxtData.Text, mtxtHorario.Text, cbbSituacao.Text, cbbGrupo.Text, cbbSubGrupo.Text, rtxtObs.Text, bllDocumentos._Nome_Arquivo, _Usuario, "", "", SelectedRow.Cells[16].Value.ToString(), _Mudou_Arquivo);

                        dtDocumento.DataSource = bllDocumentos.Sel_Documento_A_Alt(txtCodigo.Text);

                        bllDocumentos._Nome_Arquivo = null;

                        bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM DOCUMENTO", "DOCUMENTO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Documento alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Documento alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                        }

                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                        _Mudou_Arquivo = false;

                        ModoPesquisa();

                        MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    bllDocumentos.Salvar(txtDescricao.Text.Trim(), mtxtData.Text, mtxtHorario.Text, cbbSituacao.Text, cbbGrupo.Text, cbbSubGrupo.Text, rtxtObs.Text, bllDocumentos._Nome_Arquivo, _Usuario, "", "");

                    dtDocumento.DataSource = bllDocumentos.Sel_Documento_A_Salvar();

                    bllDocumentos._Nome_Arquivo = null;

                    bllRegistroAtividades.Salvar("SALVOU UM DOCUMENTO", "DOCUMENTO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Documento cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Documento cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                    }

                    _Comando_Atualizar = false;
                    _Inserir_Atualizar = false;

                    ModoPesquisa();

                    MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
                /*
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
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
                dtDocumento.DataSource = null;
                _Mudou_Arquivo = false;
                _Checkbox_Ativo = false;
                Limpar();
                ModoPesquisa();
            }
                */
            }
            else
            {
                this.DialogResult = DialogResult.None;
                txtCodigo.Select();
            }
        }



        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadDocumentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocumentos foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadDocumentos foi finalizado.");
                }
                bllDocumentos._FrmCadDocumentos_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadDocumentos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadDocumentos.");
                }
            }
        }

        private void FrmCadDocumentos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtDocumento.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtDocumento.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Visible = true;
            btnVisualizarDocumento.Enabled = false;
            btnExportarDocumento.Enabled = false;
            btnEnviarDocumentoZap.Enabled = false;
            btnEnviarDocumentoEmail.Enabled = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            _Inserir_Atualizar = true;
            _Comando_Atualizar = false;
            Limpar();
            txtDescricao.Select();
            cbbSubGrupo.Enabled = false;
            btnProcurar2.Enabled = false;
            cbbSituacao.Text = "ATIVO";
            mtxtData.Text = DateTime.Now.ToShortDateString();
            mtxtHorario.Text = DateTime.Now.ToLongTimeString();
            pcibCross.Visible = true;
            lblArquivo.Text = "Documento pendente.";
            lblArquivo.Visible = true;
            //
            try
            {
                cbbGrupo.Items.Clear();
                if (bllDocumentos.Sel_Grupo_Doc() == null)
                {
                    cbbGrupo.Text = null;
                }
                else
                {
                    cbbGrupo.Items.Add("");
                    foreach (DataRow dr in bllDocumentos.Sel_Grupo_Doc().Rows)
                    {
                        cbbGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                cbbGrupo.Text = "6—DOCUMENTOS NO GERAL";
                cbbSubGrupo.Text = "6—GERAL";
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
                dtDocumento.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
                _Mudou_Arquivo = false;
                _Checkbox_Ativo = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnVisualizarDocumento.Enabled = true;
                btnExportarDocumento.Enabled = true;
                btnEnviarDocumentoZap.Enabled = true;
                btnEnviarDocumentoEmail.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtDocumento.DataSource == null)
                {
                    Limpar();
                    btnVisualizarDocumento.Enabled = false;
                    btnExportarDocumento.Enabled = false;
                    btnEnviarDocumentoZap.Enabled = false;
                    btnEnviarDocumentoEmail.Enabled = false;
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnVisualizarDocumento.Enabled = true;
                    btnExportarDocumento.Enabled = true;
                    btnEnviarDocumentoZap.Enabled = true;
                    btnEnviarDocumentoEmail.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            ModoPesquisa();
            bllDocumentos._Nome_Arquivo = null;
            _Mudou_Arquivo = false;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescricao.Text = null;
                txtDescricao.Select();
            }
            txtDescricao.BackColor = Color.White;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtData.Select();
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

        private void cbbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    if (cbbGrupo.Text != "")
                    {
                        string[] items = cbbGrupo.SelectedItem.ToString().Split('—');
                        cbbSubGrupo.Items.Clear();
                        if (bllDocumentos.Sel_SubGrupo_Doc(items[0]) == null)
                        {
                            cbbSubGrupo.Text = null;
                            cbbSubGrupo.Enabled = false;
                            btnProcurar2.Enabled = false;
                            lblSubGrupo.Enabled = false;
                            lblAsterisco4.Enabled = false;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllDocumentos.Sel_SubGrupo_Doc(items[0]).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblSubGrupo.Enabled = true;
                                lblAsterisco4.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        cbbSubGrupo.Items.Clear();
                        cbbSubGrupo.Text = null;
                        cbbSubGrupo.Enabled = false;
                        btnProcurar2.Enabled = false;
                        lblSubGrupo.Enabled = false;
                        lblAsterisco4.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                    }
                    cbbGrupo.Text = null;
                    cbbSubGrupo.Text = null;
                }
            }
        }

        private void cbbSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtData.Text == "")
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtData.Text == "")
                {
                    mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }

        }

        private void mtxtData_Leave(object sender, EventArgs e)
        {
            mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtData.Text != "")
            {
                try
                {
                    mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtData.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtData.");
                    }
                    mtxtData.Text = null;
                }
            }
            mtxtData.BackColor = Color.White;
        }

        private void mtxtData_Enter(object sender, EventArgs e)
        {
            mtxtData.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text == "")
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario.Text == "")
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario_Leave(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text != "")
            {
                if (mtxtHorario.Text.Length == 4)
                {
                    mtxtHorario.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorario.Text = null;
                }
            }
            mtxtHorario.BackColor = Color.White;
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGrupo.Select();
            }
        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }

        private void cbbSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbSubGrupo.Enabled == false)
                {
                    rtxtObs.Select();
                }
                else
                {
                    cbbSubGrupo.Select();
                }
            }
        }

        private void cbbSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();
            }
        }

        private void mtxtData_DoubleClick(object sender, EventArgs e)
        {
            mtxtData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtData.Text == "")
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(7))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtData.Text = bllDocumentos._Data_DatePicker1;
                }
            }
            pEnabled.Enabled = true;
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                rtxtObs.Text = null;
                rtxtObs.Select();
            }
            rtxtObs.BackColor = Color.White;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtDestinatario.Visible == true)
                {
                    dtDestinatario.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
            }
        }

        private void mtxtpData_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text == "")
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpData.Text == "")
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpData_Leave(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text != "")
            {
                try
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData.Text);
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
                }
            }
            mtxtpData.BackColor = Color.White;
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
        }

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpHorario.Select();
            }
        }

        private void mtxtpHorario_DoubleClick(object sender, EventArgs e)
        {
            mtxtpHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpHorario.Text == "")
            {
                mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpHorario.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpHorario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpHorario.Text == "")
                {
                    mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpHorario.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpHorario_Leave(object sender, EventArgs e)
        {
            mtxtpHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpHorario.Text != "")
            {
                if (mtxtpHorario.Text.Length == 4)
                {
                    mtxtpHorario.Text = mtxtpHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtpHorario.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpHorario.");
                    }
                    mtxtpHorario.Text = null;
                }
            }
            mtxtpHorario.BackColor = Color.White;
        }

        private void mtxtpHorario_Enter(object sender, EventArgs e)
        {
            mtxtpHorario.BackColor = Color.LightBlue;
        }

        private void mtxtpHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
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
            else
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpData1.Text == "")
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpData1_Leave(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text != "")
            {
                try
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData1.Text);
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
                    mtxtpData1.Text = null;
                }
            }
            mtxtpData1.BackColor = Color.White;
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpHorario1.Select();
            }
        }

        private void mtxtpHorario1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpHorario1.Text == "")
            {
                mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpHorario1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpHorario1.Text == "")
                {
                    mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpHorario1_Leave(object sender, EventArgs e)
        {
            mtxtpHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpHorario1.Text != "")
            {
                if (mtxtpHorario1.Text.Length == 4)
                {
                    mtxtpHorario1.Text = mtxtpHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtpHorario1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpHorario1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpHorario1.");
                    }
                    mtxtpHorario1.Text = null;
                }
            }
            mtxtpHorario1.BackColor = Color.White;
        }

        private void mtxtpHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpCodigo.Select();
            }
        }

        private void mtxtpHorario1_Enter(object sender, EventArgs e)
        {
            mtxtpHorario1.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (cbbClieConsFuncForn.Visible == true)
                {
                    cbbClieConsFuncForn.Select();
                }
                else
                {
                    cbbpGrupo.Select();
                }

            }
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

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void cbbpUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void cbbpSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbpSubGrupo.Enabled == true)
                {
                    cbbpSubGrupo.Select();
                }
                else
                {
              
                }
            }
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
               
            }
        }

        private void cbbpGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.SelectedItem.ToString().Split('—');
                    cbbpSubGrupo.Items.Clear();
                    if (bllDocumentos.Sel_SubGrupo_Doc(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnpProcurarSubGrupo.Enabled = false;
                        lblpSubGrupo.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllDocumentos.Sel_SubGrupo_Doc(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                            cbbpSubGrupo.Enabled = true;
                            btnpProcurarSubGrupo.Enabled = true;
                            lblpSubGrupo.Enabled = true;
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnpProcurarSubGrupo.Enabled = false;
                    lblpSubGrupo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(7))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbGrupo.Items.Clear();
                        if (bllDocumentos.Sel_Grupo_Doc() == null)
                        {
                            cbbGrupo.Text = null;
                            cbbSubGrupo.Items.Clear();
                            cbbSubGrupo.Enabled = false;
                            cbbSubGrupo.Text = null;
                            btnProcurar2.Enabled = false;
                            lblSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllDocumentos.Sel_Grupo_Doc().Rows)
                            {
                                cbbGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblSubGrupo.Enabled = true;
                            }
                        }

                        cbbGrupo.Text = bllDocumentos._Grupo_PesqGrupo_Tabela;
                        bllDocumentos._Grupo_PesqGrupo_Tabela = null;
                        cbbGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        cbbGrupo.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnpProcurarGrupo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(7))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllDocumentos.Sel_Grupo_Doc() == null)
                        {
                            cbbpGrupo.Text = null;
                            cbbpSubGrupo.Enabled = false;
                            cbbpSubGrupo.Text = null;
                            btnpProcurarSubGrupo.Enabled = false;
                            lblpSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllDocumentos.Sel_Grupo_Doc().Rows)
                            {
                                cbbpGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                                cbbpSubGrupo.Enabled = true;
                                btnpProcurarSubGrupo.Enabled = true;
                                lblpSubGrupo.Enabled = true;
                            }
                        }

                        cbbpGrupo.Text = bllDocumentos._Grupo_PesqGrupo_Tabela;
                        bllDocumentos._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        cbbpGrupo.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnpProcurarSubGrupo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 5))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();

                            if (bllDocumentos.Sel_SubGrupo_Doc(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllDocumentos.Sel_SubGrupo_Doc(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                            }
                            cbbpSubGrupo.Text = bllDocumentos._SubGrupo_PesqSubGrupo_Tabela;
                            bllDocumentos._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbpSubGrupo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                cbbpSubGrupo.Text = null;
            }
            pEnabled.Enabled = true;
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbClieConsFuncForn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpGrupo.Select();
            }
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(29))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllDocumentos._Data_DatePicker1;
                    mtxtpData1.Text = bllDocumentos._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurar2_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbGrupo.Text != "")
                {
                    string[] items = cbbGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 5))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbSubGrupo.Items.Clear();
                            if (bllDocumentos.Sel_SubGrupo_Doc(items[0]) == null)
                            {
                                cbbSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllDocumentos.Sel_SubGrupo_Doc(items[0]).Rows)
                                {
                                    cbbSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                            }
                            cbbSubGrupo.Text = bllDocumentos._SubGrupo_PesqSubGrupo_Tabela;
                            bllDocumentos._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbSubGrupo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                cbbSubGrupo.Text = null;
            }
            pEnabled.Enabled = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //try
            //{
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            mtxtpHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mtxtpHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                mtxtpData.Select();
            }
            else
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //
                if (_Checkbox_Ativo == true)
                {
                    button1_Click(sender, e);
                }
                //
                if (bllDocumentos.Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(cbbpSituacao.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtpHorario.Text, mtxtpHorario1.Text, cbbClieConsFuncForn.Text, _Formulario, cbbpGrupo.Text, cbbpSubGrupo.Text) == null)
                {
                    dtDocumento.DataSource = null;
                    MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    Limpar();
                }
                else
                {
                    dtDocumento.DataSource = bllDocumentos.Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(cbbpSituacao.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtpHorario.Text, mtxtpHorario1.Text, cbbClieConsFuncForn.Text, _Formulario, cbbpGrupo.Text, cbbpSubGrupo.Text);
                    dtDocumento.Select();
                }
            }
            //
            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou documento.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou documento.");
            }
            /*
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
            dtDocumento.DataSource = null;
        }
            */
        }

        private void dtDocumento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {


            lblRegistros.Text = "Registros: " + dtDocumento.Rows.Count;

            dtDocumento.Columns[0].HeaderText = "Código";
            dtDocumento.Columns[1].HeaderText = "Descrição";
            dtDocumento.Columns[2].HeaderText = "Data";
            dtDocumento.Columns[3].HeaderText = "Horário";
            dtDocumento.Columns[4].HeaderText = "Cód. do Grupo";
            dtDocumento.Columns[5].HeaderText = "Descrição do Grupo";
            dtDocumento.Columns[6].HeaderText = "Cód. do Sub-Grupo";
            dtDocumento.Columns[7].HeaderText = "Descrição do Sub-Grupo";
            dtDocumento.Columns[8].HeaderText = "Situação";
            dtDocumento.Columns[9].HeaderText = "Observações";
            dtDocumento.Columns[10].Visible = false;
           
            dtDocumento.Columns[0].ReadOnly = true;
            dtDocumento.Columns[1].ReadOnly = true;
            dtDocumento.Columns[2].ReadOnly = true;
            dtDocumento.Columns[3].ReadOnly = true;
            dtDocumento.Columns[4].ReadOnly = true;
            dtDocumento.Columns[5].ReadOnly = true;
            dtDocumento.Columns[6].ReadOnly = true;
            dtDocumento.Columns[7].ReadOnly = true;
            dtDocumento.Columns[8].ReadOnly = true;
            dtDocumento.Columns[9].ReadOnly = true;

            dtDocumento.Columns[0].Width = 125;
            dtDocumento.Columns[1].Width = 275;
            dtDocumento.Columns[2].Width = 85;
            dtDocumento.Columns[3].Width = 85;
            dtDocumento.Columns[4].Width = 115;
            dtDocumento.Columns[5].Width = 275;
            dtDocumento.Columns[6].Width = 125;
            dtDocumento.Columns[7].Width = 275;
            dtDocumento.Columns[8].Width = 150;
            dtDocumento.Columns[9].Width = 500;

            dtDocumento.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDocumento.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtDocumento.DefaultCellStyle.Font = new Font(dtDocumento.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtDocumento.Rows.Count;
        }

        private void dtDocumento_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtDocumento.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtDocumento.Enabled = false;
                btnEnviarDocumentoZap.Enabled = false;
                btnVisualizarDocumento.Enabled = false;
                btnExportarDocumento.Enabled = false;
                btnEnviarDocumentoEmail.Enabled = false;
                btnMarcarDesmarcar.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtDocumento.Enabled = true;
                btnEnviarDocumentoZap.Enabled = true;
                btnVisualizarDocumento.Enabled = true;
                btnExportarDocumento.Enabled = true;
                btnEnviarDocumentoEmail.Enabled = true;

                btnMarcarDesmarcar.Enabled = true;
                //
                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();
                //
                if (bllGrupo.Sel_Grupo_Cor_Destaque("DOCUMENTOS") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("DOCUMENTOS").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("DOCUMENTOS").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }
                //
                for (int i = 0; i < dtDocumento.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtDocumento.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtDocumento.Rows[i].Cells[6].Value.ToString())
                        {
                            dtDocumento.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtDocumento.Rows[i].Cells[6].Value.ToString())
                        {
                            dtDocumento.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtDocumento.Rows[i].Cells[6].Value.ToString())
                        {
                            dtDocumento.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtDocumento.Rows[i].Cells[6].Value.ToString())
                        {
                            dtDocumento.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtDocumento.Rows[i].Cells[6].Value.ToString())
                        {
                            dtDocumento.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtDocumento.Rows[i].Cells[6].Value.ToString())
                        {
                            dtDocumento.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void dtDocumento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];
            //
            dtDocumento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtDocumento.DefaultCellStyle.SelectionForeColor = Color.Black;
            //
            txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
            txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
            mtxtData.Text = SelectedRow.Cells[2].Value.ToString();
            mtxtHorario.Text = SelectedRow.Cells[3].Value.ToString();
            cbbGrupo.Items.Clear();
            cbbGrupo.Items.Add(SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString());
            cbbGrupo.Text = SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString();
            cbbSubGrupo.Items.Clear();
            cbbSubGrupo.Items.Add(SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString());
            cbbSubGrupo.Text = SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString();
            cbbSituacao.Text = SelectedRow.Cells[8].Value.ToString();
            rtxtObs.Text = SelectedRow.Cells[9].Value.ToString();
            bllDocumentos._Nome_Arquivo = SelectedRow.Cells[10].Value.ToString();
            pcibCross.Visible = false;
            lblArquivo.Text = "Documento carregado.";
            pcibTick.Visible = true;
            lblArquivo.Visible = true;
            /*
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtDocumento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtDocumento.");
                }
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
                _Mudou_Arquivo = false;
                _Checkbox_Ativo = false;
                _Marcar = false;
            }
            */
        }

        private void dtDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtDocumento.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllDocumentos.Sel_Documento_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDocumento.Select();
                }
                else
                {
                    dtDocumento.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtDocumento.Enabled = false;
                    grbBox1.Enabled = false;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnExportarDocumento.Enabled = false;
                    btnEnviarDocumentoZap.Enabled = false;
                    btnVisualizarDocumento.Enabled = false;
                    btnEnviarDocumentoZap.Enabled = false;
                    btnSalvar.Enabled = true;
                    grbBox2.Enabled = true;
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtDescricao.Select();
                    _Inserir_Atualizar = true;
                    _Comando_Atualizar = true;
                    _ComboboxGrupo_Valor = cbbGrupo.Text;
                    _ComboboxSubGrupo_Valor = cbbSubGrupo.Text;
                    //
                    DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];
                    //
                    if (cbbGrupo.Text != "")
                    {
                        cbbGrupo.Items.Clear();
                        if (bllDocumentos.Sel_Grupo_Doc() == null)
                        {
                            cbbGrupo.Text = null;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllDocumentos.Sel_Grupo_Doc().Rows)
                            {
                                cbbGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }
                    }
                    //
                    if (bllDocumentos.Sel_ComboboxGrupo_Valor_A_Documento(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllDocumentos.Sel_ComboboxGrupo_Valor_A_Documento(_ComboboxGrupo_Valor).Rows)
                        {
                            cbbGrupo.Text = dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString();
                        }
                        _ComboboxGrupo_Valor = null;
                    }
                    else
                    {
                        _ComboboxGrupo_Valor = null;
                        cbbGrupo.Text = null;
                    }
                    //
                    if (cbbSubGrupo.Enabled != false & cbbGrupo.Text != "")
                    {
                        cbbSubGrupo.Items.Clear();
                        if (bllDocumentos.Sel_SubGrupo_Doc(cbbGrupo.Text) == null)
                        {
                            cbbSubGrupo.Text = null;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllDocumentos.Sel_SubGrupo_Doc(cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }

                        if (bllDocumentos.Sel_ComboboxSubGrupo_Valor_A_Alterar_Documento(_ComboboxSubGrupo_Valor, cbbGrupo.Text) != null)
                        {
                            foreach (DataRow dr in bllDocumentos.Sel_ComboboxSubGrupo_Valor_A_Alterar_Documento(_ComboboxSubGrupo_Valor, cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Text = dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxSubGrupo_Valor = null;
                        }
                        else
                        {
                            _ComboboxSubGrupo_Valor = null;
                            cbbSubGrupo.Text = null;
                        }
                    }
                    else
                    {
                        cbbSubGrupo.Items.Clear();
                        cbbSubGrupo.Text = null;
                        _ComboboxSubGrupo_Valor = null;
                        _ComboboxGrupo_Valor = null;
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
                dtDocumento.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
                _Mudou_Arquivo = false;
                _Checkbox_Ativo = false;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void btnEscolherArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.Title = "Selecione um arquivo";
                    file.Filter = "Arquivo no formato:(*.PDF;*.BMP;*.JPG;*.PNG;*.XPS;*.DOC;*.XLS;*.TXT;*.XML)|*.PDF;*.BMP;*.JPG;*.PNG*.XPS;*.DOC;*.XLS;*.TXT;*.XML";
                    file.InitialDirectory = @"C:\";
                    //
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        pcibCross.Visible = false;
                        pcibTick.Visible = true;
                        lblArquivo.Text = "Documento carregado.";
                        bllDocumentos._Nome_Arquivo = file.FileName;
                        if (_Comando_Atualizar == true)
                        {
                            _Mudou_Arquivo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEscolherArquivo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEscolherArquivo.");
                }
                //
                btnEscolherArquivo.Select();
            }
        }

        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllDocumentos.Escanear() == true)
                {
                    pcibCross.Visible = false;
                    lblArquivo.Text = "Documento carregado.";
                    pcibTick.Visible = true;
                    if (_Comando_Atualizar == true)
                    {
                        _Mudou_Arquivo = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDigitalizar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDigitalizar.");
                }
                //
                btnDigitalizar.Select();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Checkbox_Ativo == true)
                {
                    DialogResult = MessageBox.Show("Deseja excluir este(s) " + lblMarcados.Text.Replace(".", "") + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dtDocumento.Rows)
                        {
                            bool marcado = Convert.ToBoolean(row.Cells["chk"].Value);

                            if (marcado == true)
                            {
                                if (bllDocumentos.Sel_Documento_Ainda_Existe(row.Cells[0].Value.ToString()) == false)
                                {
                                    MessageBox.Show("O registro " + row.Cells[0].Value.ToString() + " já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    dtDestinatario.Select();
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;

                                    bllDocumentos.Excluir(row.Cells[0].Value.ToString());

                                    bllRegistroAtividades.Salvar("EXCLUIU VARIOS DOCUMENTOS", "DOCUMENTO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                    {
                                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - CFOP excluído. Cod: " + row.Cells[0].Value.ToString() + " | Descrição: " + row.Cells[1].Value.ToString());
                                    }
                                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                    {
                                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - CFOP excluído. Cod: " + row.Cells[0].Value.ToString() + " | Descrição: " + row.Cells[1].Value.ToString());
                                    }
                                }
                            }
                        }
                        //
                        mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            //
                            mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            //
                            dtDocumento.DataSource = null;
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            //
                            mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            //
                            if (bllDocumentos.Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(cbbpSituacao.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtpHorario.Text, mtxtpHorario1.Text, cbbClieConsFuncForn.Text, _Formulario, cbbpGrupo.Text, cbbpSubGrupo.Text) == null)
                            {
                                dtDocumento.DataSource = null;
                                this.DialogResult = DialogResult.None;
                                Limpar();
                            }
                            else
                            {
                                dtDocumento.DataSource = bllDocumentos.Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(cbbpSituacao.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtpHorario.Text, mtxtpHorario1.Text, cbbClieConsFuncForn.Text, _Formulario, cbbpGrupo.Text, cbbpSubGrupo.Text);
                                dtDocumento.Select();
                            }
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        if (dtDocumento.DataSource != null)
                        {
                            dtDocumento.Select();
                        }
                    }
                }
                else
                {
                    DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];
                    //
                    if (bllDocumentos.Sel_Documento_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                    {
                        MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtDestinatario.Select();
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("Deseja excluir este Documento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;

                            bllDocumentos.Excluir(txtCodigo.Text);

                            bllRegistroAtividades.Salvar("EXCLUIU UM DOCUMENTO", "DOCUMENTO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - CFOP excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - CFOP excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                            mtxtpHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                            if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                dtDocumento.DataSource = null;
                                this.DialogResult = DialogResult.None;
                                Limpar();
                            }
                            else
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                mtxtpHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                if (bllDocumentos.Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(cbbpSituacao.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtpHorario.Text, mtxtpHorario1.Text, cbbClieConsFuncForn.Text, _Formulario, cbbpGrupo.Text, cbbpSubGrupo.Text) == null)
                                {
                                    dtDocumento.DataSource = null;
                                    this.DialogResult = DialogResult.None;
                                    Limpar();
                                }
                                else
                                {
                                    dtDocumento.DataSource = bllDocumentos.Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(cbbpSituacao.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtpHorario.Text, mtxtpHorario1.Text, cbbClieConsFuncForn.Text, _Formulario, cbbpGrupo.Text, cbbpSubGrupo.Text);
                                    dtDocumento.Select();
                                }
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (dtDocumento.DataSource != null)
                            {
                                dtDocumento.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtDocumento.DataSource = null;
                Limpar();
                ModoPesquisa();
                _Mudou_Arquivo = false;
                _Checkbox_Ativo = false;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n5 - Asterisco Escuro (*): Significa que esse campo pode possuir um ou mais valores.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnExportarDocumento_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (_Checkbox_Ativo == true)
            {
                using (FolderBrowserDialog folder = new FolderBrowserDialog())
                {
                    folder.Description = "Selecione uma Pasta";

                    if (folder.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(folder.SelectedPath))
                    {
                        string data = DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("HH_mm_ss");
                        //
                        string comp_diretorio = @"\Exportacao_Documento_" + data;
                        //
                        bool sucesso = true;
                        foreach (DataGridViewRow row in dtDocumento.Rows)
                        {
                            bool marcado = Convert.ToBoolean(row.Cells["chk"].Value);

                            if (marcado == true)
                            {
                                if (bllDocumentos.Exportar_Arq_Documento(row.Cells[0].Value.ToString(), data) == false)
                                {
                                    sucesso = false;
                                    MessageBox.Show("O Documento de código [ " + row.Cells[0].Value.ToString() + " ] não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    DialogResult = MessageBox.Show("Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.No)
                                    {
                                        MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }
                                }
                            }
                        }
                        //
                        Directory.Move(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace("/", "").Replace(".", "").Replace("-", "") + @"\Documentos\Exportacao_Documento_" + data, folder.SelectedPath + comp_diretorio);
                        //
                        if (sucesso == true)
                        {
                            MessageBox.Show("Arquivos exportados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            else
            {
                using (FolderBrowserDialog folder = new FolderBrowserDialog())
                {
                    folder.Description = "Selecione uma Pasta";

                    if (folder.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(folder.SelectedPath))
                    {
                        string data = DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("HH_mm_ss");
                        //
                        string comp_diretorio = @"\Exportacao_Documento_" + data;
                        //
                        bool sucesso = true;
                        //
                        DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];
                        //
                        if (bllDocumentos.Exportar_Arq_Documento(SelectedRow.Cells[0].Value.ToString(), data) == false)
                        {
                            sucesso = false;
                            MessageBox.Show("O Documento de código [ " + SelectedRow.Cells[0].Value.ToString() + " ] não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            DialogResult = MessageBox.Show("Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.No)
                            {
                                MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        //
                        Directory.Move(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace("/", "").Replace(".", "").Replace("-", "") + @"\Documentos\Exportacao_Documento_" + data, folder.SelectedPath + comp_diretorio);
                        //
                        if (sucesso == true)
                        {
                            MessageBox.Show("Arquivos exportados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }/*
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExportarDocumento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExportarDocumento.");
                }
            }
                */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Checkbox_Ativo == false)
            {
                _Checkbox_Ativo = true;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();

                chk.HeaderText = "#";
                chk.Name = "chk";
                chk.Width = 35;
                chk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtDocumento.Columns.Add(chk);
                dtDocumento.Columns[11].DisplayIndex = 0;
                lblMarcados.Visible = true;

                btnAlterar.Enabled = false;
                btnNovo.Enabled = false;
                btnExcluir.Enabled = false;
                btnExportarDocumento.Enabled = false;
                btnEnviarDocumentoZap.Enabled = false;
                btnEnviarDocumentoEmail.Enabled = false;
                btnVisualizarDocumento.Enabled = false;
            }
            else
            {
                _Checkbox_Ativo = false;
                dtDocumento.Columns.Remove("chk");
                lblMarcados.Visible = false;
                lblMarcados.Text = "0 registo(s) selecionado(s).";
                btnAlterar.Enabled = true;
                btnNovo.Enabled = true;
                btnExcluir.Enabled = true;
                btnExportarDocumento.Enabled = true;
                btnEnviarDocumentoZap.Enabled = true;
                btnEnviarDocumentoEmail.Enabled = true;
                btnVisualizarDocumento.Enabled = true;
            }
        }

        private void dtDocumento_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Checkbox_Ativo == true)
            {
                if (e.ColumnIndex == 11)
                {
                    this.Cursor = Cursors.Hand;
                }
            }
        }

        private void dtDocumento_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_Checkbox_Ativo == true)
            {
                if (dtDocumento.IsCurrentCellDirty)
                {
                    dtDocumento.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void dtDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Checkbox_Ativo == true)
            {
                int quantidade = 0;
                foreach (DataGridViewRow row in dtDocumento.Rows)
                {
                    bool marcado = Convert.ToBoolean(row.Cells["chk"].Value);

                    if (marcado == true)
                    {
                        quantidade++;
                        //
                        btnExcluir.Enabled = true;
                        btnExportarDocumento.Enabled = true;
                    }
                }
                //
                if (quantidade == 0)
                {
                    btnExcluir.Enabled = false;
                    btnExportarDocumento.Enabled = false;
                }
                //
                lblMarcados.Text = quantidade + " registro(s) selecionado(s).";
            }
        }

        private void dtDocumento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_Checkbox_Ativo == true)
            {
                button1_Click(sender, e);
            }
            //
            lblRegistros.Text = "Registros: 0";
        }

        private void btnVisualizarDocumento_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];
            //
            bllDocumentos.Arq_Documento(SelectedRow.Cells[0].Value.ToString());
        }

        private async void btnEnviarDocumentoZap_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja enviar este Documento por whatsapp?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];
                    //
                    string celular;
                    //
                    pEnabled.Enabled = false;
                    using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 3))
                    {
                        if (Cel.ShowDialog() == DialogResult.OK)
                        {
                            celular = bllDocumentos._Celular_CadCelular_Tabela;
                        }
                        else
                        {
                            celular = null;
                            pEnabled.Enabled = true;
                            return;
                        }
                    }
                    //
                    celular = celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                    //
                    string destino = bllDocumentos.Arq_Documento_Zap(SelectedRow.Cells[0].Value.ToString());
                    if (destino == null)
                    {
                        MessageBox.Show("Não foi possível criar o arquivo do Documento [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pEnabled.Enabled = true;
                        return;
                    }
                    //
                    if (!File.Exists(destino))
                    {
                        MessageBox.Show("Não foi possível localizar o arquivo do Documento [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pEnabled.Enabled = true;
                        return;
                    }
                    else
                    {
                        await bllDocumentos.UploadPdfAsync(destino, celular);
                        //
                        bllRegistroAtividades.Salvar("ENVIO DE VENDA POR WHATSAPP", "VENDA", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                    }
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarWhatsapp.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarWhatsapp.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnEnviarDocumentoEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja enviar este Documento por e-mail?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    DialogResult = DialogResult.None;
                    //
                    DataGridViewRow SelectedRow = dtDocumento.Rows[dtDocumento.CurrentRow.Index];
                    //
                    string email = "";
                    //
                    string destino = bllDocumentos.Arq_Documento_Zap(SelectedRow.Cells[0].Value.ToString());
                    if (destino == null)
                    {
                        MessageBox.Show("Não foi possível criar o arquivo do Documento [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //
                    if (!File.Exists(destino))
                    {
                        MessageBox.Show("Não foi possível localizar o arquivo do Documento [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        pEnabled.Enabled = false;
                        using (FrmUtilEnviarEmail Mail = new FrmUtilEnviarEmail(5, _Cod_PDV_Computador, _Usuario, destino + ";", "Segue em anexo o Documento", "Documento", email))
                        {
                            if (Mail.ShowDialog() == DialogResult.OK)
                            {
                                dtDocumento.Select();
                            }
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarDocumentoEmail.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarDocumentoEmail.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void mtxtDataCriacao_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataCriacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataCriacao.Text == "")
            {
                mtxtDataCriacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataCriacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataCriacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataCriacao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataCriacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataCriacao.Text == "")
                {
                    mtxtDataCriacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataCriacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataCriacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataCriacao_Leave(object sender, EventArgs e)
        {
            mtxtDataCriacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataCriacao.Text != "")
            {
                try
                {
                    mtxtDataCriacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataCriacao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataCriacao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataCriacao.");
                    }
                    mtxtDataCriacao.Text = null;
                }
            }
            mtxtDataCriacao.BackColor = Color.White;
        }

        private void mtxtDataCriacao_Enter(object sender, EventArgs e)
        {
            mtxtDataCriacao.BackColor = Color.LightBlue;
        }

        private void mtxtDataCriacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataCriacao1.Select();
            }
        }

        private void mtxtDataCriacao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataCriacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataCriacao1.Text == "")
            {
                mtxtDataCriacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataCriacao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataCriacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataCriacao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataCriacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataCriacao1.Text == "")
                {
                    mtxtDataCriacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataCriacao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataCriacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataCriacao1_Leave(object sender, EventArgs e)
        {
            mtxtDataCriacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataCriacao1.Text != "")
            {
                try
                {
                    mtxtDataCriacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataCriacao1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataCriacao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataCriacao1.");
                    }
                    mtxtDataCriacao1.Text = null;
                }
            }
            mtxtDataCriacao1.BackColor = Color.White;
        }

        private void mtxtDataCriacao1_Enter(object sender, EventArgs e)
        {
            mtxtDataCriacao1.BackColor = Color.LightBlue;
        }

        private void mtxtDataCriacao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpGrupo.Select();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpHorario.Text = null;
            mtxtpHorario1.Text = null;
            txtpCodigo.Text = null;
            cbbClieConsFuncForn.Text = null;
            mtxtDataCriacao.Text = null;
            mtxtDataCriacao1.Text = null;
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Text = null;
            cbbpSituacao.Text = null;
        }
    }
}
