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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelClieCons : Form
    {
        public FrmRelClieCons(string cod_pdv_computador, string usuario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        bool _Contem_Imagem = false;
        private byte _Trabalho;
        private string _Cod_PDV_Computador;
        private string _Usuario;

        private void FrmRelCliente_Load(object sender, EventArgs e)
        {
            try
            {
                bllClieCons._FrmRelCliente_Ativo = true;

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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelCliente iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelCliente iniciado.");
                }
                rbtnNome.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelCliente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelCliente.");
                }
                this.Close();
            }
        }

        private void Limpar_OutrosFiltros()
        {
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            cbbUF.Text = null;
            cbbCidade.Text = null;
            cbbpTipo.Text = null;
            mtxtpCelular.Text = null;
            mtxtpTelefone.Text = null;
            txtpEmail.Text = null;
            txtNomeAvalista.Text = null;
            mtxtCPFAvalista.Text = null;
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Text = null;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNome_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNome_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmRelCliente_KeyUp(object sender, KeyEventArgs e)
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

        private void cbbCidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUF_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUF_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCidade_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCidade_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
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

                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData1.Text != "")
                    {
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData.Text) > Convert.ToDateTime(mtxtpData1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtpData.Text = null;
                        }
                    }
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

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
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

                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData1.Text) < Convert.ToDateTime(mtxtpData.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtpData1.Text = null;
                        }
                    }
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUF.Select();
            }
        }

        private void cbbUF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCidade.Select();
            }
        }

        private void cbbCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpTipo.Select();
            }
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            if (txtpNome.Text.Contains("'") || txtpNome.Text.Contains(";") || txtpNome.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpNome.Text = null;
                txtpNome.Select();
            }
            txtpNome.BackColor = Color.White;
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpRG_Enter(object sender, EventArgs e)
        {
            txtpRG.BackColor = Color.LightBlue;
        }

        private void txtpRG_Leave(object sender, EventArgs e)
        {
            if (txtpRG.Text.Contains("'") || txtpRG.Text.Contains(";") || txtpRG.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpRG.Text = null;
                txtpRG.Select();
            }
            txtpRG.BackColor = Color.White;
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

        private void mtxtpCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.LightBlue;
        }

        private void mtxtpCNPJ_Leave(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.White;
        }

        private void mtxtpCNPJ_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mtxtpCPF_Enter(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.LightBlue;
        }

        private void mtxtpCPF_Leave(object sender, EventArgs e)
        {
            mtxtpCPF.BackColor = Color.White;
        }

        private void mtxtpCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
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
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpCelular_Enter(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.LightBlue;
        }

        private void mtxtpCelular_Leave(object sender, EventArgs e)
        {
            mtxtpCelular.BackColor = Color.White;
        }

        private void mtxtpCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpGrupo.Select();
            }
        }

        private void mtxtpTelefone_Enter(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.LightBlue;
        }

        private void mtxtpTelefone_Leave(object sender, EventArgs e)
        {
            mtxtpTelefone.BackColor = Color.White;
        }

        private void mtxtpTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpCelular.Select();
            }
        }

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Limpar_OutrosFiltros();
                cbbpGrupo.Enabled = true;
                btnSelecionarData.Enabled = true;
                btnProcurarGrupo.Enabled = true;
                lblDatas.Enabled = true;
                lblGrupos.Enabled = true;
                lblCidade.Enabled = true;
                mtxtpData.Enabled = true;
                mtxtpData1.Enabled = true;
                lblAte.Enabled = true;
                cbbUF.Enabled = true;
                lblEndereco.Enabled = true;
                cbbCidade.Enabled = true;
                lblTipoPessoa.Enabled = true;
                cbbpTipo.Enabled = true;
                lblTelefone.Enabled = true;
                lblCelular.Enabled = true;
                lblEmail.Enabled = true;
                lblNomeAvalista.Enabled = true;
                lblCPFAvalista.Enabled = true;
                mtxtpTelefone.Enabled = true;
                mtxtpCelular.Enabled = true;
                txtpEmail.Enabled = true;
                txtNomeAvalista.Enabled = true;
                mtxtCPFAvalista.Enabled = true;
                mtxtpCNPJ.Visible = false;
                txtpPalavraChave.Visible = false;
                txtpRG.Visible = false;
                txtpNome.Visible = true;
                mtxtpCPF.Visible = false;
                txtpCodigo.Visible = false;
                lblPesquisar.Text = "Digite o nome/razão social:";
                lblPesquisar.Location = new Point(359, 19);
                txtpNome.MaxLength = 60;
                txtpNome.Text = null;
                txtpNome.Select();
                //
                cbbpGrupo.Items.Clear();
                if (bllClieCons.Sel_Grupo_Clie() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnNome.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnNome.");
                }
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
            }
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblDatas.Enabled = false;
            lblGrupos.Enabled = false;
            lblSubgrupos.Enabled = false;
            lblCidade.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            cbbUF.Enabled = false;
            lblEndereco.Enabled = false;
            cbbCidade.Enabled = false;
            lblTipoPessoa.Enabled = false;
            cbbpTipo.Enabled = false;
            lblTelefone.Enabled = false;
            lblCelular.Enabled = false;
            lblEmail.Enabled = false;
            lblNomeAvalista.Enabled = false;
            lblCPFAvalista.Enabled = false;
            mtxtpTelefone.Enabled = false;
            mtxtpCelular.Enabled = false;
            txtpEmail.Enabled = false;
            txtNomeAvalista.Enabled = false;
            mtxtCPFAvalista.Enabled = false;
            mtxtpCNPJ.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(634, 19);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblDatas.Enabled = false;
            lblGrupos.Enabled = false;
            lblSubgrupos.Enabled = false;
            lblCidade.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            cbbUF.Enabled = false;
            lblEndereco.Enabled = false;
            cbbCidade.Enabled = false;
            lblTipoPessoa.Enabled = false;
            cbbpTipo.Enabled = false;
            lblTelefone.Enabled = false;
            lblCelular.Enabled = false;
            lblEmail.Enabled = false;
            lblNomeAvalista.Enabled = false;
            lblCPFAvalista.Enabled = false;
            mtxtpTelefone.Enabled = false;
            mtxtpCelular.Enabled = false;
            txtpEmail.Enabled = false;
            txtNomeAvalista.Enabled = false;
            mtxtCPFAvalista.Enabled = false;
            mtxtpCNPJ.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o cpf:";
            lblPesquisar.Location = new Point(637, 19);
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
        }

        private void rbtnCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            btnSelecionarData.Enabled = false;
            lblDatas.Enabled = false;
            lblGrupos.Enabled = false;
            lblSubgrupos.Enabled = false;
            lblCidade.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            cbbUF.Enabled = false;
            lblEndereco.Enabled = false;
            cbbCidade.Enabled = false;
            lblTipoPessoa.Enabled = false;
            cbbpTipo.Enabled = false;
            lblTelefone.Enabled = false;
            lblCelular.Enabled = false;
            lblEmail.Enabled = false;
            lblNomeAvalista.Enabled = false;
            lblCPFAvalista.Enabled = false;
            mtxtpTelefone.Enabled = false;
            mtxtpCelular.Enabled = false;
            txtpEmail.Enabled = false;
            txtNomeAvalista.Enabled = false;
            mtxtCPFAvalista.Enabled = false;
            mtxtpCNPJ.Visible = true;
            txtpPalavraChave.Visible = false;
            txtpRG.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o cnpj:";
            lblPesquisar.Location = new Point(606, 19);
            mtxtpCNPJ.Text = null;
            mtxtpCNPJ.Select();
        }

        private void rbtnRG_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblDatas.Enabled = false;
            mtxtpData.Enabled = false;
            lblGrupos.Enabled = false;
            lblSubgrupos.Enabled = false;
            lblCidade.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            cbbUF.Enabled = false;
            lblEndereco.Enabled = false;
            cbbCidade.Enabled = false;
            lblTipoPessoa.Enabled = false;
            cbbpTipo.Enabled = false;
            lblTelefone.Enabled = false;
            lblCelular.Enabled = false;
            lblEmail.Enabled = false;
            lblNomeAvalista.Enabled = false;
            lblCPFAvalista.Enabled = false;
            mtxtpTelefone.Enabled = false;
            mtxtpCelular.Enabled = false;
            txtpEmail.Enabled = false;
            txtNomeAvalista.Enabled = false;
            mtxtCPFAvalista.Enabled = false;
            mtxtpCNPJ.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = true;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o rg:";
            lblPesquisar.Location = new Point(619, 19);
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnIE_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpGrupo.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnSelecionarData.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblDatas.Enabled = false;
            lblGrupos.Enabled = false;
            lblSubgrupos.Enabled = false;
            lblCidade.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            cbbUF.Enabled = false;
            lblEndereco.Enabled = false;
            cbbCidade.Enabled = false;
            lblTipoPessoa.Enabled = false;
            cbbpTipo.Enabled = false;
            lblTelefone.Enabled = false;
            lblCelular.Enabled = false;
            lblEmail.Enabled = false;
            lblNomeAvalista.Enabled = false;
            lblCPFAvalista.Enabled = false;
            mtxtpTelefone.Enabled = false;
            mtxtpCelular.Enabled = false;
            txtpEmail.Enabled = false;
            txtNomeAvalista.Enabled = false;
            mtxtCPFAvalista.Enabled = false;
            mtxtpCNPJ.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = true;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite a inscrição estadual:";
            lblPesquisar.Location = new Point(527, 19);
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnCPFResponsavel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Limpar_OutrosFiltros();
                cbbpGrupo.Enabled = true;
                btnSelecionarData.Enabled = true;
                btnProcurarGrupo.Enabled = true;
                lblDatas.Enabled = true;
                lblGrupos.Enabled = true;
                lblCidade.Enabled = true;
                mtxtpData.Enabled = true;
                mtxtpData1.Enabled = true;
                lblAte.Enabled = true;
                cbbUF.Enabled = true;
                lblEndereco.Enabled = true;
                cbbCidade.Enabled = true;
                lblTipoPessoa.Enabled = true;
                cbbpTipo.Enabled = true;
                lblTelefone.Enabled = true;
                lblCelular.Enabled = true;
                lblEmail.Enabled = true;
                lblNomeAvalista.Enabled = true;
                lblCPFAvalista.Enabled = true;
                mtxtpTelefone.Enabled = true;
                mtxtpCelular.Enabled = true;
                txtpEmail.Enabled = true;
                txtNomeAvalista.Enabled = true;
                mtxtCPFAvalista.Enabled = true;
                mtxtpCNPJ.Visible = false;
                txtpPalavraChave.Visible = false;
                txtpRG.Visible = false;
                txtpNome.Visible = false;
                mtxtpCPF.Visible = true;
                txtpCodigo.Visible = false;
                lblPesquisar.Text = "Digite o cpf do responsável:";
                lblPesquisar.Location = new Point(547, 19);
                mtxtpCPF.Text = null;
                mtxtpCPF.Select();
                //
                cbbpGrupo.Items.Clear();
                if (bllClieCons.Sel_Grupo_Clie() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnCPFResponsavel.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnCPFResponsavel.");
                }
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
            }
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            cbbpGrupo.Enabled = false;
            btnSelecionarData.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblDatas.Enabled = false;
            mtxtpData.Enabled = false;
            lblGrupos.Enabled = false;
            lblSubgrupos.Enabled = false;
            lblCidade.Enabled = false;
            mtxtpData1.Enabled = false;
            lblAte.Enabled = false;
            cbbUF.Enabled = false;
            lblEndereco.Enabled = false;
            cbbCidade.Enabled = false;
            lblTipoPessoa.Enabled = false;
            cbbpTipo.Enabled = false;
            lblTelefone.Enabled = false;
            lblCelular.Enabled = false;
            lblEmail.Enabled = false;
            lblNomeAvalista.Enabled = false;
            lblCPFAvalista.Enabled = false;
            mtxtpTelefone.Enabled = false;
            mtxtpCelular.Enabled = false;
            txtpEmail.Enabled = false;
            txtNomeAvalista.Enabled = false;
            mtxtCPFAvalista.Enabled = false;
            mtxtpCNPJ.Visible = false;
            txtpPalavraChave.Visible = true;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(591, 19);
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Limpar_OutrosFiltros();
                cbbpGrupo.Enabled = true;
                btnSelecionarData.Enabled = true;
                btnProcurarGrupo.Enabled = true;
                lblDatas.Enabled = true;
                mtxtpData.Enabled = true;
                lblGrupos.Enabled = true;
                lblCidade.Enabled = true;
                mtxtpData1.Enabled = true;
                lblAte.Enabled = true;
                cbbUF.Enabled = true;
                lblEndereco.Enabled = true;
                cbbCidade.Enabled = true;
                lblTipoPessoa.Enabled = true;
                cbbpTipo.Enabled = true;
                lblTelefone.Enabled = true;
                lblCelular.Enabled = true;
                lblEmail.Enabled = true;
                lblNomeAvalista.Enabled = true;
                lblCPFAvalista.Enabled = true;
                mtxtpTelefone.Enabled = true;
                mtxtpCelular.Enabled = true;
                txtpEmail.Enabled = true;
                txtNomeAvalista.Enabled = true;
                mtxtCPFAvalista.Enabled = true;
                Limpar_OutrosFiltros();
                mtxtpCNPJ.Visible = false;
                txtpPalavraChave.Visible = false;
                txtpRG.Visible = false;
                txtpNome.Visible = false;
                mtxtpCPF.Visible = false;
                txtpCodigo.Visible = false;
                lblPesquisar.Text = "Exibir todo o cadastro:";
                lblPesquisar.Location = new Point(680, 19);
                btnPesquisar.Select();
                //
                cbbpGrupo.Items.Clear();
                if (bllClieCons.Sel_Grupo_Clie() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
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
            }
        }

        private void dtClie_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
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
                dtClie.Columns[19].HeaderText = "Crédito (R$)";
                dtClie.Columns[20].HeaderText = "Usado (R$)";
                dtClie.Columns[21].HeaderText = "Crédito da Loja (R$)";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtClie.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtClie.");
                }
                dtClie.DataSource = null;
            }
        }

        private void dtClie_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
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

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmRelCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelClieCons foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelClieCons foi finalizado.");
                }
                bllClieCons._FrmRelCliente_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelClieCons.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelClieCons.");
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodos.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                        return;
                    }
                    else
                    {

                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllClieCons.Sel_Clie_Data_UF_Cidade_Pessoa_Todos(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, cbbpTipo.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim(), mtxtCPFAvalista.Text, txtNomeAvalista.Text, cbbpGrupo.Text, cbbpSubGrupo.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_Data_UF_Cidade_Pessoa_Todos(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, cbbpTipo.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim(), mtxtCPFAvalista.Text, txtNomeAvalista.Text, cbbpGrupo.Text, cbbpSubGrupo.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnNome.Checked == true)
                {
                    if (txtpNome.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtpData.Select();
                            return;
                        }
                        else
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllClieCons.Sel_Clie_Data_UF_Cidade_Pessoa_Nome(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, cbbpTipo.Text, txtpNome.Text.Trim(), mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim(), txtNomeAvalista.Text.Trim(), mtxtCPFAvalista.Text, cbbpGrupo.Text, cbbpSubGrupo.Text) == null)
                            {
                                dtClie.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtClie.DataSource = bllClieCons.Sel_Clie_Data_UF_Cidade_Pessoa_Nome(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, cbbpTipo.Text, txtpNome.Text.Trim(), mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim(), txtNomeAvalista.Text.Trim(), mtxtCPFAvalista.Text, cbbpGrupo.Text, cbbpSubGrupo.Text);
                                dtClie.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllClieCons.Sel_Cliente_Codigo(txtpCodigo.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Cliente_Codigo(txtpCodigo.Text);
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

                        if (bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCPF.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCPF.Text);
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

                        if (bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCNPJ.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_CPFCNPJ(mtxtpCNPJ.Text);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_IERG(txtpRG.Text, 0) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_IERG(txtpRG.Text, 0);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnIE.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_IERG(txtpRG.Text, 1) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_IERG(txtpRG.Text, 1);
                            dtClie.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllClieCons.Sel_Clie_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtClie.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtClie.DataSource = bllClieCons.Sel_Clie_Palavra_Chave(txtpPalavraChave.Text);
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

                        mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Cadastro ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mtxtpData.Select();
                            return;
                        }
                        else
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllClieCons.Sel_Clie_Data_UF_Cidade_Pessoa_CPF_Resp(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, cbbpTipo.Text, mtxtpCPF.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim(), txtNomeAvalista.Text.Trim(), mtxtCPFAvalista.Text, cbbpGrupo.Text, cbbpSubGrupo.Text) == null)
                            {
                                dtClie.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtClie.DataSource = bllClieCons.Sel_Clie_Data_UF_Cidade_Pessoa_CPF_Resp(mtxtpData.Text, mtxtpData1.Text, cbbUF.Text, cbbCidade.Text, cbbpTipo.Text, mtxtpCPF.Text, mtxtpTelefone.Text, mtxtpCelular.Text, txtpEmail.Text.Trim(), txtNomeAvalista.Text.Trim(), mtxtCPFAvalista.Text, cbbpGrupo.Text, cbbpSubGrupo.Text);
                                dtClie.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtClie.DataSource = null;
                rbtnNome.Checked = true;
            }
        }

        private void dtClie_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtClie.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtClie.DefaultCellStyle.SelectionForeColor = Color.Black;

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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtClie.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtClie.");
                }
                dtClie.DataSource = null;
                rbtnNome.Checked = true;
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

        private void dtClie_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtClie.DataSource == null)
            {
                pcibImagem.Enabled = false;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = false;
                pcibAjudaFoto.Enabled = false;
                dtClie.Enabled = false;
                _Contem_Imagem = false;
                grbBox2.Enabled = false;
            }
            else
            {
                pcibImagem.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                dtClie.Enabled = true;
                grbBox2.Enabled = true;
                //
                for (int i = 0; i < dtClie.Rows.Count; i++)
                {
                    if (bllGrupo.Sel_Grupo_Cor_Destaque(dtClie.Rows[i].Cells[48].Value.ToString()) != null)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque(dtClie.Rows[i].Cells[48].Value.ToString()).Rows[0];
                        //
                        if (dr["cor_destaque"].ToString() == "")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (dr["cor_destaque"].ToString() == "1")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (dr["cor_destaque"].ToString() == "2")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (dr["cor_destaque"].ToString() == "3")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (dr["cor_destaque"].ToString() == "4")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (dr["cor_destaque"].ToString() == "5")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (dr["cor_destaque"].ToString() == "6")
                        {
                            dtClie.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples resumido em PDF.\n\n2 - Relatório Completo em PDF: Clique para imprimir um relatório completo do(s) registro(s) em PDF.\n\n3 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n4 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pcibImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
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
                        MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Sem imagem para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cbbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbUF.SelectedIndex == 0)
                {
                    cbbCidade.Items.Clear();
                }
                else if (cbbUF.SelectedIndex == 1)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt", System.Text.Encoding.UTF8))//Acre
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 2)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 3)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 4)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 5)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 6)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 7)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 8)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 9)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 10)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 11)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 12)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 13)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 14)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Para\Para.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 15)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 16)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 17)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 18)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 19)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 20)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 21)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 22)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 23)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 24)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 25)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 26)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
                else if (cbbUF.SelectedIndex == 27)
                {
                    cbbCidade.Items.Clear();
                    cbbCidade.Items.Add("");
                    using (StreamReader Sr = new StreamReader(@"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt", System.Text.Encoding.UTF8))
                    {
                        while (!Sr.EndOfStream)
                        {
                            string[] items = Sr.ReadLine().Split('—');
                            cbbCidade.Items.Add(items[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do cbbUF");
                }
                cbbCidade.Text = null;
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
                    if (bllClieCons._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Clientes", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO      NOME/RAZÃO SOCIAL     ENDEREÇO    CPF/CNPJ   TELEFONE    CELULAR    E-MAIL", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtClie.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtClie.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtClie.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtClie.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(188 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString() + ", " + SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, 10));
                                //
                                if (Convert.ToByte(SelectedRow.Cells[47].Value) == 0)
                                {
                                    textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("CNPJ:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(36 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(188 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString() + ", " + SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, 10));
                                //
                                if (Convert.ToByte(SelectedRow.Cells[47].Value) == 0)
                                {
                                    textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("CNPJ:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(36 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            //
                            if (linha == (pagina - 1) & dtClie.Rows.Count > 16)
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
                                textFormatter1.DrawString("Relatório de Clientes", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Clientes", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtClie.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(188 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString() + ", " + SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, 10));
                                //
                                if (Convert.ToByte(SelectedRow.Cells[47].Value) == 0)
                                {
                                    textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("CNPJ:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(36 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando   
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(188 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Endereço:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[11].Value.ToString() + ", " + SelectedRow.Cells[12].Value.ToString() + ", " + SelectedRow.Cells[13].Value.ToString() + ", " + SelectedRow.Cells[14].Value.ToString() + ", " + SelectedRow.Cells[15].Value.ToString() + ", " + SelectedRow.Cells[16].Value.ToString() + ", " + SelectedRow.Cells[17].Value.ToString(), fonte4, XBrushes.Black, new XRect(52 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, 10));
                                //
                                if (Convert.ToByte(SelectedRow.Cells[47].Value) == 0)
                                {
                                    textFormatter2.DrawString("CPF:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(31 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                }
                                else
                                {
                                    textFormatter2.DrawString("CNPJ:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(36 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Telefone:", fonte2, XBrushes.Black, new XRect(125 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(168 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Celular:", fonte2, XBrushes.Black, new XRect(250 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte4, XBrushes.Black, new XRect(285 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("E-mail:", fonte2, XBrushes.Black, new XRect(375 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(407 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                    }
                }
            }
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
                    int TotalPaginas = dtClie.Rows.Count;
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
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllClieCons._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Clientes", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 125 + Margem_Topo, page.Width, page.Height));
                    //
                    textFormatter1.DrawString("Página(s): 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(3 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    //
                    Margem_Topo = Convert.ToInt16(Margem_Topo - 5);
                    //
                    for (int x = 0; x < dtClie.Rows.Count; x++)
                    {
                        DataGridViewRow SelectedRow = dtClie.Rows[x];
                        //
                        if (PrimeiraPagina == true)
                        {
                            //Código
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo, 75, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo, 75, 18);
                            textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                            //Descrição
                            graphics.DrawRectangle(pen, XBrushes.White, 76 + Margem_Esq, 180 + Margem_Topo, 513, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 76 + Margem_Esq, 198 + Margem_Topo, 513, 18);
                            textFormatter2.DrawString("Nome/Razão Social:", fonte4, XBrushes.Black, new XRect(78 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(78 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                            //CPF/CNPJ      
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo, 125, 18);
                            if (SelectedRow.Cells[47].Value.ToString() == "0")
                            {
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("CNPJ:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            }
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                            //Nome Fantasia
                            graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 216 + Margem_Topo, 463, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 234 + Margem_Topo, 463, 18);
                            textFormatter2.DrawString("Nome Fantasia:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                            //Data Nascimento
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[3].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            }
                            //IE/RG
                            graphics.DrawRectangle(pen, XBrushes.White, 100 + Margem_Esq, 252 + Margem_Topo, 185, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 100 + Margem_Esq, 270 + Margem_Topo, 185, 18);
                            if (SelectedRow.Cells[47].Value.ToString() == "0")
                            {
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(102 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("IE:", fonte4, XBrushes.Black, new XRect(102 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            }
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(102 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Telefone
                            graphics.DrawRectangle(pen, XBrushes.White, 285 + Margem_Esq, 252 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 285 + Margem_Esq, 270 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(287 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(287 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //FAX
                            graphics.DrawRectangle(pen, XBrushes.White, 385 + Margem_Esq, 252 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 385 + Margem_Esq, 270 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(387 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(387 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Celular
                            graphics.DrawRectangle(pen, XBrushes.White, 485 + Margem_Esq, 252 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 485 + Margem_Esq, 270 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(487 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(487 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Endereco
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo, 526, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo, 526, 18);
                            textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                            //Numero
                            graphics.DrawRectangle(pen, XBrushes.White, 526 + Margem_Esq, 288 + Margem_Topo, 63, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 526 + Margem_Esq, 306 + Margem_Topo, 63, 18);
                            textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(528 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(528 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                            //Complemento
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo, 285, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo, 285, 18);
                            textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                            //BairroDD
                            graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 324 + Margem_Topo, 299, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 342 + Margem_Topo, 299, 18);
                            textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                            //UF
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 360 + Margem_Topo, 25, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 378 + Margem_Topo, 25, 18);
                            textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                            //Cidade
                            graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 360 + Margem_Topo, 435, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 378 + Margem_Topo, 435, 18);
                            textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                            //CEP
                            graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 360 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 378 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                            //E-mail
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 396 + Margem_Topo, 345, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 414 + Margem_Topo, 345, 18);
                            textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                            //Gênero
                            graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 396 + Margem_Topo, 115, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 414 + Margem_Topo, 115, 18);
                            textFormatter2.DrawString("Gênero:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                            //Palavra-Chave
                            graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 396 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 414 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[45].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                            //Nome do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 450 + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Nome do Pai:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[35].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 452 + Margem_Topo, page.Width, page.Height));
                            //CPF do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 468 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 486 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CPF do Pai:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[36].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            //Celular do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 129 + Margem_Esq, 468 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 129 + Margem_Esq, 486 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular do Pai:", fonte4, XBrushes.Black, new XRect(131 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[37].Value.ToString(), fonte1, XBrushes.Black, new XRect(131 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            //E-mail do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 233 + Margem_Esq, 468 + Margem_Topo, 356, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 233 + Margem_Esq, 486 + Margem_Topo, 356, 18);
                            textFormatter2.DrawString("E-mail do Pai:", fonte4, XBrushes.Black, new XRect(235 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[38].Value.ToString(), fonte1, XBrushes.Black, new XRect(235 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            //Nome da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 504 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 522 + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Nome da Mãe:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 506 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[39].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 524 + Margem_Topo, page.Width, page.Height));
                            //CPF da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 540 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 558 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CPF da Mãe:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 542 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[40].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 560 + Margem_Topo, page.Width, page.Height));
                            //Celular da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 129 + Margem_Esq, 540 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 129 + Margem_Esq, 558 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular da Mãe:", fonte4, XBrushes.Black, new XRect(131 + Margem_Esq, 542 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[41].Value.ToString(), fonte1, XBrushes.Black, new XRect(131 + Margem_Esq, 560 + Margem_Topo, page.Width, page.Height));
                            //E-mail da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 233 + Margem_Esq, 540 + Margem_Topo, 356, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 233 + Margem_Esq, 558 + Margem_Topo, 356, 18);
                            textFormatter2.DrawString("E-mail da Mãe:", fonte4, XBrushes.Black, new XRect(235 + Margem_Esq, 542 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[42].Value.ToString(), fonte1, XBrushes.Black, new XRect(235 + Margem_Esq, 560 + Margem_Topo, page.Width, page.Height));
                            //Nome Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 576 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 594 + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Nome do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 578 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[22].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 596 + Margem_Topo, page.Width, page.Height));
                            //CPF Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 612 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 630 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("CPF do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 614 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 632 + Margem_Topo, page.Width, page.Height));
                            //RG Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 612 + Margem_Topo, 165, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 630 + Margem_Topo, 165, 18);
                            textFormatter2.DrawString("RG do Avalista:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 614 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[24].Value.ToString(), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 632 + Margem_Topo, page.Width, page.Height));
                            //E-mail Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 612 + Margem_Topo, 299, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 630 + Margem_Topo, 299, 18);
                            textFormatter2.DrawString("E-mail do Avalista:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 614 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 632 + Margem_Topo, page.Width, page.Height));
                            //Endereco Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 648 + Margem_Topo, 526, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 666 + Margem_Topo, 526, 18);
                            textFormatter2.DrawString("Endereço do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 650 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[26].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 668 + Margem_Topo, page.Width, page.Height));
                            //Numero Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 526 + Margem_Esq, 648 + Margem_Topo, 63, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 526 + Margem_Esq, 666 + Margem_Topo, 63, 18);
                            textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(528 + Margem_Esq, 650 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[30].Value.ToString() != "0")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[30].Value.ToString(), fonte1, XBrushes.Black, new XRect(528 + Margem_Esq, 668 + Margem_Topo, page.Width, page.Height));
                            }
                            //Complemento Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 684 + Margem_Topo, 285, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 702 + Margem_Topo, 285, 18);
                            textFormatter2.DrawString("Complemento do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 686 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[31].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 704 + Margem_Topo, page.Width, page.Height));
                            //Bairro Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 684 + Margem_Topo, 299, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 702 + Margem_Topo, 299, 18);
                            textFormatter2.DrawString("Bairro do Avalista:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 686 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[27].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 704 + Margem_Topo, page.Width, page.Height));
                            //UF Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 720 + Margem_Topo, 25, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 738 + Margem_Topo, 25, 18);
                            textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 722 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[28].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 740 + Margem_Topo, page.Width, page.Height));
                            //Cidade Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 720 + Margem_Topo, 435, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 738 + Margem_Topo, 435, 18);
                            textFormatter2.DrawString("Cidade do Avalista:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 722 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[29].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 740 + Margem_Topo, page.Width, page.Height));
                            //CEP Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 720 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 738 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CEP do Avalista:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 722 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[32].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 740 + Margem_Topo, page.Width, page.Height));
                            //Telefone Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 756 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 774 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Telefone do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[33].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 776 + Margem_Topo, page.Width, page.Height));
                            //Celular Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 105 + Margem_Esq, 756 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 105 + Margem_Esq, 774 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular do Avalista:", fonte4, XBrushes.Black, new XRect(107 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[34].Value.ToString(), fonte1, XBrushes.Black, new XRect(107 + Margem_Esq, 776 + Margem_Topo, page.Width, page.Height));
                            //Crédito
                            graphics.DrawRectangle(pen, XBrushes.White, 209 + Margem_Esq, 756 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 209 + Margem_Esq, 774 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Crédito (R$):", fonte4, XBrushes.Black, new XRect(211 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(211 + Margem_Esq, 776 + Margem_Topo, 99, page.Height));
                            //Saldo
                            graphics.DrawRectangle(pen, XBrushes.White, 313 + Margem_Esq, 756 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 313 + Margem_Esq, 774 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Usado (R$):", fonte4, XBrushes.Black, new XRect(315 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(315 + Margem_Esq, 776 + Margem_Topo, 99, page.Height));
                            //Saldo Crédito Loja
                            graphics.DrawRectangle(pen, XBrushes.White, 417 + Margem_Esq, 756 + Margem_Topo, 172, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 417 + Margem_Esq, 774 + Margem_Topo, 172, 18);
                            textFormatter2.DrawString("Crédito da Loja (R$):", fonte4, XBrushes.Black, new XRect(419 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(419 + Margem_Esq, 776 + Margem_Topo, 167, page.Height));
                            //
                            if (dtClie.Rows.Count > 1)
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
                                textFormatter1.DrawString("Relatório de Clientes", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Página(s): " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(3 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                            }
                        }
                        else
                        {
                            Margem_Topo = Convert.ToInt16(Margem_Topo - 120);
                            //Código
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 180 + Margem_Topo, 75, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 198 + Margem_Topo, 75, 18);
                            textFormatter2.DrawString("Código:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                            //Descrição
                            graphics.DrawRectangle(pen, XBrushes.White, 76 + Margem_Esq, 180 + Margem_Topo, 513, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 76 + Margem_Esq, 198 + Margem_Topo, 513, 18);
                            textFormatter2.DrawString("Nome/Razão Social:", fonte4, XBrushes.Black, new XRect(78 + Margem_Esq, 182 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte1, XBrushes.Black, new XRect(78 + Margem_Esq, 200 + Margem_Topo, page.Width, page.Height));
                            //CPF/CNPJ      
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 216 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 234 + Margem_Topo, 125, 18);
                            if (SelectedRow.Cells[47].Value.ToString() == "0")
                            {
                                textFormatter2.DrawString("CPF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("CNPJ:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            }
                            textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                            //Nome Fantasia
                            graphics.DrawRectangle(pen, XBrushes.White, 126 + Margem_Esq, 216 + Margem_Topo, 463, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 126 + Margem_Esq, 234 + Margem_Topo, 463, 18);
                            textFormatter2.DrawString("Nome Fantasia:", fonte4, XBrushes.Black, new XRect(128 + Margem_Esq, 218 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[2].Value.ToString(), fonte1, XBrushes.Black, new XRect(128 + Margem_Esq, 236 + Margem_Topo, page.Width, page.Height));
                            //Data Nascimento
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 252 + Margem_Topo, 95, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 270 + Margem_Topo, 95, 18);
                            textFormatter2.DrawString("Data de Nascimento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[3].Value.ToString() != "")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[3].Value.ToString().Substring(0, 10), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            }
                            //IE/RG
                            graphics.DrawRectangle(pen, XBrushes.White, 100 + Margem_Esq, 252 + Margem_Topo, 185, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 100 + Margem_Esq, 270 + Margem_Topo, 185, 18);
                            if (SelectedRow.Cells[47].Value.ToString() == "0")
                            {
                                textFormatter2.DrawString("RG:", fonte4, XBrushes.Black, new XRect(102 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            }
                            else
                            {
                                textFormatter2.DrawString("IE:", fonte4, XBrushes.Black, new XRect(102 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            }
                            textFormatter2.DrawString(SelectedRow.Cells[5].Value.ToString(), fonte1, XBrushes.Black, new XRect(102 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Telefone
                            graphics.DrawRectangle(pen, XBrushes.White, 285 + Margem_Esq, 252 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 285 + Margem_Esq, 270 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Telefone:", fonte4, XBrushes.Black, new XRect(287 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString(), fonte1, XBrushes.Black, new XRect(287 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //FAX
                            graphics.DrawRectangle(pen, XBrushes.White, 385 + Margem_Esq, 252 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 385 + Margem_Esq, 270 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("FAX:", fonte4, XBrushes.Black, new XRect(387 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString(), fonte1, XBrushes.Black, new XRect(387 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Celular
                            graphics.DrawRectangle(pen, XBrushes.White, 485 + Margem_Esq, 252 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 485 + Margem_Esq, 270 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular:", fonte4, XBrushes.Black, new XRect(487 + Margem_Esq, 254 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString(), fonte1, XBrushes.Black, new XRect(487 + Margem_Esq, 272 + Margem_Topo, page.Width, page.Height));
                            //Endereco
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 288 + Margem_Topo, 526, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 306 + Margem_Topo, 526, 18);
                            textFormatter2.DrawString("Endereço:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[11].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                            //Numero
                            graphics.DrawRectangle(pen, XBrushes.White, 526 + Margem_Esq, 288 + Margem_Topo, 63, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 526 + Margem_Esq, 306 + Margem_Topo, 63, 18);
                            textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(528 + Margem_Esq, 290 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte1, XBrushes.Black, new XRect(528 + Margem_Esq, 308 + Margem_Topo, page.Width, page.Height));
                            //Complemento
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 324 + Margem_Topo, 285, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 342 + Margem_Topo, 285, 18);
                            textFormatter2.DrawString("Complemento:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                            //BairroDD
                            graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 324 + Margem_Topo, 299, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 342 + Margem_Topo, 299, 18);
                            textFormatter2.DrawString("Bairro:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 326 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 344 + Margem_Topo, page.Width, page.Height));
                            //UF
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 360 + Margem_Topo, 25, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 378 + Margem_Topo, 25, 18);
                            textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                            //Cidade
                            graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 360 + Margem_Topo, 435, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 378 + Margem_Topo, 435, 18);
                            textFormatter2.DrawString("Cidade:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[16].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                            //CEP
                            graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 360 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 378 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CEP:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 362 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[17].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 380 + Margem_Topo, page.Width, page.Height));
                            //E-mail
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 396 + Margem_Topo, 345, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 414 + Margem_Topo, 345, 18);
                            textFormatter2.DrawString("E-mail:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                            //Gênero
                            graphics.DrawRectangle(pen, XBrushes.White, 350 + Margem_Esq, 396 + Margem_Topo, 115, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 350 + Margem_Esq, 414 + Margem_Topo, 115, 18);
                            textFormatter2.DrawString("Gênero:", fonte4, XBrushes.Black, new XRect(352 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString(), fonte1, XBrushes.Black, new XRect(352 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                            //Palavra-Chave
                            graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 396 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 414 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("Palavra-Chave:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 398 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[45].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 416 + Margem_Topo, page.Width, page.Height));
                            //Nome do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 432 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 450 + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Nome do Pai:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 434 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[35].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 452 + Margem_Topo, page.Width, page.Height));
                            //CPF do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 468 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 486 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CPF do Pai:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[36].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            //Celular do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 129 + Margem_Esq, 468 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 129 + Margem_Esq, 486 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular do Pai:", fonte4, XBrushes.Black, new XRect(131 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[37].Value.ToString(), fonte1, XBrushes.Black, new XRect(131 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            //E-mail do Pai
                            graphics.DrawRectangle(pen, XBrushes.White, 233 + Margem_Esq, 468 + Margem_Topo, 356, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 233 + Margem_Esq, 486 + Margem_Topo, 356, 18);
                            textFormatter2.DrawString("E-mail do Pai:", fonte4, XBrushes.Black, new XRect(235 + Margem_Esq, 470 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[38].Value.ToString(), fonte1, XBrushes.Black, new XRect(235 + Margem_Esq, 488 + Margem_Topo, page.Width, page.Height));
                            //Nome da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 504 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 522 + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Nome da Mãe:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 506 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[39].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 524 + Margem_Topo, page.Width, page.Height));
                            //CPF da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 540 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 558 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CPF da Mãe:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 542 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[40].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 560 + Margem_Topo, page.Width, page.Height));
                            //Celular da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 129 + Margem_Esq, 540 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 129 + Margem_Esq, 558 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular da Mãe:", fonte4, XBrushes.Black, new XRect(131 + Margem_Esq, 542 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[41].Value.ToString(), fonte1, XBrushes.Black, new XRect(131 + Margem_Esq, 560 + Margem_Topo, page.Width, page.Height));
                            //E-mail da Mãe
                            graphics.DrawRectangle(pen, XBrushes.White, 233 + Margem_Esq, 540 + Margem_Topo, 356, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 233 + Margem_Esq, 558 + Margem_Topo, 356, 18);
                            textFormatter2.DrawString("E-mail da Mãe:", fonte4, XBrushes.Black, new XRect(235 + Margem_Esq, 542 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[42].Value.ToString(), fonte1, XBrushes.Black, new XRect(235 + Margem_Esq, 560 + Margem_Topo, page.Width, page.Height));
                            //Nome Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 576 + Margem_Topo, 584, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 594 + Margem_Topo, 584, 18);
                            textFormatter2.DrawString("Nome do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 578 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[22].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 596 + Margem_Topo, page.Width, page.Height));
                            //CPF Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 612 + Margem_Topo, 125, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 630 + Margem_Topo, 125, 18);
                            textFormatter2.DrawString("CPF do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 614 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[23].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 632 + Margem_Topo, page.Width, page.Height));
                            //RG Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 125 + Margem_Esq, 612 + Margem_Topo, 165, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 125 + Margem_Esq, 630 + Margem_Topo, 165, 18);
                            textFormatter2.DrawString("RG do Avalista:", fonte4, XBrushes.Black, new XRect(127 + Margem_Esq, 614 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[24].Value.ToString(), fonte1, XBrushes.Black, new XRect(127 + Margem_Esq, 632 + Margem_Topo, page.Width, page.Height));
                            //E-mail Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 612 + Margem_Topo, 299, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 630 + Margem_Topo, 299, 18);
                            textFormatter2.DrawString("E-mail do Avalista:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 614 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 632 + Margem_Topo, page.Width, page.Height));
                            //Endereco Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 648 + Margem_Topo, 526, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 666 + Margem_Topo, 526, 18);
                            textFormatter2.DrawString("Endereço do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 650 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[26].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 668 + Margem_Topo, page.Width, page.Height));
                            //Numero Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 526 + Margem_Esq, 648 + Margem_Topo, 63, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 526 + Margem_Esq, 666 + Margem_Topo, 63, 18);
                            textFormatter2.DrawString("Número:", fonte4, XBrushes.Black, new XRect(528 + Margem_Esq, 650 + Margem_Topo, page.Width, page.Height));
                            if (SelectedRow.Cells[30].Value.ToString() != "0")
                            {
                                textFormatter2.DrawString(SelectedRow.Cells[30].Value.ToString(), fonte1, XBrushes.Black, new XRect(528 + Margem_Esq, 668 + Margem_Topo, page.Width, page.Height));
                            }
                            //Complemento Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 684 + Margem_Topo, 285, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 702 + Margem_Topo, 285, 18);
                            textFormatter2.DrawString("Complemento do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 686 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[31].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 704 + Margem_Topo, page.Width, page.Height));
                            //Bairro Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 290 + Margem_Esq, 684 + Margem_Topo, 299, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 290 + Margem_Esq, 702 + Margem_Topo, 299, 18);
                            textFormatter2.DrawString("Bairro do Avalista:", fonte4, XBrushes.Black, new XRect(292 + Margem_Esq, 686 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[27].Value.ToString(), fonte1, XBrushes.Black, new XRect(292 + Margem_Esq, 704 + Margem_Topo, page.Width, page.Height));
                            //UF Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 720 + Margem_Topo, 25, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 738 + Margem_Topo, 25, 18);
                            textFormatter2.DrawString("UF:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 722 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[28].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 740 + Margem_Topo, page.Width, page.Height));
                            //Cidade Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 30 + Margem_Esq, 720 + Margem_Topo, 435, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 30 + Margem_Esq, 738 + Margem_Topo, 435, 18);
                            textFormatter2.DrawString("Cidade do Avalista:", fonte4, XBrushes.Black, new XRect(32 + Margem_Esq, 722 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[29].Value.ToString(), fonte1, XBrushes.Black, new XRect(32 + Margem_Esq, 740 + Margem_Topo, page.Width, page.Height));
                            //CEP Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 465 + Margem_Esq, 720 + Margem_Topo, 124, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 465 + Margem_Esq, 738 + Margem_Topo, 124, 18);
                            textFormatter2.DrawString("CEP do Avalista:", fonte4, XBrushes.Black, new XRect(467 + Margem_Esq, 722 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[32].Value.ToString(), fonte1, XBrushes.Black, new XRect(467 + Margem_Esq, 740 + Margem_Topo, page.Width, page.Height));
                            //Telefone Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 756 + Margem_Topo, 100, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 774 + Margem_Topo, 100, 18);
                            textFormatter2.DrawString("Telefone do Avalista:", fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[33].Value.ToString(), fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 776 + Margem_Topo, page.Width, page.Height));
                            //Celular Avalista
                            graphics.DrawRectangle(pen, XBrushes.White, 105 + Margem_Esq, 756 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 105 + Margem_Esq, 774 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Celular do Avalista:", fonte4, XBrushes.Black, new XRect(107 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter2.DrawString(SelectedRow.Cells[34].Value.ToString(), fonte1, XBrushes.Black, new XRect(107 + Margem_Esq, 776 + Margem_Topo, page.Width, page.Height));
                            //Crédito
                            graphics.DrawRectangle(pen, XBrushes.White, 209 + Margem_Esq, 756 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 209 + Margem_Esq, 774 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Crédito (R$):", fonte4, XBrushes.Black, new XRect(211 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(211 + Margem_Esq, 776 + Margem_Topo, 99, page.Height));
                            //Saldo
                            graphics.DrawRectangle(pen, XBrushes.White, 313 + Margem_Esq, 756 + Margem_Topo, 104, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 313 + Margem_Esq, 774 + Margem_Topo, 104, 18);
                            textFormatter2.DrawString("Usado (R$):", fonte4, XBrushes.Black, new XRect(315 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(315 + Margem_Esq, 776 + Margem_Topo, 99, page.Height));
                            //Saldo Crédito Loja
                            graphics.DrawRectangle(pen, XBrushes.White, 417 + Margem_Esq, 756 + Margem_Topo, 172, 18);
                            graphics.DrawRectangle(pen, XBrushes.LightBlue, 417 + Margem_Esq, 774 + Margem_Topo, 172, 18);
                            textFormatter2.DrawString("Crédito da Loja (R$):", fonte4, XBrushes.Black, new XRect(419 + Margem_Esq, 758 + Margem_Topo, page.Width, page.Height));
                            textFormatter3.DrawString(Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(419 + Margem_Esq, 776 + Margem_Topo, 167, page.Height));

                            Margem_Topo = Convert.ToInt16(Margem_Topo + 120);
                            //
                            if (dtClie.Rows.Count > pagina)
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
                                textFormatter1.DrawString("Relatório de Clientes", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
                    }
                }
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.txt"))
                {
                    writer.WriteLine("Relatório de Clientes" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtClie.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtClie.Rows[linha];
                        //
                        string data_nascimento = "";
                        if (SelectedRow.Cells[3].Value.ToString() == "" || SelectedRow.Cells[3].Value.ToString() == null)
                        {
                            data_nascimento = "";
                        }
                        else
                        {
                            data_nascimento = SelectedRow.Cells[3].Value.ToString().Remove(10);
                        }
                        //
                        string pessoa = "";
                        if (SelectedRow.Cells[47].Value.ToString() == "0")
                        {
                            pessoa = "PESSOA FÍSICA";
                        }
                        else
                        {
                            pessoa = "PESSOA JURÍDICA";
                        }
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Nome/Razão Social: " + SelectedRow.Cells[1].Value.ToString() + " |Nome Fantasia: " + SelectedRow.Cells[2].Value.ToString() + " |Data de Nascimento: " + data_nascimento + " |CPF/CNPJ: " + SelectedRow.Cells[4].Value.ToString() + " |IE/RG: " + SelectedRow.Cells[5].Value.ToString() + " |Sexo: " + SelectedRow.Cells[6].Value.ToString() + " |Telefone: " + SelectedRow.Cells[7].Value.ToString() + " |FAX: " + SelectedRow.Cells[8].Value.ToString() + " |Celular: " + SelectedRow.Cells[9].Value.ToString() + "|E-mail: " + SelectedRow.Cells[10].Value.ToString() + " |Endereço: " + SelectedRow.Cells[11].Value.ToString() + " |Número: " + SelectedRow.Cells[12].Value.ToString() + " |Complemento: " + SelectedRow.Cells[13].Value.ToString() + " |Bairro: " + SelectedRow.Cells[14].Value.ToString() + " |UF: " + SelectedRow.Cells[15].Value.ToString() + " |Cidade: " + SelectedRow.Cells[16].Value.ToString() + " |CEP: " + SelectedRow.Cells[17].Value.ToString() + " |Situação: " + SelectedRow.Cells[18].Value.ToString() + " |Crédito (R$): " + Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Usado (R$): " + Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Crédito da Loja (R$): " + Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Avalista: " + SelectedRow.Cells[22].Value.ToString() + " |CPF do Avalista: " + SelectedRow.Cells[23].Value.ToString() + " |RG do Avalista: " + SelectedRow.Cells[24].Value.ToString() + " |E-mail do Avalista: " + SelectedRow.Cells[25].Value.ToString() + " |Endereço do Avalista: " + SelectedRow.Cells[26].Value.ToString() + " |Bairro do Avalista: " + SelectedRow.Cells[27].Value.ToString() + " |UF do Avalista: " + SelectedRow.Cells[28].Value.ToString() + " |Cidade do Avalista: " + SelectedRow.Cells[29].Value.ToString() + " |Número do Avalista: " + SelectedRow.Cells[30].Value.ToString() + " |Complemento do Avalista: " + SelectedRow.Cells[31].Value.ToString() + " |CEP do Avalista: " + SelectedRow.Cells[32].Value.ToString() + " |Telefone do Avalista: " + SelectedRow.Cells[33].Value.ToString() + " |Celular do Avalista: " + SelectedRow.Cells[34].Value.ToString() + " | Nome do Pai: " + SelectedRow.Cells[35].Value.ToString() + " |CPF do Pai: " + SelectedRow.Cells[36].Value.ToString() + " |Celular do Pai: " + SelectedRow.Cells[37].Value.ToString() + " |E-mail do Pai: " + SelectedRow.Cells[38].Value.ToString() + " |Nome da Mãe: " + SelectedRow.Cells[39].Value.ToString() + " |CPF da mãe: " + SelectedRow.Cells[40].Value.ToString() + " |Celular da Mãe: " + SelectedRow.Cells[41].Value.ToString() + " |E-mail da Mãe: " + SelectedRow.Cells[42].Value.ToString() + " |Observações: " + SelectedRow.Cells[43].Value.ToString() + " |Palavra-Chave: " + SelectedRow.Cells[45].Value.ToString() + " |Data de Cadastro: " + SelectedRow.Cells[46].Value.ToString().Remove(10) + " |Tipo de Pessoa: " + pessoa);
                    }
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.txt");
            }
            else if (_Trabalho == 3)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Nome/Razão Social;Nome Fantasia;Data de Nascimento;CPF/CNPJ;RG/IE;Sexo;Telefone;FAX;Celular;E-mail;Endereço;Número;Complemento;Bairro;UF;Cidade;CEP;Situação;Crédito (R$);Usado (R$);Crédito da Loja (R$);Avalista;CPF do Avalista;RG do Avalista;E-mail do Avalista;Endereço do Avalista;Bairro do Avalista;UF do Avalista;Cidade do Avalista;Número do Avalista;Complemento do Avalista;CEP do Avalista;Telefone do Avalista;Celular do Avalista;Nome do Pai;CPF do Pai;Celular do Pai;E-mail do Pai;Nome da Mãe;CPF da Mãe;Celular da Mãe;E-mail da Mãe;Observações;Palavra-Chave;Data de Cadastro;Tipo de Pessoa");
                    for (int linha = 0; linha < dtClie.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtClie.Rows[linha];
                        //
                        string data_nascimento = SelectedRow.Cells[3].Value.ToString();
                        //
                        if (data_nascimento == "" || data_nascimento == null)
                        {
                            data_nascimento = "";
                        }
                        else
                        {
                            data_nascimento = data_nascimento.Remove(10);
                        }
                        //           
                        string pessoa = "";
                        if (SelectedRow.Cells[47].Value.ToString() == "0")
                        {
                            pessoa = "PESSOA FÍSICA";
                        }
                        else
                        {
                            pessoa = "PESSOA JURÍDICA";
                        }
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28};{29};{30};{31};{32};{33};{34};{35};{36};{37};{38};{39};{40};{41};{42};{43};{44};{45};{46};", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), data_nascimento, SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[15].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), SelectedRow.Cells[17].Value.ToString(), SelectedRow.Cells[18].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[23].Value.ToString(), SelectedRow.Cells[24].Value.ToString(), SelectedRow.Cells[25].Value.ToString(), SelectedRow.Cells[26].Value.ToString(), SelectedRow.Cells[27].Value.ToString(), SelectedRow.Cells[28].Value.ToString(), SelectedRow.Cells[29].Value.ToString(), SelectedRow.Cells[30].Value.ToString(), SelectedRow.Cells[31].Value.ToString(), SelectedRow.Cells[32].Value.ToString(), SelectedRow.Cells[33].Value.ToString(), SelectedRow.Cells[34].Value.ToString(), SelectedRow.Cells[35].Value.ToString(), SelectedRow.Cells[36].Value.ToString(), SelectedRow.Cells[37].Value.ToString(), SelectedRow.Cells[38].Value.ToString(), SelectedRow.Cells[39].Value.ToString(), SelectedRow.Cells[40].Value.ToString(), SelectedRow.Cells[41].Value.ToString(), SelectedRow.Cells[42].Value.ToString(), SelectedRow.Cells[43].Value.ToString(), SelectedRow.Cells[45].Value.ToString(), SelectedRow.Cells[46].Value.ToString().Remove(10), pessoa));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Clientes");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.csv");
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
                dtClie.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
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
                dtClie.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtClie.Select();
                //
                try
                {
                    if (_Trabalho == 0 || _Trabalho == 1)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Clientes\Clientes.pdf");
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
                    dtClie.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                }
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome/razão social, código, cpf, cnpj, rg, inscrição estadual, cpf pai/mãe, palavra-chave, todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtpEmail_Enter(object sender, EventArgs e)
        {
            txtpEmail.BackColor = Color.LightBlue;
        }

        private void txtpEmail_Leave(object sender, EventArgs e)
        {
            if (txtpEmail.Text.Contains("'") || txtpEmail.Text.Contains(";") || txtpEmail.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpEmail.Text = null;
                txtpEmail.Select();
            }
            txtpEmail.BackColor = Color.White;
        }

        private void txtpEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNomeAvalista.Select();
            }
        }

        private void cbbpTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipo_DropDownClosed(object sender, EventArgs e)
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

        private void cbbpTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpTelefone.Select();
            }
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

        private void btnTodasContas_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (Seven_Sistema.FrmInfImpressao Imp = new Seven_Sistema.FrmInfImpressao(20))
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
                    dtClie.Enabled = false;
                    dtClie.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtClie.Enabled = false;
            dtClie.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 3;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtClie.Enabled = false;
            dtClie.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void mtxtpData_KeyDown(object sender, KeyEventArgs e)
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

        private void mtxtpData1_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNomeAvalista_Enter(object sender, EventArgs e)
        {
            txtNomeAvalista.BackColor = Color.LightBlue;
        }

        private void txtNomeAvalista_Leave(object sender, EventArgs e)
        {
            if (txtNomeAvalista.Text.Contains("'") || txtNomeAvalista.Text.Contains(";") || txtNomeAvalista.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeAvalista.Text = null;
                txtNomeAvalista.Select();
            }
            txtNomeAvalista.BackColor = Color.White;
        }

        private void txtNomeAvalista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCPFAvalista.Select();
            }
        }

        private void mtxtCPFAvalista_Enter(object sender, EventArgs e)
        {
            mtxtCPFAvalista.BackColor = Color.LightBlue;
        }

        private void mtxtCPFAvalista_Leave(object sender, EventArgs e)
        {
            mtxtCPFAvalista.BackColor = Color.White;
        }

        private void mtxtCPFAvalista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void dtClie_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 30 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void btnRelatorioCompleto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioCompleto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioCompleto_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (Seven_Sistema.FrmInfImpressao Imp = new Seven_Sistema.FrmInfImpressao(21))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 1;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtClie.Enabled = false;
                    dtClie.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
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
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(17))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Select();
                    mtxtpData.Text = bllClieCons._Data_DatePicker1;
                    mtxtpData1.Text = bllClieCons._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtClie.Rows[dtClie.CurrentRow.Index];

                using (FrmDocumentos Doc = new FrmDocumentos(0, SelectedRow.Cells[52].Value.ToString(), _Cod_PDV_Computador, _Usuario, SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[0].Value.ToString()))
                {
                    if (Doc.ShowDialog() == DialogResult.Abort)
                    {
                        btnInfDocumentos.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão button1_Click.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão button1_Click.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnDigitalizacaoDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDigitalizacaoDocumento_MouseLeave(object sender, EventArgs e)
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

        private void cbbpSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarSubgrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarSubgrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
                    txtpEmail.Select();
                }
            }
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpEmail.Select();
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
                    if (bllClieCons.Sel_SubGrupo_Clie(items[0]) == null)
                    {
                        lblSubgrupos.Enabled = false;
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnProcurarSubgrupo.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllClieCons.Sel_SubGrupo_Clie(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            cbbpSubGrupo.Enabled = true;
                            lblSubgrupos.Enabled = true;
                            btnProcurarSubgrupo.Enabled = true;
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
                    lblSubgrupos.Enabled = false;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
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
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(5))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllClieCons.Sel_Grupo_Clie() == null)
                        {
                            lblSubgrupos.Enabled = false;
                            cbbpGrupo.Text = null;
                            cbbpGrupo.Enabled = false;
                            cbbpSubGrupo.Text = null;
                            cbbpSubGrupo.Enabled = false;
                            btnProcurarSubgrupo.Enabled = false;
                        }
                        else
                        {
                            cbbpGrupo.Enabled = true;
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllClieCons.Sel_Grupo_Clie().Rows)
                            {
                                cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                            lblSubgrupos.Enabled = true;
                            cbbpSubGrupo.Enabled = true;
                            btnProcurarSubgrupo.Enabled = true;
                        }
                        cbbpGrupo.Text = bllClieCons._Grupo_PesqGrupo_Tabela;
                        bllClieCons._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
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
                        bllClieCons._Grupo_PesqGrupo_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarSubgrupo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                string[] items = cbbpGrupo.Text.Split('—');

                using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 3))
                {
                    if (Sub.ShowDialog() == DialogResult.OK)
                    {
                        cbbpSubGrupo.Items.Clear();
                        if (bllClieCons.Sel_SubGrupo_Clie(items[0]) == null)
                        {
                            cbbpSubGrupo.Text = null;
                            cbbpSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbpSubGrupo.Enabled = true;
                            cbbpSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllClieCons.Sel_SubGrupo_Clie(items[0]).Rows)
                            {
                                cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbpSubGrupo.Text = bllClieCons._SubGrupo_PesqSubGrupo_Tabela;
                        bllClieCons._SubGrupo_PesqSubGrupo_Tabela = null;
                        cbbpSubGrupo.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSubgrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSubgrupo.");
                }
                cbbpSubGrupo.Text = null;
                bllClieCons._SubGrupo_PesqSubGrupo_Tabela = null;
            }
            pEnabled.Enabled = true;
        }
    }
}
