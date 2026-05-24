namespace _7_Sistema_Config
{
    partial class FrmCadastroComputadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroComputadores));
            this.lblConexoes = new System.Windows.Forms.Label();
            this.dtComputadores = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.chkbPDV = new System.Windows.Forms.CheckBox();
            this.chkbADM = new System.Windows.Forms.CheckBox();
            this.btnInserirNomeComputador = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNomeServIP = new System.Windows.Forms.Label();
            this.txtNomeComputador = new System.Windows.Forms.TextBox();
            this.lblTipoConexao = new System.Windows.Forms.Label();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.ttpCadComputadores = new System.Windows.Forms.ToolTip(this.components);
            this.btnLimparRegistroAtividades = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtComputadores)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConexoes
            // 
            this.lblConexoes.AutoSize = true;
            this.lblConexoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexoes.Location = new System.Drawing.Point(12, 9);
            this.lblConexoes.Name = "lblConexoes";
            this.lblConexoes.Size = new System.Drawing.Size(91, 13);
            this.lblConexoes.TabIndex = 2;
            this.lblConexoes.Text = "Computadores:";
            // 
            // dtComputadores
            // 
            this.dtComputadores.AllowUserToAddRows = false;
            this.dtComputadores.AllowUserToDeleteRows = false;
            this.dtComputadores.AllowUserToResizeRows = false;
            this.dtComputadores.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtComputadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtComputadores.Location = new System.Drawing.Point(12, 25);
            this.dtComputadores.MultiSelect = false;
            this.dtComputadores.Name = "dtComputadores";
            this.dtComputadores.ReadOnly = true;
            this.dtComputadores.RowHeadersVisible = false;
            this.dtComputadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtComputadores.ShowCellErrors = false;
            this.dtComputadores.ShowCellToolTips = false;
            this.dtComputadores.ShowEditingIcon = false;
            this.dtComputadores.ShowRowErrors = false;
            this.dtComputadores.Size = new System.Drawing.Size(740, 128);
            this.dtComputadores.TabIndex = 1;
            this.dtComputadores.DataSourceChanged += new System.EventHandler(this.dtComputadores_DataSourceChanged);
            this.dtComputadores.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtComputadores_CellEnter);
            this.dtComputadores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtComputadores_CellFormatting);
            this.dtComputadores.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtComputadores_RowsAdded);
            this.dtComputadores.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtComputadores_RowsRemoved);
            this.dtComputadores.MouseLeave += new System.EventHandler(this.dtComputadores_MouseLeave);
            this.dtComputadores.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtComputadores_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 156);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 4;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.chkbPDV);
            this.grbBox1.Controls.Add(this.chkbADM);
            this.grbBox1.Controls.Add(this.btnInserirNomeComputador);
            this.grbBox1.Controls.Add(this.btnVer);
            this.grbBox1.Controls.Add(this.lblAsterisco3);
            this.grbBox1.Controls.Add(this.lblAsterisco);
            this.grbBox1.Controls.Add(this.lblSenha);
            this.grbBox1.Controls.Add(this.txtSenha);
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.lblNomeServIP);
            this.grbBox1.Controls.Add(this.txtNomeComputador);
            this.grbBox1.Controls.Add(this.lblTipoConexao);
            this.grbBox1.Controls.Add(this.cbbTipo);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(12, 185);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(740, 86);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Cadastrar, alterar e excluir:";
            // 
            // chkbPDV
            // 
            this.chkbPDV.AutoSize = true;
            this.chkbPDV.Location = new System.Drawing.Point(201, 63);
            this.chkbPDV.Name = "chkbPDV";
            this.chkbPDV.Size = new System.Drawing.Size(182, 17);
            this.chkbPDV.TabIndex = 10;
            this.chkbPDV.Text = "Destravar Sistema SEVEN - PDV";
            this.chkbPDV.UseVisualStyleBackColor = true;
            this.chkbPDV.MouseLeave += new System.EventHandler(this.chkbPDV_MouseLeave);
            this.chkbPDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbPDV_MouseMove);
            // 
            // chkbADM
            // 
            this.chkbADM.AutoSize = true;
            this.chkbADM.Location = new System.Drawing.Point(6, 63);
            this.chkbADM.Name = "chkbADM";
            this.chkbADM.Size = new System.Drawing.Size(184, 17);
            this.chkbADM.TabIndex = 9;
            this.chkbADM.Text = "Destravar Sistema SEVEN - ADM";
            this.chkbADM.UseVisualStyleBackColor = true;
            this.chkbADM.MouseLeave += new System.EventHandler(this.chkbADM_MouseLeave);
            this.chkbADM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbADM_MouseMove);
            // 
            // btnInserirNomeComputador
            // 
            this.btnInserirNomeComputador.Image = ((System.Drawing.Image)(resources.GetObject("btnInserirNomeComputador.Image")));
            this.btnInserirNomeComputador.Location = new System.Drawing.Point(555, 34);
            this.btnInserirNomeComputador.Name = "btnInserirNomeComputador";
            this.btnInserirNomeComputador.Size = new System.Drawing.Size(26, 25);
            this.btnInserirNomeComputador.TabIndex = 6;
            this.btnInserirNomeComputador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnInserirNomeComputador, "Clique para inserir o nome do computador atual.");
            this.btnInserirNomeComputador.UseVisualStyleBackColor = true;
            this.btnInserirNomeComputador.Click += new System.EventHandler(this.button1_Click);
            this.btnInserirNomeComputador.MouseLeave += new System.EventHandler(this.btnInserirNomeComputador_MouseLeave);
            this.btnInserirNomeComputador.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnInserirNomeComputador_MouseMove);
            // 
            // btnVer
            // 
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.Location = new System.Drawing.Point(705, 34);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(26, 25);
            this.btnVer.TabIndex = 8;
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnVer, "Clique para mostrar/esconder a senha.");
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            this.btnVer.MouseLeave += new System.EventHandler(this.btnVer_MouseLeave);
            this.btnVer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVer_MouseMove);
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(290, 21);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco3.TabIndex = 11;
            this.lblAsterisco3.Text = "*";
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(694, 21);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco.TabIndex = 0;
            this.lblAsterisco.Text = "*";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(584, 21);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(115, 13);
            this.lblSenha.TabIndex = 0;
            this.lblSenha.Text = "Senha de Autorização:";
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(587, 37);
            this.txtSenha.MaxLength = 10;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '●';
            this.txtSenha.Size = new System.Drawing.Size(112, 20);
            this.txtSenha.TabIndex = 7;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(5, 37);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(2, 21);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNomeServIP
            // 
            this.lblNomeServIP.AutoSize = true;
            this.lblNomeServIP.Location = new System.Drawing.Point(182, 21);
            this.lblNomeServIP.Name = "lblNomeServIP";
            this.lblNomeServIP.Size = new System.Drawing.Size(113, 13);
            this.lblNomeServIP.TabIndex = 0;
            this.lblNomeServIP.Text = "Nome do Computador:";
            // 
            // txtNomeComputador
            // 
            this.txtNomeComputador.BackColor = System.Drawing.Color.White;
            this.txtNomeComputador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeComputador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeComputador.Location = new System.Drawing.Point(185, 37);
            this.txtNomeComputador.MaxLength = 60;
            this.txtNomeComputador.Name = "txtNomeComputador";
            this.txtNomeComputador.Size = new System.Drawing.Size(364, 20);
            this.txtNomeComputador.TabIndex = 5;
            this.txtNomeComputador.Enter += new System.EventHandler(this.txtNomeComputador_Enter);
            this.txtNomeComputador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeComputador_KeyPress);
            this.txtNomeComputador.Leave += new System.EventHandler(this.txtNomeComputador_Leave);
            // 
            // lblTipoConexao
            // 
            this.lblTipoConexao.AutoSize = true;
            this.lblTipoConexao.Location = new System.Drawing.Point(51, 21);
            this.lblTipoConexao.Name = "lblTipoConexao";
            this.lblTipoConexao.Size = new System.Drawing.Size(31, 13);
            this.lblTipoConexao.TabIndex = 0;
            this.lblTipoConexao.Text = "Tipo:";
            // 
            // cbbTipo
            // 
            this.cbbTipo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipo.DropDownHeight = 250;
            this.cbbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipo.Enabled = false;
            this.cbbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.IntegralHeight = false;
            this.cbbTipo.Items.AddRange(new object[] {
            "SERVIDOR",
            "TERMINAL"});
            this.cbbTipo.Location = new System.Drawing.Point(54, 37);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(125, 21);
            this.cbbTipo.TabIndex = 4;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(697, 277);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 16;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnSair, "Sair do Cadastro de Computadores.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(409, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(500, 277);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnSalvar, "Salvar dados informados.");
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
            this.btnExcluir.Location = new System.Drawing.Point(190, 277);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnExcluir, "Excluir um Computador cadastrado.");
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
            this.btnAlterar.Location = new System.Drawing.Point(114, 277);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 12;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnAlterar, "Alterar um Computador cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(38, 277);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 11;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnNovo, "Cadastrar um novo Computador.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.Location = new System.Drawing.Point(12, 277);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 91;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // ttpCadComputadores
            // 
            this.ttpCadComputadores.AutoPopDelay = 5000;
            this.ttpCadComputadores.InitialDelay = 1000;
            this.ttpCadComputadores.IsBalloon = true;
            this.ttpCadComputadores.ReshowDelay = 100;
            this.ttpCadComputadores.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCadComputadores.ToolTipTitle = "Dica:";
            // 
            // btnLimparRegistroAtividades
            // 
            this.btnLimparRegistroAtividades.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparRegistroAtividades.Image")));
            this.btnLimparRegistroAtividades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparRegistroAtividades.Location = new System.Drawing.Point(178, 157);
            this.btnLimparRegistroAtividades.Name = "btnLimparRegistroAtividades";
            this.btnLimparRegistroAtividades.Size = new System.Drawing.Size(175, 25);
            this.btnLimparRegistroAtividades.TabIndex = 12;
            this.btnLimparRegistroAtividades.Text = "Limpar Registro de Atividades";
            this.btnLimparRegistroAtividades.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnLimparRegistroAtividades, "Clique para inserir o nome do computador atual.");
            this.btnLimparRegistroAtividades.UseVisualStyleBackColor = true;
            this.btnLimparRegistroAtividades.Click += new System.EventHandler(this.btnLimparRegistroAtividades_Click);
            this.btnLimparRegistroAtividades.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.btnLimparRegistroAtividades.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // FrmCadastroComputadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(764, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btnLimparRegistroAtividades);
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblConexoes);
            this.Controls.Add(this.dtComputadores);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadastroComputadores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Computadores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadastroComputadores_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadastroComputadores_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadastroComputadores_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtComputadores)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConexoes;
        private System.Windows.Forms.DataGridView dtComputadores;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblAsterisco;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNomeServIP;
        private System.Windows.Forms.TextBox txtNomeComputador;
        private System.Windows.Forms.Label lblTipoConexao;
        private System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnInserirNomeComputador;
        private System.Windows.Forms.ToolTip ttpCadComputadores;
        private System.Windows.Forms.CheckBox chkbPDV;
        private System.Windows.Forms.CheckBox chkbADM;
        private System.Windows.Forms.Button btnLimparRegistroAtividades;
    }
}