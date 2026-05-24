namespace Sistema_SEVEN_Config
{
    partial class FrmLocalizarBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalizarBanco));
            this.btnEscolherLocal = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cbbTipoConexao = new System.Windows.Forms.ComboBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.txtCaminhoBanco = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.ttpCadComputadores = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEscolherLocal
            // 
            this.btnEscolherLocal.Image = ((System.Drawing.Image)(resources.GetObject("btnEscolherLocal.Image")));
            this.btnEscolherLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherLocal.Location = new System.Drawing.Point(512, 29);
            this.btnEscolherLocal.Name = "btnEscolherLocal";
            this.btnEscolherLocal.Size = new System.Drawing.Size(176, 25);
            this.btnEscolherLocal.TabIndex = 5;
            this.btnEscolherLocal.Text = "Localizar um &Banco de Dados";
            this.btnEscolherLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnEscolherLocal, "Clique para localizar um banco de dados.");
            this.btnEscolherLocal.UseVisualStyleBackColor = true;
            this.btnEscolherLocal.Click += new System.EventHandler(this.btnEscolherLocal_Click);
            this.btnEscolherLocal.MouseLeave += new System.EventHandler(this.btnEscolherLocal_MouseLeave);
            this.btnEscolherLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEscolherLocal_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.cbbTipoConexao);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.txtCaminhoBanco);
            this.grbBox1.Controls.Add(this.btnEscolherLocal);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(695, 58);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Localizar/Informar Banco de Dados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Caminho:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(6, 16);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(31, 13);
            this.lblUsuario.TabIndex = 14;
            this.lblUsuario.Text = "Tipo:";
            // 
            // cbbTipoConexao
            // 
            this.cbbTipoConexao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoConexao.DropDownHeight = 250;
            this.cbbTipoConexao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoConexao.FormattingEnabled = true;
            this.cbbTipoConexao.IntegralHeight = false;
            this.cbbTipoConexao.Items.AddRange(new object[] {
            "LOCAL",
            "REDE"});
            this.cbbTipoConexao.Location = new System.Drawing.Point(9, 32);
            this.cbbTipoConexao.Name = "cbbTipoConexao";
            this.cbbTipoConexao.Size = new System.Drawing.Size(90, 21);
            this.cbbTipoConexao.TabIndex = 2;
            this.cbbTipoConexao.DropDown += new System.EventHandler(this.cbbTipoConexao_DropDown);
            this.cbbTipoConexao.SelectedIndexChanged += new System.EventHandler(this.cbbTipoConexao_SelectedIndexChanged);
            this.cbbTipoConexao.DropDownClosed += new System.EventHandler(this.cbbTipoConexao_DropDownClosed);
            this.cbbTipoConexao.MouseLeave += new System.EventHandler(this.cbbTipoConexao_MouseLeave);
            this.cbbTipoConexao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoConexao_MouseMove);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(179, -3);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 12;
            this.lblAsterisco1.Text = "*";
            // 
            // txtCaminhoBanco
            // 
            this.txtCaminhoBanco.BackColor = System.Drawing.Color.White;
            this.txtCaminhoBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCaminhoBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminhoBanco.Location = new System.Drawing.Point(105, 32);
            this.txtCaminhoBanco.MaxLength = 120;
            this.txtCaminhoBanco.Name = "txtCaminhoBanco";
            this.txtCaminhoBanco.Size = new System.Drawing.Size(401, 20);
            this.txtCaminhoBanco.TabIndex = 4;
            this.txtCaminhoBanco.Enter += new System.EventHandler(this.txtCaminhoBanco_Enter);
            this.txtCaminhoBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaminhoBanco_KeyPress);
            this.txtCaminhoBanco.Leave += new System.EventHandler(this.txtCaminhoBanco_Leave);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(652, 76);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnSair, "Sair de Cadastro de Computadores");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnContinuar.Location = new System.Drawing.Point(560, 76);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(86, 32);
            this.btnContinuar.TabIndex = 6;
            this.btnContinuar.Text = "&Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnContinuar, "Clique para continuar a configuração com o Banco de Dados informado.");
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            this.btnContinuar.MouseLeave += new System.EventHandler(this.btnContinuar_MouseLeave);
            this.btnContinuar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnContinuar_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 76);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 35;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // ttpCadComputadores
            // 
            this.ttpCadComputadores.AutoPopDelay = 5000;
            this.ttpCadComputadores.InitialDelay = 1000;
            this.ttpCadComputadores.IsBalloon = true;
            this.ttpCadComputadores.ReshowDelay = 100;
            this.ttpCadComputadores.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCadComputadores.ToolTipTitle = "Dica:";
            // 
            // FrmLocalizarBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(720, 114);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocalizarBanco";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Computadores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLocalizarBanco_FormClosing);
            this.Load += new System.EventHandler(this.FrmLocalizarBanco_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLocalizarBanco_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEscolherLocal;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtCaminhoBanco;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.ComboBox cbbTipoConexao;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.ToolTip ttpCadComputadores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
    }
}