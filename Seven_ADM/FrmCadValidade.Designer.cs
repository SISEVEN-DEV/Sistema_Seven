namespace Seven_Sistema
{
    partial class FrmCadValidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadValidade));
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.btnSelecionarData2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxtDataFabricacao = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxtDataValidade = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNLote = new System.Windows.Forms.TextBox();
            this.lblNCM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtValidade = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnNLote = new System.Windows.Forms.RadioButton();
            this.lblAte = new System.Windows.Forms.Label();
            this.rbtnDataValidade = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.btnSelecionarData1 = new System.Windows.Forms.Button();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpLote = new System.Windows.Forms.TextBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.btnProcurarProduto = new System.Windows.Forms.Button();
            this.cbbProduto = new System.Windows.Forms.ComboBox();
            this.ttpValidade = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidade)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.mtxtHorario1);
            this.grbBox2.Controls.Add(this.btnSelecionarData2);
            this.grbBox2.Controls.Add(this.label4);
            this.grbBox2.Controls.Add(this.mtxtDataFabricacao);
            this.grbBox2.Controls.Add(this.label20);
            this.grbBox2.Controls.Add(this.btnSelecionarData);
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.mtxtDataValidade);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Controls.Add(this.txtNLote);
            this.grbBox2.Controls.Add(this.lblNCM);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Enabled = false;
            this.grbBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox2.Location = new System.Drawing.Point(12, 336);
            this.grbBox2.Margin = new System.Windows.Forms.Padding(2);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Padding = new System.Windows.Forms.Padding(2);
            this.grbBox2.Size = new System.Drawing.Size(576, 100);
            this.grbBox2.TabIndex = 17;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(91, 72);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 21;
            this.mtxtHorario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario1.DoubleClick += new System.EventHandler(this.mtxtHorario1_DoubleClick);
            this.mtxtHorario1.Enter += new System.EventHandler(this.mtxtHorario1_Enter);
            this.mtxtHorario1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario1_KeyPress);
            this.mtxtHorario1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario1_KeyUp);
            this.mtxtHorario1.Leave += new System.EventHandler(this.mtxtHorario1_Leave);
            // 
            // btnSelecionarData2
            // 
            this.btnSelecionarData2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarData2.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData2.Image")));
            this.btnSelecionarData2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData2.Location = new System.Drawing.Point(154, 69);
            this.btnSelecionarData2.Name = "btnSelecionarData2";
            this.btnSelecionarData2.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData2.TabIndex = 22;
            this.btnSelecionarData2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSelecionarData2, "Clique para selecionar a data.");
            this.btnSelecionarData2.UseVisualStyleBackColor = true;
            this.btnSelecionarData2.Click += new System.EventHandler(this.btnSelecionarData2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Data e Horário de Fabricação:";
            // 
            // mtxtDataFabricacao
            // 
            this.mtxtDataFabricacao.BackColor = System.Drawing.Color.White;
            this.mtxtDataFabricacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataFabricacao.Location = new System.Drawing.Point(7, 72);
            this.mtxtDataFabricacao.Mask = "00/00/0000";
            this.mtxtDataFabricacao.Name = "mtxtDataFabricacao";
            this.mtxtDataFabricacao.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataFabricacao.TabIndex = 20;
            this.mtxtDataFabricacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataFabricacao.DoubleClick += new System.EventHandler(this.mtxtDataFabricacao_DoubleClick);
            this.mtxtDataFabricacao.Enter += new System.EventHandler(this.mtxtDataFabricacao_Enter);
            this.mtxtDataFabricacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataFabricacao_KeyPress);
            this.mtxtDataFabricacao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataFabricacao_KeyUp);
            this.mtxtDataFabricacao.Leave += new System.EventHandler(this.mtxtDataFabricacao_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(546, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 15);
            this.label20.TabIndex = 0;
            this.label20.Text = "*";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(545, 69);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 24;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSelecionarData, "Clique para selecionar a data.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(459, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data de Validade:";
            // 
            // mtxtDataValidade
            // 
            this.mtxtDataValidade.BackColor = System.Drawing.Color.White;
            this.mtxtDataValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataValidade.Location = new System.Drawing.Point(461, 72);
            this.mtxtDataValidade.Mask = "00/00/0000";
            this.mtxtDataValidade.Name = "mtxtDataValidade";
            this.mtxtDataValidade.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataValidade.TabIndex = 23;
            this.mtxtDataValidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataValidade.DoubleClick += new System.EventHandler(this.mtxtDataValidade_DoubleClick);
            this.mtxtDataValidade.Enter += new System.EventHandler(this.mtxtDataValidade_Enter);
            this.mtxtDataValidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataValidade_KeyPress);
            this.mtxtDataValidade.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataValidade_KeyUp);
            this.mtxtDataValidade.Leave += new System.EventHandler(this.mtxtDataValidade_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(5, 33);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(74, 20);
            this.txtCodigo.TabIndex = 18;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNLote
            // 
            this.txtNLote.BackColor = System.Drawing.Color.White;
            this.txtNLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNLote.Location = new System.Drawing.Point(85, 33);
            this.txtNLote.MaxLength = 60;
            this.txtNLote.Name = "txtNLote";
            this.txtNLote.Size = new System.Drawing.Size(486, 20);
            this.txtNLote.TabIndex = 19;
            this.txtNLote.Enter += new System.EventHandler(this.txtNLote_Enter);
            this.txtNLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNLote_KeyPress);
            this.txtNLote.Leave += new System.EventHandler(this.txtNLote_Leave);
            // 
            // lblNCM
            // 
            this.lblNCM.AutoSize = true;
            this.lblNCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNCM.ForeColor = System.Drawing.Color.Blue;
            this.lblNCM.Location = new System.Drawing.Point(4, 17);
            this.lblNCM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNCM.Name = "lblNCM";
            this.lblNCM.Size = new System.Drawing.Size(43, 13);
            this.lblNCM.TabIndex = 0;
            this.lblNCM.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nº do Lote:";
            // 
            // dtValidade
            // 
            this.dtValidade.AllowUserToAddRows = false;
            this.dtValidade.AllowUserToDeleteRows = false;
            this.dtValidade.AllowUserToResizeRows = false;
            this.dtValidade.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtValidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtValidade.Enabled = false;
            this.dtValidade.Location = new System.Drawing.Point(12, 143);
            this.dtValidade.MultiSelect = false;
            this.dtValidade.Name = "dtValidade";
            this.dtValidade.ReadOnly = true;
            this.dtValidade.RowHeadersVisible = false;
            this.dtValidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtValidade.ShowCellErrors = false;
            this.dtValidade.ShowCellToolTips = false;
            this.dtValidade.ShowEditingIcon = false;
            this.dtValidade.ShowRowErrors = false;
            this.dtValidade.Size = new System.Drawing.Size(576, 172);
            this.dtValidade.TabIndex = 16;
            this.dtValidade.DataSourceChanged += new System.EventHandler(this.dtValidade_DataSourceChanged);
            this.dtValidade.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtValidade_CellEnter);
            this.dtValidade.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtValidade_CellFormatting);
            this.dtValidade.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtValidade_RowsAdded);
            this.dtValidade.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtValidade_RowsRemoved);
            this.dtValidade.MouseLeave += new System.EventHandler(this.dtValidade_MouseLeave);
            this.dtValidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtValidade_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnNLote);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.rbtnDataValidade);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.btnSelecionarData1);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpLote);
            this.grbBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox1.Location = new System.Drawing.Point(12, 58);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(576, 79);
            this.grbBox1.TabIndex = 4;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnNLote
            // 
            this.rbtnNLote.AutoSize = true;
            this.rbtnNLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNLote.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNLote.Location = new System.Drawing.Point(6, 42);
            this.rbtnNLote.Name = "rbtnNLote";
            this.rbtnNLote.Size = new System.Drawing.Size(76, 17);
            this.rbtnNLote.TabIndex = 7;
            this.rbtnNLote.TabStop = true;
            this.rbtnNLote.Text = "Nº do Lote";
            this.rbtnNLote.UseVisualStyleBackColor = true;
            this.rbtnNLote.CheckedChanged += new System.EventHandler(this.rbtnNumeroNF_CheckedChanged);
            this.rbtnNLote.MouseLeave += new System.EventHandler(this.rbtnNumeroNF_MouseLeave);
            this.rbtnNLote.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNumeroNF_MouseMove);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(428, 21);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // rbtnDataValidade
            // 
            this.rbtnDataValidade.AutoSize = true;
            this.rbtnDataValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDataValidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDataValidade.Location = new System.Drawing.Point(6, 19);
            this.rbtnDataValidade.Name = "rbtnDataValidade";
            this.rbtnDataValidade.Size = new System.Drawing.Size(107, 17);
            this.rbtnDataValidade.TabIndex = 5;
            this.rbtnDataValidade.TabStop = true;
            this.rbtnDataValidade.Text = "Data de Validade";
            this.rbtnDataValidade.UseVisualStyleBackColor = true;
            this.rbtnDataValidade.CheckedChanged += new System.EventHandler(this.rbtnDataValidade_CheckedChanged);
            this.rbtnDataValidade.MouseLeave += new System.EventHandler(this.rbtnDataEmissao_MouseLeave);
            this.rbtnDataValidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDataEmissao_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(117, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 8;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(242, 22);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(96, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite as datas:";
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(462, 43);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(488, 41);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 15;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(117, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 6;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(344, 18);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 10;
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
            this.mtxtpData1.Location = new System.Drawing.Point(460, 18);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 11;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyUp);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // btnSelecionarData1
            // 
            this.btnSelecionarData1.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData1.Image")));
            this.btnSelecionarData1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData1.Location = new System.Drawing.Point(544, 15);
            this.btnSelecionarData1.Name = "btnSelecionarData1";
            this.btnSelecionarData1.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData1.TabIndex = 12;
            this.btnSelecionarData1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSelecionarData1, "Clique para selecionar as datas.");
            this.btnSelecionarData1.UseVisualStyleBackColor = true;
            this.btnSelecionarData1.Click += new System.EventHandler(this.btnSelecionarData1_Click);
            this.btnSelecionarData1.MouseLeave += new System.EventHandler(this.btnSelecionarData3_MouseLeave);
            this.btnSelecionarData1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData3_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(491, 18);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtpCodigo.TabIndex = 14;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpLote
            // 
            this.txtpLote.BackColor = System.Drawing.Color.White;
            this.txtpLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpLote.Location = new System.Drawing.Point(299, 18);
            this.txtpLote.MaxLength = 60;
            this.txtpLote.Name = "txtpLote";
            this.txtpLote.Size = new System.Drawing.Size(271, 20);
            this.txtpLote.TabIndex = 9;
            this.txtpLote.Visible = false;
            this.txtpLote.Enter += new System.EventHandler(this.txtpLote_Enter);
            this.txtpLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpLote_KeyPress);
            this.txtpLote.Leave += new System.EventHandler(this.txtpLote_Leave);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(473, 318);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(115, 16);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.btnProcurarProduto);
            this.grbBox3.Controls.Add(this.cbbProduto);
            this.grbBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox3.Location = new System.Drawing.Point(12, 7);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(576, 45);
            this.grbBox3.TabIndex = 1;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Produto:";
            // 
            // btnProcurarProduto
            // 
            this.btnProcurarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarProduto.Image")));
            this.btnProcurarProduto.Location = new System.Drawing.Point(546, 16);
            this.btnProcurarProduto.Name = "btnProcurarProduto";
            this.btnProcurarProduto.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarProduto.TabIndex = 3;
            this.btnProcurarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnProcurarProduto, "Clique para pesquisar um Produto.");
            this.btnProcurarProduto.UseVisualStyleBackColor = true;
            this.btnProcurarProduto.Click += new System.EventHandler(this.btnProcurarProduto_Click);
            this.btnProcurarProduto.MouseLeave += new System.EventHandler(this.btnProcurarProduto_MouseLeave);
            this.btnProcurarProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProduto_MouseMove);
            // 
            // cbbProduto
            // 
            this.cbbProduto.BackColor = System.Drawing.Color.LightBlue;
            this.cbbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProduto.DropDownWidth = 550;
            this.cbbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduto.FormattingEnabled = true;
            this.cbbProduto.Location = new System.Drawing.Point(6, 19);
            this.cbbProduto.Name = "cbbProduto";
            this.cbbProduto.Size = new System.Drawing.Size(534, 21);
            this.cbbProduto.TabIndex = 2;
            this.cbbProduto.DropDown += new System.EventHandler(this.cbbProduto_DropDown);
            this.cbbProduto.SelectedIndexChanged += new System.EventHandler(this.cbbProduto_SelectedIndexChanged);
            this.cbbProduto.DropDownClosed += new System.EventHandler(this.cbbProduto_DropDownClosed);
            this.cbbProduto.MouseLeave += new System.EventHandler(this.cbbProduto_MouseLeave);
            this.cbbProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbProduto_MouseMove);
            // 
            // ttpValidade
            // 
            this.ttpValidade.AutoPopDelay = 5000;
            this.ttpValidade.InitialDelay = 1000;
            this.ttpValidade.IsBalloon = true;
            this.ttpValidade.ReshowDelay = 100;
            this.ttpValidade.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpValidade.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(533, 441);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 30;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSair, "Sair do cadastro de Validade.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(312, 441);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(403, 441);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 29;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcluir.Location = new System.Drawing.Point(190, 441);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 27;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnExcluir, "Excluir uma Validade.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluir_MouseMove);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAlterar.Location = new System.Drawing.Point(114, 441);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 26;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnAlterar, "Alterar uma Validade cadastrada.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovo.Location = new System.Drawing.Point(38, 441);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 25;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnNovo, "Cadastrar uma nova Validade.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 441);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 105;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // FrmCadValidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(602, 478);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.grbBox3);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtValidade);
            this.Controls.Add(this.grbBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FrmCadValidade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Validade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadValidade_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadValidade_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadValidade_KeyUp);
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidade)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.grbBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox mtxtDataValidade;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNLote;
        private System.Windows.Forms.Label lblNCM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtValidade;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnNLote;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.RadioButton rbtnDataValidade;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.Button btnSelecionarData1;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.Button btnProcurarProduto;
        private System.Windows.Forms.ComboBox cbbProduto;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.ToolTip ttpValidade;
        private System.Windows.Forms.TextBox txtpLote;
        private System.Windows.Forms.Button btnSelecionarData2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtDataFabricacao;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
    }
}