namespace Seven_Sistema
{
    partial class FrmBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBackup));
            this.proBProgresso = new System.Windows.Forms.ProgressBar();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelecionarLocal = new System.Windows.Forms.Button();
            this.cbbCaminho = new System.Windows.Forms.ComboBox();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.ttpIniciarBackup = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.chkbArqDir = new System.Windows.Forms.CheckBox();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // proBProgresso
            // 
            this.proBProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.proBProgresso.Location = new System.Drawing.Point(12, 111);
            this.proBProgresso.Name = "proBProgresso";
            this.proBProgresso.Size = new System.Drawing.Size(337, 23);
            this.proBProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.proBProgresso.TabIndex = 0;
            this.proBProgresso.Visible = false;
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnSelecionarLocal);
            this.grbBox1.Controls.Add(this.cbbCaminho);
            this.grbBox1.Controls.Add(this.lblCaminho);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(335, 40);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Copiar para:";
            // 
            // btnSelecionarLocal
            // 
            this.btnSelecionarLocal.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarLocal.Image")));
            this.btnSelecionarLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarLocal.Location = new System.Drawing.Point(303, 11);
            this.btnSelecionarLocal.Name = "btnSelecionarLocal";
            this.btnSelecionarLocal.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarLocal.TabIndex = 3;
            this.btnSelecionarLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIniciarBackup.SetToolTip(this.btnSelecionarLocal, "Clique para selecionar um local específico.");
            this.btnSelecionarLocal.UseVisualStyleBackColor = true;
            this.btnSelecionarLocal.Click += new System.EventHandler(this.btnSelecionarLocal_Click);
            this.btnSelecionarLocal.MouseLeave += new System.EventHandler(this.btnSelecionarLocal_MouseLeave);
            this.btnSelecionarLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarLocal_MouseMove);
            // 
            // cbbCaminho
            // 
            this.cbbCaminho.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCaminho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCaminho.FormattingEnabled = true;
            this.cbbCaminho.Location = new System.Drawing.Point(48, 13);
            this.cbbCaminho.Name = "cbbCaminho";
            this.cbbCaminho.Size = new System.Drawing.Size(249, 21);
            this.cbbCaminho.TabIndex = 2;
            this.cbbCaminho.DropDown += new System.EventHandler(this.cbbCaminho_DropDown);
            this.cbbCaminho.DropDownClosed += new System.EventHandler(this.cbbCaminho_DropDownClosed);
            this.cbbCaminho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCaminho_KeyPress);
            this.cbbCaminho.MouseLeave += new System.EventHandler(this.cbbCaminho_MouseLeave);
            this.cbbCaminho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCaminho_MouseMove);
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Location = new System.Drawing.Point(6, 17);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(36, 13);
            this.lblCaminho.TabIndex = 2;
            this.lblCaminho.Text = "Local:";
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 140);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 36;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(292, 140);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIniciarBackup.SetToolTip(this.btnSair, "Sair do backup.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciar.Image")));
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(217, 140);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(69, 32);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "&Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIniciarBackup.SetToolTip(this.btnIniciar, "Iniciar o backup.");
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnOK_Click);
            this.btnIniciar.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnIniciar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseMove);
            // 
            // ttpIniciarBackup
            // 
            this.ttpIniciarBackup.AutoPopDelay = 5000;
            this.ttpIniciarBackup.InitialDelay = 1000;
            this.ttpIniciarBackup.IsBalloon = true;
            this.ttpIniciarBackup.ReshowDelay = 100;
            this.ttpIniciarBackup.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpIniciarBackup.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // chkbArqDir
            // 
            this.chkbArqDir.AutoSize = true;
            this.chkbArqDir.Location = new System.Drawing.Point(12, 58);
            this.chkbArqDir.Name = "chkbArqDir";
            this.chkbArqDir.Size = new System.Drawing.Size(253, 17);
            this.chkbArqDir.TabIndex = 4;
            this.chkbArqDir.Text = "Fazer Backup do diretório [ C:\\Sistema SEVEN ]";
            this.chkbArqDir.UseVisualStyleBackColor = true;
            this.chkbArqDir.MouseLeave += new System.EventHandler(this.chkbArqDir_MouseLeave);
            this.chkbArqDir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbArqDir_MouseMove);
            // 
            // lblLegenda
            // 
            this.lblLegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegenda.ForeColor = System.Drawing.Color.Red;
            this.lblLegenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLegenda.Location = new System.Drawing.Point(12, 91);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(337, 18);
            this.lblLegenda.TabIndex = 219;
            this.lblLegenda.Text = "Realizando Backup, por favor, aguarde... ";
            this.lblLegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLegenda.Visible = false;
            // 
            // FrmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(361, 177);
            this.ControlBox = false;
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.proBProgresso);
            this.Controls.Add(this.chkbArqDir);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnIniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBackup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup do Aplicativo";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBackup_FormClosing);
            this.Load += new System.EventHandler(this.FrmBackup_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmBackup_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar proBProgresso;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.ComboBox cbbCaminho;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ToolTip ttpIniciarBackup;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.CheckBox chkbArqDir;
        private System.Windows.Forms.Button btnSelecionarLocal;
        private System.Windows.Forms.Label lblLegenda;
    }
}