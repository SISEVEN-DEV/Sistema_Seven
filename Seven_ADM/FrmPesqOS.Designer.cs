namespace Seven_ADM
{
    partial class FrmPesqOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqOS));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.dtPesquisa = new System.Windows.Forms.DataGridView();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.ttpOS = new System.Windows.Forms.ToolTip(this.components);
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.btnProcurarFuncionario = new System.Windows.Forms.Button();
            this.btnProcurarUsuario = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.btnSelecionarData1 = new System.Windows.Forms.Button();
            this.chkbDestOsPend = new System.Windows.Forms.CheckBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtDataBaixa1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorarioBaixa = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorarioBaixa1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtDataBaixa = new System.Windows.Forms.MaskedTextBox();
            this.cbbFuncionario = new System.Windows.Forms.ComboBox();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblClieCons = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lbSiItuacao = new System.Windows.Forms.Label();
            this.cbbpSituacao = new System.Windows.Forms.ComboBox();
            this.cbbpUsuario = new System.Windows.Forms.ComboBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.cbbClieConsFunc = new System.Windows.Forms.ComboBox();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.btnProcurarForma = new System.Windows.Forms.Button();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.cbbFormaPagamento = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(941, 332);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 26;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnVoltar, "Sair de Pesquisar OS.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 329);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(164, 26);
            this.lblRegistros.TabIndex = 157;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(865, 332);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 25;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // dtPesquisa
            // 
            this.dtPesquisa.AllowUserToAddRows = false;
            this.dtPesquisa.AllowUserToDeleteRows = false;
            this.dtPesquisa.AllowUserToOrderColumns = true;
            this.dtPesquisa.AllowUserToResizeRows = false;
            this.dtPesquisa.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPesquisa.Enabled = false;
            this.dtPesquisa.Location = new System.Drawing.Point(12, 154);
            this.dtPesquisa.MultiSelect = false;
            this.dtPesquisa.Name = "dtPesquisa";
            this.dtPesquisa.ReadOnly = true;
            this.dtPesquisa.RowHeadersVisible = false;
            this.dtPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPesquisa.ShowCellErrors = false;
            this.dtPesquisa.ShowCellToolTips = false;
            this.dtPesquisa.ShowEditingIcon = false;
            this.dtPesquisa.ShowRowErrors = false;
            this.dtPesquisa.Size = new System.Drawing.Size(984, 172);
            this.dtPesquisa.TabIndex = 24;
            this.dtPesquisa.DataSourceChanged += new System.EventHandler(this.dtPesquisa_DataSourceChanged);
            this.dtPesquisa.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPesquisa_CellEnter);
            this.dtPesquisa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtPesquisa_CellFormatting);
            this.dtPesquisa.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtPesquisa_RowsAdded);
            this.dtPesquisa.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtPesquisa_RowsRemoved);
            this.dtPesquisa.DoubleClick += new System.EventHandler(this.dtPesquisa_DoubleClick);
            this.dtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtPesquisa_KeyDown);
            this.dtPesquisa.MouseLeave += new System.EventHandler(this.dtPesquisa_MouseLeave);
            this.dtPesquisa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtPesquisa_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(885, 116);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 35;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(911, 116);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 22;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // ttpOS
            // 
            this.ttpOS.AutoPopDelay = 5000;
            this.ttpOS.InitialDelay = 1000;
            this.ttpOS.IsBalloon = true;
            this.ttpOS.ReshowDelay = 100;
            this.ttpOS.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpOS.ToolTipTitle = "Dica:";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(12, 116);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(95, 25);
            this.btnLimpar.TabIndex = 23;
            this.btnLimpar.Text = "&Limpar Filtros";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnLimpar, "Clique para Limpar todos os campos.");
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(335, 66);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 16;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            // 
            // btnProcurarFuncionario
            // 
            this.btnProcurarFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarFuncionario.Image")));
            this.btnProcurarFuncionario.Location = new System.Drawing.Point(673, 67);
            this.btnProcurarFuncionario.Name = "btnProcurarFuncionario";
            this.btnProcurarFuncionario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarFuncionario.TabIndex = 18;
            this.btnProcurarFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnProcurarFuncionario, "Clique para pesquisar um Cliente/Consumidor/Funcionário.");
            this.btnProcurarFuncionario.UseVisualStyleBackColor = true;
            this.btnProcurarFuncionario.Click += new System.EventHandler(this.btnProcurarFuncionario_Click);
            // 
            // btnProcurarUsuario
            // 
            this.btnProcurarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarUsuario.Image")));
            this.btnProcurarUsuario.Location = new System.Drawing.Point(853, 27);
            this.btnProcurarUsuario.Name = "btnProcurarUsuario";
            this.btnProcurarUsuario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarUsuario.TabIndex = 10;
            this.btnProcurarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnProcurarUsuario, "Clique para pesquisar um Usuário.");
            this.btnProcurarUsuario.UseVisualStyleBackColor = true;
            this.btnProcurarUsuario.Click += new System.EventHandler(this.btnProcurarUsuario_Click);
            // 
            // btnProcurar
            // 
            this.btnProcurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar.Image")));
            this.btnProcurar.Location = new System.Drawing.Point(673, 28);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnProcurar.TabIndex = 8;
            this.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnProcurar, "Clique para pesquisar um Cliente/Consumidor/Funcionário.");
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // btnSelecionarData1
            // 
            this.btnSelecionarData1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarData1.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData1.Image")));
            this.btnSelecionarData1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData1.Location = new System.Drawing.Point(335, 27);
            this.btnSelecionarData1.Name = "btnSelecionarData1";
            this.btnSelecionarData1.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData1.TabIndex = 6;
            this.btnSelecionarData1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnSelecionarData1, "Clique para selecionar as datas.");
            this.btnSelecionarData1.UseVisualStyleBackColor = true;
            this.btnSelecionarData1.Click += new System.EventHandler(this.btnSelecionarData1_Click);
            // 
            // chkbDestOsPend
            // 
            this.chkbDestOsPend.AutoSize = true;
            this.chkbDestOsPend.Checked = true;
            this.chkbDestOsPend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbDestOsPend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkbDestOsPend.Location = new System.Drawing.Point(732, 116);
            this.chkbDestOsPend.Name = "chkbDestOsPend";
            this.chkbDestOsPend.Size = new System.Drawing.Size(147, 17);
            this.chkbDestOsPend.TabIndex = 19;
            this.chkbDestOsPend.Text = "Destacar O.S. Pendentes";
            this.chkbDestOsPend.UseVisualStyleBackColor = true;
            this.chkbDestOsPend.CheckedChanged += new System.EventHandler(this.chkbDestOsPend_CheckedChanged);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnProcurarForma);
            this.grbBox1.Controls.Add(this.lblFormaPagamento);
            this.grbBox1.Controls.Add(this.cbbFormaPagamento);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.mtxtDataBaixa1);
            this.grbBox1.Controls.Add(this.mtxtHorarioBaixa);
            this.grbBox1.Controls.Add(this.mtxtHorarioBaixa1);
            this.grbBox1.Controls.Add(this.mtxtDataBaixa);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.cbbFuncionario);
            this.grbBox1.Controls.Add(this.btnProcurarFuncionario);
            this.grbBox1.Controls.Add(this.lblFuncionario);
            this.grbBox1.Controls.Add(this.btnProcurarUsuario);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.lblClieCons);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.lbSiItuacao);
            this.grbBox1.Controls.Add(this.cbbpSituacao);
            this.grbBox1.Controls.Add(this.cbbpUsuario);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.btnProcurar);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.cbbClieConsFunc);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.btnSelecionarData1);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(984, 98);
            this.grbBox1.TabIndex = 158;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(156, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Até:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data de Pagamento:";
            // 
            // mtxtDataBaixa1
            // 
            this.mtxtDataBaixa1.BackColor = System.Drawing.Color.White;
            this.mtxtDataBaixa1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataBaixa1.Location = new System.Drawing.Point(188, 69);
            this.mtxtDataBaixa1.Mask = "00/00/0000";
            this.mtxtDataBaixa1.Name = "mtxtDataBaixa1";
            this.mtxtDataBaixa1.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataBaixa1.TabIndex = 14;
            this.mtxtDataBaixa1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataBaixa1.DoubleClick += new System.EventHandler(this.mtxtDataBaixa1_DoubleClick);
            this.mtxtDataBaixa1.Enter += new System.EventHandler(this.mtxtDataBaixa1_Enter);
            this.mtxtDataBaixa1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataBaixa1_KeyPress);
            this.mtxtDataBaixa1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataBaixa1_KeyUp);
            this.mtxtDataBaixa1.Leave += new System.EventHandler(this.mtxtDataBaixa1_Leave);
            // 
            // mtxtHorarioBaixa
            // 
            this.mtxtHorarioBaixa.BackColor = System.Drawing.Color.White;
            this.mtxtHorarioBaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorarioBaixa.Location = new System.Drawing.Point(93, 69);
            this.mtxtHorarioBaixa.Mask = "00:00:00";
            this.mtxtHorarioBaixa.Name = "mtxtHorarioBaixa";
            this.mtxtHorarioBaixa.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorarioBaixa.TabIndex = 13;
            this.mtxtHorarioBaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorarioBaixa.DoubleClick += new System.EventHandler(this.mtxtHorarioBaixa_DoubleClick);
            this.mtxtHorarioBaixa.Enter += new System.EventHandler(this.mtxtHorarioBaixa_Enter);
            this.mtxtHorarioBaixa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorarioBaixa_KeyPress);
            this.mtxtHorarioBaixa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorarioBaixa_KeyUp);
            this.mtxtHorarioBaixa.Leave += new System.EventHandler(this.mtxtHorarioBaixa_Leave);
            // 
            // mtxtHorarioBaixa1
            // 
            this.mtxtHorarioBaixa1.BackColor = System.Drawing.Color.White;
            this.mtxtHorarioBaixa1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorarioBaixa1.Location = new System.Drawing.Point(272, 69);
            this.mtxtHorarioBaixa1.Mask = "00:00:00";
            this.mtxtHorarioBaixa1.Name = "mtxtHorarioBaixa1";
            this.mtxtHorarioBaixa1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorarioBaixa1.TabIndex = 15;
            this.mtxtHorarioBaixa1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorarioBaixa1.DoubleClick += new System.EventHandler(this.mtxtHorarioBaixa1_DoubleClick);
            this.mtxtHorarioBaixa1.Enter += new System.EventHandler(this.mtxtHorarioBaixa1_Enter);
            this.mtxtHorarioBaixa1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorarioBaixa1_KeyPress);
            this.mtxtHorarioBaixa1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorarioBaixa1_KeyUp);
            this.mtxtHorarioBaixa1.Leave += new System.EventHandler(this.mtxtHorarioBaixa1_Leave);
            // 
            // mtxtDataBaixa
            // 
            this.mtxtDataBaixa.BackColor = System.Drawing.Color.White;
            this.mtxtDataBaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataBaixa.Location = new System.Drawing.Point(9, 69);
            this.mtxtDataBaixa.Mask = "00/00/0000";
            this.mtxtDataBaixa.Name = "mtxtDataBaixa";
            this.mtxtDataBaixa.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataBaixa.TabIndex = 12;
            this.mtxtDataBaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataBaixa.DoubleClick += new System.EventHandler(this.mtxtDataBaixa_DoubleClick);
            this.mtxtDataBaixa.Enter += new System.EventHandler(this.mtxtDataBaixa_Enter);
            this.mtxtDataBaixa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataBaixa_KeyPress);
            this.mtxtDataBaixa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataBaixa_KeyUp);
            this.mtxtDataBaixa.Leave += new System.EventHandler(this.mtxtDataBaixa_Leave);
            // 
            // cbbFuncionario
            // 
            this.cbbFuncionario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFuncionario.DropDownWidth = 550;
            this.cbbFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFuncionario.FormattingEnabled = true;
            this.cbbFuncionario.Location = new System.Drawing.Point(367, 68);
            this.cbbFuncionario.Name = "cbbFuncionario";
            this.cbbFuncionario.Size = new System.Drawing.Size(300, 21);
            this.cbbFuncionario.TabIndex = 17;
            this.cbbFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFuncionario_KeyPress);
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFuncionario.Location = new System.Drawing.Point(364, 53);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(77, 13);
            this.lblFuncionario.TabIndex = 0;
            this.lblFuncionario.Text = "Funcionário:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUsuario.Location = new System.Drawing.Point(702, 14);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário:";
            // 
            // lblClieCons
            // 
            this.lblClieCons.AutoSize = true;
            this.lblClieCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblClieCons.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClieCons.Location = new System.Drawing.Point(364, 14);
            this.lblClieCons.Name = "lblClieCons";
            this.lblClieCons.Size = new System.Drawing.Size(121, 13);
            this.lblClieCons.TabIndex = 0;
            this.lblClieCons.Text = "Cliente/Consumidor:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(882, 15);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(97, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código da O.S.:";
            // 
            // lbSiItuacao
            // 
            this.lbSiItuacao.AutoSize = true;
            this.lbSiItuacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbSiItuacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSiItuacao.Location = new System.Drawing.Point(702, 53);
            this.lbSiItuacao.Name = "lbSiItuacao";
            this.lbSiItuacao.Size = new System.Drawing.Size(61, 13);
            this.lbSiItuacao.TabIndex = 0;
            this.lbSiItuacao.Text = "Situação:";
            // 
            // cbbpSituacao
            // 
            this.cbbpSituacao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpSituacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbpSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpSituacao.DropDownWidth = 110;
            this.cbbpSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpSituacao.FormattingEnabled = true;
            this.cbbpSituacao.Items.AddRange(new object[] {
            "",
            "PENDENTE",
            "CONCLUÍDO"});
            this.cbbpSituacao.Location = new System.Drawing.Point(705, 68);
            this.cbbpSituacao.Name = "cbbpSituacao";
            this.cbbpSituacao.Size = new System.Drawing.Size(99, 21);
            this.cbbpSituacao.TabIndex = 19;
            this.cbbpSituacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpSituacao_KeyPress);
            // 
            // cbbpUsuario
            // 
            this.cbbpUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbpUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpUsuario.DropDownWidth = 197;
            this.cbbpUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpUsuario.FormattingEnabled = true;
            this.cbbpUsuario.Location = new System.Drawing.Point(705, 30);
            this.cbbpUsuario.Name = "cbbpUsuario";
            this.cbbpUsuario.Size = new System.Drawing.Size(142, 21);
            this.cbbpUsuario.TabIndex = 9;
            this.cbbpUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpUsuario_KeyPress);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(156, 33);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(6, 14);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(103, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Data de Criação:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(188, 30);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 4;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyUp);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // mtxtHorario
            // 
            this.mtxtHorario.BackColor = System.Drawing.Color.White;
            this.mtxtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario.Location = new System.Drawing.Point(93, 30);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 3;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(272, 30);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 5;
            this.mtxtHorario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario1.DoubleClick += new System.EventHandler(this.mtxtHorario1_DoubleClick);
            this.mtxtHorario1.Enter += new System.EventHandler(this.mtxtHorario1_Enter);
            this.mtxtHorario1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario1_KeyPress);
            this.mtxtHorario1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario1_KeyUp);
            this.mtxtHorario1.Leave += new System.EventHandler(this.mtxtHorario1_Leave);
            // 
            // cbbClieConsFunc
            // 
            this.cbbClieConsFunc.BackColor = System.Drawing.Color.LightBlue;
            this.cbbClieConsFunc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbClieConsFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClieConsFunc.DropDownWidth = 550;
            this.cbbClieConsFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbClieConsFunc.FormattingEnabled = true;
            this.cbbClieConsFunc.Location = new System.Drawing.Point(367, 30);
            this.cbbClieConsFunc.Name = "cbbClieConsFunc";
            this.cbbClieConsFunc.Size = new System.Drawing.Size(300, 21);
            this.cbbClieConsFunc.TabIndex = 7;
            this.cbbClieConsFunc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbClieConsFunc_KeyPress);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(9, 30);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 2;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(885, 31);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(96, 20);
            this.txtpCodigo.TabIndex = 11;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // btnProcurarForma
            // 
            this.btnProcurarForma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarForma.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarForma.Image")));
            this.btnProcurarForma.Location = new System.Drawing.Point(953, 66);
            this.btnProcurarForma.Name = "btnProcurarForma";
            this.btnProcurarForma.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarForma.TabIndex = 21;
            this.btnProcurarForma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOS.SetToolTip(this.btnProcurarForma, "Clique para pesquisar uma Forma de Pagamento.");
            this.btnProcurarForma.UseVisualStyleBackColor = true;
            this.btnProcurarForma.Click += new System.EventHandler(this.btnProcurarForma_Click);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFormaPagamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFormaPagamento.Location = new System.Drawing.Point(807, 54);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(130, 13);
            this.lblFormaPagamento.TabIndex = 25;
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // cbbFormaPagamento
            // 
            this.cbbFormaPagamento.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFormaPagamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormaPagamento.DropDownWidth = 160;
            this.cbbFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFormaPagamento.FormattingEnabled = true;
            this.cbbFormaPagamento.Items.AddRange(new object[] {
            "",
            "PENDENTE",
            "CONCLUÍDO"});
            this.cbbFormaPagamento.Location = new System.Drawing.Point(810, 68);
            this.cbbFormaPagamento.Name = "cbbFormaPagamento";
            this.cbbFormaPagamento.Size = new System.Drawing.Size(137, 21);
            this.cbbFormaPagamento.TabIndex = 20;
            this.cbbFormaPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFormaPagamento_KeyPress);
            // 
            // FrmPesqOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1004, 370);
            this.ControlBox = false;
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.chkbDestOsPend);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.dtPesquisa);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.picbInterrogacao1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqOS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Ordem de Serviço";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqOS_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqOS_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqOS_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.DataGridView dtPesquisa;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ToolTip ttpOS;
        private System.Windows.Forms.CheckBox chkbDestOsPend;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtDataBaixa1;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioBaixa;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioBaixa1;
        private System.Windows.Forms.MaskedTextBox mtxtDataBaixa;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.ComboBox cbbFuncionario;
        private System.Windows.Forms.Button btnProcurarFuncionario;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.Button btnProcurarUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblClieCons;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lbSiItuacao;
        private System.Windows.Forms.ComboBox cbbpSituacao;
        private System.Windows.Forms.ComboBox cbbpUsuario;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.ComboBox cbbClieConsFunc;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Button btnSelecionarData1;
        private System.Windows.Forms.Button btnProcurarForma;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.ComboBox cbbFormaPagamento;
    }
}