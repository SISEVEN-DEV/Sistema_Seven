namespace Seven_Sistema
{
    partial class FrmTroco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTroco));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblValorTroco = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.lblDados = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEnviarWhatsapp = new System.Windows.Forms.Button();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.ttpTroco = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.lblValorTroco);
            this.panel1.Controls.Add(this.lblTroco);
            this.panel1.Location = new System.Drawing.Point(-1, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 145);
            this.panel1.TabIndex = 36;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(398, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblValorTroco
            // 
            this.lblValorTroco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblValorTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTroco.ForeColor = System.Drawing.Color.Blue;
            this.lblValorTroco.Location = new System.Drawing.Point(13, 26);
            this.lblValorTroco.Name = "lblValorTroco";
            this.lblValorTroco.Size = new System.Drawing.Size(460, 71);
            this.lblValorTroco.TabIndex = 0;
            this.lblValorTroco.Text = "0,00";
            this.lblValorTroco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTroco
            // 
            this.lblTroco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.Location = new System.Drawing.Point(13, 1);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(460, 25);
            this.lblTroco.TabIndex = 1;
            this.lblTroco.Text = "Troco:";
            this.lblTroco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDados
            // 
            this.lblDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDados.Location = new System.Drawing.Point(12, 9);
            this.lblDados.Name = "lblDados";
            this.lblDados.Size = new System.Drawing.Size(460, 37);
            this.lblDados.TabIndex = 35;
            this.lblDados.Text = "Os dados foram salvos com sucesso.";
            this.lblDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 39);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // btnEnviarWhatsapp
            // 
            this.btnEnviarWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarWhatsapp.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarWhatsapp.Image")));
            this.btnEnviarWhatsapp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarWhatsapp.Location = new System.Drawing.Point(12, 53);
            this.btnEnviarWhatsapp.Name = "btnEnviarWhatsapp";
            this.btnEnviarWhatsapp.Size = new System.Drawing.Size(170, 25);
            this.btnEnviarWhatsapp.TabIndex = 44;
            this.btnEnviarWhatsapp.Text = "Enviar Cupom por &Whatsapp";
            this.btnEnviarWhatsapp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTroco.SetToolTip(this.btnEnviarWhatsapp, "Clique para enviar um whatsapp.");
            this.btnEnviarWhatsapp.UseVisualStyleBackColor = true;
            this.btnEnviarWhatsapp.Click += new System.EventHandler(this.btnEnviarWhatsapp_ClickAsync);
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarEmail.Image")));
            this.btnEnviarEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarEmail.Location = new System.Drawing.Point(322, 49);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(150, 25);
            this.btnEnviarEmail.TabIndex = 45;
            this.btnEnviarEmail.Text = "Enviar Cupom por &E-mail";
            this.btnEnviarEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTroco.SetToolTip(this.btnEnviarEmail, "Clique para enviar um e-mail.");
            this.btnEnviarEmail.UseVisualStyleBackColor = true;
            this.btnEnviarEmail.Click += new System.EventHandler(this.btnEnviarEmail_Click);
            // 
            // ttpTroco
            // 
            this.ttpTroco.AutoPopDelay = 5000;
            this.ttpTroco.InitialDelay = 1000;
            this.ttpTroco.IsBalloon = true;
            this.ttpTroco.ReshowDelay = 100;
            this.ttpTroco.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpTroco.ToolTipTitle = "Dica:";
            // 
            // FrmTroco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 214);
            this.Controls.Add(this.btnEnviarEmail);
            this.Controls.Add(this.btnEnviarWhatsapp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTroco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informação";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTroco_FormClosing);
            this.Load += new System.EventHandler(this.FrmTroco_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTroco_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblValorTroco;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Label lblDados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEnviarWhatsapp;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.ToolTip ttpTroco;
    }
}