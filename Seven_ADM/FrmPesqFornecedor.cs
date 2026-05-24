using BLL;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqFornecedor : Form
    {
        public FrmPesqFornecedor(byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private bool _Contem_Imagem;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqFornecedor_Load(object sender, EventArgs e)
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFornecedor iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFornecedor iniciado.");
                }
                //
                rbtnNome.Checked = true;
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
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqFornecedor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqFornecedor.");
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPalavra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavra_MouseLeave(object sender, EventArgs e)
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

        private void rbtnRG_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnRG_MouseLeave(object sender, EventArgs e)
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

        private void rbtnCPF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPF_MouseLeave(object sender, EventArgs e)
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

        private void rbtnNome_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNome_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtPesquisa_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtPesquisa.DataSource != null)
            {
                this.Cursor = Cursors.IBeam;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dtPesquisa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.White;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.White;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpRG_Enter(object sender, EventArgs e)
        {
            txtpRG.BackColor = Color.LightBlue;
        }

        private void txtpRG_Leave(object sender, EventArgs e)
        {
            txtpRG.BackColor = Color.White;
        }

        private void mtxtpCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.LightBlue;
        }

        private void mtxtpCNPJ_Leave(object sender, EventArgs e)
        {
            mtxtpCNPJ.BackColor = Color.White;
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

        private void mtxtpCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
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

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtPesquisa.DataSource != null)
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

            if (dtPesquisa.DataSource != null)
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
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmPesqFornecedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Location = new Point(278, 19);
            lblPesquisar.Text = "Digite o nome/razão social:";
            txtpNome.Visible = true;
            txtpNome.MaxLength = 60;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            mtxtpCPF.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(553, 19);
            txtpCodigo.Visible = true;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite o cpf:";
            lblPesquisar.Location = new Point(554, 19);
            mtxtpCPF.Visible = true;
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
        }

        private void rbtnCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(519, 18);
            lblPesquisar.Text = "Digite o cnpj:";
            mtxtpCNPJ.Visible = true;
            mtxtpCNPJ.Text = null;
            mtxtpCNPJ.Select();
        }

        private void rbtnRG_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(511, 18);
            lblPesquisar.Text = "Digite o rg:";
            txtpRG.Visible = true;
            txtpRG.TextAlign = HorizontalAlignment.Right;
            txtpRG.MaxLength = 20;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnIE_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            mtxtpCPF.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(419, 18);
            lblPesquisar.Text = "Digite a inscrição estadual:";
            txtpRG.Visible = true;
            txtpRG.TextAlign = HorizontalAlignment.Right;
            txtpRG.MaxLength = 20;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnPalavra_CheckedChanged(object sender, EventArgs e)
        {
            mtxtpCNPJ.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpPalavraChave.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(510, 18);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpNome.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            mtxtpCNPJ.Visible = false;
            txtpNome.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            mtxtpCPF.Visible = false;
            lblPesquisar.Location = new Point(600, 18);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção o você pesquisará os dados por nome/razão social, código, cpf, cnpj, rg, inscrição estadual, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Select();
            try
            {
                if (rbtnNome.Checked == true)
                {
                    if (txtpNome.Text != "")
                    {
                        if (bllFornecedor.Sel_F_Nome(txtpNome.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllFornecedor.Sel_F_Nome(txtpNome.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllFornecedor.Sel_F_Cod(txtpCodigo.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllFornecedor.Sel_F_Cod(txtpCodigo.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnPalavra.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllFornecedor.Sel_F_Palavra_chave(txtpPalavraChave.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllFornecedor.Sel_F_Palavra_chave(txtpPalavraChave.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnCNPJ.Checked == true)
                {
                    mtxtpCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCNPJ.Text != "")
                    {
                        mtxtpCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFornecedor.Sel_F_Cnpj(mtxtpCNPJ.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllFornecedor.Sel_F_Cnpj(mtxtpCNPJ.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnCPF.Checked == true)
                {
                    mtxtpCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCPF.Text != "")
                    {
                        mtxtpCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFornecedor.Sel_F_Cpf(mtxtpCPF.Text) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllFornecedor.Sel_F_Cpf(mtxtpCPF.Text);
                            dtPesquisa.Select();
                        }
                    }
                }
                if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllFornecedor.Sel_F_IERG(txtpRG.Text, 0) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllFornecedor.Sel_F_IERG(txtpRG.Text, 0);
                            dtPesquisa.Select();
                        }
                    }
                }
                if (rbtnIE.Checked == true)
                {
                    if (txtpRG.Text != "")
                    {
                        if (bllFornecedor.Sel_F_IERG(txtpRG.Text, 1) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllFornecedor.Sel_F_IERG(txtpRG.Text, 1);
                            dtPesquisa.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllFornecedor.Sel_F_Todos() == null)
                    {
                        dtPesquisa.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtPesquisa.DataSource = bllFornecedor.Sel_F_Todos();
                        dtPesquisa.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou fornecedor.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou fornecedor.");
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
                dtPesquisa.DataSource = null;
                rbtnNome.Checked = true;
            }
        }

        private void dtPesquisa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtPesquisa.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtPesquisa.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];

                if (SelectedRow.Cells[19].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtForn.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtForn.");
                }
                dtPesquisa.DataSource = null;
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

                if (rotateFlipType != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlipType);
                }
            }

            return image;
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtPesquisa.DataSource != null)
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
        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[19].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtPesquisa.DataSource != null)
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
        private void dtPesquisa_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPesquisa.DataSource != null)
            {
                btnIncluir.Enabled = true;
                dtPesquisa.Enabled = true;
                pcibImagem.Enabled = true;
            }
            else
            {
                btnIncluir.Enabled = false;
                dtPesquisa.Enabled = false;
                pcibImagem.Enabled = false;
            }
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmPesqFornecedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFornecedor foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFornecedor foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqFornecedor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqFornecedor.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                if (_Formulario == 0)
                {
                    bllProduto._Fornecedor_PesqFornecedor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllSaidasProdutos._Saidas_Prod_PesqForn_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    bllEntradasProdutos._FornProd_Prod_PesqForn_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    bllContasPagar._Emitente_PesqContaPagar_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    bllContasReceber._Consumidor_PesqContaReceber = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    if (SelectedRow.Cells[10].Value.ToString() == "")
                    {
                        MessageBox.Show("O Fornecedor selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[10].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 6)
                {
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O fornecedor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 7)
                {
                    bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 8)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Fornecedor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllSMS._Destinatario_SMS = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 9)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Fornecedor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnIncluir.");
                }
            }
        }

        private void dtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    if (_Formulario == 0)
                    {
                        bllProduto._Fornecedor_PesqFornecedor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        bllSaidasProdutos._Saidas_Prod_PesqForn_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 2)
                    {
                        bllEntradasProdutos._FornProd_Prod_PesqForn_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 3)
                    {
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 4)
                    {
                        bllContasReceber._Consumidor_PesqContaReceber = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 5)
                    {
                        if (SelectedRow.Cells[10].Value.ToString() == "")
                        {
                            MessageBox.Show("O Fornecedor selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtPesquisa.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[10].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 6)
                    {
                        if (SelectedRow.Cells[4].Value.ToString() == "")
                        {
                            MessageBox.Show("O fornecedor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtPesquisa.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 7)
                    {
                        bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 8)
                    {
                        if (SelectedRow.Cells[9].Value.ToString() == "")
                        {
                            MessageBox.Show("O Fornecedor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtPesquisa.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllSMS._Destinatario_SMS = SelectedRow.Cells[9].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 9)
                    {
                        if (SelectedRow.Cells[9].Value.ToString() == "")
                        {
                            MessageBox.Show("O Fornecedor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtPesquisa.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[9].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtPesquisa.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtPesquisa.");
                    }
                }
            }
        }

        private void dtPesquisa_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                if (_Formulario == 0)
                {
                    bllProduto._Fornecedor_PesqFornecedor_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllSaidasProdutos._Saidas_Prod_PesqForn_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    bllEntradasProdutos._FornProd_Prod_PesqForn_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    bllContasPagar._Emitente_PesqContaPagar_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    bllContasReceber._Consumidor_PesqContaReceber = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    if (SelectedRow.Cells[10].Value.ToString() == "")
                    {
                        MessageBox.Show("O Fornecedor selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[10].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 6)
                {
                    if (SelectedRow.Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("O fornecedor selecionado não possui CPF/CNPJ cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 7)
                {
                    bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 8)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Fornecedor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllSMS._Destinatario_SMS = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 9)
                {
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Fornecedor selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtPesquisa.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento dobleclick do dtPesquisa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento dobleclick do dtPesquisa.");
                }
            }
        }

        private void dtPesquisa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtPesquisa.Columns[0].HeaderText = "Código";
            dtPesquisa.Columns[1].HeaderText = "Nome/Razão Social";
            dtPesquisa.Columns[2].HeaderText = "Nome Fantasia";
            dtPesquisa.Columns[3].HeaderText = "Data de Nascimento";
            dtPesquisa.Columns[4].HeaderText = "CPF/CNPJ";
            dtPesquisa.Columns[5].HeaderText = "RG/IE";
            dtPesquisa.Columns[6].HeaderText = "Sexo";
            dtPesquisa.Columns[7].HeaderText = "Telefone";
            dtPesquisa.Columns[8].HeaderText = "FAX";
            dtPesquisa.Columns[9].HeaderText = "Celular";
            dtPesquisa.Columns[10].HeaderText = "E-mail";
            dtPesquisa.Columns[11].HeaderText = "Endereço";
            dtPesquisa.Columns[12].HeaderText = "Número";
            dtPesquisa.Columns[13].HeaderText = "Complemento";
            dtPesquisa.Columns[14].HeaderText = "Bairro";
            dtPesquisa.Columns[15].HeaderText = "UF";
            dtPesquisa.Columns[16].HeaderText = "Cidade";
            dtPesquisa.Columns[17].HeaderText = "CEP";
            dtPesquisa.Columns[18].HeaderText = "Observações";
            dtPesquisa.Columns[19].Visible = false;
            dtPesquisa.Columns[20].HeaderText = "Palavra-Chave";
            dtPesquisa.Columns[21].Visible = false;
            dtPesquisa.Columns[22].HeaderText = "Tipo de Pessoa";
            dtPesquisa.Columns[23].Visible = false;

            dtPesquisa.Columns[0].Width = 80;
            dtPesquisa.Columns[1].Width = 325;
            dtPesquisa.Columns[2].Width = 280;
            dtPesquisa.Columns[3].Width = 130;
            dtPesquisa.Columns[4].Width = 129;
            dtPesquisa.Columns[5].Width = 154;
            dtPesquisa.Columns[6].Width = 100;
            dtPesquisa.Columns[7].Width = 100;
            dtPesquisa.Columns[8].Width = 100;
            dtPesquisa.Columns[9].Width = 107;
            dtPesquisa.Columns[10].Width = 220;
            dtPesquisa.Columns[11].Width = 280;
            dtPesquisa.Columns[12].Width = 118;
            dtPesquisa.Columns[13].Width = 260;
            dtPesquisa.Columns[14].Width = 280;
            dtPesquisa.Columns[15].Width = 30;
            dtPesquisa.Columns[16].Width = 280;
            dtPesquisa.Columns[17].Width = 76;
            dtPesquisa.Columns[18].Width = 500;
            dtPesquisa.Columns[20].Width = 95;
            dtPesquisa.Columns[22].Width = 200;

            dtPesquisa.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistros.Text = "Registros: " + dtPesquisa.Rows.Count;

            dtPesquisa.DefaultCellStyle.Font = new Font(dtPesquisa.Font, FontStyle.Bold);
        }

        private void dtPesquisa_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtPesquisa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 22 && e.Value.ToString() == "0")
            {
                e.Value = "Pessoa Física";
            }
            else if (e.ColumnIndex == 22 && e.Value.ToString() == "1")
            {
                e.Value = "Pessoa Jurídica";
            }
        }

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                if (bllUsuario.Sel_Cadastrar_Cliente_Consumidor(_Usuario) == true)
                {
                    using (FrmCadFornecedor Forn = new FrmCadFornecedor(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllFornecedor.Sel_F_Cod(bllFornecedor._Cod_Forn_Cadastro) == null)
                            {
                                dtPesquisa.DataSource = null;
                            }
                            else
                            {
                                dtPesquisa.DataSource = bllFornecedor.Sel_F_Cod(bllFornecedor._Cod_Forn_Cadastro);
                                Forn.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        bllFornecedor._Cod_Forn_Cadastro = null;
                    }
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Fornecedores.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
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
