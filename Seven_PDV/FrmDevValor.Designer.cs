namespace Seven_Sistema
{
    partial class FrmDevValor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevValor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblTipoDev = new System.Windows.Forms.Label();
            this.lblDados = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.lblValor);
            this.panel1.Controls.Add(this.lblTipoDev);
            this.panel1.Location = new System.Drawing.Point(-1, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 145);
            this.panel1.TabIndex = 37;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(226, 74);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblValor
            // 
            this.lblValor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Blue;
            this.lblValor.Location = new System.Drawing.Point(0, 26);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(314, 41);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "0,00";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipoDev
            // 
            this.lblTipoDev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDev.Location = new System.Drawing.Point(0, 1);
            this.lblTipoDev.Name = "lblTipoDev";
            this.lblTipoDev.Size = new System.Drawing.Size(314, 25);
            this.lblTipoDev.TabIndex = 1;
            this.lblTipoDev.Text = "Tipo";
            this.lblTipoDev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDados
            // 
            this.lblDados.AutoSize = true;
            this.lblDados.Location = new System.Drawing.Point(86, 40);
            this.lblDados.Name = "lblDados";
            this.lblDados.Size = new System.Drawing.Size(182, 13);
            this.lblDados.TabIndex = 39;
            this.lblDados.Text = "Os dados foram salvos com sucesso.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 39);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // FrmDevValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 193);
            this.ControlBox = false;
            this.Controls.Add(this.lblDados);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDevValor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informação";
              this.TopMost = false;
            this.Load += new System.EventHandler(this.FrmDevValor_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmDevValor_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblTipoDev;
        private System.Windows.Forms.Label lblDados;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}