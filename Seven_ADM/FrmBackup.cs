using BLL;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
        }

        string _Caminho;

        private void FrmBackup_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBackup iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBackup iniciado.");
                }
                //
                String strHostName = Environment.MachineName;
                //
                for (int i = 0; i < bllCadastroComputadores.Sel_Nome_Computador_Todos_Cadastro_Computadores().Rows.Count; i++)
                {
                    DataRow dr = bllCadastroComputadores.Sel_Nome_Computador_Todos_Cadastro_Computadores().Rows[i];
                    //
                    if (dr["tipo_computador"].ToString() == "SERVIDOR")
                    {
                        if (dr["nome_computador"].ToString().ToUpper() == strHostName.ToUpper())
                        {
                            chkbArqDir.Checked = true;
                        }
                        else
                        {
                            chkbArqDir.Checked = false;
                        }
                    }
                }
                //
                DriveInfo[] drivers = DriveInfo.GetDrives();
                //
                for (int driv = 0; driv < drivers.Length; driv++)
                {
                    //if (!drivers[driv].IsReady)
                    //{
                    cbbCaminho.Items.Add(drivers[driv]);
                    //}
                    //else
                    //{
                    //    cbbCaminho.Items.Add(drivers[driv].Name + drivers[driv].VolumeLabel);
                    //}
                    //
                }
                //cbbCaminho.Items.RemoveAt(0);
                //
                cbbCaminho.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmBackup.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmBackup.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnIniciar.Select();
            if (cbbCaminho.Text.Trim() == "")
            {
                MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Local ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                cbbCaminho.Select();
            }
            else
            {
                DialogResult = MessageBox.Show("Deseja iniciar o Backup agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    proBProgresso.Visible = true;
                    lblLegenda.Visible = true;
                    _Caminho = cbbCaminho.Text;
                    bckwIndeterminado.RunWorkerAsync();
                    proBProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    btnIniciar.Enabled = false;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    cbbCaminho.Select();
                }
            }
        }

        private void btnOK_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Local: É para onde será salvo o backup do aplicativo.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            bllBackup.RealizarBackupLocal(_Caminho, chkbArqDir.Checked, this);
        }

        private void FrmBackup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void cbbCaminho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIniciar.Select();
            }
        }

        private void cbbCaminho_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCaminho_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCaminho_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCaminho_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                proBProgresso.MarqueeAnimationSpeed = 0;
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
                proBProgresso.Value = 0;
                this.Cursor = Cursors.Default;
                proBProgresso.Visible = false;
                lblLegenda.Visible = false;
                btnIniciar.Enabled = true;
                _Caminho = null;
            }
            else
            {
                try
                {
                    //Carrega todo progressbar.
                    proBProgresso.MarqueeAnimationSpeed = 0;
                    proBProgresso.Value = 100;
                    this.Cursor = Cursors.Default;
                    btnIniciar.Enabled = true;
                    _Caminho = null;
                    MessageBox.Show("Backup realizado com suscesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    proBProgresso.Visible = false;
                    lblLegenda.Visible = false;
                    proBProgresso.Value = 0;
                    this.DialogResult = DialogResult.Abort;
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
                    proBProgresso.Value = 0;
                    this.Cursor = Cursors.Default;
                    proBProgresso.Visible = false;
                    lblLegenda.Visible = false;
                    btnIniciar.Enabled = true;
                    _Caminho = null;
                }
            }
        }

        private void FrmBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBackup foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBackup foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmBackup.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmBackup.");
                }
            }
        }

        private void chkbArqDir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbArqDir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarLocal_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                folder.Description = "Selecione uma Pasta";
                //
                if (folder.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(folder.SelectedPath))
                {
                    cbbCaminho.Items.Clear();
                    //
                    DriveInfo[] drivers = DriveInfo.GetDrives();
                    //
                    for (int driv = 0; driv < drivers.Length; driv++)
                    {
                        //if (!drivers[driv].IsReady)
                        //{
                        cbbCaminho.Items.Add(drivers[driv]);
                        //}
                        //else
                        //{
                        //    cbbCaminho.Items.Add(drivers[driv].Name + drivers[driv].VolumeLabel);
                        //}
                        //
                    }
                    //
                    bool diretorioexiste = false;
                    //
                    for (int i = 0; i < cbbCaminho.Items.Count; i++)
                    {
                        if (cbbCaminho.Items[i].ToString() == folder.SelectedPath)
                        {
                            diretorioexiste = true;
                            break;
                        }
                    }
                    //
                    if (diretorioexiste == false)
                    {
                        cbbCaminho.Items.Add(folder.SelectedPath);
                    }
                    //
                    cbbCaminho.Text = folder.SelectedPath;
                }
            }
        }

        private void btnSelecionarLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarLocal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
