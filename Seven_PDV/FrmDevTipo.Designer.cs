namespace Seven_Sistema
{
    partial class FrmDevTipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevTipo));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnGerarCredito = new System.Windows.Forms.Button();
            this.btnDevDinheiro = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.ttpDevolucao = new System.Windows.Forms.ToolTip(this.components);
            this.lblValor = new System.Windows.Forms.Label();
            this.lblItens = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnGerarCredito);
            this.grbBox1.Controls.Add(this.btnDevDinheiro);
            this.grbBox1.Location = new System.Drawing.Point(12, 37);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(321, 55);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Escolha uma das opções:";
            // 
            // btnGerarCredito
            // 
            this.btnGerarCredito.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarCredito.Image")));
            this.btnGerarCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarCredito.Location = new System.Drawing.Point(217, 19);
            this.btnGerarCredito.Name = "btnGerarCredito";
            this.btnGerarCredito.Size = new System.Drawing.Size(98, 25);
            this.btnGerarCredito.TabIndex = 3;
            this.btnGerarCredito.Text = "Gerar &Crédito";
            this.btnGerarCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnGerarCredito, "Para fazer a devolução em crédito da loja para o consumidor.");
            this.btnGerarCredito.UseVisualStyleBackColor = true;
            this.btnGerarCredito.Click += new System.EventHandler(this.btnGerarCredito_Click);
            this.btnGerarCredito.MouseLeave += new System.EventHandler(this.btnGerarCredito_MouseLeave);
            this.btnGerarCredito.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGerarCredito_MouseMove);
            // 
            // btnDevDinheiro
            // 
            this.btnDevDinheiro.Image = ((System.Drawing.Image)(resources.GetObject("btnDevDinheiro.Image")));
            this.btnDevDinheiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevDinheiro.Location = new System.Drawing.Point(6, 19);
            this.btnDevDinheiro.Name = "btnDevDinheiro";
            this.btnDevDinheiro.Size = new System.Drawing.Size(120, 25);
            this.btnDevDinheiro.TabIndex = 2;
            this.btnDevDinheiro.Text = "&Devolver Dinheiro";
            this.btnDevDinheiro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnDevDinheiro, "Clique para fazer a devolução da venda em dinheiro para o consumidor.");
            this.btnDevDinheiro.UseVisualStyleBackColor = true;
            this.btnDevDinheiro.Click += new System.EventHandler(this.btnDevDinheiro_Click);
            this.btnDevDinheiro.MouseLeave += new System.EventHandler(this.btnDevDinheiro_MouseLeave);
            this.btnDevDinheiro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDevDinheiro_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(278, 98);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnVoltar, "Sair da Devolução/Troca de Produtos");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // ttpDevolucao
            // 
            this.ttpDevolucao.AutoPopDelay = 5000;
            this.ttpDevolucao.InitialDelay = 1000;
            this.ttpDevolucao.IsBalloon = true;
            this.ttpDevolucao.ReshowDelay = 100;
            this.ttpDevolucao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpDevolucao.ToolTipTitle = "Dica:";
            // 
            // lblValor
            // 
            this.lblValor.BackColor = System.Drawing.Color.AliceBlue;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.Red;
            this.lblValor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValor.Location = new System.Drawing.Point(210, 14);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(121, 16);
            this.lblValor.TabIndex = 5;
            this.lblValor.Text = "0,00";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItens
            // 
            this.lblItens.BackColor = System.Drawing.Color.AliceBlue;
            this.lblItens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblItens.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblItens.Location = new System.Drawing.Point(12, 9);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(321, 25);
            this.lblItens.TabIndex = 6;
            this.lblItens.Text = "O que fazer com o valor de:";
            this.lblItens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDevTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(345, 136);
            this.ControlBox = false;
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDevTipo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução/Troca de Produtos";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDevTipo_FormClosing);
            this.Load += new System.EventHandler(this.FrmDevTipo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmDevTipo_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnGerarCredito;
        private System.Windows.Forms.Button btnDevDinheiro;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.ToolTip ttpDevolucao;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblItens;
    }
}