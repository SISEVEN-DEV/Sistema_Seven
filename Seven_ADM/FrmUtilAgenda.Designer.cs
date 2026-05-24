namespace Seven_Sistema
{
    partial class FrmUtilAgenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtilAgenda));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblEscolha = new System.Windows.Forms.Label();
            this.rbtnTabela = new System.Windows.Forms.RadioButton();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.cbbSituacao = new System.Windows.Forms.ComboBox();
            this.rbtnUsuario = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnData = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnTituloAssunto = new System.Windows.Forms.RadioButton();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.cbbTabela = new System.Windows.Forms.ComboBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.txtpTitulo = new System.Windows.Forms.TextBox();
            this.cbbUsuario = new System.Windows.Forms.ComboBox();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.pcibInterregocao = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.ttpLembrete = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnDuplicar = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.dtLembretes = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.pcibCor = new System.Windows.Forms.PictureBox();
            this.grbBox4 = new System.Windows.Forms.GroupBox();
            this.lblSit = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterregocao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLembretes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibCor)).BeginInit();
            this.grbBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblEscolha);
            this.grbBox1.Controls.Add(this.rbtnTabela);
            this.grbBox1.Controls.Add(this.lblSituacao);
            this.grbBox1.Controls.Add(this.cbbSituacao);
            this.grbBox1.Controls.Add(this.rbtnUsuario);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnData);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnTituloAssunto);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.cbbTabela);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.txtpTitulo);
            this.grbBox1.Controls.Add(this.cbbUsuario);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(675, 85);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // lblEscolha
            // 
            this.lblEscolha.AutoSize = true;
            this.lblEscolha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEscolha.Location = new System.Drawing.Point(217, 19);
            this.lblEscolha.Name = "lblEscolha";
            this.lblEscolha.Size = new System.Drawing.Size(106, 13);
            this.lblEscolha.TabIndex = 0;
            this.lblEscolha.Text = "Escolha a tabela:";
            this.lblEscolha.Visible = false;
            // 
            // rbtnTabela
            // 
            this.rbtnTabela.AutoSize = true;
            this.rbtnTabela.Location = new System.Drawing.Point(74, 42);
            this.rbtnTabela.Name = "rbtnTabela";
            this.rbtnTabela.Size = new System.Drawing.Size(58, 17);
            this.rbtnTabela.TabIndex = 6;
            this.rbtnTabela.Text = "Tabela";
            this.rbtnTabela.UseVisualStyleBackColor = true;
            this.rbtnTabela.CheckedChanged += new System.EventHandler(this.rbtnTabela_CheckedChanged);
            this.rbtnTabela.MouseLeave += new System.EventHandler(this.rbtnTabela_MouseLeave);
            this.rbtnTabela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTabela_MouseMove);
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(536, 42);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(61, 13);
            this.lblSituacao.TabIndex = 53;
            this.lblSituacao.Text = "Situação:";
            // 
            // cbbSituacao
            // 
            this.cbbSituacao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbSituacao.DropDownHeight = 150;
            this.cbbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbSituacao.FormattingEnabled = true;
            this.cbbSituacao.IntegralHeight = false;
            this.cbbSituacao.Items.AddRange(new object[] {
            "",
            "ABERTO",
            "PENDENTE",
            "FINALIZADO"});
            this.cbbSituacao.Location = new System.Drawing.Point(539, 58);
            this.cbbSituacao.Name = "cbbSituacao";
            this.cbbSituacao.Size = new System.Drawing.Size(130, 21);
            this.cbbSituacao.TabIndex = 16;
            this.cbbSituacao.DropDown += new System.EventHandler(this.cbbSituacao_DropDown);
            this.cbbSituacao.DropDownClosed += new System.EventHandler(this.cbbSituacao_DropDownClosed);
            this.cbbSituacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSituacao_KeyPress);
            this.cbbSituacao.MouseLeave += new System.EventHandler(this.cbbSituacao_MouseLeave);
            this.cbbSituacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbSituacao_MouseMove);
            // 
            // rbtnUsuario
            // 
            this.rbtnUsuario.AutoSize = true;
            this.rbtnUsuario.Location = new System.Drawing.Point(7, 42);
            this.rbtnUsuario.Name = "rbtnUsuario";
            this.rbtnUsuario.Size = new System.Drawing.Size(61, 17);
            this.rbtnUsuario.TabIndex = 5;
            this.rbtnUsuario.Text = "Usuário";
            this.rbtnUsuario.UseVisualStyleBackColor = true;
            this.rbtnUsuario.CheckedChanged += new System.EventHandler(this.rbtnUsuário_CheckedChanged);
            this.rbtnUsuario.MouseLeave += new System.EventHandler(this.rbtnUsuário_MouseLeave);
            this.rbtnUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnUsuário_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(153, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 7;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnData
            // 
            this.rbtnData.AutoSize = true;
            this.rbtnData.Location = new System.Drawing.Point(7, 19);
            this.rbtnData.Name = "rbtnData";
            this.rbtnData.Size = new System.Drawing.Size(48, 17);
            this.rbtnData.TabIndex = 2;
            this.rbtnData.Text = "Data";
            this.rbtnData.UseVisualStyleBackColor = true;
            this.rbtnData.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            this.rbtnData.MouseLeave += new System.EventHandler(this.rbtnData_MouseLeave);
            this.rbtnData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnData_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(153, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 4;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.radioButton1_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseMove);
            // 
            // rbtnTituloAssunto
            // 
            this.rbtnTituloAssunto.AutoSize = true;
            this.rbtnTituloAssunto.Location = new System.Drawing.Point(74, 19);
            this.rbtnTituloAssunto.Name = "rbtnTituloAssunto";
            this.rbtnTituloAssunto.Size = new System.Drawing.Size(73, 17);
            this.rbtnTituloAssunto.TabIndex = 3;
            this.rbtnTituloAssunto.Text = "Descrição";
            this.rbtnTituloAssunto.UseVisualStyleBackColor = true;
            this.rbtnTituloAssunto.CheckedChanged += new System.EventHandler(this.rbtnTituloAssunto_CheckedChanged);
            this.rbtnTituloAssunto.MouseLeave += new System.EventHandler(this.rbtnTituloAssunto_MouseLeave);
            this.rbtnTituloAssunto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTituloAssunto_MouseMove);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(523, 19);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            this.lblAte.Visible = false;
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(439, 16);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 9;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.Visible = false;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // cbbTabela
            // 
            this.cbbTabela.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTabela.DropDownWidth = 175;
            this.cbbTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTabela.FormattingEnabled = true;
            this.cbbTabela.Items.AddRange(new object[] {
            "CONTAS A PAGAR",
            "CONTAS A RECEBER"});
            this.cbbTabela.Location = new System.Drawing.Point(329, 15);
            this.cbbTabela.Name = "cbbTabela";
            this.cbbTabela.Size = new System.Drawing.Size(153, 21);
            this.cbbTabela.TabIndex = 8;
            this.cbbTabela.Visible = false;
            this.cbbTabela.DropDown += new System.EventHandler(this.cbbTabela_DropDown);
            this.cbbTabela.DropDownClosed += new System.EventHandler(this.cbbTabela_DropDownClosed);
            this.cbbTabela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTabela_KeyPress);
            this.cbbTabela.MouseLeave += new System.EventHandler(this.cbbTabela_MouseLeave);
            this.cbbTabela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTabela_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(591, 16);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtpCodigo.TabIndex = 11;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(559, 16);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 10;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.Visible = false;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // txtpTitulo
            // 
            this.txtpTitulo.BackColor = System.Drawing.Color.White;
            this.txtpTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpTitulo.Location = new System.Drawing.Point(464, 16);
            this.txtpTitulo.MaxLength = 60;
            this.txtpTitulo.Name = "txtpTitulo";
            this.txtpTitulo.Size = new System.Drawing.Size(205, 20);
            this.txtpTitulo.TabIndex = 12;
            this.txtpTitulo.Enter += new System.EventHandler(this.txtpTitulo_Enter);
            this.txtpTitulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpTitulo_KeyPress);
            this.txtpTitulo.Leave += new System.EventHandler(this.txtpTitulo_Leave);
            // 
            // cbbUsuario
            // 
            this.cbbUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsuario.FormattingEnabled = true;
            this.cbbUsuario.Location = new System.Drawing.Point(519, 15);
            this.cbbUsuario.Name = "cbbUsuario";
            this.cbbUsuario.Size = new System.Drawing.Size(118, 21);
            this.cbbUsuario.TabIndex = 13;
            this.cbbUsuario.DropDown += new System.EventHandler(this.cbbUsuario_DropDown);
            this.cbbUsuario.DropDownClosed += new System.EventHandler(this.cbbUsuario_DropDownClosed);
            this.cbbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUsuario_KeyPress);
            this.cbbUsuario.MouseLeave += new System.EventHandler(this.cbbUsuario_MouseLeave);
            this.cbbUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUsuario_MouseMove);
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(643, 13);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 15;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnpProcurar, "Clique para pesquisar um Usuário.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Visible = false;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(643, 13);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 14;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Visible = false;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.Location = new System.Drawing.Point(344, 19);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(89, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o título:";
            // 
            // pcibInterregocao
            // 
            this.pcibInterregocao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterregocao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterregocao.Image")));
            this.pcibInterregocao.Location = new System.Drawing.Point(19, 99);
            this.pcibInterregocao.Name = "pcibInterregocao";
            this.pcibInterregocao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterregocao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterregocao.TabIndex = 76;
            this.pcibInterregocao.TabStop = false;
            this.pcibInterregocao.Click += new System.EventHandler(this.pcibInterregocao_Click);
            this.pcibInterregocao.MouseLeave += new System.EventHandler(this.pcibInterregocao_MouseLeave);
            this.pcibInterregocao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterregocao_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(603, 103);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 17;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // ttpLembrete
            // 
            this.ttpLembrete.AutoPopDelay = 5000;
            this.ttpLembrete.InitialDelay = 1000;
            this.ttpLembrete.IsBalloon = true;
            this.ttpLembrete.ReshowDelay = 100;
            this.ttpLembrete.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpLembrete.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(632, 487);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 25;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnSair, "Sair da agenda.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.Location = new System.Drawing.Point(507, 29);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 23;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnExcluir, "Excluir um lembrete.");
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
            this.btnAlterar.Location = new System.Drawing.Point(431, 29);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 22;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnAlterar, "Alterar um lembrete cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(355, 29);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 21;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnNovo, "Cadastrar um novo lembrete.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(220, 29);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(129, 32);
            this.btnFinalizar.TabIndex = 20;
            this.btnFinalizar.Text = "&Finalizar/Visualizar";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnFinalizar, "Finalizar o lembrete selecionado.");
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            this.btnFinalizar.MouseLeave += new System.EventHandler(this.btnFinalizar_MouseLeave);
            this.btnFinalizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFinalizar_MouseMove);
            // 
            // btnDuplicar
            // 
            this.btnDuplicar.Enabled = false;
            this.btnDuplicar.Image = ((System.Drawing.Image)(resources.GetObject("btnDuplicar.Image")));
            this.btnDuplicar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDuplicar.Location = new System.Drawing.Point(582, 29);
            this.btnDuplicar.Name = "btnDuplicar";
            this.btnDuplicar.Size = new System.Drawing.Size(87, 32);
            this.btnDuplicar.TabIndex = 24;
            this.btnDuplicar.Text = "&Multiplicar";
            this.btnDuplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnDuplicar, "Adicionar ocorrências para um Lembrete.");
            this.btnDuplicar.UseVisualStyleBackColor = true;
            this.btnDuplicar.Click += new System.EventHandler(this.btnDuplicar_Click);
            this.btnDuplicar.MouseLeave += new System.EventHandler(this.btnDuplicar_MouseLeave);
            this.btnDuplicar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDuplicar_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 487);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 75;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // dtLembretes
            // 
            this.dtLembretes.AllowUserToAddRows = false;
            this.dtLembretes.AllowUserToDeleteRows = false;
            this.dtLembretes.AllowUserToOrderColumns = true;
            this.dtLembretes.AllowUserToResizeRows = false;
            this.dtLembretes.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtLembretes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtLembretes.Location = new System.Drawing.Point(12, 141);
            this.dtLembretes.MultiSelect = false;
            this.dtLembretes.Name = "dtLembretes";
            this.dtLembretes.ReadOnly = true;
            this.dtLembretes.RowHeadersVisible = false;
            this.dtLembretes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtLembretes.ShowCellErrors = false;
            this.dtLembretes.ShowCellToolTips = false;
            this.dtLembretes.ShowEditingIcon = false;
            this.dtLembretes.ShowRowErrors = false;
            this.dtLembretes.Size = new System.Drawing.Size(675, 239);
            this.dtLembretes.TabIndex = 18;
            this.dtLembretes.DataSourceChanged += new System.EventHandler(this.dtLembretes_DataSourceChanged);
            this.dtLembretes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLembretes_CellEnter);
            this.dtLembretes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtLembretes_CellFormatting);
            this.dtLembretes.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtLembretes_RowsAdded);
            this.dtLembretes.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtLembretes_RowsRemoved);
            this.dtLembretes.MouseLeave += new System.EventHandler(this.dtLembretes_MouseLeave);
            this.dtLembretes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtLembretes_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 383);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(204, 26);
            this.lblRegistros.TabIndex = 77;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorSituacao
            // 
            this.lblValorSituacao.AutoSize = true;
            this.lblValorSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorSituacao.Location = new System.Drawing.Point(37, 35);
            this.lblValorSituacao.Name = "lblValorSituacao";
            this.lblValorSituacao.Size = new System.Drawing.Size(68, 19);
            this.lblValorSituacao.TabIndex = 0;
            this.lblValorSituacao.Text = "Situacao";
            this.lblValorSituacao.Visible = false;
            // 
            // pcibCor
            // 
            this.pcibCor.BackColor = System.Drawing.Color.LightGray;
            this.pcibCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibCor.Location = new System.Drawing.Point(6, 32);
            this.pcibCor.Name = "pcibCor";
            this.pcibCor.Size = new System.Drawing.Size(25, 25);
            this.pcibCor.TabIndex = 196;
            this.pcibCor.TabStop = false;
            this.pcibCor.Visible = false;
            // 
            // grbBox4
            // 
            this.grbBox4.Controls.Add(this.lblSit);
            this.grbBox4.Controls.Add(this.btnFinalizar);
            this.grbBox4.Controls.Add(this.lblValorSituacao);
            this.grbBox4.Controls.Add(this.pcibCor);
            this.grbBox4.Controls.Add(this.btnAlterar);
            this.grbBox4.Controls.Add(this.btnExcluir);
            this.grbBox4.Controls.Add(this.btnDuplicar);
            this.grbBox4.Controls.Add(this.btnNovo);
            this.grbBox4.Location = new System.Drawing.Point(12, 412);
            this.grbBox4.Name = "grbBox4";
            this.grbBox4.Size = new System.Drawing.Size(675, 69);
            this.grbBox4.TabIndex = 19;
            this.grbBox4.TabStop = false;
            this.grbBox4.Text = "Ações:";
            // 
            // lblSit
            // 
            this.lblSit.AutoSize = true;
            this.lblSit.Location = new System.Drawing.Point(2, 16);
            this.lblSit.Name = "lblSit";
            this.lblSit.Size = new System.Drawing.Size(52, 13);
            this.lblSit.TabIndex = 197;
            this.lblSit.Text = "Situação:";
            this.lblSit.Visible = false;
            // 
            // FrmUtilAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(700, 529);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox4);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.pcibInterregocao);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dtLembretes);
            this.Controls.Add(this.btnSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilAgenda";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmContLembrete_FormClosing);
            this.Load += new System.EventHandler(this.FrmContLembrete_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmContLembrete_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterregocao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLembretes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibCor)).EndInit();
            this.grbBox4.ResumeLayout(false);
            this.grbBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.TextBox txtpTitulo;
        private System.Windows.Forms.RadioButton rbtnData;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnTituloAssunto;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.ToolTip ttpLembrete;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.PictureBox pcibInterregocao;
        private System.Windows.Forms.DataGridView dtLembretes;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.PictureBox pcibCor;
        private System.Windows.Forms.GroupBox grbBox4;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.RadioButton rbtnUsuario;
        private System.Windows.Forms.Label lblSit;
        private System.Windows.Forms.ComboBox cbbUsuario;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.ComboBox cbbSituacao;
        private System.Windows.Forms.Button btnDuplicar;
        private System.Windows.Forms.RadioButton rbtnTabela;
        private System.Windows.Forms.Label lblEscolha;
        private System.Windows.Forms.ComboBox cbbTabela;
    }
}