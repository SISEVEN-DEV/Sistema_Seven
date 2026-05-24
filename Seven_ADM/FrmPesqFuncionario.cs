using BLL;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqFuncionario : Form
    {
        public FrmPesqFuncionario(byte formulario, string usuario, string cod_pdv_computador)
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

        private void FrmPesqFuncionario_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFuncionario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFuncionario iniciado.");
                }
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqFuncionario.");
                }
                this.DialogResult = DialogResult.Abort;
            }
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

        private void rbtnRG_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnRG_MouseLeave(object sender, EventArgs e)
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

        private void rbtnCPF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCPF_MouseLeave(object sender, EventArgs e)
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

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpFuncao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpFuncao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpFuncao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpFuncao_MouseLeave(object sender, EventArgs e)
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

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            cbbpFuncao.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Location = new Point(341, 20);
            lblPesquisar.Text = "Digite o nome:";
            txtpNome.Visible = true;
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpFuncao.Visible = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Location = new Point(581, 20);
            lblPesquisar.Text = "Digite o código:";
            txtpNome.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnRG_CheckedChanged(object sender, EventArgs e)
        {
            cbbpFuncao.Visible = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(512, 20);
            lblPesquisar.Text = "Digite o rg:";
            txtpNome.Visible = false;
            txtpRG.Text = null;
            txtpRG.Select();
        }

        private void rbtnPalavra_CheckedChanged(object sender, EventArgs e)
        {
            cbbpFuncao.Visible = false;
            txtpPalavraChave.Visible = true;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(510, 20);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpNome.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnCPF_CheckedChanged(object sender, EventArgs e)
        {
            cbbpFuncao.Visible = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = true;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(555, 20);
            lblPesquisar.Text = "Digite o cpf:";
            txtpNome.Visible = false;
            mtxtpCPF.Text = null;
            mtxtpCPF.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpNome.Visible = false;
            cbbpFuncao.Visible = false;
            txtpPalavraChave.Visible = false;
            mtxtpCPF.Visible = false;
            txtpRG.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(603, 20);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            if (txtpNome.Text.Contains("'") || txtpNome.Text.Contains(";") || txtpNome.Text.Contains("=") || txtpNome.Text.Contains("-"))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
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
                this.DialogResult = DialogResult.None;
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
                this.DialogResult = DialogResult.None;
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

        private void cbbpFuncao_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Select();
            try
            {
                if (rbtnNome.Checked == true)
                {
                    if (txtpNome.Text.Trim() != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_Nome(txtpNome.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Nome(txtpNome.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_Codigo(txtpCodigo.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Codigo(txtpCodigo.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnPalavra.Checked == true)
                {
                    if (txtpPalavraChave.Text.Trim() != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Palavra_Chave(txtpPalavraChave.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnCPF.Checked == true)
                {
                    mtxtpCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpCPF.Text != "")
                    {
                        mtxtpCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllFuncionario.Sel_Funcionario_CPF(mtxtpCPF.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_CPF(mtxtpCPF.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnRG.Checked == true)
                {
                    if (txtpRG.Text.Trim() != "")
                    {
                        if (bllFuncionario.Sel_Funcionario_RG(txtpRG.Text) == null)
                        {
                            dtFuncionario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;      
                        }
                        else
                        {
                            dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_RG(txtpRG.Text);
                            dtFuncionario.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllFuncionario.Sel_Funcionario_Todos() == null)
                    {
                        dtFuncionario.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Todos();
                        dtFuncionario.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou funcionário.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou funcionário.");
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
                rbtnNome.Checked = true;
                dtFuncionario.DataSource = null;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = true;
                _Contem_Imagem = false;
            }
        }

        private void pcibAjudaFoto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida no ato da alteração de dados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtFuncionario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtFuncionario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtFuncionario.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];
                //
                dtFuncionario.DefaultCellStyle.Font = new Font(dtFuncionario.Font, FontStyle.Bold);
                //
                if (SelectedRow.Cells[18].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFunc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFunc.");
                }
                dtFuncionario.DataSource = null;
                rbtnNome.Checked = true;
                pcibImagem.Image = null;
                lblLegendaImagem.Visible = true;
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

        private void dtFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtFuncionario.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome, código, rg, palavra-chave, cpf e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Contem_Imagem == true)
                {
                    DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtFuncionario.DataSource != null)
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
                    DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                    if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\");
                    }
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[18].Value;
                    string caminho = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                    File.WriteAllBytes(caminho, imagemBytes);
                    Process.Start(caminho);
                }
                else
                {
                    if (dtFuncionario.DataSource != null)
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
        private void dtFuncionario_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFuncionario.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtFuncionario.Enabled = false;
                lblLegendaImagem.Visible = false;
                pcibImagem.Image = null;
                pcibAjudaFoto.Enabled = false;
                _Contem_Imagem = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtFuncionario.Enabled = true;
                pcibAjudaFoto.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibImagem.Enabled = true;
            }
        }

        private void dtFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                    if (_Formulario == 0)
                    {
                        //bllOrcamento._Orc_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        btnIncluir.Select();
                        bllUsuario._User_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 2)
                    {
                        btnIncluir.Select();
                        bllRegistroAtividades._Reg_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 3)
                    {
                        btnIncluir.Select();
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
                        if (SelectedRow.Cells[9].Value.ToString() == "")
                        {
                            MessageBox.Show("O Funcionário selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFuncionario.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[9].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 6)
                    {
                        bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 7)
                    {
                        if (SelectedRow.Cells[8].Value.ToString() == "")
                        {
                            MessageBox.Show("O Funcionário selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFuncionario.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[8].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 8)
                    {
                        bllOS._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 9)
                    {
                        bllOS._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[18].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 10)
                    {
                        bllComissao._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 11)
                    {
                        if (SelectedRow.Cells[8].Value.ToString() == "")
                        {
                            MessageBox.Show("O Funcionário selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFuncionario.Select();
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[8].Value.ToString();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtFuncionario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtFuncionario.");
                    }
                }
            }
        }

        private void dtFuncionario_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                if (_Formulario == 0)
                {
                    //bllOrcamento._Orc_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    bllUsuario._User_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    bllRegistroAtividades._Reg_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    btnIncluir.Select();
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
                    //
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Funcionário selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFuncionario.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 6)
                {
                    bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 7)
                {
                    if (SelectedRow.Cells[8].Value.ToString() == "")
                    {
                        MessageBox.Show("O Funcionário selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFuncionario.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[8].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 8)
                {
                    bllOS._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 9)
                {
                    bllOS._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[18].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 10)
                {
                    bllComissao._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 11)
                {
                    if (SelectedRow.Cells[8].Value.ToString() == "")
                    {
                        MessageBox.Show("O Funcionário selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFuncionario.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[8].Value.ToString();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento doubleclick do dtFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento doubleclick do dtFuncionario.");
                }
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtFuncionario.Rows[dtFuncionario.CurrentRow.Index];

                if (_Formulario == 0)
                {
                    //bllOrcamento._Orc_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    bllUsuario._User_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    bllRegistroAtividades._Reg_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    btnIncluir.Select();
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
                    if (SelectedRow.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("O Funcionário selecionado não possui Email cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFuncionario.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[9].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 6)
                {
                    bllAniversariante._Aniver_PesqFornClieFunc_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 7)
                {
                    if (SelectedRow.Cells[8].Value.ToString() == "")
                    {
                        MessageBox.Show("O Funcionário selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFuncionario.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = SelectedRow.Cells[8].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 8)
                {
                    bllOS._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 9)
                {
                    bllOS._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[18].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 10)
                {
                    bllComissao._Func_PesqFuncionario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 11)
                {
                    if (SelectedRow.Cells[8].Value.ToString() == "")
                    {
                        MessageBox.Show("O Funcionário selecionado não possui Celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtFuncionario.Select();
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllDocumentos._Celular_CadCelular_Tabela = SelectedRow.Cells[8].Value.ToString();
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

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);

            if (dtFuncionario.DataSource != null)
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

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtFuncionario.DataSource != null)
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

        private void dtFuncionario_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtFuncionario.Columns[0].HeaderText = "Código";
            dtFuncionario.Columns[1].HeaderText = "Nome";
            dtFuncionario.Columns[2].HeaderText = "Data de Nascimento";
            dtFuncionario.Columns[3].HeaderText = "CPF";
            dtFuncionario.Columns[4].HeaderText = "RG";
            dtFuncionario.Columns[5].HeaderText = "Sexo";
            dtFuncionario.Columns[6].HeaderText = "Telefone";
            dtFuncionario.Columns[7].HeaderText = "FAX";
            dtFuncionario.Columns[8].HeaderText = "Celular";
            dtFuncionario.Columns[9].HeaderText = "E-mail";
            dtFuncionario.Columns[10].HeaderText = "Endereço";
            dtFuncionario.Columns[11].HeaderText = "Número";
            dtFuncionario.Columns[12].HeaderText = "Complemento";
            dtFuncionario.Columns[13].HeaderText = "Bairro";
            dtFuncionario.Columns[14].HeaderText = "UF";
            dtFuncionario.Columns[15].HeaderText = "Cidade";
            dtFuncionario.Columns[16].HeaderText = "CEP";
            dtFuncionario.Columns[17].HeaderText = "Observações";
            dtFuncionario.Columns[18].Visible = false;
            dtFuncionario.Columns[19].HeaderText = "Palavra-chave";
            dtFuncionario.Columns[20].Visible = false;

            lblRegistros.Text = "Registros: " + dtFuncionario.Rows.Count;

            dtFuncionario.Columns[0].Width = 95;
            dtFuncionario.Columns[1].Width = 325;
            dtFuncionario.Columns[2].Width = 130;
            dtFuncionario.Columns[3].Width = 129;
            dtFuncionario.Columns[4].Width = 154;
            dtFuncionario.Columns[5].Width = 100;
            dtFuncionario.Columns[6].Width = 100;
            dtFuncionario.Columns[7].Width = 100;
            dtFuncionario.Columns[8].Width = 107;
            dtFuncionario.Columns[9].Width = 220;
            dtFuncionario.Columns[10].Width = 280;
            dtFuncionario.Columns[11].Width = 118;
            dtFuncionario.Columns[12].Width = 260;
            dtFuncionario.Columns[13].Width = 280;
            dtFuncionario.Columns[14].Width = 55;
            dtFuncionario.Columns[15].Width = 280;
            dtFuncionario.Columns[16].Width = 76;
            dtFuncionario.Columns[17].Width = 550;
            dtFuncionario.Columns[19].Width = 125;

            dtFuncionario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFuncionario.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dtFuncionario_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void FrmPesqFuncionario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmPesqFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFuncionarios foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFuncionarios foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqFuncionario.");
                }
            }
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
                if (bllUsuario.Sel_Cadastrar_Funcionarios(_Usuario) == true)
                {
                    using (FrmCadFuncionario Func = new FrmCadFuncionario(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (Func.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllFuncionario.Sel_Funcionario_Codigo(bllFuncionario._Cod_Funcionario_Cadastro) == null)
                            {
                                dtFuncionario.DataSource = null;
                            }
                            else
                            {
                                dtFuncionario.DataSource = bllFuncionario.Sel_Funcionario_Codigo(bllFuncionario._Cod_Funcionario_Cadastro);
                                dtFuncionario.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        bllFuncionario._Cod_Funcionario_Cadastro = null;
                    }
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Funcionários.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
