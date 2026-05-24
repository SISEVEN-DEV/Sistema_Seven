namespace _7_Sistema_Instalador
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.pPainel1 = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCabecalho1 = new System.Windows.Forms.Label();
            this.lblInformacoescomp1 = new System.Windows.Forms.Label();
            this.rtxtContLic = new System.Windows.Forms.RichTextBox();
            this.lblPeqCabecalho1 = new System.Windows.Forms.Label();
            this.rbtnAceito = new System.Windows.Forms.RadioButton();
            this.rbtnNaoAceito = new System.Windows.Forms.RadioButton();
            this.chkbFirebird = new System.Windows.Forms.CheckBox();
            this.chkbIbexpert = new System.Windows.Forms.CheckBox();
            this.chkbAdobePDF = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            this.pPainel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcibImagem
            // 
            this.pcibImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem.Location = new System.Drawing.Point(0, 0);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(165, 325);
            this.pcibImagem.TabIndex = 0;
            this.pcibImagem.TabStop = false;
            // 
            // pPainel1
            // 
            this.pPainel1.BackColor = System.Drawing.Color.LightGray;
            this.pPainel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPainel1.Controls.Add(this.btnVoltar);
            this.pPainel1.Controls.Add(this.btnAvancar);
            this.pPainel1.Controls.Add(this.btnCancelar);
            this.pPainel1.Location = new System.Drawing.Point(0, 324);
            this.pPainel1.Name = "pPainel1";
            this.pPainel1.Size = new System.Drawing.Size(634, 87);
            this.pPainel1.TabIndex = 1;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Enabled = false;
            this.btnVoltar.Location = new System.Drawing.Point(317, 42);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(80, 23);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "<< &Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(403, 42);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(80, 23);
            this.btnAvancar.TabIndex = 1;
            this.btnAvancar.Text = "&Avançar >>";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            this.btnAvancar.MouseLeave += new System.EventHandler(this.btnAvancar_MouseLeave);
            this.btnAvancar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAvancar_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(541, 42);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancela&r";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // lblCabecalho1
            // 
            this.lblCabecalho1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho1.Location = new System.Drawing.Point(200, 25);
            this.lblCabecalho1.Name = "lblCabecalho1";
            this.lblCabecalho1.Size = new System.Drawing.Size(420, 32);
            this.lblCabecalho1.TabIndex = 2;
            this.lblCabecalho1.Text = "Bem-vindo ao assistente de instalação do software 7 Sistema";
            // 
            // lblInformacoescomp1
            // 
            this.lblInformacoescomp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacoescomp1.Location = new System.Drawing.Point(200, 129);
            this.lblInformacoescomp1.Name = "lblInformacoescomp1";
            this.lblInformacoescomp1.Size = new System.Drawing.Size(420, 91);
            this.lblInformacoescomp1.TabIndex = 3;
            this.lblInformacoescomp1.Text = "Este assistente irá instalar o 7 Sistema e outros componentes em seu computador c" +
    "lique em avançar para continuar a instalação.\r\n\r\n\r\n\r\n\r\nEste software possui Dire" +
    "itos Autorais.\r\n\r\n\r\n";
            // 
            // rtxtContLic
            // 
            this.rtxtContLic.Location = new System.Drawing.Point(203, 97);
            this.rtxtContLic.Name = "rtxtContLic";
            this.rtxtContLic.Size = new System.Drawing.Size(417, 175);
            this.rtxtContLic.TabIndex = 4;
            this.rtxtContLic.Text = "";
            this.rtxtContLic.Visible = false;
            // 
            // lblPeqCabecalho1
            // 
            this.lblPeqCabecalho1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeqCabecalho1.Location = new System.Drawing.Point(200, 80);
            this.lblPeqCabecalho1.Name = "lblPeqCabecalho1";
            this.lblPeqCabecalho1.Size = new System.Drawing.Size(420, 14);
            this.lblPeqCabecalho1.TabIndex = 5;
            this.lblPeqCabecalho1.Text = "Leia atentamente o contrato de licença:";
            this.lblPeqCabecalho1.Visible = false;
            // 
            // rbtnAceito
            // 
            this.rbtnAceito.AutoSize = true;
            this.rbtnAceito.Location = new System.Drawing.Point(203, 278);
            this.rbtnAceito.Name = "rbtnAceito";
            this.rbtnAceito.Size = new System.Drawing.Size(345, 17);
            this.rbtnAceito.TabIndex = 6;
            this.rbtnAceito.Text = "Eu li e &concordo com os termos apresentados acima neste contrato.";
            this.rbtnAceito.UseVisualStyleBackColor = true;
            this.rbtnAceito.Visible = false;
            this.rbtnAceito.CheckedChanged += new System.EventHandler(this.rbtnAceito_CheckedChanged);
            this.rbtnAceito.MouseLeave += new System.EventHandler(this.rbtnAceito_MouseLeave);
            this.rbtnAceito.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnAceito_MouseMove);
            // 
            // rbtnNaoAceito
            // 
            this.rbtnNaoAceito.AutoSize = true;
            this.rbtnNaoAceito.Location = new System.Drawing.Point(203, 301);
            this.rbtnNaoAceito.Name = "rbtnNaoAceito";
            this.rbtnNaoAceito.Size = new System.Drawing.Size(366, 17);
            this.rbtnNaoAceito.TabIndex = 7;
            this.rbtnNaoAceito.Text = "Eu li e &não concordo com os termos apresentados acima neste contrato.";
            this.rbtnNaoAceito.UseVisualStyleBackColor = true;
            this.rbtnNaoAceito.Visible = false;
            this.rbtnNaoAceito.CheckedChanged += new System.EventHandler(this.rbtnNaoAceito_CheckedChanged);
            this.rbtnNaoAceito.MouseLeave += new System.EventHandler(this.rbtnNaoAceito_MouseLeave);
            this.rbtnNaoAceito.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNaoAceito_MouseMove);
            // 
            // chkbFirebird
            // 
            this.chkbFirebird.AutoSize = true;
            this.chkbFirebird.Checked = true;
            this.chkbFirebird.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbFirebird.Location = new System.Drawing.Point(203, 109);
            this.chkbFirebird.Name = "chkbFirebird";
            this.chkbFirebird.Size = new System.Drawing.Size(78, 17);
            this.chkbFirebird.TabIndex = 8;
            this.chkbFirebird.Text = "Firebird 2.5";
            this.chkbFirebird.UseVisualStyleBackColor = true;
            this.chkbFirebird.Visible = false;
            this.chkbFirebird.MouseLeave += new System.EventHandler(this.chkbFirebird_MouseLeave);
            this.chkbFirebird.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbFirebird_MouseMove);
            // 
            // chkbIbexpert
            // 
            this.chkbIbexpert.AutoSize = true;
            this.chkbIbexpert.Checked = true;
            this.chkbIbexpert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbIbexpert.Location = new System.Drawing.Point(203, 149);
            this.chkbIbexpert.Name = "chkbIbexpert";
            this.chkbIbexpert.Size = new System.Drawing.Size(66, 17);
            this.chkbIbexpert.TabIndex = 10;
            this.chkbIbexpert.Text = "IBExpert";
            this.chkbIbexpert.UseVisualStyleBackColor = true;
            this.chkbIbexpert.Visible = false;
            this.chkbIbexpert.MouseLeave += new System.EventHandler(this.chkbIbexpert_MouseLeave);
            this.chkbIbexpert.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbIbexpert_MouseMove);
            // 
            // chkbAdobePDF
            // 
            this.chkbAdobePDF.AutoSize = true;
            this.chkbAdobePDF.Checked = true;
            this.chkbAdobePDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbAdobePDF.Location = new System.Drawing.Point(203, 187);
            this.chkbAdobePDF.Name = "chkbAdobePDF";
            this.chkbAdobePDF.Size = new System.Drawing.Size(81, 17);
            this.chkbAdobePDF.TabIndex = 11;
            this.chkbAdobePDF.Text = "Adobe PDF";
            this.chkbAdobePDF.UseVisualStyleBackColor = true;
            this.chkbAdobePDF.Visible = false;
            this.chkbAdobePDF.MouseLeave += new System.EventHandler(this.chkbAdobePDF_MouseLeave);
            this.chkbAdobePDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbAdobePDF_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.chkbAdobePDF);
            this.Controls.Add(this.chkbIbexpert);
            this.Controls.Add(this.chkbFirebird);
            this.Controls.Add(this.rbtnNaoAceito);
            this.Controls.Add(this.rbtnAceito);
            this.Controls.Add(this.lblPeqCabecalho1);
            this.Controls.Add(this.lblCabecalho1);
            this.Controls.Add(this.pPainel1);
            this.Controls.Add(this.pcibImagem);
            this.Controls.Add(this.lblInformacoescomp1);
            this.Controls.Add(this.rtxtContLic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            this.pPainel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcibImagem;
        private System.Windows.Forms.Panel pPainel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCabecalho1;
        private System.Windows.Forms.Label lblInformacoescomp1;
        private System.Windows.Forms.RichTextBox rtxtContLic;
        private System.Windows.Forms.Label lblPeqCabecalho1;
        private System.Windows.Forms.RadioButton rbtnAceito;
        private System.Windows.Forms.RadioButton rbtnNaoAceito;
        private System.Windows.Forms.CheckBox chkbFirebird;
        private System.Windows.Forms.CheckBox chkbIbexpert;
        private System.Windows.Forms.CheckBox chkbAdobePDF;
    }
}

