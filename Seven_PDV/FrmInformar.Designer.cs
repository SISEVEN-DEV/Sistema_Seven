namespace Seven_Sistema
{
    partial class FrmInformar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformar));
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnManualmente = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.ttpCapturar = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(251, 70);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 32);
            this.btnSair.TabIndex = 255;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturar.SetToolTip(this.btnSair, "Sair de Informar Consumidor. ");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.btnManualmente);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(291, 52);
            this.grbBox1.TabIndex = 254;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Escolha uma opção:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(6, 19);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(136, 25);
            this.btnPesquisar.TabIndex = 100;
            this.btnPesquisar.Text = "&Pesquisar Consumidor";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturar.SetToolTip(this.btnPesquisar, "Clique para pesquisar um consumidor cadastrado.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnManualmente
            // 
            this.btnManualmente.Image = ((System.Drawing.Image)(resources.GetObject("btnManualmente.Image")));
            this.btnManualmente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManualmente.Location = new System.Drawing.Point(148, 19);
            this.btnManualmente.Name = "btnManualmente";
            this.btnManualmente.Size = new System.Drawing.Size(137, 25);
            this.btnManualmente.TabIndex = 101;
            this.btnManualmente.Text = "&Informar Manualmente";
            this.btnManualmente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturar.SetToolTip(this.btnManualmente, "Clique para informar um consumidor manualmente.");
            this.btnManualmente.UseVisualStyleBackColor = true;
            this.btnManualmente.Click += new System.EventHandler(this.btnManualmente_Click);
            this.btnManualmente.MouseLeave += new System.EventHandler(this.btnDevolucao_MouseLeave);
            this.btnManualmente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDevolucao_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(225, 70);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 253;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // ttpCapturar
            // 
            this.ttpCapturar.AutoPopDelay = 5000;
            this.ttpCapturar.InitialDelay = 1000;
            this.ttpCapturar.IsBalloon = true;
            this.ttpCapturar.ReshowDelay = 100;
            this.ttpCapturar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCapturar.ToolTipTitle = "Dica:";
            // 
            // FrmInformar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(317, 108);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.picbInterrogacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInformar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informar Consumidor";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInformar_FormClosing);
            this.Load += new System.EventHandler(this.FrmInformar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmInformar_KeyUp);
            this.grbBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnManualmente;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.ToolTip ttpCapturar;
    }
}