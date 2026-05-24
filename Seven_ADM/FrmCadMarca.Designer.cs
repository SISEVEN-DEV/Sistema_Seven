namespace Seven_Sistema
{
    partial class FrmCadMarca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadMarca));
            this.ttpMarca = new System.Windows.Forms.ToolTip(this.components);
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnOrigem = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.cbbpOrigemPais = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.dtMarca = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbPais = new System.Windows.Forms.ComboBox();
            this.lblTabelaDestino = new System.Windows.Forms.Label();
            this.cbbOrigemPais = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPalavraChave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblNome_Desc = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMarca)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // ttpMarca
            // 
            this.ttpMarca.AutoPopDelay = 5000;
            this.ttpMarca.InitialDelay = 1000;
            this.ttpMarca.IsBalloon = true;
            this.ttpMarca.ReshowDelay = 100;
            this.ttpMarca.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMarca.ToolTipTitle = "Dica:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(532, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 11;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMarca.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(577, 357);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 24;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMarca.SetToolTip(this.btnSair, "Sair do Cadastro de Marcas.");
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
            this.btnCancelar.Location = new System.Drawing.Point(336, 357);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMarca.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(427, 357);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMarca.SetToolTip(this.btnSalvar, "Salvar dados informados.");
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
            this.btnExcluir.Location = new System.Drawing.Point(190, 357);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMarca.SetToolTip(this.btnExcluir, "Excluir uma Marca cadastrada.");
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
            this.btnAlterar.Location = new System.Drawing.Point(114, 357);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 20;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMarca.SetToolTip(this.btnAlterar, "Alterar uma Marca cadastrada.");
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
            this.btnNovo.Location = new System.Drawing.Point(38, 357);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 19;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMarca.SetToolTip(this.btnNovo, "Cadastrar uma nova Marca.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnOrigem);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.cbbpOrigemPais);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(620, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnOrigem
            // 
            this.rbtnOrigem.AutoSize = true;
            this.rbtnOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOrigem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnOrigem.Location = new System.Drawing.Point(102, 42);
            this.rbtnOrigem.Name = "rbtnOrigem";
            this.rbtnOrigem.Size = new System.Drawing.Size(58, 17);
            this.rbtnOrigem.TabIndex = 6;
            this.rbtnOrigem.TabStop = true;
            this.rbtnOrigem.Text = "Origem";
            this.rbtnOrigem.UseVisualStyleBackColor = true;
            this.rbtnOrigem.CheckedChanged += new System.EventHandler(this.rbtnTabelaDestino_CheckedChanged);
            this.rbtnOrigem.MouseLeave += new System.EventHandler(this.rbtnTabelaDestino_MouseLeave);
            this.rbtnOrigem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTabelaDestino_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(171, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
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
            this.lblPesquisar.Location = new System.Drawing.Point(274, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(506, 44);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPalavraChave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(6, 42);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavraChave.TabIndex = 5;
            this.rbtnPalavraChave.TabStop = true;
            this.rbtnPalavraChave.Text = "Palavra-Chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(102, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnDescricao
            // 
            this.rbtnDescricao.AutoSize = true;
            this.rbtnDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDescricao.Location = new System.Drawing.Point(6, 19);
            this.rbtnDescricao.Name = "rbtnDescricao";
            this.rbtnDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtnDescricao.TabIndex = 2;
            this.rbtnDescricao.Text = "Descrição";
            this.rbtnDescricao.UseVisualStyleBackColor = true;
            this.rbtnDescricao.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnDescricao.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(572, 18);
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
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpPalavraChave.Location = new System.Drawing.Point(534, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.Size = new System.Drawing.Size(80, 20);
            this.txtpPalavraChave.TabIndex = 8;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // cbbpOrigemPais
            // 
            this.cbbpOrigemPais.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpOrigemPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpOrigemPais.DropDownWidth = 180;
            this.cbbpOrigemPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpOrigemPais.FormattingEnabled = true;
            this.cbbpOrigemPais.Items.AddRange(new object[] {
            "",
            "NACIONAL",
            "ESTRANGEIRA"});
            this.cbbpOrigemPais.Location = new System.Drawing.Point(434, 17);
            this.cbbpOrigemPais.Name = "cbbpOrigemPais";
            this.cbbpOrigemPais.Size = new System.Drawing.Size(180, 21);
            this.cbbpOrigemPais.TabIndex = 10;
            this.cbbpOrigemPais.Visible = false;
            this.cbbpOrigemPais.DropDown += new System.EventHandler(this.cbbpOrigemPais_DropDown);
            this.cbbpOrigemPais.DropDownClosed += new System.EventHandler(this.cbbpOrigemPais_DropDownClosed);
            this.cbbpOrigemPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpOrigemPais_KeyPress);
            this.cbbpOrigemPais.MouseLeave += new System.EventHandler(this.cbbpOrigemPais_MouseLeave);
            this.cbbpOrigemPais.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpOrigemPais_MouseMove);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpDescricao.Location = new System.Drawing.Point(394, 17);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(220, 20);
            this.txtpDescricao.TabIndex = 7;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // dtMarca
            // 
            this.dtMarca.AllowUserToAddRows = false;
            this.dtMarca.AllowUserToDeleteRows = false;
            this.dtMarca.AllowUserToResizeRows = false;
            this.dtMarca.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMarca.Enabled = false;
            this.dtMarca.Location = new System.Drawing.Point(12, 97);
            this.dtMarca.MultiSelect = false;
            this.dtMarca.Name = "dtMarca";
            this.dtMarca.ReadOnly = true;
            this.dtMarca.RowHeadersVisible = false;
            this.dtMarca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtMarca.ShowCellErrors = false;
            this.dtMarca.ShowCellToolTips = false;
            this.dtMarca.ShowEditingIcon = false;
            this.dtMarca.ShowRowErrors = false;
            this.dtMarca.Size = new System.Drawing.Size(620, 172);
            this.dtMarca.TabIndex = 12;
            this.dtMarca.DataSourceChanged += new System.EventHandler(this.dtGrupo_DataSourceChanged);
            this.dtMarca.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtMarca_CellEnter);
            this.dtMarca.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtMarca_RowsAdded);
            this.dtMarca.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtMarca_RowsRemoved);
            this.dtMarca.MouseLeave += new System.EventHandler(this.dtGrupo_MouseLeave);
            this.dtMarca.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtGrupo_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(472, 272);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 16);
            this.lblRegistros.TabIndex = 14;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.label7);
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.cbbPais);
            this.grbBox2.Controls.Add(this.lblTabelaDestino);
            this.grbBox2.Controls.Add(this.cbbOrigemPais);
            this.grbBox2.Controls.Add(this.label5);
            this.grbBox2.Controls.Add(this.txtPalavraChave);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.txtDescricao);
            this.grbBox2.Controls.Add(this.lblNome_Desc);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox2.Location = new System.Drawing.Point(12, 291);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(620, 60);
            this.grbBox2.TabIndex = 13;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(474, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 31;
            this.label7.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(355, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(447, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 33;
            this.label1.Tag = "";
            this.label1.Text = "País:";
            // 
            // cbbPais
            // 
            this.cbbPais.BackColor = System.Drawing.Color.LightBlue;
            this.cbbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPais.DropDownWidth = 450;
            this.cbbPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPais.FormattingEnabled = true;
            this.cbbPais.Location = new System.Drawing.Point(450, 32);
            this.cbbPais.Name = "cbbPais";
            this.cbbPais.Size = new System.Drawing.Size(164, 21);
            this.cbbPais.TabIndex = 18;
            this.cbbPais.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.cbbPais.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            this.cbbPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPais_KeyPress);
            this.cbbPais.Leave += new System.EventHandler(this.cbbPais_Leave);
            this.cbbPais.MouseLeave += new System.EventHandler(this.comboBox1_MouseLeave);
            this.cbbPais.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseMove);
            // 
            // lblTabelaDestino
            // 
            this.lblTabelaDestino.AutoSize = true;
            this.lblTabelaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabelaDestino.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTabelaDestino.Location = new System.Drawing.Point(317, 16);
            this.lblTabelaDestino.Name = "lblTabelaDestino";
            this.lblTabelaDestino.Size = new System.Drawing.Size(43, 13);
            this.lblTabelaDestino.TabIndex = 0;
            this.lblTabelaDestino.Tag = "";
            this.lblTabelaDestino.Text = "Origem:";
            // 
            // cbbOrigemPais
            // 
            this.cbbOrigemPais.BackColor = System.Drawing.Color.LightBlue;
            this.cbbOrigemPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOrigemPais.DropDownWidth = 180;
            this.cbbOrigemPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOrigemPais.FormattingEnabled = true;
            this.cbbOrigemPais.Items.AddRange(new object[] {
            "",
            "NACIONAL",
            "ESTRANGEIRA"});
            this.cbbOrigemPais.Location = new System.Drawing.Point(320, 32);
            this.cbbOrigemPais.Name = "cbbOrigemPais";
            this.cbbOrigemPais.Size = new System.Drawing.Size(124, 21);
            this.cbbOrigemPais.TabIndex = 17;
            this.cbbOrigemPais.DropDown += new System.EventHandler(this.cbbTabelaDestino_DropDown);
            this.cbbOrigemPais.SelectedIndexChanged += new System.EventHandler(this.cbbOrigemPais_SelectedIndexChanged);
            this.cbbOrigemPais.DropDownClosed += new System.EventHandler(this.cbbTabelaDestino_DropDownClosed);
            this.cbbOrigemPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbOrigemPais_KeyPress);
            this.cbbOrigemPais.MouseLeave += new System.EventHandler(this.cbbTabelaDestino_MouseLeave);
            this.cbbOrigemPais.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTabelaDestino_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(55, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Palavra-Chave:";
            // 
            // txtPalavraChave
            // 
            this.txtPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPalavraChave.Location = new System.Drawing.Point(58, 32);
            this.txtPalavraChave.MaxLength = 10;
            this.txtPalavraChave.Name = "txtPalavraChave";
            this.txtPalavraChave.Size = new System.Drawing.Size(80, 20);
            this.txtPalavraChave.TabIndex = 15;
            this.txtPalavraChave.Enter += new System.EventHandler(this.txtPalavraChave_Enter);
            this.txtPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalavraChave_KeyPress);
            this.txtPalavraChave.Leave += new System.EventHandler(this.txtPalavraChave_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(194, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDescricao.Location = new System.Drawing.Point(144, 32);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(170, 20);
            this.txtDescricao.TabIndex = 16;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // lblNome_Desc
            // 
            this.lblNome_Desc.AutoSize = true;
            this.lblNome_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome_Desc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNome_Desc.Location = new System.Drawing.Point(141, 16);
            this.lblNome_Desc.Name = "lblNome_Desc";
            this.lblNome_Desc.Size = new System.Drawing.Size(58, 13);
            this.lblNome_Desc.TabIndex = 0;
            this.lblNome_Desc.Text = "Descrição:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(6, 32);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtCodigo.TabIndex = 14;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Blue;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(3, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 357);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 102;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // FrmCadMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(643, 393);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.dtMarca);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadMarca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Marcas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadMarcaProduto_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadMarcaProduto_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadMarcaProduto_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMarca)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpMarca;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnOrigem;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.ComboBox cbbpOrigemPais;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.DataGridView dtMarca;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbPais;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTabelaDestino;
        private System.Windows.Forms.ComboBox cbbOrigemPais;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPalavraChave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblNome_Desc;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label label3;
    }
}