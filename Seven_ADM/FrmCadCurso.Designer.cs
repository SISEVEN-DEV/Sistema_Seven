namespace SIE_7_Sistema
{
    partial class FrmCadCurso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadCurso));
            this.dtCurso = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnSigla = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.lblSigla = new System.Windows.Forms.Label();
            this.txtSigla = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.rtxtObs = new System.Windows.Forms.RichTextBox();
            this.lblPalavraChave = new System.Windows.Forms.Label();
            this.txtPalavraChave = new System.Windows.Forms.TextBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpCurso = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdicionarDisciplina = new System.Windows.Forms.Button();
            this.btnAdicionarProfessor = new System.Windows.Forms.Button();
            this.txtValorCurso = new System.Windows.Forms.TextBox();
            this.lblValorCurso = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtCurso)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtCurso
            // 
            this.dtCurso.AllowUserToAddRows = false;
            this.dtCurso.AllowUserToDeleteRows = false;
            this.dtCurso.AllowUserToResizeRows = false;
            this.dtCurso.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCurso.Location = new System.Drawing.Point(12, 98);
            this.dtCurso.MultiSelect = false;
            this.dtCurso.Name = "dtCurso";
            this.dtCurso.ReadOnly = true;
            this.dtCurso.RowHeadersVisible = false;
            this.dtCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCurso.ShowCellErrors = false;
            this.dtCurso.ShowCellToolTips = false;
            this.dtCurso.ShowEditingIcon = false;
            this.dtCurso.ShowRowErrors = false;
            this.dtCurso.Size = new System.Drawing.Size(639, 128);
            this.dtCurso.TabIndex = 9;
            this.dtCurso.DataSourceChanged += new System.EventHandler(this.dtCurso_DataSourceChanged);
            this.dtCurso.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCurso_CellEnter);
            this.dtCurso.MouseLeave += new System.EventHandler(this.dtCurso_MouseLeave);
            this.dtCurso.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtCurso_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnSigla);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.pcibInterrogacao);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(639, 80);
            this.grbBox1.TabIndex = 136;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnSigla
            // 
            this.rbtnSigla.AutoSize = true;
            this.rbtnSigla.Location = new System.Drawing.Point(106, 42);
            this.rbtnSigla.Name = "rbtnSigla";
            this.rbtnSigla.Size = new System.Drawing.Size(48, 17);
            this.rbtnSigla.TabIndex = 4;
            this.rbtnSigla.Text = "Sigla";
            this.rbtnSigla.UseVisualStyleBackColor = true;
            this.rbtnSigla.CheckedChanged += new System.EventHandler(this.rbtnSigla_CheckedChanged);
            this.rbtnSigla.MouseLeave += new System.EventHandler(this.rbtnSigla_MouseLeave);
            this.rbtnSigla.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnSigla_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(586, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtpCodigo.TabIndex = 7;
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
            this.txtpPalavraChave.Location = new System.Drawing.Point(543, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(88, 20);
            this.txtpPalavraChave.TabIndex = 6;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(160, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(6, 42);
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
            this.pcibInterrogacao.Location = new System.Drawing.Point(520, 44);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 136;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.pcibInterrogacao_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(546, 44);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 8;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCurso.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
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
            this.lblPesquisar.Location = new System.Drawing.Point(182, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 70;
            this.lblPesquisar.Text = "Digite a descrição:";
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
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpDescricao.Location = new System.Drawing.Point(302, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(329, 20);
            this.txtpDescricao.TabIndex = 5;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 238);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 140;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.lblValorCurso);
            this.grbBox2.Controls.Add(this.txtValorCurso);
            this.grbBox2.Controls.Add(this.lblSigla);
            this.grbBox2.Controls.Add(this.txtSigla);
            this.grbBox2.Controls.Add(this.lblObservacao);
            this.grbBox2.Controls.Add(this.rtxtObs);
            this.grbBox2.Controls.Add(this.lblPalavraChave);
            this.grbBox2.Controls.Add(this.txtPalavraChave);
            this.grbBox2.Controls.Add(this.lblAsterisco1);
            this.grbBox2.Controls.Add(this.lblDescricao);
            this.grbBox2.Controls.Add(this.txtDescricao);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(12, 258);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(639, 117);
            this.grbBox2.TabIndex = 10;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(388, 16);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(33, 13);
            this.lblSigla.TabIndex = 25;
            this.lblSigla.Text = "Sigla:";
            // 
            // txtSigla
            // 
            this.txtSigla.BackColor = System.Drawing.Color.White;
            this.txtSigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSigla.Location = new System.Drawing.Point(391, 32);
            this.txtSigla.MaxLength = 10;
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSigla.Size = new System.Drawing.Size(55, 20);
            this.txtSigla.TabIndex = 14;
            this.txtSigla.Enter += new System.EventHandler(this.txtSigla_Enter);
            this.txtSigla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSigla_KeyPress);
            this.txtSigla.Leave += new System.EventHandler(this.txtSigla_Leave);
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(6, 55);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(73, 13);
            this.lblObservacao.TabIndex = 23;
            this.lblObservacao.Text = "Observações:";
            // 
            // rtxtObs
            // 
            this.rtxtObs.BackColor = System.Drawing.Color.White;
            this.rtxtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtObs.Location = new System.Drawing.Point(6, 71);
            this.rtxtObs.MaxLength = 200;
            this.rtxtObs.Name = "rtxtObs";
            this.rtxtObs.Size = new System.Drawing.Size(627, 36);
            this.rtxtObs.TabIndex = 15;
            this.rtxtObs.Text = "";
            this.rtxtObs.Enter += new System.EventHandler(this.rtxtObs_Enter);
            this.rtxtObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtObs_KeyPress);
            this.rtxtObs.Leave += new System.EventHandler(this.rtxtObs_Leave);
            // 
            // lblPalavraChave
            // 
            this.lblPalavraChave.AutoSize = true;
            this.lblPalavraChave.Location = new System.Drawing.Point(54, 16);
            this.lblPalavraChave.Name = "lblPalavraChave";
            this.lblPalavraChave.Size = new System.Drawing.Size(79, 13);
            this.lblPalavraChave.TabIndex = 19;
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
            this.txtPalavraChave.TabIndex = 12;
            this.txtPalavraChave.Enter += new System.EventHandler(this.txtPalavraChave_Enter);
            this.txtPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalavraChave_KeyPress);
            this.txtPalavraChave.Leave += new System.EventHandler(this.txtPalavraChave_Leave);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(195, 16);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco1.TabIndex = 17;
            this.lblAsterisco1.Text = "*";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(142, 16);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 16;
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
            this.txtDescricao.Size = new System.Drawing.Size(240, 20);
            this.txtDescricao.TabIndex = 13;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 14;
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
            this.txtCodigo.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(282, 381);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCurso.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(373, 381);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 20;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCurso.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.Location = new System.Drawing.Point(12, 381);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 149;
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
            this.btnExcluir.Location = new System.Drawing.Point(190, 381);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 18;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCurso.SetToolTip(this.btnExcluir, "Excluir um curso cadastrado.");
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
            this.btnAlterar.Location = new System.Drawing.Point(114, 381);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 17;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCurso.SetToolTip(this.btnAlterar, "Alterar um curso cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(38, 381);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 16;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCurso.SetToolTip(this.btnNovo, "Cadastrar um novo curso.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(459, 381);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 21;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCurso.SetToolTip(this.btnSair, "Sair do cadastro de curso.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // ttpCurso
            // 
            this.ttpCurso.AutoPopDelay = 5000;
            this.ttpCurso.InitialDelay = 1000;
            this.ttpCurso.IsBalloon = true;
            this.ttpCurso.ReshowDelay = 100;
            this.ttpCurso.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCurso.ToolTipTitle = "Dica:";
            // 
            // btnAdicionarDisciplina
            // 
            this.btnAdicionarDisciplina.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarDisciplina.Image")));
            this.btnAdicionarDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarDisciplina.Location = new System.Drawing.Point(382, 419);
            this.btnAdicionarDisciplina.Name = "btnAdicionarDisciplina";
            this.btnAdicionarDisciplina.Size = new System.Drawing.Size(132, 25);
            this.btnAdicionarDisciplina.TabIndex = 40;
            this.btnAdicionarDisciplina.Text = "Adiconar &Disciplinas";
            this.btnAdicionarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionarDisciplina.UseVisualStyleBackColor = true;
            this.btnAdicionarDisciplina.Click += new System.EventHandler(this.btnAdicionarDisciplina_Click);
            this.btnAdicionarDisciplina.MouseLeave += new System.EventHandler(this.btnAdicionarDisciplina_MouseLeave);
            this.btnAdicionarDisciplina.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAdicionarDisciplina_MouseMove);
            // 
            // btnAdicionarProfessor
            // 
            this.btnAdicionarProfessor.Enabled = false;
            this.btnAdicionarProfessor.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarProfessor.Image")));
            this.btnAdicionarProfessor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarProfessor.Location = new System.Drawing.Point(520, 419);
            this.btnAdicionarProfessor.Name = "btnAdicionarProfessor";
            this.btnAdicionarProfessor.Size = new System.Drawing.Size(132, 25);
            this.btnAdicionarProfessor.TabIndex = 41;
            this.btnAdicionarProfessor.Text = "&Adicionar &Professores";
            this.btnAdicionarProfessor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionarProfessor.UseVisualStyleBackColor = true;
            this.btnAdicionarProfessor.Click += new System.EventHandler(this.btnAdicionarProfessor_Click);
            this.btnAdicionarProfessor.MouseLeave += new System.EventHandler(this.btnAdicionarProfessor_MouseLeave);
            this.btnAdicionarProfessor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAdicionarProfessor_MouseMove);
            // 
            // txtValorCurso
            // 
            this.txtValorCurso.BackColor = System.Drawing.Color.White;
            this.txtValorCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCurso.Location = new System.Drawing.Point(452, 32);
            this.txtValorCurso.MaxLength = 15;
            this.txtValorCurso.Name = "txtValorCurso";
            this.txtValorCurso.Size = new System.Drawing.Size(98, 20);
            this.txtValorCurso.TabIndex = 45;
            this.txtValorCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorCurso.Enter += new System.EventHandler(this.txtValorCurso_Enter);
            this.txtValorCurso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorCurso_KeyPress);
            this.txtValorCurso.Leave += new System.EventHandler(this.txtValorCurso_Leave);
            // 
            // lblValorCurso
            // 
            this.lblValorCurso.AutoSize = true;
            this.lblValorCurso.Location = new System.Drawing.Point(449, 16);
            this.lblValorCurso.Name = "lblValorCurso";
            this.lblValorCurso.Size = new System.Drawing.Size(101, 13);
            this.lblValorCurso.TabIndex = 46;
            this.lblValorCurso.Text = "Valor do curso (R$):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(545, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "*";
            // 
            // FrmCadCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(665, 443);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnAdicionarProfessor);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnAdicionarDisciplina);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtCurso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Curso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadCurso_FormClosing);
            this.Load += new System.EventHandler(this.FrmMatriculaTurmaAluno_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadCurso_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtCurso)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtCurso;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblPalavraChave;
        private System.Windows.Forms.TextBox txtPalavraChave;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.RichTextBox rtxtObs;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.RadioButton rbtnSigla;
        private System.Windows.Forms.ToolTip ttpCurso;
        private System.Windows.Forms.Button btnAdicionarDisciplina;
        private System.Windows.Forms.Button btnAdicionarProfessor;
        private System.Windows.Forms.TextBox txtValorCurso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValorCurso;
    }
}