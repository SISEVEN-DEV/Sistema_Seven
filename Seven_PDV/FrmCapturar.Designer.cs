namespace Seven_Sistema
{
    partial class FrmCapturar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapturar));
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.ttpCapturar = new System.Windows.Forms.ToolTip(this.components);
            this.btnOrcamento = new System.Windows.Forms.Button();
            this.btnDevolucao = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnDav = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(322, 70);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 99;
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
            // btnOrcamento
            // 
            this.btnOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnOrcamento.Image")));
            this.btnOrcamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrcamento.Location = new System.Drawing.Point(6, 19);
            this.btnOrcamento.Name = "btnOrcamento";
            this.btnOrcamento.Size = new System.Drawing.Size(130, 25);
            this.btnOrcamento.TabIndex = 2;
            this.btnOrcamento.Text = "Capturar &Orçamento";
            this.btnOrcamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturar.SetToolTip(this.btnOrcamento, "Clique para capturar um Orçamento.");
            this.btnOrcamento.UseVisualStyleBackColor = true;
            this.btnOrcamento.Click += new System.EventHandler(this.btnOrcamento_Click);
            this.btnOrcamento.MouseLeave += new System.EventHandler(this.btnOrcamento_MouseLeave);
            this.btnOrcamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOrcamento_MouseMove);
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolucao.Image")));
            this.btnDevolucao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevolucao.Location = new System.Drawing.Point(144, 19);
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Size = new System.Drawing.Size(127, 25);
            this.btnDevolucao.TabIndex = 3;
            this.btnDevolucao.Text = "Capturar &Devolução";
            this.btnDevolucao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturar.SetToolTip(this.btnDevolucao, "Clique para capturar uma Devolução.");
            this.btnDevolucao.UseVisualStyleBackColor = true;
            this.btnDevolucao.Click += new System.EventHandler(this.button1_Click);
            this.btnDevolucao.MouseLeave += new System.EventHandler(this.btnDevolucao_MouseLeave);
            this.btnDevolucao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDevolucao_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(348, 70);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 32);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturar.SetToolTip(this.btnSair, "Sair de Capturar Orçamento/Devolução. ");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnDav
            // 
            this.btnDav.Image = ((System.Drawing.Image)(resources.GetObject("btnDav.Image")));
            this.btnDav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDav.Location = new System.Drawing.Point(276, 19);
            this.btnDav.Name = "btnDav";
            this.btnDav.Size = new System.Drawing.Size(107, 25);
            this.btnDav.TabIndex = 4;
            this.btnDav.Text = "Capturar &Venda";
            this.btnDav.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturar.SetToolTip(this.btnDav, "Clique para capturar uma Venda.");
            this.btnDav.UseVisualStyleBackColor = true;
            this.btnDav.Click += new System.EventHandler(this.btnDav_Click);
            this.btnDav.MouseLeave += new System.EventHandler(this.btnDav_MouseLeave);
            this.btnDav.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDav_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnDav);
            this.grbBox1.Controls.Add(this.btnOrcamento);
            this.grbBox1.Controls.Add(this.btnDevolucao);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(390, 52);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Escolha uma opção:";
            // 
            // FrmCapturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(416, 107);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.picbInterrogacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCapturar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCapOrcamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmCapOrcamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCapOrcamento_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.ToolTip ttpCapturar;
        private System.Windows.Forms.Button btnOrcamento;
        private System.Windows.Forms.Button btnDevolucao;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnDav;
    }
}