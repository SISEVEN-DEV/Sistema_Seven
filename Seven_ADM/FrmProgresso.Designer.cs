namespace Seven_Sistema
{
    partial class FrmProgresso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgresso));
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.ttpAtualizacao = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.tTimer = new System.Windows.Forms.Timer(this.components);
            this.pcibMega = new System.Windows.Forms.PictureBox();
            this.lblBackupMega = new System.Windows.Forms.Label();
            this.lblMegaLink = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcibMega)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.Location = new System.Drawing.Point(12, 30);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(776, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 0;
            this.pgbProgresso.MouseLeave += new System.EventHandler(this.progressBar1_MouseLeave);
            this.pgbProgresso.MouseMove += new System.Windows.Forms.MouseEventHandler(this.progressBar1_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(733, 59);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 217;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAtualizacao.SetToolTip(this.btnSair, "Sair da Atualização do Software.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // lblLegenda
            // 
            this.lblLegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLegenda.Location = new System.Drawing.Point(12, 9);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(776, 18);
            this.lblLegenda.TabIndex = 218;
            this.lblLegenda.Text = "Legenda";
            this.lblLegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLegenda.MouseLeave += new System.EventHandler(this.lblLegenda3_MouseLeave);
            this.lblLegenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblLegenda3_MouseMove);
            // 
            // ttpAtualizacao
            // 
            this.ttpAtualizacao.AutoPopDelay = 5000;
            this.ttpAtualizacao.InitialDelay = 1000;
            this.ttpAtualizacao.IsBalloon = true;
            this.ttpAtualizacao.ReshowDelay = 100;
            this.ttpAtualizacao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAtualizacao.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.WorkerSupportsCancellation = true;
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // tTimer
            // 
            this.tTimer.Interval = 1000;
            this.tTimer.Tick += new System.EventHandler(this.tTimer_Tick);
            // 
            // pcibMega
            // 
            this.pcibMega.Image = ((System.Drawing.Image)(resources.GetObject("pcibMega.Image")));
            this.pcibMega.Location = new System.Drawing.Point(12, 59);
            this.pcibMega.Name = "pcibMega";
            this.pcibMega.Size = new System.Drawing.Size(33, 34);
            this.pcibMega.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibMega.TabIndex = 219;
            this.pcibMega.TabStop = false;
            // 
            // lblBackupMega
            // 
            this.lblBackupMega.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupMega.ForeColor = System.Drawing.Color.Red;
            this.lblBackupMega.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBackupMega.Location = new System.Drawing.Point(43, 56);
            this.lblBackupMega.Name = "lblBackupMega";
            this.lblBackupMega.Size = new System.Drawing.Size(272, 21);
            this.lblBackupMega.TabIndex = 220;
            this.lblBackupMega.Text = "Seu Backup está seguro no MEGA.";
            this.lblBackupMega.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMegaLink
            // 
            this.lblMegaLink.AutoSize = true;
            this.lblMegaLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMegaLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMegaLink.ForeColor = System.Drawing.Color.Blue;
            this.lblMegaLink.Location = new System.Drawing.Point(47, 76);
            this.lblMegaLink.Name = "lblMegaLink";
            this.lblMegaLink.Size = new System.Drawing.Size(111, 13);
            this.lblMegaLink.TabIndex = 221;
            this.lblMegaLink.Text = "https://mega.io/pt-br/";
            this.lblMegaLink.Click += new System.EventHandler(this.lblSiseven_Click);
            // 
            // FrmProgresso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 97);
            this.Controls.Add(this.lblMegaLink);
            this.Controls.Add(this.pcibMega);
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pgbProgresso);
            this.Controls.Add(this.lblBackupMega);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProgresso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progresso";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProgresso_FormClosing);
            this.Load += new System.EventHandler(this.FrmProgresso_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmProgresso_KeyUp);
            this.MouseLeave += new System.EventHandler(this.FrmProgresso_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmProgresso_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pcibMega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.ToolTip ttpAtualizacao;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Timer tTimer;
        private System.Windows.Forms.PictureBox pcibMega;
        private System.Windows.Forms.Label lblBackupMega;
        private System.Windows.Forms.Label lblMegaLink;
    }
}