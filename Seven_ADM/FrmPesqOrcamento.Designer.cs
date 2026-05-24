namespace Seven_Sistema
{
    partial class FrmPesqOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqOrcamento));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.rbtnConsumidor = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDataCriacao = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.cbbConsumidor = new System.Windows.Forms.ComboBox();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.btnProcurarCliente = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.dtPesquisa = new System.Windows.Forms.DataGridView();
            this.ttpOrcamento = new System.Windows.Forms.ToolTip(this.components);
            this.btnConsultarItens = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.rbtnConsumidor);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDataCriacao);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.cbbConsumidor);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.btnProcurarCliente);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(739, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(591, 19);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // rbtnConsumidor
            // 
            this.rbtnConsumidor.AutoSize = true;
            this.rbtnConsumidor.Location = new System.Drawing.Point(6, 40);
            this.rbtnConsumidor.Name = "rbtnConsumidor";
            this.rbtnConsumidor.Size = new System.Drawing.Size(80, 17);
            this.rbtnConsumidor.TabIndex = 4;
            this.rbtnConsumidor.Text = "Consumidor";
            this.rbtnConsumidor.UseVisualStyleBackColor = true;
            this.rbtnConsumidor.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.rbtnConsumidor.MouseLeave += new System.EventHandler(this.radioButton1_MouseLeave);
            this.rbtnConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(114, 40);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(114, 17);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnDataCriacao
            // 
            this.rbtnDataCriacao.AutoSize = true;
            this.rbtnDataCriacao.Location = new System.Drawing.Point(6, 17);
            this.rbtnDataCriacao.Name = "rbtnDataCriacao";
            this.rbtnDataCriacao.Size = new System.Drawing.Size(102, 17);
            this.rbtnDataCriacao.TabIndex = 2;
            this.rbtnDataCriacao.Text = "Data de Criação";
            this.rbtnDataCriacao.UseVisualStyleBackColor = true;
            this.rbtnDataCriacao.CheckedChanged += new System.EventHandler(this.rbtnNome_CheckedChanged);
            this.rbtnDataCriacao.MouseLeave += new System.EventHandler(this.rbtnNome_MouseLeave);
            this.rbtnDataCriacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNome_MouseMove);
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
            this.btnPesquisar.TabIndex = 12;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
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
            this.lblPesquisar.Location = new System.Drawing.Point(405, 19);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(96, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite as datas:";
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(507, 16);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 6;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(623, 16);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 7;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyUp);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // cbbConsumidor
            // 
            this.cbbConsumidor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbConsumidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConsumidor.DropDownWidth = 550;
            this.cbbConsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbConsumidor.FormattingEnabled = true;
            this.cbbConsumidor.Location = new System.Drawing.Point(426, 16);
            this.cbbConsumidor.Name = "cbbConsumidor";
            this.cbbConsumidor.Size = new System.Drawing.Size(275, 21);
            this.cbbConsumidor.TabIndex = 11;
            this.cbbConsumidor.DropDown += new System.EventHandler(this.cbbConsumidor_DropDown);
            this.cbbConsumidor.DropDownClosed += new System.EventHandler(this.cbbConsumidor_DropDownClosed);
            this.cbbConsumidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbConsumidor_KeyPress);
            this.cbbConsumidor.MouseLeave += new System.EventHandler(this.cbbConsumidor_MouseLeave);
            this.cbbConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbConsumidor_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(707, 13);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 10;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(653, 16);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 8;
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
            // 
            // btnProcurarCliente
            // 
            this.btnProcurarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarCliente.Image")));
            this.btnProcurarCliente.Location = new System.Drawing.Point(707, 13);
            this.btnProcurarCliente.Name = "btnProcurarCliente";
            this.btnProcurarCliente.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarCliente.TabIndex = 9;
            this.btnProcurarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnProcurarCliente, "Clique para pesquisar um Consumidor.");
            this.btnProcurarCliente.UseVisualStyleBackColor = true;
            this.btnProcurarCliente.Click += new System.EventHandler(this.btnProcurarCliente_Click);
            this.btnProcurarCliente.MouseLeave += new System.EventHandler(this.btnProcurarCliente_MouseLeave);
            this.btnProcurarCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarCliente_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(695, 275);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnVoltar, "Sair de Pesquisar Orçamento.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 272);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(164, 26);
            this.lblRegistros.TabIndex = 146;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(619, 275);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 15;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
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
            this.dtPesquisa.Location = new System.Drawing.Point(12, 97);
            this.dtPesquisa.MultiSelect = false;
            this.dtPesquisa.Name = "dtPesquisa";
            this.dtPesquisa.ReadOnly = true;
            this.dtPesquisa.RowHeadersVisible = false;
            this.dtPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPesquisa.ShowCellErrors = false;
            this.dtPesquisa.ShowCellToolTips = false;
            this.dtPesquisa.ShowEditingIcon = false;
            this.dtPesquisa.ShowRowErrors = false;
            this.dtPesquisa.Size = new System.Drawing.Size(739, 172);
            this.dtPesquisa.TabIndex = 13;
            this.dtPesquisa.DataSourceChanged += new System.EventHandler(this.dtPesquisa_DataSourceChanged);
            this.dtPesquisa.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPesquisa_CellEnter);
            this.dtPesquisa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtPesquisa_CellFormatting);
            this.dtPesquisa.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtPesquisa_RowsAdded);
            this.dtPesquisa.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtPesquisa_RowsRemoved);
            this.dtPesquisa.DoubleClick += new System.EventHandler(this.dtPesquisa_DoubleClick);
            this.dtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtPesquisa_KeyDown);
            this.dtPesquisa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtPesquisa_KeyUp);
            this.dtPesquisa.MouseLeave += new System.EventHandler(this.dtPesquisa_MouseLeave);
            this.dtPesquisa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtPesquisa_MouseMove);
            // 
            // ttpOrcamento
            // 
            this.ttpOrcamento.AutoPopDelay = 5000;
            this.ttpOrcamento.InitialDelay = 1000;
            this.ttpOrcamento.IsBalloon = true;
            this.ttpOrcamento.ReshowDelay = 100;
            this.ttpOrcamento.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpOrcamento.ToolTipTitle = "Dica:";
            // 
            // btnConsultarItens
            // 
            this.btnConsultarItens.Enabled = false;
            this.btnConsultarItens.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarItens.Image")));
            this.btnConsultarItens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarItens.Location = new System.Drawing.Point(332, 275);
            this.btnConsultarItens.Name = "btnConsultarItens";
            this.btnConsultarItens.Size = new System.Drawing.Size(105, 25);
            this.btnConsultarItens.TabIndex = 14;
            this.btnConsultarItens.Text = "&Consultar Itens";
            this.btnConsultarItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnConsultarItens, "Clique para consultar os itens do registro selecionado.");
            this.btnConsultarItens.UseVisualStyleBackColor = true;
            this.btnConsultarItens.Click += new System.EventHandler(this.btnConsultarItens_Click);
            this.btnConsultarItens.MouseLeave += new System.EventHandler(this.btnConsultarItens_MouseLeave);
            this.btnConsultarItens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarItens_MouseMove);
            // 
            // FrmPesqOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(762, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btnConsultarItens);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.dtPesquisa);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqOrcamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Orçamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqOrcamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqOrcamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqOrcamento_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDataCriacao;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.DataGridView dtPesquisa;
        private System.Windows.Forms.RadioButton rbtnConsumidor;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Button btnProcurarCliente;
        private System.Windows.Forms.ComboBox cbbConsumidor;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.ToolTip ttpOrcamento;
        private System.Windows.Forms.Button btnConsultarItens;
    }
}