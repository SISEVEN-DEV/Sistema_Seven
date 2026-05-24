namespace Seven_Sistema
{
    partial class FrmCadSubGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadSubGrupo));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.cbbpGrupo = new System.Windows.Forms.ComboBox();
            this.btnpGrupo = new System.Windows.Forms.Button();
            this.rbtnGrupo = new System.Windows.Forms.RadioButton();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.dtSubGrupo = new System.Windows.Forms.DataGridView();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnProcurar1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbGrupo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPalavraChave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblNome_Desc = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.ttpSubGrupo = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSubGrupo)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.cbbpGrupo);
            this.grbBox1.Controls.Add(this.btnpGrupo);
            this.grbBox1.Controls.Add(this.rbtnGrupo);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox1.Location = new System.Drawing.Point(29, 50);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(570, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // cbbpGrupo
            // 
            this.cbbpGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpGrupo.DropDownWidth = 650;
            this.cbbpGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpGrupo.FormattingEnabled = true;
            this.cbbpGrupo.Location = new System.Drawing.Point(321, 17);
            this.cbbpGrupo.Name = "cbbpGrupo";
            this.cbbpGrupo.Size = new System.Drawing.Size(211, 21);
            this.cbbpGrupo.TabIndex = 10;
            this.cbbpGrupo.DropDown += new System.EventHandler(this.cbbpGrupo_DropDown);
            this.cbbpGrupo.DropDownClosed += new System.EventHandler(this.cbbpGrupo_DropDownClosed);
            this.cbbpGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpGrupo_KeyPress);
            this.cbbpGrupo.MouseLeave += new System.EventHandler(this.cbbpGrupo_MouseLeave);
            this.cbbpGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpGrupo_MouseMove);
            // 
            // btnpGrupo
            // 
            this.btnpGrupo.Image = ((System.Drawing.Image)(resources.GetObject("btnpGrupo.Image")));
            this.btnpGrupo.Location = new System.Drawing.Point(538, 15);
            this.btnpGrupo.Name = "btnpGrupo";
            this.btnpGrupo.Size = new System.Drawing.Size(26, 25);
            this.btnpGrupo.TabIndex = 11;
            this.btnpGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnpGrupo, "Clique para pesquisar um grupo.");
            this.btnpGrupo.UseVisualStyleBackColor = true;
            this.btnpGrupo.Click += new System.EventHandler(this.btnpGrupo_Click);
            this.btnpGrupo.MouseLeave += new System.EventHandler(this.btnpGrupo_MouseLeave);
            this.btnpGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpGrupo_MouseMove);
            // 
            // rbtnGrupo
            // 
            this.rbtnGrupo.AutoSize = true;
            this.rbtnGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnGrupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnGrupo.Location = new System.Drawing.Point(6, 41);
            this.rbtnGrupo.Name = "rbtnGrupo";
            this.rbtnGrupo.Size = new System.Drawing.Size(54, 17);
            this.rbtnGrupo.TabIndex = 4;
            this.rbtnGrupo.Text = "Grupo";
            this.rbtnGrupo.UseVisualStyleBackColor = true;
            this.rbtnGrupo.CheckedChanged += new System.EventHandler(this.rbtnGrupo_CheckedChanged);
            this.rbtnGrupo.MouseLeave += new System.EventHandler(this.rbtnGrupo_MouseLeave);
            this.rbtnGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnGrupo_MouseMove);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPalavraChave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(78, 41);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavraChave.TabIndex = 5;
            this.rbtnPalavraChave.Text = "Palavra-Chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(142, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 6;
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
            this.lblPesquisar.Location = new System.Drawing.Point(201, 21);
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
            this.picbInterrogacao2.Location = new System.Drawing.Point(456, 41);
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
            this.btnPesquisar.Location = new System.Drawing.Point(482, 41);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 12;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
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
            this.rbtnCodigo.Location = new System.Drawing.Point(78, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
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
            this.txtpCodigo.Location = new System.Drawing.Point(522, 18);
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
            this.txtpPalavraChave.Location = new System.Drawing.Point(484, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.Size = new System.Drawing.Size(80, 20);
            this.txtpPalavraChave.TabIndex = 8;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpDescricao.Location = new System.Drawing.Point(321, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(240, 20);
            this.txtpDescricao.TabIndex = 7;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // dtSubGrupo
            // 
            this.dtSubGrupo.AllowUserToAddRows = false;
            this.dtSubGrupo.AllowUserToDeleteRows = false;
            this.dtSubGrupo.AllowUserToResizeRows = false;
            this.dtSubGrupo.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtSubGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtSubGrupo.Enabled = false;
            this.dtSubGrupo.Location = new System.Drawing.Point(29, 135);
            this.dtSubGrupo.MultiSelect = false;
            this.dtSubGrupo.Name = "dtSubGrupo";
            this.dtSubGrupo.ReadOnly = true;
            this.dtSubGrupo.RowHeadersVisible = false;
            this.dtSubGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtSubGrupo.ShowCellErrors = false;
            this.dtSubGrupo.ShowCellToolTips = false;
            this.dtSubGrupo.ShowEditingIcon = false;
            this.dtSubGrupo.ShowRowErrors = false;
            this.dtSubGrupo.Size = new System.Drawing.Size(570, 172);
            this.dtSubGrupo.TabIndex = 13;
            this.dtSubGrupo.DataSourceChanged += new System.EventHandler(this.dtGrupo_DataSourceChanged);
            this.dtSubGrupo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtSubGrupo_CellEnter);
            this.dtSubGrupo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtSubGrupo_RowsAdded);
            this.dtSubGrupo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtSubGrupo_RowsRemoved);
            this.dtSubGrupo.MouseLeave += new System.EventHandler(this.dtSubGrupo_MouseLeave);
            this.dtSubGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtSubGrupo_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.label7);
            this.grbBox2.Controls.Add(this.btnProcurar1);
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.cbbGrupo);
            this.grbBox2.Controls.Add(this.label5);
            this.grbBox2.Controls.Add(this.txtPalavraChave);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.txtDescricao);
            this.grbBox2.Controls.Add(this.lblNome_Desc);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox2.Location = new System.Drawing.Point(29, 329);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(570, 60);
            this.grbBox2.TabIndex = 14;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(378, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "*";
            // 
            // btnProcurar1
            // 
            this.btnProcurar1.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar1.Image")));
            this.btnProcurar1.Location = new System.Drawing.Point(538, 29);
            this.btnProcurar1.Name = "btnProcurar1";
            this.btnProcurar1.Size = new System.Drawing.Size(26, 25);
            this.btnProcurar1.TabIndex = 19;
            this.btnProcurar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnProcurar1, "Clique para pesquisar um grupo.");
            this.btnProcurar1.UseVisualStyleBackColor = true;
            this.btnProcurar1.Click += new System.EventHandler(this.btnProcurar1_Click);
            this.btnProcurar1.MouseLeave += new System.EventHandler(this.btnProcurar1_MouseLeave);
            this.btnProcurar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(344, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Grupo:";
            // 
            // cbbGrupo
            // 
            this.cbbGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGrupo.DropDownWidth = 650;
            this.cbbGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbGrupo.FormattingEnabled = true;
            this.cbbGrupo.Location = new System.Drawing.Point(347, 32);
            this.cbbGrupo.Name = "cbbGrupo";
            this.cbbGrupo.Size = new System.Drawing.Size(185, 21);
            this.cbbGrupo.TabIndex = 18;
            this.cbbGrupo.DropDown += new System.EventHandler(this.cbbGrupo_DropDown);
            this.cbbGrupo.DropDownClosed += new System.EventHandler(this.cbbGrupo_DropDownClosed);
            this.cbbGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbGrupo_KeyPress);
            this.cbbGrupo.Leave += new System.EventHandler(this.cbbGrupo_Leave);
            this.cbbGrupo.MouseLeave += new System.EventHandler(this.cbbGrupo_MouseLeave);
            this.cbbGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbGrupo_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(52, 16);
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
            this.txtPalavraChave.Location = new System.Drawing.Point(55, 32);
            this.txtPalavraChave.MaxLength = 10;
            this.txtPalavraChave.Name = "txtPalavraChave";
            this.txtPalavraChave.Size = new System.Drawing.Size(80, 20);
            this.txtPalavraChave.TabIndex = 16;
            this.txtPalavraChave.Enter += new System.EventHandler(this.txtPalavraChave_Enter);
            this.txtPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalavraChave_KeyPress);
            this.txtPalavraChave.Leave += new System.EventHandler(this.txtPalavraChave_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(191, 13);
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
            this.txtDescricao.Location = new System.Drawing.Point(141, 32);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(200, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // lblNome_Desc
            // 
            this.lblNome_Desc.AutoSize = true;
            this.lblNome_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome_Desc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNome_Desc.Location = new System.Drawing.Point(138, 16);
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
            this.txtCodigo.TabIndex = 15;
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
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(439, 310);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 16);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(331, 395);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(422, 395);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 24;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnSalvar, "Salvar dados informados.");
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
            this.btnExcluir.Location = new System.Drawing.Point(208, 395);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 22;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnExcluir, "Excluir um Subgrupo cadastrado.");
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
            this.btnAlterar.Location = new System.Drawing.Point(132, 395);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 21;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnAlterar, "Alterar um Subgrupo cadastrado.");
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
            this.btnNovo.Location = new System.Drawing.Point(55, 395);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 20;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnNovo, "Cadastrar um novo Subgrupo.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibInterrogacao2.Location = new System.Drawing.Point(29, 395);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 106;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // ttpSubGrupo
            // 
            this.ttpSubGrupo.AutoPopDelay = 5000;
            this.ttpSubGrupo.InitialDelay = 1000;
            this.ttpSubGrupo.IsBalloon = true;
            this.ttpSubGrupo.ReshowDelay = 100;
            this.ttpSubGrupo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpSubGrupo.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(544, 395);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 25;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSubGrupo.SetToolTip(this.btnSair, "Sair do Cadastro de Subgrupos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.btnSalvar);
            this.pEnabled.Controls.Add(this.btnCancelar);
            this.pEnabled.Controls.Add(this.pcibInterrogacao2);
            this.pEnabled.Controls.Add(this.dtSubGrupo);
            this.pEnabled.Controls.Add(this.btnExcluir);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.btnAlterar);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.btnNovo);
            this.pEnabled.Location = new System.Drawing.Point(-17, -38);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(631, 580);
            this.pEnabled.TabIndex = 107;
            this.pEnabled.Paint += new System.Windows.Forms.PaintEventHandler(this.pEnabled_Paint);
            // 
            // FrmCadSubGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(595, 393);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadSubGrupo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Subgrupos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadSubGrupo_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadSubGrupo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadSubGrupo_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSubGrupo)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.DataGridView dtSubGrupo;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblNome_Desc;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
        private System.Windows.Forms.ToolTip ttpSubGrupo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPalavraChave;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnProcurar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbGrupo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.RadioButton rbtnGrupo;
        private System.Windows.Forms.Button btnpGrupo;
        private System.Windows.Forms.ComboBox cbbpGrupo;
        private System.Windows.Forms.Panel pEnabled;
    }
}