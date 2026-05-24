namespace Seven_Sistema
{
    partial class FrmValorCreditoLoja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValorCreditoLoja));
            this.ttpCred = new System.Windows.Forms.ToolTip(this.components);
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorDisponivel = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.lblItens = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // ttpCred
            // 
            this.ttpCred.AutoPopDelay = 5000;
            this.ttpCred.InitialDelay = 1000;
            this.ttpCred.IsBalloon = true;
            this.ttpCred.ReshowDelay = 100;
            this.ttpCred.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCred.ToolTipTitle = "Dica:";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAtualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAtualizar.Location = new System.Drawing.Point(10, 37);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(34, 32);
            this.btnAtualizar.TabIndex = 2;
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCred.SetToolTip(this.btnAtualizar, "Clique para atualizar o valor do crédito que o consumidor possui.");
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            this.btnAtualizar.MouseLeave += new System.EventHandler(this.btnAtualizar_MouseLeave);
            this.btnAtualizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAtualizar_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(336, 111);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(72, 32);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCred.SetToolTip(this.btnSalvar, "Clique para salvar o dado informado.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(414, 111);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Sai&r";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCred.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.btnAtualizar);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.txtValorDisponivel);
            this.grbBox1.Controls.Add(this.txtValor);
            this.grbBox1.Controls.Add(this.lblDesconto);
            this.grbBox1.Location = new System.Drawing.Point(12, 31);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(457, 74);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Crédito da Loja:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(400, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor (R$):";
            // 
            // txtValorDisponivel
            // 
            this.txtValorDisponivel.BackColor = System.Drawing.Color.White;
            this.txtValorDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDisponivel.Location = new System.Drawing.Point(120, 39);
            this.txtValorDisponivel.MaxLength = 18;
            this.txtValorDisponivel.Name = "txtValorDisponivel";
            this.txtValorDisponivel.ReadOnly = true;
            this.txtValorDisponivel.Size = new System.Drawing.Size(151, 26);
            this.txtValorDisponivel.TabIndex = 3;
            this.txtValorDisponivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.White;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(315, 38);
            this.txtValor.MaxLength = 18;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(136, 26);
            this.txtValor.TabIndex = 4;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.Enter += new System.EventHandler(this.txtValor_Enter);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(6, 16);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(271, 20);
            this.lblDesconto.TabIndex = 0;
            this.lblDesconto.Text = "Valor do Crédito Disponível (R$):";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(310, 111);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 99;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // lblItens
            // 
            this.lblItens.BackColor = System.Drawing.Color.AliceBlue;
            this.lblItens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblItens.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblItens.Location = new System.Drawing.Point(12, 9);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(457, 19);
            this.lblItens.TabIndex = 0;
            this.lblItens.Text = "O consumidor possui o seguinte valor disponível em crédito loja:";
            this.lblItens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmValorCreditoLoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(483, 147);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblItens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmValorCreditoLoja";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crédito da Loja";
              this.TopMost = false;
            this.Load += new System.EventHandler(this.FrmConfCadAluno_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmValorCreditoLoja_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpCred;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValorDisponivel;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblItens;
    }
}