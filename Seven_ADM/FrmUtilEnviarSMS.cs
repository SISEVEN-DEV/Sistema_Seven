using BLL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmUtilEnviarSMS : Form
    {
        public FrmUtilEnviarSMS(byte formulario, string cod_pdv_computador, string usuario, string mensagem, string celular)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Usuario = usuario;
            _Mensagem = mensagem;
            _Celular = celular;
        }

        byte _Formulario;
        private string _Cod_PDV_Computador;
        private string _Usuario;
        private string _Mensagem;
        private string _Porta;
        private string _Celular;

        private void FrmUtilEnviarSMS_Load(object sender, EventArgs e)
        {
            try
            {
                bllEnviarSMS._FrmUtilEnviarSMS_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilEnviarSMS iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilEnviarSMS iniciado.");
                }
                //
                if (_Formulario == 1)
                {
                    txtPara.Text = _Celular;
                    txtMsg.Text = _Mensagem;
                }
                //
                if (bllSMS.Sel_Porta_SMS(bllConexao._Codigo_Conexao) != null)
                {
                    cbbPorta.Text = bllSMS.Sel_Porta_SMS(bllConexao._Codigo_Conexao);
                }
                //
                cbbPorta.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmutilEnviarSMS.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmutilEnviarSMS.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void pcibAnexo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAnexo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviar_MouseLeave(object sender, EventArgs e)
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

        private void FrmUtilEnviarSMS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmUtilEnviarSMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmutilEnviarSMS foi finalizado.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmutilEnviarSMS foi finalizado.");
                }
                bllEnviarSMS._FrmUtilEnviarSMS_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmutilEnviarSMS.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmutilEnviarSMS.");
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtPara.Text == "" || txtMsg.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Para ] e [ Mensagem ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                _Porta = cbbPorta.Text;
                grbBox1.Enabled = false;
                pgbProgresso.Visible = true;
                lblProgresso.Visible = true;
                bckwIndeterminado.RunWorkerAsync();
                pgbProgresso.MarqueeAnimationSpeed = 2;
                this.Cursor = Cursors.WaitCursor;
            }
        }

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Porta: Porta onde está localizado o modem.\n\n2 - Celular: Digite o numero do celular que você deseja enviar o sms ou adicione vários números.\n\n3 - Mensagem: Digite neste campo o conteúdo do SMS.\n\n4 - Enviar: Clique para enviar o SMS.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] items = txtPara.Text.Split(';');

            for (int i = 0; i < items.Length; i++)
            {
                SerialPort Port = new SerialPort();
                Port.PortName = _Porta;
                Port.Open();
                Port.Write("AT" + Environment.NewLine);
                Thread.Sleep(100);
                Port.Write("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                Port.Write("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                Port.Write("AT+CMGS=\"" + items[i].Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "") + "\"" + Environment.NewLine);
                Thread.Sleep(100);
                Port.Write(txtMsg.Text);
                Thread.Sleep(100);
                Port.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                MessageBox.Show(Port.ReadExisting(), "Detalhe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                if (Port.ReadExisting().Contains("ERROR"))
                {
                    MessageBox.Show("Mensagem não enviada para: " + items[i] + "\n\nStatus: 0.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Mensagem enviada com sucesso para: " + items[i] + "\n\nStatus: 1.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Port.Close();
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
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
                grbBox1.Enabled = true;
                //
                pgbProgresso.Value = 0;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                this.Cursor = Cursors.Default;
                txtMsg.Select();
            }
            else
            {
                grbBox1.Enabled = true;
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;

                try
                {
                    if (_Formulario == 0)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE SMS", "SMS", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    else if (_Formulario == 1)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE E-MAIL DE UM ANIVERSARIANTE", "EMAIL", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    //
                    if (bllSMS.Sel_Porta_SMS(bllConexao._Codigo_Conexao) == null)
                    {
                        bllSMS.Salvar(cbbPorta.Text, bllConexao._Codigo_Conexao);
                    }
                    else if (bllSMS.Sel_Porta_SMS(bllConexao._Codigo_Conexao) != cbbPorta.Text)
                    {
                        bllSMS.Alterar(cbbPorta.Text, bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        bllSMS.Salvar(cbbPorta.Text, bllConexao._Codigo_Conexao);
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
                    grbBox1.Enabled = true;
                    pgbProgresso.MarqueeAnimationSpeed = 0;
                    pgbProgresso.Value = 100;
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                }
            }
        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + txtMsg.Text.Length + "/160";
        }

        private void txtMsg_Enter(object sender, EventArgs e)
        {
            txtMsg.BackColor = Color.LightBlue;
        }

        private void txtMsg_Leave(object sender, EventArgs e)
        {
            txtMsg.BackColor = Color.White;
        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            using (FrmPesqCliente Clie = new FrmPesqCliente(11, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] items = txtPara.Text.Split(';');
                        //
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i] == bllSMS._Destinatario_SMS)
                            {
                                MessageBox.Show("O Celular já foi informado anteriormente \nno campo [ Para ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllSMS._Destinatario_SMS = null;
                                return;
                            }
                        }
                        //
                        if (txtPara.Text == "")
                        {
                            txtPara.Text = bllSMS._Destinatario_SMS;
                        }
                        else
                        {
                            txtPara.Text = txtPara.Text + ";" + bllSMS._Destinatario_SMS;
                        }
                        bllSMS._Destinatario_SMS = null;
                        txtPara.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                    }
                }
            }
        }

        private void btnPesquisarForn_Click(object sender, EventArgs e)
        {
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(8, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] items = txtPara.Text.Split(';');
                        //
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i] == bllSMS._Destinatario_SMS)
                            {
                                MessageBox.Show("O Celular já foi informado anteriormente \nno campo [ Para ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllSMS._Destinatario_SMS = null;
                                return;
                            }
                        }
                        //
                        if (txtPara.Text == "")
                        {
                            txtPara.Text = bllSMS._Destinatario_SMS;
                        }
                        else
                        {
                            txtPara.Text = txtPara.Text + ";" + bllSMS._Destinatario_SMS;
                        }
                        bllSMS._Destinatario_SMS = null;
                        txtPara.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarForn.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarForn.");
                        }
                        bllSMS._Destinatario_SMS = null;
                    }
                }
            }
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            using (FrmPesqFuncionario Func = new FrmPesqFuncionario(7, _Usuario, _Cod_PDV_Computador))
            {
                if (Func.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] items = txtPara.Text.Split(';');
                        //
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i] == bllSMS._Destinatario_SMS)
                            {
                                MessageBox.Show("O Celular já foi informado anteriormente \nno campo [ Para ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllSMS._Destinatario_SMS = null;
                                return;
                            }
                        }
                        //
                        if (txtPara.Text == "")
                        {
                            txtPara.Text = bllSMS._Destinatario_SMS;
                        }
                        else
                        {
                            txtPara.Text = txtPara.Text + ";" + bllSMS._Destinatario_SMS;
                        }
                        bllSMS._Destinatario_SMS = null;
                        txtPara.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFuncionario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFuncionario.");
                        }
                        bllSMS._Destinatario_SMS = null;
                    }
                }
            }
        }

        private void cbbPorta_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPorta_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPorta_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPorta_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCliente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarForn_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisarForn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtCelular_Enter(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.LightBlue;
        }

        private void mtxtCelular_Leave(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.White;
        }

        private void mtxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPara.Select();
            }
        }

        private void txtPara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMsg.Select();
            }
        }

        private void cbbPorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtCelular.Select();
            }
        }

        private void btnAdicionarManual_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCelular.Text != "")
                {
                    mtxtCelular.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    string[] items = txtPara.Text.Split(';');
                    //
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i] == mtxtCelular.Text)
                        {
                            MessageBox.Show("O Celular já foi informado anteriormente \nno campo [ Para ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mtxtCelular.Text = null;
                            return;
                        }
                    }
                    //
                    if (txtPara.Text == "")
                    {
                        txtPara.Text = mtxtCelular.Text;
                    }
                    else
                    {
                        txtPara.Text = txtPara.Text + ";" + mtxtCelular.Text;
                    }
                    //
                    mtxtCelular.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                }
                mtxtCelular.Text = null;
            }
        }

        private void txtPara_Enter(object sender, EventArgs e)
        {
            txtPara.BackColor = Color.LightBlue;
        }

        private void txtPara_Leave(object sender, EventArgs e)
        {
            txtPara.BackColor = Color.White;
        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEnviar.Select();
            }
        }
    }
}
