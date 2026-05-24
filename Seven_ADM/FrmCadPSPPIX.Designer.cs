namespace Seven_Sistema
{
    partial class FrmCadPSPPIX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadPSPPIX));
            this.ttpPSPPIX = new System.Windows.Forms.ToolTip(this.components);
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.cbbNomePSP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNome_Desc = new System.Windows.Forms.Label();
            this.txtChavePIX = new System.Windows.Forms.TextBox();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.lblAsterisco6 = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.cbbCidade = new System.Windows.Forms.ComboBox();
            this.lblAsterisco5 = new System.Windows.Forms.Label();
            this.lblUF = new System.Windows.Forms.Label();
            this.cbbUF = new System.Windows.Forms.ComboBox();
            this.lblAsterisco7 = new System.Windows.Forms.Label();
            this.lblCEP = new System.Windows.Forms.Label();
            this.mtxtCEP = new System.Windows.Forms.MaskedTextBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.cbbAmbiente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcessToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTipoChave = new System.Windows.Forms.ComboBox();
            this.lblCodigoCompe = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtPSP = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.rbtnPIX = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnPSP = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.cbbpTipoChave = new System.Windows.Forms.ComboBox();
            this.cbbpPSP = new System.Windows.Forms.ComboBox();
            this.btnGerarPIXCopiaCola = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.pPanel = new System.Windows.Forms.Panel();
            this.grbBox2.SuspendLayout();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPSP)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.pPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpPSPPIX
            // 
            this.ttpPSPPIX.AutoPopDelay = 5000;
            this.ttpPSPPIX.InitialDelay = 1000;
            this.ttpPSPPIX.IsBalloon = true;
            this.ttpPSPPIX.ReshowDelay = 100;
            this.ttpPSPPIX.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPSPPIX.ToolTipTitle = "Dica:";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovo.Location = new System.Drawing.Point(56, 516);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 25;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnNovo, "Cadastrar um novo PSP/PIX.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAlterar.Location = new System.Drawing.Point(132, 516);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 26;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnAlterar, "Alterar um PSP/PIX cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcluir.Location = new System.Drawing.Point(208, 516);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 27;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnExcluir, "Excluir um PSP/PIX cadastrado.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluir_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(454, 516);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 29;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(532, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 8;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(363, 516);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(596, 516);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 30;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnSair, "Sair do Cadastro de PSP/PIX.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.cbbNomePSP);
            this.grbBox2.Controls.Add(this.label6);
            this.grbBox2.Controls.Add(this.lblNome_Desc);
            this.grbBox2.Controls.Add(this.txtChavePIX);
            this.grbBox2.Controls.Add(this.grbBox3);
            this.grbBox2.Controls.Add(this.label9);
            this.grbBox2.Controls.Add(this.label7);
            this.grbBox2.Controls.Add(this.label10);
            this.grbBox2.Controls.Add(this.label8);
            this.grbBox2.Controls.Add(this.txtTimeout);
            this.grbBox2.Controls.Add(this.cbbAmbiente);
            this.grbBox2.Controls.Add(this.label4);
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.txtAcessToken);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.cbbTipoChave);
            this.grbBox2.Controls.Add(this.lblCodigoCompe);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox2.Location = new System.Drawing.Point(30, 342);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(620, 168);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // cbbNomePSP
            // 
            this.cbbNomePSP.BackColor = System.Drawing.Color.LightBlue;
            this.cbbNomePSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNomePSP.DropDownWidth = 151;
            this.cbbNomePSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNomePSP.FormattingEnabled = true;
            this.cbbNomePSP.Items.AddRange(new object[] {
            "MERCADO PAGO",
            "INTER"});
            this.cbbNomePSP.Location = new System.Drawing.Point(55, 32);
            this.cbbNomePSP.Name = "cbbNomePSP";
            this.cbbNomePSP.Size = new System.Drawing.Size(151, 21);
            this.cbbNomePSP.TabIndex = 14;
            this.cbbNomePSP.DropDown += new System.EventHandler(this.cbbNomePSP_DropDown);
            this.cbbNomePSP.DropDownClosed += new System.EventHandler(this.cbbNomePSP_DropDownClosed);
            this.cbbNomePSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbNomePSP_KeyPress);
            this.cbbNomePSP.MouseLeave += new System.EventHandler(this.cbbNomePSP_MouseLeave);
            this.cbbNomePSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbNomePSP_MouseMove);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(265, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "*";
            // 
            // lblNome_Desc
            // 
            this.lblNome_Desc.AutoSize = true;
            this.lblNome_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome_Desc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNome_Desc.Location = new System.Drawing.Point(209, 16);
            this.lblNome_Desc.Name = "lblNome_Desc";
            this.lblNome_Desc.Size = new System.Drawing.Size(61, 13);
            this.lblNome_Desc.TabIndex = 0;
            this.lblNome_Desc.Text = "Chave PIX:";
            // 
            // txtChavePIX
            // 
            this.txtChavePIX.BackColor = System.Drawing.Color.White;
            this.txtChavePIX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtChavePIX.Location = new System.Drawing.Point(212, 33);
            this.txtChavePIX.MaxLength = 60;
            this.txtChavePIX.Name = "txtChavePIX";
            this.txtChavePIX.Size = new System.Drawing.Size(281, 20);
            this.txtChavePIX.TabIndex = 15;
            this.txtChavePIX.Enter += new System.EventHandler(this.txtChavePIX_Enter);
            this.txtChavePIX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChavePIX_KeyPress);
            this.txtChavePIX.Leave += new System.EventHandler(this.txtChavePIX_Leave);
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.lblAsterisco6);
            this.grbBox3.Controls.Add(this.lblCidade);
            this.grbBox3.Controls.Add(this.cbbCidade);
            this.grbBox3.Controls.Add(this.lblAsterisco5);
            this.grbBox3.Controls.Add(this.lblUF);
            this.grbBox3.Controls.Add(this.cbbUF);
            this.grbBox3.Controls.Add(this.lblAsterisco7);
            this.grbBox3.Controls.Add(this.lblCEP);
            this.grbBox3.Controls.Add(this.mtxtCEP);
            this.grbBox3.Controls.Add(this.lblAsterisco1);
            this.grbBox3.Controls.Add(this.txtNome);
            this.grbBox3.Controls.Add(this.lblNome);
            this.grbBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox3.Location = new System.Drawing.Point(6, 98);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(608, 62);
            this.grbBox3.TabIndex = 20;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Recebedor:";
            this.grbBox3.Enter += new System.EventHandler(this.grbBox3_Enter);
            // 
            // lblAsterisco6
            // 
            this.lblAsterisco6.AutoSize = true;
            this.lblAsterisco6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco6.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco6.Location = new System.Drawing.Point(371, 14);
            this.lblAsterisco6.Name = "lblAsterisco6";
            this.lblAsterisco6.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco6.TabIndex = 0;
            this.lblAsterisco6.Text = "*";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(333, 16);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(43, 13);
            this.lblCidade.TabIndex = 0;
            this.lblCidade.Text = "Cidade:";
            // 
            // cbbCidade
            // 
            this.cbbCidade.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCidade.DropDownWidth = 325;
            this.cbbCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbCidade.FormattingEnabled = true;
            this.cbbCidade.Location = new System.Drawing.Point(336, 32);
            this.cbbCidade.Name = "cbbCidade";
            this.cbbCidade.Size = new System.Drawing.Size(189, 21);
            this.cbbCidade.TabIndex = 23;
            this.cbbCidade.DropDown += new System.EventHandler(this.cbbCidade_DropDown);
            this.cbbCidade.DropDownClosed += new System.EventHandler(this.cbbCidade_DropDownClosed);
            this.cbbCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCidade_KeyPress);
            this.cbbCidade.MouseLeave += new System.EventHandler(this.cbbCidade_MouseLeave);
            this.cbbCidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCidade_MouseMove);
            // 
            // lblAsterisco5
            // 
            this.lblAsterisco5.AutoSize = true;
            this.lblAsterisco5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco5.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco5.Location = new System.Drawing.Point(301, 14);
            this.lblAsterisco5.Name = "lblAsterisco5";
            this.lblAsterisco5.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco5.TabIndex = 0;
            this.lblAsterisco5.Text = "*";
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Location = new System.Drawing.Point(282, 16);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(24, 13);
            this.lblUF.TabIndex = 0;
            this.lblUF.Text = "UF:";
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
            this.cbbUF.Location = new System.Drawing.Point(285, 32);
            this.cbbUF.Name = "cbbUF";
            this.cbbUF.Size = new System.Drawing.Size(45, 21);
            this.cbbUF.TabIndex = 22;
            this.cbbUF.DropDown += new System.EventHandler(this.cbbUF_DropDown);
            this.cbbUF.SelectedIndexChanged += new System.EventHandler(this.cbbUF_SelectedIndexChanged);
            this.cbbUF.DropDownClosed += new System.EventHandler(this.cbbUF_DropDownClosed);
            this.cbbUF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUF_KeyPress);
            this.cbbUF.MouseLeave += new System.EventHandler(this.cbbUF_MouseLeave);
            this.cbbUF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUF_MouseMove);
            // 
            // lblAsterisco7
            // 
            this.lblAsterisco7.AutoSize = true;
            this.lblAsterisco7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco7.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco7.Location = new System.Drawing.Point(555, 14);
            this.lblAsterisco7.Name = "lblAsterisco7";
            this.lblAsterisco7.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco7.TabIndex = 0;
            this.lblAsterisco7.Text = "*";
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(528, 17);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(31, 13);
            this.lblCEP.TabIndex = 0;
            this.lblCEP.Text = "CEP:";
            // 
            // mtxtCEP
            // 
            this.mtxtCEP.BackColor = System.Drawing.Color.White;
            this.mtxtCEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCEP.Location = new System.Drawing.Point(531, 32);
            this.mtxtCEP.Mask = "00,000-000";
            this.mtxtCEP.Name = "mtxtCEP";
            this.mtxtCEP.Size = new System.Drawing.Size(70, 20);
            this.mtxtCEP.TabIndex = 24;
            this.mtxtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtCEP.Enter += new System.EventHandler(this.mtxtCEP_Enter);
            this.mtxtCEP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCEP_KeyPress);
            this.mtxtCEP.Leave += new System.EventHandler(this.mtxtCEP_Leave);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(110, 14);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(7, 32);
            this.txtNome.MaxLength = 60;
            this.txtNome.Name = "txtNome";
            this.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNome.Size = new System.Drawing.Size(272, 20);
            this.txtNome.TabIndex = 21;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 16);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(109, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome do Recebedor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(577, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(405, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(534, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Timeout:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(356, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ambiente:";
            // 
            // txtTimeout
            // 
            this.txtTimeout.BackColor = System.Drawing.Color.White;
            this.txtTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTimeout.Location = new System.Drawing.Point(537, 72);
            this.txtTimeout.MaxLength = 8;
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(77, 20);
            this.txtTimeout.TabIndex = 19;
            this.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeout.Enter += new System.EventHandler(this.txtTimeout_Enter);
            this.txtTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeout_KeyPress);
            this.txtTimeout.Leave += new System.EventHandler(this.txtTimeout_Leave);
            // 
            // cbbAmbiente
            // 
            this.cbbAmbiente.BackColor = System.Drawing.Color.LightBlue;
            this.cbbAmbiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAmbiente.DropDownWidth = 550;
            this.cbbAmbiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAmbiente.FormattingEnabled = true;
            this.cbbAmbiente.Items.AddRange(new object[] {
            "PRÉ-PRODUÇÃO",
            "PRODUÇÃO",
            "TESTE"});
            this.cbbAmbiente.Location = new System.Drawing.Point(356, 72);
            this.cbbAmbiente.Name = "cbbAmbiente";
            this.cbbAmbiente.Size = new System.Drawing.Size(175, 21);
            this.cbbAmbiente.TabIndex = 18;
            this.cbbAmbiente.DropDown += new System.EventHandler(this.cbbAmbiente_DropDown);
            this.cbbAmbiente.DropDownClosed += new System.EventHandler(this.cbbAmbiente_DropDownClosed);
            this.cbbAmbiente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbAmbiente_KeyPress);
            this.cbbAmbiente.MouseLeave += new System.EventHandler(this.cbbAmbiente_MouseLeave);
            this.cbbAmbiente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbAmbiente_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(571, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Access-Token:";
            // 
            // txtAcessToken
            // 
            this.txtAcessToken.BackColor = System.Drawing.Color.White;
            this.txtAcessToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAcessToken.Location = new System.Drawing.Point(6, 72);
            this.txtAcessToken.MaxLength = 60;
            this.txtAcessToken.Name = "txtAcessToken";
            this.txtAcessToken.Size = new System.Drawing.Size(344, 20);
            this.txtAcessToken.TabIndex = 17;
            this.txtAcessToken.Enter += new System.EventHandler(this.txtAcessToken_Enter);
            this.txtAcessToken.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcessToken_KeyPress);
            this.txtAcessToken.Leave += new System.EventHandler(this.txtAcessToken_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(124, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(496, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Chave:";
            // 
            // cbbTipoChave
            // 
            this.cbbTipoChave.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoChave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoChave.DropDownWidth = 115;
            this.cbbTipoChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoChave.FormattingEnabled = true;
            this.cbbTipoChave.Items.AddRange(new object[] {
            "ALEATORIA",
            "CELULAR",
            "CNPJ",
            "CPF",
            "EMAIL"});
            this.cbbTipoChave.Location = new System.Drawing.Point(499, 31);
            this.cbbTipoChave.Name = "cbbTipoChave";
            this.cbbTipoChave.Size = new System.Drawing.Size(115, 21);
            this.cbbTipoChave.TabIndex = 16;
            this.cbbTipoChave.DropDown += new System.EventHandler(this.cbbTipoChave_DropDown);
            this.cbbTipoChave.SelectedIndexChanged += new System.EventHandler(this.cbbTipoChave_SelectedIndexChanged);
            this.cbbTipoChave.DropDownClosed += new System.EventHandler(this.cbbTipoChave_DropDownClosed);
            this.cbbTipoChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipoChave_KeyPress);
            this.cbbTipoChave.MouseLeave += new System.EventHandler(this.cbbTipoChave_MouseLeave);
            this.cbbTipoChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoChave_MouseMove);
            // 
            // lblCodigoCompe
            // 
            this.lblCodigoCompe.AutoSize = true;
            this.lblCodigoCompe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCompe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigoCompe.Location = new System.Drawing.Point(52, 16);
            this.lblCodigoCompe.Name = "lblCodigoCompe";
            this.lblCodigoCompe.Size = new System.Drawing.Size(77, 13);
            this.lblCodigoCompe.TabIndex = 0;
            this.lblCodigoCompe.Text = "Nome do PSP:";
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
            this.txtCodigo.TabIndex = 13;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
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
            this.lblRegistros.Location = new System.Drawing.Point(490, 308);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 16);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtPSP
            // 
            this.dtPSP.AllowUserToAddRows = false;
            this.dtPSP.AllowUserToDeleteRows = false;
            this.dtPSP.AllowUserToResizeRows = false;
            this.dtPSP.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtPSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPSP.Enabled = false;
            this.dtPSP.Location = new System.Drawing.Point(30, 133);
            this.dtPSP.MultiSelect = false;
            this.dtPSP.Name = "dtPSP";
            this.dtPSP.ReadOnly = true;
            this.dtPSP.RowHeadersVisible = false;
            this.dtPSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPSP.ShowCellErrors = false;
            this.dtPSP.ShowCellToolTips = false;
            this.dtPSP.ShowEditingIcon = false;
            this.dtPSP.ShowRowErrors = false;
            this.dtPSP.Size = new System.Drawing.Size(620, 172);
            this.dtPSP.TabIndex = 9;
            this.dtPSP.DataSourceChanged += new System.EventHandler(this.dtPSP_DataSourceChanged);
            this.dtPSP.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPSP_CellEnter);
            this.dtPSP.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtPSP_RowsAdded);
            this.dtPSP.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtPSP_RowsRemoved);
            this.dtPSP.MouseLeave += new System.EventHandler(this.dtPSP_MouseLeave);
            this.dtPSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtPSP_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.rbtnPIX);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnPSP);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.cbbpTipoChave);
            this.grbBox1.Controls.Add(this.cbbpPSP);
            this.grbBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox1.Location = new System.Drawing.Point(30, 48);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(620, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(107, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.TabStop = true;
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
            this.lblPesquisar.Location = new System.Drawing.Point(223, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(95, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Escolha o PSP:";
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(506, 44);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // rbtnPIX
            // 
            this.rbtnPIX.AutoSize = true;
            this.rbtnPIX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPIX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPIX.Location = new System.Drawing.Point(7, 42);
            this.rbtnPIX.Name = "rbtnPIX";
            this.rbtnPIX.Size = new System.Drawing.Size(95, 17);
            this.rbtnPIX.TabIndex = 3;
            this.rbtnPIX.TabStop = true;
            this.rbtnPIX.Text = "Tipo de Chave";
            this.rbtnPIX.UseVisualStyleBackColor = true;
            this.rbtnPIX.CheckedChanged += new System.EventHandler(this.rbtnPIX_CheckedChanged);
            this.rbtnPIX.MouseLeave += new System.EventHandler(this.rbtnPIX_MouseLeave);
            this.rbtnPIX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPIX_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(107, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnPSP
            // 
            this.rbtnPSP.AutoSize = true;
            this.rbtnPSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPSP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPSP.Location = new System.Drawing.Point(6, 19);
            this.rbtnPSP.Name = "rbtnPSP";
            this.rbtnPSP.Size = new System.Drawing.Size(46, 17);
            this.rbtnPSP.TabIndex = 1;
            this.rbtnPSP.Text = "PSP";
            this.rbtnPSP.UseVisualStyleBackColor = true;
            this.rbtnPSP.CheckedChanged += new System.EventHandler(this.rbtnPSP_CheckedChanged);
            this.rbtnPSP.MouseLeave += new System.EventHandler(this.rbtnPSP_MouseLeave);
            this.rbtnPSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPSP_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(572, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(42, 20);
            this.txtpCodigo.TabIndex = 7;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // cbbpTipoChave
            // 
            this.cbbpTipoChave.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipoChave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipoChave.DropDownWidth = 115;
            this.cbbpTipoChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipoChave.FormattingEnabled = true;
            this.cbbpTipoChave.Items.AddRange(new object[] {
            "",
            "ALEATORIA",
            "CELULAR",
            "CNPJ",
            "CPF",
            "EMAIL"});
            this.cbbpTipoChave.Location = new System.Drawing.Point(499, 17);
            this.cbbpTipoChave.Name = "cbbpTipoChave";
            this.cbbpTipoChave.Size = new System.Drawing.Size(115, 21);
            this.cbbpTipoChave.TabIndex = 6;
            this.cbbpTipoChave.DropDown += new System.EventHandler(this.cbbpTipoChave_DropDown);
            this.cbbpTipoChave.DropDownClosed += new System.EventHandler(this.cbbpTipoChave_DropDownClosed);
            this.cbbpTipoChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipoChave_KeyPress);
            this.cbbpTipoChave.MouseLeave += new System.EventHandler(this.cbbpTipoChave_MouseLeave);
            this.cbbpTipoChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTipoChave_MouseMove);
            // 
            // cbbpPSP
            // 
            this.cbbpPSP.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpPSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpPSP.DropDownWidth = 290;
            this.cbbpPSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbpPSP.FormattingEnabled = true;
            this.cbbpPSP.Items.AddRange(new object[] {
            "",
            "MERCADO PAGO"});
            this.cbbpPSP.Location = new System.Drawing.Point(324, 17);
            this.cbbpPSP.Name = "cbbpPSP";
            this.cbbpPSP.Size = new System.Drawing.Size(290, 21);
            this.cbbpPSP.TabIndex = 5;
            this.cbbpPSP.DropDown += new System.EventHandler(this.cbbpPSP_DropDown);
            this.cbbpPSP.DropDownClosed += new System.EventHandler(this.cbbpPSP_DropDownClosed);
            this.cbbpPSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpPSP_KeyPress);
            this.cbbpPSP.MouseLeave += new System.EventHandler(this.cbbpPSP_MouseLeave);
            this.cbbpPSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpPSP_MouseMove);
            // 
            // btnGerarPIXCopiaCola
            // 
            this.btnGerarPIXCopiaCola.Enabled = false;
            this.btnGerarPIXCopiaCola.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarPIXCopiaCola.Image")));
            this.btnGerarPIXCopiaCola.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGerarPIXCopiaCola.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGerarPIXCopiaCola.Location = new System.Drawing.Point(30, 311);
            this.btnGerarPIXCopiaCola.Name = "btnGerarPIXCopiaCola";
            this.btnGerarPIXCopiaCola.Size = new System.Drawing.Size(184, 25);
            this.btnGerarPIXCopiaCola.TabIndex = 10;
            this.btnGerarPIXCopiaCola.Text = "Gerar &PIX Estático Copia e Cola";
            this.btnGerarPIXCopiaCola.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarPIXCopiaCola.UseVisualStyleBackColor = true;
            this.btnGerarPIXCopiaCola.Click += new System.EventHandler(this.btnGerarPIXCopiaCola_Click);
            this.btnGerarPIXCopiaCola.MouseLeave += new System.EventHandler(this.btnGerarPIXCopiaCola_MouseLeave);
            this.btnGerarPIXCopiaCola.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGerarPIXCopiaCola_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(30, 516);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 113;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // pPanel
            // 
            this.pPanel.Controls.Add(this.picbInterrogacao);
            this.pPanel.Controls.Add(this.btnSair);
            this.pPanel.Controls.Add(this.btnGerarPIXCopiaCola);
            this.pPanel.Controls.Add(this.btnCancelar);
            this.pPanel.Controls.Add(this.grbBox1);
            this.pPanel.Controls.Add(this.btnSalvar);
            this.pPanel.Controls.Add(this.dtPSP);
            this.pPanel.Controls.Add(this.btnExcluir);
            this.pPanel.Controls.Add(this.lblRegistros);
            this.pPanel.Controls.Add(this.btnAlterar);
            this.pPanel.Controls.Add(this.grbBox2);
            this.pPanel.Controls.Add(this.btnNovo);
            this.pPanel.Location = new System.Drawing.Point(-18, -36);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(681, 599);
            this.pPanel.TabIndex = 114;
            // 
            // FrmCadPSPPIX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(644, 517);
            this.ControlBox = false;
            this.Controls.Add(this.pPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadPSPPIX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de PSP/PIX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadPSPPIX_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadPSPPIX_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadPSPPIX_KeyUp);
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPSP)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.pPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpPSPPIX;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.ComboBox cbbNomePSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNome_Desc;
        private System.Windows.Forms.TextBox txtChavePIX;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.Label lblAsterisco6;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.ComboBox cbbCidade;
        private System.Windows.Forms.Label lblAsterisco5;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.ComboBox cbbUF;
        private System.Windows.Forms.Label lblAsterisco7;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.MaskedTextBox mtxtCEP;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.ComboBox cbbAmbiente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAcessToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbTipoChave;
        private System.Windows.Forms.Label lblCodigoCompe;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dtPSP;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnPIX;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnPSP;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.ComboBox cbbpTipoChave;
        private System.Windows.Forms.ComboBox cbbpPSP;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGerarPIXCopiaCola;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Panel pPanel;
    }
}