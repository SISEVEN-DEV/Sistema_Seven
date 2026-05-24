namespace _7_Sistema_Instalador
{
    partial class FrmInstalador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstalador));
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.pPainel1 = new System.Windows.Forms.Panel();
            this.lblSiseven = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTelzap = new System.Windows.Forms.Label();
            this.lblCabecalho1 = new System.Windows.Forms.Label();
            this.lblInformacoescomp1 = new System.Windows.Forms.Label();
            this.rtxtContLic = new System.Windows.Forms.RichTextBox();
            this.lblPeqCabecalho1 = new System.Windows.Forms.Label();
            this.rbtnAceito = new System.Windows.Forms.RadioButton();
            this.rbtnNaoAceito = new System.Windows.Forms.RadioButton();
            this.chkbFirebird = new System.Windows.Forms.CheckBox();
            this.chkbIbexpert = new System.Windows.Forms.CheckBox();
            this.pgrBarraDeProgresso = new System.Windows.Forms.ProgressBar();
            this.chkbNetProvider = new System.Windows.Forms.CheckBox();
            this.chkbIniciarADM = new System.Windows.Forms.CheckBox();
            this.lblLegendaIbe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            this.pPainel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcibImagem
            // 
            this.pcibImagem.BackColor = System.Drawing.Color.Gainsboro;
            this.pcibImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcibImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem.Image = ((System.Drawing.Image)(resources.GetObject("pcibImagem.Image")));
            this.pcibImagem.Location = new System.Drawing.Point(0, 0);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(165, 325);
            this.pcibImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcibImagem.TabIndex = 0;
            this.pcibImagem.TabStop = false;
            // 
            // pPainel1
            // 
            this.pPainel1.BackColor = System.Drawing.Color.LightGray;
            this.pPainel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPainel1.Controls.Add(this.lblSiseven);
            this.pPainel1.Controls.Add(this.btnVoltar);
            this.pPainel1.Controls.Add(this.btnAvancar);
            this.pPainel1.Controls.Add(this.btnCancelar);
            this.pPainel1.Controls.Add(this.lblTelzap);
            this.pPainel1.Location = new System.Drawing.Point(0, 324);
            this.pPainel1.Name = "pPainel1";
            this.pPainel1.Size = new System.Drawing.Size(634, 87);
            this.pPainel1.TabIndex = 1;
            // 
            // lblSiseven
            // 
            this.lblSiseven.AutoSize = true;
            this.lblSiseven.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiseven.Location = new System.Drawing.Point(11, 52);
            this.lblSiseven.Name = "lblSiseven";
            this.lblSiseven.Size = new System.Drawing.Size(105, 13);
            this.lblSiseven.TabIndex = 7;
            this.lblSiseven.Text = "www.siseven.com.br";
            this.lblSiseven.Click += new System.EventHandler(this.lblSiseven_Click);
            this.lblSiseven.MouseLeave += new System.EventHandler(this.lblSiseven_MouseLeave);
            this.lblSiseven.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSiseven_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Enabled = false;
            this.btnVoltar.Location = new System.Drawing.Point(317, 42);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(80, 23);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "<< &Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvancar.Location = new System.Drawing.Point(403, 42);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(80, 23);
            this.btnAvancar.TabIndex = 2;
            this.btnAvancar.Text = "&Avançar >>";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Location = new System.Drawing.Point(541, 42);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancela&r";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTelzap
            // 
            this.lblTelzap.AutoSize = true;
            this.lblTelzap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelzap.Location = new System.Drawing.Point(11, 64);
            this.lblTelzap.Name = "lblTelzap";
            this.lblTelzap.Size = new System.Drawing.Size(160, 13);
            this.lblTelzap.TabIndex = 86;
            this.lblTelzap.Text = "Tel/Whatsapp: (75) 98271-6595";
            this.lblTelzap.Click += new System.EventHandler(this.lblTelzap_Click);
            this.lblTelzap.MouseLeave += new System.EventHandler(this.lblTelzap_MouseLeave);
            this.lblTelzap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTelzap_MouseMove);
            // 
            // lblCabecalho1
            // 
            this.lblCabecalho1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalho1.Location = new System.Drawing.Point(200, 25);
            this.lblCabecalho1.Name = "lblCabecalho1";
            this.lblCabecalho1.Size = new System.Drawing.Size(420, 32);
            this.lblCabecalho1.TabIndex = 0;
            this.lblCabecalho1.Text = "Bem-vindo ao assistente de instalação do software\r\nSistema SEVEN ©";
            // 
            // lblInformacoescomp1
            // 
            this.lblInformacoescomp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacoescomp1.Location = new System.Drawing.Point(200, 129);
            this.lblInformacoescomp1.Name = "lblInformacoescomp1";
            this.lblInformacoescomp1.Size = new System.Drawing.Size(420, 91);
            this.lblInformacoescomp1.TabIndex = 0;
            this.lblInformacoescomp1.Text = "Este assistente irá instalar o software Sistema SEVEN e outros componentes em seu" +
    " computador clique em avançar para continuar a instalação.\r\n\r\n\r\n\r\n\r\nSISEVEN DEV©" +
    "\r\n\r\n\r\n\r\n";
            // 
            // rtxtContLic
            // 
            this.rtxtContLic.Location = new System.Drawing.Point(203, 97);
            this.rtxtContLic.Name = "rtxtContLic";
            this.rtxtContLic.ReadOnly = true;
            this.rtxtContLic.Size = new System.Drawing.Size(417, 175);
            this.rtxtContLic.TabIndex = 11;
            this.rtxtContLic.Text = resources.GetString("rtxtContLic.Text");
            this.rtxtContLic.Visible = false;
            // 
            // lblPeqCabecalho1
            // 
            this.lblPeqCabecalho1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeqCabecalho1.Location = new System.Drawing.Point(200, 80);
            this.lblPeqCabecalho1.Name = "lblPeqCabecalho1";
            this.lblPeqCabecalho1.Size = new System.Drawing.Size(420, 66);
            this.lblPeqCabecalho1.TabIndex = 0;
            this.lblPeqCabecalho1.Text = "Leia atentamente o contrato de licença:";
            this.lblPeqCabecalho1.Visible = false;
            // 
            // rbtnAceito
            // 
            this.rbtnAceito.AutoSize = true;
            this.rbtnAceito.Location = new System.Drawing.Point(203, 278);
            this.rbtnAceito.Name = "rbtnAceito";
            this.rbtnAceito.Size = new System.Drawing.Size(345, 17);
            this.rbtnAceito.TabIndex = 4;
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
            this.rbtnNaoAceito.TabIndex = 5;
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
            this.chkbFirebird.Location = new System.Drawing.Point(203, 97);
            this.chkbFirebird.Name = "chkbFirebird";
            this.chkbFirebird.Size = new System.Drawing.Size(78, 17);
            this.chkbFirebird.TabIndex = 6;
            this.chkbFirebird.Text = "&Firebird 2.5";
            this.chkbFirebird.UseVisualStyleBackColor = true;
            this.chkbFirebird.Visible = false;
            this.chkbFirebird.CheckedChanged += new System.EventHandler(this.chkbFirebird_CheckedChanged);
            this.chkbFirebird.MouseLeave += new System.EventHandler(this.chkbFirebird_MouseLeave);
            this.chkbFirebird.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbFirebird_MouseMove);
            // 
            // chkbIbexpert
            // 
            this.chkbIbexpert.AutoSize = true;
            this.chkbIbexpert.Location = new System.Drawing.Point(203, 143);
            this.chkbIbexpert.Name = "chkbIbexpert";
            this.chkbIbexpert.Size = new System.Drawing.Size(66, 17);
            this.chkbIbexpert.TabIndex = 8;
            this.chkbIbexpert.Text = "I&BExpert";
            this.chkbIbexpert.UseVisualStyleBackColor = true;
            this.chkbIbexpert.Visible = false;
            this.chkbIbexpert.MouseLeave += new System.EventHandler(this.chkbIbexpert_MouseLeave);
            this.chkbIbexpert.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbIbexpert_MouseMove);
            // 
            // pgrBarraDeProgresso
            // 
            this.pgrBarraDeProgresso.Location = new System.Drawing.Point(203, 80);
            this.pgrBarraDeProgresso.Name = "pgrBarraDeProgresso";
            this.pgrBarraDeProgresso.Size = new System.Drawing.Size(417, 23);
            this.pgrBarraDeProgresso.TabIndex = 0;
            this.pgrBarraDeProgresso.Visible = false;
            // 
            // chkbNetProvider
            // 
            this.chkbNetProvider.AutoSize = true;
            this.chkbNetProvider.Location = new System.Drawing.Point(203, 120);
            this.chkbNetProvider.Name = "chkbNetProvider";
            this.chkbNetProvider.Size = new System.Drawing.Size(108, 17);
            this.chkbNetProvider.TabIndex = 7;
            this.chkbNetProvider.Text = "&NET Provider 2.5";
            this.chkbNetProvider.UseVisualStyleBackColor = true;
            this.chkbNetProvider.Visible = false;
            this.chkbNetProvider.MouseLeave += new System.EventHandler(this.chkbNetProvider_MouseLeave);
            this.chkbNetProvider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbNetProvider_MouseMove);
            // 
            // chkbIniciarADM
            // 
            this.chkbIniciarADM.AutoSize = true;
            this.chkbIniciarADM.Location = new System.Drawing.Point(203, 149);
            this.chkbIniciarADM.Name = "chkbIniciarADM";
            this.chkbIniciarADM.Size = new System.Drawing.Size(189, 17);
            this.chkbIniciarADM.TabIndex = 10;
            this.chkbIniciarADM.Text = "Executar o &Sistema SEVEN - ADM";
            this.chkbIniciarADM.UseVisualStyleBackColor = true;
            this.chkbIniciarADM.Visible = false;
            this.chkbIniciarADM.MouseLeave += new System.EventHandler(this.chkbIniciarADM_MouseLeave);
            this.chkbIniciarADM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbIniciarADM_MouseMove);
            // 
            // lblLegendaIbe
            // 
            this.lblLegendaIbe.AutoSize = true;
            this.lblLegendaIbe.Location = new System.Drawing.Point(200, 106);
            this.lblLegendaIbe.Name = "lblLegendaIbe";
            this.lblLegendaIbe.Size = new System.Drawing.Size(158, 13);
            this.lblLegendaIbe.TabIndex = 13;
            this.lblLegendaIbe.Text = "Instalando, por favor, aguarde...";
            this.lblLegendaIbe.Visible = false;
            // 
            // FrmInstalador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.rtxtContLic);
            this.Controls.Add(this.chkbFirebird);
            this.Controls.Add(this.chkbNetProvider);
            this.Controls.Add(this.chkbIbexpert);
            this.Controls.Add(this.rbtnNaoAceito);
            this.Controls.Add(this.rbtnAceito);
            this.Controls.Add(this.lblCabecalho1);
            this.Controls.Add(this.pPainel1);
            this.Controls.Add(this.pcibImagem);
            this.Controls.Add(this.chkbIniciarADM);
            this.Controls.Add(this.lblInformacoescomp1);
            this.Controls.Add(this.pgrBarraDeProgresso);
            this.Controls.Add(this.lblLegendaIbe);
            this.Controls.Add(this.lblPeqCabecalho1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmInstalador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instalador - Sistema SEVEN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInstalador_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            this.pPainel1.ResumeLayout(false);
            this.pPainel1.PerformLayout();
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
        private System.Windows.Forms.ProgressBar pgrBarraDeProgresso;
        private System.Windows.Forms.CheckBox chkbNetProvider;
        private System.Windows.Forms.CheckBox chkbIniciarADM;
        private System.Windows.Forms.Label lblSiseven;
        private System.Windows.Forms.Label lblLegendaIbe;
        private System.Windows.Forms.Label lblTelzap;
    }
}

