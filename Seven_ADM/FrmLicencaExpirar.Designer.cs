namespace Seven_Sistema
{
    partial class FrmLicencaExpirar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLicencaExpirar));
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.btnNao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.lblDias = new System.Windows.Forms.Label();
            this.lblDataExpiracao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcibImagem
            // 
            this.pcibImagem.Image = ((System.Drawing.Image)(resources.GetObject("pcibImagem.Image")));
            this.pcibImagem.Location = new System.Drawing.Point(12, 12);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(65, 65);
            this.pcibImagem.TabIndex = 31;
            this.pcibImagem.TabStop = false;
            // 
            // btnNao
            // 
            this.btnNao.Location = new System.Drawing.Point(260, 33);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(75, 23);
            this.btnNao.TabIndex = 2;
            this.btnNao.Text = "Não";
            this.btnNao.UseVisualStyleBackColor = true;
            this.btnNao.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSim);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNao);
            this.panel1.Location = new System.Drawing.Point(-1, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 145);
            this.panel1.TabIndex = 0;
            // 
            // btnSim
            // 
            this.btnSim.Location = new System.Drawing.Point(162, 33);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(75, 23);
            this.btnSim.TabIndex = 1;
            this.btnSim.Text = "Sim";
            this.btnSim.UseVisualStyleBackColor = true;
            this.btnSim.Click += new System.EventHandler(this.btnSim_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deseja aplicar a licença agora?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTroco
            // 
            this.lblTroco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.Location = new System.Drawing.Point(77, 14);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(341, 73);
            this.lblTroco.TabIndex = 0;
            this.lblTroco.Text = "ATENÇÃO! A licença do seu software vai expirar em 5 dias";
            this.lblTroco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDias
            // 
            this.lblDias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDias.BackColor = System.Drawing.Color.Transparent;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.ForeColor = System.Drawing.Color.Red;
            this.lblDias.Location = new System.Drawing.Point(238, 46);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(111, 20);
            this.lblDias.TabIndex = 0;
            this.lblDias.Text = "em 2 dias.";
            // 
            // lblDataExpiracao
            // 
            this.lblDataExpiracao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataExpiracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataExpiracao.Location = new System.Drawing.Point(81, 68);
            this.lblDataExpiracao.Name = "lblDataExpiracao";
            this.lblDataExpiracao.Size = new System.Drawing.Size(337, 21);
            this.lblDataExpiracao.TabIndex = 0;
            this.lblDataExpiracao.Text = "21/07/1994";
            this.lblDataExpiracao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmLicencaExpirar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 156);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pcibImagem);
            this.Controls.Add(this.lblDias);
            this.Controls.Add(this.lblDataExpiracao);
            this.Controls.Add(this.lblTroco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLicencaExpirar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licença do Software";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmTroco_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTroco_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pcibImagem;
        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSim;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lblDataExpiracao;
    }
}