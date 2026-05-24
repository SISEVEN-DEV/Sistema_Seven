namespace Seven_Sistema
{
    partial class FrmPesqFormaPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqFormaPagamento));
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtFormaPagamento = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTipo = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnTodas = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.cbbpTipoPagamento = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.ttpFormaPagamento = new System.Windows.Forms.ToolTip(this.components);
            this.btnCadastrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 273);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 12;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFormaPagamento
            // 
            this.dtFormaPagamento.AllowUserToAddRows = false;
            this.dtFormaPagamento.AllowUserToDeleteRows = false;
            this.dtFormaPagamento.AllowUserToResizeRows = false;
            this.dtFormaPagamento.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFormaPagamento.Enabled = false;
            this.dtFormaPagamento.Location = new System.Drawing.Point(12, 98);
            this.dtFormaPagamento.MultiSelect = false;
            this.dtFormaPagamento.Name = "dtFormaPagamento";
            this.dtFormaPagamento.ReadOnly = true;
            this.dtFormaPagamento.RowHeadersVisible = false;
            this.dtFormaPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFormaPagamento.ShowCellErrors = false;
            this.dtFormaPagamento.ShowCellToolTips = false;
            this.dtFormaPagamento.ShowEditingIcon = false;
            this.dtFormaPagamento.ShowRowErrors = false;
            this.dtFormaPagamento.Size = new System.Drawing.Size(674, 172);
            this.dtFormaPagamento.TabIndex = 14;
            this.dtFormaPagamento.DataSourceChanged += new System.EventHandler(this.dtFormaPagamento_DataSourceChanged);
            this.dtFormaPagamento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFormaPagamento_CellContentClick);
            this.dtFormaPagamento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFormaPagamento_CellEnter);
            this.dtFormaPagamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtFormaPagamento_CellFormatting);
            this.dtFormaPagamento.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFormaPagamento_RowsAdded);
            this.dtFormaPagamento.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFormaPagamento_RowsRemoved);
            this.dtFormaPagamento.DoubleClick += new System.EventHandler(this.dtFormaPagamento_DoubleClick);
            this.dtFormaPagamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFormaPagamento_KeyDown);
            this.dtFormaPagamento.MouseLeave += new System.EventHandler(this.dtFormaPagamento_MouseLeave);
            this.dtFormaPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFormaPagamento_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTipo);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnTodas);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.cbbpTipoPagamento);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(674, 80);
            this.grbBox1.TabIndex = 13;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTipo
            // 
            this.rbtnTipo.AutoSize = true;
            this.rbtnTipo.Location = new System.Drawing.Point(6, 42);
            this.rbtnTipo.Name = "rbtnTipo";
            this.rbtnTipo.Size = new System.Drawing.Size(118, 17);
            this.rbtnTipo.TabIndex = 75;
            this.rbtnTipo.Text = "Tipo de Pagamento";
            this.rbtnTipo.UseVisualStyleBackColor = true;
            this.rbtnTipo.CheckedChanged += new System.EventHandler(this.rbtnTipo_CheckedChanged);
            this.rbtnTipo.MouseLeave += new System.EventHandler(this.rbtnTipo_MouseLeave);
            this.rbtnTipo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTipo_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(315, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // rbtnTodas
            // 
            this.rbtnTodas.AutoSize = true;
            this.rbtnTodas.Location = new System.Drawing.Point(130, 42);
            this.rbtnTodas.Name = "rbtnTodas";
            this.rbtnTodas.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodas.TabIndex = 5;
            this.rbtnTodas.Text = "Todas";
            this.rbtnTodas.UseVisualStyleBackColor = true;
            this.rbtnTodas.CheckedChanged += new System.EventHandler(this.rbtnTodas_CheckedChanged);
            this.rbtnTodas.MouseLeave += new System.EventHandler(this.rbtnTodas_MouseLeave);
            this.rbtnTodas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodas_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(558, 44);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 74;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(584, 44);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFormaPagamento.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnDescricao
            // 
            this.rbtnDescricao.AutoSize = true;
            this.rbtnDescricao.Checked = true;
            this.rbtnDescricao.Location = new System.Drawing.Point(6, 19);
            this.rbtnDescricao.Name = "rbtnDescricao";
            this.rbtnDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtnDescricao.TabIndex = 1;
            this.rbtnDescricao.TabStop = true;
            this.rbtnDescricao.Text = "Descrição";
            this.rbtnDescricao.UseVisualStyleBackColor = true;
            this.rbtnDescricao.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnDescricao.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(130, 18);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(623, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtpCodigo.TabIndex = 9;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // cbbpTipoPagamento
            // 
            this.cbbpTipoPagamento.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipoPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipoPagamento.FormattingEnabled = true;
            this.cbbpTipoPagamento.Items.AddRange(new object[] {
            "",
            "DINHEIRO",
            "CARTAO DE CREDITO",
            "CARTAO DE DEBITO",
            "NOTA PROMISSORIA",
            "PIX"});
            this.cbbpTipoPagamento.Location = new System.Drawing.Point(521, 18);
            this.cbbpTipoPagamento.Name = "cbbpTipoPagamento";
            this.cbbpTipoPagamento.Size = new System.Drawing.Size(145, 21);
            this.cbbpTipoPagamento.TabIndex = 7;
            this.cbbpTipoPagamento.Visible = false;
            this.cbbpTipoPagamento.DropDown += new System.EventHandler(this.cbbpTipoPagamento_DropDown);
            this.cbbpTipoPagamento.DropDownClosed += new System.EventHandler(this.cbbpTipoPagamento_DropDownClosed);
            this.cbbpTipoPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipoPagamento_KeyPress);
            this.cbbpTipoPagamento.MouseLeave += new System.EventHandler(this.cbbpTipoPagamento_MouseLeave);
            this.cbbpTipoPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTipoPagamento_MouseMove);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpDescricao.Location = new System.Drawing.Point(435, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.Size = new System.Drawing.Size(230, 20);
            this.txtpDescricao.TabIndex = 6;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(631, 276);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 17;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFormaPagamento.SetToolTip(this.btnVoltar, "Sair da pesquisa de forma de pagamento.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(555, 276);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 16;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFormaPagamento.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // ttpFormaPagamento
            // 
            this.ttpFormaPagamento.AutoPopDelay = 5000;
            this.ttpFormaPagamento.InitialDelay = 1000;
            this.ttpFormaPagamento.IsBalloon = true;
            this.ttpFormaPagamento.ReshowDelay = 100;
            this.ttpFormaPagamento.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpFormaPagamento.ToolTipTitle = "Dica:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCadastrar.Location = new System.Drawing.Point(463, 276);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(86, 32);
            this.btnCadastrar.TabIndex = 15;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFormaPagamento.SetToolTip(this.btnCadastrar, "Clique para cadastrar uma Forma de Pagamento.");
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Visible = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            this.btnCadastrar.MouseLeave += new System.EventHandler(this.btnCadastrar_MouseLeave);
            this.btnCadastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // FrmPesqFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(698, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtFormaPagamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqFormaPagamento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Forma de Pagamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqFormaPagamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqFormaPagamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqFormaPagamento_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dtFormaPagamento;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnTodas;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.ComboBox cbbpTipoPagamento;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.ToolTip ttpFormaPagamento;
        private System.Windows.Forms.RadioButton rbtnTipo;
        private System.Windows.Forms.Button btnCadastrar;
    }
}