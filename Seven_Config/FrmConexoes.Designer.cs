namespace _7_Sistema_Config
{
    partial class FrmConexoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConexoes));
            this.lblConexoes = new System.Windows.Forms.Label();
            this.dtConect = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnInserirNomeComputador = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOrdem = new System.Windows.Forms.Label();
            this.txtOrdem = new System.Windows.Forms.TextBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtEntidade = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNomeServIP = new System.Windows.Forms.Label();
            this.btnEscolherLocal = new System.Windows.Forms.Button();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.txtNomeServIP = new System.Windows.Forms.TextBox();
            this.lblTipoConexao = new System.Windows.Forms.Label();
            this.cbbTipoConexao = new System.Windows.Forms.ComboBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.txtCaminhoBanco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.ttpCadComputadores = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtComputadorServidor = new System.Windows.Forms.TextBox();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInserirNomeServidor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtConect)).BeginInit();
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
            this.lblConexoes.Size = new System.Drawing.Size(66, 13);
            this.lblConexoes.TabIndex = 0;
            this.lblConexoes.Text = "Conexões:";
            // 
            // dtConect
            // 
            this.dtConect.AllowUserToAddRows = false;
            this.dtConect.AllowUserToDeleteRows = false;
            this.dtConect.AllowUserToResizeRows = false;
            this.dtConect.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtConect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtConect.Location = new System.Drawing.Point(12, 25);
            this.dtConect.MultiSelect = false;
            this.dtConect.Name = "dtConect";
            this.dtConect.ReadOnly = true;
            this.dtConect.RowHeadersVisible = false;
            this.dtConect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtConect.ShowCellErrors = false;
            this.dtConect.ShowCellToolTips = false;
            this.dtConect.ShowEditingIcon = false;
            this.dtConect.ShowRowErrors = false;
            this.dtConect.Size = new System.Drawing.Size(760, 128);
            this.dtConect.TabIndex = 1;
            this.dtConect.DataSourceChanged += new System.EventHandler(this.dtConect_DataSourceChanged);
            this.dtConect.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtConect_CellEnter);
            this.dtConect.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtConect_CellFormatting);
            this.dtConect.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtConect_RowsAdded);
            this.dtConect.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtConect_RowsRemoved);
            this.dtConect.MouseLeave += new System.EventHandler(this.dtConect_MouseLeave);
            this.dtConect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtConect_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 156);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label6);
            this.grbBox1.Controls.Add(this.btnInserirNomeServidor);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.label5);
            this.grbBox1.Controls.Add(this.txtPorta);
            this.grbBox1.Controls.Add(this.label4);
            this.grbBox1.Controls.Add(this.txtComputadorServidor);
            this.grbBox1.Controls.Add(this.btnInserirNomeComputador);
            this.grbBox1.Controls.Add(this.label3);
            this.grbBox1.Controls.Add(this.lblOrdem);
            this.grbBox1.Controls.Add(this.txtOrdem);
            this.grbBox1.Controls.Add(this.btnVer);
            this.grbBox1.Controls.Add(this.lblAsterisco3);
            this.grbBox1.Controls.Add(this.lblAsterisco);
            this.grbBox1.Controls.Add(this.lblCaminho);
            this.grbBox1.Controls.Add(this.lblSenha);
            this.grbBox1.Controls.Add(this.txtCaminhoBanco);
            this.grbBox1.Controls.Add(this.txtSenha);
            this.grbBox1.Controls.Add(this.btnEscolherLocal);
            this.grbBox1.Controls.Add(this.txtEntidade);
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.lblNomeServIP);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.txtNomeServIP);
            this.grbBox1.Controls.Add(this.lblTipoConexao);
            this.grbBox1.Controls.Add(this.cbbTipoConexao);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(12, 185);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 104);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Cadastrar, alterar e excluir:";
            // 
            // btnInserirNomeComputador
            // 
            this.btnInserirNomeComputador.Image = ((System.Drawing.Image)(resources.GetObject("btnInserirNomeComputador.Image")));
            this.btnInserirNomeComputador.Location = new System.Drawing.Point(354, 34);
            this.btnInserirNomeComputador.Name = "btnInserirNomeComputador";
            this.btnInserirNomeComputador.Size = new System.Drawing.Size(26, 25);
            this.btnInserirNomeComputador.TabIndex = 6;
            this.btnInserirNomeComputador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnInserirNomeComputador, "Clique para inserir o nome do computador atual.");
            this.btnInserirNomeComputador.UseVisualStyleBackColor = true;
            this.btnInserirNomeComputador.Click += new System.EventHandler(this.btnInserirNomeComputador_Click);
            this.btnInserirNomeComputador.MouseLeave += new System.EventHandler(this.btnInserirNomeComputador_MouseLeave);
            this.btnInserirNomeComputador.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnInserirNomeComputador_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(485, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "*";
            // 
            // lblOrdem
            // 
            this.lblOrdem.AutoSize = true;
            this.lblOrdem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOrdem.Location = new System.Drawing.Point(449, 62);
            this.lblOrdem.Name = "lblOrdem";
            this.lblOrdem.Size = new System.Drawing.Size(41, 13);
            this.lblOrdem.TabIndex = 0;
            this.lblOrdem.Text = "Ordem:";
            // 
            // txtOrdem
            // 
            this.txtOrdem.BackColor = System.Drawing.Color.White;
            this.txtOrdem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtOrdem.Location = new System.Drawing.Point(452, 78);
            this.txtOrdem.MaxLength = 8;
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.Size = new System.Drawing.Size(43, 20);
            this.txtOrdem.TabIndex = 14;
            this.txtOrdem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOrdem.Enter += new System.EventHandler(this.txtOrdem_Enter);
            this.txtOrdem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrdem_KeyPress);
            this.txtOrdem.Leave += new System.EventHandler(this.txtOrdem_Leave);
            // 
            // btnVer
            // 
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.Location = new System.Drawing.Point(504, 34);
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
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(246, 21);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(12, 13);
            this.lblAsterisco3.TabIndex = 0;
            this.lblAsterisco3.Text = "*";
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(493, 21);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(12, 13);
            this.lblAsterisco.TabIndex = 0;
            this.lblAsterisco.Text = "*";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(383, 21);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(115, 13);
            this.lblSenha.TabIndex = 0;
            this.lblSenha.Text = "Senha de Autorização:";
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(386, 37);
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
            // txtEntidade
            // 
            this.txtEntidade.BackColor = System.Drawing.Color.White;
            this.txtEntidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntidade.Location = new System.Drawing.Point(501, 78);
            this.txtEntidade.MaxLength = 60;
            this.txtEntidade.Name = "txtEntidade";
            this.txtEntidade.Size = new System.Drawing.Size(253, 20);
            this.txtEntidade.TabIndex = 15;
            this.txtEntidade.Enter += new System.EventHandler(this.txtEntidade_Enter);
            this.txtEntidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntidade_KeyPress);
            this.txtEntidade.Leave += new System.EventHandler(this.txtEntidade_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(5, 37);
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(546, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "*";
            // 
            // lblNomeServIP
            // 
            this.lblNomeServIP.AutoSize = true;
            this.lblNomeServIP.Location = new System.Drawing.Point(160, 21);
            this.lblNomeServIP.Name = "lblNomeServIP";
            this.lblNomeServIP.Size = new System.Drawing.Size(91, 13);
            this.lblNomeServIP.TabIndex = 0;
            this.lblNomeServIP.Text = "Este Computador:";
            // 
            // btnEscolherLocal
            // 
            this.btnEscolherLocal.Image = ((System.Drawing.Image)(resources.GetObject("btnEscolherLocal.Image")));
            this.btnEscolherLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherLocal.Location = new System.Drawing.Point(420, 75);
            this.btnEscolherLocal.Name = "btnEscolherLocal";
            this.btnEscolherLocal.Size = new System.Drawing.Size(26, 25);
            this.btnEscolherLocal.TabIndex = 13;
            this.btnEscolherLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnEscolherLocal, "Clique para localizar um banco de dados.");
            this.btnEscolherLocal.UseVisualStyleBackColor = true;
            this.btnEscolherLocal.Click += new System.EventHandler(this.btnEscolherLocal_Click);
            this.btnEscolherLocal.MouseLeave += new System.EventHandler(this.btnEscolherLocal_MouseLeave);
            this.btnEscolherLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEscolherLocal_MouseMove);
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(137, 21);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(12, 13);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // txtNomeServIP
            // 
            this.txtNomeServIP.BackColor = System.Drawing.Color.White;
            this.txtNomeServIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeServIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeServIP.Location = new System.Drawing.Point(163, 37);
            this.txtNomeServIP.MaxLength = 60;
            this.txtNomeServIP.Name = "txtNomeServIP";
            this.txtNomeServIP.Size = new System.Drawing.Size(185, 20);
            this.txtNomeServIP.TabIndex = 5;
            this.txtNomeServIP.Enter += new System.EventHandler(this.txtNomeServIP_Enter);
            this.txtNomeServIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeServIP_KeyPress);
            this.txtNomeServIP.Leave += new System.EventHandler(this.txtNomeServIP_Leave);
            // 
            // lblTipoConexao
            // 
            this.lblTipoConexao.AutoSize = true;
            this.lblTipoConexao.Location = new System.Drawing.Point(51, 21);
            this.lblTipoConexao.Name = "lblTipoConexao";
            this.lblTipoConexao.Size = new System.Drawing.Size(91, 13);
            this.lblTipoConexao.TabIndex = 0;
            this.lblTipoConexao.Text = "Tipo de Conexão:";
            // 
            // cbbTipoConexao
            // 
            this.cbbTipoConexao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoConexao.DropDownHeight = 250;
            this.cbbTipoConexao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoConexao.FormattingEnabled = true;
            this.cbbTipoConexao.IntegralHeight = false;
            this.cbbTipoConexao.Items.AddRange(new object[] {
            "LOCAL",
            "REDE (LAN)",
            "REDE (VPS)"});
            this.cbbTipoConexao.Location = new System.Drawing.Point(54, 37);
            this.cbbTipoConexao.Name = "cbbTipoConexao";
            this.cbbTipoConexao.Size = new System.Drawing.Size(103, 21);
            this.cbbTipoConexao.TabIndex = 4;
            this.cbbTipoConexao.DropDown += new System.EventHandler(this.cbbTipoConexao_DropDown);
            this.cbbTipoConexao.SelectedIndexChanged += new System.EventHandler(this.cbbTipoConexao_SelectedIndexChanged);
            this.cbbTipoConexao.DropDownClosed += new System.EventHandler(this.cbbTipoConexao_DropDownClosed);
            this.cbbTipoConexao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipoConexao_KeyPress);
            this.cbbTipoConexao.MouseLeave += new System.EventHandler(this.cbbTipoConexao_MouseLeave);
            this.cbbTipoConexao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoConexao_MouseMove);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(283, 62);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(12, 13);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Location = new System.Drawing.Point(121, 62);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(167, 13);
            this.lblCaminho.TabIndex = 0;
            this.lblCaminho.Text = "Caminho para o Banco de Dados:";
            // 
            // txtCaminhoBanco
            // 
            this.txtCaminhoBanco.BackColor = System.Drawing.Color.White;
            this.txtCaminhoBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminhoBanco.Location = new System.Drawing.Point(124, 78);
            this.txtCaminhoBanco.MaxLength = 60;
            this.txtCaminhoBanco.Name = "txtCaminhoBanco";
            this.txtCaminhoBanco.Size = new System.Drawing.Size(290, 20);
            this.txtCaminhoBanco.TabIndex = 12;
            this.txtCaminhoBanco.TextChanged += new System.EventHandler(this.txtCaminhoBanco_TextChanged);
            this.txtCaminhoBanco.Enter += new System.EventHandler(this.txtCaminhoBanco_Enter);
            this.txtCaminhoBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaminhoBanco_KeyPress);
            this.txtCaminhoBanco.Leave += new System.EventHandler(this.txtCaminhoBanco_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Entidade:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(717, 295);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 18;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnSair, "Sair do Cadastro de Conexão.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(401, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 16;
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
            this.btnSalvar.Location = new System.Drawing.Point(492, 295);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 17;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.Location = new System.Drawing.Point(12, 295);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 90;
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
            this.btnExcluir.Location = new System.Drawing.Point(190, 295);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 15;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnExcluir, "Excluir uma Conexão cadastrada.");
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
            this.btnAlterar.Location = new System.Drawing.Point(114, 295);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 14;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnAlterar, "Alterar uma Conexão cadastrada.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(38, 295);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 13;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnNovo, "Cadastrar uma nova Conexão.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome do Servidor:";
            // 
            // txtComputadorServidor
            // 
            this.txtComputadorServidor.BackColor = System.Drawing.Color.White;
            this.txtComputadorServidor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComputadorServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComputadorServidor.Location = new System.Drawing.Point(536, 37);
            this.txtComputadorServidor.MaxLength = 60;
            this.txtComputadorServidor.Name = "txtComputadorServidor";
            this.txtComputadorServidor.Size = new System.Drawing.Size(186, 20);
            this.txtComputadorServidor.TabIndex = 9;
            this.txtComputadorServidor.Enter += new System.EventHandler(this.txtComputadorServidor_Enter);
            this.txtComputadorServidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComputadorServidor_KeyPress);
            this.txtComputadorServidor.Leave += new System.EventHandler(this.txtComputadorServidor_Leave);
            // 
            // txtPorta
            // 
            this.txtPorta.BackColor = System.Drawing.Color.White;
            this.txtPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorta.Location = new System.Drawing.Point(6, 78);
            this.txtPorta.MaxLength = 10;
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(112, 20);
            this.txtPorta.TabIndex = 11;
            this.txtPorta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorta.Enter += new System.EventHandler(this.txtPorta_Enter);
            this.txtPorta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorta_KeyPress);
            this.txtPorta.Leave += new System.EventHandler(this.txtPorta_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Porta:";
            // 
            // btnInserirNomeServidor
            // 
            this.btnInserirNomeServidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInserirNomeServidor.Image = ((System.Drawing.Image)(resources.GetObject("btnInserirNomeServidor.Image")));
            this.btnInserirNomeServidor.Location = new System.Drawing.Point(728, 34);
            this.btnInserirNomeServidor.Name = "btnInserirNomeServidor";
            this.btnInserirNomeServidor.Size = new System.Drawing.Size(26, 25);
            this.btnInserirNomeServidor.TabIndex = 10;
            this.btnInserirNomeServidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCadComputadores.SetToolTip(this.btnInserirNomeServidor, "Clique para inserir o nome do computador atual.");
            this.btnInserirNomeServidor.UseVisualStyleBackColor = true;
            this.btnInserirNomeServidor.Click += new System.EventHandler(this.btnInserirNomeServidor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(623, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "*";
            // 
            // FrmConexoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 333);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblConexoes);
            this.Controls.Add(this.dtConect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConexoes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Gerenciador de Conexões";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConexoes_FormClosing);
            this.Load += new System.EventHandler(this.FrmConexoes_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmConexoes_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtConect)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConexoes;
        private System.Windows.Forms.DataGridView dtConect;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblAsterisco;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtEntidade;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNomeServIP;
        private System.Windows.Forms.Button btnEscolherLocal;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.TextBox txtNomeServIP;
        private System.Windows.Forms.Label lblTipoConexao;
        private System.Windows.Forms.ComboBox cbbTipoConexao;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.TextBox txtCaminhoBanco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label lblOrdem;
        private System.Windows.Forms.TextBox txtOrdem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInserirNomeComputador;
        private System.Windows.Forms.ToolTip ttpCadComputadores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComputadorServidor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Button btnInserirNomeServidor;
        private System.Windows.Forms.Label label6;
    }
}