namespace Seven_Sistema
{
    partial class FrmCadUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadUsuario));
            this.ttpUsuario = new System.Windows.Forms.ToolTip(this.components);
            this.btnFuncoes = new System.Windows.Forms.Button();
            this.btnProcurarFuncionario = new System.Windows.Forms.Button();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.cbbFuncionario = new System.Windows.Forms.ComboBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome_usuario = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblNome_usuario = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnFuncionario = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNomeUsuario = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.cbbpFuncionario = new System.Windows.Forms.ComboBox();
            this.txtpNomeUsuario = new System.Windows.Forms.TextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.dtUsuario = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.grbBox2.SuspendLayout();
            this.grbBox3.SuspendLayout();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpUsuario
            // 
            this.ttpUsuario.AutoPopDelay = 5000;
            this.ttpUsuario.InitialDelay = 1000;
            this.ttpUsuario.IsBalloon = true;
            this.ttpUsuario.ReshowDelay = 100;
            this.ttpUsuario.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpUsuario.ToolTipTitle = "Dica:";
            // 
            // btnFuncoes
            // 
            this.btnFuncoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncoes.Image = ((System.Drawing.Image)(resources.GetObject("btnFuncoes.Image")));
            this.btnFuncoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFuncoes.Location = new System.Drawing.Point(371, 49);
            this.btnFuncoes.Name = "btnFuncoes";
            this.btnFuncoes.Size = new System.Drawing.Size(128, 25);
            this.btnFuncoes.TabIndex = 20;
            this.btnFuncoes.Text = "&Funções do Usuário";
            this.btnFuncoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnFuncoes, "Clique para verificar as funções deste usuário.");
            this.btnFuncoes.UseVisualStyleBackColor = true;
            this.btnFuncoes.Click += new System.EventHandler(this.btnFuncoes_Click);
            this.btnFuncoes.MouseLeave += new System.EventHandler(this.btnFuncoes_MouseLeave);
            this.btnFuncoes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFuncoes_MouseMove);
            // 
            // btnProcurarFuncionario
            // 
            this.btnProcurarFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarFuncionario.Image")));
            this.btnProcurarFuncionario.Location = new System.Drawing.Point(311, 14);
            this.btnProcurarFuncionario.Name = "btnProcurarFuncionario";
            this.btnProcurarFuncionario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarFuncionario.TabIndex = 19;
            this.btnProcurarFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnProcurarFuncionario, "Clique para pesquisar um funcionário.");
            this.btnProcurarFuncionario.UseVisualStyleBackColor = true;
            this.btnProcurarFuncionario.Click += new System.EventHandler(this.btnProcurarFuncionario_Click);
            this.btnProcurarFuncionario.MouseLeave += new System.EventHandler(this.btnProcurarFuncionario_MouseLeave);
            this.btnProcurarFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarFuncionario_MouseMove);
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(489, 15);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 7;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnpProcurar, "Clique para pesquisar um funcionário.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Visible = false;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(433, 45);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
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
            this.btnSair.Location = new System.Drawing.Point(490, 440);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 26;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnSair, "Sair do cadastro de Usuários.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(302, 440);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(393, 440);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 25;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnSalvar, "Salvar dados informados.");
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
            this.btnExcluir.Location = new System.Drawing.Point(201, 440);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 23;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnExcluir, "Excluir um Usuário cadastrado.");
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
            this.btnAlterar.Location = new System.Drawing.Point(125, 440);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 22;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnAlterar, "Alterar um Usuário cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(49, 440);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 21;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnNovo, "Cadastrar um novo Usuário.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // btnVer
            // 
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.Location = new System.Drawing.Point(326, 30);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(26, 25);
            this.btnVer.TabIndex = 16;
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnVer, "Clique para mostrar/esconder a senha.");
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            this.btnVer.MouseLeave += new System.EventHandler(this.btnVer_MouseLeave);
            this.btnVer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVer_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnVer);
            this.grbBox2.Controls.Add(this.grbBox3);
            this.grbBox2.Controls.Add(this.btnFuncoes);
            this.grbBox2.Controls.Add(this.lblAsterisco1);
            this.grbBox2.Controls.Add(this.lblAsterisco);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Controls.Add(this.txtNome_usuario);
            this.grbBox2.Controls.Add(this.lblSenha);
            this.grbBox2.Controls.Add(this.lblNome_usuario);
            this.grbBox2.Controls.Add(this.txtSenha);
            this.grbBox2.Enabled = false;
            this.grbBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grbBox2.Location = new System.Drawing.Point(24, 329);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(520, 105);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar, excluir e controlar funções de usuário:";
            this.grbBox2.Enter += new System.EventHandler(this.grbBox2_Enter);
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.btnProcurarFuncionario);
            this.grbBox3.Controls.Add(this.cbbFuncionario);
            this.grbBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox3.Location = new System.Drawing.Point(9, 59);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(343, 40);
            this.grbBox3.TabIndex = 17;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Funcionário:";
            // 
            // cbbFuncionario
            // 
            this.cbbFuncionario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFuncionario.DropDownWidth = 500;
            this.cbbFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFuncionario.FormattingEnabled = true;
            this.cbbFuncionario.Location = new System.Drawing.Point(6, 16);
            this.cbbFuncionario.Name = "cbbFuncionario";
            this.cbbFuncionario.Size = new System.Drawing.Size(299, 21);
            this.cbbFuncionario.TabIndex = 18;
            this.cbbFuncionario.DropDown += new System.EventHandler(this.cbbFuncionario_DropDown);
            this.cbbFuncionario.DropDownClosed += new System.EventHandler(this.cbbFuncionario_DropDownClosed);
            this.cbbFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFuncionario_KeyPress);
            this.cbbFuncionario.MouseLeave += new System.EventHandler(this.cbbFuncionario_MouseLeave);
            this.cbbFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFuncionario_MouseMove);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(90, 16);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(226, 16);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco.TabIndex = 0;
            this.lblAsterisco.Text = "*";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Blue;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(9, 33);
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtCodigo.TabIndex = 13;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtNome_usuario
            // 
            this.txtNome_usuario.BackColor = System.Drawing.Color.White;
            this.txtNome_usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome_usuario.Location = new System.Drawing.Point(60, 33);
            this.txtNome_usuario.MaxLength = 10;
            this.txtNome_usuario.Name = "txtNome_usuario";
            this.txtNome_usuario.Size = new System.Drawing.Size(127, 20);
            this.txtNome_usuario.TabIndex = 14;
            this.txtNome_usuario.Enter += new System.EventHandler(this.txtNome_usuario_Enter);
            this.txtNome_usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_usuario_KeyPress);
            this.txtNome_usuario.Leave += new System.EventHandler(this.txtNome_usuario_Leave);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(190, 16);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 0;
            this.lblSenha.Text = "Senha:";
            // 
            // lblNome_usuario
            // 
            this.lblNome_usuario.AutoSize = true;
            this.lblNome_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome_usuario.Location = new System.Drawing.Point(57, 16);
            this.lblNome_usuario.Name = "lblNome_usuario";
            this.lblNome_usuario.Size = new System.Drawing.Size(38, 13);
            this.lblNome_usuario.TabIndex = 0;
            this.lblNome_usuario.Text = "Nome:";
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(193, 33);
            this.txtSenha.MaxLength = 10;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '●';
            this.txtSenha.Size = new System.Drawing.Size(127, 20);
            this.txtSenha.TabIndex = 15;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnFuncionario);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnNomeUsuario);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.cbbpFuncionario);
            this.grbBox1.Controls.Add(this.txtpNomeUsuario);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox1.Location = new System.Drawing.Point(24, 49);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(521, 80);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(91, 42);
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
            // rbtnFuncionario
            // 
            this.rbtnFuncionario.AutoSize = true;
            this.rbtnFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnFuncionario.Location = new System.Drawing.Point(6, 42);
            this.rbtnFuncionario.Name = "rbtnFuncionario";
            this.rbtnFuncionario.Size = new System.Drawing.Size(80, 17);
            this.rbtnFuncionario.TabIndex = 4;
            this.rbtnFuncionario.TabStop = true;
            this.rbtnFuncionario.Text = "Funcionário";
            this.rbtnFuncionario.UseVisualStyleBackColor = true;
            this.rbtnFuncionario.CheckedChanged += new System.EventHandler(this.rbtnFuncionario_CheckedChanged);
            this.rbtnFuncionario.MouseLeave += new System.EventHandler(this.rbtnFuncionario_MouseLeave);
            this.rbtnFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnFuncionario_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(407, 45);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(91, 19);
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
            // rbtnNomeUsuario
            // 
            this.rbtnNomeUsuario.AutoSize = true;
            this.rbtnNomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNomeUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNomeUsuario.Location = new System.Drawing.Point(6, 19);
            this.rbtnNomeUsuario.Name = "rbtnNomeUsuario";
            this.rbtnNomeUsuario.Size = new System.Drawing.Size(53, 17);
            this.rbtnNomeUsuario.TabIndex = 2;
            this.rbtnNomeUsuario.Text = "Nome";
            this.rbtnNomeUsuario.UseVisualStyleBackColor = true;
            this.rbtnNomeUsuario.CheckedChanged += new System.EventHandler(this.rbtnNomeUsuario_CheckedChanged);
            this.rbtnNomeUsuario.MouseLeave += new System.EventHandler(this.rbtnNomeUsuario_MouseLeave);
            this.rbtnNomeUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNomeUsuario_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(319, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(89, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome:";
            // 
            // cbbpFuncionario
            // 
            this.cbbpFuncionario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpFuncionario.DropDownWidth = 500;
            this.cbbpFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpFuncionario.FormattingEnabled = true;
            this.cbbpFuncionario.Location = new System.Drawing.Point(295, 18);
            this.cbbpFuncionario.Name = "cbbpFuncionario";
            this.cbbpFuncionario.Size = new System.Drawing.Size(188, 21);
            this.cbbpFuncionario.TabIndex = 6;
            this.cbbpFuncionario.Visible = false;
            this.cbbpFuncionario.DropDown += new System.EventHandler(this.cbbpGrupo_DropDown);
            this.cbbpFuncionario.DropDownClosed += new System.EventHandler(this.cbbpGrupo_DropDownClosed);
            this.cbbpFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpFuncionario_KeyPress);
            this.cbbpFuncionario.MouseLeave += new System.EventHandler(this.cbbpGrupo_MouseLeave);
            this.cbbpFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpGrupo_MouseMove);
            // 
            // txtpNomeUsuario
            // 
            this.txtpNomeUsuario.BackColor = System.Drawing.Color.White;
            this.txtpNomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNomeUsuario.Location = new System.Drawing.Point(414, 18);
            this.txtpNomeUsuario.MaxLength = 10;
            this.txtpNomeUsuario.Name = "txtpNomeUsuario";
            this.txtpNomeUsuario.Size = new System.Drawing.Size(101, 20);
            this.txtpNomeUsuario.TabIndex = 8;
            this.txtpNomeUsuario.Enter += new System.EventHandler(this.txtpNomeUsuario_Enter);
            this.txtpNomeUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNomeUsuario_KeyPress);
            this.txtpNomeUsuario.Leave += new System.EventHandler(this.txtpNomeUsuario_Leave);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(470, 18);
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
            // dtUsuario
            // 
            this.dtUsuario.AllowUserToAddRows = false;
            this.dtUsuario.AllowUserToDeleteRows = false;
            this.dtUsuario.AllowUserToResizeRows = false;
            this.dtUsuario.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtUsuario.Enabled = false;
            this.dtUsuario.Location = new System.Drawing.Point(24, 135);
            this.dtUsuario.MultiSelect = false;
            this.dtUsuario.Name = "dtUsuario";
            this.dtUsuario.ReadOnly = true;
            this.dtUsuario.RowHeadersVisible = false;
            this.dtUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtUsuario.ShowCellErrors = false;
            this.dtUsuario.ShowCellToolTips = false;
            this.dtUsuario.ShowEditingIcon = false;
            this.dtUsuario.ShowRowErrors = false;
            this.dtUsuario.Size = new System.Drawing.Size(521, 172);
            this.dtUsuario.TabIndex = 11;
            this.dtUsuario.DataSourceChanged += new System.EventHandler(this.dtUsuario_DataSourceChanged);
            this.dtUsuario.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtUsuario_CellEnter);
            this.dtUsuario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtUsuario_CellFormatting);
            this.dtUsuario.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtUsuario_RowsAdded);
            this.dtUsuario.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtUsuario_RowsRemoved);
            this.dtUsuario.MouseLeave += new System.EventHandler(this.dtUsuario_MouseLeave);
            this.dtUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtUsuario_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(385, 310);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 16);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 156;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.pictureBox1);
            this.pEnabled.Controls.Add(this.btnCancelar);
            this.pEnabled.Controls.Add(this.btnNovo);
            this.pEnabled.Controls.Add(this.btnAlterar);
            this.pEnabled.Controls.Add(this.btnExcluir);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.btnSalvar);
            this.pEnabled.Controls.Add(this.dtUsuario);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Location = new System.Drawing.Point(-12, -37);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(570, 640);
            this.pEnabled.TabIndex = 157;
            this.pEnabled.Paint += new System.Windows.Forms.PaintEventHandler(this.pEnabled_Paint);
            // 
            // FrmCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(546, 441);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadUsuario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadUsuario_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadUsuario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadUsuario_KeyUp);
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpUsuario;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome_usuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblNome_usuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblAsterisco;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnProcurarFuncionario;
        private System.Windows.Forms.ComboBox cbbFuncionario;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnNomeUsuario;
        private System.Windows.Forms.ComboBox cbbpFuncionario;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.Button btnFuncoes;
        private System.Windows.Forms.DataGridView dtUsuario;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnFuncionario;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.TextBox txtpNomeUsuario;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Panel pEnabled;
    }
}