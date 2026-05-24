namespace Seven_Sistema
{
    partial class FrmConfEnviarSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfEnviarSMS));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.chkbNomeSMS = new System.Windows.Forms.CheckBox();
            this.lblPorta = new System.Windows.Forms.Label();
            this.txtPortaHotmailOutlook = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.chkbNomeSMS);
            this.grbBox1.Controls.Add(this.lblPorta);
            this.grbBox1.Controls.Add(this.txtPortaHotmailOutlook);
            this.grbBox1.Controls.Add(this.btnSalvar);
            this.grbBox1.Controls.Add(this.btnAlterar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(315, 279);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Configurações:";
            // 
            // chkbNomeSMS
            // 
            this.chkbNomeSMS.AutoSize = true;
            this.chkbNomeSMS.Location = new System.Drawing.Point(6, 58);
            this.chkbNomeSMS.Name = "chkbNomeSMS";
            this.chkbNomeSMS.Size = new System.Drawing.Size(134, 17);
            this.chkbNomeSMS.TabIndex = 19;
            this.chkbNomeSMS.Text = "Enviar SMS com nome";
            this.chkbNomeSMS.UseVisualStyleBackColor = true;
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(6, 16);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(35, 13);
            this.lblPorta.TabIndex = 17;
            this.lblPorta.Text = "Porta:";
            // 
            // txtPortaHotmailOutlook
            // 
            this.txtPortaHotmailOutlook.BackColor = System.Drawing.Color.White;
            this.txtPortaHotmailOutlook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortaHotmailOutlook.Location = new System.Drawing.Point(6, 32);
            this.txtPortaHotmailOutlook.MaxLength = 10;
            this.txtPortaHotmailOutlook.Name = "txtPortaHotmailOutlook";
            this.txtPortaHotmailOutlook.Size = new System.Drawing.Size(52, 20);
            this.txtPortaHotmailOutlook.TabIndex = 18;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(239, 251);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 25);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(163, 251);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 25);
            this.btnAlterar.TabIndex = 15;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // FrmConfEnviarSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(505, 360);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfEnviarSMS";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfEnviarSMS";
              this.TopMost = false;
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.TextBox txtPortaHotmailOutlook;
        private System.Windows.Forms.CheckBox chkbNomeSMS;
    }
}