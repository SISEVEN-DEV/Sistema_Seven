namespace Seven_Sistema
{
    partial class FrmRelClieCons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelClieCons));
            this.pcibAjudaFoto = new System.Windows.Forms.PictureBox();
            this.lblLegendaImagem = new System.Windows.Forms.Label();
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblSubgrupos = new System.Windows.Forms.Label();
            this.btnProcurarSubgrupo = new System.Windows.Forms.Button();
            this.cbbpSubGrupo = new System.Windows.Forms.ComboBox();
            this.lblGrupos = new System.Windows.Forms.Label();
            this.btnProcurarGrupo = new System.Windows.Forms.Button();
            this.cbbpGrupo = new System.Windows.Forms.ComboBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblCPFAvalista = new System.Windows.Forms.Label();
            this.lblNomeAvalista = new System.Windows.Forms.Label();
            this.txtNomeAvalista = new System.Windows.Forms.TextBox();
            this.mtxtCPFAvalista = new System.Windows.Forms.MaskedTextBox();
            this.txtpEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTipoPessoa = new System.Windows.Forms.Label();
            this.cbbpTipo = new System.Windows.Forms.ComboBox();
            this.mtxtpCelular = new System.Windows.Forms.MaskedTextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.mtxtpTelefone = new System.Windows.Forms.MaskedTextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblDatas = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.cbbCidade = new System.Windows.Forms.ComboBox();
            this.rbtnIE = new System.Windows.Forms.RadioButton();
            this.cbbUF = new System.Windows.Forms.ComboBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.rbtnCNPJ = new System.Windows.Forms.RadioButton();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCPFResponsavel = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNome = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnRG = new System.Windows.Forms.RadioButton();
            this.rbtnCPF = new System.Windows.Forms.RadioButton();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.mtxtpCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtpRG = new System.Windows.Forms.TextBox();
            this.txtpNome = new System.Windows.Forms.TextBox();
            this.mtxtpCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dtClie = new System.Windows.Forms.DataGridView();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnInfDocumentos = new System.Windows.Forms.Button();
            this.btnRelatorioCompleto = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.btnRelatorioPDF = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.ttpCliente = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.pEnabled = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClie)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcibAjudaFoto
            // 
            this.pcibAjudaFoto.BackColor = System.Drawing.Color.White;
            this.pcibAjudaFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibAjudaFoto.Enabled = false;
            this.pcibAjudaFoto.Image = ((System.Drawing.Image)(resources.GetObject("pcibAjudaFoto.Image")));
            this.pcibAjudaFoto.Location = new System.Drawing.Point(147, 313);
            this.pcibAjudaFoto.Name = "pcibAjudaFoto";
            this.pcibAjudaFoto.Size = new System.Drawing.Size(20, 20);
            this.pcibAjudaFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibAjudaFoto.TabIndex = 90;
            this.pcibAjudaFoto.TabStop = false;
            this.pcibAjudaFoto.Click += new System.EventHandler(this.pcibAjudaFoto_Click);
            this.pcibAjudaFoto.MouseLeave += new System.EventHandler(this.pcibAjudaFoto_MouseLeave);
            this.pcibAjudaFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibAjudaFoto_MouseMove);
            // 
            // lblLegendaImagem
            // 
            this.lblLegendaImagem.Location = new System.Drawing.Point(36, 290);
            this.lblLegendaImagem.Name = "lblLegendaImagem";
            this.lblLegendaImagem.Size = new System.Drawing.Size(147, 45);
            this.lblLegendaImagem.TabIndex = 0;
            this.lblLegendaImagem.Text = "Sem imagem para este registro.";
            this.lblLegendaImagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLegendaImagem.Visible = false;
            this.lblLegendaImagem.Click += new System.EventHandler(this.lblLegendaImagem_Click);
            this.lblLegendaImagem.MouseLeave += new System.EventHandler(this.lblLegendaImagem_MouseLeave);
            this.lblLegendaImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblLegendaImagem_MouseMove);
            // 
            // pcibImagem
            // 
            this.pcibImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem.Location = new System.Drawing.Point(32, 247);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(155, 127);
            this.pcibImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagem.TabIndex = 91;
            this.pcibImagem.TabStop = false;
            this.pcibImagem.Click += new System.EventHandler(this.pcibImagem_Click);
            this.pcibImagem.MouseLeave += new System.EventHandler(this.pcibImagem_MouseLeave);
            this.pcibImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagem_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblSubgrupos);
            this.grbBox1.Controls.Add(this.btnProcurarSubgrupo);
            this.grbBox1.Controls.Add(this.cbbpSubGrupo);
            this.grbBox1.Controls.Add(this.lblGrupos);
            this.grbBox1.Controls.Add(this.btnProcurarGrupo);
            this.grbBox1.Controls.Add(this.cbbpGrupo);
            this.grbBox1.Controls.Add(this.lblCidade);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblCPFAvalista);
            this.grbBox1.Controls.Add(this.lblNomeAvalista);
            this.grbBox1.Controls.Add(this.txtNomeAvalista);
            this.grbBox1.Controls.Add(this.mtxtCPFAvalista);
            this.grbBox1.Controls.Add(this.txtpEmail);
            this.grbBox1.Controls.Add(this.lblEmail);
            this.grbBox1.Controls.Add(this.lblTipoPessoa);
            this.grbBox1.Controls.Add(this.cbbpTipo);
            this.grbBox1.Controls.Add(this.mtxtpCelular);
            this.grbBox1.Controls.Add(this.lblCelular);
            this.grbBox1.Controls.Add(this.mtxtpTelefone);
            this.grbBox1.Controls.Add(this.lblEndereco);
            this.grbBox1.Controls.Add(this.lblTelefone);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.cbbCidade);
            this.grbBox1.Controls.Add(this.rbtnIE);
            this.grbBox1.Controls.Add(this.cbbUF);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.rbtnCNPJ);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCPFResponsavel);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNome);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnRG);
            this.grbBox1.Controls.Add(this.rbtnCPF);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.mtxtpCPF);
            this.grbBox1.Controls.Add(this.txtpRG);
            this.grbBox1.Controls.Add(this.txtpNome);
            this.grbBox1.Controls.Add(this.mtxtpCNPJ);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Location = new System.Drawing.Point(32, 53);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(820, 149);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // lblSubgrupos
            // 
            this.lblSubgrupos.AutoSize = true;
            this.lblSubgrupos.Enabled = false;
            this.lblSubgrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubgrupos.Location = new System.Drawing.Point(216, 102);
            this.lblSubgrupos.Name = "lblSubgrupos";
            this.lblSubgrupos.Size = new System.Drawing.Size(65, 13);
            this.lblSubgrupos.TabIndex = 34;
            this.lblSubgrupos.Text = "Subgrupo:";
            // 
            // btnProcurarSubgrupo
            // 
            this.btnProcurarSubgrupo.Enabled = false;
            this.btnProcurarSubgrupo.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarSubgrupo.Image")));
            this.btnProcurarSubgrupo.Location = new System.Drawing.Point(395, 113);
            this.btnProcurarSubgrupo.Name = "btnProcurarSubgrupo";
            this.btnProcurarSubgrupo.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarSubgrupo.TabIndex = 28;
            this.btnProcurarSubgrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcurarSubgrupo.UseVisualStyleBackColor = true;
            this.btnProcurarSubgrupo.Click += new System.EventHandler(this.btnProcurarSubgrupo_Click);
            this.btnProcurarSubgrupo.MouseLeave += new System.EventHandler(this.btnProcurarSubgrupo_MouseLeave);
            this.btnProcurarSubgrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarSubgrupo_MouseMove);
            // 
            // cbbpSubGrupo
            // 
            this.cbbpSubGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpSubGrupo.DropDownWidth = 550;
            this.cbbpSubGrupo.Enabled = false;
            this.cbbpSubGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpSubGrupo.FormattingEnabled = true;
            this.cbbpSubGrupo.Location = new System.Drawing.Point(219, 116);
            this.cbbpSubGrupo.Name = "cbbpSubGrupo";
            this.cbbpSubGrupo.Size = new System.Drawing.Size(170, 21);
            this.cbbpSubGrupo.TabIndex = 27;
            this.cbbpSubGrupo.DropDown += new System.EventHandler(this.cbbpSubGrupo_DropDown);
            this.cbbpSubGrupo.DropDownClosed += new System.EventHandler(this.cbbpSubGrupo_DropDownClosed);
            this.cbbpSubGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpSubGrupo_KeyPress);
            this.cbbpSubGrupo.MouseLeave += new System.EventHandler(this.cbbpSubGrupo_MouseLeave);
            this.cbbpSubGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpSubGrupo_MouseMove);
            // 
            // lblGrupos
            // 
            this.lblGrupos.AutoSize = true;
            this.lblGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupos.Location = new System.Drawing.Point(3, 102);
            this.lblGrupos.Name = "lblGrupos";
            this.lblGrupos.Size = new System.Drawing.Size(45, 13);
            this.lblGrupos.TabIndex = 31;
            this.lblGrupos.Text = "Grupo:";
            // 
            // btnProcurarGrupo
            // 
            this.btnProcurarGrupo.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarGrupo.Image")));
            this.btnProcurarGrupo.Location = new System.Drawing.Point(187, 113);
            this.btnProcurarGrupo.Name = "btnProcurarGrupo";
            this.btnProcurarGrupo.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarGrupo.TabIndex = 26;
            this.btnProcurarGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcurarGrupo.UseVisualStyleBackColor = true;
            this.btnProcurarGrupo.Click += new System.EventHandler(this.btnProcurarGrupo_Click);
            this.btnProcurarGrupo.MouseLeave += new System.EventHandler(this.btnProcurarGrupo_MouseLeave);
            this.btnProcurarGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarGrupo_MouseMove);
            // 
            // cbbpGrupo
            // 
            this.cbbpGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpGrupo.DropDownWidth = 550;
            this.cbbpGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpGrupo.Location = new System.Drawing.Point(6, 116);
            this.cbbpGrupo.Name = "cbbpGrupo";
            this.cbbpGrupo.Size = new System.Drawing.Size(175, 21);
            this.cbbpGrupo.TabIndex = 25;
            this.cbbpGrupo.DropDown += new System.EventHandler(this.cbbpGrupo_DropDown);
            this.cbbpGrupo.SelectedIndexChanged += new System.EventHandler(this.cbbpGrupo_SelectedIndexChanged);
            this.cbbpGrupo.DropDownClosed += new System.EventHandler(this.cbbpGrupo_DropDownClosed);
            this.cbbpGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpGrupo_KeyPress);
            this.cbbpGrupo.MouseLeave += new System.EventHandler(this.cbbpGrupo_MouseLeave);
            this.cbbpGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpGrupo_MouseMove);
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCidade.Location = new System.Drawing.Point(287, 61);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(50, 13);
            this.lblCidade.TabIndex = 28;
            this.lblCidade.Text = "Cidade:";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(206, 75);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 20;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // lblCPFAvalista
            // 
            this.lblCPFAvalista.AutoSize = true;
            this.lblCPFAvalista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPFAvalista.Location = new System.Drawing.Point(716, 101);
            this.lblCPFAvalista.Name = "lblCPFAvalista";
            this.lblCPFAvalista.Size = new System.Drawing.Size(101, 13);
            this.lblCPFAvalista.TabIndex = 0;
            this.lblCPFAvalista.Text = "CPF do Avalista:";
            // 
            // lblNomeAvalista
            // 
            this.lblNomeAvalista.AutoSize = true;
            this.lblNomeAvalista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeAvalista.Location = new System.Drawing.Point(565, 101);
            this.lblNomeAvalista.Name = "lblNomeAvalista";
            this.lblNomeAvalista.Size = new System.Drawing.Size(110, 13);
            this.lblNomeAvalista.TabIndex = 0;
            this.lblNomeAvalista.Text = "Nome do Avalista:";
            // 
            // txtNomeAvalista
            // 
            this.txtNomeAvalista.BackColor = System.Drawing.Color.White;
            this.txtNomeAvalista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeAvalista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeAvalista.Location = new System.Drawing.Point(568, 117);
            this.txtNomeAvalista.MaxLength = 60;
            this.txtNomeAvalista.Name = "txtNomeAvalista";
            this.txtNomeAvalista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNomeAvalista.Size = new System.Drawing.Size(145, 20);
            this.txtNomeAvalista.TabIndex = 30;
            this.txtNomeAvalista.Enter += new System.EventHandler(this.txtNomeAvalista_Enter);
            this.txtNomeAvalista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeAvalista_KeyPress);
            this.txtNomeAvalista.Leave += new System.EventHandler(this.txtNomeAvalista_Leave);
            // 
            // mtxtCPFAvalista
            // 
            this.mtxtCPFAvalista.BackColor = System.Drawing.Color.White;
            this.mtxtCPFAvalista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCPFAvalista.Location = new System.Drawing.Point(719, 117);
            this.mtxtCPFAvalista.Mask = "000,000,000-00";
            this.mtxtCPFAvalista.Name = "mtxtCPFAvalista";
            this.mtxtCPFAvalista.Size = new System.Drawing.Size(95, 20);
            this.mtxtCPFAvalista.TabIndex = 31;
            this.mtxtCPFAvalista.Enter += new System.EventHandler(this.mtxtCPFAvalista_Enter);
            this.mtxtCPFAvalista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCPFAvalista_KeyPress);
            this.mtxtCPFAvalista.Leave += new System.EventHandler(this.mtxtCPFAvalista_Leave);
            // 
            // txtpEmail
            // 
            this.txtpEmail.BackColor = System.Drawing.Color.White;
            this.txtpEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpEmail.Location = new System.Drawing.Point(427, 117);
            this.txtpEmail.MaxLength = 35;
            this.txtpEmail.Name = "txtpEmail";
            this.txtpEmail.Size = new System.Drawing.Size(135, 20);
            this.txtpEmail.TabIndex = 29;
            this.txtpEmail.Enter += new System.EventHandler(this.txtpEmail_Enter);
            this.txtpEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpEmail_KeyPress);
            this.txtpEmail.Leave += new System.EventHandler(this.txtpEmail_Leave);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(425, 101);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "E-mail:";
            // 
            // lblTipoPessoa
            // 
            this.lblTipoPessoa.AutoSize = true;
            this.lblTipoPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPessoa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipoPessoa.Location = new System.Drawing.Point(501, 61);
            this.lblTipoPessoa.Name = "lblTipoPessoa";
            this.lblTipoPessoa.Size = new System.Drawing.Size(99, 13);
            this.lblTipoPessoa.TabIndex = 0;
            this.lblTipoPessoa.Text = "Tipo de Pessoa:";
            // 
            // cbbpTipo
            // 
            this.cbbpTipo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipo.DropDownWidth = 150;
            this.cbbpTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipo.FormattingEnabled = true;
            this.cbbpTipo.Items.AddRange(new object[] {
            "",
            "PESSOA FÍSICA",
            "PESSOA JURÍDICA"});
            this.cbbpTipo.Location = new System.Drawing.Point(504, 77);
            this.cbbpTipo.Name = "cbbpTipo";
            this.cbbpTipo.Size = new System.Drawing.Size(105, 21);
            this.cbbpTipo.TabIndex = 22;
            this.cbbpTipo.DropDown += new System.EventHandler(this.cbbpTipo_DropDown);
            this.cbbpTipo.DropDownClosed += new System.EventHandler(this.cbbpTipo_DropDownClosed);
            this.cbbpTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipo_KeyPress);
            this.cbbpTipo.MouseLeave += new System.EventHandler(this.cbbpTipo_MouseLeave);
            this.cbbpTipo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTipo_MouseMove);
            // 
            // mtxtpCelular
            // 
            this.mtxtpCelular.BackColor = System.Drawing.Color.White;
            this.mtxtpCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpCelular.Location = new System.Drawing.Point(714, 77);
            this.mtxtpCelular.Mask = "(00) 00000-0000";
            this.mtxtpCelular.Name = "mtxtpCelular";
            this.mtxtpCelular.Size = new System.Drawing.Size(100, 20);
            this.mtxtpCelular.TabIndex = 24;
            this.mtxtpCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtpCelular.Enter += new System.EventHandler(this.mtxtpCelular_Enter);
            this.mtxtpCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCelular_KeyPress);
            this.mtxtpCelular.Leave += new System.EventHandler(this.mtxtpCelular_Leave);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelular.Location = new System.Drawing.Point(711, 61);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(50, 13);
            this.lblCelular.TabIndex = 0;
            this.lblCelular.Text = "Celular:";
            // 
            // mtxtpTelefone
            // 
            this.mtxtpTelefone.BackColor = System.Drawing.Color.White;
            this.mtxtpTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpTelefone.Location = new System.Drawing.Point(615, 77);
            this.mtxtpTelefone.Mask = "(00) 0000-0000";
            this.mtxtpTelefone.Name = "mtxtpTelefone";
            this.mtxtpTelefone.Size = new System.Drawing.Size(94, 20);
            this.mtxtpTelefone.TabIndex = 23;
            this.mtxtpTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtpTelefone.Enter += new System.EventHandler(this.mtxtpTelefone_Enter);
            this.mtxtpTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpTelefone_KeyPress);
            this.mtxtpTelefone.Leave += new System.EventHandler(this.mtxtpTelefone_Leave);
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEndereco.Location = new System.Drawing.Point(235, 61);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(27, 13);
            this.lblEndereco.TabIndex = 0;
            this.lblEndereco.Text = "UF:";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefone.Location = new System.Drawing.Point(612, 61);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(61, 13);
            this.lblTelefone.TabIndex = 0;
            this.lblTelefone.Text = "Telefone:";
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatas.Location = new System.Drawing.Point(3, 62);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(110, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Data de Cadastro:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(90, 82);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // cbbCidade
            // 
            this.cbbCidade.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCidade.DropDownWidth = 325;
            this.cbbCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbCidade.FormattingEnabled = true;
            this.cbbCidade.Location = new System.Drawing.Point(289, 77);
            this.cbbCidade.Name = "cbbCidade";
            this.cbbCidade.Size = new System.Drawing.Size(209, 21);
            this.cbbCidade.TabIndex = 21;
            this.cbbCidade.DropDown += new System.EventHandler(this.cbbCidade_DropDown);
            this.cbbCidade.DropDownClosed += new System.EventHandler(this.cbbCidade_DropDownClosed);
            this.cbbCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCidade_KeyPress);
            this.cbbCidade.MouseLeave += new System.EventHandler(this.cbbCidade_MouseLeave);
            this.cbbCidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCidade_MouseMove);
            // 
            // rbtnIE
            // 
            this.rbtnIE.AutoSize = true;
            this.rbtnIE.Location = new System.Drawing.Point(133, 42);
            this.rbtnIE.Name = "rbtnIE";
            this.rbtnIE.Size = new System.Drawing.Size(112, 17);
            this.rbtnIE.TabIndex = 7;
            this.rbtnIE.TabStop = true;
            this.rbtnIE.Text = "Inscrição Estadual";
            this.rbtnIE.UseVisualStyleBackColor = true;
            this.rbtnIE.CheckedChanged += new System.EventHandler(this.rbtnIE_CheckedChanged);
            this.rbtnIE.MouseLeave += new System.EventHandler(this.rbtnIE_MouseLeave);
            this.rbtnIE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnIE_MouseMove);
            // 
            // cbbUF
            // 
            this.cbbUF.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUF.FormattingEnabled = true;
            this.cbbUF.Items.AddRange(new object[] {
            "",
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.cbbUF.Location = new System.Drawing.Point(238, 77);
            this.cbbUF.Name = "cbbUF";
            this.cbbUF.Size = new System.Drawing.Size(45, 21);
            this.cbbUF.TabIndex = 20;
            this.cbbUF.DropDown += new System.EventHandler(this.cbbUF_DropDown);
            this.cbbUF.SelectedIndexChanged += new System.EventHandler(this.cbbUF_SelectedIndexChanged);
            this.cbbUF.DropDownClosed += new System.EventHandler(this.cbbUF_DropDownClosed);
            this.cbbUF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUF_KeyPress);
            this.cbbUF.MouseLeave += new System.EventHandler(this.cbbUF_MouseLeave);
            this.cbbUF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUF_MouseMove);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(122, 78);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 19;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyDown);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // rbtnCNPJ
            // 
            this.rbtnCNPJ.AutoSize = true;
            this.rbtnCNPJ.Location = new System.Drawing.Point(6, 42);
            this.rbtnCNPJ.Name = "rbtnCNPJ";
            this.rbtnCNPJ.Size = new System.Drawing.Size(52, 17);
            this.rbtnCNPJ.TabIndex = 5;
            this.rbtnCNPJ.TabStop = true;
            this.rbtnCNPJ.Text = "CNPJ";
            this.rbtnCNPJ.UseVisualStyleBackColor = true;
            this.rbtnCNPJ.CheckedChanged += new System.EventHandler(this.rbtnCNPJ_CheckedChanged);
            this.rbtnCNPJ.MouseLeave += new System.EventHandler(this.rbtnCNPJ_MouseLeave);
            this.rbtnCNPJ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCNPJ_MouseMove);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(6, 78);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 18;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyDown);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(346, 42);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavraChave.TabIndex = 9;
            this.rbtnPalavraChave.TabStop = true;
            this.rbtnPalavraChave.Text = "Palavra-Chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(447, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 10;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnCPFResponsavel
            // 
            this.rbtnCPFResponsavel.AutoSize = true;
            this.rbtnCPFResponsavel.Location = new System.Drawing.Point(251, 42);
            this.rbtnCPFResponsavel.Name = "rbtnCPFResponsavel";
            this.rbtnCPFResponsavel.Size = new System.Drawing.Size(89, 17);
            this.rbtnCPFResponsavel.TabIndex = 8;
            this.rbtnCPFResponsavel.TabStop = true;
            this.rbtnCPFResponsavel.Text = "CPF Pai/Mãe";
            this.rbtnCPFResponsavel.UseVisualStyleBackColor = true;
            this.rbtnCPFResponsavel.CheckedChanged += new System.EventHandler(this.rbtnCPFResponsavel_CheckedChanged);
            this.rbtnCPFResponsavel.MouseLeave += new System.EventHandler(this.rbtnCPFResponsavel_MouseLeave);
            this.rbtnCPFResponsavel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCPFResponsavel_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(133, 19);
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
            // rbtnNome
            // 
            this.rbtnNome.AutoSize = true;
            this.rbtnNome.Location = new System.Drawing.Point(6, 19);
            this.rbtnNome.Name = "rbtnNome";
            this.rbtnNome.Size = new System.Drawing.Size(121, 17);
            this.rbtnNome.TabIndex = 2;
            this.rbtnNome.Text = "Nome/Razão Social";
            this.rbtnNome.UseVisualStyleBackColor = true;
            this.rbtnNome.CheckedChanged += new System.EventHandler(this.rbtnNome_CheckedChanged);
            this.rbtnNome.MouseLeave += new System.EventHandler(this.rbtnNome_MouseLeave);
            this.rbtnNome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNome_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(359, 19);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(163, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome/razão social:";
            // 
            // rbtnRG
            // 
            this.rbtnRG.AutoSize = true;
            this.rbtnRG.Location = new System.Drawing.Point(74, 42);
            this.rbtnRG.Name = "rbtnRG";
            this.rbtnRG.Size = new System.Drawing.Size(41, 17);
            this.rbtnRG.TabIndex = 6;
            this.rbtnRG.TabStop = true;
            this.rbtnRG.Text = "RG";
            this.rbtnRG.UseVisualStyleBackColor = true;
            this.rbtnRG.CheckedChanged += new System.EventHandler(this.rbtnRG_CheckedChanged);
            this.rbtnRG.MouseLeave += new System.EventHandler(this.rbtnRG_MouseLeave);
            this.rbtnRG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnRG_MouseMove);
            // 
            // rbtnCPF
            // 
            this.rbtnCPF.AutoSize = true;
            this.rbtnCPF.Location = new System.Drawing.Point(197, 19);
            this.rbtnCPF.Name = "rbtnCPF";
            this.rbtnCPF.Size = new System.Drawing.Size(45, 17);
            this.rbtnCPF.TabIndex = 4;
            this.rbtnCPF.TabStop = true;
            this.rbtnCPF.Text = "CPF";
            this.rbtnCPF.UseVisualStyleBackColor = true;
            this.rbtnCPF.CheckedChanged += new System.EventHandler(this.rbtnCPF_CheckedChanged);
            this.rbtnCPF.MouseLeave += new System.EventHandler(this.rbtnCPF_MouseLeave);
            this.rbtnCPF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCPF_MouseMove);
            // 
            // txtpPalavraChave
            // 
            this.txtpPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtpPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpPalavraChave.Location = new System.Drawing.Point(737, 16);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(78, 20);
            this.txtpPalavraChave.TabIndex = 15;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // mtxtpCPF
            // 
            this.mtxtpCPF.BackColor = System.Drawing.Color.White;
            this.mtxtpCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpCPF.Location = new System.Drawing.Point(720, 16);
            this.mtxtpCPF.Mask = "000,000,000-00";
            this.mtxtpCPF.Name = "mtxtpCPF";
            this.mtxtpCPF.Size = new System.Drawing.Size(95, 20);
            this.mtxtpCPF.TabIndex = 13;
            this.mtxtpCPF.Visible = false;
            this.mtxtpCPF.Enter += new System.EventHandler(this.mtxtpCPF_Enter);
            this.mtxtpCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCPF_KeyPress);
            this.mtxtpCPF.Leave += new System.EventHandler(this.mtxtpCPF_Leave);
            // 
            // txtpRG
            // 
            this.txtpRG.BackColor = System.Drawing.Color.White;
            this.txtpRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpRG.Location = new System.Drawing.Point(695, 16);
            this.txtpRG.MaxLength = 20;
            this.txtpRG.Name = "txtpRG";
            this.txtpRG.Size = new System.Drawing.Size(120, 20);
            this.txtpRG.TabIndex = 12;
            this.txtpRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpRG.Visible = false;
            this.txtpRG.Enter += new System.EventHandler(this.txtpRG_Enter);
            this.txtpRG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpRG_KeyPress);
            this.txtpRG.Leave += new System.EventHandler(this.txtpRG_Leave);
            // 
            // txtpNome
            // 
            this.txtpNome.BackColor = System.Drawing.Color.White;
            this.txtpNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNome.Location = new System.Drawing.Point(528, 16);
            this.txtpNome.MaxLength = 60;
            this.txtpNome.Name = "txtpNome";
            this.txtpNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpNome.Size = new System.Drawing.Size(286, 20);
            this.txtpNome.TabIndex = 11;
            this.txtpNome.Enter += new System.EventHandler(this.txtpNome_Enter);
            this.txtpNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNome_KeyPress);
            this.txtpNome.Leave += new System.EventHandler(this.txtpNome_Leave);
            // 
            // mtxtpCNPJ
            // 
            this.mtxtpCNPJ.BackColor = System.Drawing.Color.White;
            this.mtxtpCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtpCNPJ.Location = new System.Drawing.Point(692, 16);
            this.mtxtpCNPJ.Mask = "00,000,000/0000-00";
            this.mtxtpCNPJ.Name = "mtxtpCNPJ";
            this.mtxtpCNPJ.Size = new System.Drawing.Size(123, 20);
            this.mtxtpCNPJ.TabIndex = 14;
            this.mtxtpCNPJ.Visible = false;
            this.mtxtpCNPJ.Enter += new System.EventHandler(this.mtxtpCNPJ_Enter);
            this.mtxtpCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCNPJ_KeyPress);
            this.mtxtpCNPJ.Leave += new System.EventHandler(this.mtxtpCNPJ_Leave);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(737, 16);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtpCodigo.TabIndex = 15;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(741, 208);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 35;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(767, 208);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 32;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // dtClie
            // 
            this.dtClie.AllowUserToAddRows = false;
            this.dtClie.AllowUserToDeleteRows = false;
            this.dtClie.AllowUserToOrderColumns = true;
            this.dtClie.AllowUserToResizeRows = false;
            this.dtClie.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtClie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtClie.Enabled = false;
            this.dtClie.Location = new System.Drawing.Point(193, 246);
            this.dtClie.MultiSelect = false;
            this.dtClie.Name = "dtClie";
            this.dtClie.ReadOnly = true;
            this.dtClie.RowHeadersVisible = false;
            this.dtClie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtClie.ShowCellErrors = false;
            this.dtClie.ShowCellToolTips = false;
            this.dtClie.ShowEditingIcon = false;
            this.dtClie.ShowRowErrors = false;
            this.dtClie.Size = new System.Drawing.Size(659, 172);
            this.dtClie.TabIndex = 33;
            this.dtClie.DataSourceChanged += new System.EventHandler(this.dtClie_DataSourceChanged);
            this.dtClie.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtClie_CellEnter);
            this.dtClie.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtClie_CellFormatting);
            this.dtClie.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtClie_RowsAdded);
            this.dtClie.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtClie_RowsRemoved);
            this.dtClie.MouseLeave += new System.EventHandler(this.dtClie_MouseLeave);
            this.dtClie.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtClie_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnInfDocumentos);
            this.grbBox2.Controls.Add(this.btnRelatorioCompleto);
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.btnRelatorioPDF);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(32, 424);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(820, 50);
            this.grbBox2.TabIndex = 34;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // btnInfDocumentos
            // 
            this.btnInfDocumentos.Image = ((System.Drawing.Image)(resources.GetObject("btnInfDocumentos.Image")));
            this.btnInfDocumentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfDocumentos.Location = new System.Drawing.Point(646, 19);
            this.btnInfDocumentos.Name = "btnInfDocumentos";
            this.btnInfDocumentos.Size = new System.Drawing.Size(168, 25);
            this.btnInfDocumentos.TabIndex = 39;
            this.btnInfDocumentos.Text = "Informações de D&ocumentos";
            this.btnInfDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnInfDocumentos, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnInfDocumentos.UseVisualStyleBackColor = true;
            this.btnInfDocumentos.Click += new System.EventHandler(this.button1_Click);
            this.btnInfDocumentos.MouseLeave += new System.EventHandler(this.btnDigitalizacaoDocumento_MouseLeave);
            this.btnInfDocumentos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDigitalizacaoDocumento_MouseMove);
            // 
            // btnRelatorioCompleto
            // 
            this.btnRelatorioCompleto.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioCompleto.Image")));
            this.btnRelatorioCompleto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioCompleto.Location = new System.Drawing.Point(151, 19);
            this.btnRelatorioCompleto.Name = "btnRelatorioCompleto";
            this.btnRelatorioCompleto.Size = new System.Drawing.Size(162, 25);
            this.btnRelatorioCompleto.TabIndex = 36;
            this.btnRelatorioCompleto.Text = "Relatório &Completo em PDF";
            this.btnRelatorioCompleto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnRelatorioCompleto, "Clique para imprimir o relatório completo da grade de dados em formato PDF.");
            this.btnRelatorioCompleto.UseVisualStyleBackColor = true;
            this.btnRelatorioCompleto.Click += new System.EventHandler(this.btnRelatorioCompleto_Click);
            this.btnRelatorioCompleto.MouseLeave += new System.EventHandler(this.btnRelatorioCompleto_MouseLeave);
            this.btnRelatorioCompleto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioCompleto_MouseMove);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(489, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 38;
            this.btnExportarCsv.Text = "Exp. &dados para (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // btnRelatorioPDF
            // 
            this.btnRelatorioPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioPDF.Image")));
            this.btnRelatorioPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioPDF.Location = new System.Drawing.Point(6, 19);
            this.btnRelatorioPDF.Name = "btnRelatorioPDF";
            this.btnRelatorioPDF.Size = new System.Drawing.Size(116, 25);
            this.btnRelatorioPDF.TabIndex = 35;
            this.btnRelatorioPDF.Text = "Relatório em PD&F";
            this.btnRelatorioPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnRelatorioPDF, "Clique para imprimir o relatório resumido da grade de dados em formato PDF.");
            this.btnRelatorioPDF.UseVisualStyleBackColor = true;
            this.btnRelatorioPDF.Click += new System.EventHandler(this.btnTodasContas_Click);
            this.btnRelatorioPDF.MouseLeave += new System.EventHandler(this.btnTodasContas_MouseLeave);
            this.btnRelatorioPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTodasContas_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(337, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 37;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(797, 480);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 40;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnSair, "Sair do Relatório de Clientes/Consumidores.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.Location = new System.Drawing.Point(32, 480);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 191;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(29, 379);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpCliente
            // 
            this.ttpCliente.AutoPopDelay = 5000;
            this.ttpCliente.InitialDelay = 1000;
            this.ttpCliente.IsBalloon = true;
            this.ttpCliente.ReshowDelay = 100;
            this.ttpCliente.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCliente.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(356, 287);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 0;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(346, 320);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 0;
            this.pgbProgresso.Visible = false;
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.picbInterrogacao3);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.dtClie);
            this.pEnabled.Controls.Add(this.lblLegendaImagem);
            this.pEnabled.Controls.Add(this.pcibImagem);
            this.pEnabled.Location = new System.Drawing.Point(-20, -41);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(891, 530);
            this.pEnabled.TabIndex = 192;
            // 
            // FrmRelClieCons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(844, 475);
            this.ControlBox = false;
            this.Controls.Add(this.pcibAjudaFoto);
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelClieCons";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Clientes/Consumidores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelCliente_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelCliente_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelCliente_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClie)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcibAjudaFoto;
        private System.Windows.Forms.Label lblLegendaImagem;
        private System.Windows.Forms.PictureBox pcibImagem;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnIE;
        private System.Windows.Forms.RadioButton rbtnCNPJ;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCPFResponsavel;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNome;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnRG;
        private System.Windows.Forms.RadioButton rbtnCPF;
        private System.Windows.Forms.TextBox txtpRG;
        private System.Windows.Forms.TextBox txtpNome;
        private System.Windows.Forms.MaskedTextBox mtxtpCNPJ;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpCPF;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.DataGridView dtClie;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.ComboBox cbbCidade;
        private System.Windows.Forms.ComboBox cbbUF;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.ToolTip ttpCliente;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.MaskedTextBox mtxtpCelular;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.MaskedTextBox mtxtpTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtpEmail;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button btnRelatorioPDF;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.ComboBox cbbpTipo;
        private System.Windows.Forms.Label lblTipoPessoa;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblCPFAvalista;
        private System.Windows.Forms.Label lblNomeAvalista;
        private System.Windows.Forms.TextBox txtNomeAvalista;
        private System.Windows.Forms.MaskedTextBox mtxtCPFAvalista;
        private System.Windows.Forms.Button btnRelatorioCompleto;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Button btnInfDocumentos;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Label lblGrupos;
        private System.Windows.Forms.Button btnProcurarGrupo;
        private System.Windows.Forms.ComboBox cbbpGrupo;
        private System.Windows.Forms.Label lblSubgrupos;
        private System.Windows.Forms.Button btnProcurarSubgrupo;
        private System.Windows.Forms.ComboBox cbbpSubGrupo;
        private System.Windows.Forms.Panel pEnabled;
    }
}