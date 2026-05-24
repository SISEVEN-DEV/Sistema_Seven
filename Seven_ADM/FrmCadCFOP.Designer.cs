namespace Seven_Sistema
{
    partial class FrmCadCFOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadCFOP));
            this.dtCFOP = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFinalidade = new System.Windows.Forms.Label();
            this.cbbFinalidade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblNome_Desc = new System.Windows.Forms.Label();
            this.txtCodigoCFOP = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnFinalidade = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.cbbpFinalidade = new System.Windows.Forms.ComboBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.ttpCFOP = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtCFOP)).BeginInit();
            this.grbBox2.SuspendLayout();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // dtCFOP
            // 
            this.dtCFOP.AllowUserToAddRows = false;
            this.dtCFOP.AllowUserToDeleteRows = false;
            this.dtCFOP.AllowUserToResizeRows = false;
            this.dtCFOP.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtCFOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCFOP.Enabled = false;
            this.dtCFOP.Location = new System.Drawing.Point(12, 97);
            this.dtCFOP.MultiSelect = false;
            this.dtCFOP.Name = "dtCFOP";
            this.dtCFOP.ReadOnly = true;
            this.dtCFOP.RowHeadersVisible = false;
            this.dtCFOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCFOP.ShowCellErrors = false;
            this.dtCFOP.ShowCellToolTips = false;
            this.dtCFOP.ShowEditingIcon = false;
            this.dtCFOP.ShowRowErrors = false;
            this.dtCFOP.Size = new System.Drawing.Size(620, 172);
            this.dtCFOP.TabIndex = 10;
            this.dtCFOP.DataSourceChanged += new System.EventHandler(this.dtCFOP_DataSourceChanged);
            this.dtCFOP.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCFOP_CellEnter);
            this.dtCFOP.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtCFOP_RowsAdded);
            this.dtCFOP.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtCFOP_RowsRemoved);
            this.dtCFOP.MouseLeave += new System.EventHandler(this.dtCFOP_MouseLeave);
            this.dtCFOP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtCFOP_MouseMove);
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
            this.lblRegistros.TabIndex = 96;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.lblFinalidade);
            this.grbBox2.Controls.Add(this.cbbFinalidade);
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.txtDescricao);
            this.grbBox2.Controls.Add(this.lblNome_Desc);
            this.grbBox2.Controls.Add(this.txtCodigoCFOP);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox2.Location = new System.Drawing.Point(12, 291);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(620, 60);
            this.grbBox2.TabIndex = 11;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(152, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(541, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "*";
            // 
            // lblFinalidade
            // 
            this.lblFinalidade.AutoSize = true;
            this.lblFinalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFinalidade.Location = new System.Drawing.Point(488, 16);
            this.lblFinalidade.Name = "lblFinalidade";
            this.lblFinalidade.Size = new System.Drawing.Size(58, 13);
            this.lblFinalidade.TabIndex = 13;
            this.lblFinalidade.Text = "Finalidade:";
            // 
            // cbbFinalidade
            // 
            this.cbbFinalidade.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFinalidade.DropDownHeight = 150;
            this.cbbFinalidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFinalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbFinalidade.FormattingEnabled = true;
            this.cbbFinalidade.IntegralHeight = false;
            this.cbbFinalidade.Items.AddRange(new object[] {
            "",
            "SAIDA",
            "ENTRADA",
            "DEVOLUCAO",
            "RETORNO",
            "OUTROS"});
            this.cbbFinalidade.Location = new System.Drawing.Point(491, 31);
            this.cbbFinalidade.Name = "cbbFinalidade";
            this.cbbFinalidade.Size = new System.Drawing.Size(122, 21);
            this.cbbFinalidade.TabIndex = 14;
            this.cbbFinalidade.DropDown += new System.EventHandler(this.cbbFinalidade_DropDown);
            this.cbbFinalidade.DropDownClosed += new System.EventHandler(this.cbbFinalidade_DropDownClosed);
            this.cbbFinalidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFinalidade_KeyPress);
            this.cbbFinalidade.MouseLeave += new System.EventHandler(this.cbbFinalidade_MouseLeave);
            this.cbbFinalidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFinalidade_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(90, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "*";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDescricao.Location = new System.Drawing.Point(102, 32);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(383, 20);
            this.txtDescricao.TabIndex = 13;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // lblNome_Desc
            // 
            this.lblNome_Desc.AutoSize = true;
            this.lblNome_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome_Desc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNome_Desc.Location = new System.Drawing.Point(99, 16);
            this.lblNome_Desc.Name = "lblNome_Desc";
            this.lblNome_Desc.Size = new System.Drawing.Size(58, 13);
            this.lblNome_Desc.TabIndex = 0;
            this.lblNome_Desc.Text = "Descrição:";
            // 
            // txtCodigoCFOP
            // 
            this.txtCodigoCFOP.BackColor = System.Drawing.Color.White;
            this.txtCodigoCFOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigoCFOP.Location = new System.Drawing.Point(6, 32);
            this.txtCodigoCFOP.MaxLength = 4;
            this.txtCodigoCFOP.Name = "txtCodigoCFOP";
            this.txtCodigoCFOP.Size = new System.Drawing.Size(90, 20);
            this.txtCodigoCFOP.TabIndex = 12;
            this.txtCodigoCFOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoCFOP.Enter += new System.EventHandler(this.txtCodigoCFOP_Enter);
            this.txtCodigoCFOP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCFOP_KeyPress);
            this.txtCodigoCFOP.Leave += new System.EventHandler(this.txtCodigoCFOP_Leave);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(89, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código do CFOP:";
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnFinalidade);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.cbbpFinalidade);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(620, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnFinalidade
            // 
            this.rbtnFinalidade.AutoSize = true;
            this.rbtnFinalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFinalidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnFinalidade.Location = new System.Drawing.Point(6, 42);
            this.rbtnFinalidade.Name = "rbtnFinalidade";
            this.rbtnFinalidade.Size = new System.Drawing.Size(73, 17);
            this.rbtnFinalidade.TabIndex = 4;
            this.rbtnFinalidade.Text = "Finalidade";
            this.rbtnFinalidade.UseVisualStyleBackColor = true;
            this.rbtnFinalidade.CheckedChanged += new System.EventHandler(this.rbtnFinalidade_CheckedChanged);
            this.rbtnFinalidade.MouseLeave += new System.EventHandler(this.rbtnFinalidade_MouseLeave);
            this.rbtnFinalidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(117, 42);
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
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(415, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(151, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a código do CFOP:";
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
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(532, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCFOP.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
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
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(104, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código do CFOP";
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
            this.rbtnDescricao.Location = new System.Drawing.Point(116, 19);
            this.rbtnDescricao.Name = "rbtnDescricao";
            this.rbtnDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtnDescricao.TabIndex = 3;
            this.rbtnDescricao.Text = "Descrição";
            this.rbtnDescricao.UseVisualStyleBackColor = true;
            this.rbtnDescricao.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnDescricao.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // cbbpFinalidade
            // 
            this.cbbpFinalidade.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpFinalidade.DropDownHeight = 150;
            this.cbbpFinalidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpFinalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbpFinalidade.FormattingEnabled = true;
            this.cbbpFinalidade.IntegralHeight = false;
            this.cbbpFinalidade.Items.AddRange(new object[] {
            "",
            "SAIDA",
            "ENTRADA",
            "DEVOLUCAO",
            "RETORNO",
            "OUTROS"});
            this.cbbpFinalidade.Location = new System.Drawing.Point(492, 18);
            this.cbbpFinalidade.Name = "cbbpFinalidade";
            this.cbbpFinalidade.Size = new System.Drawing.Size(122, 21);
            this.cbbpFinalidade.TabIndex = 7;
            this.cbbpFinalidade.Visible = false;
            this.cbbpFinalidade.DropDown += new System.EventHandler(this.cbbpFinalidade_DropDown);
            this.cbbpFinalidade.DropDownClosed += new System.EventHandler(this.cbbpFinalidade_DropDownClosed);
            this.cbbpFinalidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpFinalidade_KeyPress);
            this.cbbpFinalidade.MouseLeave += new System.EventHandler(this.cbbpFinalidade_MouseLeave);
            this.cbbpFinalidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpFinalidade_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(572, 18);
            this.txtpCodigo.MaxLength = 4;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(42, 20);
            this.txtpCodigo.TabIndex = 8;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpDescricao.Location = new System.Drawing.Point(374, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(240, 20);
            this.txtpDescricao.TabIndex = 6;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
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
            this.picbInterrogacao.TabIndex = 106;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(577, 357);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 20;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCFOP.SetToolTip(this.btnSair, "Sair do Cadastro de CFOP.");
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
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCFOP.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
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
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCFOP.SetToolTip(this.btnSalvar, "Salvar dados informados.");
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
            this.btnExcluir.TabIndex = 17;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCFOP.SetToolTip(this.btnExcluir, "Excluir um CFOP cadastrado.");
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
            this.btnAlterar.TabIndex = 16;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCFOP.SetToolTip(this.btnAlterar, "Alterar um CFOP cadastrado.");
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
            this.btnNovo.TabIndex = 15;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCFOP.SetToolTip(this.btnNovo, "Cadastrar um novo CFOP.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // ttpCFOP
            // 
            this.ttpCFOP.AutoPopDelay = 5000;
            this.ttpCFOP.InitialDelay = 1000;
            this.ttpCFOP.IsBalloon = true;
            this.ttpCFOP.ReshowDelay = 100;
            this.ttpCFOP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCFOP.ToolTipTitle = "Dica:";
            // 
            // FrmCadCFOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(644, 393);
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
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtCFOP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadCFOP";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de CFOP/Natureza da Operação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadCFOP_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadCFOP_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtCFOP)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtCFOP;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblNome_Desc;
        private System.Windows.Forms.TextBox txtCodigoCFOP;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.ToolTip ttpCFOP;
        private System.Windows.Forms.RadioButton rbtnFinalidade;
        private System.Windows.Forms.ComboBox cbbFinalidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFinalidade;
        private System.Windows.Forms.ComboBox cbbpFinalidade;
        private System.Windows.Forms.Label label2;
    }
}