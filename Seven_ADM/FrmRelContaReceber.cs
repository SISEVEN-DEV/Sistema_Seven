using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelContaReceber : Form
    {
        public FrmRelContaReceber(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private byte _Trabalho;
        private string _Cod_PDV_Computador;

        private void Limpar_OutrosFiltros()
        {
            mtxtpDataCad.Text = null;
            mtxtpDataCad1.Text = null;
            mtxtpDataEmi.Text = null;
            mtxtpDataEmi1.Text = null;
            mtxtpDataVenc.Text = null;
            mtxtpDataVenc1.Text = null;
            cbbpGrupo.Items.Clear();
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Items.Clear();
            cbbpSubGrupo.Text = null;
            cbbpSituacao.Text = null;
        }

        private void FrmRelContaReceber_Load(object sender, EventArgs e)
        {
            try
            {
                bllContasReceber._FrmRelContaReceber_Ativo = true;

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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaReceber iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaReceber iniciado.");
                }
                //
                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelContaReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelContaReceber.");
                }
                this.Close();
            }
        }

        private void rbtnTodas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
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
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnConsumidor_MouseLeave(object sender, EventArgs e)
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

        private void cbbpTipoConsumidor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoConsumidor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpConsumidor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpConsumidor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpConsumidor_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData2_MouseLeave(object sender, EventArgs e)
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

        private void cbbpGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipo_DropDownClosed(object sender, EventArgs e)
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

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            lblSubgrupo.Enabled = true;
            lblDataCadastro.Enabled = true;
            lblDataEmissao.Enabled = true;
            lblDataVencimento.Enabled = true;
            mtxtpDataCad.Enabled = true;
            mtxtpDataCad1.Enabled = true;
            mtxtpDataEmi.Enabled = true;
            mtxtpDataEmi1.Enabled = true;
            mtxtpDataVenc.Enabled = true;
            mtxtpDataVenc1.Enabled = true;
            btnSelecionarData1.Enabled = true;
            btnSelecionarData.Enabled = true;
            btnSelecionarData2.Enabled = true;
            lblSituacao.Enabled = true;
            lblGrupo.Enabled = true;
            cbbpGrupo.Enabled = true;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = true;
            btnProcurarSubgrupo.Enabled = false;
            cbbpSituacao.Enabled = true;
            Limpar_OutrosFiltros();
            //
            cbbpSituacao.Text = "AMBAS";
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpDescricao.Visible = true;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(426, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Text = null;
            btnLimpar.Enabled = true;
            txtpDescricao.Select();
            //
            try
            {
                cbbpGrupo.Items.Clear();
                if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnDescricao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnDescricao.");
                }
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Items.Clear();
                cbbpSubGrupo.Text = null;
            }
        }

        private void rbtnCodigo_CheckedChanged_1(object sender, EventArgs e)
        {
            lblSubgrupo.Enabled = false;
            lblDataCadastro.Enabled = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataCad.Enabled = false;
            mtxtpDataCad1.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            lblGrupo.Enabled = false;
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            cbbpSituacao.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpSituacao.Text = "AMBAS";
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            lblAte.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(583, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            btnLimpar.Enabled = true;
            btnLimpar.Enabled = false;
            txtpCodigo.Select();
        }

        private void rbtnConsumidor_CheckedChanged(object sender, EventArgs e)
        {
            lblSubgrupo.Enabled = true;
            lblDataCadastro.Enabled = true;
            lblDataEmissao.Enabled = true;
            lblDataVencimento.Enabled = true;
            mtxtpDataCad.Enabled = true;
            mtxtpDataCad1.Enabled = true;
            mtxtpDataEmi.Enabled = true;
            mtxtpDataEmi1.Enabled = true;
            mtxtpDataVenc.Enabled = true;
            mtxtpDataVenc1.Enabled = true;
            btnSelecionarData1.Enabled = true;
            btnSelecionarData.Enabled = true;
            btnSelecionarData2.Enabled = true;
            lblSituacao.Enabled = true;
            lblGrupo.Enabled = true;
            cbbpGrupo.Enabled = true;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = true;
            btnProcurarSubgrupo.Enabled = false;
            cbbpSituacao.Enabled = true;
            Limpar_OutrosFiltros();
            cbbpSituacao.Text = "AMBAS";
            cbbpTipoConsumidor.Visible = true;
            btnpProcurar.Visible = true;
            lblAte.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(257, 21);
            cbbpConsumidor.Visible = true;
            lblPesquisar.Text = "Localizar destinatário em:";
            cbbpTipoConsumidor.Text = "CLIENTES";
            cbbpConsumidor.Text = null;
            btnLimpar.Enabled = true;
            cbbpTipoConsumidor.Select();
            //
            try
            {
                cbbpConsumidor.Items.Clear();
                if (cbbpTipoConsumidor.SelectedIndex == 1)
                {
                    if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Enabled = false;
                        cbbpConsumidor.Text = null;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                //
                cbbpGrupo.Items.Clear();
                if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnConsumidor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnConsumidor.");
                }
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Items.Clear();
                cbbpSubGrupo.Text = null;
                cbbpConsumidor.Items.Clear();
                cbbpConsumidor.Text = null;
            }
        }

        private void rbtnTodas_CheckedChanged_1(object sender, EventArgs e)
        {
            lblSubgrupo.Enabled = true;
            lblDataCadastro.Enabled = true;
            lblDataEmissao.Enabled = true;
            lblDataVencimento.Enabled = true;
            mtxtpDataCad.Enabled = true;
            mtxtpDataCad1.Enabled = true;
            mtxtpDataEmi.Enabled = true;
            mtxtpDataEmi1.Enabled = true;
            mtxtpDataVenc.Enabled = true;
            mtxtpDataVenc1.Enabled = true;
            btnSelecionarData1.Enabled = true;
            btnSelecionarData.Enabled = true;
            btnSelecionarData2.Enabled = true;
            lblSituacao.Enabled = true;
            lblGrupo.Enabled = true;
            cbbpGrupo.Enabled = true;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = true;
            btnProcurarSubgrupo.Enabled = false;
            cbbpSituacao.Enabled = true;
            Limpar_OutrosFiltros();
            cbbpSituacao.Text = "AMBAS";
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            lblAte.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(633, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnLimpar.Enabled = true;
            btnPesquisar.Select();
            //
            try
            {
                cbbpGrupo.Items.Clear();
                if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnTodos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnTodos.");
                }
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Items.Clear();
                cbbpSubGrupo.Text = null;
            }
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

        private void cbbpTipoConsumidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpConsumidor.Items.Clear();
                if (cbbpTipoConsumidor.SelectedIndex == 0)
                {
                    cbbpConsumidor.Text = null;
                    cbbpConsumidor.Enabled = false;
                    btnpProcurar.Enabled = false;
                }
                else if (cbbpTipoConsumidor.SelectedIndex == 1)
                {
                    if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Text = null;
                        cbbpConsumidor.Enabled = false;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoConsumidor.SelectedIndex == 2)
                {
                    if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Text = null;
                        cbbpConsumidor.Enabled = false;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoConsumidor.SelectedIndex == 3)
                {
                    if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Text = null;
                        cbbpConsumidor.Enabled = false;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoEmitente.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoEmitente.");
                }
                cbbpConsumidor.Items.Clear();
                cbbpConsumidor.Text = null;
                cbbpTipoConsumidor.Text = null;
            }
        }

        private void cbbpTipoConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbpConsumidor.Enabled != false)
                {
                    cbbpConsumidor.Select();
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }

        private void cbbpConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            try
            {
                pPanel.Enabled = false;
                if (cbbpTipoConsumidor.Text == "CLIENTES")
                {

                    using (FrmPesqCliente Clie = new FrmPesqCliente(6, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbpConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                            {
                                cbbpConsumidor.Text = null;
                            }
                            else
                            {
                                cbbpConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                                {
                                    cbbpConsumidor.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbpConsumidor.Select();
                        }
                    }
                }
                else if (cbbpTipoConsumidor.Text == "FORNECEDORES")
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(4, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbpConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                            {
                                cbbpConsumidor.Text = null;
                            }
                            else
                            {
                                cbbpConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                                {
                                    cbbpConsumidor.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbpConsumidor.Select();
                        }
                    }
                }
                else if (cbbpTipoConsumidor.Text == "FUNCIONARIOS")
                {
                    using (FrmPesqFuncionario Func = new FrmPesqFuncionario(4, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Func.ShowDialog() == DialogResult.OK)
                        {
                            cbbpConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                            {
                                cbbpConsumidor.Text = null;
                            }
                            else
                            {
                                cbbpConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                                {
                                    cbbpConsumidor.Items.Add(dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbpConsumidor.Select();
                        }
                    }
                }
                pPanel.Enabled = true;
            }
            catch (Exception ex)
            {
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
                cbbpConsumidor.Text = null;
                bllContasReceber._Consumidor_PesqContaReceber = null;
            }
        }

        private void mtxtpDataCad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataCad1.Select();
            }
        }

        private void mtxtpDataCad1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpGrupo.Select();
            }
        }

        private void mtxtpDataEmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataEmi1.Select();
            }
        }

        private void mtxtpDataEmi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVenc.Select();
            }
        }

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbpSubGrupo.Enabled != false)
                {
                    cbbpSubGrupo.Select();
                }
                else
                {
                    mtxtpDataVenc.Select();
                }
            }
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpSituacao.Select();
            }
        }

        private void mtxtpDataVenc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVenc1.Select();
            }
        }

        private void mtxtpDataVenc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataCad.Select();
            }
        }

        private void cbbpTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpDataCad_Enter(object sender, EventArgs e)
        {
            mtxtpDataCad.BackColor = Color.LightBlue;
        }

        private void mtxtpDataCad_Leave(object sender, EventArgs e)
        {
            mtxtpDataCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCad.Text != "")
            {
                try
                {
                    mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataCad.Text);

                    mtxtpDataCad1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataCad1.Text != "")
                    {
                        mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataCad.Text) > Convert.ToDateTime(mtxtpDataCad1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataCad.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad.");
                    }
                    mtxtpDataCad.Text = null;
                }
            }
            mtxtpDataCad.BackColor = Color.White;
        }

        private void mtxtpDataCad1_Enter(object sender, EventArgs e)
        {
            mtxtpDataCad1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataCad1_Leave(object sender, EventArgs e)
        {
            mtxtpDataCad1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCad1.Text != "")
            {
                try
                {
                    mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataCad1.Text);

                    mtxtpDataCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataCad.Text != "")
                    {
                        mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataCad1.Text) < Convert.ToDateTime(mtxtpDataCad.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataCad1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataCad1.");
                    }
                    mtxtpDataCad1.Text = null;
                }
            }
            mtxtpDataCad1.BackColor = Color.White;
        }

        private void mtxtpDataEmi_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmi.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmi_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi.Text != "")
            {
                try
                {
                    mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmi.Text);

                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmi1.Text != "")
                    {
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmi.Text) > Convert.ToDateTime(mtxtpDataEmi1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi.");
                    }
                    mtxtpDataEmi.Text = null;
                }
            }
            mtxtpDataEmi.BackColor = Color.White;
        }

        private void mtxtpDataEmi1_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmi1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmi1_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi1.Text != "")
            {
                try
                {
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmi1.Text);

                    mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmi.Text != "")
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmi.Text) > Convert.ToDateTime(mtxtpDataEmi1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi1.");
                    }
                    mtxtpDataEmi1.Text = null;
                }
            }
            mtxtpDataEmi1.BackColor = Color.White;
        }

        private void mtxtpDataVenc_Enter(object sender, EventArgs e)
        {
            mtxtpDataVenc.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVenc_Leave(object sender, EventArgs e)
        {
            mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc.Text != "")
            {
                try
                {
                    mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVenc.Text);

                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVenc1.Text != "")
                    {
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVenc.Text) > Convert.ToDateTime(mtxtpDataVenc1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataVenc.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc.");
                    }
                    mtxtpDataVenc.Text = null;
                }
            }
            mtxtpDataVenc.BackColor = Color.White;
        }

        private void mtxtpDataVenc1_Enter(object sender, EventArgs e)
        {
            mtxtpDataVenc1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVenc1_Leave(object sender, EventArgs e)
        {
            mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc1.Text != "")
            {
                try
                {
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVenc1.Text);

                    mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVenc.Text != "")
                    {
                        mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVenc1.Text) < Convert.ToDateTime(mtxtpDataVenc.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataVenc1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc1.");
                    }
                    mtxtpDataVenc1.Text = null;
                }
            }
            mtxtpDataVenc1.BackColor = Color.White;
        }

        private void mtxtpDataCad_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCad.Text == "")
            {
                mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataCad.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataCad1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataCad1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCad1.Text == "")
            {
                mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataCad1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmi_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi.Text == "")
            {
                mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmi1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi1.Text == "")
            {
                mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmi1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVenc_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc.Text == "")
            {
                mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVenc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVenc1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc1.Text == "")
            {
                mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVenc1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataCad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataCad.Text == "")
                {
                    mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataCad.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataCad1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataCad1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataCad1.Text == "")
                {
                    mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataCad1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmi.Text == "")
                {
                    mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmi.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmi1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmi1.Text == "")
                {
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmi1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataVenc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataVenc.Text == "")
                {
                    mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataVenc.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataVenc1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataVenc1.Text == "")
                {
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataVenc1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(2))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataCad.Text = bllContasReceber._Data_DatePicker1;
                    mtxtpDataCad1.Text = bllContasReceber._Data_DatePicker2;
                }
            }
            pPanel.Enabled = true;
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(2))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataEmi.Text = bllContasReceber._Data_DatePicker1;
                    mtxtpDataEmi1.Text = bllContasReceber._Data_DatePicker2;
                }
            }
            pPanel.Enabled = true;
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(2))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataVenc.Text = bllContasReceber._Data_DatePicker1;
                    mtxtpDataVenc1.Text = bllContasReceber._Data_DatePicker2;
                }
            }
            pPanel.Enabled = true;
        }

        private void cbbpGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.SelectedItem.ToString().Split('—');
                    cbbpSubGrupo.Items.Clear();
                    if (bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnProcurarSubgrupo.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Enabled = true;
                        btnProcurarSubgrupo.Enabled = true;
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
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
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void btnProcurarGrupo_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(3))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                        {
                            cbbpGrupo.Text = null;
                            cbbpGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbpGrupo.Enabled = true;
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
                            {
                                cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbpGrupo.Text = bllContasReceber._Grupo_PesqGrupo_Tabela;
                        bllContasReceber._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarGrupo.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarGrupo.");
                        }
                        cbbpGrupo.Text = null;
                        bllContasReceber._Grupo_PesqGrupo_Tabela = null;
                    }
                }
            }
            pPanel.Enabled = true;
        }

        private void btnProcurarSubgrupo_Click(object sender, EventArgs e)
        {

            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    pPanel.Enabled = false;
                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 2))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();
                            if (bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                                cbbpSubGrupo.Enabled = false;
                            }
                            else
                            {
                                cbbpSubGrupo.Enabled = true;
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbpSubGrupo.Text = bllContasReceber._SubGrupo_PesqSubGrupo_Tabela;
                            bllContasReceber._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbpSubGrupo.Select();
                        }
                    }
                    pPanel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
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
                cbbpSubGrupo.Text = null;
                bllContasReceber._SubGrupo_PesqSubGrupo_Tabela = null;
            }
            pPanel.Enabled = true;
        }

        private void btnProcurarSubgrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarSubgrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmRelContaReceber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmRelContaReceber_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaReceber foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaReceber foi finalizado.");
                }
                bllContasReceber._FrmRelContaReceber_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelContaReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelContaReceber.");
                }
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTodasContas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTodasContas_MouseLeave(object sender, EventArgs e)
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

        private void dtContaPagar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtContaReceber.Columns[0].HeaderText = "Código";
                dtContaReceber.Columns[1].HeaderText = "Descrição";
                dtContaReceber.Columns[2].HeaderText = "Nº da Promissória";
                dtContaReceber.Columns[3].HeaderText = "Parcela(s)";
                dtContaReceber.Columns[4].HeaderText = "Data de Emissão";
                dtContaReceber.Columns[5].HeaderText = "Data de Vencimento";
                dtContaReceber.Columns[6].HeaderText = "Tipo do Documento";
                dtContaReceber.Columns[7].HeaderText = "Tipo de Consumidor";
                dtContaReceber.Columns[8].HeaderText = "Cód. do Consumidor";
                dtContaReceber.Columns[9].HeaderText = "Nome/Razão Social do Consumidor";
                dtContaReceber.Columns[10].HeaderText = "Cód. do Grupo";
                dtContaReceber.Columns[11].HeaderText = "Descrição do Grupo";
                dtContaReceber.Columns[12].HeaderText = "Cód. do Subgrupo";
                dtContaReceber.Columns[13].HeaderText = "Descrição do Subgrupo";
                dtContaReceber.Columns[14].HeaderText = "Valor (R$)";
                dtContaReceber.Columns[15].HeaderText = "Valor Real (R$)";
                dtContaReceber.Columns[16].HeaderText = "Desconto Até";
                dtContaReceber.Columns[17].HeaderText = "Desconto (%)";
                dtContaReceber.Columns[18].HeaderText = "Valor do Desconto (R$)";
                dtContaReceber.Columns[19].HeaderText = "Multa (%)";
                dtContaReceber.Columns[20].HeaderText = "Valor da Multa (R$)";
                dtContaReceber.Columns[21].HeaderText = "Juros (a.m) (%)";
                dtContaReceber.Columns[22].HeaderText = "Valor Juros (a.m)";
                dtContaReceber.Columns[23].HeaderText = "Situação";
                dtContaReceber.Columns[24].HeaderText = "Valor Total Pago (R$)";
                dtContaReceber.Columns[25].HeaderText = "Troco (R$)";
                dtContaReceber.Columns[26].HeaderText = "Data da Baixa";
                dtContaReceber.Columns[27].HeaderText = "Hora da Baixa";
                dtContaReceber.Columns[28].HeaderText = "Observação";
                dtContaReceber.Columns[29].HeaderText = "Palavra-Chave";
                dtContaReceber.Columns[30].HeaderText = "Data de Cadastro";
                dtContaReceber.Columns[31].HeaderText = "Cód. da Venda";
                dtContaReceber.Columns[32].HeaderText = "Ignorar Multa";
                dtContaReceber.Columns[33].HeaderText = "Ignorar Juros (a.m)";
                dtContaReceber.Columns[34].HeaderText = "Cód. do Usuario da Baixa";
                dtContaReceber.Columns[35].HeaderText = "Nome do Usuário da Baixa";
                dtContaReceber.Columns[36].Visible = false;
                dtContaReceber.Columns[37].HeaderText = "Cód. PDV/Computador Baixa";
                dtContaReceber.Columns[38].HeaderText = "Cód. do Cheque";
                //
                dtContaReceber.DefaultCellStyle.Font = new Font(dtContaReceber.Font, FontStyle.Bold);
                //
                dtContaReceber.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                dtContaReceber.Columns[0].Width = 95;
                dtContaReceber.Columns[1].Width = 325;
                dtContaReceber.Columns[2].Width = 150;
                dtContaReceber.Columns[3].Width = 146;
                dtContaReceber.Columns[4].Width = 150;
                dtContaReceber.Columns[5].Width = 150;
                dtContaReceber.Columns[6].Width = 200;
                dtContaReceber.Columns[7].Width = 150;
                dtContaReceber.Columns[8].Width = 135;
                dtContaReceber.Columns[9].Width = 325;
                dtContaReceber.Columns[10].Width = 105;
                dtContaReceber.Columns[11].Width = 325;
                dtContaReceber.Columns[12].Width = 125;
                dtContaReceber.Columns[13].Width = 325;
                dtContaReceber.Columns[14].Width = 162;
                dtContaReceber.Columns[15].Width = 162;
                dtContaReceber.Columns[16].Width = 150;
                dtContaReceber.Columns[17].Width = 150;
                dtContaReceber.Columns[18].Width = 150;
                dtContaReceber.Columns[19].Width = 150;
                dtContaReceber.Columns[20].Width = 150;
                dtContaReceber.Columns[21].Width = 150;
                dtContaReceber.Columns[22].Width = 150;
                dtContaReceber.Columns[23].Width = 168;
                dtContaReceber.Columns[24].Width = 168;
                dtContaReceber.Columns[25].Width = 168;
                dtContaReceber.Columns[26].Width = 150;
                dtContaReceber.Columns[27].Width = 150;
                dtContaReceber.Columns[28].Width = 500;
                dtContaReceber.Columns[29].Width = 150;
                dtContaReceber.Columns[30].Width = 150;
                dtContaReceber.Columns[31].Width = 135;
                dtContaReceber.Columns[32].Width = 125;
                dtContaReceber.Columns[33].Width = 125;
                dtContaReceber.Columns[34].Width = 168;
                dtContaReceber.Columns[35].Width = 168;
                dtContaReceber.Columns[37].Width = 175;
                dtContaReceber.Columns[38].Width = 125;
                //
                lblRegistros.Text = "Registros: " + dtContaReceber.Rows.Count;
                //
                decimal valortotal = 0;
                for (int i = 0; i < dtContaReceber.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtContaReceber.Rows[i].Cells[15].Value);
                }
                lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valorpago = 0;
                for (int i = 0; i < dtContaReceber.Rows.Count; i++)
                {
                    if (dtContaReceber.Rows[i].Cells[23].Value.ToString() == "FINALIZADA")
                    {
                        valorpago += Convert.ToDecimal(dtContaReceber.Rows[i].Cells[15].Value);
                    }
                    else if (dtContaReceber.Rows[i].Cells[23].Value.ToString() == "PENDENTE" & Convert.ToDecimal(dtContaReceber.Rows[i].Cells[24].Value) > 0)
                    {
                        valorpago += Convert.ToDecimal(dtContaReceber.Rows[i].Cells[24].Value);
                    }
                }
                //
                lblValorRecebido.Text = Convert.ToDecimal(valorpago).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal apagar = 0;
                for (int i = 0; i < dtContaReceber.Rows.Count; i++)
                {
                    if (dtContaReceber.Rows[i].Cells[23].Value.ToString() == "PENDENTE")
                    {
                        apagar += Convert.ToDecimal(dtContaReceber.Rows[i].Cells[15].Value);
                    }
                }
                lblValorAPagar.Text = Convert.ToDecimal(apagar).ToString("n2", new CultureInfo("pt-BR"));
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
                dtContaReceber.DataSource = null;
            }
        }

        private void dtContaReceber_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorTotal.Text = null;
            lblValorRecebido.Text = null;
            lblValorAPagar.Text = null;
        }

        private void dtContaReceber_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtContaReceber.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[14].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[15].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[17].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[18].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[18].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[19].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[19].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[20].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[21].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[22].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[24].DefaultCellStyle.Format = "n2";
            dtContaReceber.Columns[25].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtContaReceber.Columns[25].DefaultCellStyle.Format = "n2";

            DataGridViewRow SelectedRow = dtContaReceber.Rows[e.RowIndex];

            dtContaReceber.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtContaReceber.DefaultCellStyle.SelectionForeColor = Color.Black;

            if (SelectedRow.Cells[23].Value.ToString() == "PENDENTE")
            {
                btnBaixaRegistro.Enabled = true;
                btnReciboRegistro.Enabled = false;
                if (Convert.ToDecimal(SelectedRow.Cells[24].Value) > 0)
                {
                    btnReciboRegistro.Enabled = true;
                    btnDesfazer.Enabled = true;
                }
                else
                {
                    btnReciboRegistro.Enabled = false;
                    btnDesfazer.Enabled = false;
                }
                lblValorSituacao.Text = "PENDENTE";
                lblValorSituacao.ForeColor = Color.Red;
                pcibCross.Visible = true;
                pcibDelete.Visible = false;
                pcibTick.Visible = false;
            }
            else if (SelectedRow.Cells[23].Value.ToString() == "FINALIZADA")
            {
                lblValorSituacao.Text = "FINALIZADA";
                lblValorSituacao.ForeColor = Color.Green;
                pcibCross.Visible = false;
                pcibDelete.Visible = false;
                pcibTick.Visible = true;
                btnBaixaRegistro.Enabled = false;
                btnReciboRegistro.Enabled = true;
                if (SelectedRow.Cells[38].Value.ToString() == "0")
                {
                    btnDesfazer.Enabled = true;
                }
                else
                {
                    btnDesfazer.Enabled = false;
                }
                btnReciboRegistro.Enabled = true;
            }
            else if (SelectedRow.Cells[23].Value.ToString() == "CANCELADA")
            {
                lblValorSituacao.Text = "CANCELADA";
                lblValorSituacao.ForeColor = Color.Red;
                pcibCross.Visible = false;
                pcibDelete.Visible = true;
                pcibTick.Visible = false;
                btnBaixaRegistro.Enabled = false;
                btnReciboRegistro.Enabled = false;
                btnDesfazer.Enabled = false;
                btnReciboRegistro.Enabled = false;
            }
            //
            if (SelectedRow.Cells[2].Value.ToString() != "0")
            {
                btnSegundaViaProm.Enabled = true;
            }
            else
            {
                btnSegundaViaProm.Enabled = false;

            }
            //
            /*
            if (SelectedRow.Cells[6].Value.ToString() == "CHEQUE")
            {
                btnReciboRegistro.Enabled = false;
                btnConsultarPagamento.Enabled = false;
            }
            else
            {
                btnReciboRegistro.Enabled = true;
                btnConsultarPagamento.Enabled = true;
            }
            */
        }

        private void dtContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtContaReceber.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtContaReceber_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtContaReceber.DataSource == null)
            {
                dtContaReceber.Enabled = false;
                grbBox2.Enabled = false;
                lblTotal.Enabled = false;
                lblValorTotal.Enabled = false;
                lblPago.Enabled = false;
                lblValorRecebido.Enabled = false;
                lblaPagar.Enabled = false;
                lblValorAPagar.Enabled = false;
                pcibCross.Visible = false;
                pcibDelete.Visible = false;
                pcibTick.Visible = false;
                lblValorSituacao.Visible = false;
            }
            else
            {
                dtContaReceber.Enabled = true;
                grbBox2.Enabled = true;
                lblTotal.Enabled = true;
                lblValorTotal.Enabled = true;
                lblPago.Enabled = true;
                lblValorRecebido.Enabled = true;
                lblaPagar.Enabled = true;
                lblValorAPagar.Enabled = true;
                lblValorSituacao.Visible = true;
                chkbDestOsPend_CheckedChanged(sender, e);
                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();

                if (bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A RECEBER") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A RECEBER").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A RECEBER").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }

                for (int i = 0; i < dtContaReceber.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodas.Checked == true)
                {
                    mtxtpDataCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataCad1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if ((mtxtpDataCad.Text == "" & mtxtpDataCad1.Text != "") || (mtxtpDataCad.Text != "" & mtxtpDataCad1.Text == ""))
                    {
                        mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataCad.Select();
                        return;
                    }
                    else if ((mtxtpDataEmi.Text == "" & mtxtpDataEmi1.Text != "") || (mtxtpDataEmi.Text != "" & mtxtpDataEmi1.Text == ""))
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Emissão ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataEmi.Select();
                        return;
                    }
                    else if ((mtxtpDataVenc.Text == "" & mtxtpDataVenc1.Text != "") || (mtxtpDataVenc.Text != "" & mtxtpDataVenc1.Text == ""))
                    {
                        mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataEmi.Select();
                        return;
                    }
                    else
                    {
                        mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllContasReceber.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(mtxtpDataCad.Text, mtxtpDataCad1.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpSituacao.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(mtxtpDataCad.Text, mtxtpDataCad1.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpSituacao.Text);
                            dtContaReceber.Select();
                        }
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        mtxtpDataCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataCad1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataCad.Text == "" & mtxtpDataCad1.Text != "") || (mtxtpDataCad.Text != "" & mtxtpDataCad1.Text == ""))
                        {
                            mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataCad.Select();
                            return;
                        }
                        else if ((mtxtpDataEmi.Text == "" & mtxtpDataEmi1.Text != "") || (mtxtpDataEmi.Text != "" & mtxtpDataEmi1.Text == ""))
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Emissão ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtpDataVenc.Text == "" & mtxtpDataVenc1.Text != "") || (mtxtpDataVenc.Text != "" & mtxtpDataVenc1.Text == ""))
                        {
                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllContasReceber.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(txtpDescricao.Text.Trim(), mtxtpDataCad.Text, mtxtpDataCad1.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpSituacao.Text) == null)
                            {
                                dtContaReceber.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(txtpDescricao.Text.Trim(), mtxtpDataCad.Text, mtxtpDataCad1.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpSituacao.Text);
                                dtContaReceber.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Codigo_Receber(txtpCodigo.Text, "") == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Codigo_Receber(txtpCodigo.Text, "");
                        }
                    }
                }
                else if (rbtnVenda.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Codigo_Venda_Receber(txtpCodigo.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Codigo_Venda_Receber(txtpCodigo.Text);
                        }
                    }
                }
                else if (rbtnNPromissoria.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Receber_N_Promissoria(txtpCodigo.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_N_Promissoria(txtpCodigo.Text);
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Palavra_Chave_Receber(txtpPalavraChave.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Palavra_Chave_Receber(txtpPalavraChave.Text);
                        }
                    }
                }
                else if (rbtnConsumidor.Checked == true)
                {
                    if (cbbpTipoConsumidor.Text != "")
                    {
                        mtxtpDataCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataCad1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataCad.Text == "" & mtxtpDataCad1.Text != "") || (mtxtpDataCad.Text != "" & mtxtpDataCad1.Text == ""))
                        {
                            mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataCad.Select();
                            return;
                        }
                        else if ((mtxtpDataEmi.Text == "" & mtxtpDataEmi1.Text != "") || (mtxtpDataEmi.Text != "" & mtxtpDataEmi1.Text == ""))
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Emissão ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtpDataVenc.Text == "" & mtxtpDataVenc1.Text != "") || (mtxtpDataVenc.Text != "" & mtxtpDataVenc1.Text == ""))
                        {
                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataCad.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataCad1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllContasReceber.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(cbbpTipoConsumidor.Text, cbbpConsumidor.Text, mtxtpDataCad.Text, mtxtpDataCad1.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpSituacao.Text) == null)
                            {
                                dtContaReceber.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(cbbpTipoConsumidor.Text, cbbpConsumidor.Text, mtxtpDataCad.Text, mtxtpDataCad1.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpSituacao.Text);
                                dtContaReceber.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void btnTodasContas_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(0))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllContasReceber._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 0;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtContaReceber.Enabled = false;
                    dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    lblDataCadastro.Enabled = false;
                    lblDataEmissao.Enabled = false;
                    lblDataVencimento.Enabled = false;
                    mtxtpDataCad.Enabled = false;
                    mtxtpDataCad1.Enabled = false;
                    mtxtpDataEmi.Enabled = false;
                    mtxtpDataEmi1.Enabled = false;
                    mtxtpDataVenc.Enabled = false;
                    mtxtpDataVenc1.Enabled = false;
                    btnSelecionarData1.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    btnSelecionarData2.Enabled = false;
                    lblSituacao.Enabled = false;
                    lblGrupo.Enabled = false;
                    cbbpGrupo.Enabled = false;
                    btnProcurarGrupo.Enabled = false;
                    cbbpSituacao.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pPanel.Enabled = true;
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
            dtContaReceber.Enabled = false;
            dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            lblDataCadastro.Enabled = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataCad.Enabled = false;
            mtxtpDataCad1.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            lblGrupo.Enabled = false;
            cbbpGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            cbbpSituacao.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
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
            dtContaReceber.Enabled = false;
            dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            lblDataCadastro.Enabled = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataCad.Enabled = false;
            mtxtpDataCad1.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            lblGrupo.Enabled = false;
            cbbpGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            cbbpSituacao.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
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
                dtContaReceber.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                if (rbtnDescricao.Checked == true || rbtnTodas.Checked == true || rbtnConsumidor.Checked == true)
                {
                    lblDataCadastro.Enabled = true;
                    lblDataEmissao.Enabled = true;
                    lblDataVencimento.Enabled = true;
                    mtxtpDataCad.Enabled = true;
                    mtxtpDataCad1.Enabled = true;
                    mtxtpDataEmi.Enabled = true;
                    mtxtpDataEmi1.Enabled = true;
                    mtxtpDataVenc.Enabled = true;
                    mtxtpDataVenc1.Enabled = true;
                    btnSelecionarData1.Enabled = true;
                    btnSelecionarData.Enabled = true;
                    btnSelecionarData2.Enabled = true;
                    lblSituacao.Enabled = true;
                    lblGrupo.Enabled = true;
                    cbbpGrupo.Enabled = true;
                    btnProcurarGrupo.Enabled = true;
                    cbbpSituacao.Enabled = true;
                }
                else
                {
                    lblDataCadastro.Enabled = false;
                    lblDataEmissao.Enabled = false;
                    lblDataVencimento.Enabled = false;
                    mtxtpDataCad.Enabled = false;
                    mtxtpDataCad1.Enabled = false;
                    mtxtpDataEmi.Enabled = false;
                    mtxtpDataEmi1.Enabled = false;
                    mtxtpDataVenc.Enabled = false;
                    mtxtpDataVenc1.Enabled = false;
                    btnSelecionarData1.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    btnSelecionarData2.Enabled = false;
                    lblSituacao.Enabled = false;
                    lblGrupo.Enabled = false;
                    cbbpGrupo.Enabled = false;
                    btnProcurarGrupo.Enabled = false;
                    cbbpSituacao.Enabled = false;
                }
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                btnSair.Enabled = true;
                rbtnDescricao.Checked = true;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtContaReceber.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                if (rbtnDescricao.Checked == true || rbtnTodas.Checked == true || rbtnConsumidor.Checked == true)
                {
                    lblDataCadastro.Enabled = true;
                    lblDataEmissao.Enabled = true;
                    lblDataVencimento.Enabled = true;
                    mtxtpDataCad.Enabled = true;
                    mtxtpDataCad1.Enabled = true;
                    mtxtpDataEmi.Enabled = true;
                    mtxtpDataEmi1.Enabled = true;
                    mtxtpDataVenc.Enabled = true;
                    mtxtpDataVenc1.Enabled = true;
                    btnSelecionarData1.Enabled = true;
                    btnSelecionarData.Enabled = true;
                    btnSelecionarData2.Enabled = true;
                    lblSituacao.Enabled = true;
                    lblGrupo.Enabled = true;
                    cbbpGrupo.Enabled = true;
                    btnProcurarGrupo.Enabled = true;
                    cbbpSituacao.Enabled = true;
                }
                else
                {
                    lblDataCadastro.Enabled = false;
                    lblDataEmissao.Enabled = false;
                    lblDataVencimento.Enabled = false;
                    mtxtpDataCad.Enabled = false;
                    mtxtpDataCad1.Enabled = false;
                    mtxtpDataEmi.Enabled = false;
                    mtxtpDataEmi1.Enabled = false;
                    mtxtpDataVenc.Enabled = false;
                    mtxtpDataVenc1.Enabled = false;
                    btnSelecionarData1.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    btnSelecionarData2.Enabled = false;
                    lblSituacao.Enabled = false;
                    lblGrupo.Enabled = false;
                    cbbpGrupo.Enabled = false;
                    btnProcurarGrupo.Enabled = false;
                    cbbpSituacao.Enabled = false;
                }
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtContaReceber.Select();
                //
                try
                {
                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.pdf");
                    }
                    else if (_Trabalho == 3)
                    {
                        DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                        //
                        string arqmes;
                        if (Convert.ToDateTime(SelectedRow.Cells[4].Value).Month < 10)
                        {
                            arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Month;
                        }
                        else
                        {
                            arqmes = Convert.ToDateTime(SelectedRow.Cells[4].Value).Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 4)
                    {
                        DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                        //
                        string arqmes;
                        if (Convert.ToDateTime(SelectedRow.Cells[30].Value).Month < 10)
                        {
                            arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Month;
                        }
                        else
                        {
                            arqmes = Convert.ToDateTime(SelectedRow.Cells[30].Value).Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 5)
                    {
                        DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                        //
                        string arqmes;
                        if (Convert.ToDateTime(SelectedRow.Cells[30].Value).Month < 10)
                        {
                            arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Month;
                        }
                        else
                        {
                            arqmes = Convert.ToDateTime(SelectedRow.Cells[30].Value).Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
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
                    dtContaReceber.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    if (rbtnDescricao.Checked == true || rbtnConsumidor.Checked == true || rbtnTodas.Checked == true)
                    {
                        lblDataCadastro.Enabled = true;
                        lblDataEmissao.Enabled = true;
                        lblDataVencimento.Enabled = true;
                        mtxtpDataCad.Enabled = true;
                        mtxtpDataCad1.Enabled = true;
                        mtxtpDataEmi.Enabled = true;
                        mtxtpDataEmi1.Enabled = true;
                        mtxtpDataVenc.Enabled = true;
                        mtxtpDataVenc1.Enabled = true;
                        btnSelecionarData1.Enabled = true;
                        btnSelecionarData.Enabled = true;
                        btnSelecionarData2.Enabled = true;
                        lblSituacao.Enabled = true;
                        lblGrupo.Enabled = true;
                        cbbpGrupo.Enabled = true;
                        btnProcurarGrupo.Enabled = true;
                        cbbpSituacao.Enabled = true;
                    }
                    else
                    {
                        lblDataCadastro.Enabled = false;
                        lblDataEmissao.Enabled = false;
                        lblDataVencimento.Enabled = false;
                        mtxtpDataCad.Enabled = false;
                        mtxtpDataCad1.Enabled = false;
                        mtxtpDataEmi.Enabled = false;
                        mtxtpDataEmi1.Enabled = false;
                        mtxtpDataVenc.Enabled = false;
                        mtxtpDataVenc1.Enabled = false;
                        btnSelecionarData1.Enabled = false;
                        btnSelecionarData.Enabled = false;
                        btnSelecionarData2.Enabled = false;
                        lblSituacao.Enabled = false;
                        lblGrupo.Enabled = false;
                        cbbpGrupo.Enabled = false;
                        btnProcurarGrupo.Enabled = false;
                        cbbpSituacao.Enabled = false;
                    }
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnDescricao.Checked = true;
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
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllContasReceber._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter2.DrawString(DateTime.Now.ToShortTimeString(), fonte1, XBrushes.Black, new XRect(526 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
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
                    textFormatter1.DrawString("Relatório de Contas a Receber", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO  CONSUMIDOR  Nº PROMISSÓRIA  DATA DE VENCIMENTO  VALOR REAL (R$) SITUAÇÃO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtContaReceber.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtContaReceber.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtContaReceber.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtContaReceber.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[7].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº da Promissória:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(190 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(279 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(340 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(408 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Recebido (R$): " + lblValorRecebido.Text, fonte2, XBrushes.Blue, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("a Receber (R$): " + lblValorAPagar.Text, fonte2, XBrushes.Red, new XRect(240 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));

                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[7].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº da Promissória:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(190 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(279 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(340 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(408 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            //
                            if (linha == (pagina - 1) & dtContaReceber.Rows.Count > 15)
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
                                textFormatter1.DrawString("Relatório de Contas a Receber", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Contas a Receber", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtContaReceber.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[7].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº da Promissória:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(190 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(279 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(340 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(408 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Recebido (R$): " + lblValorRecebido.Text, fonte2, XBrushes.Blue, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("a Receber (R$): " + lblValorAPagar.Text, fonte2, XBrushes.Red, new XRect(240 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));

                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[7].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[7].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº da Promissória:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[2].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(190 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(279 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(340 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(408 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.pdf");
                    }
                }
            }
            /*
            else if (_Trabalho == 1)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    bool PrimeiraPagina = true;
                    int pagina = 1;
                    int ContadorPagina = 1;
                    int TotalPaginas = dtContaReceber.Rows.Count;
                    StringBuilder sb = new StringBuilder();
                    //
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    var fonte5 = new XFont("Microsoft Sans Serif", 11, XFontStyle.Bold);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    DataRow dr;
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm();
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm();
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllContasReceber._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter2.DrawString(DateTime.Now.ToShortTimeString(), fonte1, XBrushes.Black, new XRect(526 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
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
                    textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + "CPF/CNPJ.: " + dr["cpf_cnpj"].ToString() + ", IE.: " + dr["ie_rg"].ToString() + Environment.NewLine + "End.: " + dr["endereco"].ToString() + Environment.NewLine + dr["complemento"].ToString() + ", " + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + "Tel.: " + dr["telefone"].ToString() + ", Cel.: " + dr["celular"].ToString() + ", FAX.: " + dr["fax"].ToString() + Environment.NewLine + "Site.: " + dr["site"].ToString() + Environment.NewLine + "E-mail.: " + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                    //
                    textFormatter1.DrawString("Relatório de Contas a Receber", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 125 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Página(s): 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(3 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    Margem_Topo = Convert.ToInt16(Margem_Topo - 5);
                    //
                    for (int x = 0; x < dtContaReceber.Rows.Count; x++)
                    {
                        DataGridViewRow SelectedRow = dtContaReceber.Rows[x];
                        //
                        if (PrimeiraPagina == true)
                        {
                            //Código
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo, 75, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo, 75, 18);
                            textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo, 70, page.Height));
                            //Descrição
                            graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 180 + Margem_Topo, 509, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 198 + Margem_Topo, 509, 18);
                            textFormatter2.DrawString("Descrição:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                            //Código de Barras
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo, 470, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo, 470, 18);
                            textFormatter2.DrawString("Código de Barras:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                            //Nº da Promissória
                            graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, 216 + Margem_Topo, 114, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 475 + Margem_Esq, 234 + Margem_Topo, 114, 18);
                            textFormatter2.DrawString("Nº da Promissória:", fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(477 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                            //Data de Emissão
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo, 80, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo, 80, 18);
                            textFormatter2.DrawString("Data de Emissão:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Data de Vencimento
                            graphics.DrawRectangle(pen, XBrushes.White, 85 + Margem_Esq, 252 + Margem_Topo, 90, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 85 + Margem_Esq, 270 + Margem_Topo, 90, 18);
                            textFormatter2.DrawString("Data de Vencimento:", fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(87 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Tipo do Documento
                            graphics.DrawRectangle(pen, XBrushes.White, 175 + Margem_Esq, 252 + Margem_Topo, 200, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 175 + Margem_Esq, 270 + Margem_Topo, 200, 18);
                            textFormatter2.DrawString("Tipo do Documento:", fonte4, XBrushes.Black, new XRect(177 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(177 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Tipo de Emitente
                            graphics.DrawRectangle(pen, XBrushes.White, 375 + Margem_Esq, 252 + Margem_Topo, 149, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 375 + Margem_Esq, 270 + Margem_Topo, 149, 18);
                            textFormatter2.DrawString("Tipo de Consumidor:", fonte4, XBrushes.Black, new XRect(377 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(377 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Parcela(s)    
                            graphics.DrawRectangle(pen, XBrushes.White, 524 + Margem_Esq, 252 + Margem_Topo, 65, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 524 + Margem_Esq, 270 + Margem_Topo, 65, 18);
                            textFormatter2.DrawString("Parcela(s):", fonte4, XBrushes.Black, new XRect(526 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(526 + Margem_Esq, 272 + Margem_Topo, 60, page.Height));
                            //Código do Emitente
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo, 90, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo, 90, 18);
                            textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, 85, page.Height));
                            //Nome do Emitente
                            graphics.DrawRectangle(pen, XBrushes.White, 95 + Margem_Esq, 288 + Margem_Topo, 494, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 95 + Margem_Esq, 306 + Margem_Topo, 494, 18);
                            textFormatter2.DrawString("Nome/Razão Social do Consumidor:", fonte4, XBrushes.Black, new XRect(97 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(97 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                            //Código do Grupo
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo, 80, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo, 80, 18);
                            textFormatter2.DrawString("Cód. do Grupo:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, 75, page.Height));
                            //Descrição do Grupo
                            graphics.DrawRectangle(pen, XBrushes.White, 85 + Margem_Esq, 324 + Margem_Topo, 504, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 85 + Margem_Esq, 342 + Margem_Topo, 504, 18);
                            textFormatter2.DrawString("Descrição do Grupo:", fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(87 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                            //Código do Subgrupo
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 360 + Margem_Topo, 85, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 378 + Margem_Topo, 85, 18);
                            textFormatter2.DrawString("Cód. do Subgrupo:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 380 + Margem_Topo, 80, page.Height));
                            //Descrição do Subgrupo
                            graphics.DrawRectangle(pen, XBrushes.White, 90 + Margem_Esq, 360 + Margem_Topo, 499, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 90 + Margem_Esq, 378 + Margem_Topo, 499, 18);
                            textFormatter2.DrawString("Descrição do Subgrupo:", fonte4, XBrushes.Black, new XRect(92 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(92 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                            //Valor
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 396 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 414 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 416 + Margem_Topo, 90, page.Height));
                            //Valor
                            graphics.DrawRectangle(pen, XBrushes.White, 100 + Margem_Esq, 396 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 100 + Margem_Esq, 414 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Valor Real (R$):", fonte4, XBrushes.Black, new XRect(102 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(102 + Margem_Esq, 416 + Margem_Topo, 90, page.Height));
                            //Data de Desconto
                            graphics.DrawRectangle(pen, XBrushes.White, 195 + Margem_Esq, 396 + Margem_Topo, 85, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 195 + Margem_Esq, 414 + Margem_Topo, 85, 18);
                            textFormatter2.DrawString("Data de Desconto:", fonte4, XBrushes.Black, new XRect(197 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[17].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(197 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                            }
                            //Desconto (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 280 + Margem_Esq, 396 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 280 + Margem_Esq, 414 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(282 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[18].Value).ToString("n2", new CultureInfo("pt-BR")) + "%", fonte1, XBrushes.Black, new XRect(282 + Margem_Esq, 416 + Margem_Topo, 90, page.Height));
                            //Valor Desconto (R$)
                            graphics.DrawRectangle(pen, XBrushes.White, 375 + Margem_Esq, 396 + Margem_Topo, 105, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 375 + Margem_Esq, 414 + Margem_Topo, 105, 18);
                            textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(377 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(377 + Margem_Esq, 416 + Margem_Topo, 100, page.Height));
                            //Multa (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 480 + Margem_Esq, 396 + Margem_Topo, 109, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 480 + Margem_Esq, 414 + Margem_Topo, 109, 18);
                            textFormatter2.DrawString("Multa (%):", fonte4, XBrushes.Black, new XRect(482 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")) + "%", fonte1, XBrushes.Black, new XRect(482 + Margem_Esq, 416 + Margem_Topo, 104, page.Height));
                            //Valor Multa (R$)
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 450 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("Valor da Multa (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 452 + Margem_Topo, 120, page.Height));

                            //Juros (a.m) (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 130 + Margem_Esq, 432 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 130 + Margem_Esq, 450 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("Juros (a.m) (%):", fonte4, XBrushes.Black, new XRect(132 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR")) + "%", fonte1, XBrushes.Black, new XRect(132 + Margem_Esq, 452 + Margem_Topo, 120, page.Height));
                            //Valor Juros (a.m) (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 432 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 450 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("Valor do Juros (a.m) (R$):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[23].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 452 + Margem_Topo, 120, page.Height));
                            //Situação
                            graphics.DrawRectangle(pen, XBrushes.White, 380 + Margem_Esq, 432 + Margem_Topo, 105, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 380 + Margem_Esq, 450 + Margem_Topo, 105, 18);
                            textFormatter2.DrawString("Situação:", fonte4, XBrushes.Black, new XRect(382 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[24].Value.ToString(), fonte1, XBrushes.Black, new XRect(382 + Margem_Esq, 452 + Margem_Topo, page.Width, page.Height));
                            //Palavra Chave
                            graphics.DrawRectangle(pen, XBrushes.White, 485 + Margem_Esq, 432 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 485 + Margem_Esq, 450 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(487 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[30].Value.ToString(), fonte1, XBrushes.Black, new XRect(487 + Margem_Esq, 452 + Margem_Topo, page.Width, page.Height));
                            //Data do Pagamento
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 468 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 486 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Data da Baixa:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[27].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[27].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            }
                            //Valor Pago
                            graphics.DrawRectangle(pen, XBrushes.White, 105 + Margem_Esq, 468 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 105 + Margem_Esq, 486 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(107 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(107 + Margem_Esq, 488 + Margem_Topo, 95, page.Height));
                            //Troco
                            graphics.DrawRectangle(pen, XBrushes.White, 205 + Margem_Esq, 468 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 205 + Margem_Esq, 486 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(207 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[26].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(207 + Margem_Esq, 488 + Margem_Topo, 95, page.Height));
                            //Hora da Baixa
                            graphics.DrawRectangle(pen, XBrushes.White, 305 + Margem_Esq, 468 + Margem_Topo, 90, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 305 + Margem_Esq, 486 + Margem_Topo, 90, 18);
                            textFormatter2.DrawString("Hora da Baixa:", fonte4, XBrushes.Black, new XRect(307 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[28].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[28].Value.ToString().Remove(5), fonte1, XBrushes.Black, new XRect(307 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            graphics.DrawRectangle(pen, XBrushes.White, 395 + Margem_Esq, 468 + Margem_Topo, 80, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 395 + Margem_Esq, 486 + Margem_Topo, 80, 18);
                            textFormatter2.DrawString("Cód. da Venda:", fonte4, XBrushes.Black, new XRect(397 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[33].Value.ToString() != "0")
                            {
                                textFormatter3.DrawString(SelectedRow.Cells[33].Value.ToString(), fonte1, XBrushes.Black, new XRect(397 + Margem_Esq, 488 + Margem_Topo, 75, page.Height));
                            }
                            //Data de Cadastro
                            graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, 468 + Margem_Topo, 114, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 475 + Margem_Esq, 486 + Margem_Topo, 114, 18);
                            textFormatter2.DrawString("Data do Cadastro:", fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[31].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(477 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            //Observações
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 504 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 522 + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 506 + Margem_Topo, page.Width, page.Height));
                            sb.Clear();
                            sb.Append(SelectedRow.Cells[29].Value.ToString());
                            if (SelectedRow.Cells[29].Value.ToString().Length > 160)
                            {
                                if (!SelectedRow.Cells[29].Value.ToString().Substring(80, 80).Contains(" "))
                                {
                                    sb.Insert(160, Environment.NewLine);
                                }
                            }
                            //
                            if (SelectedRow.Cells[29].Value.ToString().Length > 80)
                            {
                                if (!SelectedRow.Cells[29].Value.ToString().Substring(0, 80).Contains(" "))
                                {
                                    sb.Insert(80, Environment.NewLine);
                                }
                            }
                            textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 524 + Margem_Topo, 584, 36));
                            //
                            if (dtContaReceber.Rows.Count > 1)
                            {
                                pagina = pagina + 1;
                                PrimeiraPagina = false;
                                page = doc.AddPage();//Adicionar página
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                ContadorPagina = ContadorPagina + 1;
                                textFormatter1.DrawString("Relatório de Contas a Receber", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Página(s): " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(3 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                            }
                        }
                        else
                        {
                            //Código
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 66 + Margem_Topo, 75, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 84 + Margem_Topo, 75, 18);
                            textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 68 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 86 + Margem_Topo, 70, page.Height));
                            //Descrição
                            graphics.DrawRectangle(pen, XBrushes.White, 80 + Margem_Esq, 66 + Margem_Topo, 509, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 80 + Margem_Esq, 84 + Margem_Topo, 509, 18);
                            textFormatter2.DrawString("Descrição:", fonte4, XBrushes.Black, new XRect(82 + Margem_Esq, 68 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(82 + Margem_Esq, 86 + Margem_Topo, page.Width, page.Height));
                            //Código de Barras
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 102 + Margem_Topo, 470, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 120 + Margem_Topo, 470, 18);
                            textFormatter2.DrawString("Código de Barras:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 104 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                            //Nº da Promissória
                            graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, 102 + Margem_Topo, 114, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 475 + Margem_Esq, 120 + Margem_Topo, 114, 18);
                            textFormatter2.DrawString("Nº da Promissória:", fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, 104 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(477 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                            //Data de Emissão
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 138 + Margem_Topo, 80, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 156 + Margem_Topo, 80, 18);
                            textFormatter2.DrawString("Data de Emissão:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 140 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 158 + Margem_Topo, page.Width, page.Height));
                            //Data de Vencimento
                            graphics.DrawRectangle(pen, XBrushes.White, 85 + Margem_Esq, 138 + Margem_Topo, 90, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 85 + Margem_Esq, 156 + Margem_Topo, 90, 18);
                            textFormatter2.DrawString("Data de Vencimento:", fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, 140 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(87 + Margem_Esq, 158 + Margem_Topo, page.Width, page.Height));
                            //Tipo do Documento
                            graphics.DrawRectangle(pen, XBrushes.White, 175 + Margem_Esq, 138 + Margem_Topo, 200, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 175 + Margem_Esq, 156 + Margem_Topo, 200, 18);
                            textFormatter2.DrawString("Tipo do Documento:", fonte4, XBrushes.Black, new XRect(177 + Margem_Esq, 140 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(177 + Margem_Esq, 158 + Margem_Topo, page.Width, page.Height));
                            //Tipo de Emitente
                            graphics.DrawRectangle(pen, XBrushes.White, 375 + Margem_Esq, 138 + Margem_Topo, 149, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 375 + Margem_Esq, 156 + Margem_Topo, 149, 18);
                            textFormatter2.DrawString("Tipo de Consumidor:", fonte4, XBrushes.Black, new XRect(377 + Margem_Esq, 140 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(377 + Margem_Esq, 158 + Margem_Topo, page.Width, page.Height));
                            //Parcela(s)    
                            graphics.DrawRectangle(pen, XBrushes.White, 524 + Margem_Esq, 138 + Margem_Topo, 65, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 524 + Margem_Esq, 156 + Margem_Topo, 65, 18);
                            textFormatter2.DrawString("Parcela(s):", fonte4, XBrushes.Black, new XRect(526 + Margem_Esq, 140 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[3].Value.ToString(), fonte1, XBrushes.Black, new XRect(526 + Margem_Esq, 158 + Margem_Topo, 60, page.Height));
                            //Código do Emitente
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 174 + Margem_Topo, 90, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 192 + Margem_Topo, 90, 18);
                            textFormatter2.DrawString("Cód. do Consumidor:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 176 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 194 + Margem_Topo, 85, page.Height));
                            //Nome do Emitente
                            graphics.DrawRectangle(pen, XBrushes.White, 95 + Margem_Esq, 174 + Margem_Topo, 494, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 95 + Margem_Esq, 192 + Margem_Topo, 494, 18);
                            textFormatter2.DrawString("Nome/Razão Social do Consumidor:", fonte4, XBrushes.Black, new XRect(97 + Margem_Esq, 176 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(97 + Margem_Esq, 194 + Margem_Topo, page.Width, page.Height));
                            //Código do Grupo
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 210 + Margem_Topo, 80, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 228 + Margem_Topo, 80, 18);
                            textFormatter2.DrawString("Cód. do Grupo:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 212 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 230 + Margem_Topo, 75, page.Height));
                            //Descrição do Grupo
                            graphics.DrawRectangle(pen, XBrushes.White, 85 + Margem_Esq, 210 + Margem_Topo, 504, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 85 + Margem_Esq, 228 + Margem_Topo, 504, 18);
                            textFormatter2.DrawString("Descrição do Grupo:", fonte4, XBrushes.Black, new XRect(87 + Margem_Esq, 212 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(87 + Margem_Esq, 230 + Margem_Topo, page.Width, page.Height));
                            
                            //Código do Subgrupo
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 246 + Margem_Topo, 85, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 264 + Margem_Topo, 85, 18);
                            textFormatter2.DrawString("Cód. do Subgrupo:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 248 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 266 + Margem_Topo, 80, page.Height));
                            //Descrição do Subgrupo
                            graphics.DrawRectangle(pen, XBrushes.White, 90 + Margem_Esq, 246 + Margem_Topo, 499, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 90 + Margem_Esq, 264 + Margem_Topo, 499, 18);
                            textFormatter2.DrawString("Descrição do Subgrupo:", fonte4, XBrushes.Black, new XRect(92 + Margem_Esq, 248 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(92 + Margem_Esq, 266 + Margem_Topo, page.Width, page.Height));
                            //Valor
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 282 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 300 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Valor (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 284 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 302 + Margem_Topo, 90, page.Height));
                            //Valor
                            graphics.DrawRectangle(pen, XBrushes.White, 100 + Margem_Esq, 282 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 100 + Margem_Esq, 300 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Valor Real (R$):", fonte4, XBrushes.Black, new XRect(102 + Margem_Esq, 284 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(102 + Margem_Esq, 302 + Margem_Topo, 90, page.Height));
                            //Data de Desconto
                            graphics.DrawRectangle(pen, XBrushes.White, 195 + Margem_Esq, 282 + Margem_Topo, 85, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 195 + Margem_Esq, 300 + Margem_Topo, 85, 18);
                            textFormatter2.DrawString("Data de Desconto:", fonte4, XBrushes.Black, new XRect(197 + Margem_Esq, 284 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[17].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(197 + Margem_Esq, 302 + Margem_Topo, page.Width, page.Height));
                            }
                            //Desconto (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 280 + Margem_Esq, 282 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 280 + Margem_Esq, 300 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Desconto (%):", fonte4, XBrushes.Black, new XRect(282 + Margem_Esq, 284 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[18].Value).ToString("n2", new CultureInfo("pt-BR")) + "%", fonte1, XBrushes.Black, new XRect(282 + Margem_Esq, 302 + Margem_Topo, 90, page.Height));
                            //Valor Desconto (R$)
                            graphics.DrawRectangle(pen, XBrushes.White, 375 + Margem_Esq, 282 + Margem_Topo, 105, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 375 + Margem_Esq, 300 + Margem_Topo, 105, 18);
                            textFormatter2.DrawString("Valor do Desconto (R$):", fonte4, XBrushes.Black, new XRect(377 + Margem_Esq, 284 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(377 + Margem_Esq, 302 + Margem_Topo, 100, page.Height));
                            //Multa (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 480 + Margem_Esq, 282 + Margem_Topo, 109, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 480 + Margem_Esq, 300 + Margem_Topo, 109, 18);
                            textFormatter2.DrawString("Multa (%):", fonte4, XBrushes.Black, new XRect(482 + Margem_Esq, 284 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")) + "%", fonte1, XBrushes.Black, new XRect(482 + Margem_Esq, 302 + Margem_Topo, 104, page.Height));
                            //Valor Multa (R$)
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 318 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 336 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("Valor da Multa (R$):", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 320 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 338 + Margem_Topo, 120, page.Height));

                            //Juros (a.m) (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 130 + Margem_Esq, 318 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 130 + Margem_Esq, 336 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("Juros (a.m) (%):", fonte4, XBrushes.Black, new XRect(132 + Margem_Esq, 320 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR")) + "%", fonte1, XBrushes.Black, new XRect(132 + Margem_Esq, 338 + Margem_Topo, 120, page.Height));
                            //Valor Juros (a.m) (%)
                            graphics.DrawRectangle(pen, XBrushes.White, 255 + Margem_Esq, 318 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 255 + Margem_Esq, 336 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("Valor do Juros (a.m) (R$):", fonte4, XBrushes.Black, new XRect(257 + Margem_Esq, 320 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[23].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(257 + Margem_Esq, 338 + Margem_Topo, 120, page.Height));
                            //Situação
                            graphics.DrawRectangle(pen, XBrushes.White, 380 + Margem_Esq, 318 + Margem_Topo, 105, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 380 + Margem_Esq, 336 + Margem_Topo, 105, 18);
                            textFormatter2.DrawString("Situação:", fonte4, XBrushes.Black, new XRect(382 + Margem_Esq, 320 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[24].Value.ToString(), fonte1, XBrushes.Black, new XRect(382 + Margem_Esq, 338 + Margem_Topo, page.Width, page.Height));
                            //Palavra Chave
                            graphics.DrawRectangle(pen, XBrushes.White, 485 + Margem_Esq, 318 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 485 + Margem_Esq, 336 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(487 + Margem_Esq, 320 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[30].Value.ToString(), fonte1, XBrushes.Black, new XRect(487 + Margem_Esq, 338 + Margem_Topo, page.Width, page.Height));
                            //Data do Pagamento
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 354 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 372 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Data da Baixa:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 356 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[27].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[27].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                            }
                            //Valor Pago
                            graphics.DrawRectangle(pen, XBrushes.White, 105 + Margem_Esq, 354 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 105 + Margem_Esq, 372 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Valor Total Pago (R$):", fonte4, XBrushes.Black, new XRect(107 + Margem_Esq, 356 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(107 + Margem_Esq, 374 + Margem_Topo, 95, page.Height));
                            //Troco
                            graphics.DrawRectangle(pen, XBrushes.White, 205 + Margem_Esq, 354 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 205 + Margem_Esq, 372 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Troco (R$):", fonte4, XBrushes.Black, new XRect(207 + Margem_Esq, 356 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[26].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(207 + Margem_Esq, 374 + Margem_Topo, 95, page.Height));
                            //Hora da Baixa
                            graphics.DrawRectangle(pen, XBrushes.White, 305 + Margem_Esq, 354 + Margem_Topo, 90, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 305 + Margem_Esq, 372 + Margem_Topo, 90, 18);
                            textFormatter2.DrawString("Hora da Baixa:", fonte4, XBrushes.Black, new XRect(307 + Margem_Esq, 356 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[28].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[28].Value.ToString().Remove(5), fonte1, XBrushes.Black, new XRect(307 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                            }
                            //Cód. da Venda
                            graphics.DrawRectangle(pen, XBrushes.White, 395 + Margem_Esq, 354 + Margem_Topo, 80, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 395 + Margem_Esq, 372 + Margem_Topo, 80, 18);
                            textFormatter2.DrawString("Cód. da Venda:", fonte4, XBrushes.Black, new XRect(397 + Margem_Esq, 356 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[33].Value.ToString() != "0")
                            {
                                textFormatter3.DrawString(SelectedRow.Cells[33].Value.ToString(), fonte1, XBrushes.Black, new XRect(397 + Margem_Esq, 374 + Margem_Topo, 75, page.Height));
                            }
                            //Data de Cadastro
                            graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, 354 + Margem_Topo, 114, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 475 + Margem_Esq, 372 + Margem_Topo, 114, 18);
                            textFormatter2.DrawString("Data do Cadastro:", fonte4, XBrushes.Black, new XRect(477 + Margem_Esq, 356 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[31].Value.ToString().Remove(10), fonte1, XBrushes.Black, new XRect(477 + Margem_Esq, 374 + Margem_Topo, page.Width, page.Height));
                            //Observações
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 390 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 408 + Margem_Topo, 584, 36);
                            textFormatter2.DrawString("Observações:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 392 + Margem_Topo, page.Width, page.Height));
                            sb.Clear();
                            sb.Append(SelectedRow.Cells[29].Value.ToString());
                            if (SelectedRow.Cells[29].Value.ToString().Length > 160)
                            {
                                if (!SelectedRow.Cells[29].Value.ToString().Substring(80, 80).Contains(" "))
                                {
                                    sb.Insert(160, Environment.NewLine);
                                }
                            }
                            //
                            if (SelectedRow.Cells[29].Value.ToString().Length > 80)
                            {
                                if (!SelectedRow.Cells[29].Value.ToString().Substring(0, 80).Contains(" "))
                                {
                                    sb.Insert(80, Environment.NewLine);
                                }
                            }
                            textFormatter2.DrawString(sb.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 410 + Margem_Topo, 584, 36));                            
                            //
                            if (dtContaReceber.Rows.Count > pagina)
                            {
                                pagina = pagina + 1;
                                PrimeiraPagina = false;
                                page = doc.AddPage();//Adicionar página
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                ContadorPagina = ContadorPagina + 1;
                                textFormatter1.DrawString("Relatório de Contas a Receber", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Página(s): " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\Contas a Receber"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\Contas a Receber");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\Contas a Receber\Contas a Receber.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\Contas a Receber\Contas a Receber.pdf");
                    }
                }
            }
            */
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.txt"))
                {
                    writer.WriteLine("Relatório de Contas a Receber" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToShortTimeString());
                    for (int linha = 0; linha < dtContaReceber.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtContaReceber.Rows[linha];
                        string n_promissoria = SelectedRow.Cells[2].Value.ToString();
                        string data_baixa = SelectedRow.Cells[26].Value.ToString();
                        string data_desconto = SelectedRow.Cells[16].Value.ToString();
                        string hora_baixa = SelectedRow.Cells[27].Value.ToString();
                        string codigo_venda = SelectedRow.Cells[31].Value.ToString();
                        //
                        if (data_desconto == "" || data_desconto == null)
                        {
                            data_desconto = "";
                        }
                        else
                        {
                            data_desconto = data_desconto.Remove(10);
                        }
                        //
                        if (data_baixa == "" || data_baixa == null)
                        {
                            data_baixa = "";
                        }
                        else
                        {
                            data_baixa = data_baixa.Remove(10);
                        }
                        //
                        if (hora_baixa == "" || hora_baixa == null)
                        {
                            hora_baixa = "";
                        }
                        else
                        {
                            hora_baixa = hora_baixa.Remove(5);
                        }
                        //
                        if (codigo_venda != "0")
                        {
                            codigo_venda = SelectedRow.Cells[33].Value.ToString();
                        }
                        else
                        {
                            codigo_venda = "";
                        }
                        //
                        if (n_promissoria != "0")
                        {
                            n_promissoria = SelectedRow.Cells[2].Value.ToString();
                        }
                        else
                        {
                            n_promissoria = "";
                        }
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Descrição: " + SelectedRow.Cells[1].Value.ToString() + " |Nº da Promissória: " + n_promissoria + " |Parcela(s): " + SelectedRow.Cells[3].Value.ToString() + " |Data de Emissão: " + SelectedRow.Cells[4].Value.ToString().Remove(10) + " |Data de Vencimento: " + SelectedRow.Cells[5].Value.ToString().Remove(10) + " |Tipo do Documento: " + SelectedRow.Cells[6].Value.ToString() + " |Tipo de Consumidor: " + SelectedRow.Cells[7].Value.ToString() + " |Cód. do Consumidor: " + SelectedRow.Cells[8].Value.ToString() + " |Nome/Razão Social do Consumidor: " + SelectedRow.Cells[9].Value.ToString() + " |Cód. do Grupo: " + SelectedRow.Cells[10].Value.ToString() + " |Descrição do Grupo: " + SelectedRow.Cells[11].Value.ToString() + " |Cód. do Subgrupo: " + SelectedRow.Cells[12].Value.ToString() + " |Descrição do Subgrupo: " + SelectedRow.Cells[13].Value.ToString() + " |Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Desconto Até: " + data_desconto + " |Desconto (%): " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "% |Valor do Desconto (R$): " + Convert.ToDecimal(SelectedRow.Cells[18].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Multa (%): " + Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")) + "% |Valor da Multa (R$): " + Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Juros (a.m) (%): " + Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")) + "% |Valor Juros (a.m) (R$): " + Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Situação: " + SelectedRow.Cells[23].Value.ToString() + " |Valor Total Pago (R$): " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Data da Baixa: " + data_baixa + " |Hora da Baixa: " + hora_baixa + " |Observações: " + SelectedRow.Cells[28].Value.ToString() + " |Palavra-Chave: " + SelectedRow.Cells[29].Value.ToString() + " |Data de Cadastro: " + SelectedRow.Cells[30].Value.ToString().Remove(10) + " |Cód. da Venda: " + codigo_venda + " |Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "| Cód. do Usuário da Baixa: " + SelectedRow.Cells[34].Value.ToString() + "| Nome do Usuário da Baixa: " + SelectedRow.Cells[35].Value.ToString() + "| Cód. do Cheque: " + SelectedRow.Cells[38].Value.ToString());
                    }
                    writer.WriteLine("Total (R$): " + lblValorTotal.Text);
                    writer.WriteLine("a Receber (R$): " + lblValorAPagar.Text);
                    writer.WriteLine("Recebido (R$): " + lblValorRecebido.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.txt");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Descrição;Nº da Promissória;Parcela(s);Data de Emissão;Data de Vencimento;Tipo do Documento;Tipo de Consumidor;Cód. do Consumidor;Nome/Razão Social do Consumidor;Cód. do Grupo;Descrição do Grupo;Cód. do Subgrupo;Descrição do Subgrupo;Valor (R$);Valor Real (R$);Desconto Até;Desconto (%);Valor do Desconto (R$);Multa (%);Valor da Multa (R$);Juros (a.m) (%);Valor Juros (a.m) (R$);Situação;Valor Pago (R$);Data da Baixa;Hora da Baixa;Observações;Palavra-Chave;Data de Cadastro;Cód. da Venda;Troco (R$);Cód. do Usuario da Baixa;Nome do Usuário da Baixa;Cód. do Cheque");
                    //
                    for (int linha = 0; linha < dtContaReceber.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtContaReceber.Rows[linha];
                        string n_promissoria = SelectedRow.Cells[2].Value.ToString();
                        string data_baixa = SelectedRow.Cells[26].Value.ToString();
                        string data_desconto = SelectedRow.Cells[16].Value.ToString();
                        string hora_baixa = SelectedRow.Cells[27].Value.ToString();
                        string codigo_venda = SelectedRow.Cells[31].Value.ToString();
                        //
                        if (data_desconto == "" || data_desconto == null)
                        {
                            data_desconto = "";
                        }
                        else
                        {
                            data_desconto = data_desconto.Remove(10);
                        }
                        //
                        if (data_baixa == "" || data_baixa == null)
                        {
                            data_baixa = "";
                        }
                        else
                        {
                            data_baixa = data_baixa.Remove(10);
                        }
                        //
                        if (hora_baixa == "" || hora_baixa == null)
                        {
                            hora_baixa = "";
                        }
                        else
                        {
                            hora_baixa = hora_baixa.Remove(5);
                        }
                        //
                        if (codigo_venda == "0")
                        {
                            codigo_venda = "";
                        }
                        //
                        if (n_promissoria == "0")
                        {
                            n_promissoria = "";
                        }
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28};{29};{30};{31};{32};{33};{34}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), n_promissoria, SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString().Remove(10), SelectedRow.Cells[5].Value.ToString().Remove(10), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), data_desconto, Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[18].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[23].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")), data_baixa, hora_baixa, SelectedRow.Cells[28].Value.ToString(), SelectedRow.Cells[29].Value.ToString(), SelectedRow.Cells[30].Value.ToString().Remove(10), codigo_venda, Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[34].Value.ToString(), SelectedRow.Cells[35].Value.ToString(), SelectedRow.Cells[38].Value.ToString()));

                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Contas a Receber");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToShortTimeString());
                    Sw.WriteLine("Total (R$): " + lblValorTotal.Text);
                    Sw.WriteLine("a Receber (R$): " + lblValorAPagar.Text);
                    Sw.WriteLine("Recebido (R$): " + lblValorRecebido.Text);
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Contas a Receber.csv");
            }
            else if (_Trabalho == 3)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen = new XPen(XColors.Black);
                    XPen pen2 = new XPen(XColors.LightGray);
                    int Incrementar = 0;
                    DataRow drCabecalho;
                    //
                    DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                    // 
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de 1", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //
                    //Logo da Promissoria
                    XImage imagem1 = XImage.FromFile(@"C:\Sistema SEVEN\Config\Miscellaneous\rfb_np.png");
                    //
                    CultureInfo cultura = new CultureInfo("pt-BR");
                    DateTimeFormatInfo dtfi = cultura.DateTimeFormat;
                    int dia;
                    int ano;
                    string mes;
                    //Linhas do datagrid                                            
                    //
                    //Código
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 5 + Margem_Topo, 575, 175);
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 5 + Margem_Topo, 60, 175);
                    //
                    graphics.DrawImage(imagem1, 17 + Margem_Esq, Incrementar + 7 + Margem_Topo, 45, 171);
                    //
                    XImage imagem2;
                    string espaco;
                    int margem_esq_prom_num;
                    if (bllContasReceber._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        imagem2 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem2, 70 + Margem_Esq, Incrementar + 7 + Margem_Topo, 58, 69);
                        espaco = "                           ";
                        margem_esq_prom_num = 135;
                    }
                    else
                    {
                        espaco = "";
                        margem_esq_prom_num = 70;
                    }
                    //
                    textFormatter2.DrawString("NOTA PROMISSÓRIA", fonte1, XBrushes.Black, new XRect(margem_esq_prom_num + Margem_Esq, Incrementar + 7 + Margem_Topo, page.Width, 14));
                    //
                    DateTime vencimento = Convert.ToDateTime(SelectedRow.Cells[5].Value.ToString());
                    //
                    dia = vencimento.Day;
                    ano = vencimento.Year;
                    mes = cultura.TextInfo.ToTitleCase(dtfi.GetMonthName(vencimento.Month).ToUpper());
                    //
                    graphics.DrawRectangle(pen2, XBrushes.LightGray, 400 + Margem_Esq, Incrementar + 7 + Margem_Topo, 175, 14);
                    textFormatter3.DrawString("Vencimento: " + dia + " de " + mes + " de " + ano, fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 8 + Margem_Topo, 570, 14));
                    //
                    graphics.DrawRectangle(pen2, XBrushes.LightGray, margem_esq_prom_num + Margem_Esq, Incrementar + 24 + Margem_Topo, 125, 14);
                    textFormatter2.DrawString("Nº/Parcela: " + SelectedRow.Cells[2].Value.ToString() + "/" + SelectedRow.Cells[3].Value.ToString(), fonte4, XBrushes.Black, new XRect(margem_esq_prom_num + Margem_Esq, Incrementar + 25 + Margem_Topo, 85, 14));
                    //
                    graphics.DrawRectangle(pen2, XBrushes.LightGray, 400 + Margem_Esq, Incrementar + 24 + Margem_Topo, 175, 14);
                    textFormatter3.DrawString("Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[14].Value.ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 25 + Margem_Topo, 570, 14));
                    //
                    drCabecalho = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    string cpf_cnpj;
                    if (Convert.ToByte(drCabecalho["pessoa"]) == 0)
                    {
                        cpf_cnpj = "CPF";
                    }
                    else
                    {
                        cpf_cnpj = "CNPJ";
                    }
                    textFormatter2.DrawString(espaco + "No dia " + dia + " do mês de " + mes + " do ano de " + ano + " pagarei(emos) por esta única via de NOTA PROMISSÓRIA a " + drCabecalho["nome"].ToString() + ", " + cpf_cnpj + " de nº " + drCabecalho["cpf_cnpj"].ToString() + " ou a sua ordem, a quantia de " + Convert.ToDecimal(SelectedRow.Cells[14].Value.ToString()).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(SelectedRow.Cells[14].Value.ToString())) + "), em moeda corrente deste país.", fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 65 + Margem_Topo, 505, 45));
                    //
                    textFormatter2.DrawString("Pagável em: " + drCabecalho["cidade"].ToString() + "-" + drCabecalho["uf"].ToString(), fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 119 + Margem_Topo, 505, 10));
                    //
                    DateTime emissao = Convert.ToDateTime(SelectedRow.Cells[4].Value.ToString());
                    //

                    dia = emissao.Day;
                    ano = emissao.Year;
                    mes = cultura.TextInfo.ToTitleCase(dtfi.GetMonthName(emissao.Month).ToUpper());
                    textFormatter3.DrawString("Emissão: " + dia + " de " + mes + " de " + ano, fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 119 + Margem_Topo, 570, 10));
                    //
                    textFormatter2.DrawString("Emitente:_______________________________________________________________________________________ ", fonte4, XBrushes.Black, new XRect(90 + Margem_Esq, Incrementar + 129 + Margem_Topo, 505, 10));
                    //
                    textFormatter1.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 139 + Margem_Topo, 505, 10));
                    //
                    DataRow drConsumidor = bllContasReceber.Sel_Dados_Consumidor_Conta_Receber(SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString()).Rows[0];
                    //
                    if (Convert.ToByte(drConsumidor["pessoa"]) == 0)
                    {
                        cpf_cnpj = "CPF: ";
                    }
                    else
                    {
                        cpf_cnpj = "CNPJ: ";
                    }
                    textFormatter1.DrawString(cpf_cnpj + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 149 + Margem_Topo, 505, 10));
                    //
                    textFormatter1.DrawString("End.: " + drConsumidor["endereco"].ToString() + ", " + drConsumidor["numero"].ToString() + " - " + drConsumidor["bairro"].ToString() + " - " + drConsumidor["cidade"].ToString() + "/" + drConsumidor["uf"].ToString() + " - " + drConsumidor["cep"].ToString(), fonte2, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 159 + Margem_Topo, 505, 22));
                    //
                    textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 184 + Margem_Topo, 5, 595));
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
                    string arqmes;
                    if (Convert.ToDateTime(SelectedRow.Cells[4].Value).Month < 10)
                    {
                        arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Month;
                    }
                    else
                    {
                        arqmes = Convert.ToDateTime(SelectedRow.Cells[4].Value).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + arqmes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + arqmes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + Convert.ToDateTime(SelectedRow.Cells[4].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 4)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 14, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9);
                    var fonte3 = new XFont("Microsoft Sans Serif", 11, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //                   
                    //Linhas do datagrid
                    int Incrementar = 0;
                    //                    
                    int AumentoImagem = 0;
                    if (bllContasReceber._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem;
                        imagem = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem, 15 + Margem_Esq, 7 + Margem_Topo, 58, 69);
                        AumentoImagem = 30;
                    }
                    else
                    {
                        AumentoImagem = 0;
                    }
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    textFormatter1.DrawString(dr["nome"].ToString(), fonte3, XBrushes.Black, new XRect(AumentoImagem + 7 + Margem_Esq, 7 + Margem_Topo, 575, 28));
                    //
                    textFormatter1.DrawString(dr["fantasia"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 7 + Margem_Esq, 20 + Margem_Topo, 575, 10));
                    //
                    string cpf_cnpj;
                    string ie_rg;
                    if (Convert.ToByte(dr["pessoa"]) == 0)
                    {
                        cpf_cnpj = "CPF:";
                        ie_rg = "RG:";
                    }
                    else
                    {
                        cpf_cnpj = "CNPJ:";
                        ie_rg = "IE:";
                    }
                    //
                    //graphics.DrawRectangle(pen, XBrushes.White, AumentoImagem + 45 + Margem_Esq, 40 + Margem_Topo, 500, 33);
                    textFormatter1.DrawString(cpf_cnpj + " " + dr["cpf_cnpj"].ToString() + ", " + ie_rg + " " + dr["ie_rg"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 45 + Margem_Esq, 30 + Margem_Topo, 500, 11));
                    //
                    textFormatter1.DrawString("End.: " + dr["endereco"].ToString() + ", " + dr["numero"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 45 + Margem_Esq, 40 + Margem_Topo, 500, 33));
                    //
                    textFormatter1.DrawString("RECIBO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 77 + Margem_Topo, 575, 15));
                    //
                    Margem_Topo = Margem_Topo + 15;
                    //
                    string tipo_documento;
                    //
                    DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[1].Value.ToString() == "ENTRADA DE VENDA EM NOTA PROMISSORIA" & SelectedRow.Cells[2].Value.ToString() == "0")
                    {
                        tipo_documento = "referente ao pagamento de entrada da Venda nº " + SelectedRow.Cells[31].Value.ToString() + " em Nota Promissória";
                        //
                        textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                        //
                        DataRow drVenda = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[31].Value.ToString()).Rows[0];
                        //
                        textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(drVenda["valor_real"]).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                    }
                    else
                    {
                        if (SelectedRow.Cells[31].Value.ToString() == "0" & SelectedRow.Cells[2].Value.ToString() == "0")
                        {
                            tipo_documento = "referente ao pagamento da Conta a Receber nº " + SelectedRow.Cells[0].Value.ToString();
                        }
                        else
                        {
                            tipo_documento = "referente ao pagamento da Venda nº " + SelectedRow.Cells[31].Value.ToString() + " em Nota Promissória nº " + SelectedRow.Cells[2].Value.ToString();
                        }
                        //
                        textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                        //
                        textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                    }
                    //
                    textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 83 + Margem_Topo, 575, 10));
                    //
                    DataRow drConsumidor = bllContasReceber.Sel_Dados_Consumidor_Conta_Receber(SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString()).Rows[0];
                    textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[9].Value.ToString() + "  -  " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 94 + Margem_Topo, 570, 10));
                    //
                    string quantia = SelectedRow.Cells[24].Value.ToString();
                    //
                    Margem_Topo = Margem_Topo + 10;
                    //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 120 + Margem_Topo, 570, 22);
                    textFormatter2.DrawString("Recebi(emos) de " + SelectedRow.Cells[9].Value.ToString() + ", a quantia de " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), " + tipo_documento + ".", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 105 + Margem_Topo, 570, 22));
                    //
                    textFormatter2.DrawString("Pagamento                                         -                                                 Valor Pago (R$)               -               Data               -               Hora", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 127 + Margem_Topo, 575, 10));
                    //
                    textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 128 + Margem_Topo, 570, 10));
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "0")
                    {
                        dr = bllContasReceber.Sel_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 154 + Margem_Topo, 260, 10);
                        textFormatter2.DrawString(dr["tipo"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 138 + Margem_Topo, 260, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 265 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 380 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(dr["data_pagamento"].ToString().Remove(10), fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(475 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        Incrementar = Incrementar + 8;
                        //
                        textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 132 + Margem_Topo, 570, 10));
                        //
                        /*
                        if (SelectedRow.Cells[31].Value.ToString() != "0")
                        {
                            DataRow drVenda = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[31].Value.ToString()).Rows[0];
                            textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(drVenda["valor_real"]) - Convert.ToDecimal(SelectedRow.Cells[24].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                        }
                        else
                        {
                        */
                        textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[15].Value) - (Convert.ToDecimal(SelectedRow.Cells[24].Value) - Convert.ToDecimal(SelectedRow.Cells[25].Value))).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                        //}
                    }
                    else
                    {
                        for (int i = 0; i < bllContasReceber.Sel_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllContasReceber.Sel_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 154 + Margem_Topo, 260, 10);
                            textFormatter2.DrawString(dr["tipo"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 138 + Margem_Topo, 260, 10));
                            //graphics.DrawRectangle(pen, XBrushes.White, 265 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                            textFormatter1.DrawString(Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                            //graphics.DrawRectangle(pen, XBrushes.White, 380 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                            textFormatter1.DrawString(dr["data_pagamento"].ToString().Remove(10), fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                            //graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                            textFormatter1.DrawString(dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(475 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                            Incrementar = Incrementar + 8;
                        }
                        //
                        textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 132 + Margem_Topo, 570, 10));
                        //
                        textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[15].Value) - (Convert.ToDecimal(SelectedRow.Cells[24].Value) - Convert.ToDecimal(SelectedRow.Cells[25].Value))).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                    }
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                    //
                    textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 160 + Margem_Topo, 5, 595));
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
                    string mes;
                    if (DateTime.Now.Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(SelectedRow.Cells[30].Value).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 5)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = dr["nome"].ToString();
                    fantasia = dr["fantasia"].ToString();
                    cpf_cnpj = dr["cpf_cnpj"].ToString();
                    ie_rg = dr["ie_rg"].ToString();
                    endereco = dr["endereco"].ToString();
                    numero = dr["numero"].ToString();
                    bairro = dr["bairro"].ToString();
                    cidade = dr["cidade"].ToString();
                    uf = dr["uf"].ToString();
                    cep = dr["cep"].ToString();
                    pessoa = Convert.ToByte(dr["pessoa"]);
                    //
                    page.Width = 203;
                    page.Height = 842;
                    //
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                    var fonte3 = new XFont("Courrier New", 12, XFontStyle.Regular);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_80_Pdv(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_80_Pdv(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    //
                    if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                    }
                    //        
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 2 + Margem_Topo, 203, 16);     
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 8));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 8));
                    }
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                    }
                    //
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 109 + Margem_Topo, 198, 24));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Incrementar = Incrementar - 15;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 198, 24));
                    //Margem_Topo = Margem_Topo - 4;
                    textFormatter1.DrawString("RECIBO", fonte3, XBrushes.Black, new XRect(5 + Margem_Esq, 148 + Margem_Topo + Incrementar, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 157 + Margem_Topo + Incrementar, 198, 24));
                    //
                    string tipo_documento;
                    //
                    DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[1].Value.ToString() == "ENTRADA DE VENDA EM NOTA PROMISSORIA" & SelectedRow.Cells[2].Value.ToString() == "0")
                    {
                        tipo_documento = "referente ao pagamento de entrada da Venda nº " + SelectedRow.Cells[31].Value.ToString() + " em Nota Promissória";
                        //
                        textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 183 + Margem_Topo + Incrementar, 198, 8));
                        //
                        if (SelectedRow.Cells[31].Value.ToString() != "0")
                        {
                            DataRow drVenda = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[31].Value.ToString()).Rows[0];
                            //
                            textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(drVenda["valor_real"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 171 + Margem_Topo + Incrementar, 198, 12));
                        }
                        else
                        {
                            textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 171 + Margem_Topo + Incrementar, 198, 12));
                        }
                    }
                    else
                    {
                        if (SelectedRow.Cells[31].Value.ToString() == "0" & SelectedRow.Cells[2].Value.ToString() == "0")
                        {
                            tipo_documento = "referente ao pagamento da Conta a Receber nº " + SelectedRow.Cells[0].Value.ToString();
                        }
                        else
                        {
                            tipo_documento = "referente ao pagamento da Venda nº " + SelectedRow.Cells[31].Value.ToString() + " em Nota Promissória nº " + SelectedRow.Cells[2].Value.ToString();
                        }
                        //
                        textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 183 + Margem_Topo + Incrementar, 198, 8));
                        //
                        textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 171 + Margem_Topo + Incrementar, 198, 12));
                    }
                    //
                    textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + "   -   " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 191 + Margem_Topo + Incrementar, 198, 8));
                    //
                    Margem_Topo = Margem_Topo - 17;
                    //
                    DataRow drConsumidor = bllContasReceber.Sel_Dados_Consumidor_Conta_Receber(SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString()).Rows[0];
                    //
                    if (SelectedRow.Cells[9].Value.ToString().Length > 20)
                    {
                        if (!SelectedRow.Cells[9].Value.ToString().Substring(0, 20).Contains(" ") || (!SelectedRow.Cells[9].Value.ToString().Substring(20).Contains(" ") & SelectedRow.Cells[9].Value.ToString().Substring(20).Length > 10))
                        {
                            textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[8].Value.ToString() + "—" + SelectedRow.Cells[9].Value.ToString().Insert(20, Environment.NewLine) + Environment.NewLine + "CPF/CNPJ: " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo + Incrementar, 198, 24));
                        }
                        else
                        {
                            textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[8].Value.ToString() + "—" + SelectedRow.Cells[9].Value.ToString() + Environment.NewLine + "CPF/CNPJ: " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo + Incrementar, 198, 24));
                        }
                        Margem_Topo = Margem_Topo + 8;
                    }
                    else
                    {
                        textFormatter2.DrawString("Consumidor: " + SelectedRow.Cells[8].Value.ToString() + "—" + SelectedRow.Cells[9].Value.ToString() + Environment.NewLine + "CPF/CNPJ: " + drConsumidor["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo + Incrementar, 198, 24));
                    }
                    //                    
                    string quantia = SelectedRow.Cells[24].Value.ToString();
                    //
                    Margem_Topo = Margem_Topo + 14;
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 225 + Margem_Topo, 198, 64);
                    textFormatter2.DrawString("Recebi(emos) de " + SelectedRow.Cells[9].Value.ToString() + ", a quantia de R$ " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), " + tipo_documento + ".", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo + Incrementar, 198, 64));
                    //
                    textFormatter2.DrawString(" Pagamento       -        Valor Pago (R$)   -   Data   -   Hora", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 289 + Margem_Topo + Incrementar, 198, 8));
                    //
                    textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 298 + Margem_Topo, 198, 16));
                    //
                    Margem_Topo = Margem_Topo + 2;
                    if (SelectedRow.Cells[2].Value.ToString() == "0")
                    {
                        dr = bllContasReceber.Sel_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        textFormatter2.DrawString(dr["tipo"].ToString() + "   -   " + Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")) + "  -   " + dr["data_pagamento"].ToString().Remove(10) + "  -  " + dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 305 + Margem_Topo, 198, 8));
                        //
                        Incrementar = Incrementar + 8;
                        if (SelectedRow.Cells[31].Value.ToString() != "0")
                        {
                            DataRow drVenda = bllVenda.Sel_Venda_Codigo(SelectedRow.Cells[31].Value.ToString()).Rows[0];
                            textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(drVenda["valor_real"]) - Convert.ToDecimal(SelectedRow.Cells[24].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 308 + Margem_Topo, 198, 8));
                        }
                        else
                        {
                            textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[15].Value) - Convert.ToDecimal(SelectedRow.Cells[24].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 308 + Margem_Topo, 198, 8));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < bllContasReceber.Sel_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                        {
                            dr = bllContasReceber.Sel_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                            textFormatter2.DrawString(dr["tipo"].ToString() + "   -   " + Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")) + "  -   " + dr["data_pagamento"].ToString().Remove(10) + "  -  " + dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 305 + Margem_Topo, 198, 8));
                            //
                            Incrementar = Incrementar + 8;
                        }
                        textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[15].Value) - (Convert.ToDecimal(SelectedRow.Cells[24].Value) - Convert.ToDecimal(SelectedRow.Cells[25].Value))).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 308 + Margem_Topo, 198, 8));
                    }
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 308 + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 300 + Margem_Topo, 198, 16));
                    //
                    //
                    string mes;
                    if (DateTime.Now.Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(SelectedRow.Cells[30].Value).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[30].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, consumidor, nº da promissória, palavra-chave, todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Baixar Registro: Clique para baixar um registro de conta a receber.\n\n2 - Desfazer Baixa: Clique para desfazer uma baixa feita anteriormente em um registro.\n\n3 - Relatório Resumido: Clique para imprimir um relatório simples em PDF.\n\n4 - 2ª Via da Nota Promissória: Clique para imprimir uma segunda via da nota promissória.\n\n5 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n6 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).\n\n7 - Consultar Pagamentos: Clique para visualizar os pagamentos do registro selecionado.\n\n8 - 2ª Via do Recibo: Clique para gerar a segunda via do recibo de comprovante de pagamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtContaReceber_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 33 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 33 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
            //
            if (e.ColumnIndex == 32 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 32 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 34 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 26 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 16 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 5 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 2 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 31 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 37 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 38 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void rbtnNPromissoria_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNPromissoria_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNPromissoria_CheckedChanged(object sender, EventArgs e)
        {
            lblSubgrupo.Enabled = false;
            btnSelecionarData.Enabled = false;
            lblDataCadastro.Enabled = false;
            mtxtpDataCad.Enabled = false;
            mtxtpDataCad1.Enabled = false;
            lblAte.Enabled = false;
            txtpDescricao.Visible = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData2.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblGrupo.Enabled = false;
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            lblSituacao.Enabled = false;
            cbbpSituacao.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpSituacao.Text = "AMBAS";
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(495, 21);
            lblPesquisar.Text = "Digite o nº da nota promissória:";
            txtpCodigo.Text = null;
            btnLimpar.Enabled = false;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            lblSubgrupo.Enabled = false;
            lblDataCadastro.Enabled = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataCad.Enabled = false;
            mtxtpDataCad1.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            lblGrupo.Enabled = false;
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            cbbpSituacao.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpSituacao.Text = "AMBAS";
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            lblAte.Visible = false;

            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(540, 21);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpPalavraChave.Text = null;
            btnLimpar.Enabled = false;
            txtpPalavraChave.Select();
        }

        private void btnConsultarPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnBaixaRegistro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnBaixaRegistro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorPago_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorPago_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorAPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorAPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recebido (R$): " + lblValorRecebido.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorAPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a Receber (R$): " + lblValorAPagar.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnBaixaRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                {
                    MessageBox.Show("Não é possível baixar este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtContaReceber.Select();
                }
                else if (bllContasReceber.Sel_Conta_Receber_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtContaReceber.Select();
                }
                else
                {
                    pPanel.Enabled = false;
                    using (FrmRelBaixaConta Conta = new FrmRelBaixaConta(_Usuario, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[18].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")), _Cod_PDV_Computador, SelectedRow.Cells[2].Value.ToString(), 0, Convert.ToByte(SelectedRow.Cells[36].Value), SelectedRow.Cells[8].Value.ToString()))
                    {
                        if (Conta.ShowDialog() == DialogResult.OK)
                        {
                            if (bllContasReceber.Sel_Conta_Codigo_Receber(SelectedRow.Cells[0].Value.ToString(), "") == null)
                            {
                                dtContaReceber.DataSource = null;
                            }
                            else
                            {
                                if (SelectedRow.Cells[6].Value.ToString() == "NOTA PROMISSORIA")
                                {
                                    dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Codigo_Receber(SelectedRow.Cells[0].Value.ToString(), "");
                                    DialogResult = MessageBox.Show("Deseja imprimir o Recibo de Pagamento da Conta a Receber?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        using (FrmInfImpressao Imp = new FrmInfImpressao(0))
                                        {
                                            if (Imp.ShowDialog() == DialogResult.OK)
                                            {
                                                pgbProgresso.Visible = true;
                                                lblProgresso.Visible = true;
                                                if (bllContasReceber._Tipo_Impressao == "PDF A4")
                                                {
                                                    _Trabalho = 4;
                                                }
                                                else if (bllContasReceber._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                                                {
                                                    _Trabalho = 5;
                                                }
                                                bckwIndeterminado.RunWorkerAsync();
                                                pgbProgresso.MarqueeAnimationSpeed = 2;
                                                this.Cursor = Cursors.WaitCursor;
                                                grbBox1.Enabled = false;
                                                dtContaReceber.Enabled = false;
                                                dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                                                grbBox1.Enabled = false;
                                                grbBox2.Enabled = false;
                                                lblDataCadastro.Enabled = false;
                                                lblDataEmissao.Enabled = false;
                                                lblDataVencimento.Enabled = false;
                                                mtxtpDataCad.Enabled = false;
                                                mtxtpDataCad1.Enabled = false;
                                                mtxtpDataEmi.Enabled = false;
                                                mtxtpDataEmi1.Enabled = false;
                                                mtxtpDataVenc.Enabled = false;
                                                mtxtpDataVenc1.Enabled = false;
                                                btnSelecionarData1.Enabled = false;
                                                btnSelecionarData.Enabled = false;
                                                btnSelecionarData2.Enabled = false;
                                                lblSituacao.Enabled = false;
                                                lblGrupo.Enabled = false;
                                                cbbpGrupo.Enabled = false;
                                                btnProcurarGrupo.Enabled = false;
                                                cbbpSituacao.Enabled = false;
                                                btnPesquisar.Enabled = false;
                                                picbInterrogacao1.Enabled = false;
                                                picbInterrogacao3.Enabled = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                                else
                                {
                                    dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Codigo_Receber(SelectedRow.Cells[0].Value.ToString(), "");
                                    this.DialogResult = DialogResult.None;
                                }
                                //
                                dtContaReceber.Select();
                            }
                        }
                    }
                    pPanel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnBaixaRegistro.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnBaixaRegistro.");
                }
            }
        }

        private void btnConsultarPagamento_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];

                if (Convert.ToDecimal(SelectedRow.Cells[24].Value) <= 0)
                {
                    MessageBox.Show("Ainda não existe(m) pagamento(s) para esta Conta a Receber.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtContaReceber.Select();
                }
                else
                {
                    using (FrmConsultarPagamento Pag = new FrmConsultarPagamento(SelectedRow.Cells[0].Value.ToString(), 0))
                    {
                        if (Pag.ShowDialog() == DialogResult.Abort)
                        {
                            dtContaReceber.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultaPagamento.");
                }
            }
            pPanel.Enabled = true;
        }

        private void btnReciboRegistro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnReciboRegistro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnReciboRegistro_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(0))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllContasReceber._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 4;
                    }
                    else if (bllContasReceber._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                    {
                        _Trabalho = 5;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtContaReceber.Enabled = false;
                    dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    lblDataCadastro.Enabled = false;
                    lblDataEmissao.Enabled = false;
                    lblDataVencimento.Enabled = false;
                    mtxtpDataCad.Enabled = false;
                    mtxtpDataCad1.Enabled = false;
                    mtxtpDataEmi.Enabled = false;
                    mtxtpDataEmi1.Enabled = false;
                    mtxtpDataVenc.Enabled = false;
                    mtxtpDataVenc1.Enabled = false;
                    btnSelecionarData1.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    btnSelecionarData2.Enabled = false;
                    lblSituacao.Enabled = false;
                    lblGrupo.Enabled = false;
                    cbbpGrupo.Enabled = false;
                    btnProcurarGrupo.Enabled = false;
                    cbbpSituacao.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void DesfazerBaixa()
        {
            DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
            //
            if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
            {
                MessageBox.Show("Não é possível desfazer este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                dtContaReceber.Select();
            }
            else if (bllContasReceber.Sel_Conta_Receber_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
            {
                MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtContaReceber.Select();
            }
            else
            {
                DialogResult = MessageBox.Show("Deseja desfazer a baixa do registro selecionado? Todos os dados de pagamento serão excluídos, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (SelectedRow.Cells[1].Value.ToString() == "ENTRADA DE VENDA EM NOTA PROMISSORIA" & SelectedRow.Cells[6].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível desfazer a baixa de uma entrada de uma venda em nota promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        bllContasReceber.Desfazer_refazer_Baixa_Conta_Receber(SelectedRow.Cells[0].Value.ToString());
                        //
                        bllContasReceber.Excluir_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString());
                        //
                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "SAIDA", "CANCELAMENTO DE RECEBIMENTO DE CONTA A RECEBER", (Convert.ToDecimal(SelectedRow.Cells[24].Value) - Convert.ToDecimal(SelectedRow.Cells[25].Value)).ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        bllRegistroAtividades.Salvar("DESFEZ BAIXA DA CONTA A RECEBER.", "CONTAS A RECEBER", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        if (bllContasReceber.Sel_Conta_Codigo_Receber(SelectedRow.Cells[0].Value.ToString(), "") == null)
                        {
                            dtContaReceber.DataSource = null;
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Codigo_Receber(SelectedRow.Cells[0].Value.ToString(), "");
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Permitir_Desfazer_Baixa_Usuario(_Usuario) == true)
                {
                    DesfazerBaixa();
                }
                else
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Desfazer_Baixa"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllContasReceber._Desfazer_Baixa == 1)
                            {
                                DesfazerBaixa();
                            }
                            else if (bllContasReceber._Desfazer_Baixa == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para Desfazer Baixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDesfazer.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDesfazer.");
                }
            }

        }

        private void btnDesfazer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDesfazer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSegundaViaProm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSegundaViaProm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSegundaViaProm_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(1))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllContasReceber._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 3;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtContaReceber.Enabled = false;
                    dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    lblDataCadastro.Enabled = false;
                    lblDataEmissao.Enabled = false;
                    lblDataVencimento.Enabled = false;
                    mtxtpDataCad.Enabled = false;
                    mtxtpDataCad1.Enabled = false;
                    mtxtpDataEmi.Enabled = false;
                    mtxtpDataEmi1.Enabled = false;
                    mtxtpDataVenc.Enabled = false;
                    mtxtpDataVenc1.Enabled = false;
                    btnSelecionarData1.Enabled = false;
                    btnSelecionarData.Enabled = false;
                    btnSelecionarData2.Enabled = false;
                    lblSituacao.Enabled = false;
                    lblGrupo.Enabled = false;
                    cbbpGrupo.Enabled = false;
                    btnProcurarGrupo.Enabled = false;
                    cbbpSituacao.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void rbtnVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnVenda_CheckedChanged(object sender, EventArgs e)
        {
            lblSubgrupo.Enabled = false;
            lblDataCadastro.Enabled = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataCad.Enabled = false;
            mtxtpDataCad1.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            lblGrupo.Enabled = false;
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            cbbpSituacao.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpSituacao.Text = "AMBAS";
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            btnpProcurar.Visible = false;
            lblAte.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(526, 21);
            lblPesquisar.Text = "Digite o código da venda:";
            txtpCodigo.Text = null;
            btnLimpar.Enabled = false;
            txtpCodigo.Select();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mtxtpDataEmi.Text = null;
            mtxtpDataEmi1.Text = null;
            mtxtpDataVenc.Text = null;
            mtxtpDataVenc1.Text = null;
            mtxtpDataCad.Text = null;
            mtxtpDataCad1.Text = null;
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Text = null;
            cbbpSubGrupo.Text = null;
            cbbpSituacao.Text = null;

        }

        private void lblValorRecebido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lblValorAPagar.Select();
            }
        }

        private void lblValorAPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lblValorTotal.Select();
            }
        }

        private void lblValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (grbBox2.Enabled == false)
                {
                    btnSair.Select();
                }
                else
                {
                    btnTodasContas.Select();
                }
            }
        }

        private void chkbDestOsPend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbDestOsPend.Checked == true)
            {
                if (dtContaReceber.DataSource != null)
                {
                    for (int i = 0; i < dtContaReceber.Rows.Count; i++)
                    {
                        if (dtContaReceber.Rows[i].Cells[23].Value.ToString() == "PENDENTE")
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
            else
            {
                if (dtContaReceber.DataSource != null)
                {
                    for (int i = 0; i < dtContaReceber.Rows.Count; i++)
                    {
                        dtContaReceber.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dtContaReceber_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            chkbDestOsPend_CheckedChanged(sender, e);
        }
    }
}

