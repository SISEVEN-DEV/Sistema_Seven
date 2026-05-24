namespace Seven_Sistema
{
    partial class FrmCadProdPrecoVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadProdPrecoVenda));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ttpTurma = new System.Windows.Forms.ToolTip(this.components);
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtLucroPorc = new System.Windows.Forms.TextBox();
            this.txtAliqTributacao = new System.Windows.Forms.TextBox();
            this.lblPrecoCusto = new System.Windows.Forms.Label();
            this.txtPrecoCusto = new System.Windows.Forms.TextBox();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.lblDespesas = new System.Windows.Forms.Label();
            this.lblValorLucro = new System.Windows.Forms.Label();
            this.txtOutrasDespesas = new System.Windows.Forms.TextBox();
            this.txtValorLucro = new System.Windows.Forms.TextBox();
            this.lblLucroPorc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(501, 80);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTurma.SetToolTip(this.btnSalvar, "Salvar os dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // ttpTurma
            // 
            this.ttpTurma.AutoPopDelay = 5000;
            this.ttpTurma.InitialDelay = 1000;
            this.ttpTurma.IsBalloon = true;
            this.ttpTurma.ReshowDelay = 100;
            this.ttpTurma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpTurma.ToolTipTitle = "Dica:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(577, 80);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 9;
            this.btnVoltar.Text = "V&oltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTurma.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Enabled = false;
            this.btnAplicar.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(490, 29);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(26, 25);
            this.btnAplicar.TabIndex = 39;
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTurma.SetToolTip(this.btnAplicar, "Clique para aplicar o preço de venda calculado.");
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            this.btnAplicar.MouseLeave += new System.EventHandler(this.btnAplicar_MouseLeave);
            this.btnAplicar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAplicar_MouseMove);
            // 
            // txtLucroPorc
            // 
            this.txtLucroPorc.BackColor = System.Drawing.Color.White;
            this.txtLucroPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtLucroPorc.Location = new System.Drawing.Point(143, 32);
            this.txtLucroPorc.MaxLength = 9;
            this.txtLucroPorc.Name = "txtLucroPorc";
            this.txtLucroPorc.Size = new System.Drawing.Size(46, 20);
            this.txtLucroPorc.TabIndex = 3;
            this.txtLucroPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLucroPorc.Enter += new System.EventHandler(this.txtLucroPorc_Enter);
            this.txtLucroPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLucroPorc_KeyPress);
            this.txtLucroPorc.Leave += new System.EventHandler(this.txtLucroPorc_Leave);
            // 
            // txtAliqTributacao
            // 
            this.txtAliqTributacao.BackColor = System.Drawing.Color.White;
            this.txtAliqTributacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAliqTributacao.Location = new System.Drawing.Point(308, 32);
            this.txtAliqTributacao.MaxLength = 9;
            this.txtAliqTributacao.Name = "txtAliqTributacao";
            this.txtAliqTributacao.Size = new System.Drawing.Size(46, 20);
            this.txtAliqTributacao.TabIndex = 5;
            this.txtAliqTributacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAliqTributacao.Enter += new System.EventHandler(this.txtAliqTributacao_Enter);
            this.txtAliqTributacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliqTributacao_KeyPress);
            this.txtAliqTributacao.Leave += new System.EventHandler(this.txtAliqTributacao_Leave);
            // 
            // lblPrecoCusto
            // 
            this.lblPrecoCusto.AutoSize = true;
            this.lblPrecoCusto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrecoCusto.Location = new System.Drawing.Point(3, 16);
            this.lblPrecoCusto.Name = "lblPrecoCusto";
            this.lblPrecoCusto.Size = new System.Drawing.Size(131, 13);
            this.lblPrecoCusto.TabIndex = 0;
            this.lblPrecoCusto.Tag = "";
            this.lblPrecoCusto.Text = "Preço de Custo Unit. (R$):";
            // 
            // txtPrecoCusto
            // 
            this.txtPrecoCusto.BackColor = System.Drawing.Color.White;
            this.txtPrecoCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPrecoCusto.Location = new System.Drawing.Point(6, 32);
            this.txtPrecoCusto.MaxLength = 9;
            this.txtPrecoCusto.Name = "txtPrecoCusto";
            this.txtPrecoCusto.Size = new System.Drawing.Size(92, 20);
            this.txtPrecoCusto.TabIndex = 2;
            this.txtPrecoCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecoCusto.Enter += new System.EventHandler(this.txtPrecoCusto_Enter);
            this.txtPrecoCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecoCusto_KeyPress);
            this.txtPrecoCusto.Leave += new System.EventHandler(this.txtPrecoCusto_Leave);
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.BackColor = System.Drawing.Color.White;
            this.txtPrecoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPrecoVenda.Location = new System.Drawing.Point(522, 32);
            this.txtPrecoVenda.MaxLength = 9;
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.ReadOnly = true;
            this.txtPrecoVenda.Size = new System.Drawing.Size(92, 20);
            this.txtPrecoVenda.TabIndex = 7;
            this.txtPrecoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecoVenda.Enter += new System.EventHandler(this.txtPrecoVenda_Enter);
            this.txtPrecoVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecoVenda_KeyPress);
            this.txtPrecoVenda.Leave += new System.EventHandler(this.txtPrecoVenda_Leave);
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.ForeColor = System.Drawing.Color.Blue;
            this.lblPrecoVenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrecoVenda.Location = new System.Drawing.Point(519, 16);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(110, 13);
            this.lblPrecoVenda.TabIndex = 0;
            this.lblPrecoVenda.Tag = "";
            this.lblPrecoVenda.Text = "Preço de Venda (R$):";
            // 
            // lblDespesas
            // 
            this.lblDespesas.AutoSize = true;
            this.lblDespesas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDespesas.Location = new System.Drawing.Point(389, 16);
            this.lblDespesas.Name = "lblDespesas";
            this.lblDespesas.Size = new System.Drawing.Size(80, 13);
            this.lblDespesas.TabIndex = 0;
            this.lblDespesas.Tag = "";
            this.lblDespesas.Text = "Despesas (R$):";
            // 
            // lblValorLucro
            // 
            this.lblValorLucro.AutoSize = true;
            this.lblValorLucro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValorLucro.Location = new System.Drawing.Point(204, 16);
            this.lblValorLucro.Name = "lblValorLucro";
            this.lblValorLucro.Size = new System.Drawing.Size(60, 13);
            this.lblValorLucro.TabIndex = 0;
            this.lblValorLucro.Tag = "";
            this.lblValorLucro.Text = "Lucro (R$):";
            // 
            // txtOutrasDespesas
            // 
            this.txtOutrasDespesas.BackColor = System.Drawing.Color.White;
            this.txtOutrasDespesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtOutrasDespesas.Location = new System.Drawing.Point(392, 32);
            this.txtOutrasDespesas.MaxLength = 9;
            this.txtOutrasDespesas.Name = "txtOutrasDespesas";
            this.txtOutrasDespesas.Size = new System.Drawing.Size(92, 20);
            this.txtOutrasDespesas.TabIndex = 6;
            this.txtOutrasDespesas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutrasDespesas.Enter += new System.EventHandler(this.txtOutrasDespesas_Enter);
            this.txtOutrasDespesas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutrasDespesas_KeyPress);
            this.txtOutrasDespesas.Leave += new System.EventHandler(this.txtOutrasDespesas_Leave);
            // 
            // txtValorLucro
            // 
            this.txtValorLucro.BackColor = System.Drawing.Color.White;
            this.txtValorLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtValorLucro.Location = new System.Drawing.Point(207, 32);
            this.txtValorLucro.MaxLength = 9;
            this.txtValorLucro.Name = "txtValorLucro";
            this.txtValorLucro.Size = new System.Drawing.Size(92, 20);
            this.txtValorLucro.TabIndex = 4;
            this.txtValorLucro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorLucro.Enter += new System.EventHandler(this.txtValorLucro_Enter);
            this.txtValorLucro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorLucro_KeyPress);
            this.txtValorLucro.Leave += new System.EventHandler(this.txtValorLucro_Leave);
            // 
            // lblLucroPorc
            // 
            this.lblLucroPorc.AutoSize = true;
            this.lblLucroPorc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLucroPorc.Location = new System.Drawing.Point(140, 16);
            this.lblLucroPorc.Name = "lblLucroPorc";
            this.lblLucroPorc.Size = new System.Drawing.Size(37, 13);
            this.lblLucroPorc.TabIndex = 0;
            this.lblLucroPorc.Tag = "";
            this.lblLucroPorc.Text = "Lucro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(305, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Aliq. Tributação:";
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label4);
            this.grbBox1.Controls.Add(this.btnAplicar);
            this.grbBox1.Controls.Add(this.label3);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.lblLucroPorc);
            this.grbBox1.Controls.Add(this.txtValorLucro);
            this.grbBox1.Controls.Add(this.txtOutrasDespesas);
            this.grbBox1.Controls.Add(this.lblValorLucro);
            this.grbBox1.Controls.Add(this.lblDespesas);
            this.grbBox1.Controls.Add(this.lblPrecoVenda);
            this.grbBox1.Controls.Add(this.txtPrecoVenda);
            this.grbBox1.Controls.Add(this.txtPrecoCusto);
            this.grbBox1.Controls.Add(this.lblPrecoCusto);
            this.grbBox1.Controls.Add(this.txtAliqTributacao);
            this.grbBox1.Controls.Add(this.txtLucroPorc);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(635, 62);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Calcular Preço de Venda: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(129, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 36;
            this.label4.Tag = "";
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(354, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 0;
            this.label3.Tag = "";
            this.label3.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(189, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "";
            this.label2.Text = "%";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 80);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 35;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // FrmCadProdPrecoVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(656, 118);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FrmCadProdPrecoVenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preço de Venda";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadProdPrecoVenda_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadProdEstMin_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadProdPrecoVenda_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ToolTip ttpTurma;
        private System.Windows.Forms.TextBox txtLucroPorc;
        private System.Windows.Forms.TextBox txtAliqTributacao;
        private System.Windows.Forms.Label lblPrecoCusto;
        private System.Windows.Forms.TextBox txtPrecoCusto;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.Label lblDespesas;
        private System.Windows.Forms.Label lblValorLucro;
        private System.Windows.Forms.TextBox txtOutrasDespesas;
        private System.Windows.Forms.TextBox txtValorLucro;
        private System.Windows.Forms.Label lblLucroPorc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label label4;
    }
}