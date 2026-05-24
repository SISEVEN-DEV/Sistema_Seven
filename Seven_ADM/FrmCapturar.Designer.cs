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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapturar));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnDFe = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnOrcamento = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnDFe);
            this.grbBox1.Controls.Add(this.btnVenda);
            this.grbBox1.Controls.Add(this.btnOrcamento);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(366, 52);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Escolha uma opção:";
            // 
            // btnDFe
            // 
            this.btnDFe.Image = ((System.Drawing.Image)(resources.GetObject("btnDFe.Image")));
            this.btnDFe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDFe.Location = new System.Drawing.Point(260, 19);
            this.btnDFe.Name = "btnDFe";
            this.btnDFe.Size = new System.Drawing.Size(98, 25);
            this.btnDFe.TabIndex = 4;
            this.btnDFe.Text = "Capturar &DFe";
            this.btnDFe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDFe.UseVisualStyleBackColor = true;
            this.btnDFe.Click += new System.EventHandler(this.button2_Click);
            this.btnDFe.MouseLeave += new System.EventHandler(this.btnDFe_MouseLeave);
            this.btnDFe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button2_MouseMove);
            // 
            // btnVenda
            // 
            this.btnVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnVenda.Image")));
            this.btnVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVenda.Location = new System.Drawing.Point(142, 19);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(112, 25);
            this.btnVenda.TabIndex = 3;
            this.btnVenda.Text = "Capturar &Venda";
            this.btnVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVenda.UseVisualStyleBackColor = true;
            this.btnVenda.Click += new System.EventHandler(this.button1_Click);
            this.btnVenda.MouseLeave += new System.EventHandler(this.btnVenda_MouseLeave);
            this.btnVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVenda_MouseMove);
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
            this.btnOrcamento.UseVisualStyleBackColor = true;
            this.btnOrcamento.Click += new System.EventHandler(this.btnOrcamento_Click);
            this.btnOrcamento.MouseLeave += new System.EventHandler(this.btnOrcamento_MouseLeave);
            this.btnOrcamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOrcamento_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(324, 70);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 32);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(298, 70);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 253;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // FrmCapturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(390, 108);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCapturar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar Orçamento/DFe/Venda/XML";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCapturar_FormClosing);
            this.Load += new System.EventHandler(this.FrmCapturar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCapturar_KeyUp);
            this.grbBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnOrcamento;
        private System.Windows.Forms.Button btnDFe;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picbInterrogacao;
    }
}