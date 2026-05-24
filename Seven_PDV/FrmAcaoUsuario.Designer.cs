namespace Seven_Sistema
{
    partial class FrmAcaoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcaoUsuario));
            this.lblLocalizar = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnHistoricoCaixa = new System.Windows.Forms.Button();
            this.btnInformacao = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpTipo = new System.Windows.Forms.ToolTip(this.components);
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLocalizar
            // 
            this.lblLocalizar.AutoSize = true;
            this.lblLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLocalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLocalizar.Location = new System.Drawing.Point(12, 9);
            this.lblLocalizar.Name = "lblLocalizar";
            this.lblLocalizar.Size = new System.Drawing.Size(234, 13);
            this.lblLocalizar.TabIndex = 0;
            this.lblLocalizar.Text = "Ações disponíveis para o Usuário atual:";
            // 
            // grbBox2
            // 
            this.grbBox2.BackColor = System.Drawing.Color.LightSlateGray;
            this.grbBox2.Controls.Add(this.btnHistoricoCaixa);
            this.grbBox2.Controls.Add(this.btnInformacao);
            this.grbBox2.Controls.Add(this.btnUsuario);
            this.grbBox2.Location = new System.Drawing.Point(12, 25);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(351, 51);
            this.grbBox2.TabIndex = 1;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações:";
            // 
            // btnHistoricoCaixa
            // 
            this.btnHistoricoCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoricoCaixa.Image")));
            this.btnHistoricoCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoricoCaixa.Location = new System.Drawing.Point(131, 19);
            this.btnHistoricoCaixa.Name = "btnHistoricoCaixa";
            this.btnHistoricoCaixa.Size = new System.Drawing.Size(118, 25);
            this.btnHistoricoCaixa.TabIndex = 3;
            this.btnHistoricoCaixa.Text = "&Histórico do Caixa";
            this.btnHistoricoCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTipo.SetToolTip(this.btnHistoricoCaixa, "Clique para visualizar o Histórico do Caixa.");
            this.btnHistoricoCaixa.UseVisualStyleBackColor = true;
            this.btnHistoricoCaixa.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnHistoricoCaixa.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnHistoricoCaixa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // btnInformacao
            // 
            this.btnInformacao.Image = ((System.Drawing.Image)(resources.GetObject("btnInformacao.Image")));
            this.btnInformacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformacao.Location = new System.Drawing.Point(255, 19);
            this.btnInformacao.Name = "btnInformacao";
            this.btnInformacao.Size = new System.Drawing.Size(87, 25);
            this.btnInformacao.TabIndex = 4;
            this.btnInformacao.Text = "&Informação";
            this.btnInformacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTipo.SetToolTip(this.btnInformacao, "Clique para visualizar as informações do Usuário atual.");
            this.btnInformacao.UseVisualStyleBackColor = true;
            this.btnInformacao.Click += new System.EventHandler(this.btnImprimirMatricial_Click);
            this.btnInformacao.MouseLeave += new System.EventHandler(this.btnImprimirMatricial_MouseLeave);
            this.btnInformacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimirMatricial_MouseMove);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuario.Image")));
            this.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuario.Location = new System.Drawing.Point(6, 19);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(119, 25);
            this.btnUsuario.TabIndex = 2;
            this.btnUsuario.Text = "Mudar de Usuário";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTipo.SetToolTip(this.btnUsuario, "Clique para mudar de Usuário.");
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnTodasContas_Click);
            this.btnUsuario.MouseLeave += new System.EventHandler(this.btnTodasContas_MouseLeave);
            this.btnUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTodasContas_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(308, 82);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTipo.SetToolTip(this.btnSair, "Clique para sair de Usuario do Sistema.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // ttpTipo
            // 
            this.ttpTipo.AutoPopDelay = 5000;
            this.ttpTipo.InitialDelay = 1000;
            this.ttpTipo.IsBalloon = true;
            this.ttpTipo.ReshowDelay = 100;
            this.ttpTipo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpTipo.ToolTipTitle = "Dica:";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 82);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 29;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // FrmAcaoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(365, 115);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.lblLocalizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAcaoUsuario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuário do Sistema";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTipoHistCaixa_FormClosing);
            this.Load += new System.EventHandler(this.FrmTipoHistCaixa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTipoHistCaixa_KeyUp);
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocalizar;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnHistoricoCaixa;
        private System.Windows.Forms.Button btnInformacao;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpTipo;
        private System.Windows.Forms.PictureBox picbInterrogacao;
    }
}