namespace Seven_Sistema
{
    partial class FrmEsqDetalhes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEsqDetalhes));
            this.ttpDetalhes = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.TemporizadorConexao = new System.Windows.Forms.Timer(this.components);
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblUltCustoUnit = new System.Windows.Forms.Label();
            this.txtUltCusto = new System.Windows.Forms.TextBox();
            this.lblPrecoAtual = new System.Windows.Forms.Label();
            this.txtPrecoAtual = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNovoPreco = new System.Windows.Forms.TextBox();
            this.lblNovoPreco = new System.Windows.Forms.Label();
            this.txtMargem = new System.Windows.Forms.TextBox();
            this.lblMargem = new System.Windows.Forms.Label();
            this.lblCustoUnitario = new System.Windows.Forms.Label();
            this.txtCustoUnitario = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblCustoTotal = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtCustoTotal = new System.Windows.Forms.TextBox();
            this.grbBox1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpDetalhes
            // 
            this.ttpDetalhes.AutoPopDelay = 5000;
            this.ttpDetalhes.InitialDelay = 1000;
            this.ttpDetalhes.IsBalloon = true;
            this.ttpDetalhes.ReshowDelay = 100;
            this.ttpDetalhes.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpDetalhes.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(463, 114);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 202;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDetalhes.SetToolTip(this.btnSair, "Sair de Detalhes.");
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // TemporizadorConexao
            // 
            this.TemporizadorConexao.Interval = 5000;
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblUltCustoUnit);
            this.grbBox1.Controls.Add(this.txtUltCusto);
            this.grbBox1.Controls.Add(this.lblPrecoAtual);
            this.grbBox1.Controls.Add(this.txtPrecoAtual);
            this.grbBox1.Controls.Add(this.lblQuantidade);
            this.grbBox1.Controls.Add(this.txtQuantidade);
            this.grbBox1.Controls.Add(this.groupBox1);
            this.grbBox1.Controls.Add(this.lblCustoUnitario);
            this.grbBox1.Controls.Add(this.txtCustoUnitario);
            this.grbBox1.Controls.Add(this.lblPreco);
            this.grbBox1.Controls.Add(this.lblCustoTotal);
            this.grbBox1.Controls.Add(this.txtPreco);
            this.grbBox1.Controls.Add(this.txtCustoTotal);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 106);
            this.grbBox1.TabIndex = 203;
            this.grbBox1.TabStop = false;
            // 
            // lblUltCustoUnit
            // 
            this.lblUltCustoUnit.AutoSize = true;
            this.lblUltCustoUnit.ForeColor = System.Drawing.Color.Blue;
            this.lblUltCustoUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUltCustoUnit.Location = new System.Drawing.Point(94, 56);
            this.lblUltCustoUnit.Name = "lblUltCustoUnit";
            this.lblUltCustoUnit.Size = new System.Drawing.Size(69, 13);
            this.lblUltCustoUnit.TabIndex = 44;
            this.lblUltCustoUnit.Tag = "";
            this.lblUltCustoUnit.Text = "Último Custo:";
            // 
            // txtUltCusto
            // 
            this.txtUltCusto.BackColor = System.Drawing.Color.White;
            this.txtUltCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUltCusto.Location = new System.Drawing.Point(97, 72);
            this.txtUltCusto.MaxLength = 10;
            this.txtUltCusto.Name = "txtUltCusto";
            this.txtUltCusto.ReadOnly = true;
            this.txtUltCusto.Size = new System.Drawing.Size(75, 20);
            this.txtUltCusto.TabIndex = 6;
            this.txtUltCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrecoAtual
            // 
            this.lblPrecoAtual.AutoSize = true;
            this.lblPrecoAtual.ForeColor = System.Drawing.Color.Blue;
            this.lblPrecoAtual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrecoAtual.Location = new System.Drawing.Point(6, 56);
            this.lblPrecoAtual.Name = "lblPrecoAtual";
            this.lblPrecoAtual.Size = new System.Drawing.Size(65, 13);
            this.lblPrecoAtual.TabIndex = 42;
            this.lblPrecoAtual.Tag = "";
            this.lblPrecoAtual.Text = "Preço Atual:";
            // 
            // txtPrecoAtual
            // 
            this.txtPrecoAtual.BackColor = System.Drawing.Color.White;
            this.txtPrecoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPrecoAtual.Location = new System.Drawing.Point(9, 72);
            this.txtPrecoAtual.MaxLength = 10;
            this.txtPrecoAtual.Name = "txtPrecoAtual";
            this.txtPrecoAtual.ReadOnly = true;
            this.txtPrecoAtual.Size = new System.Drawing.Size(75, 20);
            this.txtPrecoAtual.TabIndex = 5;
            this.txtPrecoAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.ForeColor = System.Drawing.Color.Blue;
            this.lblQuantidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQuantidade.Location = new System.Drawing.Point(184, 56);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 0;
            this.lblQuantidade.Tag = "";
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtQuantidade.Location = new System.Drawing.Point(187, 72);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ReadOnly = true;
            this.txtQuantidade.Size = new System.Drawing.Size(75, 20);
            this.txtQuantidade.TabIndex = 7;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNovoPreco);
            this.groupBox1.Controls.Add(this.lblNovoPreco);
            this.groupBox1.Controls.Add(this.txtMargem);
            this.groupBox1.Controls.Add(this.lblMargem);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(572, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 82);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // txtNovoPreco
            // 
            this.txtNovoPreco.BackColor = System.Drawing.Color.White;
            this.txtNovoPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNovoPreco.Location = new System.Drawing.Point(101, 33);
            this.txtNovoPreco.MaxLength = 10;
            this.txtNovoPreco.Name = "txtNovoPreco";
            this.txtNovoPreco.Size = new System.Drawing.Size(75, 20);
            this.txtNovoPreco.TabIndex = 12;
            this.txtNovoPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNovoPreco
            // 
            this.lblNovoPreco.AutoSize = true;
            this.lblNovoPreco.ForeColor = System.Drawing.Color.Black;
            this.lblNovoPreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNovoPreco.Location = new System.Drawing.Point(98, 16);
            this.lblNovoPreco.Name = "lblNovoPreco";
            this.lblNovoPreco.Size = new System.Drawing.Size(67, 13);
            this.lblNovoPreco.TabIndex = 0;
            this.lblNovoPreco.Tag = "";
            this.lblNovoPreco.Text = "Novo Preço:";
            // 
            // txtMargem
            // 
            this.txtMargem.BackColor = System.Drawing.Color.White;
            this.txtMargem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtMargem.Location = new System.Drawing.Point(9, 33);
            this.txtMargem.MaxLength = 10;
            this.txtMargem.Name = "txtMargem";
            this.txtMargem.Size = new System.Drawing.Size(75, 20);
            this.txtMargem.TabIndex = 11;
            this.txtMargem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMargem
            // 
            this.lblMargem.AutoSize = true;
            this.lblMargem.ForeColor = System.Drawing.Color.Black;
            this.lblMargem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMargem.Location = new System.Drawing.Point(6, 17);
            this.lblMargem.Name = "lblMargem";
            this.lblMargem.Size = new System.Drawing.Size(65, 13);
            this.lblMargem.TabIndex = 0;
            this.lblMargem.Tag = "";
            this.lblMargem.Text = "Margem (%):";
            // 
            // lblCustoUnitario
            // 
            this.lblCustoUnitario.AutoSize = true;
            this.lblCustoUnitario.ForeColor = System.Drawing.Color.Blue;
            this.lblCustoUnitario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustoUnitario.Location = new System.Drawing.Point(396, 56);
            this.lblCustoUnitario.Name = "lblCustoUnitario";
            this.lblCustoUnitario.Size = new System.Drawing.Size(73, 13);
            this.lblCustoUnitario.TabIndex = 0;
            this.lblCustoUnitario.Tag = "";
            this.lblCustoUnitario.Text = "Custo Unitário";
            // 
            // txtCustoUnitario
            // 
            this.txtCustoUnitario.BackColor = System.Drawing.Color.White;
            this.txtCustoUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustoUnitario.Location = new System.Drawing.Point(399, 72);
            this.txtCustoUnitario.MaxLength = 10;
            this.txtCustoUnitario.Name = "txtCustoUnitario";
            this.txtCustoUnitario.ReadOnly = true;
            this.txtCustoUnitario.Size = new System.Drawing.Size(75, 20);
            this.txtCustoUnitario.TabIndex = 9;
            this.txtCustoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.ForeColor = System.Drawing.Color.Blue;
            this.lblPreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPreco.Location = new System.Drawing.Point(279, 56);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(92, 13);
            this.lblPreco.TabIndex = 0;
            this.lblPreco.Text = "Preço de Compra:";
            // 
            // lblCustoTotal
            // 
            this.lblCustoTotal.AutoSize = true;
            this.lblCustoTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblCustoTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustoTotal.Location = new System.Drawing.Point(488, 56);
            this.lblCustoTotal.Name = "lblCustoTotal";
            this.lblCustoTotal.Size = new System.Drawing.Size(64, 13);
            this.lblCustoTotal.TabIndex = 0;
            this.lblCustoTotal.Tag = "";
            this.lblCustoTotal.Text = "Custo Total:";
            // 
            // txtPreco
            // 
            this.txtPreco.BackColor = System.Drawing.Color.White;
            this.txtPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPreco.Location = new System.Drawing.Point(282, 72);
            this.txtPreco.MaxLength = 15;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.ReadOnly = true;
            this.txtPreco.Size = new System.Drawing.Size(92, 20);
            this.txtPreco.TabIndex = 8;
            this.txtPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCustoTotal
            // 
            this.txtCustoTotal.BackColor = System.Drawing.Color.White;
            this.txtCustoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustoTotal.Location = new System.Drawing.Point(491, 72);
            this.txtCustoTotal.MaxLength = 10;
            this.txtCustoTotal.Name = "txtCustoTotal";
            this.txtCustoTotal.ReadOnly = true;
            this.txtCustoTotal.Size = new System.Drawing.Size(75, 20);
            this.txtCustoTotal.TabIndex = 10;
            this.txtCustoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmEsqDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(794, 150);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEsqDetalhes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes";
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpDetalhes;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Timer TemporizadorConexao;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblUltCustoUnit;
        private System.Windows.Forms.TextBox txtUltCusto;
        private System.Windows.Forms.Label lblPrecoAtual;
        private System.Windows.Forms.TextBox txtPrecoAtual;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNovoPreco;
        private System.Windows.Forms.Label lblNovoPreco;
        private System.Windows.Forms.TextBox txtMargem;
        private System.Windows.Forms.Label lblMargem;
        private System.Windows.Forms.Label lblCustoUnitario;
        private System.Windows.Forms.TextBox txtCustoUnitario;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblCustoTotal;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtCustoTotal;
    }
}