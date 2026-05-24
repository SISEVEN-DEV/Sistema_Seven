using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;
using System.IO.Compression;
using System.Reflection;
using System.Threading;



namespace _7_Sistema_Instalador
{
    public partial class FrmInstalador : Form
    {
        public FrmInstalador()
        {
            InitializeComponent();
        }

        private byte _Estagio = 0;
        //private int _Segundos;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAvancar.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Estagio == 1 & _Estagio == 2)
            {
                DialogResult = MessageBox.Show("Deseja cancelar a instalação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                if (_Estagio == 3 & chkbIniciarADM.Checked == true)
                {
                    try
                    {
                        Process.Start(@"C:\Sistema SEVEN\SEVEN_adm.exe");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Application.Exit();
            }
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if (_Estagio == 0)
            {
                _Estagio = 1;
                lblInformacoescomp1.Visible = false;
                btnVoltar.Enabled = true;
                lblCabecalho1.Text = "Contrato e Licença";
                lblPeqCabecalho1.Visible = true;
                rtxtContLic.Visible = true;
                rbtnAceito.Visible = true;
                rbtnNaoAceito.Visible = true;
                rbtnNaoAceito.Checked = true;
                btnAvancar.Enabled = false;
            }
            else if (_Estagio == 1)
            {
                _Estagio = 2;
                lblInformacoescomp1.Visible = false;
                btnVoltar.Enabled = true;
                lblCabecalho1.Text = "Selecione para instalar os componentes necessários para o funcionamento do software";
                lblPeqCabecalho1.Text = "Componentes:";
                lblPeqCabecalho1.Visible = true;
                rtxtContLic.Visible = false;
                rbtnAceito.Visible = false;
                rbtnNaoAceito.Visible = false;
                chkbFirebird.Visible = true;
                chkbIbexpert.Visible = true;
                chkbNetProvider.Visible = true;
                //
                try
                {
                    ServiceController Service = new ServiceController("FirebirdGuardianDefaultInstance");
                    //
                    if (Service.Status == ServiceControllerStatus.Running)
                    {
                        chkbFirebird.Checked = false;
                    }
                    else
                    {
                        chkbFirebird.Checked = true;
                    }
                }
                catch (InvalidOperationException)
                {
                    chkbFirebird.Checked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //
                if (File.Exists(@"C:\SISEVEN\FirebirdSql.Data.FirebirdClient.dll"))
                {
                    chkbNetProvider.Checked = false;
                }
                else
                {
                    chkbNetProvider.Checked = true;
                }
            }
            else if (_Estagio == 2)
            {
                this.Cursor = Cursors.WaitCursor;
                pgrBarraDeProgresso.Increment(10);
                _Estagio = 3;
                btnVoltar.Enabled = false;
                btnAvancar.Enabled = false;
                lblLegendaIbe.Visible = true;
                pgrBarraDeProgresso.Visible = true;
                lblPeqCabecalho1.Visible = false;
                chkbFirebird.Visible = false;
                chkbIbexpert.Visible = false;
                chkbNetProvider.Visible = false;
                lblCabecalho1.Text = "Instalando software Sistema SEVEN, aguarde...";
                //
                Thread.Sleep(1000);
                if (chkbFirebird.Checked == true)
                {
                    try
                    {
                        Process Processo = new Process();
                        ProcessStartInfo Starting = new ProcessStartInfo();
                        //
                        if (Environment.Is64BitOperatingSystem == true)
                        {
                            if (!Directory.Exists(@"C:\Sistema SEVEN"))
                            {
                                Directory.CreateDirectory(@"C:\Sistema SEVEN");
                            }
                            //
                            var diretorios = Directory.GetDirectories(@"files\firebird\firebird64", "*", SearchOption.AllDirectories);
                            //
                            foreach (string diretorio in diretorios)
                            {
                                string diretorioAcriar = diretorio.Replace(@"files\firebird\firebird64", @"C:\Sistema SEVEN\firebird64");
                                //
                                Directory.CreateDirectory(diretorioAcriar);
                            }
                            //
                            var todosArquivos = Directory.GetFiles(@"files\firebird\firebird64", "*", SearchOption.AllDirectories);
                            //
                            foreach (string arquivo in todosArquivos)
                            {
                                File.Copy(arquivo, arquivo.Replace(@"files\firebird\", @"C:\Sistema SEVEN\"), true);
                            }
                            //
                            Starting.FileName = @"C:\Windows\system32\cmd.exe";
                            Starting.Verb = "runas";
                            Starting.Arguments = @"/C (CD C:\Sistema SEVEN\firebird64\bin)&(install_super.bat)";
                            //MessageBox.Show(   @"/K (CD C:\Program Files\Firebird\Firebird_2_5\bin)&(gsec -user sysdba -password masterkey)&(modify sysdba -pw 7sysgod)");
                            Processo.StartInfo = Starting;
                            Starting.UseShellExecute = true;
                            Processo.Start();
                            Processo.WaitForExit();
                        }
                        else
                        {
                            if (!Directory.Exists(@"C:\Sistema SEVEN"))
                            {
                                Directory.CreateDirectory(@"C:\Sistema SEVEN");
                            }
                            //
                            var diretorios = Directory.GetDirectories(@"files\firebird\firebird32", "*", SearchOption.AllDirectories);
                            //
                            foreach (string diretorio in diretorios)
                            {
                                string diretorioAcriar = diretorio.Replace(@"files\firebird\firebird32", @"C:\Sistema SEVEN\firebird32");
                                //
                                Directory.CreateDirectory(diretorioAcriar);
                            }
                            //
                            var todosArquivos = Directory.GetFiles(@"files\firebird\firebird32", "*", SearchOption.AllDirectories);
                            //
                            foreach (string arquivo in todosArquivos)
                            {
                                File.Copy(arquivo, arquivo.Replace(@"files\firebird\", @"C:\Sistema SEVEN\"), true);
                            }
                            //
                            Starting.FileName = @"C:\Windows\system32\cmd.exe";
                            Starting.Verb = "runas";
                            Starting.Arguments = @"/C (CD C:\Sistema SEVEN\firebird32\bin)&(install_super.bat)";
                            //MessageBox.Show(   @"/K (CD C:\Program Files\Firebird\Firebird_2_5\bin)&(gsec -user sysdba -password masterkey)&(modify sysdba -pw 7sysgod)");
                            Processo.StartInfo = Starting;
                            Starting.UseShellExecute = true;
                            Processo.Start();
                            Processo.WaitForExit();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //
                Thread.Sleep(1000);
                //
                pgrBarraDeProgresso.Increment(30);
                //
                if (chkbNetProvider.Checked == true)
                {
                    try
                    {
                        if (!Directory.Exists(@"C:\Sistema SEVEN"))
                        {
                            Directory.CreateDirectory(@"C:\Sistema SEVEN");
                        }
                        //
                        var diretorios = Directory.GetDirectories(@"files\firebirdclient", "*", SearchOption.AllDirectories);
                        //
                        foreach (string diretorio in diretorios)
                        {
                            string diretorioAcriar = diretorio.Replace(@"files\firebirdclient", @"C:\Sistema SEVEN");
                            //
                            Directory.CreateDirectory(diretorioAcriar);
                        }
                        //
                        var todosArquivos = Directory.GetFiles(@"files\firebirdclient\", "*", SearchOption.AllDirectories);
                        //
                        foreach (string arquivo in todosArquivos)
                        {
                            File.Copy(arquivo, arquivo.Replace(@"files\firebirdclient\", @"C:\Sistema SEVEN\"), true);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //
                Thread.Sleep(1000);
                pgrBarraDeProgresso.Increment(30);
                //
                if (chkbIbexpert.Checked == true)
                {
                    try
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = @"files\IbExpert_edition.exe";
                        startInfo.UseShellExecute = false;
                        //
                        Process processo = new Process();
                        processo.StartInfo = startInfo;
                        processo.Start();
                        // 
                        processo.WaitForExit();
                        //
                        var todosArquivos = Directory.GetFiles(@"files\firebirdclientlibrary\system32", "*", SearchOption.AllDirectories);
                        //
                        foreach (string arquivo in todosArquivos)
                        {
                            File.Copy(arquivo, arquivo.Replace(@"files\firebirdclientlibrary\system32", @"C:\Windows\System32"), true);
                        }
                        //
                        if (Environment.Is64BitOperatingSystem == true)
                        {
                            todosArquivos = Directory.GetFiles(@"files\firebirdclientlibrary\syswow64", "*", SearchOption.AllDirectories);
                            //
                            foreach (string arquivo in todosArquivos)
                            {
                                File.Copy(arquivo, arquivo.Replace(@"files\firebirdclientlibrary\syswow64", @"C:\Windows\SysWOW64"), true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //
                Thread.Sleep(1000);
                pgrBarraDeProgresso.Increment(20);
                //
                try
                {
                    pgrBarraDeProgresso.Increment(55);
                    if (!Directory.Exists(@"C:\Sistema SEVEN"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN");
                    }
                    //
                    var diretorios1 = Directory.GetDirectories(@"files\Sistema SEVEN", "*", SearchOption.AllDirectories);
                    //
                    foreach (string diretorio in diretorios1)
                    {
                        string diretorioAcriar = diretorio.Replace(@"files\Sistema SEVEN", @"C:\Sistema SEVEN");
                        //
                        Directory.CreateDirectory(diretorioAcriar);
                    }
                    //
                    var todosArquivos1 = Directory.GetFiles(@"files\Sistema SEVEN", "*", SearchOption.AllDirectories);
                    //
                    foreach (string arquivo in todosArquivos1)
                    {
                        File.Copy(arquivo, arquivo.Replace(@"files\", @"C:\"), true);
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos");
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios");
                    }
                    //
                    if (Directory.Exists(@"C:\Users\" + Environment.UserName + @"\Desktop"))
                    {
                        Process Proc = new Process();
                        ProcessStartInfo Start = new ProcessStartInfo();
                        Start.FileName = @"C:\Windows\system32\cmd.exe";
                        //MessageBox.Show(@"/K (mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\Desktop\Sistema SEVEN - ADM" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_ADM.exe" + "\"" + ")&(mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\OneDrive\Desktop\Sistema SEVEN - PDV" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_PDV.exe" + "\"" + ")");
                        Start.Arguments = @"/C (mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\Desktop\Sistema SEVEN" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_ADM.exe" + "\"" + ")&(mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\Desktop\Sistema SEVEN - PDV" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_PDV.exe" + "\"" + ")";
                        Proc.StartInfo = Start;
                        Start.UseShellExecute = true;
                        Proc.Start();
                    }
                    else if (Directory.Exists(@"C:\Users\" + Environment.UserName + @"\OneDrive\Área de Trabalho"))
                    {
                        Process Proc = new Process();
                        ProcessStartInfo Start = new ProcessStartInfo();
                        Start.FileName = @"C:\Windows\system32\cmd.exe";
                        //MessageBox.Show(@"/K (mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\OneDrive\Área de Trabalho\Sistema SEVEN - ADM" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_ADM.exe" + "\"" + ")&(mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\OneDrive\Área de Trabalho\Sistema SEVEN - PDV" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_PDV.exe" + "\"" + ")");
                        Start.Arguments = @"/C (mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\OneDrive\Área de Trabalho\Sistema SEVEN" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_ADM.exe" + "\"" + ")&(mklink " + "\"" + @"C:\Users\" + Environment.UserName + @"\OneDrive\Área de Trabalho\Sistema SEVEN - PDV" + "\"" + " " + "\"" + @"C:\Sistema SEVEN\Seven_PDV.exe" + "\"" + ")";
                        Proc.StartInfo = Start;
                        Start.UseShellExecute = true;
                        Proc.Start();
                        //
                        pgrBarraDeProgresso.Increment(100);
                        Thread.Sleep(1000);
                        this.Cursor = Cursors.Default;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                }
                //
                lblCabecalho1.Text = "Instalação Completa";
                pgrBarraDeProgresso.Visible = false;
                btnVoltar.Visible = false;
                lblLegendaIbe.Visible = false;
                btnAvancar.Visible = false;
                btnCancelar.Text = "&Concluir";
                btnCancelar.Location = new Point(403, 42);
                lblPeqCabecalho1.Visible = true;
                lblPeqCabecalho1.Text = "O Instalador concluiu a instalação do Sistema SEVEN em seu computador. O aplicativo já pode ser iniciado clicando nos atalhos gerados na área de trabalho.\n\n\nClique em concluir para finalizar o instalador.";
                chkbIniciarADM.Visible = true;
                chkbIniciarADM.Checked = true;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (_Estagio == 1)
            {
                _Estagio = 0;
                lblInformacoescomp1.Visible = true;
                btnVoltar.Enabled = false;
                lblCabecalho1.Text = "Bem-vindo ao assistente de instalação do software Sistema SEVEN";
                lblPeqCabecalho1.Visible = false;
                rtxtContLic.Visible = false;
                rbtnAceito.Visible = false;
                rbtnNaoAceito.Visible = false;
                btnAvancar.Enabled = true;
            }
            else if (_Estagio == 2)
            {
                _Estagio = 1;
                lblInformacoescomp1.Visible = false;
                btnVoltar.Enabled = true;
                lblCabecalho1.Text = "Contrato e Licença";
                lblPeqCabecalho1.Text = "Leia atentamente o contrato de licença:";
                lblPeqCabecalho1.Visible = true;
                rtxtContLic.Visible = true;
                rbtnAceito.Visible = true;
                rbtnNaoAceito.Checked = true;
                rbtnNaoAceito.Visible = true;
                chkbFirebird.Visible = false;
                chkbIbexpert.Visible = false;
                chkbNetProvider.Visible = false;
            }
            else if (_Estagio == 3)
            {
                _Estagio = 2;
                pgrBarraDeProgresso.Visible = false;
                lblInformacoescomp1.Visible = false;
                btnVoltar.Enabled = true;
                lblCabecalho1.Text = "Selecione para instalar os componentes necessários para o funcionamento do software";
                lblPeqCabecalho1.Text = "Componentes:";
                lblPeqCabecalho1.Visible = true;
                rtxtContLic.Visible = false;
                rbtnAceito.Visible = false;
                rbtnNaoAceito.Visible = false;
                chkbFirebird.Visible = true;
                chkbIbexpert.Visible = true;
                chkbNetProvider.Visible = true;
            }
        }

        private void chkbFirebird_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbFirebird_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbIbexpert_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbIbexpert_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnAceito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnAceito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNaoAceito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNaoAceito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Estagio == 1 || _Estagio == 2)
                {
                    DialogResult = MessageBox.Show("Deseja cancelar a instalação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    if (_Estagio == 3 & chkbIniciarADM.Checked == true)
                    {
                        try
                        {
                            Process.Start(@"C:\Sistema SEVEN\SEVEN_adm.exe");
                        }
                        catch (Exception ex) 
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    Application.Exit();
                }
            }
        }

        private void rbtnAceito_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAceito.Checked == true)
            {
                btnAvancar.Enabled = true;
            }
        }

        private void rbtnNaoAceito_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNaoAceito.Checked == true)
            {
                btnAvancar.Enabled = false;
            }
        }

        private void chkbNetProvider_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbNetProvider_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbIniciarADM_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbIniciarADM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblSiseven_MouseMove(object sender, MouseEventArgs e)
        {
            lblSiseven.ForeColor = Color.Blue;
            lblSiseven.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            this.Cursor = Cursors.Hand;
        }

        private void lblSiseven_MouseLeave(object sender, EventArgs e)
        {
            lblSiseven.ForeColor = Color.Black;
            lblSiseven.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblSiseven_Click(object sender, EventArgs e)
        {
            Process.Start("www.siseven.com.br");
        }

        private void FrmInstalador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(@"C:\Windows\Temp\sevenarqsenha.bat"))
            {
                File.Delete(@"C:\Windows\Temp\sevenarqsenha.bat");
            }
        }

        private void chkbFirebird_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkbFirebird.Checked == true)
                {
                    ServiceController Service = new ServiceController("FirebirdGuardianDefaultInstance");
                    //
                    if (Service.Status == ServiceControllerStatus.Running)
                    {
                        MessageBox.Show("Um ou mais serviços do Firebird já estão rodando, é necessário desinstalar ou parar o serviço atual.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chkbFirebird.Checked = false;
                    }
                    else
                    {
                        chkbFirebird.Checked = true;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                chkbFirebird.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTelzap_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://wa.me/5575982716595?text=Ol%C3%A1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
            }
        }

        private void lblTelzap_MouseMove(object sender, MouseEventArgs e)
        {
            lblTelzap.ForeColor = Color.Blue;
            lblTelzap.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            this.Cursor = Cursors.Hand;
        }

        private void lblTelzap_MouseLeave(object sender, EventArgs e)
        {
            lblTelzap.ForeColor = Color.Black;
            lblTelzap.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }
    }
}
