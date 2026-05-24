namespace Seven_Sistema
{
    partial class FrmPesqFornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqFornecedor));
            this.dtPesquisa = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnIE = new System.Windows.Forms.RadioButton();
            this.rbtnPalavra = new System.Windows.Forms.RadioButton();
            this.rbtnRG = new System.Windows.Forms.RadioButton();
            this.rbtnCPF = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCNPJ = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNome = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.mtxtpCPF = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtpRG = new System.Windows.Forms.TextBox();
            this.txtpNome = new System.Windows.Forms.TextBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.lblLegendaImagem = new System.Windows.Forms.Label();
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.ttpFornecedor = new System.Windows.Forms.ToolTip(this.components);
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.pcibAjudaFoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).BeginInit();
            this.SuspendLayout();
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
            this.dtPesquisa.Location = new System.Drawing.Point(173, 97);
            this.dtPesquisa.MultiSelect = false;
            this.dtPesquisa.Name = "dtPesquisa";
            this.dtPesquisa.ReadOnly = true;
            this.dtPesquisa.RowHeadersVisible = false;
            this.dtPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPesquisa.ShowCellErrors = false;
            this.dtPesquisa.ShowCellToolTips = false;
            this.dtPesquisa.ShowEditingIcon = false;
            this.dtPesquisa.ShowRowErrors = false;
            this.dtPesquisa.Size = new System.Drawing.Size(578, 172);
            this.dtPesquisa.TabIndex = 17;
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
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnIE);
            this.grbBox1.Controls.Add(this.rbtnPalavra);
            this.grbBox1.Controls.Add(this.rbtnRG);
            this.grbBox1.Controls.Add(this.rbtnCPF);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCNPJ);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNome);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.mtxtpCPF);
            this.grbBox1.Controls.Add(this.mtxtpCNPJ);
            this.grbBox1.Controls.Add(this.txtpRG);
            this.grbBox1.Controls.Add(this.txtpNome);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(739, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnIE
            // 
            this.rbtnIE.AutoSize = true;
            this.rbtnIE.Location = new System.Drawing.Point(108, 41);
            this.rbtnIE.Name = "rbtnIE";
            this.rbtnIE.Size = new System.Drawing.Size(112, 17);
            this.rbtnIE.TabIndex = 7;
            this.rbtnIE.Text = "Inscrição Estadual";
            this.rbtnIE.UseVisualStyleBackColor = true;
            this.rbtnIE.CheckedChanged += new System.EventHandler(this.rbtnIE_CheckedChanged);
            this.rbtnIE.MouseLeave += new System.EventHandler(this.rbtnIE_MouseLeave);
            this.rbtnIE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnIE_MouseMove);
            // 
            // rbtnPalavra
            // 
            this.rbtnPalavra.AutoSize = true;
            this.rbtnPalavra.Location = new System.Drawing.Point(226, 41);
            this.rbtnPalavra.Name = "rbtnPalavra";
            this.rbtnPalavra.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavra.TabIndex = 8;
            this.rbtnPalavra.Text = "Palavra-Chave";
            this.rbtnPalavra.UseVisualStyleBackColor = true;
            this.rbtnPalavra.CheckedChanged += new System.EventHandler(this.rbtnPalavra_CheckedChanged);
            this.rbtnPalavra.MouseLeave += new System.EventHandler(this.rbtnPalavra_MouseLeave);
            this.rbtnPalavra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavra_MouseMove);
            // 
            // rbtnRG
            // 
            this.rbtnRG.AutoSize = true;
            this.rbtnRG.Location = new System.Drawing.Point(61, 41);
            this.rbtnRG.Name = "rbtnRG";
            this.rbtnRG.Size = new System.Drawing.Size(41, 17);
            this.rbtnRG.TabIndex = 6;
            this.rbtnRG.Text = "RG";
            this.rbtnRG.UseVisualStyleBackColor = true;
            this.rbtnRG.CheckedChanged += new System.EventHandler(this.rbtnRG_CheckedChanged);
            this.rbtnRG.MouseLeave += new System.EventHandler(this.rbtnRG_MouseLeave);
            this.rbtnRG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnRG_MouseMove);
            // 
            // rbtnCPF
            // 
            this.rbtnCPF.AutoSize = true;
            this.rbtnCPF.Location = new System.Drawing.Point(197, 17);
            this.rbtnCPF.Name = "rbtnCPF";
            this.rbtnCPF.Size = new System.Drawing.Size(45, 17);
            this.rbtnCPF.TabIndex = 4;
            this.rbtnCPF.Text = "CPF";
            this.rbtnCPF.UseVisualStyleBackColor = true;
            this.rbtnCPF.CheckedChanged += new System.EventHandler(this.rbtnCPF_CheckedChanged);
            this.rbtnCPF.MouseLeave += new System.EventHandler(this.rbtnCPF_MouseLeave);
            this.rbtnCPF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCPF_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(326, 41);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 9;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnCNPJ
            // 
            this.rbtnCNPJ.AutoSize = true;
            this.rbtnCNPJ.Location = new System.Drawing.Point(6, 41);
            this.rbtnCNPJ.Name = "rbtnCNPJ";
            this.rbtnCNPJ.Size = new System.Drawing.Size(52, 17);
            this.rbtnCNPJ.TabIndex = 5;
            this.rbtnCNPJ.Text = "CNPJ";
            this.rbtnCNPJ.UseVisualStyleBackColor = true;
            this.rbtnCNPJ.CheckedChanged += new System.EventHandler(this.rbtnCNPJ_CheckedChanged);
            this.rbtnCNPJ.MouseLeave += new System.EventHandler(this.rbtnCNPJ_MouseLeave);
            this.rbtnCNPJ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCNPJ_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(133, 17);
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
            this.rbtnNome.Location = new System.Drawing.Point(6, 17);
            this.rbtnNome.Name = "rbtnNome";
            this.rbtnNome.Size = new System.Drawing.Size(121, 17);
            this.rbtnNome.TabIndex = 2;
            this.rbtnNome.Text = "Nome/Razão Social";
            this.rbtnNome.UseVisualStyleBackColor = true;
            this.rbtnNome.CheckedChanged += new System.EventHandler(this.rbtnNome_CheckedChanged);
            this.rbtnNome.MouseLeave += new System.EventHandler(this.rbtnNome_MouseLeave);
            this.rbtnNome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNome_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(622, 42);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 35;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(648, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFornecedor.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(278, 19);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(163, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome/razão social:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(653, 16);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 14;
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
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpPalavraChave.Location = new System.Drawing.Point(655, 16);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(78, 20);
            this.txtpPalavraChave.TabIndex = 15;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // mtxtpCPF
            // 
            this.mtxtpCPF.BackColor = System.Drawing.Color.White;
            this.mtxtpCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtpCPF.Location = new System.Drawing.Point(635, 16);
            this.mtxtpCPF.Mask = "000,000,000-00";
            this.mtxtpCPF.Name = "mtxtpCPF";
            this.mtxtpCPF.Size = new System.Drawing.Size(98, 20);
            this.mtxtpCPF.TabIndex = 13;
            this.mtxtpCPF.Visible = false;
            this.mtxtpCPF.Enter += new System.EventHandler(this.mtxtpCPF_Enter);
            this.mtxtpCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCPF_KeyPress);
            this.mtxtpCPF.Leave += new System.EventHandler(this.mtxtpCPF_Leave);
            // 
            // mtxtpCNPJ
            // 
            this.mtxtpCNPJ.BackColor = System.Drawing.Color.White;
            this.mtxtpCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtpCNPJ.Location = new System.Drawing.Point(606, 16);
            this.mtxtpCNPJ.Mask = "00,000,000/0000-00";
            this.mtxtpCNPJ.Name = "mtxtpCNPJ";
            this.mtxtpCNPJ.Size = new System.Drawing.Size(127, 20);
            this.mtxtpCNPJ.TabIndex = 12;
            this.mtxtpCNPJ.Visible = false;
            this.mtxtpCNPJ.Enter += new System.EventHandler(this.mtxtpCNPJ_Enter);
            this.mtxtpCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCNPJ_KeyPress);
            this.mtxtpCNPJ.Leave += new System.EventHandler(this.mtxtpCNPJ_Leave);
            // 
            // txtpRG
            // 
            this.txtpRG.BackColor = System.Drawing.Color.White;
            this.txtpRG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpRG.Location = new System.Drawing.Point(585, 16);
            this.txtpRG.MaxLength = 20;
            this.txtpRG.Name = "txtpRG";
            this.txtpRG.Size = new System.Drawing.Size(148, 20);
            this.txtpRG.TabIndex = 11;
            this.txtpRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpRG.Visible = false;
            this.txtpRG.Enter += new System.EventHandler(this.txtpRG_Enter);
            this.txtpRG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpRG_KeyPress);
            this.txtpRG.Leave += new System.EventHandler(this.txtpRG_Leave);
            // 
            // txtpNome
            // 
            this.txtpNome.BackColor = System.Drawing.Color.White;
            this.txtpNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNome.Location = new System.Drawing.Point(447, 16);
            this.txtpNome.MaxLength = 60;
            this.txtpNome.Name = "txtpNome";
            this.txtpNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpNome.Size = new System.Drawing.Size(286, 20);
            this.txtpNome.TabIndex = 10;
            this.txtpNome.Enter += new System.EventHandler(this.txtpNome_Enter);
            this.txtpNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNome_KeyPress);
            this.txtpNome.Leave += new System.EventHandler(this.txtpNome_Leave);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 228);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(164, 26);
            this.lblRegistros.TabIndex = 142;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(620, 275);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 18;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFornecedor.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // lblLegendaImagem
            // 
            this.lblLegendaImagem.Location = new System.Drawing.Point(15, 140);
            this.lblLegendaImagem.Name = "lblLegendaImagem";
            this.lblLegendaImagem.Size = new System.Drawing.Size(148, 45);
            this.lblLegendaImagem.TabIndex = 144;
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
            this.pcibImagem.Enabled = false;
            this.pcibImagem.Location = new System.Drawing.Point(12, 97);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(155, 128);
            this.pcibImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagem.TabIndex = 145;
            this.pcibImagem.TabStop = false;
            this.pcibImagem.Click += new System.EventHandler(this.pcibImagem_Click);
            this.pcibImagem.MouseLeave += new System.EventHandler(this.pcibImagem_MouseLeave);
            this.pcibImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagem_MouseMove);
            // 
            // ttpFornecedor
            // 
            this.ttpFornecedor.AutoPopDelay = 5000;
            this.ttpFornecedor.InitialDelay = 1000;
            this.ttpFornecedor.IsBalloon = true;
            this.ttpFornecedor.ReshowDelay = 100;
            this.ttpFornecedor.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpFornecedor.ToolTipTitle = "Dica:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(696, 275);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 19;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFornecedor.SetToolTip(this.btnVoltar, "Sair de Pesquisar Fornecedor.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCadastrar.Location = new System.Drawing.Point(528, 275);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(86, 32);
            this.btnCadastrar.TabIndex = 147;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFornecedor.SetToolTip(this.btnCadastrar, "Clique para cadastrar um Fornecedor.");
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Visible = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            this.btnCadastrar.MouseLeave += new System.EventHandler(this.btnCadastrar_MouseLeave);
            this.btnCadastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
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
            this.pcibAjudaFoto.TabIndex = 146;
            this.pcibAjudaFoto.TabStop = false;
            this.pcibAjudaFoto.Click += new System.EventHandler(this.pcibAjudaFoto_Click);
            this.pcibAjudaFoto.MouseLeave += new System.EventHandler(this.pcibAjudaFoto_MouseLeave);
            this.pcibAjudaFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibAjudaFoto_MouseMove);
            // 
            // FrmPesqFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(762, 312);
            this.ControlBox = false;
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.pcibAjudaFoto);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblLegendaImagem);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.dtPesquisa);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.pcibImagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqFornecedor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Fornecedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqFornecedor_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqFornecedor_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqFornecedor_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtPesquisa;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.TextBox txtpNome;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblLegendaImagem;
        private System.Windows.Forms.PictureBox pcibImagem;
        private System.Windows.Forms.RadioButton rbtnIE;
        private System.Windows.Forms.RadioButton rbtnPalavra;
        private System.Windows.Forms.RadioButton rbtnRG;
        private System.Windows.Forms.RadioButton rbtnCPF;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCNPJ;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNome;
        private System.Windows.Forms.MaskedTextBox mtxtpCNPJ;
        private System.Windows.Forms.TextBox txtpRG;
        private System.Windows.Forms.MaskedTextBox mtxtpCPF;
        private System.Windows.Forms.ToolTip ttpFornecedor;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.PictureBox pcibAjudaFoto;
        private System.Windows.Forms.Button btnCadastrar;
    }
}