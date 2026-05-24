namespace Seven_Sistema
{
    partial class FrmArquivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArquivos));
            this.wBArquivo = new System.Windows.Forms.WebBrowser();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblArquivos = new System.Windows.Forms.Label();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpArq = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wBArquivo
            // 
            this.wBArquivo.Location = new System.Drawing.Point(6, 50);
            this.wBArquivo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wBArquivo.Name = "wBArquivo";
            this.wBArquivo.Size = new System.Drawing.Size(754, 293);
            this.wBArquivo.TabIndex = 4;
            this.wBArquivo.Url = new System.Uri("C:\\Sistema SEVEN", System.UriKind.Absolute);
            this.wBArquivo.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wBArquivo_Navigated);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(6, 19);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(60, 25);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArq.SetToolTip(this.btnVoltar, "Clique para voltar.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnVoltar_KeyUp);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblArquivos);
            this.grbBox1.Controls.Add(this.lblLegenda);
            this.grbBox1.Controls.Add(this.wBArquivo);
            this.grbBox1.Controls.Add(this.btnVoltar);
            this.grbBox1.Controls.Add(this.btnAvancar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(770, 375);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Navegador:";
            // 
            // lblArquivos
            // 
            this.lblArquivos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArquivos.BackColor = System.Drawing.Color.Transparent;
            this.lblArquivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivos.ForeColor = System.Drawing.Color.Black;
            this.lblArquivos.Location = new System.Drawing.Point(3, 346);
            this.lblArquivos.Name = "lblArquivos";
            this.lblArquivos.Size = new System.Drawing.Size(160, 26);
            this.lblArquivos.TabIndex = 200;
            this.lblArquivos.Text = "Arquivos: 0";
            this.lblArquivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLegenda
            // 
            this.lblLegenda.BackColor = System.Drawing.Color.Transparent;
            this.lblLegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegenda.Location = new System.Drawing.Point(151, 20);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(609, 23);
            this.lblLegenda.TabIndex = 199;
            this.lblLegenda.Text = "Legenda";
            this.lblLegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAvancar
            // 
            this.btnAvancar.Enabled = false;
            this.btnAvancar.Image = ((System.Drawing.Image)(resources.GetObject("btnAvancar.Image")));
            this.btnAvancar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvancar.Location = new System.Drawing.Point(72, 19);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(73, 25);
            this.btnAvancar.TabIndex = 3;
            this.btnAvancar.Text = "&Avançar";
            this.btnAvancar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArq.SetToolTip(this.btnAvancar, "Clique para avançar.");
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            this.btnAvancar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnAvancar_KeyUp);
            this.btnAvancar.MouseLeave += new System.EventHandler(this.btnAvancar_MouseLeave);
            this.btnAvancar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAvancar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(727, 393);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArq.SetToolTip(this.btnSair, "Sair de Visualizador de Arquivos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // ttpArq
            // 
            this.ttpArq.AutoPopDelay = 5000;
            this.ttpArq.InitialDelay = 1000;
            this.ttpArq.IsBalloon = true;
            this.ttpArq.ReshowDelay = 100;
            this.ttpArq.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpArq.ToolTipTitle = "Dica:";
            // 
            // FrmArquivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(795, 429);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArquivos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador de Arquivos";
            this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmArquivos_FormClosing);
            this.Load += new System.EventHandler(this.teste_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmArquivos_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wBArquivo;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.Label lblArquivos;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpArq;
    }
}