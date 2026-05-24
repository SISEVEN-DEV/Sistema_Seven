namespace Seven_Sistema
{
    partial class FrmTipoDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipoDFe));
            this.lblDados = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNFe = new System.Windows.Forms.Button();
            this.btnNFCe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDados
            // 
            this.lblDados.AutoSize = true;
            this.lblDados.Location = new System.Drawing.Point(86, 36);
            this.lblDados.Name = "lblDados";
            this.lblDados.Size = new System.Drawing.Size(211, 26);
            this.lblDados.TabIndex = 0;
            this.lblDados.Text = "Qual tipo de documento fiscal será utilizado\r\npara a venda dos produtos?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 39);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnNFe);
            this.panel1.Controls.Add(this.btnNFCe);
            this.panel1.Location = new System.Drawing.Point(-1, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 145);
            this.panel1.TabIndex = 35;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(227, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNFe
            // 
            this.btnNFe.Location = new System.Drawing.Point(13, 3);
            this.btnNFe.Name = "btnNFe";
            this.btnNFe.Size = new System.Drawing.Size(100, 23);
            this.btnNFe.TabIndex = 1;
            this.btnNFe.Text = "&NFe (Modelo 55)";
            this.btnNFe.UseVisualStyleBackColor = true;
            this.btnNFe.Click += new System.EventHandler(this.btnNFe_Click);
            // 
            // btnNFCe
            // 
            this.btnNFCe.Location = new System.Drawing.Point(119, 3);
            this.btnNFCe.Name = "btnNFCe";
            this.btnNFCe.Size = new System.Drawing.Size(102, 23);
            this.btnNFCe.TabIndex = 2;
            this.btnNFCe.Text = "NF&Ce (Modelo 65)";
            this.btnNFCe.UseVisualStyleBackColor = true;
            this.btnNFCe.Click += new System.EventHandler(this.btnNFCe_Click);
            // 
            // FrmTipoDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(314, 126);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDados);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTipoDFe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pergunta";
              this.TopMost = false;
            this.Load += new System.EventHandler(this.FrmTipoDFe_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTipoDFe_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNFCe;
        private System.Windows.Forms.Button btnNFe;
        private System.Windows.Forms.Button btnCancelar;
    }
}