namespace Seven_Sistema
{
    partial class FrmGerarQRCodePIX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGerarQRCodePIX));
            this.txtPIXCopiaCola = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.cbbPSP = new System.Windows.Forms.ComboBox();
            this.lblValorPagar = new System.Windows.Forms.Label();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pcibQRCode = new System.Windows.Forms.PictureBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEnviarZap = new System.Windows.Forms.Button();
            this.ttpPIX = new System.Windows.Forms.ToolTip(this.components);
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibQRCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPIXCopiaCola
            // 
            this.txtPIXCopiaCola.BackColor = System.Drawing.Color.White;
            this.txtPIXCopiaCola.Enabled = false;
            this.txtPIXCopiaCola.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPIXCopiaCola.Location = new System.Drawing.Point(6, 523);
            this.txtPIXCopiaCola.MaxLength = 0;
            this.txtPIXCopiaCola.Name = "txtPIXCopiaCola";
            this.txtPIXCopiaCola.ReadOnly = true;
            this.txtPIXCopiaCola.Size = new System.Drawing.Size(766, 20);
            this.txtPIXCopiaCola.TabIndex = 3;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(767, 567);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPIX.SetToolTip(this.btnSair, "Sair de Gerar QR Code PIX.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnProcurar);
            this.grbBox1.Controls.Add(this.cbbPSP);
            this.grbBox1.Controls.Add(this.lblValorPagar);
            this.grbBox1.Controls.Add(this.btnCopiar);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.txtPIXCopiaCola);
            this.grbBox1.Controls.Add(this.pcibQRCode);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(810, 549);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            // 
            // btnProcurar
            // 
            this.btnProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar.Image")));
            this.btnProcurar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnProcurar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProcurar.Location = new System.Drawing.Point(771, 12);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(33, 32);
            this.btnProcurar.TabIndex = 21;
            this.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPIX.SetToolTip(this.btnProcurar, "Clique para pesquisar um PSP/PIX.");
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            this.btnProcurar.MouseLeave += new System.EventHandler(this.btnProcurar_MouseLeave);
            this.btnProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar_MouseMove);
            // 
            // cbbPSP
            // 
            this.cbbPSP.BackColor = System.Drawing.Color.LightBlue;
            this.cbbPSP.DropDownHeight = 200;
            this.cbbPSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPSP.DropDownWidth = 520;
            this.cbbPSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPSP.FormattingEnabled = true;
            this.cbbPSP.IntegralHeight = false;
            this.cbbPSP.Location = new System.Drawing.Point(6, 17);
            this.cbbPSP.Name = "cbbPSP";
            this.cbbPSP.Size = new System.Drawing.Size(759, 24);
            this.cbbPSP.TabIndex = 22;
            this.cbbPSP.DropDown += new System.EventHandler(this.cbbPSP_DropDown);
            this.cbbPSP.SelectedIndexChanged += new System.EventHandler(this.cbbPSP_SelectedIndexChanged);
            this.cbbPSP.DropDownClosed += new System.EventHandler(this.cbbPSP_DropDownClosed);
            this.cbbPSP.MouseLeave += new System.EventHandler(this.cbbPSP_MouseLeave);
            this.cbbPSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbPSP_MouseMove);
            // 
            // lblValorPagar
            // 
            this.lblValorPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorPagar.BackColor = System.Drawing.Color.LightGray;
            this.lblValorPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorPagar.Enabled = false;
            this.lblValorPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPagar.Location = new System.Drawing.Point(6, 45);
            this.lblValorPagar.Name = "lblValorPagar";
            this.lblValorPagar.Size = new System.Drawing.Size(798, 28);
            this.lblValorPagar.TabIndex = 0;
            this.lblValorPagar.Text = "R$ 0,00";
            this.lblValorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorPagar.Click += new System.EventHandler(this.lblValorPagar_Click);
            this.lblValorPagar.MouseLeave += new System.EventHandler(this.lblValorPagar_MouseLeave);
            this.lblValorPagar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorPagar_MouseMove);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Enabled = false;
            this.btnCopiar.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiar.Image")));
            this.btnCopiar.Location = new System.Drawing.Point(778, 520);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(26, 25);
            this.btnCopiar.TabIndex = 4;
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPIX.SetToolTip(this.btnCopiar, "Clique para copiar o PIX Copia e Cola.");
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiarChave_Click);
            this.btnCopiar.MouseLeave += new System.EventHandler(this.btnCopiarChave_MouseLeave);
            this.btnCopiar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCopiarChave_MouseMove);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "QR Code / PIX Copia e Cola:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcibQRCode
            // 
            this.pcibQRCode.Enabled = false;
            this.pcibQRCode.Location = new System.Drawing.Point(6, 76);
            this.pcibQRCode.Name = "pcibQRCode";
            this.pcibQRCode.Size = new System.Drawing.Size(798, 438);
            this.pcibQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibQRCode.TabIndex = 20;
            this.pcibQRCode.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImprimir.Location = new System.Drawing.Point(343, 567);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(79, 32);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPIX.SetToolTip(this.btnImprimir, "Clique para imprimir o QR Code.");
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnImprimir.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnImprimir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // btnEnviarZap
            // 
            this.btnEnviarZap.Enabled = false;
            this.btnEnviarZap.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarZap.Image")));
            this.btnEnviarZap.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnviarZap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnviarZap.Location = new System.Drawing.Point(428, 567);
            this.btnEnviarZap.Name = "btnEnviarZap";
            this.btnEnviarZap.Size = new System.Drawing.Size(95, 32);
            this.btnEnviarZap.TabIndex = 6;
            this.btnEnviarZap.Text = "Enviar &ZAP";
            this.btnEnviarZap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPIX.SetToolTip(this.btnEnviarZap, "Clique para enviar PIX Copia e Cola pelo whatsapp.");
            this.btnEnviarZap.UseVisualStyleBackColor = true;
            this.btnEnviarZap.Click += new System.EventHandler(this.btnEnviarZap_Click);
            this.btnEnviarZap.MouseLeave += new System.EventHandler(this.btnEnviarZap_MouseLeave);
            this.btnEnviarZap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEnviarZap_MouseMove);
            // 
            // ttpPIX
            // 
            this.ttpPIX.AutoPopDelay = 5000;
            this.ttpPIX.InitialDelay = 1000;
            this.ttpPIX.IsBalloon = true;
            this.ttpPIX.ReshowDelay = 100;
            this.ttpPIX.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPIX.ToolTipTitle = "Dica:";
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 567);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 236;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // FrmGerarQRCodePIX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(834, 605);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnEnviarZap);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGerarQRCodePIX";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR Code PIX";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGerarQRCodePIX_FormClosing);
            this.Load += new System.EventHandler(this.FrmGerarQRCodePIX_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmGerarQRCodePIX_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibQRCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPIXCopiaCola;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEnviarZap;
        private System.Windows.Forms.PictureBox pcibQRCode;
        private System.Windows.Forms.Label lblValorPagar;
        private System.Windows.Forms.ToolTip ttpPIX;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.ComboBox cbbPSP;
    }
}