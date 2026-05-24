namespace SIE_7_Sistema
{
    partial class FrmCadDisciplina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadDisciplina));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTipoDisciplina = new System.Windows.Forms.RadioButton();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.cbbpTipoDisciplina = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.dtDisciplina = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lblTipoDisciplina = new System.Windows.Forms.Label();
            this.cbbTipoDisciplina = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCargaHoraria = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.rtxtObs = new System.Windows.Forms.RichTextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblPalavraChave = new System.Windows.Forms.Label();
            this.txtPalavraChave = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.ttpDisciplina = new System.Windows.Forms.ToolTip(this.components);
            this.mtxtCargaHoraria = new System.Windows.Forms.MaskedTextBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDisciplina)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTipoDisciplina);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.pcibInterrogacao);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.cbbpTipoDisciplina);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(719, 79);
            this.grbBox1.TabIndex = 0;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTipoDisciplina
            // 
            this.rbtnTipoDisciplina.AutoSize = true;
            this.rbtnTipoDisciplina.Location = new System.Drawing.Point(6, 42);
            this.rbtnTipoDisciplina.Name = "rbtnTipoDisciplina";
            this.rbtnTipoDisciplina.Size = new System.Drawing.Size(109, 17);
            this.rbtnTipoDisciplina.TabIndex = 4;
            this.rbtnTipoDisciplina.Text = "Tipo de Disciplina";
            this.rbtnTipoDisciplina.UseVisualStyleBackColor = true;
            this.rbtnTipoDisciplina.CheckedChanged += new System.EventHandler(this.rbtnTipoDisciplina_CheckedChanged);
            this.rbtnTipoDisciplina.MouseLeave += new System.EventHandler(this.rbtnTipoDisciplina_MouseLeave);
            this.rbtnTipoDisciplina.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTipoDisciplina_MouseMove);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(149, 19);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(94, 17);
            this.rbtnPalavraChave.TabIndex = 3;
            this.rbtnPalavraChave.Text = "Palavra-chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(602, 45);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 81;
            this.pcibInterrogacao.TabStop = false;
            this.ttpDisciplina.SetToolTip(this.pcibInterrogacao, "Informações úteis.");
            this.pcibInterrogacao.Click += new System.EventHandler(this.pcibInterrogacao_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(121, 42);
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
            this.rbtnCodigo.Location = new System.Drawing.Point(85, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(628, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDisciplina.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnDescricao
            // 
            this.rbtnDescricao.AutoSize = true;
            this.rbtnDescricao.Checked = true;
            this.rbtnDescricao.Location = new System.Drawing.Point(6, 19);
            this.rbtnDescricao.Name = "rbtnDescricao";
            this.rbtnDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtnDescricao.TabIndex = 1;
            this.rbtnDescricao.TabStop = true;
            this.rbtnDescricao.Text = "Descrição";
            this.rbtnDescricao.UseVisualStyleBackColor = true;
            this.rbtnDescricao.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnDescricao.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(299, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(668, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(45, 20);
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
            this.txtpPalavraChave.Location = new System.Drawing.Point(621, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(88, 20);
            this.txtpPalavraChave.TabIndex = 8;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // cbbpTipoDisciplina
            // 
            this.cbbpTipoDisciplina.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipoDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipoDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipoDisciplina.FormattingEnabled = true;
            this.cbbpTipoDisciplina.Items.AddRange(new object[] {
            "BASE COMUM",
            "PARTE DIVERSIFICADA"});
            this.cbbpTipoDisciplina.Location = new System.Drawing.Point(525, 18);
            this.cbbpTipoDisciplina.Name = "cbbpTipoDisciplina";
            this.cbbpTipoDisciplina.Size = new System.Drawing.Size(188, 21);
            this.cbbpTipoDisciplina.TabIndex = 7;
            this.cbbpTipoDisciplina.Visible = false;
            this.cbbpTipoDisciplina.DropDown += new System.EventHandler(this.cbbpTipoDisciplina_DropDown);
            this.cbbpTipoDisciplina.DropDownClosed += new System.EventHandler(this.cbbpTipoDisciplina_DropDownClosed);
            this.cbbpTipoDisciplina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipoDisciplina_KeyPress);
            this.cbbpTipoDisciplina.MouseLeave += new System.EventHandler(this.cbbpTipoDisciplina_MouseLeave);
            this.cbbpTipoDisciplina.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTipoDisciplina_MouseMove);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpDescricao.Location = new System.Drawing.Point(420, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(290, 20);
            this.txtpDescricao.TabIndex = 6;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // dtDisciplina
            // 
            this.dtDisciplina.AllowUserToAddRows = false;
            this.dtDisciplina.AllowUserToDeleteRows = false;
            this.dtDisciplina.AllowUserToResizeRows = false;
            this.dtDisciplina.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtDisciplina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDisciplina.Location = new System.Drawing.Point(12, 97);
            this.dtDisciplina.MultiSelect = false;
            this.dtDisciplina.Name = "dtDisciplina";
            this.dtDisciplina.ReadOnly = true;
            this.dtDisciplina.RowHeadersVisible = false;
            this.dtDisciplina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDisciplina.ShowCellErrors = false;
            this.dtDisciplina.ShowCellToolTips = false;
            this.dtDisciplina.ShowEditingIcon = false;
            this.dtDisciplina.ShowRowErrors = false;
            this.dtDisciplina.Size = new System.Drawing.Size(719, 128);
            this.dtDisciplina.TabIndex = 11;
            this.dtDisciplina.DataSourceChanged += new System.EventHandler(this.dtDisciplina_DataSourceChanged);
            this.dtDisciplina.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDisciplina_CellEnter);
            this.dtDisciplina.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtDisciplina_RowsAdded);
            this.dtDisciplina.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtDisciplina_RowsRemoved);
            this.dtDisciplina.MouseLeave += new System.EventHandler(this.dtDisciplina_MouseLeave);
            this.dtDisciplina.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtDisciplina_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 228);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.mtxtCargaHoraria);
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.lblAsterisco2);
            this.grbBox2.Controls.Add(this.lblTipoDisciplina);
            this.grbBox2.Controls.Add(this.cbbTipoDisciplina);
            this.grbBox2.Controls.Add(this.label4);
            this.grbBox2.Controls.Add(this.lblCargaHoraria);
            this.grbBox2.Controls.Add(this.lblAsterisco1);
            this.grbBox2.Controls.Add(this.lblObservacao);
            this.grbBox2.Controls.Add(this.rtxtObs);
            this.grbBox2.Controls.Add(this.lblDescricao);
            this.grbBox2.Controls.Add(this.txtDescricao);
            this.grbBox2.Controls.Add(this.lblPalavraChave);
            this.grbBox2.Controls.Add(this.txtPalavraChave);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grbBox2.Location = new System.Drawing.Point(12, 257);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(719, 117);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(517, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "*";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(620, 15);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco2.TabIndex = 106;
            this.lblAsterisco2.Text = "*";
            // 
            // lblTipoDisciplina
            // 
            this.lblTipoDisciplina.AutoSize = true;
            this.lblTipoDisciplina.Location = new System.Drawing.Point(531, 15);
            this.lblTipoDisciplina.Name = "lblTipoDisciplina";
            this.lblTipoDisciplina.Size = new System.Drawing.Size(94, 13);
            this.lblTipoDisciplina.TabIndex = 105;
            this.lblTipoDisciplina.Text = "Tipo de Disciplina:";
            // 
            // cbbTipoDisciplina
            // 
            this.cbbTipoDisciplina.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoDisciplina.FormattingEnabled = true;
            this.cbbTipoDisciplina.Items.AddRange(new object[] {
            "BASE COMUM",
            "PARTE DIVERSIFICADA"});
            this.cbbTipoDisciplina.Location = new System.Drawing.Point(534, 31);
            this.cbbTipoDisciplina.Name = "cbbTipoDisciplina";
            this.cbbTipoDisciplina.Size = new System.Drawing.Size(179, 21);
            this.cbbTipoDisciplina.TabIndex = 17;
            this.cbbTipoDisciplina.DropDown += new System.EventHandler(this.cbbTipoDisciplina_DropDown);
            this.cbbTipoDisciplina.DropDownClosed += new System.EventHandler(this.cbbTipoDisciplina_DropDownClosed);
            this.cbbTipoDisciplina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipoDisciplina_KeyPress);
            this.cbbTipoDisciplina.MouseLeave += new System.EventHandler(this.cbbTipoDisciplina_MouseLeave);
            this.cbbTipoDisciplina.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoDisciplina_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(470, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 0;
            // 
            // lblCargaHoraria
            // 
            this.lblCargaHoraria.AutoSize = true;
            this.lblCargaHoraria.Location = new System.Drawing.Point(385, 16);
            this.lblCargaHoraria.Name = "lblCargaHoraria";
            this.lblCargaHoraria.Size = new System.Drawing.Size(137, 13);
            this.lblCargaHoraria.TabIndex = 0;
            this.lblCargaHoraria.Text = "Carga horária da Aula (HH):";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(195, 16);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(6, 55);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(73, 13);
            this.lblObservacao.TabIndex = 0;
            this.lblObservacao.Text = "Observações:";
            // 
            // rtxtObs
            // 
            this.rtxtObs.BackColor = System.Drawing.Color.White;
            this.rtxtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtObs.Location = new System.Drawing.Point(6, 71);
            this.rtxtObs.MaxLength = 200;
            this.rtxtObs.Name = "rtxtObs";
            this.rtxtObs.Size = new System.Drawing.Size(707, 36);
            this.rtxtObs.TabIndex = 18;
            this.rtxtObs.Text = "";
            this.rtxtObs.Enter += new System.EventHandler(this.rtxtObs_Enter);
            this.rtxtObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtObs_KeyPress);
            this.rtxtObs.Leave += new System.EventHandler(this.rtxtObs_Leave);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(142, 16);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(145, 32);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescricao.Size = new System.Drawing.Size(235, 20);
            this.txtDescricao.TabIndex = 15;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // lblPalavraChave
            // 
            this.lblPalavraChave.AutoSize = true;
            this.lblPalavraChave.Location = new System.Drawing.Point(54, 16);
            this.lblPalavraChave.Name = "lblPalavraChave";
            this.lblPalavraChave.Size = new System.Drawing.Size(79, 13);
            this.lblPalavraChave.TabIndex = 0;
            this.lblPalavraChave.Text = "Palavra-chave:";
            // 
            // txtPalavraChave
            // 
            this.txtPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalavraChave.Location = new System.Drawing.Point(57, 32);
            this.txtPalavraChave.MaxLength = 10;
            this.txtPalavraChave.Name = "txtPalavraChave";
            this.txtPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPalavraChave.Size = new System.Drawing.Size(82, 20);
            this.txtPalavraChave.TabIndex = 14;
            this.txtPalavraChave.Enter += new System.EventHandler(this.txtPalavraChave_Enter);
            this.txtPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalavraChave_KeyPress);
            this.txtPalavraChave.Leave += new System.EventHandler(this.txtPalavraChave_Leave);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 32);
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtCodigo.TabIndex = 13;
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(676, 380);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 24;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDisciplina.SetToolTip(this.btnSair, "Sair do cadastro de disciplina.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(379, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDisciplina.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(470, 380);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDisciplina.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.Location = new System.Drawing.Point(12, 380);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 94;
            this.picbInterrogacao2.TabStop = false;
            this.ttpDisciplina.SetToolTip(this.picbInterrogacao2, "Informações úteis.");
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.Location = new System.Drawing.Point(190, 380);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDisciplina.SetToolTip(this.btnExcluir, "Excluir uma disciplina cadastrada.");
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
            this.btnAlterar.Location = new System.Drawing.Point(114, 380);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 20;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDisciplina.SetToolTip(this.btnAlterar, "Alterar uma disciplina cadastrada.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(38, 380);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 19;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDisciplina.SetToolTip(this.btnNovo, "Cadastrar uma nova disciplina.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // ttpDisciplina
            // 
            this.ttpDisciplina.AutoPopDelay = 5000;
            this.ttpDisciplina.InitialDelay = 1000;
            this.ttpDisciplina.IsBalloon = true;
            this.ttpDisciplina.ReshowDelay = 100;
            this.ttpDisciplina.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpDisciplina.ToolTipTitle = "Dica:";
            // 
            // mtxtCargaHoraria
            // 
            this.mtxtCargaHoraria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCargaHoraria.Location = new System.Drawing.Point(486, 32);
            this.mtxtCargaHoraria.Mask = "00:00";
            this.mtxtCargaHoraria.Name = "mtxtCargaHoraria";
            this.mtxtCargaHoraria.Size = new System.Drawing.Size(42, 20);
            this.mtxtCargaHoraria.TabIndex = 108;
            this.mtxtCargaHoraria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtCargaHoraria.ValidatingType = typeof(System.DateTime);
            this.mtxtCargaHoraria.Enter += new System.EventHandler(this.mtxtCargaHoraria_Enter);
            this.mtxtCargaHoraria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCargaHoraria_KeyPress);
            this.mtxtCargaHoraria.Leave += new System.EventHandler(this.mtxtCargaHoraria_Leave);
            // 
            // FrmCadDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(743, 424);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dtDisciplina);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadDisciplina";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Disciplina";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadDisciplina_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadDisciplina_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadDisciplina_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDisciplina)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.DataGridView dtDisciplina;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblPalavraChave;
        private System.Windows.Forms.TextBox txtPalavraChave;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.RichTextBox rtxtObs;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.ToolTip ttpDisciplina;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.Label lblCargaHoraria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTipoDisciplina;
        private System.Windows.Forms.ComboBox cbbTipoDisciplina;
        private System.Windows.Forms.ComboBox cbbpTipoDisciplina;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.RadioButton rbtnTipoDisciplina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtCargaHoraria;
    }
}