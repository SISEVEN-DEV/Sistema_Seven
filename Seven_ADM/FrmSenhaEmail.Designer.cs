namespace Seven_Sistema
{
    partial class FrmSenhaEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSenhaEmail));
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.lblLocalizar = new System.Windows.Forms.Label();
            this.btnLogar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.ttpLogin = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 71);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 39;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // lblLocalizar
            // 
            this.lblLocalizar.AutoSize = true;
            this.lblLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLocalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLocalizar.Location = new System.Drawing.Point(12, 9);
            this.lblLocalizar.Name = "lblLocalizar";
            this.lblLocalizar.Size = new System.Drawing.Size(173, 13);
            this.lblLocalizar.TabIndex = 0;
            this.lblLocalizar.Text = "Entre com a senha do E-mail:";
            // 
            // btnLogar
            // 
            this.btnLogar.Image = ((System.Drawing.Image)(resources.GetObject("btnLogar.Image")));
            this.btnLogar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLogar.Location = new System.Drawing.Point(85, 71);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(70, 32);
            this.btnLogar.TabIndex = 4;
            this.btnLogar.Text = "&Logar";
            this.btnLogar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLogin.SetToolTip(this.btnLogar, "Clique para validar o usuário.");
            this.btnLogar.UseVisualStyleBackColor = true;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            this.btnLogar.MouseLeave += new System.EventHandler(this.btnLogar_MouseLeave);
            this.btnLogar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLogar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(161, 71);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLogin.SetToolTip(this.btnSair, "Sair do formulário Logar-se.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.btnVer);
            this.grbBox1.Controls.Add(this.txtSenha);
            this.grbBox1.Controls.Add(this.lblSenha);
            this.grbBox1.Location = new System.Drawing.Point(12, 25);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(204, 40);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Logar:";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(42, 15);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // btnVer
            // 
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.Location = new System.Drawing.Point(171, 10);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(26, 25);
            this.btnVer.TabIndex = 3;
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLogin.SetToolTip(this.btnVer, "Clique para mostrar/esconder a senha.");
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            this.btnVer.MouseLeave += new System.EventHandler(this.btnVer_MouseLeave);
            this.btnVer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVer_MouseMove);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(53, 13);
            this.txtSenha.MaxLength = 60;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '●';
            this.txtSenha.Size = new System.Drawing.Size(112, 20);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(6, 16);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 0;
            this.lblSenha.Text = "Senha:";
            // 
            // ttpLogin
            // 
            this.ttpLogin.AutoPopDelay = 5000;
            this.ttpLogin.InitialDelay = 1000;
            this.ttpLogin.IsBalloon = true;
            this.ttpLogin.ReshowDelay = 100;
            this.ttpLogin.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpLogin.ToolTipTitle = "Dica:";
            // 
            // FrmSenhaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(225, 107);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.lblLocalizar);
            this.Controls.Add(this.btnLogar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSenhaEmail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logar-se ao E-mail";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSenhaEmail_FormClosing);
            this.Load += new System.EventHandler(this.FrmSenhaEmail_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmSenhaEmail_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label lblLocalizar;
        private System.Windows.Forms.Button btnLogar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.ToolTip ttpLogin;
    }
}