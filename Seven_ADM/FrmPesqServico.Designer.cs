namespace Seven_Sistema
{
    partial class FrmPesqServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqServico));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnGrupo = new System.Windows.Forms.RadioButton();
            this.lblSubGrupo1 = new System.Windows.Forms.Label();
            this.btnpProcurarSub1 = new System.Windows.Forms.Button();
            this.cbbpSubGrupo = new System.Windows.Forms.ComboBox();
            this.btnpProcurarServico = new System.Windows.Forms.Button();
            this.rbtnItemServico = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.cbbpItemServico = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.cbbpGrupo = new System.Windows.Forms.ComboBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtServico = new System.Windows.Forms.DataGridView();
            this.ttpServico = new System.Windows.Forms.ToolTip(this.components);
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtServico)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnGrupo);
            this.grbBox1.Controls.Add(this.lblSubGrupo1);
            this.grbBox1.Controls.Add(this.btnpProcurarSub1);
            this.grbBox1.Controls.Add(this.cbbpSubGrupo);
            this.grbBox1.Controls.Add(this.btnpProcurarServico);
            this.grbBox1.Controls.Add(this.rbtnItemServico);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.cbbpItemServico);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Controls.Add(this.cbbpGrupo);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(679, 79);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // rbtnGrupo
            // 
            this.rbtnGrupo.AutoSize = true;
            this.rbtnGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnGrupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnGrupo.Location = new System.Drawing.Point(6, 42);
            this.rbtnGrupo.Name = "rbtnGrupo";
            this.rbtnGrupo.Size = new System.Drawing.Size(112, 17);
            this.rbtnGrupo.TabIndex = 43;
            this.rbtnGrupo.Text = "Grupo e Subgrupo";
            this.rbtnGrupo.UseVisualStyleBackColor = true;
            this.rbtnGrupo.CheckedChanged += new System.EventHandler(this.rbtnGrupo_CheckedChanged);
            // 
            // lblSubGrupo1
            // 
            this.lblSubGrupo1.AutoSize = true;
            this.lblSubGrupo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSubGrupo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubGrupo1.Location = new System.Drawing.Point(255, 48);
            this.lblSubGrupo1.Name = "lblSubGrupo1";
            this.lblSubGrupo1.Size = new System.Drawing.Size(69, 13);
            this.lblSubGrupo1.TabIndex = 39;
            this.lblSubGrupo1.Text = "Sub-grupo:";
            this.lblSubGrupo1.Visible = false;
            // 
            // btnpProcurarSub1
            // 
            this.btnpProcurarSub1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpProcurarSub1.Enabled = false;
            this.btnpProcurarSub1.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurarSub1.Image")));
            this.btnpProcurarSub1.Location = new System.Drawing.Point(533, 43);
            this.btnpProcurarSub1.Name = "btnpProcurarSub1";
            this.btnpProcurarSub1.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurarSub1.TabIndex = 11;
            this.btnpProcurarSub1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpServico.SetToolTip(this.btnpProcurarSub1, "Clique para pesquisar um Sub-Grupo.");
            this.btnpProcurarSub1.UseVisualStyleBackColor = true;
            this.btnpProcurarSub1.Visible = false;
            this.btnpProcurarSub1.Click += new System.EventHandler(this.btnpProcurarSub1_Click);
            // 
            // cbbpSubGrupo
            // 
            this.cbbpSubGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpSubGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbpSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpSubGrupo.DropDownWidth = 550;
            this.cbbpSubGrupo.Enabled = false;
            this.cbbpSubGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpSubGrupo.FormattingEnabled = true;
            this.cbbpSubGrupo.Location = new System.Drawing.Point(330, 45);
            this.cbbpSubGrupo.Name = "cbbpSubGrupo";
            this.cbbpSubGrupo.Size = new System.Drawing.Size(197, 21);
            this.cbbpSubGrupo.TabIndex = 10;
            this.cbbpSubGrupo.Visible = false;
            this.cbbpSubGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpSubGrupo_KeyPress);
            // 
            // btnpProcurarServico
            // 
            this.btnpProcurarServico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpProcurarServico.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurarServico.Image")));
            this.btnpProcurarServico.Location = new System.Drawing.Point(647, 15);
            this.btnpProcurarServico.Name = "btnpProcurarServico";
            this.btnpProcurarServico.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurarServico.TabIndex = 8;
            this.btnpProcurarServico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpServico.SetToolTip(this.btnpProcurarServico, "Clique para pesquisar um item de serviço.");
            this.btnpProcurarServico.UseVisualStyleBackColor = true;
            this.btnpProcurarServico.Visible = false;
            this.btnpProcurarServico.Click += new System.EventHandler(this.btnpProcurarServico_Click);
            // 
            // rbtnItemServico
            // 
            this.rbtnItemServico.AutoSize = true;
            this.rbtnItemServico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnItemServico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnItemServico.Location = new System.Drawing.Point(183, 19);
            this.rbtnItemServico.Name = "rbtnItemServico";
            this.rbtnItemServico.Size = new System.Drawing.Size(84, 17);
            this.rbtnItemServico.TabIndex = 32;
            this.rbtnItemServico.TabStop = true;
            this.rbtnItemServico.Text = "Item Serviço";
            this.rbtnItemServico.UseVisualStyleBackColor = true;
            this.rbtnItemServico.CheckedChanged += new System.EventHandler(this.rbtnItemServico_CheckedChanged);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(117, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(566, 44);
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
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(592, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 12;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpServico.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(117, 19);
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
            this.txtpCodigo.Location = new System.Drawing.Point(589, 18);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(85, 20);
            this.txtpCodigo.TabIndex = 6;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(314, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // cbbpItemServico
            // 
            this.cbbpItemServico.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpItemServico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbpItemServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpItemServico.DropDownWidth = 550;
            this.cbbpItemServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpItemServico.FormattingEnabled = true;
            this.cbbpItemServico.Location = new System.Drawing.Point(434, 18);
            this.cbbpItemServico.Name = "cbbpItemServico";
            this.cbbpItemServico.Size = new System.Drawing.Size(207, 21);
            this.cbbpItemServico.TabIndex = 7;
            this.cbbpItemServico.Visible = false;
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpDescricao.Location = new System.Drawing.Point(434, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(240, 20);
            this.txtpDescricao.TabIndex = 5;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // cbbpGrupo
            // 
            this.cbbpGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbpGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpGrupo.DropDownWidth = 550;
            this.cbbpGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpGrupo.FormattingEnabled = true;
            this.cbbpGrupo.Location = new System.Drawing.Point(398, 18);
            this.cbbpGrupo.Name = "cbbpGrupo";
            this.cbbpGrupo.Size = new System.Drawing.Size(243, 21);
            this.cbbpGrupo.TabIndex = 40;
            this.cbbpGrupo.Visible = false;
            this.cbbpGrupo.SelectedIndexChanged += new System.EventHandler(this.cbbpGrupo_SelectedIndexChanged);
            this.cbbpGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpGrupo_KeyPress);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(636, 275);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpServico.SetToolTip(this.btnVoltar, "Sair de Pesquisar Serviços.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(560, 275);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 15;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpServico.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 272);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 16;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtServico
            // 
            this.dtServico.AllowUserToAddRows = false;
            this.dtServico.AllowUserToDeleteRows = false;
            this.dtServico.AllowUserToResizeRows = false;
            this.dtServico.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtServico.Enabled = false;
            this.dtServico.Location = new System.Drawing.Point(12, 97);
            this.dtServico.MultiSelect = false;
            this.dtServico.Name = "dtServico";
            this.dtServico.ReadOnly = true;
            this.dtServico.RowHeadersVisible = false;
            this.dtServico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtServico.ShowCellErrors = false;
            this.dtServico.ShowCellToolTips = false;
            this.dtServico.ShowEditingIcon = false;
            this.dtServico.ShowRowErrors = false;
            this.dtServico.Size = new System.Drawing.Size(679, 172);
            this.dtServico.TabIndex = 13;
            this.dtServico.DataSourceChanged += new System.EventHandler(this.dtServico_DataSourceChanged);
            this.dtServico.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtServico_CellEnter);
            this.dtServico.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtServico_CellFormatting);
            this.dtServico.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtServico_RowsAdded);
            this.dtServico.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtServico_RowsRemoved);
            this.dtServico.DoubleClick += new System.EventHandler(this.dtServico_DoubleClick);
            this.dtServico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtServico_KeyDown);
            this.dtServico.MouseLeave += new System.EventHandler(this.dtServico_MouseLeave);
            this.dtServico.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtServico_MouseMove);
            // 
            // ttpServico
            // 
            this.ttpServico.AutoPopDelay = 5000;
            this.ttpServico.InitialDelay = 1000;
            this.ttpServico.IsBalloon = true;
            this.ttpServico.ReshowDelay = 100;
            this.ttpServico.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpServico.ToolTipTitle = "Dica:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCadastrar.Location = new System.Drawing.Point(468, 275);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(86, 32);
            this.btnCadastrar.TabIndex = 14;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpServico.SetToolTip(this.btnCadastrar, "Clique para cadastrar um Serviço.");
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Visible = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            this.btnCadastrar.MouseLeave += new System.EventHandler(this.btnCadastrar_MouseLeave);
            this.btnCadastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // FrmPesqServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(703, 312);
            this.ControlBox = false;
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dtServico);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FrmPesqServico";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Serviços";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmpesqServico_FormClosed);
            this.Load += new System.EventHandler(this.FrmpesqServico_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqServico_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtServico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dtServico;
        private System.Windows.Forms.ToolTip ttpServico;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.RadioButton rbtnItemServico;
        private System.Windows.Forms.ComboBox cbbpItemServico;
        private System.Windows.Forms.Button btnpProcurarServico;
        private System.Windows.Forms.Label lblSubGrupo1;
        private System.Windows.Forms.Button btnpProcurarSub1;
        private System.Windows.Forms.ComboBox cbbpSubGrupo;
        private System.Windows.Forms.ComboBox cbbpGrupo;
        private System.Windows.Forms.RadioButton rbtnGrupo;
    }
}