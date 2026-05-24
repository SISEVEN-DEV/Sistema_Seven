using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Seven_Sistema
{
    public partial class FrmInfImpressao : Form
    {
        public FrmInfImpressao(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        //bool _Possui_Configuracoes;
        byte _Formulario;

        private void FrmInfImpressao_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao iniciado.");
                }
                //
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cbbImpressoras.Items.Add(printer);
                }
                //
                if (_Formulario == 0)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 1)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 2)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 3)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 4)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 5)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                else if (_Formulario == 6)
                {
                    cbbImpressoras.Items.Clear();
                    cbbImpressoras.Items.Add("PADRÃO");
                    cbbImpressoras.Text = "PADRÃO";
                    cbbTipoImpressao.Items.Clear();
                    cbbTipoImpressao.Items.Add("PDF A4");
                    cbbTipoImpressao.Items.Add("PDF Impressora Térmica(80mm)");
                    cbbTipoImpressao.Text = "PDF A4";
                    cbbTipoImpressao.Select();
                }
                /*
                if (bllPreferencia_Usuario.Sel_Tabela_InfImpressaoOrc_Configuracoes() == null)
                {
                    _Possui_Configuracoes = false;
                    cbbTipoImpressao.Select();
                }
                else
                {
                    _Possui_Configuracoes = true;
                    DataRow dr = bllPreferencia_Usuario.Sel_Tabela_InfImpressaoOrc_Configuracoes().Rows[0];
                    cbbTipoImpressao.Text = dr["tipo_imp"].ToString();
                    //
                    cbbImpressoras.Text = dr["nome_impressora"].ToString();
                    //
                    txtNCopia.Text = dr["numero_copia"].ToString();
                    //
                    if (Convert.ToByte(dr["mostrar_logo_imp"]) == 1)
                    {
                        chkbMostrarLogo.Checked = true;
                    }
                    else
                    {
                        chkbMostrarLogo.Checked = false;
                    }
                    //
                    btnImprimir.Select();
                }
                ´*/
                //               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInfImpressao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmInfImpressao.");
                }
            }
        }

        private void cbbImpressoras_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImpressoras_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImpressoras_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImpressoras_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNCopia_Enter(object sender, EventArgs e)
        {
            txtNCopia.BackColor = Color.LightBlue;
        }

        private void txtNCopia_Leave(object sender, EventArgs e)
        {
            if (txtNCopia.Text.Contains("'") || txtNCopia.Text.Contains(";") || txtNCopia.Text.Contains("=") || txtNCopia.Text.Contains("-"))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNCopia.Text = null;
                txtNCopia.Select();
            }
            if (txtNCopia.Text == "0")
            {
                MessageBox.Show("Valor não permitido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtNCopia.Text = null;
                txtNCopia.Select();
            }
            txtNCopia.BackColor = Color.White;
        }

        private void txtNCopia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnImprimir.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void FrmInfImpressao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmInfImpressao_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao foi finalizado.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmInfImpressao foi finalizado.");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                btnImprimir.Select();
                if (_Formulario == 0)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Tipo de impressão ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasReceber._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasReceber._Impressora = cbbImpressoras.Text;
                        bllContasReceber._Numero_Copias = txtNCopia.Text;
                        bllContasReceber._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 1)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Tipo de impressão ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllContasReceber._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllContasReceber._Impressora = cbbImpressoras.Text;
                        bllContasReceber._Numero_Copias = txtNCopia.Text;
                        bllContasReceber._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 2)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Tipo de impressão ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllHistCaixa._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllHistCaixa._Impressora = cbbImpressoras.Text;
                        bllHistCaixa._Numero_Copias = txtNCopia.Text;
                        bllHistCaixa._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 3)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Tipo de impressão ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllSangriaSuprimento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllSangriaSuprimento._Impressora = cbbImpressoras.Text;
                        bllSangriaSuprimento._Numero_Copias = txtNCopia.Text;
                        bllSangriaSuprimento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 4)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Tipo de impressão ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllAbert_Fech_Caixa._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllAbert_Fech_Caixa._Impressora = cbbImpressoras.Text;
                        bllAbert_Fech_Caixa._Numero_Copias = txtNCopia.Text;
                        bllAbert_Fech_Caixa._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 5)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Tipo de impressão ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllOrcamento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOrcamento._Impressora = cbbImpressoras.Text;
                        bllOrcamento._Numero_Copias = txtNCopia.Text;
                        bllOrcamento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 6)
                {
                    if (cbbTipoImpressao.Text == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Tipo de impressão ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoImpressao.Select();
                    }
                    else
                    {
                        bllHistCaixa._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllHistCaixa._Impressora = cbbImpressoras.Text;
                        bllHistCaixa._Numero_Copias = txtNCopia.Text;
                        bllHistCaixa._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                /*
                if (((cbbTipoImpressao.SelectedIndex == 0 || cbbTipoImpressao.SelectedIndex == 1 || cbbTipoImpressao.SelectedIndex == 2 || cbbTipoImpressao.SelectedIndex == 3) & cbbImpressoras.Text == "") || txtNCopia.Text.Trim() == "" || cbbTipoImpressao.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n([ Tipo de impressão orçamento ] e [ Imprimir em ]) e [ Numero de cópias ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    cbbTipoImpressao.Select();
                }
                else
                {

                        bllOrcamento._Tipo_Impressao = cbbTipoImpressao.Text;
                        bllOrcamento._Impressora = cbbImpressoras.Text;
                        bllOrcamento._Numero_Copias = txtNCopia.Text;
                        bllOrcamento._Mostrar_Logo_Marca_Imp = chkbMostrarLogo.Checked;
                        if (_Possui_Configuracoes == false)
                        {
                        //    bllPreferencia_Usuario.Salvar_InfImpressaoOrc(cbbTipoImpressao.Text, cbbImpressoras.Text, chkbMostrarLogo.Checked, txtNCopia.Text.Trim());
                        }
                        else
                        {
                          //  bllPreferencia_Usuario.Alterar_InfImpressaoOrc(cbbTipoImpressao.Text, cbbImpressoras.Text, chkbMostrarLogo.Checked, txtNCopia.Text.Trim());
                        }
                        this.DialogResult = DialogResult.OK;

                }           
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImprimir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImprimir.");
                }
                cbbImpressoras.Text = null;
                cbbTipoImpressao.Text = null;
                txtNCopia.Text = null;
                chkbMostrarLogo.Checked = false;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void cbbTipoImpressao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpressao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpressao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpressao_DropDownClosed(object sender, EventArgs e)
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

        private void cbbTipoImpressao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbImpressoras.Enabled == true)
                {
                    cbbImpressoras.Select();
                }
                else
                {
                    if (txtNCopia.Enabled == true)
                    {
                        txtNCopia.Select();
                    }
                    else
                    {
                        btnImprimir.Select();
                    }
                }
            }
        }

        private void cbbImpressoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtNCopia.Enabled == true)
                {
                    txtNCopia.Select();
                }
                else
                {
                    btnImprimir.Select();
                }
            }
        }

        private void chkbMostrarLogo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarLogo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Tipo de impressão de orçamento: É o estilo em que o orçamento será impresso na impressora selecionada.\n2 - Imprimir em: É onde o usuário seleciona a impressora em que o orçamento será impresso.\n3 - Numero de cópias: QUantidade de folhas que vão ser impressas pelo sistema.\n4 - Mostrar logo-marca nas impressões: Para mostrar a logo-marca configurada na impressão do orçamento, selecione esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbTipoImpressao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 1)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 2)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 3)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 4)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 5)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
            else if (_Formulario == 6)
            {
                if (cbbTipoImpressao.SelectedIndex == 0)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
                else if (cbbTipoImpressao.SelectedIndex == 1)
                {
                    cbbImpressoras.Enabled = true;
                    lblImp.Enabled = true;
                    lblAsterisco1.Enabled = true;
                    lblNumCopia.Enabled = false;
                    txtNCopia.Enabled = false;
                    txtNCopia.Text = "0";
                    lblAsterisco2.Enabled = false;
                }
            }
        }
    }
}
