namespace Sistema_SEVEN_Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLicencaSoftware));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtChaveLicenca = new System.Windows.Forms.TextBox();
            this.btnGerarCPFCNPJ = new System.Windows.Forms.Button();
            this.lblCPFCNPJ = new System.Windows.Forms.Label();
            this.txtCPFCNPJ = new System.Windows.Forms.TextBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtChaveLicenca);
            this.groupBox1.Controls.Add(this.btnGerarCPFCNPJ);
            this.groupBox1.Controls.Add(this.lblCPFCNPJ);
            this.groupBox1.Controls.Add(this.txtCPFCNPJ);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 66);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gerador:";
            // 
            // txtChaveLicenca
            // 
            this.txtChaveLicenca.BackColor = System.Drawing.Color.White;
            this.txtChaveLicenca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChaveLicenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChaveLicenca.Location = new System.Drawing.Point(246, 32);
            this.txtChaveLicenca.MaxLength = 30;
            this.txtChaveLicenca.Name = "txtChaveLicenca";
            this.txtChaveLicenca.Size = new System.Drawing.Size(124, 20);
            this.txtChaveLicenca.TabIndex = 4;
            this.txtChaveLicenca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChaveLicenca_KeyPress);
            // 
            // btnGerarCPFCNPJ
            // 
            this.btnGerarCPFCNPJ.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarCPFCNPJ.Image")));
            this.btnGerarCPFCNPJ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarCPFCNPJ.Location = new System.Drawing.Point(136, 29);
            this.btnGerarCPFCNPJ.Name = "btnGerarCPFCNPJ";
            this.btnGerarCPFCNPJ.Size = new System.Drawing.Size(99, 25);
            this.btnGerarCPFCNPJ.TabIndex = 3;
            this.btnGerarCPFCNPJ.Text = "&Gerar Licença";
            this.btnGerarCPFCNPJ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarCPFCNPJ.UseVisualStyleBackColor = true;
            this.btnGerarCPFCNPJ.Click += new System.EventHandler(this.btnVer_Click);
            this.btnGerarCPFCNPJ.MouseLeave += new System.EventHandler(this.btnGerarCPFCNPJ_MouseLeave);
            this.btnGerarCPFCNPJ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGerarCPFCNPJ_MouseMove);
            // 
            // lblCPFCNPJ
            // 
            this.lblCPFCNPJ.AutoSize = true;
            this.lblCPFCNPJ.Location = new System.Drawing.Point(6, 16);
            this.lblCPFCNPJ.Name = "lblCPFCNPJ";
            this.lblCPFCNPJ.Size = new System.Drawing.Size(62, 13);
            this.lblCPFCNPJ.TabIndex = 7;
            this.lblCPFCNPJ.Text = "CPF/CNPJ:";
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.BackColor = System.Drawing.Color.White;
            this.txtCPFCNPJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCPFCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPFCNPJ.Location = new System.Drawing.Point(6, 32);
            this.txtCPFCNPJ.MaxLength = 18;
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Size = new System.Drawing.Size(124, 20);
            this.txtCPFCNPJ.TabIndex = 2;
            this.txtCPFCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPFCNPJ_KeyPress);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.Image")));
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.Location = new System.Drawing.Point(286, 84);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(104, 25);
            this.btnAplicar.TabIndex = 5;
            this.btnAplicar.Text = "&Aplicar Licença";
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.MouseLeave += new System.EventHandler(this.btnAplicar_MouseLeave);
            this.btnAplicar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAplicar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(335, 115);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // FrmLicencaSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(402, 151);
            this.ControlBox = false;
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLicencaSoftware";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licença do Software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLicencaSoftware_FormClosing);
            this.Load += new System.EventHandler(this.FrmLicencaSoftware_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLicencaSoftware_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCPFCNPJ;
        private System.Windows.Forms.Label lblCPFCNPJ;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtChaveLicenca;
        private System.Windows.Forms.Button btnGerarCPFCNPJ;
        private System.Windows.Forms.Button btnSair;
    }
}