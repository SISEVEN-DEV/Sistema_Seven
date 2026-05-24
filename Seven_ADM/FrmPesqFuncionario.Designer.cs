namespace Seven_Sistema
{
    partial class FrmPesqFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqFuncionario));
            this.lblRegistros = new System.Windows.Forms.Label();
            this.pcibAjudaFoto = new System.Windows.Forms.PictureBox();
            this.lblLegendaImagem = new System.Windows.Forms.Label();
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.dtFuncionario = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnPalavra = new System.Windows.Forms.RadioButton();
            this.rbtnRG = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.rbtnCPF = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.txtpRG = new System.Windows.Forms.TextBox();
            this.cbbpFuncao = new System.Windows.Forms.ComboBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNome = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpNome = new System.Windows.Forms.TextBox();
            this.mtxtpCPF = new System.Windows.Forms.MaskedTextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.ttpFunc = new System.Windows.Forms.ToolTip(this.components);
            this.btnCadastrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFuncionario)).BeginInit();
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
            this.lblRegistros.Location = new System.Drawing.Point(7, 228);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 108;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pcibAjudaFoto
            // 
            this.pcibAjudaFoto.BackColor = System.Drawing.Color.White;
            this.pcibAjudaFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibAjudaFoto.Enabled = false;
            this.pcibAjudaFoto.Image = ((System.Drawing.Image)(resources.GetObject("pcibAjudaFoto.Image")));
            this.pcibAjudaFoto.Location = new System.Drawing.Point(147, 205);
            this.pcibAjudaFoto.Name = "pcibAjudaFoto";
            this.pcibAjudaFoto.Size = new System.Drawing.Size(20, 20);
            this.pcibAjudaFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibAjudaFoto.TabIndex = 110;
            this.pcibAjudaFoto.TabStop = false;
            this.pcibAjudaFoto.Click += new System.EventHandler(this.pcibAjudaFoto_Click);
            this.pcibAjudaFoto.MouseLeave += new System.EventHandler(this.pcibAjudaFoto_MouseLeave);
            this.pcibAjudaFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibAjudaFoto_MouseMove);
            // 
            // lblLegendaImagem
            // 
            this.lblLegendaImagem.Location = new System.Drawing.Point(15, 139);
            this.lblLegendaImagem.Name = "lblLegendaImagem";
            this.lblLegendaImagem.Size = new System.Drawing.Size(148, 45);
            this.lblLegendaImagem.TabIndex = 109;
            this.lblLegendaImagem.Text = "Sem imagem para este registro.";
            this.lblLegendaImagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLegendaImagem.Visible = false;
            this.lblLegendaImagem.Click += new System.EventHandler(this.lblLegendaImagem_Click);
            this.lblLegendaImagem.MouseLeave += new System.EventHandler(this.lblLegendaImagem_MouseLeave);
            this.lblLegendaImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblLegendaImagem_MouseMove);
            // 
            // pcibImagem
            // 
            this.pcibImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem.Location = new System.Drawing.Point(12, 97);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(155, 128);
            this.pcibImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagem.TabIndex = 111;
            this.pcibImagem.TabStop = false;
            this.pcibImagem.Click += new System.EventHandler(this.pcibImagem_Click);
            this.pcibImagem.MouseLeave += new System.EventHandler(this.pcibImagem_MouseLeave);
            this.pcibImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagem_MouseMove);
            // 
            // dtFuncionario
            // 
            this.dtFuncionario.AllowUserToAddRows = false;
            this.dtFuncionario.AllowUserToDeleteRows = false;
            this.dtFuncionario.AllowUserToResizeRows = false;
            this.dtFuncionario.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFuncionario.Enabled = false;
            this.dtFuncionario.Location = new System.Drawing.Point(173, 97);
            this.dtFuncionario.MultiSelect = false;
            this.dtFuncionario.Name = "dtFuncionario";
            this.dtFuncionario.ReadOnly = true;
            this.dtFuncionario.RowHeadersVisible = false;
            this.dtFuncionario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFuncionario.ShowCellErrors = false;
            this.dtFuncionario.ShowCellToolTips = false;
            this.dtFuncionario.ShowEditingIcon = false;
            this.dtFuncionario.ShowRowErrors = false;
            this.dtFuncionario.Size = new System.Drawing.Size(583, 172);
            this.dtFuncionario.TabIndex = 15;
            this.dtFuncionario.DataSourceChanged += new System.EventHandler(this.dtFuncionario_DataSourceChanged);
            this.dtFuncionario.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFuncionario_CellEnter);
            this.dtFuncionario.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFuncionario_RowsAdded);
            this.dtFuncionario.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFuncionario_RowsRemoved);
            this.dtFuncionario.DoubleClick += new System.EventHandler(this.dtFuncionario_DoubleClick);
            this.dtFuncionario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFuncionario_KeyDown);
            this.dtFuncionario.MouseLeave += new System.EventHandler(this.dtFuncionario_MouseLeave);
            this.dtFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFuncionario_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnPalavra);
            this.grbBox1.Controls.Add(this.rbtnRG);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.rbtnCPF);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.txtpRG);
            this.grbBox1.Controls.Add(this.cbbpFuncao);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNome);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpNome);
            this.grbBox1.Controls.Add(this.mtxtpCPF);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(744, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnPalavra
            // 
            this.rbtnPalavra.AutoSize = true;
            this.rbtnPalavra.Location = new System.Drawing.Point(6, 41);
            this.rbtnPalavra.Name = "rbtnPalavra";
            this.rbtnPalavra.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavra.TabIndex = 5;
            this.rbtnPalavra.Text = "Palavra-Chave";
            this.rbtnPalavra.UseVisualStyleBackColor = true;
            this.rbtnPalavra.CheckedChanged += new System.EventHandler(this.rbtnPalavra_CheckedChanged);
            this.rbtnPalavra.MouseLeave += new System.EventHandler(this.rbtnPalavra_MouseLeave);
            this.rbtnPalavra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavra_MouseMove);
            // 
            // rbtnRG
            // 
            this.rbtnRG.AutoSize = true;
            this.rbtnRG.Location = new System.Drawing.Point(171, 18);
            this.rbtnRG.Name = "rbtnRG";
            this.rbtnRG.Size = new System.Drawing.Size(41, 17);
            this.rbtnRG.TabIndex = 4;
            this.rbtnRG.Text = "RG";
            this.rbtnRG.UseVisualStyleBackColor = true;
            this.rbtnRG.CheckedChanged += new System.EventHandler(this.rbtnRG_CheckedChanged);
            this.rbtnRG.MouseLeave += new System.EventHandler(this.rbtnRG_MouseLeave);
            this.rbtnRG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnRG_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(627, 43);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 35;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // rbtnCPF
            // 
            this.rbtnCPF.AutoSize = true;
            this.rbtnCPF.Location = new System.Drawing.Point(106, 41);
            this.rbtnCPF.Name = "rbtnCPF";
            this.rbtnCPF.Size = new System.Drawing.Size(45, 17);
            this.rbtnCPF.TabIndex = 6;
            this.rbtnCPF.Text = "CPF";
            this.rbtnCPF.UseVisualStyleBackColor = true;
            this.rbtnCPF.CheckedChanged += new System.EventHandler(this.rbtnCPF_CheckedChanged);
            this.rbtnCPF.MouseLeave += new System.EventHandler(this.rbtnCPF_MouseLeave);
            this.rbtnCPF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCPF_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(171, 41);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 7;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(688, 17);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(52, 20);
            this.txtpCodigo.TabIndex = 12;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpPalavraChave
            // 
            this.txtpPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtpPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpPalavraChave.Location = new System.Drawing.Point(658, 17);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.Size = new System.Drawing.Size(80, 20);
            this.txtpPalavraChave.TabIndex = 13;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // txtpRG
            // 
            this.txtpRG.BackColor = System.Drawing.Color.White;
            this.txtpRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpRG.Location = new System.Drawing.Point(592, 17);
            this.txtpRG.MaxLength = 20;
            this.txtpRG.Name = "txtpRG";
            this.txtpRG.Size = new System.Drawing.Size(148, 20);
            this.txtpRG.TabIndex = 10;
            this.txtpRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpRG.Visible = false;
            this.txtpRG.Enter += new System.EventHandler(this.txtpRG_Enter);
            this.txtpRG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpRG_KeyPress);
            this.txtpRG.Leave += new System.EventHandler(this.txtpRG_Leave);
            // 
            // cbbpFuncao
            // 
            this.cbbpFuncao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpFuncao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpFuncao.DropDownWidth = 450;
            this.cbbpFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpFuncao.FormattingEnabled = true;
            this.cbbpFuncao.Location = new System.Drawing.Point(494, 17);
            this.cbbpFuncao.Name = "cbbpFuncao";
            this.cbbpFuncao.Size = new System.Drawing.Size(212, 21);
            this.cbbpFuncao.TabIndex = 9;
            this.cbbpFuncao.Visible = false;
            this.cbbpFuncao.DropDown += new System.EventHandler(this.cbbpFuncao_DropDown);
            this.cbbpFuncao.DropDownClosed += new System.EventHandler(this.cbbpFuncao_DropDownClosed);
            this.cbbpFuncao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpFuncao_KeyPress);
            this.cbbpFuncao.MouseLeave += new System.EventHandler(this.cbbpFuncao_MouseLeave);
            this.cbbpFuncao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpFuncao_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(653, 43);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 14;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFunc.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(106, 18);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnNome
            // 
            this.rbtnNome.AutoSize = true;
            this.rbtnNome.Location = new System.Drawing.Point(6, 18);
            this.rbtnNome.Name = "rbtnNome";
            this.rbtnNome.Size = new System.Drawing.Size(53, 17);
            this.rbtnNome.TabIndex = 2;
            this.rbtnNome.Text = "Nome";
            this.rbtnNome.UseVisualStyleBackColor = true;
            this.rbtnNome.CheckedChanged += new System.EventHandler(this.rbtnNome_CheckedChanged);
            this.rbtnNome.MouseLeave += new System.EventHandler(this.rbtnNome_MouseLeave);
            this.rbtnNome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNome_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(341, 20);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(89, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome:";
            // 
            // txtpNome
            // 
            this.txtpNome.BackColor = System.Drawing.Color.White;
            this.txtpNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpNome.Location = new System.Drawing.Point(438, 17);
            this.txtpNome.MaxLength = 60;
            this.txtpNome.Name = "txtpNome";
            this.txtpNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpNome.Size = new System.Drawing.Size(300, 20);
            this.txtpNome.TabIndex = 8;
            this.txtpNome.Enter += new System.EventHandler(this.txtpNome_Enter);
            this.txtpNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNome_KeyPress);
            this.txtpNome.Leave += new System.EventHandler(this.txtpNome_Leave);
            // 
            // mtxtpCPF
            // 
            this.mtxtpCPF.BackColor = System.Drawing.Color.White;
            this.mtxtpCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtpCPF.Location = new System.Drawing.Point(642, 17);
            this.mtxtpCPF.Mask = "000,000,000-00";
            this.mtxtpCPF.Name = "mtxtpCPF";
            this.mtxtpCPF.Size = new System.Drawing.Size(98, 20);
            this.mtxtpCPF.TabIndex = 11;
            this.mtxtpCPF.Visible = false;
            this.mtxtpCPF.Enter += new System.EventHandler(this.mtxtpCPF_Enter);
            this.mtxtpCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCPF_KeyPress);
            this.mtxtpCPF.Leave += new System.EventHandler(this.mtxtpCPF_Leave);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(701, 275);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 18;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFunc.SetToolTip(this.btnVoltar, "Sair de Pesquisar Funcionários");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(625, 275);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 17;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFunc.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // ttpFunc
            // 
            this.ttpFunc.AutoPopDelay = 5000;
            this.ttpFunc.InitialDelay = 1000;
            this.ttpFunc.IsBalloon = true;
            this.ttpFunc.ReshowDelay = 100;
            this.ttpFunc.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpFunc.ToolTipTitle = "Dica:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCadastrar.Location = new System.Drawing.Point(533, 275);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(86, 32);
            this.btnCadastrar.TabIndex = 16;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFunc.SetToolTip(this.btnCadastrar, "Clique para cadastrar um Funcionário.");
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Visible = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            this.btnCadastrar.MouseLeave += new System.EventHandler(this.btnCadastrar_MouseLeave);
            this.btnCadastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // FrmPesqFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(767, 312);
            this.ControlBox = false;
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.pcibAjudaFoto);
            this.Controls.Add(this.lblLegendaImagem);
            this.Controls.Add(this.pcibImagem);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtFuncionario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqFuncionario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqFuncionario_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqFuncionario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqFuncionario_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFuncionario)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.PictureBox pcibAjudaFoto;
        private System.Windows.Forms.Label lblLegendaImagem;
        private System.Windows.Forms.PictureBox pcibImagem;
        private System.Windows.Forms.DataGridView dtFuncionario;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnPalavra;
        private System.Windows.Forms.RadioButton rbtnRG;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.RadioButton rbtnCPF;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNome;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpCPF;
        private System.Windows.Forms.TextBox txtpRG;
        private System.Windows.Forms.ComboBox cbbpFuncao;
        private System.Windows.Forms.TextBox txtpNome;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.ToolTip ttpFunc;
        private System.Windows.Forms.Button btnCadastrar;
    }
}