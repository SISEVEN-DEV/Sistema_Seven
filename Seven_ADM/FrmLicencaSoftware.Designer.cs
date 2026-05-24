namespace Seven_Sistema
{
    partial class FrmLicencaSoftware
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLicencaSoftware));
            this.lblInserir = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lblChaveSistema = new System.Windows.Forms.Label();
            this.txtChave = new System.Windows.Forms.TextBox();
            this.lblChave = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblSuporte = new System.Windows.Forms.Label();
            this.lblPonto = new System.Windows.Forms.Label();
            this.ttpLicenca = new System.Windows.Forms.ToolTip(this.components);
            this.btnIniciarAvaliacao = new System.Windows.Forms.Button();
            this.pcibWhats = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcibWhats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInserir
            // 
            this.lblInserir.AutoSize = true;
            this.lblInserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInserir.ForeColor = System.Drawing.Color.White;
            this.lblInserir.Location = new System.Drawing.Point(17, 26);
            this.lblInserir.Name = "lblInserir";
            this.lblInserir.Size = new System.Drawing.Size(369, 33);
            this.lblInserir.TabIndex = 0;
            this.lblInserir.Text = "Inserir a chave do Software";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.Image")));
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.Location = new System.Drawing.Point(21, 158);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(104, 25);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "&Aplicar Licença";
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLicenca.SetToolTip(this.btnAplicar, "Clique para aplicar a licença informada.");
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Visible = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            this.btnAplicar.MouseLeave += new System.EventHandler(this.btnAplicar_MouseLeave);
            this.btnAplicar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAplicar_MouseMove);
            // 
            // lblChaveSistema
            // 
            this.lblChaveSistema.AutoSize = true;
            this.lblChaveSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaveSistema.ForeColor = System.Drawing.Color.White;
            this.lblChaveSistema.Location = new System.Drawing.Point(19, 76);
            this.lblChaveSistema.Name = "lblChaveSistema";
            this.lblChaveSistema.Size = new System.Drawing.Size(401, 36);
            this.lblChaveSistema.TabIndex = 0;
            this.lblChaveSistema.Text = "A chave do sistema pode estar no seu whatsapp ou \r\ne-mail para mais informações c" +
    "ontate o";
            // 
            // txtChave
            // 
            this.txtChave.BackColor = System.Drawing.Color.White;
            this.txtChave.Enabled = false;
            this.txtChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChave.Location = new System.Drawing.Point(23, 132);
            this.txtChave.MaxLength = 60;
            this.txtChave.Name = "txtChave";
            this.txtChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtChave.Size = new System.Drawing.Size(300, 20);
            this.txtChave.TabIndex = 1;
            this.txtChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChave_KeyPress);
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChave.ForeColor = System.Drawing.Color.White;
            this.lblChave.Location = new System.Drawing.Point(20, 116);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(47, 13);
            this.lblChave.TabIndex = 0;
            this.lblChave.Text = "Chave:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(365, 158);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLicenca.SetToolTip(this.btnSair, "Sair de Licença do Software.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // lblSuporte
            // 
            this.lblSuporte.AutoSize = true;
            this.lblSuporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuporte.ForeColor = System.Drawing.Color.White;
            this.lblSuporte.Location = new System.Drawing.Point(324, 94);
            this.lblSuporte.Name = "lblSuporte";
            this.lblSuporte.Size = new System.Drawing.Size(65, 18);
            this.lblSuporte.TabIndex = 4;
            this.lblSuporte.Text = "suporte";
            this.lblSuporte.Click += new System.EventHandler(this.lblSuporte_Click);
            this.lblSuporte.MouseLeave += new System.EventHandler(this.lblSuporte_MouseLeave);
            this.lblSuporte.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSuporte_MouseMove);
            // 
            // lblPonto
            // 
            this.lblPonto.AutoSize = true;
            this.lblPonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPonto.ForeColor = System.Drawing.Color.White;
            this.lblPonto.Location = new System.Drawing.Point(384, 94);
            this.lblPonto.Name = "lblPonto";
            this.lblPonto.Size = new System.Drawing.Size(13, 18);
            this.lblPonto.TabIndex = 5;
            this.lblPonto.Text = ".";
            // 
            // ttpLicenca
            // 
            this.ttpLicenca.AutoPopDelay = 5000;
            this.ttpLicenca.InitialDelay = 1000;
            this.ttpLicenca.IsBalloon = true;
            this.ttpLicenca.ReshowDelay = 100;
            this.ttpLicenca.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpLicenca.ToolTipTitle = "Dica:";
            // 
            // btnIniciarAvaliacao
            // 
            this.btnIniciarAvaliacao.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciarAvaliacao.Image")));
            this.btnIniciarAvaliacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarAvaliacao.Location = new System.Drawing.Point(23, 158);
            this.btnIniciarAvaliacao.Name = "btnIniciarAvaliacao";
            this.btnIniciarAvaliacao.Size = new System.Drawing.Size(167, 25);
            this.btnIniciarAvaliacao.TabIndex = 6;
            this.btnIniciarAvaliacao.Text = "&Iniciar Período de Avaliação";
            this.btnIniciarAvaliacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLicenca.SetToolTip(this.btnIniciarAvaliacao, "Clique para aplicar a licença informada.");
            this.btnIniciarAvaliacao.UseVisualStyleBackColor = true;
            this.btnIniciarAvaliacao.Click += new System.EventHandler(this.btnIniciarAvaliacao_Click);
            this.btnIniciarAvaliacao.MouseLeave += new System.EventHandler(this.btnIniciarAvaliacao_MouseLeave);
            this.btnIniciarAvaliacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIniciarAvaliacao_MouseMove);
            // 
            // pcibWhats
            // 
            this.pcibWhats.Image = ((System.Drawing.Image)(resources.GetObject("pcibWhats.Image")));
            this.pcibWhats.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibWhats.Location = new System.Drawing.Point(393, 95);
            this.pcibWhats.Name = "pcibWhats";
            this.pcibWhats.Size = new System.Drawing.Size(20, 20);
            this.pcibWhats.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibWhats.TabIndex = 105;
            this.pcibWhats.TabStop = false;
            this.pcibWhats.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.pcibWhats.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.pcibWhats.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // FrmLicencaSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(436, 194);
            this.ControlBox = false;
            this.Controls.Add(this.pcibWhats);
            this.Controls.Add(this.lblSuporte);
            this.Controls.Add(this.lblPonto);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblChave);
            this.Controls.Add(this.txtChave);
            this.Controls.Add(this.lblChaveSistema);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.lblInserir);
            this.Controls.Add(this.btnIniciarAvaliacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLicencaSoftware";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licença do Software";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLicencaSoftware_FormClosing);
            this.Load += new System.EventHandler(this.FrmAddEmpresaBanco_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLicencaSoftware_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibWhats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInserir;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label lblChaveSistema;
        private System.Windows.Forms.TextBox txtChave;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblSuporte;
        private System.Windows.Forms.Label lblPonto;
        private System.Windows.Forms.ToolTip ttpLicenca;
        private System.Windows.Forms.Button btnIniciarAvaliacao;
        private System.Windows.Forms.PictureBox pcibWhats;
    }
}