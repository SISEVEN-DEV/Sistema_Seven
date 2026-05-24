namespace Seven_Sistema
{
    partial class FrmAbrirCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbrirCaixa));
            this.lblMensagemTopo = new System.Windows.Forms.Label();
            this.lblSaldoInicial = new System.Windows.Forms.Label();
            this.txtSaldoInicial = new System.Windows.Forms.TextBox();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblAserisco1 = new System.Windows.Forms.Label();
            this.ttpAbrir = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensagemTopo
            // 
            this.lblMensagemTopo.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblMensagemTopo.ForeColor = System.Drawing.Color.Black;
            this.lblMensagemTopo.Location = new System.Drawing.Point(0, 9);
            this.lblMensagemTopo.Name = "lblMensagemTopo";
            this.lblMensagemTopo.Size = new System.Drawing.Size(256, 44);
            this.lblMensagemTopo.TabIndex = 0;
            this.lblMensagemTopo.Text = "Abrir o Caixa";
            this.lblMensagemTopo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaldoInicial
            // 
            this.lblSaldoInicial.AutoSize = true;
            this.lblSaldoInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoInicial.Location = new System.Drawing.Point(12, 73);
            this.lblSaldoInicial.Name = "lblSaldoInicial";
            this.lblSaldoInicial.Size = new System.Drawing.Size(152, 20);
            this.lblSaldoInicial.TabIndex = 0;
            this.lblSaldoInicial.Text = "Saldo Inicial (R$):";
            // 
            // txtSaldoInicial
            // 
            this.txtSaldoInicial.BackColor = System.Drawing.Color.White;
            this.txtSaldoInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoInicial.Location = new System.Drawing.Point(12, 96);
            this.txtSaldoInicial.MaxLength = 10;
            this.txtSaldoInicial.Name = "txtSaldoInicial";
            this.txtSaldoInicial.Size = new System.Drawing.Size(227, 44);
            this.txtSaldoInicial.TabIndex = 1;
            this.txtSaldoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaldoInicial.Enter += new System.EventHandler(this.txtSaldoInicial_Enter);
            this.txtSaldoInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldoInicial_KeyPress);
            this.txtSaldoInicial.Leave += new System.EventHandler(this.txtSaldoInicial_Leave);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(81, 146);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 78;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(107, 146);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(72, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAbrir.SetToolTip(this.btnSalvar, "Salvar dados informados e abrir o caixa.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // lblAserisco1
            // 
            this.lblAserisco1.AutoSize = true;
            this.lblAserisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAserisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAserisco1.Location = new System.Drawing.Point(158, 72);
            this.lblAserisco1.Name = "lblAserisco1";
            this.lblAserisco1.Size = new System.Drawing.Size(16, 20);
            this.lblAserisco1.TabIndex = 0;
            this.lblAserisco1.Text = "*";
            // 
            // ttpAbrir
            // 
            this.ttpAbrir.AutoPopDelay = 5000;
            this.ttpAbrir.InitialDelay = 1000;
            this.ttpAbrir.IsBalloon = true;
            this.ttpAbrir.ReshowDelay = 100;
            this.ttpAbrir.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAbrir.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(185, 146);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 32);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAbrir.SetToolTip(this.btnSair, "Sair de Abrir o Caixa.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // FrmAbrirCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(251, 183);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblAserisco1);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtSaldoInicial);
            this.Controls.Add(this.lblSaldoInicial);
            this.Controls.Add(this.lblMensagemTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbrirCaixa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abrir Caixa";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAbrirCaixa_FormClosing);
            this.Load += new System.EventHandler(this.FrmAbrirCaixa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAbrirCaixa_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMensagemTopo;
        private System.Windows.Forms.Label lblSaldoInicial;
        private System.Windows.Forms.TextBox txtSaldoInicial;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblAserisco1;
        private System.Windows.Forms.ToolTip ttpAbrir;
        private System.Windows.Forms.Button btnSair;
    }
}