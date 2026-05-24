namespace SIE_7_Sistema
{
    partial class FrmCadArquivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadArquivo));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTabela = new System.Windows.Forms.RadioButton();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNomeAluno = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.cbbpTipoTabela = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.dtArquivo = new System.Windows.Forms.DataGridView();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoTabela = new System.Windows.Forms.Label();
            this.cbbTipoTabela = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtObs = new System.Windows.Forms.RichTextBox();
            this.grbBox4 = new System.Windows.Forms.GroupBox();
            this.btnExcluirArquivo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSelecionar = new System.Windows.Forms.Label();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.lblPalavrachave = new System.Windows.Forms.Label();
            this.txtPalavraChave = new System.Windows.Forms.TextBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.ttpArquivo = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivo)).BeginInit();
            this.grbBox2.SuspendLayout();
            this.grbBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTabela);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNomeAluno);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.cbbpTipoTabela);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(690, 81);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTabela
            // 
            this.rbtnTabela.AutoSize = true;
            this.rbtnTabela.Location = new System.Drawing.Point(6, 42);
            this.rbtnTabela.Name = "rbtnTabela";
            this.rbtnTabela.Size = new System.Drawing.Size(58, 17);
            this.rbtnTabela.TabIndex = 4;
            this.rbtnTabela.TabStop = true;
            this.rbtnTabela.Text = "Tabela";
            this.rbtnTabela.UseVisualStyleBackColor = true;
            this.rbtnTabela.CheckedChanged += new System.EventHandler(this.rbtnTabela_CheckedChanged);
            this.rbtnTabela.MouseLeave += new System.EventHandler(this.rbtnTabela_MouseLeave);
            this.rbtnTabela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTabela_MouseMove);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(149, 19);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(94, 17);
            this.rbtnPalavraChave.TabIndex = 3;
            this.rbtnPalavraChave.TabStop = true;
            this.rbtnPalavraChave.Text = "Palavra-chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(70, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(573, 44);
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
            this.btnPesquisar.Location = new System.Drawing.Point(599, 44);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(85, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnNomeAluno
            // 
            this.rbtnNomeAluno.AutoSize = true;
            this.rbtnNomeAluno.Checked = true;
            this.rbtnNomeAluno.Location = new System.Drawing.Point(6, 19);
            this.rbtnNomeAluno.Name = "rbtnNomeAluno";
            this.rbtnNomeAluno.Size = new System.Drawing.Size(73, 17);
            this.rbtnNomeAluno.TabIndex = 1;
            this.rbtnNomeAluno.TabStop = true;
            this.rbtnNomeAluno.Text = "Descrição";
            this.rbtnNomeAluno.UseVisualStyleBackColor = true;
            this.rbtnNomeAluno.CheckedChanged += new System.EventHandler(this.rbtnNomeAluno_CheckedChanged);
            this.rbtnNomeAluno.MouseLeave += new System.EventHandler(this.rbtnNomeAluno_MouseLeave);
            this.rbtnNomeAluno.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNomeAluno_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(249, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(642, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(42, 20);
            this.txtpCodigo.TabIndex = 9;
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
            this.txtpPalavraChave.Location = new System.Drawing.Point(606, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(78, 20);
            this.txtpPalavraChave.TabIndex = 8;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // cbbpTipoTabela
            // 
            this.cbbpTipoTabela.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipoTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipoTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipoTabela.FormattingEnabled = true;
            this.cbbpTipoTabela.Items.AddRange(new object[] {
            "AMBAS",
            "ALUNO",
            "FORNECEDOR",
            "FUNCIONARIO"});
            this.cbbpTipoTabela.Location = new System.Drawing.Point(444, 18);
            this.cbbpTipoTabela.Name = "cbbpTipoTabela";
            this.cbbpTipoTabela.Size = new System.Drawing.Size(240, 21);
            this.cbbpTipoTabela.TabIndex = 7;
            this.cbbpTipoTabela.Visible = false;
            this.cbbpTipoTabela.DropDown += new System.EventHandler(this.cbbpTipoTabela_DropDown);
            this.cbbpTipoTabela.DropDownClosed += new System.EventHandler(this.cbbpTipoTabela_DropDownClosed);
            this.cbbpTipoTabela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipoTabela_KeyPress);
            this.cbbpTipoTabela.MouseLeave += new System.EventHandler(this.cbbpTipoTabela_MouseLeave);
            this.cbbpTipoTabela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTipoTabela_MouseMove);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpDescricao.Location = new System.Drawing.Point(369, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(315, 20);
            this.txtpDescricao.TabIndex = 6;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // dtArquivo
            // 
            this.dtArquivo.AllowUserToAddRows = false;
            this.dtArquivo.AllowUserToDeleteRows = false;
            this.dtArquivo.AllowUserToOrderColumns = true;
            this.dtArquivo.AllowUserToResizeRows = false;
            this.dtArquivo.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtArquivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtArquivo.Location = new System.Drawing.Point(12, 99);
            this.dtArquivo.MultiSelect = false;
            this.dtArquivo.Name = "dtArquivo";
            this.dtArquivo.ReadOnly = true;
            this.dtArquivo.RowHeadersVisible = false;
            this.dtArquivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtArquivo.ShowCellErrors = false;
            this.dtArquivo.ShowCellToolTips = false;
            this.dtArquivo.ShowEditingIcon = false;
            this.dtArquivo.ShowRowErrors = false;
            this.dtArquivo.Size = new System.Drawing.Size(690, 128);
            this.dtArquivo.TabIndex = 11;
            this.dtArquivo.DataSourceChanged += new System.EventHandler(this.dtArquivo_DataSourceChanged);
            this.dtArquivo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtArquivo_CellEnter);
            this.dtArquivo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtArquivo_RowsAdded);
            this.dtArquivo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtArquivo_RowsRemoved);
            this.dtArquivo.MouseLeave += new System.EventHandler(this.dtArquivo_MouseLeave);
            this.dtArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtArquivo_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.lblTipoTabela);
            this.grbBox2.Controls.Add(this.cbbTipoTabela);
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.rtxtObs);
            this.grbBox2.Controls.Add(this.grbBox4);
            this.grbBox2.Controls.Add(this.lblPalavrachave);
            this.grbBox2.Controls.Add(this.txtPalavraChave);
            this.grbBox2.Controls.Add(this.lblAsterisco1);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Controls.Add(this.lblNome);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Controls.Add(this.txtDescricao);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(12, 259);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(690, 159);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(479, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "*";
            // 
            // lblTipoTabela
            // 
            this.lblTipoTabela.AutoSize = true;
            this.lblTipoTabela.Location = new System.Drawing.Point(441, 15);
            this.lblTipoTabela.Name = "lblTipoTabela";
            this.lblTipoTabela.Size = new System.Drawing.Size(43, 13);
            this.lblTipoTabela.TabIndex = 0;
            this.lblTipoTabela.Text = "Tabela:";
            // 
            // cbbTipoTabela
            // 
            this.cbbTipoTabela.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoTabela.FormattingEnabled = true;
            this.cbbTipoTabela.Items.AddRange(new object[] {
            "AMBAS",
            "ALUNO",
            "FORNECEDOR",
            "FUNCIONARIO"});
            this.cbbTipoTabela.Location = new System.Drawing.Point(444, 31);
            this.cbbTipoTabela.Name = "cbbTipoTabela";
            this.cbbTipoTabela.Size = new System.Drawing.Size(240, 21);
            this.cbbTipoTabela.TabIndex = 15;
            this.cbbTipoTabela.DropDown += new System.EventHandler(this.cbbTipoTabela_DropDown);
            this.cbbTipoTabela.DropDownClosed += new System.EventHandler(this.cbbTipoTabela_DropDownClosed);
            this.cbbTipoTabela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipoTabela_KeyPress);
            this.cbbTipoTabela.MouseLeave += new System.EventHandler(this.cbbTipoTabela_MouseLeave);
            this.cbbTipoTabela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoTabela_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Observações:";
            // 
            // rtxtObs
            // 
            this.rtxtObs.BackColor = System.Drawing.Color.White;
            this.rtxtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtObs.Location = new System.Drawing.Point(6, 117);
            this.rtxtObs.MaxLength = 200;
            this.rtxtObs.Name = "rtxtObs";
            this.rtxtObs.Size = new System.Drawing.Size(678, 33);
            this.rtxtObs.TabIndex = 19;
            this.rtxtObs.Text = "";
            this.rtxtObs.Enter += new System.EventHandler(this.rtxtObs_Enter);
            this.rtxtObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtObs_KeyPress);
            this.rtxtObs.Leave += new System.EventHandler(this.rtxtObs_Leave);
            // 
            // grbBox4
            // 
            this.grbBox4.Controls.Add(this.btnExcluirArquivo);
            this.grbBox4.Controls.Add(this.label4);
            this.grbBox4.Controls.Add(this.lblSelecionar);
            this.grbBox4.Controls.Add(this.txtCaminho);
            this.grbBox4.Controls.Add(this.lblCaminho);
            this.grbBox4.Controls.Add(this.btnProcurar);
            this.grbBox4.Location = new System.Drawing.Point(6, 58);
            this.grbBox4.Name = "grbBox4";
            this.grbBox4.Size = new System.Drawing.Size(675, 40);
            this.grbBox4.TabIndex = 16;
            this.grbBox4.TabStop = false;
            this.grbBox4.Text = "Selecione um arquivo:";
            // 
            // btnExcluirArquivo
            // 
            this.btnExcluirArquivo.Enabled = false;
            this.btnExcluirArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirArquivo.Image")));
            this.btnExcluirArquivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirArquivo.Location = new System.Drawing.Point(491, 11);
            this.btnExcluirArquivo.Name = "btnExcluirArquivo";
            this.btnExcluirArquivo.Size = new System.Drawing.Size(26, 25);
            this.btnExcluirArquivo.TabIndex = 17;
            this.btnExcluirArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnExcluirArquivo, "Apagar o caminho do arquivo informado.");
            this.btnExcluirArquivo.UseVisualStyleBackColor = true;
            this.btnExcluirArquivo.Click += new System.EventHandler(this.btnExcluirArquivo_Click);
            this.btnExcluirArquivo.MouseLeave += new System.EventHandler(this.btnExcluirArquivo_MouseLeave);
            this.btnExcluirArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirArquivo_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(113, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "*";
            // 
            // lblSelecionar
            // 
            this.lblSelecionar.AutoSize = true;
            this.lblSelecionar.Location = new System.Drawing.Point(523, 17);
            this.lblSelecionar.Name = "lblSelecionar";
            this.lblSelecionar.Size = new System.Drawing.Size(115, 13);
            this.lblSelecionar.TabIndex = 0;
            this.lblSelecionar.Text = "Selecionar um arquivo:";
            // 
            // txtCaminho
            // 
            this.txtCaminho.BackColor = System.Drawing.Color.White;
            this.txtCaminho.Location = new System.Drawing.Point(116, 14);
            this.txtCaminho.MaxLength = 200;
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.ReadOnly = true;
            this.txtCaminho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCaminho.Size = new System.Drawing.Size(369, 20);
            this.txtCaminho.TabIndex = 16;
            this.txtCaminho.TextChanged += new System.EventHandler(this.txtCaminho_TextChanged);
            this.txtCaminho.Enter += new System.EventHandler(this.txtCaminho_Enter);
            this.txtCaminho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaminho_KeyPress);
            this.txtCaminho.Leave += new System.EventHandler(this.txtCaminho_Leave);
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Location = new System.Drawing.Point(6, 17);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(104, 13);
            this.lblCaminho.TabIndex = 0;
            this.lblCaminho.Text = "Caminho do arquivo:";
            // 
            // btnProcurar
            // 
            this.btnProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar.Image")));
            this.btnProcurar.Location = new System.Drawing.Point(644, 12);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnProcurar.TabIndex = 18;
            this.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnProcurar, "Adicionar um arquivo para caixa de texto caminho do arquivo.");
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            this.btnProcurar.MouseLeave += new System.EventHandler(this.btnProcurar_MouseLeave);
            this.btnProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar_MouseMove);
            // 
            // lblPalavrachave
            // 
            this.lblPalavrachave.AutoSize = true;
            this.lblPalavrachave.Location = new System.Drawing.Point(54, 16);
            this.lblPalavrachave.Name = "lblPalavrachave";
            this.lblPalavrachave.Size = new System.Drawing.Size(79, 13);
            this.lblPalavrachave.TabIndex = 0;
            this.lblPalavrachave.Text = "Palavra-chave:";
            // 
            // txtPalavraChave
            // 
            this.txtPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalavraChave.Location = new System.Drawing.Point(54, 32);
            this.txtPalavraChave.MaxLength = 10;
            this.txtPalavraChave.Name = "txtPalavraChave";
            this.txtPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPalavraChave.Size = new System.Drawing.Size(78, 20);
            this.txtPalavraChave.TabIndex = 13;
            this.txtPalavraChave.Enter += new System.EventHandler(this.txtPalavraChave_Enter);
            this.txtPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalavraChave_KeyPress);
            this.txtPalavraChave.Leave += new System.EventHandler(this.txtPalavraChave_Leave);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(169, 16);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(3, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(136, 16);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 32);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodigo.Size = new System.Drawing.Size(42, 20);
            this.txtCodigo.TabIndex = 12;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(138, 32);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescricao.Size = new System.Drawing.Size(300, 20);
            this.txtDescricao.TabIndex = 14;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(16, 234);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSair.Location = new System.Drawing.Point(647, 424);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 27;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnSair, "Sair do cadastro de arquivo.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(372, 424);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(463, 423);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 26;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.Location = new System.Drawing.Point(12, 424);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 107;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.Location = new System.Drawing.Point(190, 424);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 23;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnExcluir, "Excluir um arquivo cadastrado.");
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
            this.btnAlterar.Location = new System.Drawing.Point(114, 424);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 21;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnAlterar, "Alterar um arquivo cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(38, 424);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 20;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnNovo, "Cadastrar um novo arquivo.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Enabled = false;
            this.btnAbrirArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirArquivo.Image")));
            this.btnAbrirArquivo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAbrirArquivo.Location = new System.Drawing.Point(266, 424);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(100, 32);
            this.btnAbrirArquivo.TabIndex = 24;
            this.btnAbrirArquivo.Text = "A&brir Arquivo";
            this.btnAbrirArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnAbrirArquivo, "Abrir o arquivo contido na caixa de texto caminho do arquivo.");
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            this.btnAbrirArquivo.MouseLeave += new System.EventHandler(this.btnAbrirArquivo_MouseLeave);
            this.btnAbrirArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAbrirArquivo_MouseMove);
            // 
            // ttpArquivo
            // 
            this.ttpArquivo.AutoPopDelay = 5000;
            this.ttpArquivo.InitialDelay = 1000;
            this.ttpArquivo.IsBalloon = true;
            this.ttpArquivo.ReshowDelay = 100;
            this.ttpArquivo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpArquivo.ToolTipTitle = "Dica:";
            // 
            // FrmCadArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(715, 468);
            this.ControlBox = false;
            this.Controls.Add(this.btnAbrirArquivo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.dtArquivo);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadArquivo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Arquivos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadArquivo_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadArquivos_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadArquivo_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivo)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.grbBox4.ResumeLayout(false);
            this.grbBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNomeAluno;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.DataGridView dtArquivo;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblPalavrachave;
        private System.Windows.Forms.TextBox txtPalavraChave;
        private System.Windows.Forms.GroupBox grbBox4;
        private System.Windows.Forms.Label lblSelecionar;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtObs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.Label lblTipoTabela;
        private System.Windows.Forms.ComboBox cbbTipoTabela;
        private System.Windows.Forms.ComboBox cbbpTipoTabela;
        private System.Windows.Forms.RadioButton rbtnTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluirArquivo;
        private System.Windows.Forms.ToolTip ttpArquivo;
    }
}