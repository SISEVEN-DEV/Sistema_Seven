namespace Seven_Sistema
{
    partial class FrmRelAniversario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelAniversario));
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnEnviarZAP = new System.Windows.Forms.Button();
            this.btnRelatorioPDF = new System.Windows.Forms.Button();
            this.btnEnviarSMS = new System.Windows.Forms.Button();
            this.btnCriarLembrete = new System.Windows.Forms.Button();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.ttpAniversariante = new System.Windows.Forms.ToolTip(this.components);
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnProcurarAniversariante = new System.Windows.Forms.Button();
            this.btnSelecionarData1 = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnAniversariante = new System.Windows.Forms.RadioButton();
            this.cbbTipoAniversariante = new System.Windows.Forms.ComboBox();
            this.lblAte1 = new System.Windows.Forms.Label();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnData = new System.Windows.Forms.RadioButton();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.cbbAniversariante = new System.Windows.Forms.ComboBox();
            this.dtAniversario = new System.Windows.Forms.DataGridView();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAniversario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnEnviarZAP);
            this.grbBox2.Controls.Add(this.btnRelatorioPDF);
            this.grbBox2.Controls.Add(this.btnEnviarSMS);
            this.grbBox2.Controls.Add(this.btnCriarLembrete);
            this.grbBox2.Controls.Add(this.btnEnviarEmail);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(24, 425);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(760, 52);
            this.grbBox2.TabIndex = 192;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações:";
            // 
            // btnEnviarZAP
            // 
            this.btnEnviarZAP.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarZAP.Image")));
            this.btnEnviarZAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarZAP.Location = new System.Drawing.Point(463, 19);
            this.btnEnviarZAP.Name = "btnEnviarZAP";
            this.btnEnviarZAP.Size = new System.Drawing.Size(89, 25);
            this.btnEnviarZAP.TabIndex = 201;
            this.btnEnviarZAP.Text = "Enviar &ZAP";
            this.btnEnviarZAP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnEnviarZAP, "Clique para enviar um whatsapp.");
            this.btnEnviarZAP.UseVisualStyleBackColor = true;
            this.btnEnviarZAP.Click += new System.EventHandler(this.btnEnviarZAP_Click);
            this.btnEnviarZAP.MouseLeave += new System.EventHandler(this.btnEnviarZAP_MouseLeave);
            this.btnEnviarZAP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEnviarZAP_MouseMove);
            // 
            // btnRelatorioPDF
            // 
            this.btnRelatorioPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioPDF.Image")));
            this.btnRelatorioPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioPDF.Location = new System.Drawing.Point(638, 19);
            this.btnRelatorioPDF.Name = "btnRelatorioPDF";
            this.btnRelatorioPDF.Size = new System.Drawing.Size(116, 25);
            this.btnRelatorioPDF.TabIndex = 200;
            this.btnRelatorioPDF.Text = "Relatório em PD&F";
            this.btnRelatorioPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnRelatorioPDF, "Relatório das Informações em PDF");
            this.btnRelatorioPDF.UseVisualStyleBackColor = true;
            this.btnRelatorioPDF.Click += new System.EventHandler(this.btnRelatorioPDF_Click);
            this.btnRelatorioPDF.MouseLeave += new System.EventHandler(this.btnRelatorioPDF_MouseLeave);
            this.btnRelatorioPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioPDF_MouseMove);
            // 
            // btnEnviarSMS
            // 
            this.btnEnviarSMS.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarSMS.Image")));
            this.btnEnviarSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarSMS.Location = new System.Drawing.Point(294, 19);
            this.btnEnviarSMS.Name = "btnEnviarSMS";
            this.btnEnviarSMS.Size = new System.Drawing.Size(95, 25);
            this.btnEnviarSMS.TabIndex = 198;
            this.btnEnviarSMS.Text = "&Enviar &SMS";
            this.btnEnviarSMS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnEnviarSMS, "Clique para enviar um sms.");
            this.btnEnviarSMS.UseVisualStyleBackColor = true;
            this.btnEnviarSMS.Click += new System.EventHandler(this.btnEnviarSMS_Click);
            this.btnEnviarSMS.MouseLeave += new System.EventHandler(this.btnEnviarSMS_MouseLeave);
            this.btnEnviarSMS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEnviarSMS_MouseMove);
            // 
            // btnCriarLembrete
            // 
            this.btnCriarLembrete.Image = ((System.Drawing.Image)(resources.GetObject("btnCriarLembrete.Image")));
            this.btnCriarLembrete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCriarLembrete.Location = new System.Drawing.Point(6, 19);
            this.btnCriarLembrete.Name = "btnCriarLembrete";
            this.btnCriarLembrete.Size = new System.Drawing.Size(100, 25);
            this.btnCriarLembrete.TabIndex = 197;
            this.btnCriarLembrete.Text = "&Criar lembrete";
            this.btnCriarLembrete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnCriarLembrete, "Clique para criar um lembrete.");
            this.btnCriarLembrete.UseVisualStyleBackColor = true;
            this.btnCriarLembrete.Click += new System.EventHandler(this.btnCriarLembrete_Click);
            this.btnCriarLembrete.MouseLeave += new System.EventHandler(this.btnCriarLembrete_MouseLeave);
            this.btnCriarLembrete.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCriarLembrete_MouseMove);
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarEmail.Image")));
            this.btnEnviarEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarEmail.Location = new System.Drawing.Point(140, 19);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(100, 25);
            this.btnEnviarEmail.TabIndex = 23;
            this.btnEnviarEmail.Text = "&Enviar E-mail";
            this.btnEnviarEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnEnviarEmail, "Clique para enviar e-mail.");
            this.btnEnviarEmail.UseVisualStyleBackColor = true;
            this.btnEnviarEmail.Click += new System.EventHandler(this.btnEnviarEmail_Click);
            this.btnEnviarEmail.MouseLeave += new System.EventHandler(this.btnEnviarEmail_MouseLeave);
            this.btnEnviarEmail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEnviarEmail_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(24, 396);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 191;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(729, 483);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 197;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnSair, "Sair do relatório de aniversáriantes.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.Location = new System.Drawing.Point(24, 483);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 198;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // ttpAniversariante
            // 
            this.ttpAniversariante.AutoPopDelay = 5000;
            this.ttpAniversariante.InitialDelay = 1000;
            this.ttpAniversariante.IsBalloon = true;
            this.ttpAniversariante.ReshowDelay = 100;
            this.ttpAniversariante.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAniversariante.ToolTipTitle = "Dica:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(702, 106);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 228;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnProcurarAniversariante
            // 
            this.btnProcurarAniversariante.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarAniversariante.Image")));
            this.btnProcurarAniversariante.Location = new System.Drawing.Point(728, 15);
            this.btnProcurarAniversariante.Name = "btnProcurarAniversariante";
            this.btnProcurarAniversariante.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarAniversariante.TabIndex = 20;
            this.btnProcurarAniversariante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnProcurarAniversariante, "Clique para pesquisar um Aniversariante.");
            this.btnProcurarAniversariante.UseVisualStyleBackColor = true;
            this.btnProcurarAniversariante.Click += new System.EventHandler(this.btnProcurarEmitDest_Click);
            this.btnProcurarAniversariante.MouseLeave += new System.EventHandler(this.btnProcurarEmitDest_MouseLeave);
            this.btnProcurarAniversariante.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarEmitDest_MouseMove);
            // 
            // btnSelecionarData1
            // 
            this.btnSelecionarData1.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData1.Image")));
            this.btnSelecionarData1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData1.Location = new System.Drawing.Point(728, 15);
            this.btnSelecionarData1.Name = "btnSelecionarData1";
            this.btnSelecionarData1.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData1.TabIndex = 14;
            this.btnSelecionarData1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAniversariante.SetToolTip(this.btnSelecionarData1, "Clique para selecionar as datas.");
            this.btnSelecionarData1.UseVisualStyleBackColor = true;
            this.btnSelecionarData1.Click += new System.EventHandler(this.btnSelecionarData1_Click);
            this.btnSelecionarData1.MouseLeave += new System.EventHandler(this.btnSelecionarData1_MouseLeave);
            this.btnSelecionarData1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData1_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnAniversariante);
            this.grbBox1.Controls.Add(this.cbbTipoAniversariante);
            this.grbBox1.Controls.Add(this.lblAte1);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnData);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.cbbAniversariante);
            this.grbBox1.Controls.Add(this.btnSelecionarData1);
            this.grbBox1.Controls.Add(this.btnProcurarAniversariante);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Location = new System.Drawing.Point(24, 50);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 50);
            this.grbBox1.TabIndex = 230;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            this.grbBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbtnAniversariante
            // 
            this.rbtnAniversariante.AutoSize = true;
            this.rbtnAniversariante.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnAniversariante.Location = new System.Drawing.Point(6, 19);
            this.rbtnAniversariante.Name = "rbtnAniversariante";
            this.rbtnAniversariante.Size = new System.Drawing.Size(92, 17);
            this.rbtnAniversariante.TabIndex = 52;
            this.rbtnAniversariante.TabStop = true;
            this.rbtnAniversariante.Text = "Aniversariante";
            this.rbtnAniversariante.UseVisualStyleBackColor = true;
            this.rbtnAniversariante.CheckedChanged += new System.EventHandler(this.rbtnAniversariante_CheckedChanged);
            this.rbtnAniversariante.MouseLeave += new System.EventHandler(this.rbtnAniversariante_MouseLeave);
            this.rbtnAniversariante.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnAniversariante_MouseMove);
            // 
            // cbbTipoAniversariante
            // 
            this.cbbTipoAniversariante.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoAniversariante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoAniversariante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoAniversariante.FormattingEnabled = true;
            this.cbbTipoAniversariante.Items.AddRange(new object[] {
            "",
            "CLIENTES",
            "FORNECEDORES",
            "FUNCIONARIOS"});
            this.cbbTipoAniversariante.Location = new System.Drawing.Point(391, 17);
            this.cbbTipoAniversariante.Name = "cbbTipoAniversariante";
            this.cbbTipoAniversariante.Size = new System.Drawing.Size(125, 21);
            this.cbbTipoAniversariante.TabIndex = 18;
            this.cbbTipoAniversariante.DropDown += new System.EventHandler(this.cbbTipoEmitente_DropDown);
            this.cbbTipoAniversariante.SelectedIndexChanged += new System.EventHandler(this.cbbTipoAniversariante_SelectedIndexChanged);
            this.cbbTipoAniversariante.DropDownClosed += new System.EventHandler(this.cbbTipoEmitente_DropDownClosed);
            this.cbbTipoAniversariante.MouseLeave += new System.EventHandler(this.cbbTipoEmitente_MouseLeave);
            this.cbbTipoAniversariante.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoEmitente_MouseMove);
            // 
            // lblAte1
            // 
            this.lblAte1.AutoSize = true;
            this.lblAte1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte1.Location = new System.Drawing.Point(612, 21);
            this.lblAte1.Name = "lblAte1";
            this.lblAte1.Size = new System.Drawing.Size(26, 13);
            this.lblAte1.TabIndex = 16;
            this.lblAte1.Text = "Até:";
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(219, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(166, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Localizar aniversariante em:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(158, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 3;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnData
            // 
            this.rbtnData.AutoSize = true;
            this.rbtnData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnData.Location = new System.Drawing.Point(104, 19);
            this.rbtnData.Name = "rbtnData";
            this.rbtnData.Size = new System.Drawing.Size(48, 17);
            this.rbtnData.TabIndex = 2;
            this.rbtnData.TabStop = true;
            this.rbtnData.Text = "Data";
            this.rbtnData.UseVisualStyleBackColor = true;
            this.rbtnData.CheckedChanged += new System.EventHandler(this.rbtnData_CheckedChanged);
            this.rbtnData.MouseLeave += new System.EventHandler(this.rbtnData_MouseLeave);
            this.rbtnData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnData_MouseMove);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(644, 18);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 12;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyUp);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(528, 18);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 10;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // cbbAniversariante
            // 
            this.cbbAniversariante.BackColor = System.Drawing.Color.LightBlue;
            this.cbbAniversariante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAniversariante.DropDownWidth = 550;
            this.cbbAniversariante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAniversariante.FormattingEnabled = true;
            this.cbbAniversariante.Location = new System.Drawing.Point(522, 17);
            this.cbbAniversariante.Name = "cbbAniversariante";
            this.cbbAniversariante.Size = new System.Drawing.Size(200, 21);
            this.cbbAniversariante.TabIndex = 19;
            this.cbbAniversariante.DropDown += new System.EventHandler(this.cbbEmitenteDestinatario_DropDown);
            this.cbbAniversariante.DropDownClosed += new System.EventHandler(this.cbbEmitenteDestinatario_DropDownClosed);
            this.cbbAniversariante.MouseLeave += new System.EventHandler(this.cbbEmitenteDestinatario_MouseLeave);
            this.cbbAniversariante.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbEmitenteDestinatario_MouseMove);
            // 
            // dtAniversario
            // 
            this.dtAniversario.AllowUserToAddRows = false;
            this.dtAniversario.AllowUserToDeleteRows = false;
            this.dtAniversario.AllowUserToResizeRows = false;
            this.dtAniversario.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtAniversario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAniversario.Enabled = false;
            this.dtAniversario.Location = new System.Drawing.Point(24, 144);
            this.dtAniversario.MultiSelect = false;
            this.dtAniversario.Name = "dtAniversario";
            this.dtAniversario.ReadOnly = true;
            this.dtAniversario.RowHeadersVisible = false;
            this.dtAniversario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtAniversario.ShowCellErrors = false;
            this.dtAniversario.ShowCellToolTips = false;
            this.dtAniversario.ShowEditingIcon = false;
            this.dtAniversario.ShowRowErrors = false;
            this.dtAniversario.Size = new System.Drawing.Size(760, 249);
            this.dtAniversario.TabIndex = 231;
            this.dtAniversario.DataSourceChanged += new System.EventHandler(this.dtAniversario_DataSourceChanged);
            this.dtAniversario.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtAniversario_CellEnter);
            this.dtAniversario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtAniversario_CellFormatting);
            this.dtAniversario.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtAniversario_RowsAdded);
            this.dtAniversario.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtAniversario_RowsRemoved);
            this.dtAniversario.MouseLeave += new System.EventHandler(this.dtAniversario_MouseLeave);
            this.dtAniversario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtAniversario_MouseMove);
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibInterrogacao.Location = new System.Drawing.Point(676, 106);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 252;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(250, 235);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 253;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(240, 268);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 254;
            this.pgbProgresso.Visible = false;
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // pEnabled
            // 
            this.pEnabled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.pcibInterrogacao);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.pcibInterrogacao2);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.dtAniversario);
            this.pEnabled.Location = new System.Drawing.Point(-13, -39);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(812, 631);
            this.pEnabled.TabIndex = 255;
            // 
            // FrmRelAniversario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 483);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelAniversario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Aniversáriantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelAniversario_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelAniversario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelAniversario_KeyUp);
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAniversario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnCriarLembrete;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnEnviarSMS;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
        private System.Windows.Forms.ToolTip ttpAniversariante;
        private System.Windows.Forms.Button btnRelatorioPDF;
        private System.Windows.Forms.Button btnEnviarZAP;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnAniversariante;
        private System.Windows.Forms.ComboBox cbbTipoAniversariante;
        private System.Windows.Forms.Button btnSelecionarData1;
        private System.Windows.Forms.Label lblAte1;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.Button btnProcurarAniversariante;
        private System.Windows.Forms.ComboBox cbbAniversariante;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnData;
        private System.Windows.Forms.DataGridView dtAniversario;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Panel pEnabled;
    }
}