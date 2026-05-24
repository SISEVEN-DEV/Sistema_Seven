using ACBrLib.Core.GNRe;
using ACBrLib.NCM;
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
    public partial class FrmPesqProduto : Form
    {

        public FrmPesqProduto(byte formulario, int item, string usuario, string cod_pdv_computador, string quantidade, string tabela, string tipo)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Item = item.ToString();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Tabela = tabela;
            _Tipo = tipo;
            _Quantidade = quantidade;
        }

        private string _Item;
        private byte _Formulario;
        private string _Quantidade;
        private bool _Contem_Imagem = false;
        private string _Tabela;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Tipo;


        private void FrmPesqProduto_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqProduto iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqProduto iniciado.");
                }
                //
                rbtnDescricao.Checked = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqProduto.");
                }
                this.DialogResult = DialogResult.Abort;
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

        private void rbtnBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnGrupo_MouseLeave(object sender, EventArgs e)
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

        private void cbbpSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarSub1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurarSub1_MouseLeave(object sender, EventArgs e)
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

        private void cbbpGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_DropDownClosed(object sender, EventArgs e)
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

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
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

        private void FrmPesqProduto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
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
                this.DialogResult = DialogResult.None;
                txtpDescricao.Text = null;
            }
            txtpDescricao.BackColor = Color.White;
        }

        private void txtpBarra_Enter(object sender, EventArgs e)
        {
            txtpBarra.BackColor = Color.LightBlue;
        }

        private void txtpBarra_Leave(object sender, EventArgs e)
        {
            if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpBarra.Text = null;
            }
            txtpBarra.BackColor = Color.White;
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
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpPalavraChave.Text = null;
            }
            txtpPalavraChave.BackColor = Color.White;
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

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = true;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(341, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = true;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(571, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnBarra_CheckedChanged(object sender, EventArgs e)
        {
            txtpBarra.MaxLength = 60;
            txtpBarra.CharacterCasing = CharacterCasing.Normal;
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = true;
            lblPesquisar.Location = new Point(415, 21);
            lblPesquisar.Text = "Digite o código de barras:";
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void rbtnGrupo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpGrupo.Items.Clear();
                cbbpSubGrupo.Items.Clear();
                if (bllProduto.Sel_Grupo_Prod() == null)
                {
                    cbbpGrupo.Text = null;
                }
                else
                {
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do combo cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do combo cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
            }
            //
            cbbpSubGrupo.Text = null;
            btnpProcurar.Visible = true;
            btnpProcurarSub1.Visible = true;
            cbbpSubGrupo.Visible = true;
            cbbpSubGrupo.Enabled = false;
            btnpProcurarSub1.Enabled = false;
            lblSubGrupo1.Visible = true;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(352, 21);
            lblPesquisar.Text = "Escolha o grupo:";
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Text = null;
            cbbpGrupo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = true;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(528, 21);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(619, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void txtpBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnBarra.Checked == true)
                {
                    if (txtpBarra.Text == "")
                    {
                        btnPesquisar.Select();
                    }
                    else if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtpBarra.Text = null;
                    }
                    else
                    {
                        try
                        {
                            if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO") == null)
                            {
                                dtProd.DataSource = null;
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO");
                                dtProd.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.None;
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            txtpBarra.Text = null;
                            txtpBarra.Select();
                        }
                    }
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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
                    if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnpProcurarSub1.Enabled = false;
                        lblSubGrupo1.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            cbbpSubGrupo.Enabled = true;
                            btnpProcurarSub1.Enabled = true;
                            lblSubGrupo1.Enabled = true;
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnpProcurarSub1.Enabled = false;
                    lblSubGrupo1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(0))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllProduto.Sel_Grupo_Prod() == null)
                        {
                            cbbpGrupo.Text = null;
                            cbbpSubGrupo.Enabled = false;
                            cbbpSubGrupo.Text = null;
                            btnpProcurarSub1.Enabled = false;
                            lblSubGrupo1.Enabled = false;
                        }
                        else
                        {
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                            {
                                cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbpSubGrupo.Enabled = true;
                                btnpProcurarSub1.Enabled = true;
                                lblSubGrupo1.Enabled = true;
                            }
                        }

                        cbbpGrupo.Text = bllProduto._Grupo_PesqGrupo_Tabela;
                        bllProduto._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        this.Enabled = true;
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
            this.Enabled = true;
        }

        private void btnpProcurarSub1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 0))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();

                            if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbpSubGrupo.Text = bllProduto._SubGrupo_PesqSubGrupo_Tabela;
                            bllProduto._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbpSubGrupo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
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
            this.Enabled = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Descricao(txtpDescricao.Text, "ATIVO") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Descricao(txtpDescricao.Text, "ATIVO");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "ATIVO") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "ATIVO");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "ATIVO") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "ATIVO");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnBarra.Checked == true)
                {
                    if (txtpBarra.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "ATIVO");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    if (cbbpGrupo.Text != "")
                    {
                        if (cbbpGrupo.Text != "" && cbbpSubGrupo.Text == "")
                        {
                            if (bllProduto.Sel_Prod_Grupo(cbbpGrupo.Text, "ATIVO") == null)
                            {
                                dtProd.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Grupo(cbbpGrupo.Text, "ATIVO");
                                dtProd.Select();
                            }
                        }
                        else
                        {
                            if (bllProduto.Sel_Prod_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "ATIVO") == null)
                            {
                                dtProd.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "ATIVO");
                                dtProd.Select();
                            }
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllProduto.Sel_Prod_Todos("ATIVO") == null)
                    {
                        dtProd.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtProd.DataSource = bllProduto.Sel_Prod_Todos("ATIVO");
                        dtProd.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
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
                dtProd.DataSource = null;
                rbtnDescricao.Checked = true;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = false;
            }
        }

        private void dtProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                dtProd.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                //
                if (SelectedRow.DefaultCellStyle.ForeColor == Color.Black)
                {
                    dtProd.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (SelectedRow.DefaultCellStyle.ForeColor == Color.Red)
                {
                    dtProd.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                //
                if (Convert.ToDecimal(SelectedRow.Cells[17].Value) == 0)
                {
                    lblValorSaldo.ForeColor = Color.Black;
                }
                else if (Convert.ToDecimal(SelectedRow.Cells[17].Value) > 0)
                {
                    lblValorSaldo.ForeColor = Color.Blue;
                }
                else if (Convert.ToDecimal(SelectedRow.Cells[17].Value) < 0)
                {
                    lblValorSaldo.ForeColor = Color.Red;
                }
                //
                lblValorSaldo.Text = Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR"));
                //
                dtProd.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[3].DefaultCellStyle.Format = "n2";
                dtProd.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[15].DefaultCellStyle.Format = "n2";
                dtProd.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[16].DefaultCellStyle.Format = "n2";
                dtProd.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[17].DefaultCellStyle.Format = "n2";
                dtProd.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[21].DefaultCellStyle.Format = "n2";
                dtProd.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[22].DefaultCellStyle.Format = "n2";
                dtProd.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[27].DefaultCellStyle.Format = "n2";
                //
                //if (rbtnCodigo.Checked == true || rbtnPalavraChave.Checked == true || rbtnBarra.Checked == true)
                //{
                    dtProd.Columns[36].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[36].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[37].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[37].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[38].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[38].DefaultCellStyle.Format = "n2";
                /*
                //}
                else
                {
                    dtProd.Columns[33].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[33].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[34].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[34].DefaultCellStyle.Format = "n2";
                    dtProd.Columns[35].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[35].DefaultCellStyle.Format = "n2";
                }
                */
                //
                if (SelectedRow.Cells[14].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                rbtnDescricao.Checked = true;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = false;
                _Contem_Imagem = false;
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

                if (rotateFlipType != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlipType);
                }
            }

            return image;
        }

        private void dtProd_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                pcibImagem.Image = null;
                pcibImagem.Enabled = false;
                lblLegendaImagem.Visible = false;
                btnIncluir.Enabled = false;
                pcibAjudaFoto.Enabled = false;
                _Contem_Imagem = false;
                dtProd.Enabled = false;
                lblValorSaldo.Visible = false;
                lblSaldoAtual.Visible = false;
            }
            else
            {
                pcibImagem.Enabled = true;
                dtProd.Enabled = true;
                btnIncluir.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                lblValorSaldo.Visible = true;
                lblSaldoAtual.Visible = true;
                //                
                //
                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();
                //
                if (bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }
                //
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    btnIncluir.Select();

                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    //
                    if (_Tipo != "DAV")
                    {
                        ACBrNCM NCM = new ACBrNCM();
                        //
                        if (SelectedRow.Cells[25].Value.ToString() == "")
                        {
                            MessageBox.Show("Para realizar uma venda do tipo NFe/NFCe,\n o produto [ " + SelectedRow.Cells[0].Value.ToString() + " ] deve ter um NCM cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                        else if (NCM.Validar(SelectedRow.Cells[25].Value.ToString()) != "NCM Valido")
                        {
                            MessageBox.Show(NCM.Validar(SelectedRow.Cells[25].Value.ToString()), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    //
                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllVenda.Salvar_Items_PDV(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), _Quantidade, SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), _Tabela, bllConexao._Codigo_Conexao, "PRODUTO");
                    bllVenda._Descricao_Produto = SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllDevolucao._Devolucao_Prod_PesqProd_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                    //
                    DialogResult = DialogResult.OK;

                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    //
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllOrcamento._Orc_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    btnIncluir.Select();

                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    //
                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllVenda._PDV_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                    this.DialogResult = DialogResult.OK;

                }
                else if (_Formulario == 4)
                {
                    btnIncluir.Select();

                    using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                            //
                            _Quantidade = bllDevolucao._Quantidade;
                            //
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            bllDevolucao.Salvar_Item_Dev_Prod(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), _Quantidade, SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), bllConexao._Codigo_Conexao);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else if (_Formulario == 5)
                {
                    btnIncluir.Select();

                    using (FrmQuantidade Qtde = new FrmQuantidade(2, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                            //
                            _Quantidade = bllOrcamento._Quantidade;
                            //
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            bllOrcamento.Salvar_Itens_Orc_Operation(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), _Quantidade, SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), bllConexao._Codigo_Conexao, 0);
                            //
                            this.DialogResult = DialogResult.OK;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
            }
        }

        private void dtProd_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    btnIncluir.Select();

                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    //
                    if (_Tipo != "DAV")
                    {
                        ACBrNCM NCM = new ACBrNCM();
                        //
                        if (SelectedRow.Cells[25].Value.ToString() == "")
                        {
                            MessageBox.Show("Para realizar uma venda do tipo NFe/NFCe,\n o produto [ " + SelectedRow.Cells[0].Value.ToString() + " ] deve ter um NCM cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                        else if (NCM.Validar(SelectedRow.Cells[25].Value.ToString()) != "NCM Valido")
                        {
                            MessageBox.Show(NCM.Validar(SelectedRow.Cells[25].Value.ToString()), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    //
                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllVenda.Salvar_Items_PDV(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), _Quantidade, SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), _Tabela, bllConexao._Codigo_Conexao, "PRODUTO");
                    bllVenda._Descricao_Produto = SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();

                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllDevolucao._Devolucao_Prod_PesqProd_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                    //
                    DialogResult = DialogResult.OK;

                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();

                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllOrcamento._Orc_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;

                }
                else if (_Formulario == 3)
                {
                    btnIncluir.Select();

                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    //
                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    bllVenda._PDV_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                    //
                    this.DialogResult = DialogResult.OK;

                }
                else if (_Formulario == 4)
                {
                    btnIncluir.Select();

                    using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                            //
                            _Quantidade = bllDevolucao._Quantidade;
                            //
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            bllDevolucao.Salvar_Item_Dev_Prod(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), _Quantidade, SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), bllConexao._Codigo_Conexao);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else if (_Formulario == 5)
                {
                    btnIncluir.Select();

                    using (FrmQuantidade Qtde = new FrmQuantidade(2, "1,00"))
                    {
                        if (Qtde.ShowDialog() == DialogResult.OK)
                        {
                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                            //
                            _Quantidade = bllOrcamento._Quantidade;
                            //
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            bllOrcamento.Salvar_Itens_Orc_Operation(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), _Quantidade, SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), bllConexao._Codigo_Conexao, 0);
                            //
                            this.DialogResult = DialogResult.OK;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
            }
        }

        private void dtProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (_Formulario == 0)
                    {
                        btnIncluir.Select();

                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                        //
                        if (_Tipo != "DAV")
                        {
                            ACBrNCM NCM = new ACBrNCM();
                            //
                            if (SelectedRow.Cells[25].Value.ToString() == "")
                            {
                                MessageBox.Show("Para realizar uma venda do tipo NFe/NFCe,\n o produto [ " + SelectedRow.Cells[0].Value.ToString() + " ] deve ter um NCM cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                            else if (NCM.Validar(SelectedRow.Cells[25].Value.ToString()) != "NCM Valido")
                            {
                                MessageBox.Show(NCM.Validar(SelectedRow.Cells[25].Value.ToString()), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                        {
                            if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                            {
                                MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        bllVenda.Salvar_Items_PDV(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), _Quantidade, SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), _Tabela, bllConexao._Codigo_Conexao, "PRODUTO");
                        bllVenda._Descricao_Produto = SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        btnIncluir.Select();
                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                        if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                        {
                            if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                            {
                                MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        bllDevolucao._Devolucao_Prod_PesqProd_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                        //
                        DialogResult = DialogResult.OK;

                    }
                    else if (_Formulario == 2)
                    {
                        btnIncluir.Select();

                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                        if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                        {
                            if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                            {
                                MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        bllOrcamento._Orc_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                        //
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 3)
                    {
                        btnIncluir.Select();

                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                        if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                        {
                            if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), "1") == true)
                            {
                                MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        bllVenda._PDV_PesqProduto_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[21].Value.ToString() + "—" + SelectedRow.Cells[22].Value.ToString();
                        //
                        this.DialogResult = DialogResult.OK;

                    }
                    else if (_Formulario == 4)
                    {
                        btnIncluir.Select();

                        using (FrmQuantidade Qtde = new FrmQuantidade(1, "1,00"))
                        {
                            if (Qtde.ShowDialog() == DialogResult.OK)
                            {
                                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                //
                                _Quantidade = bllDevolucao._Quantidade;
                                //
                                if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                                {
                                    if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                                    {
                                        MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                                bllDevolucao.Salvar_Item_Dev_Prod(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), _Quantidade, SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), bllConexao._Codigo_Conexao);
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        btnIncluir.Select();

                        using (FrmQuantidade Qtde = new FrmQuantidade(2, "1,00"))
                        {
                            if (Qtde.ShowDialog() == DialogResult.OK)
                            {
                                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                //
                                _Quantidade = bllOrcamento._Quantidade;
                                //
                                if (bllProduto.Sel_Alert_Est_Max_Min_Prod(SelectedRow.Cells[0].Value.ToString()) == true)
                                {
                                    if (bllProduto.Ver_Estoque_Min_Prod(SelectedRow.Cells[0].Value.ToString(), _Quantidade) == true)
                                    {
                                        MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                                bllOrcamento.Salvar_Itens_Orc_Operation(_Item, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), _Quantidade, SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), bllConexao._Codigo_Conexao, 0);
                                //
                                this.DialogResult = DialogResult.OK;
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                    }
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void dtProd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtProd.Columns[0].HeaderText = "Código";
                dtProd.Columns[1].HeaderText = "Descrição";
                dtProd.Columns[2].HeaderText = "UM";
                dtProd.Columns[3].HeaderText = "Preço (R$)";
                dtProd.Columns[4].HeaderText = "Cód. da Marca";
                dtProd.Columns[5].HeaderText = "Descrição da Marca";
                dtProd.Columns[6].HeaderText = "Cód. do Grupo";
                dtProd.Columns[7].HeaderText = "Descrição do Grupo";
                dtProd.Columns[8].HeaderText = "Cód. do Sub-grupo";
                dtProd.Columns[9].HeaderText = "Descrição do Sub-grupo";
                dtProd.Columns[10].HeaderText = "Código de Barras*";
                dtProd.Columns[11].HeaderText = "Referência";
                dtProd.Columns[12].HeaderText = "Cód. da Localização";
                dtProd.Columns[13].HeaderText = "Descrição da Localização";
                dtProd.Columns[14].Visible = false;
                dtProd.Columns[15].HeaderText = "Estoque Mín.";
                dtProd.Columns[16].HeaderText = "Estoque Máx.";
                dtProd.Columns[17].HeaderText = "Saldo Atual";
                dtProd.Columns[18].HeaderText = "Observações";
                dtProd.Columns[19].HeaderText = "Palavra-Chave";
                dtProd.Columns[20].Visible = false;
                dtProd.Columns[21].HeaderText = "Acréscimo (%)";
                dtProd.Columns[22].HeaderText = "Desconto (%)";
                dtProd.Columns[23].Visible = false;
                dtProd.Columns[24].Visible = false;
                dtProd.Columns[25].HeaderText = "NCM";
                dtProd.Columns[26].HeaderText = "CST";
                dtProd.Columns[27].HeaderText = "Alíquota (%)";
                dtProd.Columns[28].HeaderText = "CSOSN";
                dtProd.Columns[29].HeaderText = "CEST";
                //
                //if (rbtnCodigo.Checked == true || rbtnPalavraChave.Checked == true || rbtnBarra.Checked == true)
                //{
                    dtProd.Columns[30].Visible = false;
                    dtProd.Columns[31].Visible = false;
                    dtProd.Columns[32].Visible = false;
                    dtProd.Columns[33].HeaderText = "Ex.";
                    dtProd.Columns[34].HeaderText = "CST IBS/CBS";
                    dtProd.Columns[35].HeaderText = "Cód. Sit. Trib. (cClassTrib)";
                    dtProd.Columns[36].HeaderText = "Alíq. IBS Mun. (%)";
                    dtProd.Columns[37].HeaderText = "Alíq. IBS Est. (%)";
                    dtProd.Columns[38].HeaderText = "Alíq. CBS (%)";
                    dtProd.Columns[39].HeaderText = "Situação";
                    //
                    dtProd.Columns[33].Width = 46;
                    dtProd.Columns[34].Width = 125;
                    dtProd.Columns[35].Width = 175;
                    dtProd.Columns[36].Width = 125;
                    dtProd.Columns[37].Width = 125;
                    dtProd.Columns[38].Width = 110;
                    dtProd.Columns[39].Width = 110;
                    //
                    dtProd.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[39].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[39].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                /*
                }
                else
                {
                    dtProd.Columns[30].HeaderText = "Ex.";
                    dtProd.Columns[31].HeaderText = "CST IBS/CBS";
                    dtProd.Columns[32].HeaderText = "Cód. Sit. Trib. (cClassTrib)";
                    dtProd.Columns[33].HeaderText = "Alíq. IBS Mun. (%)";
                    dtProd.Columns[34].HeaderText = "Alíq. IBS Est. (%)";
                    dtProd.Columns[35].HeaderText = "Alíq. CBS (%)";
                    //
                    dtProd.Columns[30].Width = 46;
                    dtProd.Columns[31].Width = 125;
                    dtProd.Columns[32].Width = 175;
                    dtProd.Columns[33].Width = 125;
                    dtProd.Columns[34].Width = 125;
                    dtProd.Columns[35].Width = 110;
                    //
                    dtProd.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                */
                //
                dtProd.Columns[0].Width = 85;
                dtProd.Columns[1].Width = 320;
                dtProd.Columns[2].Width = 46;
                dtProd.Columns[3].Width = 155;
                dtProd.Columns[4].Width = 115;
                dtProd.Columns[5].Width = 250;
                dtProd.Columns[6].Width = 115;
                dtProd.Columns[7].Width = 325;
                dtProd.Columns[8].Width = 125;
                dtProd.Columns[9].Width = 325;
                dtProd.Columns[10].Width = 325;
                dtProd.Columns[11].Width = 85;
                dtProd.Columns[12].Width = 135;
                dtProd.Columns[13].Width = 325;
                dtProd.Columns[15].Width = 125;
                dtProd.Columns[16].Width = 125;
                dtProd.Columns[17].Width = 95;
                dtProd.Columns[18].Width = 500;
                dtProd.Columns[19].Width = 95;
                dtProd.Columns[21].Width = 150;
                dtProd.Columns[22].Width = 150;
                dtProd.Columns[25].Width = 110;
                dtProd.Columns[26].Width = 90;
                dtProd.Columns[27].Width = 110;
                dtProd.Columns[28].Width = 90;
                dtProd.Columns[29].Width = 110;

                dtProd.DefaultCellStyle.Font = new Font(dtProd.Font, FontStyle.Bold);

                dtProd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRegistros.Text = "Registros: " + dtProd.Rows.Count;

                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    if (bllProduto.Sel_Dest_Est_Negativo_Prod(dtProd.Rows[i].Cells[0].Value.ToString()) == true)
                    {
                        dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (bllProduto.Sel_Alert_Est_Max_Min_Prod(dtProd.Rows[i].Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(dtProd.Rows[i].Cells[0].Value.ToString(), "1"))
                        {
                            dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                dtProd.DataSource = null;
            }
        }

        private void dtProd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorSaldo.Text = null;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, código de barras, grupo e sub-grupo, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtProd.DataSource != null)
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
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            lblLegendaImagem.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);

            if (dtProd.DataSource != null)
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

        private void dtProd_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtProd_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtProd.DataSource != null)
                    {
                        MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtProd.DataSource != null)
                    {
                        MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblLegendaImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblLegendaImagem.");
                }
            }
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

        private void FrmPesqProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqProduto foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqProduto foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqProduto.");
                }
            }
        }

        private void pcibAjudaFoto_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida no ato da alteração de dados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            if (e.ColumnIndex == 12 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void lblValorSaldo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorSaldo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saldo Atual: " + lblValorSaldo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnCadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (bllLicenca.Verificar_Data_Licenca() != null)
                {
                    DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                    //
                    if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar hoje em " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 1 dia " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 2 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 3 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 4 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 5 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else if (bllLicenca.Verificar_Licenca(DateTime.Now.ToShortDateString()) != true)
                    {
                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(0))
                        {
                            if (Lic.ShowDialog() == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                //
                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                return;
                            }
                        }
                    }
                }
                //
                using (FrmCadProduto Prod = new FrmCadProduto(_Usuario, _Cod_PDV_Computador, 1))
                {
                    if (Prod.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        if (bllProduto.Sel_Prod_Codigo(bllProduto._Cod_Produto_Cadastro, "ATIVO") == null)
                        {
                            dtProd.DataSource = null;
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Codigo(bllProduto._Cod_Produto_Cadastro, "ATIVO");
                            dtProd.Select();
                        }
                    }
                    //
                    bllProduto._Cod_Produto_Cadastro = null;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
