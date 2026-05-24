namespace Seven_Sistema
{
    partial class FrmEnviarTipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnviarTipo));
            this.ttpEnviar = new System.Windows.Forms.ToolTip(this.components);
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnWhatsapp = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpEnviar
            // 
            this.ttpEnviar.AutoPopDelay = 5000;
            this.ttpEnviar.InitialDelay = 1000;
            this.ttpEnviar.IsBalloon = true;
            this.ttpEnviar.ReshowDelay = 100;
            this.ttpEnviar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpEnviar.ToolTipTitle = "Dica:";
            // 
            // btnEmail
            // 
            this.btnEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEmail.Image")));
            this.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmail.Location = new System.Drawing.Point(6, 19);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(98, 25);
            this.btnEmail.TabIndex = 2;
            this.btnEmail.Text = "Enviar &E-mail";
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEnviar.SetToolTip(this.btnEmail, "Clique para enviar um e-mail.");
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            this.btnEmail.MouseLeave += new System.EventHandler(this.btnEscolherArquivo_MouseLeave);
            this.btnEmail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEscolherArquivo_MouseMove);
            // 
            // btnWhatsapp
            // 
            this.btnWhatsapp.Image = ((System.Drawing.Image)(resources.GetObject("btnWhatsapp.Image")));
            this.btnWhatsapp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWhatsapp.Location = new System.Drawing.Point(110, 19);
            this.btnWhatsapp.Name = "btnWhatsapp";
            this.btnWhatsapp.Size = new System.Drawing.Size(120, 25);
            this.btnWhatsapp.TabIndex = 3;
            this.btnWhatsapp.Text = "Enviar &Whatsapp";
            this.btnWhatsapp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEnviar.SetToolTip(this.btnWhatsapp, "Clique para enviar um whatsapp.");
            this.btnWhatsapp.UseVisualStyleBackColor = true;
            this.btnWhatsapp.Click += new System.EventHandler(this.btnWhatsapp_Click);
            this.btnWhatsapp.MouseLeave += new System.EventHandler(this.btnDigitalizar_MouseLeave);
            this.btnWhatsapp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDigitalizar_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(197, 68);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEnviar.SetToolTip(this.btnVoltar, "Sair de Enviar.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnEmail);
            this.grbBox1.Controls.Add(this.btnWhatsapp);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(240, 50);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Ações:";
            // 
            // FrmEnviarTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(259, 105);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnviarTipo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEnviarTipo_FormClosing);
            this.Load += new System.EventHandler(this.FrmUtilEmailNovoEmail_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmEnviarTipo_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpEnviar;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnWhatsapp;
        private System.Windows.Forms.Button btnVoltar;
    }
}