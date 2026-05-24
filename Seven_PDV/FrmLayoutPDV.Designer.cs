namespace Seven_Sistema
{
    partial class FrmLayoutPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLayoutPDV));
            this.lblPDV = new System.Windows.Forms.Label();
            this.pcibImagem2 = new System.Windows.Forms.PictureBox();
            this.rbtnClassico = new System.Windows.Forms.RadioButton();
            this.rbtnBigPicture = new System.Windows.Forms.RadioButton();
            this.pPanel2 = new System.Windows.Forms.Panel();
            this.pPanel1 = new System.Windows.Forms.Panel();
            this.pcibImagem1 = new System.Windows.Forms.PictureBox();
            this.lblTexto2 = new System.Windows.Forms.Label();
            this.lblTexto1 = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpLayout = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem2)).BeginInit();
            this.pPanel2.SuspendLayout();
            this.pPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPDV
            // 
            this.lblPDV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPDV.AutoSize = true;
            this.lblPDV.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDV.ForeColor = System.Drawing.Color.Black;
            this.lblPDV.Location = new System.Drawing.Point(285, 9);
            this.lblPDV.Name = "lblPDV";
            this.lblPDV.Size = new System.Drawing.Size(369, 33);
            this.lblPDV.TabIndex = 1;
            this.lblPDV.Text = "Personalize o visual do seu PDV";
            // 
            // pcibImagem2
            // 
            this.pcibImagem2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pcibImagem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem2.Image = ((System.Drawing.Image)(resources.GetObject("pcibImagem2.Image")));
            this.pcibImagem2.Location = new System.Drawing.Point(8, 6);
            this.pcibImagem2.Name = "pcibImagem2";
            this.pcibImagem2.Size = new System.Drawing.Size(450, 275);
            this.pcibImagem2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagem2.TabIndex = 3;
            this.pcibImagem2.TabStop = false;
            this.pcibImagem2.Click += new System.EventHandler(this.pcibImagem2_Click);
            this.pcibImagem2.DoubleClick += new System.EventHandler(this.pcibImagem2_DoubleClick);
            this.pcibImagem2.MouseLeave += new System.EventHandler(this.pcibImagem2_MouseLeave);
            this.pcibImagem2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagem2_MouseMove);
            // 
            // rbtnClassico
            // 
            this.rbtnClassico.AutoSize = true;
            this.rbtnClassico.Checked = true;
            this.rbtnClassico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnClassico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnClassico.Location = new System.Drawing.Point(176, 45);
            this.rbtnClassico.Name = "rbtnClassico";
            this.rbtnClassico.Size = new System.Drawing.Size(130, 20);
            this.rbtnClassico.TabIndex = 1;
            this.rbtnClassico.Text = "Estilo &Windows";
            this.rbtnClassico.UseVisualStyleBackColor = true;
            this.rbtnClassico.CheckedChanged += new System.EventHandler(this.rbtnClassico_CheckedChanged);
            this.rbtnClassico.Click += new System.EventHandler(this.rbtnClassico_Click);
            this.rbtnClassico.MouseLeave += new System.EventHandler(this.rbtnClassico_MouseLeave);
            this.rbtnClassico.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnClassico_MouseMove);
            // 
            // rbtnBigPicture
            // 
            this.rbtnBigPicture.AutoSize = true;
            this.rbtnBigPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBigPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBigPicture.Location = new System.Drawing.Point(641, 45);
            this.rbtnBigPicture.Name = "rbtnBigPicture";
            this.rbtnBigPicture.Size = new System.Drawing.Size(236, 20);
            this.rbtnBigPicture.TabIndex = 2;
            this.rbtnBigPicture.Text = "Estilo &Big Picture (Tela Inteira)";
            this.rbtnBigPicture.UseVisualStyleBackColor = true;
            this.rbtnBigPicture.CheckedChanged += new System.EventHandler(this.rbtnBigPicture_CheckedChanged);
            this.rbtnBigPicture.Click += new System.EventHandler(this.rbtnBigPicture_Click);
            this.rbtnBigPicture.MouseLeave += new System.EventHandler(this.rbtnBigPicture_MouseLeave);
            this.rbtnBigPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnBigPicture_MouseMove);
            // 
            // pPanel2
            // 
            this.pPanel2.BackColor = System.Drawing.Color.LightGray;
            this.pPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPanel2.Controls.Add(this.pcibImagem2);
            this.pPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pPanel2.Location = new System.Drawing.Point(491, 100);
            this.pPanel2.Name = "pPanel2";
            this.pPanel2.Size = new System.Drawing.Size(468, 289);
            this.pPanel2.TabIndex = 23;
            this.pPanel2.MouseLeave += new System.EventHandler(this.pPanel2_MouseLeave);
            this.pPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pPanel2_MouseMove);
            // 
            // pPanel1
            // 
            this.pPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPanel1.Controls.Add(this.pcibImagem1);
            this.pPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pPanel1.Location = new System.Drawing.Point(12, 100);
            this.pPanel1.Name = "pPanel1";
            this.pPanel1.Size = new System.Drawing.Size(468, 289);
            this.pPanel1.TabIndex = 24;
            this.pPanel1.MouseLeave += new System.EventHandler(this.pPanel1_MouseLeave);
            this.pPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pPanel1_MouseMove);
            // 
            // pcibImagem1
            // 
            this.pcibImagem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pcibImagem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem1.Image = ((System.Drawing.Image)(resources.GetObject("pcibImagem1.Image")));
            this.pcibImagem1.Location = new System.Drawing.Point(8, 6);
            this.pcibImagem1.Name = "pcibImagem1";
            this.pcibImagem1.Size = new System.Drawing.Size(450, 275);
            this.pcibImagem1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagem1.TabIndex = 3;
            this.pcibImagem1.TabStop = false;
            this.pcibImagem1.Click += new System.EventHandler(this.pcibImagem1_Click);
            this.pcibImagem1.DoubleClick += new System.EventHandler(this.pcibImagem1_DoubleClick);
            this.pcibImagem1.MouseLeave += new System.EventHandler(this.pcibImagem1_MouseLeave);
            this.pcibImagem1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagem1_MouseMove);
            // 
            // lblTexto2
            // 
            this.lblTexto2.AutoSize = true;
            this.lblTexto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto2.Location = new System.Drawing.Point(598, 63);
            this.lblTexto2.Name = "lblTexto2";
            this.lblTexto2.Size = new System.Drawing.Size(334, 36);
            this.lblTexto2.TabIndex = 25;
            this.lblTexto2.Text = "Perfeito para locais onde o cliente visualiza a tela \r\ndo caixa enquanto realiza " +
    "suas compras.";
            this.lblTexto2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTexto1
            // 
            this.lblTexto1.AutoSize = true;
            this.lblTexto1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto1.Location = new System.Drawing.Point(88, 62);
            this.lblTexto1.Name = "lblTexto1";
            this.lblTexto1.Size = new System.Drawing.Size(352, 36);
            this.lblTexto1.TabIndex = 26;
            this.lblTexto1.Text = "Recomendado para ambientes em que o cliente não\r\n tem visibilidade direta da inte" +
    "rface do caixa.";
            this.lblTexto1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnContinuar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContinuar.Location = new System.Drawing.Point(813, 395);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(86, 32);
            this.btnContinuar.TabIndex = 3;
            this.btnContinuar.Text = "&Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLayout.SetToolTip(this.btnContinuar, "Clique para continar com o Layout selecionado.");
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(905, 395);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLayout.SetToolTip(this.btnSair, "Sair de Escolher Layot PDV.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // ttpLayout
            // 
            this.ttpLayout.AutoPopDelay = 5000;
            this.ttpLayout.InitialDelay = 1000;
            this.ttpLayout.IsBalloon = true;
            this.ttpLayout.ReshowDelay = 100;
            this.ttpLayout.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpLayout.ToolTipTitle = "Dica:";
            // 
            // FrmLayoutPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(972, 433);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.lblTexto1);
            this.Controls.Add(this.lblTexto2);
            this.Controls.Add(this.pPanel1);
            this.Controls.Add(this.pPanel2);
            this.Controls.Add(this.rbtnBigPicture);
            this.Controls.Add(this.rbtnClassico);
            this.Controls.Add(this.lblPDV);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLayoutPDV";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escolher Layout do PDV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLayoutPDV_FormClosing);
            this.Load += new System.EventHandler(this.FrmLayoutPDV_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLayoutPDV_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem2)).EndInit();
            this.pPanel2.ResumeLayout(false);
            this.pPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPDV;
        private System.Windows.Forms.PictureBox pcibImagem2;
        private System.Windows.Forms.RadioButton rbtnClassico;
        private System.Windows.Forms.RadioButton rbtnBigPicture;
        private System.Windows.Forms.Panel pPanel2;
        private System.Windows.Forms.Panel pPanel1;
        private System.Windows.Forms.PictureBox pcibImagem1;
        private System.Windows.Forms.Label lblTexto2;
        private System.Windows.Forms.Label lblTexto1;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpLayout;
    }
}