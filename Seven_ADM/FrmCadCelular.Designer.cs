namespace Seven_ADM
{
    partial class FrmCadCelular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadCelular));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.mtxtCelular = new System.Windows.Forms.MaskedTextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.ttpCelular = new System.Windows.Forms.ToolTip(this.components);
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.btnPesquisarForn = new System.Windows.Forms.Button();
            this.btnProcurarCliente = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(174, 94);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(98, 94);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 6;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnIncluir, "Clique para incluir um número de celular.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.mtxtCelular);
            this.grbBox1.Controls.Add(this.lblCelular);
            this.grbBox1.Location = new System.Drawing.Point(99, 43);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(128, 45);
            this.grbBox1.TabIndex = 4;
            this.grbBox1.TabStop = false;
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(111, -4);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // mtxtCelular
            // 
            this.mtxtCelular.BackColor = System.Drawing.Color.White;
            this.mtxtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCelular.Location = new System.Drawing.Point(6, 19);
            this.mtxtCelular.Mask = "(00) 00000-0000";
            this.mtxtCelular.Name = "mtxtCelular";
            this.mtxtCelular.Size = new System.Drawing.Size(116, 20);
            this.mtxtCelular.TabIndex = 5;
            this.mtxtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtCelular.Enter += new System.EventHandler(this.mtxtCelular_Enter);
            this.mtxtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCelular_KeyPress);
            this.mtxtCelular.Leave += new System.EventHandler(this.mtxtCelular_Leave);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelular.Location = new System.Drawing.Point(9, -1);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(107, 13);
            this.lblCelular.TabIndex = 0;
            this.lblCelular.Text = "Informe o Celular:";
            // 
            // ttpCelular
            // 
            this.ttpCelular.AutoPopDelay = 5000;
            this.ttpCelular.InitialDelay = 1000;
            this.ttpCelular.IsBalloon = true;
            this.ttpCelular.ReshowDelay = 100;
            this.ttpCelular.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCelular.ToolTipTitle = "Dica:";
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnFuncionario.Image")));
            this.btnFuncionario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFuncionario.Location = new System.Drawing.Point(233, 12);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(85, 25);
            this.btnFuncionario.TabIndex = 3;
            this.btnFuncionario.Text = "&Funcionário";
            this.btnFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnFuncionario, "Clique para selecionar um Funcionário.");
            this.btnFuncionario.UseVisualStyleBackColor = true;
            this.btnFuncionario.Click += new System.EventHandler(this.btnFuncionario_Click);
            // 
            // btnPesquisarForn
            // 
            this.btnPesquisarForn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarForn.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarForn.Image")));
            this.btnPesquisarForn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisarForn.Location = new System.Drawing.Point(142, 12);
            this.btnPesquisarForn.Name = "btnPesquisarForn";
            this.btnPesquisarForn.Size = new System.Drawing.Size(85, 25);
            this.btnPesquisarForn.TabIndex = 2;
            this.btnPesquisarForn.Text = "For&necedor";
            this.btnPesquisarForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnPesquisarForn, "Clique para selecionar um Fornecedor.");
            this.btnPesquisarForn.UseVisualStyleBackColor = true;
            this.btnPesquisarForn.Click += new System.EventHandler(this.btnPesquisarForn_Click);
            // 
            // btnProcurarCliente
            // 
            this.btnProcurarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarCliente.Image")));
            this.btnProcurarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcurarCliente.Location = new System.Drawing.Point(12, 12);
            this.btnProcurarCliente.Name = "btnProcurarCliente";
            this.btnProcurarCliente.Size = new System.Drawing.Size(124, 25);
            this.btnProcurarCliente.TabIndex = 1;
            this.btnProcurarCliente.Text = "&Cliente/Consumidor";
            this.btnProcurarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnProcurarCliente, "Clique para selecionar um Cliente/Consumidor");
            this.btnProcurarCliente.UseVisualStyleBackColor = true;
            this.btnProcurarCliente.Click += new System.EventHandler(this.btnProcurarCliente_Click);
            // 
            // FrmCadCelular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(329, 131);
            this.ControlBox = false;
            this.Controls.Add(this.btnFuncionario);
            this.Controls.Add(this.btnPesquisarForn);
            this.Controls.Add(this.btnProcurarCliente);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadCelular";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Celular";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadCelular_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadCelular_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadCelular_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.MaskedTextBox mtxtCelular;
        private System.Windows.Forms.ToolTip ttpCelular;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Button btnPesquisarForn;
        private System.Windows.Forms.Button btnProcurarCliente;
        private System.Windows.Forms.Label lblCelular;
    }
}