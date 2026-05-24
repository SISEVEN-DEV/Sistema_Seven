namespace Seven_Sistema
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.btnQtdeEntidades = new System.Windows.Forms.Button();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.cbbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnLogar = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.pcibLogo = new System.Windows.Forms.PictureBox();
            this.ttpLogin = new System.Windows.Forms.ToolTip(this.components);
            this.lblSiseven = new System.Windows.Forms.Label();
            this.timerEntidade = new System.Windows.Forms.Timer(this.components);
            this.lblTelzap = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(287, 360);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLogin.SetToolTip(this.btnSair, "Sair do Login.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAsterisco3);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.btnQtdeEntidades);
            this.grbBox1.Controls.Add(this.btnVer);
            this.grbBox1.Controls.Add(this.cbbEmpresa);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.txtSenha);
            this.grbBox1.Controls.Add(this.lblSenha);
            this.grbBox1.Controls.Add(this.txtUsuario);
            this.grbBox1.Controls.Add(this.lblEmpresa);
            this.grbBox1.Location = new System.Drawing.Point(16, 235);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(490, 119);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(185, 91);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(185, 65);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // btnQtdeEntidades
            // 
            this.btnQtdeEntidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQtdeEntidades.Location = new System.Drawing.Point(458, 33);
            this.btnQtdeEntidades.Name = "btnQtdeEntidades";
            this.btnQtdeEntidades.Size = new System.Drawing.Size(26, 25);
            this.btnQtdeEntidades.TabIndex = 6;
            this.btnQtdeEntidades.Text = "1";
            this.ttpLogin.SetToolTip(this.btnQtdeEntidades, "Quantidade de Empresas/Entidades cadastradas.");
            this.btnQtdeEntidades.UseVisualStyleBackColor = true;
            this.btnQtdeEntidades.Click += new System.EventHandler(this.btnQtdeEntidades_Click);
            this.btnQtdeEntidades.MouseLeave += new System.EventHandler(this.btnQtdeEntidades_MouseLeave);
            this.btnQtdeEntidades.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnQtdeEntidades_MouseMove);
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(116, 12);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco3.TabIndex = 0;
            this.lblAsterisco3.Text = "*";
            // 
            // btnVer
            // 
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.Location = new System.Drawing.Point(316, 89);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(26, 25);
            this.btnVer.TabIndex = 5;
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLogin.SetToolTip(this.btnVer, "Clique para mostrar/esconder a senha.");
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            this.btnVer.MouseLeave += new System.EventHandler(this.btnVer_MouseLeave);
            this.btnVer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVer_MouseMove);
            // 
            // cbbEmpresa
            // 
            this.cbbEmpresa.BackColor = System.Drawing.Color.LightBlue;
            this.cbbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEmpresa.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cbbEmpresa.FormattingEnabled = true;
            this.cbbEmpresa.Location = new System.Drawing.Point(6, 32);
            this.cbbEmpresa.Name = "cbbEmpresa";
            this.cbbEmpresa.Size = new System.Drawing.Size(447, 27);
            this.cbbEmpresa.TabIndex = 2;
            this.cbbEmpresa.DropDown += new System.EventHandler(this.cbbEmpresa_DropDown);
            this.cbbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbbEmpresa_SelectedIndexChanged);
            this.cbbEmpresa.DropDownClosed += new System.EventHandler(this.cbbEmpresa_DropDownClosed);
            this.cbbEmpresa.MouseLeave += new System.EventHandler(this.cbbEmpresa_MouseLeave);
            this.cbbEmpresa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbEmpresa_MouseMove);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.Color.Black;
            this.lblEmpresa.Location = new System.Drawing.Point(6, 16);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(139, 13);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa/Entidade:";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(132, 69);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(58, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário(a):";
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(198, 92);
            this.txtSenha.MaxLength = 10;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '●';
            this.txtSenha.Size = new System.Drawing.Size(112, 20);
            this.txtSenha.TabIndex = 4;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(149, 95);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 0;
            this.lblSenha.Text = "Senha:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptsTab = true;
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(198, 66);
            this.txtUsuario.MaxLength = 10;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(112, 20);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // btnLogar
            // 
            this.btnLogar.Image = ((System.Drawing.Image)(resources.GetObject("btnLogar.Image")));
            this.btnLogar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLogar.Location = new System.Drawing.Point(197, 360);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(70, 32);
            this.btnLogar.TabIndex = 6;
            this.btnLogar.Text = "&Logar";
            this.btnLogar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLogin.SetToolTip(this.btnLogar, "Clique para acessar o aplicativo.");
            this.btnLogar.UseVisualStyleBackColor = true;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            this.btnLogar.MouseLeave += new System.EventHandler(this.btnLogar_MouseLeave);
            this.btnLogar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLogar_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(16, 360);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 6;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // pcibLogo
            // 
            this.pcibLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pcibLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcibLogo.Image")));
            this.pcibLogo.Location = new System.Drawing.Point(16, -49);
            this.pcibLogo.Name = "pcibLogo";
            this.pcibLogo.Size = new System.Drawing.Size(490, 350);
            this.pcibLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibLogo.TabIndex = 10;
            this.pcibLogo.TabStop = false;
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
            // lblSiseven
            // 
            this.lblSiseven.AutoSize = true;
            this.lblSiseven.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiseven.Location = new System.Drawing.Point(12, 379);
            this.lblSiseven.Name = "lblSiseven";
            this.lblSiseven.Size = new System.Drawing.Size(105, 13);
            this.lblSiseven.TabIndex = 11;
            this.lblSiseven.Text = "www.siseven.com.br";
            this.lblSiseven.Click += new System.EventHandler(this.lblSiseven_Click);
            this.lblSiseven.MouseLeave += new System.EventHandler(this.lblSiseven_MouseLeave);
            this.lblSiseven.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSiseven_MouseMove);
            // 
            // timerEntidade
            // 
            this.timerEntidade.Interval = 1000;
            this.timerEntidade.Tick += new System.EventHandler(this.timerEntidade_Tick);
            // 
            // lblTelzap
            // 
            this.lblTelzap.AutoSize = true;
            this.lblTelzap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelzap.Location = new System.Drawing.Point(350, 379);
            this.lblTelzap.Name = "lblTelzap";
            this.lblTelzap.Size = new System.Drawing.Size(160, 13);
            this.lblTelzap.TabIndex = 86;
            this.lblTelzap.Text = "Tel/Whatsapp: (75) 98271-6595";
            this.lblTelzap.Click += new System.EventHandler(this.lblTelzap_Click);
            this.lblTelzap.MouseLeave += new System.EventHandler(this.lblTelzap_MouseLeave);
            this.lblTelzap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTelzap_MouseMove);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(522, 399);
            this.Controls.Add(this.lblTelzap);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.pcibLogo);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnLogar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblSiseven);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema SEVEN - PDV | Logar-se";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Button btnLogar;
        public System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox pcibLogo;
        private System.Windows.Forms.ComboBox cbbEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.ToolTip ttpLogin;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblSiseven;
        private System.Windows.Forms.Button btnQtdeEntidades;
        private System.Windows.Forms.Timer timerEntidade;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblTelzap;
    }
}