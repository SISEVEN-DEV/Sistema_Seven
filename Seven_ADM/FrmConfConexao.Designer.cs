namespace Seven_Sistema
{
    partial class FrmConfConexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfConexao));
            this.dtConect = new System.Windows.Forms.DataGridView();
            this.lblConexoes = new System.Windows.Forms.Label();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeDestePC = new System.Windows.Forms.TextBox();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtDescFant = new System.Windows.Forms.TextBox();
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
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnCancelarMini = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAlterarMini = new System.Windows.Forms.Button();
            this.btnSalvarMini = new System.Windows.Forms.Button();
            this.btnExcluirMini = new System.Windows.Forms.Button();
            this.btnNovoMini = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtConect)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
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
            // lblConexoes
            // 
            this.lblConexoes.AutoSize = true;
            this.lblConexoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexoes.Location = new System.Drawing.Point(12, 9);
            this.lblConexoes.Name = "lblConexoes";
            this.lblConexoes.Size = new System.Drawing.Size(66, 13);
            this.lblConexoes.TabIndex = 19;
            this.lblConexoes.Text = "Conexões:";
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label3);
            this.grbBox1.Controls.Add(this.label4);
            this.grbBox1.Controls.Add(this.txtNomeDestePC);
            this.grbBox1.Controls.Add(this.lblAsterisco3);
            this.grbBox1.Controls.Add(this.btnVer);
            this.grbBox1.Controls.Add(this.lblAsterisco);
            this.grbBox1.Controls.Add(this.lblSenha);
            this.grbBox1.Controls.Add(this.txtSenha);
            this.grbBox1.Controls.Add(this.txtDescFant);
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.lblNomeServIP);
            this.grbBox1.Controls.Add(this.btnEscolherLocal);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.txtNomeServIP);
            this.grbBox1.Controls.Add(this.lblTipoConexao);
            this.grbBox1.Controls.Add(this.cbbTipoConexao);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.lblCaminho);
            this.grbBox1.Controls.Add(this.txtCaminhoBanco);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(12, 185);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 104);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Cadastrar, alterar e excluir:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(125, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nome deste Computador:";
            // 
            // txtNomeDestePC
            // 
            this.txtNomeDestePC.BackColor = System.Drawing.Color.White;
            this.txtNomeDestePC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeDestePC.Location = new System.Drawing.Point(6, 78);
            this.txtNomeDestePC.MaxLength = 60;
            this.txtNomeDestePC.Name = "txtNomeDestePC";
            this.txtNomeDestePC.ReadOnly = true;
            this.txtNomeDestePC.Size = new System.Drawing.Size(224, 20);
            this.txtNomeDestePC.TabIndex = 13;
            this.txtNomeDestePC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeDestePC_KeyPress);
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(258, 21);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco3.TabIndex = 11;
            this.lblAsterisco3.Text = "*";
            // 
            // btnVer
            // 
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.Location = new System.Drawing.Point(677, 75);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(26, 25);
            this.btnVer.TabIndex = 10;
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            this.btnVer.MouseLeave += new System.EventHandler(this.btnVer_MouseLeave);
            this.btnVer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVer_MouseMove);
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(666, 62);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco.TabIndex = 0;
            this.lblAsterisco.Text = "*";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(556, 62);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(115, 13);
            this.lblSenha.TabIndex = 0;
            this.lblSenha.Text = "Senha de Autorização:";
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(559, 78);
            this.txtSenha.MaxLength = 10;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '●';
            this.txtSenha.Size = new System.Drawing.Size(112, 20);
            this.txtSenha.TabIndex = 9;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // txtDescFant
            // 
            this.txtDescFant.BackColor = System.Drawing.Color.White;
            this.txtDescFant.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescFant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescFant.Location = new System.Drawing.Point(236, 78);
            this.txtDescFant.MaxLength = 60;
            this.txtDescFant.Name = "txtDescFant";
            this.txtDescFant.Size = new System.Drawing.Size(317, 20);
            this.txtDescFant.TabIndex = 8;
            this.txtDescFant.Enter += new System.EventHandler(this.txtDescFant_Enter);
            this.txtDescFant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescFant_KeyPress);
            this.txtDescFant.Leave += new System.EventHandler(this.txtDescFant_Leave);
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
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(399, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "*";
            // 
            // lblNomeServIP
            // 
            this.lblNomeServIP.AutoSize = true;
            this.lblNomeServIP.Location = new System.Drawing.Point(150, 21);
            this.lblNomeServIP.Name = "lblNomeServIP";
            this.lblNomeServIP.Size = new System.Drawing.Size(113, 13);
            this.lblNomeServIP.TabIndex = 0;
            this.lblNomeServIP.Text = "Nome do Computador:";
            // 
            // btnEscolherLocal
            // 
            this.btnEscolherLocal.Image = ((System.Drawing.Image)(resources.GetObject("btnEscolherLocal.Image")));
            this.btnEscolherLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherLocal.Location = new System.Drawing.Point(728, 34);
            this.btnEscolherLocal.Name = "btnEscolherLocal";
            this.btnEscolherLocal.Size = new System.Drawing.Size(26, 25);
            this.btnEscolherLocal.TabIndex = 7;
            this.btnEscolherLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEscolherLocal.UseVisualStyleBackColor = true;
            this.btnEscolherLocal.Click += new System.EventHandler(this.btnEscolherLocal_Click);
            this.btnEscolherLocal.MouseLeave += new System.EventHandler(this.btnEscolherLocal_MouseLeave);
            this.btnEscolherLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEscolherLocal_MouseMove);
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(137, 21);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // txtNomeServIP
            // 
            this.txtNomeServIP.BackColor = System.Drawing.Color.White;
            this.txtNomeServIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeServIP.Location = new System.Drawing.Point(153, 37);
            this.txtNomeServIP.MaxLength = 60;
            this.txtNomeServIP.Name = "txtNomeServIP";
            this.txtNomeServIP.Size = new System.Drawing.Size(224, 20);
            this.txtNomeServIP.TabIndex = 5;
            this.txtNomeServIP.Enter += new System.EventHandler(this.txtNomeComputadorIP_Enter);
            this.txtNomeServIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeComputadorIP_KeyPress);
            this.txtNomeServIP.Leave += new System.EventHandler(this.txtNomeComputadorIP_Leave);
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
            this.cbbTipoConexao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoConexao.FormattingEnabled = true;
            this.cbbTipoConexao.Items.AddRange(new object[] {
            "LOCAL",
            "REMOTA"});
            this.cbbTipoConexao.Location = new System.Drawing.Point(54, 37);
            this.cbbTipoConexao.Name = "cbbTipoConexao";
            this.cbbTipoConexao.Size = new System.Drawing.Size(93, 21);
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
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(542, 21);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Location = new System.Drawing.Point(380, 21);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(167, 13);
            this.lblCaminho.TabIndex = 0;
            this.lblCaminho.Text = "Caminho para o Banco de Dados:";
            // 
            // txtCaminhoBanco
            // 
            this.txtCaminhoBanco.BackColor = System.Drawing.Color.White;
            this.txtCaminhoBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminhoBanco.Location = new System.Drawing.Point(383, 37);
            this.txtCaminhoBanco.MaxLength = 60;
            this.txtCaminhoBanco.Name = "txtCaminhoBanco";
            this.txtCaminhoBanco.Size = new System.Drawing.Size(339, 20);
            this.txtCaminhoBanco.TabIndex = 6;
            this.txtCaminhoBanco.Enter += new System.EventHandler(this.txtCaminhoBanco_Enter);
            this.txtCaminhoBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaminhoBanco_KeyPress);
            this.txtCaminhoBanco.Leave += new System.EventHandler(this.txtCaminhoBanco_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrição/Razão Social/Fantasia:";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(10, 159);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancelarMini
            // 
            this.btnCancelarMini.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarMini.Image")));
            this.btnCancelarMini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarMini.Location = new System.Drawing.Point(395, 295);
            this.btnCancelarMini.Name = "btnCancelarMini";
            this.btnCancelarMini.Size = new System.Drawing.Size(74, 25);
            this.btnCancelarMini.TabIndex = 14;
            this.btnCancelarMini.Text = "&Cancelar";
            this.btnCancelarMini.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarMini.UseVisualStyleBackColor = true;
            this.btnCancelarMini.Visible = false;
            this.btnCancelarMini.Click += new System.EventHandler(this.btnCancelarMini_Click);
            this.btnCancelarMini.MouseLeave += new System.EventHandler(this.btnCancelarMini_MouseLeave);
            this.btnCancelarMini.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelarMini_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(717, 295);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 16;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnAlterarMini
            // 
            this.btnAlterarMini.Enabled = false;
            this.btnAlterarMini.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterarMini.Image")));
            this.btnAlterarMini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterarMini.Location = new System.Drawing.Point(103, 295);
            this.btnAlterarMini.Name = "btnAlterarMini";
            this.btnAlterarMini.Size = new System.Drawing.Size(66, 25);
            this.btnAlterarMini.TabIndex = 12;
            this.btnAlterarMini.Text = "&Alterar";
            this.btnAlterarMini.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterarMini.UseVisualStyleBackColor = true;
            this.btnAlterarMini.Click += new System.EventHandler(this.btnAlterarMini_Click);
            this.btnAlterarMini.MouseLeave += new System.EventHandler(this.btnAlterarMini_MouseLeave);
            this.btnAlterarMini.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterarMini_MouseMove);
            // 
            // btnSalvarMini
            // 
            this.btnSalvarMini.Enabled = false;
            this.btnSalvarMini.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarMini.Image")));
            this.btnSalvarMini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarMini.Location = new System.Drawing.Point(475, 295);
            this.btnSalvarMini.Name = "btnSalvarMini";
            this.btnSalvarMini.Size = new System.Drawing.Size(62, 25);
            this.btnSalvarMini.TabIndex = 15;
            this.btnSalvarMini.Text = "&Salvar";
            this.btnSalvarMini.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarMini.UseVisualStyleBackColor = true;
            this.btnSalvarMini.Click += new System.EventHandler(this.btnSalvarMini_Click);
            this.btnSalvarMini.MouseLeave += new System.EventHandler(this.btnSalvarMini_MouseLeave);
            this.btnSalvarMini.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvarMini_MouseMove);
            // 
            // btnExcluirMini
            // 
            this.btnExcluirMini.Enabled = false;
            this.btnExcluirMini.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirMini.Image")));
            this.btnExcluirMini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirMini.Location = new System.Drawing.Point(175, 295);
            this.btnExcluirMini.Name = "btnExcluirMini";
            this.btnExcluirMini.Size = new System.Drawing.Size(64, 25);
            this.btnExcluirMini.TabIndex = 13;
            this.btnExcluirMini.Text = "&Excluir";
            this.btnExcluirMini.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluirMini.UseVisualStyleBackColor = true;
            this.btnExcluirMini.Click += new System.EventHandler(this.btnExcluirMini_Click);
            this.btnExcluirMini.MouseLeave += new System.EventHandler(this.btnExcluirMini_MouseLeave);
            this.btnExcluirMini.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirMini_MouseMove);
            // 
            // btnNovoMini
            // 
            this.btnNovoMini.Image = ((System.Drawing.Image)(resources.GetObject("btnNovoMini.Image")));
            this.btnNovoMini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoMini.Location = new System.Drawing.Point(38, 295);
            this.btnNovoMini.Name = "btnNovoMini";
            this.btnNovoMini.Size = new System.Drawing.Size(59, 25);
            this.btnNovoMini.TabIndex = 11;
            this.btnNovoMini.Text = "&Novo";
            this.btnNovoMini.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoMini.UseVisualStyleBackColor = true;
            this.btnNovoMini.Click += new System.EventHandler(this.btnNovoMini_Click);
            this.btnNovoMini.MouseLeave += new System.EventHandler(this.btnNovoMini_MouseLeave);
            this.btnNovoMini.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovoMini_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 295);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 35;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // FrmConfConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(778, 327);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnCancelarMini);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAlterarMini);
            this.Controls.Add(this.btnSalvarMini);
            this.Controls.Add(this.btnExcluirMini);
            this.Controls.Add(this.btnNovoMini);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.lblConexoes);
            this.Controls.Add(this.dtConect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfConexao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexões e Banco de Dados desta Aplicação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConexao_FormClosing);
            this.Load += new System.EventHandler(this.FrmAddEmpresaBanco_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmConexao_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtConect)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtConect;
        private System.Windows.Forms.Label lblConexoes;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.TextBox txtCaminhoBanco;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblTipoConexao;
        private System.Windows.Forms.ComboBox cbbTipoConexao;
        private System.Windows.Forms.Button btnCancelarMini;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnAlterarMini;
        private System.Windows.Forms.Button btnSalvarMini;
        private System.Windows.Forms.Button btnExcluirMini;
        private System.Windows.Forms.Button btnNovoMini;
        private System.Windows.Forms.Button btnEscolherLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNomeServIP;
        private System.Windows.Forms.TextBox txtNomeServIP;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtDescFant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label lblAsterisco;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomeDestePC;
    }
}