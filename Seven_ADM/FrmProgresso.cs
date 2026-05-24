using BLL;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmProgresso : Form
    {
        public FrmProgresso(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;
        private bool _Finalizou = false;
        private int _Tempo = 0;

        private void FrmProgresso_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmProgresso iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmProgresso iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    this.Text = "Atualização do Software";
                    lblLegenda.Text = "Atualizando, por favor, aguarde...";
                    pcibMega.Visible = false;
                    lblMegaLink.Visible = false;
                    lblBackupMega.Visible = false;
                }
                else if(_Formulario == 2)
                {
                    tTimer.Start();
                    this.Text = "Backup do Software";
                    lblLegenda.Text = "Realizando Backup na nuvem, por favor, aguarde...";
                    ttpAtualizacao.SetToolTip(btnSair, "Sair do Backup do Software.");
                    pcibMega.Visible = true;
                    lblMegaLink.Visible = true;
                    lblBackupMega.Visible = true;
                }
                else if(_Formulario == 1)
                {
                    tTimer.Start();
                    this.Text = "Backup do Software";
                    lblLegenda.Text = "Realizando Backup na nuvem, por favor, aguarde... O seu sistema será finalizado.";
                    ttpAtualizacao.SetToolTip(btnSair, "Sair do Backup do Software.");
                    pcibMega.Visible = true;
                    lblMegaLink.Visible = true;
                    lblBackupMega.Visible = true;
                }
                //
                bckwIndeterminado.RunWorkerAsync();
                pgbProgresso.MarqueeAnimationSpeed = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmProgresso.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmProgresso.");
                }
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

        private void FrmProgresso_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Finalizou == false)
                {
                    if (_Formulario == 0)
                    {
                        MessageBox.Show("Atualizações em andamento. Aguarde enquanto concluímos o processo...", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //
                        if (_Finalizou == true)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else if(_Formulario == 1 || _Formulario == 2)
                    {
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmProgresso foi finalizado.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmProgresso foi finalizado.");
                        }
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmProgresso foi finalizado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmProgresso foi finalizado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmProgresso.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmProgresso.");
                }
            }
        }

        private void FrmProgresso_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
        }

        private void FrmProgresso_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblLegenda3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
        }

        private void lblLegenda3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
        }

        private void progressBar1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Formulario == 0)
            {
                bllVersao.LimparArquivosRecebidos();
                //
                if (bllVersao.VerificarAtualizacoesSQLOperation() == true)
                {
                    bllVersao.BaixarAtualizacoesSQLOperation();
                }
                //
                if (bllVersao.VerificarAtualizacoesSQLSeven() == true)
                {
                    bllVersao.BaixarAtualizacoesSQLSeven();
                }
                //
                if (bllVersao.VerificarAtualizacoesIBPT() == true)
                {
                    bllVersao.BaixarAtualizacoesIBPT();
                }
                //
                if (bllVersao.VerificarAtualizacoesSeven_Adm() == true)
                {
                    bllVersao.BaixarAtualizacoesSeven_Adm();
                }
                //
                if (bllVersao.VerificarAtualizacoesSeven_Pdv() == true)
                {
                    bllVersao.BaixarAtualizacoesSeven_Pdv();
                }
                //
                if (bllVersao.VerificarAtualizacoesBLL() == true)
                {
                    bllVersao.BaixarAtualizacoesBLL();
                }
                //
                if (bllVersao.VerificarAtualizacoesDAL() == true)
                {
                    bllVersao.BaixarAtualizacoesDAL();
                }
                //
                if (bllVersao.VerificarAtualizacoesSeven_Config() == true)
                {
                    bllVersao.BaixarAtualizacoesSeven_Config();
                }
                //
                if (bllVersao.VerificarAtualizacoesACBR_Lib() == true)
                {
                    bllVersao.BaixarAtualizacoes_ACBR_Lib();
                }
                //
                if (bllVersao.VerificarAtualizacoesConfig() == true)
                {
                    bllVersao.BaixarAtualizacoes_Config();
                }
                //
                if (bllVersao.VerificarAtualizacoesSistemaSeven() == true)
                {
                    bllVersao.BaixarAtualizacoes_Sistema_Seven();
                }
            }
            else if (_Formulario == 1 || _Formulario == 2)
            {
                bllBackup.RealizarBackupFbkRede(this);
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                if (_Formulario == 0)
                {
                    MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (_Formulario == 1 || _Formulario == 2)
                {
                    MessageBox.Show("Falha no backup: " + e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //    
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                //
                if (_Formulario == 0)
                {
                    pgbProgresso.Value = 0;
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    _Finalizou = true;
                    this.DialogResult = DialogResult.Abort;
                }
                else if (_Formulario == 1 || _Formulario == 2)
                {
                    pgbProgresso.Value = 0;
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    _Finalizou = true;
                    this.DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                _Finalizou = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmProgresso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void tTimer_Tick(object sender, EventArgs e)
        {
            if (_Tempo == 180)
            {
                this.DialogResult = DialogResult.Abort;
            }
            //
            _Tempo = _Tempo + 1;
        }

        private void lblSiseven_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://mega.io/pt-br/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblSiseven.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblSiseven.");
                }
            }
        }
    }
}
