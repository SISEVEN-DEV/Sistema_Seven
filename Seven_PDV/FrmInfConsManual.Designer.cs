namespace Seven_Sistema
{
    partial class FrmInfConsManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInfConsManual));
            this.ttpItem = new System.Windows.Forms.ToolTip(this.components);
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.mtxtCPF = new System.Windows.Forms.MaskedTextBox();
            this.mtxtCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.rbtnPfisica = new System.Windows.Forms.RadioButton();
            this.rbtnPjuridica = new System.Windows.Forms.RadioButton();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblCNPJMensagem = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCPF_CNPJ = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // ttpItem
            // 
            this.ttpItem.AutoPopDelay = 5000;
            this.ttpItem.InitialDelay = 1000;
            this.ttpItem.IsBalloon = true;
            this.ttpItem.ReshowDelay = 100;
            this.ttpItem.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpItem.ToolTipTitle = "Dica:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(375, 100);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnVoltar, "Sair do Informar Consumidor.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnSair_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(299, 100);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 9;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(6, 55);
            this.txtNome.MaxLength = 60;
            this.txtNome.Name = "txtNome";
            this.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNome.Size = new System.Drawing.Size(275, 20);
            this.txtNome.TabIndex = 6;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // mtxtCPF
            // 
            this.mtxtCPF.BackColor = System.Drawing.Color.White;
            this.mtxtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCPF.Location = new System.Drawing.Point(287, 55);
            this.mtxtCPF.Mask = "000,000,000-00";
            this.mtxtCPF.Name = "mtxtCPF";
            this.mtxtCPF.Size = new System.Drawing.Size(98, 20);
            this.mtxtCPF.TabIndex = 7;
            this.mtxtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtCPF.Enter += new System.EventHandler(this.mtxtCPF_Enter);
            this.mtxtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCPF_KeyPress);
            this.mtxtCPF.Leave += new System.EventHandler(this.mtxtCPF_Leave);
            // 
            // mtxtCNPJ
            // 
            this.mtxtCNPJ.BackColor = System.Drawing.Color.White;
            this.mtxtCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtCNPJ.Location = new System.Drawing.Point(287, 55);
            this.mtxtCNPJ.Mask = "00,000,000/0000-00";
            this.mtxtCNPJ.Name = "mtxtCNPJ";
            this.mtxtCNPJ.Size = new System.Drawing.Size(123, 20);
            this.mtxtCNPJ.TabIndex = 8;
            this.mtxtCNPJ.Visible = false;
            this.mtxtCNPJ.Enter += new System.EventHandler(this.mtxtCNPJ_Enter);
            this.mtxtCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCNPJ_KeyPress);
            this.mtxtCNPJ.Leave += new System.EventHandler(this.mtxtCNPJ_Leave);
            // 
            // rbtnPfisica
            // 
            this.rbtnPfisica.AutoSize = true;
            this.rbtnPfisica.Location = new System.Drawing.Point(6, 19);
            this.rbtnPfisica.Name = "rbtnPfisica";
            this.rbtnPfisica.Size = new System.Drawing.Size(92, 17);
            this.rbtnPfisica.TabIndex = 2;
            this.rbtnPfisica.Text = "Pessoa Física";
            this.rbtnPfisica.UseVisualStyleBackColor = true;
            this.rbtnPfisica.CheckedChanged += new System.EventHandler(this.rbtnPfisica_CheckedChanged);
            this.rbtnPfisica.MouseLeave += new System.EventHandler(this.rbtnPfisica_MouseLeave);
            this.rbtnPfisica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPfisica_MouseMove);
            // 
            // rbtnPjuridica
            // 
            this.rbtnPjuridica.AutoSize = true;
            this.rbtnPjuridica.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rbtnPjuridica.Location = new System.Drawing.Point(102, 19);
            this.rbtnPjuridica.Name = "rbtnPjuridica";
            this.rbtnPjuridica.Size = new System.Drawing.Size(101, 17);
            this.rbtnPjuridica.TabIndex = 3;
            this.rbtnPjuridica.Text = "Pessoa Jurídica";
            this.rbtnPjuridica.UseVisualStyleBackColor = true;
            this.rbtnPjuridica.CheckedChanged += new System.EventHandler(this.rbtnPjuridica_CheckedChanged);
            this.rbtnPjuridica.MouseLeave += new System.EventHandler(this.rbtnPjuridica_MouseLeave);
            this.rbtnPjuridica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPjuridica_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblCNPJMensagem);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.lblNome);
            this.grbBox1.Controls.Add(this.mtxtCPF);
            this.grbBox1.Controls.Add(this.mtxtCNPJ);
            this.grbBox1.Controls.Add(this.txtNome);
            this.grbBox1.Controls.Add(this.rbtnPfisica);
            this.grbBox1.Controls.Add(this.rbtnPjuridica);
            this.grbBox1.Controls.Add(this.lblCPF_CNPJ);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(418, 82);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações do Consumidor:";
            // 
            // lblCNPJMensagem
            // 
            this.lblCNPJMensagem.AutoSize = true;
            this.lblCNPJMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCNPJMensagem.ForeColor = System.Drawing.Color.Red;
            this.lblCNPJMensagem.Location = new System.Drawing.Point(203, 9);
            this.lblCNPJMensagem.Name = "lblCNPJMensagem";
            this.lblCNPJMensagem.Size = new System.Drawing.Size(217, 30);
            this.lblCNPJMensagem.TabIndex = 36;
            this.lblCNPJMensagem.Text = "Os dados do CNPJ serão obtidos\r\npor meio de consulta online.";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(39, 36);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 35;
            this.lblAsterisco2.Text = "*";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(309, 36);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 39);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 4;
            this.lblNome.Text = "Nome:";
            // 
            // lblCPF_CNPJ
            // 
            this.lblCPF_CNPJ.AutoSize = true;
            this.lblCPF_CNPJ.Location = new System.Drawing.Point(284, 39);
            this.lblCPF_CNPJ.Name = "lblCPF_CNPJ";
            this.lblCPF_CNPJ.Size = new System.Drawing.Size(30, 13);
            this.lblCPF_CNPJ.TabIndex = 34;
            this.lblCPF_CNPJ.Text = "CPF:";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 100);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 84;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            // 
            // FrmInfConsManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(442, 138);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInfConsManual";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informar Consumidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInfConsManual_FormClosing);
            this.Load += new System.EventHandler(this.FrmHistOrcamentoItens_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmHistOrcamentoItens_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpItem;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.MaskedTextBox mtxtCPF;
        private System.Windows.Forms.MaskedTextBox mtxtCNPJ;
        private System.Windows.Forms.RadioButton rbtnPfisica;
        private System.Windows.Forms.RadioButton rbtnPjuridica;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF_CNPJ;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblCNPJMensagem;
        private System.Windows.Forms.PictureBox picbInterrogacao;
    }
}